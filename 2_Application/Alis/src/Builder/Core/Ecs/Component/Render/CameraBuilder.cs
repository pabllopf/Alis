// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CameraBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;

namespace Alis.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    ///     The camera builder class
    /// </summary>
    public class CameraBuilder :
        IBuild<Camera>,
        IResolution<CameraBuilder, int, int>,
        IBackgroundColor<CameraBuilder, Color>
    {
        /// <summary>
        ///     The camera
        /// </summary>
        private readonly Camera camera = new Camera();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The camera</returns>
        public Camera Build() => camera;


        /// <summary>
        /// Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The camera builder</returns>
        public CameraBuilder Resolution(int x, int y)
        {
            camera.Resolution = new Vector2(x, y);
            return this;
        }
        
        /// <summary>
        /// Backgrounds the color using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The camera builder</returns>
        public CameraBuilder BackgroundColor(Color value)
        {
            camera.BackgroundColor = value;
            return this;
        }
    }
}