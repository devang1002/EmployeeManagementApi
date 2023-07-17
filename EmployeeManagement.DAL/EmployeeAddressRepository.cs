using EmployeeManagement.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.DAL
{
    public class EmployeeAddressRepository
    {
        string connectionString;

        public EmployeeAddressRepository()
        {
            connectionString = "Data Source=LAPTOP-43MTCVGF; Initial Catalog=Employee management; Integrated Security=True; trustservercertificate=true";
        }

        //Get All

        public List<EmployeeAddress> GetAllEmployeeAddress()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                List<EmployeeAddress> employeeAddresseslist = new List<EmployeeAddress>();
                string query = "Select [Employee Address].id,[Employee Address].Address,[Employee Address].EmployeeId,[Employee Address].City,[Employee Address].State,[Employee Address].Country,[Employee Address].Pincode,[Employee Address].AddressTypeId,[Employee].FirstName as EmployeeName,[AddressType].AddressTypes as TypeOfAddress " +
                   "from [Employee Address]" +
                   " inner join [Employee] on [Employee Address].EmployeeId = [Employee].id" +
                   " inner join [AddressType] on [Employee Address].AddressTypeId = [AddressType].id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    EmployeeAddress employeeAddress = new EmployeeAddress();
                    //employeeAddress = new EmployeeAddress();
                    employeeAddress.id = Guid.Parse(dataReader["id"].ToString());
                    employeeAddress.Address = dataReader["Address"].ToString();
                    employeeAddress.EmployeeId = Guid.Parse(dataReader["EmployeeId"].ToString());
                    employeeAddress.City = dataReader["City"].ToString();
                    employeeAddress.State = dataReader["State"].ToString();
                    employeeAddress.Country = dataReader["Country"].ToString();
                    employeeAddress.Pincode = dataReader["Pincode"].ToString();
                    employeeAddress.AddressTypeId = Guid.Parse(dataReader["AddressTypeId"].ToString());
                    employeeAddress.EmployeeName = dataReader["EmployeeName"].ToString();
                    employeeAddress.TypeOfAddress = dataReader["TypeOfAddress"].ToString();

                    employeeAddresseslist.Add(employeeAddress);
                   
                }
                cmd.Connection.Close();

                return employeeAddresseslist;
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
        public Guid? AddEmployeeAddress(EmployeeAddress employeeAddress)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [Employee Address] (id, Address, EmployeeId, City, State, Country, Pincode, AddressTypeId) Values (@id, @Address,@EmployeeId, @City, @State, @Country, @Pincode, @AddressTypeId)";

                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("Address", SqlDbType.VarChar).Value = employeeAddress.Address;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = employeeAddress.EmployeeId;
                cmd.Parameters.Add("City", SqlDbType.VarChar).Value = employeeAddress.City;
                cmd.Parameters.Add("State", SqlDbType.VarChar).Value = employeeAddress.State;
                cmd.Parameters.Add("Country", SqlDbType.VarChar).Value = employeeAddress.Country;
                cmd.Parameters.Add("Pincode", SqlDbType.VarChar).Value = employeeAddress.Pincode;
                cmd.Parameters.Add("AddressTypeId", SqlDbType.UniqueIdentifier).Value = employeeAddress.AddressTypeId;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
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

        public EmployeeAddress Search(EmployeeAddress employeeAddress)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                EmployeeAddress? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = "Select [Employee Address].id,[Employee Address].Address,[Employee Address].EmployeeId,[Employee Address].City,[Employee Address].State,[Employee Address].Country,[Employee Address].Pincode,[Employee Address].AddressTypeId,[Employee].FirstName as EmployeeName,[AddressType].AddressTypes as TypeOfAddress "+
                    "from [Employee Address]" +
                    " inner join [Employee] on [Employee Address].EmployeeId = [Employee].id" +
                    " inner join [AddressType] on [Employee Address].AddressTypeId = [AddressType].id And [Employee Address].id = @id";
                if(employeeAddress != null)
                {
                    if(employeeAddress.id != null)
                    {
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "id",
                            Value = employeeAddress.id
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
                    returnValue = new EmployeeAddress();
                    returnValue.id = Guid.Parse(dataReader["id"].ToString());
                    returnValue.Address = dataReader["Address"].ToString();
                    returnValue.EmployeeId = Guid.Parse (dataReader["EmployeeId"].ToString());
                    returnValue.City = dataReader["City"].ToString();
                    returnValue.State = dataReader["State"].ToString();
                    returnValue.Country = dataReader["Country"].ToString();
                    returnValue.Pincode = dataReader["Pincode"].ToString();
                    returnValue.AddressTypeId = Guid.Parse (dataReader["AddressTypeId"].ToString());
                    returnValue.EmployeeName = dataReader["EmployeeName"].ToString();
                    returnValue.TypeOfAddress = dataReader["TypeOfAddress"].ToString();
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

        public EmployeeAddress? UpdateEmployeeAddress(EmployeeAddress employeeAddress)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query = "Update [Employee Address] SET  Address = @Address, State= @State, City =@City, Country =@Country, Pincode =@Pincode,AddressTypeId =@AddressTypeId Where id = @id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = employeeAddress.id;
                cmd.Parameters.Add("Address", SqlDbType.VarChar).Value = employeeAddress.Address;
                cmd.Parameters.Add("EmployeeId", SqlDbType.UniqueIdentifier).Value = employeeAddress.EmployeeId;
                cmd.Parameters.Add("City", SqlDbType.VarChar).Value = employeeAddress.City;
                cmd.Parameters.Add("State", SqlDbType.VarChar).Value = employeeAddress.State;
                cmd.Parameters.Add("Country", SqlDbType.VarChar).Value = employeeAddress.Country;
                cmd.Parameters.Add("Pincode", SqlDbType.VarChar).Value = employeeAddress.Pincode;
                cmd.Parameters.Add("AddressTypeId", SqlDbType.UniqueIdentifier).Value = employeeAddress.AddressTypeId;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employeeAddress;

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

        public bool? DeleteEmployeeAddress(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                int rowafferted = 0;
                string query = "Delete from [Employee Address] where id =@id";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value=id;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

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
