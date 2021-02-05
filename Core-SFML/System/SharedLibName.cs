using System;
using System.Runtime.InteropServices;

namespace SFML.System
{
    public static class CSFML
    {
#if Windows
        /// <summary>Gets the audio.</summary>
        /// <value>The audio.</value>
        public const string audio = "./runtimes/win/x64/csfml-audio";

        /// <summary>The graphics</summary>
        public const string graphics = "./runtimes/win/x64/csfml-graphics";

        /// <summary>The system</summary>
        public const string system = "./runtimes/win/x64/csfml-system";

        /// <summary>The window</summary>
        public const string window = "./runtimes/win/x64/csfml-window";
#endif

#if Macos
        public const string audio = "./Runtimes/osx/x64/csfml-audio.dylib";

        public const string graphics = "./Runtimes/osx/x64/csfml-graphics.dylib";

        public const string system = "./Runtimes/osx/x64/csfml-system.dylib";

        public const string window = "./Runtimes/osx/x64/csfml-window.dylib";

#endif

#if Linux
        public const string audio = "./runtimes/debian/x64/csfml-audio";

        public const string graphics = "./runtimes/debian/x64/csfml-graphics";

        public const string system = "./runtimes/debian/x64/csfml-system";

        public const string window = "./runtimes/debian/x64/csfml-window";

#endif
    }
} 