using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    struct Contact
    {
        private static int nextId = 1;
        private readonly int id;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string mail;

        public Contact(string firstName, string lastName, string phoneNumber, string mail)
        {
            this.id = nextId++;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.mail = mail;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"ID: {id}\tИмя: {firstName}\tФамилия: {lastName}\tТелефон: {phoneNumber}\tMail: {mail}");
        }

        public static void SortByLastName(Contact[] contacts)
        {
            for (int i = 0; i < contacts.Length - 1; i++)
            {
                for (int j = 0; j < contacts.Length - i - 1; j++)
                {
                    if (string.Compare(contacts[j].lastName, contacts[j + 1].lastName) > 0)
                    {
                        Swap(contacts, j, j + 1);
                    }
                }
            }
        }
        public static void SortByFirstName(Contact[] contacts)
        {
            for (int i = 0; i < contacts.Length - 1; i++)
            {
                for (int j = 0; j < contacts.Length - i - 1; j++)
                {
                    if (string.Compare(contacts[j].firstName, contacts[j + 1].firstName) > 0)
                    {
                        Swap(contacts, j, j + 1);
                    }
                }
            }
        }
        private static void Swap(Contact[] contacts, int index1, int index2)
        {
            Contact temp = contacts[index1];
            contacts[index1] = contacts[index2];
            contacts[index2] = temp;
        }
    }
    class Program
    {
        static void Main()
        {
            Contact[] contacts = new Contact[]
            {
            new Contact("Михаил", "Иванов", "89653422134", "ivanov@mail.com"),
            new Contact("Петр", "Петров", "897654321", "petrov@mail.com"),
            new Contact("Анна", "Смирнова", "89674538890", "smirnova@mail.com"),
            new Contact("Екатерина", "Сидорова", "8975643322", "katesidorova@mail.com"),
            new Contact("Никита", "Рыбаков", "89746782212", "rybakov@mail.com")
            };

            Contact.SortByLastName(contacts);
            Console.WriteLine("Сортировка по фамилии:");
            foreach (var contact in contacts)
            {
                contact.PrintInfo();
            }

            Console.WriteLine();

            Contact.SortByFirstName(contacts);
            Console.WriteLine("Сортировка по имени:");
            foreach (var contact in contacts)
            {
                contact.PrintInfo();
            }
        }
    }
}












































