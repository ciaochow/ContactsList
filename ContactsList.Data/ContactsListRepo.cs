using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using ContactsList.Model;

namespace ContactsList.Data
{
    public class ContactsListRepo
    {
        TextFileWriter contactBook = new TextFileWriter(@"..\..\Contacts\ContactBook.txt");

        public List<Contact> AllContacts()
        {
            List<Contact> allContacts = new List<Contact>();
            string[] allLines = contactBook.ReturnAllLines();
            foreach (string line in allLines)
            {
                string[] columns = line.Split(',');
                Contact contact = new Contact();
                contact.FirstName = columns[0];
                contact.LastName = columns[1];
                contact.Phone = columns[2];
                contact.Email = columns[3];
                allContacts.Add(contact);
            }
            return allContacts;
        }

        public Contact AddContact(Contact contact)
        {
            string newcontact = contact.FirstName + ',' + contact.LastName + ',' + contact.Phone + ',' + contact.Email;
            contactBook.WriteToFile(newcontact);
            return contact;
        }
    }
}
