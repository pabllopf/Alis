# Alis.Extension.Ads.GoogleAds

tags:
  - presentation,application,extension,documentation

## Overview

The **Alis.Extension.Ads.GoogleAds** project provides an abstraction layer for Google AdMob integration, enabling game developers to implement monetization through banner ads, interstitial ads, and rewarded video ads.

**Type**: Extension  
**Framework**: net8.0/netstandard2.0  
**Files**: 4 source files

## Purpose

This extension provides a unified interface for integrating Google AdMob ads into ALIS games, handling ad lifecycle management, event callbacks, and test mode configuration.

## Components

### Core Classes

| Class | Description | Lines |
|-------|-------------|-------|
| `AdsManager` | Main ad management system | 448 |
| `AdConfiguration` | Ad configuration settings | - |
| `IAdsManager` | Ads manager interface | - |
| `AdRewardEventArgs` | Reward event data | - |

## Architecture

### Design Pattern

Implements the **Manager Pattern** from ALIS Core:

```csharp
public class AdsManager : AManager, IAdsManager, IDisposable
{
    private bool _isInitialized;
    private AdConfiguration _configuration;
}
```

### Ad Types Supported

1. **Banner Ads**: Persistent ads displayed at screen edges
2. **Interstitial Ads**: Full-screen ads between game transitions
3. **Rewarded Video Ads**: Optional ads that reward users for watching

### Event-Driven Architecture

Uses C# events for ad lifecycle callbacks:

```csharp
public event Action<string> OnBannerAdLoaded;
public event Action<string> OnBannerAdFailedToLoad;
public event Action<AdRewardEventArgs> OnAdRewarded;
```

## Public API

### Initialization

```csharp
var config = new AdConfiguration
{
    AppId = "ca-app-pub-...",
    IsTestMode = true,
    IsEnabled = true
};

await AdsManager.InitializeAsync(config);
```

### Banner Ads

```csharp
// Load banner ad
await AdsManager.LoadBannerAdAsync(adUnitId);

// Show/hide banner
AdsManager.ShowBannerAd();
AdsManager.HideBannerAd();
```

### Interstitial Ads

```csharp
// Load interstitial ad
await AdsManager.LoadInterstitialAdAsync(adUnitId);

// Show interstitial (auto-loads next)
AdsManager.ShowInterstitialAd();
```

### Rewarded Video Ads

```csharp
// Load rewarded video ad
await AdsManager.LoadRewardedVideoAdAsync(adUnitId);

// Show rewarded video (triggers OnAdRewarded event)
AdsManager.ShowRewardedVideoAd();
```

### Event Handlers

```csharp
AdsManager.OnAdRewarded += (sender, args) => 
{
    // Grant reward to player
    Player.Gold += args.RewardAmount;
};
```

## Dependencies

```xml
<Project Sdk="Microsoft.NET.Sdk">
    <Import Project="$(SolutionDir).config/Config.props"/>
</Project>
```

**Internal Dependencies**:
- `Alis.Core.Aspect.Logging` - Logging aspect
- `Alis.Core.Ecs.Systems.Manager` - Manager base class
- `Alis.Core.Ecs.Systems.Scope` - Context scope

## Configuration

### AdConfiguration

| Property | Type | Description |
|----------|------|-------------|
| `AppId` | string | Google AdMob App ID (required) |
| `IsTestMode` | bool | Enable test ads (default: true) |
| `IsEnabled` | bool | Enable/disable ads globally |

### Test Mode

Test ad unit IDs provided by Google:

- Banner: `ca-app-pub-3940256099942544/6300978111`
- Interstitial: `ca-app-pub-3940256099942544/1033173712`
- Rewarded: `ca-app-pub-3940256099942544/5224354917`

## Usage Example

```csharp
// Initialize in game startup
var adsManager = new AdsManager(context);
var config = new AdConfiguration
{
    AppId = "ca-app-pub-XXXXXXXXXXXX~YYYYYYYYYY",
    IsTestMode = true,
    IsEnabled = true
};

await adsManager.InitializeAsync(config);

// Load and show banner ad
await adsManager.LoadBannerAdAsync(adUnitId);
adsManager.ShowBannerAd();

// Show interstitial between levels
await adsManager.LoadInterstitialAdAsync(adUnitId);
adsManager.ShowInterstitialAd();

// Setup rewarded video
await adsManager.LoadRewardedVideoAdAsync(adUnitId);
adsManager.OnAdRewarded += (sender, args) => 
{
    Player.GainReward(args.RewardAmount);
};
```

## Testing

**Test Project**: `Alis.Extension.Ads.GoogleAds.Test`  
**Sample Project**: `Alis.Extension.Ads.GoogleAds.Sample`

## Security Considerations

⚠️ **Production Deployment**:
- Disable test mode in production
- Use secure ad unit IDs from Google Console
- Never commit real API keys to version control

## Status

| Aspect | Status |
|--------|--------|
| Implementation | ✓ Complete |
| Documentation | ✓ Documented |
| Tests | Pending |
| Samples | Pending |

## Related Projects

- [[projects/1_Presentation/Alis.Extension.Security]] - Secure data handling
- [[Alis.Core.Aspect.Logging]] - Logging system
- [[Alis.Core.Ecs]] - ECS engine

## TODO

- [ ] Add integration tests with mock AdMob
- [ ] Create sample game demonstrating all ad types
- [ ] Document analytics and reporting features
- [ ] Add A/B testing support for ad placements
