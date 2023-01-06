// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleWindForce.cs
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

using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Extensions.Controllers.Wind
{
    /// <summary>
    ///     Reference implementation for forces based on AbstractForceController It supports all features provided by the
    ///     base class and illustrates proper usage as an easy to understand example. As a side-effect it is a nice and easy to
    ///     use
    ///     wind force for your projects
    /// </summary>
    public class SimpleWindForce : AbstractForceController
    {
        /// <summary>Direction of the windforce</summary>
        public Vector2F Direction { get; set; }

        /// <summary>The amount of Direction randomization. Allowed range is 0-1.</summary>
        public float Divergence { get; set; }

        /// <summary>
        ///     Ignore the position and apply the force. If off only in the "front" (relative to position and direction) will
        ///     be affected
        /// </summary>
        public bool IgnorePosition { get; set; }

        /// <summary>
        ///     Applies the force using the specified dt
        /// </summary>
        /// <param name="dt">The dt</param>
        /// <param name="strength">The strength</param>
        public override void ApplyForce(float dt, float strength)
        {
            foreach (Body body in World.BodyList)
            {
                float decayMultiplier = GetDecayMultiplier(body);

                if (decayMultiplier != 0)
                {
                    Vector2F forceVector;

                    if (ForceType == ForceTypes.Point)
                    {
                        forceVector = body.Position - Position;
                    }
                    else
                    {
                        Direction = Vector2F.Normalize(Direction);

                        forceVector = Direction;

                        if (forceVector.Length() == 0)
                        {
                            forceVector = new Vector2F(0, 1);
                        }
                    }

                    // Calculate random Variation
                    if (Variation != 0)
                    {
                        float strengthVariation = (float) Randomize.NextDouble() * Helper.Clamp(Variation, 0, 1);
                        forceVector = Vector2F.Normalize(forceVector);
                        body.ApplyForce(forceVector * strength * decayMultiplier * strengthVariation);
                    }
                    else
                    {
                        forceVector = Vector2F.Normalize(forceVector);
                        body.ApplyForce(forceVector * strength * decayMultiplier);
                    }
                }
            }
        }
    }
}