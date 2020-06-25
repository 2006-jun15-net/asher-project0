using StoreApplication.Library;
using System;

namespace StoreApplication.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer c = new Customer("Asher", "Williams");
            Console.WriteLine($"First name: {c.firstName}, Last name: {c.lastName}, ID: {c.customerID}");
        }
    }
}
