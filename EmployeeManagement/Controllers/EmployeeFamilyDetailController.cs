using EmployeeManagement.BL;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeFamilyDetailController : ControllerBase
    {
        EmployeeFamilyDetailBL _dl;

        public EmployeeFamilyDetailController(EmployeeFamilyDetailBL dl)
        {
            _dl = dl;
        }
        [HttpGet]
        [Route("GetAll")]

        public List<EmployeeFamilyDetail> GetAllEmployeeFamilyDetail()
        {
            return _dl.GetAllEmployeeFamilyDetail();
        }

        [HttpGet]

        public EmployeeFamilyDetail? Get(Guid id)
        {
            return _dl.Search(new EmployeeFamilyDetail() { Id = id });
        }

        [HttpPost]

        public EmployeeFamilyDetail? AddEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            return _dl.AddEmployeeFamilyDetail(employeeFamilyDetail);
        }

        [HttpPut]

        public EmployeeFamilyDetail? UpdateEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            return _dl.UpdateEmployeeFamilyDetail(employeeFamilyDetail);
        }

        [HttpDelete]

        public bool? DeleteEmployeeFamilyDetail(Guid id)
        {
            return _dl.DeleteEmployeeFamilyDetail(id);
        }
    }
}
