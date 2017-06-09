using System;
using System.Collections.Generic;

namespace EventManager
{
    public class Menu
    {
        private Database database = new Database();

        public void Main()
        {
            Console.Clear();
            Console.WriteLine("Event Manager Main Menu:");
            Console.WriteLine("[1] Create event");
            Console.WriteLine("[2] Show all events");
            Console.WriteLine("[3] Update Event");
            Console.WriteLine("[4] Delete Event");
            Console.WriteLine("[5] Exit");
            Console.Write("Choose option: ");
            bool successful = false;
            while (!successful)
            {
                string choice = Console.ReadLine();
                successful = true;
                switch (choice)
                {
                    case "1":
                        CreateEvent();
                        break;
                    case "2":
                        ShowAllEvents();
                        break;
                    case "3":
                        UpdateEvent();
                        break;
                    case "4":
                        DeleteEvent();
                        break;
                    case "5":
                        Environment.Exit(0);
                        break;
                    default:
                        successful = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }

        public void CreateEvent()
        {
            Console.Clear();
            Console.WriteLine("Create Event:");
            Console.WriteLine("\nName: ");
            string name = string.Empty;
            bool successfulInput = false;
            while (!successfulInput)
            {
                successfulInput = true;
                name = Console.ReadLine();
                if(name == string.Empty)
                {
                    successfulInput = false;
                    Console.WriteLine("Please enter name!");
                }
            }
            Console.WriteLine("\nLocation: ");
            string location = string.Empty;
            successfulInput = false;
            while (!successfulInput)
            {
                successfulInput = true;
                location = Console.ReadLine();
                if (location == string.Empty)
                {
                    successfulInput = false;
                    Console.WriteLine("Please enter location!");
                }
            }
            Console.WriteLine("\nStart date and time in current format(yyyy-MM-dd HH:mm:ss):");
            bool successfulDataParse = false;
            DateTime startDateTime = new DateTime();
            string startDateTimeInput = string.Empty;
            while (!successfulDataParse)
            {
                successfulDataParse = true;
                startDateTimeInput = Console.ReadLine();
                try
                {
                    startDateTime = DateTime.ParseExact(startDateTimeInput, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    successfulDataParse = false;
                    Console.WriteLine("Incorrect! Try Again!");
                }
            }
            Console.WriteLine("\nEnd date and time in current format(yyyy-MM-dd HH:mm:ss):");
            successfulDataParse = false;
            DateTime endDateTime = new DateTime();
            string endDateTimeInput = string.Empty;
            while (!successfulDataParse)
            {
                successfulDataParse = true;
                endDateTimeInput = Console.ReadLine();
                try
                {
                    endDateTime = DateTime.ParseExact(endDateTimeInput, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    successfulDataParse = false;
                    Console.WriteLine("Incorrect! Try Again!");
                }
                int dateResult = DateTime.Compare(startDateTime, endDateTime);
                if(dateResult >= 0)
                {
                    successfulDataParse = false;
                    Console.WriteLine();
                    Console.WriteLine("End date and time CANNOT be before start date and time!");
                    Console.WriteLine("Please input end date and time again!");
                }
            }
            database.CreateEvent(name, location, startDateTime, endDateTime);
            Console.WriteLine();
            Console.WriteLine("Event Created Successful!");
            Console.WriteLine();
            Console.WriteLine("[1] Create new event");
            Console.WriteLine("[2] Back to the main menu");
            Console.WriteLine("[3] Exit");
            Console.Write("Choose option: ");
            bool successfulChoice = false;
            while (!successfulChoice)
            {
                string choice = Console.ReadLine();
                successfulChoice = true;
                switch (choice)
                {
                    case "1":
                        CreateEvent();
                        break;
                    case "2":
                        Main();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        successfulChoice = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }

        public void ShowAllEvents()
        {
            Console.Clear();
            database.ShowAllEvents();
            Console.WriteLine("[1] Back to the main menu");
            Console.WriteLine("[2] Exit");
            Console.Write("Choose option: ");
            bool successfulChoice = false;
            while (!successfulChoice)
            {
                string choice = Console.ReadLine();
                successfulChoice = true;
                switch (choice)
                {
                    case "1":
                        Main();
                        break;
                    case "2":
                        Environment.Exit(0);
                        break;
                    default:
                        successfulChoice = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }

        public void UpdateEvent()
        {
            Console.Clear();
            database.ShowAllEvents();
            List<int> allIds = new List<int>();
            database.GetAllIds(allIds);
            Console.WriteLine("Which event do you want to update (choose by ID): ");
            bool successfulChoice = false;
            string choice = string.Empty;
            int idToUpdate = 0;
            while (!successfulChoice)
            {
                successfulChoice = true;
                choice = Console.ReadLine();
                try
                {
                    idToUpdate = int.Parse(choice);
                }
                catch (Exception)
                {
                    successfulChoice = false;
                }
                if (successfulChoice)
                {
                    successfulChoice = false;
                    foreach(int id in allIds)
                    {
                        if (idToUpdate == id)
                        {
                            successfulChoice = true;
                            break;
                        }
                    }
                    if (successfulChoice)
                    {
                        break;
                    }
                }
                Console.WriteLine("Try Again!");
            }
            Console.Clear();
            database.ShowEventById(idToUpdate);
            Console.WriteLine("Choose an element to update: ");
            Console.WriteLine("[1] Name");
            Console.WriteLine("[2] Location");
            Console.WriteLine("[3] Start date and time");
            Console.WriteLine("[4] End date and time");
            Console.WriteLine("[5] Cancel and return to main menu");
            Console.WriteLine("Choose option: ");
            successfulChoice = false;
            while (!successfulChoice)
            {
                choice = Console.ReadLine();
                successfulChoice = true;
                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Input new name: ");
                        string newName = Console.ReadLine();
                        database.UpdateName(idToUpdate, newName);
                        break;
                    case "2":
                        Console.WriteLine("Input new location: ");
                        string newLocation = Console.ReadLine();
                        database.UpdateLocation(idToUpdate, newLocation);
                        break;
                    case "3":
                        DateTime startDateTime = new DateTime();
                        bool successfulDataParse = false;
                        string startDateTimeInput = string.Empty;
                        while (!successfulDataParse)
                        {
                            successfulDataParse = true;
                            Console.WriteLine("\nStart date and time in current format(yyyy-MM-dd HH:mm:ss):");
                            startDateTimeInput = Console.ReadLine();
                            try
                            {
                                startDateTime = DateTime.ParseExact(startDateTimeInput, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                successfulDataParse = false;
                                Console.WriteLine("Incorrect! Try Again!");
                            }
                        }
                        database.UpdateStartDateTime(idToUpdate, startDateTime);
                        break;
                    case "4":
                        bool successfulEndDataParse = false;
                        DateTime endDateTime = new DateTime();
                        string endDateTimeInput = string.Empty;
                        while (!successfulEndDataParse)
                        {
                            successfulEndDataParse = true;
                            Console.WriteLine("\nEnd date and time in current format(yyyy-MM-dd HH:mm:ss):");
                            endDateTimeInput = Console.ReadLine();
                            try
                            {
                                endDateTime = DateTime.ParseExact(endDateTimeInput, "yyyy-MM-dd HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
                            }
                            catch (Exception)
                            {
                                successfulEndDataParse = false;
                                Console.WriteLine("Incorrect! Try Again!");
                            }
                        }
                        database.UpdateEndDateTime(idToUpdate, endDateTime);
                        break;
                    case "5":
                        Main();
                        break;
                    default:
                        successfulChoice = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
            Console.Clear();
            Console.WriteLine("Event updated: ");
            database.ShowEventById(idToUpdate);
            Console.WriteLine("[1] Update other event");
            Console.WriteLine("[2] Back to the main menu");
            Console.WriteLine("[3] Exit");
            Console.Write("Choose option: ");
            successfulChoice = false;
            while (!successfulChoice)
            {
                choice = Console.ReadLine();
                successfulChoice = true;
                switch (choice)
                {
                    case "1":
                        UpdateEvent();
                        break;
                    case "2":
                        Main();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        successfulChoice = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }

        public void DeleteEvent()
        {
            Console.Clear();
            database.ShowAllEvents();
            List<int> allIds = new List<int>();
            database.GetAllIds(allIds);
            Console.WriteLine("Which event do you want to delete (choose by ID): ");
            bool successfulChoice = false;
            string choice = string.Empty;
            int idToDelete = 0;
            while (!successfulChoice)
            {
                successfulChoice = true;
                choice = Console.ReadLine();
                try
                {
                    idToDelete = int.Parse(choice);
                }
                catch (Exception)
                {
                    successfulChoice = false;
                }
                if (successfulChoice)
                {
                    successfulChoice = false;
                    foreach (int id in allIds)
                    {
                        if (idToDelete == id)
                        {
                            successfulChoice = true;
                            break;
                        }
                    }
                    if (successfulChoice)
                    {
                        break;
                    }
                }
                Console.WriteLine("Try Again!");
            }
            database.DeleteEventById(idToDelete);
            Console.WriteLine();
            Console.WriteLine("Event deleted successfully!");
            Console.WriteLine("[1] Delete other event");
            Console.WriteLine("[2] Back to the main menu");
            Console.WriteLine("[3] Exit");
            Console.Write("Choose option: ");
            successfulChoice = false;
            while (!successfulChoice)
            {
                choice = Console.ReadLine();
                successfulChoice = true;
                switch (choice)
                {
                    case "1":
                        DeleteEvent();
                        break;
                    case "2":
                        Main();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        successfulChoice = false;
                        Console.WriteLine("Try Again!");
                        break;
                }
            }
        }
    }
}
