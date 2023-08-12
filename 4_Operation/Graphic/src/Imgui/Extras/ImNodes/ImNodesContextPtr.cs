namespace Alis.Core.Graphic.Imgui.Extras.ImNodes
{
    /// <summary>
    /// The im nodes context ptr
    /// </summary>
    public unsafe struct ImNodesContextPtr
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesContextPtr"/> class
        /// </summary>
        /// <param name="ret">The ret</param>
        public unsafe ImNodesContextPtr(ImNodesContext* ret)
        {
            NativePtr = ret;
        }

        /// <summary>
        /// Gets or sets the value of the native ptr
        /// </summary>
        public unsafe ImNodesContext* NativePtr { get; private set; }
    }
}