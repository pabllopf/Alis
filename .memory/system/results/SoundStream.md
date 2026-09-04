# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundStream.cs
CoverageBefore: 0.0% (SonarCloud CI) / 4.3% (6/138 local)
CoverageAfter: 29.0% (40/138 lines; verified via XPlat Code Coverage)
TestsAdded: 3 (SoundStreamManagedCallbackTests.cs)
Commit: test: coverage SoundStream.cs
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- SoundStream.cs is an abstract streamed-audio source: abstract OnGetData/OnSeek, protected Initialize(channelCount, sampleRate) creating the native stream with managed GetData/Seek callbacks, plus the standard SFML sound accessors and Play/Pause/Stop.
- Existing suite was reflection-only (SoundStreamTest.cs, 6 ctor/abstract lines covered). Added SoundStreamManagedCallbackTests.cs exercising the pure-managed callback plumbing: private GetData fill branch (pins OnGetData buffer into Chunk, returns true), GetData EOF branch (OnGetData false), and internal Seek forwarding to OnSeek. New coverage: ctor + lines 308-326 GetData + 336-338 Seek.
- Remaining 49 missed lines require a live native stream: sfSoundStream_create in CSFML 3.0 is (onGetData, onSeek, channels, rate, sfSoundChannel* channelMapData, size_t channelMapSize, void* userData) while production calls the CSFML 2.x 5-arg form. The missing channelMap args are read from garbage registers; an isolated probe test calling Initialize caused the test host to block (native crash) — confirmed by a targeted run ("Proceso de host de pruebas bloqueado"). Probe reverted.
- All native members (SampleRate, ChannelCount, Status, Loop, Pitch, Volume, Position, RelativeToListener, MinDistance, Attenuation, PlayingOffset, Play/Pause/Stop, ToString, Destroy-with-live-pointer) and Initialize/Destroy lines are unreachable without alive native pointer. ObjectBase.Dispose guards non-zero CPointer, so Destroy cannot be reached with the zero-pointer ctor either.
- Full Sfml suite: 1863/1863 pass (net8.0).