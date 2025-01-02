using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using NativeFileDialogSharp.Native;

namespace NativeFileDialogSharp
{
    /// <summary>
    /// The dialog class
    /// </summary>
    public static class Dialog
    {
        /// <summary>
        /// The get encoder
        /// </summary>
        private static readonly Encoder utf8encoder = Encoding.UTF8.GetEncoder();

        /// <summary>
        /// The is 32 bit windows on net framework
        /// </summary>
        private static readonly bool need32bit = Is32BitWindowsOnNetFramework();
        
        /// <summary>
        /// Describes whether is 32 bit windows on net framework
        /// </summary>
        /// <returns>The bool</returns>
        private static bool Is32BitWindowsOnNetFramework()
        {
            try
            {
                // we call a function that does nothing just to test if we can load it properly
                NativeFileDialogSharp.Native.NativeFunctions.NFD_Dummy();
                return false;
            }
            catch
            {
                // a call to a default library failed, let's attempt the other one
                try
                {
                    NativeFileDialogSharp.Native.NativeFunctions32.NFD_Dummy();
                    return true;
                }
                catch
                {
                    // both of them failed so we may as well default to the default one for predictability
                    return false;
                }
            }
        }

        /// <summary>
        /// Returns the utf 8 using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <returns>The bytes</returns>
        private static unsafe byte[] ToUtf8(string s)
        {
            var byteCount = Encoding.UTF8.GetByteCount(s);
            var bytes = new byte[byteCount + 1];
            fixed (byte* o = bytes)
            fixed (char* input = s)
            {
                utf8encoder.Convert(input, s.Length, o, bytes.Length, true, out _, out var _,
                    out var completed);
                Debug.Assert(completed);
            }

            return bytes;
        }

        /// <summary>
        /// Gets the null terminated string length using the specified null terminated string
        /// </summary>
        /// <param name="nullTerminatedString">The null terminated string</param>
        /// <returns>The count</returns>
        private static unsafe int GetNullTerminatedStringLength(byte* nullTerminatedString)
        {
            int count = 0;
            var ptr = nullTerminatedString;
            while (*ptr != 0)
            {
                ptr++;
                count++;
            }

            return count;
        }

        /// <summary>
        /// Creates the utf 8 using the specified null terminated string
        /// </summary>
        /// <param name="nullTerminatedString">The null terminated string</param>
        /// <returns>The string</returns>
        private static unsafe string FromUtf8(byte* nullTerminatedString)
        {
            return Encoding.UTF8.GetString(nullTerminatedString, GetNullTerminatedStringLength(nullTerminatedString));
        }

        /// <summary>
        /// Files the open using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static unsafe DialogResult FileOpen(string filterList = null, string defaultPath = null)
        {
            fixed (byte* filterListNts = filterList != null ? ToUtf8(filterList) : null)
            fixed (byte* defaultPathNts = defaultPath != null ? ToUtf8(defaultPath) : null)
            {
                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                var result = need32bit 
                    ? NativeFunctions32.NFD_OpenDialog(filterListNts, defaultPathNts, out outPathIntPtr)
                    : NativeFunctions.NFD_OpenDialog(filterListNts, defaultPathNts, out outPathIntPtr);
                if (result == nfdresult_t.NFD_ERROR)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == nfdresult_t.NFD_OKAY)
                {
                    var outPathNts = (byte*)outPathIntPtr.ToPointer();
                    path = FromUtf8(outPathNts);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
        }

        /// <summary>
        /// Files the save using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static unsafe DialogResult FileSave(string filterList = null, string defaultPath = null)
        {
            fixed (byte* filterListNts = filterList != null ? ToUtf8(filterList) : null)
            fixed (byte* defaultPathNts = defaultPath != null ? ToUtf8(defaultPath) : null)
            {
                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                var result = need32bit 
                    ? NativeFunctions32.NFD_SaveDialog(filterListNts, defaultPathNts, out outPathIntPtr) 
                    : NativeFunctions.NFD_SaveDialog(filterListNts, defaultPathNts, out outPathIntPtr);
                if (result == nfdresult_t.NFD_ERROR)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == nfdresult_t.NFD_OKAY)
                {
                    var outPathNts = (byte*)outPathIntPtr.ToPointer();
                    path = FromUtf8(outPathNts);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
        }

        /// <summary>
        /// Folders the picker using the specified default path
        /// </summary>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static unsafe DialogResult FolderPicker(string defaultPath = null)
        {
            fixed (byte* defaultPathNts = defaultPath != null ? ToUtf8(defaultPath) : null)
            {
                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                var result = need32bit
                    ? NativeFunctions32.NFD_PickFolder(defaultPathNts, out outPathIntPtr)
                    : NativeFunctions.NFD_PickFolder(defaultPathNts, out outPathIntPtr);
                if (result == nfdresult_t.NFD_ERROR)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == nfdresult_t.NFD_OKAY)
                {
                    var outPathNts = (byte*)outPathIntPtr.ToPointer();
                    path = FromUtf8(outPathNts);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
        }

        /// <summary>
        /// Files the open multiple using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static unsafe DialogResult FileOpenMultiple(string filterList = null, string defaultPath = null)
        {
            fixed (byte* filterListNts = filterList != null ? ToUtf8(filterList) : null)
            fixed (byte* defaultPathNts = defaultPath != null ? ToUtf8(defaultPath) : null)
            {
                List<string> paths = null;
                string errorMessage = null;
                nfdpathset_t pathSet;
                var result = need32bit
                    ? NativeFunctions32.NFD_OpenDialogMultiple(filterListNts, defaultPathNts, &pathSet)
                    : NativeFunctions.NFD_OpenDialogMultiple(filterListNts, defaultPathNts, &pathSet);
                if (result == nfdresult_t.NFD_ERROR)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == nfdresult_t.NFD_OKAY)
                {
                    var pathCount = (int)NativeFunctions.NFD_PathSet_GetCount(&pathSet).ToUInt32();
                    paths = new List<string>(pathCount);
                    for (int i = 0; i < pathCount; i++)
                    {
                        paths.Add(FromUtf8(NativeFunctions.NFD_PathSet_GetPath(&pathSet, new UIntPtr((uint)i))));
                    }

                    NativeFunctions.NFD_PathSet_Free(&pathSet);
                }

                return new DialogResult(result, null, paths, errorMessage);
            }
        }
    }
}