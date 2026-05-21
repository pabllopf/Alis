// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllersGravityAndLimitSample.cs
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
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Sample.Samples
{
    /// <summary>
    /// The controllers gravity and limit sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class ControllersGravityAndLimitSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "controllers";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Gravity and velocity-limit controllers";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Uses controllers to add custom gravity and cap linear/angular speeds.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body orbA = world.CreateCircle(0.5f, 1.0f, new Vector2F(-6.0f, 0.0f), BodyType.Dynamic);
            Body orbB = world.CreateCircle(0.5f, 1.0f, new Vector2F(6.0f, 0.0f), BodyType.Dynamic);

            GravityController gravityController = new GravityController(0.20f, 40.0f, 0.5f);
            gravityController.AddPoint(Vector2F.Zero);

            VelocityLimitController limitController = new VelocityLimitController(4.5f, 2.0f);
            limitController.AddBody(orbA);
            limitController.AddBody(orbB);

            world.Add(gravityController);
            world.Add(limitController);

            orbA.ApplyLinearImpulse(new Vector2F(6.0f, 1.5f));
            orbB.ApplyLinearImpulse(new Vector2F(-6.0f, -1.0f));

            runtime.StepWorld(world, 300);
            runtime.PrintBodyState("Orb A", orbA);
            runtime.PrintBodyState("Orb B", orbB);
        }
    }
}