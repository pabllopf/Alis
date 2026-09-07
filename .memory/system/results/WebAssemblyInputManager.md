# WebAssemblyInputManager.cs

## Summary
- Status: COMPLETED
- CoverageBefore: 96.3% / Line 97.4% Branch 95.1% (SonarCloud)
- CoverageAfter: 100.0% line and branch (local coverlet)
- TestsAdded: WebAssemblyInputManagerGamepadEdgeCoverageTests.cs (7 tests)

## Approach
The 5 uncovered lines (242-247, 265) lived in `IsGamepadButtonJustPressed` and `IsGamepadButtonJustReleased`. Existing tests only exercised the no-gamepad early-return path.

The remaining branches required:
- `state.PreviousState == null` with button pressed/released (line 244)
- `CurrentState.GetButton && !PreviousState.GetButton` for both truth values (line 247)
- `!CurrentState.GetButton && PreviousState.GetButton` for both truth values (line 265)

Because `TryGetGamepadState` returns the live `_gamepadStates[index]` object and `_previousGamepadStates` entries the test must seed these internal dictionaries directly (InternalsVisibleTo is configured for the Test assembly) to control previous vs current button states.

## Verification
- 7 new tests pass.
- Full Graphic suite: 1542 passed, 613 skipped (WebOnly), 0 failed.
- coverage.cobertura.xml shows WebAssemblyInputManager at line-rate=1, branch-rate=1.