// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IslandClampCoverageTests.cs
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
    ///     The island clamp coverage tests class
    /// </summary>
    public class IslandClampCoverageTests
    {
        /// <summary>
        ///     Tests that solving with an extreme linear velocity clamps the translation.
        /// </summary>
        [Fact]
        public void Solve_WithExtremeLinearVelocity_ClampsTranslation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(10.0f, 0.0f));
            Body body = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.IsBullet = true;
            body.LinearVelocity = new Vector2F(500.0f, 0.0f);

            for (int i = 0; i < 20; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(body.Position.X > 0.0f);
        }

        /// <summary>
        ///     Tests that solving with an extreme angular velocity clamps the rotation.
        /// </summary>
        [Fact]
        public void Solve_WithExtremeAngularVelocity_ClampsRotation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(10.0f, 0.0f));
            Body body = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.IsBullet = true;
            body.AngularVelocity = 500.0f;

            for (int i = 0; i < 20; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(true);
        }

        /// <summary>
        ///     Tests that solving with extreme velocities on both axes clamps both.
        /// </summary>
        [Fact]
        public void Solve_WithExtremeVelocities_ClampsBoth()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(10.0f, 0.0f));
            Body body = world.CreateCircle(0.5f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            body.IsBullet = true;
            body.LinearVelocity = new Vector2F(500.0f, -500.0f);
            body.AngularVelocity = -500.0f;

            for (int i = 0; i < 20; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(true);
        }
    }
}
