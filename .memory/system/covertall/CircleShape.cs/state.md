# State — CircleShape.cs (Sfml Render)

Target: 1_Presentation/Extension/Graphic/Sfml/src/Render/CircleShape.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: covertall-circleshape
Baseline commit: 21d89404b36c2cfd92320c293daf9e42788a1a9e

Initial line coverage: 100.0% (32/32 sequence points, measured via filtered coverage run)
Initial branch coverage: 100.0% (0 branch points — the file contains no branches)
Current line coverage: 100.0%
Current branch coverage: 100.0%
Tests before: 39 (CircleShapeTest)
Tests after: 39 (2 weak tests strengthened with meaningful assertions)
Files modified: 1_Presentation/Extension/Graphic/Sfml/test/Render/CircleShapeTest.cs
Tests added: 0 new (GetPoint_LastValidIndex_ShouldReturnPoint and GetPoint_Triangle_AllIndices_ShouldReturnValidPoints now assert real behavior)
Commits: see git log
Remaining uncovered lines: none
Remaining uncovered branches: none

Environment blocker (documented):
Full-suite runs of Alis.Extension.Graphic.Sfml.Test crash the test host in
pre-existing, unrelated native tests (DrawableDrawCoverageTests,
WindowNativeExecutionTests, VertexBufferDrawExecutionTests,
VertexArrayDrawExecutionTests, SpriteCoverageTests — crash point moves between
runs, verified with --blame). The crash prevents coverage flush for full-suite
runs (all modules report 0 visited). Coverage for the target file was measured
with the CircleShapeTest filter, which exercises 100% of CircleShape.cs
(CircleShape is referenced only by CircleShapeTest and
DrawableDrawCoverageTests in the test project).

Status: COMPLETED
Last update: 2026-09-13
