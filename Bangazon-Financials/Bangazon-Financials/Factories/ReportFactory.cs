using System.Collections.Generic;
using Bangazon_Financial.Data;
using Microsoft.Data.Sqlite;
using Bangazon_Financials.Entities;

namespace Bangazon_Financial.Factories
{
    /*
    Class Name: ReportFactory
    Author: Fletcher Watson
    Purpose: This class defines methods to retrieve reports by week, month and quarter, and to retrieve reports by products.
    Methods: GetWeeklyReports, GetMonthlyReports, GetQuarterlyReports, GetRevenueByCustomer, GetRevenueByProduct.
    */

    public class ReportsFactory
    {
        //Method Name: GetWeeklyReports
        //Purpose: Returns the previous week of revenue.
        public List<Report> GetWeeklyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Title, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-7 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Title";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }

        //Method Name: GetMonthlyReports
        //Purpose: Returns the previous month of revenue.
        public List<Report> GetMonthlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Title, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-30 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Title";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }

        //Method Name: GetQuarterlyReports
        //Purpose: Returns the previous quarter of revenue.
        public List<Report> GetQuarterlyReports()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();
            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Name, Product.Price*COUNT(LineItem.ProductId)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            JOIN 'Order' O ON LineItem.OrderId = O.OrderId
            WHERE O.DateCompleted >= datetime('now', '-90 days') AND O.DateCompleted <= datetime('now', 'localtime')
            GROUP BY Product.Name";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }
        public List<Report> GetRevenueByCustomer()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Customer.FirstName || ' ' || Customer.LastName AS ""Full Name"", SUM(Product.Price)
            FROM Customer
            JOIN 'Order' O ON Customer.CustomerId = O.CustomerId
            JOIN LineItem ON O.OrderId = LineItem.OrderId
            JOIN Product ON LineItem.ProductId = Product.ProductId
            GROUP BY ""Full Name""";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }

        //Method Name: GetRevenueByProduct
        //Purpose: This method returns a list of reports that displays the total revenue of products sold.
        public List<Report> GetRevenueByProduct()
        {
            BangazonWebConnection Conn = new BangazonWebConnection();

            List<Report> ReportList = new List<Report>();

            string query = $@"
            SELECT Product.Title, SUM(Product.Price)
            FROM Product
            JOIN LineItem ON Product.ProductId = LineItem.ProductId
            GROUP BY Product.Title";
            Conn.execute(query, (SqliteDataReader reader) =>
            {
                while (reader.Read())
                {
                    ReportList.Add(new Report
                    {
                        Name = reader[0].ToString(),
                        Price = reader.GetDouble(1)
                    });
                }
                reader.Close();
            });
            return ReportList;
        }
    }
}