using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core
{
    public class BugMenuUI
    {
        #region ** UI Display **
        private readonly TextWriter _output; // <-- This is a private field that is used to write to the console

        public BugMenuUI(TextWriter output = null) // <-- This is a constructor that takes a TextWriter as an argument
        {                                           // if no TextWriter is provided, it will use the default console output
            _output = output ?? Console.Out;
        }

        // These are injectable callbacks, so we can mock them in tests
        public Action OnCreateBug = () => { /*Console.WriteLine("You chose to Create a Bug.");*/ };
        public Action OnViewBugList = () => { };
        public Action OnAssignBug = () => { };
        public Action OnDeleteBug = () => { };


        #region ** Menu **
        public void DisplayMenu(Func<char> inputProvider, bool skipClear = false) // <-- Func<char> is a delegate type that
        {                                                                             // takes a function that returns a char
            if (!skipClear)
            { Console.Clear(); } // <-- This allows us to skip the clear screen for testing purposes
            _output.WriteLine("==========================================");
            _output.WriteLine("|             BUG TRACKER MENU           |");
            _output.WriteLine("==========================================");
            _output.WriteLine("| (C) Create Bug                         |");
            _output.WriteLine("| (V) View Bug List                      |");
            _output.WriteLine("| (A) Assign to Developer                |");
            _output.WriteLine("| (D) Delete Bug                         |");
            _output.WriteLine("==========================================");

            _output.WriteLine("Please select an option: ");
            char userChoice = char.ToUpper(inputProvider());
            _output.WriteLine("\n");
            switch (userChoice)
            {
                case 'C':
                    if (!skipClear) // <-- This is used to skip the clear screen for testing purposes
                    { CreateBug(); }
                    else { OnCreateBug(); }
                    break;
                case 'V':
                    if (!skipClear)
                    { /*View List method goes here*/ }
                    else { OnViewBugList(); }
                    break;
                case 'A':
                    if (!skipClear)
                    { /*Assign Developer method goes here*/ }
                    else { OnAssignBug(); }
                    break;
                case 'D':
                    if (!skipClear)
                    { /*Delete method goes here*/ }
                    else { OnDeleteBug(); }
                    break;
                default:
                    _output.WriteLine("Invalid option. Please try again.");
                    if(!skipClear)
                    { DisplayMenu(() => Console.ReadKey().KeyChar); }
                    break;
            }
        }
        #endregion
        #region ** Bug Display **
        public void DisplayBugDetails(Bug bug, bool skipClear = false)
        { // in "{bug.BugId,-18}|" the "18" means that the text will be aligned and take up 18 characters
          // + numbers are right aligned, - numbers are left aligned
            if (!skipClear)
            { Console.Clear(); }
            _output.WriteLine("==========================================");
            _output.WriteLine("|               BUG  TICKET              |");
            _output.WriteLine("==========================================");
            _output.WriteLine($"| Bug ID:                {bug.BugId,-18}|");
            _output.WriteLine($"| Title:                 {bug.Title,-18}|");
            _output.WriteLine($"| Description:           {Truncate(bug.Description, 18),-18}|");
            _output.WriteLine($"| Priority:              {bug.Priority,-18}|");
            _output.WriteLine($"| Severity:              {bug.Severity,-18}|");
            _output.WriteLine($"| Status:                {bug.Status,-18}|");
            _output.WriteLine($"| Assigned To Developer: {bug.AssignedToDeveloper,-18}|");
            _output.WriteLine("==========================================");
            if (!skipClear)
            {
                _output.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
                DisplayMenu(() => Console.ReadKey().KeyChar); // < -- Is how to call the menu again with reference to the input 
            }                                                      // provider
        }  
        #endregion

        #region ** Helper Methods **
        private string Truncate(string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                return text.Substring(0, maxLength - 3) + "...";
            }
            return text;
        }                                                    // provider
        #endregion

        #endregion

        #region ** Create Bug **
        public void CreateBug()
        {
            BugService bugService = new BugService(); // Create an instance of BugService
            Bug bug;
            bool skipClear = false; // This is used to skip the clear screen for testing purposes

            if (!skipClear)
            { Console.Clear(); }
            _output.WriteLine("What is the bug's title?");
            string title = Console.ReadLine();

            if (!skipClear)
            { Console.Clear(); }
            _output.WriteLine("What is the bugs description?");
            string description = Console.ReadLine();

            if (!skipClear)
            { Console.Clear(); }
            _output.WriteLine("What is the bugs priority? (1 = Low, 2 = Medium, 3 = High)");
            string priorityInput = Console.ReadLine();
            
            if (!int.TryParse(priorityInput, out int parsedPriority) || parsedPriority < 1 || parsedPriority > 3)
            {// checks if the input is a number and if it is between 1 and 3
                // if not, it will return an error message
                _output.WriteLine("Invalid input. Please enter a number between 1 and 3.");
                return;
            }
             int priority = parsedPriority;

            if (!skipClear)
            { Console.Clear(); }
            _output.WriteLine("What is the bugs severity? (1 = Trivial, 2 = Minor, 3 = Major, 4 = Critical)");
            string severityInput = Console.ReadLine();
            
            if (!int.TryParse(severityInput, out int parsedSeverity) || parsedSeverity < 1 || parsedSeverity > 4)
            {// checks if the input is a number and if it is between 1 and 4
                // if not, it will return an error message
                _output.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                return;
            }
            int severity = parsedSeverity;

            bug = bugService.CreateBug(title, description, priority, severity); // Call the CreateBug method from BugService
            DisplayBugDetails(bug); // Display the bug details
        }
        #endregion


    }
}

