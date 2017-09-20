using System;
using System.Collections.Generic;
using System.Web;

namespace WebDevProject_BookingSystem
{
    public class CreationTables
    {
        string crtTableCustomer = "CREATE TABLE [dbo].[Customers] (id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, email VARCHAR(50), password VARCHAR(10), type BIT, title VARCHAR(5), firstName VARCHAR(20) NOT NULL, lastName VARCHAR(20) NOT NULL, phone VARCHAR(15) NOT NULL, occasion VARCHAR(20), notes VARCHAR(100))";
        string crtTableEmployee = "CREATE TABLE [dbo].[Employees] (id INT IDENTITY(1,1) NOT NULL PRIMARY KEY, username VARCHAR(10) NOT NULL, password VARCHAR(10) NOT NULL, firstName VARCHAR(20) NOT NULL, lastName VARCHAR(20) NOT NULL)";
        string crtTableRestaurant = "CREATE TABLE [dbo].[Restaurant] (id TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY, employeer_id INT FOREIGN KEY REFERENCES [Employee](id) NOT NULL, name VARCHAR(20) NOT NULL, location VARCHAR(50))";
        string crtTableTable = "CREATE TABLE [dbo].[Tables] (id TINYINT IDENTITY(1,1) NOT NULL PRIMARY KEY, name VARCHAR(10) NOT NULL, numSeats TINYINT NOT NULL, minNumBookingSeats TINYINT NOT NULL)";
        string crtTableBooking = "CREATE TABLE [dbo].[Bookings] (restaurant_id TINYINT FOREIGN KEY REFERENCES [Restaurant](id) NOT NULL, customer_id INT FOREIGN KEY REFERENCES [Customers](id) NOT NULL, table_id TINYINT FOREIGN KEY REFERENCES [Tables](id) NOT NULL, dateTime DATETIME NOT NULL, partySize TINYINT NOT NULL)";

    }
}