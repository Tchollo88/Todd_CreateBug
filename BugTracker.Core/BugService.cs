

namespace BugTracker.Core
{
    public class BugService
    {
        private readonly List<Bug> _bugs = new List<Bug>(); //Saved bugs in a list

        // Method to add a bug to the list of bugs *
        public Bug CreateBug(string title, string description, int priority, int severity)
        {
            var bug = new Bug(_bugs.Count + 1, title, description, priority, severity);
            _bugs.Add(bug);
            return bug;
        }
    }
}
