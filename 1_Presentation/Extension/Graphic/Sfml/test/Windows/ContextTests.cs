// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContextTests.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The context tests class
    /// </summary>
    public class ContextTests
    {
        /// <summary>
        ///     Tests that constructor creates context
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Constructor_CreatesContext()
        {
            Context ctx = new Context();
            Assert.NotNull(ctx);
        }

        /// <summary>
        ///     Tests that set active returns bool
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void SetActive_ReturnsBool()
        {
            Context ctx = new Context();
            bool result = ctx.SetActive(true);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        ///     Tests that settings returns context settings
        /// </summary>
        [Fact(Skip = "Cannot test Context without native SFML dependencies.")]
        public void Settings_ReturnsContextSettings()
        {
            Context ctx = new Context();
            ContextSettings settings = ctx.Settings;
            Assert.IsType<ContextSettings>(settings);
        }
    }
}