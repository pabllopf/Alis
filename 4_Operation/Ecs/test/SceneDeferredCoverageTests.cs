// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneDeferredCoverageTests.cs
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

using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The scene deferred coverage tests class
    /// </summary>
    public class SceneDeferredCoverageTests
    {
        /// <summary>
        ///     Tests that creating entities while structural changes are disallowed defers them.
        /// </summary>
        [Fact]
        public void Create_WhileDisallowed_DefersAndResolves()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new TestComponent {Value = 1}, new TestComponent2 {Value = 2});
                scene.Create(new TestComponent {Value = 3}, new TestComponent2 {Value = 4}, new AnotherComponent());
                scene.Create(new TestComponent {Value = 5}, new TestComponent2 {Value = 6}, new AnotherComponent(), new AnotherComponent2());
                scene.Create(new TestComponent {Value = 7}, new TestComponent2 {Value = 8}, new AnotherComponent(), new AnotherComponent2(), new Position());
                scene.ExitDisallowState(null, false);

                Assert.Equal(4, scene.EntityCount);
            }
        }

        /// <summary>
        ///     Tests that creating entities while disallowed with more components defers them.
        /// </summary>
        [Fact]
        public void Create_WhileDisallowed_WithManyComponents_DefersAndResolves()
        {
            using (Scene scene = new Scene())
            {
                scene.EnterDisallowState();
                scene.Create(new TestComponent {Value = 1}, new TestComponent2 {Value = 2}, new AnotherComponent(), new AnotherComponent2(), new Position(), new Health {Value = 10});
                scene.Create(new TestComponent {Value = 3}, new TestComponent2 {Value = 4}, new AnotherComponent(), new AnotherComponent2(), new Position(), new Health {Value = 20}, new Damage {Value = 5});
                scene.Create(new TestComponent {Value = 5}, new TestComponent2 {Value = 6}, new AnotherComponent(), new AnotherComponent2(), new Position(), new Health {Value = 30}, new Damage {Value = 7}, new Armor {Value = 2});
                scene.ExitDisallowState(null, false);

                Assert.Equal(3, scene.EntityCount);
            }
        }
        
       
    }
}
