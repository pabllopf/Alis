// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensionsRemainingCoverageTests.cs
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
using Alis.Core.Ecs.Kernel;
using Xunit;

namespace Alis.Core.Ecs.Test
{
    /// <summary>
    ///     The game object extensions remaining coverage tests class
    /// </summary>
    public class GameObjectExtensionsRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies the array-based component lookup overload. Existing Deconstruct
        ///     call sites use the span-based overload, so the array overload is invoked
        ///     directly with a real archetype's tag table and storage array.
        /// </summary>
        [Fact]
        public void GetComp_FromArrays_ReturnsReferenceToStoredComponent()
        {
            using (Scene scene = new Scene())
            {
                GameObject gameObject = scene.Create(new Position {X = 42, Y = 7});

                ref GameObjectLocation location = ref gameObject.AssertIsAlive(out _);
                Ref<Position> comp = GameObjectExtensions.GetComp<Position>(
                    location.Archetype.ComponentTagTable, location.Archetype.Components, location.Index);

                Assert.Equal(42, comp.Value.X);
                Assert.Equal(7, comp.Value.Y);
            }
        }

        /// <summary>
        ///     Tests that deconstruct single component returns ref
        /// </summary>
        [Fact]
        public void Deconstruct_SingleComponent_ReturnsRef()
        {
            using (Scene scene = new Scene())
            {
                GameObject gameObject = scene.Create(new Position {X = 1, Y = 2});

                gameObject.Deconstruct(out Ref<Position> comp);

                Assert.Equal(1, comp.Value.X);
                Assert.Equal(2, comp.Value.Y);
            }
        }
    }
}
