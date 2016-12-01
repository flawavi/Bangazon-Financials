using System;
using System.Collections.Generic;
using Bangazon_Financial.Factories;
using Bangazon_Financials.Entities;
namespace Bangazon_Financial.Actions
{
    //Class Name: QuarterlyReport
    //Author: Fletcher Watson
    //Purpose: This Class selects sales by product from the past month and displays them.
    public class QuarterlyReport
    {
        //Method Name: ReadInput
        //Purpose of the Method: This method selects a list of Reports that show the products sold over the past quater and displays them in the console.
        public static void ReadInput()
        {
            ReportsFactory reportFactory = new ReportsFactory();

            Console.WriteLine("\r\n######################");
            Console.WriteLine("Quarterly Revenue");
            Console.WriteLine("######################");

            List<Report> QuarterlyReports = new List<Report>();
            QuarterlyReports = reportFactory.GetQuarterlyReports();

            if (QuarterlyReports.Count == 0)
            {
                Console.WriteLine("No sales to report. Consider stepping down as CEO and hiring the programmer who made this portal.");
            }
            else if (QuarterlyReports.Count > 0)
            {
                Console.WriteLine("Product                Revenue");
                foreach (Report report in QuarterlyReports)
                {
                    Console.WriteLine($"{report.Name}                   ${report.Price}");
                }
            }

            Console.WriteLine("\r\nPress any key to return to main menu");
            Console.ReadLine();
        }
    }
}