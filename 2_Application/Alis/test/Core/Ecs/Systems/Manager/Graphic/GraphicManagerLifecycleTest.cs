// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GraphicManagerLifecycleTest.cs
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
using Alis.Core.Ecs.Systems.Manager.Graphic;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     Tests for GraphicManager lifecycle methods that can run without an OpenGL context.
    /// </summary>
    public class GraphicManagerLifecycleTest
    {
        /// <summary>
        ///     Tests that OnInit returns early without error when PreviewMode is enabled.
        ///     This exercises the PreviewMode early-return path in OnInit,
        ///     skipping all platform initialization and OpenGL setup.
        /// </summary>
        [Fact]
        public void OnInit_PreviewModeEnabled_ReturnsEarly()
        {
            Setting setting = new Setting();
            setting.Graphic = setting.Graphic with { PreviewMode = true };
            Context context = new Context(setting);
            GraphicManager manager = new GraphicManager(context);

            Exception ex = Record.Exception(() => manager.OnInit());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnStart executes without error (method is intentionally empty).
        /// </summary>
        [Fact]
        public void OnStart_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            Exception ex = Record.Exception(() => manager.OnStart());

            Assert.Null(ex);
        }

        /// <summary>
        ///     Tests that OnBeforeDraw executes without error (method is intentionally empty).
        /// </summary>
        [Fact]
        public void OnBeforeDraw_DoesNotThrow()
        {
            Context context = new Context(new Setting());
            GraphicManager manager = new GraphicManager(context);

            Exception ex = Record.Exception(() => manager.OnBeforeDraw());

            Assert.Null(ex);
        }
    }
}
