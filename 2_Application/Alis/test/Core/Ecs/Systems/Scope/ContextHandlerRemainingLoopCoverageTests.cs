// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerRemainingLoopCoverageTests.cs
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
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     Tests the ContextHandler game loop end-of-frame paths without a native graphics context.
    /// </summary>
    public class ContextHandlerRemainingLoopCoverageTests
    {
        /// <summary>
        ///     Tests that running the loop for a full second covers the fps average branch, fixed time step
        ///     accumulation, smooth delta time and frame sleeping paths.
        /// </summary>
        [Fact]
        public void Run_ForFullSecond_CoversFpsFixedStepAndSmoothDeltaPaths()
        {
            Context context = CreateContextWithNoOpGraphics();
            ContextHandler handler = new ContextHandler(context);

            Exception runException = null;
            Task runTask = Task.Run(() =>
            {
                try
                {
                    handler.Run();
                }
                catch (Exception exception)
                {
                    runException = exception;
                }
            });

            Thread.Sleep(1600);

            handler.Exit();

            Assert.True(runTask.Wait(TimeSpan.FromSeconds(8)));
            Assert.Null(runException);

            Assert.True(context.TimeManager.TotalFrames >= 10);
            Assert.True(context.TimeManager.AverageFrames > 0);
            Assert.True(context.TimeManager.FixedTime > 0);
            Assert.True(context.TimeManager.SmoothDeltaTime >= 0);
        }

        /// <summary>
        ///     Tests that a single preview frame completes the end-of-frame drawing and smooth delta paths
        ///     when no native graphics context is required.
        /// </summary>
        [Fact]
        public void Preview_WithNoOpGraphics_CompletesEndOfFramePaths()
        {
            Context context = CreateContextWithNoOpGraphics();
            ContextHandler handler = new ContextHandler(context);

            handler.InitPreview();

            Thread.Sleep(20);

            handler.Preview();

            Assert.True(context.TimeManager.FrameCount >= 1);
            Assert.True(context.TimeManager.SmoothDeltaTime >= 0);
            Assert.True(context.TimeManager.FixedTimeAsDouble >= 0);
        }

        /// <summary>
        ///     Creates a context with a no-op graphic manager so the game loop never touches native OpenGL.
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContextWithNoOpGraphics()
        {
            Context context = new Context(new Setting());
            GraphicManager original = context.GraphicManager;
            NoOpGraphicManager noOp = new NoOpGraphicManager(context);

            context.InternalRuntime.runtimes.Remove(original);
            context.InternalRuntime.runtimes.Add(noOp);

            Alis.Core.Ecs.Scene scene = new Alis.Core.Ecs.Scene();
            context.SceneManager.AddScene(scene);
            context.SceneManager.CurrentWorld = scene;

            return context;
        }

        /// <summary>
        ///     A graphic manager that performs no native graphics work.
        /// </summary>
        private sealed class NoOpGraphicManager : GraphicManager
        {
            /// <summary>
            ///     Initializes a new instance of the <see cref="NoOpGraphicManager" /> class
            /// </summary>
            /// <param name="context">The context</param>
            public NoOpGraphicManager(Context context) : base(context)
            {
            }

            /// <summary>
            ///     Does nothing
            /// </summary>
            public override void OnInit()
            {
            }

            /// <summary>
            ///     Does nothing
            /// </summary>
            public override void OnDraw()
            {
            }

            /// <summary>
            ///     Does nothing
            /// </summary>
            public override void OnAfterDraw()
            {
            }

            /// <summary>
            ///     Does nothing
            /// </summary>
            public override void OnGui()
            {
            }

            /// <summary>
            ///     Does nothing
            /// </summary>
            public override void OnRenderPresent()
            {
            }
        }
    }
}
