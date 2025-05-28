using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.GlfwLib.Structs;

namespace Alis.Core.Graphic.GlfwLib
{
    /// <summary>
    ///     This is the function signature for file drop callbacks.
    /// </summary>
    /// <param name="window">The window that received the event.</param>
    /// <param name="count">The number of dropped files.</param>
    /// <param name="arrayPtr">Pointer to an array UTF-8 encoded file and/or directory path name pointers.</param>
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void FileDropCallback(Window window, int count, IntPtr arrayPtr);
}