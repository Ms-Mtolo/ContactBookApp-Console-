using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactBookApp
{
    // Step 2: Create an object (class) to represent a Contact
    public class Contact
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }

    class Program
    {
        // Step 2: Store the contacts in a data structure (List acts as a dynamic array)
        static List<Contact> contactList = new List<Contact>();

        static void Main(string[] args)
        {
            bool exitApp = false;

            while (!exitApp)
            {
                // Step 1: Create an interface (Menu)
                Console.WriteLine("\n=================================");
                Console.WriteLine("       SIMPLE CONTACT BOOK       ");
                Console.WriteLine("=================================");
                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("2. View All Contacts");
                Console.WriteLine("3. Search Contact by Name");
                Console.WriteLine("4. Delete Contact");
                Console.WriteLine("5. Exit");
                Console.Write("Select an option (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddContact();
                        break;
                    case "2":
                        ViewContacts();
                        break;
                    case "3":
                        SearchContact();
                        break;
                    case "4":
                        DeleteContact();
                        break;
                    case "5":
                        exitApp = true;
                        Console.WriteLine("Exiting application. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        // --- METHODS FOR EACH FEATURE ---

        // Step 1: Interface for adding a new contact
        static void AddContact()
        {
            Console.WriteLine("\n--- Add New Contact ---");

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();

            // Basic validation to ensure they aren't blank
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(phone))
            {
                Console.WriteLine("Error: Name and Phone Number cannot be empty.");
                return;
            }

            // Create the new contact object and add it to our list
            Contact newContact = new Contact
            {
                Name = name,
                PhoneNumber = phone,
                Email = email
            };

            contactList.Add(newContact);
            Console.WriteLine($"Success: Contact '{name}' added to your book!");
        }

        // Step 3: Display a list of all stored contacts
        static void ViewContacts()
        {
            Console.WriteLine("\n--- All Contacts ---");

            if (contactList.Count == 0)
            {
                Console.WriteLine("Your contact book is empty.");
                return;
            }

            foreach (var contact in contactList)
            {
                Console.WriteLine($"Name:  {contact.Name}");
                Console.WriteLine($"Phone: {contact.PhoneNumber}");
                Console.WriteLine($"Email: {contact.Email}");
                Console.WriteLine("-------------------------");
            }
        }

        // Step 4: Search for contacts by name
        static void SearchContact()
        {
            Console.WriteLine("\n--- Search Contact ---");
            Console.Write("Enter name to search: ");
            string searchTerm = Console.ReadLine().ToLower();

            // Use LINQ to find any contact whose name contains the search term
            var results = contactList.Where(c => c.Name.ToLower().Contains(searchTerm)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No contacts found matching that name.");
            }
            else
            {
                Console.WriteLine($"\nFound {results.Count} matching contact(s):");
                foreach (var contact in results)
                {
                    Console.WriteLine($"Name:  {contact.Name}");
                    Console.WriteLine($"Phone: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine("-------------------------");
                }
            }
        }

        // Step 5: Delete a contact from the list
        static void DeleteContact()
        {
            Console.WriteLine("\n--- Delete Contact ---");

            if (contactList.Count == 0)
            {
                Console.WriteLine("Your contact book is empty. Nothing to delete.");
                return;
            }

            Console.Write("Enter the exact name of the contact to delete: ");
            string nameToDelete = Console.ReadLine();

            // Find the first contact that matches the exact name (ignoring case)
            Contact contactToRemove = contactList.FirstOrDefault(c => c.Name.Equals(nameToDelete, StringComparison.OrdinalIgnoreCase));

            if (contactToRemove != null)
            {
                contactList.Remove(contactToRemove);
                Console.WriteLine($"Success: Contact '{contactToRemove.Name}' has been deleted.");
            }
            else
            {
                Console.WriteLine("Contact not found. Please check the spelling.");
            }
        }
    }
}