// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TensorDampingController.cs
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
using Alis.Aspect.Time;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     The tensor damping controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public class TensorDampingController : Controller
    {
        /// <summary>
        ///     Set this to a positive number to clamp the maximum amount of damping done.
        ///     Typically one wants maxTimestep to be 1/(max eigenvalue of T), so that damping will never cause something to
        ///     reverse direction
        /// </summary>
        private float maxTimestep;

        /// <summary>
        ///     Tensor to use in damping model
        ///     Some examples (matrixes in format (row1; row2) )
        ///     (-a 0;0 -a)		Standard isotropic damping with strength a
        ///     (0 a;-a 0)		Electron in fixed field - a force at right angles to velocity with proportional magnitude
        ///     (-a 0;0 -b)		Differing x and y damping. Useful e.g. for top-down wheels.
        ///     By the way, tensor in this case just means matrix, don't let the terminology get you down.
        /// </summary>
        private Matrix22 T;

        /// Sets damping independantly along the x and y axes
        public void SetAxisAligned(float xDamping, float yDamping)
        {
            T.Col1.X = -xDamping;
            T.Col1.Y = 0;
            T.Col2.X = 0;
            T.Col2.Y = -yDamping;
            if (xDamping > 0 || yDamping > 0)
            {
                maxTimestep = 1 / Math.Max(xDamping, yDamping);
            }
            else
            {
                maxTimestep = 0;
            }
        }

        /// <summary>
        ///     Steps the step
        /// </summary>
        /// <param name="step">The step</param>
        public override void Step(TimeStep step)
        {
            float timestep = step.Dt;
            if (timestep <= Settings.FltEpsilon)
            {
                return;
            }

            if (timestep > maxTimestep && maxTimestep > 0)
            {
                timestep = maxTimestep;
            }

            for (ControllerEdge i = BodyList; i != null; i = i.NextBody)
            {
                Body body = i.Body;
                if (body.IsSleeping())
                {
                    continue;
                }

                Vector2 damping = body.GetWorldVector(Math.Mul(T, body.GetLocalVector(body.GetLinearVelocity())));
                body.SetLinearVelocity(body.GetLinearVelocity() + timestep * damping);
            }
        }
    }
}