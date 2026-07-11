---
title: Alis.Core.Audio
tags:
  - project
  - audio
  - sound
  - layer-4
status: Draft
license: GPLv3
---

# Alis.Core.Audio

## Overview

Audio playback library (Layer 4 - Operation). Provides audio management and playback capabilities.

## Properties

| Property | Value |
|---|---|
| **Layer** | 4 - Operation |
| **Project Path** | `4_Operation/Audio/src/` |
| **Test Project** | `Alis.Core.Audio.Test` |
| **Generator** | `Alis.Core.Audio.Generator` |
| **Has Samples** | Yes (`Alis.Core.Audio.Sample`) |

## Dependencies

- **Depends On**: [[Alis.Core.Aspect]] (via Layer 3/5 chain)
- **Used By**: [[Alis.App.Engine]]

## Architecture

- `src/Interfaces/` - Audio service interfaces
- `src/Players/` - Audio player implementations

## Source Structure

```
src/
  Interfaces/
  Players/
```

## Testing

- Test project: `Alis.Core.Audio.Test`
- Located at `4_Operation/Audio/test/`

## Related

- [[Alis.App.Engine]]
- [[Projects Index]]
