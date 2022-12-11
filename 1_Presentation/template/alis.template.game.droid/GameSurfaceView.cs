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

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Views;
using Android.Widget;

namespace Alis.Template.Game.Droid
{
    /// <summary>
    /// The game surface view class
    /// </summary>
    /// <seealso cref="Android.Opengl.GLSurfaceView"/>
    internal sealed class GameSurfaceView : Android.Opengl.GLSurfaceView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GameSurfaceView"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public GameSurfaceView(Context context) : base(context)
        {
            // Create an OpenGL ES 3.0 context.
            SetEGLContextClientVersion(2);

            // Set the Renderer for drawing on the GLSurfaceView
            GameRenderer  gameRenderer =  new GameRenderer();
            SetRenderer(gameRenderer);
            
            // Render the view only when there is a change in the drawing data
            RenderMode = Android.Opengl.Rendermode.Continuously;
            //LayoutParameters = (ViewGroup.LayoutParams) ViewGroup.LayoutParams.WrapContent;
        }
    }
}