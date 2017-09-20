using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebDevProject_BookingSystem
{
    public partial class ManageTables : System.Web.UI.Page
    {
        Tables table;

        private void TablesInitialization()
        {
            table = new Tables();
            //table.tableId = Message.Text;
            table.name = name.Text;
            table.numSeats = Convert.ToByte(numSeats.Text);
            table.minNumBookingSeats = Convert.ToByte(minNumBookingSeats.Text);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void TablesGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Message.Text = TablesGridView.SelectedRow.Cells[1].Text.Trim();
            name.Text = TablesGridView.SelectedRow.Cells[2].Text.Trim();
            numSeats.Text = TablesGridView.SelectedRow.Cells[3].Text.Trim();
            minNumBookingSeats.Text = TablesGridView.SelectedRow.Cells[4].Text.Trim();
        }

        protected void AddTableBtn_Click(object sender, EventArgs e)
        {
            TablesInitialization();
            table.AddTable();
            Message.Text = table.Message;
        }

        private void LoadData()
        {
            table = new Tables();
            table.ShowTables();
            TablesGridView.DataSource = table.DataTable;
            TablesGridView.DataBind();
            Message.Text = table.Message;
        }

        protected void UpdateTableBtn_Click(object sender, EventArgs e)
        {
            TablesInitialization();
            table.tableId = Convert.ToByte(TablesGridView.SelectedIndex + 1);
            table.UpdateTable();
            LoadData();
        }

        protected void ShowTablesBtn_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        protected void DeleteTableBtn_Click(object sender, EventArgs e)
        {
            TablesInitialization();
            table.DeleteTable();
            LoadData();
        }
    }
}