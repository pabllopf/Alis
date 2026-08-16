// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerExecutionTests.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     Executes the <see cref="ContextHandler" /> game-loop bodies against fake OpenGL
    ///     function pointers so that the loop lines of Run and Preview are covered.
    /// </summary>
    public class ContextHandlerExecutionTests : IDisposable
    {
        /// <summary>
        ///     Restores the uninitialized gl layer so that tests asserting the not-initialized
        ///     behavior are unaffected.
        /// </summary>
        public void Dispose()
        {
            Gl.Initialize(null);
        }

        /// <summary>
        ///     Tests that run with a running context executes the frame loop bodies.
        /// </summary>
        [Fact]
        public void Run_WithRunningContext_ExecutesFrameLoop()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true, TargetFrames = 1000.0 };
            Gl.Initialize(FakeProcAddress);
            ContextHandler handler = new ContextHandler(context);

            Task stopper = Task.Run(() =>
            {
                Thread.Sleep(60);
                handler.Exit();
            });

            handler.Run();

            stopper.Wait();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that run with a running context covers the one second average frames branch.
        /// </summary>
        [Fact]
        public void Run_WithRunningContext_OverOneSecond_CoversAverageFrames()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true, TargetFrames = 1000.0 };
            Gl.Initialize(FakeProcAddress);
            ContextHandler handler = new ContextHandler(context);

            Task stopper = Task.Run(() =>
            {
                Thread.Sleep(1100);
                handler.Exit();
            });

            handler.Run();

            stopper.Wait();

            Assert.True(context.TimeManager.TotalFrames > 100);
        }

        /// <summary>
        ///     Tests that preview with an initialized gl layer completes without throwing.
        /// </summary>
        [Fact]
        public void Preview_WithInitializedGl_Completes()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true, TargetFrames = 1000.0 };
            Gl.Initialize(FakeProcAddress);
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Thread.Sleep(20);

            Exception ex = Record.Exception(() => handler.Preview());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Creates the context with scene
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

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
                case "glClearColor": return Marshal.GetFunctionPointerForDelegate(new ClearColor(FakeClearColor));
                case "glClear": return Marshal.GetFunctionPointerForDelegate(new Clear(FakeClear));
                default: return IntPtr.Zero;
            }
        }
    }
}
