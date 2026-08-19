// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateArities6To8CoverageTests.cs
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

using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Test.Models;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    ///     Covers zero-length early-exit and range-based Run overloads
    ///     for Update arities 6, 7, and 8.
    /// </summary>
    public class UpdateArities6To8CoverageTests
    {
        #region Zero-length early exit (no deferred entities)

        /// <summary>
        ///     Tests that arity 6 range-based Run does not throw when length is zero
        /// </summary>
        [Fact]
        public void Update_Arity6_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Update6Component { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Update6Component>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
        }

        /// <summary>
        ///     Tests that arity 7 range-based Run does not throw when length is zero
        /// </summary>
        [Fact]
        public void Update_Arity7_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Update7Component { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42 }
            );
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Update7Component>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
        }
        #endregion

        #region Range-based Run (deferred entities)

        /// <summary>
        ///     Tests that arity 6 range-based Run processes deferred entities and mutates all arguments
        /// </summary>
        [Fact]
        public void Update_Arity6_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Update6Component { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Update6Component>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(
                new Update6Component { CallCount = 0 },
                new Position { X = 10, Y = 20 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 20 },
                new Damage { Value = 5 },
                new Transform { X = 0, Y = 0, Rotation = 0 }
            );
            scene.ExitDisallowState(filter, true);

            Assert.Equal(1, deferred.Get<Update6Component>().CallCount);
            Assert.Equal(13, deferred.Get<Position>().X);
            Assert.Equal(24, deferred.Get<Position>().Y);
            Assert.Equal(95, deferred.Get<Health>().Value);
            Assert.Equal(21, deferred.Get<Armor>().Value);
            Assert.Equal(7, deferred.Get<Damage>().Value);
            Assert.Equal(1, deferred.Get<Transform>().Rotation);
        }

        /// <summary>
        ///     Tests that arity 7 range-based Run processes deferred entities and mutates all arguments
        /// </summary>
        [Fact]
        public void Update_Arity7_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using Scene scene = new Scene();
            scene.Create(
                new Update7Component { CallCount = 0 },
                new Position { X = 1, Y = 2 },
                new Velocity { X = 3, Y = 4 },
                new Health { Value = 100 },
                new Armor { Value = 50 },
                new Damage { Value = 10 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 42 }
            );
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Update7Component>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(
                new Update7Component { CallCount = 0 },
                new Position { X = 5, Y = 6 },
                new Velocity { X = 1, Y = 2 },
                new Health { Value = 80 },
                new Armor { Value = 10 },
                new Damage { Value = 4 },
                new Transform { X = 0, Y = 0, Rotation = 0 },
                new TestComponent { Value = 9 }
            );
            scene.ExitDisallowState(filter, true);

            Assert.Equal(1, deferred.Get<Update7Component>().CallCount);
            Assert.Equal(6, deferred.Get<Position>().X);
            Assert.Equal(8, deferred.Get<Position>().Y);
            Assert.Equal(79, deferred.Get<Health>().Value);
            Assert.Equal(14, deferred.Get<Armor>().Value);
            Assert.Equal(1, deferred.Get<Transform>().X);
            Assert.Equal(12, deferred.Get<TestComponent>().Value);
        }

        #endregion

        #region Full Run for arity 8

       

        #endregion
    }
}
