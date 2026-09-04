# Coverage Worker Result
File: 1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBuffer.cs
CoverageBefore: 0.0% (SonarCloud CI)
CoverageAfter: 77.8% (98/126 lines, existing committed suite; verified via XPlat Code Coverage)
TestsAdded: 0
Commit: (none)
Status: PARTIAL_BLOCKED_BY_NATIVE
Details:
- SoundBuffer.cs wraps sfSoundBuffer natives: byte[] and embedded-resource ctors (sfSoundBuffer_createFromMemory, 2-arg — stable ABI, executes), SoundBuffer(short[],channels,rate) ctor, copy-from, accessors (SampleRate, ChannelCount, Duration, Samples, Duration), and LoadingFailedException guards.
- Existing committed suite (SoundBufferTest.cs + SoundBufferRemainingCoverageTests.cs) covers 98/126 executable lines including the byte[]/memory path and accessors.
- Remaining 14 uncovered lines (127-144) are the SoundBuffer(short[],uint,uint) ctor body + guard. Isolated probe test calling it blocked the test host: CSFML 3.0 sfSoundBuffer_createFromSamples is (samples, count, channels, rate, sfSoundChannel*, size_t channelMapSize) while production calls the CSFML 2.x 4-arg form, so native reads garbage channelMap registers (identical root cause to SoundStream.Initialize). Probe reverted.
- Not deterministically coverable without editing src (production ABI pinned to 2.x).