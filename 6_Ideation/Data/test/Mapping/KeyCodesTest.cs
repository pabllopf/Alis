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
    public class KeyCodesTest
    {
        /// <summary>
        /// Tests that lshift should be correct value
        /// </summary>
        [Fact]
        public void Lshift_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeLshift | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Lshift);
        }
        
        /// <summary>
        /// Tests that lalt should be correct value
        /// </summary>
        [Fact]
        public void Lalt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeLalt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Lalt);
        }
        
        /// <summary>
        /// Tests that lgui should be correct value
        /// </summary>
        [Fact]
        public void Lgui_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeLgui | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Lgui);
        }
        
        /// <summary>
        /// Tests that rctrl should be correct value
        /// </summary>
        [Fact]
        public void Rctrl_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeRctrl | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Rctrl);
        }
        
        /// <summary>
        /// Tests that rshift should be correct value
        /// </summary>
        [Fact]
        public void Rshift_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeRshift | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Rshift);
        }
        
        /// <summary>
        /// Tests that ralt should be correct value
        /// </summary>
        [Fact]
        public void Ralt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeRalt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Ralt);
        }
        
        /// <summary>
        /// Tests that rgui should be correct value
        /// </summary>
        [Fact]
        public void Rgui_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeRgui | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Rgui);
        }
        
        /// <summary>
        /// Tests that mode should be correct value
        /// </summary>
        [Fact]
        public void Mode_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeMode | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Mode);
        }
        
        /// <summary>
        /// Tests that audionext should be correct value
        /// </summary>
        [Fact]
        public void Audionext_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudionext | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audionext);
        }
        
        /// <summary>
        /// Tests that audioprev should be correct value
        /// </summary>
        [Fact]
        public void Audioprev_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudioprev | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audioprev);
        }
        
        /// <summary>
        /// Tests that audiostop should be correct value
        /// </summary>
        [Fact]
        public void Audiostop_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiostop | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiostop);
        }
        
        /// <summary>
        /// Tests that audioplay should be correct value
        /// </summary>
        [Fact]
        public void Audioplay_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudioplay | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audioplay);
        }
        
        /// <summary>
        /// Tests that audiomute should be correct value
        /// </summary>
        [Fact]
        public void Audiomute_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiomute | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiomute);
        }
        
        /// <summary>
        /// Tests that mediaselect should be correct value
        /// </summary>
        [Fact]
        public void Mediaselect_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeMediaselect | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Mediaselect);
        }
        
        /// <summary>
        /// Tests that www should be correct value
        /// </summary>
        [Fact]
        public void Www_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeWww | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Www);
        }
        
        /// <summary>
        /// Tests that mail should be correct value
        /// </summary>
        [Fact]
        public void Mail_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeMail | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Mail);
        }
        
        /// <summary>
        /// Tests that calculator should be correct value
        /// </summary>
        [Fact]
        public void Calculator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeCalculator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Calculator);
        }
        
        /// <summary>
        /// Tests that computer should be correct value
        /// </summary>
        [Fact]
        public void Computer_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeComputer | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Computer);
        }
        
        /// <summary>
        /// Tests that ac search should be correct value
        /// </summary>
        [Fact]
        public void AcSearch_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcSearch | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcSearch);
        }
        
        /// <summary>
        /// Tests that ac home should be correct value
        /// </summary>
        [Fact]
        public void AcHome_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcHome | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcHome);
        }
        
        /// <summary>
        /// Tests that ac back should be correct value
        /// </summary>
        [Fact]
        public void AcBack_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcBack | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcBack);
        }
        
        /// <summary>
        /// Tests that ac forward should be correct value
        /// </summary>
        [Fact]
        public void AcForward_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcForward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcForward);
        }
        
        /// <summary>
        /// Tests that ac stop should be correct value
        /// </summary>
        [Fact]
        public void AcStop_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcStop | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcStop);
        }
        
        /// <summary>
        /// Tests that ac refresh should be correct value
        /// </summary>
        [Fact]
        public void AcRefresh_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcRefresh | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcRefresh);
        }
        
        /// <summary>
        /// Tests that ac bookmarks should be correct value
        /// </summary>
        [Fact]
        public void AcBookmarks_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAcBookmarks | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.AcBookmarks);
        }
        
        /// <summary>
        /// Tests that brightnessdown should be correct value
        /// </summary>
        [Fact]
        public void Brightnessdown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeBrightnessdown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Brightnessdown);
        }
        
        /// <summary>
        /// Tests that brightnessup should be correct value
        /// </summary>
        [Fact]
        public void Brightnessup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeBrightnessup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Brightnessup);
        }
        
        /// <summary>
        /// Tests that displayswitch should be correct value
        /// </summary>
        [Fact]
        public void Displayswitch_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeDisplayswitch | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Displayswitch);
        }
        
        /// <summary>
        /// Tests that kbdillumtoggle should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumtoggle_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKbdillumtoggle | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kbdillumtoggle);
        }
        
        /// <summary>
        /// Tests that kbdillumdown should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumdown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKbdillumdown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kbdillumdown);
        }
        
        /// <summary>
        /// Tests that kbdillumup should be correct value
        /// </summary>
        [Fact]
        public void Kbdillumup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKbdillumup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kbdillumup);
        }
        
        /// <summary>
        /// Tests that eject should be correct value
        /// </summary>
        [Fact]
        public void Eject_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeEject | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Eject);
        }
        
        /// <summary>
        /// Tests that sleep should be correct value
        /// </summary>
        [Fact]
        public void Sleep_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeSleep | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Sleep);
        }
        
        /// <summary>
        /// Tests that app 1 should be correct value
        /// </summary>
        [Fact]
        public void App1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeApp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.App1);
        }
        
        /// <summary>
        /// Tests that app 2 should be correct value
        /// </summary>
        [Fact]
        public void App2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeApp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.App2);
        }
        
        /// <summary>
        /// Tests that audiorewind should be correct value
        /// </summary>
        [Fact]
        public void Audiorewind_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiorewind | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiorewind);
        }
        
        /// <summary>
        /// Tests that audiofastforward should be correct value
        /// </summary>
        [Fact]
        public void Audiofastforward_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiofastforward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiofastforward);
        }
        
        /// <summary>
        /// Tests that capslock should be correct value
        /// </summary>
        [Fact]
        public void Capslock_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeCapslock | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Capslock);
        }
        
        /// <summary>
        /// Tests that f 1 should be correct value
        /// </summary>
        [Fact]
        public void F1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F1);
        }
        
        /// <summary>
        /// Tests that f 2 should be correct value
        /// </summary>
        [Fact]
        public void F2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F2);
        }
        
        /// <summary>
        /// Tests that f 3 should be correct value
        /// </summary>
        [Fact]
        public void F3_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF3 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F3);
        }
        
        /// <summary>
        /// Tests that f 4 should be correct value
        /// </summary>
        [Fact]
        public void F4_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF4 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F4);
        }
        
        /// <summary>
        /// Tests that f 5 should be correct value
        /// </summary>
        [Fact]
        public void F5_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF5 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F5);
        }
        
        /// <summary>
        /// Tests that f 6 should be correct value
        /// </summary>
        [Fact]
        public void F6_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF6 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F6);
        }
        
        /// <summary>
        /// Tests that f 7 should be correct value
        /// </summary>
        [Fact]
        public void F7_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF7 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F7);
        }
        
        /// <summary>
        /// Tests that f 8 should be correct value
        /// </summary>
        [Fact]
        public void F8_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF8 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F8);
        }
        
        /// <summary>
        /// Tests that f 9 should be correct value
        /// </summary>
        [Fact]
        public void F9_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF9 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F9);
        }
        
        /// <summary>
        /// Tests that f 10 should be correct value
        /// </summary>
        [Fact]
        public void F10_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF10 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F10);
        }
        
        /// <summary>
        /// Tests that f 11 should be correct value
        /// </summary>
        [Fact]
        public void F11_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF11 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F11);
        }
        
        /// <summary>
        /// Tests that f 12 should be correct value
        /// </summary>
        [Fact]
        public void F12_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeF12 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.F12);
        }
        
        /// <summary>
        /// Tests that printscreen should be correct value
        /// </summary>
        [Fact]
        public void Printscreen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodePrintscreen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Printscreen);
        }
        
        /// <summary>
        /// Tests that scrolllock should be correct value
        /// </summary>
        [Fact]
        public void Scrolllock_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeScrolllock | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Scrolllock);
        }
        
        /// <summary>
        /// Tests that pause should be correct value
        /// </summary>
        [Fact]
        public void Pause_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodePause | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Pause);
        }
        
        /// <summary>
        /// Tests that insert should be correct value
        /// </summary>
        [Fact]
        public void Insert_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeInsert | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Insert);
        }
        
        /// <summary>
        /// Tests that home should be correct value
        /// </summary>
        [Fact]
        public void Home_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeHome | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Home);
        }
        
        /// <summary>
        /// Tests that pageup should be correct value
        /// </summary>
        [Fact]
        public void Pageup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodePageup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Pageup);
        }
        
        /// <summary>
        /// Tests that delete should be correct value
        /// </summary>
        [Fact]
        public void Delete_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) 127, KeyCodes.Delete);
        }
        
        /// <summary>
        /// Tests that end should be correct value
        /// </summary>
        [Fact]
        public void End_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeEnd | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.End);
        }
        
        /// <summary>
        /// Tests that pagedown should be correct value
        /// </summary>
        [Fact]
        public void Pagedown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodePagedown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Pagedown);
        }
        
        /// <summary>
        /// Tests that right should be correct value
        /// </summary>
        [Fact]
        public void Right_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeRight | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Right);
        }
        
        /// <summary>
        /// Tests that left should be correct value
        /// </summary>
        [Fact]
        public void Left_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeLeft | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Left);
        }
        
        /// <summary>
        /// Tests that down should be correct value
        /// </summary>
        [Fact]
        public void Down_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeDown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Down);
        }
        
        /// <summary>
        /// Tests that up should be correct value
        /// </summary>
        [Fact]
        public void Up_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeUp | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Up);
        }
        
        /// <summary>
        /// Tests that numlockclear should be correct value
        /// </summary>
        [Fact]
        public void Numlockclear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeNumlockclear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Numlockclear);
        }
        
        /// <summary>
        /// Tests that kp divide should be correct value
        /// </summary>
        [Fact]
        public void KpDivide_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpDivide | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpDivide);
        }
        
        /// <summary>
        /// Tests that kp multiply should be correct value
        /// </summary>
        [Fact]
        public void KpMultiply_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMultiply | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMultiply);
        }
        
        /// <summary>
        /// Tests that kp minus should be correct value
        /// </summary>
        [Fact]
        public void KpMinus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMinus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMinus);
        }
        
        /// <summary>
        /// Tests that kp plus should be correct value
        /// </summary>
        [Fact]
        public void KpPlus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpPlus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpPlus);
        }
        
        /// <summary>
        /// Tests that kp enter should be correct value
        /// </summary>
        [Fact]
        public void KpEnter_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpEnter | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpEnter);
        }
        
        /// <summary>
        /// Tests that kp 1 should be correct value
        /// </summary>
        [Fact]
        public void Kp1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp1);
        }
        
        /// <summary>
        /// Tests that kp 2 should be correct value
        /// </summary>
        [Fact]
        public void Kp2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp2);
        }
        
        /// <summary>
        /// Tests that kp 3 should be correct value
        /// </summary>
        [Fact]
        public void Kp3_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp3 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp3);
        }
        
        /// <summary>
        /// Tests that kp 4 should be correct value
        /// </summary>
        [Fact]
        public void Kp4_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp4 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp4);
        }
        
        /// <summary>
        /// Tests that kp 5 should be correct value
        /// </summary>
        [Fact]
        public void Kp5_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp5 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp5);
        }
        
        /// <summary>
        /// Tests that kp 6 should be correct value
        /// </summary>
        [Fact]
        public void Kp6_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp6 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp6);
        }
        
        /// <summary>
        /// Tests that kp 7 should be correct value
        /// </summary>
        [Fact]
        public void Kp7_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp7 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp7);
        }
        
        /// <summary>
        /// Tests that kp 8 should be correct value
        /// </summary>
        [Fact]
        public void Kp8_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp8 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp8);
        }
        
        /// <summary>
        /// Tests that kp 9 should be correct value
        /// </summary>
        [Fact]
        public void Kp9_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp9 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp9);
        }
        
        /// <summary>
        /// Tests that kp 0 should be correct value
        /// </summary>
        [Fact]
        public void Kp0_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKp0 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kp0);
        }
        
        /// <summary>
        /// Tests that kp period should be correct value
        /// </summary>
        [Fact]
        public void KpPeriod_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpPeriod | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpPeriod);
        }
        
        /// <summary>
        /// Tests that kbdillumup should be correct value v 2
        /// </summary>
        [Fact]
        public void Kbdillumup_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKbdillumup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Kbdillumup);
        }
        
        /// <summary>
        /// Tests that eject should be correct value v 2
        /// </summary>
        [Fact]
        public void Eject_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeEject | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Eject);
        }
        
        /// <summary>
        /// Tests that sleep should be correct value v 2
        /// </summary>
        [Fact]
        public void Sleep_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeSleep | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Sleep);
        }
        
        /// <summary>
        /// Tests that app 1 should be correct value v 2
        /// </summary>
        [Fact]
        public void App1_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeApp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.App1);
        }
        
        /// <summary>
        /// Tests that app 2 should be correct value v 2
        /// </summary>
        [Fact]
        public void App2_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeApp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.App2);
        }
        
        /// <summary>
        /// Tests that audiorewind should be correct value v 2
        /// </summary>
        [Fact]
        public void Audiorewind_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiorewind | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiorewind);
        }
        
        /// <summary>
        /// Tests that audiofastforward should be correct value v 2
        /// </summary>
        [Fact]
        public void Audiofastforward_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeAudiofastforward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Audiofastforward);
        }
        
        /// <summary>
        /// Tests that thousandsseparator should be correct value
        /// </summary>
        [Fact]
        public void Thousandsseparator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeThousandsseparator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Thousandsseparator);
        }
        
        /// <summary>
        /// Tests that decimalseparator should be correct value
        /// </summary>
        [Fact]
        public void Decimalseparator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeDecimalseparator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Decimalseparator);
        }
        
        /// <summary>
        /// Tests that currencyunit should be correct value
        /// </summary>
        [Fact]
        public void Currencyunit_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeCurrencyunit | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Currencyunit);
        }
        
        /// <summary>
        /// Tests that currencysubunit should be correct value
        /// </summary>
        [Fact]
        public void Currencysubunit_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeCurrencysubunit | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Currencysubunit);
        }
        
        /// <summary>
        /// Tests that kp leftparen should be correct value
        /// </summary>
        [Fact]
        public void KpLeftparen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpLeftparen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpLeftparen);
        }
        
        /// <summary>
        /// Tests that kp rightparen should be correct value
        /// </summary>
        [Fact]
        public void KpRightparen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpRightparen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpRightparen);
        }
        
        /// <summary>
        /// Tests that kp leftbrace should be correct value
        /// </summary>
        [Fact]
        public void KpLeftbrace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpLeftbrace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpLeftbrace);
        }
        
        /// <summary>
        /// Tests that kp rightbrace should be correct value
        /// </summary>
        [Fact]
        public void KpRightbrace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpRightbrace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpRightbrace);
        }
        
        /// <summary>
        /// Tests that kp tab should be correct value
        /// </summary>
        [Fact]
        public void KpTab_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpTab | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpTab);
        }
        
        /// <summary>
        /// Tests that kp backspace should be correct value
        /// </summary>
        [Fact]
        public void KpBackspace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpBackspace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpBackspace);
        }
        
        /// <summary>
        /// Tests that kp a should be correct value
        /// </summary>
        [Fact]
        public void KpA_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpA | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpA);
        }
        
        /// <summary>
        /// Tests that kp b should be correct value
        /// </summary>
        [Fact]
        public void KpB_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpB | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpB);
        }
        
        /// <summary>
        /// Tests that kp c should be correct value
        /// </summary>
        [Fact]
        public void KpC_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpC | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpC);
        }
        
        /// <summary>
        /// Tests that kp d should be correct value
        /// </summary>
        [Fact]
        public void KpD_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpD | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpD);
        }
        
        /// <summary>
        /// Tests that kp e should be correct value
        /// </summary>
        [Fact]
        public void KpE_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpE | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpE);
        }
        
        /// <summary>
        /// Tests that kp f should be correct value
        /// </summary>
        [Fact]
        public void KpF_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpF | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpF);
        }
        
        /// <summary>
        /// Tests that kp xor should be correct value
        /// </summary>
        [Fact]
        public void KpXor_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpXor | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpXor);
        }
        
        /// <summary>
        /// Tests that kp power should be correct value
        /// </summary>
        [Fact]
        public void KpPower_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpPower | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpPower);
        }
        
        /// <summary>
        /// Tests that kp percent should be correct value
        /// </summary>
        [Fact]
        public void KpPercent_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpPercent | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpPercent);
        }
        
        /// <summary>
        /// Tests that kp less should be correct value
        /// </summary>
        [Fact]
        public void KpLess_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpLess | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpLess);
        }
        
        /// <summary>
        /// Tests that kp greater should be correct value
        /// </summary>
        [Fact]
        public void KpGreater_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpGreater | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpGreater);
        }
        
        /// <summary>
        /// Tests that kp ampersand should be correct value
        /// </summary>
        [Fact]
        public void KpAmpersand_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpAmpersand | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpAmpersand);
        }
        
        /// <summary>
        /// Tests that kp dblampersand should be correct value
        /// </summary>
        [Fact]
        public void KpDblampersand_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpDblampersand | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpDblampersand);
        }
        
        /// <summary>
        /// Tests that kp verticalbar should be correct value
        /// </summary>
        [Fact]
        public void KpVerticalbar_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpVerticalbar | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpVerticalbar);
        }
        
        /// <summary>
        /// Tests that kp dblverticalbar should be correct value
        /// </summary>
        [Fact]
        public void KpDblverticalbar_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpDblverticalbar | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpDblverticalbar);
        }
        
        /// <summary>
        /// Tests that kp colon should be correct value
        /// </summary>
        [Fact]
        public void KpColon_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpColon | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpColon);
        }
        
        /// <summary>
        /// Tests that kp hash should be correct value
        /// </summary>
        [Fact]
        public void KpHash_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpHash | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpHash);
        }
        
        /// <summary>
        /// Tests that kp space should be correct value
        /// </summary>
        [Fact]
        public void KpSpace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpSpace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpSpace);
        }
        
        /// <summary>
        /// Tests that kp at should be correct value
        /// </summary>
        [Fact]
        public void KpAt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpAt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpAt);
        }
        
        /// <summary>
        /// Tests that kp exclam should be correct value
        /// </summary>
        [Fact]
        public void KpExclam_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpExclam | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpExclam);
        }
        
        /// <summary>
        /// Tests that kp memstore should be correct value
        /// </summary>
        [Fact]
        public void KpMemstore_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemstore | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemstore);
        }
        
        /// <summary>
        /// Tests that kp memrecall should be correct value
        /// </summary>
        [Fact]
        public void KpMemrecall_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemrecall | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemrecall);
        }
        
        /// <summary>
        /// Tests that kp memclear should be correct value
        /// </summary>
        [Fact]
        public void KpMemclear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemclear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemclear);
        }
        
        /// <summary>
        /// Tests that kp memadd should be correct value
        /// </summary>
        [Fact]
        public void KpMemadd_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemadd | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemadd);
        }
        
        /// <summary>
        /// Tests that kp memsubtract should be correct value
        /// </summary>
        [Fact]
        public void KpMemsubtract_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemsubtract | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemsubtract);
        }
        
        /// <summary>
        /// Tests that kp memmultiply should be correct value
        /// </summary>
        [Fact]
        public void KpMemmultiply_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemmultiply | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemmultiply);
        }
        
        /// <summary>
        /// Tests that kp memdivide should be correct value
        /// </summary>
        [Fact]
        public void KpMemdivide_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpMemdivide | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpMemdivide);
        }
        
        /// <summary>
        /// Tests that kp plusminus should be correct value
        /// </summary>
        [Fact]
        public void KpPlusminus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpPlusminus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpPlusminus);
        }
        
        /// <summary>
        /// Tests that kp clear should be correct value
        /// </summary>
        [Fact]
        public void KpClear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpClear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpClear);
        }
        
        /// <summary>
        /// Tests that kp clearentry should be correct value
        /// </summary>
        [Fact]
        public void KpClearentry_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpClearentry | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpClearentry);
        }
        
        /// <summary>
        /// Tests that kp binary should be correct value
        /// </summary>
        [Fact]
        public void KpBinary_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpBinary | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpBinary);
        }
        
        /// <summary>
        /// Tests that kp octal should be correct value
        /// </summary>
        [Fact]
        public void KpOctal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpOctal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpOctal);
        }
        
        /// <summary>
        /// Tests that kp decimal should be correct value
        /// </summary>
        [Fact]
        public void KpDecimal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpDecimal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpDecimal);
        }
        
        /// <summary>
        /// Tests that kp hexadecimal should be correct value
        /// </summary>
        [Fact]
        public void KpHexadecimal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeKpHexadecimal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.KpHexadecimal);
        }
        
        /// <summary>
        /// Tests that lctrl should be correct value
        /// </summary>
        [Fact]
        public void Lctrl_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeLctrl | (SdlScancode) SdlInputConst.KScancodeMask), KeyCodes.Lctrl);
        }
        
        /// <summary>
        /// Tests that cancel should be correct value
        /// </summary>
        [Fact]
        public void Cancel_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeCancel | (SdlScancode)SdlInputConst.KScancodeMask), KeyCodes.Cancel);
        }
        
        /// <summary>
        /// Tests that clear should be correct value
        /// </summary>
        [Fact]
        public void Clear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeClear | (SdlScancode)SdlInputConst.KScancodeMask), KeyCodes.Clear);
        }
        
        /// <summary>
        /// Tests that prior should be correct value
        /// </summary>
        [Fact]
        public void Prior_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodePrior | (SdlScancode)SdlInputConst.KScancodeMask), KeyCodes.Prior);
        }
        
        /// <summary>
        /// Tests that return 2 should be correct value
        /// </summary>
        [Fact]
        public void Return2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeReturn2 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCodes.Return2);
        }
        
        /// <summary>
        /// Tests that separator should be correct value
        /// </summary>
        [Fact]
        public void Separator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCodes) (SdlScancode.SdlScancodeSeparator | (SdlScancode)SdlInputConst.KScancodeMask), KeyCodes.Separator);
        }
        
    }
}