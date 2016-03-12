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
        private string _filepath = System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/contactlist.xml");
        public List<Contact> _contacts;

        public void LoadAll()
        {
            LoadFromDb();
            if (_contacts == null)
                _contacts = new List<Contact>();
        }

        public void Add(Contact contact)
        {
            int id = 0;
            id = _contacts.Max(x => x.Id) + 1;
            contact.Id = id;
            _contacts.Add(contact);
            SavetoXml();
        }

        private void LoadFromDb()
        {
            if (!File.Exists(_filepath))
            {
                return;
            }

            XmlSerializer x = new XmlSerializer(typeof(List<Contact>));
            using (FileStream fs = new FileStream(_filepath, FileMode.Open))
            {
                XmlReader r = XmlReader.Create(fs);
                _contacts = (List<Contact>)x.Deserialize(r);
            }
        }

        public List<Contact> List()
        {
            return _contacts;
        }

        private void SavetoXml()
        {
            XmlSerializer x = new XmlSerializer(_contacts.GetType());
            using (TextWriter writer = new StreamWriter(_filepath))
            {
                x.Serialize(writer, _contacts);
            }
        }
    }
}
