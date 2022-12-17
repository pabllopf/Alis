// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CSFML.cs
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

namespace Alis.Core.Aspect.Base.Settings
{
    /// <summary>
    ///     The csfml class
    /// </summary>
    public static class Csfml
    {
#if WIN
        /// <summary>
        ///     The audio
        /// </summary>
        public const string audio = "runtimes/win-x64/native/csfml-audio";
        
        /// <summary>
        ///     The graphics
        /// </summary>
        public const string graphics = "runtimes/win-x64/native/csfml-graphics";

        /// <summary>
        ///     The system
        /// </summary>
        public const string system = "runtimes/win-x64/native/csfml-system";

        /// <summary>
        ///     The window
        /// </summary>
        public const string window = "runtimes/win-x64/native/csfml-window";

#elif LINUX
        /// <summary>
        ///     The audio
        /// </summary>
        public const string Audio = "./runtimes/debian-arm64/native/libcsfml-audio.so";
        
        /// <summary>
        ///     The graphics
        /// </summary>
        public const string Graphics = "./runtimes/debian-arm64/native/libcsfml-graphics.so";

        /// <summary>
        ///     The system
        /// </summary>
        public const string System = "./runtimes/debian-arm64/native/libcsfml-system.so";

        /// <summary>
        ///     The window
        /// </summary>
        public const string Window = "./runtimes/debian-arm64/native/libcsfml-window.so";
#elif OSXARM64
        /// <summary>
        ///     The audio
        /// </summary>
        public const string Audio = "/private/var/tmp/alis/libcsfml-audio.dylib";

        /// <summary>
        ///     The graphics
        /// </summary>
        public const string Graphics = "/private/var/tmp/alis/libcsfml-graphics.dylib";

        /// <summary>
        ///     The system
        /// </summary>
        public const string System = "/private/var/tmp/alis/libcsfml-system.dylib";

        /// <summary>
        ///     The window
        /// </summary>
        public const string Window = "/private/var/tmp/alis/libcsfml-window.dylib";
#elif OSX64
        /// <summary>
        ///     The audio
        /// </summary>
        public const string audio = "./runtimes/osx-x64/native/libcsfml-audio.dylib";
        
        /// <summary>
        ///     The graphics
        /// </summary>
        public const string graphics = "./runtimes/osx-x64/native/libcsfml-graphics.dylib";

        /// <summary>
        ///     The system
        /// </summary>
        public const string system = "./runtimes/osx-x64/native/libcsfml-system.dylib";

        /// <summary>
        ///     The window
        /// </summary>
        public const string window = "./runtimes/osx-x64/native/libcsfml-window.dylib";
#elif IOS
        /// <summary>
        ///     The audio
        /// </summary>
        public const string audio = "csfml-audio";
        
        /// <summary>
        ///     The graphics
        /// </summary>
        public const string graphics = "csfml-graphics";

        /// <summary>
        ///     The system
        /// </summary>
        public const string system = "csfml-system";

        /// <summary>
        ///     The window
        /// </summary>
        public const string window = "csfml-window";

#elif ANDROID
        /// <summary>
        ///     The audio
        /// </summary>
        public const string audio = $"csfml-audio";
        
        /// <summary>
        ///     The graphics
        /// </summary>
        public const string graphics = "csfml-graphics";

        /// <summary>
        ///     The system
        /// </summary>
        public const string system = "csfml-system";

        /// <summary>
        ///     The window
        /// </summary>
        public const string window = "csfml-window";
#else
        /// <summary>
        ///     The audio
        /// </summary>
        public const string Audio = "runtimes/win-x64/native/csfml-audio";

        /// <summary>
        ///     The graphics
        /// </summary>
        public const string Graphics = "runtimes/win-x64/native/csfml-graphics";

        /// <summary>
        ///     The system
        /// </summary>
        public const string System = "runtimes/win-x64/native/csfml-system";

        /// <summary>
        ///     The window
        /// </summary>
        public const string Window = "runtimes/win-x64/native/csfml-window";
#endif
    }
}