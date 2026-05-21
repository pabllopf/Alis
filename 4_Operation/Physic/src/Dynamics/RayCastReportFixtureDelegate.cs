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
    ///     Called for each fixture found in the query. You control how the ray cast
    ///     proceeds by returning a float:
    ///     return -1: ignore this fixture and continue
    ///     return 0: terminate the ray cast
    ///     return fraction: clip the ray to this point
    ///     return 1: don't clip the ray and continue
    ///     @param fixture the fixture hit by the ray
    ///     @param point the point of initial intersection
    ///     @param normal the normal vector at the point of intersection
    ///     @return 0 to terminate, fraction to clip the ray for closest hit, 1 to continue
    /// </summary>
    public delegate float RayCastReportFixtureDelegate(Fixture fixture, Vector2F point, Vector2F normal, float fraction);
}