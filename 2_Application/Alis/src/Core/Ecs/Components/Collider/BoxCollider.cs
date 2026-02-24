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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="IBoxCollider" />
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    public class BoxCollider : IBoxCollider
    {
        // Vértices del triángulo (posición 2D)
        /// <summary>
        ///     The vertices
        /// </summary>
        private static readonly float[] Vertices =
        {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f, 0.5f
        };


        /// <summary>
        ///     The shader program
        /// </summary>
        private uint shaderProgram;

        /// <summary>
        ///     The vao
        /// </summary>
        private uint vao;

        /// <summary>
        ///     The vbo
        /// </summary>
        private uint vbo;

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

        public bool IsTrigger { get; set; }

        /// <summary>
        ///     Gets or sets the value of the width
        /// </summary>

        public float Width { get; set; }

        /// <summary>
        ///     Gets or sets the value of the height
        /// </summary>

        public float Height { get; set; }

        /// <summary>
        ///     Gets or sets the value of the rotation
        /// </summary>

        public float Rotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the relative position
        /// </summary>

        public Vector2F RelativePosition { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body
        /// </summary>

        public Physic.Dynamics.Body Body { get; set; }

        /// <summary>
        ///     Gets or sets the value of the auto tilling
        /// </summary>

        public bool AutoTilling { get; set; }

        /// <summary>
        ///     Gets or sets the value of the body type
        /// </summary>

        public BodyType BodyType { get; set; }

        /// <summary>
        ///     Gets or sets the value of the restitution
        /// </summary>

        public float Restitution { get; set; }

        /// <summary>
        ///     Gets or sets the value of the friction
        /// </summary>

        public float Friction { get; set; }

        /// <summary>
        ///     Gets or sets the value of the fixed rotation
        /// </summary>

        public bool FixedRotation { get; set; }

        /// <summary>
        ///     Gets or sets the value of the mass
        /// </summary>

        public float Mass { get; set; }

        /// <summary>
        ///     Gets or sets the value of the gravity scale
        /// </summary>

        public bool IgnoreGravity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the linear velocity
        /// </summary>

        public Vector2F LinearVelocity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the angular velocity
        /// </summary>

        public float AngularVelocity { get; set; }

        /// <summary>
        ///     Gets or sets the value of the is init
        /// </summary>
        private bool IsInit { get; set; }

        /// <summary>
        ///     Gets or sets the value of the shader program
        /// </summary>

        public uint ShaderProgram { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the size
        /// </summary>

        public Vector2F SizeOfTexture { get; set; }


        /// <summary>
        ///     Gets or sets the value of the this game object
        /// </summary>
        private IGameObject ThisGameObject { get; set; }


        /// <summary>
        ///     Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self)
        {
            if (self.Has<Transform>())
            {
                ref Transform transform = ref self.Get<Transform>();

                if (Body is not null)
                {
                    transform.Position = Body.Position;
                    transform.Rotation = Body.Rotation;
                }
            }
        }

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnStart(IGameObject self)
        {
            if (self.Has<Transform>())
            {
                ref Transform transform = ref self.Get<Transform>();

                Body = Context.PhysicManager.WorldPhysic.CreateRectangle(
                    SizeOfTexture.X * transform.Scale.X,
                    SizeOfTexture.Y * transform.Scale.Y,
                    1.0f,
                    new Vector2F(transform.Position.X + RelativePosition.X, transform.Position.Y + RelativePosition.Y),
                    Rotation,
                    BodyType);

                Body.SetRestitution(Restitution);
                Body.SetFriction(Friction);
                Body.FixedRotation = FixedRotation;
                Body.Mass = Mass;
                Body.SleepingAllowed = false;
                Body.IsBullet = false;
                Body.IgnoreGravity = IgnoreGravity;
                Body.LinearVelocity = LinearVelocity;
                Body.Awake = true;
                Body.SetIsSensor(IsTrigger);

                ThisGameObject = (GameObject) self;
                Body.Tag = self;

                Body.OnCollision += OnCollision;
                Body.OnSeparation += OnSeparation;
            }
        }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        ///     Ons the exit using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnExit(IGameObject self)
        {
            if (Body != null)
            {
                Context.PhysicManager.WorldPhysic.Remove(Body);
                Body = null;
            }
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

            if (fixtureGameObject.Equals(ThisGameObject) && fixtureBGameObject.Has<BoxCollider>())
            {
                foreach (ComponentId component in fixtureBGameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnCollisionEnter).IsAssignableFrom(componentType))
                    {
                        IOnCollisionEnter onPressKey = (IOnCollisionEnter) fixtureBGameObject.Get(componentType);
                        onPressKey.OnCollisionEnter(ThisGameObject);
                    }
                }
            }
            else if (fixtureBGameObject.Equals(ThisGameObject) && fixtureGameObject.Has<BoxCollider>())
            {
                foreach (ComponentId component in fixtureGameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnCollisionEnter).IsAssignableFrom(componentType))
                    {
                        IOnCollisionEnter onPressKey = (IOnCollisionEnter) fixtureGameObject.Get(componentType);
                        onPressKey.OnCollisionEnter(ThisGameObject);
                    }
                }
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


            if (fixtureGameObject.Equals(ThisGameObject) && fixtureBGameObject.Has<BoxCollider>())
            {
                foreach (ComponentId component in fixtureBGameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnCollisionExit).IsAssignableFrom(componentType))
                    {
                        IOnCollisionExit onPressKey = (IOnCollisionExit) fixtureBGameObject.Get(componentType);
                        onPressKey.OnCollisionExit(ThisGameObject);
                    }
                }
            }
            else if (fixtureBGameObject.Equals(ThisGameObject) && fixtureGameObject.Has<BoxCollider>())
            {
                foreach (ComponentId component in fixtureGameObject.ComponentTypes)
                {
                    Type componentType = component.Type;
                    if (typeof(IOnCollisionExit).IsAssignableFrom(componentType))
                    {
                        IOnCollisionExit onPressKey = (IOnCollisionExit) fixtureGameObject.Get(componentType);
                        onPressKey.OnCollisionExit(ThisGameObject);
                    }
                }
            }
        }


        /// <summary>
        ///     Initializes the shaders
        /// </summary>
        private void InitializeShaders()
        {
            string version = "";
            if (Context.Setting.Graphic.PreviewMode)
            {
                version = "#version 300 es";
            }
            else
            {
                version = "#version 330 core";
            }


            string VertexShaderSource = version + @"
            layout(location = 0) in vec2 in_xy;
            void main() {
            gl_Position = vec4(in_xy, 0.0, 1.0);
        }";


            string FragmentShaderSource = version + @"
            precision mediump float;
            out vec4 outColor;
            void main() {
            outColor = vec4(1.0, 0.0, 0.0, 1.0);
        }";


            // Crear y compilar shaders
            shaderProgram = Gl.GlCreateProgram();
            uint vert = Gl.GlCreateShader(ShaderType.VertexShader);
            Gl.ShaderSource(vert, VertexShaderSource);
            Gl.GlCompileShader(vert);
            Gl.GlAttachShader(shaderProgram, vert);

            uint frag = Gl.GlCreateShader(ShaderType.FragmentShader);
            Gl.ShaderSource(frag, FragmentShaderSource);
            Gl.GlCompileShader(frag);

            Gl.GlAttachShader(shaderProgram, frag);

            Gl.GlLinkProgram(shaderProgram);


            // Crear VAO y VBO
            vao = Gl.GenVertexArray();
            Gl.GlBindVertexArray(vao);
            uint[] vbos = new uint[1];
            Gl.GlGenBuffers(1, vbos);
            vbo = vbos[0];
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);

            GCHandle handle = GCHandle.Alloc(Vertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(Vertices.Length * sizeof(float)), pointer, BufferUsageHint.StaticDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }


            Gl.EnableVertexAttribArray(0);
            Gl.VertexAttribPointer(0, 2, VertexAttribPointerType.Float, false, 2 * sizeof(float), IntPtr.Zero);
            Gl.GlBindVertexArray(0);
        }

        /// <summary>
        ///     Renders the gameobject
        /// </summary>
        /// <param name="gameobject">The gameobject</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        public void Render(GameObject gameobject, Vector2F cameraPosition, Vector2F cameraResolution, float pixelsPerMeter)
        {
            if (!IsInit)
            {
                InitializeShaders();
                IsInit = true;
            }

            RenderBoxCollider(gameobject, cameraPosition, cameraResolution, pixelsPerMeter);
        }

        /// <summary>
        ///     Renders the box collider using the specified gameobject
        /// </summary>
        /// <param name="gameobject">The gameobject</param>
        /// <param name="cameraPosition">The camera position</param>
        /// <param name="cameraResolution">The camera resolution</param>
        /// <param name="pixelsPerMeter">The pixels per meter</param>
        private void RenderBoxCollider(
            GameObject gameobject,
            Vector2F cameraPosition,
            Vector2F cameraResolution,
            float pixelsPerMeter)
        {
            ref Transform transform = ref gameobject.Get<Transform>();

            Vector2F colliderPosition = transform.Position;
            Vector2F colliderScale = transform.Scale;
            // float colliderRotation = transform.Rotation; // No se usa

            float posX = colliderPosition.X * pixelsPerMeter;
            float posY = colliderPosition.Y * pixelsPerMeter;
            float width = SizeOfTexture.X * pixelsPerMeter * colliderScale.X;
            float height = SizeOfTexture.Y * pixelsPerMeter * colliderScale.Y;

            int x = (int) (posX - cameraPosition.X * pixelsPerMeter + cameraResolution.X / 2);
            int y = (int) (posY - cameraPosition.Y * pixelsPerMeter + cameraResolution.Y / 2);

            float rectangleX = (int) (x - width / 2);
            float rectangleY = (int) (y - height / 2);
            float rectangleW = (int) width;
            float rectangleH = (int) height;

            // Calcular los vértices en NDC usando rectangleX, rectangleY, rectangleW, rectangleH
            float left = rectangleX / cameraResolution.X * 2.0f - 1.0f;
            float right = (rectangleX + rectangleW) / cameraResolution.X * 2.0f - 1.0f;
            float top = rectangleY / cameraResolution.Y * 2.0f - 1.0f;
            float bottom = (rectangleY + rectangleH) / cameraResolution.Y * 2.0f - 1.0f;

            // Vértices del rectángulo (en sentido antihorario: bottom-left, top-left, top-right, bottom-right)
            float[] rectVertices = new[]
            {
                left, bottom, // bottom-left
                left, top, // top-left
                right, top, // top-right
                right, bottom // bottom-right
            };

            Gl.GlUseProgram(shaderProgram);
            Gl.GlBindVertexArray(vao);

            // Actualizar VBO dinámicamente (sin unsafe)
            Gl.GlBindBuffer(BufferTarget.ArrayBuffer, vbo);
            GCHandle handle = GCHandle.Alloc(rectVertices, GCHandleType.Pinned);
            try
            {
                IntPtr pointer = handle.AddrOfPinnedObject();
                Gl.GlBufferData(BufferTarget.ArrayBuffer, new IntPtr(rectVertices.Length * sizeof(float)), pointer, BufferUsageHint.DynamicDraw);
            }
            finally
            {
                if (handle.IsAllocated)
                {
                    handle.Free();
                }
            }

            // Dibujar solo los bordes del rectángulo
            Gl.GlDrawArrays(PrimitiveType.LineLoop, 0, 4);
            Gl.GlBindVertexArray(0);
        }
    }
}