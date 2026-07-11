// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FontTest.cs
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

using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    ///     Unit tests for the <see cref="Font"/> class.
    /// </summary>
    public class FontTest
    {
        /// <summary>
        /// Tests that font is assignable from object base
        /// </summary>
        [Fact]
        public void Font_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Font)));
        }

        /// <summary>
        /// Tests that font implements i disposable
        /// </summary>
        [Fact]
        public void Font_ImplementsIDisposable()
        {
            Assert.True(typeof(System.IDisposable).IsAssignableFrom(typeof(Font)));
        }

        /// <summary>
        /// Tests that info struct has family property
        /// </summary>
        [Fact]
        public void Info_Struct_HasFamilyProperty()
        {
            var infoType = typeof(Font).GetNestedType("Info");
            Assert.NotNull(infoType);
            var familyProp = infoType.GetProperty("Family");
            Assert.NotNull(familyProp);
            Assert.Equal(typeof(string), familyProp.PropertyType);
        }

        /// <summary>
        /// Tests that info marshal data struct has family field
        /// </summary>
        [Fact]
        public void InfoMarshalData_Struct_HasFamilyField()
        {
            var infoType = typeof(Font).GetNestedType("InfoMarshalData", System.Reflection.BindingFlags.NonPublic);
            Assert.NotNull(infoType);
            var familyField = infoType.GetField("Family");
            Assert.NotNull(familyField);
            Assert.Equal(typeof(System.IntPtr), familyField.FieldType);
        }
    }
}
