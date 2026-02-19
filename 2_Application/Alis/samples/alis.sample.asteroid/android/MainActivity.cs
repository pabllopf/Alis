// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MainActivity.cs
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
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms.Android;
using Android.App;
using Android.Content;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Javax.Microedition.Khronos.Opengles;
using EGLConfig = Javax.Microedition.Khronos.Egl.EGLConfig;
using Object = Java.Lang.Object;

namespace Alis.Sample.Asteroid.Android
{
    /// <summary>
    /// The main activity class
    /// </summary>
    /// <seealso cref="Activity"/>
    [Activity(Label = "Alis.Sample.Asteroid.Android", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar"), Register("crc647600d30597f44ece.MainActivity")]
    public class MainActivity : Activity
    {
        /// <summary>
        /// Ons the create using the specified saved instance state
        /// </summary>
        /// <param name="savedInstanceState">The saved instance state</param>
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var glView = new GlView(this);
            SetContentView(glView);
        }
    }

    /// <summary>
    /// The gl view class
    /// </summary>
    /// <seealso cref="GLSurfaceView"/>
    public class GlView : GLSurfaceView
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GlView"/> class
        /// </summary>
        /// <param name="context">The context</param>
        public GlView(Context context) : base(context)
        {
            SetEGLContextClientVersion(2);
            SetRenderer(new TriangleRenderer());
        }
    }

    /// <summary>
    /// The triangle renderer class
    /// </summary>
    /// <seealso cref="Object"/>
    /// <seealso cref="GLSurfaceView.IRenderer"/>
    public class TriangleRenderer : Object, GLSurfaceView.IRenderer
    {
        /// <summary>
        /// The coords per vertex
        /// </summary>
        private const int CoordsPerVertex = 2;

        /// <summary>
        /// The triangle coords
        /// </summary>
        private static readonly float[] TriangleCoords =
        {
            0f, 0.5f,
            -0.5f, -0.5f,
            0.5f, -0.5f
        };

        /// <summary>
        /// The vertex shader code
        /// </summary>
        private static readonly string VertexShaderCode =
            "attribute vec2 vPosition; void main() { gl_Position = vec4(vPosition, 0.0, 1.0); }";

        /// <summary>
        /// The fragment shader code
        /// </summary>
        private static readonly string FragmentShaderCode =
            "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";

        /// <summary>
        /// The vertex ptr
        /// </summary>
        private IntPtr _vertexPtr;
        /// <summary>
        /// The position handle
        /// </summary>
        private int positionHandle;
        /// <summary>
        /// The program
        /// </summary>
        private uint program;

        // Métodos para compatibilidad con IGL10/EGLConfig
        /// <summary>
        /// Ons the draw frame using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        public void OnDrawFrame(IGL10? gl)
        {
            OnDrawFrame((Object) null);
        }

        /// <summary>
        /// Ons the surface changed using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void OnSurfaceChanged(IGL10? gl, int width, int height)
        {
            OnSurfaceChanged((Object) null, width, height);
        }

        /// <summary>
        /// Ons the surface created using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="config">The config</param>
        public void OnSurfaceCreated(IGL10? gl, EGLConfig? config)
        {
            OnSurfaceCreated(null, (Object) null);
        }


        /// <summary>
        /// Ons the surface created using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="config">The config</param>
        public void OnSurfaceCreated(Object gl, Object config)
        {
            // Inicializar Gl con el puntero de funciones de EGL
            Gl.Initialize(EGLDroid.GetProcAddress);
            Log.Debug("AlisGL", "OnSurfaceCreated llamado");
            int size = TriangleCoords.Length * sizeof(float);
            IntPtr vertexPtr = Marshal.AllocHGlobal(size);
            Marshal.Copy(TriangleCoords, 0, vertexPtr, TriangleCoords.Length);

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, VertexShaderCode);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, FragmentShaderCode);
            Gl.GlCompileShader(fragmentShader);

            program = Gl.GlCreateProgram();
            Gl.GlAttachShader(program, vertexShader);
            Gl.GlAttachShader(program, fragmentShader);
            Gl.GlLinkProgram(program);

            positionHandle = Gl.GlGetAttribLocation(program, "vPosition");

            _vertexPtr = vertexPtr;
        }

        /// <summary>
        /// Ons the draw frame using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        public void OnDrawFrame(Object gl)
        {
            Log.Debug("AlisGL", "OnDrawFrame llamado");
            if (_vertexPtr == IntPtr.Zero)
            {
                Log.Error("AlisGL", "vertexPtr es null");
                return;
            }

            Gl.GlClearColor(1f, 0f, 0f, 1f); // Fondo rojo
            Gl.GlClear(ClearBufferMask.ColorBufferBit); // Limpiar buffer de color
            Gl.GlUseProgram(program);
            Gl.EnableVertexAttribArray(positionHandle);
            Gl.VertexAttribPointer(
                positionHandle,
                CoordsPerVertex,
                VertexAttribPointerType.Float,
                false,
                0,
                _vertexPtr
            );
            Gl.GlDrawArrays(PrimitiveType.Triangles, 0, 3); // Triángulo blanco
        }

        /// <summary>
        /// Ons the surface changed using the specified gl
        /// </summary>
        /// <param name="gl">The gl</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void OnSurfaceChanged(Object gl, int width, int height)
        {
            Log.Debug("AlisGL", $"OnSurfaceChanged llamado: width={width}, height={height}");
            Gl.GlViewport(0, 0, width, height);
        }

        /// <summary>
        /// Loads the shader using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="shaderCode">The shader code</param>
        /// <returns>The shader</returns>
        private uint LoadShader(ShaderType type, string shaderCode)
        {
            uint shader = Gl.GlCreateShader(type);
            Gl.ShaderSource(shader, shaderCode);
            Gl.GlCompileShader(shader);
            return shader;
        }

        /// <summary>
        /// Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        protected override void Dispose(bool disposing)
        {
            if (_vertexPtr != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(_vertexPtr);
                _vertexPtr = IntPtr.Zero;
            }

            base.Dispose(disposing);
        }
    }
}