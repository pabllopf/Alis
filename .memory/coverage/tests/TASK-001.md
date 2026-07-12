# Tests for ComponentEvent.cs

## File
`4_Operation/Ecs/test/Kernel/Events/ComponentEventBasicTest.cs`

## Tests
| Test | Description | Status |
|------|-------------|--------|
| `HasListeners_DefaultIsFalse` | New ComponentEvent has no listeners | Passing |
| `HasListeners_TrueWhenNormalEventHasListeners` | NormalEvent has listener → HasListeners true | Passing |
| `HasListeners_TrueWhenGenericEventHasListeners` | GenericEvent with listener → HasListeners true | Passing |
| `HasListeners_FalseWhenGenericEventIsNull` | Explicit null GenericEvent → HasListeners false | Passing |

## Pattern
Direct struct construction + internal field manipulation via InternalsVisibleTo.
