using System;
using System.Runtime.InteropServices;

namespace NativeFileDialogSharp.Native
{
    /// <summary>
    /// The native functions 32 class
    /// </summary>
    public static class NativeFunctions32
    {
        /// <summary>
        /// The library name
        /// </summary>
        public const string LibraryName = "nfd_x86";

        /// <summary>
        /// Nfds the open dialog using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <param name="outPath">The out path</param>
        /// <returns>The nfdresult</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe nfdresult_t NFD_OpenDialog(byte* filterList, byte* defaultPath, out IntPtr outPath);

        /// <summary>
        /// Nfds the open dialog multiple using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <param name="outPaths">The out paths</param>
        /// <returns>The nfdresult</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe nfdresult_t NFD_OpenDialogMultiple(byte* filterList, byte* defaultPath,
            nfdpathset_t* outPaths);

        /// <summary>
        /// Nfds the save dialog using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <param name="outPath">The out path</param>
        /// <returns>The nfdresult</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe nfdresult_t NFD_SaveDialog(byte* filterList, byte* defaultPath, out IntPtr outPath);

        /// <summary>
        /// Nfds the pick folder using the specified default path
        /// </summary>
        /// <param name="defaultPath">The default path</param>
        /// <param name="outPath">The out path</param>
        /// <returns>The nfdresult</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe nfdresult_t NFD_PickFolder(byte* defaultPath, out IntPtr outPath);

        /// <summary>
        /// Nfds the get error
        /// </summary>
        /// <returns>The byte</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe byte* NFD_GetError();

        /// <summary>
        /// Nfds the path set get count using the specified path set
        /// </summary>
        /// <param name="pathSet">The path set</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe UIntPtr NFD_PathSet_GetCount(nfdpathset_t* pathSet);

        /// <summary>
        /// Nfds the path set get path using the specified path set
        /// </summary>
        /// <param name="pathSet">The path set</param>
        /// <param name="index">The index</param>
        /// <returns>The byte</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe byte* NFD_PathSet_GetPath(nfdpathset_t* pathSet, UIntPtr index);

        /// <summary>
        /// Nfds the path set free using the specified path set
        /// </summary>
        /// <param name="pathSet">The path set</param>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe void NFD_PathSet_Free(nfdpathset_t* pathSet);

        /// <summary>
        /// Nfds the dummy
        /// </summary>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe void NFD_Dummy();

        /// <summary>
        /// Nfds the malloc using the specified bytes
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns>The int ptr</returns>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe IntPtr NFD_Malloc(UIntPtr bytes);

        /// <summary>
        /// Nfds the free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern unsafe void NFD_Free(IntPtr ptr);
    }
}