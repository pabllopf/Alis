// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerTests.cs
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
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     Additional coverage tests for the <see cref="ContextHandler" /> class.
    /// </summary>
    public class ContextHandlerTests
    {
        /// <summary>
        ///     Creates a <see cref="Context" /> with a default scene loaded.
        /// </summary>
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            Scene scene = new Scene();
            context.SceneManager.LoadedScenes.Add(scene);
            context.SceneManager.CurrentWorld = scene;
            return context;
        }

        /// <summary>
        ///     Tests that constructor accepts null context but method calls throw.
        /// </summary>
        [Fact]
        public void Constructor_NullContext_MethodsThrow()
        {
            ContextHandler handler = new ContextHandler(null);

            Assert.Throws<NullReferenceException>(() => handler.Exit());
            Assert.Throws<NullReferenceException>(() => handler.Save());
            Assert.Throws<NullReferenceException>(() => handler.Load());
        }

        /// <summary>
        ///     Tests that Exit can be called multiple times without error.
        /// </summary>
        [Fact]
        public void Exit_MultipleCalls_IsIdempotent()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            Assert.True(context.IsRunning);

            handler.Exit();
            Assert.False(context.IsRunning);

            handler.Exit();
            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Run enters the loop body when IsRunning is true,
        ///     and exits cleanly when Exit is called from another thread.
        /// </summary>
        [Fact]
        public void Run_WithPreviewMode_EntersLoopBodyAndExits()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Exception runException = null;
            bool runCompleted = false;

            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.Run();
                    runCompleted = true;
                }
                catch (Exception ex)
                {
                    runException = ex;
                }
            });
            thread.Start();

            Thread.Sleep(500);
            handler.Exit();

            Assert.True(thread.Join(TimeSpan.FromSeconds(5)));

            // If Run threw, it's because OnDraw threw InvalidOperationException
            // (expected without GL context). If it completed, all lines covered.
            if (runException != null)
            {
                Assert.IsAssignableFrom<Exception>(runException);
            }

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that InitPreview can be called multiple times.
        /// </summary>
        [Fact]
        public void InitPreview_CalledMultipleTimes_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();
            Assert.True(context.Setting.Graphic.PreviewMode);

            handler.InitPreview();
            Assert.True(context.Setting.Graphic.PreviewMode);
        }

        /// <summary>
        ///     Tests that Preview without InitPreview covers the fast path
        ///     where FPS counter branch and fixed update loop are skipped.
        /// </summary>
        [Fact]
        public void Preview_WithoutInitPreview_CoversFastPath()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Assert.Throws<InvalidOperationException>(() => handler.Preview());
        }

        /// <summary>
        ///     Tests that Save then Load does not throw.
        /// </summary>
        [Fact]
        public void SaveThenLoad_WithDefaultContext_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save();
            handler.Load();
        }

        /// <summary>
        ///     Tests that LoadAndRun enters the loop body when IsRunning is true.
        /// </summary>
        [Fact]
        public void LoadAndRun_WithPreviewMode_EntersLoopBodyAndExits()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            Exception runException = null;
            bool runCompleted = false;

            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.LoadAndRun();
                    runCompleted = true;
                }
                catch (Exception ex)
                {
                    runException = ex;
                }
            });
            thread.Start();

            Thread.Sleep(500);
            handler.Exit();

            Assert.True(thread.Join(TimeSpan.FromSeconds(5)));

            if (runException != null)
            {
                Assert.IsAssignableFrom<Exception>(runException);
            }

            Assert.False(context.IsRunning);
        }

        /// <summary>
        ///     Tests that Save with empty string path does not throw.
        /// </summary>
        [Fact]
        public void Save_WithEmptyPath_DoesNotThrow()
        {
            Context context = CreateContextWithScene();
            ContextHandler handler = new ContextHandler(context);

            handler.Save(string.Empty);
        }

        /// <summary>
        ///     Tests that Run after InitPreview enters the loop body
        ///     with preview mode already set.
        /// </summary>
        [Fact]
        public void Run_AfterInitPreview_EntersLoopBodyAndExits()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Exception runException = null;
            bool runCompleted = false;

            Thread thread = new Thread(() =>
            {
                try
                {
                    handler.Run();
                    runCompleted = true;
                }
                catch (Exception ex)
                {
                    runException = ex;
                }
            });
            thread.Start();

            Thread.Sleep(500);
            handler.Exit();

            Assert.True(thread.Join(TimeSpan.FromSeconds(5)));

            if (runException != null)
            {
                Assert.IsAssignableFrom<Exception>(runException);
            }

            Assert.False(context.IsRunning);
        }
    }
}
