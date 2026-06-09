---
title: Alis.Core.Graphic
tags:
  - operation
  - runtime
  - implementation
  - documentation

status: draft
---


## Overview
Graphics rendering library for ALIS game engine using OpenGL. Provides cross-platform rendering, image loading, UI system, and platform-specific OpenGL implementations.

**Author**: Pablo Perdomo Falcón  
**License**: GNU General Public License v3.0  
**Total Source Files**: 206 C# files

## Project Details

| Property | Value |
|---|---|
| **Layer** | 4_Operation |
| **Type** | Library (Graphics Engine) |
| **Framework** | net8.0 (multi-targeted) |
| **Output Type** | Class Library |
| **Namespace** | Alis.Core.Graphic |

## Purpose
Implements a complete graphics rendering system for game development. Provides cross-platform OpenGL rendering, image loading, UI system, and platform-specific implementations for Windows, macOS, Linux, and WebAssembly.

## Architecture

### Core Components

#### Image Class
BMP image loading and management.

**Features:**
- BMP file format support (1, 4, 8, 16, 24, 32 bpp)
- RLE compression support (RLE8, RLE4)
- Palette support for indexed color images
- Resource loading from embedded assets
- RGBA pixel data storage

**Implementation Details:**
```csharp
public class Image
{
    int Width { get; }
    int Height { get; }
    byte[] Data { get; } // RGBA format
    
    static Image Load(string path);
    static Image LoadImageFromResources(string resourceName);
}
```

**BMP Loading:**
- Validates BM header
- Parses BMP header and info block
- Handles compression types: None, RLE8, RLE4, BITFIELDS
- Loads color palette for indexed images
- Converts to RGBA format

#### OpenGL Wrapper (Gl.cs)
Static wrapper for OpenGL 2.1+ functions.

**Key Features:**
- Delegates for all OpenGL functions
- Cross-platform function loading
- Type-safe OpenGL bindings
- Matrix operations support

**Function Categories:**
- **State Management**: `Enable`, `Disable`, `BlendFunc`, `BlendEquation`
- **Drawing**: `Begin`, `End`, `DrawArrays`, `DrawElements`
- **Shaders**: `CreateShader`, `ShaderSource`, `CompileShader`, `LinkProgram`
- **Buffers**: `GenBuffers`, `BindBuffer`, `BufferData`, `DeleteBuffers`
- **Textures**: `GenTextures`, `BindTexture`, `TexImage2D`, `TexParameter`
- **Framebuffers**: `GenFramebuffers`, `BindFramebuffer`, `FramebufferTexture2D`
- **Uniforms**: `Uniform1F`, `Uniform2F`, `Uniform3F`, `Uniform4F`, `UniformMatrix`
- **Viewport**: `Viewport`, `Scissor`, `Viewport`

**Matrix Operations:**
- `Matrix4x4F` - 4x4 matrix operations
- `Translate`, `Rotate`, `Scale` - Transformations
- `Perspective`, `Orthographic` - Projection matrices

#### GLShader
Shader compilation and management.

**Features:**
- Vertex and fragment shader support
- Shader source loading
- Compilation error handling
- Info log retrieval

**Usage:**
```csharp
var vertexShader = Gl.CreateShader(ShaderType.VertexShader);
Gl.ShaderSource(vertexShader, vertexSource);
Gl.CompileShader(vertexShader);

// Check compilation
int success;
Gl.GetShaderIv(vertexShader, GetShaderParameter.CompileStatus, out success);
if (success == 0) {
    string infoLog = Gl.GetShaderInfoLog(vertexShader);
}
```

#### GLShaderProgram
Shader program linking and management.

**Features:**
- Multiple shader attachment
- Program linking
- Uniform location retrieval
- Attribute location retrieval
- Error handling

**Usage:**
```csharp
var program = Gl.CreateProgram();
Gl.AttachShader(program, vertexShader);
Gl.AttachShader(program, fragmentShader);
Gl.LinkProgram(program);

int location = Gl.GetUniformLocation(program, "transform");
Gl.Uniform4F(location, r, g, b, a);
```

### Platform Abstraction

#### INativePlatform
Cross-platform interface for windowing and rendering.

**Platform Implementations:**

**Windows (WinNativePlatform):**
- Win32 API integration
- OpenGL context creation
- Window message handling
- Input management

**macOS (MacNativePlatform):**
- Cocoa API integration
- OpenGL context creation
- Event handling
- Native window management

**Linux (LinuxNativePlatform):**
- X11 integration
- OpenGL context creation
- XEvent handling
- Input management

**WebAssembly (WebAssemblyPlatform):**
- Emscripten integration
- WebGL rendering
- Browser event handling
- WebAssembly memory management

### UI System

