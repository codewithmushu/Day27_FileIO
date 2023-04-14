using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_FileIO
{
    public class AddressBookFileIO
    {
        public static void WriteToFile(string fileName, List<Person> people)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(fileName))
                {
                    foreach (Person p in people)
                    {
                        sw.WriteLine($"{p.FirstName},{p.LastName},{p.Address},{p.City},{p.State},{p.ZipCode},{p.PhoneNumber},{p.Email}");
                    }
                }
                Console.WriteLine($"Address book has been written to file '{fileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while writing address book to file '{fileName}': {ex.Message}");
            }
        }

        public static List<Person> ReadFromFile(string fileName)
        {
            List<Person> people = new List<Person>();
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] fields = line.Split(',');
                        if (fields.Length == 8)
                        {
                            Person p = new Person()
                            {
                                FirstName = fields[0],
                                LastName = fields[1],
                                Address = fields[2],
                                City = fields[3],
                                State = fields[4],
                                ZipCode = fields[5],
                                PhoneNumber = fields[6],
                                Email = fields[7]
                            };
                            people.Add(p);
                        }
                    }
                }
                Console.WriteLine($"Address book has been read from file '{fileName}'");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while reading address book from file '{fileName}': {ex.Message}");
            }
            return people;
        }
    }
}
