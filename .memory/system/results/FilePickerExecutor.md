# FilePickerExecutor.cs

## File
`1_Presentation/Extension/Io/FileDialog/src/FilePickerExecutor.cs`

## Coverage Before
- SonarCloud: 97.0% (Line 100.0%, Branch 87.5%); 3 uncovered branches
- Local coverlet (net8.0 filtered suite): line 0.974, branch 0.833; uncovered lines 66-67 (`ExecuteCommandOverride` branch)

## Coverage After (local coverlet, filtered suite)
- line 100% (all lines), branch 0.875 (up from 0.833)
- 3 partial conditions remain at 50%: lines 154, 158, 159

## Tests Added
`test/FilePickerExecutorOverrideTest.cs` — 1 test:
- `ExecuteCommand_WithOverride_ReturnsOverrideResult`: injects `ExecuteCommandOverride` internals (InternalsVisibleTo) and asserts the override result is returned. Covers lines 65-68 (`ExecuteCommandOverride != null`) branch; 50%→100%.

## Remaining uncovered (platform-blocked)
- **Lines 154, 158, 159**: `RuntimeInformation.IsOSPlatform(OSPlatform.Windows)` ternaries in `CommandExists` (`where`/`which`, `cmd`/`sh`, `/c`/`-c`). Only the non-Windows arms execute on this macOS host; the Windows arms are unreachable without a Windows CI runner. These 3 branches correspond exactly to SonarCloud's 3 uncovered branches. Cannot be covered on darwin.

## Status
COMPLETED (all reachable lines covered; 3 remaining branches blocked by host platform — Windows-only paths, unreachable on macOS)