using System;
using System.Collections.Generic;
using System.Linq;
using _451AS03.DAL;
using System.Web;


namespace _451AS03.BLL
{
    /// <summary>
    /// Represents a store customer and all the methods 
    /// for selecting, inserting, and updating a customer
    /// </summary>
    public class Customer
    {
        private int _id = 0;
        private string _name = String.Empty;
        private string _address = String.Empty;
        private string _email = String.Empty;

        /// <summary>
        /// Customer Unique Identifier
        /// </summary> 
        public int Id
        {
            get { return _id; }
        }

        /// <summary>
        /// Customer Name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Customer Address
        /// </summary>
        public string Address
        {
            get { return _address; }
        }

        /// <summary>
        /// Customer Email
        /// </summary> 
        public string Email
        {
            get { return _email; }
        }

        /// <summary>
        /// Retrieves all Customers
        /// </summary> 
        /// <returns></returns>
        public static List<Customer> SelectAll()
        {
            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            return dataAccessLayer.CustomerSelectAll();
        }

        /// <summary>
        /// Updates a particular customer
        /// </summary> 
        /// <param name="id">Customer Id</param>
        /// <param name="name">Customer Name</param>
        /// <param name="address">Customer Address</param>
        /// <param name="email">Customer Email</param>
        public static void Update(int id, string name, string address, string email)
        {
            if (id < 1)
                throw new ArgumentException("Product Id must be greater than 0", "id");
            Customer customerToUpdate = new Customer(id, name, address, email);
            customerToUpdate.Save();
        }

        /// <summary>
        /// Inserts a new Customer
        /// </summary>
        /// <param name="name">Customer Name</param>
        /// <param name="address">Customer Address</param>
        /// <param name="email">Customer Email</param>
        public static void Insert(int id, string name, string address, string email)
        {
            Customer newCustomer = new Customer(id, name, address, email);
            newCustomer.Save();
        }

        /// <summary>
        /// Deletes an existing Customer
        /// </summary> 
        /// <param name="id">Customer Id</param>
        public static void Delete(int id)
        {
            if (id < 1)
                throw new ArgumentException("Customer Id must be greater than 0", "id");

            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            dataAccessLayer.CustomerDelete(id);
        }

        /// <summary>
        /// Validates Customer information before Saving Customer
        /// Properties to the database
        /// </summary>
        private void Save()
        {
            if (String.IsNullOrEmpty(_name))
                throw new ArgumentException("Customer Name not supplied", "name");
            if (_name.Length > 50)
                throw new ArgumentException("Customer Name must be less than 50 characters", "name");
            if (String.IsNullOrEmpty(_address))
                throw new ArgumentException("Customer Address not supplied", "address");

            SqlDataAccessLayer dataAccessLayer = new SqlDataAccessLayer();
            if (_id > 0)
                dataAccessLayer.CustomerUpdate(this);
            else
                dataAccessLayer.CustomerInsert(this);
        }

        /// <summary>
        /// Initializes Customer
        /// </summary>
        /// <param name="name">Customer Name</param>
        /// <param name="address">Customer Address</param>
        /// <param name="email">Customer Email</param>
        public Customer(string name, string address, string email)
            :this(0, name, address, email)
                { }
        
      

        /// <summary>
        /// Initializes Customer
        /// </summary>
        /// <param name="name">Customer Name</param>
        /// <param name="address">Customer Address</param>
        /// <param name="email">Customer Email</param>
        public Customer(int id, string name, string address, string email)
        {
            _id = id;
            _name = name;
            _address = address;
            _email = email;
        }
    }
}