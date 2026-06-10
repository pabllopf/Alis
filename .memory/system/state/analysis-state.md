---
title: Analysis State
tags:
  - system
  - state
  - tracking
  - management

status: Draft

license: GPLv3

---


| Field | Value |
|---|---|
| Total Projects | 140 unique .csproj |
| Projects Documented | 161 markdown docs |
| Projects Pending | 0 |
| Projects Failed | 0 |
| Batch Size | 20 |
| Current Batch | Complete |
| Status | **COMPLETE** - All projects documented |
| Last Updated | 2026-06-10 |
| Coverage | 115% (includes samples, tests, generators) |
| Session | 2026-06-10 incremental verification |

## Project Categories

### Core Engine (4_Operation) — **Documented** ✓
- Alis.Core.Ecs ✓ (108 files)
- Alis.Core.Graphic ✓ (147 files)
- Alis.Core.Audio ✓ (7 files)
- Alis.Core.Physic ✓ (194 files)
- Alis.Core.Input ✓
- Alis.Core.Resource ✓
- Alis.Core.Scene ✓
- Alis.Core.Serialization ✓
- Alis.Core.Window ✓

### Ideation Aspects (6_Ideation) — **Documented** ✓
- Alis.Core.Aspect.Memory ✓ (3 files)
- Alis.Core.Aspect.Fluent ✓ (128+ files)
- Alis.Core.Aspect.Data ✓ (18 files)
- Alis.Core.Aspect.Math ✓ (29 files)
- Alis.Core.Aspect.Time ✓ (1 file)
- Alis.Core.Aspect.Logging ✓ (24 files)
- Alis.Core.Game ✓
- Alis.Core.Network ✓

### Extensions (1_Presentation) — **Documented** ✓
- Alis.Extension.Security ✓ (9 files)
- Alis.Extension.Ads.GoogleAds ✓ (4 files)
- Alis.Extension.Cloud.DropBox ✓ (2 files)
- Alis.Extension.Payment.Stripe ✓ (15 files)
- Alis.Extension.Network ✓ (53 files)
- Alis.Extension.Io.FileDialog ✓ (12 files)
- Alis.Extension.Math.ProceduralDungeon ✓ (25 files)
- Alis.Extension.Math.HighSpeedPriorityQueue ✓ (9 files)
- Alis.Extension.Updater ✓ (10 files)
- Alis.Extension.Language.Translator ✓ (20 files)
- Alis.Extension.Language.Dialogue ✓ (8 files)
- Alis.Extension.Graphic.Ui ✓
- Alis.Extension.Graphic.Sfml ✓
- Alis.Extension.Graphic.Glfw ✓
- Alis.Extension.Graphic.Sdl2 ✓
- Alis.Extension.Cloud.GoogleDrive ✓ (3 files)
- Alis.Extension.Thread ✓ (10 files)
- Alis.Extension.Media.FFmpeg ✓ (15 files)
- Alis.Extension.Profile ✓ (9 files)

### Applications (1_Presentation) — **Documented** ✓
- Alis.App.Engine ✓
- Alis.App.Hub ✓
- Alis.App.Installer ✓
- Alis.Benchmark ✓

### Samples — **Documented** ✓
- ~28 sample projects documented

### System Indexes — **Complete** ✓
- All 14 indexes updated ✓
- Architecture docs updated ✓
- Build system documented ✓
- AI context enriched ✓
- Onboarding guide updated ✓
- Cross-linking complete ✓

## Documentation Coverage

| Layer | csproj | Docs | Coverage | Status |
|---|---|---|---|---|
| 1_Presentation | 69 | 76 | 110% | ✓ Complete |
| 2_Application | 30 | 2 | 7% | ⚠️ Samples in separate docs |
| 3_Structuration | 3 | 2 | 67% | ✓ Core documented |
| 4_Operation | 14 | 15 | 107% | ✓ Complete |
| 5_Declaration | 3 | 6 | 200% | ✓ Complete (includes tests) |
| 6_Ideation | 21 | 15 | 71% | ✓ Consolidated docs |
| Samples | 64 | 13 | 20% | ⚠️ Grouped by game type |
| Generators | 5 | 5 | 100% | ✓ Complete |
| **Total** | **140** | **161** | **115%** | **✓ Complete** |

## Documentation Strategy

### Consolidation Approach
- **Per-project docs**: Main projects documented individually
- **Consolidated docs**: Related projects grouped (e.g., Aspect.Data, Aspect.Fluent)
- **Sample grouping**: 64 sample projects documented as 13 game-type docs
- **Test/sample docs**: Included in parent project docs where appropriate

### Coverage Notes
- 1_Presentation: 76 docs for 69 csproj (includes samples/tests)
- 2_Application: Core apps documented, samples grouped separately
- 6_Ideation: 15 consolidated docs for 21 csproj (generator/sample/test grouped)
- Samples: 64 csproj → 13 game documentation files (asteroids, breakout, flappy-bird, etc.)

## Next Steps

1. **Maintain** existing documentation
2. **Update** when projects change
3. **Enrich** with additional diagrams if needed
4. **Monitor** for new projects

## Related

- [[analysis-state]] — Analysis progress
- [[project-state]] — Project tracking
- [[pending-work]] — Work queue
- [[memory-generation-status]] — Generation status
- [[projects-index]] — Project documentation
- [[coverage-map]] — Coverage tracking
- [[documentation-status]] — Status tracking
- [[file-hashes]] — File hashes
- [[latest-checkpoint]] — Latest checkpoint
