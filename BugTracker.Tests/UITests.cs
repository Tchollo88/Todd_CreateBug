using System;
using System.IO;

namespace BugTracker.Tests
{
 
    using BugTracker.Core;
    using System.Text;

    public class UITests
    {
        // Encodes and captures the output of the console
        private class TestOutput : TextWriter
        {
            public override Encoding Encoding => Encoding.UTF8; // <-- This is the encoding used for the output
            public StringWriter StringWriter = new StringWriter(); // <-- This is the StringWriter used to capture the output
            public override void WriteLine(string? value) => StringWriter.WriteLine(value);
            public override void Write(string? value) => StringWriter.Write(value);
        }

        #region ** Display Menu Tests **
        [Fact] // Checks to see if the menu displays correctly
        public void DisplayMenu_DisplaysMenuText()
        {
            // Arrange  
            var sw = new StringWriter(); // Create the writer FIRST
            var menu = new BugMenuUI(sw); // Inject it here

            // Act  
            menu.DisplayMenu(() => 'X', skipClear: true); // Simulate invalid input  

            // Capture output
            var output = sw.ToString();

            // Optionally, print to console to debug
            Console.WriteLine("Captured Output:");
            Console.WriteLine(output);

            // Assert  
            Assert.Contains("BUG TRACKER MENU", output);
            Assert.Contains("(C) Create Bug", output);
            Assert.Contains("Invalid option", output);
        }

        [Fact] // Checks to see if input routs to the correct method and pushes the correct action
        public void DisplayMenu_WhenInputIsC_CallsOnCreateBug()
        {
            // Arrange
            var output = new TestOutput();
            var menu = new BugMenuUI(output);
            bool createBugCalled = false;
            menu.OnCreateBug = () => createBugCalled = true;

            // Act
            menu.DisplayMenu(() => 'C', skipClear: true);

            // Assert
            Assert.True(createBugCalled);
        }
        #endregion

        #region ** Bug Details Test **

        [Fact]
        public void DisplayBugDetails_DisplaysCorrectDetails()
        {
            // Arrange
            var bug = new Bug(1, "Test Bug", "This is a test bug", 1, 1);
            var output = new StringWriter();
            var ticket = new BugMenuUI(output); // Pass the output to the class

            // Act
            ticket.DisplayBugDetails(bug, skipClear: true); // Skip Console.Clear and ReadKey
            string printedOutput = output.ToString();

            // Assert
            Assert.Contains("BUG  TICKET", printedOutput);
            Assert.Contains("Test Bug", printedOutput);
            Assert.Contains("This is a test bug".Substring(0, 18), printedOutput); // Truncated output
            Assert.Contains("1", printedOutput);
            Assert.Contains("1", printedOutput);
        }

        #endregion

        #region ** View Bugs Tests **
        [Fact]
        public void ViewBugs_SortedByTitle_OrderShouldChange()
        {
            // Arrange
            var bugs = new List<Bug>();
            var output = new TestOutput();
            var userView = new BugMenuUI(output); // Pass the output to the class

            // Act
            bugs = userView.SortedContent(ConsoleKey.T, null, true);

            // Assert
            Assert.Equal(bugs[0].BugId, 2);
            Assert.Equal(bugs[1].BugId, 3);
            Assert.Equal(bugs[2].BugId, 1);
        }
        [Fact]
        public void ViewBugs_SortedByStatus_OrderShouldChange()
        {
            // Arrange
            var bugs = new List<Bug>();
            var output = new TestOutput();
            var userView = new BugMenuUI(output); // Pass the output to the class

            // Act
            bugs = userView.SortedContent(ConsoleKey.S, null, true);

            // Assert
            Assert.Equal(bugs[0].BugId, 1);
            Assert.Equal(bugs[1].BugId, 3);
            Assert.Equal(bugs[2].BugId, 2);
        }
        #endregion
    }
}
