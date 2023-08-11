namespace Veldrid.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The dispatch entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class DispatchEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountX;
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountY;
        /// <summary>
        /// The group count
        /// </summary>
        public uint GroupCountZ;

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatchEntry"/> class
        /// </summary>
        public DispatchEntry() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="DispatchEntry"/> class
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        public DispatchEntry(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            GroupCountX = groupCountX;
            GroupCountY = groupCountY;
            GroupCountZ = groupCountZ;
        }

        /// <summary>
        /// Inits the group count x
        /// </summary>
        /// <param name="groupCountX">The group count</param>
        /// <param name="groupCountY">The group count</param>
        /// <param name="groupCountZ">The group count</param>
        /// <returns>The dispatch entry</returns>
        public DispatchEntry Init(uint groupCountX, uint groupCountY, uint groupCountZ)
        {
            GroupCountX = groupCountX;
            GroupCountY = groupCountY;
            GroupCountZ = groupCountZ;

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