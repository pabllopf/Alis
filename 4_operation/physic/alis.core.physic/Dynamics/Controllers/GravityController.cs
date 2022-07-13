// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GravityController.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Aspect.Math;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     The gravity controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public class GravityController : Controller
    {
        /// <summary>
        ///     Specifies the strength of the gravitiation force
        /// </summary>
        public readonly float G;

        /// If true, gravity is proportional to r^-2, otherwise r^-1
        public readonly bool InvSqr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GravityController" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public GravityController(GravityControllerDef def)
        {
            G = def.G;
            InvSqr = def.InvSqr;
        }

        /// <summary>
        ///     Steps the step
        /// </summary>
        /// <param name="step">The step</param>
        public override void Step(TimeStep step)
        {
            //B2_NOT_USED(step);
            if (InvSqr)
            {
                for (ControllerEdge i = BodyList; i != null; i = i.NextBody)
                {
                    Body body1 = i.Body;
                    for (ControllerEdge j = BodyList; j != i; j = j.NextBody)
                    {
                        Body body2 = j.Body;
                        Vector2 d = body2.GetWorldCenter() - body1.GetWorldCenter();
                        float r2 = d.LengthSquared();
                        if (r2 < Settings.FltEpsilon)
                        {
                            continue;
                        }

                        Vector2 f = G / r2 / Math.Sqrt(r2) * body1.GetMass() * body2.GetMass() * d;
                        body1.ApplyForce(f, body1.GetWorldCenter());
                        body2.ApplyForce(-1.0f * f, body2.GetWorldCenter());
                    }
                }
            }
            else
            {
                for (ControllerEdge i = BodyList; i != null; i = i.NextBody)
                {
                    Body body1 = i.Body;
                    for (ControllerEdge j = BodyList; j != i; j = j.NextBody)
                    {
                        Body body2 = j.Body;
                        Vector2 d = body2.GetWorldCenter() - body1.GetWorldCenter();
                        float r2 = d.LengthSquared();
                        if (r2 < Settings.FltEpsilon)
                        {
                            continue;
                        }

                        Vector2 f = G / r2 * body1.GetMass() * body2.GetMass() * d;
                        body1.ApplyForce(f, body1.GetWorldCenter());
                        body2.ApplyForce(-1.0f * f, body2.GetWorldCenter());
                    }
                }
            }
        }
    }
}