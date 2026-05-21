// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SampleCatalog.cs
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

using System.Collections.Generic;
using Alis.Core.Physic.Sample.Samples;

namespace Alis.Core.Physic.Sample
{
    /// <summary>
    /// The sample catalog class
    /// </summary>
    internal static class SampleCatalog
    {
        /// <summary>
        /// Gets the value of the all
        /// </summary>
        public static IReadOnlyList<IPhysicSample> All { get; } =
            new List<IPhysicSample>
            {
                new BasicWorldStepSample(),
                new BodyFactoryShapesSample(),
                new ForcesAndImpulsesSample(),
                new CollisionCallbacksSample(),
                new CollisionFilteringAndSensorsSample(),
                new JointsDistanceAndRevoluteSample(),
                new ControllersGravityAndLimitSample(),
                new BuoyancyControllerSample(),
                new SpatialQueriesSample(),
                new CloneAndTransformSample()
            };
    }
}

