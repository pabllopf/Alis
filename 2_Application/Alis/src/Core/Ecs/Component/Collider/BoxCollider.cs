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
using Alis.Builder.Core.Ecs.Component.Collider;
using Alis.Core.Aspect.Data.Json;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Entity;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Ecs.Component.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="ACollider" />
    public class BoxCollider : ACollider, IHasBuilder<BoxColliderBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BoxCollider" /> class
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
        
        /// <summary>
        /// Gets or sets the value of the shader program
        /// </summary>
        [JsonIgnore]
        public uint ShaderProgram { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the size
        /// </summary>
        [JsonIgnore]
        public Vector2F SizeOfTexture { get; set; }
        
        /// <summary>
        /// Gets or sets the value of the vao
        /// </summary>
        [JsonIgnore]
        public uint Vao { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the vbo
        /// </summary>
        [JsonIgnore]
        public uint Vbo { get; private set; }
        
        /// <summary>
        /// Gets or sets the value of the ebo
        /// </summary>
        [JsonIgnore]
        public uint Ebo { get; private set; }
        
        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxColliderBuilder Builder() => new BoxColliderBuilder();

        /// <summary>
        ///     Inits this instance
        /// </summary>
        public override void OnInit()
        {
            SetupBuffers();
        }
        

        private void SetupBuffers()
        {
            int windowWidth = 800;
            int windowHeight = 800;

            float scaleX = SizeOfTexture.X / windowWidth;
            float scaleY = SizeOfTexture.Y / windowHeight;

            float[] vertices =
            {
                1 * scaleX, 1 * scaleY, 0.0f, 1.0f, 0.0f,
                1 * scaleX, -1 * scaleY, 0.0f, 1.0f, 1.0f,
                -1 * scaleX, -1 * scaleY, 0.0f, 0.0f, 1.0f,
                -1 * scaleX, 1f * scaleY, 0.0f, 0.0f, 0.0f
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

        /// <summary>
        ///     Awakes this instance
        /// </summary>
        public override void OnAwake()
        {
            Body = Context.PhysicManager.World.CreateRectangle(
                Width * GameObject.Transform.Scale.X,
                Height * GameObject.Transform.Scale.Y,
                1.0f,
                new Vector2F(GameObject.Transform.Position.X + RelativePosition.X, GameObject.Transform.Position.Y + RelativePosition.Y),
                Rotation,
                BodyType);

            Body.SetRestitution(Restitution);
            Body.SetFriction(Friction);
            Body.FixedRotation = FixedRotation;
            Body.Mass = Mass;
            Body.SleepingAllowed = false;
            Body.IsBullet = true;
            Body.IgnoreGravity = IgnoreGravity;
            Body.LinearVelocity = LinearVelocity;
            Body.Awake = true;
            Body.SetIsSensor(IsTrigger);
            Body.Tag = GameObject;
            Context.GraphicManager.Attach(this);

            Body.OnCollision += OnCollision;
            Body.OnSeparation += OnSeparation;
        }

        /// <summary>
        ///     Describes whether this instance on collision
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="contact">The contact</param>
        /// <returns>The bool</returns>
        private bool OnCollision(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.GetBody.Tag;
            GameObject fixtureBGameObject = (GameObject) fixtureB.GetBody.Tag;

            if (fixtureGameObject.Equals(GameObject) && fixtureBGameObject.Contains<BoxCollider>())
            {
                fixtureBGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }
            else if (fixtureBGameObject.Equals(GameObject) && fixtureGameObject.Contains<BoxCollider>())
            {
                fixtureGameObject.Components.ForEach(i => i.OnCollisionEnter(GameObject));
            }

            return true;
        }

        /// <summary>
        ///     Ons the separation using the specified fixture a
        /// </summary>
        /// <param name="fixtureA">The fixture</param>
        /// <param name="fixtureB">The fixture</param>
        /// <param name="contact">The contact</param>
        private void OnSeparation(Fixture fixtureA, Fixture fixtureB, Contact contact)
        {
            GameObject fixtureGameObject = (GameObject) fixtureA.GetBody.Tag;
            GameObject fixtureBGameObject = (GameObject) fixtureB.GetBody.Tag;

            if (fixtureGameObject.Equals(GameObject) && fixtureBGameObject.Contains<BoxCollider>())
            {
                fixtureBGameObject.Components.ForEach(i => i.OnCollisionExit(GameObject));
            }
            else if (fixtureBGameObject.Equals(GameObject) && fixtureGameObject.Contains<BoxCollider>())
            {
                fixtureGameObject.Components.ForEach(i => i.OnCollisionExit(GameObject));
            }
        }

        /// <summary>
        ///     Starts this instance
        /// </summary>
        public override void OnStart()
        {
        }

        /// <summary>
        ///     Before the update
        /// </summary>
        public override void OnBeforeUpdate()
        {
            //GameObject.Transform = new Transform(Body.Position, Body.Rotation, GameObject.Transform.Scale);
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public override void OnUpdate()
        {
            GameObject.Transform = new Transform(Body.Position, Body.Rotation, GameObject.Transform.Scale);

            // If the collider contains a camera, update the camera position
            if (GameObject.Contains<Camera>())
            {
                Camera camera = GameObject.Get<Camera>();
                camera.Position.X = GameObject.Transform.Position.X;
                camera.Position.Y = GameObject.Transform.Position.Y;
            }
        }

        /// <summary>
        ///     Draws this instance
        /// </summary>
        public override void OnDraw()
        {
        }

        /// <summary>
        ///     Ons the exit
        /// </summary>
        public override void OnExit()
        {
            Context.GraphicManager.UnAttach(this);
            Context.PhysicManager.World.Remove(Body);
        }

        /// <summary>
        ///     Renders the renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <param name="debugColor">The debug color</param>
        public void Render(IntPtr renderer, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter, Color debugColor)
        {
        }

        /// <summary>
        ///     Describes whether this instance is visible
        /// </summary>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        /// <returns>The bool</returns>
        public bool IsVisible(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            Vector2F colliderPosition = GameObject.Transform.Position;
            Vector2F colliderSize = new Vector2F(Width, Height);
            float colliderRotation = GameObject.Transform.Rotation;

            float colliderPosX = colliderPosition.X * pixelsPerMeter;
            float colliderPosY = colliderPosition.Y * pixelsPerMeter;

            float cameraLeft = cameraPosition.X * pixelsPerMeter - cameraResolution.X / 2;
            float cameraRight = cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2;
            float cameraTop = cameraPosition.Y * pixelsPerMeter - cameraResolution.Y / 2;
            float cameraBottom = cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2;

            // Calculate the bounding box of the rotated collider
            float halfWidth = colliderSize.X / 2;
            float halfHeight = colliderSize.Y / 2;
            float cos = (float) Math.Cos(colliderRotation);
            float sin = (float) Math.Sin(colliderRotation);

            float[] cornersX = new float[4];
            float[] cornersY = new float[4];

            cornersX[0] = colliderPosX + (-halfWidth * cos - -halfHeight * sin);
            cornersY[0] = colliderPosY + (-halfWidth * sin + -halfHeight * cos);
            cornersX[1] = colliderPosX + (halfWidth * cos - -halfHeight * sin);
            cornersY[1] = colliderPosY + (halfWidth * sin + -halfHeight * cos);
            cornersX[2] = colliderPosX + (halfWidth * cos - halfHeight * sin);
            cornersY[2] = colliderPosY + (halfWidth * sin + halfHeight * cos);
            cornersX[3] = colliderPosX + (-halfWidth * cos - halfHeight * sin);
            cornersY[3] = colliderPosY + (-halfWidth * sin + halfHeight * cos);

            float colliderLeft = Min(cornersX);
            float colliderRight = Max(cornersX);
            float colliderTop = Min(cornersY);
            float colliderBottom = Max(cornersY);

            return (colliderRight > cameraLeft) && (colliderLeft < cameraRight) && (colliderBottom > cameraTop) && (colliderTop < cameraBottom);
        }

        /// <summary>
        ///     Mins the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The min</returns>
        private float Min(float[] cornersX)
        {
            float min = cornersX[0];

            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] < min)
                {
                    min = cornersX[i];
                }
            }

            return min;
        }

        /// <summary>
        ///     Maxes the corners x
        /// </summary>
        /// <param name="cornersX">The corners</param>
        /// <returns>The max</returns>
        private float Max(float[] cornersX)
        {
            float max = cornersX[0];

            for (int i = 1; i < cornersX.Length; i++)
            {
                if (cornersX[i] > max)
                {
                    max = cornersX[i];
                }
            }

            return max;
        }

      public void Render(Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter, Color debugColor)
       {
           Vector2F position = GameObject.Transform.Position;
           Vector2F scale = GameObject.Transform.Scale;
           Vector2F colliderSize = new Vector2F(Width, Height);
           float spriteRotation = GameObject.Transform.Rotation;
           Vector2F windowSize = Context.Setting.Graphic.WindowSize;
       
           Gl.GlBindVertexArray(Vao);
           Gl.GlUseProgram(ShaderProgram);
       
           Gl.EnableVertexAttribArray(0);
       
           // Calculate the offset based on the camera position and resolution
           float offsetX = (position.X - cameraPosition.X) * pixelsPerMeter / cameraResolution.X;
           float offsetY = (position.Y - cameraPosition.Y) * pixelsPerMeter / cameraResolution.Y;
       
           // Calculate the scale based on the window size and pixels per meter
           float scaleX = scale.X * pixelsPerMeter / windowSize.X;
           float scaleY = scale.Y * pixelsPerMeter / windowSize.Y;
       
           // Update the vertex positions based on the given position and size
           float[] vertices =
           {
               offsetX - colliderSize.X / 2 * scaleX, offsetY + colliderSize.Y / 2 * scaleY, 0.0f, // Top-left
               offsetX + colliderSize.X / 2 * scaleX, offsetY + colliderSize.Y / 2 * scaleY, 0.0f, // Top-right
               offsetX + colliderSize.X / 2 * scaleX, offsetY - colliderSize.Y / 2 * scaleY, 0.0f, // Bottom-right
               offsetX - colliderSize.X / 2 * scaleX, offsetY - colliderSize.Y / 2 * scaleY, 0.0f  // Bottom-left
           };
       
           uint[] indices =
           {
               0, 1, 2, // First triangle
               2, 3, 0  // Second triangle
           };
       
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
       
           Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Line);
           Gl.GlDrawElements(PrimitiveType.LineLoop, 6, DrawElementsType.UnsignedInt, IntPtr.Zero);
           Gl.GlPolygonMode(MaterialFace.FrontAndBack, PolygonModeEnum.Fill);
       }
    }
}