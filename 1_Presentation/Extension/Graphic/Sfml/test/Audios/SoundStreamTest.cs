// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SoundStreamTest.cs
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
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Audios
{
    /// <summary>
    /// The sound stream test class
    /// </summary>
    public class SoundStreamTest
    {
        /// <summary>
        /// Sounds the stream type should be accessible
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_Type_ShouldBeAccessible()
        {
            Assert.NotNull(typeof(SoundStream));
        }

        /// <summary>
        /// Sounds the stream should be abstract
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldBeAbstract()
        {
            Assert.True(typeof(SoundStream).IsAbstract);
        }

        /// <summary>
        /// Sounds the stream should be assignable from object base
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldBeAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(SoundStream)));
        }

        /// <summary>
        /// Sounds the stream namespace should be correct
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_Namespace_ShouldBeCorrect()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(SoundStream).Namespace);
        }

        /// <summary>
        /// Sounds the stream should implement i disposable
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldImplementIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(SoundStream)));
        }

        /// <summary>
        /// Sounds the stream constructor sets c pointer to zero
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_Constructor_SetsCPointerToZero()
        {
            SoundStream_Accessor stream = new SoundStream_Accessor();
            Assert.Equal(IntPtr.Zero, stream.CPointer);
            stream.Dispose();
        }

        /// <summary>
        /// Sounds the stream has abstract on get data
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_HasAbstractOnGetData()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("OnGetData");
            Assert.NotNull(method);
            Assert.True(method.IsAbstract);
            Assert.True(method.IsPublic);
        }

        /// <summary>
        /// Sounds the stream has abstract on seek
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_HasAbstractOnSeek()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("OnSeek");
            Assert.NotNull(method);
            Assert.True(method.IsAbstract);
            Assert.True(method.IsPublic);
        }

        /// <summary>
        /// Sounds the stream has public play method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicPlayMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Play");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        /// <summary>
        /// Sounds the stream has public pause method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicPauseMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Pause");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        /// <summary>
        /// Sounds the stream has public stop method
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicStopMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Stop");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        /// <summary>
        /// The soundstream accessor class
        /// </summary>
        /// <seealso cref="SoundStream"/>
        private class SoundStream_Accessor : SoundStream
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="SoundStream_Accessor"/> class
            /// </summary>
            public SoundStream_Accessor() : base()
            {
            }

            /// <summary>
            /// Ons the get data using the specified samples
            /// </summary>
            /// <param name="samples">The samples</param>
            /// <returns>The bool</returns>
            public override bool OnGetData(out short[] samples)
            {
                samples = System.Array.Empty<short>();
                return true;
            }

            /// <summary>
            /// Ons the seek using the specified sfml time offset
            /// </summary>
            /// <param name="sfmlTimeOffset">The sfml time offset</param>
            public override void OnSeek(SfmlTime sfmlTimeOffset)
            {
            }
        }
    }
}
