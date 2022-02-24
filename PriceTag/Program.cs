using PriceTag.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PriceTag
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            Console.Write("Enter the number of products:");
            int number = int.Parse(Console.ReadLine());

            for (int index = 1; index <= number; index++)
            {
                Console.WriteLine($"Product #{index} data:");

                Console.Write("Common, used or imported (c/u/i)? ");
                char type = char.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                switch (type){
                    case 'c':
                        products.Add(new Product(name, price));
                        break;

                    case 'u':
                        Console.Write("Manufacture date (DD/MM/YYYY): ");
                        DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

                        products.Add(new UsedProduct(name, price, manufactureDate));
                        break;

                    case 'i':
                        Console.Write("Customs fee: ");
                        double customsFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                        products.Add(new ImportedProduct(name, price, customsFee));
                        break;
                }
            }

            Console.WriteLine();
            Console.WriteLine("PRICE TAGS:");

            for (int i = 0; i < number; i++)
            {
                Console.WriteLine(products[i].PriceTag());
            }
        }
    }
}
