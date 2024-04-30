using MVCCrud.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Repository.Interface
{
    public interface IAdminsInterface
    {
        void RegisterAdmin(Admins newAdmin);
        Boolean DoesAdminExist(string email);
        Admins AuthenticUser(string login_email, string login_password);
    }
}
