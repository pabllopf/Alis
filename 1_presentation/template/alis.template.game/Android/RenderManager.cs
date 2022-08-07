// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   RenderManager.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

#if ANDROID
using System;
using Android.Opengl;
#endif

#if OSX || IOS
using Metal;
using MetalKit;
using MetalPerformanceShaders;
using CoreAnimation;
#endif

#if WINDOWS || LINUX
using OpenTK.Graphics.OpenGL4;
#endif

namespace Alis.Template.Game.Android
{
    /// <summary>
    ///     The render manager class
    /// </summary>
    public static class RenderManager
    {
        /// <summary>
        ///     The blue
        /// </summary>
        private static float red, green, blue;

        /// <summary>
        ///     Ons the draw frame
        /// </summary>
        public static void OnDrawFrame()
        {
#if ANDROID
             Console.WriteLine("RenderManager on android");
            
            GLES20.GlClearColor(red, green, blue, 1.0f);
            GLES20.GlClear ((int)GLES20.GlColorBufferBit);
			
            red += 0.01f;
            if (red >= 1.0f)
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;
#endif

#if WINDOWS || LINUX
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            GL.ClearColor(red, green, blue, 1.0f);
            
            red += 0.01f;
            if (red >= 1.0f)
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;
#endif
        }

#if OSX || IOS
        public static void OnDrawFrame(MTKView view, IMTLCommandQueue commandQueue)
        {
            view.ClearColor = new MTLClearColor(red, green, blue, 1.0f);
			
            // Create a new command buffer for each renderpass to the current drawable
            IMTLCommandBuffer commandBuffer = commandQueue.CommandBuffer();
			
            // Obtain a renderPassDescriptor generated from the view's drawable textures
            MTLRenderPassDescriptor renderPassDescriptor = view.CurrentRenderPassDescriptor;
			
            // Create a render command encoder so we can render into something
            IMTLRenderCommandEncoder commandEncoder = commandBuffer.CreateRenderCommandEncoder(renderPassDescriptor);
			
            commandEncoder.EndEncoding();

            ICAMetalDrawable drawable = view.CurrentDrawable;
			
            commandBuffer.PresentDrawable(drawable);
			
            commandBuffer.Commit();

            red += 0.01f;
            if (red >= 1.0f)
                red -= 1.0f;
            green += 0.02f;
            if (green >= 1.0f)
                green -= 1.0f;
            blue += 0.03f;
            if (blue >= 1.0f)
                blue -= 1.0f;
        }
#endif
    }
}