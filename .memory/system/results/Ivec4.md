# Ivec4.cs

## File
1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec4.cs

## Coverage (SonarCloud, master)
- Line: 0.0%, Uncovered Lines: 12, Complexity: 2

## Local verification
- New test file: 1_Presentation/Extension/Graphic/Sfml/test/Render/Ivec4CoverageTests.cs
- 4 tests added (int constructor, Color constructor mapping R/G/B/A to X/Y/Z/W, property getters).
- Build: pass. Tests: 4 passed, 0 failed (dotnet test filter Ivec4CoverageTests).

## Analysis
Struct with two public constructors and four int properties. Both constructors and all property getters covered via observable behavior; no reflection, no Moq needed.

## Outcome
4 tests added; production code untouched.
