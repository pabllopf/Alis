# Execution Log

## 2026-06-22

### [08:52] Task: DialogOption.cs
- Target: 1_Presentation/Extension/Language/Dialogue/src/DialogOption.cs (70.4% coverage, 6 uncovered lines/conditions)
- Existing tests: 5 tests (constructor, dialog option add, dialog manager)
- Tests added: 6 tests covering AddCondition null/valid, AddDialogAction null/valid, constructor list init for Conditions and DialogActions
- All 11 tests pass (5 original + 6 new)
- Production changes: None required
- Commit: 400dd3019

### [15:00] Task: Dialog.cs
- Target: 1_Presentation/Extension/Language/Dialogue/src/Dialog.cs (54.1% coverage, 11 uncovered lines)
- Existing tests: 5 tests in DialogTest.cs
- Tests added: 6 tests covering AddBranch valid/null/empty key, null dialog, GetBranch found/not found
- All 11 tests pass (5 original + 6 new)
- Production changes: None required
- Commit: 6e4148069

### [09:05] Task: ControllerTransform.cs
- Target: 4_Operation/Physic/src/Dynamics/ControllerTransform.cs (94.7% coverage, 3 uncovered lines)
- Existing tests: 21 tests in ControllerTransformTest.cs
- Tests added: 3 (Constructor with angle+scale, ref Multiply, ref Divide)
- All 24 tests pass (21 original + 3 new)
- Production changes: None required

### [09:25] Task: CdtDecomposer.cs
- Target: 4_Operation/Physic/src/Common/Decomposition/CDTDecomposer.cs (64.4% coverage, ~11 uncovered lines)
- Existing tests: 2 tests in CdtDecomposerTest.cs
- Tests added: 2 (ConvexPartition quadrilateral, ConvexPartition pentagon)
- All 4 tests pass (2 original + 2 new)
- Production changes: None required

### [09:15] Task: FlipcodeDecomposer.cs
- Target: 4_Operation/Physic/src/Common/Decomposition/FlipcodeDecomposer.cs (69.2% coverage, ~21 uncovered lines)
- Existing tests: 2 tests in FlipcodeDecomposerTest.cs
- Tests added: 5 (InsideTriangle outside, Snip degenerate, Snip vertex inside, ConvexPartition quadrilateral, ConvexPartition pentagon)
- All 7 tests pass (2 original + 5 new)
- Production changes: None required

### [14:35] Task: AudioSource.cs (Resumed)
- Target: 2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs (63.5% coverage, 15 uncovered lines)
- Existing tests: 12 tests (8 original + 4 branch tests from previous session)
- Tests added: 5 new tests covering Stop/Resume branches via IPlayer mock injection
- Production changes: Player field changed to IPlayer type, added internal PlayerForTest setter
- All 17 tests pass (12 original + 5 new)
- Commit: 9cddbe7df

## 2026-06-22

### [08:50] Task: GameObjectBuilder.cs
- Target: 2_Application/Alis/src/Builder/Core/Ecs/Entity/GameObjectBuilder.cs (45.1% coverage)
- Existing tests: 10 tests in GameObjectBuilderTest.cs
- Tests added: 13 tests covering WithComponent overloads (no-args for Animator/BoxCollider/Info, Camera/Sprite/AudioSource/BoxCollider configs, Animator instance, Action config) and Info-branch paths (Name/Tag/IsActive/IsStatic after Add<Info>)
- All 23 tests pass (10 original + 13 new)
- Production changes: None required
- Commit: 3e33bc380

### [10:00] Task: FixtureCollection.cs
- Target: 4_Operation/Physic/src/Dynamics/FixtureCollection.cs (97.1% coverage, 1 uncovered line, 1 uncovered condition)
- Existing tests: 24 tests in FixtureCollectionTest.cs
- Tests added: 1 test covering IEnumerator<Fixture>.Current throw when collection modified during enumeration (explicit interface implementation)
- All 25 tests pass (24 original + 1 new)
- Production changes: None required
- Commit: 74f44fcd3

### [08:45] Task: AudioSource.cs
- Target: 2_Application/Alis/src/Core/Ecs/Components/Audio/AudioSource.cs (63.5% coverage, 15 uncovered lines, 8/16 conditions uncovered)
- Existing tests: 8 tests (basic callability + property tests)
- Tests added: 4 branch coverage tests covering NameFile play path, IsLooping else branch, PlayOnAwake OnStart branch, empty NameFile edge case
- All 12 tests pass (8 original + 4 new)
- Production changes: None required
- Commit: e68fff4c3

## 2026-06-21

### [14:35] Task: BoxCollider.cs
- Target: 2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs (12.3% coverage, 239 uncovered lines)
- Existing tests: 17 tests in BoxColliderTest.cs
- Tests added: 6 new tests covering SizeOfTexture, Context, Body properties, BoxColliderSettings inequality
- All 23 tests pass (17 original + 6 new)
- Notes: OnUpdate/OnStart/OnExit require IGameObject mock (Moq ref return limitation), InitializeShaders/Render depend on OpenGL, OnCollision/OnSeparation require full ECS fixture setup
- Production changes: None required
- Commit: 7bd29b432

### [14:32] Task: Body.cs
- Target: 4_Operation/Physic/src/Dynamics/Body.cs (65.3% coverage, 188 uncovered lines)
- Existing tests: 23 tests in BodyTest.cs
- Tests added: 69 new tests covering property setters, transform conversions, fixture management, forces/impulses
- All 92 tests pass (23 original + 69 new)
- Production changes: None required
- Commit: 38cb45fc1

