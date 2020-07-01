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
        private static LocationRepository locationRepo = new LocationRepository(Program.context);
        private static GenericRepository<Product> productRepo = new GenericRepository<Product>();
        private static InventoryRepository inventoryRepo = new InventoryRepository(Program.context);
        private static OrderHistoryRepository OrderHistoryRepo = new OrderHistoryRepository(Program.context);
        private static OrdersRepository OrdersRepo = new OrdersRepository(Program.context);
        private static List<OrderHistory> orderHistories = new List<OrderHistory>();
        private static List<Product> addedProducts = new List<Product>();

        /// <summary>
        /// Creates the starting UI for the user. Asking whether they would like to sign in or exit the application
        /// </summary>
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

        /// <summary>
        /// Presents UI that determines whether we are dealing with a new customer or an existing one.
        /// Users will be asked to enter in their credentials (first name, last name, and username) to confirm their identity or to create a
        /// new account.
        /// </summary>
        private static void ExistingOrNew()
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
                        try
                        {
                            Console.Write("Whats your UserName?: ");
                            input = Console.ReadLine();
                            if (input.Length == 0)
                            {
                                throw new ArgumentException("Username must not be empty.", nameof(input));
                            }
                            else if (input.Length > 26)
                            {
                                Console.WriteLine("Your Username is too long. It must be under 26 characters long");
                                Console.WriteLine();
                            }
                            else
                            {
                                currentCustomer.UserName = input;
                                if (customerRepo.DoesUsernameExist(currentCustomer))
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
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine();
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
                        try
                        {
                            EnterFullName();
                            Console.Write("Whats your UserName?: ");
                            input = Console.ReadLine();
                            if (input.Length == 0)
                            {
                                throw new ArgumentException("Username must not be empty.", nameof(input));
                            }
                            else if (input.Length > 26)
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
                        catch(ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine();
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

        /// <summary>
        /// Has User enter in their first and last name to store it within our currentCustomer object
        /// </summary>
        private static void EnterFullName()
        {
            while (currentCustomer.FirstName == null)
            {
                try
                {
                    Console.Write("Whats your First Name?: ");
                    input = Console.ReadLine();
                    if (input.Length == 0)
                    {
                        throw new ArgumentException("First name must not be empty.", nameof(input));
                    }
                    currentCustomer.FirstName = input;
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
                
            }
            
            while(currentCustomer.LastName == null)
            {
                try
                {
                    Console.Write("Whats your Last Name?: ");
                    input = Console.ReadLine();
                    if (input.Length == 0)
                    {
                        throw new ArgumentException("Last name must not be empty.", nameof(input));
                    }
                    currentCustomer.LastName = input;
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine();
                }
            }
        }

        /// <summary>
        /// Creates the main menu of our application.
        /// Allows users to choose whether to place an order, view order histories, or exit the application
        /// </summary>
        private static void generateMainMenu()
        {
            while(true)
            {
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Place an Order");
                Console.WriteLine("2. View Order History");
                Console.WriteLine("3. Exit Application");
                Console.WriteLine();
                Console.Write("Enter a valid choice: ");
                input = Console.ReadLine();
                if (input == "1")
                {
                    PlaceAnOrder();
                }
                else if (input == "2")
                {
                    ViewOrderHistories();
                }
                else if (input == "3")
                {
                    return;
                }
                else
                {
                    InvalidInput();
                }
            }
        }

        /// <summary>
        /// Creates UI for placing an order.
        /// User first must choose a location to order from, then they must choose from a list of products to add to their order
        /// </summary>
        private static void PlaceAnOrder()
        {
            OrderHistory currentOrder = new OrderHistory();
            List<Orders> orders = new List<Orders>();
            while (true)
            {
                DisplayLocations();
                Console.WriteLine("Select a location or enter \"b\" to go back to the previous page.");
                Console.Write("Enter a valid choice: ");
                input = Console.ReadLine();
                int locationSelection;
                Location location;
                if (Int32.TryParse(input, out locationSelection))
                {
                    location = locationRepo.GetByID(locationSelection);
                }
                else
                {
                    location = null;
                }

                if (location != null)
                {
                    currentOrder.LocationId = location.LocationId;
                    while (true)
                    {
                        DisplayProducts();
                        Console.WriteLine();
                        Console.WriteLine("Select a product.");
                        Console.WriteLine("When you are finished, enter \"n\" to proceed or enter \"b\" to go back to the previous page.");
                        Console.Write("Enter a valid choice: ");
                        input = Console.ReadLine();
                        int productSelection;
                        Product product;
                        if (Int32.TryParse(input, out productSelection))
                        {
                            product = productRepo.GetById(productSelection + addedProducts.Count);
                        }
                        else
                        {
                            product = null;
                        }

                        if (product != null)
                        {
                            Inventory inventory = inventoryRepo.FindLocationInventory(location, product);
                            Orders customerOrder = AddProduct(product, inventory);
                            orders.Add(customerOrder);
                        }
                        else if (input == "n")
                        {
                            Console.WriteLine();
                            Console.WriteLine("Order Complete");
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
                            addedProducts.Clear();
                            break;
                        }
                        else if (input == "b")
                        {
                            addedProducts.Clear();
                            break;
                        }
                        else
                        {
                            InvalidInput();
                        }
                    }
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

            return;
        }

        /// <summary>
        /// Displays the locations in the DB in a numbered list
        /// </summary>
        private static void DisplayLocations()
        {
            Console.WriteLine();
            foreach (var element in locationRepo.GetAll())
            {
                Console.WriteLine($"{element.LocationId}: {element.Address}, {element.City}, {element.State}");
            }
        }

        /// <summary>
        /// Displays the Products in the DB in a numbered list
        /// </summary>
        private static void DisplayProducts()
        {
            int listCount = 1;
            Console.WriteLine();
            foreach (var element in productRepo.GetAll())
            {
                if(!addedProducts.Contains(element))
                {
                    Console.WriteLine($"{listCount}. {element.Name}: ${element.Price}");
                    listCount++;
                }
            }
        }

        /// <summary>
        /// Has User enter how much of a product they want to order, then adds this product and its quantity to our current order
        /// </summary>
        /// <param name="product"></param>
        /// <param name="inventory"></param>
        /// <returns></returns>
        private static Orders AddProduct(Product product, Inventory inventory)
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
                        addedProducts.Add(product);
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

        /// <summary>
        /// Displays View Order History UI where it asks the user which order histories they would like to view
        /// </summary>
        private static void ViewOrderHistories()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Which Order History would you like to view?");
                Console.WriteLine("1. Your Order History");
                Console.WriteLine("2. A Locations Order History");
                Console.WriteLine("3. Return to previous menu");
                Console.WriteLine();
                Console.Write("Enter a valid choice: ");
                input = Console.ReadLine();

                if (input == "1")
                {
                    while (true)
                    {
                        if(DisplayCustomerOrderHistories(currentCustomer))
                        {
                            Console.WriteLine();
                            Console.WriteLine("Select a Order History or enter \"b\" to go back to the previous page.");
                            Console.Write("Enter a valid choice: ");
                            input = Console.ReadLine();
                            int orderSelection;
                            if (Int32.TryParse(input, out orderSelection))
                            {
                                if(orderSelection > 0 && orderSelection < orderHistories.Count + 1)
                                {
                                    DisplayOrder(orderHistories[orderSelection - 1], false);
                                }
                                else
                                {
                                    InvalidInput();
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
                        else
                        {
                            break;
                        }
                    }
                }
                else if (input == "2")
                {
                    while (true)
                    {
                        DisplayLocations();
                        Console.WriteLine();
                        Console.WriteLine("Select a location or enter \"b\" to go back to the previous page.");
                        Console.Write("Enter a valid choice: ");
                        input = Console.ReadLine();
                        int locationSelection;
                        Location location;
                        if (Int32.TryParse(input, out locationSelection))
                        {
                            location = locationRepo.GetByID(locationSelection);
                        }
                        else
                        {
                            location = null;
                        }

                        if (location != null)
                        {
                            while (true)
                            {
                                if(DisplayLocationOrderHistories(location))
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Select a Order History or enter \"b\" to go back to the previous page.");
                                    Console.Write("Enter a valid choice: ");
                                    input = Console.ReadLine();
                                    int orderSelection;
                                    if (Int32.TryParse(input, out orderSelection))
                                    {
                                        if(orderSelection > 0 && orderSelection < orderHistories.Count + 1)
                                        {
                                            DisplayOrder(orderHistories[orderSelection - 1], true);
                                        }
                                        else
                                        {
                                            InvalidInput();
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
                                else
                                {
                                    break;
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
                else if (input == "3")
                {
                    break;
                }
                else
                {
                    InvalidInput();
                }
            }

            return;
        }

        /// <summary>
        /// Displays the information of an Order, (Customer who made the order, Location order was placed, and products ordered)
        /// </summary>
        /// <param name="orderHistory"></param>
        private static void DisplayOrder(OrderHistory orderHistory, bool viewingLocation)
        {
            var customerRef = OrderHistoryRepo.getCustomerRef(orderHistory);
            Customer customer = customerRef.Customer;
            var locationRef = OrderHistoryRepo.getLocationRef(orderHistory);
            Location location = locationRef.Location;
            //List<Orders> orders = Program.context.Orders.Include(oh => oh.OrderHistory).ToList();
            List<Orders> orders = OrdersRepo.GetAllOrdersInHistory().ToList();

            // added .ToList() in foreach b/c somewhere under the hood, something was indirectly changing my list of orderhistories.
            // so by adding .ToList() it copies the values in orders to a separate new list at the start of the foreach
            foreach(var order in orders.ToList())
            {
                if(order.OrderHistoryId != orderHistory.OrderHistoryId)
                {
                    orders.Remove(order);
                }
            }
            Console.WriteLine();
            if(!viewingLocation)
            {
                Console.WriteLine($"Customer: {customer.FirstName} {customer.LastName}");
            }
            Console.WriteLine($"Store Location: {location.Address}, {location.City}, {location.State}");
            Console.WriteLine("Purchased:");
            double totalSum = 0.0;
            foreach(var order in orders)
            {
                Console.WriteLine($"  {productRepo.GetById(order.ProductId).Name}");
                Console.WriteLine($"    Amount Bought: {order.AmountOrdered}");
                totalSum += OrdersRepo.CalculateTotal(productRepo.GetById(order.ProductId), order);
            }
            Console.WriteLine($"Total cost: ${totalSum}");
        }

        /// <summary>
        /// Displays a list of all of the orders that a customer has made
        /// </summary>
        /// <param name="customer"></param>
        private static bool DisplayCustomerOrderHistories(Customer customer)
        {
            Console.WriteLine();
            //orderHistories = Program.context.OrderHistory.Where(o => o.CustomerId == customer.CustomerId).ToList();
            orderHistories = OrderHistoryRepo.GetAllCustomerOrders(customer).ToList();

            if(orderHistories.Count == 0)
            {
                Console.WriteLine("You haven't made any orders.");
                return false;
            }

            Console.WriteLine($"{customer.FirstName} {customer.LastName} Order History:");
            int count = 1;
            foreach (var history in orderHistories)
            {
                Console.WriteLine($"   {count}: Order placed on {history.TimeOrdered}");
                count++;
            }
            
            return true;
        }

        /// <summary>
        /// Displays a list of all the orders that a location has received
        /// </summary>
        /// <param name="location"></param>
        private static bool DisplayLocationOrderHistories(Location location)
        {
            Console.WriteLine();
            //orderHistories = Program.context.OrderHistory.Where(o => o.LocationId == location.LocationId).ToList();
            orderHistories = OrderHistoryRepo.GetAllLocationOrders(location).ToList();

            if(orderHistories.Count == 0)
            {
                Console.WriteLine("This store location has not received any orders.");
                return false;
            }

            Console.WriteLine($"Order Histories at {location.Address}, {location.City}, {location.State}:");
            int count = 1;
            foreach (var history in orderHistories)
            {
                Console.WriteLine($"   {count}: Order placed on {history.TimeOrdered}");
                count++;
            }

            return true;
        }

        /// <summary>
        /// Contains responses to when a user enters invalid input to any of the requests made by the application
        /// </summary>
        private static void InvalidInput()
        {
            Console.WriteLine();
            Console.WriteLine("That's not a valid choice. Please try again.");
        }
    }
}
