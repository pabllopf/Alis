// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicContinuousPhysicsTests.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     This collection exists so the tests can safely toggle the process-wide
    ///     <see cref="SettingEnv.ContinuousPhysics" /> flag without racing another test
    ///     collection that is running in parallel.
    /// </summary>
    [CollectionDefinition("WorldPhysicContinuousPhysics", DisableParallelization = true)]
    public class WorldPhysicContinuousPhysicsCollection
    {
    }

    /// <summary>
    ///     Behavioural tests for the Continuous Collision Detection toggle that control the
    ///     <c>SettingEnv.ContinuousPhysics &amp;&amp; step.Dt &gt; 0</c> step path in
    ///     <see cref="WorldPhysic" />.
    /// </summary>
    [Collection("WorldPhysicContinuousPhysics")]
    public class WorldPhysicContinuousPhysicsTests
    {
        /// <summary>
        ///     With continuous physics enabled the TOI solver is executed after the regular
        ///     solve, which re-sizes the island workspace to the TOI capacities.
        /// </summary>
        [Fact]
        public void Step_WhenContinuousPhysicsEnabled_RunsToiSolver()
        {
            bool original = SettingEnv.ContinuousPhysics;
            SettingEnv.ContinuousPhysics = true;
            try
            {
                WorldPhysic world = new WorldPhysic(Vector2F.Zero);
                world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
                world.CreateCircle(1.0f, 1.0f, new Vector2F(3, 0), BodyType.Dynamic);

                world.Step(1.0f / 30.0f);

                Assert.Equal(2 * SettingEnv.MaxToiContacts, world.GetIsland.BodyCapacity);
                Assert.Equal(SettingEnv.MaxToiContacts, world.GetIsland.ContactCapacity);
            }
            finally
            {
                SettingEnv.ContinuousPhysics = original;
            }
        }

        /// <summary>
        ///     With continuous physics disabled the TOI solver is skipped, so after stepping the
        ///     island workspace keeps the capacities of the regular island solve instead of the
        ///     TOI ones.
        /// </summary>
        [Fact]
        public void Step_WhenContinuousPhysicsDisabled_SkipsToiSolver()
        {
            bool original = SettingEnv.ContinuousPhysics;
            SettingEnv.ContinuousPhysics = false;
            try
            {
                WorldPhysic world = new WorldPhysic(Vector2F.Zero);
                world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);
                world.CreateCircle(1.0f, 1.0f, new Vector2F(3, 0), BodyType.Dynamic);

                world.Step(1.0f / 30.0f);

                Assert.Equal(world.GetIsland.BodyCapacity, 2);
                Assert.NotEqual(2 * SettingEnv.MaxToiContacts, world.GetIsland.BodyCapacity);
            }
            finally
            {
                SettingEnv.ContinuousPhysics = original;
            }
        }

        /// <summary>
        ///     Disabling continuous physics still allows the world to take a time step without
        ///     throwing and without leaving the world locked.
        /// </summary>
        [Fact]
        public void Step_WhenContinuousPhysicsDisabled_LeavesWorldUnlocked()
        {
            bool original = SettingEnv.ContinuousPhysics;
            SettingEnv.ContinuousPhysics = false;
            try
            {
                WorldPhysic world = new WorldPhysic(Vector2F.Zero);
                world.CreateCircle(1.0f, 1.0f, new Vector2F(0, 0), BodyType.Dynamic);

                world.Step(1.0f / 30.0f);

                Assert.False(world.GetIsLocked);
            }
            finally
            {
                SettingEnv.ContinuousPhysics = original;
            }
        }
    }
}