// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioSourceBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Components.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    public class AudioSourceBuilderTest
    {
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            Assert.NotNull(builder);
        }

        [Fact]
        public void Build_ReturnsAudioSourceInstance()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSource audioSource = builder.Build();
            Assert.NotNull(audioSource);
        }

        [Fact]
        public void File_SetsFilePath_ReturnsBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSourceBuilder result = builder.File("audio/test.wav");
            Assert.Same(builder, result);
        }

        [Fact]
        public void Volume_SetsVolume_ReturnsBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSourceBuilder result = builder.Volume(75f);
            Assert.Same(builder, result);
        }

        [Fact]
        public void Mute_SetsMute_ReturnsBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSourceBuilder result = builder.Mute(true);
            Assert.Same(builder, result);
        }

        [Fact]
        public void PlayOnAwake_SetsPlayOnAwake_ReturnsBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSourceBuilder result = builder.PlayOnAwake(true);
            Assert.Same(builder, result);
        }

        [Fact]
        public void Loop_SetsLoop_ReturnsBuilder()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSourceBuilder result = builder.Loop(true);
            Assert.Same(builder, result);
        }

        [Fact]
        public void ChainingAllProperties_CreatesAudioSource()
        {
            Context context = new Context();
            AudioSourceBuilder builder = new AudioSourceBuilder(context);
            AudioSource audioSource = builder
                .File("audio/sound.wav")
                .Volume(50f)
                .Mute(false)
                .PlayOnAwake(true)
                .Loop(true)
                .Build();
            Assert.NotNull(audioSource);
        }
    }
}
