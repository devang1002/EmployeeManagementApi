using EmployeeManagement.BL;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeRelationController : ControllerBase
    {
        EmployeeRelationBL _rl;

        public EmployeeRelationController(EmployeeRelationBL rl)
        {
            _rl = rl;
        }

        [HttpGet]
        [Route("Get All")]

        public List<EmployeeRelation> GetEmployeeRelations()
        {
            return _rl.GetAllEmployeeRelation();
        }

        [HttpGet]

        public EmployeeRelation? Get(Guid id)
        {
            return _rl.Search(new EmployeeRelation() { Id = id });
        }

        [HttpPost]
        public EmployeeRelation AddEmployeeRelation(EmployeeRelation employeeRelation)
        {
            return _rl.AddEmployeeRelation(employeeRelation);
        }

        [HttpPut]

        public EmployeeRelation? UpdateEmployeeRelation(EmployeeRelation employeeRelation)
        {
            return _rl.UpdateEmployeeRelation(employeeRelation);
        }

        [HttpDelete]

        public bool? DeleteEmployeeRelatio(Guid id)
        {
            return _rl.DeleteEmployeeRelation(id);
        }
    }
}
