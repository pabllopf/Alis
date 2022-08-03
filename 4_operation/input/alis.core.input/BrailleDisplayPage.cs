// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BrailleDisplayPage.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.ComponentModel;

namespace DevDecoder.HIDDevices.Usages
{
#pragma warning disable CS0108
    /// <summary>
    ///     Braille Display Usage Page.
    /// </summary>
    [Description("Braille Display Usage Page")]
    public enum BrailleDisplayPage : uint
    {
        /// <summary>
        ///     Undefined Usage.
        /// </summary>
        [Description("Undefined")]
        Undefined = 0x00410000,

        /// <summary>
        ///     Braille Display Usage.
        /// </summary>
        [Description("Braille Display")]
        BrailleDisplay = 0x00410001,

        /// <summary>
        ///     Braille Row Usage.
        /// </summary>
        [Description("Braille Row")]
        BrailleRow = 0x00410002,

        /// <summary>
        ///     8 Dot Braille Cell Usage.
        /// </summary>
        [Description("8 Dot Braille Cell")]
        DotBrailleCell = 0x00410003,

        /// <summary>
        ///     6 Dot Braille Cell Usage.
        /// </summary>
        [Description("6 Dot Braille Cell")]
        DotBrailleCell2 = 0x00410004,

        /// <summary>
        ///     Number of Braille Cells Usage.
        /// </summary>
        [Description("Number of Braille Cells")]
        NumberOfBrailleCells = 0x00410005,

        /// <summary>
        ///     Screen Reader Control Usage.
        /// </summary>
        [Description("Screen Reader Control")]
        ScreenReaderControl = 0x00410006,

        /// <summary>
        ///     Screen Reader Identifier Usage.
        /// </summary>
        [Description("Screen Reader Identifier")]
        ScreenReaderIdentifier = 0x00410007,

        /*
         * Range: 0x00fa -> 0x00fc
         * Router Set {n+1}
         */

        /// <summary>
        ///     Router Set 1 Usage.
        /// </summary>
        [Description("Router Set 1")]
        RouterSet1 = 0x004100fa,

        /// <summary>
        ///     Router Set 2 Usage.
        /// </summary>
        [Description("Router Set 2")]
        RouterSet2 = 0x004100fb,

        /// <summary>
        ///     Router Set 3 Usage.
        /// </summary>
        [Description("Router Set 3")]
        RouterSet3 = 0x004100fc,

        /// <summary>
        ///     Braille Buttons Usage.
        /// </summary>
        [Description("Braille Buttons")]
        BrailleButtons = 0x00410100,

        /*
         * Range: 0x0201 -> 0x0208
         * Braille Keyboard Dot {n+1}
         */

        /// <summary>
        ///     Braille Keyboard Dot 1 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 1")]
        BrailleKeyboardDot1 = 0x00410201,

        /// <summary>
        ///     Braille Keyboard Dot 2 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 2")]
        BrailleKeyboardDot2 = 0x00410202,

        /// <summary>
        ///     Braille Keyboard Dot 3 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 3")]
        BrailleKeyboardDot3 = 0x00410203,

        /// <summary>
        ///     Braille Keyboard Dot 4 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 4")]
        BrailleKeyboardDot4 = 0x00410204,

        /// <summary>
        ///     Braille Keyboard Dot 5 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 5")]
        BrailleKeyboardDot5 = 0x00410205,

        /// <summary>
        ///     Braille Keyboard Dot 6 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 6")]
        BrailleKeyboardDot6 = 0x00410206,

        /// <summary>
        ///     Braille Keyboard Dot 7 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 7")]
        BrailleKeyboardDot7 = 0x00410207,

        /// <summary>
        ///     Braille Keyboard Dot 8 Usage.
        /// </summary>
        [Description("Braille Keyboard Dot 8")]
        BrailleKeyboardDot8 = 0x00410208,

