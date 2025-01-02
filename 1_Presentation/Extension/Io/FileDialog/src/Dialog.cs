using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Data.Dll;
using Alis.Extension.Io.FileDialog.Native;
using Alis.Extension.Io.FileDialog.Properties;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    /// The dialog class
    /// </summary>
    public static class Dialog
    {
        public const string NativeLibName = "nfd";
        
        static Dialog() => EmbeddedDllClass.ExtractEmbeddedDlls("nfd", DllType.Lib, NfdDlls.NfdDllBytes, Assembly.GetAssembly(typeof(Dialog)));

        /// <summary>
        /// The is 32 bit windows on net framework
        /// </summary>
        private static readonly bool Need32Bit = Is32BitWindowsOnNetFramework();

        /// <summary>
        /// Describes whether is 32 bit windows on net framework
        /// </summary>
        /// <returns>The bool</returns>
        private static bool Is32BitWindowsOnNetFramework()
        {
            try
            {
                // we call a function that does nothing just to test if we can load it properly
                NativeFunctions.NFD_Dummy();
                return false;
            }
            catch
            {
                // a call to a default library failed, let's attempt the other one
                try
                {
                    NativeFunctions32.NFD_Dummy();
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
        private static byte[] ToUtf8(string s)
        {
            int byteCount = Encoding.UTF8.GetByteCount(s);
            byte[] bytes = new byte[byteCount + 1];
            Encoding.UTF8.GetBytes(s, 0, s.Length, bytes, 0);
            bytes[byteCount] = 0; // Null-terminate the byte array
            return bytes;
        }

        /// <summary>
        /// Gets the null terminated string length using the specified null terminated string
        /// </summary>
        /// <param name="nullTerminatedString">The null terminated string</param>
        /// <returns>The count</returns>
        private static int GetNullTerminatedStringLength(IntPtr nullTerminatedString)
        {
            int count = 0;
            while (Marshal.ReadByte(nullTerminatedString, count) != 0)
            {
                count++;
            }

            return count;
        }

        /// <summary>
        /// Creates the utf 8 using the specified null terminated string
        /// </summary>
        /// <param name="nullTerminatedString">The null terminated string</param>
        /// <returns>The string</returns>
        private static string FromUtf8(IntPtr nullTerminatedString)
        {
            return Marshal.PtrToStringAnsi(nullTerminatedString);
        }

        /// <summary>
        /// Files the open using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static DialogResult FileOpen(string filterList = null, string defaultPath = null)
        {
            IntPtr filterListNts = IntPtr.Zero;
            IntPtr defaultPathNts = IntPtr.Zero;
            try
            {
                filterListNts = filterList != null ? Marshal.StringToHGlobalAnsi(filterList) : IntPtr.Zero;
                defaultPathNts = defaultPath != null ? Marshal.StringToHGlobalAnsi(defaultPath) : IntPtr.Zero;

                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                NfdresultT result = Need32Bit
                    ? NativeFunctions32.NFD_OpenDialog(filterListNts, defaultPathNts, out outPathIntPtr)
                    : NativeFunctions.NFD_OpenDialog(filterListNts, defaultPathNts, out outPathIntPtr);
                if (result == NfdresultT.NfdError)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == NfdresultT.NfdOkay)
                {
                    path = Marshal.PtrToStringAnsi(outPathIntPtr);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
            finally
            {
                if (filterListNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(filterListNts);
                }

                if (defaultPathNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(defaultPathNts);
                }
            }
        }

        /// <summary>
        /// Files the save using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static DialogResult FileSave(string filterList = null, string defaultPath = null)
        {
            IntPtr filterListNts = IntPtr.Zero;
            IntPtr defaultPathNts = IntPtr.Zero;
            try
            {
                filterListNts = filterList != null ? Marshal.StringToHGlobalAnsi(filterList) : IntPtr.Zero;
                defaultPathNts = defaultPath != null ? Marshal.StringToHGlobalAnsi(defaultPath) : IntPtr.Zero;

                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                NfdresultT result = Need32Bit
                    ? NativeFunctions32.NFD_SaveDialog(filterListNts, defaultPathNts, out outPathIntPtr)
                    : NativeFunctions.NFD_SaveDialog(filterListNts, defaultPathNts, out outPathIntPtr);
                if (result == NfdresultT.NfdError)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == NfdresultT.NfdOkay)
                {
                    path = Marshal.PtrToStringAnsi(outPathIntPtr);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
            finally
            {
                if (filterListNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(filterListNts);
                }

                if (defaultPathNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(defaultPathNts);
                }
            }
        }

        /// <summary>
        /// Folders the picker using the specified default path
        /// </summary>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static DialogResult FolderPicker(string defaultPath = null)
        {
            IntPtr defaultPathNts = IntPtr.Zero;
            try
            {
                defaultPathNts = defaultPath != null ? Marshal.StringToHGlobalAnsi(defaultPath) : IntPtr.Zero;

                string path = null;
                string errorMessage = null;
                IntPtr outPathIntPtr;
                NfdresultT result = Need32Bit
                    ? NativeFunctions32.NFD_PickFolder(defaultPathNts, out outPathIntPtr)
                    : NativeFunctions.NFD_PickFolder(defaultPathNts, out outPathIntPtr);
                if (result == NfdresultT.NfdError)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == NfdresultT.NfdOkay)
                {
                    path = Marshal.PtrToStringAnsi(outPathIntPtr);
                    NativeFunctions.NFD_Free(outPathIntPtr);
                }

                return new DialogResult(result, path, null, errorMessage);
            }
            finally
            {
                if (defaultPathNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(defaultPathNts);
                }
            }
        }

        /// <summary>
        /// Files the open multiple using the specified filter list
        /// </summary>
        /// <param name="filterList">The filter list</param>
        /// <param name="defaultPath">The default path</param>
        /// <returns>The dialog result</returns>
        public static DialogResult FileOpenMultiple(string filterList = null, string defaultPath = null)
        {
            IntPtr filterListNts = IntPtr.Zero;
            IntPtr defaultPathNts = IntPtr.Zero;
            try
            {
                filterListNts = filterList != null ? Marshal.StringToHGlobalAnsi(filterList) : IntPtr.Zero;
                defaultPathNts = defaultPath != null ? Marshal.StringToHGlobalAnsi(defaultPath) : IntPtr.Zero;

                List<string> paths = null;
                string errorMessage = null;
                NfdpathsetT pathSet;
                NfdresultT result = Need32Bit
                    ? NativeFunctions32.NFD_OpenDialogMultiple(filterListNts, defaultPathNts, out pathSet)
                    : NativeFunctions.NFD_OpenDialogMultiple(filterListNts, defaultPathNts, out pathSet);
                if (result == NfdresultT.NfdError)
                {
                    errorMessage = FromUtf8(NativeFunctions.NFD_GetError());
                }
                else if (result == NfdresultT.NfdOkay)
                {
                    int pathCount = (int) NativeFunctions.NFD_PathSet_GetCount(pathSet).ToUInt32();
                    paths = new List<string>(pathCount);
                    for (int i = 0; i < pathCount; i++)
                    {
                        paths.Add(FromUtf8(NativeFunctions.NFD_PathSet_GetPath(pathSet, new UIntPtr((uint) i))));
                    }

                    NativeFunctions.NFD_PathSet_Free(pathSet);
                }

                return new DialogResult(result, null, paths, errorMessage);
            }
            finally
            {
                if (filterListNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(filterListNts);
                }

                if (defaultPathNts != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(defaultPathNts);
                }
            }
        }
    }
}