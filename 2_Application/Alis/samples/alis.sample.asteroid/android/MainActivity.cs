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
    [Activity(Label = "Alis.Sample.Asteroid.Android", MainLauncher = true, Theme = "@android:style/Theme.NoTitleBar"), Register("crc647600d30597f44ece.MainActivity")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var glView = new GlView(this);
            SetContentView(glView);
        }
    }

    public class GlView : GLSurfaceView
    {
        public GlView(Context context) : base(context)
        {
            SetEGLContextClientVersion(2);
            SetRenderer(new TriangleRenderer());
        }
    }

    public class TriangleRenderer : Object, GLSurfaceView.IRenderer
    {
        private const int CoordsPerVertex = 2;

        private static readonly float[] TriangleCoords =
        {
            0f, 0.5f,
            -0.5f, -0.5f,
            0.5f, -0.5f
        };

        private static readonly string VertexShaderCode =
            "attribute vec2 vPosition; void main() { gl_Position = vec4(vPosition, 0.0, 1.0); }";

        private static readonly string FragmentShaderCode =
            "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";

        private IntPtr _vertexPtr;
        private int positionHandle;
        private uint program;

        // Métodos para compatibilidad con IGL10/EGLConfig
        public void OnDrawFrame(IGL10? gl)
        {
            OnDrawFrame((Object) null);
        }

        public void OnSurfaceChanged(IGL10? gl, int width, int height)
        {
            OnSurfaceChanged((Object) null, width, height);
        }

        public void OnSurfaceCreated(IGL10? gl, EGLConfig? config)
        {
            OnSurfaceCreated(null, (Object) null);
        }


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

        public void OnSurfaceChanged(Object gl, int width, int height)
        {
            Log.Debug("AlisGL", $"OnSurfaceChanged llamado: width={width}, height={height}");
            Gl.GlViewport(0, 0, width, height);
        }

        private uint LoadShader(ShaderType type, string shaderCode)
        {
            uint shader = Gl.GlCreateShader(type);
            Gl.ShaderSource(shader, shaderCode);
            Gl.GlCompileShader(shader);
            return shader;
        }

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