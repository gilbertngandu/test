using ServiceLayer.Models.Address;
using ServiceLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
namespace ServiceLayer
{
    public class Program
    {
        private static CommonFactorService _commonFactorService;
        private static AddressService _addressService;
        
        static void Main(string[] args)
        {
            _commonFactorService = new CommonFactorService();
            _addressService = new AddressService();

            int[] testNumbers = new int[]
            {
                 8, 12, 24, 32
            };

            var result = _commonFactorService.highestCommonFactor(testNumbers);
            Console.WriteLine("Given the following set of numbers:");
            var list = testNumbers.ToList();
            list.ForEach((x) =>
            {
                Console.WriteLine(x);
            });
            Console.WriteLine("The Highest common factor is " + result);
            //Get Data from JSON
            _addressService.loadAddresses().Wait();

            Console.WriteLine("All Addresses");
            PrintAllToConsole(_addressService.Addresses);
            Console.WriteLine();
            Console.WriteLine("Specific Address Types");
            PrintByType(_addressService.Addresses, "business");
            Console.WriteLine();
            Console.WriteLine("Show invalid Addresses");
            PrintAllToConsole(_addressService.Addresses, showInvalid: true);
            Console.WriteLine();
            Console.ReadLine();

        }

        public static List<Address> PrintAllToConsole(List<Address> allAddresses, bool showInvalid = false)
        {
            string reason = String.Empty;
            List<Address> addresses = allAddresses;
            addresses.ForEach(a =>
            {
                Console.BackgroundColor = ConsoleColor.Black;
                if (showInvalid)
                {
                    if (a.IsValid(out reason))
                    {
                        Console.WriteLine(a.PrettyPrintAddress());
                    } else
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine(reason+" ** " + a.PrettyPrintAddress());
                    }
                } else
                {
                    Console.WriteLine(a.PrettyPrintAddress());
                }
            });
            return addresses;
        }

        public static List<Address> PrintByType(List<Address> allAddresses, string type, bool excludeInvalid = false)
        {

            string reason = "";
            List<Address> addresses = new List<Address>();
            addresses = allAddresses.Where(a => (a.type?.name != null &&
                                                a.type.name.ToLower().Contains(type.ToLower())
                                                )).ToList();
            addresses.ForEach(a =>
            {
                if (excludeInvalid)
                {
                    if (a.IsValid(out reason))
                    {
                        Console.WriteLine(reason +" ** " +a.PrettyPrintAddress());
                    }
                } else
                {
                    Console.WriteLine(a.PrettyPrintAddress());
                }
            });
            return addresses;
        }
    }
}
