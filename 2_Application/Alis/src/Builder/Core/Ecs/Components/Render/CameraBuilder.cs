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
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using NotImplementedException = System.NotImplementedException;

namespace Alis.Builder.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The camera builder class
    /// </summary>
    /// <seealso cref="IBuild{Camera}" />
    public class CameraBuilder : IBuild<Camera>
    {
        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F cameraPosition = new Vector2F(0, 0);

        /// <summary>
        ///     The vector
        /// </summary>
        private Vector2F resolution = new Vector2F(1920, 1080);
        
        /// <summary>
        /// The context
        /// </summary>
        private Context context;

        /// <summary>
        /// Initializes a new instance of the <see cref="CameraBuilder"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public CameraBuilder(Context context)
        {
            this.context = context;
        }

        /// <summary>
        /// Gets or sets the value of the background color
        /// </summary>
        private Color backgroundColor { get; set; } = Color.Black;

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The camera</returns>
        public Camera Build() => new Camera(context, cameraPosition, resolution);

        /// <summary>
        ///     Resolutions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The camera builder</returns>
        public CameraBuilder Resolution(int x, int y)
        {
            resolution = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        ///     Positions the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The camera builder</returns>
        public CameraBuilder Position(float x, float y)
        {
            cameraPosition = new Vector2F(x, y);
            return this;
        }

        /// <summary>
        /// Backgrounds the color using the specified black
        /// </summary>
        /// <param name="black">The black</param>
        /// <returns>The camera builder</returns>
        public CameraBuilder BackgroundColor(Color black)
        {
            backgroundColor = black;
            return this;
        }
    }
}