# State — Font.cs

Target: 1_Presentation/Extension/Graphic/Sfml/src/Render/Font.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: cover-agent-001
Baseline commit: 2e91a3e6cfb3a7ba79b612b87b591954d0c1a5b4
Initial line coverage: 100.00% (59/59)
Initial branch coverage: 100.00% (10/10)
Current line coverage: 100.00%
Current branch coverage: 100.00%
Tests before: 1662
Tests after: 1662
Files modified: none
Tests added: 0
Commits: none
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-08-17

## Notes

Existing tests in test/Render/FontTest.cs cover all constructors (filename,
stream, bytes, copy, private IntPtr via reflection-free public paths), both
loading-failure branches (lines 66, 84), all glyph/kerning/line-spacing/
underline/texture/info accessors, ToString, and every Destroy branch
(204, 211, 216 — disposing true/false combinations). The OpenCover report shows
59/59 sequence points and 10/10 branch points covered. No additional tests
required.