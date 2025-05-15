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
        public void UpdateStatusTestPending()
        {
            Bug bug = new Bug(3, "Pending", "Tests Pending status");
            bug.UpdateStatus((BugStatus)2);
            Assert.Equal(BugStatus.Pending, bug.Status);
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
            bug.UpdateStatus(BugStatus.InProgress);

            // Assert
            Assert.Equal((BugStatus)1, bug.Status);
        }

        [Fact]
        public void UpdateStatus_ChangesStatus_FromOldStatus()
        {
            // Arrange
            var bug = new Bug(8, "Icon missing", "Settings icon not visible");
            var initialStatus = bug.Status;
            // Act
            bug.UpdateStatus(BugStatus.InProgress);

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
            switch (status)
            {
                case 0:
                    // Arrange
                    var bug0 = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                    // Act
                    var ex0 = Assert.Throws<ArgumentException>(() => bug0.UpdateStatus((BugStatus)status));
                    // Assert
                    Assert.Equal("Status is already set to the same value.", ex0.Message);
                    break;
                case 1:
                    // Arrange
                    var bug1 = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                    // Assignes the bug status to the same value as the one being tested
                    bug1.UpdateStatus((BugStatus)status);
                    // Act
                    var ex1 = Assert.Throws<ArgumentException>(() => bug1.UpdateStatus((BugStatus)status));
                    // Assert
                    Assert.Equal("Status is already set to the same value.", ex1.Message);
                    break;
                case 2:
                    // Arrange
                    var bug2 = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                    // Assignes the bug status to the same value as the one being tested
                    bug2.UpdateStatus((BugStatus)1);
                    bug2.UpdateStatus((BugStatus)status);
                    // Act
                    var ex2 = Assert.Throws<ArgumentException>(() => bug2.UpdateStatus((BugStatus)status));
                    // Assert
                    Assert.Equal("Status is already set to the same value.", ex2.Message);
                    break;
                case 3:
                    // Arrange
                    var bug3 = new Bug(7, "StatusTest", "Status must change to a new status when updated");
                    // Assignes the bug status to the same value as the one being tested
                    bug3.UpdateStatus((BugStatus)1);
                    bug3.UpdateStatus((BugStatus)2);
                    bug3.UpdateStatus((BugStatus)status);
                    // Act
                    var ex3 = Assert.Throws<ArgumentException>(() => bug3.UpdateStatus((BugStatus)status));
                    // Assert
                    Assert.Equal("Status is already set to the same value.", ex3.Message);
                    break;
            }
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
        [Fact]
        public void StatusChange_OpenToInProgress_ShouldChange()
        {
            // Arrange
            var bug = new Bug(10, "OpenToInProgress", "Should succeed");

            // Act
            bug.UpdateStatus(BugStatus.InProgress);

            // Assert
            Assert.Equal(BugStatus.InProgress, bug.Status);
        }

        [Theory]
        [InlineData(BugStatus.Pending)]
        [InlineData(BugStatus.Closed)]
        public void StatusChange_InProgressToPendingOrClosed_ShouldChange(BugStatus bugStatus)
        {
            // Arrange
            var bug = new Bug(11, "InProgressToPendingOrClosed", "Should succeed");

            // Act
            bug.UpdateStatus(BugStatus.InProgress);
            bug.UpdateStatus(bugStatus);

            // Assert
            Assert.Equal(bugStatus, bug.Status);
        }

        [Theory]
        [InlineData(BugStatus.InProgress)]
        [InlineData(BugStatus.Closed)]
        public void StatusChange_PendingToInProgressOrClosed_ShouldChange(BugStatus bugStatus)
        {
            // Arrange
            var bug = new Bug(12, "PendingToInProgressOrClosed", "Should succeed");

            // Act
            bug.UpdateStatus(BugStatus.InProgress);
            bug.UpdateStatus(BugStatus.Pending);
            bug.UpdateStatus(bugStatus);

            // Assert
            Assert.Equal(bugStatus, bug.Status);
        }

        [Theory]
        [InlineData(BugStatus.Open)]
        [InlineData(BugStatus.Pending)]
        public void StatusChange_ClosedToOpenOrPending_ShouldNotChange(BugStatus bugStatus)
        {
            // Arrange
            var bug = new Bug(13, "ClosedToOpenOrPending", "Should not succeed");

            // Act
            bug.UpdateStatus(BugStatus.InProgress);
            bug.UpdateStatus(BugStatus.Pending);
            bug.UpdateStatus(BugStatus.Closed);
            bug.UpdateStatus(bugStatus);

            // Assert
            Assert.Equal(BugStatus.Closed, bug.Status);
        }
    }
}
