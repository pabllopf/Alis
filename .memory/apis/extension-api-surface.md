---
title: Extension API Surface
tags:
  - api
  - extensions
  - surface
status: Draft
license: GPLv3
---

# Extension API Surface

## Network Extension

```csharp
// Server
var server = WebSocketServerFactory.Create(port);
server.OnMessage += (clientId, message) => { };
server.Start();

// Client
var client = WebSocketClientFactory.Create(url);
client.OnMessage += (message) => { };
client.Connect();
```

## Security Extension

```csharp
var secureString = new SecureString("sensitive data");
var secureRandom = new SecureRandom();
var encrypted = SecureByte.Encrypt(data, key);
```

## Graphics Extensions

```csharp
// SDL2 Window
var window = new SdlWindow(title, width, height);

// SFML Window
var window = new SfmlWindow(title, width, height);

// GLFW Window
var window = new GlfwWindow(title, width, height);

// ImGui UI
ImGui.BeginWindow("Debug");
ImGui.Text("FPS: " + fps);
ImGui.EndWindow();
```

## Cloud Extensions

```csharp
// Google Drive
var drive = new GoogleDriveCloudManager(credentials);
await drive.UploadFileAsync("file.txt");

// Dropbox
var dropbox = new DropBoxCloudManager(token);
await dropbox.DownloadFileAsync("file.txt");
```

## Payment Extension

```csharp
var stripe = new StripeGatewayClient(apiKey);
var session = await stripe.CreateCheckoutSessionAsync(priceId);
```

## Related

- [[Engine API Surface]]
- [[Engine Services Overview]]
- [[APIs Index]]
- [[Projects Index]]
