// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundBufferTest.cs
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
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound buffer test class
    /// </summary>
    public class SoundBufferTest
    {
        /// <summary>
        /// Sounds the buffer is assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_IsAssignableFromObjectBase()
        {
            System.Type type = typeof(SoundBuffer);
            Assert.True(typeof(ObjectBase).IsAssignableFrom(type));
        }

        /// <summary>
        /// Sounds the buffer class exists
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Class_Exists()
        {
            System.Type type = typeof(SoundBuffer);
            Assert.NotNull(type);
        }

        /// <summary>
        /// Sounds the buffer implements i disposable
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Implements_IDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(SoundBuffer)));
        }

        /// <summary>
        /// Sounds the buffer has sample rate property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_SampleRate_Property()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.PropertyInfo prop = type.GetProperty("SampleRate");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.Equal(typeof(uint), prop.PropertyType);
        }

        /// <summary>
        /// Sounds the buffer has channel count property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_ChannelCount_Property()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.PropertyInfo prop = type.GetProperty("ChannelCount");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.Equal(typeof(uint), prop.PropertyType);
        }

        /// <summary>
        /// Sounds the buffer has duration property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Duration_Property()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.PropertyInfo prop = type.GetProperty("Duration");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.Equal(typeof(SfmlTime), prop.PropertyType);
        }

        /// <summary>
        /// Sounds the buffer has samples property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Samples_Property()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.PropertyInfo prop = type.GetProperty("Samples");
            Assert.NotNull(prop);
            Assert.True(prop.CanRead);
            Assert.Equal(typeof(short[]), prop.PropertyType);
        }

        /// <summary>
        /// Sounds the buffer has save to file method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_SaveToFile_Method()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.MethodInfo method = type.GetMethod("SaveToFile");
            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer has destroy method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Destroy_Method()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.MethodInfo method = type.GetMethod("Destroy");
            Assert.NotNull(method);
        }

        /// <summary>
        /// Sounds the buffer to string returns formatted string
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_ToString_Returns_Formatted_String()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.MethodInfo method = type.GetMethod("ToString");
            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
        }

        /// <summary>
        /// Sounds the buffer has string constructor
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_String_Constructor()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(string) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Sounds the buffer has stream constructor
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Stream_Constructor()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(Stream) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Sounds the buffer has byte array constructor
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_ByteArray_Constructor()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(byte[]) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Sounds the buffer has samples constructor
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Samples_Constructor()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(short[]), typeof(uint), typeof(uint) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Sounds the buffer has copy constructor
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_Copy_Constructor()
        {
            System.Type type = typeof(SoundBuffer);
            System.Reflection.ConstructorInfo ctor = type.GetConstructor(new[] { typeof(SoundBuffer) });
            Assert.NotNull(ctor);
        }

        /// <summary>
        /// Sounds the buffer namespace is correct
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Namespace_Is_Correct()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(SoundBuffer).Namespace);
        }

        /// <summary>
        /// Sounds the buffer is public
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_IsPublic()
        {
            Assert.True(typeof(SoundBuffer).IsPublic);
        }

        /// <summary>
        /// Sounds the buffer has base type object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_Has_BaseType_ObjectBase()
        {
            Assert.Equal(typeof(ObjectBase), typeof(SoundBuffer).BaseType);
        }

        /// <summary>
        /// Sounds the buffer base type has c pointer property
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundBuffer_BaseType_Has_CPointer_Property()
        {
            System.Type baseType = typeof(SoundBuffer).BaseType;
            System.Reflection.PropertyInfo prop = baseType.GetProperty("CPointer");
            Assert.NotNull(prop);
            Assert.Equal(typeof(IntPtr), prop.PropertyType);
        }
    }
}
