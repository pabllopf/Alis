namespace imnodesNET
{
    /// <summary>
    /// The im nodes editor context ptr class
    /// </summary>
    public class ImNodesEditorContextPtr
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesEditorContextPtr"/> class
        /// </summary>
        /// <param name="ret">The ret</param>
        public unsafe ImNodesEditorContextPtr(ImNodesEditorContext* ret)
        {
            NativePtr = ret;
        }

        /// <summary>
        /// Gets or sets the value of the native ptr
        /// </summary>
        public unsafe ImNodesEditorContext* NativePtr { get; private set; }
    }
}