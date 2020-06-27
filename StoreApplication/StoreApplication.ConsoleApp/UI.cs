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
        private static CustomerRepository customerRepo = new CustomerRepository(Program.context);
        private static GenericRepository<Location> locationRepo = new GenericRepository<Location>();
        private static GenericRepository<Product> productRepo = new GenericRepository<Product>();
        private static GenericRepository<Inventory> inventoryRepo = new GenericRepository<Inventory>();
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
                    break;
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
                            Console.WriteLine();
                        }
                        else
                        {
                            customer.UserName = input;
                            if (Program.context.Customer.FirstOrDefault(c => c.UserName == customer.UserName) != null)
                            {
                                Console.WriteLine("UserName already Exists. Please enter a different one.");
                                Console.WriteLine();
                            }
                            else
                            {
                                customerRepo.AddCustomer(customer);
                                customerRepo.Save();
                                generateMainMenu();
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
                            Console.WriteLine();
                        }
                        else
                        {
                            customer.UserName = input;
                            if (customerRepo.findCustomer(customer.FirstName, customer.LastName, customer.UserName) == null)
                            {
                                Console.WriteLine("One of your credentials was wrong. Please Try Again.");
                                Console.WriteLine();
                            }
                            else
                            {
                                generateMainMenu();
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

        public static void generateMainMenu()
        {
            OrderHistory order = new OrderHistory();

            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1. Place an Order");
            Console.WriteLine("2. View Order History");
            Console.WriteLine("3. Exit Application");
            Console.WriteLine();
            Console.Write("Enter a valid choice: ");
            input = Console.ReadLine();
            if(input == "1")
            {
                while(true)
                {
                    Console.WriteLine();
                    foreach (var element in locationRepo.GetAll())
                    {
                        Console.WriteLine($"{element.LocationId}: {element.Address}, {element.City}, {element.State}");
                    }
                    Console.WriteLine("Select a location or enter \"b\" to go back to the previous page.");
                    Console.Write("Enter a valid choice: ");
                    input = Console.ReadLine();
                    int locationSelection;
                    Location location;
                    if(Int32.TryParse(input, out locationSelection))
                    {
                        location = locationRepo.GetById(locationSelection);
                    }
                    else
                    {
                        location = null;
                    }
                    if (location != null)
                    {
                        order.Location = location;
                        while(true)
                        {
                            Console.WriteLine();
                            foreach (var element in productRepo.GetAll())
                            {
                                Console.WriteLine($"{element.ProductId}. {element.Name}: ${element.Price}");
                            }
                            Console.WriteLine("Select a product.");
                            Console.WriteLine("When you are finished, enter \"n\" to proceed or enter \"b\" to go back to the previous page.");
                            Console.Write("Enter a valid choice: ");
                            input = Console.ReadLine();
                            int productSelection;
                            Product product;
                            if (Int32.TryParse(input, out productSelection))
                            {
                                product = productRepo.GetById(productSelection);
                            }
                            else
                            {
                                product = null;
                            }
                            if (product != null)
                            {
                                Inventory inventory = Program.context.Inventory.Where(i => (i.Location == location) && (i.Product == product)).FirstOrDefault();
                                AddProduct(product, inventory);
                            }
                            else if(input == "n")
                            {
                                Console.WriteLine("next");
                                break;
                            }
                            else if (input == "b")
                            {
                                break;
                            }
                            else
                            {
                                InvalidInput();
                            }
                        }
                    }
                    else if (input == "b")
                    {
                        break;
                    }
                    else
                    {
                        InvalidInput();
                    }
                }
            }
            else if(input == "2")
            {
                Console.WriteLine("Not Implemented");
            }
            else if(input == "3")
            {
                return;
            }
            else
            {
                InvalidInput();
            }
        }

        public static void AddProduct(Product product, Inventory inventory)
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("How many would you like order?");
                Console.Write("Enter Amount: ");
                input = Console.ReadLine();
                int amount;
                if (Int32.TryParse(input, out amount))
                {
                    if (amount > product.MaxPerOrder)
                    {
                        Console.WriteLine("You cannot order that much in a single order.");
                    }
                    else if (inventory.InStock < amount)
                    {
                        Console.WriteLine("Sorry, this location does not have that much in stock.");
                        Console.WriteLine($"Current Stock: {inventory.InStock}");
                    }
                    else
                    {
                        inventory.InStock = inventory.InStock - amount;
                        inventoryRepo.Update(inventory);
                        inventoryRepo.Save();
                        break;
                    }
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
