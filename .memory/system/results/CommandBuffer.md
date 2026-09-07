# CommandBuffer.cs

## File
`4_Operation/Ecs/src/Kernel/CommandBuffer.cs`

## Coverage Before
- SonarCloud: 96.8% overall (Line 96.7%, Branch 97.4%)
- Local coverlet (net8.0, filtered 74-test suite): line 0.9673, branch 0.9736; uncovered lines 343-347 (AddComp event block), 363 (structural dead); line 342 50%

## Coverage After (local coverlet, 74-test suite)
- line 0.9945, branch 100% (all conditions 100%)
- Only line 363 remains uncovered — `}` closing the `if` block after a `Throw()` local function that always throws; structurally unreachable dead code.

## Tests Added
`test/Kernel/CommandBufferAddCompEventTest.cs` — 1 test:
- `AddComponent_ViaBuffer_WithSubscribedAddEvent_FiresHandler`: subscribes `OnComponentAdded`, adds component via `CommandBuffer.AddComponent<T>`, asserts handler fires during `Playback()`. Covers the `record.HasEvent(AddComp)` true-branch (line 342 went 50%→100%) and the event invocation block (lines 343-347).

## Remaining uncovered (unreachable structural dead code)
- **Line 363** (`}` closing `if (LastCreateEntityComponentsBufferIndex < 0)` after the unconditional-throw local function `Throw()`): control never reaches the closing brace because `Throw()` always throws. The throw itself (line 368) is covered by existing test `With_WithoutEntity_ThrowsInvalidOperation`.

## Status
COMPLETED (all reachable lines and branches covered)