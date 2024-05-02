using MVCCrud.Helpers.Helper;
using MVCCrud.Models.Context;
using MVCCrud.Models.CustomModel;
using MVCCrud.Repository.Services;
using System;
using System.Collections.Generic;
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
        public ActionResult ListOfEmployee(string name)
        {
            throw new Exception();
            if (!TempData.ContainsKey("Name"))
            {
                TempData["Name"] = name;
            }
            List<Employees> EmployeeList = _service.GetAllEmployee();
            List<EmployeesModel> EmployeeModelList = ModelConverter.convertEmployeeListToEmployeeModelList(EmployeeList);
            return View(EmployeeModelList);
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
            Employees convertedEmployee = ModelConverter.convertEmployeeModelToEmployee(updatedEmployee);
            _service.UpdateEmployee(convertedEmployee);
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
            Employees convertedEmployee = ModelConverter.convertEmployeeModelToEmployee(newEmployeeDate);
            _service.AddEmployee(convertedEmployee);
            TempData["smessage"] = "Successfully Added New Employee";
            return RedirectToAction("AddEmployee");
        }

        public ActionResult PageNotFound()
        {
            return View("~/Views/Shared/Error");
        }
    }
}