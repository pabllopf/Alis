# AudioPlayerWindow Coverage Task

## File
1_Presentation/Engine/src/Windows/AudioPlayerWindow.cs

## Coverage
0.0% (35 uncovered lines)

## Status
TESTS WRITTEN BUT UNTESTABLE DUE TO INFRASTRUCTURE

## Reason
The Engine test project has custom output directories (bin/$(Configuration)/$(RuntimeIdentifier)/lib/) 
combined with no network access to NuGet, causing the test host to fail loading Castle.Core.dll 
and other package dependencies. This is a project-wide infrastructure issue, not specific to these tests.

## Tests Written
File: 1_Presentation/Engine/test/AudioPlayerWindowTest.cs

Tests include:
- AudioPlayerWindow_ShouldImplementIWindow (reflection-based, IWindow is internal)
- Constructor_ShouldAssignSpaceWorkProperty (creates SpaceWork, passes to constructor)
- SpaceWork_Property_ShouldBeReadOnly (verifies property has no setter)
- Initialize_ShouldNotThrow (no-op method test)
- Start_ShouldNotThrow (no-op method test)
- WindowName_ShouldBeNonEmpty (verifies static property)
- PrivateConstants_ShouldHaveExpectedDefaultValues (reflection on private fields)
- Render_Method_ShouldExistWithExpectedSignature (verifies method exists)

## Workaround Required
Tests would pass in an environment with:
- Network access to NuGet
- Standard output directories
- Or a fix to the project's OutDir configuration

## Priority
HIGH (0% coverage, 35 lines, high ROI when infrastructure is fixed)

## Next Steps
- Fix project test infrastructure OR
- Create a standalone minimal test project without Moq dependency
- Or accept partial coverage for ImGui-dependent windows
