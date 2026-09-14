File: 1_Presentation/Extension/Graphic/Sdl2/src/Sdl.cs
CoverageBefore: 8.4%
CoverageAfter: 100% (local coverlet line-rate 1.0, 835/835 sequence points hit)
TestsAdded: 7 (SdlRemainingCoverageTests.cs) + 24 (SdlManagedCoverageTests.cs)
Status: COMPLETED
Notes: Added SdlRemainingCoverageTests.cs covering the last 16 uncovered wrapper lines (CreateWindow, CreateWindowAndRenderer, CreateContext, GetGrabbedWindow, CreateCursor, touch device queries, MapRgb). A type initializer selects the headless dummy video driver via native setenv so the Cocoa main-thread-restricted wrappers run from the xUnit worker thread. Whole scope 1_Presentation/Extension/Graphic/Sdl2/src now at 100% (1137/1137 sequence points).