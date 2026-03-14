[![](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/banner/Alis_Banner_970x250.bmp)](https://pabllopf.github.io/Alis/index.html)

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
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



The following table contains all the available packages, their purpose, and their download statistics.

## 🔷Alis

| Package Name | Version                                                           | Downloads                                                               | Description                          |
| ------------ | ----------------------------------------------------------------- | ----------------------------------------------------------------------- | ------------------------------------ |
| **Alis**     | ![Nuget](https://img.shields.io/nuget/v/alis?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis?label=nuget&color=green) | Main package for the Alis framework. |


## 🔷 Alis.Core

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core)


| Package Name  | Version                                                                | Downloads                                                                    | Description            |
| ------------- | ---------------------------------------------------------------------- | ---------------------------------------------------------------------------- | ---------------------- |
| **Alis.Core** | ![Nuget](https://img.shields.io/nuget/v/alis.core?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core?label=nuget&color=green) | Core library for Alis. |


### 🔷 Alis.Core.Ecs

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-ecs&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-ecs)

| Package Name          | Version                                                                        | Downloads                                                                            | Description           |
| --------------------- | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | --------------------- |
| **Alis.Core.Ecs**     | ![Nuget](https://img.shields.io/nuget/v/alis.core.ecs?label=&color=green)     | ![Nuget](https://img.shields.io/nuget/dt/alis.core.ecs?label=nuget&color=green)     | ECS module.           |


### 🔷 Alis.Core.Physic

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-physic&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-physic)

| Package Name          | Version                                                                        | Downloads                                                                            | Description           |
| --------------------- | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | --------------------- |
| **Alis.Core.Physic**  | ![Nuget](https://img.shields.io/nuget/v/alis.core.physic?label=&color=green)  | ![Nuget](https://img.shields.io/nuget/dt/alis.core.physic?label=nuget&color=green)  | Physics module.       |


### 🔷 Alis.Core.Audio

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-audio&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-audio)

| Package Name          | Version                                                                        | Downloads                                                                            | Description           |
| --------------------- | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | --------------------- |
| **Alis.Core.Audio**   | ![Nuget](https://img.shields.io/nuget/v/alis.core.audio?label=&color=green)   | ![Nuget](https://img.shields.io/nuget/dt/alis.core.audio?label=nuget&color=green)   | Audio module.         |


### 🔷 Alis.Core.Graphic

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-graphic&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-graphic)

| Package Name          | Version                                                                        | Downloads                                                                            | Description           |
| --------------------- | ------------------------------------------------------------------------------ | ------------------------------------------------------------------------------------ | --------------------- |
| **Alis.Core.Graphic** | ![Nuget](https://img.shields.io/nuget/v/alis.core.graphic?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.graphic?label=nuget&color=green) | Graphics core module. |


## 🔷 Alis.Core.Aspect

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect)


| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect**         | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect?label=&color=green)         | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect?label=nuget&color=green)         | Base AOP system.      |


### 🔷 Alis.Core.Aspect.Data

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-data&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-data)

| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Data**    | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.data?label=&color=green)    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.data?label=nuget&color=green)    | Data AOP extensions.  |


### 🔷 Alis.Core.Aspect.Fluent

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-fluent&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-fluent)


| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Fluent**  | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.fluent?label=&color=green)  | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.fluent?label=nuget&color=green)  | Fluent AOP API.       |


### 🔷 Alis.Core.Aspect.Logging

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-logging&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-logging)

| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Logging** | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.logging?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.logging?label=nuget&color=green) | Logging aspects.      |



### 🔷 Alis.Core.Aspect.Math

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-math&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-math)

| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Math**    | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.math?label=&color=green)    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.math?label=nuget&color=green)    | Math AOP utilities.   |



### 🔷 Alis.Core.Aspect.Memory

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-memory&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-memory)  


| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Memory**  | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.memory?label=&color=green)  | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.memory?label=nuget&color=green)  | Memory AOP utilities. |



### 🔷 Alis.Core.Aspect.Time

[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=coverage)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=ncloc)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=code_smells)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=sqale_index)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_alis-core-aspect-time&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_alis-core-aspect-time)


