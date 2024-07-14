// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneWindow.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.App.Engine.Fonts;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        private const string NameWindow = "Scene";
        
        private bool isOpen = true;
        
        private ImGuiWindowFlags windowFlags = ImGuiWindowFlags.NoCollapse;
        
        private IntPtr pixelsPtr;
        
        private uint textureopenglId;
        
        private IntPtr texture;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }
        
        public void Initialize()
        {
            pixelsPtr = Marshal.AllocHGlobal(800 * 600 * 4);
            // write into the pixels array:
            for (int i = 0; i < 800 * 600 * 4; i += 4)
            {
                Marshal.WriteByte(pixelsPtr, i, 255);
                Marshal.WriteByte(pixelsPtr, i + 1, 0);
                Marshal.WriteByte(pixelsPtr, i + 2, 0);
                Marshal.WriteByte(pixelsPtr, i + 3, 255);
            }
            
            uint[] textures = new uint[1];
            Gl.GlGenTextures(1, textures);
            textureopenglId = textures[0];
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenglId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelsPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            
            
            texture = (IntPtr)textureopenglId;
        }
        
        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (!isOpen)return;


            Sdl.SetRenderDrawColor(SpaceWork.rendererGame, 0, 0, 0, 255);
            Sdl.RenderClear(SpaceWork.rendererGame);
            Sdl.RenderPresent(SpaceWork.rendererGame);
            
            RectangleI rect = new RectangleI( 0, 0, 800, 600);
            Sdl.RenderReadPixels(SpaceWork.rendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelsPtr, 800 * 4);
            
            // Update opengl texture 
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenglId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelsPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D,  0);
            
            if (ImGui.Begin(NameWindow, ref isOpen, windowFlags))
            { 
                float x = ImGui.GetWindowWidth();
                float y = ImGui.GetWindowHeight();
                float marginX = 20;
                float marginY = 40;
                
                ImGui.Image(
                    texture,
                    new Vector2(x - marginX, y - marginY),
                    new Vector2(1, 1),
                    new Vector2(1, 1),
                    new Vector4(1, 1, 1, 1),
                    new Vector4(255, 0, 0, 255));

            }
            
            ImGui.End();
        }
        
        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
    }
}