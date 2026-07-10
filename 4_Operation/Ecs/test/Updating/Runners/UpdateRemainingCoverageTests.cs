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
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating.Runners
{
    public class UpdateRemainingCoverageTests
    {
        #region Zero-length range (early-exit branch: length <= 0)

        [Fact]
        public void Update_Arity0_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Cov0Comp { CallCount = 0 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov0Comp>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
            Assert.Equal(0, entity.Get<Cov0Comp>().CallCount);
        }

        [Fact]
        public void Update_Arity2_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Cov2Comp { CallCount = 0 }, new ArgA { X = 1 }, new ArgB { X = 2 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov2Comp>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
            Assert.Equal(0, entity.Get<Cov2Comp>().CallCount);
        }

        [Fact]
        public void Update_Arity3_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Cov3Comp { CallCount = 0 }, new ArgA { X = 1 }, new ArgB { X = 2 }, new ArgC { X = 3 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov3Comp>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
            Assert.Equal(0, entity.Get<Cov3Comp>().CallCount);
        }

        [Fact]
        public void Update_Arity4_RangeZeroLength_DoesNotThrow()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(new Cov4Comp { CallCount = 0 }, new ArgA { X = 1 }, new ArgB { X = 2 }, new ArgC { X = 3 }, new ArgD { X = 4 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov4Comp>.Id);
            scene.EnterDisallowState();
            scene.ExitDisallowState(filter, true);
            Assert.Equal(0, entity.Get<Cov4Comp>().CallCount);
        }

        #endregion

        #region Range-based Run(Scene, Archetype, int, int)

        [Fact]
        public void Update_Arity0_RangeRun_ProcessesDeferredEntities()
        {
            using Scene scene = new Scene();
            GameObject existing = scene.Create(new Cov0Comp { CallCount = 0 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov0Comp>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new Cov0Comp { CallCount = 0 });
            scene.ExitDisallowState(filter, true);
            Assert.Equal(0, existing.Get<Cov0Comp>().CallCount);
            Assert.Equal(1, deferred.Get<Cov0Comp>().CallCount);
        }

        [Fact]
        public void Update_Arity2_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using Scene scene = new Scene();
            scene.Create(new Cov2Comp { CallCount = 0 }, new ArgA { X = 0 }, new ArgB { X = 0 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov2Comp>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new Cov2Comp { CallCount = 0 }, new ArgA { X = 10 }, new ArgB { X = 20 });
            scene.ExitDisallowState(filter, true);
            Assert.Equal(1, deferred.Get<Cov2Comp>().CallCount);
            Assert.Equal(30, deferred.Get<ArgA>().X);
            Assert.Equal(21, deferred.Get<ArgB>().X);
        }

        [Fact]
        public void Update_Arity3_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using Scene scene = new Scene();
            scene.Create(new Cov3Comp { CallCount = 0 }, new ArgA { X = 0 }, new ArgB { X = 0 }, new ArgC { X = 0 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov3Comp>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new Cov3Comp { CallCount = 0 }, new ArgA { X = 5 }, new ArgB { X = 10 }, new ArgC { X = 15 });
            scene.ExitDisallowState(filter, true);
            Assert.Equal(1, deferred.Get<Cov3Comp>().CallCount);
            Assert.Equal(6, deferred.Get<ArgA>().X);
            Assert.Equal(12, deferred.Get<ArgB>().X);
            Assert.Equal(14, deferred.Get<ArgC>().X);
        }

        [Fact]
        public void Update_Arity4_RangeRun_ProcessesDeferredEntitiesAndMutates()
        {
            using Scene scene = new Scene();
            scene.Create(new Cov4Comp { CallCount = 0 }, new ArgA { X = 0 }, new ArgB { X = 0 }, new ArgC { X = 0 }, new ArgD { X = 0 });
            SingleComponentUpdateFilter filter = new SingleComponentUpdateFilter(scene, Component<Cov4Comp>.Id);
            scene.EnterDisallowState();
            GameObject deferred = scene.Create(new Cov4Comp { CallCount = 0 }, new ArgA { X = 1 }, new ArgB { X = 2 }, new ArgC { X = 3 }, new ArgD { X = 4 });
            scene.ExitDisallowState(filter, true);
            Assert.Equal(1, deferred.Get<Cov4Comp>().CallCount);
            Assert.Equal(3, deferred.Get<ArgA>().X);
            Assert.Equal(5, deferred.Get<ArgB>().X);
        }

        #endregion
    }

    #region Test components and argument types

    internal struct Cov0Comp : IOnUpdate
    {
        public int CallCount;
        public void OnUpdate(IGameObject self) => CallCount++;
    }

    internal struct Cov2Comp : IOnUpdate<ArgA, ArgB>
    {
        public int CallCount;
        public void Update(IGameObject self, ref ArgA a, ref ArgB b)
        {
            CallCount++;
            a.X += b.X;
            b.X += 1;
        }
    }

    internal struct Cov3Comp : IOnUpdate<ArgA, ArgB, ArgC>
    {
        public int CallCount;
        public void Update(IGameObject self, ref ArgA a, ref ArgB b, ref ArgC c)
        {
            CallCount++;
            a.X += 1;
            b.X += 2;
            c.X -= 1;
        }
    }

    internal struct Cov4Comp : IOnUpdate<ArgA, ArgB, ArgC, ArgD>
    {
        public int CallCount;
        public void Update(IGameObject self, ref ArgA a, ref ArgB b, ref ArgC c, ref ArgD d)
        {
            CallCount++;
            a.X += 2;
            b.X += 3;
        }
    }

    internal struct ArgA { public int X; }
    internal struct ArgB { public int X; }
    internal struct ArgC { public int X; }
    internal struct ArgD { public int X; }

    #endregion
}
