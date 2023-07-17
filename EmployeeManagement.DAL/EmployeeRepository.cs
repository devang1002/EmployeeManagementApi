using EmployeeManagement.Core;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Reflection.Metadata;

namespace EmployeeManagement.DAL
{
    public class EmployeeRepository
    {
        string connectionString;
        public EmployeeRepository()
        {
            connectionString = "Data Source=LAPTOP-43MTCVGF;Initial Catalog=Employee management; Integrated Security=True; trustservercertificate=true";
        }
        //Get All

        public List<Employee> GetAllEmployee()
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                List<Employee> employeelist = new List<Employee>();
                string query = "Select * from [Employee]";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                var dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    Employee employee = new Employee();
                   // employee = new Employee();
                    employee.Id = Guid.Parse(dataReader["id"].ToString());
                    employee.Email = dataReader["Email"].ToString();
                    employee.EmergencyContectNo = dataReader["EmergencyContectNo"].ToString();
                    employee.EmergencyContectName = dataReader["EmergencyContectName"].ToString();
                    employee.Designation = dataReader["Designation"].ToString();
                    employee.Mobile = dataReader["Mobile"].ToString();
                    employee.DOB = Convert.ToDateTime(dataReader["DOB"].ToString());
                    employee.DOJ = Convert.ToDateTime(dataReader["DOJ"].ToString());
                    employee.EmpCode = dataReader["EmpCode"].ToString();
                    employee.FirstName = dataReader["FirstName"].ToString();
                    employee.Gender = dataReader["Gender"].ToString();
                    employee.LastName = dataReader["LastName"].ToString();
                    employee.MiddleName = dataReader["MiddleName"].ToString();
                    employee.Phone = dataReader["Phone"].ToString();

                    employeelist.Add(employee);
                }
                cmd.Connection.Close();

                return employeelist;
            }
            catch (Exception)
            {

                throw;
            }
        }

        //AddEmployee
        public Guid? AddEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                var id = System.Guid.NewGuid();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "Insert Into [Employee] (id, EmpCode, FirstName,MiddleName, LastName, Email, DOJ, DOB, Gender, Designation, Phone, Mobile, EmergencyContectNo, EmergencyContectName) Values (@id, @EmpCode, @FirstName,@MiddleName, @LastName, @Email, @DOJ, @DOB, @Gender, @Designation, @Phone, @Mobile, @EmergencyContectNo, @EmergencyContectName)";
                
                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = id;
                cmd.Parameters.Add("EmpCode", SqlDbType.VarChar).Value = employee.EmpCode;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employee.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employee.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employee.LastName;
                cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("DOJ", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("DOB", SqlDbType.Date).Value = employee.DOB;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = employee.Gender;
                cmd.Parameters.Add("Designation", SqlDbType.VarChar).Value = employee.Designation;
                cmd.Parameters.Add("Mobile", SqlDbType.VarChar).Value = employee.Mobile;
                cmd.Parameters.Add("Phone", SqlDbType.VarChar).Value = employee.Phone;
                cmd.Parameters.Add("EmergencyContectNo", SqlDbType.VarChar).Value = employee.EmergencyContectNo;
                cmd.Parameters.Add("EmergencyContectName", SqlDbType.VarChar).Value = employee.EmergencyContectName ;
                

                cmd.Connection.Open();
                var Result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                if (Result > 0)
                    return id;
                else
                    return null;
            }
            catch (Exception)
            {

                throw;
            }

        }

        //Get By Id

        public Employee? Search(Employee employee)
        {
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            try
            {
                Employee? returnValue = null;
                List<SqlParameter> parameters = new List<SqlParameter>();
                string query = " Select * from Employee Where Id =@Id";

                if (employee != null)
                {
                    if(employee.Id != null)
                    {
                        //query += " And Id =@Id";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Id",
                            Value = employee.Id
                        });
                    }
                    if (!string.IsNullOrEmpty(employee.Email))
                    {
                        query = " Select * from Employee where Email =@Email ";
                        //query += " And Email =@Email";
                        parameters.Add(new SqlParameter()
                        {
                            ParameterName = "Email",
                            Value = employee.Email
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

                while (dataReader.Read())
                {
                    returnValue = new Employee();
                    returnValue.Id = Guid.Parse(dataReader["id"].ToString());
                    returnValue.Email = dataReader["Email"].ToString();
                    returnValue.EmergencyContectNo = dataReader["EmergencyContectNo"].ToString();
                    returnValue.EmergencyContectName = dataReader["EmergencyContectName"].ToString();
                    returnValue.Designation = dataReader["Designation"].ToString();
                    returnValue.Mobile = dataReader["Mobile"].ToString();
                    returnValue.DOB = Convert.ToDateTime (dataReader["DOB"].ToString());
                    returnValue.DOJ = Convert.ToDateTime(dataReader["DOJ"].ToString());
                    returnValue.EmpCode = dataReader["EmpCode"].ToString();
                    returnValue.FirstName = dataReader["FirstName"].ToString();
                    returnValue.LastName = dataReader["LastName"].ToString();
                    returnValue.MiddleName = dataReader["MiddleName"].ToString();
                    returnValue.Phone = dataReader["Phone"].ToString();
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
        public Employee? UpdateEmployee(Employee employee)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                string query = "Update [Employee] SET EmpCode = @EmpCode, FirstName = @FirstName,MiddleName= @MiddleName,LastName= @LastName,Email= @Email,DOJ= @DOJ,DOB= @DOB,Gender= @Gender,Designation= @Designation,Phone= @Phone,Mobile= @Mobile,EmergencyContectNo =@EmergencyContectNo,EmergencyContectName= @EmergencyContectName Where id= @id";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Parameters.Add("id", SqlDbType.UniqueIdentifier).Value = employee.Id;
                cmd.Parameters.Add("EmpCode", SqlDbType.VarChar).Value = employee.EmpCode;
                cmd.Parameters.Add("FirstName", SqlDbType.VarChar).Value = employee.FirstName;
                cmd.Parameters.Add("MiddleName", SqlDbType.VarChar).Value = employee.MiddleName;
                cmd.Parameters.Add("LastName", SqlDbType.VarChar).Value = employee.LastName;
                cmd.Parameters.Add("Email", SqlDbType.VarChar).Value = employee.Email;
                cmd.Parameters.Add("DOJ", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("DOB", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("Gender", SqlDbType.VarChar).Value = employee.Gender;
                cmd.Parameters.Add("Designation", SqlDbType.VarChar).Value = employee.Designation;
                cmd.Parameters.Add("Phone", SqlDbType.VarChar).Value = employee.Phone;
                cmd.Parameters.Add("Mobile", SqlDbType.VarChar).Value = employee.Mobile;
                cmd.Parameters.Add("EmergencyContectNo", SqlDbType.VarChar).Value = employee.EmergencyContectNo;
                cmd.Parameters.Add("EmergencyContectName", SqlDbType.VarChar).Value = employee.EmergencyContectName;

                cmd.Connection.Open();
                var result = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return employee;
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

        public bool? DeleteEmployee(Guid id)
        {
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                int rowaffected = 0;
                string query = "Delete from [Employee] where id=@id ";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.Add("id",SqlDbType.UniqueIdentifier).Value = id;
                cmd.Connection = conn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = query;

                cmd.Connection.Open();
                rowaffected = cmd.ExecuteNonQuery();
                cmd.Connection.Close();

                return rowaffected > 0 ? true : false;

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