using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCCrud.Models.CustomModel
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public List<EmployeesModel> ListOfEmployee { get; set; }
    }
}
