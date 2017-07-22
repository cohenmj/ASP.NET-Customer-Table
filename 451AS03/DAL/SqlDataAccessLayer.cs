using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using _451AS03.BLL;
using System.Web;
using System.Web.Configuration;

namespace _451AS03.DAL
{
    /// <summary>
    /// Data Access Layer for Interacting with Microsoft
    /// SQL Server 2008
    /// </summary>
    public class SqlDataAccessLayer
    {
        private static readonly string _connectionString = string.Empty;
        /// <summary>
        /// Selects all customers from the database
        /// </summary>
        public List<Customer> CustomerSelectAll()
        {
            // Create Customer Collection
            List<Customer> colCustomers = new List<Customer>();

            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT Id,Name,Address,Email FROM Customers";

            //Execute command
            using (con)
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    colCustomers.Add(new Customer(
                        (int)reader["Id"],
                        (string)reader["Name"],
                        (string)reader["Address"],
                        (string)reader["Email"]));
                }
            }
            return colCustomers;
        }
        /// <summary>
        /// Inserts a new product into the database
        /// </summary>
        /// <param name="newCustomer">Customer</param>
        public void CustomerInsert(Customer newCustomer)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "INSERT Customers (Name,Address,Email) VALUES (@Name,@Address,@Email)";

            // Add parameters
            cmd.Parameters.AddWithValue("@Name", newCustomer.Name);
            cmd.Parameters.AddWithValue("@Address", newCustomer.Address);
            cmd.Parameters.AddWithValue("@Email", newCustomer.Email);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Updates an existing Customer into the database
        /// </summary>
        /// <param name="customerToUpdate">Customer</param>
        public void CustomerUpdate(Customer customerToUpdate)
        {
            // Create Connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create Command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "UPDATE Customers SET Name=@Name,Address=@Address,Email=@Email WHERE Id=@Id)";

            // Add Parameters
            cmd.Parameters.AddWithValue("@Name", customerToUpdate.Name);
            cmd.Parameters.AddWithValue("@Address", customerToUpdate.Address);
            cmd.Parameters.AddWithValue("@Email", customerToUpdate.Email);
            cmd.Parameters.AddWithValue("@Id", customerToUpdate.Id);

            // Execute command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        /// <summary>
        /// Deletes an existing customer in the database
        /// </summary>
        /// <param name="id">Customer Id</param>
        public void CustomerDelete(int Id)
        {
            // Create connection
            SqlConnection con = new SqlConnection(_connectionString);

            // Create command
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "DELETE Customers WHERE Id=@Id";

            // Add Parameters
            cmd.Parameters.AddWithValue("@Id", Id);

            // Execute Command
            using (con)
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Initialize the data access layer by
        /// loading the database connection string from
        /// the Web.Config file
        /// </summary>
        static SqlDataAccessLayer()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["Store"].ConnectionString;
            if (string.IsNullOrEmpty(_connectionString))
                throw new Exception("No Connectin string configured in Web.Config file");
        }
    }
}