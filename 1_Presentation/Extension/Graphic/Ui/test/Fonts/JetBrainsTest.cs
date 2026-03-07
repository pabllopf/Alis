// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JetBrainsTest.cs
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

using System;
using Alis.Extension.Graphic.Ui.Fonts;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Fonts
{
    /// <summary>
    ///     Provides unit coverage for <see cref="JetBrains" /> font constants.
    /// </summary>
    public class JetBrainsTest
    {
        /// <summary>
        ///     Verifies that the type is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(JetBrains);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Verifies that all file names are valid TrueType font files.
        /// </summary>
        [Fact]
        public void FontNames_ShouldBeValidTtfFiles()
        {
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameRegular));
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameSolid));
            Assert.False(string.IsNullOrWhiteSpace(JetBrains.NameLight));

            Assert.EndsWith(".ttf", JetBrains.NameRegular, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", JetBrains.NameSolid, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", JetBrains.NameLight, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Verifies that regular and light names currently map to the same file.
        /// </summary>
        [Fact]
        public void RegularAndLight_ShouldMatchCurrentDefinition()
        {
            Assert.Equal(JetBrains.NameRegular, JetBrains.NameLight);
        }
    }
}