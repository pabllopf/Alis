using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;
using NativeLibrary = NativeLibraryLoader.NativeLibrary;

namespace Alis.Core.Systems.Audio.OpenAl.Binding
{
    public static unsafe partial class AlNative
    {
        private static readonly NativeLibrary m_alLibrary;

        private static NativeLibrary LoadOpenAL()
        {
            string[] names;
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                names = new[]
                {
                    "libopenal.dll"
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                names = new[]
                {
                    "libopenal.so",
                    "libopenal.so.1"
                };
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                names = new[]
                {
                    "libopenal.dylib",
                    "liblibopenal.dylib"
                };
            }
            else
            {
                Debug.WriteLine("Unknown OpenAL platform. Attempting to load \"openal\"");
                names = new[] { "openal" };
            }

            NativeLibrary lib = new NativeLibrary(names);
            return lib;
        }

        private static T LoadFunction<T>(string name)
        {
            return m_alLibrary.LoadFunction<T>(name);
        }

        static AlNative()
        {
            m_alLibrary = LoadOpenAL();

            LoadAlc();
            LoadAl();
        }
    }
}
