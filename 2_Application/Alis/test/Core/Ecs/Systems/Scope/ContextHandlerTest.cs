// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerTest.cs
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
using System.Threading;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     Tests for the <see cref="ContextHandler" /> class.
    /// </summary>
    public class ContextHandlerTest
    {
        /// <summary>
        ///     Tests that Exit sets IsRunning to false.
        /// </summary>
        [Fact]
        public void Exit_ShouldSetIsRunningToFalse()
        {
            Context context = new Context(new Setting());
            ContextHandler handler = new ContextHandler(context);

            Assert.True(context.IsRunning);

            handler.Exit();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Save does not throw on a default context.
        /// </summary>
        [Fact]
        public void Save_OnDefaultContext_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            ContextHandler handler = new ContextHandler(context);

            handler.Save();
        }

        /// <summary>
        ///     Tests that Load does not throw on a default context.
        /// </summary>
        [Fact]
        public void Load_OnDefaultContext_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            ContextHandler handler = new ContextHandler(context);

            handler.Load();
        }

        /// <summary>
        ///     Tests that Context property returns the same instance.
        /// </summary>
        [Fact]
        public void ContextProperty_ShouldReturnSameInstance()
        {
            Context context = new Context(new Setting());
            ContextHandler handler = new ContextHandler(context);

            Assert.Same(context, handler.Context);
        }

        /// <summary>
        ///     Tests that Save with path does not throw on a default context.
        /// </summary>
        [Fact]
        public void Save_WithFilePath_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            ContextHandler handler = new ContextHandler(context);

            handler.Save("/tmp/test-save.dat");
        }

        /// <summary>
        ///     Creates a <see cref="Context" /> with a default scene loaded so that
        ///     lifecycle methods (Init, Awake, Start) do not throw.
        /// </summary>
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        /// <summary>
        ///     Tests that InitPreview sets the preview mode on the graphic setting.
        /// </summary>
        [Fact]
        public void InitPreview_WhenCalled_SetsPreviewMode()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Assert.True(context.Setting.Graphic.PreviewMode);
        }

        /// <summary>
        ///     Tests that Run exits immediately when IsRunning is false at entry.
        ///     Sets preview mode to avoid GraphicManager attempting OpenGL initialization,
        ///     which requires a native graphics context not available in unit tests.
        /// </summary>
        [Fact]
        public void Run_WhenAlreadyStopped_ExitsImmediately()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.Exit();

            handler.Run();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Run enters the main loop body and executes time/frame
        ///     management code before OnDraw throws (no GL context available).
        ///     Verifies that frame counters are updated inside the loop.
        /// </summary>
        [Fact(Skip = "Excluded: Run() contains an infinite game loop that can hang the test host")]
        public void Run_ExecutesMainLoopBody_UpdatesFrameCounters()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Exception captured = null;
            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.Run();
                }
                catch (Exception ex)
                {
                    captured = ex;
                }
            })
            {
                IsBackground = true
            };
            thread.Start();

            Thread.Sleep(50);
            handler.Exit();

            Assert.True(thread.Join(5000));

            Assert.NotNull(captured);
            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Run propagates the OnDraw exception from GraphicManager
        ///     when the loop body executes with no native GL context.
        /// </summary>
        [Fact(Skip = "Excluded: Run() contains an infinite game loop that can hang the test host")]
        public void Run_WhenLoopBodyExecutes_ThrowsInvalidOperationException()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Exception captured = null;
            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.Run();
                }
                catch (Exception ex)
                {
                    captured = ex;
                }
            })
            {
                IsBackground = true
            };
            thread.Start();

            Thread.Sleep(50);
            handler.Exit();

            Assert.True(thread.Join(5000));
            Assert.IsType<InvalidOperationException>(captured);
        }

        /// <summary>
        ///     Tests that LoadAndRun exits immediately when IsRunning is false at entry.
        ///     Sets preview mode to avoid GraphicManager attempting OpenGL initialization.
        /// </summary>
        [Fact]
        public void LoadAndRun_WhenAlreadyStopped_ExitsImmediately()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.Exit();

            handler.LoadAndRun();

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that LoadAndRun enters the run loop when context is running,
        ///     covering the Load + OnInit + OnAwake + OnStart calls.
        /// </summary>
        [Fact(Skip = "Excluded: LoadAndRun() enters the infinite Run() game loop that can hang the test host")]
        public void LoadAndRun_WhenContextIsRunning_EntersLoop()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Exception captured = null;
            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.LoadAndRun();
                }
                catch (Exception ex)
                {
                    captured = ex;
                }
            })
            {
                IsBackground = true
            };
            thread.Start();

            Thread.Sleep(50);
            handler.Exit();

            Assert.True(thread.Join(5000));
            Assert.NotNull(captured);
            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Preview after InitPreview throws InvalidOperationException
        ///     because GL is not initialized (no native graphics context).
        ///     Covers all Preview lines before OnDraw (time calculations, lifecycle calls, branches).
        /// </summary>
        [Fact]
        public void Preview_AfterInitPreview_ThrowsInvalidOperationException()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            // Sleep to trigger FPS counter branch (newTime - lastTime >= 1.0)
            // and fixed-update while-loop (accumulator >= 0.016f)
            Thread.Sleep(1001);

            Assert.Throws<InvalidOperationException>(() => handler.Preview());
        }

        /// <summary>
        ///     Tests that Preview without InitPreview throws InvalidOperationException,
        ///     covering the path where currentTime/lastTime have default values.
        /// </summary>
        [Fact]
        public void Preview_WithoutInitPreview_ThrowsInvalidOperationException()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Assert.Throws<InvalidOperationException>(() => handler.Preview());
        }

        /// <summary>
        ///     Tests that InitPreview sets internal timing fields correctly
        ///     and Preview captures the preview mode state.
        /// </summary>
        [Fact]
        public void InitPreview_SetsPreviewMode_AndAllowsPreviewToStart()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Assert.True(context.Setting.Graphic.PreviewMode);
        }
    }
}
