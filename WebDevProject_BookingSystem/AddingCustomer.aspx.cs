using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDevProject_BookingSystem
{
    public partial class AddingCustomer : System.Web.UI.Page
    {
        bool typeAccount;

        protected void Page_Load(object sender, EventArgs e)
        {
            GuestType.Checked = true;

            title.Items.Add("Mr.");
            title.Items.Add("Ms.");
            title.Items.Add("Miss");

            occasion.Items.Add("Birtday");
            occasion.Items.Add("Honey moon");
            occasion.Items.Add("Meeting");
        }

        protected void GuestType_CheckedChanged(object sender, EventArgs e)
        {
            typeAccount = false;
        }

        protected void RegisterType_CheckedChanged(object sender, EventArgs e)
        {
            typeAccount = true;
        }

        protected void AddCustomerBtn_Click(object sender, EventArgs e)
        {
            Customers customer = new Customers();
            customer.email = email.Text;
            customer.password = password.Text;
            customer.typeAccount = typeAccount;
            customer.title = title.SelectedValue;
            customer.firstName = firstName.Text;
            customer.lastName = lastName.Text;
            customer.phone = phone.Text;
            customer.occasion = occasion.SelectedValue;
            customer.notes = notes.Text;

            customer.AddCustomer();
            TextBox1.Text = customer.Message;
        }
    }
}