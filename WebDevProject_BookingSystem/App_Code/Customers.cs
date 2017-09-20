using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;

namespace WebDevProject_BookingSystem
{
    public class Customers
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;

        public int customerId = 0;
        public string email;
        public string password;
        public bool typeAccount;
        public string title;
        public string firstName;
        public string lastName;
        public string phone;
        public string occasion;
        public string notes;
        private string _message;

        public string Message { get { return _message; } }

        public void AddCustomer()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                // checking if customer is already in the DB and has type 1 (non-guest)
                cmd = new SqlCommand("select count(*) from Customers where email = @email AND type = 1", conn);
                cmd.Parameters.AddWithValue("@email", email);
                if ((int)cmd.ExecuteScalar() > 0)
                {
                    _message = "E-mail already exist";
                    conn.Close();
                    return;
                }

                string addCustomer = "INSERT INTO Customers (email, password, type, title, firstName, lastName, phone, occasion, notes) " +
                                        "OUTPUT INSERTED.id " +
                                        "(@email, @password, @type, @title, @firstName, @lastName, @phone, @occasion, @notes)";
                cmd = new SqlCommand(addCustomer, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@type", typeAccount);
                cmd.Parameters.AddWithValue("@title", title);
                cmd.Parameters.AddWithValue("@firstName", firstName);
                cmd.Parameters.AddWithValue("@lastName", lastName);
                cmd.Parameters.AddWithValue("@phone", phone);
                cmd.Parameters.AddWithValue("@occasion", occasion);
                cmd.Parameters.AddWithValue("@notes", notes);

                customerId = (int)cmd.ExecuteScalar();

                if (customerId != 0)
                    _message = "Customer has been added";
                conn.Close();
            }
        }
    }
}