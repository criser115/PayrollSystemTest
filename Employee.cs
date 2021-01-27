/// <summary>
/// Created by Chris Riser, 10/10/20
/// Adv Software App and Design, CIT-405A
/// Fig. 12.4: Employee.cs
/// Employee abstract base class.
/// </summary>

namespace PayrollSystemTest
{
    public abstract class Employee
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string SocialSecurityNumber { get; }
        private Date BirthDate { get; }

        // three-parameter constructor
        public Employee(string firstName, string lastName, string socialSecurityNumber, Date birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            SocialSecurityNumber = socialSecurityNumber;
            BirthDate = birthDate;
        }

        // return string representation of Employee object, using properties
        public override string ToString() => $"{FirstName} {LastName}\n" + $"social security number: {SocialSecurityNumber}\n" + $"birthdate: {BirthDate}";

        // abstract method overridden by derived classes
        public abstract decimal Earnings();              
                
    }
}
