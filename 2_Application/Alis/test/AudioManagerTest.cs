// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AudioManagerTest.cs
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

//  File:AudioManagerTest.cs
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


using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Audio;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    ///     Contains unit tests for the <see cref="AudioManager" /> class.
    /// </summary>
    public class AudioManagerTest
    {
        /// <summary>
        ///     Tests that the constructor creates an AudioManager with the provided context.
        /// </summary>
        [Fact]
        public void Constructor_CreatesAudioManager_WithContext()
        {
            // Arrange
            Context context = new Context(new Setting());

            // Act
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.NotNull(audioManager);
            Assert.Same(context, audioManager.Context);
        }

        /// <summary>
        ///     Tests that AudioManager inherits from AManager.
        /// </summary>
        [Fact]
        public void AudioManager_InheritsFromAManager()
        {
            // Arrange & Act
            Context context = new Context(new Setting());
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.IsAssignableFrom<AManager>(audioManager);
        }

        /// <summary>
        ///     Tests that AudioManager has the expected default properties.
        /// </summary>
        [Fact]
        public void AudioManager_HasExpectedProperties()
        {
            // Arrange & Act
            Context context = new Context(new Setting());
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.NotNull(audioManager.Id);
            Assert.Equal("Manager", audioManager.Name);
            Assert.Equal("Untagged", audioManager.Tag);
            Assert.True(audioManager.IsEnable);
        }

        /// <summary>
        ///     Tests that the AudioManager context is set correctly.
        /// </summary>
        [Fact]
        public void AudioManager_Context_IsSetCorrectly()
        {
            // Arrange
            Context context = new Context(new Setting());

            // Act
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.NotNull(audioManager.Context);
            Assert.Same(context, audioManager.Context);
        }

        /// <summary>
        ///     Tests that AudioManager implements IManager interface.
        /// </summary>
        [Fact]
        public void AudioManager_ImplementsIManagerInterface()
        {
            // Arrange & Act
            Context context = new Context(new Setting());
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.IsAssignableFrom<IManager>(audioManager);
        }

        /// <summary>
        ///     Tests that the AudioManager default state is valid.
        /// </summary>
        [Fact]
        public void AudioManager_DefaultState_IsValid()
        {
            // Arrange & Act
            Context context = new Context(new Setting());
            AudioManager audioManager = new AudioManager(context);

            // Assert
            Assert.NotNull(audioManager.Id);
            Assert.NotEmpty(audioManager.Id);
            Assert.NotNull(audioManager.Name);
            Assert.NotNull(audioManager.Tag);
            Assert.True(audioManager.IsEnable);
        }

        /// <summary>
        ///     Tests that AudioManager properties are accessible.
        /// </summary>
        [Fact]
        public void AudioManager_Properties_AreAccessible()
        {
            // Arrange
            Context context = new Context(new Setting());

            // Act
            AudioManager audioManager = new AudioManager(context);
            audioManager.Name = "Audio";
            audioManager.Tag = "AudioTag";
            audioManager.IsEnable = false;

            // Assert
            Assert.Equal("Audio", audioManager.Name);
            Assert.Equal("AudioTag", audioManager.Tag);
            Assert.False(audioManager.IsEnable);
        }

        /// <summary>
        ///     Tests the full constructor with all parameters.
        /// </summary>
        [Theory]
        [InlineData("test-id", "TestAudio", "AudioTag", true)]
        [InlineData("", "", "", false)]
        public void FullConstructor_SetsAllProperties(string id, string name, string tag, bool isEnable)
        {
            // Arrange
            Context context = new Context(new Setting());

            // Act
            AudioManager audioManager = new AudioManager(id, name, tag, isEnable, context);

            // Assert
            Assert.Equal(id, audioManager.Id);
            Assert.Equal(name, audioManager.Name);
            Assert.Equal(tag, audioManager.Tag);
            Assert.Equal(isEnable, audioManager.IsEnable);
        }
    }
}
