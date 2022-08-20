// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstantAccelController.cs
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

using Alis.Aspect.Math;
using Alis.Aspect.Time;
using Alis.Core.Physic.Dynamics.Bodys;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     The constant accel controller class
    /// </summary>
    /// <seealso cref="Controller" />
    public class ConstantAccelController : Controller
    {
        /// <summary>
        ///     The force to apply
        /// </summary>
        public Vector2 A;

        /// <summary>
        ///     The constant accel controller def
        /// </summary>
        private ConstantAccelControllerDef constantAccelControllerDef;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstantAccelController" /> class
        /// </summary>
        /// <param name="def">The def</param>
        public ConstantAccelController(ConstantAccelControllerDef def)
        {
            constantAccelControllerDef = def;
            A = def.A;
        }

        /// <summary>
        ///     Steps the step
        /// </summary>
        /// <param name="step">The step</param>
        public override void Step(TimeStep step)
        {
            for (ControllerEdge i = BodyList; i != null; i = i.NextBody)
            {
                Body body = i.Body;
                if (body.IsSleeping())
                {
                    continue;
                }

                body.SetLinearVelocity(body.GetLinearVelocity() + step.Dt * A);
            }
        }
    }
}