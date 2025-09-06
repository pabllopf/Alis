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

using System.Reflection;
using Alis.Core.Aspect.Data.Dll;
using Alis.Extension.Graphic.Sfml.Properties;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     The csfml class
    /// </summary>
    public static class Csfml
    {
        /// <summary>
        ///     The audio
        /// </summary>
        public const string Audio = "csfml-audio";

        /// <summary>
        ///     The graphics
        /// </summary>
        public const string Graphics = "csfml-graphics";

        /// <summary>
        ///     The system
        /// </summary>
        public const string System = "csfml-system";

        /// <summary>
        ///     The window
        /// </summary>
        public const string Window = "csfml-window";

        /// <summary>
        ///     Initializes a new instance of the <see cref="Csfml" /> class
        /// </summary>
        static Csfml()
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("sfml", DllType.File, SfmlDlls.SfmlDllBytes, Assembly.GetAssembly(typeof(SfmlDlls)));
        }
    }
}