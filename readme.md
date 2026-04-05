[![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/banner/Alis_Banner_970x250.bmp)](https://pabllopf.github.io/Alis/index.html)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)
![GitHub issues](https://img.shields.io/github/issues/pabllopf/alis?label=Open%20Tickets&color=green)
[![License](https://img.shields.io/badge/license-GPL%20v3.0-blue)](https://github.com/pabllopf/Alis/blob/main/LICENSE)
[![Web](https://img.shields.io/website?down_color=red&down_message=failed&up_color=blue&up_message=active&url=https%3A%2F%2Fpabllopf.github.io%2FAlis.Web%2F)](https://pabllopf.github.io/Alis.Web/index.html)
![Nuget](https://img.shields.io/nuget/v/alis?label=latest%20version&color=green)
![Total downloads](https://img.shields.io/badge/downloads-+1M-green)
![GitHub Stars](https://img.shields.io/github/stars/pabllopf/alis?style=social)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/pabllopf)
![Commit activity](https://img.shields.io/github/commit-activity/m/pabllopf/Alis)

> Develop the video games of your dreams 💯 free!! on Windows, MacOS, Linux, WEB, Android(soon), IOS(soon).

## 📚 Table of Contents

- [Description](#-description)
- [Getting Started](#-getting-started)
- [Features](#features)
- [NuGet Packages Overview](#-nuget-packages-overview)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

## 📖 Description

Alis is a cross-platform framework designed to help developers create video games effortlessly. It includes a wide range
of packages tailored for different functionalities like graphics, physics, networking, audio, and extensions for cloud
integrations, AI, and more.

### Features:

- **Cross-Platform**: Compatible with Windows, macOS, Linux, WEB,  and planned support for Android and iOS.
- **Modular**: Each feature is available as a separate NuGet package.
- **Open Source**: Licensed under GNU GPL v3.0 (ALL FREE!).
- **Powerful Extensions**: Integrate easily with Google Ads, Google Drive, FFmpeg, and more.

---

### ⚙️ Modular Design

> All modules within the Alis framework are fully independent and can be used separately. While the primary focus of
> Alis is game development, these modules are versatile and can be integrated into other types of applications requiring
> data management capabilities.

---

### 🖥️ Platform Compatibility

> The Alis framework is designed to support a wide range of platforms, ensuring flexibility and adaptability for
> developers. Each module is optimized for seamless integration across the following architectures and operating
> systems:

#### Supported Platforms:

- **Windows**
    - `win-x64`
    - `win-x86`
    - `win-arm64`
- **Linux**
    - `linux-x64`
    - `linux-musl-x64`
    - `linux-arm`
    - `linux-arm64`
    - `linux-musl-arm`
    - `linux-musl-arm64`
- **macOS**
    - `osx-x64`
    - `osx-arm64`
- **Web**
    - `browser-wasm`

- **Mobile (Planned)**
    - `Android (soon)`
    - `iOS (soon)`

--- 

### 🎮 Platform Compatibility

`Alis` is designed to support a wide range of frameworks, ensuring maximum flexibility across different platforms and
environments. Whether you're working with legacy systems or the latest .NET versions, this module has got you covered!

#### Supported Frameworks:

| **Framework**      | **Version(s)**                                                                      |
|--------------------|-------------------------------------------------------------------------------------|
| **.NET Core**      | `netcoreapp2.0`, `netcoreapp2.1`, `netcoreapp2.2`, `netcoreapp3.0`, `netcoreapp3.1` |
| **.NET 5 & Above** | `net5.0`, `net6.0`, `net7.0`, `net8.0`, `net9.0`, `net10.0`                          |
| **.NET Standard**  | `netstandard2.0`, `netstandard2.1`                                                  |
| **.NET Framework** | `net471`, `net472`, `net48`, `net481`                                               |

---

## 🚀 Getting Started

To start using Alis, simply install the core package from NuGet:

```bash
dotnet add package Alis
```

### 🛠️ Example Usage

```csharp
using Alis;
using Alis.Core.Ecs.System;

class Program
{
    static void Main()
    {
        VideoGame.Create().Run();
    }
}
```

---

## 📦 NuGet Packages Overview

The ALIS framework is built with a modular architecture to provide flexibility, scalability, and performance
optimization for game development. Below, you’ll find an explanation of the structure and purpose of the different
packages available.

### Core Package

If your primary goal is to develop a game, you should start with the **ALIS** package. This is the main package of the
framework and includes the fundamental tools required to build games effectively. It acts as the foundation, and in most
cases, it’s all you need to get started.

### Modular Architecture

The framework is divided into multiple packages to ensure clarity and scalability:

- **Clear Responsibility**: Each package handles a specific domain, such as graphics, physics, or ECS (Entity Component
  System), making the framework easy to maintain and extend.
- **Customizability**: Only include the packages relevant to your game, keeping your project lightweight and performant.
- **Reusability**: Packages can be reused across different projects without relying on unnecessary dependencies.

This structure allows developers to tailor the framework to their specific needs, focusing on essential features without
being burdened by unused functionality.

### Extensions

The framework also provides a variety of **extensions**, which are optional add-ons that enhance the core functionality
of the framework. These are designed to cover advanced or specific use cases. For example:

- **Graphic Extensions** like OpenGL or SDL2 allow for advanced rendering capabilities.
- **Cloud Extensions** enable integration with services such as Dropbox or Google Drive.
- **Language and Audio Extensions** add dialogue systems, translators, or enhanced audio features.
- **Physics, Math, and Networking Extensions** allow deeper customization and control over game mechanics.

By including only the extensions you need, you can optimize your project and add functionality tailored to your game’s
requirements.


| Package | Version | Downloads                                                                                                    | Quality Metrics                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            | Description |
| ------- | ------- |--------------------------------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------| ----------- |
| [**Alis**](https://www.nuget.org/packages/Alis) | ![Nuget](https://img.shields.io/nuget/v/alis?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/Alis?label=nuget&color=green)                                       | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis)                                                                                                                                                                                                                                     | Full game development bundle that brings together the main ALIS runtime modules and entry points. |
|  |  |                                                                                                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |  |
| [**Alis.Core**](https://www.nuget.org/packages/Alis.Core) | ![Nuget](https://img.shields.io/nuget/v/alis.core?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core?label=nuget&color=green)                                  | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core)                                                                                                                                                                                                       | Shared runtime foundations used across ALIS, including common abstractions, services, and utilities. |
| [**Alis.Core.Ecs**](https://www.nuget.org/packages/Alis.Core.Ecs) | ![Nuget](https://img.shields.io/nuget/v/alis.core.ecs?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.ecs?label=nuget&color=green)                              | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-ecs&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-ecs)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-ecs&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-ecs)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-ecs&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-ecs)                                                                                                                                                                               | Entity Component System architecture for high-performance composition and update of game objects. |
| [**Alis.Core.Physic**](https://www.nuget.org/packages/Alis.Core.Physic) | ![Nuget](https://img.shields.io/nuget/v/alis.core.physic?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.physic?label=nuget&color=green)                           | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-physic&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-physic)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-physic&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-physic)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-physic&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-physic)                                                                                                                                                             | Physics primitives and simulation helpers for collisions, movement, and world interaction rules. |
| [**Alis.Core.Audio**](https://www.nuget.org/packages/Alis.Core.Audio) | ![Nuget](https://img.shields.io/nuget/v/alis.core.audio?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.audio?label=nuget&color=green)                            | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-audio&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-audio)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-audio&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-audio)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-audio&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-audio)                                                                                                                                                                   | Audio abstractions for playback, routing, and integration of music and sound effects. |
| [**Alis.Core.Graphic**](https://www.nuget.org/packages/Alis.Core.Graphic) | ![Nuget](https://img.shields.io/nuget/v/alis.core.graphic?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.graphic?label=nuget&color=green)                          | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-graphic&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-graphic)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-graphic&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-graphic)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-graphic&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-graphic)                                                                                                                                                       | Rendering core with graphics abstractions and pipeline components to draw game scenes. |
|  |  |                                                                                                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |  |
| [**Alis.Core.Aspect**](https://www.nuget.org/packages/Alis.Core.Aspect) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect?label=nuget&color=green)                           | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect)                                                                                                                                                             | Aspect-oriented foundation for implementing reusable cross-cutting behavior. |
| [**Alis.Core.Aspect.Data**](https://www.nuget.org/packages/Alis.Core.Aspect.Data) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.data?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.data?label=nuget&color=green)                      | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-data&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-data)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-data&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-data)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-data&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-data)                                                                                                                               | Data-focused aspects that centralize validation, transformation, and data access concerns. |
| [**Alis.Core.Aspect.Fluent**](https://www.nuget.org/packages/Alis.Core.Aspect.Fluent) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.fluent?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.fluent?label=nuget&color=green)                    | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-fluent&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-fluent)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-fluent&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-fluent)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-fluent&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-fluent)                                                                                                                   | Fluent API for configuring and composing aspects with readable, chainable syntax. |
| [**Alis.Core.Aspect.Logging**](https://www.nuget.org/packages/Alis.Core.Aspect.Logging) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.logging?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.logging?label=nuget&color=green)                   | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-logging&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-logging)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-logging&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-logging)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-logging&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-logging)                                                                                                             | Logging aspects for tracing, diagnostics, and consistent observability across modules. |
| [**Alis.Core.Aspect.Math**](https://www.nuget.org/packages/Alis.Core.Aspect.Math) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.math?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.math?label=nuget&color=green)                      | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-math&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-math)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-math&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-math)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-math&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-math)                                                                                                                               | Aspect helpers for math-intensive workflows, calculations, and numeric consistency checks. |
| [**Alis.Core.Aspect.Memory**](https://www.nuget.org/packages/Alis.Core.Aspect.Memory) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.memory?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.memory?label=nuget&color=green)                    | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-memory&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-memory)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-memory&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-memory)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-memory&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-memory)                                                                                                                   | Memory-oriented aspects to monitor allocations and improve runtime performance behavior. |
| [**Alis.Core.Aspect.Time**](https://www.nuget.org/packages/Alis.Core.Aspect.Time) | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.time?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.time?label=nuget&color=green)                      | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-time&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-time)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-time&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-time)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-core-aspect-time&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-core-aspect-time)                                                                                                                               | Timing and profiling aspects for latency tracking, benchmarking, and execution monitoring. |
|  |  |                                                                                                              |                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |  |
| [**Alis.Extension.Ads.GoogleAds**](https://www.nuget.org/packages/Alis.Extension.Ads.GoogleAds) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.ads.googleads?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.ads.googleads?label=nuget&color=green)               | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-ads-googleads&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-ads-googleads)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-ads-googleads&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-ads-googleads)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-ads-googleads&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-ads-googleads)                                                                                     | Google Ads integration for ad monetization workflows in games and apps. |
| [**Alis.Extension.Cloud.DropBox**](https://www.nuget.org/packages/Alis.Extension.Cloud.DropBox) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.dropbox?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.dropbox?label=nuget&color=green)               | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-dropbox&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-dropbox)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-dropbox&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-dropbox)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-dropbox&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-dropbox)                                                                                     | Dropbox connector for cloud file sync and remote asset access. |
| [**Alis.Extension.Cloud.GoogleDrive**](https://www.nuget.org/packages/Alis.Extension.Cloud.GoogleDrive) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.googledrive?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.googledrive?label=nuget&color=green)           | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-googledrive&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-googledrive)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-googledrive&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-googledrive)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-cloud-googledrive&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-cloud-googledrive)                                                             | Google Drive adapter for cloud persistence and content sharing scenarios. |
| [**Alis.Extension.Profile**](https://www.nuget.org/packages/Alis.Extension.Profile) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.profile?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.profile?label=nuget&color=green)                     | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-profile&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-profile)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-profile&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-profile)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-profile&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-profile)                                                                                                                         | Profile management features for player settings and user-related metadata. |
| [**Alis.Extension.Language.Translator**](https://www.nuget.org/packages/Alis.Extension.Language.Translator) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.translator?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.translator?label=nuget&color=green)         | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-translator&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-translator)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-translator&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-translator)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-translator&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-translator)                                                 | Translation utilities to support multilingual interfaces and localized game text. |
| [**Alis.Extension.Language.Dialogue**](https://www.nuget.org/packages/Alis.Extension.Language.Dialogue) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.dialogue?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.dialogue?label=nuget&color=green)           | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-dialogue&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-dialogue)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-dialogue&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-dialogue)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-language-dialogue&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-language-dialogue)                                                             | Dialogue systems for structured conversations, branching text, and narrative flows. |
| [**Alis.Extension.Payment.Stripe**](https://www.nuget.org/packages/Alis.Extension.Payment.Stripe) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.payment.stripe?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.payment.stripe?label=nuget&color=green)              | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-payment-stripe&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-payment-stripe)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-payment-stripe&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-payment-stripe)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-payment-stripe&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-payment-stripe)                                                                               | Stripe integration for secure payment processing and commerce workflows. |
| [**Alis.Extension.Math.HighSpeedPriorityQueue**](https://www.nuget.org/packages/Alis.Extension.Math.HighSpeedPriorityQueue) | ![Nuget](https://img.shields.io/nuget/v/Alis.Extension.Math.HighSpeedPriorityQueue?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/Alis.Extension.Math.HighSpeedPriorityQueue?label=nuget&color=green) | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-highspeedpriorityqueue&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-highspeedpriorityqueue)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-highspeedpriorityqueue&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-highspeedpriorityqueue)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-highspeedpriorityqueue&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-highspeedpriorityqueue) | High-performance priority queue for scheduling, pathfinding, and order-sensitive tasks. |
| [**Alis.Extension.Math.ProceduralDungeon**](https://www.nuget.org/packages/Alis.Extension.Math.ProceduralDungeon) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.math.proceduraldungeon?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.math.proceduraldungeon?label=nuget&color=green)      | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-proceduraldungeon&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-proceduraldungeon)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-proceduraldungeon&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-proceduraldungeon)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-math-proceduraldungeon&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-math-proceduraldungeon)                               | Procedural dungeon generation toolkit for dynamic level layout creation. |
| [**Alis.Extension.Updater**](https://www.nuget.org/packages/Alis.Extension.Updater) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.updater?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.updater?label=nuget&color=green)                     | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-updater&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-updater)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-updater&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-updater)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-updater&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-updater)                                                                                                                         | Update helper for delivering and applying version upgrades to applications. |
| [**Alis.Extension.Io.FileDialog**](https://www.nuget.org/packages/Alis.Extension.Io.FileDialog) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.io.filedialog?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.io.filedialog?label=nuget&color=green)               | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-io-filedialog&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-io-filedialog)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-io-filedialog&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-io-filedialog)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-io-filedialog&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-io-filedialog)                                                                                     | Native file dialog integration for open/save workflows across platforms. |
| [**Alis.Extension.Graphic.Sdl2**](https://www.nuget.org/packages/Alis.Extension.Graphic.Sdl2) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sdl2?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sdl2?label=nuget&color=green)                | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sdl2&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sdl2)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sdl2&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sdl2)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sdl2&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sdl2)                                                                                           | SDL2 backend adapter for windowing, input handling, and graphics output. |
| [**Alis.Extension.Graphic.Sfml**](https://www.nuget.org/packages/Alis.Extension.Graphic.Sfml) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sfml?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sfml?label=nuget&color=green)                | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sfml&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sfml)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sfml&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sfml)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-sfml&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-sfml)                                                                                           | SFML backend integration for 2D rendering and platform abstraction support. |
| [**Alis.Extension.Graphic.Glfw**](https://www.nuget.org/packages/Alis.Extension.Graphic.Glfw) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.glfw?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.glfw?label=nuget&color=green)                | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-glfw&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-glfw)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-glfw&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-glfw)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-glfw&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-glfw)                                                                                           | GLFW backend for context creation, input processing, and rendering setup. |
| [**Alis.Extension.Graphic.Ui**](https://www.nuget.org/packages/Alis.Extension.Graphic.Ui) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.ui?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.ui?label=nuget&color=green)                  | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-ui&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-ui)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-ui&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-ui)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-graphic-ui&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-graphic-ui)                                                                                                       | UI rendering helpers for menus, overlays, and in-game interface composition. |
| [**Alis.Extension.Network**](https://www.nuget.org/packages/Alis.Extension.Network) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.network?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.network?label=nuget&color=green)                     | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-network&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-network)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-network&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-network)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-network&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-network)                                                                                                                         | Networking utilities for client/server communication and multiplayer features. |
| [**Alis.Extension.Security**](https://www.nuget.org/packages/Alis.Extension.Security) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.security?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.security?label=nuget&color=green)                    | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-security&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-security)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-security&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-security)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-security&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-security)                                                                                                                   | Security helpers for protection, hardening, and safer data handling practices. |
| [**Alis.Extension.Thread**](https://www.nuget.org/packages/Alis.Extension.Thread) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.thread?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.thread?label=nuget&color=green)                      | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-thread&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-thread)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-thread&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-thread)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-thread&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-thread)                                                                                                                               | Threading utilities for concurrency control and background task orchestration. |
| [**Alis.Extension.Media.FFmpeg**](https://www.nuget.org/packages/Alis.Extension.Media.FFmpeg) | ![Nuget](https://img.shields.io/nuget/v/alis.extension.media.ffmpeg?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.media.ffmpeg?label=nuget&color=green)                | [![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-media-ffmpeg&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-media-ffmpeg)<br>[![Reliability](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-media-ffmpeg&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-media-ffmpeg)<br>[![Security](https://sonarcloud.io/api/project_badges/measure?project=pabllopf-official_alis-extension-media-ffmpeg&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf-official_alis-extension-media-ffmpeg)                                                                                           | FFmpeg-based media processing for encoding, decoding, and stream handling workflows. |

> **Note**: For the complete list of packages, visit the [NuGet Gallery](https://www.nuget.org/profiles/pabllopf).

---

## 🛡️ License

The ALIS framework is released under
the [GNU General Public License v3 (GPL-3.0)](https://github.com/pabllopf/Alis/blob/master/license.md), a strong
copyleft license that ensures your freedom to use, modify, and distribute the framework while preserving the same
license terms. Below is an explanation of how the license affects you as a developer:

[![License](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/licence/License.bmp)](https://github.com/pabllopf/Alis/blob/master/license.md)

### Key License Points

- **Complete Freedom for Video Game Developers**:  
  Any video game created with the ALIS framework is **completely free and unrestricted**. You are free to create,
  publish, and distribute your games without any licensing fees or royalties.

- **Source Code Availability**:  
  If you make modifications to the ALIS framework itself or integrate it as part of a larger software project (beyond
  just using it in a video game), you are required to make those changes publicly available under the same GPL-3.0
  license. This ensures the framework remains open and accessible to everyone.

- **No Obligation to Mention**:  
  While it’s not required, it would be greatly appreciated if you mention or credit the ALIS project somewhere in your
  game, such as in the credits or documentation. This is entirely optional and is meant to help grow the ALIS community.

- **Patent Rights**:  
  Contributors to ALIS provide an express grant of patent rights, meaning you’re protected from patent-related legal
  issues when using the framework.

- **Copyright and Notices**:  
  You must preserve copyright notices and license texts when redistributing ALIS, either in its original form or as part
  of a modified version.

### What This Means for Your Games

- **Your Game’s License**:  
  The GPL-3.0 license applies only to the ALIS framework and its modifications. It does not impose restrictions on the
  license of the game you build using ALIS. You are free to license your game however you choose (e.g., proprietary,
  open-source, or public domain).

- **Monetization**:  
  You are free to monetize games created with ALIS, whether by selling them, integrating ads, or any other form of
  commercialization.

> For more details, you can read the full license by clicking the link below:

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/master/license.md)

---



## 🙏 Acknowledgements

ALIS is powered by a combination of open-source and licensed technologies that enable high-performance, cross-platform game development. Licenses for each technology are indicated in the tables below.

---

### 🎮 Game Development & Graphics

| Logo                                                                                 | Technology     | Description                                                                      | License    | Links                                                                       |
|--------------------------------------------------------------------------------------|----------------|----------------------------------------------------------------------------------| ---------- |-----------------------------------------------------------------------------|
| ![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/logos/sdl2.svg)      | **SDL2**       | Cross-platform low-level multimedia layer for graphics, input, and audio.        | Zlib       | [Web](https://www.libsdl.org) • [Repo](https://github.com/libsdl-org/SDL)   |
| ![](https://cdn.simpleicons.org/sfml)                                                | **SFML**       | Modern C++ multimedia framework for graphics, audio, windowing, and networking.  | Zlib       | [Web](https://www.sfml-dev.org) • [Repo](https://github.com/SFML/SFML)      |
| ![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/logos/glfw.svg)      | **GLFW**       | Lightweight framework for OpenGL/Vulkan contexts, window creation, and input.    | Zlib       | [Web](https://www.glfw.org) • [Repo](https://github.com/glfw/glfw)          |
| ![](https://cdn.simpleicons.org/opengl)                                              | **OpenGL**     | Cross-platform API for high-performance real-time 2D and 3D rendering.           | Open       | [Web](https://www.opengl.org)                                               |
| ![](https://cdn.simpleicons.org/vulkan)                                              | **Vulkan**     | Modern explicit graphics and compute API delivering high-efficiency GPU control. | Apache 2.0 | [Web](https://www.vulkan.org)                                               |
| ![](https://cdn.simpleicons.org/opengl)                                              | **OpenGL ES**  | Embedded systems variant of OpenGL optimized for mobile and web platforms.       | Open       | [Web](https://www.khronos.org/opengles/)                                    |
| ![](https://cdn.simpleicons.org/webgl)                                               | **WebGL**      | JavaScript API for GPU-accelerated rendering inside web browsers.                | Open       | [Web](https://www.khronos.org/webgl/)                                       |
| ![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/logos/dearimgui.svg) | **Dear ImGui** | Immediate-mode GUI library for debug tools and in-engine interfaces.             | MIT        | [Repo](https://github.com/ocornut/imgui)                                    |
| ![](https://cdn.simpleicons.org/blender)                                             | **Blender**    | 3D creation suite for modeling, animation, and asset production.                 | GPL        | [Web](https://www.blender.org) • [Repo](https://github.com/blender/blender) |
| ![](https://cdn.simpleicons.org/gimp/black/ffff)                                     | **Gimp**       | 2D creation suite for modeling, animation, and asset production.                 | GPL        | [Web](https://www.gimp.org)                                                 |


---

### 🎧 Media & Audio Technologies

| Logo                                      | Technology   | Description                                                              | License     | Links                                                                              |
| ----------------------------------------- | ------------ | ------------------------------------------------------------------------ | ----------- | ---------------------------------------------------------------------------------- |
| ![](https://cdn.simpleicons.org/ffmpeg)   | **FFmpeg**   | Multimedia framework for encoding, decoding, transcoding, and streaming. | LGPL/GPL    | [Web](https://ffmpeg.org) • [Repo](https://github.com/FFmpeg/FFmpeg)               |
| ![](https://cdn.simpleicons.org/audacity) | **Audacity** | Digital audio editor and recording tool.                                 | GPL         | [Web](https://www.audacityteam.org) • [Repo](https://github.com/audacity/audacity) |

---

### ☁️ Cloud & Online Services

| Logo                                         | Service            | Description                                                                 | License     | Links                                                         |
| -------------------------------------------- |--------------------| --------------------------------------------------------------------------- | ----------- | ------------------------------------------------------------- |
| ![](https://cdn.simpleicons.org/googleads)   | **Google Ads**     | Advertising and monetization platform for user acquisition and analytics.   | Proprietary | [Web](https://ads.google.com)                                 |
| ![](https://cdn.simpleicons.org/googledrive) | **Google Drive**   | Cloud storage service for synchronization and distributed asset management. | Proprietary | [Web](https://drive.google.com)                               |
| ![](https://cdn.simpleicons.org/dropbox)     | **Dropbox**        | Cloud-based file hosting platform for backup and remote synchronization.    | Proprietary | [Web](https://www.dropbox.com)                                |
| ![](https://cdn.simpleicons.org/stripe)      | **Stripe**         | Online payment infrastructure supporting secure global transactions.        | Proprietary | [Web](https://stripe.com) • [Repo](https://github.com/stripe) |
| ![](https://cdn.simpleicons.org/cloudflare)  | **Cloudflare**     | Global CDN and edge security platform for performance and protection.       | Proprietary | [Web](https://www.cloudflare.com)                             |

---

### 🧠 Technology & Ecosystem

| Logo                                                  | Technology             | Description                                                               | License                 | Links                                                                   |
|-------------------------------------------------------| ---------------------- | ------------------------------------------------------------------------- |-------------------------| ----------------------------------------------------------------------- |
| ![](https://cdn.simpleicons.org/dotnet)               | **.NET**               | Cross-platform managed runtime and development framework.                 | MIT                     | [Web](https://dotnet.microsoft.com) • [Repo](https://github.com/dotnet) |
| ![](https://cdn.simpleicons.org/git)                  | **Git**                | Distributed version control system for source code management.            | GPL                     | [Web](https://git-scm.com) • [Repo](https://github.com/git/git)         |
| ![](https://cdn.simpleicons.org/github/black/ffff)               | **GitHub**             | Collaborative development and DevOps platform for hosting projects.       | Proprietary With Open Source Use License             | [Web](https://github.com)                                               |
| ![](https://cdn.simpleicons.org/githubactions)        | **GitHub Actions**     | CI/CD automation platform for build, test, and deployment workflows.      | Proprietary With Open Source Use License             | [Web](https://github.com/features/actions)                              |
| ![](https://cdn.simpleicons.org/nuget)                | **NuGet**              | Package manager for .NET enabling dependency distribution.                | MIT                     | [Web](https://www.nuget.org) • [Repo](https://github.com/NuGet)         |
| ![](https://cdn.simpleicons.org/sonarqubecloud)       | **SonarCloud**         | Cloud platform for continuous code quality and security inspection.       | Proprietary With Open Source Use License        | [Web](https://sonarcloud.io)                                            |
| ![](https://cdn.simpleicons.org/jetbrains/black/ffff) | **JetBrains Rider**    | Advanced cross-platform IDE for .NET and game development workflows.      | Proprietary With Open Source Use License | [Web](https://www.jetbrains.com/rider/)                                 |

## Contributor Guide

Thank you for investing your time in contributing to our project! Any contribution you make will be reflected.
Read our Code of Conduct to keep our community approachable and respectable.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)

### Contributor Covenant Code of Conduct

In the interest of fostering an open and welcoming environment, we as contributors and maintainers pledge to making
participation in our project and our community a harassment-free experience for everyone, regardless of age, body size,
disability, ethnicity, sex characteristics, gender identity and expression, level of experience, education,
socio-economic status, nationality, personal appearance, race, religion, or sexual identity and orientation.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)


## Authors

|                                                                                                                                           | 
|-------------------------------------------------------------------------------------------------------------------------------------------|
| ![](https://avatars.githubusercontent.com/u/48176121?v=4&s=200)**Pablo Perdomo Falcón**([@pabllopf](https://github.com/pabllopf)) | 

---

## Collaborators

| | | | |
|---|---|---|---|
| ![](https://avatars.githubusercontent.com/u/43152062?v=4)**Raúl Lozano Ponce**([@RaulLozanoPonce](https://github.com/RaulLozanoPonce)) | ![](https://avatars.githubusercontent.com/u/45520663?v=4)**Juan Ángel Trujillo Jiménez**([@cannt](https://github.com/cannt)) | ![](https://avatars.githubusercontent.com/u/55676590?v=4)**Christian García**([@Chgv99](https://github.com/Chgv99)) | ![](https://avatars.githubusercontent.com/u/62963416?v=4)**RicardoVillarta**([@RicardoVillarta](https://github.com/RicardoVillarta)) |
| ![](https://avatars.githubusercontent.com/u/75950686?v=4)**Gabriel**([@GabrielRT01](https://github.com/GabrielRT01)) | ![](https://avatars.githubusercontent.com/u/82670532?v=4)**Pedro D.GR**([@SPEEDCROW98](https://github.com/SPEEDCROW98)) | ![](https://avatars.githubusercontent.com/u/82757764?v=4)**Claudia2000pf**([@Claudia2000pf](https://github.com/Claudia2000pf)) | ![](https://avatars.githubusercontent.com/u/82760316?v=4)**Carlos**([@suarez0965](https://github.com/suarez0965)) |




## Stats
<a href="https://info.flagcounter.com/1AeG"><img src="https://s01.flagcounter.com/count2/1AeG/bg_FFFFFF/txt_000000/border_CCCCCC/columns_8/maxflags_250/viewers_0/labels_1/pageviews_1/flags_0/percent_0/" alt="Flag Counter" border="0"></a>

