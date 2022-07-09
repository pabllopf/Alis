namespace Alis.Core.Physic.Dynamics.Controllers
{
    /// <summary>
    /// A controller edge is used to connect bodies and controllers together
    /// in a bipartite graph.
    /// </summary>
    public class ControllerEdge
    {
        /// <summary>
        /// The controller
        /// </summary>
        public Controller controller;		// provides quick access to other end of this edge.
        /// <summary>
        /// The body
        /// </summary>
        public Body body;					// the body
        /// <summary>
        /// The prev body
        /// </summary>
        public ControllerEdge prevBody;		// the previous controller edge in the controllers's joint list
        /// <summary>
        /// The next body
        /// </summary>
        public ControllerEdge nextBody;		// the next controller edge in the controllers's joint list
        /// <summary>
        /// The prev controller
        /// </summary>
        public ControllerEdge prevController;		// the previous controller edge in the body's joint list
        /// <summary>
        /// The next controller
        /// </summary>
        public ControllerEdge nextController;		// the next controller edge in the body's joint list
    }
}