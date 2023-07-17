using EmployeeManagement.Core;
using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BL
{
    public class AddressTypeBL
    {
        AddressTypeRepository _repository;

        public AddressTypeBL(AddressTypeRepository repository)
        {
            _repository = repository;
        }

        //Get All

        public List<AddressType> GetAllAddressType()
        {
            return _repository.GetAllAddressType();
        }
        //Get

        public AddressType? Search(AddressType addressType)
        {
            return _repository.Search(addressType);
        }
        //Add
        public AddressType AddAddressType (AddressType addressType)
        {
            var existingAddressType = Search(new AddressType() { AddressTypes = addressType.AddressTypes });
            if(existingAddressType != null)
            {
                throw new Exception("please enter carrect addressType");
            }
            var id= _repository.AddAddressType(addressType);
            AddressType? returnValue = null;
            if(id != null)
            {
                returnValue = new AddressType();
                returnValue = Search(new AddressType() { Id = addressType.Id });
            }
            return addressType;
        }

        //Update

        public AddressType? UpdateAddressType (AddressType addressType)
        {
            var existingAddressType = Search(new AddressType() { Id = addressType.Id });
            if(existingAddressType == null)
            {
                throw new Exception("please enter your correct update id");
            }

            return _repository.UpdateAddressType (addressType);
        }

        //Delete 

        public bool? DeleteAddressType (Guid id)
        {
            return _repository.DeleteAddressType (id);
        }
    }
}
