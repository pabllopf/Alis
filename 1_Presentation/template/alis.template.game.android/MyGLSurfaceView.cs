// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MyGLSurfaceView.cs
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

using Android.Content;
using Android.Opengl;

namespace Alis.Template.Game.Android
{
    /// <summary>
    ///     The my gl surface view class
    /// </summary>
    /// <seealso cref="GLSurfaceView" />
    internal class MyGLSurfaceView : GLSurfaceView
    {
        /// <summary>
        ///     The renderer
        /// </summary>
        private MyGLRenderer mRenderer;

        /// <summary>
        ///     Initializes a new instance of the <see cref="MyGLSurfaceView" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public MyGLSurfaceView(Context context) : base(context)
        {
            // Create an OpenGL ES 3.0 context.
            SetEGLContextClientVersion(3);

            // Set the Renderer for drawing on the GLSurfaceView
            mRenderer = new MyGLRenderer();
            SetRenderer(mRenderer);

            // Render the view only when there is a change in the drawing data
            RenderMode = Rendermode.Continuously;
        }

        /// <summary>
        ///     The touch scale factor
        /// </summary>
        private const float TOUCH_SCALE_FACTOR = 180.0f / 320;
    }
}