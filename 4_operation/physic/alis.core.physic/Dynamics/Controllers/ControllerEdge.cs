// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   ControllerEdge.cs
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

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     A controller edge is used to connect bodies and controllers together
    ///     in a bipartite graph.
    /// </summary>
    public class ControllerEdge
    {
        /// <summary>
        ///     The body
        /// </summary>
        public Body Body; // the body

        /// <summary>
        ///     The controller
        /// </summary>
        public Controller Controller; // provides quick access to other end of this edge.

        /// <summary>
        ///     The next body
        /// </summary>
        public ControllerEdge NextBody; // the next controller edge in the controllers's joint list

        /// <summary>
        ///     The next controller
        /// </summary>
        public ControllerEdge NextController; // the next controller edge in the body's joint list

        /// <summary>
        ///     The prev body
        /// </summary>
        public ControllerEdge PrevBody; // the previous controller edge in the controllers's joint list

        /// <summary>
        ///     The prev controller
        /// </summary>
        public ControllerEdge PrevController; // the previous controller edge in the body's joint list
    }
}