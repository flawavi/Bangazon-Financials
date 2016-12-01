using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financials.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: WeeklyReport
    //Author: Fletcher Watson
    //Purpose: This Class selects sales by product from the past month and displays them.
    public class WeeklyReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the products sold over the past week and displays them in the console.
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n#############################");
            Console.WriteLine("This Week's Revenue");
            Console.WriteLine("#############################");

            List<Report> WeeklyReports = new List<Report>();
            WeeklyReports = reportFactory.GetWeeklyReports();

            if (WeeklyReports.Count == 0)
            {
                Console.WriteLine("No sales to report. Perhaps you should have a meeting with your sales managers.");
            }
            else if (WeeklyReports.Count > 0)
            {
                Console.WriteLine("Product                Revenue");
                foreach (Report report in WeeklyReports)
                {
                    Console.WriteLine($"{report.Name} ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}