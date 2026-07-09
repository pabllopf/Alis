# coverage-010 — AdsManager.cs (Complete)

## Summary
Added 5 tests covering uncovered catch blocks in `AdsManager.cs`:
- **LoadBannerAd catch**: subscriber throws in OnBannerAdLoaded → OnBannerAdFailedToLoad fires
- **LoadInterstitialAd catch**: subscriber throws in OnInterstitialAdLoaded → OnInterstitialAdFailedToLoad fires
- **LoadRewardedVideoAd catch**: subscriber throws in OnRewardedVideoAdLoaded → OnRewardedVideoAdFailedToLoad fires
- **Dispose(false) path**: no-op path when disposing=false (via wrapper class exposing protected method)
- **Dispose(false) after init**: OnAdClosed should NOT fire when disposing=false

## Key Discovery
The catch blocks in Load*Ad fire the FailedToLoad event but do NOT reset the `_is*AdLoaded` flag (it was set to `true` before the event fired). This matches the existing behavior — the catch is for logging/failure notification, not state rollback.

## Files Changed
- `1_Presentation/Extension/Ads/GoogleAds/test/AdsManagerCoverageTest.cs` (new, 184 lines) — 5 new xUnit tests + wrapper class

## Commit
- `dcc3eca97` — test: coverage AdsManager.cs

## Coverage Delta
- File: `AdsManager.cs` — was 91.0% (Line: 91.0%, Branch: 90.9%) with 15 ul / 6 branches

## Next
- Increment skip to 10 for next loop iteration
