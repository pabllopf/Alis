# 🚀 Quick Start

Alis is a free, open-source, and cross-platform project that currently supports Windows, macOS, Linux, iOS, and Android.
In this section, you'll find a brief introduction to the project, instructions for installation, and some examples to
help you get started.

## 📥 Installation

To import Alis into your project, simply add the following using statement to your code:

```csharp
using Alis;
```

If you want to use the NuGet repository, you can install it with the following command:

```bash
dotnet add package Alis
```

Alternatively, you can use the GitHub repository to install Alis:

```bash
dotnet add package Alis --source "https://nuget.pkg.github.com/pabllopf/index.json" --source "https://api.nuget.org/v3/index.json"
```

## 🚀 Getting Started

To use Alis for the first time, simply create a new instance of `VideoGame` using the `Builder` method and call
the `Run` method:

```csharp
VideoGame.Builder().Run();
```

## 🎮 Example

Here's a simple example to get you started:

```csharp
using Alis;

class Program
{
    static void Main(string[] args)
    {
        VideoGame game = VideoGame.Builder()
                                .WithPlayer("Player 1")
                                .WithLevel(1)
                                .WithDifficulty(Difficulty.Easy)
                                .Build();

        game.Run();
    }
}
```

In this example, we create a new `VideoGame` instance with the player's name, the starting level, and the game
difficulty. Finally, we call the `Run` method to start the game.

## 📝 Note

Please note that Alis is a community-driven project, and we welcome contributions from anyone. If you have any questions
or would like to get involved in the project, please refer to the [Contributing](#-contributing) section below.

## 🔧 Changes to this Section

We reserve the right to modify this section at any time. If we make significant changes, we will notify you by email or
through a notification on our website.
