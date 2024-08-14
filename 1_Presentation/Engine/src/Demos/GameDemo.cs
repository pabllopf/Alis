// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameDemo.cs
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
using System.Diagnostics;
using System.Runtime.InteropServices;
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;

namespace Alis.App.Engine.Demos
{
    /// <summary>
    ///     The game demo class
    /// </summary>
    /// <seealso cref="IDemo" />
    public class GameDemo : IDemo
    {
        /// <summary>
        ///     The name window
        /// </summary>
        public const string NameWindow = "Game(sample)";
        
        /// <summary>
        ///     The blue
        /// </summary>
        public byte _blue;
        
        /// <summary>
        ///     The green
        /// </summary>
        public byte _green;
        
        /// <summary>
        ///     The red
        /// </summary>
        public byte _red;
        
        /// <summary>
        ///     The close render
        /// </summary>
        public bool closeRender = true;
        
        /// <summary>
        ///     The pixels ptr
        /// </summary>
        public IntPtr pixelsPtr;
        
        /// <summary>
        ///     The zero
        /// </summary>
        public IntPtr rendererGame = IntPtr.Zero;
        
        /// <summary>
        ///     The texture
        /// </summary>
        public IntPtr texture;
        
        /// <summary>
        ///     The textureopengl id
        /// </summary>
        public uint textureopenglId;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameDemo" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public GameDemo(SpaceWork spaceWork) => SpaceWork = spaceWork;
        
        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
        
        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
            InitSimpleGameDemo();
        }
        
        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }
        
        
        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            SimpleGameDemo();
        }
        
        /// <summary>
        ///     Inits the simple game demo
        /// </summary>
        [Conditional("DEBUG")]
        public void InitSimpleGameDemo()
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
            
            
            texture = (IntPtr) textureopenglId;
        }
        
        /// <summary>
        ///     Simples the game demo
        /// </summary>
        [Conditional("DEBUG")]
        public void SimpleGameDemo()
        {
            RenderColors();
            
            Sdl.SetRenderDrawColor(rendererGame, _red, _green, _blue, 255);
            Sdl.RenderClear(rendererGame);
            Sdl.RenderPresent(rendererGame);
            
            RectangleI rect = new RectangleI(0, 0, 800, 600);
            Sdl.RenderReadPixels(rendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelsPtr, 800 * 4);
            
            // Update opengl texture 
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenglId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelsPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
            
            if (ImGui.Begin(NameWindow, ref closeRender, ImGuiWindowFlags.NoCollapse))
            {
                ImGui.Text("This is some useful text.");
                ImGui.Image(
                    texture,
                    new Vector2(100, 100),
                    new Vector2(1, 1),
                    new Vector2(1, 1),
                    new Vector4(1, 1, 1, 1),
                    new Vector4(255, 0, 0, 255));
            }
            
            ImGui.End();
        }
        
        /// <summary>
        ///     Renders the colors
        /// </summary>
        public void RenderColors()
        {
            if (_red < 255)
            {
                _red++;
            }
            else if (_green < 255)
            {
                _green++;
            }
            else if (_blue < 255)
            {
                _blue++;
            }
            else
            {
                _red = 0;
                _green = 0;
                _blue = 0;
            }
        }
    }
}