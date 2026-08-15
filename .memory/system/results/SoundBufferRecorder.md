# Result: SoundBufferRecorder.cs

File: `1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBufferRecorder.cs`
CoverageBefore: 0.0% (SonarCloud; stale artifact)
CoverageAfter: 81.2% (13/16 lines, local coverlet; unchanged)
TestsAdded: 0 (OnStop depends on the broken SoundBuffer samples constructor)
Commit: test: coverage SoundBufferRecorder.cs
Status: BLOCKED_BY_PRODUCTION_CODE

## Summary

SoundBufferRecorder.cs is the SFML sound-buffer recorder wrapper (SoundBuffer property,
ToString, OnStart/OnProcessSamples/OnStop overrides). The committed `SoundBufferRecorderTest.cs`
covers 13/16 lines (81.2%) on a desktop host (ctor, OnStart, OnProcessSamples, ToString, base
SoundRecorder members).

## Remaining uncovered lines (3) — BLOCKED_BY_PRODUCTION_CODE

Lines 97-99 (`OnStop`): the body builds `new SoundBuffer(mySamplesArray.ToArray(), 1,
SampleRate)`, which routes into the `SoundBuffer(short[], uint, uint)` constructor whose
`sfSoundBuffer_createFromSamples` declaration mismatches CSFML 3.0's 6-parameter signature
(extra channelMapData/channelMapSize read from garbage registers). A direct probe
(OnProcessSamples then OnStop) failed with `LoadingFailedException: Failed to load sound
buffer from memory` (and the sibling SoundBuffer analysis in this repo records SIGBUS for
other sample counts). The exception is thrown at the call site, so `OnStop` cannot complete
and its lines are only coverable by a platform-version-dependent throwing test, which was
rejected (same decision as the committed SoundBuffer suite, whose samples-ctor probes were
removed).

Deterministic coverage requires the production ABI fix for
`sfSoundBuffer_createFromSamples`, out of scope.

## Verification

- SoundBufferRecorder filter (net8.0, Debug): 18 passed, 0 failed, 0 skipped.
- Local coverlet: SoundBufferRecorder.cs 13/16 lines (81.2%); lines 97-99 blocked.
- Direct OnStop probe: LoadingFailedException at SoundBuffer.cs:142.
