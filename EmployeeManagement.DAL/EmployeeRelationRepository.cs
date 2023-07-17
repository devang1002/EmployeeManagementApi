using EmployeeManagement.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class EmployeeRelationRepository
    {
        string connectionString;

        public EmployeeRelationRepository()
        {
            connectionString = "Data Source=LAPTOP-43MTCVGF;Initial Catalog=Employee management; Integrated Security=True; trustservercertificate=true";
        }

        //Get All

        public List<EmployeeRelation> GetAllEmployeeRelation()
        {
            SqlConnection Conn = new SqlConnection(connectionString);

            try
            {
                List<EmployeeRelation>employeeRelationlist = new List<EmployeeRelation>();
                string query = "Select * from [Employee Relation] ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = Conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeeRelation enployeeRelation = new EmployeeRelation();
                    enployeeRelation.Id = Guid.Parse(dataReader["id"].ToString());
                    enployeeRelation.Relation = (dataReader["Relation"].ToString());

                    employeeRelationlist.Add(enployeeRelation);
                }
                cmd.Connection.Close();

                return employeeRelationlist;
               
            }
            catch (Exception)
            {

                throw;
            }
        }
        //Add Post
        public Guid? AddEmployeeRelation(EmployeeRelation employeeRelation)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [Employee Relation] (id, Relation) Values (@id, @Relation)";

                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Relation", SqlDbType.VarChar).Value = employeeRelation.Relation;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if(result > 0)
                   return id;
                else
                    return null;
                
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        //Get

        public EmployeeRelation? Search(EmployeeRelation employeeRelation)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                EmployeeRelation? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = string.Empty;
                if(employeeRelation != null)
                {
                    if(employeeRelation.Id != null)
                    {
                        query = "Select * from [Employee Relation] Where Id =@id ";                        
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "id",
                            Value = employeeRelation.Id
                        });
                    }
                    if(!string.IsNullOrEmpty(employeeRelation.Relation))
                    {
                        query = " Select * from [Employee Relation] where Relation = @Relation";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "relation",
                            Value = employeeRelation.Relation
                        });

                    }
                }

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }

                cmd.Connection.Open ();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    returnValue = new EmployeeRelation();
                    returnValue.Id = Guid.Parse(dataReader["id"].ToString());
                    returnValue.Relation = (dataReader["Relation"].ToString());
                    break;
                }
                cmd.Connection.Close();

                return returnValue;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        //Update

        public EmployeeRelation? UpdateEmployeeRelation(EmployeeRelation employeeRelation)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query = "Update [Employee Relation] SET Relation =@Relation Where id =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType= System.Data.CommandType.Text;
                cmd.CommandText= query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = employeeRelation.Id;
                cmd.Parameters.Add("Relation", SqlDbType.VarChar).Value = employeeRelation.Relation;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employeeRelation;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }

        //Delete

        public bool? DeleteEmployeeRelation(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                int rowafferted = 0;
                string query = "Delete from [Employee Relation] where id =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Connection= conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText= query;

                cmd.Connection.Open();
                rowafferted = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return rowafferted > 0 ? true : false;


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (conn.State != System.Data.ConnectionState.Closed)
                {
                    conn.Close();
                }
            }
        }
    }
}
