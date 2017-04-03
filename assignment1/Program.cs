//Author: Zachery Holderman
//CIS 237
//Assignment 5
/*
 * The Menu Choices Displayed By The UI
 * 1. Load Wine List From CSV
 * 2. Print The Entire List Of Items
 * 3. Search For An Item
 * 4. Add New Item To The List
 * 5. Exit Program
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Wine Program!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Run The program");
            Console.WriteLine("2. Exit the program");
            int decision = int.Parse(Console.ReadLine());
            while(decision == 1)
            {
                NewUserInterface ui = new NewUserInterface();
                ui.UserInteface();
                Console.WriteLine("Run the program again?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. No");
                decision = int.Parse(Console.ReadLine());
            }
            if(decision == 2)
            {
                Console.WriteLine("GoodBye");
                Environment.Exit(0);
            }
        }
    }
}
