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
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeCapslock | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Capslock);
        }
        
        /// <summary>
        /// Tests that f 1 should be correct value
        /// </summary>
        [Fact]
        public void F1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F1);
        }
        
        /// <summary>
        /// Tests that f 2 should be correct value
        /// </summary>
        [Fact]
        public void F2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F2);
        }
        
        /// <summary>
        /// Tests that f 3 should be correct value
        /// </summary>
        [Fact]
        public void F3_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF3 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F3);
        }
        
        /// <summary>
        /// Tests that f 4 should be correct value
        /// </summary>
        [Fact]
        public void F4_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF4 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F4);
        }
        
        /// <summary>
        /// Tests that f 5 should be correct value
        /// </summary>
        [Fact]
        public void F5_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF5 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F5);
        }
        
        /// <summary>
        /// Tests that f 6 should be correct value
        /// </summary>
        [Fact]
        public void F6_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF6 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F6);
        }
        
        /// <summary>
        /// Tests that f 7 should be correct value
        /// </summary>
        [Fact]
        public void F7_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF7 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F7);
        }
        
        /// <summary>
        /// Tests that f 8 should be correct value
        /// </summary>
        [Fact]
        public void F8_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF8 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F8);
        }
        
        /// <summary>
        /// Tests that f 9 should be correct value
        /// </summary>
        [Fact]
        public void F9_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF9 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F9);
        }
        
        /// <summary>
        /// Tests that f 10 should be correct value
        /// </summary>
        [Fact]
        public void F10_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF10 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F10);
        }
        
        /// <summary>
        /// Tests that f 11 should be correct value
        /// </summary>
        [Fact]
        public void F11_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF11 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F11);
        }
        
        /// <summary>
        /// Tests that f 12 should be correct value
        /// </summary>
        [Fact]
        public void F12_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeF12 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.F12);
        }
        
        /// <summary>
        /// Tests that printscreen should be correct value
        /// </summary>
        [Fact]
        public void Printscreen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePrintscreen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Printscreen);
        }
        
        /// <summary>
        /// Tests that scrolllock should be correct value
        /// </summary>
        [Fact]
        public void Scrolllock_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeScrolllock | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Scrolllock);
        }
        
        /// <summary>
        /// Tests that pause should be correct value
        /// </summary>
        [Fact]
        public void Pause_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePause | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Pause);
        }
        
        /// <summary>
        /// Tests that insert should be correct value
        /// </summary>
        [Fact]
        public void Insert_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeInsert | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Insert);
        }
        
        /// <summary>
        /// Tests that home should be correct value
        /// </summary>
        [Fact]
        public void Home_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeHome | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Home);
        }
        
        /// <summary>
        /// Tests that pageup should be correct value
        /// </summary>
        [Fact]
        public void Pageup_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePageup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Pageup);
        }
        
        /// <summary>
        /// Tests that delete should be correct value
        /// </summary>
        [Fact]
        public void Delete_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) 127, KeyCode.Delete);
        }
        
        /// <summary>
        /// Tests that end should be correct value
        /// </summary>
        [Fact]
        public void End_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeEnd | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.End);
        }
        
        /// <summary>
        /// Tests that pagedown should be correct value
        /// </summary>
        [Fact]
        public void Pagedown_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePagedown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Pagedown);
        }
        
        /// <summary>
        /// Tests that right should be correct value
        /// </summary>
        [Fact]
        public void Right_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeRight | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Right);
        }
        
        /// <summary>
        /// Tests that left should be correct value
        /// </summary>
        [Fact]
        public void Left_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeLeft | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Left);
        }
        
        /// <summary>
        /// Tests that down should be correct value
        /// </summary>
        [Fact]
        public void Down_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeDown | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Down);
        }
        
        /// <summary>
        /// Tests that up should be correct value
        /// </summary>
        [Fact]
        public void Up_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeUp | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Up);
        }
        
        /// <summary>
        /// Tests that numlockclear should be correct value
        /// </summary>
        [Fact]
        public void Numlockclear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeNumlockclear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Numlockclear);
        }
        
        /// <summary>
        /// Tests that kp divide should be correct value
        /// </summary>
        [Fact]
        public void KpDivide_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpDivide | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpDivide);
        }
        
        /// <summary>
        /// Tests that kp multiply should be correct value
        /// </summary>
        [Fact]
        public void KpMultiply_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMultiply | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMultiply);
        }
        
        /// <summary>
        /// Tests that kp minus should be correct value
        /// </summary>
        [Fact]
        public void KpMinus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMinus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMinus);
        }
        
        /// <summary>
        /// Tests that kp plus should be correct value
        /// </summary>
        [Fact]
        public void KpPlus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpPlus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpPlus);
        }
        
        /// <summary>
        /// Tests that kp enter should be correct value
        /// </summary>
        [Fact]
        public void KpEnter_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpEnter | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpEnter);
        }
        
        /// <summary>
        /// Tests that kp 1 should be correct value
        /// </summary>
        [Fact]
        public void Kp1_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp1);
        }
        
        /// <summary>
        /// Tests that kp 2 should be correct value
        /// </summary>
        [Fact]
        public void Kp2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp2);
        }
        
        /// <summary>
        /// Tests that kp 3 should be correct value
        /// </summary>
        [Fact]
        public void Kp3_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp3 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp3);
        }
        
        /// <summary>
        /// Tests that kp 4 should be correct value
        /// </summary>
        [Fact]
        public void Kp4_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp4 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp4);
        }
        
        /// <summary>
        /// Tests that kp 5 should be correct value
        /// </summary>
        [Fact]
        public void Kp5_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp5 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp5);
        }
        
        /// <summary>
        /// Tests that kp 6 should be correct value
        /// </summary>
        [Fact]
        public void Kp6_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp6 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp6);
        }
        
        /// <summary>
        /// Tests that kp 7 should be correct value
        /// </summary>
        [Fact]
        public void Kp7_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp7 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp7);
        }
        
        /// <summary>
        /// Tests that kp 8 should be correct value
        /// </summary>
        [Fact]
        public void Kp8_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp8 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp8);
        }
        
        /// <summary>
        /// Tests that kp 9 should be correct value
        /// </summary>
        [Fact]
        public void Kp9_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp9 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp9);
        }
        
        /// <summary>
        /// Tests that kp 0 should be correct value
        /// </summary>
        [Fact]
        public void Kp0_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKp0 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kp0);
        }
        
        /// <summary>
        /// Tests that kp period should be correct value
        /// </summary>
        [Fact]
        public void KpPeriod_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpPeriod | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpPeriod);
        }
        
        /// <summary>
        /// Tests that kbdillumup should be correct value v 2
        /// </summary>
        [Fact]
        public void Kbdillumup_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKbdillumup | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Kbdillumup);
        }
        
        /// <summary>
        /// Tests that eject should be correct value v 2
        /// </summary>
        [Fact]
        public void Eject_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeEject | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Eject);
        }
        
        /// <summary>
        /// Tests that sleep should be correct value v 2
        /// </summary>
        [Fact]
        public void Sleep_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeSleep | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Sleep);
        }
        
        /// <summary>
        /// Tests that app 1 should be correct value v 2
        /// </summary>
        [Fact]
        public void App1_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeApp1 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.App1);
        }
        
        /// <summary>
        /// Tests that app 2 should be correct value v 2
        /// </summary>
        [Fact]
        public void App2_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeApp2 | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.App2);
        }
        
        /// <summary>
        /// Tests that audiorewind should be correct value v 2
        /// </summary>
        [Fact]
        public void Audiorewind_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiorewind | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiorewind);
        }
        
        /// <summary>
        /// Tests that audiofastforward should be correct value v 2
        /// </summary>
        [Fact]
        public void Audiofastforward_ShouldBeCorrectValue_v2()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeAudiofastforward | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Audiofastforward);
        }
        
        /// <summary>
        /// Tests that thousandsseparator should be correct value
        /// </summary>
        [Fact]
        public void Thousandsseparator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeThousandsseparator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Thousandsseparator);
        }
        
        /// <summary>
        /// Tests that decimalseparator should be correct value
        /// </summary>
        [Fact]
        public void Decimalseparator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeDecimalseparator | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Decimalseparator);
        }
        
        /// <summary>
        /// Tests that currencyunit should be correct value
        /// </summary>
        [Fact]
        public void Currencyunit_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeCurrencyunit | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Currencyunit);
        }
        
        /// <summary>
        /// Tests that currencysubunit should be correct value
        /// </summary>
        [Fact]
        public void Currencysubunit_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeCurrencysubunit | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Currencysubunit);
        }
        
        /// <summary>
        /// Tests that kp leftparen should be correct value
        /// </summary>
        [Fact]
        public void KpLeftparen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpLeftparen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpLeftparen);
        }
        
        /// <summary>
        /// Tests that kp rightparen should be correct value
        /// </summary>
        [Fact]
        public void KpRightparen_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpRightparen | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpRightparen);
        }
        
        /// <summary>
        /// Tests that kp leftbrace should be correct value
        /// </summary>
        [Fact]
        public void KpLeftbrace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpLeftbrace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpLeftbrace);
        }
        
        /// <summary>
        /// Tests that kp rightbrace should be correct value
        /// </summary>
        [Fact]
        public void KpRightbrace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpRightbrace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpRightbrace);
        }
        
        /// <summary>
        /// Tests that kp tab should be correct value
        /// </summary>
        [Fact]
        public void KpTab_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpTab | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpTab);
        }
        
        /// <summary>
        /// Tests that kp backspace should be correct value
        /// </summary>
        [Fact]
        public void KpBackspace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpBackspace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpBackspace);
        }
        
        /// <summary>
        /// Tests that kp a should be correct value
        /// </summary>
        [Fact]
        public void KpA_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpA | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpA);
        }
        
        /// <summary>
        /// Tests that kp b should be correct value
        /// </summary>
        [Fact]
        public void KpB_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpB | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpB);
        }
        
        /// <summary>
        /// Tests that kp c should be correct value
        /// </summary>
        [Fact]
        public void KpC_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpC | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpC);
        }
        
        /// <summary>
        /// Tests that kp d should be correct value
        /// </summary>
        [Fact]
        public void KpD_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpD | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpD);
        }
        
        /// <summary>
        /// Tests that kp e should be correct value
        /// </summary>
        [Fact]
        public void KpE_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpE | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpE);
        }
        
        /// <summary>
        /// Tests that kp f should be correct value
        /// </summary>
        [Fact]
        public void KpF_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpF | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpF);
        }
        
        /// <summary>
        /// Tests that kp xor should be correct value
        /// </summary>
        [Fact]
        public void KpXor_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpXor | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpXor);
        }
        
        /// <summary>
        /// Tests that kp power should be correct value
        /// </summary>
        [Fact]
        public void KpPower_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpPower | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpPower);
        }
        
        /// <summary>
        /// Tests that kp percent should be correct value
        /// </summary>
        [Fact]
        public void KpPercent_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpPercent | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpPercent);
        }
        
        /// <summary>
        /// Tests that kp less should be correct value
        /// </summary>
        [Fact]
        public void KpLess_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpLess | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpLess);
        }
        
        /// <summary>
        /// Tests that kp greater should be correct value
        /// </summary>
        [Fact]
        public void KpGreater_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpGreater | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpGreater);
        }
        
        /// <summary>
        /// Tests that kp ampersand should be correct value
        /// </summary>
        [Fact]
        public void KpAmpersand_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpAmpersand | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpAmpersand);
        }
        
        /// <summary>
        /// Tests that kp dblampersand should be correct value
        /// </summary>
        [Fact]
        public void KpDblampersand_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpDblampersand | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpDblampersand);
        }
        
        /// <summary>
        /// Tests that kp verticalbar should be correct value
        /// </summary>
        [Fact]
        public void KpVerticalbar_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpVerticalbar | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpVerticalbar);
        }
        
        /// <summary>
        /// Tests that kp dblverticalbar should be correct value
        /// </summary>
        [Fact]
        public void KpDblverticalbar_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpDblverticalbar | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpDblverticalbar);
        }
        
        /// <summary>
        /// Tests that kp colon should be correct value
        /// </summary>
        [Fact]
        public void KpColon_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpColon | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpColon);
        }
        
        /// <summary>
        /// Tests that kp hash should be correct value
        /// </summary>
        [Fact]
        public void KpHash_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpHash | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpHash);
        }
        
        /// <summary>
        /// Tests that kp space should be correct value
        /// </summary>
        [Fact]
        public void KpSpace_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpSpace | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpSpace);
        }
        
        /// <summary>
        /// Tests that kp at should be correct value
        /// </summary>
        [Fact]
        public void KpAt_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpAt | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpAt);
        }
        
        /// <summary>
        /// Tests that kp exclam should be correct value
        /// </summary>
        [Fact]
        public void KpExclam_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpExclam | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpExclam);
        }
        
        /// <summary>
        /// Tests that kp memstore should be correct value
        /// </summary>
        [Fact]
        public void KpMemstore_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemstore | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemstore);
        }
        
        /// <summary>
        /// Tests that kp memrecall should be correct value
        /// </summary>
        [Fact]
        public void KpMemrecall_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemrecall | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemrecall);
        }
        
        /// <summary>
        /// Tests that kp memclear should be correct value
        /// </summary>
        [Fact]
        public void KpMemclear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemclear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemclear);
        }
        
        /// <summary>
        /// Tests that kp memadd should be correct value
        /// </summary>
        [Fact]
        public void KpMemadd_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemadd | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemadd);
        }
        
        /// <summary>
        /// Tests that kp memsubtract should be correct value
        /// </summary>
        [Fact]
        public void KpMemsubtract_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemsubtract | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemsubtract);
        }
        
        /// <summary>
        /// Tests that kp memmultiply should be correct value
        /// </summary>
        [Fact]
        public void KpMemmultiply_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemmultiply | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemmultiply);
        }
        
        /// <summary>
        /// Tests that kp memdivide should be correct value
        /// </summary>
        [Fact]
        public void KpMemdivide_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpMemdivide | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpMemdivide);
        }
        
        /// <summary>
        /// Tests that kp plusminus should be correct value
        /// </summary>
        [Fact]
        public void KpPlusminus_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpPlusminus | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpPlusminus);
        }
        
        /// <summary>
        /// Tests that kp clear should be correct value
        /// </summary>
        [Fact]
        public void KpClear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpClear | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpClear);
        }
        
        /// <summary>
        /// Tests that kp clearentry should be correct value
        /// </summary>
        [Fact]
        public void KpClearentry_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpClearentry | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpClearentry);
        }
        
        /// <summary>
        /// Tests that kp binary should be correct value
        /// </summary>
        [Fact]
        public void KpBinary_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpBinary | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpBinary);
        }
        
        /// <summary>
        /// Tests that kp octal should be correct value
        /// </summary>
        [Fact]
        public void KpOctal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpOctal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpOctal);
        }
        
        /// <summary>
        /// Tests that kp decimal should be correct value
        /// </summary>
        [Fact]
        public void KpDecimal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpDecimal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpDecimal);
        }
        
        /// <summary>
        /// Tests that kp hexadecimal should be correct value
        /// </summary>
        [Fact]
        public void KpHexadecimal_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeKpHexadecimal | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.KpHexadecimal);
        }
        
        /// <summary>
        /// Tests that lctrl should be correct value
        /// </summary>
        [Fact]
        public void Lctrl_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeLctrl | (SdlScancode) SdlInputConst.KScancodeMask), KeyCode.Lctrl);
        }
        
        /// <summary>
        /// Tests that cancel should be correct value
        /// </summary>
        [Fact]
        public void Cancel_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeCancel | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Cancel);
        }
        
        /// <summary>
        /// Tests that clear should be correct value
        /// </summary>
        [Fact]
        public void Clear_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeClear | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Clear);
        }
        
        /// <summary>
        /// Tests that prior should be correct value
        /// </summary>
        [Fact]
        public void Prior_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodePrior | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Prior);
        }
        
        /// <summary>
        /// Tests that return 2 should be correct value
        /// </summary>
        [Fact]
        public void Return2_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeReturn2 | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Return2);
        }
        
        /// <summary>
        /// Tests that separator should be correct value
        /// </summary>
        [Fact]
        public void Separator_ShouldBeCorrectValue()
        {
            Assert.Equal((KeyCode) (SdlScancode.SdlScancodeSeparator | (SdlScancode)SdlInputConst.KScancodeMask), KeyCode.Separator);
        }
        
    }
}