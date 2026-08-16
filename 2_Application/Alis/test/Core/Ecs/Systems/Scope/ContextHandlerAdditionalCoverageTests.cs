// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerAdditionalCoverageTests.cs
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
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The context handler additional coverage tests class
    /// </summary>
    public class ContextHandlerAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that run without a graphics context executes the main loop body and then throws
        /// </summary>
        [Fact]
        public void Run_WithoutGraphicsContext_ExecutesLoopBody_ThenThrows()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            InvalidOperationException exception = Assert.Throws<InvalidOperationException>(() => handler.Run());

            Assert.Equal(1, context.TimeManager.TotalFrames);
            Assert.Equal(1f, context.TimeManager.FrameCount);
            Assert.Equal(context.TimeManager.UnscaledDeltaTime, context.TimeManager.DeltaTime);
            Assert.Equal(context.TimeManager.UnscaledTime * context.TimeManager.TimeScale, context.TimeManager.Time);
            Assert.Equal(context.TimeManager.UnscaledTimeAsDouble * context.TimeManager.TimeScale, context.TimeManager.TimeAsDouble);
            Assert.True(context.TimeManager.MaximumDeltaTime >= 0f);
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Creates the context with scene
        /// </summary>
        /// <returns>The context</returns>
        private static Context CreateContextWithScene()
        {
            Context context = new Context(new Setting());
            context.SceneManager.LoadedScenes.Add(new Scene());
            context.SceneManager.CurrentWorld = context.SceneManager.LoadedScenes[0];
            return context;
        }
    }
}
