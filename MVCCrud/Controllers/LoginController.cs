using MVCCrud.Helpers.Helper;
using MVCCrud.Models.Context;
using MVCCrud.Repository.Services;
using MVCCrud.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCrud.Controllers
{
    public class LoginController : Controller
    {
        private readonly AdminsServices _service;

        public LoginController(AdminsServices service)
        {
            _service = service;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(string login_email, string login_password)
        {
            Admins authenticAdmin = _service.AuthenticUser(login_email, login_password);
            if (authenticAdmin != null)
            {
                AdminSession.UserID = authenticAdmin.adminID;
                AdminSession.UserName = authenticAdmin.firstname + authenticAdmin.lastname;
                TempData["smessage"] = "Log In Successfull";
                return RedirectToAction("ListOfEmployee", "Home", new { name = $"{authenticAdmin.firstname} {authenticAdmin.lastname}" });
            }
            else
            {
                TempData["emessage"] = "Incorrect Login Credentials";
                return View();
            }
        }

        public ActionResult SignOut()
        {
            HttpContext.Session.Clear();
            TempData.Clear();
            return Redirect("SignIn");
        }

        public ActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignUp(AdminsModel newAdmin)
        {
            if (ModelState.IsValid)
            {
                if (_service.DoesAdminExist(newAdmin.email))
                {
                    TempData["wmessage"] = "Admin is already registered";
                    return View();
                }
                Admins newConvertedAdmin = ModelConverter.convertModalToAdmin(newAdmin);
                _service.RegisterAdmin(newConvertedAdmin);

                TempData["smessage"] = "Admin Registered Successfully";
                return RedirectToAction("SignIn");
            }

            TempData["emessage"] = "Form contains invalid fields";
            return View();
        }


        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}