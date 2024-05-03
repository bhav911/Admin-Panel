using MVCCrud.Helpers.Helper;
using MVCCrud.Models.Context;
using MVCCrud.Models.CustomModel;
using MVCCrud.Repository.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    [CustomAuthorizeAttribute]
    [CustomHandleErrorAttribute]
    public class HomeController : Controller
    {
        private readonly EmployeesServices _service = new EmployeesServices();

        public ActionResult EntryAction(string name)
        {
            if (!TempData.ContainsKey("Name"))
            {
                TempData["Name"] = name;
            }
            return RedirectToAction("ListOfEmployee");
        }

        public ActionResult ListOfEmployee()
        {
            PaginationModel result = GetRequestedPage(1);
            return View(result);
        }

        [HttpPost]
        public ActionResult ListOfEmployee(int pageNumber)
        {
            PaginationModel result = GetRequestedPage(pageNumber);
            return View(result);
        }

        [HttpGet]
        public ActionResult EditEmployee(int employeeID)
        {
            Employees Employee = _service.GetEmployee(employeeID);
            EmployeesModel EmployeeModel = ModelConverter.convertEmployeeToEmployeeModel(Employee);
            return View("AddEmployee", EmployeeModel);
        }

        [HttpPost]
        public ActionResult EditEmployee(EmployeesModel updatedEmployee)
        {
            Employees_Profile emp_image = new Employees_Profile();
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase file = Request.Files[0];
                string a = ConvertToStringPhoto(file);
                emp_image.imageData = a;
            }
            Employees convertedEmployee = ModelConverter.convertEmployeeModelToEmployee(updatedEmployee);
            _service.UpdateEmployee(convertedEmployee, emp_image);
            TempData["smessage"] = "Successfully Updated Employee Details";
            return RedirectToAction("AddEmployee");
        }

        public ActionResult DeleteEmployee(int employeeID)
        {
            _service.DeleteEmployee(employeeID);
            TempData["wmessage"] = "Deleted Employee Successfully";
            return RedirectToAction("ListOfEmployee");
        }

        public ActionResult AddEmployee()
        {
            EmployeesModel temp = new EmployeesModel();
            return View(temp);
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeesModel newEmployeeDate)
        {
            if (ModelState.IsValid)
            {
                Employees_Profile emp_image = new Employees_Profile();
                if(Request.Files.Count > 0)
                {
                    HttpPostedFileBase file = Request.Files[0];
                    string a = ConvertToStringPhoto(file);
                    emp_image.imageData = a;
                }
                Employees convertedEmployee = ModelConverter.convertEmployeeModelToEmployee(newEmployeeDate);
                _service.AddEmployee(convertedEmployee, emp_image);
                TempData["smessage"] = "Successfully Added New Employee";
                return RedirectToAction("AddEmployee");
            }
            return View();
        }

        [NonAction]
        public string ConvertToStringPhoto(HttpPostedFileBase file)
        {
            if (file.ContentLength <= 0)
                return null;
            var images = new Byte[file.ContentLength - 1];
            file.InputStream.Read(images, 0, images.Length);
            var base64String = Convert.ToBase64String(images, 0, images.Length);
            return base64String;
        }

        public ActionResult PageNotFound()
        {
            return View("~/Views/Shared/Error");
        }

        [NonAction]
        private PaginationModel GetRequestedPage(int pageNumber)
        {
            PaginationModel currentPage = new PaginationModel();

            int maxRecord = 5;

            List<Employees> allEmployee = _service.GetAllEmployee();
            List<EmployeesModel> currentList = ModelConverter.convertEmployeeListToEmployeeModelList(allEmployee).Skip((pageNumber - 1) * maxRecord).Take(maxRecord).ToList();

            int countOfRecords = _service.getEmployeeCount();

            decimal intermediatePageCount = countOfRecords / (decimal)(maxRecord);

            currentPage.TotalPage = Convert.ToInt16(Math.Ceiling(intermediatePageCount));
            currentPage.ListOfEmployee = currentList;
            currentPage.CurrentPage = pageNumber;
            return currentPage;
        }
    }
}