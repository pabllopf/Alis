using System;
using System.Runtime.InteropServices;

namespace SFML.System
{
    public static class CSFML
    {
#if Windows
        /// <summary>Gets the audio.</summary>
        /// <value>The audio.</value>
        public const string audio = "./Runtimes/win/x64/csfml-audio";

        /// <summary>The graphics</summary>
        public const string graphics = "./Runtimes/win/x64/csfml-graphics";

        /// <summary>The system</summary>
        public const string system = "./Runtimes/win/x64/csfml-system";

        /// <summary>The window</summary>
        public const string window = "./Runtimes/win/x64/csfml-window";
#endif

#if Macos
        public const string audio = "./Runtimes/osx/x64/csfml-audio.dylib";

        public const string graphics = "./Runtimes/osx/x64/csfml-graphics.dylib";

        public const string system = "./Runtimes/osx/x64/csfml-system.dylib";

        public const string window = "./Runtimes/osx/x64/csfml-window.dylib";

#endif

#if Linux
        public const string audio = "./Runtimes/debian/x64/csfml-audio.so";

        public const string graphics = "./Runtimes/debian/x64/csfml-graphics.so";

        public const string system = "./Runtimes/debian/x64/csfml-system.so";

        public const string window = "./Runtimes/debian/x64/csfml-window.so";

#endif
    }
} 