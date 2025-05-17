using BugTracker.Core;

var menu = new BugMenuUI(Console.Out);

bool keepRunning = true;
while (keepRunning)
{
    // Pass in Console.ReadKey so it reads from the keyboard
    menu.DisplayMenu(() => Console.ReadKey(true).KeyChar);
}
