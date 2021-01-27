/// <summary>
/// Created by Chris Riser, 10/10/20
/// Adv Software App and Design, CIT-405A
/// Session 6 Payroll System Modification Programming Exercise (12.9)
/// This program will create employee objects from different class. 
/// There is a base employee class and derived classed for each employee type. 
/// and pay rate and will calculate gross pay
/// </summary>

using System;
using System.Collections.Generic;

namespace PayrollSystemTest
{
    class PayrollSystemTest
    {
        static void Main(string[] args)
        {
            // create birthday objects for each employee
            var birthday1 = new Date(2, 15, 1963);
            var birthday2 = new Date(4, 15, 1992);
            var birthday3 = new Date(9, 19, 1971);
            var birthday4 = new Date(12, 1, 1987);

            // create derived-class objects
            var salariedEmployee = new SalariedEmployee("Jim", "Miller", "777-77-7777", birthday1, 2650.00M);
            var hourlyEmployee = new HourlyEmployee("Thomas", "Swoon", "888-88-8888", birthday2, 27.0M, 40.0M);
            var commissionEmployee = new CommissionEmployee("Sam", "Overton", "444-44-4444", birthday3, 8650.00M, .15M);
            var basePlusCommissionEmployee = new BasePlusCommissionEmployee("Rufus", "Mitchell", "333-33-3333", birthday4, 12520.00M, .08M, 100.00M);

            Console.WriteLine("Employee processed individually:\n");
            Console.WriteLine($"{salariedEmployee}\nearned: " + $"{salariedEmployee.Earnings():C}\n");
            Console.WriteLine($"{hourlyEmployee}\nearned: {hourlyEmployee.Earnings():C}\n");
            Console.WriteLine($"{commissionEmployee}\nearned: " + $"{commissionEmployee.Earnings():C}\n");
            Console.WriteLine($"{basePlusCommissionEmployee}\nearned: " + $"{basePlusCommissionEmployee.Earnings():C}\n");

            // create List<Employee> and initialize with employee objects
            var employees = new List<Employee>() { salariedEmployee, hourlyEmployee, commissionEmployee, basePlusCommissionEmployee };

            // create array with the employee's birthday months
            int[] birthdayMonths = { birthday1.Month, birthday2.Month, birthday3.Month, birthday4.Month };
            
            string[] monthsList = { "null", "Jan.", "Feb.", "Mar.", "Apr.", "May", "June", "July", "Aug.", "Sept.", "Oct.", "Nov.", "Dec." };            

            
            Console.WriteLine("Employees processed polymorphically:\n");
            
            // counter to index though employee's birthday months list
            int counter = 0;

            // generically process each element in employees
            foreach (var currentEmployee in employees)
            {
                // varibale to add the employees monthly eranings
                decimal total = 0;
                Console.WriteLine(currentEmployee); // invokes ToString                
                
                // display each employee monthly earning and birthday month bonus  
                for (int months = 1; months <= 12; ++months)
                {
                    int currentEmployeeBirthdayMonth = birthdayMonths[counter];

                    if (currentEmployeeBirthdayMonth == months)
                    {
                        decimal monthlyBonus = currentEmployee.Earnings() + 100.0M;
                        Console.WriteLine($"{monthsList[months],12}: {monthlyBonus,10:C} Bonus Month!");
                        total += monthlyBonus;
                    }
                    else
                    {
                        Console.WriteLine($"{monthsList[months],12}: {currentEmployee.Earnings(),10:C}");
                        total += currentEmployee.Earnings();
                    }              
                    
                }
                
                // display total earnings
                Console.WriteLine($"Total earned: {total:C}\n");

                // incrementing the index counter
                counter++;
            }
            Console.ReadLine();
        }
    }
}

