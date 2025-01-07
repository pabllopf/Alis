![Alis Banner](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/banner/Alis_Banner_970x250.png)

![GitHub Stars](https://img.shields.io/github/stars/pabllopf/alis?style=social)
[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=sqale_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=security_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=bugs)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=reliability_rating)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=duplicated_lines_density)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=pabllopf_Alis&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=pabllopf_Alis)
![GitHub issues](https://img.shields.io/github/issues/pabllopf/alis?label=Open%20Tickets&color=green)
[![License](https://img.shields.io/badge/license-GPL%20v3.0-blue)](https://github.com/pabllopf/Alis/blob/main/LICENSE)
[![Web](https://img.shields.io/website?down_color=red&down_message=failed&up_color=blue&up_message=active&url=https%3A%2F%2Fpabllopf.github.io%2FAlis.Web%2F)](https://pabllopf.github.io/Alis.Web/index.html)
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.me/pabllopf)

> Develop the video games of your dreams 💯 free!! on Windows, MacOS, Linux, Android(soon), IOS(soon).

## 📚 Alis.Core.Aspect.Memory
- [Modular Design](#-modular-design)
- [Description](#-description)
- [Getting Started](#-getting-started)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

### ⚙️ Modular Design

> All modules within the Alis framework, including `Alis.Core.Aspect.Memory`, are fully independent and can be used separately. While the primary focus of Alis is game development, these modules are designed to be versatile and can be integrated into other types of applications or environments where memory management or data validation is required.

---

### 🖥️ Platform Compatibility

> The Alis framework, including `Alis.Core.Aspect.Memory`, is designed to support a wide range of platforms, ensuring flexibility and adaptability for developers. Each module is optimized for seamless integration across the following architectures and operating systems:

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
--- 

## 📖 Description

`Alis.Core.Aspect.Memory` is a module within the Alis framework that provides tools for memory management and validation, ensuring that values meet specified constraints. It includes a set of attributes and a validation system to ensure that data values adhere to important rules, such as non-zero or non-null values.

### Features:
- **Data Validation**: Use attributes like `[IsNotZero]` and `[IsNotNull]` to ensure values meet specific conditions.
- **Flexible Validation**: Validator system that checks values before they are used, preventing runtime errors.
- **Main Classes**:
    - `Validator`: Validates data according to rules such as non-zero or non-null.
    - `NotZeroException`: Thrown when a value is zero when it shouldn't be.

---

## 🚀 Getting Started
To start using `Alis.Core.Aspect.Memory`, simply install the package:

```bash
dotnet add package Alis.Core.Aspect.Memory
```

This module is ideal for applications where data integrity is crucial, and you need to ensure that certain values adhere to specific constraints.

### Basic Usage Example:

```csharp
using Alis.Core.Aspect.Memory;
using System;

public static class Program
{
    /// <summary>
    ///     Gets or sets the value of the non zero value
    /// </summary>
    [IsNotZero] private static int _nonZeroValue;

    /// <summary>
    ///     Gets or sets the value of the non zero value
    /// </summary>
    private static int _nonZeroValuev2;

    /// <summary>
    ///     Gets or sets the value of the sample
    /// </summary>
    [IsNotZero]
    private static int Sample { get; set; }

    /// <summary>
    ///     Samples the method using the specified value
    /// </summary>
    /// <param name="value">The value</param>
    public static void SampleMethod([IsNotZero, IsNotNull] int value)
    {
        Validator.Validate(value, nameof(value));
        Console.WriteLine("The value of value is " + value);
    }

    /// <summary>
    ///     Main the args
    /// </summary>
    /// <param name="args">The args</param>
    public static void Main(string[] args)
    {
        try
        {
            Sample = 0;
            Validator.Validate(Sample, nameof(Sample));
        }
        catch (NotZeroException e)
        {
            Console.WriteLine(e);
        }

        try
        {
            SampleMethod(0);
        }
        catch (NotZeroException e)
        {
            Console.WriteLine(e);
        }

        _nonZeroValuev2 = 0;
        Validator.Validate(_nonZeroValuev2, nameof(_nonZeroValuev2));

        try
        {
            _nonZeroValue = 0;
            Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));
        }
        catch (NotZeroException ex)
        {
            Console.WriteLine(ex);
        }

        try
        {
            _nonZeroValue = 5;
            Validator.Validate(_nonZeroValue, nameof(_nonZeroValue));
            Console.WriteLine("NonZeroValue has been successfully set to " + _nonZeroValue);
        }
        catch (NotZeroException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
```

---

## 🛡️ License

The ALIS framework is released under the [GNU General Public License v3 (GPL-3.0)](https://github.com/pabllopf/Alis/blob/master/license.md), ensuring your freedom to use, modify, and distribute the framework.

[![License](https://raw.githubusercontent.com/pabllopf/Alis/master/docs/licence/License.png)](https://github.com/pabllopf/Alis/blob/master/license.md)

### Key License Points

- **Complete Freedom for Developers**:  
  Any software created with the ALIS framework is **free** to use, modify, and distribute.

- **Source Code Availability**:  
  If you modify the ALIS framework, you must make the source code publicly available under the GPL-3.0 license.

- **Monetization**:  
  You are free to monetize any project developed using ALIS without any royalties.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/master/license.md)

---

## Contributor Guide

We welcome contributions to the project! Please check our [Code of Conduct](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md) for guidelines on how to contribute respectfully.

[![](https://img.shields.io/badge/Read%20More--blue)](https://github.com/pabllopf/Alis/blob/main/code_of_conduct.md)

---

## Authors

<!-- readme: pabllopf -start -->
| [![Pablo Perdomo Falcón](https://avatars.githubusercontent.com/u/48176121?v=4&s=75)](https://github.com/pabllopf) |
|:--------------------------------------------------------------------------------------------------:|
| **[Pablo Perdomo Falcón](https://github.com/pabllopf)**                                             |
<!-- readme: pabllopf -end -->

## Collaborators

<!-- readme: collaborators -start -->
| [![Raúl Lozano Ponce](https://avatars.githubusercontent.com/u/43152062?v=4)](https://github.com/RaulLozanoPonce)  | [![Juan Ángel Trujillo Jiménez](https://avatars.githubusercontent.com/u/45520663?v=4)](https://github.com/cannt)  | [![Pablo Perdomo Falcón](https://avatars.githubusercontent.com/u/48176121?v=4)](https://github.com/pabllopf)  | [![Christian García](https://avatars.githubusercontent.com/u/55676590?v=4)](https://github.com/Chgv99)  | [![RicardoVillarta](https://avatars.githubusercontent.com/u/62963416?v=4)](https://github.com/RicardoVillarta)  |
|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|
| **[Raúl Lozano Ponce](https://github.com/RaulLozanoPonce)**                                        | **[Juan Ángel Trujillo Jiménez](https://github.com/cannt)**                                         | **[Pablo Perdomo Falcón](https://github.com/pabllopf)**                                             | **[Christian García](https://github.com/Chgv99)**                                                  | **[RicardoVillarta](https://github.com/RicardoVillarta)**                                           |

| [![Gabriel](https://avatars.githubusercontent.com/u/75950686?v=4)](https://github.com/GabrielRT01)  | [![Pedro D.GR](https://avatars.githubusercontent.com/u/82670532?v=4)](https://github.com/SPEEDCROW98)  | [![Claudia2000pf](https://avatars.githubusercontent.com/u/82757764?v=4)](https://github.com/Claudia2000pf)  | [![Carlos](https://avatars.githubusercontent.com/u/82760316?v=4)](https://github.com/suarez0965)  | [![Roser Almenar](https://avatars.githubusercontent.com/u/118014440?v=4)](https://github.com/roseralmenar)  |
|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|:--------------------------------------------------------------------------------------------------:|
| **[Gabriel](https://github.com/GabrielRT01)**                                                      | **[Pedro D.GR](https://github.com/SPEEDCROW98)**                                                  | **[Claudia2000pf](https://github.com/Claudia2000pf)**                                              | **[Carlos](https://github.com/suarez0965)**                                                       | **[Roser Almenar](https://github.com/roseralmenar)**                                               |
<!-- readme: collaborators -end -->
