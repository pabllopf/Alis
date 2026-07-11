---
title: Technology Stack
tags:
  - context
  - technology
  - platform
status: Draft
license: GPLv3
---

# Technology Stack

## Languages

| Language | Purpose |
|---|---|
| C# | Primary development language |
| MSBuild XML | Build system configuration |
| YAML | CI/CD configuration |
| Shell/Bash | Build scripts |

## .NET Framework Targets

| Category | Frameworks |
|---|---|
| Modern | net10.0, net9.0, net8.0, net7.0, net6.0, net5.0 |
| Legacy .NET Core | netcoreapp3.1, netcoreapp3.0, netcoreapp2.2, netcoreapp2.1, netcoreapp2.0 |
| .NET Standard | netstandard2.1, netstandard2.0 |
| .NET Framework | net481, net48, net472, net471, net461 |

## Build System

| Component | Technology |
|---|---|
| SDK | .NET SDK (global.json pinned) |
| Build Engine | MSBuild |
| Solution Format | .slnx (new VS2022+ format) + legacy .sln |
| Property Sheets | Custom .props/.targets in `.config/` |
| Package Tool | NuGet (NuGet.Config) |

## External NuGet Dependencies

| Package | Version | Project |
|---|---|---|
| Stripe.net | 49.2.0 | Alis.Extension.Payment.Stripe |
| Google.Ads.Common | 9.5.3 | Alis.Extension.Ads.GoogleAds |
| Google.Apis.Drive.v3 | 1.68.0.3601 | Alis.Extension.Cloud.GoogleDrive |
| Dropbox.Api | 7.0.0 | Alis.Extension.Cloud.DropBox |

## Native Dependencies

| Library | Used By | Platform |
|---|---|---|
| SDL2 | Alis.Extension.Graphic.Sdl2 | All |
| SDL2_image | Alis.Extension.Graphic.Sdl2 | All |
| SDL2_ttf | Alis.Extension.Graphic.Sdl2 | All |
| SFML | Alis.Extension.Graphic.Sfml | All |
| GLFW | Alis.Extension.Graphic.Glfw | All |
| FFmpeg | Alis.Extension.Media.FFmpeg | All |
| Dear ImGui | Alis.Extension.Graphic.Ui | All |

## Testing Framework

| Component | Technology |
|---|---|
| Test Framework | xUnit |
| Mocking | Moq |
| STA Fact | Xunit.StaFact |
| Code Coverage | coverlet |
| Test Output | TRX format in `.test/` directory |

## CI/CD

| Component | Service |
|---|---|
| Source Control | GitHub |
| CI Runner | GitHub Actions |
| Analysis | SonarQube (`.config/SonarQube.Analysis.xml`) |

## Related

- [[Repository Overview]]
- [[Architecture Overview]]
- [[Build System]]
