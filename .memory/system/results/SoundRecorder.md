# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundRecorder.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 98.0% (100/102 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- SoundRecorder.cs is the abstract audio capture source (Start/Stop/Start-with-rate, available devices, sample rate/channel count, OnStart/OnProcessSamples/OnStop overrides, SetDevice, SetProcessingInterval) over sfSoundRecorder natives. CSFML 3.0 sfSoundRecorder_create(onStart,onProcess,onStop,userData) matches the 2.x form, so the recorder executes locally.
- Existing committed suite (SoundRecorderTest.cs + accessor) covers 100/102 executable lines, including guarded Start/Stop and the callback overrides.
- Sole missed line 221: SetProcessingInterval body. sfSoundRecorder_setProcessingInterval does not exist in CSFML 3.0 (absent from SoundRecorder.h and the installed dylib); existing test SetProcessingInterval_ThrowsEntryPointNotFound asserts the resulting EntryPointNotFoundException. The line cannot be hit. Not deterministically coverable.