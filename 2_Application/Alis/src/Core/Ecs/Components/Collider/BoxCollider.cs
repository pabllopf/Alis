// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxCollider.cs
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
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Ecs.Components.Collider
{
    /// <summary>
    /// The box collider class
    /// </summary>
    /// <seealso cref="IBoxCollider"/>
    /// <seealso cref="IInitable"/>
    /// <seealso cref="IGameObjectComponent"/>
    public class BoxCollider : IBoxCollider, IInitable, IGameObjectComponent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BoxCollider"/> class
        /// </summary>
        public BoxCollider()
        {
            Width = 10;
            Height = 10;
            Rotation = 0;
            RelativePosition = new Vector2F(0, 0);
            AutoTilling = false;
            BodyType = BodyType.Static;
            Restitution = 0.5f;
            Friction = 0.5f;
            FixedRotation = false;
            Mass = 1.0f;
            IgnoreGravity = false;
            LinearVelocity = new Vector2F(0, 0);
            AngularVelocity = 0;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider" /> class
        /// </summary>
        /// <param name="isTrigger">The is trigger</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="rotation">The rotation</param>
        /// <param name="relativePosition">The relative position</param>
        /// <param name="autoTilling">The auto tilling</param>
        /// <param name="bodyType">The body type</param>
        /// <param name="restitution">The restitution</param>
        /// <param name="friction">The friction</param>
        /// <param name="fixedRotation">The fixed rotation</param>
        /// <param name="mass">The mass</param>
        /// <param name="ignoreGravity">The ignore gravity</param>
        /// <param name="linearVelocity">The linear velocity</param>
        /// <param name="angularVelocity">The angular velocity</param>
        [JsonConstructor]
        public BoxCollider(
            bool isTrigger,
            float width,
            float height,
            float rotation,
            Vector2F relativePosition,
            bool autoTilling,
            BodyType bodyType,
            float restitution,
            float friction,
            bool fixedRotation,
            float mass,
            bool ignoreGravity,
            Vector2F linearVelocity,
            float angularVelocity)
        {
            IsTrigger = isTrigger;
            Width = width;
            Height = height;
            Rotation = rotation;
            RelativePosition = relativePosition;
            AutoTilling = autoTilling;
            BodyType = bodyType;
            Restitution = restitution;
            Friction = friction;
            FixedRotation = fixedRotation;
            Mass = mass;
            IgnoreGravity = ignoreGravity;
            LinearVelocity = linearVelocity;
            AngularVelocity = angularVelocity;
        }

        /// <summary>
        ///     Gets or sets the value of the is trigger
        /// </summary>
        [JsonPropertyName("_IsTrigger_")]
        public bool IsTrigger { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>
        [JsonPropertyName("_Width_")]
        public float Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>
        [JsonPropertyName("_Height_")]
        public float Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the rotation
        /// </summary>
        [JsonPropertyName("_Rotation_")]
        public float Rotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>
        [JsonPropertyName("_RelativePosition_")]
        public Vector2F RelativePosition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body
        /// </summary>
        [JsonIgnore]
        public Physic.Dynamics.Body Body { get; set; }

        /// <summary>
        ///     Gets or sets the value of the auto tilling
        /// </summary>
        [JsonPropertyName("_AutoTilling_")]
        public bool AutoTilling { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>
        [JsonPropertyName("_BodyType_")]
        public BodyType BodyType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>
        [JsonPropertyName("_Restitution_")]
        public float Restitution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>
        [JsonPropertyName("_Friction_")]
        public float Friction { get; set; }

        /// <summary>
        ///     Gets or sets the value of the fixed rotation
        /// </summary>
        [JsonPropertyName("_FixedRotation_")]
        public bool FixedRotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mass
        /// </summary>
        [JsonPropertyName("_Mass_")]
        public float Mass { get; set; }

        /// <summary>
        ///     Gets or sets the value of the gravity scale
        /// </summary>
        [JsonPropertyName("_IgnoreGravity_")]
        public bool IgnoreGravity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the linear velocity
        /// </summary>
        [JsonPropertyName("_LinearVelocity_")]
        public Vector2F LinearVelocity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the angular velocity
        /// </summary>
        [JsonPropertyName("_AngularVelocity_")]
        public float AngularVelocity { get; set; }

        private bool IsInit { get; set; } = false;

        /// <summary>
        ///     Gets or sets the value of the shader program
        /// </summary>
        [JsonIgnore]
        public uint ShaderProgram { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>
        [JsonIgnore]
        public Vector2F SizeOfTexture { get; set; }

        /// <summary>
        ///     Gets or sets the value of the vao
        /// </summary>
        [JsonIgnore]
        public uint Vao { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the vbo
        /// </summary>
        [JsonIgnore]
        public uint Vbo { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the ebo
        /// </summary>
        [JsonIgnore]
        public uint Ebo { get; private set; }

        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self)
        {
        }

        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Update(IGameObject self)
        {
        }
        
                /// <summary>
        ///     Initializes the shaders
        /// </summary>
        private void InitializeShaders()
        {
             float[] vertices =
            {
                -0.5f, 0.5f, 0.0f, // Top-left
                0.5f, 0.5f, 0.0f, // Top-right
                0.5f, -0.5f, 0.0f, // Bottom-right
                -0.5f, -0.5f, 0.0f // Bottom-left
            };

            uint[] indices =
            {
                0, 1, 2, // First triangle
                2, 3, 0 // Second triangle
            };

            Vbo = Gl.GenBuffer();
            Vao = Gl.GenVertexArray();
            uint ebo = Gl.GenBuffer();

            Gl.GlBindVertexArray(Vao);

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            Gl.GlBindBuffer(BufferTarget.ElementArrayBuffer, ebo);
            handle = GCHandle.Alloc(indices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ElementArrayBuffer, new IntPtr(indices.Length * sizeof(uint)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            string vertexShaderSource = @"
              #version 330 core
              layout (location = 0) in vec3 aPos;
              void main()
              {
                  gl_Position = vec4(aPos, 1.0);
              }
          ";

            string fragmentShaderSource = @"
              #version 330 core
              out vec4 FragColor;
              void main()
              {
                  FragColor = vec4(1.0f, 0.0f, 0.0f, 1.0f); // Red color
              }
          ";

            uint vertexShader = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vertexShader, vertexShaderSource);
            Gl.GlCompileShader(vertexShader);

            uint fragmentShader = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(fragmentShader, fragmentShaderSource);
            Gl.GlCompileShader(fragmentShader);

            ShaderProgram = Gl.GlCreateProgram();
            Gl.GlAttachShader(ShaderProgram, vertexShader);
            Gl.GlAttachShader(ShaderProgram, fragmentShader);
            Gl.GlLinkProgram(ShaderProgram);

            Gl.GlBindVertexArray(Vao);
            Gl.GlUseProgram(ShaderProgram);

            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), IntPtr.Zero);
        }

        public void Render(GameObject boxColliderGameobject, Vector2F valuePosition, Vector2F valueResolution, float pixelsPerMeter)
        {
            if (!IsInit)
            {
                InitializeShaders();
                IsInit = true;
            }
            
            Gl.GlUseProgram(ShaderProgram);
            Gl.GlBindVertexArray(Vao);
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
            
            Vector2F pos = new Vector2F(0, 0);
            Vector2F size = new Vector2F(1, 1);
            
            
            // Update the vertex positions based on the given position and size
            float[] vertices =
            {
                pos.X - size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-left
                pos.X + size.X / 2, pos.Y + size.Y / 2, 0.0f, // Top-right
                pos.X + size.X / 2, pos.Y - size.Y / 2, 0.0f, // Bottom-right
                pos.X - size.X / 2, pos.Y - size.Y / 2, 0.0f // Bottom-left
            };

            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, Vbo);
            GCHandle handle = GCHandle.Alloc(vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Line);
            Gl.GlDrawElements(PrimitiveType.LineLoop, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
            Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Fill);
        }

       
    }
}