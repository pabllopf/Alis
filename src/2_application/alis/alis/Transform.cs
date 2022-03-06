// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Transform.cs
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

using System.Numerics;

namespace Alis
{
    public class Transform : Alis.Core.Entities.Transform
    {
        public Transform(): base()
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Transform" /> class
        /// </summary>
        /// <param name="scale">The scale</param>
        public Transform(Vector3 scale) : base(scale)
        {
        }

        /// <summary>Initializes a new instance of the <see cref="Transform" /> class.</summary>
        /// <param name="scale">The size.</param>
        /// <param name="position">The position.</param>
        /// <param name="rotation">The rotation.</param>
        public Transform(Vector3 scale, Vector3 position, Vector3 rotation)  : base(scale, position, rotation)
        {
        }
    }
}