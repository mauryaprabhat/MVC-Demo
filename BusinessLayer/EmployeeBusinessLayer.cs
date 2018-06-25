using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class EmployeeBusinessLayer
    {
        public IEnumerable<Employee> Employees
        {
            get
            {
                string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
                List<Employee> employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee employee = new Employee
                        {
                            Id = Convert.ToInt32(rdr["Id"]),
                            Name = rdr["Name"].ToString(),
                            Gender = rdr["Gender"].ToString(),
                            City = rdr["City"].ToString()
                        };
                        employees.Add(employee);
                    }
                }
                return employees;
            }
        }

        public void AddEmployee(Employee employee)
        {
            string connectionString =
                ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void EditEmployee(Employee employee)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DetailEmployee(Employee employee)
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = employee.Id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteEmployee(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}