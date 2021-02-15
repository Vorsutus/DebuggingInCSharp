using BrownfieldLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownfieldLibrary
{
    //static so that we can't store data in the processor
    public static class TimeSheetProcessing
    {
        public static double GetHoursWorkedForCompany(List<TimeSheetEntry> timeSheets, string companyName)
        {
            double output = 0;

            for (int i = 0; i < timeSheets.Count; i++)
            {
                if (timeSheets[i].WorkDone.Contains(companyName.ToLower()))
                {
                    //ttl += i; //only adds 1 job
                    output += timeSheets[i].WorkedHours; //adds the hours for the job to the total
                }
            }
            return output;
        }

        public static decimal CalculateEmployeePay(List<TimeSheetEntry> timeSheets, EmployeeModel employee )
        {
            decimal output = 0;
            double totalHours = 0;

            for (int i = 0; i < timeSheets.Count; i++)
            {
                totalHours += timeSheets[i].WorkedHours;
            }

            if (totalHours > 40)
            {

                //Console.WriteLine("You will get paid $" + ((40 * 10) + ((totalHours - 40) * 15)) + " for your work.");
                output = (decimal)( ((decimal)(totalHours - 40) * (employee.HourlyRate * 1.5M)) + (40M * employee.HourlyRate) );
                //(decimal)totalHours * employee.HourlyRate) +
            }
            else
            {
                //Console.WriteLine("You will get paid $" + totalHours * 10 + " for your time.");
                output = (decimal)totalHours * employee.HourlyRate;
            }

            return output;
        }
    }
}
