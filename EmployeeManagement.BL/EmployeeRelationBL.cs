using EmployeeManagement.Core;
using EmployeeManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BL
{
    public class EmployeeRelationBL
    {
        EmployeeRelationRepository _repository;

        public EmployeeRelationBL(EmployeeRelationRepository repository)
        {
            _repository = repository;
        }

        //Get All

        public List<EmployeeRelation> GetAllEmployeeRelation()
        {
            return _repository.GetAllEmployeeRelation();
        }

        //Get

        public EmployeeRelation? Search(EmployeeRelation employeeRelation)
        {
            return _repository.Search(employeeRelation);
        }

        //Add
        public EmployeeRelation AddEmployeeRelation(EmployeeRelation employeeRelation)
        {
            var existingEmployeeRelation = Search(new EmployeeRelation() { Relation = employeeRelation.Relation });
            if(existingEmployeeRelation != null)
            {
                throw new Exception("please enter carrect relation name");
            }
            var id = _repository.AddEmployeeRelation(employeeRelation);

            EmployeeRelation? returnValue = null;
            if(id != null )
            {
                returnValue = new EmployeeRelation();
                returnValue = Search(new EmployeeRelation() { Id = employeeRelation.Id });
            }
            return returnValue;
        }

        //Update
        public EmployeeRelation? UpdateEmployeeRelation(EmployeeRelation employeeRelation)
        {
            var exiatingEmployeeRelation = Search(new EmployeeRelation() { Id = employeeRelation.Id });
            if( exiatingEmployeeRelation == null )
            {
                throw new Exception("please enter a new correct update id");
            }
            return _repository.UpdateEmployeeRelation(employeeRelation);
        }

        //Delete
        public bool? DeleteEmployeeRelation(Guid id)
        {
            return _repository.DeleteEmployeeRelation(id);
        }
    }
}
