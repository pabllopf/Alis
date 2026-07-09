# coverage-011: AdsManager.cs (1_Presentation/Extension/Ads/GoogleAds/src)

## Task
Cover 15 previously uncovered lines and 6 branches in AdsManager.cs (91.0% → ~95-96%)

## Commit
5c1546ebc9d9d88fad2763565a8e8a14ca8807c1

## File Modified
- `1_Presentation/Extension/Ads/GoogleAds/test/AdsManagerHappyPathTest.cs` (NEW - 42 tests)

## Methods Covered
1. `AdsManager(Context)` — sets Name, Tag, _isBannerAdVisible
2. `AdsManager(string, string, string, bool, Context)` — sets Name, Tag, _isBannerAdVisible
3. `Initialize` — null config check, empty AppId check, _configuration assignment, _isInitialized = true, Logger.Info
4. `LoadBannerAd` — not initialized check, empty adUnitId check, disabled ads branch (Logger.Warning + OnBannerAdFailedToLoad), happy path (Logger.Info + _isBannerAdLoaded = true + OnBannerAdLoaded)
5. `LoadInterstitialAd` — same happy/error paths
6. `LoadRewardedVideoAd` — same happy/error paths
7. `ShowBannerAd` — not initialized (Logger.Error), not loaded (Logger.Error), happy path (_isBannerAdVisible = true + Logger.Info)
8. `HideBannerAd` — not initialized (Logger.Error), happy path (_isBannerAdVisible = false + Logger.Info)
9. `ShowInterstitialAd` — not initialized (Logger.Error), not loaded (Logger.Error), happy path (Logger.Info + OnAdClicked + _isInterstitialAdLoaded = false)
10. `ShowRewardedVideoAd` — not initialized (Logger.Error), not loaded (Logger.Error), happy path (Logger.Info + OnAdClicked + OnAdRewarded + _isRewardedVideoAdLoaded = false)
11. `Dispose(bool)` — Logger.Info("AdsManager disposed"), if (_isInitialized) OnAdClosed

## Coverage Delta
- 42 tests added covering ~15 lines and ~6 branches
- Expected: 91.0% → ~95-96%
