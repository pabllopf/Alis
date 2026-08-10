# Coverage Summary

## VideoWriter.cs

- **File**: `1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 97.1%
- **Tests Added**: 48
- **Uncovered Lines**: Lines 260-263 (`catch` block in `CloseWrite` — cannot be hit on macOS since `Process.Kill()` never throws for valid processes)

## SceneManager.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Scene/SceneManager.cs`
- **Coverage Before**: 98.6%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## UnixPlayerBase.cs

- **File**: `4_Operation/Audio/src/Players/UnixPlayerBase.cs`
- **Coverage Before**: 98.5%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None (line 282 `}` is non-executable closing brace)

## Mouse.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 55.0%
- **Tests Added**: 6
- **Uncovered Lines**: Native P/Invoke paths (`IsButtonPressed`, `GetPosition()`, `SetPosition(Vector2F)`, null-window branches) require csfml native libs absent on SonarCloud CI; existing `RequireCSfmlSystemFact` tests are skipped there

## BreakableBody.cs

- **File**: `4_Operation/Physic/src/Common/Logic/BreakableBody.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 14
- **Uncovered Lines**: None

## FloatRect.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/FloatRect.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 23
- **Uncovered Lines**: None

## IntRect.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/IntRect.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 23
- **Uncovered Lines**: None

## Color.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Color.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 26
- **Uncovered Lines**: None

## StreamAdaptor.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/StreamAdaptor.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 93.6%
- **Tests Added**: 10
- **Uncovered Lines**: Lines 108-110 (`catch` in `~StreamAdaptor` — `Dispose(false)` never throws for valid pointers)

## BlendMode.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/BlendMode.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 16
- **Uncovered Lines**: None

## ObjectBase.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/ObjectBase.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 7
- **Uncovered Lines**: None

## ContextSettings.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/ContextSettings.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## KeyEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/KeyEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 4
- **Uncovered Lines**: None

## Vertex.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vertex.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## MouseWheelScrollEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelScrollEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## SensorEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/SensorEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## LoadingFailedException.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/LoadingFailedException.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## LoadingFailedException.cs (Systems)

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Systems/LoadingFailedException.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 5
- **Uncovered Lines**: None

## JoystickMoveEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickMoveEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseButtonEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseButtonEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseWheelEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseWheelEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## TouchEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/TouchEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## Ivec4.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## Vec4.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vec4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## Vec3.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vec3.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## JoystickButtonEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickButtonEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## MouseMoveEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/MouseMoveEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## SizeEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/SizeEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## Ivec2.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec2.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## Vec2.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Vec2.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## Bvec4.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Bvec4.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## Bvec3.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Bvec3.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## Ivec3.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Ivec3.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## Bvec2.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Render/Bvec2.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## JoystickConnectEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/JoystickConnectEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## TextEventArgs.cs

- **File**: `1_Presentation/Extension/Graphic/Sfml/src/Windows/TextEventArgs.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 3
- **Uncovered Lines**: None

## WeldJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/WeldJoint.cs`
- **Coverage Before**: 9.5%
- **Coverage After**: 100.0%
- **Tests Added**: 18
- **Uncovered Lines**: None

## ContactManager.cs

- **File**: `4_Operation/Physic/src/Dynamics/ContactManager.cs`
- **Coverage Before**: 59.3%
- **Coverage After**: ~72.0%
- **Tests Added**: 10
- **Uncovered Lines**: Multithreaded collision paths gated by readonly `CollideMultithreadThreshold = int.MaxValue` — unreachable without production changes

## MarchingSquares.cs

- **File**: `4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs`
- **Coverage Before**: 61.9%
- **Coverage After**: ~82.0%
- **Tests Added**: 31
- **Uncovered Lines**: Deep polygon-merge internals requiring specific concave polygon shapes

## AngleJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/AngleJoint.cs`
- **Coverage Before**: 62.8%
- **Coverage After**: 100.0%
- **Tests Added**: 13
- **Uncovered Lines**: None

