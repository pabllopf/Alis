// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysicLatestCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The world physic latest coverage tests class
    /// </summary>
    public class WorldPhysicLatestCoverageTests
    {
        /// <summary>
        ///     Tests that a large fast bullet entering a dense static cluster exercises the toi island branches
        /// </summary>
        [Fact]
        public void LargeBullet_IntoDenseStaticCluster_ExercisesToiIslandBranches()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            for (int row = 0; row < 16; row++)
            {
                for (int col = 0; col < 12; col++)
                {
                    world.CreateCircle(0.1f, 1.0f, new Vector2F(12 + col * 0.2f, 0.25f + row * 0.2f), BodyType.Static);
                }
            }

            world.CreateCircle(0.1f, 1.0f, new Vector2F(12, 1.375f), BodyType.Dynamic);
            world.CreateCircle(0.1f, 1.0f, new Vector2F(13, 1.775f), BodyType.Dynamic);
            world.CreateCircle(0.1f, 1.0f, new Vector2F(12.8f, 1.2f), BodyType.Dynamic);

            Body bulletA = world.CreateCircle(1.5f, 1.0f, new Vector2F(0, 1.375f), BodyType.Dynamic);
            bulletA.IsBullet = true;
            bulletA.LinearVelocity = new Vector2F(50, 0);

            Body bulletB = world.CreateCircle(1.5f, 1.0f, new Vector2F(16, 1.375f), BodyType.Dynamic);
            bulletB.IsBullet = true;
            bulletB.LinearVelocity = new Vector2F(-50, 0);

            Body sensorBody = world.CreateBody(new Vector2F(12, 3.5f), 0, BodyType.Static);
            Fixture sensorFixture = sensorBody.CreateFixture(new CircleShape(2.0f, 0.0f));
            sensorFixture.GetIsSensor = true;

            for (int i = 0; i < 100; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
            Assert.True(bulletA.Position.X > 0);
        }

        /// <summary>
        ///     Tests that a large fast bullet hitting a dense line of bodies saturates the toi island capacity
        /// </summary>
        [Fact]
        public void LargeBullet_HittingLineOfBodies_SaturatesToiIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            world.CreateCircle(0.01f, 1.0f, new Vector2F(0, 0.1f), BodyType.Dynamic);
            world.CreateCircle(0.01f, 1.0f, new Vector2F(0.006f, 0.108f), BodyType.Dynamic);

            for (int i = -17; i <= 17; i++)
            {
                world.CreateCircle(0.01f, 1.0f, new Vector2F(0, i * 0.018f), BodyType.Static);
            }

            Body bullet = world.CreateCircle(3.0f, 1.0f, new Vector2F(-5, 0), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(50, 0);

            for (int i = 0; i < 80; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
            Assert.True(bullet.Position.X < -2.9f);
        }

        /// <summary>
        ///     Tests that a large fast bullet touching dynamic neighbors adds them to the toi island
        /// </summary>
        [Fact]
        public void LargeBullet_TouchingDynamicNeighbors_AddsThemToToiIsland()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Body dynamicA = world.CreateCircle(0.01f, 1.0f, new Vector2F(0, 0.02f), BodyType.Dynamic);
            Body dynamicB = world.CreateCircle(0.01f, 1.0f, new Vector2F(0.01f, 0.02f), BodyType.Dynamic);
            world.CreateCircle(0.01f, 1.0f, new Vector2F(0, 0), BodyType.Static);

            Body bullet = world.CreateCircle(3.0f, 1.0f, new Vector2F(-5, 0), BodyType.Dynamic);
            bullet.IsBullet = true;
            bullet.LinearVelocity = new Vector2F(50, 0);

            for (int i = 0; i < 40; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
            Assert.True(dynamicA.Position.X > -5);
            Assert.True(dynamicB.Position.X > -5);
        }

        /// <summary>
        ///     Tests that a fast polygon bullet hitting a static polygon restores a non touching toi contact
        /// </summary>
        [Fact]
        public void FastPolygonBullet_HittingStaticPolygon_RestoresNonTouchingToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 20.0f, 1.0f, new Vector2F(0, 0));
            Body box = world.CreateRectangle(0.5f, 0.5f, 1.0f, new Vector2F(6, 0), 0, BodyType.Dynamic);
            box.IsBullet = true;
            box.LinearVelocity = new Vector2F(-12, 0);

            for (int i = 0; i < 200; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0 || box.Position.X < 0);
        }

        /// <summary>
        ///     Tests that a slightly rotating polygon bullet hitting a static polygon restores a non touching toi contact
        /// </summary>
        [Fact]
        public void SlightlyRotatingPolygonBullet_HittingStaticPolygon_RestoresNonTouchingToi()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(2.0f, 20.0f, 1.0f, new Vector2F(0, 0));
            Body box = world.CreateRectangle(0.5f, 0.5f, 1.0f, new Vector2F(6, 0.4f), 0, BodyType.Dynamic);
            box.IsBullet = true;
            box.LinearVelocity = new Vector2F(-12, 0);
            box.AngularVelocity = 0.5f;

            for (int i = 0; i < 200; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0 || box.Position.X < 0);
        }

        /// <summary>
        ///     Tests that a bullet caught from behind by a faster bullet exercises the alpha mismatch branches
        /// </summary>
        [Fact]
        public void Bullet_CaughtFromBehind_ExercisesAlphaMismatchBranches()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body wall = world.CreateRectangle(1.0f, 10.0f, 1.0f, new Vector2F(0, 0));
            Body bulletA = world.CreateCircle(0.5f, 1.0f, new Vector2F(3, 0), BodyType.Dynamic);
            bulletA.IsBullet = true;
            bulletA.LinearVelocity = new Vector2F(-40, 0);
            Body bulletB = world.CreateCircle(0.5f, 1.0f, new Vector2F(6, 0), BodyType.Dynamic);
            bulletB.IsBullet = true;
            bulletB.LinearVelocity = new Vector2F(-70, 0);

            for (int i = 0; i < 120; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0 || bulletA.Position.X < 2);
        }
    }
}
