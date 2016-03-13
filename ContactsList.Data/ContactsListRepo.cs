using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
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
            for (int i = 0; i < allLines.Length; i++)
            {
                string[] columns = allLines[i].Split(',');
                Contact contact = new Contact();
                contact.Id = i;
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
            string newcontact = ContactToString(contact);
            contactBook.WriteToFile(newcontact);
            return contact;
        }

        
        public Contact RemoveContact(int id)
        {
            Contact contact = new Contact();
             contact = AllContacts()[id];
            ////contact = contacts[id];
            
            
            string contacttodelete = ContactToString(contact);
            contactBook.DeleteFromFile(contacttodelete);
            return contact;
        }

        public string ContactToString(Contact contact)
        {

            return contact.FirstName + ',' + contact.LastName + ',' + contact.Phone + ',' + contact.Email;

        }

        public Contact StringToContact(string text)
        {
            string[] columns = text.Split(',');
            Contact contact = new Contact();
            contact.FirstName = columns[0];
            contact.LastName = columns[1];
            contact.Phone = columns[2];
            contact.Email = columns[3];
            return contact;
        }

    }
}
