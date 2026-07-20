## Fix: AZ9WLQoab3Yg5Wvlzs06

- File: 4_Operation/Physic/src/Collisions/DynamicTreeBroadPhase.cs
- Rule: csharpsquid:S2583
- Severity: MAJOR
- Date: 2026-07-13

### Change

Added `_pairCount > 0 &&` guard in the for loop condition to make unreachable path explicit.

### Before

```csharp
for (int i = 0; i < _pairCount; i++)
```

### After

```csharp
for (int i = 0; _pairCount > 0 && i < _pairCount; i++)
```
