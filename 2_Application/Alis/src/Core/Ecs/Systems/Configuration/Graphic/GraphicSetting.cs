// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicSetting.cs
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

using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Ecs.Systems.Configuration.Graphic
{
    /// <summary>
    /// The graphic setting class
    /// </summary>
    /// <seealso cref="IGraphicSetting"/>
    public class GraphicSetting(
        double targetFrames = 60,
        string target = "OpenGL",
        bool previewMode = false,
        Color gridColor = default(Color),
        bool hasGrid = false,
        Color backgroundColor = default(Color),
        Vector2F windowSize = default(Vector2F),
        bool isResizable = true) : IGraphicSetting
    {
        /// <summary>
        /// Gets or sets the value of the target frames
        /// </summary>
        public double TargetFrames { get; set; } = targetFrames;
        /// <summary>
        /// Gets or sets the value of the target
        /// </summary>
        public string Target { get; set; } = target;
        /// <summary>
        /// Gets or sets the value of the preview mode
        /// </summary>
        public bool PreviewMode { get; set; } = previewMode;
        /// <summary>
        /// Gets or sets the value of the grid color
        /// </summary>
        public Color GridColor { get; set; } = gridColor;
        /// <summary>
        /// Gets or sets the value of the has grid
        /// </summary>
        public bool HasGrid { get; set; } = hasGrid;
        /// <summary>
        /// Gets or sets the value of the background color
        /// </summary>
        public Color BackgroundColor { get; set; } = backgroundColor;
        /// <summary>
        /// Gets or sets the value of the window size
        /// </summary>
        public Vector2F WindowSize { get; set; } = windowSize;
        /// <summary>
        /// Gets or sets the value of the is resizable
        /// </summary>
        public bool IsResizable { get; set; } = isResizable;
    }
}