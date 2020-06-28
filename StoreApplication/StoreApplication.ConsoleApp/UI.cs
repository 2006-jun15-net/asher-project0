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
        private static Customer currentCustomer = new Customer();
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
                            currentCustomer.UserName = input;
                            if (Program.context.Customer.FirstOrDefault(c => c.UserName == currentCustomer.UserName) != null)
                            {
                                Console.WriteLine("UserName already Exists. Please enter a different one.");
                                Console.WriteLine();
                            }
                            else
                            {
                                customerRepo.AddCustomer(currentCustomer);
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
                            currentCustomer.UserName = input;
                            if (customerRepo.findCustomer(currentCustomer.FirstName, currentCustomer.LastName, currentCustomer.UserName) == null)
                            {
                                Console.WriteLine("One of your credentials was wrong. Please Try Again.");
                                Console.WriteLine();
                            }
                            else
                            {
                                currentCustomer = customerRepo.findCustomer(currentCustomer.FirstName, currentCustomer.LastName, currentCustomer.UserName);
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
            currentCustomer.FirstName = input;
            Console.Write("Whats your Last Name?: ");
            input = Console.ReadLine();
            currentCustomer.LastName = input;
        }

        public static void generateMainMenu()
        {
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
                OrderHistory currentOrder = new OrderHistory();
                List<Orders> orders = new List<Orders>();
                while (true)
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
                        currentOrder.LocationId = location.LocationId;
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
                                Orders customerOrder = AddProduct(product, inventory);
                                orders.Add(customerOrder);
                            }
                            else if(input == "n")
                            {
                                Console.WriteLine();
                                Console.WriteLine("Order Finished");
                                Program.context.SaveChanges();
                                currentOrder.CustomerId = currentCustomer.CustomerId;
                                currentOrder.TimeOrdered = DateTime.Now;
                                Program.context.OrderHistory.Add(currentOrder);
                                Program.context.SaveChanges();
                                foreach (var x in orders)
                                {
                                    x.OrderHistoryId = currentOrder.OrderHistoryId;
                                    Program.context.Orders.Add(x);
                                }
                                Program.context.SaveChanges();
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

        public static Orders AddProduct(Product product, Inventory inventory)
        {
            Orders orders = new Orders();
            while (true)
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
                        orders.ProductId = product.ProductId;
                        orders.AmountOrdered = amount;
                        inventory.InStock = inventory.InStock - amount;
                        inventoryRepo.Update(inventory);
                        break;
                    }
                }
                else
                {
                    InvalidInput();
                }
            }

            return orders;
        }
        public static void DisplayOrder(OrderHistory orderHistory)
        {
            var customerRef = Program.context.OrderHistory.Where(o => o.OrderHistoryId == orderHistory.OrderHistoryId).Include(c => c.Customer).FirstOrDefault();
            Customer customer = customerRef.Customer;
            var locationRef = Program.context.OrderHistory.Where(o => o.OrderHistoryId == orderHistory.OrderHistoryId).Include(l => l.Location).FirstOrDefault();
            Location location = locationRef.Location;
            List<Orders> orders = Program.context.Orders.Include(oh => oh.OrderHistory).ToList();
            foreach(var order in orders)
            {
                if(order.OrderHistoryId != orderHistory.OrderHistoryId)
                {
                    orders.Remove(order);
                }
            }
            Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
            Console.WriteLine($"Store Location: {location.Address}, {location.City}, {location.State}");
            Console.WriteLine("Purchased:");
            foreach(var order in orders)
            {
                GenericRepository<Product> generic = new GenericRepository<Product>();
                Console.WriteLine($"  {generic.GetById(order.ProductId).Name}");
                Console.WriteLine($"    Amount Bought: {order.AmountOrdered}");
            }
        }
        public static void DisplayCustomerOrderHistories(Customer customer)
        {
            var orderHistories = Program.context.OrderHistory.Where(o => o.CustomerId == customer.CustomerId);
            Console.WriteLine($"{customer.FirstName} {customer.LastName} Order History:");
            foreach(var history in orderHistories)
            {
                Console.WriteLine($"Order placed on {history.TimeOrdered}");
            }
        }
        public static void DisplayLocationOrderHistories(Location location)
        {
            var orderHistories = Program.context.OrderHistory.Where(o => o.LocationId == location.LocationId);
            Console.WriteLine($"Order Histories at {location.Address}, {location.City}, {location.State}:");
            foreach (var history in orderHistories)
            {
                Console.WriteLine($"Order placed on {history.TimeOrdered}");
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
