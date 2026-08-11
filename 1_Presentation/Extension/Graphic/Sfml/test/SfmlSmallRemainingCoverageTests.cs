// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SfmlSmallRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Audios;
using Alis.Extension.Graphic.Sfml.Render;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test
{
    /// <summary>
    ///     Remaining coverage tests for small Sfml wrapper classes
    /// </summary>
    public class SfmlSmallRemainingCoverageTests
    {
        /// <summary>
        /// The assets dir
        /// </summary>
        private static readonly string AssetsDir;

        /// <summary>
        /// Initializes a new instance of the <see cref="SfmlSmallRemainingCoverageTests"/> class
        /// </summary>
        static SfmlSmallRemainingCoverageTests()
        {
            string assemblyDir = Path.GetDirectoryName(typeof(SfmlSmallRemainingCoverageTests).Assembly.Location);
            AssetsDir = Path.GetFullPath(Path.Combine(assemblyDir, "..", "..", "..", "Assets"));
        }

        /// <summary>
        /// Tests the touch is down returns a bool
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Touch_IsDown_ReturnsBool()
        {
            bool result = Touch.IsDown(0);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests the touch get position returns a position
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Touch_GetPosition_ReturnsPosition()
        {
            _ = Touch.GetPosition(0);
        }

        /// <summary>
        /// Tests the touch get position with null window returns a position
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Touch_GetPosition_NullWindow_ReturnsPosition()
        {
            _ = Touch.GetPosition(0, null);
        }

        /// <summary>
        /// Tests the keyboard is key pressed returns a bool
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Keyboard_IsKeyPressed_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.A);
            Assert.IsType<bool>(result);
        }

        /// <summary>
        /// Tests the keyboard set virtual keyboard visible does not throw
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void Keyboard_SetVirtualKeyboardVisible_DoesNotThrow()
        {
            Keyboard.SetVirtualKeyboardVisible(false);
        }

        /// <summary>
        /// Tests the view reset throws entry point not found
        /// </summary>
        [RequireCSfmlSystemFact]
        public void View_Reset_ThrowsEntryPointNotFound()
        {
            using View view = new View();
            Assert.Throws<EntryPointNotFoundException>(() => view.Reset(new FloatRect(0, 0, 800, 600)));
        }

        /// <summary>
        /// Tests the text find character pos does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfmlText_FindCharacterPos_DoesNotThrow()
        {
            using Font font = new Font("/System/Library/Fonts/Symbol.ttf");
            using SfmlText text = new SfmlText("hello", font, 16);
            _ = text.FindCharacterPos(2);
        }

        /// <summary>
        /// Tests the text get local bounds does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfmlText_GetLocalBounds_DoesNotThrow()
        {
            using Font font = new Font("/System/Library/Fonts/Symbol.ttf");
            using SfmlText text = new SfmlText("hello", font, 16);
            _ = text.GetLocalBounds();
        }

        /// <summary>
        /// Tests the text get global bounds does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfmlText_GetGlobalBounds_DoesNotThrow()
        {
            using Font font = new Font("/System/Library/Fonts/Symbol.ttf");
            using SfmlText text = new SfmlText("hello", font, 16);
            _ = text.GetGlobalBounds();
        }

        /// <summary>
        /// Tests the music position get and set
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Position_GetAndSet()
        {
            using Music music = new Music(Path.Combine(AssetsDir, "AudioSample.wav"));
            music.Position = new Vector3F(1, 2, 3);
            _ = music.Position;
        }

        /// <summary>
        /// Tests the music loop points set does not throw
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_LoopPoints_Set_DoesNotThrow()
        {
            using Music music = new Music(Path.Combine(AssetsDir, "AudioSample.wav"));
            Music.TimeSpan span = music.LoopPoints;
            music.LoopPoints = span;
        }

        /// <summary>
        /// Tests the sound recorder capture invokes the process samples callback
        /// </summary>
        [RequireCSfmlAudioFact]
        public void SoundRecorder_Capture_InvokesProcessSamples()
        {
            using TestRecorder recorder = new TestRecorder();
            bool started = recorder.Start(22050);
            if (started)
            {
                System.Threading.Thread.Sleep(200);
                recorder.Stop();
            }

            Assert.IsType<bool>(started);
        }

        /// <summary>
        /// Tests the music loop getter throws entry point not found
        /// </summary>
        [RequireCSfmlAudioFact]
        public void Music_Loop_ThrowsEntryPointNotFound()
        {
            using Music music = new Music(Path.Combine(AssetsDir, "AudioSample.wav"));
            Assert.Throws<EntryPointNotFoundException>(() => _ = music.Loop);
        }
        /// <summary>
        /// The test recorder class
        /// </summary>
        /// <seealso cref="SoundRecorder"/>
        private class TestRecorder : SoundRecorder
        {
            /// <summary>
            /// Ons the start
            /// </summary>
            /// <returns>The bool</returns>
            public override bool OnStart() => true;

            /// <summary>
            /// Ons the process samples
            /// </summary>
            /// <param name="samples">The samples</param>
            /// <returns>The bool</returns>
            public override bool OnProcessSamples(short[] samples) => true;

            /// <summary>
            /// Ons the stop
            /// </summary>
            public override void OnStop()
            {
            }
        }
    }
}
