using MVCCrud.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Helpers.Helper
{
    public class ModelConverter
    {
        public static Admins convertModalToAdmin(AdminsModel adminModel)
        {
            Admins newAdmin = new Admins()
            {
                firstname = adminModel.firstname,
                lastname = adminModel.lastname,
                email = adminModel.email,
                phoneNumber = adminModel.phoneNumber,
                adminPassword = adminModel.og_pass
            };

            return newAdmin;
        }
    }
}
