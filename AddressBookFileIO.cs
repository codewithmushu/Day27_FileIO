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

        public void ReadFromFile()
        {
            string filePath = @"C:\\Users\\91997\\source\\repos\\AddressBook_FileIO\\FileIO.txt";

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("An error occurred while reading the file:");
                Console.WriteLine(e.Message);
            }

        }
    }
}
