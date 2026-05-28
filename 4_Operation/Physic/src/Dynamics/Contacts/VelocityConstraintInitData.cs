// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VelocityConstraintInitData.cs
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

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     Initialization data for velocity constraint points
    /// </summary>
    internal readonly record struct VelocityConstraintInitData(
        Vector2F cA,
        Vector2F cB,
        float mA,
        float mB,
        float iA,
        float iB,
        Vector2F tangent,
        Vector2F vA,
        float wA,
        Vector2F vB,
        float wB)
    {

        internal Vector2F cA { get; } = cA;
        internal Vector2F cB { get; } = cB;
        internal float mA { get; } = mA;
        internal float mB { get; } = mB;
        internal float iA { get; } = iA;
        internal float iB { get; } = iB;
        internal Vector2F tangent { get; } = tangent;
        internal Vector2F vA { get; } = vA;
        internal float wA { get; } = wA;
        internal Vector2F vB { get; } = vB;
        internal float wB { get; } = wB;
    }
}