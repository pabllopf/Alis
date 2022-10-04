// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Controller.cs
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

using System;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Body;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    ///     Base class for controllers. Controllers are a convience for encapsulating common
    ///     per-step functionality.
    /// </summary>
    public abstract class Controller : IDisposable
    {
        /// <summary>
        ///     The body count
        /// </summary>
        protected int BodyCount;

        /// <summary>
        ///     The body list
        /// </summary>
        protected ControllerEdge BodyList;

        /// <summary>
        ///     The next
        /// </summary>
        internal Controller Next;

        /// <summary>
        ///     The prev
        /// </summary>
        internal Controller Prev;

        /// <summary>
        ///     The world
        /// </summary>
        internal World World;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Controller" /> class
        /// </summary>
        public Controller()
        {
            BodyList = null;
            BodyCount = 0;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Controller" /> class
        /// </summary>
        /// <param name="world">The world</param>
        public Controller(World world)
        {
            BodyList = null;
            BodyCount = 0;

            World = world;
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            //Remove attached bodies

            //Previus implementation:
            //while (_bodyCount > 0)
            //    RemoveBody(_bodyList.body);

            Clear();
        }

        /// <summary>
        ///     Controllers override this to implement per-step functionality.
        /// </summary>
        public abstract void Step(TimeStep step);

        /// <summary>
        ///     Adds a body to the controller list.
        /// </summary>
        public void AddBody(BodyBase bodyBase)
        {
            ControllerEdge edge = new ControllerEdge();

            edge.BodyBase = bodyBase;
            edge.Controller = this;

            //Add edge to controller list
            edge.NextBody = BodyList;
            edge.PrevBody = null;
            if (BodyList != null)
            {
                BodyList.PrevBody = edge;
            }

            BodyList = edge;
            ++BodyCount;

            //Add edge to body list
            edge.NextController = bodyBase.ControllerList;
            edge.PrevController = null;
            if (bodyBase.ControllerList != null)
            {
                bodyBase.ControllerList.PrevController = edge;
            }

            bodyBase.ControllerList = edge;
        }

        /// <summary>
        ///     Removes a body from the controller list.
        /// </summary>
        public void RemoveBody(BodyBase bodyBase)
        {
            //Assert that the controller is not empty
            Box2DxDebug.Assert(BodyCount > 0);

            //Find the corresponding edge
            ControllerEdge edge = BodyList;
            while (edge != null && edge.BodyBase != bodyBase)
            {
                edge = edge.NextBody;
            }

            //Assert that we are removing a body that is currently attached to the controller
            Box2DxDebug.Assert(edge != null);

            //Remove edge from controller list
            if (edge.PrevBody != null)
            {
                edge.PrevBody.NextBody = edge.NextBody;
            }

            if (edge.NextBody != null)
            {
                edge.NextBody.PrevBody = edge.PrevBody;
            }

            if (edge == BodyList)
            {
                BodyList = edge.NextBody;
            }

            --BodyCount;

            //Remove edge from body list
            if (edge.PrevController != null)
            {
                edge.PrevController.NextController = edge.NextController;
            }

            if (edge.NextController != null)
            {
                edge.NextController.PrevController = edge.PrevController;
            }

            if (edge == bodyBase.ControllerList)
            {
                bodyBase.ControllerList = edge.NextController;
            }

            //Free the edge
            edge = null;
        }

        /// <summary>
        ///     Removes all bodies from the controller list.
        /// </summary>
        public void Clear()
        {
            ControllerEdge current = BodyList;
            while (current != null)
            {
                ControllerEdge edge = current;

                //Remove edge from controller list
                BodyList = edge.NextBody;

                //Remove edge from body list
                if (edge.PrevController != null)
                {
                    edge.PrevController.NextController = edge.NextController;
                }

                if (edge.NextController != null)
                {
                    edge.NextController.PrevController = edge.PrevController;
                }

                if (edge == edge.BodyBase.ControllerList)
                {
                    edge.BodyBase.ControllerList = edge.NextController;
                }

                //Free the edge
                //m_world->m_blockAllocator.Free(edge, sizeof(b2ControllerEdge));
            }

            BodyCount = 0;
        }

        /// <summary>
        ///     Get the next body in the world's body list.
        /// </summary>
        internal Controller GetNext() => Next;

        /// <summary>
        ///     Get the parent world of this body.
        /// </summary>
        internal World GetWorld() => World;

        /// <summary>
        ///     Get the attached body list
        /// </summary>
        internal ControllerEdge GetBodyList() => BodyList;
    }
}