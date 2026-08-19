// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UpdateRemainingCoverageTests.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    /// <summary>
    /// The update remaining coverage tests class
    /// </summary>
    public class UpdateRemainingCoverageTests
    {
        #region Zero-length range (early-exit branch: length <= 0)

        /// <summary>
        /// Tests that update arity 0 range zero length does not throw
        /// </summary>
        [Fact] public void Update_Arity0_RangeZeroLength_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Cov0Comp {CallCount = 0});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov0Comp>.Id);
                scene.EnterDisallowState();
                scene.ExitDisallowState(filter, true);
                Assert.Equal(0, entity.Get<Cov0Comp>().CallCount);
            }
        }

        /// <summary>
        /// Tests that update arity 2 range zero length does not throw
        /// </summary>
        [Fact] public void Update_Arity2_RangeZeroLength_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Cov2Comp {CallCount = 0}, new ArgA {X = 1}, new ArgB {X = 2});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov2Comp>.Id);
                scene.EnterDisallowState();
                scene.ExitDisallowState(filter, true);
                Assert.Equal(0, entity.Get<Cov2Comp>().CallCount);
            }
        }

        /// <summary>
        /// Tests that update arity 3 range zero length does not throw
        /// </summary>
        [Fact] public void Update_Arity3_RangeZeroLength_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Cov3Comp {CallCount = 0}, new ArgA {X = 1}, new ArgB {X = 2}, new ArgC {X = 3});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov3Comp>.Id);
                scene.EnterDisallowState();
                scene.ExitDisallowState(filter, true);
                Assert.Equal(0, entity.Get<Cov3Comp>().CallCount);
            }
        }

        /// <summary>
        /// Tests that update arity 4 range zero length does not throw
        /// </summary>
        [Fact] public void Update_Arity4_RangeZeroLength_DoesNotThrow()
        {
            using (Scene scene = new Scene())
            {
                GameObject entity = scene.Create(new Cov4Comp {CallCount = 0}, new ArgA {X = 1}, new ArgB {X = 2}, new ArgC {X = 3}, new ArgD {X = 4});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov4Comp>.Id);
                scene.EnterDisallowState();
                scene.ExitDisallowState(filter, true);
                Assert.Equal(0, entity.Get<Cov4Comp>().CallCount);
            }
        }

        #endregion

        #region Range-based Run(Scene, Archetype, int, int)

        /// <summary>
        /// Tests that update arity 0 range run processes deferred entities
        /// </summary>
        [Fact] public void Update_Arity0_RangeRun_ProcessesDeferredEntities()
        {
            using (Scene scene = new Scene())
            {
                GameObject existing = scene.Create(new Cov0Comp {CallCount = 0});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov0Comp>.Id);
                scene.EnterDisallowState();
                GameObject deferred = scene.Create(new Cov0Comp {CallCount = 0});
                scene.ExitDisallowState(filter, true);
                Assert.Equal(0, existing.Get<Cov0Comp>().CallCount);
                Assert.Equal(1, deferred.Get<Cov0Comp>().CallCount);
            }
        }

        /// <summary>
        /// Tests that update arity 2 range run processes deferred entities and mutates
        /// </summary>
        [Fact] public void Update_Arity2_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Cov2Comp {CallCount = 0}, new ArgA {X = 0}, new ArgB {X = 0});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov2Comp>.Id);
                scene.EnterDisallowState();
                GameObject deferred = scene.Create(new Cov2Comp {CallCount = 0}, new ArgA {X = 10}, new ArgB {X = 20});
                scene.ExitDisallowState(filter, true);
                Assert.Equal(1, deferred.Get<Cov2Comp>().CallCount);
                Assert.Equal(30, deferred.Get<ArgA>().X);
                Assert.Equal(21, deferred.Get<ArgB>().X);
            }
        }

        /// <summary>
        /// Tests that update arity 3 range run processes deferred entities and mutates
        /// </summary>
        [Fact] public void Update_Arity3_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Cov3Comp {CallCount = 0}, new ArgA {X = 0}, new ArgB {X = 0}, new ArgC {X = 0});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov3Comp>.Id);
                scene.EnterDisallowState();
                GameObject deferred = scene.Create(new Cov3Comp {CallCount = 0}, new ArgA {X = 5}, new ArgB {X = 10}, new ArgC {X = 15});
                scene.ExitDisallowState(filter, true);
                Assert.Equal(1, deferred.Get<Cov3Comp>().CallCount);
                Assert.Equal(6, deferred.Get<ArgA>().X);
                Assert.Equal(12, deferred.Get<ArgB>().X);
                Assert.Equal(14, deferred.Get<ArgC>().X);
            }
        }

        /// <summary>
        /// Tests that update arity 4 range run processes deferred entities and mutates
        /// </summary>
        [Fact] public void Update_Arity4_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using (Scene scene = new Scene())
            {
                scene.Create(new Cov4Comp {CallCount = 0}, new ArgA {X = 0}, new ArgB {X = 0}, new ArgC {X = 0}, new ArgD {X = 0});
                SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov4Comp>.Id);
                scene.EnterDisallowState();
                GameObject deferred = scene.Create(new Cov4Comp {CallCount = 0}, new ArgA {X = 1}, new ArgB {X = 2}, new ArgC {X = 3}, new ArgD {X = 4});
                scene.ExitDisallowState(filter, true);
                Assert.Equal(1, deferred.Get<Cov4Comp>().CallCount);
                Assert.Equal(3, deferred.Get<ArgA>().X);
                Assert.Equal(5, deferred.Get<ArgB>().X);
            }
        }

        #endregion
    }

    #region Test components and argument types

    /// <summary>
    /// The cov comp
    /// </summary>
    internal struct Cov0Comp : IOnUpdate
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;
        /// <summary>
        /// Ons the update using the specified self
        /// </summary>
        /// <param name="self">The self</param>
        public void OnUpdate(IGameObject self) => CallCount++;
    }

    /// <summary>
    /// The cov comp
    /// </summary>
    internal struct Cov2Comp : IOnUpdate<ArgA, ArgB>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        public void Update(IGameObject self, ref ArgA a, ref ArgB b)
        {
            CallCount++;
            a.X += b.X;
            b.X += 1;
        }
    }

    /// <summary>
    /// The cov comp
    /// </summary>
    internal struct Cov3Comp : IOnUpdate<ArgA, ArgB, ArgC>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        public void Update(IGameObject self, ref ArgA a, ref ArgB b, ref ArgC c)
        {
            CallCount++;
            a.X += 1;
            b.X += 2;
            c.X -= 1;
        }
    }

    /// <summary>
    /// The cov comp
    /// </summary>
    internal struct Cov4Comp : IOnUpdate<ArgA, ArgB, ArgC, ArgD>
    {
        /// <summary>
        /// The call count
        /// </summary>
        public int CallCount;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        public void Update(IGameObject self, ref ArgA a, ref ArgB b, ref ArgC c, ref ArgD d)
        {
            CallCount++;
            a.X += 2;
            b.X += 3;
        }
    }

    /// <summary>
    /// The arg
    /// </summary>
    internal struct ArgA { /// <summary>
/// The 
/// </summary>
public int X; }
    /// <summary>
    /// The arg
    /// </summary>
    internal struct ArgB { /// <summary>
/// The 
/// </summary>
public int X; }
    /// <summary>
    /// The arg
    /// </summary>
    internal struct ArgC { /// <summary>
/// The 
/// </summary>
public int X; }
    /// <summary>
    /// The arg
    /// </summary>
    internal struct ArgD { /// <summary>
/// The 
/// </summary>
public int X; }

    #endregion
}
