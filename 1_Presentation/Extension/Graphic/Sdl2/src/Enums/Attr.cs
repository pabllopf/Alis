// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Attr.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Extension.Graphic.Sdl2.Enums
{
    /// <summary>
    ///     The sdl gl attr enum
    /// </summary>
    public enum Attr
    {
    /// <summary>
    ///     Size of the red channel in bits for the GL framebuffer
    /// </summary>
    SdlGlRedSize,

    /// <summary>
    ///     Size of the green channel in bits for the GL framebuffer
    /// </summary>
    SdlGlGreenSize,

    /// <summary>
    ///     Size of the blue channel in bits for the GL framebuffer
    /// </summary>
    SdlGlBlueSize,

    /// <summary>
    ///     Size of the alpha channel in bits for the GL framebuffer
    /// </summary>
    SdlGlAlphaSize,

    /// <summary>
    ///     Size of the color buffer in bits for the GL framebuffer
    /// </summary>
    SdlGlBufferSize,

    /// <summary>
    ///     Whether double buffering is enabled for the GL context
    /// </summary>
    SdlGlDoubleBuffer,

    /// <summary>
    ///     Size of the depth buffer in bits for the GL framebuffer
    /// </summary>
    SdlGlDepthSize,

    /// <summary>
    ///     Size of the stencil buffer in bits for the GL framebuffer
    /// </summary>
    SdlGlStencilSize,

    /// <summary>
    ///     Size of the red accumulation channel in bits for the GL framebuffer
    /// </summary>
    SdlGlAccumRedSize,

    /// <summary>
    ///     Size of the green accumulation channel in bits for the GL framebuffer
    /// </summary>
    SdlGlAccumGreenSize,

    /// <summary>
    ///     Size of the blue accumulation channel in bits for the GL framebuffer
    /// </summary>
    SdlGlAccumBlueSize,

    /// <summary>
    ///     Size of the alpha accumulation channel in bits for the GL framebuffer
    /// </summary>
    SdlGlAccumAlphaSize,

    /// <summary>
    ///     Whether stereoscopic 3D rendering is enabled for the GL context
    /// </summary>
    SdlGlStereo,

    /// <summary>
    ///     Number of multisample buffers used for antialiasing
    /// </summary>
    SdlGlMultiSampleBuffers,

    /// <summary>
    ///     Number of multisample samples per pixel used for antialiasing
    /// </summary>
    SdlGlMultiSampleSamples,

    /// <summary>
    ///     Whether the GL context uses an accelerated visual
    /// </summary>
    SdlGlAcceleratedVisual,

    /// <summary>
    ///     Whether the GL context retains the back buffer after swap
    /// </summary>
    SdlGlRetainedBacking,

    /// <summary>
    ///     Major version number of the OpenGL context to request
    /// </summary>
    SdlGlContextMajorVersion,

    /// <summary>
    ///     Minor version number of the OpenGL context to request
    /// </summary>
    SdlGlContextMinorVersion,

    /// <summary>
    ///     Whether the GL context uses EGL instead of the native platform GL
    /// </summary>
    SdlGlContextEgl,

    /// <summary>
    ///     Bitmask of GL context flags (debug, forward compatible, etc.)
    /// </summary>
    SdlGlContextFlags,

    /// <summary>
    ///     Bitmask of the GL context profile mask (core, compatibility, ES)
    /// </summary>
    SdlGlContextProfileMask,

    /// <summary>
    ///     Whether to share resources with the currently active GL context
    /// </summary>
    SdlGlShareWithCurrentContext,

    /// <summary>
    ///     Whether the framebuffer supports sRGB color space
    /// </summary>
    SdlGlFramebufferSrgbCapable,

    /// <summary>
    ///     Release behavior for the GL context (flush or none)
    /// </summary>
    SdlGlContextReleaseBehavior,

    /// <summary>
    ///     Reset notification strategy for the GL context
    /// </summary>
    SdlGlContextResetNotification,

    /// <summary>
    ///     Whether the GL context suppresses error reporting for performance
    /// </summary>
    SdlGlContextNoError
    }
}