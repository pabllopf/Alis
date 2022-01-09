using System.Diagnostics;
using System.Runtime.InteropServices;
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
                    "Lib/OpenAL/Win64/OpenAL32.dll"
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
                    "liblibopenal.dylib",
                    "soft_oal.so",
                    "/opt/homebrew/Cellar/openal-soft/1.21.1/lib/libopenal.1.dylib"
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
