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

namespace Alis.Core.Ecs.System.Configuration.Graphic
{
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
        public double TargetFrames { get; set; } = targetFrames;
        public string Target { get; set; } = target;
        public bool PreviewMode { get; set; } = previewMode;
        public Color GridColor { get; set; } = gridColor;
        public bool HasGrid { get; set; } = hasGrid;
        public Color BackgroundColor { get; set; } = backgroundColor;
        public Vector2F WindowSize { get; set; } = windowSize;
        public bool IsResizable { get; set; } = isResizable;
    }
}