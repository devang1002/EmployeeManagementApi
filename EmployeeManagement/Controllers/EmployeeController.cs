using EmployeeManagement.BL;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        EmployeeBL _bl;

        public EmployeeController(EmployeeBL bl)
        {
            _bl = bl;
        }

        [HttpGet]
        [Route("GetAll")]

        public List<Employee> GetAllEmployee()
        {
            return _bl.GetAllEmployee();
        }

        [HttpGet]
        public Employee? Get(Guid id)
        {
            return _bl.Search(new Employee() { Id = id });
        }

        [HttpPost]
        public Employee? AddEmployee(Employee employee)
        {
            return _bl.AddEmployee(employee);
        }

        [HttpPut]
        public Employee? UpdateEmployee(Employee employee)
        {
            return _bl.UpdateEmployee(employee);
        }

        [HttpDelete]

        public bool? DeleteEmployee(Guid id)
        {
            return _bl.DeleteEmployee(id);
        }

    }
}
