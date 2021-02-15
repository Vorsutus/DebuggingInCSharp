using BrownfieldLibrary;
using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //string whatIdid;
            //int i;
            //double totalHours;
            //double ttl = 0;
            //double myTimeInHours;

            //List<TimeSheetEntry> ents = new List<TimeSheetEntry>();
            //TimeSheetEntry ent = new TimeSheetEntry();

            //what job do you do
            //how long do you do it for
            //check the value given by the user
            //add the data as an entry to the TimeSheetEntry

            //ask for more time - if yes repeat, - if no continue
            //check if worked for acme
            //send email to acme
            //calculate total bill for Acme
            //check if worked for ABC
            //send email to ABC
            //calculate total bill for ABC
            //calculate pay and overtime
            //end application

            //Console.Write("Enter what you did and for Acme or ABC?: ");
            //whatIdid = Console.ReadLine();


            //Console.Write("How many hours did you do it for: ");
            //string myHours = Console.ReadLine();
            //checkHoursValid(myHours);
            ////t = int.Parse(Console.ReadLine());

            //ent.WorkDone = whatIdid;
            //ent.WorkedHours = myTimeInHours;
            //ents.Add(ent);

            //Console.Write("Do you want to enter more time:");
            ////bool cont = bool.Parse(Console.ReadLine());
            //string answer = Console.ReadLine();
            //checkMoreTimeValid(answer);


            //while (cont == true)
            //{
            //    Console.Write("Enter what you did and for Acme or ABC?: ");
            //    whatIdid = Console.ReadLine();

            //    Console.Write("How many hours did you do it for: ");
            //    //t = int.Parse(Console.ReadLine());
            //    myHours = Console.ReadLine();
            //    checkHoursValid(myHours);

            //    ent = new TimeSheetEntry(); //this is a new instance, not a ref to the old one
            //    ent.WorkedHours = myTimeInHours;
            //    ent.WorkDone = whatIdid;
            //    ents.Add(ent);

            //    Console.Write("Do you want to enter more time:");
            //    //cont = bool.Parse(Console.ReadLine());
            //    answer = Console.ReadLine();
            //    checkMoreTimeValid(answer);
            //    //cont = false;
            //}


            //REFACTORED creation of new method LoadTimeSheets
            List<TimeSheetEntry> timeSheets = LoadTimeSheets();

            //pull a EmployeeModel reference to a certain employee and call if currentEmployee
            EmployeeModel currentEmployee = DataAccess.GetCurrentEmployee();

            //get me a list of customers we'll call customers of type "CustomerModel" populated by the method DataAccess.GetCustomer()
            List<CustomerModel> customers = DataAccess.GetCustomers();

            //(in one line)
            //Bill each customer in the TimeSheets and send them an email
            customers.ForEach(x => BillCustomer(timeSheets, x));

            //OR (standard way)
            //foreach(var customer in customers)
            //{
            //    //BillCustomer(timeSheets, customer.CustomerName, customer.HourlyRateToBill);
            //    //REFACTORED BillCustomer to just take in the CustomerModel so it can access those properties
            //    BillCustomer(timeSheets, customer);
            //}

            //totalHours = TimeSheetProcessing.GetHoursWorkedForCompany(timeSheets, "Acme");
            //Console.WriteLine();
            //Console.WriteLine("Simulating Sending email to Acme");
            //Console.WriteLine("Your bill is $" + totalHours * 150 + " for the hours worked.");
            //BillCustomer(timeSheets, "Acme", 150);

            //totalHours = TimeSheetProcessing.GetHoursWorkedForCompany(timeSheets, "ABC");
            //Console.WriteLine();
            //Console.WriteLine("Simulating Sending email to ABC");
            //Console.WriteLine("Your bill is $" + totalHours * 125 + " for the hours worked.");
            //BillCustomer(timeSheets, "ABC", 125);

            //totalHours = 0;
            //for (i = 0; i < timeSheets.Count; i++)
            //{
            //    totalHours += timeSheets[i].WorkedHours;
            //}

            //if (totalHours > 40)
            //{

            //    Console.WriteLine("You will get paid $" + ((40 * 10) + ((totalHours - 40) * 15)) + " for your work.");
            //}
            //else
            //{
            //    Console.WriteLine("You will get paid $" + totalHours * 10 + " for your time.");
            //}
            //Pay the employee based on the time sheet entry and the current employees pay rate
            PayEmployee(timeSheets, currentEmployee);

            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }

        private static void PayEmployee(List<TimeSheetEntry> timeSheets, EmployeeModel employee)
        {
            //decimal totalHours = 0;
            //for (i = 0; i < timeSheets.Count; i++)
            //{
            //    totalHours += timeSheets[i].WorkedHours;
            //}

            //if (totalHours > 40)
            //{

            //    Console.WriteLine("You will get paid $" + ((40 * 10) + ((totalHours - 40) * 15)) + " for your work.");
            //}
            //else
            //{
            //Console.WriteLine($"You will get paid " + totalHours * 10 + " for your time.");
            //}

            decimal totalPay = TimeSheetProcessing.CalculateEmployeePay(timeSheets, employee);
            Console.WriteLine($"You will get paid {totalPay} for your time.");
        }

        //returns a Time Sheet Entry when called
        private static List<TimeSheetEntry> LoadTimeSheets()
        {
            List<TimeSheetEntry> output = new List<TimeSheetEntry>();
            string enterMoreTimeSheets = "";

            //"while" runs 0 or more times
            //while (enterMoreTimeSheets == true)
            //"do" loop executes 1 or more times
            do
            {
                Console.Write("Enter what you did and for Acme or ABC?: ");
                string workDone = Console.ReadLine();

                Console.Write("How many hours did you do it for: ");
                //t = int.Parse(Console.ReadLine());
                string rawTimeWorked = Console.ReadLine();
                double timeWorked = checkHoursValid(rawTimeWorked);

                TimeSheetEntry timeSheet = new TimeSheetEntry(); //this is a new instance, not a ref to the old one
                timeSheet.WorkedHours = timeWorked;
                timeSheet.WorkDone = workDone.ToLower();
                output.Add(timeSheet);

                Console.Write("Do you want to enter more time:");
                //cont = bool.Parse(Console.ReadLine());
                enterMoreTimeSheets = Console.ReadLine();

            } while (checkMoreTimeValid(enterMoreTimeSheets) == true);


            return output;
        }

        private static bool checkMoreTimeValid(string moreTimeAnswer)
        {
            while (moreTimeAnswer.ToLower() != "yes" && moreTimeAnswer.ToLower() != "no")
            {
                Console.WriteLine();
                Console.Write("Invalid Entry. Do you want to enter more time:");
                moreTimeAnswer = Console.ReadLine();
            }

            bool isValidAnswer = moreTimeAnswer == "yes" ? true : false;

            return isValidAnswer;
        }

        //Check to see if the User entry was actually a string that could be Parsed as an int
        private static double checkHoursValid(string myLine)
        {
            double myTimeInHours;

            while (double.TryParse(myLine, out myTimeInHours) == false)
            {
                Console.WriteLine();
                Console.Write("Please write numbers rounded to the nearest hour: ");
                myLine = Console.ReadLine();
            }
            return myTimeInHours;
        }

        //private static void BillCustomer(List<TimeSheetEntry> timeSheets, string companyName, decimal hourlyRate)
        private static void BillCustomer(List<TimeSheetEntry> timeSheets, CustomerModel customer)
        {
            double totalHours = TimeSheetProcessing.GetHoursWorkedForCompany(timeSheets, customer.CustomerName);

            Console.WriteLine();
            Console.WriteLine($"Simulating Sending email to {customer.CustomerName}");
            Console.WriteLine("Your bill is $" + (decimal)totalHours * customer.HourlyRateToBill + " for the hours worked.");
        }
    }
}
