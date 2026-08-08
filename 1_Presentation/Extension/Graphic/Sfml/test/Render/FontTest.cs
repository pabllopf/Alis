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

using System;
using System.IO;
using System.Reflection;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Test.Render
{
    /// <summary>
    /// The font test class
    /// </summary>
    public class FontTest
    {
        /// <summary>
        /// Tests that font is assignable from object base
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Font_IsAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(Font)));
        }

        /// <summary>
        /// Tests that font implements i disposable
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Font_ImplementsIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(Font)));
        }

        /// <summary>
        /// Tests that info struct has family property
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Info_Struct_HasFamilyProperty()
        {
            Type infoType = typeof(Font).GetNestedType("Info");
            Assert.NotNull(infoType);
            PropertyInfo familyProp = infoType.GetProperty("Family");
            Assert.NotNull(familyProp);
            Assert.Equal(typeof(string), familyProp.PropertyType);
        }

        /// <summary>
        /// Tests that info family property is read write
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Info_Family_Property_IsReadWrite()
        {
            Type infoType = typeof(Font).GetNestedType("Info");
            Assert.NotNull(infoType);
            PropertyInfo familyProp = infoType.GetProperty("Family");
            Assert.NotNull(familyProp);
            Assert.True(familyProp.CanRead);
            Assert.True(familyProp.CanWrite);
        }

        /// <summary>
        /// Tests that info marshal data struct has family field
        /// </summary>
        [RequireCSfmlSystemFact]
        public void InfoMarshalData_Struct_HasFamilyField()
        {
            Type infoType = typeof(Font).GetNestedType("InfoMarshalData", BindingFlags.NonPublic);
            Assert.NotNull(infoType);
            FieldInfo familyField = infoType.GetField("Family");
            Assert.NotNull(familyField);
            Assert.Equal(typeof(IntPtr), familyField.FieldType);
        }

        /// <summary>
        /// Tests that constructor filename exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Filename_Exists()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(new[] { typeof(string) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        /// <summary>
        /// Tests that constructor stream exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Stream_Exists()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(new[] { typeof(Stream) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        /// <summary>
        /// Tests that constructor bytes exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Bytes_Exists()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(new[] { typeof(byte[]) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        /// <summary>
        /// Tests that constructor copy exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Copy_Exists()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(new[] { typeof(Font) });
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPublic);
        }

        /// <summary>
        /// Tests that constructor int ptr is private
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_IntPtr_IsPrivate()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null);
            Assert.NotNull(ctor);
            Assert.True(ctor.IsPrivate);
        }

        /// <summary>
        /// Tests that get glyph method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlyph_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetGlyph", new[] { typeof(uint), typeof(uint), typeof(bool), typeof(float) });
            Assert.NotNull(method);
            Assert.Equal(typeof(Glyph), method.ReturnType);
        }

        /// <summary>
        /// Tests that get kerning method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetKerning_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetKerning", new[] { typeof(uint), typeof(uint), typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(float), method.ReturnType);
        }

        /// <summary>
        /// Tests that get line spacing method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLineSpacing_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetLineSpacing", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(float), method.ReturnType);
        }

        /// <summary>
        /// Tests that get underline position method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetUnderlinePosition_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetUnderlinePosition", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(float), method.ReturnType);
        }

        /// <summary>
        /// Tests that get underline thickness method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetUnderlineThickness_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetUnderlineThickness", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(float), method.ReturnType);
        }

        /// <summary>
        /// Tests that get texture method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetTexture_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetTexture", new[] { typeof(uint) });
            Assert.NotNull(method);
            Assert.Equal(typeof(Texture), method.ReturnType);
        }

        /// <summary>
        /// Tests that get info method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetInfo_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("GetInfo", Type.EmptyTypes);
            Assert.NotNull(method);
            Assert.Equal(typeof(Font.Info), method.ReturnType);
        }

        /// <summary>
        /// Tests that to string method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("ToString", Type.EmptyTypes);
            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
        }

        /// <summary>
        /// Tests that destroy method exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_Method_Exists()
        {
            MethodInfo method = typeof(Font).GetMethod("Destroy", new[] { typeof(bool) });
            Assert.NotNull(method);
        }

        /// <summary>
        /// Tests that to string is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_IsOverride()
        {
            MethodInfo method = typeof(Font).GetMethod("ToString");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that destroy is override
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_IsOverride()
        {
            MethodInfo method = typeof(Font).GetMethod("Destroy");
            Assert.NotNull(method);
            Assert.True(method.IsVirtual);
            Assert.NotEqual(method.GetBaseDefinition(), method);
        }

        /// <summary>
        /// Tests that pinned objects field exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void PinnedObjects_Field_Exists()
        {
            FieldInfo field = typeof(Font).GetField("_pinnedObjects", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.True(field.IsInitOnly);
        }

        /// <summary>
        /// Tests that my textures field exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void MyTextures_Field_Exists()
        {
            FieldInfo field = typeof(Font).GetField("myTextures", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.NotNull(field);
            Assert.True(field.IsInitOnly);
        }

        /// <summary>
        /// Tests that info struct can instantiate and set family
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Info_Struct_CanInstantiateAndSetFamily()
        {
            Font.Info info = new Font.Info();
            info.Family = "Arial";
            Assert.Equal("Arial", info.Family);
        }

        /// <summary>
        /// Tests that info struct default family is null
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Info_Struct_DefaultFamilyIsNull()
        {
            Font.Info info = new Font.Info();
            Assert.Null(info.Family);
        }

        /// <summary>
        /// Constructors the filename non existent throws loading failed exception
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Filename_NonExistent_ThrowsLoadingFailedException()
        {
            Assert.Throws<LoadingFailedException>(() => new Font("nonexistent_font_file.ttf"));
        }

        /// <summary>
        /// Constructors the stream invalid data throws loading failed exception
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_Stream_InvalidData_ThrowsLoadingFailedException()
        {
            using MemoryStream ms = new MemoryStream(new byte[] { 0, 1, 2, 3, 4 });
            Assert.Throws<LoadingFailedException>(() => new Font(ms));
        }

        /// <summary>
        /// Constructors the empty bytes throws loading failed exception
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_EmptyBytes_ThrowsLoadingFailedException()
        {
            Assert.Throws<LoadingFailedException>(() => new Font(Array.Empty<byte>()));
        }

        /// <summary>
        /// Tests that to string returns font
        /// </summary>
        [RequireCSfmlSystemFact]
        public void ToString_ReturnsFont()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null);
            Font font = (Font)ctor.Invoke(new object[] { IntPtr.Zero });
            string result = font.ToString();
            Assert.Equal("Font", result);
        }

        /// <summary>
        /// Destroys the with disposing true sets c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingTrue_SetsCPointerToZero()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null);
            Font font = (Font)ctor.Invoke(new object[] { IntPtr.Zero });
            font.Destroy(true);
            Assert.Equal(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Destroys the with disposing false sets c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithDisposingFalse_SetsCPointerToZero()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null);
            Font font = (Font)ctor.Invoke(new object[] { IntPtr.Zero });
            font.Destroy(false);
            Assert.Equal(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Disposes the does not crash with zero pointer
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Dispose_DoesNotCrash_WithZeroPointer()
        {
            ConstructorInfo ctor = typeof(Font).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(IntPtr) }, null);
            Font font = (Font)ctor.Invoke(new object[] { IntPtr.Zero });
            font.Dispose();
            Assert.Equal(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Constructors the valid filename creates font
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ValidFilename_CreatesFont()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            Assert.NotNull(font);
            Assert.NotEqual(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Constructors the valid file stream creates font
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ValidFileStream_CreatesFont()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using FileStream fs = File.OpenRead(fontPath);
            using Font font = new Font(fs);
            Assert.NotNull(font);
            Assert.NotEqual(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Constructors the valid bytes creates font
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_ValidBytes_CreatesFont()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            byte[] bytes = File.ReadAllBytes(fontPath);
            using Font font = new Font(bytes);
            Assert.NotNull(font);
            Assert.NotEqual(IntPtr.Zero, font.CPointer);
        }

        /// <summary>
        /// Constructors the copy font creates copy
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Constructor_CopyFont_CreatesCopy()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font original = new Font(fontPath);
            using Font copy = new Font(original);
            Assert.NotNull(copy);
            Assert.NotEqual(IntPtr.Zero, copy.CPointer);
            Assert.NotEqual(original.CPointer, copy.CPointer);
        }

        /// <summary>
        /// Gets the glyph with valid font returns glyph
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetGlyph_WithValidFont_ReturnsGlyph()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            Glyph glyph = font.GetGlyph(65, 30, false, 0);
            Assert.NotEqual(0u, glyph.Advance);
        }

        /// <summary>
        /// Gets the kerning with valid font returns zero or value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetKerning_WithValidFont_ReturnsZeroOrValue()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            float kerning = font.GetKerning(65, 66, 30);
            Assert.True(kerning >= 0);
        }

        /// <summary>
        /// Gets the line spacing with valid font returns positive value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetLineSpacing_WithValidFont_ReturnsPositiveValue()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            float spacing = font.GetLineSpacing(30);
            Assert.True(spacing > 0);
        }

        /// <summary>
        /// Gets the underline position with valid font returns value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetUnderlinePosition_WithValidFont_ReturnsValue()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            float position = font.GetUnderlinePosition(30);
            Assert.True(position >= 0);
        }

        /// <summary>
        /// Gets the underline thickness with valid font returns positive value
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetUnderlineThickness_WithValidFont_ReturnsPositiveValue()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            float thickness = font.GetUnderlineThickness(30);
            Assert.True(thickness > 0);
        }

        /// <summary>
        /// Gets the texture with valid font returns texture
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetTexture_WithValidFont_ReturnsTexture()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            Texture texture = font.GetTexture(30);
            Assert.NotNull(texture);
            Assert.NotEqual(IntPtr.Zero, texture.CPointer);
            font.GetTexture(30);
        }

        /// <summary>
        /// Gets the info with valid font returns family
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetInfo_WithValidFont_ReturnsFamily()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            using Font font = new Font(fontPath);
            Font.Info info = font.GetInfo();
            Assert.NotNull(info.Family);
            Assert.NotEmpty(info.Family);
        }

        /// <summary>
        /// Destroys the with real font sets c pointer to zero
        /// </summary>
        [RequireCSfmlSystemFact]
        public void Destroy_WithRealFont_SetsCPointerToZero()
        {
            string fontPath = "/System/Library/Fonts/Symbol.ttf";
            Font font = new Font(fontPath);
            Assert.NotEqual(IntPtr.Zero, font.CPointer);
            font.Destroy(true);
            Assert.Equal(IntPtr.Zero, font.CPointer);
        }

    }
}