#### Font
TrueType font rendering.

**Features:**
- Font file loading
- Glyph atlas generation
- Text rendering
- Font metrics

#### FontManager
Font caching and management.

**Features:**
- Font resource caching
- Multiple font support
- Memory management

### OpenGL Constructs

#### Shader Programs
- `GLShader` - Individual shader compilation
- `GLShaderProgram` - Program linking
- `GLShaderProgramParam` - Uniform/attribute management

#### Drawing Primitives
- `DrawArrays` - Vertex array drawing
- `DrawElements` - Indexed drawing
- `PrimitiveType` - Vertex primitives (Points, Lines, Triangles, etc.)

#### Framebuffers
- `FramebufferAttachment` - Attachment points (Color, Depth, Stencil)
- `FramebufferTarget` - Target binding (Read, Draw)

### OpenGL Enums (28 files)

Complete OpenGL enumeration types:

| Enum Category | Purpose |
|---|---|
| `TextureUnit` | Texture unit binding |
| `ShaderType` | Shader compilation type |
| `PrimitiveType` | Vertex primitives |
| `PixelFormat` | Pixel data format |
| `PixelType` | Pixel data type |
| `TextureTarget` | Texture binding target |
| `TextureParameter` | Texture parameter names |
| `TextureWrapMode` | Texture wrapping mode |
| `TextureMinFilter` | Texture minification filter |
| `TextureMagFilter` | Texture magnification filter |
| `BlendEquation` | Blend equation mode |
| `BlendFunc` | Blend function |
| `EnableCap` | Enable/disable capabilities |
| `BufferTarget` | Buffer binding target |
| `BufferUsage` | Buffer usage hint |
| `AttribMask` | Attribute bit masks |
| `ClearBufferMask` | Clear buffer bits |
| `FramebufferAttachment` | Framebuffer attachment point |
| `FramebufferTarget` | Framebuffer target |
| `FramebufferStatus` | Framebuffer completeness |
| `GetPName` | Get parameter names |
| `GetStringName` | String query names |
| `TextureParameterName` | Texture parameter names |
| `UniformType` | Uniform type |
| `VertexAttribType` | Vertex attribute type |
| `VertexAttribPointer` | Vertex attribute pointer |
| `PixelStoreParam` | Pixel store parameters |
| `InternalFormat` | Internal pixel format |

### OpenGL Delegates (62 files)

Function pointer delegates for OpenGL API.

**Categories:**
- **State Delegates**: `Enable`, `Disable`, `BlendFunc`, `LineWidth`
- **Drawing Delegates**: `Begin`, `End`, `DrawArrays`, `DrawElements`
- **Shader Delegates**: `CreateShader`, `ShaderSource`, `CompileShader`, `DeleteShader`
- **Program Delegates**: `CreateProgram`, `LinkProgram`, `UseProgram`, `AttachShader`
- **Uniform Delegates**: `Uniform1F`, `Uniform2F`, `Uniform3F`, `Uniform4F`, `UniformMatrix`
- **Buffer Delegates**: `GenBuffers`, `BindBuffer`, `BufferData`, `DeleteBuffers`
- **Texture Delegates**: `GenTextures`, `BindTexture`, `TexImage2D`, `TexParameter`
- **Framebuffer Delegates**: `GenFramebuffers`, `BindFramebuffer`, `FramebufferTexture2D`
- **Query Delegates**: `GetIntegerv`, `GetString`, `GetShaderInfoLog`

### Platform-Specific Code

#### Windows Native (Win/Native)
- `Kernel32.cs` - Windows kernel functions
- `User32.cs` - User interface functions
- `Gdi32.cs` - GDI functions
- `Opengl32.cs` - OpenGL functions
- `ClassStyles.cs` - Window class styles
- `WindowStyles.cs` - Window styles
- `WindowExStyles.cs` - Extended window styles
- `Msg.cs` - Window messages
- `PixelFormatFlags.cs` - Pixel format flags

#### macOS Native (Osx/Native)
- `ObjectiveCInterop.cs` - Objective-C interop
- `MacWindow.cs` - Native window handling
- `MacOpenGLContext.cs` - OpenGL context
- `CGPoint.cs` - Core Graphics points
- `NsPoint.cs` - NSWindow points
- `NsRect.cs` - NSWindow rectangles
- `MacConstants.cs` - macOS constants

#### Linux Native (Linux/Native)
- `XEvent.cs` - X11 events
- `XAnyEvent.cs` - Generic X11 events
- `XMotionEvent.cs` - Mouse motion events
- `XButtonEvent.cs` - Button events
- `XKeyEvent.cs` - Keyboard events
- `XConfigureEvent.cs` - Window configure events
- `XFocusChangeEvent.cs` - Focus change events
- `XVisibilityEvent.cs` - Visibility events
- `XClientMessageEvent.cs` - Client messages

