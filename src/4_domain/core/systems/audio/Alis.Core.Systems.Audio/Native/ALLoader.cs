// 

using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Alis.Core.Systems.Audio.Native
{
    /// <summary>
    ///     Provides a base for ApiContext so that it can register dll intercepts.
    /// </summary>
    internal static class ALLoader
    {
        static ALLoader()
        {
            RegisterDllResolver();
        }

        private static readonly OpenALLibraryNameContainer ALLibraryNameContainer = new OpenALLibraryNameContainer();

        private static bool RegisteredResolver;

        internal static void RegisterDllResolver()
        {
            if (RegisteredResolver == false)
            {
                NativeLibrary.SetDllImportResolver(typeof(ALLoader).Assembly, ImportResolver);
                RegisteredResolver = true;
            }
        }

        private static IntPtr ImportResolver(string libraryName, Assembly assembly, DllImportSearchPath? searchPath)
        {
            if (libraryName == AL.AL.Lib || libraryName == ALC.ALC.Lib)
            {
                string libName = ALLibraryNameContainer.GetLibraryName();

                if (NativeLibrary.TryLoad(libName, assembly, searchPath, out IntPtr libHandle) == false)
                {
                    throw new DllNotFoundException(
                        $"Could not load the dll '{libName}' (this load is intercepted, specified in DllImport as '{libraryName}').");
                }

                return libHandle;
            }

            return NativeLibrary.Load(libraryName, assembly, searchPath);
        }
    }
}