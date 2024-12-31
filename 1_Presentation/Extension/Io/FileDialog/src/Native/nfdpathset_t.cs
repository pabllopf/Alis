using System;

namespace NativeFileDialogSharp.Native
{
    /// <summary>
    /// The nfdpathset
    /// </summary>
    public struct nfdpathset_t
    {
        /// <summary>
        /// The buf
        /// </summary>
        public IntPtr buf;
        /// <summary>
        /// The indices
        /// </summary>
        public IntPtr indices;
        /// <summary>
        /// The count
        /// </summary>
        public UIntPtr count;
    }
}