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
    public class SoundStreamTest
    {
        [RequireCSfmlAudioFact]
        public void SoundStream_Type_ShouldBeAccessible()
        {
            Assert.NotNull(typeof(SoundStream));
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldBeAbstract()
        {
            Assert.True(typeof(SoundStream).IsAbstract);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldBeAssignableFromObjectBase()
        {
            Assert.True(typeof(ObjectBase).IsAssignableFrom(typeof(SoundStream)));
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_Namespace_ShouldBeCorrect()
        {
            Assert.Equal("Alis.Extension.Graphic.Sfml.Audios", typeof(SoundStream).Namespace);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_ShouldImplementIDisposable()
        {
            Assert.True(typeof(IDisposable).IsAssignableFrom(typeof(SoundStream)));
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_Constructor_SetsCPointerToZero()
        {
            SoundStream_Accessor stream = new SoundStream_Accessor();
            Assert.Equal(IntPtr.Zero, stream.CPointer);
            stream.Dispose();
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_HasAbstractOnGetData()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("OnGetData");
            Assert.NotNull(method);
            Assert.True(method.IsAbstract);
            Assert.True(method.IsPublic);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_HasAbstractOnSeek()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("OnSeek");
            Assert.NotNull(method);
            Assert.True(method.IsAbstract);
            Assert.True(method.IsPublic);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicPlayMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Play");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicPauseMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Pause");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        [RequireCSfmlAudioFact]
        public void SoundStream_HasPublicStopMethod()
        {
            System.Reflection.MethodInfo method = typeof(SoundStream).GetMethod("Stop");
            Assert.NotNull(method);
            Assert.True(method.IsPublic);
        }

        private class SoundStream_Accessor : SoundStream
        {
            public SoundStream_Accessor() : base()
            {
            }

            public override bool OnGetData(out short[] samples)
            {
                samples = System.Array.Empty<short>();
                return true;
            }

            public override void OnSeek(SfmlTime sfmlTimeOffset)
            {
            }
        }
    }
}
