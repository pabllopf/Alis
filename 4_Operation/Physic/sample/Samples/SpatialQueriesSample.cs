// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SpatialQueriesSample.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The spatial queries sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class SpatialQueriesSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "queries";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "AABB queries, ray-casts and point tests";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Demonstrates WorldPhysic.QueryAabb, WorldPhysic.RayCast and WorldPhysic.TestPoint.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            world.CreateCircle(0.8f, 0.0f, new Vector2F(-3.0f, 0.0f), BodyType.Static);
            world.CreateRectangle(2.0f, 1.0f, 0.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);
            world.CreateCircle(0.6f, 0.0f, new Vector2F(3.0f, 0.0f), BodyType.Static);

            Aabb queryRegion = new Aabb(new Vector2F(0.0f, 0.0f), 8.0f, 4.0f);
            int aabbHits = 0;
            world.QueryAabb(
                fixture =>
                {
                    aabbHits++;
                    return true;
                },
                ref queryRegion);

            int rayHits = 0;
            world.RayCast(
                (fixture, point, normal, fraction) =>
                {
                    rayHits++;
                    return 1.0f;
                },
                new Vector2F(-10.0f, 0.0f),
                new Vector2F(10.0f, 0.0f));

            Fixture testedFixture = world.TestPoint(new Vector2F(0.0f, 0.0f));

            Console.WriteLine("AABB hits: {0}", aabbHits);
            Console.WriteLine("Ray hits: {0}", rayHits);
            Console.WriteLine("TestPoint found fixture: {0}", testedFixture != null ? "yes" : "no");
        }
    }
}