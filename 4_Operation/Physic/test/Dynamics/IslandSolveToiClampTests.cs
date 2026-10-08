// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandSolveToiClampTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests that exercise the translation and rotation clamping performed by
    ///     <see cref="Island.SolveToi" /> when a sub-step velocity exceeds the
    ///     configured maximum limits.
    /// </summary>
    public class IslandSolveToiClampTests
    {
        /// <summary>
        ///     Tests that a sub-step with a large linear velocity clamps the body
        ///     translation to <see cref="SettingEnv.MaxTranslation" />.
        /// </summary>
        [Fact]
        public void SolveToi_WhenLinearVelocityExceedsMaxTranslation_ClampsLinearVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Island island = new Island();
            island.Reset(4, 4, 0, world.ContactManager);

            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.LinearVelocityInternal = new Vector2F(100.0f, 0.0f);
            island.Add(bodyA);
            island.Add(bodyB);

            TimeStep subStep = new TimeStep
            {
                Dt = 1.0f,
                InvDt = 1.0f,
                DtRatio = 1.0f,
                PositionIterations = 0,
                VelocityIterations = 0,
                WarmStarting = false
            };

            island.SolveToi(ref subStep, 0, 1);

            Assert.Equal(SettingEnv.MaxTranslation, bodyA.LinearVelocityInternal.Length(), 4);
            Assert.Equal(0.0f, bodyB.LinearVelocityInternal.Length(), 4);

            island.Dispose();
        }

        /// <summary>
        ///     Tests that a sub-step with a large angular velocity clamps the body
        ///     rotation to <see cref="SettingEnv.MaxRotation" />.
        /// </summary>
        [Fact]
        public void SolveToi_WhenAngularVelocityExceedsMaxRotation_ClampsAngularVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Island island = new Island();
            island.Reset(4, 4, 0, world.ContactManager);

            Body bodyA = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(1.0f, 0.0f), BodyType.Dynamic);
            bodyA.AngularVelocity = 100.0f;
            island.Add(bodyA);
            island.Add(bodyB);

            TimeStep subStep = new TimeStep
            {
                Dt = 1.0f,
                InvDt = 1.0f,
                DtRatio = 1.0f,
                PositionIterations = 0,
                VelocityIterations = 0,
                WarmStarting = false
            };

            island.SolveToi(ref subStep, 0, 1);

            Assert.Equal(SettingEnv.MaxRotation, Math.Abs(bodyA.AngularVelocity), 4);
            Assert.Equal(0.0f, bodyB.AngularVelocity);

            island.Dispose();
        }
    }
}
