# State — ConvexShape.cs

Target: 1_Presentation/Extension/Graphic/Sfml/src/Render/ConvexShape.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 100.00% (26/26)
Initial branch coverage: 100.00% (2/2)
Current line coverage: 100.00%
Current branch coverage: 100.00%
Tests before: 1661
Tests after: 1661
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-08-17

## Notes

Existing tests in test/Render/ConvexShapeTests.cs already cover all constructors
(default, point-count, copy — including the copy loop with non-empty source),
GetPointCount, SetPointCount, GetPoint and SetPoint (both lines including the
Update() calls). The OpenCover report shows 26/26 sequence points and 2/2 branch
points covered. No additional tests required.