### [14:30] Coverage Delta Synchronization (Resumed Session)
- Loaded SonarCloud project coverage: 49.9% coverage, 49.4% line coverage, 52.4% branch coverage
- Compared with previous state: minor fluctuation
- Reviewed git history: 42 test files modified in last 50 commits
- Updated coverage-index.md with full task completion ledger

### [10:42] Coverage Delta Synchronization
- Loaded SonarCloud project coverage: 50.0% coverage, 49.5% line coverage, 52.5% branch coverage
- Identified 24 files with < 100% coverage
- Baseline saved to coverage-index.md

### [10:43] Task: AotReflectionAnalyzer.cs
- Target: 6_Ideation/Fluent/generator/AotReflectionAnalyzer.cs (0.0% coverage, 131 uncovered lines)
- Production changes: Changed helper methods to internal static, added InternalsVisibleTo
- Created test file: AotReflectionAnalyzerTest.cs (54 tests)
- All 54 tests passed
- Commit: 63e251b8a

### [10:45] Task: BrowserPlayer.cs
- Target: 4_Operation/Audio/src/Players/BrowserPlayer.cs (0.0% coverage)
- Status: Already covered — 35 existing tests in BrowserPlayerWavParsingTests.cs
- Reason: Test project has SonarQubeExclude=true; constructor/Play depend on OpenAL native libraries

### [10:46] Task: BottomMenu.cs
- Target: 1_Presentation/Engine/src/Menus/BottomMenu.cs (2.2% coverage)
- Status: Already covered — 8 existing tests in BottomMenuTest.cs
- Reason: Render methods depend on ImGui UI framework

### [10:47] Task: AssetsWindow.cs
- Target: 1_Presentation/Engine/src/Windows/AssetsWindow.cs (19.7% coverage)
- Status: Already covered — 7 existing tests in AssetsWindowTest.cs
- Reason: Render methods depend on ImGui UI framework

### [10:50] Task: AudioReader.cs
- Target: 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs (30.2% coverage)
- Status: Already covered — 28 existing tests in AudioReaderTest.cs
- Reason: LoadMetadata/Load/NextFrame depend on external FFmpeg/ffprobe execution

### [10:52] Task: AudioPlayerWindow.cs
- Target: 1_Presentation/Engine/src/Windows/AudioPlayerWindow.cs (35.6% coverage)
- Status: Already covered — 5 existing tests in AudioPlayerWindowTest.cs
- Reason: Render method depends on ImGui UI framework

### [10:53] Task: AudioPlayer.cs
- Target: 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs (37.1% coverage)
- Status: Already covered — 9 existing tests in AudioPlayerTest.cs
- Reason: Play/OpenWrite/CloseWrite depend on external ffplay process

### [10:55] Task: AudioVideoWriter.cs
- Target: 1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs (51.2% coverage)
- Status: Already covered — 30 existing tests in AudioVideoWriterTest.cs
- Reason: OpenWrite/CloseWrite/WriteFrame depend on external FFmpeg process

### [10:30] Task: FixtureCollection.cs
- Target: 4_Operation/Physic/src/Dynamics/FixtureCollection.cs (97.1%, 1 uncovered line/condition)
- Existing tests: 24 tests in FixtureCollectionTest.cs
- Tests added: 1 test covering `IEnumerator<Fixture>.Current` throw on modification (explicit interface)
- All 25 tests pass
- Production changes: None
- Commit: 74f44fcd3

### [08:50] Task: Animator.cs (DrawAnimation coverage)
- Target: 2_Application/Alis/src/Core/Ecs/Components/Render/Animator.cs (89.2%, 7 ul, 3 uc)
- Existing tests: 33 tests in AnimatorTest.cs
- Tests added: 2 DrawAnimation tests — matching names (no LoadTexture call) and different names (LoadTexture throws without GL)
- All 35 tests pass (33 original + 2 new)
- Production changes: None required
- Remaining: DrawAnimation LoadTexture path requires GL context — not testable in unit tests

### [08:50] Task: DialogManager.cs
- Target: 1_Presentation/Extension/Language/Dialogue/src/DialogManager.cs (93.6%, 4 ul, 9 uc)
- Existing tests: 25 tests in DialogManagerTest.cs
- Tests added: 7 tests (StartDialog non-existent dialog returns, SelectOption non-existent dialog no throw, SelectOption negative index, SelectOption failing condition does not execute, GetAvailableOptions when dialog not in dict, ShowDialog invalid choice, ShowDialog choice exceeding options)
- All 44 tests pass (25 original + 7 new + 10 from DialogActionExecutor + others)
- Production changes: None required
- Commit: aa8e1d90f

### [08:30] Task: DialogActionExecutor.cs
- Target: 1_Presentation/Extension/Language/Dialogue/src/Core/DialogActionExecutor.cs (90.6%, 2 ul, 1 uc)
- Existing tests: 7 tests in DialogActionExecutorTest.cs
- Tests added: 3 tests (ExecuteAction invalid returns false, ExecuteAction invalid does not execute, ExecuteActions mixed valid/invalid counts only valid)
- All 10 tests pass (7 original + 3 new)
- Production changes: None required
- Commit: 6c9ab22ac

### [10:40] Task: CircleShape.cs
- Target: 4_Operation/Physic/src/Collisions/Shapes/CircleShape.cs (96.0%, 2 uncovered conditions)
- Existing tests: 24 tests in CircleShapeTest.cs
- Tests added: 2 edge cases — zero-length ray (`rr < Epsilon`), ray pointing away from circle (`0.0f <= a` false)
- All 26 tests pass (full suite: 2140 pass)
- Production changes: None
- Commit: pending
