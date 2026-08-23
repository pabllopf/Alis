// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlScancodeTest.cs
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

using Alis.Extension.Graphic.Sdl2.Mapping;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The sdl scancode test class
    /// </summary>
    public class SdlScancodeTest
    {
        /// <summary>
        /// Tests that unknown is zero
        /// </summary>
        [RequireSdl2ImageFact]
        public void Unknown_IsZero()
        {
            Assert.Equal(0, (int)SdlScancode.SdlScancodeUnknown);
        }

        /// <summary>
        /// Tests that letter keys start at 4
        /// </summary>
        [RequireSdl2ImageFact]
        public void LetterKeys_StartAt4()
        {
            Assert.Equal(4, (int)SdlScancode.SdlScancodeA);
            Assert.Equal(5, (int)SdlScancode.SdlScancodeB);
            Assert.Equal(29, (int)SdlScancode.SdlScancodeZ);
        }

        /// <summary>
        /// Tests that number keys start at 30
        /// </summary>
        [RequireSdl2ImageFact]
        public void NumberKeys_StartAt30()
        {
            Assert.Equal(30, (int)SdlScancode.SdlScancode1);
            Assert.Equal(31, (int)SdlScancode.SdlScancode2);
            Assert.Equal(38, (int)SdlScancode.SdlScancode9);
            Assert.Equal(39, (int)SdlScancode.SdlScancode0);
        }

        /// <summary>
        /// Tests that function keys start at 58
        /// </summary>
        [RequireSdl2ImageFact]
        public void FunctionKeys_StartAt58()
        {
            Assert.Equal(58, (int)SdlScancode.SdlScancodeF1);
            Assert.Equal(69, (int)SdlScancode.SdlScancodeF12);
            Assert.Equal(115, (int)SdlScancode.SdlScancodeF24);
        }

        /// <summary>
        /// Tests that arrow keys are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void ArrowKeys_AreCorrect()
        {
            Assert.Equal(79, (int)SdlScancode.SdlScancodeRight);
            Assert.Equal(80, (int)SdlScancode.SdlScancodeLeft);
            Assert.Equal(81, (int)SdlScancode.SdlScancodeDown);
            Assert.Equal(82, (int)SdlScancode.SdlScancodeUp);
        }

        /// <summary>
        /// Tests that modifier keys start at 224
        /// </summary>
        [RequireSdl2ImageFact]
        public void ModifierKeys_StartAt224()
        {
            Assert.Equal(224, (int)SdlScancode.SdlScancodeLctrl);
            Assert.Equal(225, (int)SdlScancode.SdlScancodeLshift);
            Assert.Equal(226, (int)SdlScancode.SdlScancodeLalt);
            Assert.Equal(227, (int)SdlScancode.SdlScancodeLgui);
            Assert.Equal(228, (int)SdlScancode.SdlScancodeRctrl);
            Assert.Equal(229, (int)SdlScancode.SdlScancodeRshift);
            Assert.Equal(230, (int)SdlScancode.SdlScancodeRalt);
            Assert.Equal(231, (int)SdlScancode.SdlScancodeRgui);
        }

        /// <summary>
        /// Tests that num scancodes is 512
        /// </summary>
        [RequireSdl2ImageFact]
        public void NumScancodes_Is512()
        {
            Assert.Equal(512, (int)SdlScancode.SdlNumScancodes);
        }

        /// <summary>
        /// Tests that return is 40
        /// </summary>
        [RequireSdl2ImageFact]
        public void Return_Is40()
        {
            Assert.Equal(40, (int)SdlScancode.SdlScancodeReturn);
        }

        /// <summary>
        /// Tests that escape is 41
        /// </summary>
        [RequireSdl2ImageFact]
        public void Escape_Is41()
        {
            Assert.Equal(41, (int)SdlScancode.SdlScancodeEscape);
        }

        /// <summary>
        /// Tests that backspace is 42
        /// </summary>
        [RequireSdl2ImageFact]
        public void Backspace_Is42()
        {
            Assert.Equal(42, (int)SdlScancode.SdlScancodeBackspace);
        }

        /// <summary>
        /// Tests that space is 44
        /// </summary>
        [RequireSdl2ImageFact]
        public void Space_Is44()
        {
            Assert.Equal(44, (int)SdlScancode.SdlScancodeSpace);
        }

        /// <summary>
        /// Tests that delete is 76
        /// </summary>
        [RequireSdl2ImageFact]
        public void Delete_Is76()
        {
            Assert.Equal(76, (int)SdlScancode.SdlScancodeDelete);
        }

        /// <summary>
        /// Tests that page navigation are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void PageNavigation_AreCorrect()
        {
            Assert.Equal(74, (int)SdlScancode.SdlScancodeHome);
            Assert.Equal(75, (int)SdlScancode.SdlScancodePageup);
            Assert.Equal(77, (int)SdlScancode.SdlScancodeEnd);
            Assert.Equal(78, (int)SdlScancode.SdlScancodePagedown);
        }

        /// <summary>
        /// Tests that keypad keys are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void KeypadKeys_AreCorrect()
        {
            Assert.Equal(84, (int)SdlScancode.SdlScancodeKpDivide);
            Assert.Equal(85, (int)SdlScancode.SdlScancodeKpMultiply);
            Assert.Equal(86, (int)SdlScancode.SdlScancodeKpMinus);
            Assert.Equal(87, (int)SdlScancode.SdlScancodeKpPlus);
            Assert.Equal(88, (int)SdlScancode.SdlScancodeKpEnter);
            Assert.Equal(89, (int)SdlScancode.SdlScancodeKp1);
            Assert.Equal(98, (int)SdlScancode.SdlScancodeKp0);
            Assert.Equal(99, (int)SdlScancode.SdlScancodeKpPeriod);
        }

        /// <summary>
        /// Tests that multimedia keys are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void MultimediaKeys_AreCorrect()
        {
            Assert.Equal(258, (int)SdlScancode.SdlScancodeAudionext);
            Assert.Equal(259, (int)SdlScancode.SdlScancodeAudioprev);
            Assert.Equal(260, (int)SdlScancode.SdlScancodeAudiostop);
            Assert.Equal(261, (int)SdlScancode.SdlScancodeAudioplay);
            Assert.Equal(262, (int)SdlScancode.SdlScancodeAudiomute);
        }

        /// <summary>
        /// Tests that brightness and display keys are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void BrightnessAndDisplayKeys_AreCorrect()
        {
            Assert.Equal(275, (int)SdlScancode.SdlScancodeBrightnessdown);
            Assert.Equal(276, (int)SdlScancode.SdlScancodeBrightnessup);
            Assert.Equal(277, (int)SdlScancode.SdlScancodeDisplayswitch);
        }

        /// <summary>
        /// Tests that audio rewind and fast forward are correct
        /// </summary>
        [RequireSdl2ImageFact]
        public void AudioRewindAndFastForward_AreCorrect()
        {
            Assert.Equal(285, (int)SdlScancode.SdlScancodeAudiorewind);
            Assert.Equal(286, (int)SdlScancode.SdlScancodeAudiofastforward);
        }
    }
}
