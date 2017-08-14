using ConsoleApplication.Model;
using EntityFramework.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                var db = new pharmacydbEntities();

                Console.WriteLine();
                Console.WriteLine("Please Select Operation");
                Console.WriteLine("[1] Insert , [2] Update , [3] Delete , [4] Show Data");

                var x = Console.ReadLine(); //Read input from user

                // there are 4 choices 
                if (x.ToString() == "1")
                {
                    // Insert  
                    try
                    {
                        var cust = GetCustomers();
                        db.customers.AddRange(cust);
                        db.SaveChanges();
                        Console.WriteLine("Info saved");
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }

                if (x.ToString() == "2")
                {
                    //Update
                    try
                    {
                        customer cu = db.customers.First(c => c.cust_name == "John");
                        {
                            cu.cust_name = "Emad";
                        };
                        db.SaveChanges();
                        Console.WriteLine("Info was Updated");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                if (x.ToString() == "3")
                {
                    //Delete
                    try
                    {
                        var del = (from c in db.customers
                                   where c.cust_name == "Krkr"
                                   select c).First();

                        db.customers.Remove(del);
                        db.SaveChanges();
                        Console.WriteLine("Customer Info Deleted");

                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());
                    }

                }

                if (x.ToString() == "4")
                {
                    //Show recordes
                    try
                    {
                        foreach (var customer in db.customers.ToList())
                        {
                            Console.WriteLine("CustomerInfo - {0}-{1}", customer.cust_name, customer.cust_address);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.ToString());

                    }
                }

            }
        }
        public static List<customer> GetCustomers()
        {
            var customers = new List<Model.customer>
                    {
                        new customer()
                            {
                                cust_name    = "Krkr",
                                cust_address = "Krkr@admin.com"
                            }
            };
            return customers;
        }
    }
}

