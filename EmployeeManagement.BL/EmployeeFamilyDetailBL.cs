using EmployeeManagement.Core;
using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BL
{
    public class EmployeeFamilyDetailBL
    {
        EmployeeFamilyDetailRepository _repository;

        public EmployeeFamilyDetailBL(EmployeeFamilyDetailRepository repository)
        {
            _repository = repository;
        }
        //Get All

        public List<EmployeeFamilyDetail> GetAllEmployeeFamilyDetail()
        {
            return _repository.GetAllEmployeeFamilyDetail();
        }

        //Get

        public EmployeeFamilyDetail? Search(EmployeeFamilyDetail employeeFamilyDetail)
        {
            return _repository.Search(employeeFamilyDetail);
        }

        //Add
        public EmployeeFamilyDetail AddEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            var id = _repository.AddEmployeeFamilyDetail(employeeFamilyDetail);
            if (id != null)
            {
                employeeFamilyDetail.Id = id;
            }
            return employeeFamilyDetail;
        }

        //Update

        public EmployeeFamilyDetail? UpdateEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            var existingEmployeeFamilyDetail = Search (new EmployeeFamilyDetail() { Id = employeeFamilyDetail.Id });
            if (existingEmployeeFamilyDetail == null)
            {
                throw new Exception("plese enter a correct update id");
            }

            return _repository.UpdateEmployeeFamilyDetail(employeeFamilyDetail);
        }

        //Delete

        public bool? DeleteEmployeeFamilyDetail(Guid id)
        {
            return _repository.DelateEmployeeFamilyDetail(id);
        }
    }
}
