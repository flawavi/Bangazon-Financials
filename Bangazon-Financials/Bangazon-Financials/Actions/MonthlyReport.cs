
using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financials.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: MonthlyReport
    //Author: Grant Regnier
    //Purpose of the class: This Class selects sales by product from the past month and displays them.
    public class MonthlyReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the products sold over the past month and displays them in the console.
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n########################");
            Console.WriteLine("MONTHLY REPORT");
            Console.WriteLine("########################");

            List<Report> MonthlyReports = new List<Report>();
            MonthlyReports = reportFactory.GetMonthlyReports();

            if (MonthlyReports.Count == 0)
            {
                Console.WriteLine("No sales to report. Fire your sales team.");
            }
            else if (MonthlyReports.Count > 0)
            {
                Console.WriteLine("Product                       Revenue");
                foreach (Report report in MonthlyReports)
                {
                    Console.WriteLine($"{report.Name}                ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}