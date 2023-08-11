namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The clear color target entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class ClearColorTargetEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public uint Index;
        /// <summary>
        /// The clear color
        /// </summary>
        public RgbaFloat ClearColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearColorTargetEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        public ClearColorTargetEntry(uint index, RgbaFloat clearColor)
        {
            Index = index;
            ClearColor = clearColor;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClearColorTargetEntry"/> class
        /// </summary>
        public ClearColorTargetEntry() { }

        /// <summary>
        /// Inits the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="clearColor">The clear color</param>
        /// <returns>The clear color target entry</returns>
        public ClearColorTargetEntry Init(uint index, RgbaFloat clearColor)
        {
            Index = index;
            ClearColor = clearColor;
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