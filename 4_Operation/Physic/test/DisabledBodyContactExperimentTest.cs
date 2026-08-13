// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DisabledBodyContactExperimentTest.cs
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

namespace Alis.Core.Physic.Test
{
    /// <summary>
    ///     The disabled body contact experiment test class
    /// </summary>
    public class DisabledBodyContactExperimentTest
    {
        /// <summary>
        ///     Tests that stepping a world with a disabled body in contact does not throw
        /// </summary>
        [Fact]
        public void Step_WithDisabledBodyInContact_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactCount >= 1);

            bodyB.Enabled = false;

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }
        }

        /// <summary>
        ///     Tests that disabling both bodies in a contact still steps cleanly
        /// </summary>
        [Fact]
        public void Step_WithBothBodiesDisabled_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            bodyA.Enabled = false;
            bodyB.Enabled = false;

            for (int i = 0; i < 5; i++)
            {
                world.Step(1.0f / 60.0f);
            }
        }
    }
}
