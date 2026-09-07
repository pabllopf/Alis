# Result: ImGuiStyle.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiStyle.cs`
CoverageBefore: 99.1% line / 98.3% branch (local coverlet, net8.0)
CoverageAfter: 99.1% line / 98.3% branch (no change — unreachable dead code)
TestsAdded: 0
Commit: none
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiStyle.cs is a plain data struct (670 LOC) with 55 `Vector4F` color properties,
scalar/vector style properties, an indexer (get/set) over the color array, and a
`ScaleAllSizes` method that delegates to native ImGui interop.

The existing test suite (ImGuiStyleTest.cs, ImGuiStyleTests.cs, ImGuiStyleRemainingCoverageTests.cs)
covers 444 of 446 instrumented lines (99.1%). All property getters/setters, all 55
indexer branches (get and set), boundary throw paths, and edge-case values are exercised.

## Unreachable lines

Two lines remain uncovered (dead code):

- **Line 589** — `_ => throw new CustomIndexOutOfRangeException(...)` in the indexer getter
  switch expression.
- **Line 656** — `default: throw new CustomIndexOutOfRangeException(...)` in the indexer
  setter switch statement.

Both are unreachable because the guard clause (`if (index < 0 || index >= 55) throw`)
on lines 527/594 catches all invalid indices before the switch executes, and the switch
covers every valid case (0–54). No test can reach these branches without modifying
production code.

## Verification

- Targeted run: 354 passed / 0 failed (net8.0, ImGuiStyle filter).
