

namespace BugTracker.Core
{
    public class BugService
    {
        private readonly List<Bug> _bugs = new List<Bug>(); //Saved bugs in a list

        public List<Bug> getBugs
        {
            get { return _bugs; }
        }


        // Method to add a bug to the list of bugs *
        public Bug CreateBug(string title, string description, int priority, int severity)
        {
            var bug = new Bug(_bugs.Count + 1, title, description, priority, severity);
            _bugs.Add(bug);
            return bug;
        }

        public List<Bug> SortBugsByTitle()
        {
            List<Bug> UnsortedBugs = _bugs;
            UnsortedBugs.Sort((x, y) => string.Compare(x.Title.ToLower(), y.Title.ToLower(), StringComparison.Ordinal));
            List<Bug> SortedByTitle = UnsortedBugs;
            return SortedByTitle;
        }

        public List<Bug> SortBugsByStatus()
        {
            List<Bug> UnsortedBugs = _bugs;
            UnsortedBugs.Sort((x, y) => x.Status.CompareTo(y.Status));
            List<Bug> SortedById = UnsortedBugs;
            return SortedById;
        }

        // ToDo: Add to developer service should assign to developer and then check if status is open or not, if open set to in progress

        // ToDo: Delete bug from list
    }
}
