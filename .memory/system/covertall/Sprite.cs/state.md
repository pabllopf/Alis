# State — Sprite.cs (SFML)

Target: 1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs
Project: 1_Presentation/Extension/Graphic/Sfml/src/Alis.Extension.Graphic.Sfml.csproj
Test project: 1_Presentation/Extension/Graphic/Sfml/test/Alis.Extension.Graphic.Sfml.Test.csproj
Agent: agent-sprite-sfml-001
Baseline commit: f76bd863b9e1a9e1e23df6ed60c74d832ea7f723
Initial line coverage: 0.0%
Initial branch coverage: 0.0%
Current line coverage: 0.0% (tests written, run blocked)
Current branch coverage: 0.0% (tests written, run blocked)
Tests before: 0 (behavioral, real SFML)
Tests after: 19 (new SpriteCoverageTests.cs)
Files modified: test/Render/SpriteCoverageTests.cs (new)
Tests added: 19
Commits: (pending)
Remaining uncovered lines: all (43 sequence points)
Remaining uncovered branches: 6
Status: IN_PROGRESS
Last update: intraday (2026-09-12)

## Concurrency note
While this agent worked on Sprite.cs, other agents concurrently modified the SAME
test project (SoundSoundBufferManagedSurfaceCoverageTests, ShaderDeterministicCoverageTests,
VertexBufferDrawExecutionTests, TransformCoverageTests, WindowNativeExecutionTests —
locks seen: NativeWindow.cs.lock, Vec4.cs.lock, SoundBufferTest edits).
Filtered Sprite runs repeat a hard test-host crash at ~7s; the whole-project run
passess 1870/1870 before those files churn and I could not get a full green+coverage
run after adding SpriteCoverageTests while the other agent's files were mid-flight.
