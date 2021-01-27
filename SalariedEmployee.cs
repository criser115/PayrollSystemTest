/// <summary>
/// Created by Chris Riser, 10/10/20
/// Adv Software App and Design, CIT-405A
/// Fig. 12.5: SalariedEmployee.cs
/// SalariedEmployee class that extends Employee
/// </summary> 

using System;

namespace PayrollSystemTest
{
    public class SalariedEmployee : Employee
    {
        private decimal weeklySalary;

        // four-parameter constructor
        public SalariedEmployee(string firstName, string lastName, string socialSecurityNumber, Date birthDate, decimal weeklySalary)
            : base(firstName, lastName, socialSecurityNumber, birthDate)
        {
            WeeklySalary = weeklySalary; // validate salary
        }

        // property that gets and sets salaried employee's salary
        public decimal WeeklySalary
        {
            get
            {
                return weeklySalary;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(WeeklySalary)} must be >= 0");
                }
                weeklySalary = value;
            }
        }

        // calculate earnings; override abstact method Earnings in Employee
        public override decimal Earnings() => WeeklySalary;

        // return string representation of SalariedEmployee object
        public override string ToString() =>
            $"salaried employee: {base.ToString()}\n" +
            $"weekly salary: {WeeklySalary:C}";
    }
}
