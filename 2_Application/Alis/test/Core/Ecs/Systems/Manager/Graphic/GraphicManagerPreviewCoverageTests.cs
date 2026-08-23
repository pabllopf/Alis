// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerPreviewCoverageTests.cs
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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Graphic;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Context = Alis.Core.Ecs.Systems.Scope.Context;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     Exercises the GraphicManager preview and debug rendering paths with fake OpenGL
    ///     function pointers.
    /// </summary>
    public class GraphicManagerPreviewCoverageTests : IDisposable
    {
        /// <summary>
        ///     The fake clear color delegate reference
        /// </summary>
        private static readonly ClearColor FakeClearColorDelegate = FakeClearColor;

        /// <summary>
        ///     The fake clear delegate reference
        /// </summary>
        private static readonly Clear FakeClearDelegate = FakeClear;

        /// <summary>
        ///     The fake clear color delegate body
        /// </summary>
        /// <param name="r">The r</param>
        /// <param name="g">The g</param>
        /// <param name="b">The b</param>
        /// <param name="a">The a</param>
        private static void FakeClearColor(float r, float g, float b, float a)
        {
        }

        /// <summary>
        ///     The fake clear delegate body
        /// </summary>
        /// <param name="mask">The mask</param>
        private static void FakeClear(ClearBufferMasks mask)
        {
        }

        /// <summary>
        ///     The fake proc address resolver
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The function pointer</returns>
        private static IntPtr FakeProcAddress(string name)
        {
            switch (name)
            {
                case "glClearColor": return Marshal.GetFunctionPointerForDelegate(FakeClearColorDelegate);
                case "glClear": return Marshal.GetFunctionPointerForDelegate(FakeClearDelegate);
                default: return IntPtr.Zero;
            }
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Creates a context with preview mode enabled and a scene as the current world
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The context</returns>
        private static Context CreatePreviewContext(Alis.Core.Ecs.Scene scene)
        {
            Setting setting = new Setting
            {
                Graphic = new GraphicSetting { PreviewMode = true }
            };
            Context context = new Context(setting);
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        /// <summary>
        ///     Verifies that the init skips graphics initialization in preview mode.
        /// </summary>
        [Fact]
        public void OnInit_InPreviewMode_SkipsInitialization()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreatePreviewContext(scene);
            GraphicManager manager = new GraphicManager(context);
            manager.OnInit();
        }

        /// <summary>
        ///     Verifies that the preview render executes with an empty world.
        /// </summary>
        [Fact]
        public void RenderPreview_WithEmptyWorld_Executes()
        {
            Gl.Initialize(FakeProcAddress);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            Context context = CreatePreviewContext(scene);
            GraphicManager manager = new GraphicManager(context);
            manager.RenderPreview();
        }

        /// <summary>
        ///     Verifies that the preview render executes with a camera in the world.
        /// </summary>
        [Fact]
        public void RenderPreview_WithCamera_Executes()
        {
            Gl.Initialize(FakeProcAddress);
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject gameObject = scene.Create();
            gameObject.Add(new Alis.Core.Ecs.Components.Render.Camera());
            Context context = CreatePreviewContext(scene);
            GraphicManager manager = new GraphicManager(context);
            manager.RenderPreview();
        }

        /// <summary>
        ///     Verifies that the box collider render loop skips colliders when debug is off.
        /// </summary>
        [Fact]
        public void RenderBoxColliders_WithDebugDisabled_SkipsRender()
        {
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            GameObject gameObject = scene.Create();
            gameObject.Add(new Alis.Core.Ecs.Components.Collider.BoxCollider());
            Context context = CreatePreviewContext(scene);
            GraphicManager manager = new GraphicManager(context);
            GraphicManager.RenderBoxColliders(
                context.SceneManager.CurrentWorld.Query<With<Alis.Core.Ecs.Components.Collider.BoxCollider>>().EnumerateWithEntities(),
                context.Setting.Physic,
                default,
                100.0f);
        }
    }
}
