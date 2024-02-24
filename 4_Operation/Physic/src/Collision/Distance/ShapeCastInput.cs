// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShapeCastInput.cs
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

namespace Alis.Core.Physic.Collision.Distance
{
    /// <summary>Input parameters for b2ShapeCast</summary>
    public struct ShapeCastInput
    {
        /// <summary>
        ///     The proxy
        /// </summary>
        public DistanceProxy ProxyA { get; }

        /// <summary>
        ///     The proxy
        /// </summary>
        public DistanceProxy ProxyB { get; }

        /// <summary>
        ///     The transform
        /// </summary>
        public Transform TransformA { get; }

        /// <summary>
        ///     The transform
        /// </summary>
        public Transform TransformB { get; }

        /// <summary>
        ///     The translation
        /// </summary>
        public Vector2 TranslationB { get; }
    }
}