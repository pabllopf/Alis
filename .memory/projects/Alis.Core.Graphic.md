---
title: Alis.Core.Graphic
tags:
  - operation
  - graphic
  - opengl
  - rendering
  - platform
status: Draft
license: GPLv3
---

# Alis.Core.Graphic

**Layer:** 4_Operation
**Path:** `4_Operation/Graphic/src/Alis.Core.Graphic.csproj`

## Purpose

Cross-platform graphics rendering system based on OpenGL, supporting Windows, macOS, Linux, Web (WebAssembly/Emscripten), and Android targets.

## Architecture

### Core
- `Gl` — OpenGL bindings
- `Image` — Image/texture loading

### OpenGL Constructs
- `GLShader` / `GLShaderProgram` — Shader management
- `GLShaderProgramParam` — Uniform/attribute parameters
- `ParamType` — Parameter type enum

### OpenGL Delegates (functions)
Function pointer delegates for all GL entry points (50+ delegates):
- `Clear`, `ClearColor`, `Viewport`, `Scissor`
- `CreateShader`, `CompileShader`, `ShaderSourceDel`, `LinkProgram`
- `GenBuffers`, `GenTextures`, `GenVertexArrays`
- `BindBuffer`, `BindTexture`, `BindVertexArray`
- `BufferData`, `TexImage2D`, `TexParameteri`
- `Uniform1F` through `Uniform4Fv`
- `VertexAttribPointerDel`, `EnableVertexAttribArrayDel`
- `DrawArrays`, `DrawElements`, `DrawElementsBaseVertex`
- And more

### OpenGL Enums
20+ enum types for GL constants (BeginMode, BufferTarget, ShaderType, TextureTarget, etc.)

### Platforms
- **Windows**: `WinNativePlatform` + Win32 P/Invoke (`User32`, `Gdi32`, `Opengl32`, `Kernel32`)
- **macOS**: `MacNativePlatform` + Objective-C interop (`MacWindow`, `MacOpenGLContext`, `ObjectiveCInterop`)
- **Linux**: `LinuxNativePlatform` + X11 interop (`XEvent`, `XButtonEvent`, `XKeyEvent`, etc.)
- **Web**: `WebAssemblyPlatform` + Emscripten/JS interop (`EGL`, `Emscripten`, `WebAssembly*`)
- **Android**: `EGLDroid`

### UI
- `Font` / `FontManager` — Font rendering

## Dependencies

- Alis.Core.Aspect (5_Declaration)

## Testing

**Path:** `4_Operation/Graphic/test/`

90+ test files covering:
- GL construct tests (Shader, ShaderProgram, Parameters)
- Platform-specific tests (Windows, macOS, WebAssembly)
- Image loading and manipulation
- All GL delegate and enum tests
- Font rendering tests
- Extensive platform interop tests

## Platform Support

| Platform | Graphics API | Test Coverage |
|---|---|---|
| Windows | OpenGL via Win32 | Moderate |
| macOS | OpenGL via Cocoa/ObjC | Moderate |
| Linux | OpenGL via X11 | Minimal |
| Web | WebGL via Emscripten | Extensive |
| Android | OpenGL ES via EGL | Minimal |

## Related Documents

- [[Alis.Core.Aspect]]
- [[Alis.Core.Ecs]]
- [[Alis.Core.Physic]]
- [[testing-overview]]
