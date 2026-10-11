// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandAllowSleepCoverageTests.cs
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
    ///     <see cref="SettingEnv.AllowSleep" /> flag without racing another test
    ///     collection that is running in parallel.
    /// </summary>
    [CollectionDefinition("IslandAllowSleep", DisableParallelization = true)]
    public class IslandAllowSleepCollection
    {
    }

    /// <summary>
    ///     Behavioural tests for the <see cref="SettingEnv.AllowSleep" /> toggle that
    ///     controls the early return of <see cref="Island.UpdateSleepState" />.
    /// </summary>
    [Collection("IslandAllowSleep")]
    public class IslandAllowSleepCoverageTests
    {
        /// <summary>
        ///     When sleeping is disabled <see cref="Island.UpdateSleepState" /> must
        ///     return before evaluating any body, leaving an eligible body awake.
        /// </summary>
        [Fact]
        public void UpdateSleepState_WhenAllowSleepDisabled_ReturnsWithoutSleepingBodies()
        {
            bool original = SettingEnv.AllowSleep;
            SettingEnv.AllowSleep = false;
            try
            {
                WorldPhysic world = new WorldPhysic(Vector2F.Zero);
                Island island = new Island();
                island.Reset(4, 4, 4, world.ContactManager);
                Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
                body.SleepTime = 10.0f;
                island.Add(body);

                island.UpdateSleepState(1.0f, true);

                Assert.True(body.Awake);
            }
            finally
            {
                SettingEnv.AllowSleep = original;
            }
        }

        /// <summary>
        ///     When sleeping is enabled an otherwise-idle body whose accumulated sleep
        ///     time exceeds <see cref="SettingEnv.TimeToSleep" /> is put to sleep, which
        ///     proves the early return tested above is the only thing preventing it.
        /// </summary>
        [Fact]
        public void UpdateSleepState_WhenAllowSleepEnabled_SleepsEligibleBody()
        {
            bool original = SettingEnv.AllowSleep;
            SettingEnv.AllowSleep = true;
            try
            {
                WorldPhysic world = new WorldPhysic(Vector2F.Zero);
                Island island = new Island();
                island.Reset(4, 4, 4, world.ContactManager);
                Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
                body.SleepTime = 10.0f;
                island.Add(body);

                island.UpdateSleepState(1.0f, true);

                Assert.False(body.Awake);
            }
            finally
            {
                SettingEnv.AllowSleep = original;
            }
        }
    }
}
