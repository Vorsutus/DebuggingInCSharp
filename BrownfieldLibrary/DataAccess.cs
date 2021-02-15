using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    //static because we aren't saving data too the class, just accessing it to get information
    public static class DataAccess
    {
        //this is a Data Model List - Class that holds data
        //static because just retrieving data, not saving to it
        public static List<CustomerModel> GetCustomers()
        {
            //Normally would ask Dapper to get something from the Database here

            //Simulate getting something from the Database
            //instantiate a List of Customers based on whats in the CustomerModel Class
            List<CustomerModel> output = new List<CustomerModel>();
            output.Add(new CustomerModel { CustomerName = "Acme", HourlyRateToBill = 150 });
            output.Add(new CustomerModel { CustomerName = "ABC", HourlyRateToBill = 125 });

            return output;
        }

        //another call to the simulated data
        public static EmployeeModel GetCurrentEmployee()
        {
            EmployeeModel output = new EmployeeModel 
            { 
                FirstName = "Steve", 
                LastName = "Rogers", 
                HourlyRate = 10 
            };

            return output;
        }
    }
}