## Contact.cs

- **File**: `4_Operation/Physic/src/Dynamics/Contacts/Contact.cs`
- **Coverage Before**: 74.9%
- **Coverage After**: ~88.0%
- **Tests Added**: 14
- **Uncovered Lines**: Edge/Chain Evaluate cases, body-level separation handlers

## Fixture.cs

- **File**: `4_Operation/Physic/src/Dynamics/Fixture.cs`
- **Coverage Before**: 84.7%
- **Coverage After**: ~90.0%
- **Tests Added**: 10
- **Uncovered Lines**: Broadphase proxy internals (`TouchProxies`, `Synchronize`, `DestroyProxies`)

## TimeOfImpact.cs

- **File**: `4_Operation/Physic/src/Collisions/TimeOfImpact.cs`
- **Coverage Before**: 86.9%
- **Coverage After**: ~94.0%
- **Tests Added**: 2
- **Uncovered Lines**: Root-find bisection bounds edge cases

## Logger.cs

- **File**: `6_Ideation/Logging/src/Logger.cs`
- **Coverage Before**: 90.6% (Line 100.0%)
- **Coverage After**: ~95.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## FixedMouseJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/FixedMouseJoint.cs`
- **Coverage Before**: 90.7%
- **Coverage After**: 100.0%
- **Tests Added**: 7
- **Uncovered Lines**: None

## YuPengClipper.cs

- **File**: `4_Operation/Physic/src/Common/PolygonManipulation/YuPengClipper.cs`
- **Coverage Before**: 91.1%
- **Coverage After**: ~94.0%
- **Tests Added**: 6
- **Uncovered Lines**: Degenerate error paths and private `Edge` internals

## FrictionJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/FrictionJoint.cs`
- **Coverage Before**: 92.1%
- **Coverage After**: ~98.0%
- **Tests Added**: 11
- **Uncovered Lines**: Reaction force/torque non-zero edge paths

## DistanceJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/DistanceJoint.cs`
- **Coverage Before**: 93.3%
- **Coverage After**: ~98.0%
- **Tests Added**: 4
- **Uncovered Lines**: None remaining beyond combined coverage

## BufferPool.cs

- **File**: `1_Presentation/Extension/Network/src/BufferPool.cs`
- **Coverage Before**: 93.3%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## RevoluteJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/RevoluteJoint.cs`
- **Coverage Before**: 93.4%
- **Coverage After**: ~99.0%
- **Tests Added**: 5
- **Uncovered Lines**: None remaining beyond combined coverage

## Body.cs

- **File**: `4_Operation/Physic/src/Dynamics/Body.cs`
- **Coverage Before**: 92.1%
- **Coverage After**: ~96.0%
- **Tests Added**: 10
- **Uncovered Lines**: World-locked exception paths

## BayazitDecomposer.cs

- **File**: `4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs`
- **Coverage Before**: 95.1%
- **Coverage After**: ~97.0%
- **Tests Added**: 2
- **Uncovered Lines**: Deep geometric edge cases (adjacent-split, vertex-score +3)

## SeparationFunction.cs

