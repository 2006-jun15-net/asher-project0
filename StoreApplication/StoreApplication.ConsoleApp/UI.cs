using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApplication.ConsoleApp
{
    public static class UI
    {
        public static string IntroMenu()
        {
            Console.WriteLine("Welcome to the store!");
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1.  Sign in");
            Console.WriteLine("2.  Exit store");
            Console.Write("Please enter a valid choice: ");
            var input = Console.ReadLine();
            return input;
        }
    }
}
