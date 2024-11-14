# AssetManager Class

The `AssetManager` class is a static class that provides a method to find assets in your application.

## Methods

- `Find(string assetName)`: Finds the asset name in the "assets" folder and its subdirectories.

### Find Method

The `Find` method takes a string parameter `assetName` and returns a string.

#### Parameters

- `assetName`: The name of the asset to find. This parameter cannot be null, empty, contain invalid characters, or lack
  an extension.

#### Returns

The full path of the asset if found; otherwise, an empty string.

#### Exceptions

- `ArgumentNullException`: Thrown when the `assetName` is null.
- `ArgumentException`: Thrown when the `assetName` is empty, contains invalid characters, or lacks an extension.
- `InvalidOperationException`: Thrown when multiple files with the same name are found.

## Usage

The `AssetManager` class is typically used to find the path of an asset in the "Assets" directory or its subdirectories.
Here is an example of how to use the `Find` method:

```csharp
string assetName = "example.txt";
string assetPath = AssetManager.Find(assetName);
```