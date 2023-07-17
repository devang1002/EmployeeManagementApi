using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core
{
    public class EmployeeAddress
    {
        public Guid? id {  get; set; }
        public string Address { get; set; } = string.Empty;
        public Guid EmployeeId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Pincode { get; set; } = string.Empty;
        public string EmployeeName { get; set; } = string.Empty;
        public string TypeOfAddress { get; set; } = string.Empty;
        public Guid AddressTypeId { get; set; }
    }
}
