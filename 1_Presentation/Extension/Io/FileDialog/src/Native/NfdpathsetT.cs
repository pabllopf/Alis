namespace Alis.Extension.Io.FileDialog.Native
{
    /// <summary>
    /// The nfdpathset
    /// </summary>
    public struct NfdpathsetT
    {
        /// <summary>
        /// The buf
        /// </summary>
        public IntPtr Buf;
        
        /// <summary>
        /// The indices
        /// </summary>
        public IntPtr Indices;
        
        /// <summary>
        /// The count
        /// </summary>
        public UIntPtr Count;
    }
}