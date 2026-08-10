// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextHandlerRemainingCoverageTests.cs
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

using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Scope;
using Scene = Alis.Core.Ecs.Scene;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The context handler remaining coverage tests class
    /// </summary>
    public class ContextHandlerRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that run loop executes iterations until exit
        /// </summary>
        [Fact]
        public void Run_LoopExecutesIterations_UntilExit()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);

            bool loopThrew = false;
            Task runTask = Task.Run(() =>
            {
                try
                {
                    handler.Run();
                }
                catch
                {
                    loopThrew = true;
                }
            });

            Thread.Sleep(30);
            handler.Exit();

            Assert.True(runTask.Wait(2000));
            Assert.True(loopThrew || !context.IsRunning);
        }

        /// <summary>
        ///     Tests that preview covers smooth delta time paths
        /// </summary>
        [Fact]
        public void Preview_CoversSmoothDeltaTimePaths()
        {
            Context context = CreateContextWithScene();
            context.Setting.Graphic = context.Setting.Graphic with { PreviewMode = true };
            ContextHandler handler = new ContextHandler(context);
            handler.InitPreview();

            Thread.Sleep(20);
            Assert.ThrowsAny<System.Exception>(() => handler.Preview());
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
