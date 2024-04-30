using MVCCrud.Helpers.Helper;
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
        public ActionResult EmployeeList()
        {
            return View();
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

        [HttpPost]
        public ActionResult DeleteEmployee()
        {
            return View();
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmplyee()
        {
            return View();
        }
    }
}