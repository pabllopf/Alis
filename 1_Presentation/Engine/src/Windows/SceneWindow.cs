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
using System.Collections.Generic;
using Alis.App.Engine.Core;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Fonts;

namespace Alis.App.Engine.Windows
{
    /// <summary>
    ///     The scene window class
    /// </summary>
    public class SceneWindow : IWindow
    {
        /// <summary>
        ///     The hashtag
        /// </summary>
        public static readonly string NameWindow = $"{FontAwesome5.Hashtag} Scene";

        /// <summary>
        ///     The active button
        /// </summary>
        private readonly HashSet<ActiveButton> activeButtons = new HashSet<ActiveButton>();

        /// <summary>
        ///     The height texture
        /// </summary>
        private float heightTexture;

        /// <summary>
        ///     The offset texture
        /// </summary>
        private Vector2F offsetTexture;

        /// <summary>
        ///     The pixel ptr
        /// </summary>
        private IntPtr pixelPtr;


        /// <summary>
        ///     The selected game object
        /// </summary>
        //private GameObject selectedGameObject;

        /// <summary>
        ///     The textureopen gl id
        /// </summary>
        private uint textureopenGlId;

        /// <summary>
        ///     The width texture
        /// </summary>
        private float widthTexture;


        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneWindow" /> class
        /// </summary>
        /// <param name="spaceWork">The space work</param>
        public SceneWindow(SpaceWork spaceWork) => SpaceWork = spaceWork;

        /// <summary>
        ///     Gets the value of the space work
        /// </summary>
        public SpaceWork SpaceWork { get; }

        /// <summary>
        ///     Initializes this instance
        /// </summary>
        public void Initialize()
        {
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public void Start()
        {
        }

        /// <summary>
        ///     Renders this instance
        /// </summary>
        public void Render()
        {
            if (ImGui.Begin(NameWindow, ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoCollapse))
            {
            }

            ImGui.End();
        }

        /// <summary>
        ///     Gets the mouse world position
        /// </summary>
        /// <returns>The world pos</returns>
        private Vector2F GetMouseWorldPosition()
        {
            ImGuiIoPtr io = ImGui.GetIo();

            Vector2F mousePosition = io.MousePos;
            Vector2F windowPosition = ImGui.GetWindowPos();
            Vector2F windowSize = ImGui.GetWindowSize();
            Vector2F textureSize = new Vector2F(widthTexture, heightTexture);

            Vector2F mousePositionRelativeToWindow = mousePosition - windowPosition;
            Vector2F mousePositionRelativeToTexture = mousePositionRelativeToWindow - (windowSize - textureSize) / 2;

            mousePositionRelativeToTexture.Y -= 30.0f;

            Logger.Info("--------------------");
            Logger.Info($"Mouse Position: {mousePosition.X}, {mousePosition.Y}");
            Logger.Info($"Window Position: {windowPosition.X}, {windowPosition.Y}");
            Logger.Info($"Window Size: {windowSize.X}, {windowSize.Y}");
            Logger.Info($"Texture Size: {textureSize.X}, {textureSize.Y}");
            Logger.Info($"Mouse Position Relative To Window: {mousePositionRelativeToWindow.X}, {mousePositionRelativeToWindow.Y}");
            Logger.Info($"Mouse Position Relative To Texture: {mousePositionRelativeToTexture.X}, {mousePositionRelativeToTexture.Y}");
            Logger.Info("--------------------");
            Vector2F errorPosition = new Vector2F(0, 0);

            if (mousePositionRelativeToTexture.X >= textureSize.X)
            {
                errorPosition.X = mousePositionRelativeToTexture.X - textureSize.X;
                Logger.Info($"Error Position X: {errorPosition.X}");
            }

            if (mousePositionRelativeToTexture.X < 0)
            {
                errorPosition.X = -mousePositionRelativeToTexture.X;
                Logger.Info($"Error Position X: {errorPosition.X}");
            }

            if (mousePositionRelativeToTexture.Y >= textureSize.Y)
            {
                errorPosition.Y = mousePositionRelativeToTexture.Y - textureSize.Y;
                Logger.Info($"Error Position Y: {errorPosition.Y}");
            }

            if (mousePositionRelativeToTexture.Y < 0)
            {
                errorPosition.Y = -mousePositionRelativeToTexture.Y;
                Logger.Info($"Error Position Y: {errorPosition.Y}");
            }

            Vector2F mousePositionRelativeToTextureAdjusted = mousePositionRelativeToTexture - errorPosition;

            mousePositionRelativeToTextureAdjusted.X = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.X);
            mousePositionRelativeToTextureAdjusted.Y = (float) Math.Floor(mousePositionRelativeToTextureAdjusted.Y);

            Logger.Info($"Mouse Position Relative To Texture Adjusted: {mousePositionRelativeToTextureAdjusted.X}, {mousePositionRelativeToTextureAdjusted.Y}");

            Vector2F mousePositionRelativeToTextureCentered = new Vector2F(0, 0);
            mousePositionRelativeToTextureCentered.X = mousePositionRelativeToTextureAdjusted.X - textureSize.X / 2;
            mousePositionRelativeToTextureCentered.Y = mousePositionRelativeToTextureAdjusted.Y - textureSize.Y / 2;

            Logger.Info($"Mouse Position Relative To Texture Centered: {mousePositionRelativeToTextureCentered.X}, {mousePositionRelativeToTextureCentered.Y}");

           Vector2F worldPos = new Vector2F();
            return worldPos;
        }

      }
}