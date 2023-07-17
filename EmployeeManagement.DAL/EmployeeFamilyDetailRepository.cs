using EmployeeManagement.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class EmployeeFamilyDetailRepository
    {
        string connectionString;

        public EmployeeFamilyDetailRepository()
        {
            connectionString = "Data Source=LAPTOP-43MTCVGF;Initial Catalog=Employee management; Integrated Security=True; trustservercertificate=true";
        }

        //Get All

        public List<EmployeeFamilyDetail> GetAllEmployeeFamilyDetail()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                List<EmployeeFamilyDetail> employeeFamilyDetailslist = new List<EmployeeFamilyDetail>();
                string query = "Select [Employee Family Detail].Id,[Employee Family Detail].EmployeeId,[Employee Family Detail].FirstName,[Employee Family Detail].LastName,[Employee Family Detail].MiddleName,[Employee Family Detail].DOB,[Employee Family Detail].RelationId,[Employee].FirstName as EmployeeName,[Employee Relation].Relation as RelationName" +
                    " from [Employee Family Detail]" +
                    " inner join [Employee] on [Employee Family Detail].EmployeeId = [Employee].id" +
                    " inner join [Employee Relation] on [Employee Family Detail].RelationId = [Employee Relation].Id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeeFamilyDetail employeeFamilyDetail = new EmployeeFamilyDetail();
                    employeeFamilyDetail.Id = Guid.Parse(dataReader["id"].ToString());
                    employeeFamilyDetail.EmployeeId = Guid.Parse(dataReader["EmployeeId"].ToString());
                    employeeFamilyDetail.FirstName = (dataReader["FirstName"].ToString());
                    employeeFamilyDetail.MiddleName = (dataReader["MiddleName"].ToString());
                    employeeFamilyDetail.LastName = (dataReader["LastName"].ToString());
                    employeeFamilyDetail.DOB = Convert.ToDateTime(dataReader["DOB"].ToString());
                    employeeFamilyDetail.RelationId = Guid.Parse(dataReader["RelationId"].ToString());
                    employeeFamilyDetail.EmployeeName = (dataReader["EmployeeName"].ToString());
                    employeeFamilyDetail.RelationName = (dataReader["RelationName"].ToString());

                    employeeFamilyDetailslist.Add(employeeFamilyDetail);
                }
                cmd.Connection.Close();

                return employeeFamilyDetailslist;
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

        //Add Post
        public Guid? AddEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [Employee Family Detail] (id, EmployeeId, FirstName, MiddleName, LastName, DOB, RelationId) Values (@id, @EmployeeId, @FirstName, @MiddleName, @LastName, @DOB, @RelationId)";

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = employeeFamilyDetail.EmployeeId;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employeeFamilyDetail.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employeeFamilyDetail.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employeeFamilyDetail.LastName;
                cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("RelationId", SqlDbType.UniqueIdentifier).Value = employeeFamilyDetail.RelationId;

                cmd.Connection.Open();
                var result= cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (result > 0)
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

        public EmployeeFamilyDetail? Search(EmployeeFamilyDetail employeeFamilyDetail)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                EmployeeFamilyDetail? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select [Employee Family Detail].Id,[Employee Family Detail].EmployeeId,[Employee Family Detail].FirstName,[Employee Family Detail].LastName,[Employee Family Detail].MiddleName,[Employee Family Detail].DOB,[Employee Family Detail].RelationId,[Employee].FirstName as EmployeeName,[Employee Relation].Relation as RelationName" +
                    " from [Employee Family Detail]" +
                    " inner join [Employee] on [Employee Family Detail].EmployeeId = [Employee].id" +
                    " inner join [Employee Relation] on [Employee Family Detail].RelationId = [Employee Relation].Id  ";

                if(employeeFamilyDetail != null)
                {
                    if(employeeFamilyDetail.Id != null)
                    {
                        query += " And [Employee Family Detail].id = @id ";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "id",
                            Value = employeeFamilyDetail.Id
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
                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    returnValue = new EmployeeFamilyDetail();
                    returnValue.Id = Guid.Parse(dataReader["id"].ToString());
                    returnValue.EmployeeId = Guid.Parse(dataReader["EmployeeId"].ToString());
                    returnValue.FirstName = (dataReader["FirstName"].ToString());
                    returnValue.MiddleName = (dataReader["MiddleName"].ToString());
                    returnValue.LastName = (dataReader["LastName"].ToString());
                    returnValue.DOB = Convert.ToDateTime(dataReader["DOB"].ToString());
                    returnValue.RelationId = Guid.Parse(dataReader["RelationId"].ToString());
                    returnValue.EmployeeName = (dataReader["EmployeeName"].ToString());
                    returnValue.RelationName = (dataReader["RelationName"].ToString());
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

        //update

        public EmployeeFamilyDetail? UpdateEmployeeFamilyDetail(EmployeeFamilyDetail employeeFamilyDetail)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query = "Update [Employee Family Detail] SET EmployeeId =@EmployeeId, FirstName =@FirstName, MiddleName =@MiddleName, LastName =@LastName, DOB =@DOB, RelationId =@RelationId Where id =@id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = employeeFamilyDetail.Id;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = employeeFamilyDetail.EmployeeId;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employeeFamilyDetail.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employeeFamilyDetail.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employeeFamilyDetail.LastName;
                cmd.Parameters.Add("DOB", SqlDbType.DateTime).Value = DateTime.Now;
                cmd.Parameters.Add("RelationId", SqlDbType.UniqueIdentifier).Value = employeeFamilyDetail.RelationId;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employeeFamilyDetail;
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
        public bool? DelateEmployeeFamilyDetail(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                int rowafferted = 0;
                string query = "Delete from [Employee Family Detail] where id =@id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value=id;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                rowafferted = cmd.ExecuteNonQuery();
                cmd.Connection.Close() ;

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
