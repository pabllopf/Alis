---
title: Testing Overview
tags:
  - testing
  - overview
  - coverage
status: Draft
license: GPLv3
---

# Testing Overview

## Test Projects

The repository contains **34 test projects** across all layers:

### Layer 1: Presentation (14 test projects)
| Test Project | Source Project |
|---|---|
| Alis.App.Engine.Test | Alis.App.Engine |
| Alis.App.Hub.Test | Alis.App.Hub |
| Alis.App.Installer.Test | Alis.App.Installer |
| Alis.Extension.Network.Test | Alis.Extension.Network |
| Alis.Extension.Security.Test | Alis.Extension.Security |
| Alis.Extension.Profile.Test | Alis.Extension.Profile |
| Alis.Extension.Media.FFmpeg.Test | Alis.Extension.Media.FFmpeg |
| Alis.Extension.Graphic.Sdl2.Test | Alis.Extension.Graphic.Sdl2 |
| Alis.Extension.Graphic.Sfml.Test | Alis.Extension.Graphic.Sfml |
| Alis.Extension.Graphic.Glfw.Test | Alis.Extension.Graphic.Glfw |
| Alis.Extension.Graphic.Ui.Test | Alis.Extension.Graphic.Ui |
| Alis.Extension.Io.FileDialog.Test | Alis.Extension.Io.FileDialog |
| Alis.Extension.Cloud.GoogleDrive.Test | Alis.Extension.Cloud.GoogleDrive |
| Alis.Extension.Cloud.DropBox.Test | Alis.Extension.Cloud.DropBox |

### Layer 2: Application (1 test project)
| Test Project | Source Project |
|---|---|
| Alis.Test | Alis |

### Layer 3: Structuration (1 test project)
| Test Project | Source Project |
|---|---|
| Alis.Core.Test | Alis.Core |

### Layer 4: Operation (4 test projects)
| Test Project | Source Project |
|---|---|
| Alis.Core.Ecs.Test | Alis.Core.Ecs |
| Alis.Core.Audio.Test | Alis.Core.Audio |
| Alis.Core.Graphic.Test | Alis.Core.Graphic |
| Alis.Core.Physic.Test | Alis.Core.Physic |

### Layer 5: Declaration (1 test project)
| Test Project | Source Project |
|---|---|
| Alis.Core.Aspect.Test | Alis.Core.Aspect |

### Layer 6: Ideation (6 test projects)
| Test Project | Source Project |
|---|---|
| Alis.Core.Aspect.Data.Test | Alis.Core.Aspect.Data |
| Alis.Core.Aspect.Fluent.Test | Alis.Core.Aspect.Fluent |
| Alis.Core.Aspect.Logging.Test | Alis.Core.Aspect.Logging |
| Alis.Core.Aspect.Math.Test | Alis.Core.Aspect.Math |
| Alis.Core.Aspect.Memory.Test | Alis.Core.Aspect.Memory |
| Alis.Core.Aspect.Time.Test | Alis.Core.Aspect.Time |

### Other
| Test Project | Source Project |
|---|---|
| Alis.Extension.Payment.Stripe.Test | Alis.Extension.Payment.Stripe |
| Alis.Extension.Ads.GoogleAds.Test | Alis.Extension.Ads.GoogleAds |
| Alis.Extension.Language.Dialogue.Test | Alis.Extension.Language.Dialogue |
| Alis.Extension.Language.Translator.Test | Alis.Extension.Language.Translator |
| Alis.Extension.Math.HighSpeedPriorityQueue.Test | Alis.Extension.Math.HighSpeedPriorityQueue |
| Alis.Extension.Thread.Test | Alis.Extension.Thread |
| Alis.Extension.Updater.Test | Alis.Extension.Updater |

## Test Infrastructure

| Component | Technology |
|---|---|
| Test Framework | xUnit |
| Mocking | Moq |
| STA Tests | Xunit.StaFact |
| Code Coverage | coverlet |
| Test Output | TRX format in `.test/<TFM>/` |

## Test Configuration

- `InternalsVisibleTo` attribute auto-added to all projects for test access
- Test configuration in `.config/xunit.runner.json`
- Coverage configuration in `.config/coverlet.runsettings`

## Testing Conventions

- Unit tests preferred over integration tests
- Test projects auto-reference their source project by naming convention
- TDD approach recommended for development
- Test projects excluded from NuGet packaging

## Missing Test Areas

- Sample projects lack dedicated tests
- Benchmark project has no test project
- Generator projects are not directly tested

## Related

- [[Tests Index]]
- [[Testing Checkpoint]]
- [[Repository Overview]]
