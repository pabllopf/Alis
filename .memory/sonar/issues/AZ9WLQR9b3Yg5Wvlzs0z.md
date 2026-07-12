# Issue: AZ9WLQR9b3Yg5Wvlzs0z

- Rule: csharpsquid:S2292
- File: 2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs
- Line: 59
- Severity: MINOR
- Message: Make this an auto-implemented property and remove its backing field.

## Code Snippet

```csharp
internal IPlayer PlayerForTest { get => player; set => player = value; }
```

## Context

Struct with auto-properties (PlayOnAwake, IsMute, IsLooping, etc.). The `player` field is used across multiple methods in the class.

