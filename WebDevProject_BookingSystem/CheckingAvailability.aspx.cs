using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDevProject_BookingSystem
{
    public partial class CheckingAvailability : System.Web.UI.Page
    {
        Bookings bookings;

        protected void Page_Load(object sender, EventArgs e)
        {
            partySizeList.Items.Clear();
            timeList.Items.Clear();

            // Creation Party size list
            for (int group = 1; group < 9; group++)
                partySizeList.Items.Add(group.ToString());

            // Creation Time list
            for (int time = 12; time < 23; time++)
                timeList.Items.Add(time.ToString() + ":00");

            //bookings = new Bookings();
            //bookings._status = false;
        }

        protected void SubmitBtn_Click(object sender, EventArgs e)
        {
            bookings = new Bookings();

            //partySize = String.Format("{0}", Request.Form["partySize"]);
            //date = String.Format("{0}", Request.Form["date"]);
            //time = String.Format("{0}", Request.Form["time"]);

            bookings.bookingDate = dateCalendar.Text + " " + timeList.SelectedValue; // '23/06/2017 14:00'
            bookings.partySize = partySizeList.SelectedValue;
            bookings.CheckingAvailability();
            Msg.Text = bookings.Message;
            if (bookings._status)
            {
                //Response.AddHeader("REFRESH", "3;URL=AddingCustomer.aspx");
                //bookings._status = false;
            }
            //Response.Redirect("AddingCustomer.aspx");

        }
    }
}