using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook_FileIO
{
    public class Program
    {
        static void Main(string[] args)
        {
           // string filePath = @"C:\\Users\\91997\\source\\repos\\AddressBook_FileIO\\FileIO.txt";

            AddressBookFileIO addressBook = new AddressBookFileIO();
            AddressBook Person = new AddressBook();

            Person.AddPerson(new Person
            {
                FirstName = "Muskan",
                LastName = "Shaikh",
                Address = "557 Shaniwar peth",
                City = "Satara",
                State = "Maharashtra",
                ZipCode = "415002",
                PhoneNumber = "9975001230",
                Email = "mushk1111shaikh@gamil.com"
            });

            addressBook.WriteToFile();
            addressBook.ReadFromFile();


           
           

        }

    }

}
