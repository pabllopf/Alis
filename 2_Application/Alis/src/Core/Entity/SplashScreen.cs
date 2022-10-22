// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SplashScreen.cs
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

using Alis.Builder.Core.Entity;
using Alis.Core.Aspect.Fluent;

namespace Alis.Core.Entity
{
    /// <summary>
    ///     The splash screen class
    /// </summary>
    public class SplashScreen :
        IBuilder<SplashScreenBuilder>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SplashScreen" /> class
        /// </summary>
        public SplashScreen() => filePath = "";

        /// <summary>
        ///     Initializes a new instance of the <see cref="SplashScreen" /> class
        /// </summary>
        /// <param name="filePath">The file path</param>
        public SplashScreen(string filePath) => this.filePath = filePath;

        /// <summary>
        ///     Gets or sets the value of the enabled
        /// </summary>
        public bool Enabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets the value of the style
        /// </summary>
        public Style Style { get; set; } = Style.Light;

        /// <summary>
        ///     The file path
        /// </summary>
        public string filePath { get; set; } = "";

        /// <summary>
        ///     Gets or sets the value of the enabled alis logo
        /// </summary>
        public bool EnabledAlisLogo { get; set; } = true;

        /// <summary>
        ///     Builders this instance
        /// </summary>
        /// <returns>The splash screen builder</returns>
        public SplashScreenBuilder Builder() => new SplashScreenBuilder();
    }
}