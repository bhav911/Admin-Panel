using MVCCrud.Models.Context;
using MVCCrud.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Repository.Services
{
    public class AdminsServices : IAdminsInterface
    {
        private readonly CRUDdbEntities _context;

        public AdminsServices(CRUDdbEntities context)
        {
            _context = context;
        }

        public void RegisterAdmin(Admins newAdmin)
        {
            _context.Admins.Add(newAdmin);
            _context.SaveChanges();
        }

        public Boolean DoesAdminExist(String email)
        {
            return _context.Admins.FirstOrDefault(n => n.email == email) != null;
        }

        public Admins AuthenticUser(string login_email, string login_password)
        {
            Admins requestingUser = _context.Admins.FirstOrDefault(n => n.email == login_email);
            return requestingUser.adminPassword == login_password ? requestingUser : null;
        }
    }
}
