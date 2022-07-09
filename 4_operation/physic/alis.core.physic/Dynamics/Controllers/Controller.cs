using System;

namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    /// Base class for controllers. Controllers are a convience for encapsulating common
    /// per-step functionality.
    /// </summary>
    public abstract class Controller : IDisposable
    {
        /// <summary>
        /// The prev
        /// </summary>
        internal Controller Prev;
        /// <summary>
        /// The next
        /// </summary>
        internal Controller Next;

        /// <summary>
        /// The world
        /// </summary>
        internal World World;
        /// <summary>
        /// The body list
        /// </summary>
        protected ControllerEdge BodyList;
        /// <summary>
        /// The body count
        /// </summary>
        protected int BodyCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class
        /// </summary>
        public Controller()
        {
            BodyList = null;
            BodyCount = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Controller"/> class
        /// </summary>
        /// <param name="world">The world</param>
        public Controller(World world)
        {
            BodyList = null;
            BodyCount = 0;

            World = world;
        }

        /// <summary>
        /// Disposes this instance
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
        /// Controllers override this to implement per-step functionality.
        /// </summary>
        public abstract void Step(TimeStep step);

        /// <summary>
        /// Controllers override this to provide debug drawing.
        /// </summary>
        public virtual void Draw(DebugDraw debugDraw) { }

        /// <summary>
        /// Adds a body to the controller list.
        /// </summary>
        public void AddBody(Body body)
        {
            ControllerEdge edge = new ControllerEdge();

            edge.Body = body;
            edge.Controller = this;

            //Add edge to controller list
            edge.NextBody = BodyList;
            edge.PrevBody = null;
            if (BodyList != null)
                BodyList.PrevBody = edge;
            BodyList = edge;
            ++BodyCount;

            //Add edge to body list
            edge.NextController = body._controllerList;
            edge.PrevController = null;
            if (body._controllerList != null)
                body._controllerList.PrevController = edge;
            body._controllerList = edge;
        }

        /// <summary>
        /// Removes a body from the controller list.
        /// </summary>
        public void RemoveBody(Body body)
        {
            //Assert that the controller is not empty
            Box2DXDebug.Assert(BodyCount > 0);

            //Find the corresponding edge
            ControllerEdge edge = BodyList;
            while (edge != null && edge.Body != body)
                edge = edge.NextBody;

            //Assert that we are removing a body that is currently attached to the controller
            Box2DXDebug.Assert(edge != null);

            //Remove edge from controller list
            if (edge.PrevBody != null)
                edge.PrevBody.NextBody = edge.NextBody;
            if (edge.NextBody != null)
                edge.NextBody.PrevBody = edge.PrevBody;
            if (edge == BodyList)
                BodyList = edge.NextBody;
            --BodyCount;

            //Remove edge from body list
            if (edge.PrevController != null)
                edge.PrevController.NextController = edge.NextController;
            if (edge.NextController != null)
                edge.NextController.PrevController = edge.PrevController;
            if (edge == body._controllerList)
                body._controllerList = edge.NextController;

            //Free the edge
            edge = null;
        }

        /// <summary>
        /// Removes all bodies from the controller list.
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
                    edge.PrevController.NextController = edge.NextController;
                if (edge.NextController != null)
                    edge.NextController.PrevController = edge.PrevController;
                if (edge == edge.Body._controllerList)
                    edge.Body._controllerList = edge.NextController;

                //Free the edge
                //m_world->m_blockAllocator.Free(edge, sizeof(b2ControllerEdge));
            }

            BodyCount = 0;
        }

        /// <summary>
        /// Get the next body in the world's body list.
        /// </summary>
        internal Controller GetNext() { return Next; }

        /// <summary>
        /// Get the parent world of this body.
        /// </summary>
        internal World GetWorld() { return World; }

        /// <summary>
        /// Get the attached body list
        /// </summary>
        internal ControllerEdge GetBodyList() { return BodyList; }
    }
}