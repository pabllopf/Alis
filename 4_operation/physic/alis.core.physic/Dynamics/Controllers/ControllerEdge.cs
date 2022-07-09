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
        public Controller Controller;		// provides quick access to other end of this edge.
        /// <summary>
        /// The body
        /// </summary>
        public Body Body;					// the body
        /// <summary>
        /// The prev body
        /// </summary>
        public ControllerEdge PrevBody;		// the previous controller edge in the controllers's joint list
        /// <summary>
        /// The next body
        /// </summary>
        public ControllerEdge NextBody;		// the next controller edge in the controllers's joint list
        /// <summary>
        /// The prev controller
        /// </summary>
        public ControllerEdge PrevController;		// the previous controller edge in the body's joint list
        /// <summary>
        /// The next controller
        /// </summary>
        public ControllerEdge NextController;		// the next controller edge in the body's joint list
    }
}