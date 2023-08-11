namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The clear depth target entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class ClearDepthTargetEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The depth
        /// </summary>
        public float Depth;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDepthTargetEntry"/> class
        /// </summary>
        /// <param name="depth">The depth</param>
        public ClearDepthTargetEntry(float depth)
        {
            Depth = depth;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearDepthTargetEntry"/> class
        /// </summary>
        public ClearDepthTargetEntry() { }

        /// <summary>
        /// Inits the depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <returns>The clear depth target entry</returns>
        public ClearDepthTargetEntry Init(float depth)
        {
            Depth = depth;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
        }
    }
}