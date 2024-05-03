using MVCCrud.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Repository.Interface
{
    interface IEmployeesInterface
    {
        int getEmployeeCount();
        Employees GetEmployee(int employeeID);
        List<Employees> GetAllEmployee();
        void UpdateEmployee(Employees updatedEmpData, Employees_Profile emp_image);
        void DeleteEmployee(int employeeID);
        void AddEmployee(Employees newEmpData, Employees_Profile emp_image);
    }
}
