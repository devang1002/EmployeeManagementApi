using EmployeeManagement.BL;
using EmployeeManagement.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AddressTypeController : ControllerBase
    {
        AddressTypeBL _al;

        public AddressTypeController(AddressTypeBL al)
        {
            _al = al;
        }

        [HttpGet]
        [Route("GetAll")]

        public List<AddressType> GetAddresses()
        {
            return _al.GetAllAddressType();
        }

        [HttpGet]

        public AddressType? Get(Guid id)
        {
            return _al.Search(new AddressType() { Id= id});
        }

        [HttpPost]

        public AddressType AddAddressType(AddressType addressType)
        {
            return _al.AddAddressType(addressType);
        }

        [HttpPut]

        public AddressType? UpdateAddressType(AddressType addressType)
        {
            return _al.UpdateAddressType(addressType);
        }

        [HttpDelete]
        public bool? DeleteAddressType(Guid id)
        {
            return _al.DeleteAddressType(id);
        }
    }
}
