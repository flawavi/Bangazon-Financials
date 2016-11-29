using System.Collections.Generic;
using Bangazon_Financial.Actions;
using System;

namespace Bangazon_Financials.Menu
{
    //Class Name: Menu
    //Author: FLetcher Watson
    //Purpose of the class: This Class is where our console application will run, all actions will be executed from here, menu interactions will start and finish in this class.
    //Methods in this Class: MarkDone, MenuSystem, Start, ShowMainMenu.
    public class MenuSystem
    {
        private struct MenuItem
        {
            public string prompt;
            public delegate void MenuAction();
            public MenuAction Action;
        };

        private Dictionary<int, MenuItem> _MenuItems = new Dictionary<int, MenuItem>();

        private bool done = false;

        //Method Name: MarkDone
        //Purpose: this method sets the private bool to false and ends the program when toggled in the Start method's while loop.
        private void MarkDone()
        {
            done = true;
        }

        //Method Name: MenuSystem
        //Purpose of the Method: This method adds MenuItems to a private dictionary of structs and assigns the delegate action.
        public MenuSystem()
        {
            _MenuItems.Add(1, new MenuItem()
            {
                prompt = "Weekly Report",
                Action = WeeklyReport.ReadInput
            });

            _MenuItems.Add(2, new MenuItem()
            {
                prompt = "Monthly Report",
                Action = MonthlyReport.ReadInput
            });

            _MenuItems.Add(3, new MenuItem()
            {
                prompt = "Quarterly Report",
                Action = QuarterlyReport.ReadInput
            });

            _MenuItems.Add(4, new MenuItem()
            {
                prompt = "Customer Revenue Report",
                Action = CustomerRevenueReport.ReadInput
            });

            _MenuItems.Add(5, new MenuItem()
            {
                prompt = "Product Revenue Report",
                Action = ProductRevenueReport.ReadInput
            });

            _MenuItems.Add(6, new MenuItem()
            {
                prompt = "Exit Application",
                Action = MarkDone
            });
        }

        //Method Name: Start
        //Purpose of the Method: This method reruns the ShowMainMenu method (the core of the console application)
        //continuously until the private bool 'done' is set to true.
        public void Start()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            while (!done)
            {
                ShowMainMenu();
            }
        }

        //Method Name: ShowMainMenu
        //Purpose of the Method: This method loads the main menu and handles the user input that chooses 
        //which action to preform.
        public void ShowMainMenu()
        {
            Console.Clear();

            Console.WriteLine("#################################");
            Console.WriteLine("");
            Console.WriteLine("BANGAZON FINANCIAL REPORTS PORTAL");
            Console.WriteLine("");
            Console.WriteLine("#################################");

            // Display each menu item
            foreach (KeyValuePair<int, MenuItem> item in _MenuItems)
            {
                Console.WriteLine($"\r\n{item.Key}. {item.Value.prompt}");
            }

            Console.Write("> ");

            // Read in the user's choice
            try
            {
                int selection;
                Int32.TryParse(Console.ReadLine(), out selection);

                // Based on their choice, execute the appropriate action
                MenuItem menuItem;
                _MenuItems.TryGetValue(selection, out menuItem);
                menuItem.Action();
            }
            catch
            {
                Console.WriteLine("Not a valid option; please choose from the numbered list above.");
            }
        }
    }
}