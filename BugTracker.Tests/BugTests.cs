namespace BugTracker.Tests
{
    using BugTracker.Core;
    public class BugTests
    {
        [Fact]
        public void ValidConstructorTest()
        {
            Bug bug = new Bug(0,"Constructor","Valid constructor test");
            Assert.IsType<Bug>(bug);
        }
        [Fact]
        public void UpdateStatusTestOpen()
        {
            Bug bug = new Bug(1, "Open", "Tests Open status");
            bug.UpdateStatus((BugStatus)1);
            bug.UpdateStatus((BugStatus)0);
            Assert.Equal(BugStatus.Open, bug.Status);
        }
        [Fact]
        public void UpdateStatusTestInProgress()
        {
            Bug bug = new Bug(2, "InProgress", "Tests InProgress status");
            bug.UpdateStatus((BugStatus)1);
            Assert.Equal(BugStatus.InProgress, bug.Status);
        }
        [Fact]
        public void UpdateStatusTestResolved()
        {
            Bug bug = new Bug(3, "Resolved", "Tests Resolved status");
            bug.UpdateStatus((BugStatus)2);
            Assert.Equal(BugStatus.Resolved, bug.Status);
        }
        [Fact]
        public void UpdateStatusTestClosed()
        {
            Bug bug = new Bug(4, "Closed", "Tests Closed status");
            bug.UpdateStatus((BugStatus)3);
            Assert.Equal(BugStatus.Closed, bug.Status);
        }

        [Fact]
        public void Constructor_ValidInput_InitializesCorrectly()
        {
            // Arrange & Act
            var bug = new Bug(5, "Login fails", "Fails with correct credentials");

            // Assert
            Assert.Equal(5, bug.BugId);
            Assert.Equal("Login fails", bug.Title);
            Assert.Equal("Fails with correct credentials", bug.Description);
            Assert.Equal(BugStatus.Open, bug.Status);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void Constructor_InvalidTitle_ThrowsArgumentException(string invalidTitle)
        {
            // Arrange, Act & Assert
            // TODO: Uncomment this after implementing the guard clause
            var ex = Assert.Throws<ArgumentException>(() => new Bug(1, invalidTitle, "desc"));
            Assert.Equal("Title cannot be null, empty, or whitespace.", ex.Message);
        }

        [Fact]
        public void UpdateStatus_ChangesStatus_ToNewStatus()
        {
            // Arrange
            var bug = new Bug(6, "Icon missing", "Settings icon not visible");

            // Act
            bug.UpdateStatus(BugStatus.Resolved);

            // Assert
            Assert.Equal((BugStatus)2, bug.Status);
        }

        [Fact]
        public void UpdateStatus_ChangesStatus_FromOldStatus()
        {
            // Arrange
            var bug = new Bug(8, "Icon missing", "Settings icon not visible");
            var initialStatus = bug.Status;
            // Act
            bug.UpdateStatus(BugStatus.Resolved);

            // Assert
            Assert.NotEqual(initialStatus, bug.Status);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void UpdateStatus_ToSameStatus_ThrowsArgumentException(int status)
        {
            if (status == 0)
            {
                // Arrange
                var bug = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                // Act
                var ex = Assert.Throws<ArgumentException>(() => bug.UpdateStatus((BugStatus)status));
                // Assert
                Assert.True(ex.Message == "Status is already set to the same value.");
            }
            else
            {
                // Arrange
                var bug = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                // Assignes the bug status to the same value as the one being tested
                bug.UpdateStatus((BugStatus)status);
                // Act
                var ex = Assert.Throws<ArgumentException>(() => bug.UpdateStatus((BugStatus)status));
                // Assert
                Assert.Equal("Status is already set to the same value.", ex.Message);
            }
        }

        [Fact]
        public void Constructor_AssignedToDeveloper_DefaultsToNull()
        {
            // Arrange & Act
            var bug = new Bug(9, "Login fails", "Fails with correct credentials");
            // Assert
            Assert.Null(bug.AssignedToDeveloper);
        }

        [Fact]
        public void UpdateAssignedToDeveloper_ChangesAssignedToDeveloper()
        {
            // Arrange
            var bug = new Bug(10, "Login fails", "Fails with correct credentials");
            string developerName = "John Doe";
            // Act
            bug.UpdateAssignedToDeveloper(developerName);
            // Assert
            Assert.Equal(developerName, bug.AssignedToDeveloper);
        }
    }
    public class BugServiceTests
    {
        [Fact]
        public void DeleteBug_ShouldRemoveBug_WhenBugExists()
        {
            // Arrange
            var service = new BugService();
            var bug = service.CreateBug("Test Bug", "Sample description", 1, 2);
            int bugId = bug.BugId;

            // Act
            bool result = service.DeleteBug(bugId);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(service.getBugs, b => b.BugId == bugId);
        }

        [Fact]
        public void DeleteBug_ShouldReturnFalse_WhenBugDoesNotExist()
        {
            // Arrange
            var service = new BugService();
            int nonExistentBugId = 999;

            // Act
            bool result = service.DeleteBug(nonExistentBugId);

            // Assert
            Assert.False(result);
        }
    }
}
