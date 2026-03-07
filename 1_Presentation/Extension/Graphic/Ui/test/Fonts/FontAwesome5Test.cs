// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontAwesome5Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Fonts;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Fonts
{
    /// <summary>
    ///     Provides unit coverage for <see cref="FontAwesome5" /> constants.
    /// </summary>
    public class FontAwesome5Test
    {
        /// <summary>
        ///     Verifies that the type is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(FontAwesome5);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Verifies that font file names are set and end with .ttf.
        /// </summary>
        [Fact]
        public void FontNames_ShouldBeTtfFiles()
        {
            Assert.EndsWith(".ttf", FontAwesome5.NameRegular, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", FontAwesome5.NameSolid, StringComparison.OrdinalIgnoreCase);
            Assert.EndsWith(".ttf", FontAwesome5.NameLight, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Verifies icon range constants are coherent.
        /// </summary>
        [Fact]
        public void IconRange_ShouldBeCoherent()
        {
            Assert.True(FontAwesome5.IconMin > 0);
            Assert.True(FontAwesome5.IconMax >= FontAwesome5.IconMin);
            Assert.Equal(FontAwesome5.IconMax, FontAwesome5.IconMax16);
        }

        /// <summary>
        ///     Verifies that icon string catalog remains broad and non-empty.
        /// </summary>
        [Fact]
        public void IconCatalog_ShouldContainManyNonEmptyConstants()
        {
            FieldInfo[] iconFields = typeof(FontAwesome5)
                .GetFields(BindingFlags.Public | BindingFlags.Static)
                .Where(field => field.FieldType == typeof(string))
                .Where(field => field.Name != nameof(FontAwesome5.NameRegular))
                .Where(field => field.Name != nameof(FontAwesome5.NameSolid))
                .Where(field => field.Name != nameof(FontAwesome5.NameLight))
                .ToArray();

            Assert.True(iconFields.Length > 300);

            foreach (FieldInfo field in iconFields)
            {
                string value = field.GetValue(null) as string;
                Assert.False(string.IsNullOrWhiteSpace(value));
            }
        }

        /// <summary>
        ///     Verifies a representative subset of known icon constants.
        /// </summary>
        [Fact]
        public void RepresentativeIcons_ShouldMatchExpectedGlyphs()
        {
            Assert.Equal("\uf641", FontAwesome5.Ad);
            Assert.Equal("\uf2b9", FontAwesome5.AddressBook);
            Assert.Equal("\uf2bb", FontAwesome5.AddressCard);
            Assert.Equal("\uf042", FontAwesome5.Adjust);
        }
    }
}