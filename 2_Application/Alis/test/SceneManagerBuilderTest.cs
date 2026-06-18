// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneManagerBuilderTest.cs
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
using Alis.Builder.Core.Ecs.System.ManagerBuilders.Scenes;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    public class SceneManagerBuilderTest
    {
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);
            Assert.NotNull(builder);
        }

        [Fact]
        public void Build_ReturnsSceneManagerInstance()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);
            SceneManager result = builder.Build();
            Assert.NotNull(result);
        }

        [Fact]
        public void Build_ReturnsSameInstance()
        {
            Context context = new Context();
            SceneManagerBuilder builder = new SceneManagerBuilder(context);
            SceneManager first = builder.Build();
            SceneManager second = builder.Build();
            Assert.Same(first, second);
        }
    }
}
