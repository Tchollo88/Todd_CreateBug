namespace BugTracker.Core
{
    public class Bug
    {
        public int BugId {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public BugStatus Status { get; set; }
        public string AssignedToDeveloper { get; set; }

        public Bug(int bugId, string title, string description)
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

        public void UpdateStatus(BugStatus newStatus)
        {
            if (newStatus == Status)
                throw new ArgumentException("Status is already set to the same value.");
            else
            {
                switch (newStatus)
                {
                    case BugStatus.Closed:
                        if (Status == BugStatus.InProgress || Status == BugStatus.Pending)
                        {
                            Status = newStatus;
                        }
                        break;
                    case BugStatus.InProgress:
                        if (Status == BugStatus.Open || Status == BugStatus.Pending)
                        {
                            Status = newStatus;
                        }
                        break;
                    case BugStatus.Pending:
                        if (Status == BugStatus.InProgress)
                        {
                            Status = newStatus;
                        }
                        break;
                }
            }
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
        Pending,
        Closed
    }
}
