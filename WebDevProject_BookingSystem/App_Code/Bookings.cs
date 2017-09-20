using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace WebDevProject_BookingSystem
{
    public class Bookings
    {
        private string connStr = WebConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
        private SqlDataReader dataReader;
        private DataTable dataTable;
        private SqlConnection conn;
        private SqlCommand cmd;

        /// <summary>
        /// The status of availability a table (true - the table is available for booking, false - not available)
        /// </summary>
        public bool _status = false;
        //public bool Status { get; set; }

        private string _message;
        public byte restaurantId;
        public int customerId;
        public byte tableId;
        public string bookingDate; // '23/06/2017 14:00'
        public string partySize;
        private int _idChosenTable;

        public string Message { get { return _message; } }
        public int IdChosenTable { get { return _idChosenTable; } }

        public void CheckingAvailability()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                //string checkTable = "select table_id from Bookings where bookingDate = CONVERT(datetime, @bookingDate, 103) and partySize = @partySize";
                //string checkTable = "select count(table_id) from Bookings where bookingDate = CONVERT(datetime, '" + bookingDate + "', 103) and partySize = " + partySize;
                string checkTable = "SELECT id, numSeats FROM Tables WHERE " +
                                        "id NOT IN (SELECT table_id FROM Bookings WHERE bookingDate = CONVERT(datetime, '" + bookingDate + "', 103)) " +
                                        "AND " + partySize + " BETWEEN minNumBookingSeats AND numSeats";
                cmd = new SqlCommand(checkTable, conn);
                //cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
                //cmd.Parameters.AddWithValue("@partySize", partySize);

                // запросить все айди столов, включая numSeats 
                // выбрать стол с минимальным numSeats
                // если их несколько, выбрать рендомный


                dataReader = cmd.ExecuteReader();
                dataTable = new DataTable();
                if (dataReader.HasRows)
                {
                    _message = "Table is available for booking";
                    dataTable.Load(dataReader);
                    //string tableId = dataTable.Rows[0]["id"].ToString();
                    //string numSeats = dataTable.Rows[0]["numSeats"].ToString();

                    byte minNumSeats = byte.MaxValue;
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        byte numSeats = dataRow.Field<byte>("numSeats");
                        minNumSeats = Math.Min(minNumSeats, numSeats);

                    }

                    var queryIdTablesWithMinNumSeats =
                         from table in dataTable.AsEnumerable()
                         where table.Field<byte>("numSeats") == minNumSeats
                         select table.Field<int>("id");

                    int countSeats = queryIdTablesWithMinNumSeats.Count();
                    // if there more than one table with min count of seats
                    //byte[] idTables = new (byte)idTablesWithMinNumSeats;
                    if (countSeats > 1)
                    {
                        //byte counter = 0;
                        int[] idArray = new int[countSeats];
                        int i = 0;
                        foreach (var id in queryIdTablesWithMinNumSeats)
                        {
                            idArray[i] = id;
                            i++;
                        }

                        Random randomTable = new Random();
                        int index = randomTable.Next(0, countSeats - 1);
                        _idChosenTable = idArray[index];

                        _status = true;
                    }
                    else
                    {
                        _idChosenTable = Convert.ToInt32(queryIdTablesWithMinNumSeats);
                    }
                    _message = minNumSeats.ToString(); //_idChosenTable.ToString(); //"There is no any table for booking at this time";
                    //_message += ", " + res.ToString();
                    conn.Close();
                }
            }
        }

        public void AddBooking()
        {
            using (conn = new SqlConnection(connStr))
            {
                conn.Open();
                //cmd = new SqlCommand("select count(*) from Tables where name = @name", conn);
                //cmd.Parameters.AddWithValue("@name", name);
                //if ((int)cmd.ExecuteNonQuery() > 0)
                //{
                //    message = "Name already exist";
                //    conn.Close();
                //    return;
                //}

                string addBooking = "INSERT INTO Booking (restaurant_id, customer_id, table_id, bookingDate, partySize) values " +
                                    "(@restaurant_id, @cudtomer_id, @table_id, @bookingDate, @partySize)";

                cmd = new SqlCommand(addBooking, conn);
                cmd.Parameters.AddWithValue("@restaurant_id", restaurantId);
                cmd.Parameters.AddWithValue("@cudtomer_id", customerId);
                cmd.Parameters.AddWithValue("@table_id", tableId);
                cmd.Parameters.AddWithValue("@bookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@partySize", partySize);

                if (cmd.ExecuteNonQuery() == 1)
                    _message = "Booking has been added";
                conn.Close();
            }
        }
    }
}