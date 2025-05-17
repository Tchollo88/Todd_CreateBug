using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BugTracker.Core
{
    public class BugService
    {
        private readonly List<Bug> _bugs = new List<Bug>();

        public List<Bug> getBugs
        {
            get { return _bugs; }
        }

        // Todd method to create a bug
        public Bug CreateBug(string title, string description, int priority, int severity)
        {
            var bug = new Bug(_bugs.Count + 1, title, description, priority, severity);
            _bugs.Add(bug);
            return bug;
        }

        
        public bool DeleteBug(int bugId)
        {
            var bug = _bugs.FirstOrDefault(b => b.BugId == bugId);
            if (bug != null)
            {
                _bugs.Remove(bug);
                return true;
            }
            return false;
        }
    }
}
