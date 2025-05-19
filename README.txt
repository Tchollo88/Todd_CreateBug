Bug status tracker

# Sprint 2 – Bug Tracker Implementation

## Team Members:
- (Ian Engle, Chris Cane, Jean Paul Sidibe, Todd Holloman)

## Sprint Goal:
(Summarize your Sprint Goal from your Sprint Plan)

## Features Implemented:
[Create Bug]
User Story
As a User, I want to be able to create a bug so that the developer knows it needs to be fixed and what status, priority, and severity it is.

Acceptance Criteria
1 Have an input initialize a bug object. <-- User presses (C) to open the initialization.
2 Ensure the bug has a title, description, severity, assignto, and status field. <-- The initialize process is a queue of questions asking for all required data.
3 Check that status is only resulting enum/list statuses. [Open, Pending, InProgress, Closed] <-- Checks and fills the Status field with Open, the defaulting Status.
4 Ensure that the object Status data is defaulted to “Open.”

(5) Points – The feature requires input to instantiate the creation of a bug, opens fields to input valid data for each property, and an enum/list to store all required status types, ensuring that status is tied to the enum/list. 

I managed to build a process that initializes the creation of a bug by  requiring the user to press the letter c while interacting with the project's main menu. Once pressed,d I run a method that asks a queue of questions to fulfill all the required data {Title, Description, Priority, Severity}. Once the questions are answered, it takes the data, passes into creating the bug with said data, and adds it to the saved list.

### ✅ B2: View Bug List
- Explain your solution and testing approach

### ✅ B4: Priority Tagging
- Describe how priority was stored and used

## Tests Completed:
- List which tests exist and what they validate

## Known Issues:
- Note any bugs, confusion, or to-dos

## What We Learned:
- Share insights from building and testing
- What is one thing your team would do differently in the next sprint?

============================================================

Bugs have ID's, Titles, Descriptions, and Status'.
Newly created bugs will always default to being Open.

Status' can be any of the following Open, InProgress, Resolved, Closed.
Status' can be changed from any status to any other status but not to the same status that it already is.

============================================================
