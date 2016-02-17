﻿using RJ.BLL;
using RJ.Poco;
using RJ.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RJ.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //CsvHelper();
                
                //PalindromeTest();
                //TestRecusrion();
                //TestSelectMany();
                Console.WriteLine("Please enter a number");
                int number = Convert.ToInt32(Console.ReadLine());
                var fib = PrintFibonacciRecursively(number);
                foreach (var item in fib)
                {
                    Console.WriteLine(item);  
                }
                             
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Hit enter to Reprocess ");
                var result = Console.ReadLine();
                if (result == "1")
                {
                    TestRecusrion();
                }
            }
            //Console.WriteLine("Finished wrting to the file");
            Console.ReadKey();

        }

        public static List<int> PrintFibonacci(int number)
        {
            List<int> result = new List<int>();
            if (number == 0)
            {
                result.Add(0);
                return result;
            }
            else if (number == 1)
            {
                result.Add(0);
                return result;
            }
            else if (number == 2)
            {
                result.AddRange(new List<int>() { 0, 1 });
                return result;
            }
            else
            {
                //if we got thus far,we should have f1,f2 and f3 as fibonacci numbers
                int f1 = 0,
                    f2 = 1;

                result.AddRange(new List<int>() { f1, f2 });
                for (int i = 2; i < number; i++)
                {
                    result.Add(result[i - 1] + result[i - 2]);
                }
            }
            return result;

        }

        private static void TestSelectMany()
        {

            var orders = new List<Order>
            {
              new Order{OrderId = 1,Packages = new List<Package>()
              {
                new Package{PackageId = 1,OrderId = 1,ShipDate = new DateTime(2015,12,31),
                            Items = new List<PackageItems>(){new PackageItems{PackageItemId = 1,PackageId = 1,Qty = 10,Size = "SM"},
                                                             new PackageItems{PackageItemId = 2,PackageId = 2,Qty = 10,Size = "XL"}}},
                new Package{PackageId = 2,OrderId = 1,ShipDate = new DateTime(2015,12,25),
                            Items = new List<PackageItems>(){new PackageItems{PackageItemId = 3,PackageId = 1,Qty = 10,Size = "SM"},
                                                             new PackageItems{PackageItemId = 4,PackageId = 2,Qty = 10,Size = "XL"}}},
                new Package{PackageId = 3,OrderId = 1,ShipDate = new DateTime(2016,02,10),
                            Items = new List<PackageItems>(){new PackageItems{PackageItemId = 5,PackageId = 1,Qty = 10,Size = "SM"},
                                                             new PackageItems{PackageItemId = 6,PackageId = 2,Qty = 10,Size = "XL"}}}
              }}
            };

            var packageItemIds = orders.SelectMany(o => o.Packages)
                                        .SelectMany(p => p.Items)
                                        .Where(pi => pi.Qty > 0 && pi.Size.ToLower().Equals("xl"))
                                        .Select(pki => pki.PackageItemId)
                                        .Distinct()
                                        .ToList();
            foreach (var item in packageItemIds)
            {
                Console.WriteLine(item);
            }
        }

        private static void CsvHelperMethod()
        {
            CsvHelper.WriteCsv<Person>(GetPersons(), @"C:\Test\Person.csv", "|");
            CsvHelper.ReportBurstFiles(@"C:\Test\Reports.csv", "|");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(DateTime.Now.ToString("ddMMyyyyhhmmsstt"));
            }
        }

        private static void TestRecusrion()
        {
            var meItems = new MenuItemsService().MenuItemReadAll().Result;
            foreach (var item in meItems)
            {
                Console.WriteLine("{0} {1} {2}", item.ParentId, item.DisplayName, item.Url);
            }
        }

        private static void PalindromeTest()
        {
            Console.WriteLine("Enter the word");
            string val = Console.ReadLine();
            Console.WriteLine(IsPalindrome(val));
        }

        public static  bool IsPalindrome(string word)
        {
            //first reverse the string
            string reversedString = new string(word.Reverse().ToArray());
            return string.Compare(word, reversedString) == 0 ? true : false;
        }

        private static string ReverseString(string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        private static void TestPolymorphism()
        {
            var shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Triangle());
            foreach (var shape in shapes)
            {
                shape.Draw();
            }
        }

        private static void PrintHeader()
        {
            string[] columns = new string[] { "PersonId", "FirstName", "LastName" };
            string header = string.Join("|", columns);
            Console.WriteLine(header);
        }

        private static List<Person> GetPersons()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 10; i++)
            {
                persons.Add(new Person
                {
                    FirstName = "Rennish_" + i.ToString(),
                    LastName = "Joseph_" + i.ToString(),
                    PersonId = i,
                    ZipCode = "32225_" + i.ToString()
                });
            }
            return persons;
        }
    }

    public enum ConsoleActions
    { 
        PrintHeader = 1,
    }

    #region C# Interview Prep
    public class Shape
    {
        public virtual void Draw()
        {
            Console.WriteLine("Base classes Draw");
        }
    }
    public class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circles draw gets called");
            base.Draw();
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Drawing a Triangle");
            base.Draw();
        }
    }
    
    #endregion
    
}
