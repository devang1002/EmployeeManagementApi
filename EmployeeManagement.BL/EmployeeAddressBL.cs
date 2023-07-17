using EmployeeManagement.Core;
using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BL
{
    public class EmployeeAddressBL
    {
        EmployeeAddressRepository _repository;

        public EmployeeAddressBL(EmployeeAddressRepository repository)
        {
            _repository = repository;
        }
        //Get All

        public List<EmployeeAddress> GetAllEmployeeAddress()
        {
            return _repository.GetAllEmployeeAddress();
        }
        //Get

        public EmployeeAddress Search(EmployeeAddress employeeAddress)
        {
            return _repository.Search(employeeAddress);
        }
        //Add
        public EmployeeAddress? AddEmployeeAddress(EmployeeAddress employeeAddress)
        {
            var id = _repository.AddEmployeeAddress(employeeAddress);

            if(id != null)
            {
                employeeAddress.id = id;
            }
            return employeeAddress;
        }

        //Update

        public EmployeeAddress? UpdateEmployeeAddress(EmployeeAddress employeeAddress)
        {
            var existingEmployeeAddress = Search(new EmployeeAddress() { id = employeeAddress.id });
            if (existingEmployeeAddress == null)
            {
                throw new Exception("please enter correct id");
            }
            return _repository.UpdateEmployeeAddress(employeeAddress);
        }
        //Delete

        public bool? DeleteEmployeeAddress(Guid id)
        {
            return _repository.DeleteEmployeeAddress(id);
        }
    }
   
}
