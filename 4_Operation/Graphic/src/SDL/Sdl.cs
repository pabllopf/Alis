// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;


namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sdl" /> class
        /// </summary>
        static Sdl()
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
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.linux_arm64_sdl2);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2.so", NativeGraphic.linux_x64_sdl2);
                        break;
                }
            }
        }
        
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2";


        
        /// <summary>
        ///     Utfs the 8 size using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The int</returns>
        internal static int Utf8Size(string str)
        {
            if (str == null)
            {
                return 0;
            }

            return str.Length * 4 + 1;
        }

        /// <summary>
        ///     Utfs the 8 encode using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The buffer</returns>
        internal static byte[] Utf8Encode(string str, byte[] buffer, int bufferSize)
        {
            if (str == null)
            {
                return null;
            }
        
            Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
            buffer[str.Length] = 0; // Null-terminate the string
        
            return buffer;
        }



        /// <summary>
        ///     Utfs the 8 encode heap using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The buffer</returns>
        internal static byte[] Utf8EncodeHeap(string str)
        {
            if (str == null)
            {
                return null;
            }
        
            int bufferSize = Encoding.UTF8.GetByteCount(str) + 1;
            byte[] buffer = new byte[bufferSize];
            Encoding.UTF8.GetBytes(str, 0, str.Length, buffer, 0);
            buffer[bufferSize - 1] = 0; // Null-terminate the string
        
            return buffer;
        }


        
        /// <summary>
        ///     Utfs the 8 to managed using the specified s
        /// </summary>
        /// <param name="s">The </param>
        /// <param name="freePtr">The free ptr</param>
        /// <returns>The result</returns>
        public static string UTF8_ToManaged(IntPtr s, bool freePtr = false)
        {
            if (s == IntPtr.Zero)
            {
                return null;
            }
        
            byte[] bytes = new byte[0];
            int len = 0;
            while (Marshal.ReadByte(s, len) != 0)
            {
                len++;
            }
        
            if (len == 0)
            {
                return string.Empty;
            }
        
            bytes = new byte[len];
            Marshal.Copy(s, bytes, 0, len);
            string result = Encoding.UTF8.GetString(bytes);
        
            if (freePtr)
            {
                SDL_free(s);
            }
        
            return result;
        }


        
        /// <summary>
        ///     Sdls the fourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_FOURCC(byte a, byte b, byte c, byte d) => (uint) (a | (b << 8) | (c << 16) | (d << 24));

        

        /// <summary>
        ///     Sdls the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr SDL_malloc(int size);

        /// <summary>
        ///     Sdls the free using the specified memblock
        /// </summary>
        /// <param name="memblock">The memblock</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        internal static extern void SDL_free(IntPtr memblock);

        
        /// <summary>
        ///     Sdls the memcpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_memcpy(IntPtr dst, IntPtr src, IntPtr len);
        
        /// <summary>
        ///     The rw seek set
        /// </summary>
        public const int RwSeekSet = 0;

        /// <summary>
        ///     The rw seek cur
        /// </summary>
        public const int RwSeekCur = 1;

        /// <summary>
        ///     The rw seek end
        /// </summary>
        public const int RwSeekEnd = 2;

        /// <summary>
        ///     The sdl rwops unknown
        /// </summary>
        public const uint SdlRwopsUnknown = 0; 

        /// <summary>
        ///     The sdl rwops winfile
        /// </summary>
        public const uint SdlRwopsWinfile = 1; 

        /// <summary>
        ///     The sdl rwops stdfile
        /// </summary>
        public const uint SdlRwopsStdfile = 2; 

        /// <summary>
        ///     The sdl rwops jnifile
        /// </summary>
        public const uint SdlRwopsJnifile = 3; 

        /// <summary>
        ///     The sdl rwops memory
        /// </summary>
        public const uint SdlRwopsMemory = 4; 

        /// <summary>
        ///     The sdl rwops memory ro
        /// </summary>
        public const uint SdlRwopsMemoryRo = 5; 

        /// <summary>
        ///     The sdlr wops size callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SdlrWopsSizeCallback(IntPtr context);

        /// <summary>
        ///     The sdlr wops seek callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate long SdlrWopsSeekCallback(
            IntPtr context,
            long offset,
            int whence
        );

        /// <summary>
        ///     The sdlr wops read callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlrWopsReadCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        /// <summary>
        ///     The sdlr wops write callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlrWopsWriteCallback(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr num
        );

        /// <summary>
        ///     The sdlr wops close callback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SdlrWopsCloseCallback(
            IntPtr context
        );

        
        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_RWFromFile(
            byte[] file,
            byte[] mode
        );

        /// <summary>
        ///     Sdls the rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The rw ops</returns>
        public static  IntPtr SDL_RWFromFile(
            string file,
            string mode
        )
        {
            byte[] utf8File = Utf8EncodeHeap(file);
            byte[] utf8Mode = Utf8EncodeHeap(mode);
            IntPtr rwOps = INTERNAL_SDL_RWFromFile(
                utf8File,
                utf8Mode
            );
            return rwOps;
        }

        
        /// <summary>
        ///     Sdls the alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocRW();

        
        /// <summary>
        ///     Sdls the free rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeRW(IntPtr area);

        
        /// <summary>
        ///     Sdls the rw from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoclose">The autoclose</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromFP(IntPtr fp, SdlBool autoclose);

        
        /// <summary>
        ///     Sdls the rw from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromMem(IntPtr mem, int size);

        
        /// <summary>
        ///     Sdls the rw from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RWFromConstMem(IntPtr mem, int size);

        
        /// <summary>
        ///     Sdls the r wsize using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWsize(IntPtr context);

        /// <summary>
        ///     Sdls the r wseek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWseek(
            IntPtr context,
            long offset,
            int whence
        );

        /// <summary>
        ///     Sdls the r wtell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWtell(IntPtr context);

        
        /// <summary>
        ///     Sdls the r wread using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxnum">The maxnum</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWread(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        
        /// <summary>
        ///     Sdls the r wwrite using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxnum">The maxnum</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWwrite(
            IntPtr context,
            IntPtr ptr,
            IntPtr size,
            IntPtr maxnum
        );

        

        /// <summary>
        ///     Sdls the read u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_ReadU8(IntPtr src);

        /// <summary>
        ///     Sdls the read le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadLE16(IntPtr src);

        /// <summary>
        ///     Sdls the read be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_ReadBE16(IntPtr src);

        /// <summary>
        ///     Sdls the read le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadLE32(IntPtr src);

        /// <summary>
        ///     Sdls the read be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_ReadBE32(IntPtr src);

        /// <summary>
        ///     Sdls the read le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadLE64(IntPtr src);

        /// <summary>
        ///     Sdls the read be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_ReadBE64(IntPtr src);
        
        /// <summary>
        ///     Sdls the write u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteU8(IntPtr dst, byte value);

        /// <summary>
        ///     Sdls the write le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdls the write be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE16(IntPtr dst, ushort value);

        /// <summary>
        ///     Sdls the write le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdls the write be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE32(IntPtr dst, uint value);

        /// <summary>
        ///     Sdls the write le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteLE64(IntPtr dst, ulong value);

        /// <summary>
        ///     Sdls the write be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WriteBE64(IntPtr dst, ulong value);

        
        /// <summary>
        ///     Sdls the r wclose using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_RWclose(IntPtr context);

        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="datasize">The datasize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_LoadFile(byte[] file, out IntPtr datasize);

        /// <summary>
        ///     Sdls the load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="datasize">The datasize</param>
        /// <returns>The result</returns>
        public static  IntPtr SDL_LoadFile(string file, out IntPtr datasize)
        {
            byte[] utf8File = Utf8EncodeHeap(file);
            IntPtr result = INTERNAL_SDL_LoadFile(utf8File, out datasize);
            return result;
        }

        /// <summary>
        ///     Sdls the set main ready
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetMainReady();

        
        /// <summary>
        ///     The sdl main func
        /// </summary>
        public delegate int SdlMainFunc(int argc, IntPtr argv);

        
        /// <summary>
        ///     Sdls the win rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WinRTRunApp(
            SdlMainFunc mainFunction,
            IntPtr reserved
        );
        
        /// <summary>
        ///     Sdls the ui kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UIKitRunApp(
            int argc,
            IntPtr argv,
            SdlMainFunc mainFunction
        );


        /// <summary>
        ///     The sdl init timer
        /// </summary>
        public const uint SdlInitTimer = 0x00000001;

        /// <summary>
        ///     The sdl init audio
        /// </summary>
        public const uint SdlInitAudio = 0x00000010;

        /// <summary>
        ///     The sdl init video
        /// </summary>
        public const uint SdlInitVideo = 0x00000020;

        /// <summary>
        ///     The sdl init joystick
        /// </summary>
        public const uint SdlInitJoystick = 0x00000200;

        /// <summary>
        ///     The sdl init haptic
        /// </summary>
        public const uint SdlInitHaptic = 0x00001000;

        /// <summary>
        ///     The sdl init gamecontroller
        /// </summary>
        public const uint SdlInitGamecontroller = 0x00002000;

        /// <summary>
        ///     The sdl init events
        /// </summary>
        public const uint SdlInitEvents = 0x00004000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitSensor = 0x00008000;

        /// <summary>
        ///     The sdl init noparachute
        /// </summary>
        public const uint SdlInitNoparachute = 0x00100000;

        /// <summary>
        ///     The sdl init sensor
        /// </summary>
        public const uint SdlInitEverything = SdlInitTimer | SdlInitAudio | SdlInitVideo |
                                              SdlInitEvents | SdlInitJoystick | SdlInitHaptic |
                                              SdlInitGamecontroller | SdlInitSensor;

        /// <summary>
        ///     Sdls the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_Init(uint flags);

        /// <summary>
        ///     Sdls the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_InitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Quit();

        /// <summary>
        ///     Sdls the quit sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_QuitSubSystem(uint flags);

        /// <summary>
        ///     Sdls the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_WasInit(uint flags);
        
        /// <summary>
        ///     Internals the sdl get platform
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPlatform();

        /// <summary>
        ///     Sdls the get platform
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetPlatform() => UTF8_ToManaged(INTERNAL_SDL_GetPlatform());

 
        /// <summary>
        ///     The sdl hint framebuffer acceleration
        /// </summary>
        public const string SdlHintFramebufferAcceleration =
            "SDL_FRAMEBUFFER_ACCELERATION";

        /// <summary>
        ///     The sdl hint render driver
        /// </summary>
        public const string SdlHintRenderDriver =
            "SDL_RENDER_DRIVER";

        /// <summary>
        ///     The sdl hint render opengl shaders
        /// </summary>
        public const string SdlHintRenderOpenglShaders =
            "SDL_RENDER_OPENGL_SHADERS";

        /// <summary>
        ///     The sdl hint render direct3d threadsafe
        /// </summary>
        public const string SdlHintRenderDirect3DThreadsafe =
            "SDL_RENDER_DIRECT3D_THREADSAFE";

        /// <summary>
        ///     The sdl hint render vsync
        /// </summary>
        public const string SdlHintRenderVsync =
            "SDL_RENDER_VSYNC";

        /// <summary>
        ///     The sdl hint video x11 xvidmode
        /// </summary>
        public const string SdlHintVideoX11Xvidmode =
            "SDL_VIDEO_X11_XVIDMODE";

        /// <summary>
        ///     The sdl hint video x11 xinerama
        /// </summary>
        public const string SdlHintVideoX11Xinerama =
            "SDL_VIDEO_X11_XINERAMA";

        /// <summary>
        ///     The sdl hint video x11 xrandr
        /// </summary>
        public const string SdlHintVideoX11Xrandr =
            "SDL_VIDEO_X11_XRANDR";

        /// <summary>
        ///     The sdl hint grab keyboard
        /// </summary>
        public const string SdlHintGrabKeyboard =
            "SDL_GRAB_KEYBOARD";

        /// <summary>
        ///     The sdl hint video minimize on focus loss
        /// </summary>
        public const string SdlHintVideoMinimizeOnFocusLoss =
            "SDL_VIDEO_MINIMIZE_ON_FOCUS_LOSS";

        /// <summary>
        ///     The sdl hint idle timer disabled
        /// </summary>
        public const string SdlHintIdleTimerDisabled =
            "SDL_IOS_IDLE_TIMER_DISABLED";

        /// <summary>
        ///     The sdl hint orientations
        /// </summary>
        public const string SdlHintOrientations =
            "SDL_IOS_ORIENTATIONS";

        /// <summary>
        ///     The sdl hint xinput enabled
        /// </summary>
        public const string SdlHintXinputEnabled =
            "SDL_XINPUT_ENABLED";

        /// <summary>
        ///     The sdl hint gamecontrollerconfig
        /// </summary>
        public const string SdlHintGamecontrollerconfig =
            "SDL_GAMECONTROLLERCONFIG";

        /// <summary>
        ///     The sdl hint joystick allow background events
        /// </summary>
        public const string SdlHintJoystickAllowBackgroundEvents =
            "SDL_JOYSTICK_ALLOW_BACKGROUND_EVENTS";

        /// <summary>
        ///     The sdl hint allow topmost
        /// </summary>
        public const string SdlHintAllowTopmost =
            "SDL_ALLOW_TOPMOST";

        /// <summary>
        ///     The sdl hint timer resolution
        /// </summary>
        public const string SdlHintTimerResolution =
            "SDL_TIMER_RESOLUTION";

        /// <summary>
        ///     The sdl hint render scale quality
        /// </summary>
        public const string SdlHintRenderScaleQuality =
            "SDL_RENDER_SCALE_QUALITY";

        
        /// <summary>
        ///     The sdl hint video highdpi disabled
        /// </summary>
        public const string SdlHintVideoHighdpiDisabled =
            "SDL_VIDEO_HIGHDPI_DISABLED";

        
        /// <summary>
        ///     The sdl hint ctrl click emulate right click
        /// </summary>
        public const string SdlHintCtrlClickEmulateRightClick =
            "SDL_CTRL_CLICK_EMULATE_RIGHT_CLICK";

        /// <summary>
        ///     The sdl hint video win d3dcompiler
        /// </summary>
        public const string SdlHintVideoWinD3Dcompiler =
            "SDL_VIDEO_WIN_D3DCOMPILER";

        /// <summary>
        ///     The sdl hint mouse relative mode warp
        /// </summary>
        public const string SdlHintMouseRelativeModeWarp =
            "SDL_MOUSE_RELATIVE_MODE_WARP";

        /// <summary>
        ///     The sdl hint video window share pixel format
        /// </summary>
        public const string SdlHintVideoWindowSharePixelFormat =
            "SDL_VIDEO_WINDOW_SHARE_PIXEL_FORMAT";

        /// <summary>
        ///     The sdl hint video allow screensaver
        /// </summary>
        public const string SdlHintVideoAllowScreensaver =
            "SDL_VIDEO_ALLOW_SCREENSAVER";

        /// <summary>
        ///     The sdl hint accelerometer as joystick
        /// </summary>
        public const string SdlHintAccelerometerAsJoystick =
            "SDL_ACCELEROMETER_AS_JOYSTICK";

        /// <summary>
        ///     The sdl hint video mac fullscreen spaces
        /// </summary>
        public const string SdlHintVideoMacFullscreenSpaces =
            "SDL_VIDEO_MAC_FULLSCREEN_SPACES";

        
        /// <summary>
        ///     The sdl hint winrt privacy policy url
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyUrl =
            "SDL_WINRT_PRIVACY_POLICY_URL";

        /// <summary>
        ///     The sdl hint winrt privacy policy label
        /// </summary>
        public const string SdlHintWinrtPrivacyPolicyLabel =
            "SDL_WINRT_PRIVACY_POLICY_LABEL";

        /// <summary>
        ///     The sdl hint winrt handle back button
        /// </summary>
        public const string SdlHintWinrtHandleBackButton =
            "SDL_WINRT_HANDLE_BACK_BUTTON";

        
        /// <summary>
        ///     The sdl hint no signal handlers
        /// </summary>
        public const string SdlHintNoSignalHandlers =
            "SDL_NO_SIGNAL_HANDLERS";

        /// <summary>
        ///     The sdl hint ime internal editing
        /// </summary>
        public const string SdlHintImeInternalEditing =
            "SDL_IME_INTERNAL_EDITING";

        /// <summary>
        ///     The sdl hint android separate mouse and touch
        /// </summary>
        public const string SdlHintAndroidSeparateMouseAndTouch =
            "SDL_ANDROID_SEPARATE_MOUSE_AND_TOUCH";

        /// <summary>
        ///     The sdl hint emscripten keyboard element
        /// </summary>
        public const string SdlHintEmscriptenKeyboardElement =
            "SDL_EMSCRIPTEN_KEYBOARD_ELEMENT";

        /// <summary>
        ///     The sdl hint thread stack size
        /// </summary>
        public const string SdlHintThreadStackSize =
            "SDL_THREAD_STACK_SIZE";

        /// <summary>
        ///     The sdl hint window frame usable while cursor hidden
        /// </summary>
        public const string SdlHintWindowFrameUsableWhileCursorHidden =
            "SDL_WINDOW_FRAME_USABLE_WHILE_CURSOR_HIDDEN";

        /// <summary>
        ///     The sdl hint windows enable messageloop
        /// </summary>
        public const string SdlHintWindowsEnableMessageloop =
            "SDL_WINDOWS_ENABLE_MESSAGELOOP";

        /// <summary>
        ///     The sdl hint windows no close on alt f4
        /// </summary>
        public const string SdlHintWindowsNoCloseOnAltF4 =
            "SDL_WINDOWS_NO_CLOSE_ON_ALT_F4";

        /// <summary>
        ///     The sdl hint xinput use old joystick mapping
        /// </summary>
        public const string SdlHintXinputUseOldJoystickMapping =
            "SDL_XINPUT_USE_OLD_JOYSTICK_MAPPING";

        /// <summary>
        ///     The sdl hint mac background app
        /// </summary>
        public const string SdlHintMacBackgroundApp =
            "SDL_MAC_BACKGROUND_APP";

        /// <summary>
        ///     The sdl hint video x11 net wm ping
        /// </summary>
        public const string SdlHintVideoX11NetWmPing =
            "SDL_VIDEO_X11_NET_WM_PING";

        /// <summary>
        ///     The sdl hint android apk expansion main file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionMainFileVersion =
            "SDL_ANDROID_APK_EXPANSION_MAIN_FILE_VERSION";

        /// <summary>
        ///     The sdl hint android apk expansion patch file version
        /// </summary>
        public const string SdlHintAndroidApkExpansionPatchFileVersion =
            "SDL_ANDROID_APK_EXPANSION_PATCH_FILE_VERSION";

        
        /// <summary>
        ///     The sdl hint mouse focus clickthrough
        /// </summary>
        public const string SdlHintMouseFocusClickthrough =
            "SDL_MOUSE_FOCUS_CLICKTHROUGH";

        /// <summary>
        ///     The sdl hint bmp save legacy format
        /// </summary>
        public const string SdlHintBmpSaveLegacyFormat =
            "SDL_BMP_SAVE_LEGACY_FORMAT";

        /// <summary>
        ///     The sdl hint windows disable thread naming
        /// </summary>
        public const string SdlHintWindowsDisableThreadNaming =
            "SDL_WINDOWS_DISABLE_THREAD_NAMING";

        /// <summary>
        ///     The sdl hint apple tv remote allow rotation
        /// </summary>
        public const string SdlHintAppleTvRemoteAllowRotation =
            "SDL_APPLE_TV_REMOTE_ALLOW_ROTATION";

        
        /// <summary>
        ///     The sdl hint audio resampling mode
        /// </summary>
        public const string SdlHintAudioResamplingMode =
            "SDL_AUDIO_RESAMPLING_MODE";

        /// <summary>
        ///     The sdl hint render logical size mode
        /// </summary>
        public const string SdlHintRenderLogicalSizeMode =
            "SDL_RENDER_LOGICAL_SIZE_MODE";

        /// <summary>
        ///     The sdl hint mouse normal speed scale
        /// </summary>
        public const string SdlHintMouseNormalSpeedScale =
            "SDL_MOUSE_NORMAL_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint mouse relative speed scale
        /// </summary>
        public const string SdlHintMouseRelativeSpeedScale =
            "SDL_MOUSE_RELATIVE_SPEED_SCALE";

        /// <summary>
        ///     The sdl hint touch mouse events
        /// </summary>
        public const string SdlHintTouchMouseEvents =
            "SDL_TOUCH_MOUSE_EVENTS";

        /// <summary>
        ///     The sdl hint windows intresource icon
        /// </summary>
        public const string SdlHintWindowsIntresourceIcon =
            "SDL_WINDOWS_INTRESOURCE_ICON";

        /// <summary>
        ///     The sdl hint windows intresource icon small
        /// </summary>
        public const string SdlHintWindowsIntresourceIconSmall =
            "SDL_WINDOWS_INTRESOURCE_ICON_SMALL";

        
        /// <summary>
        ///     The sdl hint ios hide home indicator
        /// </summary>
        public const string SdlHintIosHideHomeIndicator =
            "SDL_IOS_HIDE_HOME_INDICATOR";

        /// <summary>
        ///     The sdl hint tv remote as joystick
        /// </summary>
        public const string SdlHintTvRemoteAsJoystick =
            "SDL_TV_REMOTE_AS_JOYSTICK";

        /// <summary>
        ///     The sdl video x11 net wm bypass compositor
        /// </summary>
        public const string SdlVideoX11NetWmBypassCompositor =
            "SDL_VIDEO_X11_NET_WM_BYPASS_COMPOSITOR";

        
        /// <summary>
        ///     The sdl hint mouse double click time
        /// </summary>
        public const string SdlHintMouseDoubleClickTime =
            "SDL_MOUSE_DOUBLE_CLICK_TIME";

        /// <summary>
        ///     The sdl hint mouse double click radius
        /// </summary>
        public const string SdlHintMouseDoubleClickRadius =
            "SDL_MOUSE_DOUBLE_CLICK_RADIUS";

        /// <summary>
        ///     The sdl hint joystick hidapi
        /// </summary>
        public const string SdlHintJoystickHidapi =
            "SDL_JOYSTICK_HIDAPI";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4
        /// </summary>
        public const string SdlHintJoystickHidapiPs4 =
            "SDL_JOYSTICK_HIDAPI_PS4";

        /// <summary>
        ///     The sdl hint joystick hidapi ps4 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs4Rumble =
            "SDL_JOYSTICK_HIDAPI_PS4_RUMBLE";

        /// <summary>
        ///     The sdl hint joystick hidapi steam
        /// </summary>
        public const string SdlHintJoystickHidapiSteam =
            "SDL_JOYSTICK_HIDAPI_STEAM";

        /// <summary>
        ///     The sdl hint joystick hidapi switch
        /// </summary>
        public const string SdlHintJoystickHidapiSwitch =
            "SDL_JOYSTICK_HIDAPI_SWITCH";

        /// <summary>
        ///     The sdl hint joystick hidapi xbox
        /// </summary>
        public const string SdlHintJoystickHidapiXbox =
            "SDL_JOYSTICK_HIDAPI_XBOX";

        /// <summary>
        ///     The sdl hint enable steam controllers
        /// </summary>
        public const string SdlHintEnableSteamControllers =
            "SDL_ENABLE_STEAM_CONTROLLERS";

        /// <summary>
        ///     The sdl hint android trap back button
        /// </summary>
        public const string SdlHintAndroidTrapBackButton =
            "SDL_ANDROID_TRAP_BACK_BUTTON";

        
        /// <summary>
        ///     The sdl hint mouse touch events
        /// </summary>
        public const string SdlHintMouseTouchEvents =
            "SDL_MOUSE_TOUCH_EVENTS";

        /// <summary>
        ///     The sdl hint gamecontrollerconfig file
        /// </summary>
        public const string SdlHintGamecontrollerconfigFile =
            "SDL_GAMECONTROLLERCONFIG_FILE";

        /// <summary>
        ///     The sdl hint android block on pause
        /// </summary>
        public const string SdlHintAndroidBlockOnPause =
            "SDL_ANDROID_BLOCK_ON_PAUSE";

        /// <summary>
        ///     The sdl hint render batching
        /// </summary>
        public const string SdlHintRenderBatching =
            "SDL_RENDER_BATCHING";

        /// <summary>
        ///     The sdl hint event logging
        /// </summary>
        public const string SdlHintEventLogging =
            "SDL_EVENT_LOGGING";

        /// <summary>
        ///     The sdl hint wave riff chunk size
        /// </summary>
        public const string SdlHintWaveRiffChunkSize =
            "SDL_WAVE_RIFF_CHUNK_SIZE";

        /// <summary>
        ///     The sdl hint wave truncation
        /// </summary>
        public const string SdlHintWaveTruncation =
            "SDL_WAVE_TRUNCATION";

        /// <summary>
        ///     The sdl hint wave fact chunk
        /// </summary>
        public const string SdlHintWaveFactChunk =
            "SDL_WAVE_FACT_CHUNK";

        
        /// <summary>
        ///     The sdl hint vido x11 window visualid
        /// </summary>
        public const string SdlHintVidoX11WindowVisualid =
            "SDL_VIDEO_X11_WINDOW_VISUALID";

        /// <summary>
        ///     The sdl hint gamecontroller use button labels
        /// </summary>
        public const string SdlHintGamecontrollerUseButtonLabels =
            "SDL_GAMECONTROLLER_USE_BUTTON_LABELS";

        /// <summary>
        ///     The sdl hint video external context
        /// </summary>
        public const string SdlHintVideoExternalContext =
            "SDL_VIDEO_EXTERNAL_CONTEXT";

        /// <summary>
        ///     The sdl hint joystick hidapi gamecube
        /// </summary>
        public const string SdlHintJoystickHidapiGamecube =
            "SDL_JOYSTICK_HIDAPI_GAMECUBE";

        /// <summary>
        ///     The sdl hint display usable bounds
        /// </summary>
        public const string SdlHintDisplayUsableBounds =
            "SDL_DISPLAY_USABLE_BOUNDS";

        /// <summary>
        ///     The sdl hint video x11 force egl
        /// </summary>
        public const string SdlHintVideoX11ForceEgl =
            "SDL_VIDEO_X11_FORCE_EGL";

        /// <summary>
        ///     The sdl hint gamecontrollertype
        /// </summary>
        public const string SdlHintGamecontrollertype =
            "SDL_GAMECONTROLLERTYPE";

        
        /// <summary>
        ///     The sdl hint joystick hidapi correlate xinput
        /// </summary>
        public const string SdlHintJoystickHidapiCorrelateXinput =
            "SDL_JOYSTICK_HIDAPI_CORRELATE_XINPUT"; 

        /// <summary>
        ///     The sdl hint joystick rawinput
        /// </summary>
        public const string SdlHintJoystickRawinput =
            "SDL_JOYSTICK_RAWINPUT";

        /// <summary>
        ///     The sdl hint audio device app name
        /// </summary>
        public const string SdlHintAudioDeviceAppName =
            "SDL_AUDIO_DEVICE_APP_NAME";

        /// <summary>
        ///     The sdl hint audio device stream name
        /// </summary>
        public const string SdlHintAudioDeviceStreamName =
            "SDL_AUDIO_DEVICE_STREAM_NAME";

        /// <summary>
        ///     The sdl hint preferred locales
        /// </summary>
        public const string SdlHintPreferredLocales =
            "SDL_PREFERRED_LOCALES";

        /// <summary>
        ///     The sdl hint thread priority policy
        /// </summary>
        public const string SdlHintThreadPriorityPolicy =
            "SDL_THREAD_PRIORITY_POLICY";

        /// <summary>
        ///     The sdl hint emscripten asyncify
        /// </summary>
        public const string SdlHintEmscriptenAsyncify =
            "SDL_EMSCRIPTEN_ASYNCIFY";

        /// <summary>
        ///     The sdl hint linux joystick deadzones
        /// </summary>
        public const string SdlHintLinuxJoystickDeadzones =
            "SDL_LINUX_JOYSTICK_DEADZONES";

        /// <summary>
        ///     The sdl hint android block on pause pauseaudio
        /// </summary>
        public const string SdlHintAndroidBlockOnPausePauseaudio =
            "SDL_ANDROID_BLOCK_ON_PAUSE_PAUSEAUDIO";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5
        /// </summary>
        public const string SdlHintJoystickHidapiPs5 =
            "SDL_JOYSTICK_HIDAPI_PS5";

        /// <summary>
        ///     The sdl hint thread force realtime time critical
        /// </summary>
        public const string SdlHintThreadForceRealtimeTimeCritical =
            "SDL_THREAD_FORCE_REALTIME_TIME_CRITICAL";

        /// <summary>
        ///     The sdl hint joystick thread
        /// </summary>
        public const string SdlHintJoystickThread =
            "SDL_JOYSTICK_THREAD";

        /// <summary>
        ///     The sdl hint auto update joysticks
        /// </summary>
        public const string SdlHintAutoUpdateJoysticks =
            "SDL_AUTO_UPDATE_JOYSTICKS";

        /// <summary>
        ///     The sdl hint auto update sensors
        /// </summary>
        public const string SdlHintAutoUpdateSensors =
            "SDL_AUTO_UPDATE_SENSORS";

        /// <summary>
        ///     The sdl hint mouse relative scaling
        /// </summary>
        public const string SdlHintMouseRelativeScaling =
            "SDL_MOUSE_RELATIVE_SCALING";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 rumble
        /// </summary>
        public const string SdlHintJoystickHidapiPs5Rumble =
            "SDL_JOYSTICK_HIDAPI_PS5_RUMBLE";

        
        /// <summary>
        ///     The sdl hint windows force mutex critical sections
        /// </summary>
        public const string SdlHintWindowsForceMutexCriticalSections =
            "SDL_WINDOWS_FORCE_MUTEX_CRITICAL_SECTIONS";

        /// <summary>
        ///     The sdl hint windows force semaphore kernel
        /// </summary>
        public const string SdlHintWindowsForceSemaphoreKernel =
            "SDL_WINDOWS_FORCE_SEMAPHORE_KERNEL";

        /// <summary>
        ///     The sdl hint joystick hidapi ps5 player led
        /// </summary>
        public const string SdlHintJoystickHidapiPs5PlayerLed =
            "SDL_JOYSTICK_HIDAPI_PS5_PLAYER_LED";

        /// <summary>
        ///     The sdl hint windows use d3d9ex
        /// </summary>
        public const string SdlHintWindowsUseD3D9Ex =
            "SDL_WINDOWS_USE_D3D9EX";

        /// <summary>
        ///     The sdl hint joystick hidapi joy cons
        /// </summary>
        public const string SdlHintJoystickHidapiJoyCons =
            "SDL_JOYSTICK_HIDAPI_JOY_CONS";

        /// <summary>
        ///     The sdl hint joystick hidapi stadia
        /// </summary>
        public const string SdlHintJoystickHidapiStadia =
            "SDL_JOYSTICK_HIDAPI_STADIA";

        /// <summary>
        ///     The sdl hint joystick hidapi switch home led
        /// </summary>
        public const string SdlHintJoystickHidapiSwitchHomeLed =
            "SDL_JOYSTICK_HIDAPI_SWITCH_HOME_LED";

        /// <summary>
        ///     The sdl hint allow alt tab while grabbed
        /// </summary>
        public const string SdlHintAllowAltTabWhileGrabbed =
            "SDL_ALLOW_ALT_TAB_WHILE_GRABBED";

        /// <summary>
        ///     The sdl hint kmsdrm require drm master
        /// </summary>
        public const string SdlHintKmsdrmRequireDrmMaster =
            "SDL_KMSDRM_REQUIRE_DRM_MASTER";

        /// <summary>
        ///     The sdl hint audio device stream role
        /// </summary>
        public const string SdlHintAudioDeviceStreamRole =
            "SDL_AUDIO_DEVICE_STREAM_ROLE";

        /// <summary>
        ///     The sdl hint x11 force override redirect
        /// </summary>
        public const string SdlHintX11ForceOverrideRedirect =
            "SDL_X11_FORCE_OVERRIDE_REDIRECT";

        /// <summary>
        ///     The sdl hint joystick hidapi luna
        /// </summary>
        public const string SdlHintJoystickHidapiLuna =
            "SDL_JOYSTICK_HIDAPI_LUNA";

        /// <summary>
        ///     The sdl hint joystick rawinput correlate xinput
        /// </summary>
        public const string SdlHintJoystickRawinputCorrelateXinput =
            "SDL_JOYSTICK_RAWINPUT_CORRELATE_XINPUT";

        /// <summary>
        ///     The sdl hint audio include monitors
        /// </summary>
        public const string SdlHintAudioIncludeMonitors =
            "SDL_AUDIO_INCLUDE_MONITORS";

        /// <summary>
        ///     The sdl hint video wayland allow libdecor
        /// </summary>
        public const string SdlHintVideoWaylandAllowLibdecor =
            "SDL_VIDEO_WAYLAND_ALLOW_LIBDECOR";

        
        /// <summary>
        ///     The sdl hint video egl allow transparency
        /// </summary>
        public const string SdlHintVideoEglAllowTransparency =
            "SDL_VIDEO_EGL_ALLOW_TRANSPARENCY";

        /// <summary>
        ///     The sdl hint app name
        /// </summary>
        public const string SdlHintAppName =
            "SDL_APP_NAME";

        /// <summary>
        ///     The sdl hint screensaver inhibit activity name
        /// </summary>
        public const string SdlHintScreensaverInhibitActivityName =
            "SDL_SCREENSAVER_INHIBIT_ACTIVITY_NAME";

        /// <summary>
        ///     The sdl hint ime show ui
        /// </summary>
        public const string SdlHintImeShowUi =
            "SDL_IME_SHOW_UI";

        /// <summary>
        ///     The sdl hint window no activation when shown
        /// </summary>
        public const string SdlHintWindowNoActivationWhenShown =
            "SDL_WINDOW_NO_ACTIVATION_WHEN_SHOWN";

        /// <summary>
        ///     The sdl hint poll sentinel
        /// </summary>
        public const string SdlHintPollSentinel =
            "SDL_POLL_SENTINEL";

        /// <summary>
        ///     The sdl hint joystick device
        /// </summary>
        public const string SdlHintJoystickDevice =
            "SDL_JOYSTICK_DEVICE";

        /// <summary>
        ///     The sdl hint linux joystick classic
        /// </summary>
        public const string SdlHintLinuxJoystickClassic =
            "SDL_LINUX_JOYSTICK_CLASSIC";

        /// <summary>
        ///     Sdls the clear hints
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearHints();

        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_GetHint(byte[] name);

        /// <summary>
        ///     Sdls the get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The string</returns>
        public static  string SDL_GetHint(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return UTF8_ToManaged(
                INTERNAL_SDL_GetHint(
                    Utf8Encode(name, utf8Name, utf8NameBufSize)
                )
            );
        }

        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlBool INTERNAL_SDL_SetHint(
            byte[] name,
            byte[] value
        );

        /// <summary>
        ///     Sdls the set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        public static  SdlBool SDL_SetHint(string name, string value)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte[] utf8Value = new byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHint(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlBool INTERNAL_SDL_SetHintWithPriority(
            byte[] name,
            byte[] value,
            SdlHintPriority priority
        );

        /// <summary>
        ///     Sdls the set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        public static  SdlBool SDL_SetHintWithPriority(
            string name,
            string value,
            SdlHintPriority priority
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];

            int utf8ValueBufSize = Utf8Size(value);
            byte[] utf8Value = new byte[utf8ValueBufSize];

            return INTERNAL_SDL_SetHintWithPriority(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                Utf8Encode(value, utf8Value, utf8ValueBufSize),
                priority
            );
        }

        
        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlBool INTERNAL_SDL_GetHintBoolean(
            byte[] name,
            SdlBool defaultValue
        );

        /// <summary>
        ///     Sdls the get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        public static  SdlBool SDL_GetHintBoolean(
            string name,
            SdlBool defaultValue
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetHintBoolean(
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                defaultValue
            );
        }

        /// <summary>
        ///     Sdls the clear error
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetError();

        /// <summary>
        ///     Sdls the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetError() => UTF8_ToManaged(INTERNAL_SDL_GetError());

        
        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_SetError(byte[] fmtAndArglist);

        /// <summary>
        ///     Sdls the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_SetError(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_SetError(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Sdls the get error msg using the specified errstr
        /// </summary>
        /// <param name="errstr">The errstr</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetErrorMsg(IntPtr errstr, int maxlength);


        
        /// <summary>
        ///     The sdl logoutputfunction
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlLogOutputFunction(
            IntPtr userdata,
            int category,
            SdlLogPriority priority,
            IntPtr message
        );

        
        /// <summary>
        ///     Internals the sdl log using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_Log(byte[] fmtAndArglist);

        /// <summary>
        ///     Sdls the log using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_Log(string fmtAndArglist)
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_Log(
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogVerbose(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogVerbose(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogVerbose(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogDebug(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogDebug(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogDebug(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogInfo(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogInfo(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogInfo(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogWarn(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogWarn(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogWarn(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogError(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogError(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogError(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogCritical(
            int category,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogCritical(
            int category,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogCritical(
                category,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogMessage(
            int category,
            SdlLogPriority priority,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogMessage(
                category,
                priority,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        
        /// <summary>
        ///     Internals the sdl log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            byte[] fmtAndArglist
        );

        /// <summary>
        ///     Sdls the log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static  void SDL_LogMessageV(
            int category,
            SdlLogPriority priority,
            string fmtAndArglist
        )
        {
            int utf8FmtAndArglistBufSize = Utf8Size(fmtAndArglist);
            byte[] utf8FmtAndArglist = new byte[utf8FmtAndArglistBufSize];
            INTERNAL_SDL_LogMessageV(
                category,
                priority,
                Utf8Encode(fmtAndArglist, utf8FmtAndArglist, utf8FmtAndArglistBufSize)
            );
        }

        /// <summary>
        ///     Sdls the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlLogPriority SDL_LogGetPriority(
            int category
        );

        /// <summary>
        ///     Sdls the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetPriority(
            int category,
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdls the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetAllPriority(
            SdlLogPriority priority
        );

        /// <summary>
        ///     Sdls the log reset priorities
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogResetPriorities();

        
        /// <summary>
        ///     Sdls the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void SDL_LogGetOutputFunction(
            out IntPtr callback,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdls the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        public static void SDL_LogGetOutputFunction(
            out SdlLogOutputFunction callback,
            out IntPtr userdata
        )
        {
            IntPtr result = IntPtr.Zero;
            SDL_LogGetOutputFunction(
                out result,
                out userdata
            );
            if (result != IntPtr.Zero)
            {
                callback = (SdlLogOutputFunction) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlLogOutputFunction)
                );
            }
            else
            {
                callback = null;
            }
        }

        
        /// <summary>
        ///     Sdls the log set output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LogSetOutputFunction(
            SdlLogOutputFunction callback,
            IntPtr userdata
        );

        /// <summary>
        ///     Internals the sdl show message box using the specified messageboxdata
        /// </summary>
        /// <param name="messageboxdata">The messageboxdata</param>
        /// <param name="buttonid">The buttonid</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_ShowMessageBox([In] ref InternalSdlMessageBoxData messageboxdata, out int buttonid);

        
        /// <summary>
        ///     Internals the alloc utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The mem</returns>
        private static IntPtr INTERNAL_AllocUTF8(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            byte[] bytes = Encoding.UTF8.GetBytes(str + '\0');
            IntPtr mem = SDL_malloc(bytes.Length);
            Marshal.Copy(bytes, 0, mem, bytes.Length);
            return mem;
        }

        /// <summary>
        ///     Sdls the show message box using the specified messageboxdata
        /// </summary>
        /// <param name="messageboxdata">The messageboxdata</param>
        /// <param name="buttonid">The buttonid</param>
        /// <returns>The result</returns>
        public static int SDL_ShowMessageBox(ref SdlMessageBoxData messageboxdata, out int buttonid)
        {
            InternalSdlMessageBoxData data = new InternalSdlMessageBoxData
            {
                flags = messageboxdata.flags,
                window = messageboxdata.window,
                title = INTERNAL_AllocUTF8(messageboxdata.title),
                message = INTERNAL_AllocUTF8(messageboxdata.message),
                numbuttons = messageboxdata.numbuttons
            };

            InternalSdlMessageBoxButtonData[] buttons = new InternalSdlMessageBoxButtonData[messageboxdata.numbuttons];
            IntPtr buttonsPtr = IntPtr.Zero;

            try
            {
                for (int i = 0; i < messageboxdata.numbuttons; i++)
                {
                    buttons[i] = new InternalSdlMessageBoxButtonData
                    {
                        flags = messageboxdata.buttons[i].flags,
                        buttonid = messageboxdata.buttons[i].buttonid,
                        text = INTERNAL_AllocUTF8(messageboxdata.buttons[i].text)
                    };
                }

                buttonsPtr = Marshal.AllocHGlobal(buttons.Length * Marshal.SizeOf<InternalSdlMessageBoxButtonData>());
                for (int i = 0; i < buttons.Length; i++)
                {
                    IntPtr buttonPtr = buttonsPtr + (i * Marshal.SizeOf<InternalSdlMessageBoxButtonData>());
                    Marshal.StructureToPtr(buttons[i], buttonPtr, false);
                }

                data.buttons = buttonsPtr;

                IntPtr colorSchemePtr = IntPtr.Zero;
                if (messageboxdata.colorScheme != null)
                {
                    colorSchemePtr = Marshal.AllocHGlobal(Marshal.SizeOf<SdlMessageBoxColorScheme>());
                    Marshal.StructureToPtr(messageboxdata.colorScheme.Value, colorSchemePtr, false);
                }

                int result = INTERNAL_SDL_ShowMessageBox(ref data, out buttonid);

                for (int i = 0; i < messageboxdata.numbuttons; i++)
                {
                    SDL_free(buttons[i].text);
                }

                SDL_free(data.message);
                SDL_free(data.title);

                if (colorSchemePtr != IntPtr.Zero)
                {
                    Marshal.DestroyStructure<SdlMessageBoxColorScheme>(colorSchemePtr);
                    Marshal.FreeHGlobal(colorSchemePtr);
                }

                return result;
            }
            finally
            {
                if (buttonsPtr != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(buttonsPtr);
                }
            }
        }


        
        /// <summary>
        ///     Internals the sdl show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            byte[] title,
            byte[] message,
            IntPtr window
        );

        /// <summary>
        ///     Sdls the show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        public static  int SDL_ShowSimpleMessageBox(
            SdlMessageBoxFlags flags,
            string title,
            string message,
            IntPtr window
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];

            int utf8MessageBufSize = Utf8Size(message);
            byte[] utf8Message = new byte[utf8MessageBufSize];

            return INTERNAL_SDL_ShowSimpleMessageBox(
                flags,
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                Utf8Encode(message, utf8Message, utf8MessageBufSize),
                window
            );
        }
        


        /// <summary>
        ///     The sdl major version
        /// </summary>
        public const int SdlMajorVersion = 2;

        /// <summary>
        ///     The sdl minor version
        /// </summary>
        public const int SdlMinorVersion = 0;

        /// <summary>
        ///     The sdl patchlevel
        /// </summary>
        public const int SdlPatchlevel = 18;

        /// <summary>
        ///     The sdl patchlevel
        /// </summary>
        public static readonly int SdlCompiledversion = SDL_VERSIONNUM(
            SdlMajorVersion,
            SdlMinorVersion,
            SdlPatchlevel
        );
        
        /// <summary>
        ///     Sdls the version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_VERSION(out SdlVersion x)
        {
            x.major = SdlMajorVersion;
            x.minor = SdlMinorVersion;
            x.patch = SdlPatchlevel;
        }

        /// <summary>
        ///     Sdls the versionnum using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The int</returns>
        public static int SDL_VERSIONNUM(int x, int y, int z) => x * 1000 + y * 100 + z;

        /// <summary>
        ///     Describes whether sdl version atleast
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="z">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_VERSION_ATLEAST(int x, int y, int z) => SdlCompiledversion >= SDL_VERSIONNUM(x, y, z);

        /// <summary>
        ///     Sdls the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetVersion(out SdlVersion ver);

        /// <summary>
        ///     Internals the sdl get revision
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetRevision();

        /// <summary>
        ///     Sdls the get revision
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetRevision() => UTF8_ToManaged(INTERNAL_SDL_GetRevision());

        /// <summary>
        ///     Sdls the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRevisionNumber();

        /// <summary>
        ///     The sdl glprofile enum
        /// </summary>
        [Flags]
        public enum SdlGLprofile
        {
            /// <summary>
            ///     The sdl gl context profile core sdl glprofile
            /// </summary>
            SdlGlContextProfileCore = 0x0001,

            /// <summary>
            ///     The sdl gl context profile compatibility sdl glprofile
            /// </summary>
            SdlGlContextProfileCompatibility = 0x0002,

            /// <summary>
            ///     The sdl gl context profile es sdl glprofile
            /// </summary>
            SdlGlContextProfileEs = 0x0004
        }

        /// <summary>
        ///     The sdl glcontext enum
        /// </summary>
        [Flags]
        public enum SdlGLcontext
        {
            /// <summary>
            ///     The sdl gl context debug flag sdl glcontext
            /// </summary>
            SdlGlContextDebugFlag = 0x0001,

            /// <summary>
            ///     The sdl gl context forward compatible flag sdl glcontext
            /// </summary>
            SdlGlContextForwardCompatibleFlag = 0x0002,

            /// <summary>
            ///     The sdl gl context robust access flag sdl glcontext
            /// </summary>
            SdlGlContextRobustAccessFlag = 0x0004,

            /// <summary>
            ///     The sdl gl context reset isolation flag sdl glcontext
            /// </summary>
            SdlGlContextResetIsolationFlag = 0x0008
        }

        /// <summary>
        ///     The sdl windoweventid enum
        /// </summary>
        public enum SdlWindowEventId : byte
        {
            /// <summary>
            ///     The sdl windowevent none sdl windoweventid
            /// </summary>
            SdlWindoweventNone,

            /// <summary>
            ///     The sdl windowevent shown sdl windoweventid
            /// </summary>
            SdlWindoweventShown,

            /// <summary>
            ///     The sdl windowevent hidden sdl windoweventid
            /// </summary>
            SdlWindoweventHidden,

            /// <summary>
            ///     The sdl windowevent exposed sdl windoweventid
            /// </summary>
            SdlWindoweventExposed,

            /// <summary>
            ///     The sdl windowevent moved sdl windoweventid
            /// </summary>
            SdlWindoweventMoved,

            /// <summary>
            ///     The sdl windowevent resized sdl windoweventid
            /// </summary>
            SdlWindoweventResized,

            /// <summary>
            ///     The sdl windowevent size changed sdl windoweventid
            /// </summary>
            SdlWindoweventSizeChanged,

            /// <summary>
            ///     The sdl windowevent minimized sdl windoweventid
            /// </summary>
            SdlWindoweventMinimized,

            /// <summary>
            ///     The sdl windowevent maximized sdl windoweventid
            /// </summary>
            SdlWindoweventMaximized,

            /// <summary>
            ///     The sdl windowevent restored sdl windoweventid
            /// </summary>
            SdlWindoweventRestored,

            /// <summary>
            ///     The sdl windowevent enter sdl windoweventid
            /// </summary>
            SdlWindoweventEnter,

            /// <summary>
            ///     The sdl windowevent leave sdl windoweventid
            /// </summary>
            SdlWindoweventLeave,

            /// <summary>
            ///     The sdl windowevent focus gained sdl windoweventid
            /// </summary>
            SdlWindoweventFocusGained,

            /// <summary>
            ///     The sdl windowevent focus lost sdl windoweventid
            /// </summary>
            SdlWindoweventFocusLost,

            /// <summary>
            ///     The sdl windowevent close sdl windoweventid
            /// </summary>
            SdlWindoweventClose,

            
            /// <summary>
            ///     The sdl windowevent take focus sdl windoweventid
            /// </summary>
            SdlWindoweventTakeFocus,

            /// <summary>
            ///     The sdl windowevent hit test sdl windoweventid
            /// </summary>
            SdlWindoweventHitTest,

            
            /// <summary>
            ///     The sdl windowevent iccprof changed sdl windoweventid
            /// </summary>
            SdlWindoweventIccprofChanged,

            /// <summary>
            ///     The sdl windowevent display changed sdl windoweventid
            /// </summary>
            SdlWindoweventDisplayChanged
        }

        /// <summary>
        ///     The sdl displayeventid enum
        /// </summary>
        public enum SdlDisplayEventId : byte
        {
            /// <summary>
            ///     The sdl displayevent none sdl displayeventid
            /// </summary>
            SdlDisplayeventNone,

            /// <summary>
            ///     The sdl displayevent orientation sdl displayeventid
            /// </summary>
            SdlDisplayeventOrientation,

            /// <summary>
            ///     The sdl displayevent connected sdl displayeventid
            /// </summary>
            SdlDisplayeventConnected, 

            /// <summary>
            ///     The sdl displayevent disconnected sdl displayeventid
            /// </summary>
            SdlDisplayeventDisconnected 
        }

        /// <summary>
        ///     The sdl displayorientation enum
        /// </summary>
        public enum SdlDisplayOrientation
        {
            /// <summary>
            ///     The sdl orientation unknown sdl displayorientation
            /// </summary>
            SdlOrientationUnknown,

            /// <summary>
            ///     The sdl orientation landscape sdl displayorientation
            /// </summary>
            SdlOrientationLandscape,

            /// <summary>
            ///     The sdl orientation landscape flipped sdl displayorientation
            /// </summary>
            SdlOrientationLandscapeFlipped,

            /// <summary>
            ///     The sdl orientation portrait sdl displayorientation
            /// </summary>
            SdlOrientationPortrait,

            /// <summary>
            ///     The sdl orientation portrait flipped sdl displayorientation
            /// </summary>
            SdlOrientationPortraitFlipped
        }

        
        /// <summary>
        ///     The sdl flashoperation enum
        /// </summary>
        public enum SdlFlashOperation
        {
            /// <summary>
            ///     The sdl flash cancel sdl flashoperation
            /// </summary>
            SdlFlashCancel,

            /// <summary>
            ///     The sdl flash briefly sdl flashoperation
            /// </summary>
            SdlFlashBriefly,

            /// <summary>
            ///     The sdl flash until focused sdl flashoperation
            /// </summary>
            SdlFlashUntilFocused
        }

        /// <summary>
        ///     The sdl windowflags enum
        /// </summary>
        [Flags]
        public enum SdlWindowFlags : uint
        {
            /// <summary>
            ///     The sdl window fullscreen sdl windowflags
            /// </summary>
            SdlWindowFullscreen = 0x00000001,

            /// <summary>
            ///     The sdl window opengl sdl windowflags
            /// </summary>
            SdlWindowOpengl = 0x00000002,

            /// <summary>
            ///     The sdl window shown sdl windowflags
            /// </summary>
            SdlWindowShown = 0x00000004,

            /// <summary>
            ///     The sdl window hidden sdl windowflags
            /// </summary>
            SdlWindowHidden = 0x00000008,

            /// <summary>
            ///     The sdl window borderless sdl windowflags
            /// </summary>
            SdlWindowBorderless = 0x00000010,

            /// <summary>
            ///     The sdl window resizable sdl windowflags
            /// </summary>
            SdlWindowResizable = 0x00000020,

            /// <summary>
            ///     The sdl window minimized sdl windowflags
            /// </summary>
            SdlWindowMinimized = 0x00000040,

            /// <summary>
            ///     The sdl window maximized sdl windowflags
            /// </summary>
            SdlWindowMaximized = 0x00000080,

            /// <summary>
            ///     The sdl window mouse grabbed sdl windowflags
            /// </summary>
            SdlWindowMouseGrabbed = 0x00000100,

            /// <summary>
            ///     The sdl window input focus sdl windowflags
            /// </summary>
            SdlWindowInputFocus = 0x00000200,

            /// <summary>
            ///     The sdl window mouse focus sdl windowflags
            /// </summary>
            SdlWindowMouseFocus = 0x00000400,

            /// <summary>
            ///     The sdl window fullscreen desktop sdl windowflags
            /// </summary>
            SdlWindowFullscreenDesktop =
                SdlWindowFullscreen | 0x00001000,

            /// <summary>
            ///     The sdl window foreign sdl windowflags
            /// </summary>
            SdlWindowForeign = 0x00000800,

            /// <summary>
            ///     The sdl window allow highdpi sdl windowflags
            /// </summary>
            SdlWindowAllowHighdpi = 0x00002000, 

            /// <summary>
            ///     The sdl window mouse capture sdl windowflags
            /// </summary>
            SdlWindowMouseCapture = 0x00004000, 

            /// <summary>
            ///     The sdl window always on top sdl windowflags
            /// </summary>
            SdlWindowAlwaysOnTop = 0x00008000, 

            /// <summary>
            ///     The sdl window skip taskbar sdl windowflags
            /// </summary>
            SdlWindowSkipTaskbar = 0x00010000, 

            /// <summary>
            ///     The sdl window utility sdl windowflags
            /// </summary>
            SdlWindowUtility = 0x00020000, 

            /// <summary>
            ///     The sdl window tooltip sdl windowflags
            /// </summary>
            SdlWindowTooltip = 0x00040000, 

            /// <summary>
            ///     The sdl window popup menu sdl windowflags
            /// </summary>
            SdlWindowPopupMenu = 0x00080000, 

            /// <summary>
            ///     The sdl window keyboard grabbed sdl windowflags
            /// </summary>
            SdlWindowKeyboardGrabbed = 0x00100000, 

            /// <summary>
            ///     The sdl window vulkan sdl windowflags
            /// </summary>
            SdlWindowVulkan = 0x10000000, 

            /// <summary>
            ///     The sdl window metal sdl windowflags
            /// </summary>
            SdlWindowMetal = 0x2000000, 

            /// <summary>
            ///     The sdl window input grabbed sdl windowflags
            /// </summary>
            SdlWindowInputGrabbed =
                SdlWindowMouseGrabbed
        }

        
        /// <summary>
        ///     The sdl hittestresult enum
        /// </summary>
        public enum SdlHitTestResult
        {
            /// <summary>
            ///     The sdl hittest normal sdl hittestresult
            /// </summary>
            SdlHittestNormal, 

            /// <summary>
            ///     The sdl hittest draggable sdl hittestresult
            /// </summary>
            SdlHittestDraggable, 

            /// <summary>
            ///     The sdl hittest resize topleft sdl hittestresult
            /// </summary>
            SdlHittestResizeTopleft,

            /// <summary>
            ///     The sdl hittest resize top sdl hittestresult
            /// </summary>
            SdlHittestResizeTop,

            /// <summary>
            ///     The sdl hittest resize topright sdl hittestresult
            /// </summary>
            SdlHittestResizeTopright,

            /// <summary>
            ///     The sdl hittest resize right sdl hittestresult
            /// </summary>
            SdlHittestResizeRight,

            /// <summary>
            ///     The sdl hittest resize bottomright sdl hittestresult
            /// </summary>
            SdlHittestResizeBottomright,

            /// <summary>
            ///     The sdl hittest resize bottom sdl hittestresult
            /// </summary>
            SdlHittestResizeBottom,

            /// <summary>
            ///     The sdl hittest resize bottomleft sdl hittestresult
            /// </summary>
            SdlHittestResizeBottomleft,

            /// <summary>
            ///     The sdl hittest resize left sdl hittestresult
            /// </summary>
            SdlHittestResizeLeft
        }

        /// <summary>
        ///     The sdl windowpos undefined mask
        /// </summary>
        public const int SdlWindowposUndefinedMask = 0x1FFF0000;

        /// <summary>
        ///     The sdl windowpos centered mask
        /// </summary>
        public const int SdlWindowposCenteredMask = 0x2FFF0000;

        /// <summary>
        ///     The sdl windowpos undefined
        /// </summary>
        public const int SdlWindowposUndefined = 0x1FFF0000;

        /// <summary>
        ///     The sdl windowpos centered
        /// </summary>
        public const int SdlWindowposCentered = 0x2FFF0000;

        /// <summary>
        ///     Sdls the windowpos undefined display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SDL_WINDOWPOS_UNDEFINED_DISPLAY(int x) => SdlWindowposUndefinedMask | x;

        /// <summary>
        ///     Describes whether sdl windowpos isundefined
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_WINDOWPOS_ISUNDEFINED(int x) => (x & 0xFFFF0000) == SdlWindowposUndefinedMask;

        /// <summary>
        ///     Sdls the windowpos centered display using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The int</returns>
        public static int SDL_WINDOWPOS_CENTERED_DISPLAY(int x) => SdlWindowposCenteredMask | x;

        /// <summary>
        ///     Describes whether sdl windowpos iscentered
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_WINDOWPOS_ISCENTERED(int x) => (x & 0xFFFF0000) == SdlWindowposCenteredMask;

        
        /// <summary>
        ///     The sdl hittest
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate SdlHitTestResult SdlHitTest(IntPtr win, IntPtr area, IntPtr data);

        
        /// <summary>
        ///     Internals the sdl create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_CreateWindow(
            byte[] title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        );

        /// <summary>
        ///     Sdls the create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        public static  IntPtr SDL_CreateWindow(
            string title,
            int x,
            int y,
            int w,
            int h,
            SdlWindowFlags flags
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];
            return INTERNAL_SDL_CreateWindow(
                Utf8Encode(title, utf8Title, utf8TitleBufSize),
                x, y, w, h,
                flags
            );
        }

        
        /// <summary>
        ///     Sdls the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CreateWindowAndRenderer(
            int width,
            int height,
            SdlWindowFlags windowFlags,
            out IntPtr window,
            out IntPtr renderer
        );

        
        /// <summary>
        ///     Sdls the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateWindowFrom(IntPtr data);

        
        /// <summary>
        ///     Sdls the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyWindow(IntPtr window);

        /// <summary>
        ///     Sdls the disable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DisableScreenSaver();

        /// <summary>
        ///     Sdls the enable screen saver
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_EnableScreenSaver();

        
        /// <summary>
        ///     Sdls the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetClosestDisplayMode(
            int displayIndex,
            ref SdlDisplayMode mode,
            out SdlDisplayMode closest
        );

        /// <summary>
        ///     Sdls the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCurrentDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentVideoDriver();

        /// <summary>
        ///     Sdls the get current video driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentVideoDriver() => UTF8_ToManaged(INTERNAL_SDL_GetCurrentVideoDriver());

        /// <summary>
        ///     Sdls the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDesktopDisplayMode(
            int displayIndex,
            out SdlDisplayMode mode
        );

        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetDisplayName(int index);

        /// <summary>
        ///     Sdls the get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetDisplayName(int index) => UTF8_ToManaged(INTERNAL_SDL_GetDisplayName(index));

        /// <summary>
        ///     Sdls the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayBounds(
            int displayIndex,
            out SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="ddpi">The ddpi</param>
        /// <param name="hdpi">The hdpi</param>
        /// <param name="vdpi">The vdpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayDPI(
            int displayIndex,
            out float ddpi,
            out float hdpi,
            out float vdpi
        );

        
        /// <summary>
        ///     Sdls the get display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlDisplayOrientation SDL_GetDisplayOrientation(
            int displayIndex
        );

        /// <summary>
        ///     Sdls the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayMode(
            int displayIndex,
            int modeIndex,
            out SdlDisplayMode mode
        );

        
        /// <summary>
        ///     Sdls the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetDisplayUsableBounds(
            int displayIndex,
            out SdlRect rect
        );

        /// <summary>
        ///     Sdls the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumDisplayModes(
            int displayIndex
        );

        /// <summary>
        ///     Sdls the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDisplays();

        /// <summary>
        ///     Sdls the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumVideoDrivers();

        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetVideoDriver(
            int index
        );

        /// <summary>
        ///     Sdls the get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetVideoDriver(int index) => UTF8_ToManaged(INTERNAL_SDL_GetVideoDriver(index));

        
        /// <summary>
        ///     Sdls the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GetWindowBrightness(
            IntPtr window
        );

        
        /// <summary>
        ///     Sdls the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowOpacity(
            IntPtr window,
            float opacity
        );

        
        /// <summary>
        ///     Sdls the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowOpacity(
            IntPtr window,
            out float outOpacity
        );

        
        /// <summary>
        ///     Sdls the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowModalFor(
            IntPtr modalWindow,
            IntPtr parentWindow
        );

        
        /// <summary>
        ///     Sdls the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowInputFocus(IntPtr window);

        
        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_GetWindowData(
            IntPtr window,
            byte[] name
        );

        /// <summary>
        ///     Sdls the get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        public static  IntPtr SDL_GetWindowData(
            IntPtr window,
            string name
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }

        
        /// <summary>
        ///     Sdls the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayIndex(
            IntPtr window
        );

        
        /// <summary>
        ///     Sdls the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowDisplayMode(
            IntPtr window,
            out SdlDisplayMode mode
        );

        
        /// <summary>
        ///     Sdls the get window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowICCProfile(
            IntPtr window,
            out IntPtr mode
        );

        
        /// <summary>
        ///     Sdls the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowFlags(IntPtr window);

        
        /// <summary>
        ///     Sdls the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowFromID(uint id);

        
        /// <summary>
        ///     Sdls the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowGammaRamp(
            IntPtr window,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );

        
        /// <summary>
        ///     Sdls the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowGrab(IntPtr window);

        
        /// <summary>
        ///     Sdls the get window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowKeyboardGrab(IntPtr window);

        
        /// <summary>
        ///     Sdls the get window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowMouseGrab(IntPtr window);

        
        /// <summary>
        ///     Sdls the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowID(IntPtr window);

        
        /// <summary>
        ///     Sdls the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetWindowPixelFormat(
            IntPtr window
        );

        
        /// <summary>
        ///     Sdls the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMaximumSize(
            IntPtr window,
            out int maxW,
            out int maxH
        );

        
        /// <summary>
        ///     Sdls the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowMinimumSize(
            IntPtr window,
            out int minW,
            out int minH
        );

        
        /// <summary>
        ///     Sdls the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowPosition(
            IntPtr window,
            out int x,
            out int y
        );

        
        /// <summary>
        ///     Sdls the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetWindowSize(
            IntPtr window,
            out int w,
            out int h
        );

        
        /// <summary>
        ///     Sdls the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowSurface(IntPtr window);

        
        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetWindowTitle(
            IntPtr window
        );

        /// <summary>
        ///     Sdls the get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The string</returns>
        public static string SDL_GetWindowTitle(IntPtr window) => UTF8_ToManaged(
            INTERNAL_SDL_GetWindowTitle(window)
        );

        
        /// <summary>
        ///     Sdls the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texw">The texw</param>
        /// <param name="texh">The texh</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_BindTexture(
            IntPtr texture,
            out float texw,
            out float texh
        );

        
        /// <summary>
        ///     Sdls the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_CreateContext(IntPtr window);

        
        /// <summary>
        ///     Sdls the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_DeleteContext(IntPtr context);

        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_GL_LoadLibrary(byte[] path);

        /// <summary>
        ///     Sdls the gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static  int SDL_GL_LoadLibrary(string path)
        {
            byte[] utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_GL_LoadLibrary(
                utf8Path
            );
            return result;
        }

        
        /// <summary>
        ///     Sdls the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetProcAddress(byte[] proc);

        
        /// <summary>
        ///     Sdls the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        public static  IntPtr SDL_GL_GetProcAddress(string proc)
        {
            int utf8ProcBufSize = Utf8Size(proc);
            byte[] utf8Proc = new byte[utf8ProcBufSize];
            return SDL_GL_GetProcAddress(
                Utf8Encode(proc, utf8Proc, utf8ProcBufSize)
            );
        }

        /// <summary>
        ///     Sdls the gl unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_UnloadLibrary();

        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlBool INTERNAL_SDL_GL_ExtensionSupported(
            byte[] extension
        );

        /// <summary>
        ///     Sdls the gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        public static  SdlBool SDL_GL_ExtensionSupported(string extension)
        {
            int utf8ExtensionBufSize = Utf8Size(extension);
            byte[] utf8Extension = new byte[utf8ExtensionBufSize];
            return INTERNAL_SDL_GL_ExtensionSupported(
                Utf8Encode(extension, utf8Extension, utf8ExtensionBufSize)
            );
        }

        
        /// <summary>
        ///     Sdls the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_ResetAttributes();

        /// <summary>
        ///     Sdls the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetAttribute(
            SdlGLattr attr,
            out int value
        );

        /// <summary>
        ///     Sdls the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_GetSwapInterval();

        
        /// <summary>
        ///     Sdls the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_MakeCurrent(
            IntPtr window,
            IntPtr context
        );

        
        /// <summary>
        ///     Sdls the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentWindow();

        
        /// <summary>
        ///     Sdls the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GL_GetCurrentContext();

        
        /// <summary>
        ///     Sdls the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     Sdls the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetAttribute(
            SdlGLattr attr,
            int value
        );

        /// <summary>
        ///     Sdls the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="profile">The profile</param>
        /// <returns>The int</returns>
        public static int SDL_GL_SetAttribute(
            SdlGLattr attr,
            SdlGLprofile profile
        )
            => SDL_GL_SetAttribute(attr, (int) profile);

        /// <summary>
        ///     Sdls the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_SetSwapInterval(int interval);

        
        /// <summary>
        ///     Sdls the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GL_SwapWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GL_UnbindTexture(IntPtr texture);

        
        /// <summary>
        ///     Sdls the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HideWindow(IntPtr window);

        /// <summary>
        ///     Sdls the is screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenSaverEnabled();

        
        /// <summary>
        ///     Sdls the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MaximizeWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MinimizeWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RaiseWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RestoreWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowBrightness(
            IntPtr window,
            float brightness
        );

        
        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_SetWindowData(
            IntPtr window,
            byte[] name,
            IntPtr userdata
        );

        /// <summary>
        ///     Sdls the set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        public static  IntPtr SDL_SetWindowData(
            IntPtr window,
            string name,
            IntPtr userdata
        )
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_SetWindowData(
                window,
                Utf8Encode(name, utf8Name, utf8NameBufSize),
                userdata
            );
        }

        
        /// <summary>
        ///     Sdls the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            ref SdlDisplayMode mode
        );

        
        
        /// <summary>
        ///     Sdls the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowDisplayMode(
            IntPtr window,
            IntPtr mode
        );

        
        /// <summary>
        ///     Sdls the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowFullscreen(
            IntPtr window,
            uint flags
        );

        
        /// <summary>
        ///     Sdls the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowGammaRamp(
            IntPtr window,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] red,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue
        );

        
        /// <summary>
        ///     Sdls the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowGrab(
            IntPtr window,
            SdlBool grabbed
        );

        
        /// <summary>
        ///     Sdls the set window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowKeyboardGrab(
            IntPtr window,
            SdlBool grabbed
        );

        
        /// <summary>
        ///     Sdls the set window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMouseGrab(
            IntPtr window,
            SdlBool grabbed
        );


        
        /// <summary>
        ///     Sdls the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowIcon(
            IntPtr window,
            IntPtr icon
        );

        
        /// <summary>
        ///     Sdls the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMaximumSize(
            IntPtr window,
            int maxW,
            int maxH
        );

        
        /// <summary>
        ///     Sdls the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowMinimumSize(
            IntPtr window,
            int minW,
            int minH
        );

        
        /// <summary>
        ///     Sdls the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowPosition(
            IntPtr window,
            int x,
            int y
        );

        
        /// <summary>
        ///     Sdls the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowSize(
            IntPtr window,
            int w,
            int h
        );

        
        /// <summary>
        ///     Sdls the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowBordered(
            IntPtr window,
            SdlBool bordered
        );

        
        /// <summary>
        ///     Sdls the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetWindowBordersSize(
            IntPtr window,
            out int top,
            out int left,
            out int bottom,
            out int right
        );

        
        /// <summary>
        ///     Sdls the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowResizable(
            IntPtr window,
            SdlBool resizable
        );

        
        /// <summary>
        ///     Sdls the set window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowAlwaysOnTop(
            IntPtr window,
            SdlBool onTop
        );

        
        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        private static extern  void INTERNAL_SDL_SetWindowTitle(
            IntPtr window,
            byte[] title
        );

        /// <summary>
        ///     Sdls the set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        public static  void SDL_SetWindowTitle(
            IntPtr window,
            string title
        )
        {
            int utf8TitleBufSize = Utf8Size(title);
            byte[] utf8Title = new byte[utf8TitleBufSize];
            INTERNAL_SDL_SetWindowTitle(
                window,
                Utf8Encode(title, utf8Title, utf8TitleBufSize)
            );
        }

        
        /// <summary>
        ///     Sdls the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ShowWindow(IntPtr window);

        
        /// <summary>
        ///     Sdls the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurface(IntPtr window);

        
        /// <summary>
        ///     Sdls the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numrects">The numrects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateWindowSurfaceRects(
            IntPtr window,
            [In] SdlRect[] rects,
            int numrects
        );

        /// <summary>
        ///     Internals the sdl video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_VideoInit(
            byte[] driverName
        );

        /// <summary>
        ///     Sdls the video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static  int SDL_VideoInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte[] utf8DriverName = new byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_VideoInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdls the video quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_VideoQuit();

        
        /// <summary>
        ///     Sdls the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowHitTest(
            IntPtr window,
            SdlHitTest callback,
            IntPtr callbackData
        );

        
        /// <summary>
        ///     Sdls the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetGrabbedWindow();

        
        /// <summary>
        ///     Sdls the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetWindowMouseRect(
            IntPtr window,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the get window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetWindowMouseRect(
            IntPtr window
        );

        
        /// <summary>
        ///     Sdls the flash window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FlashWindow(
            IntPtr window,
            SdlFlashOperation operation
        );

        /// <summary>
        ///     The sdl blendmode enum
        /// </summary>
        [Flags]
        public enum SdlBlendMode
        {
            /// <summary>
            ///     The sdl blendmode none sdl blendmode
            /// </summary>
            SdlBlendmodeNone = 0x00000000,

            /// <summary>
            ///     The sdl blendmode blend sdl blendmode
            /// </summary>
            SdlBlendmodeBlend = 0x00000001,

            /// <summary>
            ///     The sdl blendmode add sdl blendmode
            /// </summary>
            SdlBlendmodeAdd = 0x00000002,

            /// <summary>
            ///     The sdl blendmode mod sdl blendmode
            /// </summary>
            SdlBlendmodeMod = 0x00000004,

            /// <summary>
            ///     The sdl blendmode mul sdl blendmode
            /// </summary>
            SdlBlendmodeMul = 0x00000008, 

            /// <summary>
            ///     The sdl blendmode invalid sdl blendmode
            /// </summary>
            SdlBlendmodeInvalid = 0x7FFFFFFF
        }

        /// <summary>
        ///     The sdl blendoperation enum
        /// </summary>
        public enum SdlBlendOperation
        {
            /// <summary>
            ///     The sdl blendoperation add sdl blendoperation
            /// </summary>
            SdlBlendoperationAdd = 0x1,

            /// <summary>
            ///     The sdl blendoperation subtract sdl blendoperation
            /// </summary>
            SdlBlendoperationSubtract = 0x2,

            /// <summary>
            ///     The sdl blendoperation rev subtract sdl blendoperation
            /// </summary>
            SdlBlendoperationRevSubtract = 0x3,

            /// <summary>
            ///     The sdl blendoperation minimum sdl blendoperation
            /// </summary>
            SdlBlendoperationMinimum = 0x4,

            /// <summary>
            ///     The sdl blendoperation maximum sdl blendoperation
            /// </summary>
            SdlBlendoperationMaximum = 0x5
        }

        /// <summary>
        ///     The sdl blendfactor enum
        /// </summary>
        public enum SdlBlendFactor
        {
            /// <summary>
            ///     The sdl blendfactor zero sdl blendfactor
            /// </summary>
            SdlBlendfactorZero = 0x1,

            /// <summary>
            ///     The sdl blendfactor one sdl blendfactor
            /// </summary>
            SdlBlendfactorOne = 0x2,

            /// <summary>
            ///     The sdl blendfactor src color sdl blendfactor
            /// </summary>
            SdlBlendfactorSrcColor = 0x3,

            /// <summary>
            ///     The sdl blendfactor one minus src color sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusSrcColor = 0x4,

            /// <summary>
            ///     The sdl blendfactor src alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorSrcAlpha = 0x5,

            /// <summary>
            ///     The sdl blendfactor one minus src alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusSrcAlpha = 0x6,

            /// <summary>
            ///     The sdl blendfactor dst color sdl blendfactor
            /// </summary>
            SdlBlendfactorDstColor = 0x7,

            /// <summary>
            ///     The sdl blendfactor one minus dst color sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusDstColor = 0x8,

            /// <summary>
            ///     The sdl blendfactor dst alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorDstAlpha = 0x9,

            /// <summary>
            ///     The sdl blendfactor one minus dst alpha sdl blendfactor
            /// </summary>
            SdlBlendfactorOneMinusDstAlpha = 0xA
        }

        
        /// <summary>
        ///     Sdls the compose custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBlendMode SDL_ComposeCustomBlendMode(
            SdlBlendFactor srcColorFactor,
            SdlBlendFactor dstColorFactor,
            SdlBlendOperation colorOperation,
            SdlBlendFactor srcAlphaFactor,
            SdlBlendFactor dstAlphaFactor,
            SdlBlendOperation alphaOperation
        );
        
        /// <summary>
        ///     Internals the sdl vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_Vulkan_LoadLibrary(
            byte[] path
        );

        /// <summary>
        ///     Sdls the vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The result</returns>
        public static  int SDL_Vulkan_LoadLibrary(string path)
        {
            byte[] utf8Path = Utf8EncodeHeap(path);
            int result = INTERNAL_SDL_Vulkan_LoadLibrary(
                utf8Path
            );
            return result;
        }

        
        /// <summary>
        ///     Sdls the vulkan get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Vulkan_GetVkGetInstanceProcAddr();

        
        /// <summary>
        ///     Sdls the vulkan unload library
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_UnloadLibrary();

        
        /// <summary>
        ///     Sdls the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr pNames
        );

        
        /// <summary>
        ///     Sdls the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_GetInstanceExtensions(
            IntPtr window,
            out uint pCount,
            IntPtr[] pNames
        );

        
        /// <summary>
        ///     Sdls the vulkan create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Vulkan_CreateSurface(
            IntPtr window,
            IntPtr instance,
            out ulong surface
        );

        
        /// <summary>
        ///     Sdls the vulkan get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Vulkan_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     Sdls the metal create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_CreateView(
            IntPtr window
        );

        
        /// <summary>
        ///     Sdls the metal destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_DestroyView(
            IntPtr view
        );

        
        /// <summary>
        ///     Sdls the metal get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_Metal_GetLayer(
            IntPtr view
        );

        
        /// <summary>
        ///     Sdls the metal get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Metal_GetDrawableSize(
            IntPtr window,
            out int w,
            out int h
        );

        /// <summary>
        ///     The sdl rendererflags enum
        /// </summary>
        [Flags]
        public enum SdlRendererFlags : uint
        {
            /// <summary>
            ///     The sdl renderer software sdl rendererflags
            /// </summary>
            SdlRendererSoftware = 0x00000001,

            /// <summary>
            ///     The sdl renderer accelerated sdl rendererflags
            /// </summary>
            SdlRendererAccelerated = 0x00000002,

            /// <summary>
            ///     The sdl renderer presentvsync sdl rendererflags
            /// </summary>
            SdlRendererPresentvsync = 0x00000004,

            /// <summary>
            ///     The sdl renderer targettexture sdl rendererflags
            /// </summary>
            SdlRendererTargettexture = 0x00000008
        }

        /// <summary>
        ///     The sdl rendererflip enum
        /// </summary>
        [Flags]
        public enum SdlRendererFlip
        {
            /// <summary>
            ///     The sdl flip none sdl rendererflip
            /// </summary>
            SdlFlipNone = 0x00000000,

            /// <summary>
            ///     The sdl flip horizontal sdl rendererflip
            /// </summary>
            SdlFlipHorizontal = 0x00000001,

            /// <summary>
            ///     The sdl flip vertical sdl rendererflip
            /// </summary>
            SdlFlipVertical = 0x00000002
        }

        /// <summary>
        ///     The sdl textureaccess enum
        /// </summary>
        public enum SdlTextureAccess
        {
            /// <summary>
            ///     The sdl textureaccess static sdl textureaccess
            /// </summary>
            SdlTextureaccessStatic,

            /// <summary>
            ///     The sdl textureaccess streaming sdl textureaccess
            /// </summary>
            SdlTextureaccessStreaming,

            /// <summary>
            ///     The sdl textureaccess target sdl textureaccess
            /// </summary>
            SdlTextureaccessTarget
        }

        /// <summary>
        ///     The sdl texturemodulate enum
        /// </summary>
        [Flags]
        public enum SdlTextureModulate
        {
            /// <summary>
            ///     The sdl texturemodulate none sdl texturemodulate
            /// </summary>
            SdlTexturemodulateNone = 0x00000000,

            /// <summary>
            ///     The sdl texturemodulate horizontal sdl texturemodulate
            /// </summary>
            SdlTexturemodulateHorizontal = 0x00000001,

            /// <summary>
            ///     The sdl texturemodulate vertical sdl texturemodulate
            /// </summary>
            SdlTexturemodulateVertical = 0x00000002
        }

        
        /// <summary>
        ///     The sdl scalemode enum
        /// </summary>
        public enum SdlScaleMode
        {
            /// <summary>
            ///     The sdl scalemodenearest sdl scalemode
            /// </summary>
            SdlScaleModeNearest,

            /// <summary>
            ///     The sdl scalemodelinear sdl scalemode
            /// </summary>
            SdlScaleModeLinear,

            /// <summary>
            ///     The sdl scalemodebest sdl scalemode
            /// </summary>
            SdlScaleModeBest
        }

        

        
        /// <summary>
        ///     Sdls the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRenderer(
            IntPtr window,
            int index,
            SdlRendererFlags flags
        );

        
        /// <summary>
        ///     Sdls the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSoftwareRenderer(IntPtr surface);

        
        /// <summary>
        ///     Sdls the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTexture(
            IntPtr renderer,
            uint format,
            int access,
            int w,
            int h
        );

        
        /// <summary>
        ///     Sdls the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateTextureFromSurface(
            IntPtr renderer,
            IntPtr surface
        );

        
        /// <summary>
        ///     Sdls the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyRenderer(IntPtr renderer);

        
        /// <summary>
        ///     Sdls the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DestroyTexture(IntPtr texture);

        /// <summary>
        ///     Sdls the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumRenderDrivers();

        
        /// <summary>
        ///     Sdls the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawBlendMode(
            IntPtr renderer,
            out SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the set texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureScaleMode(
            IntPtr texture,
            SdlScaleMode scaleMode
        );

        
        /// <summary>
        ///     Sdls the get texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureScaleMode(
            IntPtr texture,
            out SdlScaleMode scaleMode
        );

        
        /// <summary>
        ///     Sdls the set texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureUserData(
            IntPtr texture,
            IntPtr userdata
        );

        
        /// <summary>
        ///     Sdls the get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTextureUserData(IntPtr texture);

        
        /// <summary>
        ///     Sdls the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDrawColor(
            IntPtr renderer,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        /// <summary>
        ///     Sdls the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRenderDriverInfo(
            int index,
            out SdlRendererInfo info
        );

        
        /// <summary>
        ///     Sdls the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderer(IntPtr window);

        
        /// <summary>
        ///     Sdls the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererInfo(
            IntPtr renderer,
            out SdlRendererInfo info
        );

        
        /// <summary>
        ///     Sdls the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetRendererOutputSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        
        /// <summary>
        ///     Sdls the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureAlphaMod(
            IntPtr texture,
            out byte alpha
        );

        
        /// <summary>
        ///     Sdls the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureBlendMode(
            IntPtr texture,
            out SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetTextureColorMod(
            IntPtr texture,
            out byte r,
            out byte g,
            out byte b
        );

        
        /// <summary>
        ///     Sdls the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr pixels,
            out int pitch
        );

        
        /// <summary>
        ///     Sdls the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTexture(
            IntPtr texture,
            IntPtr rect,
            out IntPtr pixels,
            out int pitch
        );

        
        /// <summary>
        ///     Sdls the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            ref SdlRect rect,
            out IntPtr surface
        );

        
        /// <summary>
        ///     Sdls the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockTextureToSurface(
            IntPtr texture,
            IntPtr rect,
            out IntPtr surface
        );

        
        /// <summary>
        ///     Sdls the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueryTexture(
            IntPtr texture,
            out uint format,
            out int access,
            out int w,
            out int h
        );

        
        /// <summary>
        ///     Sdls the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderClear(IntPtr renderer);

        
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopy(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLine(
            IntPtr renderer,
            int x1,
            int y1,
            int x2,
            int y2
        );

        
        /// <summary>
        ///     Sdls the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLines(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );

        
        /// <summary>
        ///     Sdls the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoint(
            IntPtr renderer,
            int x,
            int y
        );

        
        /// <summary>
        ///     Sdls the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPoints(
            IntPtr renderer,
            [In] SdlPoint[] points,
            int count
        );

        
        /// <summary>
        ///     Sdls the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRect(
            IntPtr renderer,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );

        
        /// <summary>
        ///     Sdls the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRect(
            IntPtr renderer,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRects(
            IntPtr renderer,
            [In] SdlRect[] rects,
            int count
        );

        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyEx(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            ref SdlFRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            ref SdlFPoint center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            ref SdlFRect dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            ref SdlRect srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dstrect">The dstrect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderCopyExF(
            IntPtr renderer,
            IntPtr texture,
            IntPtr srcrect,
            IntPtr dstrect,
            double angle,
            IntPtr center,
            SdlRendererFlip flip
        );

        
        /// <summary>
        ///     Sdls the render geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometry(
            IntPtr renderer,
            IntPtr texture,
            [In] SdlVertex[] vertices,
            int numVertices,
            [In] int[] indices,
            int numIndices
        );

        
        /// <summary>
        ///     Sdls the render geometry raw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="xy">The xy</param>
        /// <param name="xyStride">The xy stride</param>
        /// <param name="color">The color</param>
        /// <param name="colorStride">The color stride</param>
        /// <param name="uv">The uv</param>
        /// <param name="uvStride">The uv stride</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <param name="sizeIndices">The size indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGeometryRaw(
            IntPtr renderer,
            IntPtr texture,
            [In] float[] xy,
            int xyStride,
            [In] int[] color,
            int colorStride,
            [In] float[] uv,
            int uvStride,
            int numVertices,
            IntPtr indices,
            int numIndices,
            int sizeIndices
        );

        
        /// <summary>
        ///     Sdls the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointF(
            IntPtr renderer,
            float x,
            float y
        );

        
        /// <summary>
        ///     Sdls the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawPointsF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );

        
        /// <summary>
        ///     Sdls the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLineF(
            IntPtr renderer,
            float x1,
            float y1,
            float x2,
            float y2
        );

        
        /// <summary>
        ///     Sdls the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawLinesF(
            IntPtr renderer,
            [In] SdlFPoint[] points,
            int count
        );

        
        /// <summary>
        ///     Sdls the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );

        
        /// <summary>
        ///     Sdls the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectF(
            IntPtr renderer,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderDrawRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );

        
        /// <summary>
        ///     Sdls the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            ref SdlFRect rect
        );

        
        /// <summary>
        ///     Sdls the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectF(
            IntPtr renderer,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFillRectsF(
            IntPtr renderer,
            [In] SdlFRect[] rects,
            int count
        );

        

        
        /// <summary>
        ///     Sdls the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetClipRect(
            IntPtr renderer,
            out SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetLogicalSize(
            IntPtr renderer,
            out int w,
            out int h
        );

        
        /// <summary>
        ///     Sdls the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderGetScale(
            IntPtr renderer,
            out float scaleX,
            out float scaleY
        );

        
        /// <summary>
        ///     Sdls the render window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderWindowToLogical(
            IntPtr renderer,
            int windowX,
            int windowY,
            out float logicalX,
            out float logicalY
        );

        
        /// <summary>
        ///     Sdls the render logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderLogicalToWindow(
            IntPtr renderer,
            float logicalX,
            float logicalY,
            out int windowX,
            out int windowY
        );

        
        /// <summary>
        ///     Sdls the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderGetViewport(
            IntPtr renderer,
            out SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_RenderPresent(IntPtr renderer);

        
        /// <summary>
        ///     Sdls the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderReadPixels(
            IntPtr renderer,
            ref SdlRect rect,
            uint format,
            IntPtr pixels,
            int pitch
        );

        
        /// <summary>
        ///     Sdls the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetClipRect(
            IntPtr renderer,
            IntPtr rect
        );

        
        /// <summary>
        ///     Sdls the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetLogicalSize(
            IntPtr renderer,
            int w,
            int h
        );

        
        /// <summary>
        ///     Sdls the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetScale(
            IntPtr renderer,
            float scaleX,
            float scaleY
        );

        
        /// <summary>
        ///     Sdls the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetIntegerScale(
            IntPtr renderer,
            SdlBool enable
        );

        
        /// <summary>
        ///     Sdls the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetViewport(
            IntPtr renderer,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawBlendMode(
            IntPtr renderer,
            SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderDrawColor(
            IntPtr renderer,
            byte r,
            byte g,
            byte b,
            byte a
        );

        
        /// <summary>
        ///     Sdls the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRenderTarget(
            IntPtr renderer,
            IntPtr texture
        );

        
        /// <summary>
        ///     Sdls the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureAlphaMod(
            IntPtr texture,
            byte alpha
        );

        
        /// <summary>
        ///     Sdls the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureBlendMode(
            IntPtr texture,
            SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetTextureColorMod(
            IntPtr texture,
            byte r,
            byte g,
            byte b
        );

        
        /// <summary>
        ///     Sdls the unlock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockTexture(IntPtr texture);

        
        /// <summary>
        ///     Sdls the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr pixels,
            int pitch
        );

        
        /// <summary>
        ///     Sdls the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateTexture(
            IntPtr texture,
            IntPtr rect,
            IntPtr pixels,
            int pitch
        );

        
        /// <summary>
        ///     Sdls the update yuv texture using the specified texture
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateYUVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uPlane,
            int uPitch,
            IntPtr vPlane,
            int vPitch
        );

        
        /// <summary>
        ///     Sdls the update nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpdateNVTexture(
            IntPtr texture,
            ref SdlRect rect,
            IntPtr yPlane,
            int yPitch,
            IntPtr uvPlane,
            int uvPitch
        );

        
        /// <summary>
        ///     Sdls the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderTargetSupported(
            IntPtr renderer
        );

        
        /// <summary>
        ///     Sdls the get render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetRenderTarget(IntPtr renderer);

        
        /// <summary>
        ///     Sdls the render get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalLayer(
            IntPtr renderer
        );

        
        /// <summary>
        ///     Sdls the render get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetMetalCommandEncoder(
            IntPtr renderer
        );

        
        /// <summary>
        ///     Sdls the render set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderSetVSync(IntPtr renderer, int vsync);

        
        /// <summary>
        ///     Sdls the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RenderIsClipEnabled(IntPtr renderer);

        
        /// <summary>
        ///     Sdls the render flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_RenderFlush(IntPtr renderer);

        /// <summary>
        ///     Sdls the define pixelfourcc using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <param name="d">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_DEFINE_PIXELFOURCC(byte a, byte b, byte c, byte d) => SDL_FOURCC(a, b, c, d);

        /// <summary>
        ///     Sdls the define pixelformat using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="order">The order</param>
        /// <param name="layout">The layout</param>
        /// <param name="bits">The bits</param>
        /// <param name="bytes">The bytes</param>
        /// <returns>The uint</returns>
        public static uint SDL_DEFINE_PIXELFORMAT(
            SdlPixelType type,
            uint order,
            SdlPackedLayout layout,
            byte bits,
            byte bytes
        )
            => (uint) (
                (1 << 28) |
                ((byte) type << 24) |
                ((byte) order << 20) |
                ((byte) layout << 16) |
                (bits << 8) |
                bytes
            );

        /// <summary>
        ///     Sdls the pixelflag using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELFLAG(uint x) => (byte) ((x >> 28) & 0x0F);

        /// <summary>
        ///     Sdls the pixeltype using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELTYPE(uint x) => (byte) ((x >> 24) & 0x0F);

        /// <summary>
        ///     Sdls the pixelorder using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELORDER(uint x) => (byte) ((x >> 20) & 0x0F);

        /// <summary>
        ///     Sdls the pixellayout using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_PIXELLAYOUT(uint x) => (byte) ((x >> 16) & 0x0F);

        /// <summary>
        ///     Sdls the bitsperpixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_BITSPERPIXEL(uint x) => (byte) ((x >> 8) & 0xFF);

        /// <summary>
        ///     Sdls the bytesperpixel using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The byte</returns>
        public static byte SDL_BYTESPERPIXEL(uint x)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(x))
            {
                if (x == SdlPixelformatYuy2 ||
                    x == SdlPixelformatUyvy ||
                    x == SdlPixelformatYvyu)
                {
                    return 2;
                }

                return 1;
            }

            return (byte) (x & 0xFF);
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat indexed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_INDEXED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypeIndex1 ||
                   pType == SdlPixelType.SdlPixeltypeIndex4 ||
                   pType == SdlPixelType.SdlPixeltypeIndex8;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat packed
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_PACKED(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypePacked8 ||
                   pType == SdlPixelType.SdlPixeltypePacked16 ||
                   pType == SdlPixelType.SdlPixeltypePacked32;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat array
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_ARRAY(uint format)
        {
            if (SDL_ISPIXELFORMAT_FOURCC(format))
            {
                return false;
            }

            SdlPixelType pType =
                (SdlPixelType) SDL_PIXELTYPE(format);
            return pType == SdlPixelType.SdlPixeltypeArrayu8 ||
                   pType == SdlPixelType.SdlPixeltypeArrayu16 ||
                   pType == SdlPixelType.SdlPixeltypeArrayu32 ||
                   pType == SdlPixelType.SdlPixeltypeArrayf16 ||
                   pType == SdlPixelType.SdlPixeltypeArrayf32;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat alpha
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_ALPHA(uint format)
        {
            if (SDL_ISPIXELFORMAT_PACKED(format))
            {
                SdlPackedOrder pOrder =
                    (SdlPackedOrder) SDL_PIXELORDER(format);
                return pOrder == SdlPackedOrder.SdlPackedorderArgb ||
                       pOrder == SdlPackedOrder.SdlPackedorderRgba ||
                       pOrder == SdlPackedOrder.SdlPackedorderAbgr ||
                       pOrder == SdlPackedOrder.SdlPackedorderBgra;
            }

            if (SDL_ISPIXELFORMAT_ARRAY(format))
            {
                SdlArrayOrder aOrder =
                    (SdlArrayOrder) SDL_PIXELORDER(format);
                return aOrder == SdlArrayOrder.SdlArrayorderArgb ||
                       aOrder == SdlArrayOrder.SdlArrayorderRgba ||
                       aOrder == SdlArrayOrder.SdlArrayorderAbgr ||
                       aOrder == SdlArrayOrder.SdlArrayorderBgra;
            }

            return false;
        }

        /// <summary>
        ///     Describes whether sdl ispixelformat fourcc
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool SDL_ISPIXELFORMAT_FOURCC(uint format) => (format == 0) && (SDL_PIXELFLAG(format) != 1);

        /// <summary>
        ///     The sdl pixeltype enum
        /// </summary>
        public enum SdlPixelType
        {
            /// <summary>
            ///     The sdl pixeltype unknown sdl pixeltype
            /// </summary>
            SdlPixeltypeUnknown,

            /// <summary>
            ///     The sdl pixeltype index1 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex1,

            /// <summary>
            ///     The sdl pixeltype index4 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex4,

            /// <summary>
            ///     The sdl pixeltype index8 sdl pixeltype
            /// </summary>
            SdlPixeltypeIndex8,

            /// <summary>
            ///     The sdl pixeltype packed8 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked8,

            /// <summary>
            ///     The sdl pixeltype packed16 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked16,

            /// <summary>
            ///     The sdl pixeltype packed32 sdl pixeltype
            /// </summary>
            SdlPixeltypePacked32,

            /// <summary>
            ///     The sdl pixeltype arrayu8 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu8,

            /// <summary>
            ///     The sdl pixeltype arrayu16 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu16,

            /// <summary>
            ///     The sdl pixeltype arrayu32 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayu32,

            /// <summary>
            ///     The sdl pixeltype arrayf16 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayf16,

            /// <summary>
            ///     The sdl pixeltype arrayf32 sdl pixeltype
            /// </summary>
            SdlPixeltypeArrayf32
        }

        /// <summary>
        ///     The sdl pixelformat unknown
        /// </summary>
        public static readonly uint SdlPixelformatUnknown = 0;

        /// <summary>
        ///     The sdl bitmaporder 4321
        /// </summary>
        public static readonly uint SdlPixelformatIndex1Lsb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 1234
        /// </summary>
        public static readonly uint SdlPixelformatIndex1Msb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder1234,
                0,
                1, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 4321
        /// </summary>
        public static readonly uint SdlPixelformatIndex4Lsb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl bitmaporder 1234
        /// </summary>
        public static readonly uint SdlPixelformatIndex4Msb =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex4,
                (uint) SdlBitmapOrder.SdlBitmaporder1234,
                0,
                4, 0
            );

        /// <summary>
        ///     The sdl pixeltype index8
        /// </summary>
        public static readonly uint SdlPixelformatIndex8 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex8,
                0,
                0,
                8, 1
            );

        /// <summary>
        ///     The sdl packedlayout 332
        /// </summary>
        public static readonly uint SdlPixelformatRgb332 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked8,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout332,
                8, 1
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatXrgb444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixelformat xrgb444
        /// </summary>
        public static readonly uint SdlPixelformatRgb444 =
            SdlPixelformatXrgb444;

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatXbgr444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                12, 2
            );

        /// <summary>
        ///     The sdl pixelformat xbgr444
        /// </summary>
        public static readonly uint SdlPixelformatBgr444 =
            SdlPixelformatXbgr444;

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatXrgb1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixelformat xrgb1555
        /// </summary>
        public static readonly uint SdlPixelformatRgb555 =
            SdlPixelformatXrgb1555;

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatXbgr1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeIndex1,
                (uint) SdlBitmapOrder.SdlBitmaporder4321,
                SdlPackedLayout.SdlPackedlayout1555,
                15, 2
            );

        /// <summary>
        ///     The sdl pixelformat xbgr1555
        /// </summary>
        public static readonly uint SdlPixelformatBgr555 =
            SdlPixelformatXbgr1555;

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatArgb4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatRgba4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatAbgr4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 4444
        /// </summary>
        public static readonly uint SdlPixelformatBgra4444 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout4444,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatArgb1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 5551
        /// </summary>
        public static readonly uint SdlPixelformatRgba5551 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 1555
        /// </summary>
        public static readonly uint SdlPixelformatAbgr1555 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout1555,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 5551
        /// </summary>
        public static readonly uint SdlPixelformatBgra5551 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout5551,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 565
        /// </summary>
        public static readonly uint SdlPixelformatRgb565 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl packedlayout 565
        /// </summary>
        public static readonly uint SdlPixelformatBgr565 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked16,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout565,
                16, 2
            );

        /// <summary>
        ///     The sdl arrayorder rgb
        /// </summary>
        public static readonly uint SdlPixelformatRgb24 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderRgb,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl arrayorder bgr
        /// </summary>
        public static readonly uint SdlPixelformatBgr24 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypeArrayu8,
                (uint) SdlArrayOrder.SdlArrayorderBgr,
                0,
                24, 3
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatXrgb888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXrgb,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixelformat xrgb888
        /// </summary>
        public static readonly uint SdlPixelformatRgb888 =
            SdlPixelformatXrgb888;

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatRgbx8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgbx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatXbgr888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderXbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl pixelformat xbgr888
        /// </summary>
        public static readonly uint SdlPixelformatBgr888 =
            SdlPixelformatXbgr888;

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatBgrx8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgrx,
                SdlPackedLayout.SdlPackedlayout8888,
                24, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatArgb8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatRgba8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderRgba,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatAbgr8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderAbgr,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 8888
        /// </summary>
        public static readonly uint SdlPixelformatBgra8888 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderBgra,
                SdlPackedLayout.SdlPackedlayout8888,
                32, 4
            );

        /// <summary>
        ///     The sdl packedlayout 2101010
        /// </summary>
        public static readonly uint SdlPixelformatArgb2101010 =
            SDL_DEFINE_PIXELFORMAT(
                SdlPixelType.SdlPixeltypePacked32,
                (uint) SdlPackedOrder.SdlPackedorderArgb,
                SdlPackedLayout.SdlPackedlayout2101010,
                32, 4
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYv12 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) '1', (byte) '2'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatIyuv =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'I', (byte) 'Y', (byte) 'U', (byte) 'V'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYuy2 =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'U', (byte) 'Y', (byte) '2'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatUyvy =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'U', (byte) 'Y', (byte) 'V', (byte) 'Y'
            );

        /// <summary>
        ///     The sdl define pixelfourcc
        /// </summary>
        public static readonly uint SdlPixelformatYvyu =
            SDL_DEFINE_PIXELFOURCC(
                (byte) 'Y', (byte) 'V', (byte) 'Y', (byte) 'U'
            );

        
        /// <summary>
        ///     Sdls the alloc format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocFormat(uint pixelFormat);

        
        /// <summary>
        ///     Sdls the alloc palette using the specified ncolors
        /// </summary>
        /// <param name="ncolors">The ncolors</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AllocPalette(int ncolors);

        /// <summary>
        ///     Sdls the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CalculateGammaRamp(
            float gamma,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] ramp
        );

        
        /// <summary>
        ///     Sdls the free format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeFormat(IntPtr format);

        
        /// <summary>
        ///     Sdls the free palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreePalette(IntPtr palette);

        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetPixelFormatName(
            uint format
        );

        /// <summary>
        ///     Sdls the get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The string</returns>
        public static string SDL_GetPixelFormatName(uint format) => UTF8_ToManaged(
            INTERNAL_SDL_GetPixelFormatName(format)
        );

        
        /// <summary>
        ///     Sdls the get rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGB(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b
        );

        
        /// <summary>
        ///     Sdls the get rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetRGBA(
            uint pixel,
            IntPtr format,
            out byte r,
            out byte g,
            out byte b,
            out byte a
        );

        
        /// <summary>
        ///     Sdls the map rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGB(
            IntPtr format,
            byte r,
            byte g,
            byte b
        );

        
        /// <summary>
        ///     Sdls the map rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MapRGBA(
            IntPtr format,
            byte r,
            byte g,
            byte b,
            byte a
        );

        /// <summary>
        ///     Sdls the masks to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_MasksToPixelFormatEnum(
            int bpp,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        /// <summary>
        ///     Sdls the pixel format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_PixelFormatEnumToMasks(
            uint format,
            out int bpp,
            out uint rmask,
            out uint gmask,
            out uint bmask,
            out uint amask
        );

        
        /// <summary>
        ///     Sdls the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstcolor">The firstcolor</param>
        /// <param name="ncolors">The ncolors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPaletteColors(
            IntPtr palette,
            [In] SdlColor[] colors,
            int firstcolor,
            int ncolors
        );

        
        /// <summary>
        ///     Sdls the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetPixelFormatPalette(
            IntPtr format,
            IntPtr palette
        );

        /// <summary>
        ///     Sdls the point in rect using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_PointInRect(ref SdlPoint p, ref SdlRect r) => (p.x >= r.x) &&
                                                                                (p.x < r.x + r.w) &&
                                                                                (p.y >= r.y) &&
                                                                                (p.y < r.y + r.h)
            ? SdlBool.SdlTrue
            : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the enclose points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_EnclosePoints(
            [In] SdlPoint[] points,
            int count,
            ref SdlRect clip,
            out SdlRect result
        );

        /// <summary>
        ///     Sdls the has intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasIntersection(
            ref SdlRect a,
            ref SdlRect b
        );

        /// <summary>
        ///     Sdls the intersect rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );

        /// <summary>
        ///     Sdls the intersect rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IntersectRectAndLine(
            ref SdlRect rect,
            ref int x1,
            ref int y1,
            ref int x2,
            ref int y2
        );

        /// <summary>
        ///     Sdls the rect empty using the specified r
        /// </summary>
        /// <param name="r">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEmpty(ref SdlRect r) => r.w <= 0 || r.h <= 0 ? SdlBool.SdlTrue : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the rect equals using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        public static SdlBool SDL_RectEquals(
            ref SdlRect a,
            ref SdlRect b
        )
            => (a.x == b.x) &&
               (a.y == b.y) &&
               (a.w == b.w) &&
               (a.h == b.h)
                ? SdlBool.SdlTrue
                : SdlBool.SdlFalse;

        /// <summary>
        ///     Sdls the union rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnionRect(
            ref SdlRect a,
            ref SdlRect b,
            out SdlRect result
        );

        /// <summary>
        ///     The sdl swsurface
        /// </summary>
        public const uint SdlSwsurface = 0x00000000;

        /// <summary>
        ///     The sdl prealloc
        /// </summary>
        public const uint SdlPrealloc = 0x00000001;

        /// <summary>
        ///     The sdl rleaccel
        /// </summary>
        public const uint SdlRleaccel = 0x00000002;

        /// <summary>
        ///     The sdl dontfree
        /// </summary>
        public const uint SdlDontfree = 0x00000004;

        
        /// <summary>
        ///     Describes whether sdl mustlock
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The bool</returns>
        public static bool SDL_MUSTLOCK(IntPtr surface)
        {
            SdlSurface sur;
            sur = (SdlSurface) Marshal.PtrToStructure(
                surface,
                typeof(SdlSurface)
            );
            return (sur.flags & SdlRleaccel) != 0;
        }

        
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitSurface(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_BlitScaled(
            IntPtr src,
            IntPtr srcrect,
            IntPtr dst,
            IntPtr dstrect
        );

        
        /// <summary>
        ///     Sdls the convert pixels using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ConvertPixels(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );

        
        /// <summary>
        ///     Sdls the premultiply alpha using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="srcFormat">The src format</param>
        /// <param name="src">The src</param>
        /// <param name="srcPitch">The src pitch</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstPitch">The dst pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PremultiplyAlpha(
            int width,
            int height,
            uint srcFormat,
            IntPtr src,
            int srcPitch,
            uint dstFormat,
            IntPtr dst,
            int dstPitch
        );

        
        /// <summary>
        ///     Sdls the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurface(
            IntPtr src,
            IntPtr fmt,
            uint flags
        );

        
        /// <summary>
        ///     Sdls the convert surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_ConvertSurfaceFormat(
            IntPtr src,
            uint pixelFormat,
            uint flags
        );

        
        /// <summary>
        ///     Sdls the create rgb surface using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurface(
            uint flags,
            int width,
            int height,
            int depth,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        
        /// <summary>
        ///     Sdls the create rgb surface from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="rmask">The rmask</param>
        /// <param name="gmask">The gmask</param>
        /// <param name="bmask">The bmask</param>
        /// <param name="amask">The amask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint rmask,
            uint gmask,
            uint bmask,
            uint amask
        );

        
        /// <summary>
        ///     Sdls the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormat(
            uint flags,
            int width,
            int height,
            int depth,
            uint format
        );

        
        /// <summary>
        ///     Sdls the create rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateRGBSurfaceWithFormatFrom(
            IntPtr pixels,
            int width,
            int height,
            int depth,
            int pitch,
            uint format
        );

        
        /// <summary>
        ///     Sdls the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            ref SdlRect rect,
            uint color
        );

        
        /// <summary>
        ///     Sdls the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRect(
            IntPtr dst,
            IntPtr rect,
            uint color
        );

        
        /// <summary>
        ///     Sdls the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_FillRects(
            IntPtr dst,
            [In] SdlRect[] rects,
            int count,
            uint color
        );

        
        /// <summary>
        ///     Sdls the free surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeSurface(IntPtr surface);

        
        /// <summary>
        ///     Sdls the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GetClipRect(
            IntPtr surface,
            out SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasColorKey(IntPtr surface);

        
        /// <summary>
        ///     Sdls the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetColorKey(
            IntPtr surface,
            out uint key
        );

        
        /// <summary>
        ///     Sdls the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceAlphaMod(
            IntPtr surface,
            out byte alpha
        );

        
        /// <summary>
        ///     Sdls the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceBlendMode(
            IntPtr surface,
            out SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSurfaceColorMod(
            IntPtr surface,
            out byte r,
            out byte g,
            out byte b
        );

        
        
        
        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadBMP_RW(
            IntPtr src,
            int freesrc
        );

        /// <summary>
        ///     Sdls the load bmp using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadBMP(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_LoadBMP_RW(rwops, 1);
        }

        
        /// <summary>
        ///     Sdls the lock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LockSurface(IntPtr surface);

        
        /// <summary>
        ///     Sdls the lower blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlit(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the lower blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_LowerBlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        
        
        /// <summary>
        ///     Internals the sdl save bmp rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_SaveBMP_RW(
            IntPtr surface,
            IntPtr src,
            int freesrc
        );

        /// <summary>
        ///     Sdls the save bmp using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SDL_SaveBMP(IntPtr surface, string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "wb");
            return INTERNAL_SDL_SaveBMP_RW(surface, rwops, 1);
        }

        
        /// <summary>
        ///     Sdls the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_SetClipRect(
            IntPtr surface,
            ref SdlRect rect
        );

        
        /// <summary>
        ///     Sdls the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetColorKey(
            IntPtr surface,
            int flag,
            uint key
        );

        
        /// <summary>
        ///     Sdls the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceAlphaMod(
            IntPtr surface,
            byte alpha
        );

        
        /// <summary>
        ///     Sdls the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceBlendMode(
            IntPtr surface,
            SdlBlendMode blendMode
        );

        
        /// <summary>
        ///     Sdls the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceColorMod(
            IntPtr surface,
            byte r,
            byte g,
            byte b
        );

        
        /// <summary>
        ///     Sdls the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfacePalette(
            IntPtr surface,
            IntPtr palette
        );

        
        /// <summary>
        ///     Sdls the set surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetSurfaceRLE(
            IntPtr surface,
            int flag
        );

        
        /// <summary>
        ///     Sdls the has surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSurfaceRLE(
            IntPtr surface
        );

        
        /// <summary>
        ///     Sdls the soft stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretch(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the soft stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SoftStretchLinear(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the unlock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSurface(IntPtr surface);

        
        /// <summary>
        ///     Sdls the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlit(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcrect">The srcrect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstrect">The dstrect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_UpperBlitScaled(
            IntPtr src,
            ref SdlRect srcrect,
            IntPtr dst,
            ref SdlRect dstrect
        );

        
        /// <summary>
        ///     Sdls the duplicate surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_DuplicateSurface(IntPtr surface);
        
        /// <summary>
        ///     Sdls the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasClipboardText();

        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetClipboardText();

        /// <summary>
        ///     Sdls the get clipboard text
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetClipboardText() => UTF8_ToManaged(INTERNAL_SDL_GetClipboardText(), true);

        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_SetClipboardText(
            byte[] text
        );

        /// <summary>
        ///     Sdls the set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The result</returns>
        public static  int SDL_SetClipboardText(
            string text
        )
        {
            byte[] utf8Text = Utf8EncodeHeap(text);
            int result = INTERNAL_SDL_SetClipboardText(
                utf8Text
            );
            return result;
        }

        
        
        
        /// <summary>
        ///     The sdl pressed
        /// </summary>
        public const byte SdlPressed = 1;

        /// <summary>
        ///     The sdl released
        /// </summary>
        public const byte SdlReleased = 0;

        
        /// <summary>
        ///     The sdl texteditingevent text size
        /// </summary>
        public const int SdlTexteditingeventTextSize = 32;

        /// <summary>
        ///     The sdl textinputevent text size
        /// </summary>
        public const int SdlTextinputeventTextSize = 32;


        /// <summary>
        ///     The sdl eventfilter
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate int SdlEventFilter(
            IntPtr userdata, 
            IntPtr sdlevent 
        );
        
        /// <summary>
        ///     Sdls the pump events
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PumpEvents();

        /// <summary>
        ///     Sdls the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numevents">The numevents</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PeepEvents(
            [Out] SdlEvent[] events,
            int numevents,
            SdlEventaction action,
            SdlEventType minType,
            SdlEventType maxType
        );

        
        /// <summary>
        ///     Sdls the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvent(SdlEventType type);

        /// <summary>
        ///     Sdls the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasEvents(
            SdlEventType minType,
            SdlEventType maxType
        );

        
        /// <summary>
        ///     Sdls the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvent(SdlEventType type);

        /// <summary>
        ///     Sdls the flush events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FlushEvents(
            SdlEventType min,
            SdlEventType max
        );

        
        /// <summary>
        ///     Sdls the poll event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PollEvent(out SdlEvent @event);

        
        /// <summary>
        ///     Sdls the wait event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEvent(out SdlEvent @event);

        
        /// <summary>
        ///     Sdls the wait event timeout using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WaitEventTimeout(out SdlEvent @event, int timeout);

        
        /// <summary>
        ///     Sdls the push event using the specified  event
        /// </summary>
        /// <param name="event">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_PushEvent(ref SdlEvent @event);

        
        /// <summary>
        ///     Sdls the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetEventFilter(
            SdlEventFilter filter,
            IntPtr userdata
        );

        
        /// <summary>
        ///     Sdls the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern SdlBool SDL_GetEventFilter(
            out IntPtr filter,
            out IntPtr userdata
        );

        /// <summary>
        ///     Sdls the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The retval</returns>
        public static SdlBool SDL_GetEventFilter(
            out SdlEventFilter filter,
            out IntPtr userdata
        )
        {
            IntPtr result = IntPtr.Zero;
            SdlBool retval = SDL_GetEventFilter(out result, out userdata);
            if (result != IntPtr.Zero)
            {
                filter = (SdlEventFilter) Marshal.GetDelegateForFunctionPointer(
                    result,
                    typeof(SdlEventFilter)
                );
            }
            else
            {
                filter = null;
            }

            return retval;
        }

        
        /// <summary>
        ///     Sdls the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AddEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );

        
        /// <summary>
        ///     Sdls the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_DelEventWatch(
            SdlEventFilter filter,
            IntPtr userdata
        );

        
        /// <summary>
        ///     Sdls the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FilterEvents(
            SdlEventFilter filter,
            IntPtr userdata
        );
        
        /// <summary>
        ///     The sdl query
        /// </summary>
        public const int SdlQuery = -1;

        /// <summary>
        ///     The sdl ignore
        /// </summary>
        public const int SdlIgnore = 0;

        /// <summary>
        ///     The sdl disable
        /// </summary>
        public const int SdlDisable = 0;

        /// <summary>
        ///     The sdl enable
        /// </summary>
        public const int SdlEnable = 1;
        
        /// <summary>
        ///     Sdls the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_EventState(SdlEventType type, int state);
        
        /// <summary>
        ///     Sdls the get event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The byte</returns>
        public static byte SDL_GetEventState(SdlEventType type) => SDL_EventState(type, SdlQuery);

        
        /// <summary>
        ///     Sdls the register events using the specified numevents
        /// </summary>
        /// <param name="numevents">The numevents</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_RegisterEvents(int numevents);
        
        /// <summary>
        ///     The sdlk scancode mask
        /// </summary>
        public const int SdlkScancodeMask = 1 << 30;

        /// <summary>
        ///     Sdls the scancode to keycode using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The sdl keycode</returns>
        public static SdlKeycode SDL_SCANCODE_TO_KEYCODE(SdlScancode x) => (SdlKeycode) ((int) x | SdlkScancodeMask);
        
        /// <summary>
        ///     Sdls the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardFocus();
        
        /// <summary>
        ///     Sdls the get keyboard state using the specified numkeys
        /// </summary>
        /// <param name="numkeys">The numkeys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetKeyboardState(out int numkeys);
        
        /// <summary>
        ///     Sdls the get mod state
        /// </summary>
        /// <returns>The sdl keymod</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeymod SDL_GetModState();
        
        /// <summary>
        ///     Sdls the set mod state using the specified modstate
        /// </summary>
        /// <param name="modstate">The modstate</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetModState(SdlKeymod modstate);
        
        /// <summary>
        ///     Sdls the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlKeycode SDL_GetKeyFromScancode(SdlScancode scancode);
        
        /// <summary>
        ///     Sdls the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlScancode SDL_GetScancodeFromKey(SdlKeycode key);
        
        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetScancodeName(SdlScancode scancode);

        /// <summary>
        ///     Sdls the get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The string</returns>
        public static string SDL_GetScancodeName(SdlScancode scancode) => UTF8_ToManaged(
            INTERNAL_SDL_GetScancodeName(scancode)
        );
        
        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlScancode INTERNAL_SDL_GetScancodeFromName(
            byte[] name
        );

        /// <summary>
        ///     Sdl the get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        public static  SdlScancode SDL_GetScancodeFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetScancodeFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }
        
        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetKeyName(SdlKeycode key);

        /// <summary>
        ///     Sdl the get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The string</returns>
        public static string SDL_GetKeyName(SdlKeycode key) => UTF8_ToManaged(INTERNAL_SDL_GetKeyName(key));
        
        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlKeycode INTERNAL_SDL_GetKeyFromName(
            byte[] name
        );

        /// <summary>
        ///     Sdls the get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        public static  SdlKeycode SDL_GetKeyFromName(string name)
        {
            int utf8NameBufSize = Utf8Size(name);
            byte[] utf8Name = new byte[utf8NameBufSize];
            return INTERNAL_SDL_GetKeyFromName(
                Utf8Encode(name, utf8Name, utf8NameBufSize)
            );
        }
        
        /// <summary>
        ///     Sdls the start text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StartTextInput();
        
        /// <summary>
        ///     Sdls the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsTextInputActive();
        
        /// <summary>
        ///     Sdl the stop text input
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_StopTextInput();
        
        /// <summary>
        ///     Sdl the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetTextInputRect(ref SdlRect rect);
        
        /// <summary>
        ///     Sdl the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasScreenKeyboardSupport();
        
        /// <summary>
        ///     Sdl the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsScreenKeyboardShown(IntPtr window);
        
        /// <summary>
        ///     Sdl the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetMouseFocus();
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, out int y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(out int x, IntPtr y);
        
        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetMouseState(IntPtr x, IntPtr y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, out int y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(out int x, IntPtr y);
        
        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetGlobalMouseState(IntPtr x, IntPtr y);
        
        /// <summary>
        ///     Sdl the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetRelativeMouseState(out int x, out int y);
        
        /// <summary>
        ///     Sdl the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_WarpMouseInWindow(IntPtr window, int x, int y);
        
        /// <summary>
        ///     Sdl the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_WarpMouseGlobal(int x, int y);
        
        /// <summary>
        ///     Sdl the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SetRelativeMouseMode(SdlBool enabled);
        
        /// <summary>
        ///     Sdl the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_CaptureMouse(SdlBool enabled);
        
        /// <summary>
        ///     Sdl the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetRelativeMouseMode();
        
        /// <summary>
        ///     Sdl the create cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateCursor(
            IntPtr data,
            IntPtr mask,
            int w,
            int h,
            int hotX,
            int hotY
        );
        
        /// <summary>
        ///     Sdls the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateColorCursor(
            IntPtr surface,
            int hotX,
            int hotY
        );
        
        /// <summary>
        ///     Sdls the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_CreateSystemCursor(SdlSystemCursor id);
        
        /// <summary>
        ///     Sdls the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetCursor(IntPtr cursor);
        
        /// <summary>
        ///     Sdls the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetCursor();
        
        /// <summary>
        ///     Sdls the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeCursor(IntPtr cursor);
        
        /// <summary>
        ///     Sdls the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_ShowCursor(int toggle);

        /// <summary>
        ///     Sdls the button using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The uint</returns>
        public static uint SDL_BUTTON(uint x) =>
            // If only there were a better way of doing this in C#
            (uint) (1 << ((int) x - 1));

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint SdlButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint SdlButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint SdlButtonRight = 3;

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public const uint SdlButtonX1 = 4;

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public const uint SdlButtonX2 = 5;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public static readonly uint SdlButtonLmask = SDL_BUTTON(SdlButtonLeft);

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public static readonly uint SdlButtonMmask = SDL_BUTTON(SdlButtonMiddle);

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public static readonly uint SdlButtonRmask = SDL_BUTTON(SdlButtonRight);

        /// <summary>
        ///     The sdl button x1
        /// </summary>
        public static readonly uint SdlButtonX1Mask = SDL_BUTTON(SdlButtonX1);

        /// <summary>
        ///     The sdl button x2
        /// </summary>
        public static readonly uint SdlButtonX2Mask = SDL_BUTTON(SdlButtonX2);
        
        /// <summary>
        ///     The max value
        /// </summary>
        public const uint SdlTouchMouseid = uint.MaxValue;
        
        /// <summary>
        /// Sdl the get num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchDevices();

        
        /// <summary>
        /// Sdl the get touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long SDL_GetTouchDevice(int index);
        
        /// <summary>
        /// Sdl the get num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumTouchFingers(long touchId);
        
        /// <summary>
        /// Sdl the get touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetTouchFinger(long touchId, int index);
        
        /// <summary>
        ///     Sdls the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlTouchDeviceType SDL_GetTouchDeviceType(long touchId);

        


        /// <summary>
        ///     The sdl hat centered
        /// </summary>
        public const byte SdlHatCentered = 0x00;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatUp = 0x01;

        /// <summary>
        ///     The sdl hat right
        /// </summary>
        public const byte SdlHatRight = 0x02;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatDown = 0x04;

        /// <summary>
        ///     The sdl hat left
        /// </summary>
        public const byte SdlHatLeft = 0x08;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatRightup = SdlHatRight | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatRightdown = SdlHatRight | SdlHatDown;

        /// <summary>
        ///     The sdl hat up
        /// </summary>
        public const byte SdlHatLeftup = SdlHatLeft | SdlHatUp;

        /// <summary>
        ///     The sdl hat down
        /// </summary>
        public const byte SdlHatLeftdown = SdlHatLeft | SdlHatDown;


        /// <summary>
        ///     The sdl iphone max gforce
        /// </summary>
        public const float SdlIphoneMaxGforce = 5.0f;

        
        /// <summary>
        ///     Sdls the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumble(
            IntPtr joystick,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );

        
        /// <summary>
        ///     Sdls the joystick rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickRumbleTriggers(
            IntPtr joystick,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );

        
        /// <summary>
        ///     Sdls the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickClose(IntPtr joystick);

        /// <summary>
        ///     Sdls the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickEventState(int state);

        
        /// <summary>
        ///     Sdls the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_JoystickGetAxis(
            IntPtr joystick,
            int axis
        );

        
        /// <summary>
        ///     Sdls the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAxisInitialState(
            IntPtr joystick,
            int axis,
            out ushort state
        );

        
        /// <summary>
        ///     Sdls the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetBall(
            IntPtr joystick,
            int ball,
            out int dx,
            out int dy
        );

        
        /// <summary>
        ///     Sdls the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetButton(
            IntPtr joystick,
            int button
        );

        
        /// <summary>
        ///     Sdls the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_JoystickGetHat(
            IntPtr joystick,
            int hat
        );

        
        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickName(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickName(IntPtr joystick) => UTF8_ToManaged(
            INTERNAL_SDL_JoystickName(joystick)
        );

        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickNameForIndex(
            int deviceIndex
        );

        /// <summary>
        ///     Sdls the joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickNameForIndex(int deviceIndex) => UTF8_ToManaged(
            INTERNAL_SDL_JoystickNameForIndex(deviceIndex)
        );

        
        /// <summary>
        ///     Sdls the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumAxes(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumBalls(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumButtons(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickNumHats(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickOpen(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickUpdate();

        
        /// <summary>
        ///     Sdls the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumJoysticks();

        /// <summary>
        ///     Sdls the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetDeviceGUID(
            int deviceIndex
        );

        
        /// <summary>
        ///     Sdls the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern Guid SDL_JoystickGetGUID(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickGetGUIDString(
            Guid guid,
            byte[] pszGuid,
            int cbGuid
        );

        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern  Guid INTERNAL_SDL_JoystickGetGUIDFromString(
            byte[] pchGuid
        );

        /// <summary>
        ///     Sdls the joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        public static  Guid SDL_JoystickGetGUIDFromString(string pchGuid)
        {
            int utf8PchGuidBufSize = Utf8Size(pchGuid);
            byte[] utf8PchGuid = new byte[utf8PchGuidBufSize];
            return INTERNAL_SDL_JoystickGetGUIDFromString(
                Utf8Encode(pchGuid, utf8PchGuid, utf8PchGuidBufSize)
            );
        }

        
        /// <summary>
        ///     Sdls the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceVendor(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProduct(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetDeviceProductVersion(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetDeviceType(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickGetDeviceInstanceID(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetVendor(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProduct(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_JoystickGetProductVersion(IntPtr joystick);

        
        /// <summary>
        ///     Internals the sdl joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_JoystickGetSerial(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The string</returns>
        public static string SDL_JoystickGetSerial(
            IntPtr joystick
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_JoystickGetSerial(joystick)
            );

        
        /// <summary>
        ///     Sdls the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickType SDL_JoystickGetType(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickGetAttached(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickInstanceID(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlJoystickPowerLevel SDL_JoystickCurrentPowerLevel(
            IntPtr joystick
        );

        
        /// <summary>
        ///     Sdls the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromInstanceID(int instanceId);

        
        /// <summary>
        ///     Sdls the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockJoysticks();

        
        /// <summary>
        ///     Sdls the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockJoysticks();

        
        /// <summary>
        ///     Sdls the joystick from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_JoystickFromPlayerIndex(int playerIndex);

        
        /// <summary>
        ///     Sdls the joystick set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_JoystickSetPlayerIndex(
            IntPtr joystick,
            int playerIndex
        );

        
        /// <summary>
        ///     Sdls the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="naxes">The naxes</param>
        /// <param name="nbuttons">The nbuttons</param>
        /// <param name="nhats">The nhats</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickAttachVirtual(
            int type,
            int naxes,
            int nbuttons,
            int nhats
        );

        
        /// <summary>
        ///     Sdls the joystick detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickDetachVirtual(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickIsVirtual(int deviceIndex);

        
        /// <summary>
        ///     Sdls the joystick set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualAxis(
            IntPtr joystick,
            int axis,
            short value
        );

        
        /// <summary>
        ///     Sdls the joystick set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualButton(
            IntPtr joystick,
            int button,
            byte value
        );

        
        /// <summary>
        ///     Sdls the joystick set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetVirtualHat(
            IntPtr joystick,
            int hat,
            byte value
        );

        
        /// <summary>
        ///     Sdls the joystick has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasLED(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumble(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_JoystickHasRumbleTriggers(IntPtr joystick);

        
        /// <summary>
        ///     Sdls the joystick set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSetLED(
            IntPtr joystick,
            byte red,
            byte green,
            byte blue
        );

        
        /// <summary>
        ///     Sdls the joystick send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickSendEffect(
            IntPtr joystick,
            IntPtr data,
            int size
        );


        // FIXME: I'd rather this somehow be private...

        // FIXME: I'd rather this somehow be private...

        

        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_GameControllerAddMapping(
            byte[] mappingString
        );

        /// <summary>
        ///     Sdls the game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The result</returns>
        public static  int SDL_GameControllerAddMapping(
            string mappingString
        )
        {
            byte[] utf8MappingString = Utf8EncodeHeap(mappingString);
            int result = INTERNAL_SDL_GameControllerAddMapping(
                utf8MappingString
            );
            return result;
        }

        
        /// <summary>
        ///     Sdls the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerNumMappings();

        
        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForIndex(int mappingIndex);

        /// <summary>
        ///     Sdls the game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForIndex(int mappingIndex) => UTF8_ToManaged(
            INTERNAL_SDL_GameControllerMappingForIndex(
                mappingIndex
            ),
            true
        );

        
        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freerw">The freerw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_SDL_GameControllerAddMappingsFromRW(
            IntPtr rw,
            int freerw
        );

        /// <summary>
        ///     Sdls the game controller add mappings from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SDL_GameControllerAddMappingsFromFile(string file)
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_GameControllerAddMappingsFromRW(rwops, 1);
        }

        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForGUID(
            Guid guid
        );

        /// <summary>
        ///     Sdls the game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForGUID(Guid guid) => UTF8_ToManaged(
            INTERNAL_SDL_GameControllerMappingForGUID(guid),
            true
        );

        
        /// <summary>
        ///     Internals the sdl game controller mapping using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMapping(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller mapping using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMapping(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMapping(
                    gamecontroller
                ),
                true
            );

        /// <summary>
        ///     Sdls the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsGameController(int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerNameForIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdls the game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerNameForIndex(
            int joystickIndex
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerNameForIndex(joystickIndex)
            );

        
        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        );

        /// <summary>
        ///     Sdls the game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerMappingForDeviceIndex(
            int joystickIndex
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerMappingForDeviceIndex(joystickIndex),
                true
            );

        
        /// <summary>
        ///     Sdls the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerOpen(int joystickIndex);

        
        /// <summary>
        ///     Internals the sdl game controller name using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerName(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller name using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerName(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerName(gamecontroller)
            );

        
        /// <summary>
        ///     Sdls the game controller get vendor using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetVendor(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Sdls the game controller get product using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProduct(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Sdls the game controller get product version using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort SDL_GameControllerGetProductVersion(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Internals the sdl game controller get serial using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetSerial(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller get serial using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetSerial(
            IntPtr gamecontroller
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetSerial(gamecontroller)
            );

        
        /// <summary>
        ///     Sdls the game controller get attached using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerGetAttached(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Sdls the game controller get joystick using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerGetJoystick(
            IntPtr gamecontroller
        );

        /// <summary>
        ///     Sdls the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerEventState(int state);

        /// <summary>
        ///     Sdls the game controller update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerUpdate();

        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlGameControllerAxis INTERNAL_SDL_GameControllerGetAxisFromString(
            byte[] pchString
        );

        /// <summary>
        ///     Sdls the game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        public static  SdlGameControllerAxis SDL_GameControllerGetAxisFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte[] utf8PchString = new byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetAxisFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForAxis(
            SdlGameControllerAxis axis
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForAxis(
                    axis
                )
            );

        
        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get bind for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForAxis(
                gamecontroller,
                axis
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind();
            result.bindType = (SdlGameControllerBindType) dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        
        /// <summary>
        ///     Sdls the game controller get axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern short SDL_GameControllerGetAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlGameControllerButton INTERNAL_SDL_GameControllerGetButtonFromString(
            byte[] pchString
        );

        /// <summary>
        ///     Sdls the game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        public static  SdlGameControllerButton SDL_GameControllerGetButtonFromString(
            string pchString
        )
        {
            int utf8PchStringBufSize = Utf8Size(pchString);
            byte[] utf8PchString = new byte[utf8PchStringBufSize];
            return INTERNAL_SDL_GameControllerGetButtonFromString(
                Utf8Encode(pchString, utf8PchString, utf8PchStringBufSize)
            );
        }

        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetStringForButton(
            SdlGameControllerButton button
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetStringForButton(button)
            );

        
        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern InternalSdlGameControllerButtonBind INTERNAL_SDL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get bind for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The result</returns>
        public static SdlGameControllerButtonBind SDL_GameControllerGetBindForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        )
        {
            // This is guaranteed to never be null
            InternalSdlGameControllerButtonBind dumb = INTERNAL_SDL_GameControllerGetBindForButton(
                gamecontroller,
                button
            );
            SdlGameControllerButtonBind result = new SdlGameControllerButtonBind();
            result.bindType = (SdlGameControllerBindType) dumb.bindType;
            result.value.hat.hat = dumb.unionVal0;
            result.value.hat.hat_mask = dumb.unionVal1;
            return result;
        }

        
        /// <summary>
        ///     Sdls the game controller get button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte SDL_GameControllerGetButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        
        /// <summary>
        ///     Sdls the game controller rumble using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumble(
            IntPtr gamecontroller,
            ushort lowFrequencyRumble,
            ushort highFrequencyRumble,
            uint durationMs
        );

        
        /// <summary>
        ///     Sdls the game controller rumble triggers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerRumbleTriggers(
            IntPtr gamecontroller,
            ushort leftRumble,
            ushort rightRumble,
            uint durationMs
        );

        
        /// <summary>
        ///     Sdls the game controller close using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerClose(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );

        /// <summary>
        ///     Sdls the game controller get apple sf symbols name for button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForButton(gamecontroller, button)
            );

        
        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );

        /// <summary>
        ///     Sdls the game controller get apple sf symbols name for axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The string</returns>
        public static string SDL_GameControllerGetAppleSFSymbolsNameForAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GameControllerGetAppleSFSymbolsNameForAxis(gamecontroller, axis)
            );

        
        /// <summary>
        ///     Sdls the game controller from instance id using the specified joyid
        /// </summary>
        /// <param name="joyid">The joyid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromInstanceID(int joyid);

        
        /// <summary>
        ///     Sdls the game controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerTypeForIndex(
            int joystickIndex
        );

        
        /// <summary>
        ///     Sdls the game controller get type using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlGameControllerType SDL_GameControllerGetType(
            IntPtr gamecontroller
        );

        
        /// <summary>
        ///     Sdls the game controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GameControllerFromPlayerIndex(
            int playerIndex
        );

        
        /// <summary>
        ///     Sdls the game controller set player index using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_GameControllerSetPlayerIndex(
            IntPtr gamecontroller,
            int playerIndex
        );

        
        /// <summary>
        ///     Sdls the game controller has led using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasLED(
            IntPtr gamecontroller
        );
        
        /// <summary>
        ///     Sdls the game controller has rumble using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumble(
            IntPtr gamecontroller
        );
        
        /// <summary>
        ///     Sdls the game controller has rumble triggers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasRumbleTriggers(
            IntPtr gamecontroller
        );
        
        /// <summary>
        ///     Sdls the game controller set led using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetLED(
            IntPtr gamecontroller,
            byte red,
            byte green,
            byte blue
        );
        
        /// <summary>
        ///     Sdls the game controller has axis using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasAxis(
            IntPtr gamecontroller,
            SdlGameControllerAxis axis
        );
        
        /// <summary>
        ///     Sdls the game controller has button using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasButton(
            IntPtr gamecontroller,
            SdlGameControllerButton button
        );
        
        /// <summary>
        ///     Sdls the game controller get num touchpads using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpads(
            IntPtr gamecontroller
        );
        
        /// <summary>
        ///     Sdls the game controller get num touchpad fingers using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetNumTouchpadFingers(
            IntPtr gamecontroller,
            int touchpad
        );
        
        /// <summary>
        ///     Sdls the game controller get touchpad finger using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetTouchpadFinger(
            IntPtr gamecontroller,
            int touchpad,
            int finger,
            out byte state,
            out float x,
            out float y,
            out float pressure
        );
        
        /// <summary>
        ///     Sdls the game controller has sensor using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerHasSensor(
            IntPtr gamecontroller,
            SdlSensorType type
        );
        
        /// <summary>
        ///     Sdls the game controller set sensor enabled using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSetSensorEnabled(
            IntPtr gamecontroller,
            SdlSensorType type,
            SdlBool enabled
        );
        
        /// <summary>
        ///     Sdls the game controller is sensor enabled using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GameControllerIsSensorEnabled(
            IntPtr gamecontroller,
            SdlSensorType type
        );
        
        /// <summary>
        ///     Sdls the game controller get sensor data using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerGetSensorData(
            IntPtr gamecontroller,
            SdlSensorType type,
            IntPtr data,
            int numValues
        );
        
        /// <summary>
        ///     Sdls the game controller get sensor data rate using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern float SDL_GameControllerGetSensorDataRate(
            IntPtr gamecontroller,
            SdlSensorType type
        );
        
        /// <summary>
        ///     Sdls the game controller send effect using the specified gamecontroller
        /// </summary>
        /// <param name="gamecontroller">The gamecontroller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GameControllerSendEffect(
            IntPtr gamecontroller,
            IntPtr data,
            int size
        );

        /// <summary>
        ///     The sdl haptic constant
        /// </summary>
        public const ushort SdlHapticConstant = 1 << 0;

        /// <summary>
        ///     The sdl haptic sine
        /// </summary>
        public const ushort SdlHapticSine = 1 << 1;

        /// <summary>
        ///     The sdl haptic leftright
        /// </summary>
        public const ushort SdlHapticLeftright = 1 << 2;

        /// <summary>
        ///     The sdl haptic triangle
        /// </summary>
        public const ushort SdlHapticTriangle = 1 << 3;

        /// <summary>
        ///     The sdl haptic sawtoothup
        /// </summary>
        public const ushort SdlHapticSawtoothup = 1 << 4;

        /// <summary>
        ///     The sdl haptic sawtoothdown
        /// </summary>
        public const ushort SdlHapticSawtoothdown = 1 << 5;

        /// <summary>
        ///     The sdl haptic spring
        /// </summary>
        public const ushort SdlHapticSpring = 1 << 7;

        /// <summary>
        ///     The sdl haptic damper
        /// </summary>
        public const ushort SdlHapticDamper = 1 << 8;

        /// <summary>
        ///     The sdl haptic inertia
        /// </summary>
        public const ushort SdlHapticInertia = 1 << 9;

        /// <summary>
        ///     The sdl haptic friction
        /// </summary>
        public const ushort SdlHapticFriction = 1 << 10;

        /// <summary>
        ///     The sdl haptic custom
        /// </summary>
        public const ushort SdlHapticCustom = 1 << 11;

        /// <summary>
        ///     The sdl haptic gain
        /// </summary>
        public const ushort SdlHapticGain = 1 << 12;

        /// <summary>
        ///     The sdl haptic autocenter
        /// </summary>
        public const ushort SdlHapticAutocenter = 1 << 13;

        /// <summary>
        ///     The sdl haptic status
        /// </summary>
        public const ushort SdlHapticStatus = 1 << 14;

        /// <summary>
        ///     The sdl haptic pause
        /// </summary>
        public const ushort SdlHapticPause = 1 << 15;

        
        /// <summary>
        ///     The sdl haptic polar
        /// </summary>
        public const byte SdlHapticPolar = 0;

        /// <summary>
        ///     The sdl haptic cartesian
        /// </summary>
        public const byte SdlHapticCartesian = 1;

        /// <summary>
        ///     The sdl haptic spherical
        /// </summary>
        public const byte SdlHapticSpherical = 2;

        /// <summary>
        ///     The sdl haptic steering axis
        /// </summary>
        public const byte SdlHapticSteeringAxis = 3; 

        
        /// <summary>
        ///     The sdl haptic infinity
        /// </summary>
        public const uint SdlHapticInfinity = 4294967295U;

        /// <summary>
        ///     Sdls the haptic close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticClose(IntPtr haptic);
        
        /// <summary>
        ///     Sdls the haptic destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HapticDestroyEffect(
            IntPtr haptic,
            int effect
        );
        
        /// <summary>
        ///     Sdls the haptic effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticEffectSupported(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /// <summary>
        ///     Sdls the haptic get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticGetEffectStatus(
            IntPtr haptic,
            int effect
        );

        /// <summary>
        ///     Sdls the haptic index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticIndex(IntPtr haptic);

        /// <summary>
        ///     Internals the sdl haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_HapticName(int deviceIndex);

        /// <summary>
        ///     Sdls the haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_HapticName(int deviceIndex) => UTF8_ToManaged(INTERNAL_SDL_HapticName(deviceIndex));
        
        /// <summary>
        ///     Sdls the haptic new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNewEffect(
            IntPtr haptic,
            ref SdlHapticEffect effect
        );

        /// <summary>
        ///     Sdls the haptic num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumAxes(IntPtr haptic);

        /// <summary>
        ///     Sdls the haptic num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffects(IntPtr haptic);
        
        /// <summary>
        ///     Sdls the haptic num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticNumEffectsPlaying(IntPtr haptic);

        /// <summary>
        ///     Sdls the haptic open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpen(int deviceIndex);

        /// <summary>
        ///     Sdls the haptic opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticOpened(int deviceIndex);

        /// <summary>
        ///     Sdls the haptic open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromJoystick(
            IntPtr joystick
        );

        /// <summary>
        ///     Sdls the haptic open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_HapticOpenFromMouse();

        /// <summary>
        ///     Sdls the haptic pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticPause(IntPtr haptic);
        
        /// <summary>
        ///     Sdls the haptic query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_HapticQuery(IntPtr haptic);
        
        /// <summary>
        ///     Sdls the haptic rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleInit(IntPtr haptic);

        /// <summary>
        ///     Sdls the haptic rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumblePlay(
            IntPtr haptic,
            float strength,
            uint length
        );

        /// <summary>
        ///     Sdls the haptic rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleStop(IntPtr haptic);
        
        /// <summary>
        ///     Sdls the haptic rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRumbleSupported(IntPtr haptic);

        /// <summary>
        ///     Sdls the haptic run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticRunEffect(
            IntPtr haptic,
            int effect,
            uint iterations
        );

        /// <summary>
        ///     Sdls the haptic set autocenter using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autocenter">The autocenter</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetAutocenter(
            IntPtr haptic,
            int autocenter
        );

        /// <summary>
        ///     Sdls the haptic set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticSetGain(
            IntPtr haptic,
            int gain
        );

        /// <summary>
        ///     Sdls the haptic stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopAll(IntPtr haptic);

        
        /// <summary>
        ///     Sdls the haptic stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticStopEffect(
            IntPtr haptic,
            int effect
        );

        /// <summary>
        ///     Sdls the haptic unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUnpause(IntPtr haptic);

        /// <summary>
        ///     Sdls the haptic update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_HapticUpdateEffect(
            IntPtr haptic,
            int effect,
            ref SdlHapticEffect data
        );

        
        /// <summary>
        ///     Sdls the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_JoystickIsHaptic(IntPtr joystick);

        /// <summary>
        ///     Sdls the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_MouseIsHaptic();

        /// <summary>
        ///     Sdls the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumHaptics();

        /// <summary>
        ///     The sdl standard gravity
        /// </summary>
        public const float SdlStandardGravity = 9.80665f;

        /// <summary>
        ///     Sdls the num sensors
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_NumSensors();

        /// <summary>
        ///     Internals the sdl sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetDeviceName(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetDeviceName(int deviceIndex) => UTF8_ToManaged(INTERNAL_SDL_SensorGetDeviceName(deviceIndex));

        /// <summary>
        ///     Sdls the sensor get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetDeviceType(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceNonPortableType(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetDeviceInstanceID(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorOpen(int deviceIndex);

        /// <summary>
        ///     Sdls the sensor from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SensorFromInstanceID(
            int instanceId
        );

        /// <summary>
        ///     Internals the sdl sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_SensorGetName(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The string</returns>
        public static string SDL_SensorGetName(IntPtr sensor) => UTF8_ToManaged(INTERNAL_SDL_SensorGetName(sensor));

        /// <summary>
        ///     Sdls the sensor get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlSensorType SDL_SensorGetType(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetNonPortableType(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetInstanceID(IntPtr sensor);
        
        /// <summary>
        ///     Sdls the sensor get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_SensorGetData(
            IntPtr sensor,
            float[] data,
            int numValues
        );
        
        /// <summary>
        ///     Sdls the sensor close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorClose(IntPtr sensor);

        /// <summary>
        ///     Sdls the sensor update
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SensorUpdate();
        
        /// <summary>
        ///     Sdls the lock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockSensors();
        
        /// <summary>
        ///     Sdls the unlock sensors
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockSensors();
        
        /// <summary>
        ///     The sdl audio mask bitsize
        /// </summary>
        public const ushort SdlAudioMaskBitsize = 0xFF;

        /// <summary>
        ///     The sdl audio mask datatype
        /// </summary>
        public const ushort SdlAudioMaskDatatype = 1 << 8;

        /// <summary>
        ///     The sdl audio mask endian
        /// </summary>
        public const ushort SdlAudioMaskEndian = 1 << 12;

        /// <summary>
        ///     The sdl audio mask signed
        /// </summary>
        public const ushort SdlAudioMaskSigned = 1 << 15;

        /// <summary>
        ///     Sdls the audio bitsize using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The ushort</returns>
        public static ushort SDL_AUDIO_BITSIZE(ushort x) => (ushort) (x & SdlAudioMaskBitsize);

        /// <summary>
        ///     Describes whether sdl audio isfloat
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISFLOAT(ushort x) => (x & SdlAudioMaskDatatype) != 0;

        /// <summary>
        ///     Describes whether sdl audio isbigendian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISBIGENDIAN(ushort x) => (x & SdlAudioMaskEndian) != 0;

        /// <summary>
        ///     Describes whether sdl audio issigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISSIGNED(ushort x) => (x & SdlAudioMaskSigned) != 0;

        /// <summary>
        ///     Describes whether sdl audio isint
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISINT(ushort x) => (x & SdlAudioMaskDatatype) == 0;

        /// <summary>
        ///     Describes whether sdl audio islittleendian
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISLITTLEENDIAN(ushort x) => (x & SdlAudioMaskEndian) == 0;

        /// <summary>
        ///     Describes whether sdl audio isunsigned
        /// </summary>
        /// <param name="x">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_AUDIO_ISUNSIGNED(ushort x) => (x & SdlAudioMaskSigned) == 0;

        /// <summary>
        ///     The audio u8
        /// </summary>
        public const ushort AudioU8 = 0x0008;

        /// <summary>
        ///     The audio s8
        /// </summary>
        public const ushort AudioS8 = 0x8008;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16Lsb = 0x0010;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16Lsb = 0x8010;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public const ushort AudioU16Msb = 0x1010;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public const ushort AudioS16Msb = 0x9010;

        /// <summary>
        ///     The audio u16lsb
        /// </summary>
        public const ushort AudioU16 = AudioU16Lsb;

        /// <summary>
        ///     The audio s16lsb
        /// </summary>
        public const ushort AudioS16 = AudioS16Lsb;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32Lsb = 0x8020;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public const ushort AudioS32Msb = 0x9020;

        /// <summary>
        ///     The audio s32lsb
        /// </summary>
        public const ushort AudioS32 = AudioS32Lsb;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32Lsb = 0x8120;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public const ushort AudioF32Msb = 0x9120;

        /// <summary>
        ///     The audio f32lsb
        /// </summary>
        public const ushort AudioF32 = AudioF32Lsb;

        /// <summary>
        ///     The audio u16msb
        /// </summary>
        public static readonly ushort AudioU16Sys =
            BitConverter.IsLittleEndian ? AudioU16Lsb : AudioU16Msb;

        /// <summary>
        ///     The audio s16msb
        /// </summary>
        public static readonly ushort AudioS16Sys =
            BitConverter.IsLittleEndian ? AudioS16Lsb : AudioS16Msb;

        /// <summary>
        ///     The audio s32msb
        /// </summary>
        public static readonly ushort AudioS32Sys =
            BitConverter.IsLittleEndian ? AudioS32Lsb : AudioS32Msb;

        /// <summary>
        ///     The audio f32msb
        /// </summary>
        public static readonly ushort AudioF32Sys =
            BitConverter.IsLittleEndian ? AudioF32Lsb : AudioF32Msb;

        /// <summary>
        ///     The sdl audio allow frequency change
        /// </summary>
        public const uint SdlAudioAllowFrequencyChange = 0x00000001;

        /// <summary>
        ///     The sdl audio allow format change
        /// </summary>
        public const uint SdlAudioAllowFormatChange = 0x00000002;

        /// <summary>
        ///     The sdl audio allow channels change
        /// </summary>
        public const uint SdlAudioAllowChannelsChange = 0x00000004;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowSamplesChange = 0x00000008;

        /// <summary>
        ///     The sdl audio allow samples change
        /// </summary>
        public const uint SdlAudioAllowAnyChange = SdlAudioAllowFrequencyChange |
                                                   SdlAudioAllowFormatChange |
                                                   SdlAudioAllowChannelsChange |
                                                   SdlAudioAllowSamplesChange;

        /// <summary>
        ///     The sdl mix maxvolume
        /// </summary>
        public const int SdlMixMaxvolume = 128;


        /// <summary>
        ///     The sdl audiocallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlAudioCallback(
            IntPtr userdata,
            IntPtr stream,
            int len
        );

        /// <summary>
        ///     Internals the sdl audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_AudioInit(
            byte[] driverName
        );

        /// <summary>
        ///     Sdls the audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        public static  int SDL_AudioInit(string driverName)
        {
            int utf8DriverNameBufSize = Utf8Size(driverName);
            byte[] utf8DriverName = new byte[utf8DriverNameBufSize];
            return INTERNAL_SDL_AudioInit(
                Utf8Encode(driverName, utf8DriverName, utf8DriverNameBufSize)
            );
        }

        /// <summary>
        ///     Sdls the audio quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioQuit();

        /// <summary>
        ///     Sdls the close audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudio();

        
        /// <summary>
        ///     Sdls the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_CloseAudioDevice(uint dev);

        
        /// <summary>
        ///     Sdls the free wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeWAV(IntPtr audioBuf);

        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDeviceName(
            int index,
            int iscapture
        );

        /// <summary>
        ///     Sdls the get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDeviceName(
            int index,
            int iscapture
        )
            => UTF8_ToManaged(
                INTERNAL_SDL_GetAudioDeviceName(index, iscapture)
            );
        
        /// <summary>
        ///     Sdls the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioDeviceStatus(
            uint dev
        );

        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetAudioDriver(int index);

        /// <summary>
        ///     Sdls the get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The string</returns>
        public static string SDL_GetAudioDriver(int index) => UTF8_ToManaged(
            INTERNAL_SDL_GetAudioDriver(index)
        );

        /// <summary>
        ///     Sdls the get audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlAudioStatus SDL_GetAudioStatus();

        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetCurrentAudioDriver();

        /// <summary>
        ///     Sdls the get current audio driver
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetCurrentAudioDriver() => UTF8_ToManaged(INTERNAL_SDL_GetCurrentAudioDriver());

        /// <summary>
        ///     Sdls the get num audio devices using the specified iscapture
        /// </summary>
        /// <param name="iscapture">The iscapture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDevices(int iscapture);

        /// <summary>
        ///     Sdls the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetNumAudioDrivers();

        /// <summary>
        ///     Internals the sdl load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_LoadWAV_RW(
            IntPtr src,
            int freesrc,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        );

        /// <summary>
        ///     Sdls the load wav using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        public static IntPtr SDL_LoadWAV(
            string file,
            out SdlAudioSpec spec,
            out IntPtr audioBuf,
            out uint audioLen
        )
        {
            IntPtr rwops = SDL_RWFromFile(file, "rb");
            return INTERNAL_SDL_LoadWAV_RW(
                rwops,
                1,
                out spec,
                out audioBuf,
                out audioLen
            );
        }

        /// <summary>
        ///     Sdls the lock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudio();

        /// <summary>
        ///     Sdls the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_LockAudioDevice(uint dev);

        /// <summary>
        ///     Sdls the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudio(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)]
            byte[] src,
            uint len,
            int volume
        );
        
        /// <summary>
        ///     Sdls the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            IntPtr dst,
            IntPtr src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdls the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_MixAudioFormat(
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] dst,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)]
            byte[] src,
            ushort format,
            uint len,
            int volume
        );

        /// <summary>
        ///     Sdls the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained
        );

        /// <summary>
        ///     Sdls the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_OpenAudio(
            ref SdlAudioSpec desired,
            IntPtr obtained
        );
        
        /// <summary>
        ///     Sdls the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_OpenAudioDevice(
            IntPtr device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        );

        /// <summary>
        ///     Internals the sdl open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        private static extern  uint INTERNAL_SDL_OpenAudioDevice(
            byte[] device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        );

        /// <summary>
        ///     Sdls the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        public static  uint SDL_OpenAudioDevice(
            string device,
            int iscapture,
            ref SdlAudioSpec desired,
            out SdlAudioSpec obtained,
            int allowedChanges
        )
        {
            int utf8DeviceBufSize = Utf8Size(device);
            byte[] utf8Device = new byte[utf8DeviceBufSize];
            return INTERNAL_SDL_OpenAudioDevice(
                Utf8Encode(device, utf8Device, utf8DeviceBufSize),
                iscapture,
                ref desired,
                out obtained,
                allowedChanges
            );
        }

        /// <summary>
        ///     Sdls the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudio(int pauseOn);
        
        /// <summary>
        ///     Sdls the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_PauseAudioDevice(
            uint dev,
            int pauseOn
        );

        /// <summary>
        ///     Sdls the unlock audio
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudio();
        
        /// <summary>
        ///     Sdls the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_UnlockAudioDevice(uint dev);
        
        /// <summary>
        ///     Sdls the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_QueueAudio(
            uint dev,
            IntPtr data,
            uint len
        );
        
        /// <summary>
        ///     Sdls the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_DequeueAudio(
            uint dev,
            IntPtr data,
            uint len
        );
        
        /// <summary>
        ///     Sdls the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetQueuedAudioSize(uint dev);
        
        /// <summary>
        ///     Sdls the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_ClearQueuedAudio(uint dev);
        
        /// <summary>
        ///     Sdls the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_NewAudioStream(
            ushort srcFormat,
            byte srcChannels,
            int srcRate,
            ushort dstFormat,
            byte dstChannels,
            int dstRate
        );
        
        /// <summary>
        ///     Sdls the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamPut(
            IntPtr stream,
            IntPtr buf,
            int len
        );
        
        /// <summary>
        ///     Sdls the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamGet(
            IntPtr stream,
            IntPtr buf,
            int len
        );

        /// <summary>
        ///     Sdls the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AudioStreamAvailable(IntPtr stream);
        
        /// <summary>
        ///     Sdls the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AudioStreamClear(IntPtr stream);
        
        /// <summary>
        ///     Sdls the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_FreeAudioStream(IntPtr stream);

        
        /// <summary>
        ///     Sdls the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="iscapture">The iscapture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetAudioDeviceSpec(
            int index,
            int iscapture,
            out SdlAudioSpec spec
        );
        
        /// <summary>
        ///     Describes whether sdl ticks passed
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        public static bool SDL_TICKS_PASSED(uint a, uint b) => (int) (b - a) <= 0;

        /// <summary>
        ///     Sdls the delay using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_Delay(uint ms);
        
        /// <summary>
        ///     Sdls the get ticks
        /// </summary>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_GetTicks();
        
        /// <summary>
        ///     Sdls the get ticks 64
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetTicks64();
        
        /// <summary>
        ///     Sdls the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceCounter();
        
        /// <summary>
        ///     Sdls the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ulong SDL_GetPerformanceFrequency();
        
        /// <summary>
        ///     The sdl timercallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate uint SdlTimerCallback(uint interval, IntPtr param);

        
        /// <summary>
        ///     Sdls the add timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AddTimer(
            uint interval,
            SdlTimerCallback callback,
            IntPtr param
        );

        /// <summary>
        ///     Sdls the remove timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_RemoveTimer(int id);
        
        /// <summary>
        ///     The sdl windowsmessagehook
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate IntPtr SdlWindowsMessageHook(
            IntPtr userdata,
            IntPtr hWnd,
            uint message,
            ulong wParam,
            long lParam
        );

        /// <summary>
        ///     Sdls the set windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SetWindowsMessageHook(
            SdlWindowsMessageHook callback,
            IntPtr userdata
        );
        
        /// <summary>
        ///     Sdls the render get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D9Device(IntPtr renderer);
        
        /// <summary>
        ///     Sdls the render get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_RenderGetD3D11Device(IntPtr renderer);
        
        /// <summary>
        ///     The sdl iphoneanimationcallback
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void SdlIPhoneAnimationCallback(IntPtr p);

        /// <summary>
        ///     Sdls the i phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_iPhoneSetAnimationCallback(
            IntPtr window, 
            int interval,
            SdlIPhoneAnimationCallback callback,
            IntPtr callbackParam
        );

        /// <summary>
        ///     Sdls the i phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_iPhoneSetEventPump(SdlBool enabled);

        

        /// <summary>
        ///     The sdl android external storage read
        /// </summary>
        public const int SdlAndroidExternalStorageRead = 0x01;

        /// <summary>
        ///     The sdl android external storage write
        /// </summary>
        public const int SdlAndroidExternalStorageWrite = 0x02;

        
        /// <summary>
        ///     Sdls the android get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetJNIEnv();

        
        /// <summary>
        ///     Sdls the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_AndroidGetActivity();

        /// <summary>
        ///     Sdls the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsAndroidTV();

        /// <summary>
        ///     Sdls the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsChromebook();

        /// <summary>
        ///     Sdls the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsDeXMode();

        /// <summary>
        ///     Sdls the android back button
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_AndroidBackButton();

        /// <summary>
        ///     Internals the sdl android get internal storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_AndroidGetInternalStoragePath();

        /// <summary>
        ///     Sdls the android get internal storage path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_AndroidGetInternalStoragePath() => UTF8_ToManaged(
            INTERNAL_SDL_AndroidGetInternalStoragePath()
        );

        /// <summary>
        ///     Sdls the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_AndroidGetExternalStorageState();

        /// <summary>
        ///     Internals the sdl android get external storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_AndroidGetExternalStoragePath();

        /// <summary>
        ///     Sdls the android get external storage path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_AndroidGetExternalStoragePath() => UTF8_ToManaged(
            INTERNAL_SDL_AndroidGetExternalStoragePath()
        );

        /// <summary>
        ///     Sdls the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetAndroidSDKVersion();

        
        /// <summary>
        ///     Internals the sdl android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidRequestPermission", CallingConvention = CallingConvention.Cdecl)]
        private static extern  SdlBool INTERNAL_SDL_AndroidRequestPermission(
            byte[] permission
        );

        /// <summary>
        ///     Sdls the android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The result</returns>
        public static  SdlBool SDL_AndroidRequestPermission(
            string permission
        )
        {
            byte[] permissionPtr = Utf8EncodeHeap(permission);
            SdlBool result = INTERNAL_SDL_AndroidRequestPermission(
                permissionPtr
            );
            return result;
        }
        
        /// <summary>
        ///     Internals the sdl android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidShowToast", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_AndroidShowToast(
            byte[] message,
            int duration,
            int gravity,
            int xOffset,
            int yOffset
        );

        /// <summary>
        ///     Sdls the android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The result</returns>
        public static  int SDL_AndroidShowToast(
            string message,
            int duration,
            int gravity,
            int xOffset,
            int yOffset
        )
        {
            byte[] messagePtr = Utf8EncodeHeap(message);
            int result = INTERNAL_SDL_AndroidShowToast(
                messagePtr,
                duration,
                gravity,
                xOffset,
                yOffset
            );
            return result;
        }
        
        /// <summary>
        ///     Sdls the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlWinRtDeviceFamily SDL_WinRTGetDeviceFamily();

        /// <summary>
        ///     Sdls the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_IsTablet();
        
        /// <summary>
        ///     Sdls the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_GetWindowWMInfo(
            IntPtr window,
            ref SdlSysWMinfo info
        );
        
        /// <summary>
        ///     Internals the sdl get base path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_SDL_GetBasePath();

        /// <summary>
        ///     Sdls the get base path
        /// </summary>
        /// <returns>The string</returns>
        public static string SDL_GetBasePath() => UTF8_ToManaged(INTERNAL_SDL_GetBasePath(), true);

        /// <summary>
        ///     Internals the sdl get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_SDL_GetPrefPath(
            byte[] org,
            byte[] app
        );

        /// <summary>
        ///     Sdls the get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The string</returns>
        public static  string SDL_GetPrefPath(string org, string app)
        {
            int utf8OrgBufSize = Utf8Size(org);
            byte[] utf8Org = new byte[utf8OrgBufSize];

            int utf8AppBufSize = Utf8Size(app);
            byte[] utf8App = new byte[utf8AppBufSize];

            return UTF8_ToManaged(
                INTERNAL_SDL_GetPrefPath(
                    Utf8Encode(org, utf8Org, utf8OrgBufSize),
                    Utf8Encode(app, utf8App, utf8AppBufSize)
                ),
                true
            );
        }

        /// <summary>
        ///     Sdls the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlPowerState SDL_GetPowerInfo(
            out int secs,
            out int pct
        );

        /// <summary>
        ///     Sdls the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCPUCount();

        /// <summary>
        ///     Sdls the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetCPUCacheLineSize();

        /// <summary>
        ///     Sdls the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasRDTSC();

        /// <summary>
        ///     Sdls the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAltiVec();

        /// <summary>
        ///     Sdls the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasMMX();

        /// <summary>
        ///     Sdls the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_Has3DNow();

        /// <summary>
        ///     Sdls the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE();

        /// <summary>
        ///     Sdls the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE2();

        /// <summary>
        ///     Sdls the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE3();

        /// <summary>
        ///     Sdls the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE41();

        /// <summary>
        ///     Sdls the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasSSE42();

        /// <summary>
        ///     Sdls the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX();

        /// <summary>
        ///     Sdls the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX2();

        /// <summary>
        ///     Sdls the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasAVX512F();

        /// <summary>
        ///     Sdls the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern SdlBool SDL_HasNEON();
        
        /// <summary>
        ///     Sdls the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetSystemRAM();
        
        /// <summary>
        ///     Sdls the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint SDL_SIMDGetAlignment();
        
        /// <summary>
        ///     Sdls the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SIMDAlloc(uint len);
        
        /// <summary>
        ///     Sdls the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_SIMDRealloc(IntPtr ptr, uint len);
        
        /// <summary>
        ///     Sdls the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_SIMDFree(IntPtr ptr);
        
        /// <summary>
        ///     Sdls the has armsimd
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void SDL_HasARMSIMD();
        
        /// <summary>
        ///     Sdls the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr SDL_GetPreferredLocales();
        
        /// <summary>
        ///     Internals the sdl open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenURL", CallingConvention = CallingConvention.Cdecl)]
        private static extern  int INTERNAL_SDL_OpenURL(byte[] url);

        /// <summary>
        ///     Sdls the open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The result</returns>
        public static  int SDL_OpenURL(string url)
        {
            byte[] urlPtr = Utf8EncodeHeap(url);
            int result = INTERNAL_SDL_OpenURL(urlPtr);
            
            return result;
        }
    }
}