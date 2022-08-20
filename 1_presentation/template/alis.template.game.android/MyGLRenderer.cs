// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MyGLRenderer.cs
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

using Android.Opengl;
using Java.Lang;
using Javax.Microedition.Khronos.Opengles;
using EGLConfig = Javax.Microedition.Khronos.Egl.EGLConfig;

namespace Alis.Template.Game.Android
{
    /// <summary>
    ///     The my gl renderer class
    /// </summary>
    /// <seealso cref="Java.Lang.Object" />
    /// <seealso cref="GLSurfaceView.IRenderer" />
    internal class MyGLRenderer : Object, GLSurfaceView.IRenderer
    {
        /// <summary>
        ///     The proj matrix
        /// </summary>
        private float[] mProjMatrix = new float[16];

        /// <summary>
        ///     The tag
        /// </summary>
        private static string TAG = "MyGLRenderer";


        /// <summary>
        ///     Ons the draw frame using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        public void OnDrawFrame(IGL10 gl)
        {
            RenderManager.OnDrawFrame();
        }

        /// <summary>
        ///     Ons the surface changed using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            // Adjust the viewport based on geometry changes,
            // such as screen rotation
            GLES20.GlViewport(0, 0, width, height);

            float ratio = (float) width / height;

            // this projection matrix is applied to object coordinates
            // in the onDrawFrame() method
            Matrix.FrustumM(mProjMatrix, 0, -ratio, ratio, -1, 1, 3, 7);
        }

        /// <summary>
        ///     Ons the surface created using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="config">The config</param>
        public void OnSurfaceCreated(IGL10 gl, EGLConfig config)
        {
            //GLES30.GlClearColor (0.0f, 0.0f, 0.0f, 1.0f);
        }
    }
}