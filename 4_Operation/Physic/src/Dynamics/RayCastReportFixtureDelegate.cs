// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastReportFixtureDelegate.cs
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

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     Represents a callback invoked for each fixture intersected by a ray during a ray cast query.
    ///     The return value controls the ray cast behavior:
    ///     <list type="table">
    ///     <item><term>-1</term><description>Ignore this fixture and continue the ray cast</description></item>
    ///     <item><term>0</term><description>Terminate the ray cast</description></item>
    ///     <item><term>fraction</term><description>Clip the ray to this point (for closest-hit queries)</description></item>
    ///     <item><term>1</term><description>Don't clip the ray and continue</description></item>
    ///     </list>
    /// </summary>
    /// <param name="fixture">The fixture hit by the ray.</param>
    /// <param name="point">The world-space point of intersection.</param>
    /// <param name="normal">The surface normal at the point of intersection.</param>
    /// <param name="fraction">The fraction along the ray at which the intersection occurred.</param>
    /// <returns>A float controlling the ray cast behavior: 0 to terminate, fraction to clip, 1 to continue, -1 to skip.</returns>
    public delegate float RayCastReportFixtureDelegate(Fixture fixture, Vector2F point, Vector2F normal, float fraction);
}