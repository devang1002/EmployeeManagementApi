using EmployeeManagement.Core;
using EmployeeManagement.DAL;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeManagement.BL
{
    public class EmployeeBL
    {
        EmployeeRepository _repository;

        public EmployeeBL(EmployeeRepository repository)
        {
            _repository = repository;
        }
        //Get All

        public List<Employee> GetAllEmployee()
        {
            return _repository.GetAllEmployee();
        }
        //Get
        public Employee? Search(Employee employee)
        {
            return _repository.Search(employee);
        }

        //Add
        public Employee AddEmployee(Employee employee)
        {

            var existingemployee = Search(new Employee() { Email = employee.Email });
            if (existingemployee != null)
            {
                throw new Exception("Employee Already Exist");
            }
         

            var id = _repository.AddEmployee(employee);
            
            if (id != null)
            {
                employee.Id = id;
            }
            return employee;
        }

        //Update
        public  Employee? UpdateEmployee(Employee employee)
        {
            var existingEmployee = Search(new Employee() { Id = employee.Id });
            if(existingEmployee == null)
            {
                throw new Exception("please enter a correct id for update employee");
            }
            return _repository.UpdateEmployee(employee);
        }

        //Delete

        public bool? DeleteEmployee(Guid id)
        {
            return _repository.DeleteEmployee(id);
        }
    }
}