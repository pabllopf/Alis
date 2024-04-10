// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MyBreakableBody.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Test.Samples
{
   /// <summary>
   /// The my breakable body class
   /// </summary>
   /// <seealso cref="BreakableBody"/>
   public class MyBreakableBody : BreakableBody
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MyBreakableBody"/> class
    /// </summary>
    /// <param name="world">The world</param>
    /// <param name="parts">The parts</param>
    /// <param name="density">The density</param>
    /// <param name="position">The position</param>
    /// <param name="rotation">The rotation</param>
    public MyBreakableBody(World world, ICollection<Vertices> parts, float density, Vector2 position, float rotation)
        : base(world, parts, density, position, rotation)
    {
    }
}
}