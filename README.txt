# Developer README – Bug Priority Feature

## Feature Overview

This update introduces a **priority system** for bug tracking using the `BugPriority` enum. Each `Bug` instance now has an associated priority level set during object creation, helping to triage and organize issues more effectively.

### Priority Levels

The priority system supports the following levels:

- `Low` (0)
- `Medium` (1)
- `High` (2)

These values are mapped from integer inputs passed into the `Bug` constructor, ensuring consistency and type safety.

### Key Design Elements

- `Priority` is a **read-only** property (externally immutable)
- Conversion and validation are handled by a dedicated `SetPriority(int)` method
- Invalid values throw an `ArgumentException` to prevent misuse

---

## Setup Instructions

To integrate or maintain this feature in the project, follow these steps:

### 1. Add the `BugPriority` Enum

Ensure the following enum exists in your models:

```csharp
public enum BugPriority
{
    Low,
    Medium,
    High
}
