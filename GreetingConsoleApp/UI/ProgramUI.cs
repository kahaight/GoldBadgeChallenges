using GreetingClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreetingConsoleApp.UI
{
    public class ProgramUI
    {
        private int _userInput;
        private bool _exitMenu;
        private bool _exitManageCustomerMenu;
        private bool _exitViewCustomerMenu;
        private bool _exitGetCustomerName;
        private bool _exitGetCustomerId;
        private CustomerRepository _customerRepo = new CustomerRepository();
        private bool _exitAddCustomerMenu;
        public void Run()
        {
            SeedContent();
            _exitMenu = false;
            while (!_exitMenu)
            {
                RunMenu();
            }
        }

        public void RunMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Review Customer Emails\n" +
                "2. Send Customer Emails\n" +
                "3. Manage Customers\n" +
                "4. Exit\n");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        Console.Clear();
                        ReviewCustomerEmails();
                        break;
                    case 2:
                        Console.Clear();
                        SendCustomerEmails();
                        break;
                    case 3:
                        Console.Clear();
                        _exitManageCustomerMenu = false;
                        while (!_exitManageCustomerMenu)
                        {
                            ManageCustomerMenu();
                        }
                        break;
                    case 4:
                        _exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response.\n" +
                    "Press any key to try again");
                Console.ReadKey();
            }
        }

        public void ManageCustomerMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Add a Customer\n" +
                "2. View Customer Details\n" +
                "3. Edit a Customer\n" +
                "4. Delete a Customer\n" +
                "5. Exit to Main Menu.");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        Console.Clear();
                        _exitAddCustomerMenu = false;
                        while (!_exitAddCustomerMenu)
                        {
                            AddCustomerMenu();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        _exitViewCustomerMenu = false;
                        while (!_exitViewCustomerMenu)
                        {
                            ViewCustomerMenu();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        EditCustomer();
                        break;
                    case 4:
                        Console.Clear();
                        DeleteCustomer();
                        break;
                    case 5:
                        _exitManageCustomerMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }

        }
        public void AddCustomerMenu()
        {
            Console.WriteLine("What type of customer are you adding?\n" +
                "1. Current\n" +
                "2. Past\n" +
                "3. Potential\n" +
                "4. Return to Manage Customer Menu");

            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        AddCurrent();
                        break;
                    case 2:
                        AddPast();
                        break;
                    case 3:
                        AddPotential();
                        break;
                    case 4:
                        _exitAddCustomerMenu = true;
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
        }

        public void ViewCustomerMenu()
        {
            Console.WriteLine("What would you like to do?\n" +
                "1. Search for Customer by Name\n" +
                "2. Search for Customer by ID\n" +
                "3. Search for Customer by email\n" +
                "4. Return to Manage Customer Menu\n");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        _exitGetCustomerName = false;
                        while (!_exitGetCustomerName)
                        {
                            GetCustomerByName();
                        }
                        break;
                    case 2:
                        _exitGetCustomerId = false;
                        while (!_exitGetCustomerId)
                        {
                            GetCustomerById();
                        }
                        break;
                    case 3:
                        GetCustomerByEmail();
                        break;
                    case 4:
                        _exitViewCustomerMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid response\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        break;

                }
            }
            else
            {
                Console.WriteLine("Please enter a valid response.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
        }
        public void ReviewCustomerEmails()
        {
            List<ICustomer> customers = _customerRepo.GetCustomerList();
            foreach (ICustomer customer in customers)
            {
                Console.Write(String.Format("|{0,10}|{1,10}|{2,10}|{3,20}| ", customer.FirstName, customer.LastName, customer.Type, customer.Email));
                if (customer.Type == "Current")
                {
                    Console.Write("Thank you for your work with us. We appreciate your loyalty. Here's a coupon.\n");
                }
                else if (customer.Type == "Past")
                {
                    Console.Write("It's been a long time since we've heard from you, we want you back.\n");
                }
                else if (customer.Type == "Potential")
                {
                    Console.Write("We currently have the lowest rates on Helicopter Insurance!\n");
                }
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            //Console.WriteLine(String.Format("|{0,10}|{1, 10}|{2, 35}|{3, 12}|{4, 16}|{5, 13}|{6, 15}|", claimTwo.ClaimId, claimTwo.TypeOfClaim, claimTwo.ClaimDescription, claimTwo.ClaimAmount, claimTwo.DateOfIncident.ToString("yyyy-MM-dd"), claimTwo.DateOfClaim.ToString("yyyy-MM-dd"), claimTwo.IsValid));
        }
        public void SendCustomerEmails()
        {

        }

        public void SeedContent()
        {
            CurrentCustomer customerOne = new CurrentCustomer(1, "Konrad", "Haight", "konradhaight@gmail.com");
            _customerRepo.AddCustomerToList(customerOne);
            PastCustomer customerTwo = new PastCustomer(2, "Nicole", "Haight", "nicole.boyd1123@gmail.com");
            _customerRepo.AddCustomerToList(customerTwo);
            PotentialCustomer customerThree = new PotentialCustomer(3, "Ruby", "Haight", "none");
            _customerRepo.AddCustomerToList(customerThree);
        }

        public void EditCustomer()
        {
            Console.WriteLine("Enter the customer ID:");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                if (_customerRepo.GetCustomerById(_userInput) != null)
                {
                    ICustomer oldCustomer = _customerRepo.GetCustomerById(_userInput);
                    ICustomer newCustomer;

                    if (oldCustomer is CurrentCustomer)
                    {
                        newCustomer = new CurrentCustomer();
                    }
                    else if (oldCustomer is PastCustomer)
                    {
                        newCustomer = new PastCustomer();
                    }
                    else
                        newCustomer = new PotentialCustomer();

                    Console.WriteLine("Enter the new customer ID");
                    newCustomer.Id = Int32.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the new customer first name");
                    newCustomer.FirstName = Console.ReadLine();
                    Console.WriteLine("Enter the new customer last name");
                    newCustomer.LastName = Console.ReadLine();
                    Console.WriteLine("Enter the new customer email");
                    newCustomer.Email = Console.ReadLine();

                    _customerRepo.UpdateExistingCustomer(_userInput, newCustomer);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Failed to locate customer\n" +
                    "Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid customer ID\n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void DeleteCustomer()
        {
            Console.WriteLine("Enter the ID of the customer you wish to delete");
            if(Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                _customerRepo.RemoveCustomerFromList(_customerRepo.GetCustomerById(_userInput));
            }
            else
            {
                Console.WriteLine("Please enter a valid customer ID\n" +
                    "Press any key to try again");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void AddCurrent()
        {
            CurrentCustomer customer = new CurrentCustomer();
            bool parsed = false;
            while (!parsed)
            {

                Console.WriteLine("Enter new customer ID:");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    if (_customerRepo.GetCustomerById(_userInput) == null)
                    {
                        customer.Id = _userInput;
                        parsed = true;
                    }
                    else
                    {
                        Console.WriteLine("This customer ID is already in use.\n" +
                            "Press any key to try again with a different ID.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid customer ID.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                }
            }
            Console.WriteLine("Enter new customer first name:");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter new customer last name:");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter new customer email");
            customer.Email = Console.ReadLine();
            Console.Clear();
            _customerRepo.AddCustomerToList(customer);

        }
        public void AddPast()
        {
            PastCustomer customer = new PastCustomer();
            Console.WriteLine("Enter past customer ID:");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                if (_customerRepo.GetCustomerById(_userInput) == null)
                {
                    customer.Id = _userInput;
                }
                else
                {
                    Console.WriteLine("This customer ID is already in use.\n" +
                        "Press any key to try again with a different ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid customer ID.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
            Console.WriteLine("Enter past customer first name:");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter past customer last name:");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter past customer email");
            customer.Email = Console.ReadLine();
            Console.Clear();
            _customerRepo.AddCustomerToList(customer);

        }
        public void AddPotential()
        {
            PotentialCustomer customer = new PotentialCustomer();
            Console.WriteLine("Enter potential customer ID:");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                if (_customerRepo.GetCustomerById(_userInput) == null)
                {
                    customer.Id = _userInput;
                }
                else
                {
                    Console.WriteLine("This customer ID is already in use.\n" +
                        "Press any key to try again with a different ID.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid customer ID.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
            }
            Console.WriteLine("Enter potential customer first name:");
            customer.FirstName = Console.ReadLine();
            Console.WriteLine("Enter potential customer last name:");
            customer.LastName = Console.ReadLine();
            Console.WriteLine("Enter potential customer email");
            customer.Email = Console.ReadLine();
            Console.Clear();
            _customerRepo.AddCustomerToList(customer);

        }
        public void GetCustomerByName()
        {
            ICustomer customer;
            Console.WriteLine("Enter the first and last name of the customer");
            string name = Console.ReadLine();
            string[] names = name.Split(' ');
            string firstName = names[0];
            string lastName = names[1];
            customer = _customerRepo.GetCustomerByName(firstName, lastName);
            if (customer != null)
            {

                Console.WriteLine($"{customer.Id}\n" +
                    $"{customer.FirstName}\n" +
                    $"{customer.LastName}\n" +
                    $"{customer.Email}\n" +
                    $"{customer.Type}\n" +
                    $"Press any key to continue.");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("Failed to locate customer\n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
            }
            bool parsed = false;
            while (!parsed)
            {

                Console.WriteLine("Search for another customer by name?\n" +
                    "1. Yes\n" +
                    "2. No, return to View Customer Menu\n" +
                    "3. No, return to Manage Customer Menu");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    switch (_userInput)
                    {
                        case 1:
                            parsed = true;
                            break;
                        case 2:
                            parsed = true;
                            _exitGetCustomerName = true;
                            break;
                        case 3:
                            parsed = true;
                            _exitGetCustomerName = true;
                            _exitViewCustomerMenu = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }


        }
        public void GetCustomerById()
        {
            ICustomer customer;
            Console.WriteLine("Enter the customer ID");
            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {

                customer = _customerRepo.GetCustomerById(_userInput);
                if (customer != null)
                {

                    Console.WriteLine($"{customer.Id}\n" +
                        $"{customer.FirstName}\n" +
                        $"{customer.LastName}\n" +
                        $"{customer.Email}\n" +
                        $"{customer.Type}\n" +
                        $"Press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Failed to locate customer\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid ID.\n" +
                    "Press any key to try again.");
                Console.ReadKey();
                Console.Clear();
            }
            bool parsed = false;
            while (!parsed)
            {
                Console.WriteLine("Search for another customer by ID?\n" +
                    "1. Yes\n" +
                    "2. No, return to View Customer Menu\n" +
                    "3. No, return to Manage Customer Menu");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    switch (_userInput)
                    {
                        case 1:
                            parsed = true;
                            break;
                        case 2:
                            parsed = true;
                            _exitGetCustomerId = true;
                            break;
                        case 3:
                            parsed = true;
                            _exitGetCustomerId = true;
                            _exitViewCustomerMenu = true;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid response.\n" +
                        "Press any key to try again.");
                    Console.ReadKey();
                    Console.Clear();
                }

            }
        }

        public void GetCustomerByEmail()
        {
            Console.WriteLine("This option is not functional yet.\n" +
                "Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
