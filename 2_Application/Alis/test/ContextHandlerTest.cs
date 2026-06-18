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

using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    public class ContextHandlerTest
    {
        [Fact]
        public void Constructor_WithContext_CreatesHandler()
        {
            Context context = new Context();
            ContextHandler handler = new ContextHandler(context);
            Assert.NotNull(handler);
        }

        [Fact]
        public void Context_Property_ReturnsSameInstance()
        {
            Context context = new Context();
            ContextHandler handler = new ContextHandler(context);
            Assert.Same(context, handler.Context);
        }

        [Fact]
        public void Exit_SetsIsRunningToFalse()
        {
            Context context = new Context();
            ContextHandler handler = new ContextHandler(context);
            Assert.True(context.IsRunning);
            handler.Exit();
            Assert.False(context.IsRunning);
        }

        [Fact]
        public void Load_DoesNotThrow()
        {
            Context context = new Context();
            ContextHandler handler = new ContextHandler(context);
            handler.Load();
        }

        [Fact]
        public void Save_DoesNotThrow()
        {
            Context context = new Context();
            ContextHandler handler = new ContextHandler(context);
            handler.Save();
        }
    }
}
