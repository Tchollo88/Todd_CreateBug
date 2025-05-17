namespace BugTracker.Core
{
    public class Bug
    {
        public int BugId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public string AssignedToDeveloper { get; set; }

        public Bug(int bugId, string title, string description, int priority, int severity)
        {
            // TODO: Add guard clause for title
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title cannot be null, empty, or whitespace.");

            BugId = bugId;
            Title = title;
            Description = description;
            Status = BugStatus.Open;
            AssignedToDeveloper = null;
        }

        public Bug(int v1, string v2, string v3)
        {
        }

        public void UpdateStatus(BugStatus newStatus)
        {
            if (newStatus == Status)
                throw new ArgumentException("Status is already set to the same value.");
            else
                Status = newStatus;
        }

        public void UpdateAssignedToDeveloper(string developer)
        {
            AssignedToDeveloper = developer;
        }
    }
    public enum BugStatus
    {
        Open,
        InProgress,
        Resolved,
        Closed
    }
}
