# AudioReader Coverage Task — COMPLETED
# File: 1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs
# Coverage: 31.4% | Line Coverage: 33.7% | Branch Coverage: 26.2% | Uncovered Lines: 65

## Completed Tests (Commit: 58fc1848e)
- Constructor default initialization
- Constructor with custom ffplay path
- Constructor with filename
- Full constructor with all parameters
- Dispose on fresh instance (no throw)
- Multiple dispose calls (idempotent)
- Dispose on default-constructed player
- Play without filename → InvalidOperationException
- Play with empty string filename → InvalidOperationException  
- Play with null filename → InvalidOperationException
- OpenWrite with invalid bit depths (8, 17, 48, 64, -16, 0) → InvalidOperationException
- CloseWrite when not opened → InvalidOperationException
- PlayInBackground without filename → InvalidOperationException
- Play with extra params but no filename → InvalidOperationException
- PlayInBackground with extra params but no filename → InvalidOperationException

## Test Count: 19 tests added
## Estimated Coverage Improvement: +3-5% on AudioPlayer.cs