#### WebAssembly Native (Web)
- `Emscripten.cs` - Emscripten runtime
- `EGL.cs` - EGL context creation
- `WebAssemblyPlatform.cs` - Web platform
- `WebAssemblyConfiguration.cs` - Web configuration
- `WebAssemblyDisplayManager.cs` - Display handling
- `WebAssemblyInputManager.cs` - Input handling
- `WebAssemblyGameContext.cs` - Game context
- `WebAssemblyGameExamples.cs` - Example games

## Key Components

### Image.cs (25KB)
BMP image loading and management.

### Gl.cs (28KB)
OpenGL function wrapper.

### GLShader.cs (3KB)
Shader compilation.

### GLShaderProgram.cs (14KB)
Shader program management.

### GLShaderProgramParam.cs (8KB)
Shader parameter handling.

### Platform Files (100+ files)
Cross-platform windowing and rendering.

### UI Files (2 files)
Font rendering system.

### Enum Files (28 files)
OpenGL enumeration types.

### Delegate Files (62 files)
OpenGL function delegates.

## Dependencies

### Internal
- [[Alis.Core.Aspect.Memory]] - Memory management
- [[Alis.Core.Aspect.Math.Matrix]] - Matrix operations

### External
- None (pure .NET with P/Invoke)

## Build Configuration

| Property | Value |
|---|---|
| **LangVersion** | 13 |
| **Nullable** | enabled |
| **AllowUnsafeBlocks** | true |
| **Target Frameworks** | 15+ (netstandard2.0–net10.0, net461–net481) |

## Platform Support

| Platform | Status | Implementation |
|---|---|---|
| **Windows** | ✅ Supported | Win32 API + OpenGL |
| **macOS** | ✅ Supported | Cocoa + OpenGL |
| **Linux** | ✅ Supported | X11 + OpenGL |
| **WebAssembly** | ✅ Supported | Emscripten + WebGL |
| **Android** | 🔄 Partial | EGL implementation |

## Rendering Pipeline

1. **Initialization**
   - Platform window creation
   - OpenGL context creation
   - Function pointer loading

2. **Resource Loading**
   - Image loading (BMP)
   - Font loading
   - Shader compilation

3. **Rendering**
   - Clear framebuffer
   - Set viewport
   - Bind shader program
   - Set uniforms
   - Draw primitives

4. **Swap**
   - Buffer swap
   - Event processing

## Public APIs

### Image Class
```csharp
public class Image
{
    int Width { get; }
    int Height { get; }
    byte[] Data { get; } // RGBA
    
    static Image Load(string path);
    static Image LoadImageFromResources(string resourceName);
}
```

### OpenGL Wrapper
```csharp
public static class Gl
{
    // State
    static Enable GlEnable { get; }
    static Disable GlDisable { get; }
    
    // Drawing
    static Begin GlBegin { get; }
    static End GlEnd { get; }
    static DrawArrays GlDrawArrays { get; }
    static DrawElements GlDrawElements { get; }
    
    // Shaders
    static CreateShader GlCreateShader { get; }
    static ShaderSourceDel GlShaderSource { get; }
    static CompileShader GlCompileShader { get; }
    static CreateProgram GlCreateProgram { get; }
    static LinkProgram GlLinkProgram { get; }
    
    // Uniforms
    static Uniform4F GlUniform4F { get; }
    static UniformMatrix2x3FvDel GlUniformMatrix2x3Fv { get; }
    
    // Framebuffers
    static GenFramebuffers GlGenFramebuffers { get; }
    static BindFramebuffer GlBindFramebuffer { get; }
    static FramebufferTexture2D GlFramebufferTexture2D { get; }
}
```

### Shader Program
```csharp
public class GLShaderProgram
{
    uint Id { get; }
    
    void AttachShader(GLShader shader);
    void Link();
    void Use();
    int GetUniformLocation(string name);
    int GetAttribLocation(string name);
}
```

### Platform Interface
```csharp
public interface INativePlatform
{
    void Initialize();
    void Run();
    void Shutdown();
}
```

## Namespaces

| Namespace | Purpose |
|---|---|
| `Alis.Core.Graphic` | Core graphics types |
| `Alis.Core.Graphic.OpenGL` | OpenGL functions |
| `Alis.Core.Graphic.OpenGL.Constructs` | Shader constructs |
| `Alis.Core.Graphic.OpenGL.Enums` | OpenGL enumerations |
| `Alis.Core.Graphic.OpenGL.Delegates` | OpenGL delegates |
| `Alis.Core.Graphic.Platforms` | Platform-specific code |
| `Alis.Core.Graphic.Platforms.Win` | Windows platform |
| `Alis.Core.Graphic.Platforms.Osx` | macOS platform |
| `Alis.Core.Graphic.Platforms.Linux` | Linux platform |
| `Alis.Core.Graphic.Platforms.Web` | WebAssembly platform |
| `Alis.Core.Graphic.Ui` | UI system |

