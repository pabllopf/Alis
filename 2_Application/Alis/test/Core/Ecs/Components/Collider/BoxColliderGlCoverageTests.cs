// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderGlCoverageTests.cs
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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Collider
{
    /// <summary>
    /// Drives the GL and physics backed paths of <see cref="BoxCollider" /> using a fake function pointer table.
    /// </summary>
    /// <seealso cref="IDisposable"/>
    public class BoxColliderGlCoverageTests : IDisposable
    {
        private static readonly FieldInfo GlField = typeof(Gl).GetField("_getProcAddress", BindingFlags.NonPublic | BindingFlags.Static);

        private static readonly MethodInfo InitializeShadersMethod = typeof(BoxCollider).GetMethod("InitializeShaders", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo OnCollisionMethod = typeof(BoxCollider).GetMethod("OnCollision", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly MethodInfo OnSeparationMethod = typeof(BoxCollider).GetMethod("OnSeparation", BindingFlags.NonPublic | BindingFlags.Instance);

        private static readonly FieldInfo FixtureListField = typeof(Alis.Core.Physic.Dynamics.Body).GetField("FixtureList", BindingFlags.NonPublic | BindingFlags.Instance);

        private static int OnCollisionEnterCalls;

        private static int OnCollisionExitCalls;

        private struct CollisionEnterSpy : IOnCollisionEnter
        {
            public void OnCollisionEnter(IGameObject other) => OnCollisionEnterCalls++;
        }

        private struct CollisionExitSpy : IOnCollisionExit
        {
            public void OnCollisionExit(IGameObject other) => OnCollisionExitCalls++;
        }

        private readonly object _savedGl;

        /// <summary>
        /// Initializes a new instance of the <see cref="BoxColliderGlCoverageTests"/> class
        /// </summary>
        public BoxColliderGlCoverageTests() => _savedGl = GlField?.GetValue(null);

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose() => GlField?.SetValue(null, _savedGl);

        private static readonly CreateProgram FakeCreateProgram = () => 1;

        private static readonly CreateShader FakeCreateShader = _ => 1;

        private static readonly ShaderSourceDel FakeShaderSource = (_, _, _, _) => { };

        private static readonly CompileShader FakeCompileShader = _ => { };

        private static readonly AttachShader FakeAttachShader = (_, _) => { };

        private static readonly LinkProgram FakeLinkProgram = _ => { };

        private static readonly GenVertexArrays FakeGenVertexArrays = (_, arrays) => arrays[0] = 2;

        private static readonly BindVertexArray FakeBindVertexArray = _ => { };

        private static readonly GenBuffers FakeGenBuffers = (_, buffers) => buffers[0] = 3;

        private static readonly BindBuffer FakeBindBuffer = (_, _) => { };

        private static readonly BufferData FakeBufferData = (_, _, _, _) => { };

        private static readonly EnableVertexAttribArrayDel FakeEnableVertexAttribArray = _ => { };

        private static readonly VertexAttribPointerDel FakeVertexAttribPointer = (_, _, _, _, _, _) => { };

        private static readonly UseProgram FakeUseProgram = _ => { };

        private static readonly DrawArrays FakeDrawArrays = (_, _, _) => { };

        private static Gl.GetProcAddressDelegate Resolver() => name => name switch
        {
            "glCreateProgram" => Marshal.GetFunctionPointerForDelegate(FakeCreateProgram),
            "glCreateShader" => Marshal.GetFunctionPointerForDelegate(FakeCreateShader),
            "glShaderSource" => Marshal.GetFunctionPointerForDelegate(FakeShaderSource),
            "glCompileShader" => Marshal.GetFunctionPointerForDelegate(FakeCompileShader),
            "glAttachShader" => Marshal.GetFunctionPointerForDelegate(FakeAttachShader),
            "glLinkProgram" => Marshal.GetFunctionPointerForDelegate(FakeLinkProgram),
            "glGenVertexArrays" => Marshal.GetFunctionPointerForDelegate(FakeGenVertexArrays),
            "glBindVertexArray" => Marshal.GetFunctionPointerForDelegate(FakeBindVertexArray),
            "glGenBuffers" => Marshal.GetFunctionPointerForDelegate(FakeGenBuffers),
            "glBindBuffer" => Marshal.GetFunctionPointerForDelegate(FakeBindBuffer),
            "glBufferData" => Marshal.GetFunctionPointerForDelegate(FakeBufferData),
            "glEnableVertexAttribArray" => Marshal.GetFunctionPointerForDelegate(FakeEnableVertexAttribArray),
            "glVertexAttribPointer" => Marshal.GetFunctionPointerForDelegate(FakeVertexAttribPointer),
            "glUseProgram" => Marshal.GetFunctionPointerForDelegate(FakeUseProgram),
            "glDrawArrays" => Marshal.GetFunctionPointerForDelegate(FakeDrawArrays),
            _ => IntPtr.Zero
        };

        private static Context BuildContext(bool previewMode)
        {
            Context context = new Context();
            if (previewMode)
            {
                context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            }

            return context;
        }

        private static GameObject BuildEntity() => new Scene().CreateFromObjects(new object[] { new Transform(new Vector2F(0f, 0f), 0f) });

        private static BoxCollider BuildCollider(Context context)
        {
            BoxCollider collider = new BoxCollider
            {
                Context = context,
                SizeOfTexture = new Vector2F(16f, 16f),
                BodyType = BodyType.Static,
                Restitution = 0.5f,
                Friction = 0.5f,
                FixedRotation = false,
                Mass = 1f,
                IgnoreGravity = false,
                LinearVelocity = new Vector2F(0f, 0f),
                IsTrigger = false
            };
            return collider;
        }

        /// <summary>
        /// Initializes the shaders with the desktop shader variant
        /// </summary>
        [Fact]
        public void InitializeShaders_DesktopContext_FakeGl_Executes()
        {
            Gl.Initialize(Resolver());
            BoxCollider collider = BuildCollider(BuildContext(false));

            InitializeShadersMethod?.Invoke(collider, null);
        }

        /// <summary>
        /// Initializes the shaders with the OpenGL ES shader variant
        /// </summary>
        [Fact]
        public void InitializeShaders_PreviewModeContext_FakeGl_Executes()
        {
            Gl.Initialize(Resolver());
            BoxCollider collider = BuildCollider(BuildContext(true));

            InitializeShadersMethod?.Invoke(collider, null);
        }

        /// <summary>
        /// Renders an uninitialized collider and initializes the shaders inside the render path
        /// </summary>
        [Fact]
        public void Render_FirstCall_InitializesAndDraws()
        {
            Gl.Initialize(Resolver());
            Component.RegisterComponent<Transform>();
            GameObject entity = BuildEntity();
            BoxCollider collider = BuildCollider(BuildContext(false));

            collider.Render(entity, new Vector2F(0f, 0f), new Vector2F(32f, 32f), 1f);
        }

        /// <summary>
        /// Renders an initialized collider and skips the shader initialization
        /// </summary>
        [Fact]
        public void Render_SecondCall_SkipsInitialization()
        {
            Gl.Initialize(Resolver());
            Component.RegisterComponent<Transform>();
            GameObject entity = BuildEntity();
            BoxCollider collider = BuildCollider(BuildContext(false));

            collider.Render(entity, new Vector2F(0f, 0f), new Vector2F(32f, 32f), 1f);
            collider.Render(entity, new Vector2F(0f, 0f), new Vector2F(32f, 32f), 1f);
        }

        /// <summary>
        /// Creates a rectangle body inside the physics world on start
        /// </summary>
        [Fact]
        public void OnStart_WithTransform_CreatesRectangleBody()
        {
            Component.RegisterComponent<Transform>();
            Context context = BuildContext(false);
            BoxCollider collider = BuildCollider(context);
            GameObject entity = BuildEntity();

            collider.OnStart(entity);

            Assert.NotNull(collider.Body);
            Assert.Equal(entity, collider.Body.Tag);
        }

        /// <summary>
        /// Removes the body from the physics world on exit
        /// </summary>
        [Fact]
        public void OnExit_WithBody_RemovesBody()
        {
            Component.RegisterComponent<Transform>();
            Context context = BuildContext(false);
            BoxCollider collider = BuildCollider(context);
            GameObject entity = BuildEntity();
            collider.OnStart(entity);

            collider.OnExit(entity);

            Assert.Null(collider.Body);
        }

        /// <summary>
        /// Dispatches a collision to a component implementing IOnCollisionEnter
        /// </summary>
        [Fact]
        public void OnCollision_WithCollisionEnterComponent_Executes()
        {
            Component.RegisterComponent<Transform>();
            Component.RegisterComponent<CollisionEnterSpy>();
            Component.RegisterComponent<CollisionExitSpy>();
            OnCollisionEnterCalls = 0;
            Context context = BuildContext(false);
            Scene scene = new Scene();
            GameObject entityA = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(0f, 0f), 0f), new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1f, 1f) }, new CollisionEnterSpy(), new CollisionExitSpy() });
            GameObject entityB = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(2f, 0f), 0f), new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1f, 1f) }, new CollisionEnterSpy(), new CollisionExitSpy() });
            BoxCollider colliderA = entityA.Get<BoxCollider>();
            BoxCollider colliderB = entityB.Get<BoxCollider>();
            colliderA.OnStart(entityA);
            colliderB.OnStart(entityB);

            Fixture fixtureA = ((IList<Fixture>) FixtureListField?.GetValue(colliderA.Body))?[0];
            Fixture fixtureB = ((IList<Fixture>) FixtureListField?.GetValue(colliderB.Body))?[0];

            OnCollisionMethod?.Invoke(colliderA, new object[] { fixtureA, fixtureB, null });

            Assert.Equal(1, OnCollisionEnterCalls);

            OnCollisionMethod?.Invoke(colliderA, new object[] { fixtureB, fixtureA, null });

            Assert.Equal(2, OnCollisionEnterCalls);
        }

        /// <summary>
        /// Dispatches a separation to a component implementing IOnCollisionExit
        /// </summary>
        [Fact]
        public void OnSeparation_WithCollisionExitComponent_Executes()
        {
            Component.RegisterComponent<Transform>();
            Component.RegisterComponent<CollisionEnterSpy>();
            Component.RegisterComponent<CollisionExitSpy>();
            OnCollisionExitCalls = 0;
            Context context = BuildContext(false);
            Scene scene = new Scene();
            GameObject entityA = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(0f, 0f), 0f), new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1f, 1f) }, new CollisionEnterSpy(), new CollisionExitSpy() });
            GameObject entityB = scene.CreateFromObjects(new object[] { new Transform(new Vector2F(2f, 0f), 0f), new BoxCollider { Context = context, SizeOfTexture = new Vector2F(1f, 1f) }, new CollisionEnterSpy(), new CollisionExitSpy() });
            BoxCollider colliderA = entityA.Get<BoxCollider>();
            BoxCollider colliderB = entityB.Get<BoxCollider>();
            colliderA.OnStart(entityA);
            colliderB.OnStart(entityB);

            Fixture fixtureA = ((IList<Fixture>) FixtureListField?.GetValue(colliderA.Body))?[0];
            Fixture fixtureB = ((IList<Fixture>) FixtureListField?.GetValue(colliderB.Body))?[0];

            OnSeparationMethod?.Invoke(colliderA, new object[] { fixtureA, fixtureB, null });

            Assert.Equal(1, OnCollisionExitCalls);

            OnSeparationMethod?.Invoke(colliderA, new object[] { fixtureB, fixtureA, null });

            Assert.Equal(2, OnCollisionExitCalls);
        }
    }
}