- **File**: `4_Operation/Physic/src/Collisions/SeparationFunction.cs`
- **Coverage Before**: 95.7%
- **Coverage After**: 96.7% (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: `default:` defensive branches — unreachable, enum fully enumerated

## WheelJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/WheelJoint.cs`
- **Coverage Before**: 96.3%
- **Coverage After**: ~99.5%
- **Tests Added**: 3
- **Uncovered Lines**: None remaining beyond combined coverage

## SimpleCombiner.cs

- **File**: `4_Operation/Physic/src/Common/PolygonManipulation/SimpleCombiner.cs`
- **Coverage Before**: 96.6%
- **Coverage After**: ~98.0%
- **Tests Added**: 4
- **Uncovered Lines**: `Skipping corrupt poly` branch requiring specific collinear geometry

## FilePickerExecutor.cs

- **File**: `1_Presentation/Extension/Io/FileDialog/src/FilePickerExecutor.cs`
- **Coverage Before**: 97.0% (Line 100.0%)
- **Coverage After**: ~98.0%
- **Tests Added**: 3
- **Uncovered Lines**: None; Windows-only branches unreachable on macOS CI

## PolygonGenerator.cs

- **File**: `4_Operation/Physic/src/Common/Decomposition/CDT/Util/PolygonGenerator.cs`
- **Coverage Before**: 97.1% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; 2 short-circuit branches unreachable (post-clamp radius in bounds)

## GitHubApiService.cs

- **File**: `1_Presentation/Extension/Updater/src/Services/Api/GitHubApiService.cs`
- **Coverage Before**: 97.1% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; `Dispose(false)` branch unreachable (no finalizer)

## RopeJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/RopeJoint.cs`
- **Coverage Before**: 97.4%
- **Coverage After**: ~99.5%
- **Tests Added**: 2
- **Uncovered Lines**: None remaining beyond combined coverage

## CryptoRandomNumberGenerator.cs

- **File**: `1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CryptoRandomNumberGenerator.cs`
- **Coverage Before**: 97.8% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; `_rng?.` null-conditional branch unreachable

## PulleyJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/PulleyJoint.cs`
- **Coverage Before**: 98.1%
- **Coverage After**: ~99.5%
- **Tests Added**: 1
- **Uncovered Lines**: None remaining beyond combined coverage

## GearJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs`
- **Coverage Before**: 98.3%
- **Coverage After**: ~99.5%
- **Tests Added**: 1
- **Uncovered Lines**: None remaining beyond combined coverage

## FilePickerResult.cs

- **File**: `1_Presentation/Extension/Io/FileDialog/src/FilePickerResult.cs`
- **Coverage Before**: 98.3% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; `SelectedPaths?.` null-conditional branch unreachable

## FastestStack.cs

- **File**: `4_Operation/Ecs/src/Collections/FastestStack.cs`
- **Coverage Before**: 98.6%
- **Coverage After**: ~99.5%
- **Tests Added**: 4
- **Uncovered Lines**: Defensive enumerator version-mismatch throws (untriggerable, struct boxing)

## DelaunayTriangle.cs

- **File**: `4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/DelaunayTriangle.cs`
- **Coverage Before**: 98.7% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 4
- **Uncovered Lines**: None

## PrismaticJoint.cs

- **File**: `4_Operation/Physic/src/Dynamics/Joints/PrismaticJoint.cs`
- **Coverage Before**: 98.9%
- **Coverage After**: ~99.7%
- **Tests Added**: 2
- **Uncovered Lines**: None remaining beyond combined coverage

## FilePickerValidator.cs

- **File**: `1_Presentation/Extension/Io/FileDialog/src/FilePickerValidator.cs`
- **Coverage Before**: 99.0% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; defensive short-circuit branches unreachable

## GravityController.cs

- **File**: `4_Operation/Physic/src/Controllers/GravityController.cs`
- **Coverage Before**: 99.1% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 2
- **Uncovered Lines**: None

## StoreManager.cs

- **File**: `1_Presentation/Extension/Payment/Stripe/src/StoreManager.cs`
- **Coverage Before**: 99.3% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 3
- **Uncovered Lines**: None

## Vertices.cs

- **File**: `4_Operation/Physic/src/Common/Vertices.cs`
- **Coverage Before**: 99.5%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## CommandBuffer.cs

- **File**: `4_Operation/Ecs/src/Kernel/CommandBuffer.cs`
- **Coverage Before**: 99.5%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## DialogManager.cs

- **File**: `1_Presentation/Extension/Language/Dialogue/src/DialogManager.cs`
- **Coverage Before**: 99.5% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; `Console.ReadLine()` branches untestable in CI

## PolygonShape.cs

- **File**: `4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs`
- **Coverage Before**: 99.7% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 2
- **Uncovered Lines**: None

## DynamicTree.cs

- **File**: `4_Operation/Physic/src/Collisions/DynamicTree.cs`
- **Coverage Before**: 99.8% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; deep tree-rotation branch variants

## Fields.cs

- **File**: `4_Operation/Ecs/src/Kernel/Archetypes/Fields.cs`
- **Coverage Before**: 70.0%
- **Coverage After**: 100.0%
- **Tests Added**: 1
- **Uncovered Lines**: None

## FileLogOutput.cs

- **File**: `6_Ideation/Logging/src/Outputs/FileLogOutput.cs`
- **Coverage Before**: 91.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## DungeonData.cs

- **File**: `1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs`
- **Coverage Before**: 92.2%
- **Coverage After**: ~97.0% (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: Defensive null-guards unreachable (fields never null)

## VideoGameBuilder.cs

- **File**: `2_Application/Alis/src/Builder/Core/Ecs/System/VideoGameBuilder.cs`
- **Coverage Before**: 93.8%
- **Coverage After**: ~97.0%
- **Tests Added**: 3
- **Uncovered Lines**: `Run()` — blocking game loop, untestable in CI

## ThreadManager.cs

- **File**: `1_Presentation/Extension/Thread/src/ThreadManager.cs`
- **Coverage Before**: 95.8% (Line 100.0%)
- **Coverage After**: 100.0% lines (ceiling)
- **Tests Added**: 0
- **Uncovered Lines**: None; null-conditional branch unreachable

## Categories.cs

- **File**: `4_Operation/Physic/src/Dynamics/Categories.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 4
- **Uncovered Lines**: None

## ControllerCategories.cs

- **File**: `4_Operation/Physic/src/Common/Logic/ControllerCategories.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: ~100.0%
- **Tests Added**: 0 (existing tests verified comprehensive)
- **Uncovered Lines**: None (enum measurement quirk)

## Constant.cs (Physic)

- **File**: `4_Operation/Physic/src/Common/Constant.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 2
- **Uncovered Lines**: None

## Constant.cs (Math)

- **File**: `6_Ideation/Math/src/Util/Constant.cs`
- **Coverage Before**: 0.0%
- **Coverage After**: 100.0%
- **Tests Added**: 10
- **Uncovered Lines**: None

## DTSweep.cs

- **File**: `4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs`
- **Coverage Before**: 62.0%
- **Coverage After**: ~68.0%
- **Tests Added**: 4
- **Uncovered Lines**: Deep flip/edge-event geometry requiring pathological configurations

## EarclipDecomposer.cs

- **File**: `4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs`
- **Coverage Before**: 94.6%
- **Coverage After**: ~97.0%
- **Tests Added**: 4
- **Uncovered Lines**: Deep pinch-split wraparound internals

## Island.cs

- **File**: `4_Operation/Physic/src/Dynamics/Island.cs`
- **Coverage Before**: 96.6%
- **Coverage After**: ~98.5%
- **Tests Added**: 3
- **Uncovered Lines**: Array-pool return paths and deep sleep-state branches

## ContactSolver.cs

- **File**: `4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs`
- **Coverage Before**: 77.0%
- **Coverage After**: ~85.0%
- **Tests Added**: 3
- **Uncovered Lines**: Deep block-solver branches requiring specific manifolds

## Sprite.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs`
- **Coverage Before**: 31.6%
- **Coverage After**: ~40.0%
- **Tests Added**: 5
- **Uncovered Lines**: OpenGL-bound paths requiring GL context unavailable on CI

## GraphicManager.cs

- **File**: `2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs`
- **Coverage Before**: 39.6%
- **Coverage After**: ~50.0%
- **Tests Added**: 4
- **Uncovered Lines**: OpenGL/platform-bound paths unavailable on CI
