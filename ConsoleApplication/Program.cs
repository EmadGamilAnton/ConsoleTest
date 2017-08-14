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
            Classes.DbOperation dbObject = new Classes.DbOperation();
            for (;;)
            {         
                Console.WriteLine();
                Console.WriteLine("Please Select Operation");
                Console.WriteLine("[1] Insert , [2] Update , [3] Delete , [4] Show Data");

                var x = Console.ReadLine(); //Read input from user

                // there are 4 choices 
                if (x.ToString() == "1")
                {
                    Console.Write("Enter Customer Name : ");
                    var custName = Console.ReadLine();
                    Console.Write("Enter Customer Address : ");
                    var custAddress = Console.ReadLine();

                    dbObject.InsertRecord(custName.ToString(), custAddress.ToString());
                }

                if (x.ToString() == "2")
                {
                    Console.Write("Enter Customer Name : ");
                    var custName = Console.ReadLine();
                    Console.Write("Enter Update Name : ");
                    var newName = Console.ReadLine();

                    dbObject.UpdateRecord(custName.ToString(), newName.ToString());
                }
                if (x.ToString() == "3")
                {
                    Console.Write("Enter Customer Name :- ");
                    var custName = Console.ReadLine();
                    
                    dbObject.DeleteRecord(custName.ToString());
                }

                if (x.ToString() == "4")
                {
                    dbObject.ViewRecords();
                }

            }
        }
    }
}

