# State — Transform.cs

Target: 1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs
Project: Alis.Extension.Graphic.Sfml
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: covertall-sfmltime-2 (SonarCloud-focused round)
Baseline commit: f76bd863b9e1a9e1e23df6ed60c74d832ea7f723 (work done after a919e151e/a3eb19394)
SonarCloud reported: 0.0% / 76 uncovered lines (stale analysis of 2026-08-24)
Initial local coverage: 0/76 lines, 0/2 branches
Current line coverage: 100% (76/76 sequence points, report d6bfbe53-...)
Current branch coverage: 100% (2/2 branch points at line 259 boxed-equality, both paths)
Files modified:
- test/Render/TransformCoverageTests.cs (new, 21 tests)
- test/SfmlTestBootstrap.cs (removed stray committed `}` at l.214 that broke the whole test project build — defect fix, rule 27)
Tests added:
- 21 [RequireCSfmlGraphicsFact] tests covering: 9-arg ctor, TransformPoint(x,y), TransformPoint(Vector2F), TransformRect, Combine,
  Translate(x,y)/Translate(Vector2F), Rotate(angle), Rotate(angle,cx,cy), Rotate(angle,Vector2F), Scale x4 overloads,
  GetInverse (translate cancel), scaleX/scaleY centered raw+vector overloads, operator * (transform x transform),
  operator * (transform x point), FloatRect bounds, Identity property, ToString contents, Equals(Transform),
  Equals(object) boxed ok/rejection/null path, GetHashCode (equal-distinct + stability).
Test result: PASS (21/21)
Empirical note: csfml-graphics transform natives are correct under CSFML 3.0 (center rotation verified by probe).
Commits: (see git log)
Remaining uncovered lines: none
Remaining uncovered branches: none
Status: COMPLETED
Last update: 2026-09-12

Commits: 5908a1ce8 (integrated with concurrent agent sweep: fix: covert unit tetss)
