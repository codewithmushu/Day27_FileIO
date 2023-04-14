using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_FileIO
{
    public class AddressBook
    {
        private List<Person> people = new List<Person>();

        public void AddPerson(Person person)
        {
            if (!people.Any(p => p.FirstName.Equals(person.FirstName, StringComparison.OrdinalIgnoreCase)))
            {
                people.Add(person);
                Console.WriteLine($"Added {person.FirstName} {person.LastName} to the address book.");
            }
            else
            {
                Console.WriteLine($"A person with the name {person.FirstName} already exists in the address book.");
            }
        }

        public void GetCountByCity()
        {
            var result = people.GroupBy(p => p.City.ToLower())
                               .Select(g => new { City = g.Key, Count = g.Count() });
            if (result.Any())
            {
                Console.WriteLine("Number of persons in each city:");
                foreach (var group in result)
                {
                    Console.WriteLine($"{group.City}: {group.Count}");
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        public void GetCountByState()
        {
            var result = people.GroupBy(p => p.State.ToLower())
                               .Select(g => new { State = g.Key, Count = g.Count() });
            if (result.Any())
            {
                Console.WriteLine("Number of persons in each state:");
                foreach (var group in result)
                {
                    Console.WriteLine($"{group.State}: {group.Count}");
                }
            }
            else
            {
                Console.WriteLine("No data found.");
            }
        }

        private List<Person> addressBook = new List<Person>();

        public void WriteToFile()
        {
            string filePath = @"C:\\Users\\91997\\source\\repos\\AddressBook_FileIO\\FileIO.txt";

            using (StreamWriter writer = File.AppendText(filePath))
            {
                foreach (var person in addressBook)
                {
                    writer.WriteLine($"{person.FirstName},{person.LastName},{person.Address},{person.City},{person.State},{person.ZipCode},{person.PhoneNumber},{person.Email}");
                }
                Console.WriteLine("Address book written to file successfully.");
            }
        }
    }
}
