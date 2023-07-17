using EmployeeManagement.Core;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EmployeeManagement.DAL
{
    public class AddressTypeRepository
    {
        string connectionString;

        public AddressTypeRepository()
        {
            connectionString = "Data Source=LAPTOP-43MTCVGF;Initial Catalog=Employee management; Integrated Security=True; trustservercertificate=true";
        }

        //Get All

        public List<AddressType> GetAllAddressType()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                List<AddressType> addressTypelist = new List<AddressType>();
                string query = "Select * from [AddressType] ";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    AddressType addressType = new AddressType();
                    addressType.Id = Guid.Parse(dataReader["Id"].ToString());
                    addressType.AddressTypes = dataReader["AddressTypes"].ToString();

                    addressTypelist.Add(addressType);
                }
                cmd.Connection.Close();

                return addressTypelist;
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
        public Guid? AddAddressType (AddressType addressType)
        {
            SqlConnection conn = new SqlConnection (connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [AddressType] (Id, AddressTypes) Values (@Id, @AddressTypes)";

                cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("@AddressTypes", SqlDbType.VarChar).Value = addressType.AddressTypes;

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

        public AddressType? Search(AddressType addressType)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                AddressType? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query=string.Empty;
                               
                
                if (addressType != null)
                {
                    if (addressType.Id != null)
                    {                         
                        query = "Select * from [AddressType] Where Id=@Id";
                        //cmd.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = addressType.Id;
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "id",
                            Value = addressType.Id
                        });
                       

                    }
                    if(!string.IsNullOrEmpty(addressType.AddressTypes))
                    {
                        query = "Select * from AddressType Where";
                        query += " AddressTypes =@AddressTypes";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "addressTypes",
                            Value = addressType.AddressTypes
                        });
                    }
                }

               
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = query;
               
                foreach (SqlParameter param in parameters)
                {
                    cmd.Parameters.Add(param);
                }
                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while(dataReader.Read())
                {
                    returnValue = new AddressType();
                    returnValue.Id = Guid.Parse(dataReader["Id"].ToString());
                    returnValue.AddressTypes = dataReader["AddressTypes"].ToString();
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

        public AddressType? UpdateAddressType (AddressType addressType)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query =" update[AddressType] set AddressTypes = @AddressTypes where Id = @id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = addressType.Id;
                cmd.Parameters.Add("AddressTypes", SqlDbType.VarChar).Value = addressType.AddressTypes;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return addressType;
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

        public bool? DeleteAddressType(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                int rowafferted = 0;
                string query = " Delete from [AddressType] where id = @id ";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value =id;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText= query;

                cmd.Connection.Open ();
                rowafferted = cmd.ExecuteNonQuery ();
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
