// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CloneAndTransformSample.cs
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
    /// The clone and transform sample class
    /// </summary>
    /// <seealso cref="IPhysicSample"/>
    internal sealed class CloneAndTransformSample : IPhysicSample
    {
        /// <summary>
        /// Gets the value of the key
        /// </summary>
        public string Key => "clone";

        /// <summary>
        /// Gets the value of the title
        /// </summary>
        public string Title => "Clone, transform and point-space conversions";

        /// <summary>
        /// Gets the value of the description
        /// </summary>
        public string Description => "Clones bodies and converts points between local/world space.";

        /// <summary>
        /// Runs the runtime
        /// </summary>
        /// <param name="runtime">The runtime</param>
        public void Run(SampleRuntime runtime)
        {
            WorldPhysic world = runtime.CreateWorld(Vector2F.Zero);

            Body original = world.CreateRectangle(2.0f, 1.0f, 1.0f, new Vector2F(-2.0f, 0.0f), 0.25f, BodyType.Dynamic);
            original.LinearVelocity = new Vector2F(1.5f, 0.0f);
            original.AngularVelocity = 1.0f;

            Body clone = original.DeepClone(world);
            clone.Position = new Vector2F(2.0f, 0.0f);
            clone.ApplyLinearImpulse(new Vector2F(0.0f, 2.5f));

            Vector2F localPoint = new Vector2F(1.0f, 0.0f);
            Vector2F worldPoint = original.GetWorldPoint(localPoint);
            Vector2F backToLocal = original.GetLocalPoint(worldPoint);

            Console.WriteLine("World point from local (1,0): ({0:F2}, {1:F2})", worldPoint.X, worldPoint.Y);
            Console.WriteLine("Local point recovered: ({0:F2}, {1:F2})", backToLocal.X, backToLocal.Y);

            runtime.StepWorld(world, 180);
            runtime.PrintBodyState("Original", original);
            runtime.PrintBodyState("Clone", clone);
        }
    }
}