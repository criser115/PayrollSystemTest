/// <summary>
/// Created by Chris Riser, 10/10/20
/// Adv Software App and Design, CIT-405A
/// Fig. 12.8: BasePlusCommissionEmployee.cs
/// BasePlusCommissionEmployee class that extends CommissionEmployee.
/// </summary>

using System;

namespace PayrollSystemTest
{
    public class BasePlusCommissionEmployee : CommissionEmployee
    {
        private decimal baseSalary; // base salary per week

        // six-parameter constructor
        public BasePlusCommissionEmployee(string firstName, string lastName, string socialSecurityNumber, Date birthDate, decimal grossSales,
            decimal commissionRate, decimal baseSalary) : base(firstName, lastName, socialSecurityNumber, birthDate, grossSales,commissionRate)
        {
            BaseSalary = baseSalary; // validates base salary
        }

        // property that gets and sets
        // BasePlusCommissionEmployee's base salary
        public decimal BaseSalary
        {
            get
            {
                return baseSalary;
            }
            set
            {
                if (value < 0) // validation
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        value, $"{nameof(BaseSalary)} must be >= 0");
                }

                baseSalary = value;
            }
        }

        // calculate earnings
        public override decimal Earnings() => BaseSalary + base.Earnings();
        
        // return string representation of BasePlusCommissionEmployee
        public override string ToString() => $"base-salaried {base.ToString()}\nbase salary: {BaseSalary:C}";
    }
}


