using ConsoleApplication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Classes
{
    class DbOperation
    {
        public void ViewRecords()
        {
            var db = new pharmacydbEntities();

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

        public string InsertRecord(string custName,string custAddress)
        {
            var db = new pharmacydbEntities();

            // Insert  
            try
            {
                var cust = GetCustomers(custName,custAddress);
                db.customers.AddRange(cust);
                db.SaveChanges();
                Console.WriteLine("Info saved");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return custName;
        }

        public string UpdateRecord(string custName,string newName)
        {
            var db = new pharmacydbEntities();

            //Update
            try
            {
                customer cu = db.customers.First(c => c.cust_name == custName);
                {
                    cu.cust_name = newName;
                };
                db.SaveChanges();
                Console.WriteLine("Info was Updated");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return custName;
        }

        public string DeleteRecord(string custName)
        {
            var db = new pharmacydbEntities();
            //Delete
            try
            {
                var del = (from c in db.customers
                           where c.cust_name == custName
                           select c).First();

                db.customers.Remove(del);
                db.SaveChanges();
                Console.WriteLine("Customer Info Deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return custName;

        }

        public static List<customer> GetCustomers(string custName,string custAddress)
        {
            var customers = new List<customer>
                    {
                        new customer()
                            {
                                cust_name    = custName,
                                cust_address = custAddress
                            }
            };
            return customers;
        }

    }
}

