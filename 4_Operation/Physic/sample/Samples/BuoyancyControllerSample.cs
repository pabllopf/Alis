// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BuoyancyControllerSample.cs
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
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The buoyancy controller sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class BuoyancyControllerSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "buoyancy";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Buoyancy controller";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Creates a water volume that applies buoyancy and drag to submerged bodies.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(new Vector2F(0.0f, -9.81f));
            runtime.AddGround(world, -10.0f);

            Aabb water = new Aabb(new Vector2F(-20.0f, -2.0f), new Vector2F(20.0f, 2.0f));
            BuoyancyController controller = new BuoyancyController(water, 2.5f, 2.0f, 1.0f, world.GetGravity);
            world.Add(controller);

            Body floatingBox = world.CreateRectangle(1.6f, 1.6f, 0.5f, new Vector2F(0.0f, 4.0f), 0.0f, BodyType.Dynamic);

            runtime.StepWorld(world, 360, step =>
            {
                if (step % 120 == 0)
                {
                    runtime.PrintBodyState("Floating box at step " + step, floatingBox);
                }
            });
        }
    }
}