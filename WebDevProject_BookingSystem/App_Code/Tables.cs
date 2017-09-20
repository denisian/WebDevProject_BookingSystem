using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Web;
using System.Web.Configuration;

namespace WebDevProject_BookingSystem
{
    public class Tables
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        private SqlConnection conn;
        private SqlCommand cmd;
        private SqlDataReader dataReader;
        private DataTable dataTable;
        public DataTable DataTable { get { return dataTable; } }

        public byte tableId;
        public string name;
        public byte numSeats;
        public byte minNumBookingSeats;
        private string _message;
        public string Message { get { return _message; } }

        public void ShowTables()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                cmd = new SqlCommand("select * from Tables", conn);
                dataReader = cmd.ExecuteReader();
                dataTable = new DataTable();
                if (dataReader.HasRows)
                    dataTable.Load(dataReader);
                else
                {
                    //dataTable.Load(dataReader);
                    _message = "No data found";
                }
                conn.Close();
            }
        }

        public void AddTable()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                cmd = new SqlCommand("select count(*) from Tables where name = @name", conn);
                cmd.Parameters.AddWithValue("@name", name);
                if ((int)cmd.ExecuteNonQuery() > 0)
                {
                    _message = "Name already exist";
                    conn.Close();
                    return;
                }

                string addTable = "INSERT INTO Tables (name, numSeats, minNumBookingSeats) " +
                                    "VALUES (@name, @numSeats, @minNumBookingSeats)";

                cmd = new SqlCommand(addTable, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@numSeats", numSeats);
                cmd.Parameters.AddWithValue("@minNumBookingSeats", minNumBookingSeats);

                if (cmd.ExecuteNonQuery() == 1)
                    _message = "Table has been added";
                conn.Close();
            }
        }

        public void UpdateTable()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                string updateTable = "update Tables set name = @name, numSeats = @numSeats, minNumBookingSeats = @minNumBookingSeats where id = @id";
                cmd = new SqlCommand(updateTable, conn);
                cmd.Parameters.AddWithValue("@id", tableId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@numSeats", numSeats);
                cmd.Parameters.AddWithValue("@minNumBookingSeats", minNumBookingSeats);

                if (cmd.ExecuteNonQuery() == 1)
                    _message = "Table updated suuccesfully";
                conn.Close();
            }
        }

        public void DeleteTable()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                string deleteTable = "delete from Tables where id = @id";
                cmd = new SqlCommand(deleteTable, conn);
                cmd.Parameters.AddWithValue("@id", tableId);

                if (cmd.ExecuteNonQuery() == 1)
                    _message = "Table deleted suuccesfully";
                conn.Close();
            }
        }

        public void ChooseTableForBooking()
        {
            //using (conn = new SqlConnection(connStr))
            //{
            //    conn.Open();
            //    cmd = new SqlCommand("select id from Tables where numSeats = @numSeats", conn);
            //    cmd.Parameters.AddWithValue("@name", name);
            //    if ((int)cmd.ExecuteNonQuery() > 0)
            //    {
            //        _message = "Name already exist";
            //        conn.Close();
            //        return;
            //    }
            //}
        }
    }
}