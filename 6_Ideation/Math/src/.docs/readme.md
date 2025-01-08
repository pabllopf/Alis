# Alis.Core.Aspect.Math

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

---

## 📚 Table of Contents
- [Modular Design](#-modular-design)
- [Description](#-description)
- [Getting Started](#-getting-started)
- [License](#-license)
- [Contributor Guide](#-contributor-guide)
- [Authors](#-authors)
- [Collaborators](#-collaborators)

---

### ⚙️ Modular Design

> All modules within the Alis framework, including `Alis.Core.Aspect.Math`, are fully independent and can be used separately. While the primary focus of Alis is game development, these modules are versatile and can be integrated into other types of applications requiring advanced mathematical capabilities.

---

## 📖 Description

`Alis.Core.Aspect.Math` is a powerful math module within the Alis framework. It provides developers with advanced mathematical tools and utilities designed to simplify common calculations and handle complex mathematical operations.

### Features:
- **Linear Algebra Support**: Includes matrices, vectors, and operations for 2D and 3D spaces.
- **Advanced Math Functions**: Trigonometry, interpolation, and more.
---

## 🚀 Getting Started

To start using `Alis.Core.Aspect.Math`, simply install the package:

```bash
dotnet add package Alis.Core.Aspect.Math
```

This module is ideal for applications that need efficient and robust mathematical tools, particularly in game development.

### Basic Usage Example:

```csharp
using Alis.Core.Aspect.Math;

public static class Program
{
    public static void Main(string[] args)
    {
        // Vector operations
        Vector2F vec1 = new Vector2F(1, 2);
        Vector2F vec2 = new Vector2F(3, 4);
        Vector2F result = vec1 + vec2;

        Console.WriteLine($"Vector addition: {result}");
        
        Matrix4X4 matrix = Matrix4X4.Identity;
        Matrix4X4 translated = matrix * Matrix4X4.CreateTranslation(new Vector3F(1, 2, 3));

        Console.WriteLine($"Matrix after translation: {translated}");
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

---

## Authors

<!-- readme: pabllopf -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/pabllopf">
                    <img src="https://avatars.githubusercontent.com/u/48176121?v=4" width="75;" alt="pabllopf"/>
                    <br />
                    <sub><b>Pablo Perdomo Falcón</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: pabllopf -end -->

## Collaborators

<!-- readme: collaborators -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/RaulLozanoPonce">
                    <img src="https://avatars.githubusercontent.com/u/43152062?v=4" width="75;" alt="RaulLozanoPonce"/>
                    <br />
                    <sub><b>Raúl Lozano Ponce</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/cannt">
                    <img src="https://avatars.githubusercontent.com/u/45520663?v=4" width="75;" alt="cannt"/>
                    <br />
                    <sub><b>Juan Ángel Trujillo Jiménez</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/Chgv99">
                    <img src="https://avatars.githubusercontent.com/u/55676590?v=4" width="75;" alt="Chgv99"/>
                    <br />
                    <sub><b>Christian García</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/RicardoVillarta">
                    <img src="https://avatars.githubusercontent.com/u/62963416?v=4" width="75;" alt="RicardoVillarta"/>
                    <br />
                    <sub><b>RicardoVillarta</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/GabrielRT01">
                    <img src="https://avatars.githubusercontent.com/u/75950686?v=4" width="75;" alt="GabrielRT01"/>
                    <br />
                    <sub><b>Gabriel</b></sub>
                </a>
            </td>
		</tr>
		<tr>
            <td align="center">
                <a href="https://github.com/SPEEDCROW98">
                    <img src="https://avatars.githubusercontent.com/u/82670532?v=4" width="75;" alt="SPEEDCROW98"/>
                    <br />
                    <sub><b>Pedro D.GR</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/Claudia2000pf">
                    <img src="https://avatars.githubusercontent.com/u/82757764?v=4" width="75;" alt="Claudia2000pf"/>
                    <br />
                    <sub><b>Claudia2000pf</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/suarez0965">
                    <img src="https://avatars.githubusercontent.com/u/82760316?v=4" width="75;" alt="suarez0965"/>
                    <br />
                    <sub><b>Carlos</b></sub>
                </a>
            </td>
            <td align="center">
                <a href="https://github.com/roseralmenar">
                    <img src="https://avatars.githubusercontent.com/u/118014440?v=4" width="75;" alt="roseralmenar"/>
                    <br />
                    <sub><b>Roser Almenar</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators -end -->
