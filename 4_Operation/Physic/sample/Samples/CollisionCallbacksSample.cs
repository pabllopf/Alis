// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollisionCallbacksSample.cs
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

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The collision callbacks sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class CollisionCallbacksSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "callbacks";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Collision callbacks";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Subscribes to collision and separation callbacks on fixtures and bodies.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body left = world.CreateBody(new Vector2F(-2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body right = world.CreateBody(new Vector2F(2.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture leftFixture = left.CreateCircle(0.8f, 1.0f);
            Fixture rightFixture = right.CreateCircle(0.8f, 1.0f);

            left.LinearVelocity = new Vector2F(4.0f, 0.0f);
            right.LinearVelocity = new Vector2F(-4.0f, 0.0f);

            int fixtureCollisionCount = 0;
            int fixtureSeparationCount = 0;
            int bodyCollisionCount = 0;

            leftFixture.OnCollision = (sender, other, contact) =>
            {
                fixtureCollisionCount++;
                return true;
            };
            leftFixture.OnSeparation = (sender, other, contact) => { fixtureSeparationCount++; };
            left.OnCollision += (sender, other, contact) =>
            {
                bodyCollisionCount++;
                return true;
            };

            runtime.StepWorld(world, 180);
            Console.WriteLine("Fixture collisions: {0}", fixtureCollisionCount);
            Console.WriteLine("Fixture separations: {0}", fixtureSeparationCount);
            Console.WriteLine("Body collisions: {0}", bodyCollisionCount);
            runtime.PrintBodyState("Left", left);
            runtime.PrintBodyState("Right", right);
        }
    }
}