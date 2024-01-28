// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JointEdge.cs
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

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A joint edge is used to connect bodies and joints together in a joint graph where each body is a node and each
    ///     joint is an edge. A joint edge belongs to a doubly linked list maintained in each attached body. Each joint has two
    ///     joint nodes, one for each attached body.
    /// </summary>
    public sealed class JointEdge
    {
        /// <summary>The joint.</summary>
        public Joint Joint;

        /// <summary>The next joint edge in the body's joint list.</summary>
        public JointEdge Next;

        /// <summary>Provides quick access to the other body attached.</summary>
        public Body Other;

        /// <summary>The previous joint edge in the body's joint list.</summary>
        public JointEdge Prev;
    }
}