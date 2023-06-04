// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlGLattr.cs
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

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl glattr enum
    /// </summary>
    public enum SdlGLattr
    {
        /// <summary>
        ///     The sdl gl red size sdl glattr
        /// </summary>
        SdlGlRedSize,

        /// <summary>
        ///     The sdl gl green size sdl glattr
        /// </summary>
        SdlGlGreenSize,

        /// <summary>
        ///     The sdl gl blue size sdl glattr
        /// </summary>
        SdlGlBlueSize,

        /// <summary>
        ///     The sdl gl alpha size sdl glattr
        /// </summary>
        SdlGlAlphaSize,

        /// <summary>
        ///     The sdl gl buffer size sdl glattr
        /// </summary>
        SdlGlBufferSize,

        /// <summary>
        ///     The sdl gl doublebuffer sdl glattr
        /// </summary>
        SdlGlDoublebuffer,

        /// <summary>
        ///     The sdl gl depth size sdl glattr
        /// </summary>
        SdlGlDepthSize,

        /// <summary>
        ///     The sdl gl stencil size sdl glattr
        /// </summary>
        SdlGlStencilSize,

        /// <summary>
        ///     The sdl gl accum red size sdl glattr
        /// </summary>
        SdlGlAccumRedSize,

        /// <summary>
        ///     The sdl gl accum green size sdl glattr
        /// </summary>
        SdlGlAccumGreenSize,

        /// <summary>
        ///     The sdl gl accum blue size sdl glattr
        /// </summary>
        SdlGlAccumBlueSize,

        /// <summary>
        ///     The sdl gl accum alpha size sdl glattr
        /// </summary>
        SdlGlAccumAlphaSize,

        /// <summary>
        ///     The sdl gl stereo sdl glattr
        /// </summary>
        SdlGlStereo,

        /// <summary>
        ///     The sdl gl multisamplebuffers sdl glattr
        /// </summary>
        SdlGlMultisamplebuffers,

        /// <summary>
        ///     The sdl gl multisamplesamples sdl glattr
        /// </summary>
        SdlGlMultisamplesamples,

        /// <summary>
        ///     The sdl gl accelerated visual sdl glattr
        /// </summary>
        SdlGlAcceleratedVisual,

        /// <summary>
        ///     The sdl gl retained backing sdl glattr
        /// </summary>
        SdlGlRetainedBacking,

        /// <summary>
        ///     The sdl gl context major version sdl glattr
        /// </summary>
        SdlGlContextMajorVersion,

        /// <summary>
        ///     The sdl gl context minor version sdl glattr
        /// </summary>
        SdlGlContextMinorVersion,

        /// <summary>
        ///     The sdl gl context egl sdl glattr
        /// </summary>
        SdlGlContextEgl,

        /// <summary>
        ///     The sdl gl context flags sdl glattr
        /// </summary>
        SdlGlContextFlags,

        /// <summary>
        ///     The sdl gl context profile mask sdl glattr
        /// </summary>
        SdlGlContextProfileMask,

        /// <summary>
        ///     The sdl gl share with current context sdl glattr
        /// </summary>
        SdlGlShareWithCurrentContext,

        /// <summary>
        ///     The sdl gl framebuffer srgb capable sdl glattr
        /// </summary>
        SdlGlFramebufferSrgbCapable,

        /// <summary>
        ///     The sdl gl context release behavior sdl glattr
        /// </summary>
        SdlGlContextReleaseBehavior,

        /// <summary>
        ///     The sdl gl context reset notification sdl glattr
        /// </summary>
        SdlGlContextResetNotification, 

        /// <summary>
        ///     The sdl gl context no error sdl glattr
        /// </summary>
        SdlGlContextNoError 
    }
}