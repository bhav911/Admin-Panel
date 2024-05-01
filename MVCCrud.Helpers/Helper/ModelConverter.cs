using MVCCrud.Models.Context;
using MVCCrud.Models.CustomModel;
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

        public static List<EmployeesModel> convertEmployeeListToEmployeeModelList(List<Employees> EmployeesList)
        {
            List<EmployeesModel> result = new List<EmployeesModel>();

            foreach(Employees emp in EmployeesList)
            {
                EmployeesModel temp = new EmployeesModel()
                {
                    firstname = emp.firstname,
                    lastname = emp.lastname,
                    emp_address = emp.emp_address,
                    email = emp.email,
                    emp_role = emp.emp_role,
                    gender = emp.gender == "M" ? "Male" : emp.gender == "F" ? "Female" : "Other",
                    phoneNumber = emp.phoneNumber,
                    employeeID = emp.employeeID
                };
                result.Add(temp);
            }

            return result;
        }

        public static Employees convertEmployeeToEmployeeModel(EmployeesModel oldEmployee)
        {
            Employees newEmployee = new Employees()
            {
                firstname = oldEmployee.firstname,
                lastname = oldEmployee.lastname,
                emp_address = oldEmployee.emp_address,
                email = oldEmployee.email,
                emp_role = oldEmployee.emp_role,
                gender = oldEmployee.gender == "Male" ? "M" : oldEmployee.gender == "Female" ? "F" : "O",
                phoneNumber = oldEmployee.phoneNumber,
            };
            return newEmployee;
        }
    }
}
