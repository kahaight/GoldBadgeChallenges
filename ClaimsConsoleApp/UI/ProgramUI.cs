using ClaimsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsConsoleApp.UI
{
    class ProgramUI
    {
        private readonly ClaimRepository _claimRepo = new ClaimRepository();
        private bool _exitMenu = false;
        private bool _userInputParsed = false;
        private int _userInput;
        private string _userStringInput;
        private decimal _userDecimalInput;
        public void Run()
        {
            SeedContent();
            while (!_exitMenu)
            {
                RunMenu();
            }
        }

        public void RunMenu()
        {
            Console.WriteLine("Welcome to Komodo Insurance Claims Handling\n" +
                "What would you like to do?\n" +
                "1. See all claims\n" +
                "2. Handle next claim\n" +
                "3. Enter a new claim\n" +
                "4. Exit");

            if (Int32.TryParse(Console.ReadLine(), out _userInput))
            {
                switch (_userInput)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        HandleNextClaim();
                        break;
                    case 3:
                        EnterNewClaim();
                        break;
                    case 4:
                        _exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option\n" +
                            "Press any key to try again");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid option\n" +
                    "Press any key to try again");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public void SeeAllClaims()
        {
            //int columnWidth = 0;
            Queue<Claim> claimQueue = _claimRepo.GetAllClaims();

            //foreach(Claim claimOne in claimQueue)
            //{
            //    if (claimOne.ClaimDescription.Length > columnWidth)
            //    {
            //        columnWidth = claimOne.ClaimDescription.Length;
            //    }
            //}

            Console.WriteLine(String.Format("|{0,10}|{1, 10}|{2, 35}|{3, 12}|{4, 16}|{5, 13}|{6, 15}|", "Claim ID", "Claim Type", "Claim Description", "Claim Amount", "Date Of Incident", "Date Of Claim", "Claim Is Valid"));

            foreach (Claim claimTwo in claimQueue)
            {
                Console.WriteLine(String.Format("|{0,10}|{1, 10}|{2, 35}|{3, 12}|{4, 16}|{5, 13}|{6, 15}|", claimTwo.ClaimId, claimTwo.TypeOfClaim, claimTwo.ClaimDescription, claimTwo.ClaimAmount, claimTwo.DateOfIncident.ToString("yyyy-MM-dd"), claimTwo.DateOfClaim.ToString("yyyy-MM-dd"), claimTwo.IsValid));
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
        public void HandleNextClaim()
        {
            Console.Clear();
            Claim nextClaim = _claimRepo.GetNextClaim();
            Console.WriteLine($"Claim ID: {nextClaim.ClaimId}\n" +
                $"Claim Type: {nextClaim.TypeOfClaim}\n" +
                $"Description: {nextClaim.ClaimDescription}\n" +
                $"Claim Amount: {nextClaim.ClaimAmount}\n" +
                $"Date of Incident: {nextClaim.DateOfIncident.ToString("yyyy-MM-dd")}\n" +
                $"Date of Claim: {nextClaim.DateOfClaim.ToString("yyyy-MM-dd")}\n" +
                $"Claim is valid: {nextClaim.IsValid}");
            _userInputParsed = false;
            while (!_userInputParsed)
            {
                Console.WriteLine("Would you like to handle this claim now?\n" +
                    "1. Yes\n" +
                    "2. No (return to main menu");
                if (Int32.TryParse(Console.ReadLine(), out _userInput))
                {
                    switch (_userInput)
                    {
                        case 1:
                            _claimRepo.RemoveClaim(nextClaim);
                            _userInputParsed = true;
                            Console.Clear();
                            break;
                        case 2:
                            _userInputParsed = true;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
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
        public void EnterNewClaim()
        {
            Claim newClaim = new Claim();
            bool newClaimConfirmed = false;
            while (!newClaimConfirmed)
            {
                bool parsed = false;
                while (!parsed)
                {
                    Console.WriteLine("Enter the claim ID:");
                    if (Int32.TryParse(Console.ReadLine(), out _userInput))
                    {
                        newClaim.ClaimId = _userInput;
                        parsed = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
                parsed = false;
                while (!parsed)
                {
                    ClaimType typeOfClaim;
                    Console.WriteLine("Enter the claim type:\n" +
                        "Car\n" +
                        "Home\n" +
                        "Theft");
                    if (Enum.TryParse(Console.ReadLine(), out typeOfClaim))
                    {
                        newClaim.TypeOfClaim = typeOfClaim;
                        parsed = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
                parsed = false;
                while (!parsed)
                {
                    Console.Clear();
                    Console.WriteLine("Enter the claim description:");
                    _userStringInput = Console.ReadLine();
                    bool confirmed = false;
                    while (!confirmed)
                    {
                        Console.WriteLine($"You entered {_userStringInput}.\n" +
                            $"Confirm description?\n" +
                            $"1.) Yes\n" +
                            $"2.) No\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            switch (_userInput)
                            {
                                case 1:
                                    newClaim.ClaimDescription = _userStringInput;
                                    parsed = true;
                                    confirmed = true;
                                    Console.Clear();
                                    break;

                                case 2:
                                    Console.WriteLine("Press any key to re-enter the description");
                                    confirmed = true;
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;

                                default:
                                    Console.WriteLine("Please enter a valid number.\n" +
                                        "Press any key to continue");
                                    Console.ReadKey();
                                    Console.Clear();
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

                parsed = false;
                while (!parsed)
                {
                    Console.WriteLine("Enter the claim amount:\n");
                    if (Decimal.TryParse(Console.ReadLine(), out _userDecimalInput))
                    {
                        newClaim.ClaimAmount = _userDecimalInput;
                        parsed = true;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid response.\n" +
                            "Press any key to try again.");
                        Console.ReadKey();
                        Console.Clear();
                        continue;
                    }
                }
                Console.Clear();
                int year = 0;
                int month = 0;
                int day = 0;
                bool incidentDateConfirmed = false;
                while (!incidentDateConfirmed)
                {


                    bool incidentYearConfirmed = false;
                    while (!incidentYearConfirmed)
                    {
                        Console.WriteLine("Enter the incident year:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            year = _userInput;
                            incidentYearConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    bool incidentMonthConfirmed = false;
                    while (!incidentMonthConfirmed)
                    {
                        Console.WriteLine("Enter the incident month:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            month = _userInput;
                            incidentMonthConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }

                    bool incidentDayConfirmed = false;
                    while (!incidentDayConfirmed)
                    {

                        Console.WriteLine("Enter the incident day:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            day = _userInput;
                            incidentDayConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    Console.Clear();
                    DateTime incidentDate = new DateTime(year, month, day);
                    Console.WriteLine($"You entered {incidentDate.ToString("yyyy-MM-dd")}\n" +
                        $"1. Confirm incident date\n" +
                        $"2. Re-enter incident date\n");

                    parsed = false;
                    while (!parsed)
                    {


                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            switch (_userInput)
                            {
                                case 1:
                                    newClaim.DateOfIncident = incidentDate;
                                    incidentDateConfirmed = true;
                                    parsed = true;
                                    break;
                                case 2:
                                    Console.WriteLine("Press any key to re-enter the date");
                                    Console.ReadKey();
                                    parsed = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid repsonse\n" +
                                        "Press any key to try again.");
                                    Console.ReadKey();
                                    break;

                            }

                        }

                    }


                }
                Console.Clear();
                bool claimDateConfirmed = false;
                while (!claimDateConfirmed)
                {
                    bool claimYearConfirmed = false;
                    while (!claimYearConfirmed)
                    {
                        Console.WriteLine("Enter the claim year:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            year = _userInput;
                            claimYearConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    bool claimMonthConfirmed = false;
                    while (!claimMonthConfirmed)
                    {
                        Console.WriteLine("Enter the claim month:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            month = _userInput;
                            claimMonthConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }

                    bool claimDayConfirmed = false;
                    while (!claimDayConfirmed)
                    {

                        Console.WriteLine("Enter the claim day:\n");
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            day = _userInput;
                            claimDayConfirmed = true;
                        }
                        else
                        {
                            Console.WriteLine("Please enter a valid response.\n" +
                                "Press any key to try again.");
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        }
                    }
                    Console.Clear();
                    DateTime claimDate = new DateTime(year, month, day);
                    Console.WriteLine($"You entered {claimDate.ToString("yyyy-MM-dd")}\n" +
                        $"1. Confirm claim date\n" +
                        $"2. Re-enter claim date\n");
                    parsed = false;
                    while (!parsed)
                    {
                        if (Int32.TryParse(Console.ReadLine(), out _userInput))
                        {
                            switch (_userInput)
                            {
                                case 1:
                                    newClaim.DateOfClaim = claimDate;
                                    claimDateConfirmed = true;
                                    parsed = true;
                                    break;
                                case 2:
                                    Console.WriteLine("Press any key to re-enter the date");
                                    Console.ReadKey();
                                    parsed = true;
                                    break;
                                default:
                                    Console.WriteLine("Please enter a valid repsonse\n" +
                                        "Press any key to try again.");
                                    Console.ReadKey();
                                    break;
                            }
                        }
                    }
                }
                Console.Clear();
                Console.WriteLine($"You entered:\n" +
                    $"Claim ID: {newClaim.ClaimId}\n" +
                    $"Claim Type: {newClaim.TypeOfClaim}\n" +
                    $"Description: {newClaim.ClaimDescription}\n" +
                    $"Claim Amount: {newClaim.ClaimAmount}\n" +
                    $"Date of Incident: {newClaim.DateOfIncident.ToString("yyyy-MM-dd")}\n" +
                    $"Date of Claim: {newClaim.DateOfClaim.ToString("yyyy-MM-dd")}\n" +
                    $"Confirm new claim?\n" +
                    $"1. Yes (add claim to repository)\n" +
                    $"2. No (re-enter claim information)\n");
                parsed = false;
                while (!parsed)
                {
                    if (Int32.TryParse(Console.ReadLine(), out _userInput))
                    {
                        switch (_userInput)
                        {
                            case 1:
                                _claimRepo.AddNewClaim(newClaim);
                                newClaimConfirmed = true;
                                parsed = true;
                                break;
                            case 2:
                                parsed = true;
                                break;
                            default:
                                Console.WriteLine("Please enter a valid response.\n" +
                                    "Press any key to try again.");
                                Console.ReadKey();
                                break;
                        }
                    }
                }
            }
        }
        public void SeedContent()
        {
            Claim claimOne = new Claim(1, ClaimType.Car, "Claimant rear-ended insured", 1000.50m, new DateTime(2020, 2, 14), new DateTime(2020, 2, 18));
            _claimRepo.AddNewClaim(claimOne);
            Claim claimTwo = new Claim(2, ClaimType.Home, "Water leaking from pipe in basement", 2150.58m, new DateTime(2020, 2, 13), new DateTime(2020, 2, 18));
            _claimRepo.AddNewClaim(claimTwo);
            Claim claimThree = new Claim(3, ClaimType.Theft, "Robbery", 540.34m, new DateTime(2020, 1, 14), new DateTime(2020, 2, 18));
            _claimRepo.AddNewClaim(claimThree);
        }
    }
}

