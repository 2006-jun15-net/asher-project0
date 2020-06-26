using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    public static class UI
    {
        private static string input;
        public static void IntroMenu()
        {
            while(true)
            {
                Console.WriteLine("Welcome to the store!");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1.  Sign in");
                Console.WriteLine("2.  Exit store");
                Console.Write("Please enter a valid choice: ");
                input = Console.ReadLine();
                if(input == "1")
                {
                    ExistingOrNew();
                }
                else if(input == "2")
                {
                    break;
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        public static void ExistingOrNew()
        {
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Are you an existing customer or a new one?");
                Console.WriteLine("1.  New");
                Console.WriteLine("2.  Existing");
                Console.WriteLine("3.  Go back to previous menu");
                Console.Write("Please enter a valid choice: ");
                input = Console.ReadLine();

                if(input == "1")
                {
                    Console.WriteLine("New Customer");
                    Console.WriteLine();
                    break;
                }
                else if(input == "2")
                {
                    Console.WriteLine("Existing Customer");
                    Console.WriteLine();
                    break;
                }
                else if(input == "3")
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    InvalidInput();
                }
            }
            
        }

        public static void InvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("That's not a valid choice. Please try again.");
            Console.WriteLine();
        }
    }
}
