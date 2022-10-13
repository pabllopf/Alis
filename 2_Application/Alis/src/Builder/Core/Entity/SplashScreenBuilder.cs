// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SplashScreenBuilder.cs
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

using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Entity;

namespace Alis.Builder.Core.Entity
{
    /// <summary>
    /// The splash screen builder class
    /// </summary>
    /// <seealso cref="IBuild{SplashScreen}"/>
    public class SplashScreenBuilder :
        IBuild<SplashScreen>,
        IIsActive<SplashScreenBuilder, bool>,
        IFilePath<SplashScreenBuilder, string>,
        IStyle<SplashScreenBuilder, Style>
    {
        /// <summary>
        /// The splash screen
        /// </summary>
        private SplashScreen splashScreen = new SplashScreen();
        
        
        /// <summary>
        /// Builds this instance
        /// </summary>
        /// <returns>The splash screen</returns>
        public SplashScreen Build() => splashScreen;

        /// <summary>
        /// Files the path using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The splash screen builder</returns>
        public SplashScreenBuilder FilePath(string value)
        {
            splashScreen.filePath = value;
            return this;
        }

        /// <summary>
        /// Ises the active using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The splash screen builder</returns>
        public SplashScreenBuilder IsActive(bool value)
        {
            splashScreen.Enabled = value;
            return this;
        }

        /// <summary>
        /// Styles the value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The splash screen builder</returns>
        public SplashScreenBuilder Style(Style value)
        {
            splashScreen.Style = value;
            return this;
        }
    }
}