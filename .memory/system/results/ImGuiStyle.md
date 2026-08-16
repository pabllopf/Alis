# Result: ImGuiStyle.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiStyle.cs`
CoverageBefore: 86.9% (SonarCloud, stale); local coverlet 99.1% line (663/669)
CoverageAfter: 99.1% line (663/669, local coverlet, net8.0 — unchanged)
TestsAdded: 0 (both remaining lines verified to be dead code)
Commit: test: coverage ImGuiStyle.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

ImGuiStyle.cs (669 LOC, ImGui style wrapper with 55 named color properties + indexer). The
committed suite (4 test files) already covers 99.1% locally — SonarCloud's 86.9% is stale. The
only uncovered lines are 589 and 656, the `_ => throw new CustomIndexOutOfRangeException(...)`
defaults of the indexer's switch getter/setter.

## Analysis

Both switch defaults are DEAD CODE: the indexer's getter and setter both start with an explicit
bounds guard (`if (index < 0 || index >= 55) throw ...` at lines 527-529 / 594-596) that
precedes the switch, so the switch default is unreachable for any input. Verified empirically:
the committed tests `Indexer_Get_IndexOutOfRange_ShouldThrow` / `Indexer_Set_IndexOutOfRange_ShouldThrow`
pass (the guard throws) while coverlet confirms 589/656 remain at 0 hits.

## Verification

- Targeted run: all ImGuiStyle tests pass (net8.0).
- Local coverlet: 663/669 = 99.1% line; only the two dead switch-default lines remain.
