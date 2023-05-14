#region License
/* SDL2# - C# Wrapper for SDL2
 *
 * Copyright (c) 2013-2021 Ethan Lee.
 *
 * This software is provided 'as-is', without any express or implied warranty.
 * In no event will the authors be held liable for any damages arising from
 * the use of this software.
 *
 * Permission is granted to anyone to use this software for any purpose,
 * including commercial applications, and to alter it and redistribute it
 * freely, subject to the following restrictions:
 *
 * 1. The origin of this software must not be misrepresented; you must not
 * claim that you wrote the original software. If you use this software in a
 * product, an acknowledgment in the product documentation would be
 * appreciated but is not required.
 *
 * 2. Altered source versions must be plainly marked as such, and must not be
 * misrepresented as being the original software.
 *
 * 3. This notice may not be removed or altered from any source distribution.
 *
 * Ethan "flibitijibibo" Lee <flibitijibibo@flibitijibibo.com>
 *
 */
#endregion

#region Using Statements

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;

#endregion

namespace Alis.Core.Graphic.SDL
{
	/// <summary>
	/// The sdl class
	/// </summary>
	public static class SDL
	{
        static SDL()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dylib", NativeGraphic.osx_arm64_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dylib", NativeGraphic.osx_x64_sdl2);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_arm64_sdl2);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_x86_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.dll", NativeGraphic.win_x64_sdl2);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.debian_arm64_cimgui);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.debian_arm64_cimgui);
                        break;
                }
            }
        }
        
		#region SDL2# Variables

		/// <summary>
		/// The native lib name
		/// </summary>
		private const string nativeLibName = "sdl2";

		#endregion

		#region UTF8 Marshaling

		/* Used for stack allocated string marshaling. */
		/// <summary>
		/// Utfs the 8 size using the specified str
		/// </summary>
		/// <param name="str">The str</param>
		/// <returns>The int</returns>
		internal static int Utf8Size(string str)
		{
			if (str == null)
			{
				return 0;
			}
			return (str.Length * 4) + 1;
		}
		/// <summary>
		/// Utfs the 8 encode using the specified str
		/// </summary>
		/// <param name="str">The str</param>
		/// <param name="buffer">The buffer</param>
		/// <param name="bufferSize">The buffer size</param>
		/// <returns>The buffer</returns>
		internal static unsafe byte* Utf8Encode(string str, byte* buffer, int bufferSize)
		{
			if (str == null)
			{
				return (byte*) 0;
			}
			fixed (char* strPtr = str)
			{
				Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
			}
			return buffer;
		}

		/* Used for heap allocated string marshaling.
		 * Returned byte* must be free'd with FreeHGlobal.
		 */
		/// <summary>
		/// Utfs the 8 encode heap using the specified str
		/// </summary>
		/// <param name="str">The str</param>
		/// <returns>The buffer</returns>
		internal static unsafe byte* Utf8EncodeHeap(string str)
		{
			if (str == null)
			{
				return (byte*) 0;
			}

			int bufferSize = Utf8Size(str);
			byte* buffer = (byte*) Marshal.AllocHGlobal(bufferSize);
			fixed (char* strPtr = str)
			{
				Encoding.UTF8.GetBytes(strPtr, str.Length + 1, buffer, bufferSize);
			}
			return buffer;
		}

		/* This is public because SDL_DropEvent needs it! */
		/// <summary>
		/// Utfs the 8 to managed using the specified s
		/// </summary>
		/// <param name="s">The </param>
		/// <param name="freePtr">The free ptr</param>
		/// <returns>The result</returns>
		public static unsafe string UTF8_ToManaged(IntPtr s, bool freePtr = false)
		{
			if (s == IntPtr.Zero)
			{
				return null;
			}

			/* We get to do strlen ourselves! */
			byte* ptr = (byte*) s;
			while (*ptr != 0)
			{
				ptr++;
			}

			/* TODO: This #ifdef is only here because the equivalent
			 * .NET 2.0 constructor appears to be less efficient?
			 * Here's the pretty version, maybe steal this instead:
			 *
			string result = new string(
				(sbyte*) s, // Also, why sbyte???
				0,
				(int) (ptr - (byte*) s),
				System.Text.Encoding.UTF8
			);
			 * See the CoreCLR source for more info.
			 * -flibit
			 */
#if NETSTANDARD2_0
			/* Modern C# lets you just send the byte*, nice! */
			string result = System.Text.Encoding.UTF8.GetString(
				(byte*) s,
				(int) (ptr - (byte*) s)
			);
#else
			/* Old C# requires an extra memcpy, bleh! */
			int len = (int) (ptr - (byte*) s);
			if (len == 0)
			{
				return string.Empty;
			}
			char* chars = stackalloc char[len];
			int strLen = System.Text.Encoding.UTF8.GetChars((byte*) s, len, chars, len);
			string result = new string(chars, 0, strLen);
#endif

			/* Some SDL functions will malloc, we have to free! */
			if (freePtr)
			{
				SDL_free(s);
			}
			return result;
		}

		#endregion

		#region SDL_stdinc.h

		/// <summary>
		/// Sdls the fourcc using the specified a
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <param name="C">The </param>
		/// <param name="D">The </param>
		/// <returns>The uint</returns>
		public static uint SDL_FOURCC(byte A, byte B, byte C, byte D)
		{
			return (uint) (A | (B << 8) | (C << 16) | (D << 24));
		}

		/// <summary>
		/// The sdl bool enum
		/// </summary>
		public enum SDL_bool
		{
			/// <summary>
			/// The sdl false sdl bool
			/// </summary>
			SDL_FALSE = 0,
			/// <summary>
			/// The sdl true sdl bool
			/// </summary>
			SDL_TRUE = 1
		}

		/* malloc/free are used by the marshaler! -flibit */

		/// <summary>
		/// Sdls the malloc using the specified size
		/// </summary>
		/// <param name="size">The size</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern IntPtr SDL_malloc(IntPtr size);

		/// <summary>
		/// Sdls the free using the specified memblock
		/// </summary>
		/// <param name="memblock">The memblock</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		internal static extern void SDL_free(IntPtr memblock);

		/* Buffer.BlockCopy is not available in every runtime yet. Also,
		 * using memcpy directly can be a compatibility issue in other
		 * strange ways. So, we expose this to get around all that.
		 * -flibit
		 */
		/// <summary>
		/// Sdls the memcpy using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="src">The src</param>
		/// <param name="len">The len</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_memcpy(IntPtr dst, IntPtr src, IntPtr len);

		#endregion

		#region SDL_rwops.h

		/// <summary>
		/// The rw seek set
		/// </summary>
		public const int RW_SEEK_SET = 0;
		/// <summary>
		/// The rw seek cur
		/// </summary>
		public const int RW_SEEK_CUR = 1;
		/// <summary>
		/// The rw seek end
		/// </summary>
		public const int RW_SEEK_END = 2;

		/// <summary>
		/// The sdl rwops unknown
		/// </summary>
		public const UInt32 SDL_RWOPS_UNKNOWN	= 0; /* Unknown stream type */
		/// <summary>
		/// The sdl rwops winfile
		/// </summary>
		public const UInt32 SDL_RWOPS_WINFILE	= 1; /* Win32 file */
		/// <summary>
		/// The sdl rwops stdfile
		/// </summary>
		public const UInt32 SDL_RWOPS_STDFILE	= 2; /* Stdio file */
		/// <summary>
		/// The sdl rwops jnifile
		/// </summary>
		public const UInt32 SDL_RWOPS_JNIFILE	= 3; /* Android asset */
		/// <summary>
		/// The sdl rwops memory
		/// </summary>
		public const UInt32 SDL_RWOPS_MEMORY	= 4; /* Memory stream */
		/// <summary>
		/// The sdl rwops memory ro
		/// </summary>
		public const UInt32 SDL_RWOPS_MEMORY_RO = 5; /* Read-Only memory stream */

		/// <summary>
		/// The sdlr wops size callback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate long SDLRWopsSizeCallback(IntPtr context);

		/// <summary>
		/// The sdlr wops seek callback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate long SDLRWopsSeekCallback(
			IntPtr context,
			long offset,
			int whence
		);

		/// <summary>
		/// The sdlr wops read callback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr SDLRWopsReadCallback(
			IntPtr context,
			IntPtr ptr,
			IntPtr size,
			IntPtr maxnum
		);

		/// <summary>
		/// The sdlr wops write callback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr SDLRWopsWriteCallback(
			IntPtr context,
			IntPtr ptr,
			IntPtr size,
			IntPtr num
		);

		/// <summary>
		/// The sdlr wops close callback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SDLRWopsCloseCallback(
			IntPtr context
		);

		/// <summary>
		/// The sdl rwops
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_RWops
		{
			/// <summary>
			/// The size
			/// </summary>
			public IntPtr size;
			/// <summary>
			/// The seek
			/// </summary>
			public IntPtr seek;
			/// <summary>
			/// The read
			/// </summary>
			public IntPtr read;
			/// <summary>
			/// The write
			/// </summary>
			public IntPtr write;
			/// <summary>
			/// The close
			/// </summary>
			public IntPtr close;

			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;

			/* NOTE: This isn't the full structure since
			 * the native SDL_RWops contains a hidden union full of
			 * internal information and platform-specific stuff depending
			 * on what conditions the native library was built with
			 */
		}

		/* IntPtr refers to an SDL_RWops* */
		/// <summary>
		/// Internals the sdl rw from file using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_RWFromFile(
			byte* file,
			byte* mode
		);
		/// <summary>
		/// Sdls the rw from file using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="mode">The mode</param>
		/// <returns>The rw ops</returns>
		public static unsafe IntPtr SDL_RWFromFile(
			string file,
			string mode
		) {
			byte* utf8File = Utf8EncodeHeap(file);
			byte* utf8Mode = Utf8EncodeHeap(mode);
			IntPtr rwOps = INTERNAL_SDL_RWFromFile(
				utf8File,
				utf8Mode
			);
			Marshal.FreeHGlobal((IntPtr) utf8Mode);
			Marshal.FreeHGlobal((IntPtr) utf8File);
			return rwOps;
		}

		/* IntPtr refers to an SDL_RWops* */
		/// <summary>
		/// Sdls the alloc rw
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AllocRW();

		/* area refers to an SDL_RWops* */
		/// <summary>
		/// Sdls the free rw using the specified area
		/// </summary>
		/// <param name="area">The area</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeRW(IntPtr area);

		/* fp refers to a void* */
		/// <summary>
		/// Sdls the rw from fp using the specified fp
		/// </summary>
		/// <param name="fp">The fp</param>
		/// <param name="autoclose">The autoclose</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RWFromFP(IntPtr fp, SDL_bool autoclose);

		/* mem refers to a void*, IntPtr to an SDL_RWops* */
		/// <summary>
		/// Sdls the rw from mem using the specified mem
		/// </summary>
		/// <param name="mem">The mem</param>
		/// <param name="size">The size</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);

		/* mem refers to a const void*, IntPtr to an SDL_RWops* */
		/// <summary>
		/// Sdls the rw from const mem using the specified mem
		/// </summary>
		/// <param name="mem">The mem</param>
		/// <param name="size">The size</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);

		/* context refers to an SDL_RWops*.
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wsize using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWsize(IntPtr context);

		/* context refers to an SDL_RWops*.
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wseek using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <param name="offset">The offset</param>
		/// <param name="whence">The whence</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWseek(
			IntPtr context,
			long offset,
			int whence
		);

		/* context refers to an SDL_RWops*.
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wtell using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWtell(IntPtr context);

		/* context refers to an SDL_RWops*, ptr refers to a void*.
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wread using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <param name="ptr">The ptr</param>
		/// <param name="size">The size</param>
		/// <param name="maxnum">The maxnum</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWread(
			IntPtr context,
			IntPtr ptr,
			IntPtr size,
			IntPtr maxnum
		);

		/* context refers to an SDL_RWops*, ptr refers to a const void*.
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wwrite using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <param name="ptr">The ptr</param>
		/// <param name="size">The size</param>
		/// <param name="maxnum">The maxnum</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWwrite(
			IntPtr context,
			IntPtr ptr,
			IntPtr size,
			IntPtr maxnum
		);

		/* Read endian functions */

		/// <summary>
		/// Sdls the read u 8 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The byte</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_ReadU8(IntPtr src);

		/// <summary>
		/// Sdls the read le 16 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 16</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt16 SDL_ReadLE16(IntPtr src);

		/// <summary>
		/// Sdls the read be 16 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 16</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt16 SDL_ReadBE16(IntPtr src);

		/// <summary>
		/// Sdls the read le 32 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_ReadLE32(IntPtr src);

		/// <summary>
		/// Sdls the read be 32 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_ReadBE32(IntPtr src);

		/// <summary>
		/// Sdls the read le 64 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 64</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt64 SDL_ReadLE64(IntPtr src);

		/// <summary>
		/// Sdls the read be 64 using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <returns>The int 64</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt64 SDL_ReadBE64(IntPtr src);

		/* Write endian functions */

		/// <summary>
		/// Sdls the write u 8 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteU8(IntPtr dst, byte value);

		/// <summary>
		/// Sdls the write le 16 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteLE16(IntPtr dst, UInt16 value);

		/// <summary>
		/// Sdls the write be 16 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteBE16(IntPtr dst, UInt16 value);

		/// <summary>
		/// Sdls the write le 32 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteLE32(IntPtr dst, UInt32 value);

		/// <summary>
		/// Sdls the write be 32 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteBE32(IntPtr dst, UInt32 value);

		/// <summary>
		/// Sdls the write le 64 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteLE64(IntPtr dst, UInt64 value);

		/// <summary>
		/// Sdls the write be 64 using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="value">The value</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WriteBE64(IntPtr dst, UInt64 value);

		/* context refers to an SDL_RWops*
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the r wclose using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		/// <returns>The long</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_RWclose(IntPtr context);

		/* datasize refers to a size_t*
		 * IntPtr refers to a void*
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Internals the sdl load file using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="datasize">The datasize</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_LoadFile(byte* file, out IntPtr datasize);
		/// <summary>
		/// Sdls the load file using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="datasize">The datasize</param>
		/// <returns>The result</returns>
		public static unsafe IntPtr SDL_LoadFile(string file, out IntPtr datasize)
		{
			byte* utf8File = Utf8EncodeHeap(file);
			IntPtr result = INTERNAL_SDL_LoadFile(utf8File, out datasize);
			Marshal.FreeHGlobal((IntPtr) utf8File);
			return result;
		}

		#endregion

		#region SDL_main.h

		/// <summary>
		/// Sdls the set main ready
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetMainReady();

		/* This is used as a function pointer to a C main() function */
		/// <summary>
		/// The sdl main func
		/// </summary>
		public delegate int SDL_main_func(int argc, IntPtr argv);

		/* Use this function with UWP to call your C# Main() function! */
		/// <summary>
		/// Sdls the win rt run app using the specified main function
		/// </summary>
		/// <param name="mainFunction">The main function</param>
		/// <param name="reserved">The reserved</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WinRTRunApp(
			SDL_main_func mainFunction,
			IntPtr reserved
		);

		/* Use this function with iOS to call your C# Main() function!
		 * Only available in SDL 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the ui kit run app using the specified argc
		/// </summary>
		/// <param name="argc">The argc</param>
		/// <param name="argv">The argv</param>
		/// <param name="mainFunction">The main function</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UIKitRunApp(
			int argc,
			IntPtr argv,
			SDL_main_func mainFunction
		);

		#endregion

		#region SDL.h

		/// <summary>
		/// The sdl init timer
		/// </summary>
		public const uint SDL_INIT_TIMER =		0x00000001;
		/// <summary>
		/// The sdl init audio
		/// </summary>
		public const uint SDL_INIT_AUDIO =		0x00000010;
		/// <summary>
		/// The sdl init video
		/// </summary>
		public const uint SDL_INIT_VIDEO =		0x00000020;
		/// <summary>
		/// The sdl init joystick
		/// </summary>
		public const uint SDL_INIT_JOYSTICK =		0x00000200;
		/// <summary>
		/// The sdl init haptic
		/// </summary>
		public const uint SDL_INIT_HAPTIC =		0x00001000;
		/// <summary>
		/// The sdl init gamecontroller
		/// </summary>
		public const uint SDL_INIT_GAMECONTROLLER =	0x00002000;
		/// <summary>
		/// The sdl init events
		/// </summary>
		public const uint SDL_INIT_EVENTS =		0x00004000;
		/// <summary>
		/// The sdl init sensor
		/// </summary>
		public const uint SDL_INIT_SENSOR =		0x00008000;
		/// <summary>
		/// The sdl init noparachute
		/// </summary>
		public const uint SDL_INIT_NOPARACHUTE =	0x00100000;
		/// <summary>
		/// The sdl init sensor
		/// </summary>
		public const uint SDL_INIT_EVERYTHING = (
			SDL_INIT_TIMER | SDL_INIT_AUDIO | SDL_INIT_VIDEO |
			SDL_INIT_EVENTS | SDL_INIT_JOYSTICK | SDL_INIT_HAPTIC |
			SDL_INIT_GAMECONTROLLER | SDL_INIT_SENSOR
		);

		/// <summary>
		/// Sdls the init using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_Init(uint flags);

		/// <summary>
		/// Sdls the init sub system using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_InitSubSystem(uint flags);

		/// <summary>
		/// Sdls the quit
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Quit();

		/// <summary>
		/// Sdls the quit sub system using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_QuitSubSystem(uint flags);

		/// <summary>
		/// Sdls the was init using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_WasInit(uint flags);

		#endregion

		#region SDL_platform.h

		/// <summary>
		/// Internals the sdl get platform
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetPlatform();
		/// <summary>
		/// Sdls the get platform
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetPlatform()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetPlatform());
		}

		#endregion

		#region SDL_hints.h

		/// <summary>
		/// The sdl hint framebuffer acceleration
		/// </summary>
		public const string SDL_HINT_FRAMEBUFFER_ACCELERATION =
			"SDL_FRAMEBUFFER_ACCELERATION";
		/// <summary>
		/// The sdl hint render driver
		/// </summary>
		public const string SDL_HINT_RENDER_DRIVER =
			"SDL_RENDER_DRIVER";
		/// <summary>
		/// The sdl hint render opengl shaders
		/// </summary>
		public const string SDL_HINT_RENDER_OPENGL_SHADERS =
			"SDL_RENDER_OPENGL_SHADERS";
		/// <summary>
		/// The sdl hint render direct3d threadsafe
		/// </summary>
		public const string SDL_HINT_RENDER_DIRECT3D_THREADSAFE =
			"SDL_RENDER_DIRECT3D_THREADSAFE";
		/// <summary>
		/// The sdl hint render vsync
		/// </summary>
		public const string SDL_HINT_RENDER_VSYNC =
			"SDL_RENDER_VSYNC";
		/// <summary>
		/// The sdl hint video x11 xvidmode
		/// </summary>
		public const string SDL_HINT_VIDEO_X11_XVIDMODE =
			"SDL_VIDEO_X11_XVIDMODE";
		/// <summary>
		/// The sdl hint video x11 xinerama
		/// </summary>
		public const string SDL_HINT_VIDEO_X11_XINERAMA =
			"SDL_VIDEO_X11_XINERAMA";
		/// <summary>
		/// The sdl hint video x11 xrandr
		/// </summary>
		public const string SDL_HINT_VIDEO_X11_XRANDR =
			"SDL_VIDEO_X11_XRANDR";
		/// <summary>
		/// The sdl hint grab keyboard
		/// </summary>
		public const string SDL_HINT_GRAB_KEYBOARD =
			"SDL_GRAB_KEYBOARD";
		/// <summary>
		/// The sdl hint video minimize on focus loss
		/// </summary>
		public const string SDL_HINT_VIDEO_MINIMIZE_ON_FOCUS_LOSS =
			"SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";
		/// <summary>
		/// The sdl hint idle timer disabled
		/// </summary>
		public const string SDL_HINT_IDLE_TIMER_DISABLED =
			"SDL_IOS_IDLE_TIMER_DISABLED";
		/// <summary>
		/// The sdl hint orientations
		/// </summary>
		public const string SDL_HINT_ORIENTATIONS =
			"SDL_IOS_ORIENTATIONS";
		/// <summary>
		/// The sdl hint xinput enabled
		/// </summary>
		public const string SDL_HINT_XINPUT_ENABLED =
			"SDL_XINPUT_ENABLED";
		/// <summary>
		/// The sdl hint gamecontrollerconfig
		/// </summary>
		public const string SDL_HINT_GAMECONTROLLERCONFIG =
			"SDL_GAMECONTROLLERCONFIG";
		/// <summary>
		/// The sdl hint joystick allow background events
		/// </summary>
		public const string SDL_HINT_JOYSTICK_ALLOW_BACKGROUND_EVENTS =
			"SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";
		/// <summary>
		/// The sdl hint allow topmost
		/// </summary>
		public const string SDL_HINT_ALLOW_TOPMOST =
			"SDL_ALLOW_TOPMOST";
		/// <summary>
		/// The sdl hint timer resolution
		/// </summary>
		public const string SDL_HINT_TIMER_RESOLUTION =
			"SDL_TIMER_RESOLUTION";
		/// <summary>
		/// The sdl hint render scale quality
		/// </summary>
		public const string SDL_HINT_RENDER_SCALE_QUALITY =
			"SDL_RENDER_SCALE_QUALITY";

		/* Only available in SDL 2.0.1 or higher. */
		/// <summary>
		/// The sdl hint video highdpi disabled
		/// </summary>
		public const string SDL_HINT_VIDEO_HIGHDPI_DISABLED =
			"SDL_VIDEO_HIGHDPI_DISABLED";

		/* Only available in SDL 2.0.2 or higher. */
		/// <summary>
		/// The sdl hint ctrl click emulate right click
		/// </summary>
		public const string SDL_HINT_CTRL_CLICK_EMULATE_RIGHT_CLICK =
			"SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";
		/// <summary>
		/// The sdl hint video win d3dcompiler
		/// </summary>
		public const string SDL_HINT_VIDEO_WIN_D3DCOMPILER =
			"SDL_VIDEO_WIN_D3DCOMPILER";
		/// <summary>
		/// The sdl hint mouse relative mode warp
		/// </summary>
		public const string SDL_HINT_MOUSE_RELATIVE_MODE_WARP =
			"SDL_MOUSE_RELATIVE_MODE_WARP";
		/// <summary>
		/// The sdl hint video window share pixel format
		/// </summary>
		public const string SDL_HINT_VIDEO_WINDOW_SHARE_PIXEL_FORMAT =
			"SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";
		/// <summary>
		/// The sdl hint video allow screensaver
		/// </summary>
		public const string SDL_HINT_VIDEO_ALLOW_SCREENSAVER =
			"SDL_VIDEO_ALLOW_SCREENSAVER";
		/// <summary>
		/// The sdl hint accelerometer as joystick
		/// </summary>
		public const string SDL_HINT_ACCELEROMETER_AS_JOYSTICK =
			"SDL_ACCELEROMETER_AS_JOYSTICK";
		/// <summary>
		/// The sdl hint video mac fullscreen spaces
		/// </summary>
		public const string SDL_HINT_VIDEO_MAC_FULLSCREEN_SPACES =
			"SDL_VIDEO_MAC_FULLSCREEN_SPACES";

		/* Only available in SDL 2.0.3 or higher. */
		/// <summary>
		/// The sdl hint winrt privacy policy url
		/// </summary>
		public const string SDL_HINT_WINRT_PRIVACY_POLICY_URL =
			"SDL_WINRT_PRIVACY_POLICY_URL";
		/// <summary>
		/// The sdl hint winrt privacy policy label
		/// </summary>
		public const string SDL_HINT_WINRT_PRIVACY_POLICY_LABEL =
			"SDL_WINRT_PRIVACY_POLICY_LABEL";
		/// <summary>
		/// The sdl hint winrt handle back button
		/// </summary>
		public const string SDL_HINT_WINRT_HANDLE_BACK_BUTTON =
			"SDL_WINRT_HANDLE_BACK_BUTTON";

		/* Only available in SDL 2.0.4 or higher. */
		/// <summary>
		/// The sdl hint no signal handlers
		/// </summary>
		public const string SDL_HINT_NO_SIGNAL_HANDLERS =
			"SDL_NO_SIGNAL_HANDLERS";
		/// <summary>
		/// The sdl hint ime internal editing
		/// </summary>
		public const string SDL_HINT_IME_INTERNAL_EDITING =
			"SDL_IME_INTERNAL_EDITING";
		/// <summary>
		/// The sdl hint android separate mouse and touch
		/// </summary>
		public const string SDL_HINT_ANDROID_SEPARATE_MOUSE_AND_TOUCH =
			"SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";
		/// <summary>
		/// The sdl hint emscripten keyboard element
		/// </summary>
		public const string SDL_HINT_EMSCRIPTEN_KEYBOARD_ELEMENT =
			"SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";
		/// <summary>
		/// The sdl hint thread stack size
		/// </summary>
		public const string SDL_HINT_THREAD_STACK_SIZE =
			"SDL_THREAD_STACK_SIZE";
		/// <summary>
		/// The sdl hint window frame usable while cursor hidden
		/// </summary>
		public const string SDL_HINT_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN =
			"SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";
		/// <summary>
		/// The sdl hint windows enable messageloop
		/// </summary>
		public const string SDL_HINT_WINDOWS_ENABLE_MESSAGELOOP =
			"SDL_WINDOWS_ENABLE_MESSAGELOOP";
		/// <summary>
		/// The sdl hint windows no close on alt f4
		/// </summary>
		public const string SDL_HINT_WINDOWS_NO_CLOSE_ON_ALT_F4 =
			"SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";
		/// <summary>
		/// The sdl hint xinput use old joystick mapping
		/// </summary>
		public const string SDL_HINT_XINPUT_USE_OLD_JOYSTICK_MAPPING =
			"SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";
		/// <summary>
		/// The sdl hint mac background app
		/// </summary>
		public const string SDL_HINT_MAC_BACKGROUND_APP =
			"SDL_MAC_BACKGROUND_APP";
		/// <summary>
		/// The sdl hint video x11 net wm ping
		/// </summary>
		public const string SDL_HINT_VIDEO_X11_NET_WM_PING =
			"SDL_VIDEO_X11_NET_WM_PING";
		/// <summary>
		/// The sdl hint android apk expansion main file version
		/// </summary>
		public const string SDL_HINT_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION =
			"SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";
		/// <summary>
		/// The sdl hint android apk expansion patch file version
		/// </summary>
		public const string SDL_HINT_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION =
			"SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

		/* Only available in 2.0.5 or higher. */
		/// <summary>
		/// The sdl hint mouse focus clickthrough
		/// </summary>
		public const string SDL_HINT_MOUSE_FOCUS_CLICKTHROUGH =
			"SDL_MOUSE_FOCUS_CLICKTHROUGH";
		/// <summary>
		/// The sdl hint bmp save legacy format
		/// </summary>
		public const string SDL_HINT_BMP_SAVE_LEGACY_FORMAT =
			"SDL_BMP_SAVE_LEGACY_FORMAT";
		/// <summary>
		/// The sdl hint windows disable thread naming
		/// </summary>
		public const string SDL_HINT_WINDOWS_DISABLE_THREAD_NAMING =
			"SDL_WINDOWS_DISABLE_THREAD_NAMING";
		/// <summary>
		/// The sdl hint apple tv remote allow rotation
		/// </summary>
		public const string SDL_HINT_APPLE_TV_REMOTE_ALLOW_ROTATION =
			"SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// The sdl hint audio resampling mode
		/// </summary>
		public const string SDL_HINT_AUDIO_RESAMPLING_MODE =
			"SDL_AUDIO_RESAMPLING_MODE";
		/// <summary>
		/// The sdl hint render logical size mode
		/// </summary>
		public const string SDL_HINT_RENDER_LOGICAL_SIZE_MODE =
			"SDL_RENDER_LOGICAL_SIZE_MODE";
		/// <summary>
		/// The sdl hint mouse normal speed scale
		/// </summary>
		public const string SDL_HINT_MOUSE_NORMAL_SPEED_SCALE =
			"SDL_MOUSE_NORMAL_SPEED_SCALE";
		/// <summary>
		/// The sdl hint mouse relative speed scale
		/// </summary>
		public const string SDL_HINT_MOUSE_RELATIVE_SPEED_SCALE =
			"SDL_MOUSE_RELATIVE_SPEED_SCALE";
		/// <summary>
		/// The sdl hint touch mouse events
		/// </summary>
		public const string SDL_HINT_TOUCH_MOUSE_EVENTS =
			"SDL_TOUCH_MOUSE_EVENTS";
		/// <summary>
		/// The sdl hint windows intresource icon
		/// </summary>
		public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON =
			"SDL_WINDOWS_INTRESOURCE_ICON";
		/// <summary>
		/// The sdl hint windows intresource icon small
		/// </summary>
		public const string SDL_HINT_WINDOWS_INTRESOURCE_ICON_SMALL =
			"SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

		/* Only available in 2.0.8 or higher. */
		/// <summary>
		/// The sdl hint ios hide home indicator
		/// </summary>
		public const string SDL_HINT_IOS_HIDE_HOME_INDICATOR =
			"SDL_IOS_HIDE_HOME_INDICATOR";
		/// <summary>
		/// The sdl hint tv remote as joystick
		/// </summary>
		public const string SDL_HINT_TV_REMOTE_AS_JOYSTICK =
			"SDL_TV_REMOTE_AS_JOYSTICK";
		/// <summary>
		/// The sdl video x11 net wm bypass compositor
		/// </summary>
		public const string SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR =
			"SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";

		/* Only available in 2.0.9 or higher. */
		/// <summary>
		/// The sdl hint mouse double click time
		/// </summary>
		public const string SDL_HINT_MOUSE_DOUBLE_CLICK_TIME =
			"SDL_MOUSE_DOUBLE_CLICK_TIME";
		/// <summary>
		/// The sdl hint mouse double click radius
		/// </summary>
		public const string SDL_HINT_MOUSE_DOUBLE_CLICK_RADIUS =
			"SDL_MOUSE_DOUBLE_CLICK_RADIUS";
		/// <summary>
		/// The sdl hint joystick hidapi
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI =
			"SDL_JOYSTICK_HIDAPI";
		/// <summary>
		/// The sdl hint joystick hidapi ps4
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_PS4 =
			"SDL_JOYSTICK_HIDAPI_PS4";
		/// <summary>
		/// The sdl hint joystick hidapi ps4 rumble
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_PS4_RUMBLE =
			"SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";
		/// <summary>
		/// The sdl hint joystick hidapi steam
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_STEAM =
			"SDL_JOYSTICK_HIDAPI_STEAM";
		/// <summary>
		/// The sdl hint joystick hidapi switch
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_SWITCH =
			"SDL_JOYSTICK_HIDAPI_SWITCH";
		/// <summary>
		/// The sdl hint joystick hidapi xbox
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_XBOX =
			"SDL_JOYSTICK_HIDAPI_XBOX";
		/// <summary>
		/// The sdl hint enable steam controllers
		/// </summary>
		public const string SDL_HINT_ENABLE_STEAM_CONTROLLERS =
			"SDL_ENABLE_STEAM_CONTROLLERS";
		/// <summary>
		/// The sdl hint android trap back button
		/// </summary>
		public const string SDL_HINT_ANDROID_TRAP_BACK_BUTTON =
			"SDL_ANDROID_TRAP_BACK_BUTTON";

		/* Only available in 2.0.10 or higher. */
		/// <summary>
		/// The sdl hint mouse touch events
		/// </summary>
		public const string SDL_HINT_MOUSE_TOUCH_EVENTS =
			"SDL_MOUSE_TOUCH_EVENTS";
		/// <summary>
		/// The sdl hint gamecontrollerconfig file
		/// </summary>
		public const string SDL_HINT_GAMECONTROLLERCONFIG_FILE =
			"SDL_GAMECONTROLLERCONFIG_FILE";
		/// <summary>
		/// The sdl hint android block on pause
		/// </summary>
		public const string SDL_HINT_ANDROID_BLOCK_ON_PAUSE =
			"SDL_ANDROID_BLOCK_ON_PAUSE";
		/// <summary>
		/// The sdl hint render batching
		/// </summary>
		public const string SDL_HINT_RENDER_BATCHING =
			"SDL_RENDER_BATCHING";
		/// <summary>
		/// The sdl hint event logging
		/// </summary>
		public const string SDL_HINT_EVENT_LOGGING =
			"SDL_EVENT_LOGGING";
		/// <summary>
		/// The sdl hint wave riff chunk size
		/// </summary>
		public const string SDL_HINT_WAVE_RIFF_CHUNK_SIZE =
			"SDL_WAVE_RIFF_CHUNK_SIZE";
		/// <summary>
		/// The sdl hint wave truncation
		/// </summary>
		public const string SDL_HINT_WAVE_TRUNCATION =
			"SDL_WAVE_TRUNCATION";
		/// <summary>
		/// The sdl hint wave fact chunk
		/// </summary>
		public const string SDL_HINT_WAVE_FACT_CHUNK =
			"SDL_WAVE_FACT_CHUNK";

		/* Only available in 2.0.11 or higher. */
		/// <summary>
		/// The sdl hint vido x11 window visualid
		/// </summary>
		public const string SDL_HINT_VIDO_X11_WINDOW_VISUALID =
			"SDL_VIDEO_X11_WINDOW_VISUALID";
		/// <summary>
		/// The sdl hint gamecontroller use button labels
		/// </summary>
		public const string SDL_HINT_GAMECONTROLLER_USE_BUTTON_LABELS =
			"SDL_GAMECONTROLLER_USE_BUTTON_LABELS";
		/// <summary>
		/// The sdl hint video external context
		/// </summary>
		public const string SDL_HINT_VIDEO_EXTERNAL_CONTEXT =
			"SDL_VIDEO_EXTERNAL_CONTEXT";
		/// <summary>
		/// The sdl hint joystick hidapi gamecube
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_GAMECUBE =
			"SDL_JOYSTICK_HIDAPI_GAMECUBE";
		/// <summary>
		/// The sdl hint display usable bounds
		/// </summary>
		public const string SDL_HINT_DISPLAY_USABLE_BOUNDS =
			"SDL_DISPLAY_USABLE_BOUNDS";
		/// <summary>
		/// The sdl hint video x11 force egl
		/// </summary>
		public const string SDL_HINT_VIDEO_X11_FORCE_EGL =
			"SDL_VIDEO_X11_FORCE_EGL";
		/// <summary>
		/// The sdl hint gamecontrollertype
		/// </summary>
		public const string SDL_HINT_GAMECONTROLLERTYPE =
			"SDL_GAMECONTROLLERTYPE";

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// The sdl hint joystick hidapi correlate xinput
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_CORRELATE_XINPUT =
			"SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT"; /* NOTE: This was removed in 2.0.16. */
		/// <summary>
		/// The sdl hint joystick rawinput
		/// </summary>
		public const string SDL_HINT_JOYSTICK_RAWINPUT =
			"SDL_JOYSTICK_RAWINPUT";
		/// <summary>
		/// The sdl hint audio device app name
		/// </summary>
		public const string SDL_HINT_AUDIO_DEVICE_APP_NAME =
			"SDL_AUDIO_DEVICE_APP_NAME";
		/// <summary>
		/// The sdl hint audio device stream name
		/// </summary>
		public const string SDL_HINT_AUDIO_DEVICE_STREAM_NAME =
			"SDL_AUDIO_DEVICE_STREAM_NAME";
		/// <summary>
		/// The sdl hint preferred locales
		/// </summary>
		public const string SDL_HINT_PREFERRED_LOCALES =
			"SDL_PREFERRED_LOCALES";
		/// <summary>
		/// The sdl hint thread priority policy
		/// </summary>
		public const string SDL_HINT_THREAD_PRIORITY_POLICY =
			"SDL_THREAD_PRIORITY_POLICY";
		/// <summary>
		/// The sdl hint emscripten asyncify
		/// </summary>
		public const string SDL_HINT_EMSCRIPTEN_ASYNCIFY =
			"SDL_EMSCRIPTEN_ASYNCIFY";
		/// <summary>
		/// The sdl hint linux joystick deadzones
		/// </summary>
		public const string SDL_HINT_LINUX_JOYSTICK_DEADZONES =
			"SDL_LINUX_JOYSTICK_DEADZONES";
		/// <summary>
		/// The sdl hint android block on pause pauseaudio
		/// </summary>
		public const string SDL_HINT_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO =
			"SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";
		/// <summary>
		/// The sdl hint joystick hidapi ps5
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_PS5 =
			"SDL_JOYSTICK_HIDAPI_PS5";
		/// <summary>
		/// The sdl hint thread force realtime time critical
		/// </summary>
		public const string SDL_HINT_THREAD_FORCE_REALTIME_TIME_CRITICAL =
			"SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";
		/// <summary>
		/// The sdl hint joystick thread
		/// </summary>
		public const string SDL_HINT_JOYSTICK_THREAD =
			"SDL_JOYSTICK_THREAD";
		/// <summary>
		/// The sdl hint auto update joysticks
		/// </summary>
		public const string SDL_HINT_AUTO_UPDATE_JOYSTICKS =
			"SDL_AUTO_UPDATE_JOYSTICKS";
		/// <summary>
		/// The sdl hint auto update sensors
		/// </summary>
		public const string SDL_HINT_AUTO_UPDATE_SENSORS =
			"SDL_AUTO_UPDATE_SENSORS";
		/// <summary>
		/// The sdl hint mouse relative scaling
		/// </summary>
		public const string SDL_HINT_MOUSE_RELATIVE_SCALING =
			"SDL_MOUSE_RELATIVE_SCALING";
		/// <summary>
		/// The sdl hint joystick hidapi ps5 rumble
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_PS5_RUMBLE =
			"SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// The sdl hint windows force mutex critical sections
		/// </summary>
		public const string SDL_HINT_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS =
			"SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";
		/// <summary>
		/// The sdl hint windows force semaphore kernel
		/// </summary>
		public const string SDL_HINT_WINDOWS_FORCE_SEMAPHORE_KERNEL =
			"SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";
		/// <summary>
		/// The sdl hint joystick hidapi ps5 player led
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_PS5_PLAYER_LED =
			"SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";
		/// <summary>
		/// The sdl hint windows use d3d9ex
		/// </summary>
		public const string SDL_HINT_WINDOWS_USE_D3D9EX =
			"SDL_WINDOWS_USE_D3D9EX";
		/// <summary>
		/// The sdl hint joystick hidapi joy cons
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_JOY_CONS =
			"SDL_JOYSTICK_HIDAPI_JOY_CONS";
		/// <summary>
		/// The sdl hint joystick hidapi stadia
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_STADIA =
			"SDL_JOYSTICK_HIDAPI_STADIA";
		/// <summary>
		/// The sdl hint joystick hidapi switch home led
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_SWITCH_HOME_LED =
			"SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";
		/// <summary>
		/// The sdl hint allow alt tab while grabbed
		/// </summary>
		public const string SDL_HINT_ALLOW_ALT_TAB_WHILE_GRABBED =
			"SDL_ALLOW_ALT_TAB_WHILE_GRABBED";
		/// <summary>
		/// The sdl hint kmsdrm require drm master
		/// </summary>
		public const string SDL_HINT_KMSDRM_REQUIRE_DRM_MASTER =
			"SDL_KMSDRM_REQUIRE_DRM_MASTER";
		/// <summary>
		/// The sdl hint audio device stream role
		/// </summary>
		public const string SDL_HINT_AUDIO_DEVICE_STREAM_ROLE =
			"SDL_AUDIO_DEVICE_STREAM_ROLE";
		/// <summary>
		/// The sdl hint x11 force override redirect
		/// </summary>
		public const string SDL_HINT_X11_FORCE_OVERRIDE_REDIRECT =
			"SDL_X11_FORCE_OVERRIDE_REDIRECT";
		/// <summary>
		/// The sdl hint joystick hidapi luna
		/// </summary>
		public const string SDL_HINT_JOYSTICK_HIDAPI_LUNA =
			"SDL_JOYSTICK_HIDAPI_LUNA";
		/// <summary>
		/// The sdl hint joystick rawinput correlate xinput
		/// </summary>
		public const string SDL_HINT_JOYSTICK_RAWINPUT_CORRELATE_XINPUT =
			"SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";
		/// <summary>
		/// The sdl hint audio include monitors
		/// </summary>
		public const string SDL_HINT_AUDIO_INCLUDE_MONITORS =
			"SDL_AUDIO_INCLUDE_MONITORS";
		/// <summary>
		/// The sdl hint video wayland allow libdecor
		/// </summary>
		public const string SDL_HINT_VIDEO_WAYLAND_ALLOW_LIBDECOR =
			"SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";

		/* Only available in 2.0.18 or higher. */
		/// <summary>
		/// The sdl hint video egl allow transparency
		/// </summary>
		public const string SDL_HINT_VIDEO_EGL_ALLOW_TRANSPARENCY =
			"SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";
		/// <summary>
		/// The sdl hint app name
		/// </summary>
		public const string SDL_HINT_APP_NAME =
			"SDL_APP_NAME";
		/// <summary>
		/// The sdl hint screensaver inhibit activity name
		/// </summary>
		public const string SDL_HINT_SCREENSAVER_INHIBIT_ACTIVITY_NAME =
			"SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";
		/// <summary>
		/// The sdl hint ime show ui
		/// </summary>
		public const string SDL_HINT_IME_SHOW_UI =
			"SDL_IME_SHOW_UI";
		/// <summary>
		/// The sdl hint window no activation when shown
		/// </summary>
		public const string SDL_HINT_WINDOW_NO_ACTIVATION_WHEN_SHOWN =
			"SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";
		/// <summary>
		/// The sdl hint poll sentinel
		/// </summary>
		public const string SDL_HINT_POLL_SENTINEL =
			"SDL_POLL_SENTINEL";
		/// <summary>
		/// The sdl hint joystick device
		/// </summary>
		public const string SDL_HINT_JOYSTICK_DEVICE =
			"SDL_JOYSTICK_DEVICE";
		/// <summary>
		/// The sdl hint linux joystick classic
		/// </summary>
		public const string SDL_HINT_LINUX_JOYSTICK_CLASSIC =
			"SDL_LINUX_JOYSTICK_CLASSIC";

		/// <summary>
		/// The sdl hintpriority enum
		/// </summary>
		public enum SDL_HintPriority
		{
			/// <summary>
			/// The sdl hint default sdl hintpriority
			/// </summary>
			SDL_HINT_DEFAULT,
			/// <summary>
			/// The sdl hint normal sdl hintpriority
			/// </summary>
			SDL_HINT_NORMAL,
			/// <summary>
			/// The sdl hint override sdl hintpriority
			/// </summary>
			SDL_HINT_OVERRIDE
		}

		/// <summary>
		/// Sdls the clear hints
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearHints();

		/// <summary>
		/// Internals the sdl get hint using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_GetHint(byte* name);
		/// <summary>
		/// Sdls the get hint using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The string</returns>
		public static unsafe string SDL_GetHint(string name)
		{
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return UTF8_ToManaged(
				INTERNAL_SDL_GetHint(
					Utf8Encode(name, utf8Name, utf8NameBufSize)
				)
			);
		}

		/// <summary>
		/// Internals the sdl set hint using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="value">The value</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_bool INTERNAL_SDL_SetHint(
			byte* name,
			byte* value
		);
		/// <summary>
		/// Sdls the set hint using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="value">The value</param>
		/// <returns>The sdl bool</returns>
		public static unsafe SDL_bool SDL_SetHint(string name, string value)
		{
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];

			int utf8ValueBufSize = Utf8Size(value);
			byte* utf8Value = stackalloc byte[utf8ValueBufSize];

			return INTERNAL_SDL_SetHint(
				Utf8Encode(name, utf8Name, utf8NameBufSize),
				Utf8Encode(value, utf8Value, utf8ValueBufSize)
			);
		}

		/// <summary>
		/// Internals the sdl set hint with priority using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="value">The value</param>
		/// <param name="priority">The priority</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_bool INTERNAL_SDL_SetHintWithPriority(
			byte* name,
			byte* value,
			SDL_HintPriority priority
		);
		/// <summary>
		/// Sdls the set hint with priority using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="value">The value</param>
		/// <param name="priority">The priority</param>
		/// <returns>The sdl bool</returns>
		public static unsafe SDL_bool SDL_SetHintWithPriority(
			string name,
			string value,
			SDL_HintPriority priority
		) {
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];

			int utf8ValueBufSize = Utf8Size(value);
			byte* utf8Value = stackalloc byte[utf8ValueBufSize];

			return INTERNAL_SDL_SetHintWithPriority(
				Utf8Encode(name, utf8Name, utf8NameBufSize),
				Utf8Encode(value, utf8Value, utf8ValueBufSize),
				priority
			);
		}

		/* Only available in 2.0.5 or higher. */
		/// <summary>
		/// Internals the sdl get hint boolean using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="default_value">The default value</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_bool INTERNAL_SDL_GetHintBoolean(
			byte* name,
			SDL_bool default_value
		);
		/// <summary>
		/// Sdls the get hint boolean using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <param name="default_value">The default value</param>
		/// <returns>The sdl bool</returns>
		public static unsafe SDL_bool SDL_GetHintBoolean(
			string name,
			SDL_bool default_value
		) {
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return INTERNAL_SDL_GetHintBoolean(
				Utf8Encode(name, utf8Name, utf8NameBufSize),
				default_value
			);
		}

		#endregion

		#region SDL_error.h

		/// <summary>
		/// Sdls the clear error
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearError();

		/// <summary>
		/// Internals the sdl get error
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetError();
		/// <summary>
		/// Sdls the get error
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetError()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetError());
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl set error using the specified fmt and arglist
		/// </summary>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_SetError(byte* fmtAndArglist);
		/// <summary>
		/// Sdls the set error using the specified fmt and arglist
		/// </summary>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_SetError(string fmtAndArglist)
		{
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_SetError(
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* IntPtr refers to a char*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the get error msg using the specified errstr
		/// </summary>
		/// <param name="errstr">The errstr</param>
		/// <param name="maxlength">The maxlength</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetErrorMsg(IntPtr errstr, int maxlength);

		#endregion

		#region SDL_log.h

		/// <summary>
		/// The sdl logcategory enum
		/// </summary>
		public enum SDL_LogCategory
		{
			/// <summary>
			/// The sdl log category application sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_APPLICATION,
			/// <summary>
			/// The sdl log category error sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_ERROR,
			/// <summary>
			/// The sdl log category assert sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_ASSERT,
			/// <summary>
			/// The sdl log category system sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_SYSTEM,
			/// <summary>
			/// The sdl log category audio sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_AUDIO,
			/// <summary>
			/// The sdl log category video sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_VIDEO,
			/// <summary>
			/// The sdl log category render sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RENDER,
			/// <summary>
			/// The sdl log category input sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_INPUT,
			/// <summary>
			/// The sdl log category test sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_TEST,

			/* Reserved for future SDL library use */
			/// <summary>
			/// The sdl log category reserved1 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED1,
			/// <summary>
			/// The sdl log category reserved2 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED2,
			/// <summary>
			/// The sdl log category reserved3 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED3,
			/// <summary>
			/// The sdl log category reserved4 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED4,
			/// <summary>
			/// The sdl log category reserved5 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED5,
			/// <summary>
			/// The sdl log category reserved6 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED6,
			/// <summary>
			/// The sdl log category reserved7 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED7,
			/// <summary>
			/// The sdl log category reserved8 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED8,
			/// <summary>
			/// The sdl log category reserved9 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED9,
			/// <summary>
			/// The sdl log category reserved10 sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_RESERVED10,

			/* Beyond this point is reserved for application use, e.g.
			enum {
				MYAPP_CATEGORY_AWESOME1 = SDL_LOG_CATEGORY_CUSTOM,
				MYAPP_CATEGORY_AWESOME2,
				MYAPP_CATEGORY_AWESOME3,
				...
			};
			*/
			/// <summary>
			/// The sdl log category custom sdl logcategory
			/// </summary>
			SDL_LOG_CATEGORY_CUSTOM
		}

		/// <summary>
		/// The sdl logpriority enum
		/// </summary>
		public enum SDL_LogPriority
		{
			/// <summary>
			/// The sdl log priority verbose sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_VERBOSE = 1,
			/// <summary>
			/// The sdl log priority debug sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_DEBUG,
			/// <summary>
			/// The sdl log priority info sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_INFO,
			/// <summary>
			/// The sdl log priority warn sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_WARN,
			/// <summary>
			/// The sdl log priority error sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_ERROR,
			/// <summary>
			/// The sdl log priority critical sdl logpriority
			/// </summary>
			SDL_LOG_PRIORITY_CRITICAL,
			/// <summary>
			/// The sdl num log priorities sdl logpriority
			/// </summary>
			SDL_NUM_LOG_PRIORITIES
		}

		/* userdata refers to a void*, message to a const char* */
		/// <summary>
		/// The sdl logoutputfunction
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SDL_LogOutputFunction(
			IntPtr userdata,
			int category,
			SDL_LogPriority priority,
			IntPtr message
		);

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log using the specified fmt and arglist
		/// </summary>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_Log(byte* fmtAndArglist);
		/// <summary>
		/// Sdls the log using the specified fmt and arglist
		/// </summary>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_Log(string fmtAndArglist)
		{
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_Log(
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log verbose using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogVerbose(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log verbose using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogVerbose(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogVerbose(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log debug using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogDebug(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log debug using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogDebug(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogDebug(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log info using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogInfo(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log info using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogInfo(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogInfo(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log warn using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogWarn(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log warn using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogWarn(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogWarn(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log error using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogError(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log error using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogError(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogError(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log critical using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogCritical(
			int category,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log critical using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogCritical(
			int category,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogCritical(
				category,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log message using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="priority">The priority</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogMessage(
			int category,
			SDL_LogPriority priority,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log message using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="priority">The priority</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogMessage(
			int category,
			SDL_LogPriority priority,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogMessage(
				category,
				priority,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/* Use string.Format for arglists */
		/// <summary>
		/// Internals the sdl log message v using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="priority">The priority</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_LogMessageV(
			int category,
			SDL_LogPriority priority,
			byte* fmtAndArglist
		);
		/// <summary>
		/// Sdls the log message v using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="priority">The priority</param>
		/// <param name="fmtAndArglist">The fmt and arglist</param>
		public static unsafe void SDL_LogMessageV(
			int category,
			SDL_LogPriority priority,
			string fmtAndArglist
		) {
			int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
			byte* utf8FmtAndArglist = stackalloc byte[utf8FmtAndArglistBufSize];
			INTERNAL_SDL_LogMessageV(
				category,
				priority,
				Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
			);
		}

		/// <summary>
		/// Sdls the log get priority using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <returns>The sdl log priority</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_LogPriority SDL_LogGetPriority(
			int category
		);

		/// <summary>
		/// Sdls the log set priority using the specified category
		/// </summary>
		/// <param name="category">The category</param>
		/// <param name="priority">The priority</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetPriority(
			int category,
			SDL_LogPriority priority
		);

		/// <summary>
		/// Sdls the log set all priority using the specified priority
		/// </summary>
		/// <param name="priority">The priority</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetAllPriority(
			SDL_LogPriority priority
		);

		/// <summary>
		/// Sdls the log reset priorities
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogResetPriorities();

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the log get output function using the specified callback
		/// </summary>
		/// <param name="callback">The callback</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		private static extern void SDL_LogGetOutputFunction(
			out IntPtr callback,
			out IntPtr userdata
		);
		/// <summary>
		/// Sdls the log get output function using the specified callback
		/// </summary>
		/// <param name="callback">The callback</param>
		/// <param name="userdata">The userdata</param>
		public static void SDL_LogGetOutputFunction(
			out SDL_LogOutputFunction callback,
			out IntPtr userdata
		) {
			IntPtr result = IntPtr.Zero;
			SDL_LogGetOutputFunction(
				out result,
				out userdata
			);
			if (result != IntPtr.Zero)
			{
				callback = (SDL_LogOutputFunction) Marshal.GetDelegateForFunctionPointer(
					result,
					typeof(SDL_LogOutputFunction)
				);
			}
			else
			{
				callback = null;
			}
		}

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the log set output function using the specified callback
		/// </summary>
		/// <param name="callback">The callback</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LogSetOutputFunction(
			SDL_LogOutputFunction callback,
			IntPtr userdata
		);

		#endregion

		#region SDL_messagebox.h

		/// <summary>
		/// The sdl messageboxflags enum
		/// </summary>
		[Flags]
		public enum SDL_MessageBoxFlags : uint
		{
			/// <summary>
			/// The sdl messagebox error sdl messageboxflags
			/// </summary>
			SDL_MESSAGEBOX_ERROR =		0x00000010,
			/// <summary>
			/// The sdl messagebox warning sdl messageboxflags
			/// </summary>
			SDL_MESSAGEBOX_WARNING =	0x00000020,
			/// <summary>
			/// The sdl messagebox information sdl messageboxflags
			/// </summary>
			SDL_MESSAGEBOX_INFORMATION =	0x00000040
		}

		/// <summary>
		/// The sdl messageboxbuttonflags enum
		/// </summary>
		[Flags]
		public enum SDL_MessageBoxButtonFlags : uint
		{
			/// <summary>
			/// The sdl messagebox button returnkey default sdl messageboxbuttonflags
			/// </summary>
			SDL_MESSAGEBOX_BUTTON_RETURNKEY_DEFAULT = 0x00000001,
			/// <summary>
			/// The sdl messagebox button escapekey default sdl messageboxbuttonflags
			/// </summary>
			SDL_MESSAGEBOX_BUTTON_ESCAPEKEY_DEFAULT = 0x00000002
		}

		/// <summary>
		/// The internal sdl messageboxbuttondata
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_SDL_MessageBoxButtonData
		{
			/// <summary>
			/// The flags
			/// </summary>
			public SDL_MessageBoxButtonFlags flags;
			/// <summary>
			/// The buttonid
			/// </summary>
			public int buttonid;
			/// <summary>
			/// The text
			/// </summary>
			public IntPtr text; /* The UTF-8 button text */
		}

		/// <summary>
		/// The sdl messageboxbuttondata
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MessageBoxButtonData
		{
			/// <summary>
			/// The flags
			/// </summary>
			public SDL_MessageBoxButtonFlags flags;
			/// <summary>
			/// The buttonid
			/// </summary>
			public int buttonid;
			/// <summary>
			/// The text
			/// </summary>
			public string text; /* The UTF-8 button text */
		}

		/// <summary>
		/// The sdl messageboxcolor
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MessageBoxColor
		{
			/// <summary>
			/// The 
			/// </summary>
			public byte r, g, b;
		}

		/// <summary>
		/// The sdl messageboxcolortype enum
		/// </summary>
		public enum SDL_MessageBoxColorType
		{
			/// <summary>
			/// The sdl messagebox color background sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_BACKGROUND,
			/// <summary>
			/// The sdl messagebox color text sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_TEXT,
			/// <summary>
			/// The sdl messagebox color button border sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_BUTTON_BORDER,
			/// <summary>
			/// The sdl messagebox color button background sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_BUTTON_BACKGROUND,
			/// <summary>
			/// The sdl messagebox color button selected sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_BUTTON_SELECTED,
			/// <summary>
			/// The sdl messagebox color max sdl messageboxcolortype
			/// </summary>
			SDL_MESSAGEBOX_COLOR_MAX
		}

		/// <summary>
		/// The sdl messageboxcolorscheme
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MessageBoxColorScheme
		{
			/// <summary>
			/// The colors
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.Struct, SizeConst = (int)SDL_MessageBoxColorType.SDL_MESSAGEBOX_COLOR_MAX)]
				public SDL_MessageBoxColor[] colors;
		}

		/// <summary>
		/// The internal sdl messageboxdata
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_SDL_MessageBoxData
		{
			/// <summary>
			/// The flags
			/// </summary>
			public SDL_MessageBoxFlags flags;
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window;				/* Parent window, can be NULL */
			/// <summary>
			/// The title
			/// </summary>
			public IntPtr title;				/* UTF-8 title */
			/// <summary>
			/// The message
			/// </summary>
			public IntPtr message;				/* UTF-8 message text */
			/// <summary>
			/// The numbuttons
			/// </summary>
			public int numbuttons;
			/// <summary>
			/// The buttons
			/// </summary>
			public IntPtr buttons;
			/// <summary>
			/// The color scheme
			/// </summary>
			public IntPtr colorScheme;			/* Can be NULL to use system settings */
		}

		/// <summary>
		/// The sdl messageboxdata
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MessageBoxData
		{
			/// <summary>
			/// The flags
			/// </summary>
			public SDL_MessageBoxFlags flags;
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window;				/* Parent window, can be NULL */
			/// <summary>
			/// The title
			/// </summary>
			public string title;				/* UTF-8 title */
			/// <summary>
			/// The message
			/// </summary>
			public string message;				/* UTF-8 message text */
			/// <summary>
			/// The numbuttons
			/// </summary>
			public int numbuttons;
			/// <summary>
			/// The buttons
			/// </summary>
			public SDL_MessageBoxButtonData[] buttons;
			/// <summary>
			/// The color scheme
			/// </summary>
			public SDL_MessageBoxColorScheme? colorScheme;	/* Can be NULL to use system settings */
		}

		/// <summary>
		/// Internals the sdl show message box using the specified messageboxdata
		/// </summary>
		/// <param name="messageboxdata">The messageboxdata</param>
		/// <param name="buttonid">The buttonid</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_SDL_ShowMessageBox([In()] ref INTERNAL_SDL_MessageBoxData messageboxdata, out int buttonid);

		/* Ripped from Jameson's LpUtf8StrMarshaler */
		/// <summary>
		/// Internals the alloc utf 8 using the specified str
		/// </summary>
		/// <param name="str">The str</param>
		/// <returns>The mem</returns>
		private static IntPtr INTERNAL_AllocUTF8(string str)
		{
			if (string.IsNullOrEmpty(str))
			{
				return IntPtr.Zero;
			}
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(str + '\0');
			IntPtr mem = SDL.SDL_malloc((IntPtr) bytes.Length);
			Marshal.Copy(bytes, 0, mem, bytes.Length);
			return mem;
		}

		/// <summary>
		/// Sdls the show message box using the specified messageboxdata
		/// </summary>
		/// <param name="messageboxdata">The messageboxdata</param>
		/// <param name="buttonid">The buttonid</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_ShowMessageBox([In()] ref SDL_MessageBoxData messageboxdata, out int buttonid)
		{
			var data = new INTERNAL_SDL_MessageBoxData()
			{
				flags = messageboxdata.flags,
				window = messageboxdata.window,
				title = INTERNAL_AllocUTF8(messageboxdata.title),
				message = INTERNAL_AllocUTF8(messageboxdata.message),
				numbuttons = messageboxdata.numbuttons,
			};

			var buttons = new INTERNAL_SDL_MessageBoxButtonData[messageboxdata.numbuttons];
			for (int i = 0; i < messageboxdata.numbuttons; i++)
			{
				buttons[i] = new INTERNAL_SDL_MessageBoxButtonData()
				{
					flags = messageboxdata.buttons[i].flags,
					buttonid = messageboxdata.buttons[i].buttonid,
					text = INTERNAL_AllocUTF8(messageboxdata.buttons[i].text),
				};
			}

			if (messageboxdata.colorScheme != null)
			{
				data.colorScheme = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(SDL_MessageBoxColorScheme)));
				Marshal.StructureToPtr(messageboxdata.colorScheme.Value, data.colorScheme, false);
			}

			int result;
			fixed (INTERNAL_SDL_MessageBoxButtonData* buttonsPtr = &buttons[0])
			{
				data.buttons = (IntPtr)buttonsPtr;
				result = INTERNAL_SDL_ShowMessageBox(ref data, out buttonid);
			}

			Marshal.FreeHGlobal(data.colorScheme);
			for (int i = 0; i < messageboxdata.numbuttons; i++)
			{
				SDL_free(buttons[i].text);
			}
			SDL_free(data.message);
			SDL_free(data.title);

			return result;
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Internals the sdl show simple message box using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <param name="title">The title</param>
		/// <param name="message">The message</param>
		/// <param name="window">The window</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_ShowSimpleMessageBox(
			SDL_MessageBoxFlags flags,
			byte* title,
			byte* message,
			IntPtr window
		);
		/// <summary>
		/// Sdls the show simple message box using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <param name="title">The title</param>
		/// <param name="message">The message</param>
		/// <param name="window">The window</param>
		/// <returns>The int</returns>
		public static unsafe int SDL_ShowSimpleMessageBox(
			SDL_MessageBoxFlags flags,
			string title,
			string message,
			IntPtr window
		) {
			int utf8TitleBufSize = Utf8Size(title);
			byte* utf8Title = stackalloc byte[utf8TitleBufSize];

			int utf8MessageBufSize = Utf8Size(message);
			byte* utf8Message = stackalloc byte[utf8MessageBufSize];

			return INTERNAL_SDL_ShowSimpleMessageBox(
				flags,
				Utf8Encode(title, utf8Title, utf8TitleBufSize),
				Utf8Encode(message, utf8Message, utf8MessageBufSize),
				window
			);
		}

		#endregion

		#region SDL_version.h, SDL_revision.h

		/* Similar to the headers, this is the version we're expecting to be
		 * running with. You will likely want to check this somewhere in your
		 * program!
		 */
		/// <summary>
		/// The sdl major version
		/// </summary>
		public const int SDL_MAJOR_VERSION =	2;
		/// <summary>
		/// The sdl minor version
		/// </summary>
		public const int SDL_MINOR_VERSION =	0;
		/// <summary>
		/// The sdl patchlevel
		/// </summary>
		public const int SDL_PATCHLEVEL =	18;

		/// <summary>
		/// The sdl patchlevel
		/// </summary>
		public static readonly int SDL_COMPILEDVERSION = SDL_VERSIONNUM(
			SDL_MAJOR_VERSION,
			SDL_MINOR_VERSION,
			SDL_PATCHLEVEL
		);

		/// <summary>
		/// The sdl version
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_version
		{
			/// <summary>
			/// The major
			/// </summary>
			public byte major;
			/// <summary>
			/// The minor
			/// </summary>
			public byte minor;
			/// <summary>
			/// The patch
			/// </summary>
			public byte patch;
		}

		/// <summary>
		/// Sdls the version using the specified x
		/// </summary>
		/// <param name="x">The </param>
		public static void SDL_VERSION(out SDL_version x)
		{
			x.major = SDL_MAJOR_VERSION;
			x.minor = SDL_MINOR_VERSION;
			x.patch = SDL_PATCHLEVEL;
		}

		/// <summary>
		/// Sdls the versionnum using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <param name="Y">The </param>
		/// <param name="Z">The </param>
		/// <returns>The int</returns>
		public static int SDL_VERSIONNUM(int X, int Y, int Z)
		{
			return (X * 1000) + (Y * 100) + Z;
		}

		/// <summary>
		/// Describes whether sdl version atleast
		/// </summary>
		/// <param name="X">The </param>
		/// <param name="Y">The </param>
		/// <param name="Z">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_VERSION_ATLEAST(int X, int Y, int Z)
		{
			return (SDL_COMPILEDVERSION >= SDL_VERSIONNUM(X, Y, Z));
		}

		/// <summary>
		/// Sdls the get version using the specified ver
		/// </summary>
		/// <param name="ver">The ver</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetVersion(out SDL_version ver);

		/// <summary>
		/// Internals the sdl get revision
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetRevision();
		/// <summary>
		/// Sdls the get revision
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetRevision()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetRevision());
		}

		/// <summary>
		/// Sdls the get revision number
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRevisionNumber();

		#endregion

		#region SDL_video.h

		/// <summary>
		/// The sdl glattr enum
		/// </summary>
		public enum SDL_GLattr
		{
			/// <summary>
			/// The sdl gl red size sdl glattr
			/// </summary>
			SDL_GL_RED_SIZE,
			/// <summary>
			/// The sdl gl green size sdl glattr
			/// </summary>
			SDL_GL_GREEN_SIZE,
			/// <summary>
			/// The sdl gl blue size sdl glattr
			/// </summary>
			SDL_GL_BLUE_SIZE,
			/// <summary>
			/// The sdl gl alpha size sdl glattr
			/// </summary>
			SDL_GL_ALPHA_SIZE,
			/// <summary>
			/// The sdl gl buffer size sdl glattr
			/// </summary>
			SDL_GL_BUFFER_SIZE,
			/// <summary>
			/// The sdl gl doublebuffer sdl glattr
			/// </summary>
			SDL_GL_DOUBLEBUFFER,
			/// <summary>
			/// The sdl gl depth size sdl glattr
			/// </summary>
			SDL_GL_DEPTH_SIZE,
			/// <summary>
			/// The sdl gl stencil size sdl glattr
			/// </summary>
			SDL_GL_STENCIL_SIZE,
			/// <summary>
			/// The sdl gl accum red size sdl glattr
			/// </summary>
			SDL_GL_ACCUM_RED_SIZE,
			/// <summary>
			/// The sdl gl accum green size sdl glattr
			/// </summary>
			SDL_GL_ACCUM_GREEN_SIZE,
			/// <summary>
			/// The sdl gl accum blue size sdl glattr
			/// </summary>
			SDL_GL_ACCUM_BLUE_SIZE,
			/// <summary>
			/// The sdl gl accum alpha size sdl glattr
			/// </summary>
			SDL_GL_ACCUM_ALPHA_SIZE,
			/// <summary>
			/// The sdl gl stereo sdl glattr
			/// </summary>
			SDL_GL_STEREO,
			/// <summary>
			/// The sdl gl multisamplebuffers sdl glattr
			/// </summary>
			SDL_GL_MULTISAMPLEBUFFERS,
			/// <summary>
			/// The sdl gl multisamplesamples sdl glattr
			/// </summary>
			SDL_GL_MULTISAMPLESAMPLES,
			/// <summary>
			/// The sdl gl accelerated visual sdl glattr
			/// </summary>
			SDL_GL_ACCELERATED_VISUAL,
			/// <summary>
			/// The sdl gl retained backing sdl glattr
			/// </summary>
			SDL_GL_RETAINED_BACKING,
			/// <summary>
			/// The sdl gl context major version sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_MAJOR_VERSION,
			/// <summary>
			/// The sdl gl context minor version sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_MINOR_VERSION,
			/// <summary>
			/// The sdl gl context egl sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_EGL,
			/// <summary>
			/// The sdl gl context flags sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_FLAGS,
			/// <summary>
			/// The sdl gl context profile mask sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_PROFILE_MASK,
			/// <summary>
			/// The sdl gl share with current context sdl glattr
			/// </summary>
			SDL_GL_SHARE_WITH_CURRENT_CONTEXT,
			/// <summary>
			/// The sdl gl framebuffer srgb capable sdl glattr
			/// </summary>
			SDL_GL_FRAMEBUFFER_SRGB_CAPABLE,
			/// <summary>
			/// The sdl gl context release behavior sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_RELEASE_BEHAVIOR,
			/// <summary>
			/// The sdl gl context reset notification sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_RESET_NOTIFICATION,	/* Requires >= 2.0.6 */
			/// <summary>
			/// The sdl gl context no error sdl glattr
			/// </summary>
			SDL_GL_CONTEXT_NO_ERROR,		/* Requires >= 2.0.6 */
		}

		/// <summary>
		/// The sdl glprofile enum
		/// </summary>
		[Flags]
		public enum SDL_GLprofile
		{
			/// <summary>
			/// The sdl gl context profile core sdl glprofile
			/// </summary>
			SDL_GL_CONTEXT_PROFILE_CORE				= 0x0001,
			/// <summary>
			/// The sdl gl context profile compatibility sdl glprofile
			/// </summary>
			SDL_GL_CONTEXT_PROFILE_COMPATIBILITY	= 0x0002,
			/// <summary>
			/// The sdl gl context profile es sdl glprofile
			/// </summary>
			SDL_GL_CONTEXT_PROFILE_ES				= 0x0004
		}

		/// <summary>
		/// The sdl glcontext enum
		/// </summary>
		[Flags]
		public enum SDL_GLcontext
		{
			/// <summary>
			/// The sdl gl context debug flag sdl glcontext
			/// </summary>
			SDL_GL_CONTEXT_DEBUG_FLAG				= 0x0001,
			/// <summary>
			/// The sdl gl context forward compatible flag sdl glcontext
			/// </summary>
			SDL_GL_CONTEXT_FORWARD_COMPATIBLE_FLAG	= 0x0002,
			/// <summary>
			/// The sdl gl context robust access flag sdl glcontext
			/// </summary>
			SDL_GL_CONTEXT_ROBUST_ACCESS_FLAG		= 0x0004,
			/// <summary>
			/// The sdl gl context reset isolation flag sdl glcontext
			/// </summary>
			SDL_GL_CONTEXT_RESET_ISOLATION_FLAG		= 0x0008
		}

		/// <summary>
		/// The sdl windoweventid enum
		/// </summary>
		public enum SDL_WindowEventID : byte
		{
			/// <summary>
			/// The sdl windowevent none sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_NONE,
			/// <summary>
			/// The sdl windowevent shown sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_SHOWN,
			/// <summary>
			/// The sdl windowevent hidden sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_HIDDEN,
			/// <summary>
			/// The sdl windowevent exposed sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_EXPOSED,
			/// <summary>
			/// The sdl windowevent moved sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_MOVED,
			/// <summary>
			/// The sdl windowevent resized sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_RESIZED,
			/// <summary>
			/// The sdl windowevent size changed sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_SIZE_CHANGED,
			/// <summary>
			/// The sdl windowevent minimized sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_MINIMIZED,
			/// <summary>
			/// The sdl windowevent maximized sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_MAXIMIZED,
			/// <summary>
			/// The sdl windowevent restored sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_RESTORED,
			/// <summary>
			/// The sdl windowevent enter sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_ENTER,
			/// <summary>
			/// The sdl windowevent leave sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_LEAVE,
			/// <summary>
			/// The sdl windowevent focus gained sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_FOCUS_GAINED,
			/// <summary>
			/// The sdl windowevent focus lost sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_FOCUS_LOST,
			/// <summary>
			/// The sdl windowevent close sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_CLOSE,
			/* Only available in 2.0.5 or higher. */
			/// <summary>
			/// The sdl windowevent take focus sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_TAKE_FOCUS,
			/// <summary>
			/// The sdl windowevent hit test sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_HIT_TEST,
			/* Only available in 2.0.18 or higher. */
			/// <summary>
			/// The sdl windowevent iccprof changed sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_ICCPROF_CHANGED,
			/// <summary>
			/// The sdl windowevent display changed sdl windoweventid
			/// </summary>
			SDL_WINDOWEVENT_DISPLAY_CHANGED
		}

		/// <summary>
		/// The sdl displayeventid enum
		/// </summary>
		public enum SDL_DisplayEventID : byte
		{
			/// <summary>
			/// The sdl displayevent none sdl displayeventid
			/// </summary>
			SDL_DISPLAYEVENT_NONE,
			/// <summary>
			/// The sdl displayevent orientation sdl displayeventid
			/// </summary>
			SDL_DISPLAYEVENT_ORIENTATION,
			/// <summary>
			/// The sdl displayevent connected sdl displayeventid
			/// </summary>
			SDL_DISPLAYEVENT_CONNECTED,	/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl displayevent disconnected sdl displayeventid
			/// </summary>
			SDL_DISPLAYEVENT_DISCONNECTED	/* Requires >= 2.0.14 */
		}

		/// <summary>
		/// The sdl displayorientation enum
		/// </summary>
		public enum SDL_DisplayOrientation
		{
			/// <summary>
			/// The sdl orientation unknown sdl displayorientation
			/// </summary>
			SDL_ORIENTATION_UNKNOWN,
			/// <summary>
			/// The sdl orientation landscape sdl displayorientation
			/// </summary>
			SDL_ORIENTATION_LANDSCAPE,
			/// <summary>
			/// The sdl orientation landscape flipped sdl displayorientation
			/// </summary>
			SDL_ORIENTATION_LANDSCAPE_FLIPPED,
			/// <summary>
			/// The sdl orientation portrait sdl displayorientation
			/// </summary>
			SDL_ORIENTATION_PORTRAIT,
			/// <summary>
			/// The sdl orientation portrait flipped sdl displayorientation
			/// </summary>
			SDL_ORIENTATION_PORTRAIT_FLIPPED
		}

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// The sdl flashoperation enum
		/// </summary>
		public enum SDL_FlashOperation
		{
			/// <summary>
			/// The sdl flash cancel sdl flashoperation
			/// </summary>
			SDL_FLASH_CANCEL,
			/// <summary>
			/// The sdl flash briefly sdl flashoperation
			/// </summary>
			SDL_FLASH_BRIEFLY,
			/// <summary>
			/// The sdl flash until focused sdl flashoperation
			/// </summary>
			SDL_FLASH_UNTIL_FOCUSED
		}

		/// <summary>
		/// The sdl windowflags enum
		/// </summary>
		[Flags]
		public enum SDL_WindowFlags : uint
		{
			/// <summary>
			/// The sdl window fullscreen sdl windowflags
			/// </summary>
			SDL_WINDOW_FULLSCREEN =		0x00000001,
			/// <summary>
			/// The sdl window opengl sdl windowflags
			/// </summary>
			SDL_WINDOW_OPENGL =		0x00000002,
			/// <summary>
			/// The sdl window shown sdl windowflags
			/// </summary>
			SDL_WINDOW_SHOWN =		0x00000004,
			/// <summary>
			/// The sdl window hidden sdl windowflags
			/// </summary>
			SDL_WINDOW_HIDDEN =		0x00000008,
			/// <summary>
			/// The sdl window borderless sdl windowflags
			/// </summary>
			SDL_WINDOW_BORDERLESS =		0x00000010,
			/// <summary>
			/// The sdl window resizable sdl windowflags
			/// </summary>
			SDL_WINDOW_RESIZABLE =		0x00000020,
			/// <summary>
			/// The sdl window minimized sdl windowflags
			/// </summary>
			SDL_WINDOW_MINIMIZED =		0x00000040,
			/// <summary>
			/// The sdl window maximized sdl windowflags
			/// </summary>
			SDL_WINDOW_MAXIMIZED =		0x00000080,
			/// <summary>
			/// The sdl window mouse grabbed sdl windowflags
			/// </summary>
			SDL_WINDOW_MOUSE_GRABBED =	0x00000100,
			/// <summary>
			/// The sdl window input focus sdl windowflags
			/// </summary>
			SDL_WINDOW_INPUT_FOCUS =	0x00000200,
			/// <summary>
			/// The sdl window mouse focus sdl windowflags
			/// </summary>
			SDL_WINDOW_MOUSE_FOCUS =	0x00000400,
			/// <summary>
			/// The sdl window fullscreen desktop sdl windowflags
			/// </summary>
			SDL_WINDOW_FULLSCREEN_DESKTOP =
				(SDL_WINDOW_FULLSCREEN | 0x00001000),
			/// <summary>
			/// The sdl window foreign sdl windowflags
			/// </summary>
			SDL_WINDOW_FOREIGN =		0x00000800,
			/// <summary>
			/// The sdl window allow highdpi sdl windowflags
			/// </summary>
			SDL_WINDOW_ALLOW_HIGHDPI =	0x00002000,	/* Requires >= 2.0.1 */
			/// <summary>
			/// The sdl window mouse capture sdl windowflags
			/// </summary>
			SDL_WINDOW_MOUSE_CAPTURE =	0x00004000,	/* Requires >= 2.0.4 */
			/// <summary>
			/// The sdl window always on top sdl windowflags
			/// </summary>
			SDL_WINDOW_ALWAYS_ON_TOP =	0x00008000,	/* Requires >= 2.0.5 */
			/// <summary>
			/// The sdl window skip taskbar sdl windowflags
			/// </summary>
			SDL_WINDOW_SKIP_TASKBAR =	0x00010000,	/* Requires >= 2.0.5 */
			/// <summary>
			/// The sdl window utility sdl windowflags
			/// </summary>
			SDL_WINDOW_UTILITY =		0x00020000,	/* Requires >= 2.0.5 */
			/// <summary>
			/// The sdl window tooltip sdl windowflags
			/// </summary>
			SDL_WINDOW_TOOLTIP =		0x00040000,	/* Requires >= 2.0.5 */
			/// <summary>
			/// The sdl window popup menu sdl windowflags
			/// </summary>
			SDL_WINDOW_POPUP_MENU =		0x00080000,	/* Requires >= 2.0.5 */
			/// <summary>
			/// The sdl window keyboard grabbed sdl windowflags
			/// </summary>
			SDL_WINDOW_KEYBOARD_GRABBED =	0x00100000,	/* Requires >= 2.0.16 */
			/// <summary>
			/// The sdl window vulkan sdl windowflags
			/// </summary>
			SDL_WINDOW_VULKAN =		0x10000000,	/* Requires >= 2.0.6 */
			/// <summary>
			/// The sdl window metal sdl windowflags
			/// </summary>
			SDL_WINDOW_METAL =		0x2000000,	/* Requires >= 2.0.14 */

			/// <summary>
			/// The sdl window input grabbed sdl windowflags
			/// </summary>
			SDL_WINDOW_INPUT_GRABBED =
				SDL_WINDOW_MOUSE_GRABBED,
		}

		/* Only available in 2.0.4 or higher. */
		/// <summary>
		/// The sdl hittestresult enum
		/// </summary>
		public enum SDL_HitTestResult
		{
			/// <summary>
			/// The sdl hittest normal sdl hittestresult
			/// </summary>
			SDL_HITTEST_NORMAL,		/* Region is normal. No special properties. */
			/// <summary>
			/// The sdl hittest draggable sdl hittestresult
			/// </summary>
			SDL_HITTEST_DRAGGABLE,		/* Region can drag entire window. */
			/// <summary>
			/// The sdl hittest resize topleft sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_TOPLEFT,
			/// <summary>
			/// The sdl hittest resize top sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_TOP,
			/// <summary>
			/// The sdl hittest resize topright sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_TOPRIGHT,
			/// <summary>
			/// The sdl hittest resize right sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_RIGHT,
			/// <summary>
			/// The sdl hittest resize bottomright sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_BOTTOMRIGHT,
			/// <summary>
			/// The sdl hittest resize bottom sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_BOTTOM,
			/// <summary>
			/// The sdl hittest resize bottomleft sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_BOTTOMLEFT,
			/// <summary>
			/// The sdl hittest resize left sdl hittestresult
			/// </summary>
			SDL_HITTEST_RESIZE_LEFT
		}

		/// <summary>
		/// The sdl windowpos undefined mask
		/// </summary>
		public const int SDL_WINDOWPOS_UNDEFINED_MASK =	0x1FFF0000;
		/// <summary>
		/// The sdl windowpos centered mask
		/// </summary>
		public const int SDL_WINDOWPOS_CENTERED_MASK =	0x2FFF0000;
		/// <summary>
		/// The sdl windowpos undefined
		/// </summary>
		public const int SDL_WINDOWPOS_UNDEFINED =	0x1FFF0000;
		/// <summary>
		/// The sdl windowpos centered
		/// </summary>
		public const int SDL_WINDOWPOS_CENTERED =	0x2FFF0000;

		/// <summary>
		/// Sdls the windowpos undefined display using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The int</returns>
		public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int X)
		{
			return (SDL_WINDOWPOS_UNDEFINED_MASK | X);
		}

		/// <summary>
		/// Describes whether sdl windowpos isundefined
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_WINDOWPOS_ISUNDEFINED(int X)
		{
			return (X & 0xFFFF0000) == SDL_WINDOWPOS_UNDEFINED_MASK;
		}

		/// <summary>
		/// Sdls the windowpos centered display using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The int</returns>
		public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int X)
		{
			return (SDL_WINDOWPOS_CENTERED_MASK | X);
		}

		/// <summary>
		/// Describes whether sdl windowpos iscentered
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_WINDOWPOS_ISCENTERED(int X)
		{
			return (X & 0xFFFF0000) == SDL_WINDOWPOS_CENTERED_MASK;
		}

		/// <summary>
		/// The sdl displaymode
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_DisplayMode
		{
			/// <summary>
			/// The format
			/// </summary>
			public uint format;
			/// <summary>
			/// The 
			/// </summary>
			public int w;
			/// <summary>
			/// The 
			/// </summary>
			public int h;
			/// <summary>
			/// The refresh rate
			/// </summary>
			public int refresh_rate;
			/// <summary>
			/// The driverdata
			/// </summary>
			public IntPtr driverdata; // void*
		}

		/* win refers to an SDL_Window*, area to a const SDL_Point*, data to a void*.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// The sdl hittest
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate SDL_HitTestResult SDL_HitTest(IntPtr win, IntPtr area, IntPtr data);

		/* IntPtr refers to an SDL_Window* */
		/// <summary>
		/// Internals the sdl create window using the specified title
		/// </summary>
		/// <param name="title">The title</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <param name="flags">The flags</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_CreateWindow(
			byte* title,
			int x,
			int y,
			int w,
			int h,
			SDL_WindowFlags flags
		);
		/// <summary>
		/// Sdls the create window using the specified title
		/// </summary>
		/// <param name="title">The title</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <param name="flags">The flags</param>
		/// <returns>The int ptr</returns>
		public static unsafe IntPtr SDL_CreateWindow(
			string title,
			int x,
			int y,
			int w,
			int h,
			SDL_WindowFlags flags
		) {
			int utf8TitleBufSize = Utf8Size(title);
			byte* utf8Title = stackalloc byte[utf8TitleBufSize];
			return INTERNAL_SDL_CreateWindow(
				Utf8Encode(title, utf8Title, utf8TitleBufSize),
				x, y, w, h,
				flags
			);
		}

		/* window refers to an SDL_Window*, renderer to an SDL_Renderer* */
		/// <summary>
		/// Sdls the create window and renderer using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="window_flags">The window flags</param>
		/// <param name="window">The window</param>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_CreateWindowAndRenderer(
			int width,
			int height,
			SDL_WindowFlags window_flags,
			out IntPtr window,
			out IntPtr renderer
		);

		/* data refers to some native window type, IntPtr to an SDL_Window* */
		/// <summary>
		/// Sdls the create window from using the specified data
		/// </summary>
		/// <param name="data">The data</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the destroy window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyWindow(IntPtr window);

		/// <summary>
		/// Sdls the disable screen saver
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DisableScreenSaver();

		/// <summary>
		/// Sdls the enable screen saver
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_EnableScreenSaver();

		/* IntPtr refers to an SDL_DisplayMode. Just use closest. */
		/// <summary>
		/// Sdls the get closest display mode using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="mode">The mode</param>
		/// <param name="closest">The closest</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetClosestDisplayMode(
			int displayIndex,
			ref SDL_DisplayMode mode,
			out SDL_DisplayMode closest
		);

		/// <summary>
		/// Sdls the get current display mode using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetCurrentDisplayMode(
			int displayIndex,
			out SDL_DisplayMode mode
		);

		/// <summary>
		/// Internals the sdl get current video driver
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();
		/// <summary>
		/// Sdls the get current video driver
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetCurrentVideoDriver()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());
		}

		/// <summary>
		/// Sdls the get desktop display mode using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDesktopDisplayMode(
			int displayIndex,
			out SDL_DisplayMode mode
		);

		/// <summary>
		/// Internals the sdl get display name using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetDisplayName(int index);
		/// <summary>
		/// Sdls the get display name using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The string</returns>
		public static string SDL_GetDisplayName(int index)
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetDisplayName(index));
		}

		/// <summary>
		/// Sdls the get display bounds using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayBounds(
			int displayIndex,
			out SDL_Rect rect
		);

		/* Only available in 2.0.4 or higher. */
		/// <summary>
		/// Sdls the get display dpi using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="ddpi">The ddpi</param>
		/// <param name="hdpi">The hdpi</param>
		/// <param name="vdpi">The vdpi</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayDPI(
			int displayIndex,
			out float ddpi,
			out float hdpi,
			out float vdpi
		);

		/* Only available in 2.0.9 or higher. */
		/// <summary>
		/// Sdls the get display orientation using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <returns>The sdl display orientation</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_DisplayOrientation SDL_GetDisplayOrientation(
			int displayIndex
		);

		/// <summary>
		/// Sdls the get display mode using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="modeIndex">The mode index</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayMode(
			int displayIndex,
			int modeIndex,
			out SDL_DisplayMode mode
		);

		/* Only available in 2.0.5 or higher. */
		/// <summary>
		/// Sdls the get display usable bounds using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetDisplayUsableBounds(
			int displayIndex,
			out SDL_Rect rect
		);

		/// <summary>
		/// Sdls the get num display modes using the specified display index
		/// </summary>
		/// <param name="displayIndex">The display index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumDisplayModes(
			int displayIndex
		);

		/// <summary>
		/// Sdls the get num video displays
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumVideoDisplays();

		/// <summary>
		/// Sdls the get num video drivers
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumVideoDrivers();

		/// <summary>
		/// Internals the sdl get video driver using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetVideoDriver(
			int index
		);
		/// <summary>
		/// Sdls the get video driver using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The string</returns>
		public static string SDL_GetVideoDriver(int index)
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetVideoDriver(index));
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window brightness using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The float</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern float SDL_GetWindowBrightness(
			IntPtr window
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the set window opacity using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="opacity">The opacity</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowOpacity(
			IntPtr window,
			float opacity
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the get window opacity using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="out_opacity">The out opacity</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowOpacity(
			IntPtr window,
			out float out_opacity
		);

		/* modal_window and parent_window refer to an SDL_Window*s
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the set window modal for using the specified modal window
		/// </summary>
		/// <param name="modal_window">The modal window</param>
		/// <param name="parent_window">The parent window</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowModalFor(
			IntPtr modal_window,
			IntPtr parent_window
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the set window input focus using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowInputFocus(IntPtr window);

		/* window refers to an SDL_Window*, IntPtr to a void* */
		/// <summary>
		/// Internals the sdl get window data using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="name">The name</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_GetWindowData(
			IntPtr window,
			byte* name
		);
		/// <summary>
		/// Sdls the get window data using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="name">The name</param>
		/// <returns>The int ptr</returns>
		public static unsafe IntPtr SDL_GetWindowData(
			IntPtr window,
			string name
		) {
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return INTERNAL_SDL_GetWindowData(
				window,
				Utf8Encode(name, utf8Name, utf8NameBufSize)
			);
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window display index using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowDisplayIndex(
			IntPtr window
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window display mode using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowDisplayMode(
			IntPtr window,
			out SDL_DisplayMode mode
		);

		/* IntPtr refers to a void*
		 * window refers to an SDL_Window*
		 * mode refers to a size_t*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the get window icc profile using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowICCProfile(
			IntPtr window,
			out IntPtr mode
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window flags using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowFlags(IntPtr window);

		/* IntPtr refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window from id using the specified id
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowFromID(uint id);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window gamma ramp using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="red">The red</param>
		/// <param name="green">The green</param>
		/// <param name="blue">The blue</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowGammaRamp(
			IntPtr window,
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] red,
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] green,
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] blue
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GetWindowGrab(IntPtr window);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the get window keyboard grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GetWindowKeyboardGrab(IntPtr window);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the get window mouse grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GetWindowMouseGrab(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window id using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowID(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window pixel format using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_GetWindowPixelFormat(
			IntPtr window
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window maximum size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="max_w">The max</param>
		/// <param name="max_h">The max</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowMaximumSize(
			IntPtr window,
			out int max_w,
			out int max_h
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window minimum size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="min_w">The min</param>
		/// <param name="min_h">The min</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowMinimumSize(
			IntPtr window,
			out int min_w,
			out int min_h
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window position using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowPosition(
			IntPtr window,
			out int x,
			out int y
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetWindowSize(
			IntPtr window,
			out int w,
			out int h
		);

		/* IntPtr refers to an SDL_Surface*, window to an SDL_Window* */
		/// <summary>
		/// Sdls the get window surface using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Internals the sdl get window title using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetWindowTitle(
			IntPtr window
		);
		/// <summary>
		/// Sdls the get window title using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The string</returns>
		public static string SDL_GetWindowTitle(IntPtr window)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GetWindowTitle(window)
			);
		}

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the gl bind texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="texw">The texw</param>
		/// <param name="texh">The texh</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_BindTexture(
			IntPtr texture,
			out float texw,
			out float texh
		);

		/* IntPtr and window refer to an SDL_GLContext and SDL_Window* */
		/// <summary>
		/// Sdls the gl create context using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

		/* context refers to an SDL_GLContext */
		/// <summary>
		/// Sdls the gl delete context using the specified context
		/// </summary>
		/// <param name="context">The context</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_DeleteContext(IntPtr context);

		/// <summary>
		/// Internals the sdl gl load library using the specified path
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_GL_LoadLibrary(byte* path);
		/// <summary>
		/// Sdls the gl load library using the specified path
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_GL_LoadLibrary(string path)
		{
			byte* utf8Path = Utf8EncodeHeap(path);
			int result = INTERNAL_SDL_GL_LoadLibrary(
				utf8Path
			);
			Marshal.FreeHGlobal((IntPtr) utf8Path);
			return result;
		}

		/* IntPtr refers to a function pointer, proc to a const char* */
		/// <summary>
		/// Sdls the gl get proc address using the specified proc
		/// </summary>
		/// <param name="proc">The proc</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetProcAddress(IntPtr proc);

		/* IntPtr refers to a function pointer */
		/// <summary>
		/// Sdls the gl get proc address using the specified proc
		/// </summary>
		/// <param name="proc">The proc</param>
		/// <returns>The int ptr</returns>
		public static unsafe IntPtr SDL_GL_GetProcAddress(string proc)
		{
			int utf8ProcBufSize = Utf8Size(proc);
			byte* utf8Proc = stackalloc byte[utf8ProcBufSize];
			return SDL_GL_GetProcAddress(
				(IntPtr) Utf8Encode(proc, utf8Proc, utf8ProcBufSize)
			);
		}

		/// <summary>
		/// Sdls the gl unload library
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_UnloadLibrary();

		/// <summary>
		/// Internals the sdl gl extension supported using the specified extension
		/// </summary>
		/// <param name="extension">The extension</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_bool INTERNAL_SDL_GL_ExtensionSupported(
			byte* extension
		);
		/// <summary>
		/// Sdls the gl extension supported using the specified extension
		/// </summary>
		/// <param name="extension">The extension</param>
		/// <returns>The sdl bool</returns>
		public static unsafe SDL_bool SDL_GL_ExtensionSupported(string extension)
		{
			int utf8ExtensionBufSize = Utf8Size(extension);
			byte* utf8Extension = stackalloc byte[utf8ExtensionBufSize];
			return INTERNAL_SDL_GL_ExtensionSupported(
				Utf8Encode(extension, utf8Extension, utf8ExtensionBufSize)
			);
		}

		/* Only available in SDL 2.0.2 or higher. */
		/// <summary>
		/// Sdls the gl reset attributes
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_ResetAttributes();

		/// <summary>
		/// Sdls the gl get attribute using the specified attr
		/// </summary>
		/// <param name="attr">The attr</param>
		/// <param name="value">The value</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_GetAttribute(
			SDL_GLattr attr,
			out int value
		);

		/// <summary>
		/// Sdls the gl get swap interval
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_GetSwapInterval();

		/* window and context refer to an SDL_Window* and SDL_GLContext */
		/// <summary>
		/// Sdls the gl make current using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="context">The context</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_MakeCurrent(
			IntPtr window,
			IntPtr context
		);

		/* IntPtr refers to an SDL_Window* */
		/// <summary>
		/// Sdls the gl get current window
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetCurrentWindow();

		/* IntPtr refers to an SDL_Context */
		/// <summary>
		/// Sdls the gl get current context
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GL_GetCurrentContext();

		/* window refers to an SDL_Window*.
		 * Only available in SDL 2.0.1 or higher.
		 */
		/// <summary>
		/// Sdls the gl get drawable size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		/// <summary>
		/// Sdls the gl set attribute using the specified attr
		/// </summary>
		/// <param name="attr">The attr</param>
		/// <param name="value">The value</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_SetAttribute(
			SDL_GLattr attr,
			int value
		);

		/// <summary>
		/// Sdls the gl set attribute using the specified attr
		/// </summary>
		/// <param name="attr">The attr</param>
		/// <param name="profile">The profile</param>
		/// <returns>The int</returns>
		public static int SDL_GL_SetAttribute(
			SDL_GLattr attr,
			SDL_GLprofile profile
		) {
			return SDL_GL_SetAttribute(attr, (int)profile);
		}

		/// <summary>
		/// Sdls the gl set swap interval using the specified interval
		/// </summary>
		/// <param name="interval">The interval</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_SetSwapInterval(int interval);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the gl swap window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GL_SwapWindow(IntPtr window);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the gl unbind texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GL_UnbindTexture(IntPtr texture);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the hide window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HideWindow(IntPtr window);

		/// <summary>
		/// Sdls the is screen saver enabled
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsScreenSaverEnabled();

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the maximize window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MaximizeWindow(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the minimize window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MinimizeWindow(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the raise window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RaiseWindow(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the restore window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RestoreWindow(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window brightness using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="brightness">The brightness</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowBrightness(
			IntPtr window,
			float brightness
		);

		/* IntPtr and userdata are void*, window is an SDL_Window* */
		/// <summary>
		/// Internals the sdl set window data using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="name">The name</param>
		/// <param name="userdata">The userdata</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_SetWindowData(
			IntPtr window,
			byte* name,
			IntPtr userdata
		);
		/// <summary>
		/// Sdls the set window data using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="name">The name</param>
		/// <param name="userdata">The userdata</param>
		/// <returns>The int ptr</returns>
		public static unsafe IntPtr SDL_SetWindowData(
			IntPtr window,
			string name,
			IntPtr userdata
		) {
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return INTERNAL_SDL_SetWindowData(
				window,
				Utf8Encode(name, utf8Name, utf8NameBufSize),
				userdata
			);
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window display mode using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowDisplayMode(
			IntPtr window,
			ref SDL_DisplayMode mode
		);

		/* window refers to an SDL_Window* */
		/* NULL overload - use the window's dimensions and the desktop's format and refresh rate */
		/// <summary>
		/// Sdls the set window display mode using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="mode">The mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowDisplayMode(
			IntPtr window,
			IntPtr mode
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window fullscreen using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="flags">The flags</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowFullscreen(
			IntPtr window,
			uint flags
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window gamma ramp using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="red">The red</param>
		/// <param name="green">The green</param>
		/// <param name="blue">The blue</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowGammaRamp(
			IntPtr window,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] red,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] green,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] blue
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="grabbed">The grabbed</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowGrab(
			IntPtr window,
			SDL_bool grabbed
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the set window keyboard grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="grabbed">The grabbed</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowKeyboardGrab(
			IntPtr window,
			SDL_bool grabbed
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the set window mouse grab using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="grabbed">The grabbed</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowMouseGrab(
			IntPtr window,
			SDL_bool grabbed
		);


		/* window refers to an SDL_Window*, icon to an SDL_Surface* */
		/// <summary>
		/// Sdls the set window icon using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="icon">The icon</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowIcon(
			IntPtr window,
			IntPtr icon
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window maximum size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="max_w">The max</param>
		/// <param name="max_h">The max</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowMaximumSize(
			IntPtr window,
			int max_w,
			int max_h
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window minimum size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="min_w">The min</param>
		/// <param name="min_h">The min</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowMinimumSize(
			IntPtr window,
			int min_w,
			int min_h
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window position using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowPosition(
			IntPtr window,
			int x,
			int y
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowSize(
			IntPtr window,
			int w,
			int h
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the set window bordered using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="bordered">The bordered</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowBordered(
			IntPtr window,
			SDL_bool bordered
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window borders size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="top">The top</param>
		/// <param name="left">The left</param>
		/// <param name="bottom">The bottom</param>
		/// <param name="right">The right</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetWindowBordersSize(
			IntPtr window,
			out int top,
			out int left,
			out int bottom,
			out int right
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the set window resizable using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="resizable">The resizable</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowResizable(
			IntPtr window,
			SDL_bool resizable
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the set window always on top using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="on_top">The on top</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowAlwaysOnTop(
			IntPtr window,
			SDL_bool on_top
		);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Internals the sdl set window title using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="title">The title</param>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe void INTERNAL_SDL_SetWindowTitle(
			IntPtr window,
			byte* title
		);
		/// <summary>
		/// Sdls the set window title using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="title">The title</param>
		public static unsafe void SDL_SetWindowTitle(
			IntPtr window,
			string title
		) {
			int utf8TitleBufSize = Utf8Size(title);
			byte* utf8Title = stackalloc byte[utf8TitleBufSize];
			INTERNAL_SDL_SetWindowTitle(
				window,
				Utf8Encode(title, utf8Title, utf8TitleBufSize)
			);
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the show window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ShowWindow(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the update window surface using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateWindowSurface(IntPtr window);

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the update window surface rects using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="rects">The rects</param>
		/// <param name="numrects">The numrects</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateWindowSurfaceRects(
			IntPtr window,
			[In] SDL_Rect[] rects,
			int numrects
		);

		/// <summary>
		/// Internals the sdl video init using the specified driver name
		/// </summary>
		/// <param name="driver_name">The driver name</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_VideoInit(
			byte* driver_name
		);
		/// <summary>
		/// Sdls the video init using the specified driver name
		/// </summary>
		/// <param name="driver_name">The driver name</param>
		/// <returns>The int</returns>
		public static unsafe int SDL_VideoInit(string driver_name)
		{
			int utf8DriverNameBufSize = Utf8Size(driver_name);
			byte* utf8DriverName = stackalloc byte[utf8DriverNameBufSize];
			return INTERNAL_SDL_VideoInit(
				Utf8Encode(driver_name, utf8DriverName, utf8DriverNameBufSize)
			);
		}

		/// <summary>
		/// Sdls the video quit
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_VideoQuit();

		/* window refers to an SDL_Window*, callback_data to a void*
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the set window hit test using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="callback">The callback</param>
		/// <param name="callback_data">The callback data</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowHitTest(
			IntPtr window,
			SDL_HitTest callback,
			IntPtr callback_data
		);

		/* IntPtr refers to an SDL_Window*
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the get grabbed window
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetGrabbedWindow();

		/* window refers to an SDL_Window*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the set window mouse rect using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowMouseRect(
			IntPtr window,
			ref SDL_Rect rect
		);

		/* window refers to an SDL_Window*
		 * rect refers to an SDL_Rect*
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the set window mouse rect using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetWindowMouseRect(
			IntPtr window,
			IntPtr rect
		);

		/* window refers to an SDL_Window*
		 * IntPtr refers to an SDL_Rect*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the get window mouse rect using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetWindowMouseRect(
			IntPtr window
		);

		/* window refers to an SDL_Window*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the flash window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="operation">The operation</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FlashWindow(
			IntPtr window,
			SDL_FlashOperation operation
		);

		#endregion

		#region SDL_blendmode.h

		/// <summary>
		/// The sdl blendmode enum
		/// </summary>
		[Flags]
		public enum SDL_BlendMode
		{
			/// <summary>
			/// The sdl blendmode none sdl blendmode
			/// </summary>
			SDL_BLENDMODE_NONE =	0x00000000,
			/// <summary>
			/// The sdl blendmode blend sdl blendmode
			/// </summary>
			SDL_BLENDMODE_BLEND =	0x00000001,
			/// <summary>
			/// The sdl blendmode add sdl blendmode
			/// </summary>
			SDL_BLENDMODE_ADD =	0x00000002,
			/// <summary>
			/// The sdl blendmode mod sdl blendmode
			/// </summary>
			SDL_BLENDMODE_MOD =	0x00000004,
			/// <summary>
			/// The sdl blendmode mul sdl blendmode
			/// </summary>
			SDL_BLENDMODE_MUL =	0x00000008,	/* >= 2.0.11 */
			/// <summary>
			/// The sdl blendmode invalid sdl blendmode
			/// </summary>
			SDL_BLENDMODE_INVALID =	0x7FFFFFFF
		}

		/// <summary>
		/// The sdl blendoperation enum
		/// </summary>
		public enum SDL_BlendOperation
		{
			/// <summary>
			/// The sdl blendoperation add sdl blendoperation
			/// </summary>
			SDL_BLENDOPERATION_ADD		= 0x1,
			/// <summary>
			/// The sdl blendoperation subtract sdl blendoperation
			/// </summary>
			SDL_BLENDOPERATION_SUBTRACT	= 0x2,
			/// <summary>
			/// The sdl blendoperation rev subtract sdl blendoperation
			/// </summary>
			SDL_BLENDOPERATION_REV_SUBTRACT	= 0x3,
			/// <summary>
			/// The sdl blendoperation minimum sdl blendoperation
			/// </summary>
			SDL_BLENDOPERATION_MINIMUM	= 0x4,
			/// <summary>
			/// The sdl blendoperation maximum sdl blendoperation
			/// </summary>
			SDL_BLENDOPERATION_MAXIMUM	= 0x5
		}

		/// <summary>
		/// The sdl blendfactor enum
		/// </summary>
		public enum SDL_BlendFactor
		{
			/// <summary>
			/// The sdl blendfactor zero sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ZERO			= 0x1,
			/// <summary>
			/// The sdl blendfactor one sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ONE			= 0x2,
			/// <summary>
			/// The sdl blendfactor src color sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_SRC_COLOR		= 0x3,
			/// <summary>
			/// The sdl blendfactor one minus src color sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ONE_MINUS_SRC_COLOR	= 0x4,
			/// <summary>
			/// The sdl blendfactor src alpha sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_SRC_ALPHA		= 0x5,
			/// <summary>
			/// The sdl blendfactor one minus src alpha sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ONE_MINUS_SRC_ALPHA	= 0x6,
			/// <summary>
			/// The sdl blendfactor dst color sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_DST_COLOR		= 0x7,
			/// <summary>
			/// The sdl blendfactor one minus dst color sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ONE_MINUS_DST_COLOR	= 0x8,
			/// <summary>
			/// The sdl blendfactor dst alpha sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_DST_ALPHA		= 0x9,
			/// <summary>
			/// The sdl blendfactor one minus dst alpha sdl blendfactor
			/// </summary>
			SDL_BLENDFACTOR_ONE_MINUS_DST_ALPHA	= 0xA
		}

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the compose custom blend mode using the specified src color factor
		/// </summary>
		/// <param name="srcColorFactor">The src color factor</param>
		/// <param name="dstColorFactor">The dst color factor</param>
		/// <param name="colorOperation">The color operation</param>
		/// <param name="srcAlphaFactor">The src alpha factor</param>
		/// <param name="dstAlphaFactor">The dst alpha factor</param>
		/// <param name="alphaOperation">The alpha operation</param>
		/// <returns>The sdl blend mode</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_BlendMode SDL_ComposeCustomBlendMode(
			SDL_BlendFactor srcColorFactor,
			SDL_BlendFactor dstColorFactor,
			SDL_BlendOperation colorOperation,
			SDL_BlendFactor srcAlphaFactor,
			SDL_BlendFactor dstAlphaFactor,
			SDL_BlendOperation alphaOperation
		);

		#endregion

		#region SDL_vulkan.h

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Internals the sdl vulkan load library using the specified path
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_Vulkan_LoadLibrary(
			byte* path
		);
		/// <summary>
		/// Sdls the vulkan load library using the specified path
		/// </summary>
		/// <param name="path">The path</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_Vulkan_LoadLibrary(string path)
		{
			byte* utf8Path = Utf8EncodeHeap(path);
			int result = INTERNAL_SDL_Vulkan_LoadLibrary(
				utf8Path
			);
			Marshal.FreeHGlobal((IntPtr) utf8Path);
			return result;
		}

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the vulkan get vk get instance proc addr
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the vulkan unload library
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Vulkan_UnloadLibrary();

		/* window refers to an SDL_Window*, pNames to a const char**.
		 * Only available in 2.0.6 or higher.
		 * This overload allows for IntPtr.Zero (null) to be passed for pNames.
		 */
		/// <summary>
		/// Sdls the vulkan get instance extensions using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="pCount">The count</param>
		/// <param name="pNames">The names</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_Vulkan_GetInstanceExtensions(
			IntPtr window,
			out uint pCount,
			IntPtr pNames
		);

		/* window refers to an SDL_Window*, pNames to a const char**.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the vulkan get instance extensions using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="pCount">The count</param>
		/// <param name="pNames">The names</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_Vulkan_GetInstanceExtensions(
			IntPtr window,
			out uint pCount,
			IntPtr[] pNames
		);

		/* window refers to an SDL_Window.
		 * instance refers to a VkInstance.
		 * surface refers to a VkSurfaceKHR.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the vulkan create surface using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="instance">The instance</param>
		/// <param name="surface">The surface</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_Vulkan_CreateSurface(
			IntPtr window,
			IntPtr instance,
			out ulong surface
		);

		/* window refers to an SDL_Window*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the vulkan get drawable size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Vulkan_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		#endregion

		#region SDL_metal.h

		/* Only available in 2.0.11 or higher. */
		/// <summary>
		/// Sdls the metal create view using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_Metal_CreateView(
			IntPtr window
		);

		/* Only available in 2.0.11 or higher. */
		/// <summary>
		/// Sdls the metal destroy view using the specified view
		/// </summary>
		/// <param name="view">The view</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Metal_DestroyView(
			IntPtr view
		);

		/* view refers to an SDL_MetalView.
		 * Only available in 2.0.14 or higher. */
		/// <summary>
		/// Sdls the metal get layer using the specified view
		/// </summary>
		/// <param name="view">The view</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_Metal_GetLayer(
			IntPtr view
		);

		/* window refers to an SDL_Window*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the metal get drawable size using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Metal_GetDrawableSize(
			IntPtr window,
			out int w,
			out int h
		);

		#endregion

		#region SDL_render.h

		/// <summary>
		/// The sdl rendererflags enum
		/// </summary>
		[Flags]
		public enum SDL_RendererFlags : uint
		{
			/// <summary>
			/// The sdl renderer software sdl rendererflags
			/// </summary>
			SDL_RENDERER_SOFTWARE =		0x00000001,
			/// <summary>
			/// The sdl renderer accelerated sdl rendererflags
			/// </summary>
			SDL_RENDERER_ACCELERATED =	0x00000002,
			/// <summary>
			/// The sdl renderer presentvsync sdl rendererflags
			/// </summary>
			SDL_RENDERER_PRESENTVSYNC =	0x00000004,
			/// <summary>
			/// The sdl renderer targettexture sdl rendererflags
			/// </summary>
			SDL_RENDERER_TARGETTEXTURE =	0x00000008
		}

		/// <summary>
		/// The sdl rendererflip enum
		/// </summary>
		[Flags]
		public enum SDL_RendererFlip
		{
			/// <summary>
			/// The sdl flip none sdl rendererflip
			/// </summary>
			SDL_FLIP_NONE =		0x00000000,
			/// <summary>
			/// The sdl flip horizontal sdl rendererflip
			/// </summary>
			SDL_FLIP_HORIZONTAL =	0x00000001,
			/// <summary>
			/// The sdl flip vertical sdl rendererflip
			/// </summary>
			SDL_FLIP_VERTICAL =	0x00000002
		}

		/// <summary>
		/// The sdl textureaccess enum
		/// </summary>
		public enum SDL_TextureAccess
		{
			/// <summary>
			/// The sdl textureaccess static sdl textureaccess
			/// </summary>
			SDL_TEXTUREACCESS_STATIC,
			/// <summary>
			/// The sdl textureaccess streaming sdl textureaccess
			/// </summary>
			SDL_TEXTUREACCESS_STREAMING,
			/// <summary>
			/// The sdl textureaccess target sdl textureaccess
			/// </summary>
			SDL_TEXTUREACCESS_TARGET
		}

		/// <summary>
		/// The sdl texturemodulate enum
		/// </summary>
		[Flags]
		public enum SDL_TextureModulate
		{
			/// <summary>
			/// The sdl texturemodulate none sdl texturemodulate
			/// </summary>
			SDL_TEXTUREMODULATE_NONE =		0x00000000,
			/// <summary>
			/// The sdl texturemodulate horizontal sdl texturemodulate
			/// </summary>
			SDL_TEXTUREMODULATE_HORIZONTAL =	0x00000001,
			/// <summary>
			/// The sdl texturemodulate vertical sdl texturemodulate
			/// </summary>
			SDL_TEXTUREMODULATE_VERTICAL =		0x00000002
		}

		/// <summary>
		/// The sdl rendererinfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_RendererInfo
		{
			/// <summary>
			/// The name
			/// </summary>
			public IntPtr name; // const char*
			/// <summary>
			/// The flags
			/// </summary>
			public uint flags;
			/// <summary>
			/// The num texture formats
			/// </summary>
			public uint num_texture_formats;
			/// <summary>
			/// The texture formats
			/// </summary>
			public fixed uint texture_formats[16];
			/// <summary>
			/// The max texture width
			/// </summary>
			public int max_texture_width;
			/// <summary>
			/// The max texture height
			/// </summary>
			public int max_texture_height;
		}

		/* Only available in 2.0.11 or higher. */
		/// <summary>
		/// The sdl scalemode enum
		/// </summary>
		public enum SDL_ScaleMode
		{
			/// <summary>
			/// The sdl scalemodenearest sdl scalemode
			/// </summary>
			SDL_ScaleModeNearest,
			/// <summary>
			/// The sdl scalemodelinear sdl scalemode
			/// </summary>
			SDL_ScaleModeLinear,
			/// <summary>
			/// The sdl scalemodebest sdl scalemode
			/// </summary>
			SDL_ScaleModeBest
		}

		/* Only available in 2.0.18 or higher. */
		/// <summary>
		/// The sdl vertex
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Vertex
		{
			/// <summary>
			/// The position
			/// </summary>
			public SDL_FPoint position;
			/// <summary>
			/// The color
			/// </summary>
			public SDL_Color color;
			/// <summary>
			/// The tex coord
			/// </summary>
			public SDL_FPoint tex_coord;
		}

		/* IntPtr refers to an SDL_Renderer*, window to an SDL_Window* */
		/// <summary>
		/// Sdls the create renderer using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="index">The index</param>
		/// <param name="flags">The flags</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRenderer(
			IntPtr window,
			int index,
			SDL_RendererFlags flags
		);

		/* IntPtr refers to an SDL_Renderer*, surface to an SDL_Surface* */
		/// <summary>
		/// Sdls the create software renderer using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

		/* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
		/// <summary>
		/// Sdls the create texture using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="format">The format</param>
		/// <param name="access">The access</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateTexture(
			IntPtr renderer,
			uint format,
			int access,
			int w,
			int h
		);

		/* IntPtr refers to an SDL_Texture*
		 * renderer refers to an SDL_Renderer*
		 * surface refers to an SDL_Surface*
		 */
		/// <summary>
		/// Sdls the create texture from surface using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="surface">The surface</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateTextureFromSurface(
			IntPtr renderer,
			IntPtr surface
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the destroy renderer using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyRenderer(IntPtr renderer);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the destroy texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DestroyTexture(IntPtr texture);

		/// <summary>
		/// Sdls the get num render drivers
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumRenderDrivers();

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the get render draw blend mode using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDrawBlendMode(
			IntPtr renderer,
			out SDL_BlendMode blendMode
		);

		/* texture refers to an SDL_Texture*
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the set texture scale mode using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="scaleMode">The scale mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureScaleMode(
			IntPtr texture,
			SDL_ScaleMode scaleMode
		);

		/* texture refers to an SDL_Texture*
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the get texture scale mode using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="scaleMode">The scale mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureScaleMode(
			IntPtr texture,
			out SDL_ScaleMode scaleMode
		);

		/* texture refers to an SDL_Texture*
		 * userdata refers to a void*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the set texture user data using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="userdata">The userdata</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureUserData(
			IntPtr texture,
			IntPtr userdata
		);

		/* IntPtr refers to a void*, texture refers to an SDL_Texture*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the get texture user data using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the get render draw color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDrawColor(
			IntPtr renderer,
			out byte r,
			out byte g,
			out byte b,
			out byte a
		);

		/// <summary>
		/// Sdls the get render driver info using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <param name="info">The info</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRenderDriverInfo(
			int index,
			out SDL_RendererInfo info
		);

		/* IntPtr refers to an SDL_Renderer*, window to an SDL_Window* */
		/// <summary>
		/// Sdls the get renderer using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetRenderer(IntPtr window);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the get renderer info using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="info">The info</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRendererInfo(
			IntPtr renderer,
			out SDL_RendererInfo info
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the get renderer output size using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetRendererOutputSize(
			IntPtr renderer,
			out int w,
			out int h
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the get texture alpha mod using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="alpha">The alpha</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureAlphaMod(
			IntPtr texture,
			out byte alpha
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the get texture blend mode using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureBlendMode(
			IntPtr texture,
			out SDL_BlendMode blendMode
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the get texture color mod using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetTextureColorMod(
			IntPtr texture,
			out byte r,
			out byte g,
			out byte b
		);

		/* texture refers to an SDL_Texture*, pixels to a void* */
		/// <summary>
		/// Sdls the lock texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="pixels">The pixels</param>
		/// <param name="pitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTexture(
			IntPtr texture,
			ref SDL_Rect rect,
			out IntPtr pixels,
			out int pitch
		);

		/* texture refers to an SDL_Texture*, pixels to a void*.
		 * Internally, this function contains logic to use default values when
		 * the rectangle is passed as NULL.
		 * This overload allows for IntPtr.Zero to be passed for rect.
		 */
		/// <summary>
		/// Sdls the lock texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="pixels">The pixels</param>
		/// <param name="pitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTexture(
			IntPtr texture,
			IntPtr rect,
			out IntPtr pixels,
			out int pitch
		);

		/* texture refers to an SDL_Texture*, surface to an SDL_Surface*
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the lock texture to surface using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="surface">The surface</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTextureToSurface(
			IntPtr texture,
			ref SDL_Rect rect,
			out IntPtr surface
		);

		/* texture refers to an SDL_Texture*, surface to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * the rectangle is passed as NULL.
		 * This overload allows for IntPtr.Zero to be passed for rect.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the lock texture to surface using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="surface">The surface</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockTextureToSurface(
			IntPtr texture,
			IntPtr rect,
			out IntPtr surface
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the query texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="format">The format</param>
		/// <param name="access">The access</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_QueryTexture(
			IntPtr texture,
			out uint format,
			out int access,
			out int w,
			out int h
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render clear using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderClear(IntPtr renderer);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
		/// <summary>
		/// Sdls the render copy using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_Rect dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the render copy using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_Rect dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the render copy using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
		 */
		/// <summary>
		/// Sdls the render copy using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopy(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_Rect dstrect,
			double angle,
			ref SDL_Point center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_Rect dstrect,
			double angle,
			ref SDL_Point center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect,
			double angle,
			ref SDL_Point center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_Rect dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			ref SDL_Point center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_Rect dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw line using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLine(
			IntPtr renderer,
			int x1,
			int y1,
			int x2,
			int y2
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw lines using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="points">The points</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLines(
			IntPtr renderer,
			[In] SDL_Point[] points,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw point using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPoint(
			IntPtr renderer,
			int x,
			int y
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw points using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="points">The points</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPoints(
			IntPtr renderer,
			[In] SDL_Point[] points,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRect(
			IntPtr renderer,
			ref SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		/// <summary>
		/// Sdls the render draw rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw rects using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rects">The rects</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRects(
			IntPtr renderer,
			[In] SDL_Rect[] rects,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render fill rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRect(
			IntPtr renderer,
			ref SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		/// <summary>
		/// Sdls the render fill rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render fill rects using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rects">The rects</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRects(
			IntPtr renderer,
			[In] SDL_Rect[] rects,
			int count
		);

		#region Floating Point Render Functions

		/* This region only available in SDL 2.0.10 or higher. */

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
		/// <summary>
		/// Sdls the render copy f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_FRect dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the render copy f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_FRect dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the render copy f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
		 */
		/// <summary>
		/// Sdls the render copy f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_FRect dstrect,
			double angle,
			ref SDL_FPoint center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the render copy ex using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyEx(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_FRect dstrect,
			double angle,
			ref SDL_FPoint center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect,
			double angle,
			ref SDL_FPoint center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for center.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			ref SDL_FRect dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and dstrect.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			ref SDL_FPoint center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * srcrect and center.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			ref SDL_FRect dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both
		 * dstrect and center.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			ref SDL_Rect srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture*.
		 * Internally, this function contains logic to use default values when
		 * source, destination, and/or center are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for all
		 * three parameters.
		 */
		/// <summary>
		/// Sdls the render copy ex f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dstrect">The dstrect</param>
		/// <param name="angle">The angle</param>
		/// <param name="center">The center</param>
		/// <param name="flip">The flip</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderCopyExF(
			IntPtr renderer,
			IntPtr texture,
			IntPtr srcrect,
			IntPtr dstrect,
			double angle,
			IntPtr center,
			SDL_RendererFlip flip
		);

		/* renderer refers to an SDL_Renderer*
		 * texture refers to an SDL_Texture*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the render geometry using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="vertices">The vertices</param>
		/// <param name="num_vertices">The num vertices</param>
		/// <param name="indices">The indices</param>
		/// <param name="num_indices">The num indices</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderGeometry(
			IntPtr renderer,
			IntPtr texture,
			[In] SDL_Vertex[] vertices,
			int num_vertices,
			[In] int[] indices,
			int num_indices
		);

		/* renderer refers to an SDL_Renderer*
		 * texture refers to an SDL_Texture*
		 * indices refers to a void*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the render geometry raw using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <param name="xy">The xy</param>
		/// <param name="xy_stride">The xy stride</param>
		/// <param name="color">The color</param>
		/// <param name="color_stride">The color stride</param>
		/// <param name="uv">The uv</param>
		/// <param name="uv_stride">The uv stride</param>
		/// <param name="num_vertices">The num vertices</param>
		/// <param name="indices">The indices</param>
		/// <param name="num_indices">The num indices</param>
		/// <param name="size_indices">The size indices</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderGeometryRaw(
			IntPtr renderer,
			IntPtr texture,
			[In] float[] xy,
			int xy_stride,
			[In] int[] color,
			int color_stride,
			[In] float[] uv,
			int uv_stride,
			int num_vertices,
			IntPtr indices,
			int num_indices,
			int size_indices
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw point f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPointF(
			IntPtr renderer,
			float x,
			float y
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw points f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="points">The points</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawPointsF(
			IntPtr renderer,
			[In] SDL_FPoint[] points,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw line f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="x1">The </param>
		/// <param name="y1">The </param>
		/// <param name="x2">The </param>
		/// <param name="y2">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLineF(
			IntPtr renderer,
			float x1,
			float y1,
			float x2,
			float y2
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw lines f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="points">The points</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawLinesF(
			IntPtr renderer,
			[In] SDL_FPoint[] points,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw rect f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRectF(
			IntPtr renderer,
			ref SDL_FRect rect
		);

		/* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		/// <summary>
		/// Sdls the render draw rect f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRectF(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render draw rects f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rects">The rects</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderDrawRectsF(
			IntPtr renderer,
			[In] SDL_FRect[] rects,
			int count
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render fill rect f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRectF(
			IntPtr renderer,
			ref SDL_FRect rect
		);

		/* renderer refers to an SDL_Renderer*, rect to an SDL_Rect*.
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		/// <summary>
		/// Sdls the render fill rect f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRectF(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render fill rects f using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rects">The rects</param>
		/// <param name="count">The count</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFillRectsF(
			IntPtr renderer,
			[In] SDL_FRect[] rects,
			int count
		);

		#endregion

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render get clip rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetClipRect(
			IntPtr renderer,
			out SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render get logical size using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetLogicalSize(
			IntPtr renderer,
			out int w,
			out int h
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render get scale using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="scaleX">The scale</param>
		/// <param name="scaleY">The scale</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderGetScale(
			IntPtr renderer,
			out float scaleX,
			out float scaleY
		);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the render window to logical using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="windowX">The window</param>
		/// <param name="windowY">The window</param>
		/// <param name="logicalX">The logical</param>
		/// <param name="logicalY">The logical</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderWindowToLogical(
			IntPtr renderer,
			int windowX,
			int windowY,
			out float logicalX,
			out float logicalY
		);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the render logical to window using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="logicalX">The logical</param>
		/// <param name="logicalY">The logical</param>
		/// <param name="windowX">The window</param>
		/// <param name="windowY">The window</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderLogicalToWindow(
			IntPtr renderer,
			float logicalX,
			float logicalY,
			out int windowX,
			out int windowY
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render get viewport using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderGetViewport(
			IntPtr renderer,
			out SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render present using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_RenderPresent(IntPtr renderer);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render read pixels using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <param name="format">The format</param>
		/// <param name="pixels">The pixels</param>
		/// <param name="pitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderReadPixels(
			IntPtr renderer,
			ref SDL_Rect rect,
			uint format,
			IntPtr pixels,
			int pitch
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render set clip rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetClipRect(
			IntPtr renderer,
			ref SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer*
		 * This overload allows for IntPtr.Zero (null) to be passed for rect.
		 */
		/// <summary>
		/// Sdls the render set clip rect using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetClipRect(
			IntPtr renderer,
			IntPtr rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render set logical size using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetLogicalSize(
			IntPtr renderer,
			int w,
			int h
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render set scale using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="scaleX">The scale</param>
		/// <param name="scaleY">The scale</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetScale(
			IntPtr renderer,
			float scaleX,
			float scaleY
		);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the render set integer scale using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="enable">The enable</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetIntegerScale(
			IntPtr renderer,
			SDL_bool enable
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render set viewport using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="rect">The rect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetViewport(
			IntPtr renderer,
			ref SDL_Rect rect
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the set render draw blend mode using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderDrawBlendMode(
			IntPtr renderer,
			SDL_BlendMode blendMode
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the set render draw color using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderDrawColor(
			IntPtr renderer,
			byte r,
			byte g,
			byte b,
			byte a
		);

		/* renderer refers to an SDL_Renderer*, texture to an SDL_Texture* */
		/// <summary>
		/// Sdls the set render target using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="texture">The texture</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRenderTarget(
			IntPtr renderer,
			IntPtr texture
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the set texture alpha mod using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="alpha">The alpha</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureAlphaMod(
			IntPtr texture,
			byte alpha
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the set texture blend mode using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureBlendMode(
			IntPtr texture,
			SDL_BlendMode blendMode
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the set texture color mod using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetTextureColorMod(
			IntPtr texture,
			byte r,
			byte g,
			byte b
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the unlock texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockTexture(IntPtr texture);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the update texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="pixels">The pixels</param>
		/// <param name="pitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateTexture(
			IntPtr texture,
			ref SDL_Rect rect,
			IntPtr pixels,
			int pitch
		);

		/* texture refers to an SDL_Texture* */
		/// <summary>
		/// Sdls the update texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="pixels">The pixels</param>
		/// <param name="pitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateTexture(
			IntPtr texture,
			IntPtr rect,
			IntPtr pixels,
			int pitch
		);

		/* texture refers to an SDL_Texture*
		 * Only available in 2.0.1 or higher.
		 */
		/// <summary>
		/// Sdls the update yuv texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="yPlane">The plane</param>
		/// <param name="yPitch">The pitch</param>
		/// <param name="uPlane">The plane</param>
		/// <param name="uPitch">The pitch</param>
		/// <param name="vPlane">The plane</param>
		/// <param name="vPitch">The pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateYUVTexture(
			IntPtr texture,
			ref SDL_Rect rect,
			IntPtr yPlane,
			int yPitch,
			IntPtr uPlane,
			int uPitch,
			IntPtr vPlane,
			int vPitch
		);

		/* texture refers to an SDL_Texture*.
		 * yPlane and uvPlane refer to const Uint*.
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the update nv texture using the specified texture
		/// </summary>
		/// <param name="texture">The texture</param>
		/// <param name="rect">The rect</param>
		/// <param name="yPlane">The plane</param>
		/// <param name="yPitch">The pitch</param>
		/// <param name="uvPlane">The uv plane</param>
		/// <param name="uvPitch">The uv pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpdateNVTexture(
			IntPtr texture,
			ref SDL_Rect rect,
			IntPtr yPlane,
			int yPitch,
			IntPtr uvPlane,
			int uvPitch
		);

		/* renderer refers to an SDL_Renderer* */
		/// <summary>
		/// Sdls the render target supported using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_RenderTargetSupported(
			IntPtr renderer
		);

		/* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
		/// <summary>
		/// Sdls the get render target using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.8 or higher.
		 */
		/// <summary>
		/// Sdls the render get metal layer using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RenderGetMetalLayer(
			IntPtr renderer
		);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.8 or higher.
		 */
		/// <summary>
		/// Sdls the render get metal command encoder using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RenderGetMetalCommandEncoder(
			IntPtr renderer
		);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the render set v sync using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <param name="vsync">The vsync</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderSetVSync(IntPtr renderer, int vsync);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the render is clip enabled using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_RenderIsClipEnabled(IntPtr renderer);

		/* renderer refers to an SDL_Renderer*
		 * Only available in 2.0.10 or higher.
		 */
		/// <summary>
		/// Sdls the render flush using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_RenderFlush(IntPtr renderer);

		#endregion

		#region SDL_pixels.h

		/// <summary>
		/// Sdls the define pixelfourcc using the specified a
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <param name="C">The </param>
		/// <param name="D">The </param>
		/// <returns>The uint</returns>
		public static uint SDL_DEFINE_PIXELFOURCC(byte A, byte B, byte C, byte D)
		{
			return SDL_FOURCC(A, B, C, D);
		}

		/// <summary>
		/// Sdls the define pixelformat using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <param name="order">The order</param>
		/// <param name="layout">The layout</param>
		/// <param name="bits">The bits</param>
		/// <param name="bytes">The bytes</param>
		/// <returns>The uint</returns>
		public static uint SDL_DEFINE_PIXELFORMAT(
			SDL_PixelType type,
			uint order,
			SDL_PackedLayout layout,
			byte bits,
			byte bytes
		) {
			return (uint) (
				(1 << 28) |
				(((byte) type) << 24) |
				(((byte) order) << 20) |
				(((byte) layout) << 16) |
				(bits << 8) |
				(bytes)
			);
		}

		/// <summary>
		/// Sdls the pixelflag using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_PIXELFLAG(uint X)
		{
			return (byte) ((X >> 28) & 0x0F);
		}

		/// <summary>
		/// Sdls the pixeltype using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_PIXELTYPE(uint X)
		{
			return (byte) ((X >> 24) & 0x0F);
		}

		/// <summary>
		/// Sdls the pixelorder using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_PIXELORDER(uint X)
		{
			return (byte) ((X >> 20) & 0x0F);
		}

		/// <summary>
		/// Sdls the pixellayout using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_PIXELLAYOUT(uint X)
		{
			return (byte) ((X >> 16) & 0x0F);
		}

		/// <summary>
		/// Sdls the bitsperpixel using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_BITSPERPIXEL(uint X)
		{
			return (byte) ((X >> 8) & 0xFF);
		}

		/// <summary>
		/// Sdls the bytesperpixel using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The byte</returns>
		public static byte SDL_BYTESPERPIXEL(uint X)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(X))
			{
				if (	(X == SDL_PIXELFORMAT_YUY2) ||
						(X == SDL_PIXELFORMAT_UYVY) ||
						(X == SDL_PIXELFORMAT_YVYU)	)
				{
					return 2;
				}
				return 1;
			}
			return (byte) (X & 0xFF);
		}

		/// <summary>
		/// Describes whether sdl ispixelformat indexed
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The bool</returns>
		public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			SDL_PixelType pType =
				(SDL_PixelType) SDL_PIXELTYPE(format);
			return (
				pType == SDL_PixelType.SDL_PIXELTYPE_INDEX1 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_INDEX4 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_INDEX8
			);
		}

		/// <summary>
		/// Describes whether sdl ispixelformat packed
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The bool</returns>
		public static bool SDL_ISPIXELFORMAT_PACKED(uint format)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			SDL_PixelType pType =
				(SDL_PixelType) SDL_PIXELTYPE(format);
			return (
				pType == SDL_PixelType.SDL_PIXELTYPE_PACKED8 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_PACKED16 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_PACKED32
			);
		}

		/// <summary>
		/// Describes whether sdl ispixelformat array
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The bool</returns>
		public static bool SDL_ISPIXELFORMAT_ARRAY(uint format)
		{
			if (SDL_ISPIXELFORMAT_FOURCC(format))
			{
				return false;
			}
			SDL_PixelType pType =
				(SDL_PixelType) SDL_PIXELTYPE(format);
			return (
				pType == SDL_PixelType.SDL_PIXELTYPE_ARRAYU8 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_ARRAYU16 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_ARRAYU32 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_ARRAYF16 ||
				pType == SDL_PixelType.SDL_PIXELTYPE_ARRAYF32
			);
		}

		/// <summary>
		/// Describes whether sdl ispixelformat alpha
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The bool</returns>
		public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
		{
			if (SDL_ISPIXELFORMAT_PACKED(format))
			{
				SDL_PackedOrder pOrder =
					(SDL_PackedOrder) SDL_PIXELORDER(format);
				return (
					pOrder == SDL_PackedOrder.SDL_PACKEDORDER_ARGB ||
					pOrder == SDL_PackedOrder.SDL_PACKEDORDER_RGBA ||
					pOrder == SDL_PackedOrder.SDL_PACKEDORDER_ABGR ||
					pOrder == SDL_PackedOrder.SDL_PACKEDORDER_BGRA
				);
			}
			else if (SDL_ISPIXELFORMAT_ARRAY(format))
			{
				SDL_ArrayOrder aOrder =
					(SDL_ArrayOrder) SDL_PIXELORDER(format);
				return (
					aOrder == SDL_ArrayOrder.SDL_ARRAYORDER_ARGB ||
					aOrder == SDL_ArrayOrder.SDL_ARRAYORDER_RGBA ||
					aOrder == SDL_ArrayOrder.SDL_ARRAYORDER_ABGR ||
					aOrder == SDL_ArrayOrder.SDL_ARRAYORDER_BGRA
				);
			}
			return false;
		}

		/// <summary>
		/// Describes whether sdl ispixelformat fourcc
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The bool</returns>
		public static bool SDL_ISPIXELFORMAT_FOURCC(uint format)
		{
			return (format == 0) && (SDL_PIXELFLAG(format) != 1);
		}

		/// <summary>
		/// The sdl pixeltype enum
		/// </summary>
		public enum SDL_PixelType
		{
			/// <summary>
			/// The sdl pixeltype unknown sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_UNKNOWN,
			/// <summary>
			/// The sdl pixeltype index1 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_INDEX1,
			/// <summary>
			/// The sdl pixeltype index4 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_INDEX4,
			/// <summary>
			/// The sdl pixeltype index8 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_INDEX8,
			/// <summary>
			/// The sdl pixeltype packed8 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_PACKED8,
			/// <summary>
			/// The sdl pixeltype packed16 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_PACKED16,
			/// <summary>
			/// The sdl pixeltype packed32 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_PACKED32,
			/// <summary>
			/// The sdl pixeltype arrayu8 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_ARRAYU8,
			/// <summary>
			/// The sdl pixeltype arrayu16 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_ARRAYU16,
			/// <summary>
			/// The sdl pixeltype arrayu32 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_ARRAYU32,
			/// <summary>
			/// The sdl pixeltype arrayf16 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_ARRAYF16,
			/// <summary>
			/// The sdl pixeltype arrayf32 sdl pixeltype
			/// </summary>
			SDL_PIXELTYPE_ARRAYF32
		}

		/// <summary>
		/// The sdl bitmaporder enum
		/// </summary>
		public enum SDL_BitmapOrder
		{
			/// <summary>
			/// The sdl bitmaporder none sdl bitmaporder
			/// </summary>
			SDL_BITMAPORDER_NONE,
			/// <summary>
			/// The sdl bitmaporder 4321 sdl bitmaporder
			/// </summary>
			SDL_BITMAPORDER_4321,
			/// <summary>
			/// The sdl bitmaporder 1234 sdl bitmaporder
			/// </summary>
			SDL_BITMAPORDER_1234
		}

		/// <summary>
		/// The sdl packedorder enum
		/// </summary>
		public enum SDL_PackedOrder
		{
			/// <summary>
			/// The sdl packedorder none sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_NONE,
			/// <summary>
			/// The sdl packedorder xrgb sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_XRGB,
			/// <summary>
			/// The sdl packedorder rgbx sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_RGBX,
			/// <summary>
			/// The sdl packedorder argb sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_ARGB,
			/// <summary>
			/// The sdl packedorder rgba sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_RGBA,
			/// <summary>
			/// The sdl packedorder xbgr sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_XBGR,
			/// <summary>
			/// The sdl packedorder bgrx sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_BGRX,
			/// <summary>
			/// The sdl packedorder abgr sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_ABGR,
			/// <summary>
			/// The sdl packedorder bgra sdl packedorder
			/// </summary>
			SDL_PACKEDORDER_BGRA
		}

		/// <summary>
		/// The sdl arrayorder enum
		/// </summary>
		public enum SDL_ArrayOrder
		{
			/// <summary>
			/// The sdl arrayorder none sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_NONE,
			/// <summary>
			/// The sdl arrayorder rgb sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_RGB,
			/// <summary>
			/// The sdl arrayorder rgba sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_RGBA,
			/// <summary>
			/// The sdl arrayorder argb sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_ARGB,
			/// <summary>
			/// The sdl arrayorder bgr sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_BGR,
			/// <summary>
			/// The sdl arrayorder bgra sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_BGRA,
			/// <summary>
			/// The sdl arrayorder abgr sdl arrayorder
			/// </summary>
			SDL_ARRAYORDER_ABGR
		}

		/// <summary>
		/// The sdl packedlayout enum
		/// </summary>
		public enum SDL_PackedLayout
		{
			/// <summary>
			/// The sdl packedlayout none sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_NONE,
			/// <summary>
			/// The sdl packedlayout 332 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_332,
			/// <summary>
			/// The sdl packedlayout 4444 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_4444,
			/// <summary>
			/// The sdl packedlayout 1555 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_1555,
			/// <summary>
			/// The sdl packedlayout 5551 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_5551,
			/// <summary>
			/// The sdl packedlayout 565 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_565,
			/// <summary>
			/// The sdl packedlayout 8888 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_8888,
			/// <summary>
			/// The sdl packedlayout 2101010 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_2101010,
			/// <summary>
			/// The sdl packedlayout 1010102 sdl packedlayout
			/// </summary>
			SDL_PACKEDLAYOUT_1010102
		}

		/// <summary>
		/// The sdl pixelformat unknown
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_UNKNOWN = 0;
		/// <summary>
		/// The sdl bitmaporder 4321
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_INDEX1LSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX1,
				(uint) SDL_BitmapOrder.SDL_BITMAPORDER_4321,
				0,
				1, 0
			);
		/// <summary>
		/// The sdl bitmaporder 1234
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_INDEX1MSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX1,
				(uint) SDL_BitmapOrder.SDL_BITMAPORDER_1234,
				0,
				1, 0
			);
		/// <summary>
		/// The sdl bitmaporder 4321
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_INDEX4LSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX4,
				(uint) SDL_BitmapOrder.SDL_BITMAPORDER_4321,
				0,
				4, 0
			);
		/// <summary>
		/// The sdl bitmaporder 1234
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_INDEX4MSB =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX4,
				(uint) SDL_BitmapOrder.SDL_BITMAPORDER_1234,
				0,
				4, 0
			);
		/// <summary>
		/// The sdl pixeltype index8
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_INDEX8 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX8,
				0,
				0,
				8, 1
			);
		/// <summary>
		/// The sdl packedlayout 332
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB332 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED8,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XRGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_332,
				8, 1
			);
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XRGB444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XRGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				12, 2
			);
		/// <summary>
		/// The sdl pixelformat xrgb444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB444 =
			SDL_PIXELFORMAT_XRGB444;
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XBGR444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XBGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				12, 2
			);
		/// <summary>
		/// The sdl pixelformat xbgr444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGR444 =
			SDL_PIXELFORMAT_XBGR444;
		/// <summary>
		/// The sdl packedlayout 1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XRGB1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XRGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_1555,
				15, 2
			);
		/// <summary>
		/// The sdl pixelformat xrgb1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB555 =
			SDL_PIXELFORMAT_XRGB1555;
		/// <summary>
		/// The sdl packedlayout 1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XBGR1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_INDEX1,
				(uint) SDL_BitmapOrder.SDL_BITMAPORDER_4321,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_1555,
				15, 2
			);
		/// <summary>
		/// The sdl pixelformat xbgr1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGR555 =
			SDL_PIXELFORMAT_XBGR1555;
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ARGB4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ARGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGBA4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_RGBA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ABGR4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ABGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 4444
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGRA4444 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_BGRA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_4444,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ARGB1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ARGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_1555,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 5551
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGBA5551 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_RGBA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_5551,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 1555
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ABGR1555 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ABGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_1555,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 5551
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGRA5551 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_BGRA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_5551,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 565
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB565 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XRGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_565,
				16, 2
			);
		/// <summary>
		/// The sdl packedlayout 565
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGR565 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED16,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XBGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_565,
				16, 2
			);
		/// <summary>
		/// The sdl arrayorder rgb
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB24 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_ARRAYU8,
				(uint) SDL_ArrayOrder.SDL_ARRAYORDER_RGB,
				0,
				24, 3
			);
		/// <summary>
		/// The sdl arrayorder bgr
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGR24 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_ARRAYU8,
				(uint) SDL_ArrayOrder.SDL_ARRAYORDER_BGR,
				0,
				24, 3
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XRGB888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XRGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		/// <summary>
		/// The sdl pixelformat xrgb888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGB888 =
			SDL_PIXELFORMAT_XRGB888;
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGBX8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_RGBX,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_XBGR888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_XBGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		/// <summary>
		/// The sdl pixelformat xbgr888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGR888 =
			SDL_PIXELFORMAT_XBGR888;
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGRX8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_BGRX,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				24, 4
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ARGB8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ARGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_RGBA8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_RGBA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ABGR8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ABGR,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		/// <summary>
		/// The sdl packedlayout 8888
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_BGRA8888 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_BGRA,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_8888,
				32, 4
			);
		/// <summary>
		/// The sdl packedlayout 2101010
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_ARGB2101010 =
			SDL_DEFINE_PIXELFORMAT(
				SDL_PixelType.SDL_PIXELTYPE_PACKED32,
				(uint) SDL_PackedOrder.SDL_PACKEDORDER_ARGB,
				SDL_PackedLayout.SDL_PACKEDLAYOUT_2101010,
				32, 4
			);
		/// <summary>
		/// The sdl define pixelfourcc
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_YV12 =
			SDL_DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
			);
		/// <summary>
		/// The sdl define pixelfourcc
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_IYUV =
			SDL_DEFINE_PIXELFOURCC(
				(byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
			);
		/// <summary>
		/// The sdl define pixelfourcc
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_YUY2 =
			SDL_DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
			);
		/// <summary>
		/// The sdl define pixelfourcc
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_UYVY =
			SDL_DEFINE_PIXELFOURCC(
				(byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
			);
		/// <summary>
		/// The sdl define pixelfourcc
		/// </summary>
		public static readonly uint SDL_PIXELFORMAT_YVYU =
			SDL_DEFINE_PIXELFOURCC(
				(byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
			);

		/// <summary>
		/// The sdl color
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Color
		{
			/// <summary>
			/// The 
			/// </summary>
			public byte r;
			/// <summary>
			/// The 
			/// </summary>
			public byte g;
			/// <summary>
			/// The 
			/// </summary>
			public byte b;
			/// <summary>
			/// The 
			/// </summary>
			public byte a;
		}

		/// <summary>
		/// The sdl palette
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Palette
		{
			/// <summary>
			/// The ncolors
			/// </summary>
			public int ncolors;
			/// <summary>
			/// The colors
			/// </summary>
			public IntPtr colors;
			/// <summary>
			/// The version
			/// </summary>
			public int version;
			/// <summary>
			/// The refcount
			/// </summary>
			public int refcount;
		}

		/// <summary>
		/// The sdl pixelformat
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_PixelFormat
		{
			/// <summary>
			/// The format
			/// </summary>
			public uint format;
			/// <summary>
			/// The palette
			/// </summary>
			public IntPtr palette; // SDL_Palette*
			/// <summary>
			/// The bits per pixel
			/// </summary>
			public byte BitsPerPixel;
			/// <summary>
			/// The bytes per pixel
			/// </summary>
			public byte BytesPerPixel;
			/// <summary>
			/// The rmask
			/// </summary>
			public uint Rmask;
			/// <summary>
			/// The gmask
			/// </summary>
			public uint Gmask;
			/// <summary>
			/// The bmask
			/// </summary>
			public uint Bmask;
			/// <summary>
			/// The amask
			/// </summary>
			public uint Amask;
			/// <summary>
			/// The rloss
			/// </summary>
			public byte Rloss;
			/// <summary>
			/// The gloss
			/// </summary>
			public byte Gloss;
			/// <summary>
			/// The bloss
			/// </summary>
			public byte Bloss;
			/// <summary>
			/// The aloss
			/// </summary>
			public byte Aloss;
			/// <summary>
			/// The rshift
			/// </summary>
			public byte Rshift;
			/// <summary>
			/// The gshift
			/// </summary>
			public byte Gshift;
			/// <summary>
			/// The bshift
			/// </summary>
			public byte Bshift;
			/// <summary>
			/// The ashift
			/// </summary>
			public byte Ashift;
			/// <summary>
			/// The refcount
			/// </summary>
			public int refcount;
			/// <summary>
			/// The next
			/// </summary>
			public IntPtr next; // SDL_PixelFormat*
		}

		/* IntPtr refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the alloc format using the specified pixel format
		/// </summary>
		/// <param name="pixel_format">The pixel format</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AllocFormat(uint pixel_format);

		/* IntPtr refers to an SDL_Palette* */
		/// <summary>
		/// Sdls the alloc palette using the specified ncolors
		/// </summary>
		/// <param name="ncolors">The ncolors</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AllocPalette(int ncolors);

		/// <summary>
		/// Sdls the calculate gamma ramp using the specified gamma
		/// </summary>
		/// <param name="gamma">The gamma</param>
		/// <param name="ramp">The ramp</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CalculateGammaRamp(
			float gamma,
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
				ushort[] ramp
		);

		/* format refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the free format using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeFormat(IntPtr format);

		/* palette refers to an SDL_Palette* */
		/// <summary>
		/// Sdls the free palette using the specified palette
		/// </summary>
		/// <param name="palette">The palette</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreePalette(IntPtr palette);

		/// <summary>
		/// Internals the sdl get pixel format name using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetPixelFormatName(
			uint format
		);
		/// <summary>
		/// Sdls the get pixel format name using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <returns>The string</returns>
		public static string SDL_GetPixelFormatName(uint format)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GetPixelFormatName(format)
			);
		}

		/* format refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the get rgb using the specified pixel
		/// </summary>
		/// <param name="pixel">The pixel</param>
		/// <param name="format">The format</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetRGB(
			uint pixel,
			IntPtr format,
			out byte r,
			out byte g,
			out byte b
		);

		/* format refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the get rgba using the specified pixel
		/// </summary>
		/// <param name="pixel">The pixel</param>
		/// <param name="format">The format</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetRGBA(
			uint pixel,
			IntPtr format,
			out byte r,
			out byte g,
			out byte b,
			out byte a
		);

		/* format refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the map rgb using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MapRGB(
			IntPtr format,
			byte r,
			byte g,
			byte b
		);

		/* format refers to an SDL_PixelFormat* */
		/// <summary>
		/// Sdls the map rgba using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <param name="a">The </param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MapRGBA(
			IntPtr format,
			byte r,
			byte g,
			byte b,
			byte a
		);

		/// <summary>
		/// Sdls the masks to pixel format enum using the specified bpp
		/// </summary>
		/// <param name="bpp">The bpp</param>
		/// <param name="Rmask">The rmask</param>
		/// <param name="Gmask">The gmask</param>
		/// <param name="Bmask">The bmask</param>
		/// <param name="Amask">The amask</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_MasksToPixelFormatEnum(
			int bpp,
			uint Rmask,
			uint Gmask,
			uint Bmask,
			uint Amask
		);

		/// <summary>
		/// Sdls the pixel format enum to masks using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <param name="bpp">The bpp</param>
		/// <param name="Rmask">The rmask</param>
		/// <param name="Gmask">The gmask</param>
		/// <param name="Bmask">The bmask</param>
		/// <param name="Amask">The amask</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_PixelFormatEnumToMasks(
			uint format,
			out int bpp,
			out uint Rmask,
			out uint Gmask,
			out uint Bmask,
			out uint Amask
		);

		/* palette refers to an SDL_Palette* */
		/// <summary>
		/// Sdls the set palette colors using the specified palette
		/// </summary>
		/// <param name="palette">The palette</param>
		/// <param name="colors">The colors</param>
		/// <param name="firstcolor">The firstcolor</param>
		/// <param name="ncolors">The ncolors</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetPaletteColors(
			IntPtr palette,
			[In] SDL_Color[] colors,
			int firstcolor,
			int ncolors
		);

		/* format and palette refer to an SDL_PixelFormat* and SDL_Palette* */
		/// <summary>
		/// Sdls the set pixel format palette using the specified format
		/// </summary>
		/// <param name="format">The format</param>
		/// <param name="palette">The palette</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetPixelFormatPalette(
			IntPtr format,
			IntPtr palette
		);

		#endregion

		#region SDL_rect.h

		/// <summary>
		/// The sdl point
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Point
		{
			/// <summary>
			/// The 
			/// </summary>
			public int x;
			/// <summary>
			/// The 
			/// </summary>
			public int y;
		}

		/// <summary>
		/// The sdl rect
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Rect
		{
			/// <summary>
			/// The 
			/// </summary>
			public int x;
			/// <summary>
			/// The 
			/// </summary>
			public int y;
			/// <summary>
			/// The 
			/// </summary>
			public int w;
			/// <summary>
			/// The 
			/// </summary>
			public int h;
		}

		/* Only available in 2.0.10 or higher. */
		/// <summary>
		/// The sdl fpoint
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_FPoint
		{
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
		}

		/* Only available in 2.0.10 or higher. */
		/// <summary>
		/// The sdl frect
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_FRect
		{
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
			/// <summary>
			/// The 
			/// </summary>
			public float w;
			/// <summary>
			/// The 
			/// </summary>
			public float h;
		}

		/* Only available in 2.0.4 or higher. */
		/// <summary>
		/// Sdls the point in rect using the specified p
		/// </summary>
		/// <param name="p">The </param>
		/// <param name="r">The </param>
		/// <returns>The sdl bool</returns>
		public static SDL_bool SDL_PointInRect(ref SDL_Point p, ref SDL_Rect r)
		{
			return (	(p.x >= r.x) &&
					(p.x < (r.x + r.w)) &&
					(p.y >= r.y) &&
					(p.y < (r.y + r.h))	) ?
				SDL_bool.SDL_TRUE :
				SDL_bool.SDL_FALSE;
		}

		/// <summary>
		/// Sdls the enclose points using the specified points
		/// </summary>
		/// <param name="points">The points</param>
		/// <param name="count">The count</param>
		/// <param name="clip">The clip</param>
		/// <param name="result">The result</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_EnclosePoints(
			[In] SDL_Point[] points,
			int count,
			ref SDL_Rect clip,
			out SDL_Rect result
		);

		/// <summary>
		/// Sdls the has intersection using the specified a
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasIntersection(
			ref SDL_Rect A,
			ref SDL_Rect B
		);

		/// <summary>
		/// Sdls the intersect rect using the specified a
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <param name="result">The result</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IntersectRect(
			ref SDL_Rect A,
			ref SDL_Rect B,
			out SDL_Rect result
		);

		/// <summary>
		/// Sdls the intersect rect and line using the specified rect
		/// </summary>
		/// <param name="rect">The rect</param>
		/// <param name="X1">The </param>
		/// <param name="Y1">The </param>
		/// <param name="X2">The </param>
		/// <param name="Y2">The </param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IntersectRectAndLine(
			ref SDL_Rect rect,
			ref int X1,
			ref int Y1,
			ref int X2,
			ref int Y2
		);

		/// <summary>
		/// Sdls the rect empty using the specified r
		/// </summary>
		/// <param name="r">The </param>
		/// <returns>The sdl bool</returns>
		public static SDL_bool SDL_RectEmpty(ref SDL_Rect r)
		{
			return ((r.w <= 0) || (r.h <= 0)) ?
				SDL_bool.SDL_TRUE :
				SDL_bool.SDL_FALSE;
		}

		/// <summary>
		/// Sdls the rect equals using the specified a
		/// </summary>
		/// <param name="a">The </param>
		/// <param name="b">The </param>
		/// <returns>The sdl bool</returns>
		public static SDL_bool SDL_RectEquals(
			ref SDL_Rect a,
			ref SDL_Rect b
		) {
			return (	(a.x == b.x) &&
					(a.y == b.y) &&
					(a.w == b.w) &&
					(a.h == b.h)	) ?
				SDL_bool.SDL_TRUE :
				SDL_bool.SDL_FALSE;
		}

		/// <summary>
		/// Sdls the union rect using the specified a
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <param name="result">The result</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnionRect(
			ref SDL_Rect A,
			ref SDL_Rect B,
			out SDL_Rect result
		);

		#endregion

		#region SDL_surface.h

		/// <summary>
		/// The sdl swsurface
		/// </summary>
		public const uint SDL_SWSURFACE =	0x00000000;
		/// <summary>
		/// The sdl prealloc
		/// </summary>
		public const uint SDL_PREALLOC =	0x00000001;
		/// <summary>
		/// The sdl rleaccel
		/// </summary>
		public const uint SDL_RLEACCEL =	0x00000002;
		/// <summary>
		/// The sdl dontfree
		/// </summary>
		public const uint SDL_DONTFREE =	0x00000004;

		/// <summary>
		/// The sdl surface
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Surface
		{
			/// <summary>
			/// The flags
			/// </summary>
			public uint flags;
			/// <summary>
			/// The format
			/// </summary>
			public IntPtr format; // SDL_PixelFormat*
			/// <summary>
			/// The 
			/// </summary>
			public int w;
			/// <summary>
			/// The 
			/// </summary>
			public int h;
			/// <summary>
			/// The pitch
			/// </summary>
			public int pitch;
			/// <summary>
			/// The pixels
			/// </summary>
			public IntPtr pixels; // void*
			/// <summary>
			/// The userdata
			/// </summary>
			public IntPtr userdata; // void*
			/// <summary>
			/// The locked
			/// </summary>
			public int locked;
			/// <summary>
			/// The list blitmap
			/// </summary>
			public IntPtr list_blitmap; // void*
			/// <summary>
			/// The clip rect
			/// </summary>
			public SDL_Rect clip_rect;
			/// <summary>
			/// The map
			/// </summary>
			public IntPtr map; // SDL_BlitMap*
			/// <summary>
			/// The refcount
			/// </summary>
			public int refcount;
		}

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Describes whether sdl mustlock
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The bool</returns>
		public static bool SDL_MUSTLOCK(IntPtr surface)
		{
			SDL_Surface sur;
			sur = (SDL_Surface) Marshal.PtrToStructure(
				surface,
				typeof(SDL_Surface)
			);
			return (sur.flags & SDL_RLEACCEL) != 0;
		}

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the blit surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitSurface(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the blit surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitSurface(
			IntPtr src,
			IntPtr srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the blit surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitSurface(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			IntPtr dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
		 */
		/// <summary>
		/// Sdls the blit surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitSurface(
			IntPtr src,
			IntPtr srcrect,
			IntPtr dst,
			IntPtr dstrect
		);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitScaled(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for srcrect.
		 */
		/// <summary>
		/// Sdls the blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitScaled(
			IntPtr src,
			IntPtr srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for dstrect.
		 */
		/// <summary>
		/// Sdls the blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitScaled(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			IntPtr dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Internally, this function contains logic to use default values when
		 * source and destination rectangles are passed as NULL.
		 * This overload allows for IntPtr.Zero (null) to be passed for both SDL_Rects.
		 */
		/// <summary>
		/// Sdls the blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_BlitScaled(
			IntPtr src,
			IntPtr srcrect,
			IntPtr dst,
			IntPtr dstrect
		);

		/* src and dst are void* pointers */
		/// <summary>
		/// Sdls the convert pixels using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="src_format">The src format</param>
		/// <param name="src">The src</param>
		/// <param name="src_pitch">The src pitch</param>
		/// <param name="dst_format">The dst format</param>
		/// <param name="dst">The dst</param>
		/// <param name="dst_pitch">The dst pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_ConvertPixels(
			int width,
			int height,
			uint src_format,
			IntPtr src,
			int src_pitch,
			uint dst_format,
			IntPtr dst,
			int dst_pitch
		);

		/* src and dst are void* pointers
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the premultiply alpha using the specified width
		/// </summary>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="src_format">The src format</param>
		/// <param name="src">The src</param>
		/// <param name="src_pitch">The src pitch</param>
		/// <param name="dst_format">The dst format</param>
		/// <param name="dst">The dst</param>
		/// <param name="dst_pitch">The dst pitch</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PremultiplyAlpha(
			int width,
			int height,
			uint src_format,
			IntPtr src,
			int src_pitch,
			uint dst_format,
			IntPtr dst,
			int dst_pitch
		);

		/* IntPtr refers to an SDL_Surface*
		 * src refers to an SDL_Surface*
		 * fmt refers to an SDL_PixelFormat*
		 */
		/// <summary>
		/// Sdls the convert surface using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="fmt">The fmt</param>
		/// <param name="flags">The flags</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_ConvertSurface(
			IntPtr src,
			IntPtr fmt,
			uint flags
		);

		/* IntPtr refers to an SDL_Surface*, src to an SDL_Surface* */
		/// <summary>
		/// Sdls the convert surface format using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="pixel_format">The pixel format</param>
		/// <param name="flags">The flags</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_ConvertSurfaceFormat(
			IntPtr src,
			uint pixel_format,
			uint flags
		);

		/* IntPtr refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the create rgb surface using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="depth">The depth</param>
		/// <param name="Rmask">The rmask</param>
		/// <param name="Gmask">The gmask</param>
		/// <param name="Bmask">The bmask</param>
		/// <param name="Amask">The amask</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurface(
			uint flags,
			int width,
			int height,
			int depth,
			uint Rmask,
			uint Gmask,
			uint Bmask,
			uint Amask
		);

		/* IntPtr refers to an SDL_Surface*, pixels to a void* */
		/// <summary>
		/// Sdls the create rgb surface from using the specified pixels
		/// </summary>
		/// <param name="pixels">The pixels</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="depth">The depth</param>
		/// <param name="pitch">The pitch</param>
		/// <param name="Rmask">The rmask</param>
		/// <param name="Gmask">The gmask</param>
		/// <param name="Bmask">The bmask</param>
		/// <param name="Amask">The amask</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceFrom(
			IntPtr pixels,
			int width,
			int height,
			int depth,
			int pitch,
			uint Rmask,
			uint Gmask,
			uint Bmask,
			uint Amask
		);

		/* IntPtr refers to an SDL_Surface*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the create rgb surface with format using the specified flags
		/// </summary>
		/// <param name="flags">The flags</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="depth">The depth</param>
		/// <param name="format">The format</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(
			uint flags,
			int width,
			int height,
			int depth,
			uint format
		);

		/* IntPtr refers to an SDL_Surface*, pixels to a void*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the create rgb surface with format from using the specified pixels
		/// </summary>
		/// <param name="pixels">The pixels</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		/// <param name="depth">The depth</param>
		/// <param name="pitch">The pitch</param>
		/// <param name="format">The format</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(
			IntPtr pixels,
			int width,
			int height,
			int depth,
			int pitch,
			uint format
		);

		/* dst refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the fill rect using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="rect">The rect</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRect(
			IntPtr dst,
			ref SDL_Rect rect,
			uint color
		);

		/* dst refers to an SDL_Surface*.
		 * This overload allows passing NULL to rect.
		 */
		/// <summary>
		/// Sdls the fill rect using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="rect">The rect</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRect(
			IntPtr dst,
			IntPtr rect,
			uint color
		);

		/* dst refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the fill rects using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="rects">The rects</param>
		/// <param name="count">The count</param>
		/// <param name="color">The color</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_FillRects(
			IntPtr dst,
			[In] SDL_Rect[] rects,
			int count,
			uint color
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the free surface using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeSurface(IntPtr surface);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the get clip rect using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="rect">The rect</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GetClipRect(
			IntPtr surface,
			out SDL_Rect rect
		);

		/* surface refers to an SDL_Surface*.
		 * Only available in 2.0.9 or higher.
		 */
		/// <summary>
		/// Sdls the has color key using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasColorKey(IntPtr surface);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the get color key using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="key">The key</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetColorKey(
			IntPtr surface,
			out uint key
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the get surface alpha mod using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="alpha">The alpha</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceAlphaMod(
			IntPtr surface,
			out byte alpha
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the get surface blend mode using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceBlendMode(
			IntPtr surface,
			out SDL_BlendMode blendMode
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the get surface color mod using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSurfaceColorMod(
			IntPtr surface,
			out byte r,
			out byte g,
			out byte b
		);

		/* These are for SDL_LoadBMP, which is a macro in the SDL headers. */
		/* IntPtr refers to an SDL_Surface* */
		/* THIS IS AN RWops FUNCTION! */
		/// <summary>
		/// Internals the sdl load bmp rw using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="freesrc">The freesrc</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(
			IntPtr src,
			int freesrc
		);
		/// <summary>
		/// Sdls the load bmp using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <returns>The int ptr</returns>
		public static IntPtr SDL_LoadBMP(string file)
		{
			IntPtr rwops = SDL_RWFromFile(file, "rb");
			return INTERNAL_SDL_LoadBMP_RW(rwops, 1);
		}

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the lock surface using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LockSurface(IntPtr surface);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the lower blit using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LowerBlit(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the lower blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_LowerBlitScaled(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* These are for SDL_SaveBMP, which is a macro in the SDL headers. */
		/* IntPtr refers to an SDL_Surface* */
		/* THIS IS AN RWops FUNCTION! */
		/// <summary>
		/// Internals the sdl save bmp rw using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="src">The src</param>
		/// <param name="freesrc">The freesrc</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_SDL_SaveBMP_RW(
			IntPtr surface,
			IntPtr src,
			int freesrc
		);
		/// <summary>
		/// Sdls the save bmp using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="file">The file</param>
		/// <returns>The int</returns>
		public static int SDL_SaveBMP(IntPtr surface, string file)
		{
			IntPtr rwops = SDL_RWFromFile(file, "wb");
			return INTERNAL_SDL_SaveBMP_RW(surface, rwops, 1);
		}

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set clip rect using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="rect">The rect</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_SetClipRect(
			IntPtr surface,
			ref SDL_Rect rect
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set color key using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="flag">The flag</param>
		/// <param name="key">The key</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetColorKey(
			IntPtr surface,
			int flag,
			uint key
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set surface alpha mod using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="alpha">The alpha</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceAlphaMod(
			IntPtr surface,
			byte alpha
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set surface blend mode using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="blendMode">The blend mode</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceBlendMode(
			IntPtr surface,
			SDL_BlendMode blendMode
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set surface color mod using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="r">The </param>
		/// <param name="g">The </param>
		/// <param name="b">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceColorMod(
			IntPtr surface,
			byte r,
			byte g,
			byte b
		);

		/* surface refers to an SDL_Surface*, palette to an SDL_Palette* */
		/// <summary>
		/// Sdls the set surface palette using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="palette">The palette</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfacePalette(
			IntPtr surface,
			IntPtr palette
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the set surface rle using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="flag">The flag</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetSurfaceRLE(
			IntPtr surface,
			int flag
		);

		/* surface refers to an SDL_Surface*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the has surface rle using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSurfaceRLE(
			IntPtr surface
		);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the soft stretch using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SoftStretch(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the soft stretch linear using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SoftStretchLinear(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* surface refers to an SDL_Surface* */
		/// <summary>
		/// Sdls the unlock surface using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockSurface(IntPtr surface);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the upper blit using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpperBlit(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* src and dst refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the upper blit scaled using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="srcrect">The srcrect</param>
		/// <param name="dst">The dst</param>
		/// <param name="dstrect">The dstrect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_UpperBlitScaled(
			IntPtr src,
			ref SDL_Rect srcrect,
			IntPtr dst,
			ref SDL_Rect dstrect
		);

		/* surface and IntPtr refer to an SDL_Surface* */
		/// <summary>
		/// Sdls the duplicate surface using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);

		#endregion

		#region SDL_clipboard.h

		/// <summary>
		/// Sdls the has clipboard text
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasClipboardText();

		/// <summary>
		/// Internals the sdl get clipboard text
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetClipboardText();
		/// <summary>
		/// Sdls the get clipboard text
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetClipboardText()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetClipboardText(), true);
		}

		/// <summary>
		/// Internals the sdl set clipboard text using the specified text
		/// </summary>
		/// <param name="text">The text</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_SetClipboardText(
			byte* text
		);
		/// <summary>
		/// Sdls the set clipboard text using the specified text
		/// </summary>
		/// <param name="text">The text</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_SetClipboardText(
			string text
		) {
			byte* utf8Text = Utf8EncodeHeap(text);
			int result = INTERNAL_SDL_SetClipboardText(
				utf8Text
			);
			Marshal.FreeHGlobal((IntPtr) utf8Text);
			return result;
		}

		#endregion

		#region SDL_events.h

		/* General keyboard/mouse state definitions. */
		/// <summary>
		/// The sdl pressed
		/// </summary>
		public const byte SDL_PRESSED =		1;
		/// <summary>
		/// The sdl released
		/// </summary>
		public const byte SDL_RELEASED =	0;

		/* Default size is according to SDL2 default. */
		/// <summary>
		/// The sdl texteditingevent text size
		/// </summary>
		public const int SDL_TEXTEDITINGEVENT_TEXT_SIZE = 32;
		/// <summary>
		/// The sdl textinputevent text size
		/// </summary>
		public const int SDL_TEXTINPUTEVENT_TEXT_SIZE = 32;

		/* The types of events that can be delivered. */
		/// <summary>
		/// The sdl eventtype enum
		/// </summary>
		public enum SDL_EventType : uint
		{
			/// <summary>
			/// The sdl firstevent sdl eventtype
			/// </summary>
			SDL_FIRSTEVENT =		0,

			/* Application events */
			/// <summary>
			/// The sdl quit sdl eventtype
			/// </summary>
			SDL_QUIT = 			0x100,

			/* iOS/Android/WinRT app events */
			/// <summary>
			/// The sdl app terminating sdl eventtype
			/// </summary>
			SDL_APP_TERMINATING,
			/// <summary>
			/// The sdl app lowmemory sdl eventtype
			/// </summary>
			SDL_APP_LOWMEMORY,
			/// <summary>
			/// The sdl app willenterbackground sdl eventtype
			/// </summary>
			SDL_APP_WILLENTERBACKGROUND,
			/// <summary>
			/// The sdl app didenterbackground sdl eventtype
			/// </summary>
			SDL_APP_DIDENTERBACKGROUND,
			/// <summary>
			/// The sdl app willenterforeground sdl eventtype
			/// </summary>
			SDL_APP_WILLENTERFOREGROUND,
			/// <summary>
			/// The sdl app didenterforeground sdl eventtype
			/// </summary>
			SDL_APP_DIDENTERFOREGROUND,

			/* Only available in SDL 2.0.14 or higher. */
			/// <summary>
			/// The sdl localechanged sdl eventtype
			/// </summary>
			SDL_LOCALECHANGED,

			/* Display events */
			/* Only available in SDL 2.0.9 or higher. */
			/// <summary>
			/// The sdl displayevent sdl eventtype
			/// </summary>
			SDL_DISPLAYEVENT =		0x150,

			/* Window events */
			/// <summary>
			/// The sdl windowevent sdl eventtype
			/// </summary>
			SDL_WINDOWEVENT = 		0x200,
			/// <summary>
			/// The sdl syswmevent sdl eventtype
			/// </summary>
			SDL_SYSWMEVENT,

			/* Keyboard events */
			/// <summary>
			/// The sdl keydown sdl eventtype
			/// </summary>
			SDL_KEYDOWN = 			0x300,
			/// <summary>
			/// The sdl keyup sdl eventtype
			/// </summary>
			SDL_KEYUP,
			/// <summary>
			/// The sdl textediting sdl eventtype
			/// </summary>
			SDL_TEXTEDITING,
			/// <summary>
			/// The sdl textinput sdl eventtype
			/// </summary>
			SDL_TEXTINPUT,
			/// <summary>
			/// The sdl keymapchanged sdl eventtype
			/// </summary>
			SDL_KEYMAPCHANGED,

			/* Mouse events */
			/// <summary>
			/// The sdl mousemotion sdl eventtype
			/// </summary>
			SDL_MOUSEMOTION = 		0x400,
			/// <summary>
			/// The sdl mousebuttondown sdl eventtype
			/// </summary>
			SDL_MOUSEBUTTONDOWN,
			/// <summary>
			/// The sdl mousebuttonup sdl eventtype
			/// </summary>
			SDL_MOUSEBUTTONUP,
			/// <summary>
			/// The sdl mousewheel sdl eventtype
			/// </summary>
			SDL_MOUSEWHEEL,

			/* Joystick events */
			/// <summary>
			/// The sdl joyaxismotion sdl eventtype
			/// </summary>
			SDL_JOYAXISMOTION =		0x600,
			/// <summary>
			/// The sdl joyballmotion sdl eventtype
			/// </summary>
			SDL_JOYBALLMOTION,
			/// <summary>
			/// The sdl joyhatmotion sdl eventtype
			/// </summary>
			SDL_JOYHATMOTION,
			/// <summary>
			/// The sdl joybuttondown sdl eventtype
			/// </summary>
			SDL_JOYBUTTONDOWN,
			/// <summary>
			/// The sdl joybuttonup sdl eventtype
			/// </summary>
			SDL_JOYBUTTONUP,
			/// <summary>
			/// The sdl joydeviceadded sdl eventtype
			/// </summary>
			SDL_JOYDEVICEADDED,
			/// <summary>
			/// The sdl joydeviceremoved sdl eventtype
			/// </summary>
			SDL_JOYDEVICEREMOVED,

			/* Game controller events */
			/// <summary>
			/// The sdl controlleraxismotion sdl eventtype
			/// </summary>
			SDL_CONTROLLERAXISMOTION = 	0x650,
			/// <summary>
			/// The sdl controllerbuttondown sdl eventtype
			/// </summary>
			SDL_CONTROLLERBUTTONDOWN,
			/// <summary>
			/// The sdl controllerbuttonup sdl eventtype
			/// </summary>
			SDL_CONTROLLERBUTTONUP,
			/// <summary>
			/// The sdl controllerdeviceadded sdl eventtype
			/// </summary>
			SDL_CONTROLLERDEVICEADDED,
			/// <summary>
			/// The sdl controllerdeviceremoved sdl eventtype
			/// </summary>
			SDL_CONTROLLERDEVICEREMOVED,
			/// <summary>
			/// The sdl controllerdeviceremapped sdl eventtype
			/// </summary>
			SDL_CONTROLLERDEVICEREMAPPED,
			/// <summary>
			/// The sdl controllertouchpaddown sdl eventtype
			/// </summary>
			SDL_CONTROLLERTOUCHPADDOWN,	/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl controllertouchpadmotion sdl eventtype
			/// </summary>
			SDL_CONTROLLERTOUCHPADMOTION,	/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl controllertouchpadup sdl eventtype
			/// </summary>
			SDL_CONTROLLERTOUCHPADUP,	/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl controllersensorupdate sdl eventtype
			/// </summary>
			SDL_CONTROLLERSENSORUPDATE,	/* Requires >= 2.0.14 */

			/* Touch events */
			/// <summary>
			/// The sdl fingerdown sdl eventtype
			/// </summary>
			SDL_FINGERDOWN = 		0x700,
			/// <summary>
			/// The sdl fingerup sdl eventtype
			/// </summary>
			SDL_FINGERUP,
			/// <summary>
			/// The sdl fingermotion sdl eventtype
			/// </summary>
			SDL_FINGERMOTION,

			/* Gesture events */
			/// <summary>
			/// The sdl dollargesture sdl eventtype
			/// </summary>
			SDL_DOLLARGESTURE =		0x800,
			/// <summary>
			/// The sdl dollarrecord sdl eventtype
			/// </summary>
			SDL_DOLLARRECORD,
			/// <summary>
			/// The sdl multigesture sdl eventtype
			/// </summary>
			SDL_MULTIGESTURE,

			/* Clipboard events */
			/// <summary>
			/// The sdl clipboardupdate sdl eventtype
			/// </summary>
			SDL_CLIPBOARDUPDATE =		0x900,

			/* Drag and drop events */
			/// <summary>
			/// The sdl dropfile sdl eventtype
			/// </summary>
			SDL_DROPFILE =			0x1000,
			/* Only available in 2.0.4 or higher. */
			/// <summary>
			/// The sdl droptext sdl eventtype
			/// </summary>
			SDL_DROPTEXT,
			/// <summary>
			/// The sdl dropbegin sdl eventtype
			/// </summary>
			SDL_DROPBEGIN,
			/// <summary>
			/// The sdl dropcomplete sdl eventtype
			/// </summary>
			SDL_DROPCOMPLETE,

			/* Audio hotplug events */
			/* Only available in SDL 2.0.4 or higher. */
			/// <summary>
			/// The sdl audiodeviceadded sdl eventtype
			/// </summary>
			SDL_AUDIODEVICEADDED =		0x1100,
			/// <summary>
			/// The sdl audiodeviceremoved sdl eventtype
			/// </summary>
			SDL_AUDIODEVICEREMOVED,

			/* Sensor events */
			/* Only available in SDL 2.0.9 or higher. */
			/// <summary>
			/// The sdl sensorupdate sdl eventtype
			/// </summary>
			SDL_SENSORUPDATE =		0x1200,

			/* Render events */
			/* Only available in SDL 2.0.2 or higher. */
			/// <summary>
			/// The sdl render targets reset sdl eventtype
			/// </summary>
			SDL_RENDER_TARGETS_RESET =	0x2000,
			/* Only available in SDL 2.0.4 or higher. */
			/// <summary>
			/// The sdl render device reset sdl eventtype
			/// </summary>
			SDL_RENDER_DEVICE_RESET,

			/* Internal events */
			/* Only available in 2.0.18 or higher. */
			/// <summary>
			/// The sdl pollsentinel sdl eventtype
			/// </summary>
			SDL_POLLSENTINEL =		0x7F00,

			/* Events SDL_USEREVENT through SDL_LASTEVENT are for
			 * your use, and should be allocated with
			 * SDL_RegisterEvents()
			 */
			/// <summary>
			/// The sdl userevent sdl eventtype
			/// </summary>
			SDL_USEREVENT =			0x8000,

			/* The last event, used for bouding arrays. */
			/// <summary>
			/// The sdl lastevent sdl eventtype
			/// </summary>
			SDL_LASTEVENT =			0xFFFF
		}

		/* Only available in 2.0.4 or higher. */
		/// <summary>
		/// The sdl mousewheeldirection enum
		/// </summary>
		public enum SDL_MouseWheelDirection : uint
		{
			/// <summary>
			/// The sdl mousewheel normal sdl mousewheeldirection
			/// </summary>
			SDL_MOUSEWHEEL_NORMAL,
			/// <summary>
			/// The sdl mousewheel flipped sdl mousewheeldirection
			/// </summary>
			SDL_MOUSEWHEEL_FLIPPED
		}

		/* Fields shared by every event */
		/// <summary>
		/// The sdl genericevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_GenericEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/// <summary>
		/// The sdl displayevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_DisplayEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The display
			/// </summary>
			public UInt32 display;
			/// <summary>
			/// The display event
			/// </summary>
			public SDL_DisplayEventID displayEvent; // event, lolC#
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The data
			/// </summary>
			public Int32 data1;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Window state change event data (event.window.*) */
		/// <summary>
		/// The sdl windowevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_WindowEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The window event
			/// </summary>
			public SDL_WindowEventID windowEvent; // event, lolC#
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The data
			/// </summary>
			public Int32 data1;
			/// <summary>
			/// The data
			/// </summary>
			public Int32 data2;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Keyboard button event structure (event.key.*) */
		/// <summary>
		/// The sdl keyboardevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_KeyboardEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The state
			/// </summary>
			public byte state;
			/// <summary>
			/// The repeat
			/// </summary>
			public byte repeat; /* non-zero if this is a repeat */
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The keysym
			/// </summary>
			public SDL_Keysym keysym;
		}
#pragma warning restore 0169

		/// <summary>
		/// The sdl texteditingevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_TextEditingEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The sdl texteditingevent text size
			/// </summary>
			public fixed byte text[SDL_TEXTEDITINGEVENT_TEXT_SIZE];
			/// <summary>
			/// The start
			/// </summary>
			public Int32 start;
			/// <summary>
			/// The length
			/// </summary>
			public Int32 length;
		}

		/// <summary>
		/// The sdl textinputevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_TextInputEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The sdl textinputevent text size
			/// </summary>
			public fixed byte text[SDL_TEXTINPUTEVENT_TEXT_SIZE];
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse motion event structure (event.motion.*) */
		/// <summary>
		/// The sdl mousemotionevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MouseMotionEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The which
			/// </summary>
			public UInt32 which;
			/// <summary>
			/// The state
			/// </summary>
			public byte state; /* bitmask of buttons */
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The 
			/// </summary>
			public Int32 x;
			/// <summary>
			/// The 
			/// </summary>
			public Int32 y;
			/// <summary>
			/// The xrel
			/// </summary>
			public Int32 xrel;
			/// <summary>
			/// The yrel
			/// </summary>
			public Int32 yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Mouse button event structure (event.button.*) */
		/// <summary>
		/// The sdl mousebuttonevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MouseButtonEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The which
			/// </summary>
			public UInt32 which;
			/// <summary>
			/// The button
			/// </summary>
			public byte button; /* button id */
			/// <summary>
			/// The state
			/// </summary>
			public byte state; /* SDL_PRESSED or SDL_RELEASED */
			/// <summary>
			/// The clicks
			/// </summary>
			public byte clicks; /* 1 for single-click, 2 for double-click, etc. */
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The 
			/// </summary>
			public Int32 x;
			/// <summary>
			/// The 
			/// </summary>
			public Int32 y;
		}
#pragma warning restore 0169

		/* Mouse wheel event structure (event.wheel.*) */
		/// <summary>
		/// The sdl mousewheelevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MouseWheelEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The which
			/// </summary>
			public UInt32 which;
			/// <summary>
			/// The 
			/// </summary>
			public Int32 x; /* amount scrolled horizontally */
			/// <summary>
			/// The 
			/// </summary>
			public Int32 y; /* amount scrolled vertically */
			/// <summary>
			/// The direction
			/// </summary>
			public UInt32 direction; /* Set to one of the SDL_MOUSEWHEEL_* defines */
			/// <summary>
			/// The precise
			/// </summary>
			public float preciseX; /* Requires >= 2.0.18 */
			/// <summary>
			/// The precise
			/// </summary>
			public float preciseY; /* Requires >= 2.0.18 */
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick axis motion event structure (event.jaxis.*) */
		/// <summary>
		/// The sdl joyaxisevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_JoyAxisEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The axis
			/// </summary>
			public byte axis;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The axis value
			/// </summary>
			public Int16 axisValue; /* value, lolC# */
			/// <summary>
			/// The padding
			/// </summary>
			public UInt16 padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick trackball motion event structure (event.jball.*) */
		/// <summary>
		/// The sdl joyballevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_JoyBallEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The ball
			/// </summary>
			public byte ball;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The xrel
			/// </summary>
			public Int16 xrel;
			/// <summary>
			/// The yrel
			/// </summary>
			public Int16 yrel;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick hat position change event struct (event.jhat.*) */
		/// <summary>
		/// The sdl joyhatevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_JoyHatEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The hat
			/// </summary>
			public byte hat; /* index of the hat */
			/// <summary>
			/// The hat value
			/// </summary>
			public byte hatValue; /* value, lolC# */
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Joystick button event structure (event.jbutton.*) */
		/// <summary>
		/// The sdl joybuttonevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_JoyButtonEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The button
			/// </summary>
			public byte button;
			/// <summary>
			/// The state
			/// </summary>
			public byte state; /* SDL_PRESSED or SDL_RELEASED */
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
		}
#pragma warning restore 0169

		/* Joystick device event structure (event.jdevice.*) */
		/// <summary>
		/// The sdl joydeviceevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_JoyDeviceEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller axis motion event (event.caxis.*) */
		/// <summary>
		/// The sdl controlleraxisevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_ControllerAxisEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The axis
			/// </summary>
			public byte axis;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
			/// <summary>
			/// The axis value
			/// </summary>
			public Int16 axisValue; /* value, lolC# */
			/// <summary>
			/// The padding
			/// </summary>
			private UInt16 padding4;
		}
#pragma warning restore 0169

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Game controller button event (event.cbutton.*) */
		/// <summary>
		/// The sdl controllerbuttonevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_ControllerButtonEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The button
			/// </summary>
			public byte button;
			/// <summary>
			/// The state
			/// </summary>
			public byte state;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
		}
#pragma warning restore 0169

		/* Game controller device event (event.cdevice.*) */
		/// <summary>
		/// The sdl controllerdeviceevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_ControllerDeviceEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which;	/* joystick id for ADDED,
						 * else instance id
						 */
		}

		/* Game controller touchpad event structure (event.ctouchpad.*) */
		/// <summary>
		/// The sdl controllertouchpadevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_ControllerTouchpadEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The touchpad
			/// </summary>
			public Int32 touchpad;
			/// <summary>
			/// The finger
			/// </summary>
			public Int32 finger;
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
			/// <summary>
			/// The pressure
			/// </summary>
			public float pressure;
		}

		/* Game controller sensor event structure (event.csensor.*) */
		/// <summary>
		/// The sdl controllersensorevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_ControllerSensorEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which; /* SDL_JoystickID */
			/// <summary>
			/// The sensor
			/// </summary>
			public Int32 sensor;
			/// <summary>
			/// The data
			/// </summary>
			public float data1;
			/// <summary>
			/// The data
			/// </summary>
			public float data2;
			/// <summary>
			/// The data
			/// </summary>
			public float data3;
		}

// Ignore private members used for padding in this struct
#pragma warning disable 0169
		/* Audio device event (event.adevice.*) */
		/// <summary>
		/// The sdl audiodeviceevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_AudioDeviceEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public UInt32 which;
			/// <summary>
			/// The iscapture
			/// </summary>
			public byte iscapture;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding1;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding2;
			/// <summary>
			/// The padding
			/// </summary>
			private byte padding3;
		}
#pragma warning restore 0169

		/// <summary>
		/// The sdl touchfingerevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_TouchFingerEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The touch id
			/// </summary>
			public Int64 touchId; // SDL_TouchID
			/// <summary>
			/// The finger id
			/// </summary>
			public Int64 fingerId; // SDL_GestureID
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
			/// <summary>
			/// The dx
			/// </summary>
			public float dx;
			/// <summary>
			/// The dy
			/// </summary>
			public float dy;
			/// <summary>
			/// The pressure
			/// </summary>
			public float pressure;
			/// <summary>
			/// The window id
			/// </summary>
			public uint windowID;
		}

		/// <summary>
		/// The sdl multigestureevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_MultiGestureEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The touch id
			/// </summary>
			public Int64 touchId; // SDL_TouchID
			/// <summary>
			/// The theta
			/// </summary>
			public float dTheta;
			/// <summary>
			/// The dist
			/// </summary>
			public float dDist;
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
			/// <summary>
			/// The num fingers
			/// </summary>
			public UInt16 numFingers;
			/// <summary>
			/// The padding
			/// </summary>
			public UInt16 padding;
		}

		/// <summary>
		/// The sdl dollargestureevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_DollarGestureEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The touch id
			/// </summary>
			public Int64 touchId; // SDL_TouchID
			/// <summary>
			/// The gesture id
			/// </summary>
			public Int64 gestureId; // SDL_GestureID
			/// <summary>
			/// The num fingers
			/// </summary>
			public UInt32 numFingers;
			/// <summary>
			/// The error
			/// </summary>
			public float error;
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
		}

		/* File open request by system (event.drop.*), enabled by
		 * default
		 */
		/// <summary>
		/// The sdl dropevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_DropEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;

			/* char* filename, to be freed.
			 * Access the variable EXACTLY ONCE like this:
			 * string s = SDL.UTF8_ToManaged(evt.drop.file, true);
			 */
			/// <summary>
			/// The file
			/// </summary>
			public IntPtr file;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
		}

		/// <summary>
		/// The sdl sensorevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_SensorEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The which
			/// </summary>
			public Int32 which;
			/// <summary>
			/// The data
			/// </summary>
			public fixed float data[6];
		}

		/* The "quit requested" event */
		/// <summary>
		/// The sdl quitevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_QuitEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
		}

		/* A user defined event (event.user.*) */
		/// <summary>
		/// The sdl userevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_UserEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public UInt32 type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The window id
			/// </summary>
			public UInt32 windowID;
			/// <summary>
			/// The code
			/// </summary>
			public Int32 code;
			/// <summary>
			/// The data
			/// </summary>
			public IntPtr data1; /* user-defined */
			/// <summary>
			/// The data
			/// </summary>
			public IntPtr data2; /* user-defined */
		}

		/* A video driver dependent event (event.syswm.*), disabled */
		/// <summary>
		/// The sdl syswmevent
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_SysWMEvent
		{
			/// <summary>
			/// The type
			/// </summary>
			public SDL_EventType type;
			/// <summary>
			/// The timestamp
			/// </summary>
			public UInt32 timestamp;
			/// <summary>
			/// The msg
			/// </summary>
			public IntPtr msg; /* SDL_SysWMmsg*, system-dependent*/
		}

		/* General event structure */
		// C# doesn't do unions, so we do this ugly thing. */
		/// <summary>
		/// The sdl event
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public unsafe struct SDL_Event
		{
			/// <summary>
			/// The type
			/// </summary>
			[FieldOffset(0)]
			public SDL_EventType type;
			/// <summary>
			/// The type sharp
			/// </summary>
			[FieldOffset(0)]
			public SDL_EventType typeFSharp;
			/// <summary>
			/// The display
			/// </summary>
			[FieldOffset(0)]
			public SDL_DisplayEvent display;
			/// <summary>
			/// The window
			/// </summary>
			[FieldOffset(0)]
			public SDL_WindowEvent window;
			/// <summary>
			/// The key
			/// </summary>
			[FieldOffset(0)]
			public SDL_KeyboardEvent key;
			/// <summary>
			/// The edit
			/// </summary>
			[FieldOffset(0)]
			public SDL_TextEditingEvent edit;
			/// <summary>
			/// The text
			/// </summary>
			[FieldOffset(0)]
			public SDL_TextInputEvent text;
			/// <summary>
			/// The motion
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseMotionEvent motion;
			/// <summary>
			/// The button
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseButtonEvent button;
			/// <summary>
			/// The wheel
			/// </summary>
			[FieldOffset(0)]
			public SDL_MouseWheelEvent wheel;
			/// <summary>
			/// The jaxis
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyAxisEvent jaxis;
			/// <summary>
			/// The jball
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyBallEvent jball;
			/// <summary>
			/// The jhat
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyHatEvent jhat;
			/// <summary>
			/// The jbutton
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyButtonEvent jbutton;
			/// <summary>
			/// The jdevice
			/// </summary>
			[FieldOffset(0)]
			public SDL_JoyDeviceEvent jdevice;
			/// <summary>
			/// The caxis
			/// </summary>
			[FieldOffset(0)]
			public SDL_ControllerAxisEvent caxis;
			/// <summary>
			/// The cbutton
			/// </summary>
			[FieldOffset(0)]
			public SDL_ControllerButtonEvent cbutton;
			/// <summary>
			/// The cdevice
			/// </summary>
			[FieldOffset(0)]
			public SDL_ControllerDeviceEvent cdevice;
			/// <summary>
			/// The ctouchpad
			/// </summary>
			[FieldOffset(0)]
			public SDL_ControllerTouchpadEvent ctouchpad;
			/// <summary>
			/// The csensor
			/// </summary>
			[FieldOffset(0)]
			public SDL_ControllerSensorEvent csensor;
			/// <summary>
			/// The adevice
			/// </summary>
			[FieldOffset(0)]
			public SDL_AudioDeviceEvent adevice;
			/// <summary>
			/// The sensor
			/// </summary>
			[FieldOffset(0)]
			public SDL_SensorEvent sensor;
			/// <summary>
			/// The quit
			/// </summary>
			[FieldOffset(0)]
			public SDL_QuitEvent quit;
			/// <summary>
			/// The user
			/// </summary>
			[FieldOffset(0)]
			public SDL_UserEvent user;
			/// <summary>
			/// The syswm
			/// </summary>
			[FieldOffset(0)]
			public SDL_SysWMEvent syswm;
			/// <summary>
			/// The tfinger
			/// </summary>
			[FieldOffset(0)]
			public SDL_TouchFingerEvent tfinger;
			/// <summary>
			/// The mgesture
			/// </summary>
			[FieldOffset(0)]
			public SDL_MultiGestureEvent mgesture;
			/// <summary>
			/// The dgesture
			/// </summary>
			[FieldOffset(0)]
			public SDL_DollarGestureEvent dgesture;
			/// <summary>
			/// The drop
			/// </summary>
			[FieldOffset(0)]
			public SDL_DropEvent drop;
			/// <summary>
			/// The padding
			/// </summary>
			[FieldOffset(0)]
			private fixed byte padding[56];
		}

		/// <summary>
		/// The sdl eventfilter
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int SDL_EventFilter(
			IntPtr userdata, // void*
			IntPtr sdlevent // SDL_Event* event, lolC#
		);

		/* Pump the event loop, getting events from the input devices*/
		/// <summary>
		/// Sdls the pump events
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PumpEvents();

		/// <summary>
		/// The sdl eventaction enum
		/// </summary>
		public enum SDL_eventaction
		{
			/// <summary>
			/// The sdl addevent sdl eventaction
			/// </summary>
			SDL_ADDEVENT,
			/// <summary>
			/// The sdl peekevent sdl eventaction
			/// </summary>
			SDL_PEEKEVENT,
			/// <summary>
			/// The sdl getevent sdl eventaction
			/// </summary>
			SDL_GETEVENT
		}

		/// <summary>
		/// Sdls the peep events using the specified events
		/// </summary>
		/// <param name="events">The events</param>
		/// <param name="numevents">The numevents</param>
		/// <param name="action">The action</param>
		/// <param name="minType">The min type</param>
		/// <param name="maxType">The max type</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PeepEvents(
			[Out] SDL_Event[] events,
			int numevents,
			SDL_eventaction action,
			SDL_EventType minType,
			SDL_EventType maxType
		);

		/* Checks to see if certain events are in the event queue */
		/// <summary>
		/// Sdls the has event using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasEvent(SDL_EventType type);

		/// <summary>
		/// Sdls the has events using the specified min type
		/// </summary>
		/// <param name="minType">The min type</param>
		/// <param name="maxType">The max type</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasEvents(
			SDL_EventType minType,
			SDL_EventType maxType
		);

		/* Clears events from the event queue */
		/// <summary>
		/// Sdls the flush event using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FlushEvent(SDL_EventType type);

		/// <summary>
		/// Sdls the flush events using the specified min
		/// </summary>
		/// <param name="min">The min</param>
		/// <param name="max">The max</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FlushEvents(
			SDL_EventType min,
			SDL_EventType max
		);

		/* Polls for currently pending events */
		/// <summary>
		/// Sdls the poll event using the specified  event
		/// </summary>
		/// <param name="_event">The event</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PollEvent(out SDL_Event _event);

		/* Waits indefinitely for the next event */
		/// <summary>
		/// Sdls the wait event using the specified  event
		/// </summary>
		/// <param name="_event">The event</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WaitEvent(out SDL_Event _event);

		/* Waits until the specified timeout (in ms) for the next event
		 */
		/// <summary>
		/// Sdls the wait event timeout using the specified  event
		/// </summary>
		/// <param name="_event">The event</param>
		/// <param name="timeout">The timeout</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WaitEventTimeout(out SDL_Event _event, int timeout);

		/* Add an event to the event queue */
		/// <summary>
		/// Sdls the push event using the specified  event
		/// </summary>
		/// <param name="_event">The event</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_PushEvent(ref SDL_Event _event);

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the set event filter using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetEventFilter(
			SDL_EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the get event filter using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		private static extern SDL_bool SDL_GetEventFilter(
			out IntPtr filter,
			out IntPtr userdata
		);
		/// <summary>
		/// Sdls the get event filter using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		/// <returns>The retval</returns>
		public static SDL_bool SDL_GetEventFilter(
			out SDL_EventFilter filter,
			out IntPtr userdata
		) {
			IntPtr result = IntPtr.Zero;
			SDL_bool retval = SDL_GetEventFilter(out result, out userdata);
			if (result != IntPtr.Zero)
			{
				filter = (SDL_EventFilter) Marshal.GetDelegateForFunctionPointer(
					result,
					typeof(SDL_EventFilter)
				);
			}
			else
			{
				filter = null;
			}
			return retval;
		}

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the add event watch using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AddEventWatch(
			SDL_EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the del event watch using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_DelEventWatch(
			SDL_EventFilter filter,
			IntPtr userdata
		);

		/* userdata refers to a void* */
		/// <summary>
		/// Sdls the filter events using the specified filter
		/// </summary>
		/// <param name="filter">The filter</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FilterEvents(
			SDL_EventFilter filter,
			IntPtr userdata
		);

		/* These are for SDL_EventState() */
		/// <summary>
		/// The sdl query
		/// </summary>
		public const int SDL_QUERY = 		-1;
		/// <summary>
		/// The sdl ignore
		/// </summary>
		public const int SDL_IGNORE = 		0;
		/// <summary>
		/// The sdl disable
		/// </summary>
		public const int SDL_DISABLE =		0;
		/// <summary>
		/// The sdl enable
		/// </summary>
		public const int SDL_ENABLE = 		1;

		/* This function allows you to enable/disable certain events */
		/// <summary>
		/// Sdls the event state using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <param name="state">The state</param>
		/// <returns>The byte</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_EventState(SDL_EventType type, int state);

		/* Get the state of an event */
		/// <summary>
		/// Sdls the get event state using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <returns>The byte</returns>
		public static byte SDL_GetEventState(SDL_EventType type)
		{
			return SDL_EventState(type, SDL_QUERY);
		}

		/* Allocate a set of user-defined events */
		/// <summary>
		/// Sdls the register events using the specified numevents
		/// </summary>
		/// <param name="numevents">The numevents</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_RegisterEvents(int numevents);
		#endregion

		#region SDL_scancode.h

		/* Scancodes based off USB keyboard page (0x07) */
		/// <summary>
		/// The sdl scancode enum
		/// </summary>
		public enum SDL_Scancode
		{
			/// <summary>
			/// The sdl scancode unknown sdl scancode
			/// </summary>
			SDL_SCANCODE_UNKNOWN = 0,

			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_A = 4,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_B = 5,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_C = 6,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_D = 7,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_E = 8,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_F = 9,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_G = 10,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_H = 11,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_I = 12,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_J = 13,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_K = 14,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_L = 15,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_M = 16,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_N = 17,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_O = 18,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_P = 19,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_Q = 20,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_R = 21,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_S = 22,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_T = 23,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_U = 24,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_V = 25,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_W = 26,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_X = 27,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_Y = 28,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_Z = 29,

			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_1 = 30,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_2 = 31,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_3 = 32,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_4 = 33,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_5 = 34,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_6 = 35,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_7 = 36,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_8 = 37,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_9 = 38,
			/// <summary>
			/// The sdl scancode sdl scancode
			/// </summary>
			SDL_SCANCODE_0 = 39,

			/// <summary>
			/// The sdl scancode return sdl scancode
			/// </summary>
			SDL_SCANCODE_RETURN = 40,
			/// <summary>
			/// The sdl scancode escape sdl scancode
			/// </summary>
			SDL_SCANCODE_ESCAPE = 41,
			/// <summary>
			/// The sdl scancode backspace sdl scancode
			/// </summary>
			SDL_SCANCODE_BACKSPACE = 42,
			/// <summary>
			/// The sdl scancode tab sdl scancode
			/// </summary>
			SDL_SCANCODE_TAB = 43,
			/// <summary>
			/// The sdl scancode space sdl scancode
			/// </summary>
			SDL_SCANCODE_SPACE = 44,

			/// <summary>
			/// The sdl scancode minus sdl scancode
			/// </summary>
			SDL_SCANCODE_MINUS = 45,
			/// <summary>
			/// The sdl scancode equals sdl scancode
			/// </summary>
			SDL_SCANCODE_EQUALS = 46,
			/// <summary>
			/// The sdl scancode leftbracket sdl scancode
			/// </summary>
			SDL_SCANCODE_LEFTBRACKET = 47,
			/// <summary>
			/// The sdl scancode rightbracket sdl scancode
			/// </summary>
			SDL_SCANCODE_RIGHTBRACKET = 48,
			/// <summary>
			/// The sdl scancode backslash sdl scancode
			/// </summary>
			SDL_SCANCODE_BACKSLASH = 49,
			/// <summary>
			/// The sdl scancode nonushash sdl scancode
			/// </summary>
			SDL_SCANCODE_NONUSHASH = 50,
			/// <summary>
			/// The sdl scancode semicolon sdl scancode
			/// </summary>
			SDL_SCANCODE_SEMICOLON = 51,
			/// <summary>
			/// The sdl scancode apostrophe sdl scancode
			/// </summary>
			SDL_SCANCODE_APOSTROPHE = 52,
			/// <summary>
			/// The sdl scancode grave sdl scancode
			/// </summary>
			SDL_SCANCODE_GRAVE = 53,
			/// <summary>
			/// The sdl scancode comma sdl scancode
			/// </summary>
			SDL_SCANCODE_COMMA = 54,
			/// <summary>
			/// The sdl scancode period sdl scancode
			/// </summary>
			SDL_SCANCODE_PERIOD = 55,
			/// <summary>
			/// The sdl scancode slash sdl scancode
			/// </summary>
			SDL_SCANCODE_SLASH = 56,

			/// <summary>
			/// The sdl scancode capslock sdl scancode
			/// </summary>
			SDL_SCANCODE_CAPSLOCK = 57,

			/// <summary>
			/// The sdl scancode f1 sdl scancode
			/// </summary>
			SDL_SCANCODE_F1 = 58,
			/// <summary>
			/// The sdl scancode f2 sdl scancode
			/// </summary>
			SDL_SCANCODE_F2 = 59,
			/// <summary>
			/// The sdl scancode f3 sdl scancode
			/// </summary>
			SDL_SCANCODE_F3 = 60,
			/// <summary>
			/// The sdl scancode f4 sdl scancode
			/// </summary>
			SDL_SCANCODE_F4 = 61,
			/// <summary>
			/// The sdl scancode f5 sdl scancode
			/// </summary>
			SDL_SCANCODE_F5 = 62,
			/// <summary>
			/// The sdl scancode f6 sdl scancode
			/// </summary>
			SDL_SCANCODE_F6 = 63,
			/// <summary>
			/// The sdl scancode f7 sdl scancode
			/// </summary>
			SDL_SCANCODE_F7 = 64,
			/// <summary>
			/// The sdl scancode f8 sdl scancode
			/// </summary>
			SDL_SCANCODE_F8 = 65,
			/// <summary>
			/// The sdl scancode f9 sdl scancode
			/// </summary>
			SDL_SCANCODE_F9 = 66,
			/// <summary>
			/// The sdl scancode f10 sdl scancode
			/// </summary>
			SDL_SCANCODE_F10 = 67,
			/// <summary>
			/// The sdl scancode f11 sdl scancode
			/// </summary>
			SDL_SCANCODE_F11 = 68,
			/// <summary>
			/// The sdl scancode f12 sdl scancode
			/// </summary>
			SDL_SCANCODE_F12 = 69,

			/// <summary>
			/// The sdl scancode printscreen sdl scancode
			/// </summary>
			SDL_SCANCODE_PRINTSCREEN = 70,
			/// <summary>
			/// The sdl scancode scrolllock sdl scancode
			/// </summary>
			SDL_SCANCODE_SCROLLLOCK = 71,
			/// <summary>
			/// The sdl scancode pause sdl scancode
			/// </summary>
			SDL_SCANCODE_PAUSE = 72,
			/// <summary>
			/// The sdl scancode insert sdl scancode
			/// </summary>
			SDL_SCANCODE_INSERT = 73,
			/// <summary>
			/// The sdl scancode home sdl scancode
			/// </summary>
			SDL_SCANCODE_HOME = 74,
			/// <summary>
			/// The sdl scancode pageup sdl scancode
			/// </summary>
			SDL_SCANCODE_PAGEUP = 75,
			/// <summary>
			/// The sdl scancode delete sdl scancode
			/// </summary>
			SDL_SCANCODE_DELETE = 76,
			/// <summary>
			/// The sdl scancode end sdl scancode
			/// </summary>
			SDL_SCANCODE_END = 77,
			/// <summary>
			/// The sdl scancode pagedown sdl scancode
			/// </summary>
			SDL_SCANCODE_PAGEDOWN = 78,
			/// <summary>
			/// The sdl scancode right sdl scancode
			/// </summary>
			SDL_SCANCODE_RIGHT = 79,
			/// <summary>
			/// The sdl scancode left sdl scancode
			/// </summary>
			SDL_SCANCODE_LEFT = 80,
			/// <summary>
			/// The sdl scancode down sdl scancode
			/// </summary>
			SDL_SCANCODE_DOWN = 81,
			/// <summary>
			/// The sdl scancode up sdl scancode
			/// </summary>
			SDL_SCANCODE_UP = 82,

			/// <summary>
			/// The sdl scancode numlockclear sdl scancode
			/// </summary>
			SDL_SCANCODE_NUMLOCKCLEAR = 83,
			/// <summary>
			/// The sdl scancode kp divide sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_DIVIDE = 84,
			/// <summary>
			/// The sdl scancode kp multiply sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MULTIPLY = 85,
			/// <summary>
			/// The sdl scancode kp minus sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MINUS = 86,
			/// <summary>
			/// The sdl scancode kp plus sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_PLUS = 87,
			/// <summary>
			/// The sdl scancode kp enter sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_ENTER = 88,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_1 = 89,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_2 = 90,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_3 = 91,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_4 = 92,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_5 = 93,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_6 = 94,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_7 = 95,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_8 = 96,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_9 = 97,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_0 = 98,
			/// <summary>
			/// The sdl scancode kp period sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_PERIOD = 99,

			/// <summary>
			/// The sdl scancode nonusbackslash sdl scancode
			/// </summary>
			SDL_SCANCODE_NONUSBACKSLASH = 100,
			/// <summary>
			/// The sdl scancode application sdl scancode
			/// </summary>
			SDL_SCANCODE_APPLICATION = 101,
			/// <summary>
			/// The sdl scancode power sdl scancode
			/// </summary>
			SDL_SCANCODE_POWER = 102,
			/// <summary>
			/// The sdl scancode kp equals sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_EQUALS = 103,
			/// <summary>
			/// The sdl scancode f13 sdl scancode
			/// </summary>
			SDL_SCANCODE_F13 = 104,
			/// <summary>
			/// The sdl scancode f14 sdl scancode
			/// </summary>
			SDL_SCANCODE_F14 = 105,
			/// <summary>
			/// The sdl scancode f15 sdl scancode
			/// </summary>
			SDL_SCANCODE_F15 = 106,
			/// <summary>
			/// The sdl scancode f16 sdl scancode
			/// </summary>
			SDL_SCANCODE_F16 = 107,
			/// <summary>
			/// The sdl scancode f17 sdl scancode
			/// </summary>
			SDL_SCANCODE_F17 = 108,
			/// <summary>
			/// The sdl scancode f18 sdl scancode
			/// </summary>
			SDL_SCANCODE_F18 = 109,
			/// <summary>
			/// The sdl scancode f19 sdl scancode
			/// </summary>
			SDL_SCANCODE_F19 = 110,
			/// <summary>
			/// The sdl scancode f20 sdl scancode
			/// </summary>
			SDL_SCANCODE_F20 = 111,
			/// <summary>
			/// The sdl scancode f21 sdl scancode
			/// </summary>
			SDL_SCANCODE_F21 = 112,
			/// <summary>
			/// The sdl scancode f22 sdl scancode
			/// </summary>
			SDL_SCANCODE_F22 = 113,
			/// <summary>
			/// The sdl scancode f23 sdl scancode
			/// </summary>
			SDL_SCANCODE_F23 = 114,
			/// <summary>
			/// The sdl scancode f24 sdl scancode
			/// </summary>
			SDL_SCANCODE_F24 = 115,
			/// <summary>
			/// The sdl scancode execute sdl scancode
			/// </summary>
			SDL_SCANCODE_EXECUTE = 116,
			/// <summary>
			/// The sdl scancode help sdl scancode
			/// </summary>
			SDL_SCANCODE_HELP = 117,
			/// <summary>
			/// The sdl scancode menu sdl scancode
			/// </summary>
			SDL_SCANCODE_MENU = 118,
			/// <summary>
			/// The sdl scancode select sdl scancode
			/// </summary>
			SDL_SCANCODE_SELECT = 119,
			/// <summary>
			/// The sdl scancode stop sdl scancode
			/// </summary>
			SDL_SCANCODE_STOP = 120,
			/// <summary>
			/// The sdl scancode again sdl scancode
			/// </summary>
			SDL_SCANCODE_AGAIN = 121,
			/// <summary>
			/// The sdl scancode undo sdl scancode
			/// </summary>
			SDL_SCANCODE_UNDO = 122,
			/// <summary>
			/// The sdl scancode cut sdl scancode
			/// </summary>
			SDL_SCANCODE_CUT = 123,
			/// <summary>
			/// The sdl scancode copy sdl scancode
			/// </summary>
			SDL_SCANCODE_COPY = 124,
			/// <summary>
			/// The sdl scancode paste sdl scancode
			/// </summary>
			SDL_SCANCODE_PASTE = 125,
			/// <summary>
			/// The sdl scancode find sdl scancode
			/// </summary>
			SDL_SCANCODE_FIND = 126,
			/// <summary>
			/// The sdl scancode mute sdl scancode
			/// </summary>
			SDL_SCANCODE_MUTE = 127,
			/// <summary>
			/// The sdl scancode volumeup sdl scancode
			/// </summary>
			SDL_SCANCODE_VOLUMEUP = 128,
			/// <summary>
			/// The sdl scancode volumedown sdl scancode
			/// </summary>
			SDL_SCANCODE_VOLUMEDOWN = 129,
			/* not sure whether there's a reason to enable these */
			/*	SDL_SCANCODE_LOCKINGCAPSLOCK = 130, */
			/*	SDL_SCANCODE_LOCKINGNUMLOCK = 131, */
			/*	SDL_SCANCODE_LOCKINGSCROLLLOCK = 132, */
			/// <summary>
			/// The sdl scancode kp comma sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_COMMA = 133,
			/// <summary>
			/// The sdl scancode kp equalsas400 sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_EQUALSAS400 = 134,

			/// <summary>
			/// The sdl scancode international1 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL1 = 135,
			/// <summary>
			/// The sdl scancode international2 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL2 = 136,
			/// <summary>
			/// The sdl scancode international3 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL3 = 137,
			/// <summary>
			/// The sdl scancode international4 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL4 = 138,
			/// <summary>
			/// The sdl scancode international5 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL5 = 139,
			/// <summary>
			/// The sdl scancode international6 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL6 = 140,
			/// <summary>
			/// The sdl scancode international7 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL7 = 141,
			/// <summary>
			/// The sdl scancode international8 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL8 = 142,
			/// <summary>
			/// The sdl scancode international9 sdl scancode
			/// </summary>
			SDL_SCANCODE_INTERNATIONAL9 = 143,
			/// <summary>
			/// The sdl scancode lang1 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG1 = 144,
			/// <summary>
			/// The sdl scancode lang2 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG2 = 145,
			/// <summary>
			/// The sdl scancode lang3 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG3 = 146,
			/// <summary>
			/// The sdl scancode lang4 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG4 = 147,
			/// <summary>
			/// The sdl scancode lang5 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG5 = 148,
			/// <summary>
			/// The sdl scancode lang6 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG6 = 149,
			/// <summary>
			/// The sdl scancode lang7 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG7 = 150,
			/// <summary>
			/// The sdl scancode lang8 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG8 = 151,
			/// <summary>
			/// The sdl scancode lang9 sdl scancode
			/// </summary>
			SDL_SCANCODE_LANG9 = 152,

			/// <summary>
			/// The sdl scancode alterase sdl scancode
			/// </summary>
			SDL_SCANCODE_ALTERASE = 153,
			/// <summary>
			/// The sdl scancode sysreq sdl scancode
			/// </summary>
			SDL_SCANCODE_SYSREQ = 154,
			/// <summary>
			/// The sdl scancode cancel sdl scancode
			/// </summary>
			SDL_SCANCODE_CANCEL = 155,
			/// <summary>
			/// The sdl scancode clear sdl scancode
			/// </summary>
			SDL_SCANCODE_CLEAR = 156,
			/// <summary>
			/// The sdl scancode prior sdl scancode
			/// </summary>
			SDL_SCANCODE_PRIOR = 157,
			/// <summary>
			/// The sdl scancode return2 sdl scancode
			/// </summary>
			SDL_SCANCODE_RETURN2 = 158,
			/// <summary>
			/// The sdl scancode separator sdl scancode
			/// </summary>
			SDL_SCANCODE_SEPARATOR = 159,
			/// <summary>
			/// The sdl scancode out sdl scancode
			/// </summary>
			SDL_SCANCODE_OUT = 160,
			/// <summary>
			/// The sdl scancode oper sdl scancode
			/// </summary>
			SDL_SCANCODE_OPER = 161,
			/// <summary>
			/// The sdl scancode clearagain sdl scancode
			/// </summary>
			SDL_SCANCODE_CLEARAGAIN = 162,
			/// <summary>
			/// The sdl scancode crsel sdl scancode
			/// </summary>
			SDL_SCANCODE_CRSEL = 163,
			/// <summary>
			/// The sdl scancode exsel sdl scancode
			/// </summary>
			SDL_SCANCODE_EXSEL = 164,

			/// <summary>
			/// The sdl scancode kp 00 sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_00 = 176,
			/// <summary>
			/// The sdl scancode kp 000 sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_000 = 177,
			/// <summary>
			/// The sdl scancode thousandsseparator sdl scancode
			/// </summary>
			SDL_SCANCODE_THOUSANDSSEPARATOR = 178,
			/// <summary>
			/// The sdl scancode decimalseparator sdl scancode
			/// </summary>
			SDL_SCANCODE_DECIMALSEPARATOR = 179,
			/// <summary>
			/// The sdl scancode currencyunit sdl scancode
			/// </summary>
			SDL_SCANCODE_CURRENCYUNIT = 180,
			/// <summary>
			/// The sdl scancode currencysubunit sdl scancode
			/// </summary>
			SDL_SCANCODE_CURRENCYSUBUNIT = 181,
			/// <summary>
			/// The sdl scancode kp leftparen sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_LEFTPAREN = 182,
			/// <summary>
			/// The sdl scancode kp rightparen sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_RIGHTPAREN = 183,
			/// <summary>
			/// The sdl scancode kp leftbrace sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_LEFTBRACE = 184,
			/// <summary>
			/// The sdl scancode kp rightbrace sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_RIGHTBRACE = 185,
			/// <summary>
			/// The sdl scancode kp tab sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_TAB = 186,
			/// <summary>
			/// The sdl scancode kp backspace sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_BACKSPACE = 187,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_A = 188,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_B = 189,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_C = 190,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_D = 191,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_E = 192,
			/// <summary>
			/// The sdl scancode kp sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_F = 193,
			/// <summary>
			/// The sdl scancode kp xor sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_XOR = 194,
			/// <summary>
			/// The sdl scancode kp power sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_POWER = 195,
			/// <summary>
			/// The sdl scancode kp percent sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_PERCENT = 196,
			/// <summary>
			/// The sdl scancode kp less sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_LESS = 197,
			/// <summary>
			/// The sdl scancode kp greater sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_GREATER = 198,
			/// <summary>
			/// The sdl scancode kp ampersand sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_AMPERSAND = 199,
			/// <summary>
			/// The sdl scancode kp dblampersand sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_DBLAMPERSAND = 200,
			/// <summary>
			/// The sdl scancode kp verticalbar sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_VERTICALBAR = 201,
			/// <summary>
			/// The sdl scancode kp dblverticalbar sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_DBLVERTICALBAR = 202,
			/// <summary>
			/// The sdl scancode kp colon sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_COLON = 203,
			/// <summary>
			/// The sdl scancode kp hash sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_HASH = 204,
			/// <summary>
			/// The sdl scancode kp space sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_SPACE = 205,
			/// <summary>
			/// The sdl scancode kp at sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_AT = 206,
			/// <summary>
			/// The sdl scancode kp exclam sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_EXCLAM = 207,
			/// <summary>
			/// The sdl scancode kp memstore sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMSTORE = 208,
			/// <summary>
			/// The sdl scancode kp memrecall sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMRECALL = 209,
			/// <summary>
			/// The sdl scancode kp memclear sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMCLEAR = 210,
			/// <summary>
			/// The sdl scancode kp memadd sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMADD = 211,
			/// <summary>
			/// The sdl scancode kp memsubtract sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMSUBTRACT = 212,
			/// <summary>
			/// The sdl scancode kp memmultiply sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMMULTIPLY = 213,
			/// <summary>
			/// The sdl scancode kp memdivide sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_MEMDIVIDE = 214,
			/// <summary>
			/// The sdl scancode kp plusminus sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_PLUSMINUS = 215,
			/// <summary>
			/// The sdl scancode kp clear sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_CLEAR = 216,
			/// <summary>
			/// The sdl scancode kp clearentry sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_CLEARENTRY = 217,
			/// <summary>
			/// The sdl scancode kp binary sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_BINARY = 218,
			/// <summary>
			/// The sdl scancode kp octal sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_OCTAL = 219,
			/// <summary>
			/// The sdl scancode kp decimal sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_DECIMAL = 220,
			/// <summary>
			/// The sdl scancode kp hexadecimal sdl scancode
			/// </summary>
			SDL_SCANCODE_KP_HEXADECIMAL = 221,

			/// <summary>
			/// The sdl scancode lctrl sdl scancode
			/// </summary>
			SDL_SCANCODE_LCTRL = 224,
			/// <summary>
			/// The sdl scancode lshift sdl scancode
			/// </summary>
			SDL_SCANCODE_LSHIFT = 225,
			/// <summary>
			/// The sdl scancode lalt sdl scancode
			/// </summary>
			SDL_SCANCODE_LALT = 226,
			/// <summary>
			/// The sdl scancode lgui sdl scancode
			/// </summary>
			SDL_SCANCODE_LGUI = 227,
			/// <summary>
			/// The sdl scancode rctrl sdl scancode
			/// </summary>
			SDL_SCANCODE_RCTRL = 228,
			/// <summary>
			/// The sdl scancode rshift sdl scancode
			/// </summary>
			SDL_SCANCODE_RSHIFT = 229,
			/// <summary>
			/// The sdl scancode ralt sdl scancode
			/// </summary>
			SDL_SCANCODE_RALT = 230,
			/// <summary>
			/// The sdl scancode rgui sdl scancode
			/// </summary>
			SDL_SCANCODE_RGUI = 231,

			/// <summary>
			/// The sdl scancode mode sdl scancode
			/// </summary>
			SDL_SCANCODE_MODE = 257,

			/* These come from the USB consumer page (0x0C) */
			/// <summary>
			/// The sdl scancode audionext sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIONEXT = 258,
			/// <summary>
			/// The sdl scancode audioprev sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOPREV = 259,
			/// <summary>
			/// The sdl scancode audiostop sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOSTOP = 260,
			/// <summary>
			/// The sdl scancode audioplay sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOPLAY = 261,
			/// <summary>
			/// The sdl scancode audiomute sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOMUTE = 262,
			/// <summary>
			/// The sdl scancode mediaselect sdl scancode
			/// </summary>
			SDL_SCANCODE_MEDIASELECT = 263,
			/// <summary>
			/// The sdl scancode www sdl scancode
			/// </summary>
			SDL_SCANCODE_WWW = 264,
			/// <summary>
			/// The sdl scancode mail sdl scancode
			/// </summary>
			SDL_SCANCODE_MAIL = 265,
			/// <summary>
			/// The sdl scancode calculator sdl scancode
			/// </summary>
			SDL_SCANCODE_CALCULATOR = 266,
			/// <summary>
			/// The sdl scancode computer sdl scancode
			/// </summary>
			SDL_SCANCODE_COMPUTER = 267,
			/// <summary>
			/// The sdl scancode ac search sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_SEARCH = 268,
			/// <summary>
			/// The sdl scancode ac home sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_HOME = 269,
			/// <summary>
			/// The sdl scancode ac back sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_BACK = 270,
			/// <summary>
			/// The sdl scancode ac forward sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_FORWARD = 271,
			/// <summary>
			/// The sdl scancode ac stop sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_STOP = 272,
			/// <summary>
			/// The sdl scancode ac refresh sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_REFRESH = 273,
			/// <summary>
			/// The sdl scancode ac bookmarks sdl scancode
			/// </summary>
			SDL_SCANCODE_AC_BOOKMARKS = 274,

			/* These come from other sources, and are mostly mac related */
			/// <summary>
			/// The sdl scancode brightnessdown sdl scancode
			/// </summary>
			SDL_SCANCODE_BRIGHTNESSDOWN = 275,
			/// <summary>
			/// The sdl scancode brightnessup sdl scancode
			/// </summary>
			SDL_SCANCODE_BRIGHTNESSUP = 276,
			/// <summary>
			/// The sdl scancode displayswitch sdl scancode
			/// </summary>
			SDL_SCANCODE_DISPLAYSWITCH = 277,
			/// <summary>
			/// The sdl scancode kbdillumtoggle sdl scancode
			/// </summary>
			SDL_SCANCODE_KBDILLUMTOGGLE = 278,
			/// <summary>
			/// The sdl scancode kbdillumdown sdl scancode
			/// </summary>
			SDL_SCANCODE_KBDILLUMDOWN = 279,
			/// <summary>
			/// The sdl scancode kbdillumup sdl scancode
			/// </summary>
			SDL_SCANCODE_KBDILLUMUP = 280,
			/// <summary>
			/// The sdl scancode eject sdl scancode
			/// </summary>
			SDL_SCANCODE_EJECT = 281,
			/// <summary>
			/// The sdl scancode sleep sdl scancode
			/// </summary>
			SDL_SCANCODE_SLEEP = 282,

			/// <summary>
			/// The sdl scancode app1 sdl scancode
			/// </summary>
			SDL_SCANCODE_APP1 = 283,
			/// <summary>
			/// The sdl scancode app2 sdl scancode
			/// </summary>
			SDL_SCANCODE_APP2 = 284,

			/* These come from the USB consumer page (0x0C) */
			/// <summary>
			/// The sdl scancode audiorewind sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOREWIND = 285,
			/// <summary>
			/// The sdl scancode audiofastforward sdl scancode
			/// </summary>
			SDL_SCANCODE_AUDIOFASTFORWARD = 286,

			/* This is not a key, simply marks the number of scancodes
			 * so that you know how big to make your arrays. */
			/// <summary>
			/// The sdl num scancodes sdl scancode
			/// </summary>
			SDL_NUM_SCANCODES = 512
		}

		#endregion

		#region SDL_keycode.h

		/// <summary>
		/// The sdlk scancode mask
		/// </summary>
		public const int SDLK_SCANCODE_MASK = (1 << 30);
		/// <summary>
		/// Sdls the scancode to keycode using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The sdl keycode</returns>
		public static SDL_Keycode SDL_SCANCODE_TO_KEYCODE(SDL_Scancode X)
		{
			return (SDL_Keycode)((int)X | SDLK_SCANCODE_MASK);
		}

		/// <summary>
		/// The sdl keycode enum
		/// </summary>
		public enum SDL_Keycode
		{
			/// <summary>
			/// The sdlk unknown sdl keycode
			/// </summary>
			SDLK_UNKNOWN = 0,

			/// <summary>
			/// The sdlk return sdl keycode
			/// </summary>
			SDLK_RETURN = '\r',
			/// <summary>
			/// The sdlk escape sdl keycode
			/// </summary>
			SDLK_ESCAPE = 27, // '\033'
			/// <summary>
			/// The sdlk backspace sdl keycode
			/// </summary>
			SDLK_BACKSPACE = '\b',
			/// <summary>
			/// The sdlk tab sdl keycode
			/// </summary>
			SDLK_TAB = '\t',
			/// <summary>
			/// The sdlk space sdl keycode
			/// </summary>
			SDLK_SPACE = ' ',
			/// <summary>
			/// The sdlk exclaim sdl keycode
			/// </summary>
			SDLK_EXCLAIM = '!',
			/// <summary>
			/// The sdlk quotedbl sdl keycode
			/// </summary>
			SDLK_QUOTEDBL = '"',
			/// <summary>
			/// The sdlk hash sdl keycode
			/// </summary>
			SDLK_HASH = '#',
			/// <summary>
			/// The sdlk percent sdl keycode
			/// </summary>
			SDLK_PERCENT = '%',
			/// <summary>
			/// The sdlk dollar sdl keycode
			/// </summary>
			SDLK_DOLLAR = '$',
			/// <summary>
			/// The sdlk ampersand sdl keycode
			/// </summary>
			SDLK_AMPERSAND = '&',
			/// <summary>
			/// The sdlk quote sdl keycode
			/// </summary>
			SDLK_QUOTE = '\'',
			/// <summary>
			/// The sdlk leftparen sdl keycode
			/// </summary>
			SDLK_LEFTPAREN = '(',
			/// <summary>
			/// The sdlk rightparen sdl keycode
			/// </summary>
			SDLK_RIGHTPAREN = ')',
			/// <summary>
			/// The sdlk asterisk sdl keycode
			/// </summary>
			SDLK_ASTERISK = '*',
			/// <summary>
			/// The sdlk plus sdl keycode
			/// </summary>
			SDLK_PLUS = '+',
			/// <summary>
			/// The sdlk comma sdl keycode
			/// </summary>
			SDLK_COMMA = ',',
			/// <summary>
			/// The sdlk minus sdl keycode
			/// </summary>
			SDLK_MINUS = '-',
			/// <summary>
			/// The sdlk period sdl keycode
			/// </summary>
			SDLK_PERIOD = '.',
			/// <summary>
			/// The sdlk slash sdl keycode
			/// </summary>
			SDLK_SLASH = '/',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_0 = '0',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_1 = '1',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_2 = '2',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_3 = '3',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_4 = '4',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_5 = '5',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_6 = '6',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_7 = '7',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_8 = '8',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_9 = '9',
			/// <summary>
			/// The sdlk colon sdl keycode
			/// </summary>
			SDLK_COLON = ':',
			/// <summary>
			/// The sdlk semicolon sdl keycode
			/// </summary>
			SDLK_SEMICOLON = ';',
			/// <summary>
			/// The sdlk less sdl keycode
			/// </summary>
			SDLK_LESS = '<',
			/// <summary>
			/// The sdlk equals sdl keycode
			/// </summary>
			SDLK_EQUALS = '=',
			/// <summary>
			/// The sdlk greater sdl keycode
			/// </summary>
			SDLK_GREATER = '>',
			/// <summary>
			/// The sdlk question sdl keycode
			/// </summary>
			SDLK_QUESTION = '?',
			/// <summary>
			/// The sdlk at sdl keycode
			/// </summary>
			SDLK_AT = '@',
			/*
			Skip uppercase letters
			*/
			/// <summary>
			/// The sdlk leftbracket sdl keycode
			/// </summary>
			SDLK_LEFTBRACKET = '[',
			/// <summary>
			/// The sdlk backslash sdl keycode
			/// </summary>
			SDLK_BACKSLASH = '\\',
			/// <summary>
			/// The sdlk rightbracket sdl keycode
			/// </summary>
			SDLK_RIGHTBRACKET = ']',
			/// <summary>
			/// The sdlk caret sdl keycode
			/// </summary>
			SDLK_CARET = '^',
			/// <summary>
			/// The sdlk underscore sdl keycode
			/// </summary>
			SDLK_UNDERSCORE = '_',
			/// <summary>
			/// The sdlk backquote sdl keycode
			/// </summary>
			SDLK_BACKQUOTE = '`',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_a = 'a',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_b = 'b',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_c = 'c',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_d = 'd',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_e = 'e',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_f = 'f',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_g = 'g',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_h = 'h',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_i = 'i',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_j = 'j',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_k = 'k',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_l = 'l',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_m = 'm',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_n = 'n',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_o = 'o',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_p = 'p',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_q = 'q',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_r = 'r',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_s = 's',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_t = 't',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_u = 'u',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_v = 'v',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_w = 'w',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_x = 'x',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_y = 'y',
			/// <summary>
			/// The sdlk sdl keycode
			/// </summary>
			SDLK_z = 'z',

			/// <summary>
			/// The sdlk capslock sdl keycode
			/// </summary>
			SDLK_CAPSLOCK = (int)SDL_Scancode.SDL_SCANCODE_CAPSLOCK | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk f1 sdl keycode
			/// </summary>
			SDLK_F1 = (int)SDL_Scancode.SDL_SCANCODE_F1 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f2 sdl keycode
			/// </summary>
			SDLK_F2 = (int)SDL_Scancode.SDL_SCANCODE_F2 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f3 sdl keycode
			/// </summary>
			SDLK_F3 = (int)SDL_Scancode.SDL_SCANCODE_F3 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f4 sdl keycode
			/// </summary>
			SDLK_F4 = (int)SDL_Scancode.SDL_SCANCODE_F4 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f5 sdl keycode
			/// </summary>
			SDLK_F5 = (int)SDL_Scancode.SDL_SCANCODE_F5 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f6 sdl keycode
			/// </summary>
			SDLK_F6 = (int)SDL_Scancode.SDL_SCANCODE_F6 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f7 sdl keycode
			/// </summary>
			SDLK_F7 = (int)SDL_Scancode.SDL_SCANCODE_F7 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f8 sdl keycode
			/// </summary>
			SDLK_F8 = (int)SDL_Scancode.SDL_SCANCODE_F8 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f9 sdl keycode
			/// </summary>
			SDLK_F9 = (int)SDL_Scancode.SDL_SCANCODE_F9 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f10 sdl keycode
			/// </summary>
			SDLK_F10 = (int)SDL_Scancode.SDL_SCANCODE_F10 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f11 sdl keycode
			/// </summary>
			SDLK_F11 = (int)SDL_Scancode.SDL_SCANCODE_F11 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f12 sdl keycode
			/// </summary>
			SDLK_F12 = (int)SDL_Scancode.SDL_SCANCODE_F12 | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk printscreen sdl keycode
			/// </summary>
			SDLK_PRINTSCREEN = (int)SDL_Scancode.SDL_SCANCODE_PRINTSCREEN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk scrolllock sdl keycode
			/// </summary>
			SDLK_SCROLLLOCK = (int)SDL_Scancode.SDL_SCANCODE_SCROLLLOCK | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk pause sdl keycode
			/// </summary>
			SDLK_PAUSE = (int)SDL_Scancode.SDL_SCANCODE_PAUSE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk insert sdl keycode
			/// </summary>
			SDLK_INSERT = (int)SDL_Scancode.SDL_SCANCODE_INSERT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk home sdl keycode
			/// </summary>
			SDLK_HOME = (int)SDL_Scancode.SDL_SCANCODE_HOME | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk pageup sdl keycode
			/// </summary>
			SDLK_PAGEUP = (int)SDL_Scancode.SDL_SCANCODE_PAGEUP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk delete sdl keycode
			/// </summary>
			SDLK_DELETE = 127,
			/// <summary>
			/// The sdlk end sdl keycode
			/// </summary>
			SDLK_END = (int)SDL_Scancode.SDL_SCANCODE_END | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk pagedown sdl keycode
			/// </summary>
			SDLK_PAGEDOWN = (int)SDL_Scancode.SDL_SCANCODE_PAGEDOWN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk right sdl keycode
			/// </summary>
			SDLK_RIGHT = (int)SDL_Scancode.SDL_SCANCODE_RIGHT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk left sdl keycode
			/// </summary>
			SDLK_LEFT = (int)SDL_Scancode.SDL_SCANCODE_LEFT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk down sdl keycode
			/// </summary>
			SDLK_DOWN = (int)SDL_Scancode.SDL_SCANCODE_DOWN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk up sdl keycode
			/// </summary>
			SDLK_UP = (int)SDL_Scancode.SDL_SCANCODE_UP | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk numlockclear sdl keycode
			/// </summary>
			SDLK_NUMLOCKCLEAR = (int)SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp divide sdl keycode
			/// </summary>
			SDLK_KP_DIVIDE = (int)SDL_Scancode.SDL_SCANCODE_KP_DIVIDE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp multiply sdl keycode
			/// </summary>
			SDLK_KP_MULTIPLY = (int)SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp minus sdl keycode
			/// </summary>
			SDLK_KP_MINUS = (int)SDL_Scancode.SDL_SCANCODE_KP_MINUS | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp plus sdl keycode
			/// </summary>
			SDLK_KP_PLUS = (int)SDL_Scancode.SDL_SCANCODE_KP_PLUS | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp enter sdl keycode
			/// </summary>
			SDLK_KP_ENTER = (int)SDL_Scancode.SDL_SCANCODE_KP_ENTER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_1 = (int)SDL_Scancode.SDL_SCANCODE_KP_1 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_2 = (int)SDL_Scancode.SDL_SCANCODE_KP_2 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_3 = (int)SDL_Scancode.SDL_SCANCODE_KP_3 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_4 = (int)SDL_Scancode.SDL_SCANCODE_KP_4 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_5 = (int)SDL_Scancode.SDL_SCANCODE_KP_5 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_6 = (int)SDL_Scancode.SDL_SCANCODE_KP_6 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_7 = (int)SDL_Scancode.SDL_SCANCODE_KP_7 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_8 = (int)SDL_Scancode.SDL_SCANCODE_KP_8 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_9 = (int)SDL_Scancode.SDL_SCANCODE_KP_9 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_0 = (int)SDL_Scancode.SDL_SCANCODE_KP_0 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp period sdl keycode
			/// </summary>
			SDLK_KP_PERIOD = (int)SDL_Scancode.SDL_SCANCODE_KP_PERIOD | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk application sdl keycode
			/// </summary>
			SDLK_APPLICATION = (int)SDL_Scancode.SDL_SCANCODE_APPLICATION | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk power sdl keycode
			/// </summary>
			SDLK_POWER = (int)SDL_Scancode.SDL_SCANCODE_POWER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp equals sdl keycode
			/// </summary>
			SDLK_KP_EQUALS = (int)SDL_Scancode.SDL_SCANCODE_KP_EQUALS | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f13 sdl keycode
			/// </summary>
			SDLK_F13 = (int)SDL_Scancode.SDL_SCANCODE_F13 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f14 sdl keycode
			/// </summary>
			SDLK_F14 = (int)SDL_Scancode.SDL_SCANCODE_F14 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f15 sdl keycode
			/// </summary>
			SDLK_F15 = (int)SDL_Scancode.SDL_SCANCODE_F15 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f16 sdl keycode
			/// </summary>
			SDLK_F16 = (int)SDL_Scancode.SDL_SCANCODE_F16 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f17 sdl keycode
			/// </summary>
			SDLK_F17 = (int)SDL_Scancode.SDL_SCANCODE_F17 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f18 sdl keycode
			/// </summary>
			SDLK_F18 = (int)SDL_Scancode.SDL_SCANCODE_F18 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f19 sdl keycode
			/// </summary>
			SDLK_F19 = (int)SDL_Scancode.SDL_SCANCODE_F19 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f20 sdl keycode
			/// </summary>
			SDLK_F20 = (int)SDL_Scancode.SDL_SCANCODE_F20 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f21 sdl keycode
			/// </summary>
			SDLK_F21 = (int)SDL_Scancode.SDL_SCANCODE_F21 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f22 sdl keycode
			/// </summary>
			SDLK_F22 = (int)SDL_Scancode.SDL_SCANCODE_F22 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f23 sdl keycode
			/// </summary>
			SDLK_F23 = (int)SDL_Scancode.SDL_SCANCODE_F23 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk f24 sdl keycode
			/// </summary>
			SDLK_F24 = (int)SDL_Scancode.SDL_SCANCODE_F24 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk execute sdl keycode
			/// </summary>
			SDLK_EXECUTE = (int)SDL_Scancode.SDL_SCANCODE_EXECUTE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk help sdl keycode
			/// </summary>
			SDLK_HELP = (int)SDL_Scancode.SDL_SCANCODE_HELP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk menu sdl keycode
			/// </summary>
			SDLK_MENU = (int)SDL_Scancode.SDL_SCANCODE_MENU | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk select sdl keycode
			/// </summary>
			SDLK_SELECT = (int)SDL_Scancode.SDL_SCANCODE_SELECT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk stop sdl keycode
			/// </summary>
			SDLK_STOP = (int)SDL_Scancode.SDL_SCANCODE_STOP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk again sdl keycode
			/// </summary>
			SDLK_AGAIN = (int)SDL_Scancode.SDL_SCANCODE_AGAIN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk undo sdl keycode
			/// </summary>
			SDLK_UNDO = (int)SDL_Scancode.SDL_SCANCODE_UNDO | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk cut sdl keycode
			/// </summary>
			SDLK_CUT = (int)SDL_Scancode.SDL_SCANCODE_CUT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk copy sdl keycode
			/// </summary>
			SDLK_COPY = (int)SDL_Scancode.SDL_SCANCODE_COPY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk paste sdl keycode
			/// </summary>
			SDLK_PASTE = (int)SDL_Scancode.SDL_SCANCODE_PASTE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk find sdl keycode
			/// </summary>
			SDLK_FIND = (int)SDL_Scancode.SDL_SCANCODE_FIND | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk mute sdl keycode
			/// </summary>
			SDLK_MUTE = (int)SDL_Scancode.SDL_SCANCODE_MUTE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk volumeup sdl keycode
			/// </summary>
			SDLK_VOLUMEUP = (int)SDL_Scancode.SDL_SCANCODE_VOLUMEUP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk volumedown sdl keycode
			/// </summary>
			SDLK_VOLUMEDOWN = (int)SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp comma sdl keycode
			/// </summary>
			SDLK_KP_COMMA = (int)SDL_Scancode.SDL_SCANCODE_KP_COMMA | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp equalsas400 sdl keycode
			/// </summary>
			SDLK_KP_EQUALSAS400 =
			(int)SDL_Scancode.SDL_SCANCODE_KP_EQUALSAS400 | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk alterase sdl keycode
			/// </summary>
			SDLK_ALTERASE = (int)SDL_Scancode.SDL_SCANCODE_ALTERASE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk sysreq sdl keycode
			/// </summary>
			SDLK_SYSREQ = (int)SDL_Scancode.SDL_SCANCODE_SYSREQ | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk cancel sdl keycode
			/// </summary>
			SDLK_CANCEL = (int)SDL_Scancode.SDL_SCANCODE_CANCEL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk clear sdl keycode
			/// </summary>
			SDLK_CLEAR = (int)SDL_Scancode.SDL_SCANCODE_CLEAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk prior sdl keycode
			/// </summary>
			SDLK_PRIOR = (int)SDL_Scancode.SDL_SCANCODE_PRIOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk return2 sdl keycode
			/// </summary>
			SDLK_RETURN2 = (int)SDL_Scancode.SDL_SCANCODE_RETURN2 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk separator sdl keycode
			/// </summary>
			SDLK_SEPARATOR = (int)SDL_Scancode.SDL_SCANCODE_SEPARATOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk out sdl keycode
			/// </summary>
			SDLK_OUT = (int)SDL_Scancode.SDL_SCANCODE_OUT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk oper sdl keycode
			/// </summary>
			SDLK_OPER = (int)SDL_Scancode.SDL_SCANCODE_OPER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk clearagain sdl keycode
			/// </summary>
			SDLK_CLEARAGAIN = (int)SDL_Scancode.SDL_SCANCODE_CLEARAGAIN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk crsel sdl keycode
			/// </summary>
			SDLK_CRSEL = (int)SDL_Scancode.SDL_SCANCODE_CRSEL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk exsel sdl keycode
			/// </summary>
			SDLK_EXSEL = (int)SDL_Scancode.SDL_SCANCODE_EXSEL | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk kp 00 sdl keycode
			/// </summary>
			SDLK_KP_00 = (int)SDL_Scancode.SDL_SCANCODE_KP_00 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp 000 sdl keycode
			/// </summary>
			SDLK_KP_000 = (int)SDL_Scancode.SDL_SCANCODE_KP_000 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk thousandsseparator sdl keycode
			/// </summary>
			SDLK_THOUSANDSSEPARATOR =
			(int)SDL_Scancode.SDL_SCANCODE_THOUSANDSSEPARATOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk decimalseparator sdl keycode
			/// </summary>
			SDLK_DECIMALSEPARATOR =
			(int)SDL_Scancode.SDL_SCANCODE_DECIMALSEPARATOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk currencyunit sdl keycode
			/// </summary>
			SDLK_CURRENCYUNIT = (int)SDL_Scancode.SDL_SCANCODE_CURRENCYUNIT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk currencysubunit sdl keycode
			/// </summary>
			SDLK_CURRENCYSUBUNIT =
			(int)SDL_Scancode.SDL_SCANCODE_CURRENCYSUBUNIT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp leftparen sdl keycode
			/// </summary>
			SDLK_KP_LEFTPAREN = (int)SDL_Scancode.SDL_SCANCODE_KP_LEFTPAREN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp rightparen sdl keycode
			/// </summary>
			SDLK_KP_RIGHTPAREN = (int)SDL_Scancode.SDL_SCANCODE_KP_RIGHTPAREN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp leftbrace sdl keycode
			/// </summary>
			SDLK_KP_LEFTBRACE = (int)SDL_Scancode.SDL_SCANCODE_KP_LEFTBRACE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp rightbrace sdl keycode
			/// </summary>
			SDLK_KP_RIGHTBRACE = (int)SDL_Scancode.SDL_SCANCODE_KP_RIGHTBRACE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp tab sdl keycode
			/// </summary>
			SDLK_KP_TAB = (int)SDL_Scancode.SDL_SCANCODE_KP_TAB | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp backspace sdl keycode
			/// </summary>
			SDLK_KP_BACKSPACE = (int)SDL_Scancode.SDL_SCANCODE_KP_BACKSPACE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_A = (int)SDL_Scancode.SDL_SCANCODE_KP_A | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_B = (int)SDL_Scancode.SDL_SCANCODE_KP_B | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_C = (int)SDL_Scancode.SDL_SCANCODE_KP_C | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_D = (int)SDL_Scancode.SDL_SCANCODE_KP_D | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_E = (int)SDL_Scancode.SDL_SCANCODE_KP_E | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp sdl keycode
			/// </summary>
			SDLK_KP_F = (int)SDL_Scancode.SDL_SCANCODE_KP_F | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp xor sdl keycode
			/// </summary>
			SDLK_KP_XOR = (int)SDL_Scancode.SDL_SCANCODE_KP_XOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp power sdl keycode
			/// </summary>
			SDLK_KP_POWER = (int)SDL_Scancode.SDL_SCANCODE_KP_POWER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp percent sdl keycode
			/// </summary>
			SDLK_KP_PERCENT = (int)SDL_Scancode.SDL_SCANCODE_KP_PERCENT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp less sdl keycode
			/// </summary>
			SDLK_KP_LESS = (int)SDL_Scancode.SDL_SCANCODE_KP_LESS | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp greater sdl keycode
			/// </summary>
			SDLK_KP_GREATER = (int)SDL_Scancode.SDL_SCANCODE_KP_GREATER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp ampersand sdl keycode
			/// </summary>
			SDLK_KP_AMPERSAND = (int)SDL_Scancode.SDL_SCANCODE_KP_AMPERSAND | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp dblampersand sdl keycode
			/// </summary>
			SDLK_KP_DBLAMPERSAND =
			(int)SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp verticalbar sdl keycode
			/// </summary>
			SDLK_KP_VERTICALBAR =
			(int)SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp dblverticalbar sdl keycode
			/// </summary>
			SDLK_KP_DBLVERTICALBAR =
			(int)SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp colon sdl keycode
			/// </summary>
			SDLK_KP_COLON = (int)SDL_Scancode.SDL_SCANCODE_KP_COLON | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp hash sdl keycode
			/// </summary>
			SDLK_KP_HASH = (int)SDL_Scancode.SDL_SCANCODE_KP_HASH | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp space sdl keycode
			/// </summary>
			SDLK_KP_SPACE = (int)SDL_Scancode.SDL_SCANCODE_KP_SPACE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp at sdl keycode
			/// </summary>
			SDLK_KP_AT = (int)SDL_Scancode.SDL_SCANCODE_KP_AT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp exclam sdl keycode
			/// </summary>
			SDLK_KP_EXCLAM = (int)SDL_Scancode.SDL_SCANCODE_KP_EXCLAM | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memstore sdl keycode
			/// </summary>
			SDLK_KP_MEMSTORE = (int)SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memrecall sdl keycode
			/// </summary>
			SDLK_KP_MEMRECALL = (int)SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memclear sdl keycode
			/// </summary>
			SDLK_KP_MEMCLEAR = (int)SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memadd sdl keycode
			/// </summary>
			SDLK_KP_MEMADD = (int)SDL_Scancode.SDL_SCANCODE_KP_MEMADD | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memsubtract sdl keycode
			/// </summary>
			SDLK_KP_MEMSUBTRACT =
			(int)SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memmultiply sdl keycode
			/// </summary>
			SDLK_KP_MEMMULTIPLY =
			(int)SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp memdivide sdl keycode
			/// </summary>
			SDLK_KP_MEMDIVIDE = (int)SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp plusminus sdl keycode
			/// </summary>
			SDLK_KP_PLUSMINUS = (int)SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp clear sdl keycode
			/// </summary>
			SDLK_KP_CLEAR = (int)SDL_Scancode.SDL_SCANCODE_KP_CLEAR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp clearentry sdl keycode
			/// </summary>
			SDLK_KP_CLEARENTRY = (int)SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp binary sdl keycode
			/// </summary>
			SDLK_KP_BINARY = (int)SDL_Scancode.SDL_SCANCODE_KP_BINARY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp octal sdl keycode
			/// </summary>
			SDLK_KP_OCTAL = (int)SDL_Scancode.SDL_SCANCODE_KP_OCTAL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp decimal sdl keycode
			/// </summary>
			SDLK_KP_DECIMAL = (int)SDL_Scancode.SDL_SCANCODE_KP_DECIMAL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kp hexadecimal sdl keycode
			/// </summary>
			SDLK_KP_HEXADECIMAL =
			(int)SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk lctrl sdl keycode
			/// </summary>
			SDLK_LCTRL = (int)SDL_Scancode.SDL_SCANCODE_LCTRL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk lshift sdl keycode
			/// </summary>
			SDLK_LSHIFT = (int)SDL_Scancode.SDL_SCANCODE_LSHIFT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk lalt sdl keycode
			/// </summary>
			SDLK_LALT = (int)SDL_Scancode.SDL_SCANCODE_LALT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk lgui sdl keycode
			/// </summary>
			SDLK_LGUI = (int)SDL_Scancode.SDL_SCANCODE_LGUI | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk rctrl sdl keycode
			/// </summary>
			SDLK_RCTRL = (int)SDL_Scancode.SDL_SCANCODE_RCTRL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk rshift sdl keycode
			/// </summary>
			SDLK_RSHIFT = (int)SDL_Scancode.SDL_SCANCODE_RSHIFT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ralt sdl keycode
			/// </summary>
			SDLK_RALT = (int)SDL_Scancode.SDL_SCANCODE_RALT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk rgui sdl keycode
			/// </summary>
			SDLK_RGUI = (int)SDL_Scancode.SDL_SCANCODE_RGUI | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk mode sdl keycode
			/// </summary>
			SDLK_MODE = (int)SDL_Scancode.SDL_SCANCODE_MODE | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk audionext sdl keycode
			/// </summary>
			SDLK_AUDIONEXT = (int)SDL_Scancode.SDL_SCANCODE_AUDIONEXT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk audioprev sdl keycode
			/// </summary>
			SDLK_AUDIOPREV = (int)SDL_Scancode.SDL_SCANCODE_AUDIOPREV | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk audiostop sdl keycode
			/// </summary>
			SDLK_AUDIOSTOP = (int)SDL_Scancode.SDL_SCANCODE_AUDIOSTOP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk audioplay sdl keycode
			/// </summary>
			SDLK_AUDIOPLAY = (int)SDL_Scancode.SDL_SCANCODE_AUDIOPLAY | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk audiomute sdl keycode
			/// </summary>
			SDLK_AUDIOMUTE = (int)SDL_Scancode.SDL_SCANCODE_AUDIOMUTE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk mediaselect sdl keycode
			/// </summary>
			SDLK_MEDIASELECT = (int)SDL_Scancode.SDL_SCANCODE_MEDIASELECT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk www sdl keycode
			/// </summary>
			SDLK_WWW = (int)SDL_Scancode.SDL_SCANCODE_WWW | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk mail sdl keycode
			/// </summary>
			SDLK_MAIL = (int)SDL_Scancode.SDL_SCANCODE_MAIL | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk calculator sdl keycode
			/// </summary>
			SDLK_CALCULATOR = (int)SDL_Scancode.SDL_SCANCODE_CALCULATOR | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk computer sdl keycode
			/// </summary>
			SDLK_COMPUTER = (int)SDL_Scancode.SDL_SCANCODE_COMPUTER | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac search sdl keycode
			/// </summary>
			SDLK_AC_SEARCH = (int)SDL_Scancode.SDL_SCANCODE_AC_SEARCH | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac home sdl keycode
			/// </summary>
			SDLK_AC_HOME = (int)SDL_Scancode.SDL_SCANCODE_AC_HOME | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac back sdl keycode
			/// </summary>
			SDLK_AC_BACK = (int)SDL_Scancode.SDL_SCANCODE_AC_BACK | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac forward sdl keycode
			/// </summary>
			SDLK_AC_FORWARD = (int)SDL_Scancode.SDL_SCANCODE_AC_FORWARD | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac stop sdl keycode
			/// </summary>
			SDLK_AC_STOP = (int)SDL_Scancode.SDL_SCANCODE_AC_STOP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac refresh sdl keycode
			/// </summary>
			SDLK_AC_REFRESH = (int)SDL_Scancode.SDL_SCANCODE_AC_REFRESH | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk ac bookmarks sdl keycode
			/// </summary>
			SDLK_AC_BOOKMARKS = (int)SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk brightnessdown sdl keycode
			/// </summary>
			SDLK_BRIGHTNESSDOWN =
			(int)SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk brightnessup sdl keycode
			/// </summary>
			SDLK_BRIGHTNESSUP = (int)SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk displayswitch sdl keycode
			/// </summary>
			SDLK_DISPLAYSWITCH = (int)SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kbdillumtoggle sdl keycode
			/// </summary>
			SDLK_KBDILLUMTOGGLE =
			(int)SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kbdillumdown sdl keycode
			/// </summary>
			SDLK_KBDILLUMDOWN = (int)SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk kbdillumup sdl keycode
			/// </summary>
			SDLK_KBDILLUMUP = (int)SDL_Scancode.SDL_SCANCODE_KBDILLUMUP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk eject sdl keycode
			/// </summary>
			SDLK_EJECT = (int)SDL_Scancode.SDL_SCANCODE_EJECT | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk sleep sdl keycode
			/// </summary>
			SDLK_SLEEP = (int)SDL_Scancode.SDL_SCANCODE_SLEEP | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk app1 sdl keycode
			/// </summary>
			SDLK_APP1 = (int)SDL_Scancode.SDL_SCANCODE_APP1 | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk app2 sdl keycode
			/// </summary>
			SDLK_APP2 = (int)SDL_Scancode.SDL_SCANCODE_APP2 | SDLK_SCANCODE_MASK,

			/// <summary>
			/// The sdlk audiorewind sdl keycode
			/// </summary>
			SDLK_AUDIOREWIND = (int)SDL_Scancode.SDL_SCANCODE_AUDIOREWIND | SDLK_SCANCODE_MASK,
			/// <summary>
			/// The sdlk audiofastforward sdl keycode
			/// </summary>
			SDLK_AUDIOFASTFORWARD = (int)SDL_Scancode.SDL_SCANCODE_AUDIOFASTFORWARD | SDLK_SCANCODE_MASK
		}

		/* Key modifiers (bitfield) */
		/// <summary>
		/// The sdl keymod enum
		/// </summary>
		[Flags]
		public enum SDL_Keymod : ushort
		{
			/// <summary>
			/// The kmod none sdl keymod
			/// </summary>
			KMOD_NONE = 0x0000,
			/// <summary>
			/// The kmod lshift sdl keymod
			/// </summary>
			KMOD_LSHIFT = 0x0001,
			/// <summary>
			/// The kmod rshift sdl keymod
			/// </summary>
			KMOD_RSHIFT = 0x0002,
			/// <summary>
			/// The kmod lctrl sdl keymod
			/// </summary>
			KMOD_LCTRL = 0x0040,
			/// <summary>
			/// The kmod rctrl sdl keymod
			/// </summary>
			KMOD_RCTRL = 0x0080,
			/// <summary>
			/// The kmod lalt sdl keymod
			/// </summary>
			KMOD_LALT = 0x0100,
			/// <summary>
			/// The kmod ralt sdl keymod
			/// </summary>
			KMOD_RALT = 0x0200,
			/// <summary>
			/// The kmod lgui sdl keymod
			/// </summary>
			KMOD_LGUI = 0x0400,
			/// <summary>
			/// The kmod rgui sdl keymod
			/// </summary>
			KMOD_RGUI = 0x0800,
			/// <summary>
			/// The kmod num sdl keymod
			/// </summary>
			KMOD_NUM = 0x1000,
			/// <summary>
			/// The kmod caps sdl keymod
			/// </summary>
			KMOD_CAPS = 0x2000,
			/// <summary>
			/// The kmod mode sdl keymod
			/// </summary>
			KMOD_MODE = 0x4000,
			/// <summary>
			/// The kmod scroll sdl keymod
			/// </summary>
			KMOD_SCROLL = 0x8000,

			/* These are defines in the SDL headers */
			/// <summary>
			/// The kmod ctrl sdl keymod
			/// </summary>
			KMOD_CTRL = (KMOD_LCTRL | KMOD_RCTRL),
			/// <summary>
			/// The kmod shift sdl keymod
			/// </summary>
			KMOD_SHIFT = (KMOD_LSHIFT | KMOD_RSHIFT),
			/// <summary>
			/// The kmod alt sdl keymod
			/// </summary>
			KMOD_ALT = (KMOD_LALT | KMOD_RALT),
			/// <summary>
			/// The kmod gui sdl keymod
			/// </summary>
			KMOD_GUI = (KMOD_LGUI | KMOD_RGUI),

			/// <summary>
			/// The kmod reserved sdl keymod
			/// </summary>
			KMOD_RESERVED = KMOD_SCROLL
		}

		#endregion

		#region SDL_keyboard.h

		/// <summary>
		/// The sdl keysym
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Keysym
		{
			/// <summary>
			/// The scancode
			/// </summary>
			public SDL_Scancode scancode;
			/// <summary>
			/// The sym
			/// </summary>
			public SDL_Keycode sym;
			/// <summary>
			/// The mod
			/// </summary>
			public SDL_Keymod mod; /* UInt16 */
			/// <summary>
			/// The unicode
			/// </summary>
			public UInt32 unicode; /* Deprecated */
		}

		/* Get the window which has kbd focus */
		/* Return type is an SDL_Window pointer */
		/// <summary>
		/// Sdls the get keyboard focus
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetKeyboardFocus();

		/* Get a snapshot of the keyboard state. */
		/* Return value is a pointer to a UInt8 array */
		/* Numkeys returns the size of the array if non-null */
		/// <summary>
		/// Sdls the get keyboard state using the specified numkeys
		/// </summary>
		/// <param name="numkeys">The numkeys</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetKeyboardState(out int numkeys);

		/* Get the current key modifier state for the keyboard. */
		/// <summary>
		/// Sdls the get mod state
		/// </summary>
		/// <returns>The sdl keymod</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_Keymod SDL_GetModState();

		/* Set the current key modifier state */
		/// <summary>
		/// Sdls the set mod state using the specified modstate
		/// </summary>
		/// <param name="modstate">The modstate</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetModState(SDL_Keymod modstate);

		/* Get the key code corresponding to the given scancode
		 * with the current keyboard layout.
		 */
		/// <summary>
		/// Sdls the get key from scancode using the specified scancode
		/// </summary>
		/// <param name="scancode">The scancode</param>
		/// <returns>The sdl keycode</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_Keycode SDL_GetKeyFromScancode(SDL_Scancode scancode);

		/* Get the scancode for the given keycode */
		/// <summary>
		/// Sdls the get scancode from key using the specified key
		/// </summary>
		/// <param name="key">The key</param>
		/// <returns>The sdl scancode</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_Scancode SDL_GetScancodeFromKey(SDL_Keycode key);

		/* Wrapper for SDL_GetScancodeName */
		/// <summary>
		/// Internals the sdl get scancode name using the specified scancode
		/// </summary>
		/// <param name="scancode">The scancode</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetScancodeName(SDL_Scancode scancode);
		/// <summary>
		/// Sdls the get scancode name using the specified scancode
		/// </summary>
		/// <param name="scancode">The scancode</param>
		/// <returns>The string</returns>
		public static string SDL_GetScancodeName(SDL_Scancode scancode)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GetScancodeName(scancode)
			);
		}

		/* Get a scancode from a human-readable name */
		/// <summary>
		/// Internals the sdl get scancode from name using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The sdl scancode</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_Scancode INTERNAL_SDL_GetScancodeFromName(
			byte* name
		);
		/// <summary>
		/// Sdls the get scancode from name using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The sdl scancode</returns>
		public static unsafe SDL_Scancode SDL_GetScancodeFromName(string name)
		{
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return INTERNAL_SDL_GetScancodeFromName(
				Utf8Encode(name, utf8Name, utf8NameBufSize)
			);
		}

		/* Wrapper for SDL_GetKeyName */
		/// <summary>
		/// Internals the sdl get key name using the specified key
		/// </summary>
		/// <param name="key">The key</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetKeyName(SDL_Keycode key);
		/// <summary>
		/// Sdls the get key name using the specified key
		/// </summary>
		/// <param name="key">The key</param>
		/// <returns>The string</returns>
		public static string SDL_GetKeyName(SDL_Keycode key)
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetKeyName(key));
		}

		/* Get a key code from a human-readable name */
		/// <summary>
		/// Internals the sdl get key from name using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The sdl keycode</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_Keycode INTERNAL_SDL_GetKeyFromName(
			byte* name
		);
		/// <summary>
		/// Sdls the get key from name using the specified name
		/// </summary>
		/// <param name="name">The name</param>
		/// <returns>The sdl keycode</returns>
		public static unsafe SDL_Keycode SDL_GetKeyFromName(string name)
		{
			int utf8NameBufSize = Utf8Size(name);
			byte* utf8Name = stackalloc byte[utf8NameBufSize];
			return INTERNAL_SDL_GetKeyFromName(
				Utf8Encode(name, utf8Name, utf8NameBufSize)
			);
		}

		/* Start accepting Unicode text input events, show keyboard */
		/// <summary>
		/// Sdls the start text input
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_StartTextInput();

		/* Check if unicode input events are enabled */
		/// <summary>
		/// Sdls the is text input active
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsTextInputActive();

		/* Stop receiving any text input events, hide onscreen kbd */
		/// <summary>
		/// Sdls the stop text input
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_StopTextInput();

		/* Set the rectangle used for text input, hint for IME */
		/// <summary>
		/// Sdls the set text input rect using the specified rect
		/// </summary>
		/// <param name="rect">The rect</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetTextInputRect(ref SDL_Rect rect);

		/* Does the platform support an on-screen keyboard? */
		/// <summary>
		/// Sdls the has screen keyboard support
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasScreenKeyboardSupport();

		/* Is the on-screen keyboard shown for a given window? */
		/* window is an SDL_Window pointer */
		/// <summary>
		/// Sdls the is screen keyboard shown using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsScreenKeyboardShown(IntPtr window);

		#endregion

		#region SDL_mouse.c

		/* Note: SDL_Cursor is a typedef normally. We'll treat it as
		 * an IntPtr, because C# doesn't do typedefs. Yay!
		 */

		/* System cursor types */
		/// <summary>
		/// The sdl systemcursor enum
		/// </summary>
		public enum SDL_SystemCursor
		{
			/// <summary>
			/// The sdl system cursor arrow sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_ARROW,	// Arrow
			/// <summary>
			/// The sdl system cursor ibeam sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_IBEAM,	// I-beam
			/// <summary>
			/// The sdl system cursor wait sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_WAIT,		// Wait
			/// <summary>
			/// The sdl system cursor crosshair sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_CROSSHAIR,	// Crosshair
			/// <summary>
			/// The sdl system cursor waitarrow sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_WAITARROW,	// Small wait cursor (or Wait if not available)
			/// <summary>
			/// The sdl system cursor sizenwse sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_SIZENWSE,	// Double arrow pointing northwest and southeast
			/// <summary>
			/// The sdl system cursor sizenesw sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_SIZENESW,	// Double arrow pointing northeast and southwest
			/// <summary>
			/// The sdl system cursor sizewe sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_SIZEWE,	// Double arrow pointing west and east
			/// <summary>
			/// The sdl system cursor sizens sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_SIZENS,	// Double arrow pointing north and south
			/// <summary>
			/// The sdl system cursor sizeall sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_SIZEALL,	// Four pointed arrow pointing north, south, east, and west
			/// <summary>
			/// The sdl system cursor no sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_NO,		// Slashed circle or crossbones
			/// <summary>
			/// The sdl system cursor hand sdl systemcursor
			/// </summary>
			SDL_SYSTEM_CURSOR_HAND,		// Hand
			/// <summary>
			/// The sdl num system cursors sdl systemcursor
			/// </summary>
			SDL_NUM_SYSTEM_CURSORS
		}

		/* Get the window which currently has mouse focus */
		/* Return value is an SDL_Window pointer */
		/// <summary>
		/// Sdls the get mouse focus
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetMouseFocus();

		/* Get the current state of the mouse */
		/// <summary>
		/// Sdls the get mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetMouseState(out int x, out int y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to x */
		/// <summary>
		/// Sdls the get mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetMouseState(IntPtr x, out int y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to y */
		/// <summary>
		/// Sdls the get mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetMouseState(out int x, IntPtr y);

		/* Get the current state of the mouse */
		/* This overload allows for passing NULL to both x and y */
		/// <summary>
		/// Sdls the get mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetMouseState(IntPtr x, IntPtr y);

		/* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the get global mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetGlobalMouseState(out int x, out int y);

		/* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to x.
		 */
		/// <summary>
		/// Sdls the get global mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetGlobalMouseState(IntPtr x, out int y);

		/* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to y.
		 */
		/// <summary>
		/// Sdls the get global mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetGlobalMouseState(out int x, IntPtr y);

		/* Get the current state of the mouse, in relation to the desktop.
		 * Only available in 2.0.4 or higher.
		 * This overload allows for passing NULL to both x and y
		 */
		/// <summary>
		/// Sdls the get global mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetGlobalMouseState(IntPtr x, IntPtr y);

		/* Get the mouse state with relative coords*/
		/// <summary>
		/// Sdls the get relative mouse state using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetRelativeMouseState(out int x, out int y);

		/* Set the mouse cursor's position (within a window) */
		/* window is an SDL_Window pointer */
		/// <summary>
		/// Sdls the warp mouse in window using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);

		/* Set the mouse cursor's position in global screen space.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the warp mouse global using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_WarpMouseGlobal(int x, int y);

		/* Enable/Disable relative mouse mode (grabs mouse, rel coords) */
		/// <summary>
		/// Sdls the set relative mouse mode using the specified enabled
		/// </summary>
		/// <param name="enabled">The enabled</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SetRelativeMouseMode(SDL_bool enabled);

		/* Capture the mouse, to track input outside an SDL window.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the capture mouse using the specified enabled
		/// </summary>
		/// <param name="enabled">The enabled</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_CaptureMouse(SDL_bool enabled);

		/* Query if the relative mouse mode is enabled */
		/// <summary>
		/// Sdls the get relative mouse mode
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GetRelativeMouseMode();

		/* Create a cursor from bitmap data (amd mask) in MSB format.
		 * data and mask are byte arrays, and w must be a multiple of 8.
		 * return value is an SDL_Cursor pointer.
		 */
		/// <summary>
		/// Sdls the create cursor using the specified data
		/// </summary>
		/// <param name="data">The data</param>
		/// <param name="mask">The mask</param>
		/// <param name="w">The </param>
		/// <param name="h">The </param>
		/// <param name="hot_x">The hot</param>
		/// <param name="hot_y">The hot</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateCursor(
			IntPtr data,
			IntPtr mask,
			int w,
			int h,
			int hot_x,
			int hot_y
		);

		/* Create a cursor from an SDL_Surface.
		 * IntPtr refers to an SDL_Cursor*, surface to an SDL_Surface*
		 */
		/// <summary>
		/// Sdls the create color cursor using the specified surface
		/// </summary>
		/// <param name="surface">The surface</param>
		/// <param name="hot_x">The hot</param>
		/// <param name="hot_y">The hot</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateColorCursor(
			IntPtr surface,
			int hot_x,
			int hot_y
		);

		/* Create a cursor from a system cursor id.
		 * return value is an SDL_Cursor pointer
		 */
		/// <summary>
		/// Sdls the create system cursor using the specified id
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_CreateSystemCursor(SDL_SystemCursor id);

		/* Set the active cursor.
		 * cursor is an SDL_Cursor pointer
		 */
		/// <summary>
		/// Sdls the set cursor using the specified cursor
		/// </summary>
		/// <param name="cursor">The cursor</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetCursor(IntPtr cursor);

		/* Return the active cursor
		 * return value is an SDL_Cursor pointer
		 */
		/// <summary>
		/// Sdls the get cursor
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetCursor();

		/* Frees a cursor created with one of the CreateCursor functions.
		 * cursor in an SDL_Cursor pointer
		 */
		/// <summary>
		/// Sdls the free cursor using the specified cursor
		/// </summary>
		/// <param name="cursor">The cursor</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeCursor(IntPtr cursor);

		/* Toggle whether or not the cursor is shown */
		/// <summary>
		/// Sdls the show cursor using the specified toggle
		/// </summary>
		/// <param name="toggle">The toggle</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_ShowCursor(int toggle);

		/// <summary>
		/// Sdls the button using the specified x
		/// </summary>
		/// <param name="X">The </param>
		/// <returns>The uint</returns>
		public static uint SDL_BUTTON(uint X)
		{
			// If only there were a better way of doing this in C#
			return (uint) (1 << ((int) X - 1));
		}

		/// <summary>
		/// The sdl button left
		/// </summary>
		public const uint SDL_BUTTON_LEFT =	1;
		/// <summary>
		/// The sdl button middle
		/// </summary>
		public const uint SDL_BUTTON_MIDDLE =	2;
		/// <summary>
		/// The sdl button right
		/// </summary>
		public const uint SDL_BUTTON_RIGHT =	3;
		/// <summary>
		/// The sdl button x1
		/// </summary>
		public const uint SDL_BUTTON_X1 =	4;
		/// <summary>
		/// The sdl button x2
		/// </summary>
		public const uint SDL_BUTTON_X2 =	5;
		/// <summary>
		/// The sdl button left
		/// </summary>
		public static readonly UInt32 SDL_BUTTON_LMASK =	SDL_BUTTON(SDL_BUTTON_LEFT);
		/// <summary>
		/// The sdl button middle
		/// </summary>
		public static readonly UInt32 SDL_BUTTON_MMASK =	SDL_BUTTON(SDL_BUTTON_MIDDLE);
		/// <summary>
		/// The sdl button right
		/// </summary>
		public static readonly UInt32 SDL_BUTTON_RMASK =	SDL_BUTTON(SDL_BUTTON_RIGHT);
		/// <summary>
		/// The sdl button x1
		/// </summary>
		public static readonly UInt32 SDL_BUTTON_X1MASK =	SDL_BUTTON(SDL_BUTTON_X1);
		/// <summary>
		/// The sdl button x2
		/// </summary>
		public static readonly UInt32 SDL_BUTTON_X2MASK =	SDL_BUTTON(SDL_BUTTON_X2);

		#endregion

		#region SDL_touch.h

		/// <summary>
		/// The max value
		/// </summary>
		public const uint SDL_TOUCH_MOUSEID = uint.MaxValue;

		/// <summary>
		/// The sdl finger
		/// </summary>
		public struct SDL_Finger
		{
			/// <summary>
			/// The id
			/// </summary>
			public long id; // SDL_FingerID
			/// <summary>
			/// The 
			/// </summary>
			public float x;
			/// <summary>
			/// The 
			/// </summary>
			public float y;
			/// <summary>
			/// The pressure
			/// </summary>
			public float pressure;
		}

		/* Only available in 2.0.10 or higher. */
		/// <summary>
		/// The sdl touchdevicetype enum
		/// </summary>
		public enum SDL_TouchDeviceType
		{
			/// <summary>
			/// The sdl touch device invalid sdl touchdevicetype
			/// </summary>
			SDL_TOUCH_DEVICE_INVALID = -1,
			/// <summary>
			/// The sdl touch device direct sdl touchdevicetype
			/// </summary>
			SDL_TOUCH_DEVICE_DIRECT,            /* touch screen with window-relative coordinates */
			/// <summary>
			/// The sdl touch device indirect absolute sdl touchdevicetype
			/// </summary>
			SDL_TOUCH_DEVICE_INDIRECT_ABSOLUTE, /* trackpad with absolute device coordinates */
			/// <summary>
			/// The sdl touch device indirect relative sdl touchdevicetype
			/// </summary>
			SDL_TOUCH_DEVICE_INDIRECT_RELATIVE  /* trackpad with screen cursor-relative coordinates */
		}

		/**
		 *  \brief Get the number of registered touch devices.
 		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumTouchDevices();

		/**
		 *  \brief Get the touch ID with the given index, or 0 if the index is invalid.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern long SDL_GetTouchDevice(int index);

		/**
		 *  \brief Get the number of active fingers for a given touch device.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumTouchFingers(long touchID);

		/**
		 *  \brief Get the finger object of the given touch, with the given index.
		 *  Returns pointer to SDL_Finger.
		 */
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetTouchFinger(long touchID, int index);

		/* Only available in 2.0.10 or higher. */
		/// <summary>
		/// Sdls the get touch device type using the specified touch id
		/// </summary>
		/// <param name="touchID">The touch id</param>
		/// <returns>The sdl touch device type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_TouchDeviceType SDL_GetTouchDeviceType(Int64 touchID);

		#endregion

		#region SDL_joystick.h

		/// <summary>
		/// The sdl hat centered
		/// </summary>
		public const byte SDL_HAT_CENTERED =	0x00;
		/// <summary>
		/// The sdl hat up
		/// </summary>
		public const byte SDL_HAT_UP =		0x01;
		/// <summary>
		/// The sdl hat right
		/// </summary>
		public const byte SDL_HAT_RIGHT =	0x02;
		/// <summary>
		/// The sdl hat down
		/// </summary>
		public const byte SDL_HAT_DOWN =	0x04;
		/// <summary>
		/// The sdl hat left
		/// </summary>
		public const byte SDL_HAT_LEFT =	0x08;
		/// <summary>
		/// The sdl hat up
		/// </summary>
		public const byte SDL_HAT_RIGHTUP =	SDL_HAT_RIGHT | SDL_HAT_UP;
		/// <summary>
		/// The sdl hat down
		/// </summary>
		public const byte SDL_HAT_RIGHTDOWN =	SDL_HAT_RIGHT | SDL_HAT_DOWN;
		/// <summary>
		/// The sdl hat up
		/// </summary>
		public const byte SDL_HAT_LEFTUP =	SDL_HAT_LEFT | SDL_HAT_UP;
		/// <summary>
		/// The sdl hat down
		/// </summary>
		public const byte SDL_HAT_LEFTDOWN =	SDL_HAT_LEFT | SDL_HAT_DOWN;

		/// <summary>
		/// The sdl joystickpowerlevel enum
		/// </summary>
		public enum SDL_JoystickPowerLevel
		{
			/// <summary>
			/// The sdl joystick power unknown sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_UNKNOWN = -1,
			/// <summary>
			/// The sdl joystick power empty sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_EMPTY,
			/// <summary>
			/// The sdl joystick power low sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_LOW,
			/// <summary>
			/// The sdl joystick power medium sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_MEDIUM,
			/// <summary>
			/// The sdl joystick power full sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_FULL,
			/// <summary>
			/// The sdl joystick power wired sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_WIRED,
			/// <summary>
			/// The sdl joystick power max sdl joystickpowerlevel
			/// </summary>
			SDL_JOYSTICK_POWER_MAX
		}

		/// <summary>
		/// The sdl joysticktype enum
		/// </summary>
		public enum SDL_JoystickType
		{
			/// <summary>
			/// The sdl joystick type unknown sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_UNKNOWN,
			/// <summary>
			/// The sdl joystick type gamecontroller sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_GAMECONTROLLER,
			/// <summary>
			/// The sdl joystick type wheel sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_WHEEL,
			/// <summary>
			/// The sdl joystick type arcade stick sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_ARCADE_STICK,
			/// <summary>
			/// The sdl joystick type flight stick sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_FLIGHT_STICK,
			/// <summary>
			/// The sdl joystick type dance pad sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_DANCE_PAD,
			/// <summary>
			/// The sdl joystick type guitar sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_GUITAR,
			/// <summary>
			/// The sdl joystick type drum kit sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_DRUM_KIT,
			/// <summary>
			/// The sdl joystick type arcade pad sdl joysticktype
			/// </summary>
			SDL_JOYSTICK_TYPE_ARCADE_PAD
		}

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// The sdl iphone max gforce
		/// </summary>
		public const float SDL_IPHONE_MAX_GFORCE = 5.0f;

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.9 or higher.
		 */
		/// <summary>
		/// Sdls the joystick rumble using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="low_frequency_rumble">The low frequency rumble</param>
		/// <param name="high_frequency_rumble">The high frequency rumble</param>
		/// <param name="duration_ms">The duration ms</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickRumble(
			IntPtr joystick,
			UInt16 low_frequency_rumble,
			UInt16 high_frequency_rumble,
			UInt32 duration_ms
		);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick rumble triggers using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="left_rumble">The left rumble</param>
		/// <param name="right_rumble">The right rumble</param>
		/// <param name="duration_ms">The duration ms</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickRumbleTriggers(
			IntPtr joystick,
			UInt16 left_rumble,
			UInt16 right_rumble,
			UInt32 duration_ms
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick close using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickClose(IntPtr joystick);

		/// <summary>
		/// Sdls the joystick event state using the specified state
		/// </summary>
		/// <param name="state">The state</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickEventState(int state);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get axis using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="axis">The axis</param>
		/// <returns>The short</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern short SDL_JoystickGetAxis(
			IntPtr joystick,
			int axis
		);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get axis initial state using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="axis">The axis</param>
		/// <param name="state">The state</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickGetAxisInitialState(
			IntPtr joystick,
			int axis,
			out ushort state
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get ball using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="ball">The ball</param>
		/// <param name="dx">The dx</param>
		/// <param name="dy">The dy</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickGetBall(
			IntPtr joystick,
			int ball,
			out int dx,
			out int dy
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get button using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="button">The button</param>
		/// <returns>The byte</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_JoystickGetButton(
			IntPtr joystick,
			int button
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get hat using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="hat">The hat</param>
		/// <returns>The byte</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_JoystickGetHat(
			IntPtr joystick,
			int hat
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Internals the sdl joystick name using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_JoystickName(
			IntPtr joystick
		);
		/// <summary>
		/// Sdls the joystick name using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The string</returns>
		public static string SDL_JoystickName(IntPtr joystick)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_JoystickName(joystick)
			);
		}

		/// <summary>
		/// Internals the sdl joystick name for index using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex(
			int device_index
		);
		/// <summary>
		/// Sdls the joystick name for index using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The string</returns>
		public static string SDL_JoystickNameForIndex(int device_index)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_JoystickNameForIndex(device_index)
			);
		}

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick num axes using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumAxes(IntPtr joystick);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick num balls using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumBalls(IntPtr joystick);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick num buttons using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumButtons(IntPtr joystick);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick num hats using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickNumHats(IntPtr joystick);

		/* IntPtr refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick open using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_JoystickOpen(int device_index);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick update
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickUpdate();

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the num joysticks
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_NumJoysticks();

		/// <summary>
		/// Sdls the joystick get device guid using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The guid</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern Guid SDL_JoystickGetDeviceGUID(
			int device_index
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get guid using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The guid</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern Guid SDL_JoystickGetGUID(
			IntPtr joystick
		);

		/// <summary>
		/// Sdls the joystick get guid string using the specified guid
		/// </summary>
		/// <param name="guid">The guid</param>
		/// <param name="pszGUID">The psz guid</param>
		/// <param name="cbGUID">The cb guid</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickGetGUIDString(
			Guid guid,
			byte[] pszGUID,
			int cbGUID
		);

		/// <summary>
		/// Internals the sdl joystick get guid from string using the specified pch guid
		/// </summary>
		/// <param name="pchGUID">The pch guid</param>
		/// <returns>The guid</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe Guid INTERNAL_SDL_JoystickGetGUIDFromString(
			byte* pchGUID
		);
		/// <summary>
		/// Sdls the joystick get guid from string using the specified pch guid
		/// </summary>
		/// <param name="pchGuid">The pch guid</param>
		/// <returns>The guid</returns>
		public static unsafe Guid SDL_JoystickGetGUIDFromString(string pchGuid)
		{
			int utf8PchGuidBufSize = Utf8Size(pchGuid);
			byte* utf8PchGuid = stackalloc byte[utf8PchGuidBufSize];
			return INTERNAL_SDL_JoystickGetGUIDFromString(
				Utf8Encode(pchGuid, utf8PchGuid, utf8PchGuidBufSize)
			);
		}

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the joystick get device vendor using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceVendor(int device_index);

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the joystick get device product using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceProduct(int device_index);

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the joystick get device product version using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetDeviceProductVersion(int device_index);

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the joystick get device type using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The sdl joystick type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_JoystickType SDL_JoystickGetDeviceType(int device_index);

		/* int refers to an SDL_JoystickID.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get device instance id using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickGetDeviceInstanceID(int device_index);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get vendor using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get product using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get product version using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Internals the sdl joystick get serial using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_JoystickGetSerial(
			IntPtr joystick
		);
		/// <summary>
		/// Sdls the joystick get serial using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The string</returns>
		public static string SDL_JoystickGetSerial(
			IntPtr joystick
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_JoystickGetSerial(joystick)
			);
		}

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the joystick get type using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl joystick type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_JoystickType SDL_JoystickGetType(IntPtr joystick);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick get attached using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickGetAttached(IntPtr joystick);

		/* int refers to an SDL_JoystickID, joystick to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick instance id using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickInstanceID(IntPtr joystick);

		/* joystick refers to an SDL_Joystick*.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the joystick current power level using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl joystick power level</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_JoystickPowerLevel SDL_JoystickCurrentPowerLevel(
			IntPtr joystick
		);

		/* int refers to an SDL_JoystickID, IntPtr to an SDL_Joystick*.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the joystick from instance id using the specified instance id
		/// </summary>
		/// <param name="instance_id">The instance id</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_JoystickFromInstanceID(int instance_id);

		/* Only available in 2.0.7 or higher. */
		/// <summary>
		/// Sdls the lock joysticks
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockJoysticks();

		/* Only available in 2.0.7 or higher. */
		/// <summary>
		/// Sdls the unlock joysticks
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockJoysticks();

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the joystick from player index using the specified player index
		/// </summary>
		/// <param name="player_index">The player index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_JoystickFromPlayerIndex(int player_index);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the joystick set player index using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="player_index">The player index</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_JoystickSetPlayerIndex(
			IntPtr joystick,
			int player_index
		);

		/* Int32 refers to an SDL_JoystickType.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick attach virtual using the specified type
		/// </summary>
		/// <param name="type">The type</param>
		/// <param name="naxes">The naxes</param>
		/// <param name="nbuttons">The nbuttons</param>
		/// <param name="nhats">The nhats</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickAttachVirtual(
			Int32 type,
			int naxes,
			int nbuttons,
			int nhats
		);

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Sdls the joystick detach virtual using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickDetachVirtual(int device_index);

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Sdls the joystick is virtual using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickIsVirtual(int device_index);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick set virtual axis using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="axis">The axis</param>
		/// <param name="value">The value</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickSetVirtualAxis(
			IntPtr joystick,
			int axis,
			Int16 value
		);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick set virtual button using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="button">The button</param>
		/// <param name="value">The value</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickSetVirtualButton(
			IntPtr joystick,
			int button,
			byte value
		);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick set virtual hat using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="hat">The hat</param>
		/// <param name="value">The value</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickSetVirtualHat(
			IntPtr joystick,
			int hat,
			byte value
		);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick has led using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickHasLED(IntPtr joystick);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the joystick has rumble using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickHasRumble(IntPtr joystick);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the joystick has rumble triggers using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_JoystickHasRumbleTriggers(IntPtr joystick);

		/* IntPtr refers to an SDL_Joystick*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the joystick set led using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="red">The red</param>
		/// <param name="green">The green</param>
		/// <param name="blue">The blue</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickSetLED(
			IntPtr joystick,
			byte red,
			byte green,
			byte blue
		);

		/* joystick refers to an SDL_Joystick*.
		 * data refers to a const void*.
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the joystick send effect using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <param name="data">The data</param>
		/// <param name="size">The size</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickSendEffect(
			IntPtr joystick,
			IntPtr data,
			int size
		);

		#endregion

		#region SDL_gamecontroller.h

		/// <summary>
		/// The sdl gamecontrollerbindtype enum
		/// </summary>
		public enum SDL_GameControllerBindType
		{
			/// <summary>
			/// The sdl controller bindtype none sdl gamecontrollerbindtype
			/// </summary>
			SDL_CONTROLLER_BINDTYPE_NONE,
			/// <summary>
			/// The sdl controller bindtype button sdl gamecontrollerbindtype
			/// </summary>
			SDL_CONTROLLER_BINDTYPE_BUTTON,
			/// <summary>
			/// The sdl controller bindtype axis sdl gamecontrollerbindtype
			/// </summary>
			SDL_CONTROLLER_BINDTYPE_AXIS,
			/// <summary>
			/// The sdl controller bindtype hat sdl gamecontrollerbindtype
			/// </summary>
			SDL_CONTROLLER_BINDTYPE_HAT
		}

		/// <summary>
		/// The sdl gamecontrolleraxis enum
		/// </summary>
		public enum SDL_GameControllerAxis
		{
			/// <summary>
			/// The sdl controller axis invalid sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_INVALID = -1,
			/// <summary>
			/// The sdl controller axis leftx sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_LEFTX,
			/// <summary>
			/// The sdl controller axis lefty sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_LEFTY,
			/// <summary>
			/// The sdl controller axis rightx sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_RIGHTX,
			/// <summary>
			/// The sdl controller axis righty sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_RIGHTY,
			/// <summary>
			/// The sdl controller axis triggerleft sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_TRIGGERLEFT,
			/// <summary>
			/// The sdl controller axis triggerright sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_TRIGGERRIGHT,
			/// <summary>
			/// The sdl controller axis max sdl gamecontrolleraxis
			/// </summary>
			SDL_CONTROLLER_AXIS_MAX
		}

		/// <summary>
		/// The sdl gamecontrollerbutton enum
		/// </summary>
		public enum SDL_GameControllerButton
		{
			/// <summary>
			/// The sdl controller button invalid sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_INVALID = -1,
			/// <summary>
			/// The sdl controller button sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_A,
			/// <summary>
			/// The sdl controller button sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_B,
			/// <summary>
			/// The sdl controller button sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_X,
			/// <summary>
			/// The sdl controller button sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_Y,
			/// <summary>
			/// The sdl controller button back sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_BACK,
			/// <summary>
			/// The sdl controller button guide sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_GUIDE,
			/// <summary>
			/// The sdl controller button start sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_START,
			/// <summary>
			/// The sdl controller button leftstick sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_LEFTSTICK,
			/// <summary>
			/// The sdl controller button rightstick sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_RIGHTSTICK,
			/// <summary>
			/// The sdl controller button leftshoulder sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_LEFTSHOULDER,
			/// <summary>
			/// The sdl controller button rightshoulder sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_RIGHTSHOULDER,
			/// <summary>
			/// The sdl controller button dpad up sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_DPAD_UP,
			/// <summary>
			/// The sdl controller button dpad down sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_DPAD_DOWN,
			/// <summary>
			/// The sdl controller button dpad left sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_DPAD_LEFT,
			/// <summary>
			/// The sdl controller button dpad right sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_DPAD_RIGHT,
			/// <summary>
			/// The sdl controller button misc1 sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_MISC1,
			/// <summary>
			/// The sdl controller button paddle1 sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_PADDLE1,
			/// <summary>
			/// The sdl controller button paddle2 sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_PADDLE2,
			/// <summary>
			/// The sdl controller button paddle3 sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_PADDLE3,
			/// <summary>
			/// The sdl controller button paddle4 sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_PADDLE4,
			/// <summary>
			/// The sdl controller button touchpad sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_TOUCHPAD,
			/// <summary>
			/// The sdl controller button max sdl gamecontrollerbutton
			/// </summary>
			SDL_CONTROLLER_BUTTON_MAX,
		}

		/// <summary>
		/// The sdl gamecontrollertype enum
		/// </summary>
		public enum SDL_GameControllerType
		{
			/// <summary>
			/// The sdl controller type unknown sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_UNKNOWN = 0,
			/// <summary>
			/// The sdl controller type xbox360 sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_XBOX360,
			/// <summary>
			/// The sdl controller type xboxone sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_XBOXONE,
			/// <summary>
			/// The sdl controller type ps3 sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_PS3,
			/// <summary>
			/// The sdl controller type ps4 sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_PS4,
			/// <summary>
			/// The sdl controller type nintendo switch pro sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_NINTENDO_SWITCH_PRO,
			/// <summary>
			/// The sdl controller type virtual sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_VIRTUAL,		/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl controller type ps5 sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_PS5,		/* Requires >= 2.0.14 */
			/// <summary>
			/// The sdl controller type amazon luna sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_AMAZON_LUNA,	/* Requires >= 2.0.16 */
			/// <summary>
			/// The sdl controller type google stadia sdl gamecontrollertype
			/// </summary>
			SDL_CONTROLLER_TYPE_GOOGLE_STADIA	/* Requires >= 2.0.16 */
		}

		// FIXME: I'd rather this somehow be private...
		/// <summary>
		/// The internal gamecontrollerbuttonbind hat
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_GameControllerButtonBind_hat
		{
			/// <summary>
			/// The hat
			/// </summary>
			public int hat;
			/// <summary>
			/// The hat mask
			/// </summary>
			public int hat_mask;
		}

		// FIXME: I'd rather this somehow be private...
		/// <summary>
		/// The internal gamecontrollerbuttonbind union
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct INTERNAL_GameControllerButtonBind_union
		{
			/// <summary>
			/// The button
			/// </summary>
			[FieldOffset(0)]
			public int button;
			/// <summary>
			/// The axis
			/// </summary>
			[FieldOffset(0)]
			public int axis;
			/// <summary>
			/// The hat
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_GameControllerButtonBind_hat hat;
		}

		/// <summary>
		/// The sdl gamecontrollerbuttonbind
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_GameControllerButtonBind
		{
			/// <summary>
			/// The bind type
			/// </summary>
			public SDL_GameControllerBindType bindType;
			/// <summary>
			/// The value
			/// </summary>
			public INTERNAL_GameControllerButtonBind_union value;
		}

		/* This exists to deal with C# being stupid about blittable types. */
		/// <summary>
		/// The internal sdl gamecontrollerbuttonbind
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		private struct INTERNAL_SDL_GameControllerButtonBind
		{
			/// <summary>
			/// The bind type
			/// </summary>
			public int bindType;
			/* Largest data type in the union is two ints in size */
			/// <summary>
			/// The union val
			/// </summary>
			public int unionVal0;
			/// <summary>
			/// The union val
			/// </summary>
			public int unionVal1;
		}

		/// <summary>
		/// Internals the sdl game controller add mapping using the specified mapping string
		/// </summary>
		/// <param name="mappingString">The mapping string</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_GameControllerAddMapping(
			byte* mappingString
		);
		/// <summary>
		/// Sdls the game controller add mapping using the specified mapping string
		/// </summary>
		/// <param name="mappingString">The mapping string</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_GameControllerAddMapping(
			string mappingString
		) {
			byte* utf8MappingString = Utf8EncodeHeap(mappingString);
			int result = INTERNAL_SDL_GameControllerAddMapping(
				utf8MappingString
			);
			Marshal.FreeHGlobal((IntPtr) utf8MappingString);
			return result;
		}

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Sdls the game controller num mappings
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerNumMappings();

		/* Only available in 2.0.6 or higher. */
		/// <summary>
		/// Internals the sdl game controller mapping for index using the specified mapping index
		/// </summary>
		/// <param name="mapping_index">The mapping index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex(int mapping_index);
		/// <summary>
		/// Sdls the game controller mapping for index using the specified mapping index
		/// </summary>
		/// <param name="mapping_index">The mapping index</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerMappingForIndex(int mapping_index)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerMappingForIndex(
					mapping_index
				),
				true
			);
		}

		/* THIS IS AN RWops FUNCTION! */
		/// <summary>
		/// Internals the sdl game controller add mappings from rw using the specified rw
		/// </summary>
		/// <param name="rw">The rw</param>
		/// <param name="freerw">The freerw</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
		private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(
			IntPtr rw,
			int freerw
		);
		/// <summary>
		/// Sdls the game controller add mappings from file using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <returns>The int</returns>
		public static int SDL_GameControllerAddMappingsFromFile(string file)
		{
			IntPtr rwops = SDL_RWFromFile(file, "rb");
			return INTERNAL_SDL_GameControllerAddMappingsFromRW(rwops, 1);
		}

		/// <summary>
		/// Internals the sdl game controller mapping for guid using the specified guid
		/// </summary>
		/// <param name="guid">The guid</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(
			Guid guid
		);
		/// <summary>
		/// Sdls the game controller mapping for guid using the specified guid
		/// </summary>
		/// <param name="guid">The guid</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerMappingForGUID(Guid guid)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerMappingForGUID(guid),
				true
			);
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Internals the sdl game controller mapping using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerMapping(
			IntPtr gamecontroller
		);
		/// <summary>
		/// Sdls the game controller mapping using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerMapping(
			IntPtr gamecontroller
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerMapping(
					gamecontroller
				),
				true
			);
		}

		/// <summary>
		/// Sdls the is game controller using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsGameController(int joystick_index);

		/// <summary>
		/// Internals the sdl game controller name for index using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex(
			int joystick_index
		);
		/// <summary>
		/// Sdls the game controller name for index using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerNameForIndex(
			int joystick_index
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerNameForIndex(joystick_index)
			);
		}

		/* Only available in 2.0.9 or higher. */
		/// <summary>
		/// Internals the sdl game controller mapping for device index using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerMappingForDeviceIndex(
			int joystick_index
		);
		/// <summary>
		/// Sdls the game controller mapping for device index using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerMappingForDeviceIndex(
			int joystick_index
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystick_index),
				true
			);
		}

		/* IntPtr refers to an SDL_GameController* */
		/// <summary>
		/// Sdls the game controller open using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerOpen(int joystick_index);

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Internals the sdl game controller name using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerName(
			IntPtr gamecontroller
		);
		/// <summary>
		/// Sdls the game controller name using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerName(
			IntPtr gamecontroller
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerName(gamecontroller)
			);
		}

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get vendor using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetVendor(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get product using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetProduct(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.6 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get product version using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The ushort</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort SDL_GameControllerGetProductVersion(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Internals the sdl game controller get serial using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerGetSerial(
			IntPtr gamecontroller
		);
		/// <summary>
		/// Sdls the game controller get serial using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerGetSerial(
			IntPtr gamecontroller
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerGetSerial(gamecontroller)
			);
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Sdls the game controller get attached using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerGetAttached(
			IntPtr gamecontroller
		);

		/* IntPtr refers to an SDL_Joystick*
		 * gamecontroller refers to an SDL_GameController*
		 */
		/// <summary>
		/// Sdls the game controller get joystick using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerGetJoystick(
			IntPtr gamecontroller
		);

		/// <summary>
		/// Sdls the game controller event state using the specified state
		/// </summary>
		/// <param name="state">The state</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerEventState(int state);

		/// <summary>
		/// Sdls the game controller update
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GameControllerUpdate();

		/// <summary>
		/// Internals the sdl game controller get axis from string using the specified pch string
		/// </summary>
		/// <param name="pchString">The pch string</param>
		/// <returns>The sdl game controller axis</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_GameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(
			byte* pchString
		);
		/// <summary>
		/// Sdls the game controller get axis from string using the specified pch string
		/// </summary>
		/// <param name="pchString">The pch string</param>
		/// <returns>The sdl game controller axis</returns>
		public static unsafe SDL_GameControllerAxis SDL_GameControllerGetAxisFromString(
			string pchString
		) {
			int utf8PchStringBufSize = Utf8Size(pchString);
			byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
			return INTERNAL_SDL_GameControllerGetAxisFromString(
				Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
			);
		}

		/// <summary>
		/// Internals the sdl game controller get string for axis using the specified axis
		/// </summary>
		/// <param name="axis">The axis</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(
			SDL_GameControllerAxis axis
		);
		/// <summary>
		/// Sdls the game controller get string for axis using the specified axis
		/// </summary>
		/// <param name="axis">The axis</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerGetStringForAxis(
			SDL_GameControllerAxis axis
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerGetStringForAxis(
					axis
				)
			);
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Internals the sdl game controller get bind for axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The internal sdl game controller button bind</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
		private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		);
		/// <summary>
		/// Sdls the game controller get bind for axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The result</returns>
		public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		) {
			// This is guaranteed to never be null
			INTERNAL_SDL_GameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForAxis(
				gamecontroller,
				axis
			);
			SDL_GameControllerButtonBind result = new SDL_GameControllerButtonBind();
			result.bindType = (SDL_GameControllerBindType) dumb.bindType;
			result.value.hat.hat = dumb.unionVal0;
			result.value.hat.hat_mask = dumb.unionVal1;
			return result;
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Sdls the game controller get axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The short</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern short SDL_GameControllerGetAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		);

		/// <summary>
		/// Internals the sdl game controller get button from string using the specified pch string
		/// </summary>
		/// <param name="pchString">The pch string</param>
		/// <returns>The sdl game controller button</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe SDL_GameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(
			byte* pchString
		);
		/// <summary>
		/// Sdls the game controller get button from string using the specified pch string
		/// </summary>
		/// <param name="pchString">The pch string</param>
		/// <returns>The sdl game controller button</returns>
		public static unsafe SDL_GameControllerButton SDL_GameControllerGetButtonFromString(
			string pchString
		) {
			int utf8PchStringBufSize = Utf8Size(pchString);
			byte* utf8PchString = stackalloc byte[utf8PchStringBufSize];
			return INTERNAL_SDL_GameControllerGetButtonFromString(
				Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
			);
		}

		/// <summary>
		/// Internals the sdl game controller get string for button using the specified button
		/// </summary>
		/// <param name="button">The button</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(
			SDL_GameControllerButton button
		);
		/// <summary>
		/// Sdls the game controller get string for button using the specified button
		/// </summary>
		/// <param name="button">The button</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerGetStringForButton(
			SDL_GameControllerButton button
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerGetStringForButton(button)
			);
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Internals the sdl game controller get bind for button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The internal sdl game controller button bind</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
		private static extern INTERNAL_SDL_GameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		);
		/// <summary>
		/// Sdls the game controller get bind for button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The result</returns>
		public static SDL_GameControllerButtonBind SDL_GameControllerGetBindForButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		) {
			// This is guaranteed to never be null
			INTERNAL_SDL_GameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForButton(
				gamecontroller,
				button
			);
			SDL_GameControllerButtonBind result = new SDL_GameControllerButtonBind();
			result.bindType = (SDL_GameControllerBindType) dumb.bindType;
			result.value.hat.hat = dumb.unionVal0;
			result.value.hat.hat_mask = dumb.unionVal1;
			return result;
		}

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Sdls the game controller get button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The byte</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern byte SDL_GameControllerGetButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.9 or higher.
		 */
		/// <summary>
		/// Sdls the game controller rumble using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="low_frequency_rumble">The low frequency rumble</param>
		/// <param name="high_frequency_rumble">The high frequency rumble</param>
		/// <param name="duration_ms">The duration ms</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerRumble(
			IntPtr gamecontroller,
			UInt16 low_frequency_rumble,
			UInt16 high_frequency_rumble,
			UInt32 duration_ms
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller rumble triggers using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="left_rumble">The left rumble</param>
		/// <param name="right_rumble">The right rumble</param>
		/// <param name="duration_ms">The duration ms</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerRumbleTriggers(
			IntPtr gamecontroller,
			UInt16 left_rumble,
			UInt16 right_rumble,
			UInt32 duration_ms
		);

		/* gamecontroller refers to an SDL_GameController* */
		/// <summary>
		/// Sdls the game controller close using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GameControllerClose(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Internals the sdl game controller get apple sf symbols name for button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		);
		/// <summary>
		/// Sdls the game controller get apple sf symbols name for button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gamecontroller, button)
			);
		}

		/* gamecontroller refers to an SDL_GameController*
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Internals the sdl game controller get apple sf symbols name for axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		);
		/// <summary>
		/// Sdls the game controller get apple sf symbols name for axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The string</returns>
		public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gamecontroller, axis)
			);
		}

		/* int refers to an SDL_JoystickID, IntPtr to an SDL_GameController*.
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the game controller from instance id using the specified joyid
		/// </summary>
		/// <param name="joyid">The joyid</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

		/* Only available in 2.0.11 or higher. */
		/// <summary>
		/// Sdls the game controller type for index using the specified joystick index
		/// </summary>
		/// <param name="joystick_index">The joystick index</param>
		/// <returns>The sdl game controller type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_GameControllerType SDL_GameControllerTypeForIndex(
			int joystick_index
		);

		/* IntPtr refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get type using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The sdl game controller type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_GameControllerType SDL_GameControllerGetType(
			IntPtr gamecontroller
		);

		/* IntPtr refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the game controller from player index using the specified player index
		/// </summary>
		/// <param name="player_index">The player index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GameControllerFromPlayerIndex(
			int player_index
		);

		/* IntPtr refers to an SDL_GameController*.
		 * Only available in 2.0.11 or higher.
		 */
		/// <summary>
		/// Sdls the game controller set player index using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="player_index">The player index</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_GameControllerSetPlayerIndex(
			IntPtr gamecontroller,
			int player_index
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has led using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasLED(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has rumble using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasRumble(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has rumble triggers using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasRumbleTriggers(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller set led using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="red">The red</param>
		/// <param name="green">The green</param>
		/// <param name="blue">The blue</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerSetLED(
			IntPtr gamecontroller,
			byte red,
			byte green,
			byte blue
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has axis using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="axis">The axis</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasAxis(
			IntPtr gamecontroller,
			SDL_GameControllerAxis axis
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has button using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="button">The button</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasButton(
			IntPtr gamecontroller,
			SDL_GameControllerButton button
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get num touchpads using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerGetNumTouchpads(
			IntPtr gamecontroller
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get num touchpad fingers using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="touchpad">The touchpad</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerGetNumTouchpadFingers(
			IntPtr gamecontroller,
			int touchpad
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get touchpad finger using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="touchpad">The touchpad</param>
		/// <param name="finger">The finger</param>
		/// <param name="state">The state</param>
		/// <param name="x">The </param>
		/// <param name="y">The </param>
		/// <param name="pressure">The pressure</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerGetTouchpadFinger(
			IntPtr gamecontroller,
			int touchpad,
			int finger,
			out byte state,
			out float x,
			out float y,
			out float pressure
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller has sensor using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="type">The type</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerHasSensor(
			IntPtr gamecontroller,
			SDL_SensorType type
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller set sensor enabled using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="type">The type</param>
		/// <param name="enabled">The enabled</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerSetSensorEnabled(
			IntPtr gamecontroller,
			SDL_SensorType type,
			SDL_bool enabled
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller is sensor enabled using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="type">The type</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GameControllerIsSensorEnabled(
			IntPtr gamecontroller,
			SDL_SensorType type
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * data refers to a float*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get sensor data using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="type">The type</param>
		/// <param name="data">The data</param>
		/// <param name="num_values">The num values</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerGetSensorData(
			IntPtr gamecontroller,
			SDL_SensorType type,
			IntPtr data,
			int num_values
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the game controller get sensor data rate using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="type">The type</param>
		/// <returns>The float</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern float SDL_GameControllerGetSensorDataRate(
			IntPtr gamecontroller,
			SDL_SensorType type
		);

		/* gamecontroller refers to an SDL_GameController*.
		 * data refers to a const void*.
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the game controller send effect using the specified gamecontroller
		/// </summary>
		/// <param name="gamecontroller">The gamecontroller</param>
		/// <param name="data">The data</param>
		/// <param name="size">The size</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GameControllerSendEffect(
			IntPtr gamecontroller,
			IntPtr data,
			int size
		);

		#endregion

		#region SDL_haptic.h

		/* SDL_HapticEffect type */
		/// <summary>
		/// The sdl haptic constant
		/// </summary>
		public const ushort SDL_HAPTIC_CONSTANT =	(1 << 0);
		/// <summary>
		/// The sdl haptic sine
		/// </summary>
		public const ushort SDL_HAPTIC_SINE =		(1 << 1);
		/// <summary>
		/// The sdl haptic leftright
		/// </summary>
		public const ushort SDL_HAPTIC_LEFTRIGHT =	(1 << 2);
		/// <summary>
		/// The sdl haptic triangle
		/// </summary>
		public const ushort SDL_HAPTIC_TRIANGLE =	(1 << 3);
		/// <summary>
		/// The sdl haptic sawtoothup
		/// </summary>
		public const ushort SDL_HAPTIC_SAWTOOTHUP =	(1 << 4);
		/// <summary>
		/// The sdl haptic sawtoothdown
		/// </summary>
		public const ushort SDL_HAPTIC_SAWTOOTHDOWN =	(1 << 5);
		/// <summary>
		/// The sdl haptic spring
		/// </summary>
		public const ushort SDL_HAPTIC_SPRING =		(1 << 7);
		/// <summary>
		/// The sdl haptic damper
		/// </summary>
		public const ushort SDL_HAPTIC_DAMPER =		(1 << 8);
		/// <summary>
		/// The sdl haptic inertia
		/// </summary>
		public const ushort SDL_HAPTIC_INERTIA =	(1 << 9);
		/// <summary>
		/// The sdl haptic friction
		/// </summary>
		public const ushort SDL_HAPTIC_FRICTION =	(1 << 10);
		/// <summary>
		/// The sdl haptic custom
		/// </summary>
		public const ushort SDL_HAPTIC_CUSTOM =		(1 << 11);
		/// <summary>
		/// The sdl haptic gain
		/// </summary>
		public const ushort SDL_HAPTIC_GAIN =		(1 << 12);
		/// <summary>
		/// The sdl haptic autocenter
		/// </summary>
		public const ushort SDL_HAPTIC_AUTOCENTER =	(1 << 13);
		/// <summary>
		/// The sdl haptic status
		/// </summary>
		public const ushort SDL_HAPTIC_STATUS =		(1 << 14);
		/// <summary>
		/// The sdl haptic pause
		/// </summary>
		public const ushort SDL_HAPTIC_PAUSE =		(1 << 15);

		/* SDL_HapticDirection type */
		/// <summary>
		/// The sdl haptic polar
		/// </summary>
		public const byte SDL_HAPTIC_POLAR =		0;
		/// <summary>
		/// The sdl haptic cartesian
		/// </summary>
		public const byte SDL_HAPTIC_CARTESIAN =	1;
		/// <summary>
		/// The sdl haptic spherical
		/// </summary>
		public const byte SDL_HAPTIC_SPHERICAL =	2;
		/// <summary>
		/// The sdl haptic steering axis
		/// </summary>
		public const byte SDL_HAPTIC_STEERING_AXIS =	3; /* Requires >= 2.0.14 */

		/* SDL_HapticRunEffect */
		/// <summary>
		/// The sdl haptic infinity
		/// </summary>
		public const uint SDL_HAPTIC_INFINITY = 4294967295U;

		/// <summary>
		/// The sdl hapticdirection
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_HapticDirection
		{
			/// <summary>
			/// The type
			/// </summary>
			public byte type;
			/// <summary>
			/// The dir
			/// </summary>
			public fixed int dir[3];
		}

		/// <summary>
		/// The sdl hapticconstant
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_HapticConstant
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			/// <summary>
			/// The direction
			/// </summary>
			public SDL_HapticDirection direction;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			/// <summary>
			/// The delay
			/// </summary>
			public ushort delay;
			// Trigger
			/// <summary>
			/// The button
			/// </summary>
			public ushort button;
			/// <summary>
			/// The interval
			/// </summary>
			public ushort interval;
			// Constant
			/// <summary>
			/// The level
			/// </summary>
			public short level;
			// Envelope
			/// <summary>
			/// The attack length
			/// </summary>
			public ushort attack_length;
			/// <summary>
			/// The attack level
			/// </summary>
			public ushort attack_level;
			/// <summary>
			/// The fade length
			/// </summary>
			public ushort fade_length;
			/// <summary>
			/// The fade level
			/// </summary>
			public ushort fade_level;
		}

		/// <summary>
		/// The sdl hapticperiodic
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_HapticPeriodic
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			/// <summary>
			/// The direction
			/// </summary>
			public SDL_HapticDirection direction;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			/// <summary>
			/// The delay
			/// </summary>
			public ushort delay;
			// Trigger
			/// <summary>
			/// The button
			/// </summary>
			public ushort button;
			/// <summary>
			/// The interval
			/// </summary>
			public ushort interval;
			// Periodic
			/// <summary>
			/// The period
			/// </summary>
			public ushort period;
			/// <summary>
			/// The magnitude
			/// </summary>
			public short magnitude;
			/// <summary>
			/// The offset
			/// </summary>
			public short offset;
			/// <summary>
			/// The phase
			/// </summary>
			public ushort phase;
			// Envelope
			/// <summary>
			/// The attack length
			/// </summary>
			public ushort attack_length;
			/// <summary>
			/// The attack level
			/// </summary>
			public ushort attack_level;
			/// <summary>
			/// The fade length
			/// </summary>
			public ushort fade_length;
			/// <summary>
			/// The fade level
			/// </summary>
			public ushort fade_level;
		}

		/// <summary>
		/// The sdl hapticcondition
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public unsafe struct SDL_HapticCondition
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			/// <summary>
			/// The direction
			/// </summary>
			public SDL_HapticDirection direction;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			/// <summary>
			/// The delay
			/// </summary>
			public ushort delay;
			// Trigger
			/// <summary>
			/// The button
			/// </summary>
			public ushort button;
			/// <summary>
			/// The interval
			/// </summary>
			public ushort interval;
			// Condition
			/// <summary>
			/// The right sat
			/// </summary>
			public fixed ushort right_sat[3];
			/// <summary>
			/// The left sat
			/// </summary>
			public fixed ushort left_sat[3];
			/// <summary>
			/// The right coeff
			/// </summary>
			public fixed short right_coeff[3];
			/// <summary>
			/// The left coeff
			/// </summary>
			public fixed short left_coeff[3];
			/// <summary>
			/// The deadband
			/// </summary>
			public fixed ushort deadband[3];
			/// <summary>
			/// The center
			/// </summary>
			public fixed short center[3];
		}

		/// <summary>
		/// The sdl hapticramp
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_HapticRamp
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			/// <summary>
			/// The direction
			/// </summary>
			public SDL_HapticDirection direction;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			/// <summary>
			/// The delay
			/// </summary>
			public ushort delay;
			// Trigger
			/// <summary>
			/// The button
			/// </summary>
			public ushort button;
			/// <summary>
			/// The interval
			/// </summary>
			public ushort interval;
			// Ramp
			/// <summary>
			/// The start
			/// </summary>
			public short start;
			/// <summary>
			/// The end
			/// </summary>
			public short end;
			// Envelope
			/// <summary>
			/// The attack length
			/// </summary>
			public ushort attack_length;
			/// <summary>
			/// The attack level
			/// </summary>
			public ushort attack_level;
			/// <summary>
			/// The fade length
			/// </summary>
			public ushort fade_length;
			/// <summary>
			/// The fade level
			/// </summary>
			public ushort fade_level;
		}

		/// <summary>
		/// The sdl hapticleftright
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_HapticLeftRight
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			// Rumble
			/// <summary>
			/// The large magnitude
			/// </summary>
			public ushort large_magnitude;
			/// <summary>
			/// The small magnitude
			/// </summary>
			public ushort small_magnitude;
		}

		/// <summary>
		/// The sdl hapticcustom
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_HapticCustom
		{
			// Header
			/// <summary>
			/// The type
			/// </summary>
			public ushort type;
			/// <summary>
			/// The direction
			/// </summary>
			public SDL_HapticDirection direction;
			// Replay
			/// <summary>
			/// The length
			/// </summary>
			public uint length;
			/// <summary>
			/// The delay
			/// </summary>
			public ushort delay;
			// Trigger
			/// <summary>
			/// The button
			/// </summary>
			public ushort button;
			/// <summary>
			/// The interval
			/// </summary>
			public ushort interval;
			// Custom
			/// <summary>
			/// The channels
			/// </summary>
			public byte channels;
			/// <summary>
			/// The period
			/// </summary>
			public ushort period;
			/// <summary>
			/// The samples
			/// </summary>
			public ushort samples;
			/// <summary>
			/// The data
			/// </summary>
			public IntPtr data; // Uint16*
			// Envelope
			/// <summary>
			/// The attack length
			/// </summary>
			public ushort attack_length;
			/// <summary>
			/// The attack level
			/// </summary>
			public ushort attack_level;
			/// <summary>
			/// The fade length
			/// </summary>
			public ushort fade_length;
			/// <summary>
			/// The fade level
			/// </summary>
			public ushort fade_level;
		}

		/// <summary>
		/// The sdl hapticeffect
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct SDL_HapticEffect
		{
			/// <summary>
			/// The type
			/// </summary>
			[FieldOffset(0)]
			public ushort type;
			/// <summary>
			/// The constant
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticConstant constant;
			/// <summary>
			/// The periodic
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticPeriodic periodic;
			/// <summary>
			/// The condition
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticCondition condition;
			/// <summary>
			/// The ramp
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticRamp ramp;
			/// <summary>
			/// The leftright
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticLeftRight leftright;
			/// <summary>
			/// The custom
			/// </summary>
			[FieldOffset(0)]
			public SDL_HapticCustom custom;
		}

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic close using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HapticClose(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic destroy effect using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HapticDestroyEffect(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic effect supported using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticEffectSupported(
			IntPtr haptic,
			ref SDL_HapticEffect effect
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic get effect status using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticGetEffectStatus(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic index using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticIndex(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Internals the sdl haptic name using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_HapticName(int device_index);
		/// <summary>
		/// Sdls the haptic name using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The string</returns>
		public static string SDL_HapticName(int device_index)
		{
			return UTF8_ToManaged(INTERNAL_SDL_HapticName(device_index));
		}

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic new effect using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNewEffect(
			IntPtr haptic,
			ref SDL_HapticEffect effect
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic num axes using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumAxes(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic num effects using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumEffects(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic num effects playing using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

		/* IntPtr refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic open using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpen(int device_index);

		/// <summary>
		/// Sdls the haptic opened using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticOpened(int device_index);

		/* IntPtr refers to an SDL_Haptic*, joystick to an SDL_Joystick* */
		/// <summary>
		/// Sdls the haptic open from joystick using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpenFromJoystick(
			IntPtr joystick
		);

		/* IntPtr refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic open from mouse
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_HapticOpenFromMouse();

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic pause using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticPause(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic query using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_HapticQuery(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic rumble init using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleInit(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic rumble play using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="strength">The strength</param>
		/// <param name="length">The length</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumblePlay(
			IntPtr haptic,
			float strength,
			uint length
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic rumble stop using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleStop(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic rumble supported using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic run effect using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <param name="iterations">The iterations</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticRunEffect(
			IntPtr haptic,
			int effect,
			uint iterations
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic set autocenter using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="autocenter">The autocenter</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticSetAutocenter(
			IntPtr haptic,
			int autocenter
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic set gain using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="gain">The gain</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticSetGain(
			IntPtr haptic,
			int gain
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic stop all using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticStopAll(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic stop effect using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticStopEffect(
			IntPtr haptic,
			int effect
		);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic unpause using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticUnpause(IntPtr haptic);

		/* haptic refers to an SDL_Haptic* */
		/// <summary>
		/// Sdls the haptic update effect using the specified haptic
		/// </summary>
		/// <param name="haptic">The haptic</param>
		/// <param name="effect">The effect</param>
		/// <param name="data">The data</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_HapticUpdateEffect(
			IntPtr haptic,
			int effect,
			ref SDL_HapticEffect data
		);

		/* joystick refers to an SDL_Joystick* */
		/// <summary>
		/// Sdls the joystick is haptic using the specified joystick
		/// </summary>
		/// <param name="joystick">The joystick</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

		/// <summary>
		/// Sdls the mouse is haptic
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_MouseIsHaptic();

		/// <summary>
		/// Sdls the num haptics
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_NumHaptics();

		#endregion

		#region SDL_sensor.h

		/* This region is only available in 2.0.9 or higher. */

		/// <summary>
		/// The sdl sensortype enum
		/// </summary>
		public enum SDL_SensorType
		{
			/// <summary>
			/// The sdl sensor invalid sdl sensortype
			/// </summary>
			SDL_SENSOR_INVALID = -1,
			/// <summary>
			/// The sdl sensor unknown sdl sensortype
			/// </summary>
			SDL_SENSOR_UNKNOWN,
			/// <summary>
			/// The sdl sensor accel sdl sensortype
			/// </summary>
			SDL_SENSOR_ACCEL,
			/// <summary>
			/// The sdl sensor gyro sdl sensortype
			/// </summary>
			SDL_SENSOR_GYRO
		}

		/// <summary>
		/// The sdl standard gravity
		/// </summary>
		public const float SDL_STANDARD_GRAVITY = 9.80665f;

		/// <summary>
		/// Sdls the num sensors
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_NumSensors();

		/// <summary>
		/// Internals the sdl sensor get device name using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_SensorGetDeviceName(int device_index);
		/// <summary>
		/// Sdls the sensor get device name using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The string</returns>
		public static string SDL_SensorGetDeviceName(int device_index)
		{
			return UTF8_ToManaged(INTERNAL_SDL_SensorGetDeviceName(device_index));
		}

		/// <summary>
		/// Sdls the sensor get device type using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The sdl sensor type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_SensorType SDL_SensorGetDeviceType(int device_index);

		/// <summary>
		/// Sdls the sensor get device non portable type using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SensorGetDeviceNonPortableType(int device_index);

		/// <summary>
		/// Sdls the sensor get device instance id using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern Int32 SDL_SensorGetDeviceInstanceID(int device_index);

		/* IntPtr refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor open using the specified device index
		/// </summary>
		/// <param name="device_index">The device index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_SensorOpen(int device_index);

		/* IntPtr refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor from instance id using the specified instance id
		/// </summary>
		/// <param name="instance_id">The instance id</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_SensorFromInstanceID(
			Int32 instance_id
		);

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Internals the sdl sensor get name using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_SensorGetName(IntPtr sensor);
		/// <summary>
		/// Sdls the sensor get name using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <returns>The string</returns>
		public static string SDL_SensorGetName(IntPtr sensor)
		{
			return UTF8_ToManaged(INTERNAL_SDL_SensorGetName(sensor));
		}

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor get type using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <returns>The sdl sensor type</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_SensorType SDL_SensorGetType(IntPtr sensor);

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor get non portable type using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor get instance id using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern Int32 SDL_SensorGetInstanceID(IntPtr sensor);

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor get data using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		/// <param name="data">The data</param>
		/// <param name="num_values">The num values</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_SensorGetData(
			IntPtr sensor,
			float[] data,
			int num_values
		);

		/* sensor refers to an SDL_Sensor* */
		/// <summary>
		/// Sdls the sensor close using the specified sensor
		/// </summary>
		/// <param name="sensor">The sensor</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SensorClose(IntPtr sensor);

		/// <summary>
		/// Sdls the sensor update
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SensorUpdate();

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Sdls the lock sensors
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockSensors();

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Sdls the unlock sensors
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockSensors();

		#endregion

		#region SDL_audio.h

		/// <summary>
		/// The sdl audio mask bitsize
		/// </summary>
		public const ushort SDL_AUDIO_MASK_BITSIZE =	0xFF;
		/// <summary>
		/// The sdl audio mask datatype
		/// </summary>
		public const ushort SDL_AUDIO_MASK_DATATYPE =	(1 << 8);
		/// <summary>
		/// The sdl audio mask endian
		/// </summary>
		public const ushort SDL_AUDIO_MASK_ENDIAN =	(1 << 12);
		/// <summary>
		/// The sdl audio mask signed
		/// </summary>
		public const ushort SDL_AUDIO_MASK_SIGNED =	(1 << 15);

		/// <summary>
		/// Sdls the audio bitsize using the specified x
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The ushort</returns>
		public static ushort SDL_AUDIO_BITSIZE(ushort x)
		{
			return (ushort) (x & SDL_AUDIO_MASK_BITSIZE);
		}

		/// <summary>
		/// Describes whether sdl audio isfloat
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISFLOAT(ushort x)
		{
			return (x & SDL_AUDIO_MASK_DATATYPE) != 0;
		}

		/// <summary>
		/// Describes whether sdl audio isbigendian
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISBIGENDIAN(ushort x)
		{
			return (x & SDL_AUDIO_MASK_ENDIAN) != 0;
		}

		/// <summary>
		/// Describes whether sdl audio issigned
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISSIGNED(ushort x)
		{
			return (x & SDL_AUDIO_MASK_SIGNED) != 0;
		}

		/// <summary>
		/// Describes whether sdl audio isint
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISINT(ushort x)
		{
			return (x & SDL_AUDIO_MASK_DATATYPE) == 0;
		}

		/// <summary>
		/// Describes whether sdl audio islittleendian
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x)
		{
			return (x & SDL_AUDIO_MASK_ENDIAN) == 0;
		}

		/// <summary>
		/// Describes whether sdl audio isunsigned
		/// </summary>
		/// <param name="x">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_AUDIO_ISUNSIGNED(ushort x)
		{
			return (x & SDL_AUDIO_MASK_SIGNED) == 0;
		}

		/// <summary>
		/// The audio u8
		/// </summary>
		public const ushort AUDIO_U8 =		0x0008;
		/// <summary>
		/// The audio s8
		/// </summary>
		public const ushort AUDIO_S8 =		0x8008;
		/// <summary>
		/// The audio u16lsb
		/// </summary>
		public const ushort AUDIO_U16LSB =	0x0010;
		/// <summary>
		/// The audio s16lsb
		/// </summary>
		public const ushort AUDIO_S16LSB =	0x8010;
		/// <summary>
		/// The audio u16msb
		/// </summary>
		public const ushort AUDIO_U16MSB =	0x1010;
		/// <summary>
		/// The audio s16msb
		/// </summary>
		public const ushort AUDIO_S16MSB =	0x9010;
		/// <summary>
		/// The audio u16lsb
		/// </summary>
		public const ushort AUDIO_U16 =		AUDIO_U16LSB;
		/// <summary>
		/// The audio s16lsb
		/// </summary>
		public const ushort AUDIO_S16 =		AUDIO_S16LSB;
		/// <summary>
		/// The audio s32lsb
		/// </summary>
		public const ushort AUDIO_S32LSB =	0x8020;
		/// <summary>
		/// The audio s32msb
		/// </summary>
		public const ushort AUDIO_S32MSB =	0x9020;
		/// <summary>
		/// The audio s32lsb
		/// </summary>
		public const ushort AUDIO_S32 =		AUDIO_S32LSB;
		/// <summary>
		/// The audio f32lsb
		/// </summary>
		public const ushort AUDIO_F32LSB =	0x8120;
		/// <summary>
		/// The audio f32msb
		/// </summary>
		public const ushort AUDIO_F32MSB =	0x9120;
		/// <summary>
		/// The audio f32lsb
		/// </summary>
		public const ushort AUDIO_F32 =		AUDIO_F32LSB;

		/// <summary>
		/// The audio u16msb
		/// </summary>
		public static readonly ushort AUDIO_U16SYS =
			BitConverter.IsLittleEndian ? AUDIO_U16LSB : AUDIO_U16MSB;
		/// <summary>
		/// The audio s16msb
		/// </summary>
		public static readonly ushort AUDIO_S16SYS =
			BitConverter.IsLittleEndian ? AUDIO_S16LSB : AUDIO_S16MSB;
		/// <summary>
		/// The audio s32msb
		/// </summary>
		public static readonly ushort AUDIO_S32SYS =
			BitConverter.IsLittleEndian ? AUDIO_S32LSB : AUDIO_S32MSB;
		/// <summary>
		/// The audio f32msb
		/// </summary>
		public static readonly ushort AUDIO_F32SYS =
			BitConverter.IsLittleEndian ? AUDIO_F32LSB : AUDIO_F32MSB;

		/// <summary>
		/// The sdl audio allow frequency change
		/// </summary>
		public const uint SDL_AUDIO_ALLOW_FREQUENCY_CHANGE =	0x00000001;
		/// <summary>
		/// The sdl audio allow format change
		/// </summary>
		public const uint SDL_AUDIO_ALLOW_FORMAT_CHANGE =	0x00000002;
		/// <summary>
		/// The sdl audio allow channels change
		/// </summary>
		public const uint SDL_AUDIO_ALLOW_CHANNELS_CHANGE =	0x00000004;
		/// <summary>
		/// The sdl audio allow samples change
		/// </summary>
		public const uint SDL_AUDIO_ALLOW_SAMPLES_CHANGE =	0x00000008;
		/// <summary>
		/// The sdl audio allow samples change
		/// </summary>
		public const uint SDL_AUDIO_ALLOW_ANY_CHANGE = (
			SDL_AUDIO_ALLOW_FREQUENCY_CHANGE |
			SDL_AUDIO_ALLOW_FORMAT_CHANGE |
			SDL_AUDIO_ALLOW_CHANNELS_CHANGE |
			SDL_AUDIO_ALLOW_SAMPLES_CHANGE
		);

		/// <summary>
		/// The sdl mix maxvolume
		/// </summary>
		public const int SDL_MIX_MAXVOLUME = 128;

		/// <summary>
		/// The sdl audiostatus enum
		/// </summary>
		public enum SDL_AudioStatus
		{
			/// <summary>
			/// The sdl audio stopped sdl audiostatus
			/// </summary>
			SDL_AUDIO_STOPPED,
			/// <summary>
			/// The sdl audio playing sdl audiostatus
			/// </summary>
			SDL_AUDIO_PLAYING,
			/// <summary>
			/// The sdl audio paused sdl audiostatus
			/// </summary>
			SDL_AUDIO_PAUSED
		}

		/// <summary>
		/// The sdl audiospec
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_AudioSpec
		{
			/// <summary>
			/// The freq
			/// </summary>
			public int freq;
			/// <summary>
			/// The format
			/// </summary>
			public ushort format; // SDL_AudioFormat
			/// <summary>
			/// The channels
			/// </summary>
			public byte channels;
			/// <summary>
			/// The silence
			/// </summary>
			public byte silence;
			/// <summary>
			/// The samples
			/// </summary>
			public ushort samples;
			/// <summary>
			/// The size
			/// </summary>
			public uint size;
			/// <summary>
			/// The callback
			/// </summary>
			public SDL_AudioCallback callback;
			/// <summary>
			/// The userdata
			/// </summary>
			public IntPtr userdata; // void*
		}

		/* userdata refers to a void*, stream to a Uint8 */
		/// <summary>
		/// The sdl audiocallback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SDL_AudioCallback(
			IntPtr userdata,
			IntPtr stream,
			int len
		);

		/// <summary>
		/// Internals the sdl audio init using the specified driver name
		/// </summary>
		/// <param name="driver_name">The driver name</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe int INTERNAL_SDL_AudioInit(
			byte* driver_name
		);
		/// <summary>
		/// Sdls the audio init using the specified driver name
		/// </summary>
		/// <param name="driver_name">The driver name</param>
		/// <returns>The int</returns>
		public static unsafe int SDL_AudioInit(string driver_name)
		{
			int utf8DriverNameBufSize = Utf8Size(driver_name);
			byte* utf8DriverName = stackalloc byte[utf8DriverNameBufSize];
			return INTERNAL_SDL_AudioInit(
				Utf8Encode(driver_name, utf8DriverName, utf8DriverNameBufSize)
			);
		}

		/// <summary>
		/// Sdls the audio quit
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AudioQuit();

		/// <summary>
		/// Sdls the close audio
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CloseAudio();

		/* dev refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Sdls the close audio device using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_CloseAudioDevice(uint dev);

		/* audio_buf refers to a malloc()'d buffer from SDL_LoadWAV */
		/// <summary>
		/// Sdls the free wav using the specified audio buf
		/// </summary>
		/// <param name="audio_buf">The audio buf</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeWAV(IntPtr audio_buf);

		/// <summary>
		/// Internals the sdl get audio device name using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <param name="iscapture">The iscapture</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName(
			int index,
			int iscapture
		);
		/// <summary>
		/// Sdls the get audio device name using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <param name="iscapture">The iscapture</param>
		/// <returns>The string</returns>
		public static string SDL_GetAudioDeviceName(
			int index,
			int iscapture
		) {
			return UTF8_ToManaged(
				INTERNAL_SDL_GetAudioDeviceName(index, iscapture)
			);
		}

		/* dev refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Sdls the get audio device status using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		/// <returns>The sdl audio status</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_AudioStatus SDL_GetAudioDeviceStatus(
			uint dev
		);

		/// <summary>
		/// Internals the sdl get audio driver using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetAudioDriver(int index);
		/// <summary>
		/// Sdls the get audio driver using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <returns>The string</returns>
		public static string SDL_GetAudioDriver(int index)
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_GetAudioDriver(index)
			);
		}

		/// <summary>
		/// Sdls the get audio status
		/// </summary>
		/// <returns>The sdl audio status</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_AudioStatus SDL_GetAudioStatus();

		/// <summary>
		/// Internals the sdl get current audio driver
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();
		/// <summary>
		/// Sdls the get current audio driver
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetCurrentAudioDriver()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetCurrentAudioDriver());
		}

		/// <summary>
		/// Sdls the get num audio devices using the specified iscapture
		/// </summary>
		/// <param name="iscapture">The iscapture</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumAudioDevices(int iscapture);

		/// <summary>
		/// Sdls the get num audio drivers
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetNumAudioDrivers();

		/* audio_buf refers to a malloc()'d buffer, IntPtr to an SDL_AudioSpec* */
		/* THIS IS AN RWops FUNCTION! */
		/// <summary>
		/// Internals the sdl load wav rw using the specified src
		/// </summary>
		/// <param name="src">The src</param>
		/// <param name="freesrc">The freesrc</param>
		/// <param name="spec">The spec</param>
		/// <param name="audio_buf">The audio buf</param>
		/// <param name="audio_len">The audio len</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(
			IntPtr src,
			int freesrc,
			out SDL_AudioSpec spec,
			out IntPtr audio_buf,
			out uint audio_len
		);
		/// <summary>
		/// Sdls the load wav using the specified file
		/// </summary>
		/// <param name="file">The file</param>
		/// <param name="spec">The spec</param>
		/// <param name="audio_buf">The audio buf</param>
		/// <param name="audio_len">The audio len</param>
		/// <returns>The int ptr</returns>
		public static IntPtr SDL_LoadWAV(
			string file,
			out SDL_AudioSpec spec,
			out IntPtr audio_buf,
			out uint audio_len
		) {
			IntPtr rwops = SDL_RWFromFile(file, "rb");
			return INTERNAL_SDL_LoadWAV_RW(
				rwops,
				1,
				out spec,
				out audio_buf,
				out audio_len
			);
		}

		/// <summary>
		/// Sdls the lock audio
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockAudio();

		/* dev refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Sdls the lock audio device using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_LockAudioDevice(uint dev);

		/// <summary>
		/// Sdls the mix audio using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="src">The src</param>
		/// <param name="len">The len</param>
		/// <param name="volume">The volume</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MixAudio(
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
				byte[] dst,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
				byte[] src,
			uint len,
			int volume
		);

		/* format refers to an SDL_AudioFormat */
		/* This overload allows raw pointers to be passed for dst and src. */
		/// <summary>
		/// Sdls the mix audio format using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="src">The src</param>
		/// <param name="format">The format</param>
		/// <param name="len">The len</param>
		/// <param name="volume">The volume</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MixAudioFormat(
			IntPtr dst,
			IntPtr src,
			ushort format,
			uint len,
			int volume
		);

		/* format refers to an SDL_AudioFormat */
		/// <summary>
		/// Sdls the mix audio format using the specified dst
		/// </summary>
		/// <param name="dst">The dst</param>
		/// <param name="src">The src</param>
		/// <param name="format">The format</param>
		/// <param name="len">The len</param>
		/// <param name="volume">The volume</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_MixAudioFormat(
			[Out()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
				byte[] dst,
			[In()] [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
				byte[] src,
			ushort format,
			uint len,
			int volume
		);

		/// <summary>
		/// Sdls the open audio using the specified desired
		/// </summary>
		/// <param name="desired">The desired</param>
		/// <param name="obtained">The obtained</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_OpenAudio(
			ref SDL_AudioSpec desired,
			out SDL_AudioSpec obtained
		);

		/// <summary>
		/// Sdls the open audio using the specified desired
		/// </summary>
		/// <param name="desired">The desired</param>
		/// <param name="obtained">The obtained</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_OpenAudio(
			ref SDL_AudioSpec desired,
			IntPtr obtained
		);

		/* uint refers to an SDL_AudioDeviceID */
		/* This overload allows for IntPtr.Zero (null) to be passed for device. */
		/// <summary>
		/// Sdls the open audio device using the specified device
		/// </summary>
		/// <param name="device">The device</param>
		/// <param name="iscapture">The iscapture</param>
		/// <param name="desired">The desired</param>
		/// <param name="obtained">The obtained</param>
		/// <param name="allowed_changes">The allowed changes</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern unsafe uint SDL_OpenAudioDevice(
			IntPtr device,
			int iscapture,
			ref SDL_AudioSpec desired,
			out SDL_AudioSpec obtained,
			int allowed_changes
		);

		/* uint refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Internals the sdl open audio device using the specified device
		/// </summary>
		/// <param name="device">The device</param>
		/// <param name="iscapture">The iscapture</param>
		/// <param name="desired">The desired</param>
		/// <param name="obtained">The obtained</param>
		/// <param name="allowed_changes">The allowed changes</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe uint INTERNAL_SDL_OpenAudioDevice(
			byte* device,
			int iscapture,
			ref SDL_AudioSpec desired,
			out SDL_AudioSpec obtained,
			int allowed_changes
		);
		/// <summary>
		/// Sdls the open audio device using the specified device
		/// </summary>
		/// <param name="device">The device</param>
		/// <param name="iscapture">The iscapture</param>
		/// <param name="desired">The desired</param>
		/// <param name="obtained">The obtained</param>
		/// <param name="allowed_changes">The allowed changes</param>
		/// <returns>The uint</returns>
		public static unsafe uint SDL_OpenAudioDevice(
			string device,
			int iscapture,
			ref SDL_AudioSpec desired,
			out SDL_AudioSpec obtained,
			int allowed_changes
		) {
			int utf8DeviceBufSize = Utf8Size(device);
			byte* utf8Device = stackalloc byte[utf8DeviceBufSize];
			return INTERNAL_SDL_OpenAudioDevice(
				Utf8Encode(device, utf8Device, utf8DeviceBufSize),
				iscapture,
				ref desired,
				out obtained,
				allowed_changes
			);
		}

		/// <summary>
		/// Sdls the pause audio using the specified pause on
		/// </summary>
		/// <param name="pause_on">The pause on</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PauseAudio(int pause_on);

		/* dev refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Sdls the pause audio device using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		/// <param name="pause_on">The pause on</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_PauseAudioDevice(
			uint dev,
			int pause_on
		);

		/// <summary>
		/// Sdls the unlock audio
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockAudio();

		/* dev refers to an SDL_AudioDeviceID */
		/// <summary>
		/// Sdls the unlock audio device using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_UnlockAudioDevice(uint dev);

		/* dev refers to an SDL_AudioDeviceID, data to a void*
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the queue audio using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		/// <param name="data">The data</param>
		/// <param name="len">The len</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_QueueAudio(
			uint dev,
			IntPtr data,
			UInt32 len
		);

		/* dev refers to an SDL_AudioDeviceID, data to a void*
		 * Only available in 2.0.5 or higher.
		 */
		/// <summary>
		/// Sdls the dequeue audio using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		/// <param name="data">The data</param>
		/// <param name="len">The len</param>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_DequeueAudio(
			uint dev,
			IntPtr data,
			uint len
		);

		/* dev refers to an SDL_AudioDeviceID
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the get queued audio size using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetQueuedAudioSize(uint dev);

		/* dev refers to an SDL_AudioDeviceID
		 * Only available in 2.0.4 or higher.
		 */
		/// <summary>
		/// Sdls the clear queued audio using the specified dev
		/// </summary>
		/// <param name="dev">The dev</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_ClearQueuedAudio(uint dev);

		/* src_format and dst_format refer to SDL_AudioFormats.
		 * IntPtr refers to an SDL_AudioStream*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the new audio stream using the specified src format
		/// </summary>
		/// <param name="src_format">The src format</param>
		/// <param name="src_channels">The src channels</param>
		/// <param name="src_rate">The src rate</param>
		/// <param name="dst_format">The dst format</param>
		/// <param name="dst_channels">The dst channels</param>
		/// <param name="dst_rate">The dst rate</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_NewAudioStream(
			ushort src_format,
			byte src_channels,
			int src_rate,
			ushort dst_format,
			byte dst_channels,
			int dst_rate
		);

		/* stream refers to an SDL_AudioStream*, buf to a void*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the audio stream put using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <param name="buf">The buf</param>
		/// <param name="len">The len</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AudioStreamPut(
			IntPtr stream,
			IntPtr buf,
			int len
		);

		/* stream refers to an SDL_AudioStream*, buf to a void*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the audio stream get using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <param name="buf">The buf</param>
		/// <param name="len">The len</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AudioStreamGet(
			IntPtr stream,
			IntPtr buf,
			int len
		);

		/* stream refers to an SDL_AudioStream*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the audio stream available using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AudioStreamAvailable(IntPtr stream);

		/* stream refers to an SDL_AudioStream*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the audio stream clear using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AudioStreamClear(IntPtr stream);

		/* stream refers to an SDL_AudioStream*.
		 * Only available in 2.0.7 or higher.
		 */
		/// <summary>
		/// Sdls the free audio stream using the specified stream
		/// </summary>
		/// <param name="stream">The stream</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_FreeAudioStream(IntPtr stream);

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// Sdls the get audio device spec using the specified index
		/// </summary>
		/// <param name="index">The index</param>
		/// <param name="iscapture">The iscapture</param>
		/// <param name="spec">The spec</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetAudioDeviceSpec(
			int index,
			int iscapture,
			out SDL_AudioSpec spec
		);

		#endregion

		#region SDL_timer.h

		/* System timers rely on different OS mechanisms depending on
		 * which operating system SDL2 is compiled against.
		 */

		/* Compare tick values, return true if A has passed B. Introduced in SDL 2.0.1,
		 * but does not require it (it was a macro).
		 */
		/// <summary>
		/// Describes whether sdl ticks passed
		/// </summary>
		/// <param name="A">The </param>
		/// <param name="B">The </param>
		/// <returns>The bool</returns>
		public static bool SDL_TICKS_PASSED(UInt32 A, UInt32 B)
		{
			return ((Int32)(B - A) <= 0);
		}

		/* Delays the thread's processing based on the milliseconds parameter */
		/// <summary>
		/// Sdls the delay using the specified ms
		/// </summary>
		/// <param name="ms">The ms</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_Delay(UInt32 ms);

		/* Returns the milliseconds that have passed since SDL was initialized */
		/// <summary>
		/// Sdls the get ticks
		/// </summary>
		/// <returns>The int 32</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt32 SDL_GetTicks();

		/* Returns the milliseconds that have passed since SDL was initialized
		 * Only available in 2.0.18 or higher.
		 */
		/// <summary>
		/// Sdls the get ticks 64
		/// </summary>
		/// <returns>The int 64</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt64 SDL_GetTicks64();

		/* Get the current value of the high resolution counter */
		/// <summary>
		/// Sdls the get performance counter
		/// </summary>
		/// <returns>The int 64</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt64 SDL_GetPerformanceCounter();

		/* Get the count per second of the high resolution counter */
		/// <summary>
		/// Sdls the get performance frequency
		/// </summary>
		/// <returns>The int 64</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern UInt64 SDL_GetPerformanceFrequency();

		/* param refers to a void* */
		/// <summary>
		/// The sdl timercallback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate UInt32 SDL_TimerCallback(UInt32 interval, IntPtr param);

		/* int refers to an SDL_TimerID, param to a void* */
		/// <summary>
		/// Sdls the add timer using the specified interval
		/// </summary>
		/// <param name="interval">The interval</param>
		/// <param name="callback">The callback</param>
		/// <param name="param">The param</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AddTimer(
			UInt32 interval,
			SDL_TimerCallback callback,
			IntPtr param
		);

		/* id refers to an SDL_TimerID */
		/// <summary>
		/// Sdls the remove timer using the specified id
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_RemoveTimer(int id);

		#endregion

		#region SDL_system.h

		/* Windows */

		/// <summary>
		/// The sdl windowsmessagehook
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate IntPtr SDL_WindowsMessageHook(
			IntPtr userdata,
			IntPtr hWnd,
			uint message,
			ulong wParam,
			long lParam
		);

		/// <summary>
		/// Sdls the set windows message hook using the specified callback
		/// </summary>
		/// <param name="callback">The callback</param>
		/// <param name="userdata">The userdata</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SetWindowsMessageHook(
			SDL_WindowsMessageHook callback,
			IntPtr userdata
		);

		/* renderer refers to an SDL_Renderer*
		 * IntPtr refers to an IDirect3DDevice9*
		 * Only available in 2.0.1 or higher.
		 */
		/// <summary>
		/// Sdls the render get d 3 d 9 device using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RenderGetD3D9Device(IntPtr renderer);

		/* renderer refers to an SDL_Renderer*
		 * IntPtr refers to an ID3D11Device*
		 * Only available in 2.0.16 or higher.
		 */
		/// <summary>
		/// Sdls the render get d 3 d 11 device using the specified renderer
		/// </summary>
		/// <param name="renderer">The renderer</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_RenderGetD3D11Device(IntPtr renderer);

		/* iOS */

		/// <summary>
		/// The sdl iphoneanimationcallback
		/// </summary>
		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void SDL_iPhoneAnimationCallback(IntPtr p);

		/// <summary>
		/// Sdls the i phone set animation callback using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="interval">The interval</param>
		/// <param name="callback">The callback</param>
		/// <param name="callbackParam">The callback param</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_iPhoneSetAnimationCallback(
			IntPtr window, /* SDL_Window* */
			int interval,
			SDL_iPhoneAnimationCallback callback,
			IntPtr callbackParam
		);

		/// <summary>
		/// Sdls the i phone set event pump using the specified enabled
		/// </summary>
		/// <param name="enabled">The enabled</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_iPhoneSetEventPump(SDL_bool enabled);

		/* Android */

		/// <summary>
		/// The sdl android external storage read
		/// </summary>
		public const int SDL_ANDROID_EXTERNAL_STORAGE_READ = 0x01;
		/// <summary>
		/// The sdl android external storage write
		/// </summary>
		public const int SDL_ANDROID_EXTERNAL_STORAGE_WRITE = 0x02;

		/* IntPtr refers to a JNIEnv* */
		/// <summary>
		/// Sdls the android get jni env
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AndroidGetJNIEnv();

		/* IntPtr refers to a jobject */
		/// <summary>
		/// Sdls the android get activity
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_AndroidGetActivity();

		/// <summary>
		/// Sdls the is android tv
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsAndroidTV();

		/// <summary>
		/// Sdls the is chromebook
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsChromebook();

		/// <summary>
		/// Sdls the is de x mode
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsDeXMode();

		/// <summary>
		/// Sdls the android back button
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_AndroidBackButton();

		/// <summary>
		/// Internals the sdl android get internal storage path
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_AndroidGetInternalStoragePath();

		/// <summary>
		/// Sdls the android get internal storage path
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_AndroidGetInternalStoragePath()
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_AndroidGetInternalStoragePath()
			);
		}

		/// <summary>
		/// Sdls the android get external storage state
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_AndroidGetExternalStorageState();

		/// <summary>
		/// Internals the sdl android get external storage path
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_AndroidGetExternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_AndroidGetExternalStoragePath();

		/// <summary>
		/// Sdls the android get external storage path
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_AndroidGetExternalStoragePath()
		{
			return UTF8_ToManaged(
				INTERNAL_SDL_AndroidGetExternalStoragePath()
			);
		}

		/// <summary>
		/// Sdls the get android sdk version
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetAndroidSDKVersion();

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Internals the sdl android request permission using the specified permission
		/// </summary>
		/// <param name="permission">The permission</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_AndroidRequestPermission", CallingConvention = CallingConvention.Cdecl)]
		private static unsafe extern SDL_bool INTERNAL_SDL_AndroidRequestPermission(
			byte* permission
		);
		/// <summary>
		/// Sdls the android request permission using the specified permission
		/// </summary>
		/// <param name="permission">The permission</param>
		/// <returns>The result</returns>
		public static unsafe SDL_bool SDL_AndroidRequestPermission(
			string permission
		) {
			byte* permissionPtr = Utf8EncodeHeap(permission);
			SDL_bool result = INTERNAL_SDL_AndroidRequestPermission(
				permissionPtr
			);
			Marshal.FreeHGlobal((IntPtr) permissionPtr);
			return result;
		}

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// Internals the sdl android show toast using the specified message
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="duration">The duration</param>
		/// <param name="gravity">The gravity</param>
		/// <param name="xOffset">The offset</param>
		/// <param name="yOffset">The offset</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_AndroidShowToast", CallingConvention = CallingConvention.Cdecl)]
		private static unsafe extern int INTERNAL_SDL_AndroidShowToast(
			byte* message,
			int duration,
			int gravity,
			int xOffset,
			int yOffset
		);
		/// <summary>
		/// Sdls the android show toast using the specified message
		/// </summary>
		/// <param name="message">The message</param>
		/// <param name="duration">The duration</param>
		/// <param name="gravity">The gravity</param>
		/// <param name="xOffset">The offset</param>
		/// <param name="yOffset">The offset</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_AndroidShowToast(
			string message,
			int duration,
			int gravity,
			int xOffset,
			int yOffset
		) {
			byte* messagePtr = Utf8EncodeHeap(message);
			int result = INTERNAL_SDL_AndroidShowToast(
				messagePtr,
				duration,
				gravity,
				xOffset,
				yOffset
			);
			Marshal.FreeHGlobal((IntPtr) messagePtr);
			return result;
		}

		/* WinRT */

		/// <summary>
		/// The sdl winrt devicefamily enum
		/// </summary>
		public enum SDL_WinRT_DeviceFamily
		{
			/// <summary>
			/// The sdl winrt devicefamily unknown sdl winrt devicefamily
			/// </summary>
			SDL_WINRT_DEVICEFAMILY_UNKNOWN,
			/// <summary>
			/// The sdl winrt devicefamily desktop sdl winrt devicefamily
			/// </summary>
			SDL_WINRT_DEVICEFAMILY_DESKTOP,
			/// <summary>
			/// The sdl winrt devicefamily mobile sdl winrt devicefamily
			/// </summary>
			SDL_WINRT_DEVICEFAMILY_MOBILE,
			/// <summary>
			/// The sdl winrt devicefamily xbox sdl winrt devicefamily
			/// </summary>
			SDL_WINRT_DEVICEFAMILY_XBOX
		}

		/// <summary>
		/// Sdls the win rt get device family
		/// </summary>
		/// <returns>The sdl win rt device family</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_WinRT_DeviceFamily SDL_WinRTGetDeviceFamily();

		/// <summary>
		/// Sdls the is tablet
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_IsTablet();

		#endregion

		#region SDL_syswm.h

		/// <summary>
		/// The sdl syswm type enum
		/// </summary>
		public enum SDL_SYSWM_TYPE
		{
			/// <summary>
			/// The sdl syswm unknown sdl syswm type
			/// </summary>
			SDL_SYSWM_UNKNOWN,
			/// <summary>
			/// The sdl syswm windows sdl syswm type
			/// </summary>
			SDL_SYSWM_WINDOWS,
			/// <summary>
			/// The sdl syswm x11 sdl syswm type
			/// </summary>
			SDL_SYSWM_X11,
			/// <summary>
			/// The sdl syswm directfb sdl syswm type
			/// </summary>
			SDL_SYSWM_DIRECTFB,
			/// <summary>
			/// The sdl syswm cocoa sdl syswm type
			/// </summary>
			SDL_SYSWM_COCOA,
			/// <summary>
			/// The sdl syswm uikit sdl syswm type
			/// </summary>
			SDL_SYSWM_UIKIT,
			/// <summary>
			/// The sdl syswm wayland sdl syswm type
			/// </summary>
			SDL_SYSWM_WAYLAND,
			/// <summary>
			/// The sdl syswm mir sdl syswm type
			/// </summary>
			SDL_SYSWM_MIR,
			/// <summary>
			/// The sdl syswm winrt sdl syswm type
			/// </summary>
			SDL_SYSWM_WINRT,
			/// <summary>
			/// The sdl syswm android sdl syswm type
			/// </summary>
			SDL_SYSWM_ANDROID,
			/// <summary>
			/// The sdl syswm vivante sdl syswm type
			/// </summary>
			SDL_SYSWM_VIVANTE,
			/// <summary>
			/// The sdl syswm os2 sdl syswm type
			/// </summary>
			SDL_SYSWM_OS2,
			/// <summary>
			/// The sdl syswm haiku sdl syswm type
			/// </summary>
			SDL_SYSWM_HAIKU,
			/// <summary>
			/// The sdl syswm kmsdrm sdl syswm type
			/// </summary>
			SDL_SYSWM_KMSDRM /* requires >= 2.0.16 */
		}

		// FIXME: I wish these weren't public...
		/// <summary>
		/// The internal windows wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_windows_wminfo
		{
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an HWND
			/// <summary>
			/// The hdc
			/// </summary>
			public IntPtr hdc; // Refers to an HDC
			/// <summary>
			/// The hinstance
			/// </summary>
			public IntPtr hinstance; // Refers to an HINSTANCE
		}

		/// <summary>
		/// The internal winrt wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_winrt_wminfo
		{
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an IInspectable*
		}

		/// <summary>
		/// The internal x11 wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_x11_wminfo
		{
			/// <summary>
			/// The display
			/// </summary>
			public IntPtr display; // Refers to a Display*
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to a Window (XID, use ToInt64!)
		}

		/// <summary>
		/// The internal directfb wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_directfb_wminfo
		{
			/// <summary>
			/// The dfb
			/// </summary>
			public IntPtr dfb; // Refers to an IDirectFB*
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an IDirectFBWindow*
			/// <summary>
			/// The surface
			/// </summary>
			public IntPtr surface; // Refers to an IDirectFBSurface*
		}

		/// <summary>
		/// The internal cocoa wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_cocoa_wminfo
		{
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an NSWindow*
		}

		/// <summary>
		/// The internal uikit wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_uikit_wminfo
		{
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to a UIWindow*
			/// <summary>
			/// The framebuffer
			/// </summary>
			public uint framebuffer;
			/// <summary>
			/// The colorbuffer
			/// </summary>
			public uint colorbuffer;
			/// <summary>
			/// The resolve framebuffer
			/// </summary>
			public uint resolveFramebuffer;
		}

		/// <summary>
		/// The internal wayland wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_wayland_wminfo
		{
			/// <summary>
			/// The display
			/// </summary>
			public IntPtr display; // Refers to a wl_display*
			/// <summary>
			/// The surface
			/// </summary>
			public IntPtr surface; // Refers to a wl_surface*
			/// <summary>
			/// The shell surface
			/// </summary>
			public IntPtr shell_surface; // Refers to a wl_shell_surface*
			/// <summary>
			/// The egl window
			/// </summary>
			public IntPtr egl_window; // Refers to an egl_window*, requires >= 2.0.16
			/// <summary>
			/// The xdg surface
			/// </summary>
			public IntPtr xdg_surface; // Refers to an xdg_surface*, requires >= 2.0.16
			/// <summary>
			/// The xdg toplevel
			/// </summary>
			public IntPtr xdg_toplevel; // Referes to an xdg_toplevel*, requires >= 2.0.18
		}

		/// <summary>
		/// The internal mir wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_mir_wminfo
		{
			/// <summary>
			/// The connection
			/// </summary>
			public IntPtr connection; // Refers to a MirConnection*
			/// <summary>
			/// The surface
			/// </summary>
			public IntPtr surface; // Refers to a MirSurface*
		}

		/// <summary>
		/// The internal android wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_android_wminfo
		{
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an ANativeWindow
			/// <summary>
			/// The surface
			/// </summary>
			public IntPtr surface; // Refers to an EGLSurface
		}

		/// <summary>
		/// The internal vivante wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_vivante_wminfo
		{
			/// <summary>
			/// The display
			/// </summary>
			public IntPtr display; // Refers to an EGLNativeDisplayType
			/// <summary>
			/// The window
			/// </summary>
			public IntPtr window; // Refers to an EGLNativeWindowType
		}

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// The internal os2 wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_os2_wminfo
		{
			/// <summary>
			/// The hwnd
			/// </summary>
			public IntPtr hwnd; // Refers to an HWND
			/// <summary>
			/// The hwnd frame
			/// </summary>
			public IntPtr hwndFrame; // Refers to an HWND
		}

		/* Only available in 2.0.16 or higher. */
		/// <summary>
		/// The internal kmsdrm wminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct INTERNAL_kmsdrm_wminfo
		{
			/// <summary>
			/// The dev index
			/// </summary>
			int dev_index;
			/// <summary>
			/// The drm fd
			/// </summary>
			int drm_fd;
			/// <summary>
			/// The gbm dev
			/// </summary>
			IntPtr gbm_dev; // Refers to a gbm_device*
		}

		/// <summary>
		/// The internal syswmdriverunion
		/// </summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct INTERNAL_SysWMDriverUnion
		{
			/// <summary>
			/// The win
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_windows_wminfo win;
			/// <summary>
			/// The winrt
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_winrt_wminfo winrt;
			/// <summary>
			/// The 11
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_x11_wminfo x11;
			/// <summary>
			/// The dfb
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_directfb_wminfo dfb;
			/// <summary>
			/// The cocoa
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_cocoa_wminfo cocoa;
			/// <summary>
			/// The uikit
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_uikit_wminfo uikit;
			/// <summary>
			/// The wl
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_wayland_wminfo wl;
			/// <summary>
			/// The mir
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_mir_wminfo mir;
			/// <summary>
			/// The android
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_android_wminfo android;
			/// <summary>
			/// The os
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_os2_wminfo os2;
			/// <summary>
			/// The vivante
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_vivante_wminfo vivante;
			/// <summary>
			/// The ksmdrm
			/// </summary>
			[FieldOffset(0)]
			public INTERNAL_kmsdrm_wminfo ksmdrm;
			// private int dummy;
		}

		/// <summary>
		/// The sdl syswminfo
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_SysWMinfo
		{
			/// <summary>
			/// The version
			/// </summary>
			public SDL_version version;
			/// <summary>
			/// The subsystem
			/// </summary>
			public SDL_SYSWM_TYPE subsystem;
			/// <summary>
			/// The info
			/// </summary>
			public INTERNAL_SysWMDriverUnion info;
		}

		/* window refers to an SDL_Window* */
		/// <summary>
		/// Sdls the get window wm info using the specified window
		/// </summary>
		/// <param name="window">The window</param>
		/// <param name="info">The info</param>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_GetWindowWMInfo(
			IntPtr window,
			ref SDL_SysWMinfo info
		);

		#endregion

		#region SDL_filesystem.h

		/* Only available in 2.0.1 or higher. */
		/// <summary>
		/// Internals the sdl get base path
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
		private static extern IntPtr INTERNAL_SDL_GetBasePath();
		/// <summary>
		/// Sdls the get base path
		/// </summary>
		/// <returns>The string</returns>
		public static string SDL_GetBasePath()
		{
			return UTF8_ToManaged(INTERNAL_SDL_GetBasePath(), true);
		}

		/* Only available in 2.0.1 or higher. */
		/// <summary>
		/// Internals the sdl get pref path using the specified org
		/// </summary>
		/// <param name="org">The org</param>
		/// <param name="app">The app</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
		private static extern unsafe IntPtr INTERNAL_SDL_GetPrefPath(
			byte* org,
			byte* app
		);
		/// <summary>
		/// Sdls the get pref path using the specified org
		/// </summary>
		/// <param name="org">The org</param>
		/// <param name="app">The app</param>
		/// <returns>The string</returns>
		public static unsafe string SDL_GetPrefPath(string org, string app)
		{
			int utf8OrgBufSize = Utf8Size(org);
			byte* utf8Org = stackalloc byte[utf8OrgBufSize];

			int utf8AppBufSize = Utf8Size(app);
			byte* utf8App = stackalloc byte[utf8AppBufSize];

			return UTF8_ToManaged(
				INTERNAL_SDL_GetPrefPath(
					Utf8Encode(org, utf8Org, utf8OrgBufSize),
					Utf8Encode(app, utf8App, utf8AppBufSize)
				),
				true
			);
		}

		#endregion

		#region SDL_power.h

		/// <summary>
		/// The sdl powerstate enum
		/// </summary>
		public enum SDL_PowerState
		{
			/// <summary>
			/// The sdl powerstate unknown sdl powerstate
			/// </summary>
			SDL_POWERSTATE_UNKNOWN = 0,
			/// <summary>
			/// The sdl powerstate on battery sdl powerstate
			/// </summary>
			SDL_POWERSTATE_ON_BATTERY,
			/// <summary>
			/// The sdl powerstate no battery sdl powerstate
			/// </summary>
			SDL_POWERSTATE_NO_BATTERY,
			/// <summary>
			/// The sdl powerstate charging sdl powerstate
			/// </summary>
			SDL_POWERSTATE_CHARGING,
			/// <summary>
			/// The sdl powerstate charged sdl powerstate
			/// </summary>
			SDL_POWERSTATE_CHARGED
		}

		/// <summary>
		/// Sdls the get power info using the specified secs
		/// </summary>
		/// <param name="secs">The secs</param>
		/// <param name="pct">The pct</param>
		/// <returns>The sdl power state</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_PowerState SDL_GetPowerInfo(
			out int secs,
			out int pct
		);

		#endregion

		#region SDL_cpuinfo.h

		/// <summary>
		/// Sdls the get cpu count
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetCPUCount();

		/// <summary>
		/// Sdls the get cpu cache line size
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetCPUCacheLineSize();

		/// <summary>
		/// Sdls the has rdtsc
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasRDTSC();

		/// <summary>
		/// Sdls the has alti vec
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasAltiVec();

		/// <summary>
		/// Sdls the has mmx
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasMMX();

		/// <summary>
		/// Sdls the has 3 d now
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_Has3DNow();

		/// <summary>
		/// Sdls the has sse
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSSE();

		/// <summary>
		/// Sdls the has sse 2
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSSE2();

		/// <summary>
		/// Sdls the has sse 3
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSSE3();

		/// <summary>
		/// Sdls the has sse 41
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSSE41();

		/// <summary>
		/// Sdls the has sse 42
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasSSE42();

		/// <summary>
		/// Sdls the has avx
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasAVX();

		/// <summary>
		/// Sdls the has avx 2
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasAVX2();

		/// <summary>
		/// Sdls the has avx 512 f
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasAVX512F();

		/// <summary>
		/// Sdls the has neon
		/// </summary>
		/// <returns>The sdl bool</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern SDL_bool SDL_HasNEON();

		/* Only available in 2.0.1 or higher. */
		/// <summary>
		/// Sdls the get system ram
		/// </summary>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int SDL_GetSystemRAM();

		/* Only available in SDL 2.0.10 or higher. */
		/// <summary>
		/// Sdls the simd get alignment
		/// </summary>
		/// <returns>The uint</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern uint SDL_SIMDGetAlignment();

		/* Only available in SDL 2.0.10 or higher. */
		/// <summary>
		/// Sdls the simd alloc using the specified len
		/// </summary>
		/// <param name="len">The len</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_SIMDAlloc(uint len);

		/* Only available in SDL 2.0.14 or higher. */
		/// <summary>
		/// Sdls the simd realloc using the specified ptr
		/// </summary>
		/// <param name="ptr">The ptr</param>
		/// <param name="len">The len</param>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_SIMDRealloc(IntPtr ptr, uint len);

		/* Only available in SDL 2.0.10 or higher. */
		/// <summary>
		/// Sdls the simd free using the specified ptr
		/// </summary>
		/// <param name="ptr">The ptr</param>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_SIMDFree(IntPtr ptr);

		/* Only available in SDL 2.0.11 or higher. */
		/// <summary>
		/// Sdls the has armsimd
		/// </summary>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void SDL_HasARMSIMD();

		#endregion

		#region SDL_locale.h

		/// <summary>
		/// The sdl locale
		/// </summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SDL_Locale
		{
			/// <summary>
			/// The language
			/// </summary>
			IntPtr language;
			/// <summary>
			/// The country
			/// </summary>
			IntPtr country;
		}

		/* IntPtr refers to an SDL_Locale*.
		 * Only available in 2.0.14 or higher.
		 */
		/// <summary>
		/// Sdls the get preferred locales
		/// </summary>
		/// <returns>The int ptr</returns>
		[DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr SDL_GetPreferredLocales();

		#endregion

		#region SDL_misc.h

		/* Only available in 2.0.14 or higher. */
		/// <summary>
		/// Internals the sdl open url using the specified url
		/// </summary>
		/// <param name="url">The url</param>
		/// <returns>The int</returns>
		[DllImport(nativeLibName, EntryPoint = "SDL_OpenURL", CallingConvention = CallingConvention.Cdecl)]
		private static unsafe extern int INTERNAL_SDL_OpenURL(byte* url);
		/// <summary>
		/// Sdls the open url using the specified url
		/// </summary>
		/// <param name="url">The url</param>
		/// <returns>The result</returns>
		public static unsafe int SDL_OpenURL(string url)
		{
			byte* urlPtr = Utf8EncodeHeap(url);
			int result = INTERNAL_SDL_OpenURL(urlPtr);
			Marshal.FreeHGlobal((IntPtr) urlPtr);
			return result;
		}

		#endregion
	}
}
