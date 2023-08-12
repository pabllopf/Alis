namespace Alis.Core.Graphic.Backends.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set compute resource set entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetComputeResourceSetEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The slot
        /// </summary>
        public uint Slot;
        /// <summary>
        /// The resource set
        /// </summary>
        public ResourceSet ResourceSet;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetComputeResourceSetEntry"/> class
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        public SetComputeResourceSetEntry(uint slot, ResourceSet rs)
        {
            Slot = slot;
            ResourceSet = rs;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetComputeResourceSetEntry"/> class
        /// </summary>
        public SetComputeResourceSetEntry() { }

        /// <summary>
        /// Inits the slot
        /// </summary>
        /// <param name="slot">The slot</param>
        /// <param name="rs">The rs</param>
        /// <returns>The set compute resource set entry</returns>
        public SetComputeResourceSetEntry Init(uint slot, ResourceSet rs)
        {
            Slot = slot;
            ResourceSet = rs;
            return this;
        }

        /// <summary>
        /// Clears the references
        /// </summary>
        public override void ClearReferences()
        {
            ResourceSet = null;
        }
    }
}