        /// <summary>
        ///     Braille Keyboard Space Usage.
        /// </summary>
        [Description("Braille Keyboard Space")]
        BrailleKeyboardSpace = 0x00410209,

        /// <summary>
        ///     Braille Keyboard Left Space Usage.
        /// </summary>
        [Description("Braille Keyboard Left Space")]
        BrailleKeyboardLeftSpace = 0x0041020a,

        /// <summary>
        ///     Braille Keyboard Right Space Usage.
        /// </summary>
        [Description("Braille Keyboard Right Space")]
        BrailleKeyboardRightSpace = 0x0041020b,

        /// <summary>
        ///     Braille Face Controls Usage.
        /// </summary>
        [Description("Braille Face Controls")]
        BrailleFaceControls = 0x0041020c,

        /// <summary>
        ///     Braille Left Controls Usage.
        /// </summary>
        [Description("Braille Left Controls")]
        BrailleLeftControls = 0x0041020d,

        /// <summary>
        ///     Braille Right Controls Usage.
        /// </summary>
        [Description("Braille Right Controls")]
        BrailleRightControls = 0x0041020e,

        /// <summary>
        ///     Braille Top Controls Usage.
        /// </summary>
        [Description("Braille Top Controls")]
        BrailleTopControls = 0x0041020f,

        /// <summary>
        ///     Braille Joystick Center Usage.
        /// </summary>
        [Description("Braille Joystick Center")]
        BrailleJoystickCenter = 0x00410210,

        /// <summary>
        ///     Braille Joystick Up Usage.
        /// </summary>
        [Description("Braille Joystick Up")]
        BrailleJoystickUp = 0x00410211,

        /// <summary>
        ///     Braille Joystick Down Usage.
        /// </summary>
        [Description("Braille Joystick Down")]
        BrailleJoystickDown = 0x00410212,

        /// <summary>
        ///     Braille Joystick Left Usage.
        /// </summary>
        [Description("Braille Joystick Left")]
        BrailleJoystickLeft = 0x00410213,

        /// <summary>
        ///     Braille Joystick Right Usage.
        /// </summary>
        [Description("Braille Joystick Right")]
        BrailleJoystickRight = 0x00410214,

        /// <summary>
        ///     Braille D-pad Center Usage.
        /// </summary>
        [Description("Braille D-pad Center")]
        BrailleDpadCenter = 0x00410215,

        /// <summary>
        ///     Braille D-pad Up Usage.
        /// </summary>
        [Description("Braille D-pad Up")]
        BrailleDpadUp = 0x00410216,

        /// <summary>
        ///     Braille D-pad Down Usage.
        /// </summary>
        [Description("Braille D-pad Down")]
        BrailleDpadDown = 0x00410217,

        /// <summary>
        ///     Braille D-pad Left Usage.
        /// </summary>
        [Description("Braille D-pad Left")]
        BrailleDpadLeft = 0x00410218,

        /// <summary>
        ///     Braille D-pad Right Usage.
        /// </summary>
        [Description("Braille D-pad Right")]
        BrailleDpadRight = 0x00410219,

        /// <summary>
        ///     Braille Pan Left Usage.
        /// </summary>
        [Description("Braille Pan Left")]
        BraillePanLeft = 0x0041021a,

        /// <summary>
        ///     Braille Pan Right Usage.
        /// </summary>
        [Description("Braille Pan Right")]
        BraillePanRight = 0x0041021b,

        /// <summary>
        ///     Braille Rocker Up Usage.
        /// </summary>
        [Description("Braille Rocker Up")]
        BrailleRockerUp = 0x0041021c,

        /// <summary>
        ///     Braille Rocker Down Usage.
        /// </summary>
        [Description("Braille Rocker Down")]
        BrailleRockerDown = 0x0041021d,

        /// <summary>
        ///     Braille Rocker Press Usage.
        /// </summary>
        [Description("Braille Rocker Press")]
        BrailleRockerPress = 0x0041021e
    }
}