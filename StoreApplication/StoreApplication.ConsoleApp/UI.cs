using DataAccess.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StoreApplication.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    public static class UI
    {
        private static string input;
        private static Customer customer = new Customer();
        private static CustomerRepository repository = new CustomerRepository(Program.context);
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
                    Console.WriteLine();
                    EnterFullName();
                    while (true)
                    {
                        Console.Write("Whats your UserName?: ");
                        input = Console.ReadLine();
                        if (input.Length > 26)
                        {
                            Console.WriteLine("Your Username is too long. It must be under 26 characters long");
                        }
                        else
                        {
                            customer.UserName = input;
                            if (repository.findCustomer(customer.FirstName, customer.LastName, customer.UserName) != null)
                            {
                                Console.WriteLine("UserName already Exists. Please enter a different one.");
                            }
                            else
                            {
                                repository.AddCustomer(customer);
                                break;
                            }
                        }

                    }
                    Console.WriteLine();
                    break;
                }
                else if(input == "2")
                {
                    Console.WriteLine();
                    while (true)
                    {
                        EnterFullName();
                        Console.Write("Whats your UserName?: ");
                        input = Console.ReadLine();
                        if (input.Length > 26)
                        {
                            Console.WriteLine("Your Username is too long. It must be under 26 characters long");
                        }
                        else
                        {
                            customer.UserName = input;
                            if (repository.findCustomer(customer.FirstName, customer.LastName, customer.UserName) == null)
                            {
                                Console.WriteLine("One of your credentials was wrong. Please Try Again.");
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
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

        public static void EnterFullName()
        {
            Console.Write("Whats your First Name?: ");
            input = Console.ReadLine();
            customer.FirstName = input;
            Console.Write("Whats your Last Name?: ");
            input = Console.ReadLine();
            customer.LastName = input;
        }

        public static void InvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("That's not a valid choice. Please try again.");
            Console.WriteLine();
        }
    }
}
