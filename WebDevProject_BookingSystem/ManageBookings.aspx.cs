using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDevProject_BookingSystem
{
    public partial class ManageBookings : System.Web.UI.Page
    {
        Customers customer;
        Tables table;
        Bookings booking;
        string[] occasion;
        int customerId;
        byte tableId;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            booking = new Bookings();

            // Default Guest account
            customer.typeAccount = false;

            // Creation Occasion list
            occasion = new string[] { "Choose...", "Anniversary", "Birthday", "Honeymoon", "Wedding", "Meeting", "Other" };

            occasionList.Items.Clear();

            foreach (string item in occasion)
                occasionList.Items.Add(item);
        }

        private void AddCustomer()
        {
            customer = new Customers();

            customer.email = email.Text;
            customer.title = title.Text;
            customer.firstName = firstName.Text;
            customer.lastName = lastName.Text;
            customer.phone = phone.Text;
            customer.occasion = occasionList.SelectedValue;
            customer.notes = notes.Text;

            customer.AddCustomer();

            customerId = customer.customerId;
        }

        private void BookTable()
        {
            table = new Tables();

            table.AddTable();
            tableId = table.tableId;
        }


        protected void BookingBtn_Click(object sender, EventArgs e)
        {

            Msg.Text = customer.Message;


        }
    }
}