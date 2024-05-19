// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyCodeTest.cs
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

using Alis.Core.Aspect.Data.Mapping;
using Xunit;

namespace Alis.Core.Aspect.Data.Test.Mapping
{
    /// <summary>
    /// The key code test class
    /// </summary>
    public class KeyCodeTest
    {
        /// <summary>
        /// Tests that lshift should be correct value
        /// </summary>
        [Fact]
        public void Lshift_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeLshift | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Lshift);
        }
        
        /// <summary>
        /// Tests that lalt should be correct value
        /// </summary>
        [Fact]
        public void Lalt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeLalt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Lalt);
        }
        
        /// <summary>
        /// Tests that lgui should be correct value
        /// </summary>
        [Fact]
        public void Lgui_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeLgui | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Lgui);
        }
        
        /// <summary>
        /// Tests that rctrl should be correct value
        /// </summary>
        [Fact]
        public void Rctrl_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeRctrl | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Rctrl);
        }
        
        /// <summary>
        /// Tests that rshift should be correct value
        /// </summary>
        [Fact]
        public void Rshift_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeRshift | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Rshift);
        }
        
        /// <summary>
        /// Tests that ralt should be correct value
        /// </summary>
        [Fact]
        public void Ralt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeRalt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Ralt);
        }
        
        /// <summary>
        /// Tests that rgui should be correct value
        /// </summary>
        [Fact]
        public void Rgui_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeRgui | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Rgui);
        }
        
        /// <summary>
        /// Tests that mode should be correct value
        /// </summary>
        [Fact]
        public void Mode_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeMode | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Mode);
        }
        
        /// <summary>
        /// Tests that audionext should be correct value
        /// </summary>
        [Fact]
        public void Audionext_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudionext | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audionext);
        }
        
        /// <summary>
        /// Tests that audioprev should be correct value
        /// </summary>
        [Fact]
        public void Audioprev_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudioprev | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audioprev);
        }
        
        /// <summary>
        /// Tests that audiostop should be correct value
        /// </summary>
        [Fact]
        public void Audiostop_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiostop | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiostop);
        }
        
        /// <summary>
        /// Tests that audioplay should be correct value
        /// </summary>
        [Fact]
        public void Audioplay_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudioplay | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audioplay);
        }
        
        /// <summary>
        /// Tests that audiomute should be correct value
        /// </summary>
        [Fact]
        public void Audiomute_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiomute | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiomute);
        }
        
        /// <summary>
        /// Tests that mediaselect should be correct value
        /// </summary>
        [Fact]
        public void Mediaselect_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeMediaselect | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Mediaselect);
        }
        
        /// <summary>
        /// Tests that www should be correct value
        /// </summary>
        [Fact]
        public void Www_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeWww | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Www);
        }
        
        /// <summary>
        /// Tests that mail should be correct value
        /// </summary>
        [Fact]
        public void Mail_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeMail | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Mail);
        }
        
        /// <summary>
        /// Tests that calculator should be correct value
        /// </summary>
        [Fact]
        public void Calculator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeCalculator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Calculator);
        }
        
        /// <summary>
        /// Tests that computer should be correct value
        /// </summary>
        [Fact]
        public void Computer_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeComputer | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Computer);
        }
        
        /// <summary>
        /// Tests that ac search should be correct value
        /// </summary>
        [Fact]
        public void AcSearch_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcSearch | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcSearch);
        }
        
        /// <summary>
        /// Tests that ac home should be correct value
        /// </summary>
        [Fact]
        public void AcHome_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcHome | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcHome);
        }
        
        /// <summary>
        /// Tests that ac back should be correct value
        /// </summary>
        [Fact]
        public void AcBack_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcBack | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcBack);
        }
        
        /// <summary>
        /// Tests that ac forward should be correct value
        /// </summary>
        [Fact]
        public void AcForward_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcForward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcForward);
        }
        
        /// <summary>
        /// Tests that ac stop should be correct value
        /// </summary>
        [Fact]
        public void AcStop_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcStop | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcStop);
        }
        
        /// <summary>
        /// Tests that ac refresh should be correct value
        /// </summary>
        [Fact]
        public void AcRefresh_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcRefresh | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcRefresh);
        }
        
        /// <summary>
        /// Tests that ac bookmarks should be correct value
        /// </summary>
        [Fact]
        public void AcBookmarks_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAcBookmarks | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.AcBookmarks);
        }
        
        /// <summary>
        /// Tests that brightnessdown should be correct value
        /// </summary>
        [Fact]
        public void Brightnessdown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeBrightnessdown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Brightnessdown);
        }
        
        /// <summary>
        /// Tests that brightnessup should be correct value
        /// </summary>
        [Fact]
        public void Brightnessup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeBrightnessup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Brightnessup);
        }
        
        /// <summary>
        /// Tests that displayswitch should be correct value
        /// </summary>
        [Fact]
        public void Displayswitch_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeDisplayswitch | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Displayswitch);
        }
        
        /// <summary>
        /// Tests that kbdillumtoggle should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumtoggle_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKbdillumtoggle | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kbdillumtoggle);
        }
        
        /// <summary>
        /// Tests that kbdillumdown should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumdown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKbdillumdown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kbdillumdown);
        }
        
        /// <summary>
        /// Tests that kbdillumup should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKbdillumup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kbdillumup);
        }
        
        /// <summary>
        /// Tests that eject should be correct value
        /// </summary>
        [Fact]
        public void Eject_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeEject | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Eject);
        }
        
        /// <summary>
        /// Tests that sleep should be correct value
        /// </summary>
        [Fact]
        public void Sleep_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeSleep | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Sleep);
        }
        
        /// <summary>
        /// Tests that app 1 should be correct value
        /// </summary>
        [Fact]
        public void App1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeApp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.App1);
        }
        
        /// <summary>
        /// Tests that app 2 should be correct value
        /// </summary>
        [Fact]
        public void App2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeApp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.App2);
        }
        
        /// <summary>
        /// Tests that audiorewind should be correct value
        /// </summary>
        [Fact]
        public void Audiorewind_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiorewind | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiorewind);
        }
        
        /// <summary>
        /// Tests that audiofastforward should be correct value
        /// </summary>
        [Fact]
        public void Audiofastforward_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiofastforward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiofastforward);
        }
        
        /// <summary>
        /// Tests that capslock should be correct value
        /// </summary>
        [Fact]
        public void Capslock_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeCapslock | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Capslock);
        }
        
        /// <summary>
        /// Tests that f 1 should be correct value
        /// </summary>
        [Fact]
        public void F1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF1 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F1);
        }
        
        /// <summary>
        /// Tests that f 2 should be correct value
        /// </summary>
        [Fact]
        public void F2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF2 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F2);
        }
        
        /// <summary>
        /// Tests that f 3 should be correct value
        /// </summary>
        [Fact]
        public void F3_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF3 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F3);
        }
        
        /// <summary>
        /// Tests that f 4 should be correct value
        /// </summary>
        [Fact]
        public void F4_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF4 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F4);
        }
        
        /// <summary>
        /// Tests that f 5 should be correct value
        /// </summary>
        [Fact]
        public void F5_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF5 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F5);
        }
        
        /// <summary>
        /// Tests that f 6 should be correct value
        /// </summary>
        [Fact]
        public void F6_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF6 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F6);
        }
        
        /// <summary>
        /// Tests that f 7 should be correct value
        /// </summary>
        [Fact]
        public void F7_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF7 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F7);
        }
        
        /// <summary>
        /// Tests that f 8 should be correct value
        /// </summary>
        [Fact]
        public void F8_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF8 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F8);
        }
        
        /// <summary>
        /// Tests that f 9 should be correct value
        /// </summary>
        [Fact]
        public void F9_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF9 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F9);
        }
        
        /// <summary>
        /// Tests that f 10 should be correct value
        /// </summary>
        [Fact]
        public void F10_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF10 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F10);
        }
        
        /// <summary>
        /// Tests that f 11 should be correct value
        /// </summary>
        [Fact]
        public void F11_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF11 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F11);
        }
        
        /// <summary>
        /// Tests that f 12 should be correct value
        /// </summary>
        [Fact]
        public void F12_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeF12 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.F12);
        }
        
        /// <summary>
        /// Tests that printscreen should be correct value
        /// </summary>
        [Fact]
        public void Printscreen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodePrintscreen | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Printscreen);
        }
        
        /// <summary>
        /// Tests that scrolllock should be correct value
        /// </summary>
        [Fact]
        public void Scrolllock_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeScrolllock | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Scrolllock);
        }
        
        /// <summary>
        /// Tests that pause should be correct value
        /// </summary>
        [Fact]
        public void Pause_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodePause | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Pause);
        }
        
        /// <summary>
        /// Tests that insert should be correct value
        /// </summary>
        [Fact]
        public void Insert_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeInsert | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Insert);
        }
        
        /// <summary>
        /// Tests that home should be correct value
        /// </summary>
        [Fact]
        public void Home_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeHome | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Home);
        }
        
        /// <summary>
        /// Tests that pageup should be correct value
        /// </summary>
        [Fact]
        public void Pageup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodePageup | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Pageup);
        }
        
        /// <summary>
        /// Tests that delete should be correct value
        /// </summary>
        [Fact]
        public void Delete_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)127, KeyCode.Delete);
        }
        
        /// <summary>
        /// Tests that end should be correct value
        /// </summary>
        [Fact]
        public void End_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode)(SdlScancode.SdlScancodeEnd | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.End);
        }
        
        /// <summary>
        /// Tests that pagedown should be correct value
        /// </summary>
        [Fact]
        public void Pagedown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePagedown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Pagedown);
        }
    }
}