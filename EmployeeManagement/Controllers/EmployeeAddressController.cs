using EmployeeManagement.BL;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAddressController : ControllerBase
    {
        EmployeeAddressBL _el;

        public EmployeeAddressController(EmployeeAddressBL el)
        {
            _el = el;
        }
        [HttpGet]
        [Route("GetAll")]

        public List<EmployeeAddress> GetAll()
        {
            return _el.GetAllEmployeeAddress();
        }

        [HttpGet]

        public EmployeeAddress Get(Guid id)
        {
            return _el.Search(new EmployeeAddress() { id = id });
        }
        [HttpPost]
        public EmployeeAddress? AddEmployeeAddress(EmployeeAddress employeeAddress)
        {
            return _el.AddEmployeeAddress(employeeAddress);
        }

        [HttpPut]

        public EmployeeAddress? UpdateEmployeeAddress(EmployeeAddress employeeAddress)
        {
            return _el.UpdateEmployeeAddress(employeeAddress);
        }

        [HttpDelete]

        public bool? DeleteEmployeeAddress(Guid id)
        {
            return _el.DeleteEmployeeAddress(id);
        }
    }
}
