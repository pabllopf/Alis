# AssetManager Class

The `AssetManager` class is a static class that provides methods to manage and find assets in your application.

## Properties

- `AssetPath`: A string that represents the path to the "Assets" directory.

## Methods

- `Find(string assetName)`: Finds the asset name in the "assets" folder and its subdirectories.

### Find Method

The `Find` method takes a string parameter `assetName` and returns a string.

#### Parameters

- `assetName`: The name of the asset to find. This parameter cannot be null or contain invalid characters.

#### Returns

The full path of the asset if found; otherwise, an empty string.

#### Exceptions

- `ArgumentNullException`: Thrown when the `assetName` is null.
- `ArgumentException`: Thrown when the `assetName` is empty or contains invalid characters.
- `InvalidOperationException`: Thrown when multiple files with the same name are found.

## Usage

The `AssetManager` class is typically used to find the path of an asset in the "Assets" directory or its subdirectories.
Here is an example of how to use the `Find` method:

```csharp
string assetName = "example.txt";
string assetPath = AssetManager.Find(assetName);
```