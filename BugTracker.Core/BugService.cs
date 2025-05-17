

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
        // ToDo: View list of bugs should manipulate the list of bugs and display them in a user friendly way

        // ToDo: Add to developer service should assign to developer and then check if status is open or not, if open set to in progress

        // ToDo: Delete bug from list
    }
}
