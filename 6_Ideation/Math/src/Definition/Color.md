# Color Struct

## Description

The `Color` struct represents a color in RGBA color space. Each color component is represented as a byte, with values ranging from 0 to 255.

## Properties

- `R`: The red component of the color.
- `G`: The green component of the color.
- `B`: The blue component of the color.
- `A`: The alpha (transparency) component of the color.

## Constructors

- `Color(byte r, byte g, byte b, byte a)`: Initializes a new instance of the `Color` struct with the specified red, green, blue, and alpha values.
- `Color(int r, int g, int b, int a)`: Initializes a new instance of the `Color` struct with the specified red, green, blue, and alpha values. The integer values are cast to bytes.

## Static Properties

- `Black`: Represents the color black. This property is read-only.
- `Red`: Represents the color red. This property is read-only.

## Examples

Creating a new `Color` instance:

```csharp
Color color = new Color(255, 128, 64, 32);