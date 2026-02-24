// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BlueGLKViewController.cs
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
using CoreGraphics;
using GLKit;
using OpenGLES;

namespace Alis.Sample.Asteroid.IOS
{
    // GLKViewController que pinta el fondo rojo y un triángulo blanco
    /// <summary>
    /// The blue glk view controller class
    /// </summary>
    /// <seealso cref="GLKViewController"/>
    public class BlueGlkViewController : GLKViewController
    {
        /// <summary>
        /// The gl color buffer bit
        /// </summary>
        private const uint GL_COLOR_BUFFER_BIT = 0x4000;
        /// <summary>
        /// The gl array buffer
        /// </summary>
        private const uint GL_ARRAY_BUFFER = 0x8892;
        /// <summary>
        /// The gl static draw
        /// </summary>
        private const uint GL_STATIC_DRAW = 0x88E4;
        /// <summary>
        /// The gl float
        /// </summary>
        private const uint GL_FLOAT = 0x1406;
        /// <summary>
        /// The gl triangles
        /// </summary>
        private const uint GL_TRIANGLES = 0x0004;
        /// <summary>
        /// The context
        /// </summary>
        private readonly EAGLContext? _context;
        /// <summary>
        /// The position loc
        /// </summary>
        private int _positionLoc;
        /// <summary>
        /// The program
        /// </summary>
        private int _program;
        /// <summary>
        /// The vbo
        /// </summary>
        private uint _vbo;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlueGlkViewController"/> class
        /// </summary>
        /// <param name="frame">The frame</param>
        public BlueGlkViewController(CGRect frame)
        {
            _context = new EAGLContext(EAGLRenderingAPI.OpenGLES2);
            GLKView glkView = new GLKView(frame)
            {
                Context = _context,
                DrawableColorFormat = GLKViewDrawableColorFormat.RGBA8888,
                DrawableDepthFormat = GLKViewDrawableDepthFormat.Format24,
                DrawableStencilFormat = GLKViewDrawableStencilFormat.Format8,
                DrawableMultisample = GLKViewDrawableMultisample.None
            };
            base.View = glkView;
            base.PreferredFramesPerSecond = 60;
            SetupGL();
        }

        /// <summary>
        /// Gls the clear color using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glClearColor(float r, float g, float b, float a);

        /// <summary>
        /// Gls the clear using the specified mask
        /// </summary>
        /// <param name="mask">The mask</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glClear(uint mask);

        /// <summary>
        /// Gls the create shader using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The int</returns>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern int glCreateShader(uint type);

        /// <summary>
        /// Gls the shader source using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        /// <param name="count">The count</param>
        /// <param name="source">The source</param>
        /// <param name="length">The length</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glShaderSource(int shader, int count, string[] source, int[] length);

        /// <summary>
        /// Gls the compile shader using the specified shader
        /// </summary>
        /// <param name="shader">The shader</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glCompileShader(int shader);

        /// <summary>
        /// Gls the create program
        /// </summary>
        /// <returns>The int</returns>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern int glCreateProgram();

        /// <summary>
        /// Gls the attach shader using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="shader">The shader</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glAttachShader(int program, int shader);

        /// <summary>
        /// Gls the link program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glLinkProgram(int program);

        /// <summary>
        /// Gls the use program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glUseProgram(int program);

        /// <summary>
        /// Gls the get attrib location using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        /// <param name="name">The name</param>
        /// <returns>The int</returns>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern int glGetAttribLocation(int program, string name);

        /// <summary>
        /// Gls the enable vertex attrib array using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glEnableVertexAttribArray(int index);

        /// <summary>
        /// Gls the vertex attrib pointer using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="size">The size</param>
        /// <param name="type">The type</param>
        /// <param name="normalized">The normalized</param>
        /// <param name="stride">The stride</param>
        /// <param name="pointer">The pointer</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glVertexAttribPointer(int index, int size, uint type, bool normalized, int stride, IntPtr pointer);

        /// <summary>
        /// Gls the gen buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glGenBuffers(int n, out uint buffers);

