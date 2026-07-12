## COVERAGE TASK

### File
4_Operation/Ecs/src/Kernel/Events/ComponentEvent.cs

### Coverage
28.6%

### Previously Uncovered Lines
`GenericEvent is { } e && e.HasListeners` branch in `HasListeners` property

### Method
`HasListeners` (property)

### Existing Tests
- `ComponentEventExtendedTest` (all skipped)
- `EventCoverageTest` (all skipped)

### Source Code
```csharp
public bool HasListeners => NormalEvent.HasListeners || (GenericEvent is { } e && e.HasListeners);
```

### Tests Added
- `HasListeners_DefaultIsFalse` — verifies no listeners on new instance
- `HasListeners_TrueWhenNormalEventHasListeners` — covers left branch of `||`
- `HasListeners_TrueWhenGenericEventHasListeners` — covers right branch `GenericEvent is { } e && e.HasListeners`
- `HasListeners_FalseWhenGenericEventIsNull` — covers null GenericEvent path

### Commit
`8ac785a7c`

### Status
Completed
