using MVCCrud.Models.Context;
using MVCCrud.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Repository.Services
{
    public class EmployeesServices : IEmployeesInterface
    {
        private readonly CRUDdbEntities _context = new CRUDdbEntities();

        public List<Employees> GetAllEmployee()
        {
            return _context.Employees.ToList();
        }

        public Employees GetEmployee(int employeeID)
        {
            Employees result = _context.Employees.FirstOrDefault(e => e.employeeID == employeeID);
            return result;
        }

        public void UpdateEmployee(Employees updatedEmpData)
        {
            int employeeID = updatedEmpData.employeeID;
            Employees empToUpd = GetEmployee(employeeID);
            empToUpd.firstname = updatedEmpData.firstname;
            empToUpd.lastname = updatedEmpData.lastname;
            empToUpd.phoneNumber = updatedEmpData.phoneNumber;
            empToUpd.gender = updatedEmpData.gender;
            empToUpd.emp_role = updatedEmpData.emp_role;
            empToUpd.emp_address = updatedEmpData.emp_address;
            empToUpd.email = updatedEmpData.email;
            _context.SaveChanges();
        }
        public void DeleteEmployee(int employeeID)
        {
            Employees empToDel = GetEmployee(employeeID);
            _context.Employees.Remove(empToDel);
            _context.SaveChanges();
        }

        public void AddEmployee(Employees newEmpData)
        {
                _context.Employees.Add(newEmpData);
                _context.SaveChanges();            
        }
    }
}