        /// <summary>
        /// Gls the bind buffer using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="buffer">The buffer</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glBindBuffer(uint target, uint buffer);

        /// <summary>
        /// Gls the buffer data using the specified target
        /// </summary>
        /// <param name="target">The target</param>
        /// <param name="size">The size</param>
        /// <param name="data">The data</param>
        /// <param name="usage">The usage</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glBufferData(uint target, IntPtr size, float[] data, uint usage);

        /// <summary>
        /// Gls the draw arrays using the specified mode
        /// </summary>
        /// <param name="mode">The mode</param>
        /// <param name="first">The first</param>
        /// <param name="count">The count</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glDrawArrays(uint mode, int first, int count);

        /// <summary>
        /// Gls the delete program using the specified program
        /// </summary>
        /// <param name="program">The program</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glDeleteProgram(int program);

        /// <summary>
        /// Gls the delete buffers using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="buffers">The buffers</param>
        [DllImport("__Internal")]
        [ExcludeFromCodeCoverage]
        private static extern void glDeleteBuffers(int n, ref uint buffers);

        /// <summary>
        /// Setup the gl
        /// </summary>
        private void SetupGL()
        {
            EAGLContext.SetCurrentContext(_context);
            // Vertex shader
            string vertexShaderSrc = "attribute vec2 a_position; void main() { gl_Position = vec4(a_position, 0.0, 1.0); }";
            // Fragment shader
            string fragmentShaderSrc = "precision mediump float; void main() { gl_FragColor = vec4(1.0, 1.0, 1.0, 1.0); }";
            int vertexShader = glCreateShader(0x8B31); // GL_VERTEX_SHADER
            int fragmentShader = glCreateShader(0x8B30); // GL_FRAGMENT_SHADER
            glShaderSource(vertexShader, 1, new[] {vertexShaderSrc}, new[] {vertexShaderSrc.Length});
            glCompileShader(vertexShader);
            glShaderSource(fragmentShader, 1, new[] {fragmentShaderSrc}, new[] {fragmentShaderSrc.Length});
            glCompileShader(fragmentShader);
            _program = glCreateProgram();
            glAttachShader(_program, vertexShader);
            glAttachShader(_program, fragmentShader);
            glLinkProgram(_program);
            glUseProgram(_program);
            _positionLoc = glGetAttribLocation(_program, "a_position");
            // Triángulo centrado
            float[] vertices = new[]
            {
                0.0f, 0.5f, // Arriba
                -0.5f, -0.5f, // Izquierda
                0.5f, -0.5f // Derecha
            };
            glGenBuffers(1, out _vbo);
            glBindBuffer(GL_ARRAY_BUFFER, _vbo);
            glBufferData(GL_ARRAY_BUFFER, vertices.Length * sizeof(float), vertices, GL_STATIC_DRAW);
        }

        /// <summary>
        /// Draws the in rect using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <param name="rect">The rect</param>
        public override void DrawInRect(GLKView view, CGRect rect)
        {
            EAGLContext.SetCurrentContext(_context);
            // Fondo rojo
            glClearColor(1f, 0f, 0f, 1f);
            glClear(GL_COLOR_BUFFER_BIT);
            // Dibuja triángulo blanco
            glUseProgram(_program);
            glBindBuffer(GL_ARRAY_BUFFER, _vbo);
            glEnableVertexAttribArray(_positionLoc);
            glVertexAttribPointer(_positionLoc, 2, GL_FLOAT, false, 2 * sizeof(float), IntPtr.Zero);
            glDrawArrays(GL_TRIANGLES, 0, 3);
        }

        /// <summary>
        /// Disposes the disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        protected override void Dispose(bool disposing)
        {
            if (_vbo != 0)
            {
                glDeleteBuffers(1, ref _vbo);
                _vbo = 0;
            }

            if (_program != 0)
            {
                glDeleteProgram(_program);
                _program = 0;
            }

            _context?.Dispose();
            base.Dispose(disposing);
        }
    }
}