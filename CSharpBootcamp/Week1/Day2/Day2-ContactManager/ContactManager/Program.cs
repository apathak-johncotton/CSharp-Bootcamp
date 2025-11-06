namespace ContactManager
{
    public class Program
    {
        List<Contact> Contacts = new List<Contact>();
        static void Main(string[] args)
        {
            Program obj = new Program();
            var contact1 = new Contact("Ankit", "123", "abc@abc.com");
            var contact2 = new Contact("Ankita", "1234", "abca@abc.com");
            obj.Contacts.Add(contact1);
            obj.Contacts.Add(contact2 );
            obj.ListContacts();
            obj.SearchByName("Ankit");
            obj.DeleteByName("Ankit");
        }

        public void ListContacts()
        {
            foreach (var contact in Contacts)
            {
                Console.WriteLine($"Contact - {contact.Name}, {contact.Phone}, {contact.Email}");
            }
        }

        public void SearchByName(string name)
        {
            var contact = Contacts.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            Console.WriteLine($"Contact - {contact.Name}, {contact.Phone}, {contact.Email}");
        }

        public void DeleteByName(string name)
        {
            var contact = Contacts.Where(c => c.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            Contacts.Remove(contact);
            Console.WriteLine($"Contact removed - {contact.Name}, {contact.Phone}, {contact.Email}");
        }
    }
}
