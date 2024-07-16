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
using Alis.Core.Aspect.Data.Resource;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.Sdl2;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.ImGui;
using Alis.Extension.Graphic.ImGui.Native;
using Alis.Extension.Graphic.OpenGL;
using Alis.Extension.Graphic.OpenGL.Enums;
using PixelFormat = Alis.Extension.Graphic.OpenGL.Enums.PixelFormat;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        private uint textureopenGlId;
        private IntPtr pixelPtr;

        private const string NameWindow = "Scene";
        
        /// <summary>
        /// Initializes a new instance of the <see cref="SceneWindow"/> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork)
        {
            SpaceWork = spaceWork;
        }
        
        /// <summary>
        /// Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }
        
        public void Initialize()
        {
            /*SpaceWork.windowGame = Sdl.CreateWindow("Game Preview", 
                0, 0, 
                800, 600, 
                WindowSettings.WindowResizable | WindowSettings.WindowHidden );
            SpaceWork.rendererGame = Sdl.CreateRenderer(SpaceWork.windowGame, -1, 
                Renderers.SdlRendererAccelerated | Renderers.SdlRendererTargetTexture);*/
            
            SpaceWork.windowGame = SpaceWork.VideoGame.Context.GraphicManager.Window;
            SpaceWork.rendererGame = SpaceWork.VideoGame.Context.GraphicManager.Renderer;
        }

        public void Start()
        {

            pixelPtr = Marshal.AllocHGlobal(800 * 600 * 4);
            uint[] textures = new uint[1];
            Gl.GlGenTextures(1, textures);
            textureopenGlId = textures[0];
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
			
            Console.WriteLine($"Gl Version: {Gl.GlGetString(StringName.Version)}");
            Console.WriteLine($"Vendor: {Gl.GlGetString(StringName.Vendor)}");
            Console.WriteLine($"Renderer: {Gl.GlGetString(StringName.Renderer)}");
            Console.WriteLine($"Extensions: {Gl.GlGetString(StringName.Extensions)}");
            Console.WriteLine($"SDL2 Version: {Sdl.GetVersion().major}.{Sdl.GetVersion().minor}.{Sdl.GetVersion().patch}");
            Console.WriteLine($"Imgui Version: {ImGui.GetVersion()}");
        }
        
        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            SpaceWork.VideoGame.RunPreview();
            
            RectangleI rect = new RectangleI(0, 0, 800, 600);
            Sdl.RenderReadPixels(SpaceWork.rendererGame, ref rect, Sdl.PixelFormatABgr8888, pixelPtr, 800 * 4);
            
            Gl.GlBindTexture(TextureTarget.Texture2D, textureopenGlId);
            Gl.GlTexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba8, 800, 600, 0, PixelFormat.Rgba, PixelType.UnsignedByte, pixelPtr);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter,TextureParameter.Linear);
            Gl.GlTexParameteri(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, TextureParameter.Linear);
            Gl.GlBindTexture(TextureTarget.Texture2D, 0);
				
            if(ImGui.Begin("Scene Sample"))
            {
                ImGui.Image(
                    (IntPtr)textureopenGlId,
                    new Vector2(800, 600),
                    new Vector2(0, 0),
                    new Vector2(1, 1),
                    new Vector4(1, 1, 1, 1),
                    new Vector4(255, 0, 0, 255));
            }
            ImGui.End();
        }
    }
}