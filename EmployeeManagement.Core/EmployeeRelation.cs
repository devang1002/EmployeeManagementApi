using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Core
{
    public class EmployeeRelation
    {
        public Guid? Id { get; set; }
        public string Relation { get; set; } =string.Empty;
    }
}