## Data Access

### Image Data
- **RGBA Format**: 4 bytes per pixel (R, G, B, A)
- **Row Padding**: 4-byte alignment
- **Palette Support**: Indexed color images (1, 4, 8 bpp)

### OpenGL State
- **Current Program**: Bound shader program
- **Current Texture**: Bound texture unit
- **Current Buffer**: Bound buffer target
- **Viewport**: Viewport dimensions
- **Scissor**: Scissor rectangle

## Messaging Usage

### Events
- **Platform Events**: Window resize, close, input
- **OpenGL Errors**: Shader compilation, linking errors

### Delegates
- **OpenGL Functions**: Function pointer delegates
- **Platform Callbacks**: Platform-specific callbacks

## DI Registrations

**Auto-Registration:**
- Platform implementations auto-selected by target
- OpenGL functions auto-loaded via P/Invoke

**Manual Registration:**
- Custom shaders implement shader patterns
- Custom platforms implement `INativePlatform`

## Configuration Usage

**Platform Configuration:**
```csharp
INativePlatform platform = PlatformSelector.Select();
platform.Initialize();
platform.Run();
```

**Shader Configuration:**
```csharp
var vertexShader = new GLShader(ShaderType.VertexShader, vertexSource);
var fragmentShader = new GLShader(ShaderType.FragmentShader, fragmentSource);
var program = new GLShaderProgram();
program.AttachShader(vertexShader);
program.AttachShader(fragmentShader);
program.Link();
```

## EF Core Usage

**None** - Pure graphics library, no ORM usage.

## Testing Status

| Test Type | Status |
|---|---|
| **Unit Tests** | Limited - needs expansion |
| **Integration Tests** | Platform-specific tests |
| **Performance Tests** - Rendering benchmarks |
| **Coverage** | Medium - core paths covered |

## Security-Sensitive Areas

1. **P/Invoke Security**
   - Native function loading
   - Pointer operations
   - Memory marshaling

2. **Unsafe Code**
   - `AllowUnsafeBlocks: true` for performance
   - Direct memory access via `IntPtr`
   - Buffer operations

3. **Resource Management**
   - OpenGL object disposal
   - Shader program cleanup
   - Texture memory management

## Performance-Sensitive Areas

1. **Image Loading**
   - BMP parsing
   - Palette conversion
   - RGBA conversion

2. **OpenGL Calls**
   - Function pointer caching
   - Batch rendering
   - State minimization

3. **Shader Compilation**
   - Source loading
   - Error handling
   - Uniform management

4. **Platform Abstraction**
   - Cross-platform rendering
   - Event handling
   - Input processing

## Risks

1. **Memory Leaks**
   - OpenGL objects not disposed
   - Shader programs not deleted
   - Textures not freed

2. **Platform Compatibility**
   - OpenGL version differences
   - Platform-specific bugs
   - WebGL limitations

3. **Shader Errors**
   - Compilation failures
   - Linking errors
   - Uniform mismatches

4. **Thread Safety**
   - OpenGL context not thread-safe
   - Requires single-threaded access
   - Platform-specific threading

5. **Resource Loading**
   - BMP file corruption
   - Missing embedded resources
   - Invalid image data

## TODOs

- [ ] Expand unit test coverage
- [ ] Add multi-threading support
- [ ] Profile rendering performance
- [ ] Add texture loading (PNG, JPG)
- [ ] Add video rendering
- [ ] Create visual debugging tools
- [ ] Document rendering benchmarks

## Complexity Observations

- **High**: Platform abstraction layer
- **High**: OpenGL function wrapping
- **Medium**: Shader compilation and linking
- **Medium**: Image loading and parsing
- **Low**: Basic rendering operations

## Related

- [[4_Operation/Alis.Core.Ecs]] - ECS engine
- [[4_Operation/Alis.Core.Audio]] - Audio system
- [[4_Operation/Alis.Core.Physic]] - Physics system
- [[6_Ideation/Alis.Core.Game]] - Game logic
- [[concepts/opengl-rendering]] - OpenGL rendering
- [[concepts/cross-platform-rendering]] - Cross-platform rendering

## See Also

- [[projects/4_Operation/Core]] - Core operations
- [[architecture/repository-overview]] - Repository architecture
- [[glossary/opengl]] - OpenGL definition
- [[glossary/shader]] - Shader definition
- [[glossary/framebuffer]] - Framebuffer definition
