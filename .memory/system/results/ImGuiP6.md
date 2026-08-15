# Result: ImGuiP6.cs

File: `1_Presentation/Extension/Graphic/Ui/src/ImGuiP6.cs`
CoverageBefore: 97.14% (713/734 lines, local coverlet; SonarCloud stale 0.0%)
CoverageAfter: 97.14%
TestsAdded: 0
Commit: none
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

Every remaining uncovered line routes through broken production wrappers or has filesystem side
effects. No tests can be added without modifying `src/`.

## Per-method root causes

1. `InputInt3` (160-161, 174-175): `ImGuiNative.cs` declares the entry point as
   `EntryPoint = "_igInputInt3"` (leading underscore) while every sibling
   (`igInputInt`/`igInputInt2`/`igInputInt4`) uses the correct form without the underscore. On
   macOS the CoreCLR PAL strips a leading `_` before `dlsym`, so the call throws
   `EntryPointNotFoundException: Unable to find an entry point named '_igInputInt3'`. Verified
   empirically; `nm` confirms `_igInputInt3` is exported, so only the entry-point string is wrong.
2. `ListBox` (880-881, 902-903): passes a `byte[][]` (nested array) to `igListBox_Str_arr`, which
   the default interop marshaller rejects with
   `MarshalDirectiveException: no marshaling support for nested arrays` (same defect as
   ImPlot.cs `SetupAxisTicks` and ImGuiP5.cs `Combo`).
3. `LoadIniSettingsFromDisk` (910-912): reads a file from disk (filesystem side effect, not
   allowed in tests; also mutates context settings).
4. `LogToFile` (980-983, 990-992, 1000-1002): `igLogToFile` opens and writes `imgui_log.txt`
   (filesystem side effect, not allowed in tests).

## Verification

- `EntryPointNotFoundException` reproduced by a framed-context execution test (`igInputInt3`); the
  identical `InputInt4` pattern passes, isolating the defect to the `_`-prefixed entry point.
- The nested-array marshalling defect was previously confirmed empirically in ImPlot.cs.
- Full ImGui suite still 3802 passed / 2 skipped — no regressions.
