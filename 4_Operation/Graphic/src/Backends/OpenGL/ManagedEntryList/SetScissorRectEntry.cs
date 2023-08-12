namespace Alis.Core.Graphic.Backends.OpenGL.ManagedEntryList
{
    /// <summary>
    /// The set scissor rect entry class
    /// </summary>
    /// <seealso cref="OpenGLCommandEntry"/>
    internal class SetScissorRectEntry : OpenGLCommandEntry
    {
        /// <summary>
        /// The index
        /// </summary>
        public uint Index;
        /// <summary>
        /// The 
        /// </summary>
        public uint X;
        /// <summary>
        /// The 
        /// </summary>
        public uint Y;
        /// <summary>
        /// The width
        /// </summary>
        public uint Width;
        /// <summary>
        /// The height
        /// </summary>
        public uint Height;

        /// <summary>
        /// Initializes a new instance of the <see cref="SetScissorRectEntry"/> class
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        public SetScissorRectEntry(uint index, uint x, uint y, uint width, uint height)
        {
            Index = index;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetScissorRectEntry"/> class
        /// </summary>
        public SetScissorRectEntry() { }

        /// <summary>
        /// Inits the index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The set scissor rect entry</returns>
        public SetScissorRectEntry Init(uint index, uint x, uint y, uint width, uint height)
        {
            Index = index;
            X = x;
            Y = y;
            Width = width;
            Height = height;
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