| Package Name                 | Version                                                                               | Downloads                                                                                   | Description           |
| ---------------------------- | ------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------- | --------------------- |
| **Alis.Core.Aspect.Time**    | ![Nuget](https://img.shields.io/nuget/v/alis.core.aspect.time?label=&color=green)    | ![Nuget](https://img.shields.io/nuget/dt/alis.core.aspect.time?label=nuget&color=green)    | Time AOP utilities.   |



## 🔷 Alis.Extensions

| Package Name                                   | Version                                                                                                 | Downloads                                                                                                     | Description                    |
| ---------------------------------------------- | ------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------- | ------------------------------ |
| **Alis.Extension.Ads.GoogleAds**               | ![Nuget](https://img.shields.io/nuget/v/alis.extension.ads.googleads?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.ads.googleads?label=nuget&color=green)               | Google Ads integration.        |
| **Alis.Extension.Cloud.DropBox**               | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.dropbox?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.dropbox?label=nuget&color=green)               | Dropbox integration.           |
| **Alis.Extension.Cloud.GoogleDrive**           | ![Nuget](https://img.shields.io/nuget/v/alis.extension.cloud.googledrive?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.cloud.googledrive?label=nuget&color=green)           | Google Drive integration.      |
| **Alis.Extension.Profile**                     | ![Nuget](https://img.shields.io/nuget/v/alis.extension.profile?label=&color=green)                     | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.profile?label=nuget&color=green)                     | Profile system.                |
| **Alis.Extension.Language.Translator**         | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.translator?label=&color=green)         | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.translator?label=nuget&color=green)         | Translation system.            |
| **Alis.Extension.Language.Dialogue**           | ![Nuget](https://img.shields.io/nuget/v/alis.extension.language.dialogue?label=&color=green)           | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.language.dialogue?label=nuget&color=green)           | Dialogue system.               |
| **Alis.Extension.Payment.Stripe**              | ![Nuget](https://img.shields.io/nuget/v/alis.extension.payment.stripe?label=&color=green)              | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.payment.stripe?label=nuget&color=green)              | Stripe integration.            |
| **Alis.Extension.Math.HighSpeedPriorityQueue** | ![Nuget](https://img.shields.io/nuget/v/Alis.Extension.Math.HighSpeedPriorityQueue?label=&color=green) | ![Nuget](https://img.shields.io/nuget/dt/Alis.Extension.Math.HighSpeedPriorityQueue?label=nuget&color=green) | High speed priority queue.     |
| **Alis.Extension.Math.ProceduralDungeon**      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.math.proceduraldungeon?label=&color=green)      | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.math.proceduraldungeon?label=nuget&color=green)      | Procedural dungeon generation. |
| **Alis.Extension.Updater**                     | ![Nuget](https://img.shields.io/nuget/v/alis.extension.updater?label=&color=green)                     | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.updater?label=nuget&color=green)                     | Updater system.                |
| **Alis.Extension.Io.FileDialog**               | ![Nuget](https://img.shields.io/nuget/v/alis.extension.io.filedialog?label=&color=green)               | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.io.filedialog?label=nuget&color=green)               | File dialog integration.       |
| **Alis.Extension.Graphic.Sdl2**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sdl2?label=&color=green)                | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sdl2?label=nuget&color=green)                | SDL2 graphics backend.         |
| **Alis.Extension.Graphic.Sfml**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.sfml?label=&color=green)                | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.sfml?label=nuget&color=green)                | SFML graphics backend.         |
| **Alis.Extension.Graphic.Glfw**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.glfw?label=&color=green)                | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.glfw?label=nuget&color=green)                | GLFW graphics backend.         |
| **Alis.Extension.Graphic.Ui**                  | ![Nuget](https://img.shields.io/nuget/v/alis.extension.graphic.ui?label=&color=green)                  | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.graphic.ui?label=nuget&color=green)                  | UI graphics helpers.           |
| **Alis.Extension.Network**                     | ![Nuget](https://img.shields.io/nuget/v/alis.extension.network?label=&color=green)                     | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.network?label=nuget&color=green)                     | Networking extension.          |
| **Alis.Extension.Security**                    | ![Nuget](https://img.shields.io/nuget/v/alis.extension.security?label=&color=green)                    | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.security?label=nuget&color=green)                    | Security extension.            |
| **Alis.Extension.Thread**                      | ![Nuget](https://img.shields.io/nuget/v/alis.extension.thread?label=&color=green)                      | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.thread?label=nuget&color=green)                      | Thread utilities.              |
| **Alis.Extension.Media.FFmpeg**                | ![Nuget](https://img.shields.io/nuget/v/alis.extension.media.ffmpeg?label=&color=green)                | ![Nuget](https://img.shields.io/nuget/dt/alis.extension.media.ffmpeg?label=nuget&color=green)                | FFmpeg media processing.       |

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

