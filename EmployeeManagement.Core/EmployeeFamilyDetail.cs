using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core
{
    public class EmployeeFamilyDetail
    {
        public Guid? Id { get; set; }
        public Guid EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string RelationName { get; set; } = string.Empty;
        public DateTime DOB { get; set; }
        public Guid RelationId { get; set; }
    }
}
