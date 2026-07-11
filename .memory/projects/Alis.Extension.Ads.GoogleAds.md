---
title: Alis.Extension.Ads.GoogleAds
tags:
  - project
  - ads
  - google-ads
  - advertising
  - layer-1
status: Draft
license: GPLv3
---

# Alis.Extension.Ads.GoogleAds

## Overview

Google Ads integration (Layer 1 - Extension). Provides advertising capabilities through Google Ads API.

## Properties

| Property | Value |
|---|---|
| **Layer** | 1 - Presentation (Extension) |
| **Project Path** | `1_Presentation/Extension/Ads/GoogleAds/src/` |
| **Test Project** | `Alis.Extension.Ads.GoogleAds.Test` |
| **Has Samples** | Yes (`Alis.Extension.Ads.GoogleAds.Sample`) |

## Dependencies

- **Depends On**: [[Alis]] (Layer 2 - Application)
- **NuGet**: Google.Ads.Common v9.5.3

## Architecture

- Flat file structure in `src/`
- Key types: `AdsManager`, `AdConfiguration`, `AdRewardEventArgs`, `IAdsManager`

## Related

- [[Projects Index]]
