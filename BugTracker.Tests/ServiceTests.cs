namespace BugTracker.Tests
{
    using BugTracker.Core;

    public class ServiceTests
    {
        #region **CreateBug Tests**
        [Fact]
        public void CreateBug_AddsBugToList_WithCorrectDetails()
        {
            // Arrange  
            var bugManager = new BugService();

            // Act  
            var bug = bugManager.CreateBug("Test Title", "Test Description", 2, 1);

            // Assert  
            Assert.NotNull(bug);
            Assert.Equal(4, bug.BugId); // Should the 4th bug because 3 bugs are created as seeds by default
            Assert.Equal("Test Title", bug.Title);
            Assert.Equal("Test Description", bug.Description);
            Assert.Equal(BugPriority.High, bug.Priority);
            Assert.Equal(BugSeverity.Minor, bug.Severity);

            // Verify it was added to the internal list  
            var allBugs = bugManager.getBugs;
            Assert.Same(bug, allBugs[3]);
        }

        [Fact]
        public void CreateBug_AssignsIncrementingBugId()
        {
            // Arrange  
            var bugManager = new BugService();

            // Act  
            var bug1 = bugManager.CreateBug("Bug 1", "Desc 1", (int)BugPriority.Low, 1);
            var bug2 = bugManager.CreateBug("Bug 2", "Desc 2", (int)BugPriority.High, 2);

            // Assert  
            Assert.Equal(4, bug1.BugId);
            Assert.Equal(5, bug2.BugId);
        }
        #endregion

        #region **DeleteBug Tests**
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
        #endregion
    }
}
