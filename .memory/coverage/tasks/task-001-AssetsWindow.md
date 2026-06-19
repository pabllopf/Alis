# Task 001: AssetsWindow.cs Coverage

## File
`1_Presentation/Engine/src/Windows/AssetsWindow.cs`

## Coverage
0.0% (382 uncovered lines)

## Uncovered Lines
1-382 (full file)

## Priority
1 (highest - 382 uncovered lines, 0% coverage)

## Methods to Cover
- Constructor: `AssetsWindow(SpaceWork)` - Marshal.AllocHGlobal
- Properties: `IsDefaultSize`, `SpaceWork`, `WindowName` (static field)
- Methods: `Initialize()`, `Start()` (empty no-ops)

## Existing Tests
None found.

## Source Reference
Fetched from SonarCloud via `api/sources/raw`

## Test Strategy
- Reflection-based interface verification (following AudioPlayerWindowTest pattern)
- Constructor SpaceWork assignment test
- Property access tests via reflection
- Static field WindowName verification
- Memory allocation safety (Marshal.AllocHGlobal must be freed)

## Test Project
`./1_Presentation/Engine/test/Alis.App.Engine.Test.csproj` (net8.0)
