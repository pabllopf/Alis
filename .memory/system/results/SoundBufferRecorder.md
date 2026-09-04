# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBufferRecorder.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 81.25% (26/32 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- Missed lines 97-99: OnStop() override whose body constructs `new SoundBuffer(mySamplesArray.ToArray(), 1, SampleRate)`.
- That ctor routes to the CSFML 3.0 `sfSoundBuffer_createFromSamples(samples, samplesCount, channelCount, sampleRate, channelMap, channelMapSize)` (6-arg; ABI gained the channelMap pair) vs production's 4-arg define — verified host-crashing signature divergence (same blocker as SoundBuffer.cs). No recording/samples path can reach OnStop without crashing the test host.
- Everything else (Start/Stop/IsAvailable/OnStart/OnProcessSamples, buffer get) is covered. OnProcessSamples runs without a native call.