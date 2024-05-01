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
        Employees GetEmployee(int employeeID);
        List<Employees> GetAllEmployee();
        void UpdateEmployee(Employees updatedEmpData);
        void DeleteEmployee(int employeeID);
        void AddEmployee(Employees newEmpData);
    }
}
