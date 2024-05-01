using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Models.CustomModel
{
    public class EmployeesModel
    {
        public int employeeID { get; set; }

        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Invalid Firstname")] 
        [Required(ErrorMessage = "Can't Leave field Empty")] 
        public string firstname { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid Lastname")] 
        [Required(ErrorMessage = "Can't Leave field Empty")] 
        public string lastname { get; set; }

        [Display(Name = "Role")]
        [RegularExpression(@"^[a-zA-Z]*$", ErrorMessage = "Invalid Role")]
        [Required(ErrorMessage = "Can't Leave field Empty")]
        public string emp_role { get; set; }

        [Display(Name = "Contact Number")]
        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Required(ErrorMessage = "Can't Leave field Empty")]
        public string phoneNumber { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Required(ErrorMessage = "Can't Leave field Empty")]
        public string email { get; set; }

        [Display(Name = "Address")]
        [Required(ErrorMessage = "Can't Leave field Empty")]
        public string emp_address { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }
    }
}
