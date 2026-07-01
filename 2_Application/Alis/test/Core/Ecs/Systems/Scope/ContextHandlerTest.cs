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
    }
}
