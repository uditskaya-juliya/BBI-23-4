using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2
{
    abstract class Person
    {
        protected string firstName;
        protected string lastName;

        public string FirstName { get { return firstName; } }
        public string LastName { get { return lastName; } }

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public abstract void PrintInfo();
    }

    class Employee : Person
    {
        private double salary;
        private DateTime hireDate;

        public double Salary { get { return salary; } }
        public DateTime HireDate { get { return hireDate; } }

        public Employee(string firstName, string lastName, double salary, DateTime hireDate) : base(firstName, lastName)
        {
            this.salary = salary;
            this.hireDate = hireDate;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}\tSalary: {Salary}\tHire Date: {HireDate}");
        }
    }

    class Counteragent : Person
    {
        private double contractCost;
        private int contractDuration;

        public double ContractCost { get { return contractCost; } }
        public int ContractDuration { get { return contractDuration; } }

        public Counteragent(string firstName, string lastName, double contractCost, int contractDuration) : base(firstName, lastName)
        {
            this.contractCost = contractCost;
            this.contractDuration = contractDuration;
        }

        public override void PrintInfo()
        {
            Console.WriteLine($"Name: {FirstName} {LastName}\tContract Cost: {ContractCost}\tContract Duration: {ContractDuration} days");
        }
    }

    class Program
    {
        static void Main()
        {
            Person[] people = new Person[]
            {
            new Employee("Anna", "D", 50000, new DateTime(2010, 5, 15)),
            new Employee("Alice", "Smirn", 60000, new DateTime(2015, 8, 20)),
            new Employee("Viktor", "Nikitin", 55000, new DateTime(2012, 3, 10)),
            new Employee("Eva", "Timof", 52000, new DateTime(2018, 7, 25)),
            new Employee("David", "Smirnov", 53000, new DateTime(2014, 9, 30)),
            new Counteragent("Olya", "Larina", 100000, 365),
            new Counteragent("Sophia", "Kotova", 80000, 180),
            new Counteragent("Danila", "Krutov", 120000, 240),
            new Counteragent("Lera", "Moroz", 90000, 300),
            new Counteragent("Katya", "Volkova", 95000, 200)
            };

            for (int i = 0; i < people.Length - 1; i++)
            {
                for (int j = 0; j < people.Length - i - 1; j++)
                {
                    if (string.Compare(people[j].LastName, people[j + 1].LastName) > 0)
                    {
                        var temp = people[j];
                        people[j] = people[j + 1];
                        people[j + 1] = temp;
                    }
                }
            }

            Console.WriteLine("Employees:");
            Console.WriteLine("Name\tSalary\tHire Date");
            foreach (var person in people)
            {
                if (person is Employee)
                {
                    person.PrintInfo();
                }
            }
            Console.WriteLine("\nCounteragents:");
            Console.WriteLine("Name\tContract Cost\tContract Duration");
            foreach (var person in people)
            {
                if (person is Counteragent)
                {
                    person.PrintInfo();
                }
            }
            Console.WriteLine("\nAll People:");
            Console.WriteLine("Name\tSalary/Contract Cost\tHire Date/Contract Duration");
            foreach (var person in people)
            {
                person.PrintInfo();
            }
        }
    }
}
