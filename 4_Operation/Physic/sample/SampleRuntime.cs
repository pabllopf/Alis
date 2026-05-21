// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SampleRuntime.cs
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

namespace Alis.Core.Physic.Sample
{
    /// <summary>
    /// The sample runtime class
    /// </summary>
    internal sealed class SampleRuntime
    {
        /// <summary>
        /// The fixed delta time
        /// </summary>
        public const float FixedDeltaTime = 1.0f / 60.0f;

        /// <summary>
        /// Creates the world using the specified gravity
        /// </summary>
        /// <param name="gravity">The gravity</param>
        /// <returns>The world</returns>
        public WorldPhysic CreateWorld(Vector2F gravity)
        {
            WorldPhysic world = new WorldPhysic(gravity);
            return world;
        }

        /// <summary>
        /// Adds the ground using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public void AddGround(WorldPhysic world, float y = -10.0f, float width = 80.0f, float height = 1.0f)
        {
            world.CreateRectangle(width, height, 0.0f, new Vector2F(0.0f, y), 0.0f, BodyType.Static);
        }

        /// <summary>
        /// Steps the world using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="steps">The steps</param>
        /// <param name="perStep">The per step</param>
        public void StepWorld(WorldPhysic world, int steps, Action<int> perStep = null)
        {
            for (int i = 0; i < steps; i++)
            {
                world.Step(FixedDeltaTime);
                if (perStep != null)
                {
                    perStep(i + 1);
                }
            }
        }

        /// <summary>
        /// Prints the body state using the specified label
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="body">The body</param>
        public void PrintBodyState(string label, Body body)
        {
            Console.WriteLine(
                "{0}: pos=({1:F2}, {2:F2}) vel=({3:F2}, {4:F2}) angle={5:F2}",
                label,
                body.Position.X,
                body.Position.Y,
                body.LinearVelocity.X,
                body.LinearVelocity.Y,
                body.Rotation);
        }

        /// <summary>
        /// Prints the separator
        /// </summary>
        public void PrintSeparator()
        {
            Console.WriteLine(new string('-', 72));
        }
    }
}

