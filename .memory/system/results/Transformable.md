# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Render/Transformable.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 100.0% (144/144 lines, existing committed suite; verified via XPlat Code Coverage, 56 tests pass)
TestsAdded: 0
Commit: (none)
Status: ALREADY_COVERED_LOCALLY
Details:
- Transformable.cs is the SFML transformable base (Position, Rotation, Scale, Origin, Transform, InverseTransform, Move/Rotate/Scale mutators, ToString, Destroy of the sfTransformable native handle).
- Existing committed suite (TransformableTests.cs + TransformableTest.cs, 56 tests) covers 144/144 executable lines. sfTransformable ABI is stable in CSFML 3.0, so native get/set calls execute locally.
- SonarCloud 0% is the CI no-native-lib artifact; no new tests needed.