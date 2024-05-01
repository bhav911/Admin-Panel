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
    public class HomeController : Controller
    {
        private readonly EmployeesServices _service = new EmployeesServices();
        public ActionResult ListOfEmployee(string name)
        {
            if (!TempData.ContainsKey("Name"))
            {
                TempData["Name"] = name;
            }
            List<Employees> EmployeeList = _service.GetAllEmployee();
            List<EmployeesModel> EmployeeModelList = ModelConverter.convertEmployeeListToEmployeeModelList(EmployeeList);
            return View(EmployeeModelList);
        }

        [HttpGet]
        public ActionResult EditEmployee()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult EditEmployee()
        //{
        //    return View();
        //}

        public ActionResult DeleteEmployee(int employeeID)
        {
            _service.DeleteEmployee(employeeID);
            return RedirectToAction("ListOfEmployee");
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(EmployeesModel newEmployeeDate)
        {
            Employees convertedEmployee = ModelConverter.convertEmployeeToEmployeeModel(newEmployeeDate);
            _service.AddEmployee(convertedEmployee);
            TempData["smessage"] = "Successfully Added New Employee";
            return RedirectToAction("AddEmployee");
        }
    }
}