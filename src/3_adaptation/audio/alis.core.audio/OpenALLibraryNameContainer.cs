// 

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Systems.Audio
{
    /// <summary>
    ///     Contains the library name of OpenAL.
    /// </summary>
    public class OpenALLibraryNameContainer
    {
        /// <summary>
        ///     Gets the library name to use on Windows.
        /// </summary>
        public string Windows => "openal32.dll";

        /// <summary>
        ///     Gets the library name to use on Linux.
        /// </summary>
        public string Linux => "libopenal.so.1";

        /// <summary>
        ///     Gets the library name to use on MacOS.
        /// </summary>
        public string MacOS => "/System/Library/Frameworks/OpenAL.framework/OpenAL";

        /// <summary>
        ///     Gets the library name to use on Android.
        /// </summary>
        public string Android => Linux;

        /// <summary>
        ///     Gets the library name to use on iOS.
        /// </summary>
        public string IOS => MacOS;

        public string GetLibraryName()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("ANDROID")))
                {
                    return Android;
                }

                return Linux;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Windows;
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Create("IOS")))
                {
                    return IOS;
                }

                return MacOS;
            }

            throw new NotSupportedException(
                $"The library name couldn't be resolved for the given platform ('{RuntimeInformation.OSDescription}').");
        }
    }
}