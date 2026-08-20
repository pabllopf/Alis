// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIoKeysDataCoverageTests.cs
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

using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui io keys data coverage tests class
    /// </summary>
    public class ImGuiIoKeysDataCoverageTests
    {
        /// <summary>
        ///     Tests that keys data 2 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData2_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 1.0f, DownDurationPrev = 0.5f, AnalogValue = 0.75f };
            io.KeysData2 = value;
            Assert.Equal((byte)1, io.KeysData2.Down);
            Assert.Equal(1.0f, io.KeysData2.DownDuration, 5);
            Assert.Equal(0.5f, io.KeysData2.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData2.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 3 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData3_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 1.5f, DownDurationPrev = 0.75f, AnalogValue = 0.75f };
            io.KeysData3 = value;
            Assert.Equal((byte)1, io.KeysData3.Down);
            Assert.Equal(1.5f, io.KeysData3.DownDuration, 5);
            Assert.Equal(0.75f, io.KeysData3.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData3.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 4 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData4_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 2.0f, DownDurationPrev = 1.0f, AnalogValue = 0.75f };
            io.KeysData4 = value;
            Assert.Equal((byte)1, io.KeysData4.Down);
            Assert.Equal(2.0f, io.KeysData4.DownDuration, 5);
            Assert.Equal(1.0f, io.KeysData4.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData4.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 5 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData5_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 2.5f, DownDurationPrev = 1.25f, AnalogValue = 0.75f };
            io.KeysData5 = value;
            Assert.Equal((byte)1, io.KeysData5.Down);
            Assert.Equal(2.5f, io.KeysData5.DownDuration, 5);
            Assert.Equal(1.25f, io.KeysData5.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData5.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 6 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData6_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 3.0f, DownDurationPrev = 1.5f, AnalogValue = 0.75f };
            io.KeysData6 = value;
            Assert.Equal((byte)1, io.KeysData6.Down);
            Assert.Equal(3.0f, io.KeysData6.DownDuration, 5);
            Assert.Equal(1.5f, io.KeysData6.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData6.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 7 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData7_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 3.5f, DownDurationPrev = 1.75f, AnalogValue = 0.75f };
            io.KeysData7 = value;
            Assert.Equal((byte)1, io.KeysData7.Down);
            Assert.Equal(3.5f, io.KeysData7.DownDuration, 5);
            Assert.Equal(1.75f, io.KeysData7.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData7.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 8 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData8_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 4.0f, DownDurationPrev = 2.0f, AnalogValue = 0.75f };
            io.KeysData8 = value;
            Assert.Equal((byte)1, io.KeysData8.Down);
            Assert.Equal(4.0f, io.KeysData8.DownDuration, 5);
            Assert.Equal(2.0f, io.KeysData8.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData8.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 9 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData9_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 4.5f, DownDurationPrev = 2.25f, AnalogValue = 0.75f };
            io.KeysData9 = value;
            Assert.Equal((byte)1, io.KeysData9.Down);
            Assert.Equal(4.5f, io.KeysData9.DownDuration, 5);
            Assert.Equal(2.25f, io.KeysData9.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData9.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 10 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData10_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 5.0f, DownDurationPrev = 2.5f, AnalogValue = 0.75f };
            io.KeysData10 = value;
            Assert.Equal((byte)1, io.KeysData10.Down);
            Assert.Equal(5.0f, io.KeysData10.DownDuration, 5);
            Assert.Equal(2.5f, io.KeysData10.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData10.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 11 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData11_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 5.5f, DownDurationPrev = 2.75f, AnalogValue = 0.75f };
            io.KeysData11 = value;
            Assert.Equal((byte)1, io.KeysData11.Down);
            Assert.Equal(5.5f, io.KeysData11.DownDuration, 5);
            Assert.Equal(2.75f, io.KeysData11.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData11.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 12 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData12_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 6.0f, DownDurationPrev = 3.0f, AnalogValue = 0.75f };
            io.KeysData12 = value;
            Assert.Equal((byte)1, io.KeysData12.Down);
            Assert.Equal(6.0f, io.KeysData12.DownDuration, 5);
            Assert.Equal(3.0f, io.KeysData12.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData12.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 13 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData13_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 6.5f, DownDurationPrev = 3.25f, AnalogValue = 0.75f };
            io.KeysData13 = value;
            Assert.Equal((byte)1, io.KeysData13.Down);
            Assert.Equal(6.5f, io.KeysData13.DownDuration, 5);
            Assert.Equal(3.25f, io.KeysData13.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData13.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 14 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData14_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 7.0f, DownDurationPrev = 3.5f, AnalogValue = 0.75f };
            io.KeysData14 = value;
            Assert.Equal((byte)1, io.KeysData14.Down);
            Assert.Equal(7.0f, io.KeysData14.DownDuration, 5);
            Assert.Equal(3.5f, io.KeysData14.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData14.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 15 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData15_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 7.5f, DownDurationPrev = 3.75f, AnalogValue = 0.75f };
            io.KeysData15 = value;
            Assert.Equal((byte)1, io.KeysData15.Down);
            Assert.Equal(7.5f, io.KeysData15.DownDuration, 5);
            Assert.Equal(3.75f, io.KeysData15.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData15.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 16 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData16_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 8.0f, DownDurationPrev = 4.0f, AnalogValue = 0.75f };
            io.KeysData16 = value;
            Assert.Equal((byte)1, io.KeysData16.Down);
            Assert.Equal(8.0f, io.KeysData16.DownDuration, 5);
            Assert.Equal(4.0f, io.KeysData16.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData16.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 17 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData17_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 8.5f, DownDurationPrev = 4.25f, AnalogValue = 0.75f };
            io.KeysData17 = value;
            Assert.Equal((byte)1, io.KeysData17.Down);
            Assert.Equal(8.5f, io.KeysData17.DownDuration, 5);
            Assert.Equal(4.25f, io.KeysData17.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData17.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 18 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData18_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 9.0f, DownDurationPrev = 4.5f, AnalogValue = 0.75f };
            io.KeysData18 = value;
            Assert.Equal((byte)1, io.KeysData18.Down);
            Assert.Equal(9.0f, io.KeysData18.DownDuration, 5);
            Assert.Equal(4.5f, io.KeysData18.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData18.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 19 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData19_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 9.5f, DownDurationPrev = 4.75f, AnalogValue = 0.75f };
            io.KeysData19 = value;
            Assert.Equal((byte)1, io.KeysData19.Down);
            Assert.Equal(9.5f, io.KeysData19.DownDuration, 5);
            Assert.Equal(4.75f, io.KeysData19.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData19.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 20 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData20_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 10.0f, DownDurationPrev = 5.0f, AnalogValue = 0.75f };
            io.KeysData20 = value;
            Assert.Equal((byte)1, io.KeysData20.Down);
            Assert.Equal(10.0f, io.KeysData20.DownDuration, 5);
            Assert.Equal(5.0f, io.KeysData20.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData20.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 21 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData21_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 10.5f, DownDurationPrev = 5.25f, AnalogValue = 0.75f };
            io.KeysData21 = value;
            Assert.Equal((byte)1, io.KeysData21.Down);
            Assert.Equal(10.5f, io.KeysData21.DownDuration, 5);
            Assert.Equal(5.25f, io.KeysData21.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData21.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 22 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData22_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 11.0f, DownDurationPrev = 5.5f, AnalogValue = 0.75f };
            io.KeysData22 = value;
            Assert.Equal((byte)1, io.KeysData22.Down);
            Assert.Equal(11.0f, io.KeysData22.DownDuration, 5);
            Assert.Equal(5.5f, io.KeysData22.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData22.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 23 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData23_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 11.5f, DownDurationPrev = 5.75f, AnalogValue = 0.75f };
            io.KeysData23 = value;
            Assert.Equal((byte)1, io.KeysData23.Down);
            Assert.Equal(11.5f, io.KeysData23.DownDuration, 5);
            Assert.Equal(5.75f, io.KeysData23.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData23.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 24 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData24_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 12.0f, DownDurationPrev = 6.0f, AnalogValue = 0.75f };
            io.KeysData24 = value;
            Assert.Equal((byte)1, io.KeysData24.Down);
            Assert.Equal(12.0f, io.KeysData24.DownDuration, 5);
            Assert.Equal(6.0f, io.KeysData24.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData24.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 25 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData25_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 12.5f, DownDurationPrev = 6.25f, AnalogValue = 0.75f };
            io.KeysData25 = value;
            Assert.Equal((byte)1, io.KeysData25.Down);
            Assert.Equal(12.5f, io.KeysData25.DownDuration, 5);
            Assert.Equal(6.25f, io.KeysData25.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData25.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 26 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData26_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 13.0f, DownDurationPrev = 6.5f, AnalogValue = 0.75f };
            io.KeysData26 = value;
            Assert.Equal((byte)1, io.KeysData26.Down);
            Assert.Equal(13.0f, io.KeysData26.DownDuration, 5);
            Assert.Equal(6.5f, io.KeysData26.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData26.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 27 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData27_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 13.5f, DownDurationPrev = 6.75f, AnalogValue = 0.75f };
            io.KeysData27 = value;
            Assert.Equal((byte)1, io.KeysData27.Down);
            Assert.Equal(13.5f, io.KeysData27.DownDuration, 5);
            Assert.Equal(6.75f, io.KeysData27.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData27.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 28 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData28_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 14.0f, DownDurationPrev = 7.0f, AnalogValue = 0.75f };
            io.KeysData28 = value;
            Assert.Equal((byte)1, io.KeysData28.Down);
            Assert.Equal(14.0f, io.KeysData28.DownDuration, 5);
            Assert.Equal(7.0f, io.KeysData28.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData28.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 29 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData29_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 14.5f, DownDurationPrev = 7.25f, AnalogValue = 0.75f };
            io.KeysData29 = value;
            Assert.Equal((byte)1, io.KeysData29.Down);
            Assert.Equal(14.5f, io.KeysData29.DownDuration, 5);
            Assert.Equal(7.25f, io.KeysData29.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData29.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 30 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData30_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 15.0f, DownDurationPrev = 7.5f, AnalogValue = 0.75f };
            io.KeysData30 = value;
            Assert.Equal((byte)1, io.KeysData30.Down);
            Assert.Equal(15.0f, io.KeysData30.DownDuration, 5);
            Assert.Equal(7.5f, io.KeysData30.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData30.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 31 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData31_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 15.5f, DownDurationPrev = 7.75f, AnalogValue = 0.75f };
            io.KeysData31 = value;
            Assert.Equal((byte)1, io.KeysData31.Down);
            Assert.Equal(15.5f, io.KeysData31.DownDuration, 5);
            Assert.Equal(7.75f, io.KeysData31.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData31.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 32 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData32_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 16.0f, DownDurationPrev = 8.0f, AnalogValue = 0.75f };
            io.KeysData32 = value;
            Assert.Equal((byte)1, io.KeysData32.Down);
            Assert.Equal(16.0f, io.KeysData32.DownDuration, 5);
            Assert.Equal(8.0f, io.KeysData32.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData32.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 33 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData33_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 16.5f, DownDurationPrev = 8.25f, AnalogValue = 0.75f };
            io.KeysData33 = value;
            Assert.Equal((byte)1, io.KeysData33.Down);
            Assert.Equal(16.5f, io.KeysData33.DownDuration, 5);
            Assert.Equal(8.25f, io.KeysData33.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData33.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 34 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData34_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 17.0f, DownDurationPrev = 8.5f, AnalogValue = 0.75f };
            io.KeysData34 = value;
            Assert.Equal((byte)1, io.KeysData34.Down);
            Assert.Equal(17.0f, io.KeysData34.DownDuration, 5);
            Assert.Equal(8.5f, io.KeysData34.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData34.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 35 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData35_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 17.5f, DownDurationPrev = 8.75f, AnalogValue = 0.75f };
            io.KeysData35 = value;
            Assert.Equal((byte)1, io.KeysData35.Down);
            Assert.Equal(17.5f, io.KeysData35.DownDuration, 5);
            Assert.Equal(8.75f, io.KeysData35.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData35.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 36 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData36_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 18.0f, DownDurationPrev = 9.0f, AnalogValue = 0.75f };
            io.KeysData36 = value;
            Assert.Equal((byte)1, io.KeysData36.Down);
            Assert.Equal(18.0f, io.KeysData36.DownDuration, 5);
            Assert.Equal(9.0f, io.KeysData36.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData36.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 37 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData37_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 18.5f, DownDurationPrev = 9.25f, AnalogValue = 0.75f };
            io.KeysData37 = value;
            Assert.Equal((byte)1, io.KeysData37.Down);
            Assert.Equal(18.5f, io.KeysData37.DownDuration, 5);
            Assert.Equal(9.25f, io.KeysData37.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData37.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 38 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData38_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 19.0f, DownDurationPrev = 9.5f, AnalogValue = 0.75f };
            io.KeysData38 = value;
            Assert.Equal((byte)1, io.KeysData38.Down);
            Assert.Equal(19.0f, io.KeysData38.DownDuration, 5);
            Assert.Equal(9.5f, io.KeysData38.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData38.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 39 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData39_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 19.5f, DownDurationPrev = 9.75f, AnalogValue = 0.75f };
            io.KeysData39 = value;
            Assert.Equal((byte)1, io.KeysData39.Down);
            Assert.Equal(19.5f, io.KeysData39.DownDuration, 5);
            Assert.Equal(9.75f, io.KeysData39.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData39.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 40 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData40_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 20.0f, DownDurationPrev = 10.0f, AnalogValue = 0.75f };
            io.KeysData40 = value;
            Assert.Equal((byte)1, io.KeysData40.Down);
            Assert.Equal(20.0f, io.KeysData40.DownDuration, 5);
            Assert.Equal(10.0f, io.KeysData40.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData40.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 41 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData41_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 20.5f, DownDurationPrev = 10.25f, AnalogValue = 0.75f };
            io.KeysData41 = value;
            Assert.Equal((byte)1, io.KeysData41.Down);
            Assert.Equal(20.5f, io.KeysData41.DownDuration, 5);
            Assert.Equal(10.25f, io.KeysData41.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData41.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 42 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData42_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 21.0f, DownDurationPrev = 10.5f, AnalogValue = 0.75f };
            io.KeysData42 = value;
            Assert.Equal((byte)1, io.KeysData42.Down);
            Assert.Equal(21.0f, io.KeysData42.DownDuration, 5);
            Assert.Equal(10.5f, io.KeysData42.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData42.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 43 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData43_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 21.5f, DownDurationPrev = 10.75f, AnalogValue = 0.75f };
            io.KeysData43 = value;
            Assert.Equal((byte)1, io.KeysData43.Down);
            Assert.Equal(21.5f, io.KeysData43.DownDuration, 5);
            Assert.Equal(10.75f, io.KeysData43.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData43.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 44 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData44_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 22.0f, DownDurationPrev = 11.0f, AnalogValue = 0.75f };
            io.KeysData44 = value;
            Assert.Equal((byte)1, io.KeysData44.Down);
            Assert.Equal(22.0f, io.KeysData44.DownDuration, 5);
            Assert.Equal(11.0f, io.KeysData44.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData44.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 45 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData45_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 22.5f, DownDurationPrev = 11.25f, AnalogValue = 0.75f };
            io.KeysData45 = value;
            Assert.Equal((byte)1, io.KeysData45.Down);
            Assert.Equal(22.5f, io.KeysData45.DownDuration, 5);
            Assert.Equal(11.25f, io.KeysData45.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData45.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 46 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData46_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 23.0f, DownDurationPrev = 11.5f, AnalogValue = 0.75f };
            io.KeysData46 = value;
            Assert.Equal((byte)1, io.KeysData46.Down);
            Assert.Equal(23.0f, io.KeysData46.DownDuration, 5);
            Assert.Equal(11.5f, io.KeysData46.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData46.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 47 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData47_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 23.5f, DownDurationPrev = 11.75f, AnalogValue = 0.75f };
            io.KeysData47 = value;
            Assert.Equal((byte)1, io.KeysData47.Down);
            Assert.Equal(23.5f, io.KeysData47.DownDuration, 5);
            Assert.Equal(11.75f, io.KeysData47.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData47.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 48 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData48_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 24.0f, DownDurationPrev = 12.0f, AnalogValue = 0.75f };
            io.KeysData48 = value;
            Assert.Equal((byte)1, io.KeysData48.Down);
            Assert.Equal(24.0f, io.KeysData48.DownDuration, 5);
            Assert.Equal(12.0f, io.KeysData48.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData48.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 49 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData49_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 24.5f, DownDurationPrev = 12.25f, AnalogValue = 0.75f };
            io.KeysData49 = value;
            Assert.Equal((byte)1, io.KeysData49.Down);
            Assert.Equal(24.5f, io.KeysData49.DownDuration, 5);
            Assert.Equal(12.25f, io.KeysData49.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData49.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 50 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData50_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 25.0f, DownDurationPrev = 12.5f, AnalogValue = 0.75f };
            io.KeysData50 = value;
            Assert.Equal((byte)1, io.KeysData50.Down);
            Assert.Equal(25.0f, io.KeysData50.DownDuration, 5);
            Assert.Equal(12.5f, io.KeysData50.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData50.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 51 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData51_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 25.5f, DownDurationPrev = 12.75f, AnalogValue = 0.75f };
            io.KeysData51 = value;
            Assert.Equal((byte)1, io.KeysData51.Down);
            Assert.Equal(25.5f, io.KeysData51.DownDuration, 5);
            Assert.Equal(12.75f, io.KeysData51.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData51.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 52 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData52_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 26.0f, DownDurationPrev = 13.0f, AnalogValue = 0.75f };
            io.KeysData52 = value;
            Assert.Equal((byte)1, io.KeysData52.Down);
            Assert.Equal(26.0f, io.KeysData52.DownDuration, 5);
            Assert.Equal(13.0f, io.KeysData52.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData52.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 53 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData53_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 26.5f, DownDurationPrev = 13.25f, AnalogValue = 0.75f };
            io.KeysData53 = value;
            Assert.Equal((byte)1, io.KeysData53.Down);
            Assert.Equal(26.5f, io.KeysData53.DownDuration, 5);
            Assert.Equal(13.25f, io.KeysData53.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData53.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 54 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData54_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 27.0f, DownDurationPrev = 13.5f, AnalogValue = 0.75f };
            io.KeysData54 = value;
            Assert.Equal((byte)1, io.KeysData54.Down);
            Assert.Equal(27.0f, io.KeysData54.DownDuration, 5);
            Assert.Equal(13.5f, io.KeysData54.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData54.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 55 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData55_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 27.5f, DownDurationPrev = 13.75f, AnalogValue = 0.75f };
            io.KeysData55 = value;
            Assert.Equal((byte)1, io.KeysData55.Down);
            Assert.Equal(27.5f, io.KeysData55.DownDuration, 5);
            Assert.Equal(13.75f, io.KeysData55.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData55.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 56 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData56_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 28.0f, DownDurationPrev = 14.0f, AnalogValue = 0.75f };
            io.KeysData56 = value;
            Assert.Equal((byte)1, io.KeysData56.Down);
            Assert.Equal(28.0f, io.KeysData56.DownDuration, 5);
            Assert.Equal(14.0f, io.KeysData56.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData56.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 57 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData57_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 28.5f, DownDurationPrev = 14.25f, AnalogValue = 0.75f };
            io.KeysData57 = value;
            Assert.Equal((byte)1, io.KeysData57.Down);
            Assert.Equal(28.5f, io.KeysData57.DownDuration, 5);
            Assert.Equal(14.25f, io.KeysData57.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData57.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 58 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData58_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 29.0f, DownDurationPrev = 14.5f, AnalogValue = 0.75f };
            io.KeysData58 = value;
            Assert.Equal((byte)1, io.KeysData58.Down);
            Assert.Equal(29.0f, io.KeysData58.DownDuration, 5);
            Assert.Equal(14.5f, io.KeysData58.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData58.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 59 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData59_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 29.5f, DownDurationPrev = 14.75f, AnalogValue = 0.75f };
            io.KeysData59 = value;
            Assert.Equal((byte)1, io.KeysData59.Down);
            Assert.Equal(29.5f, io.KeysData59.DownDuration, 5);
            Assert.Equal(14.75f, io.KeysData59.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData59.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 60 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData60_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 30.0f, DownDurationPrev = 15.0f, AnalogValue = 0.75f };
            io.KeysData60 = value;
            Assert.Equal((byte)1, io.KeysData60.Down);
            Assert.Equal(30.0f, io.KeysData60.DownDuration, 5);
            Assert.Equal(15.0f, io.KeysData60.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData60.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 61 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData61_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 30.5f, DownDurationPrev = 15.25f, AnalogValue = 0.75f };
            io.KeysData61 = value;
            Assert.Equal((byte)1, io.KeysData61.Down);
            Assert.Equal(30.5f, io.KeysData61.DownDuration, 5);
            Assert.Equal(15.25f, io.KeysData61.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData61.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 62 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData62_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 31.0f, DownDurationPrev = 15.5f, AnalogValue = 0.75f };
            io.KeysData62 = value;
            Assert.Equal((byte)1, io.KeysData62.Down);
            Assert.Equal(31.0f, io.KeysData62.DownDuration, 5);
            Assert.Equal(15.5f, io.KeysData62.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData62.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 63 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData63_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 31.5f, DownDurationPrev = 15.75f, AnalogValue = 0.75f };
            io.KeysData63 = value;
            Assert.Equal((byte)1, io.KeysData63.Down);
            Assert.Equal(31.5f, io.KeysData63.DownDuration, 5);
            Assert.Equal(15.75f, io.KeysData63.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData63.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 64 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData64_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 32.0f, DownDurationPrev = 16.0f, AnalogValue = 0.75f };
            io.KeysData64 = value;
            Assert.Equal((byte)1, io.KeysData64.Down);
            Assert.Equal(32.0f, io.KeysData64.DownDuration, 5);
            Assert.Equal(16.0f, io.KeysData64.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData64.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 65 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData65_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 32.5f, DownDurationPrev = 16.25f, AnalogValue = 0.75f };
            io.KeysData65 = value;
            Assert.Equal((byte)1, io.KeysData65.Down);
            Assert.Equal(32.5f, io.KeysData65.DownDuration, 5);
            Assert.Equal(16.25f, io.KeysData65.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData65.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 66 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData66_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 33.0f, DownDurationPrev = 16.5f, AnalogValue = 0.75f };
            io.KeysData66 = value;
            Assert.Equal((byte)1, io.KeysData66.Down);
            Assert.Equal(33.0f, io.KeysData66.DownDuration, 5);
            Assert.Equal(16.5f, io.KeysData66.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData66.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 67 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData67_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 33.5f, DownDurationPrev = 16.75f, AnalogValue = 0.75f };
            io.KeysData67 = value;
            Assert.Equal((byte)1, io.KeysData67.Down);
            Assert.Equal(33.5f, io.KeysData67.DownDuration, 5);
            Assert.Equal(16.75f, io.KeysData67.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData67.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 68 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData68_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 34.0f, DownDurationPrev = 17.0f, AnalogValue = 0.75f };
            io.KeysData68 = value;
            Assert.Equal((byte)1, io.KeysData68.Down);
            Assert.Equal(34.0f, io.KeysData68.DownDuration, 5);
            Assert.Equal(17.0f, io.KeysData68.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData68.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 69 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData69_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 34.5f, DownDurationPrev = 17.25f, AnalogValue = 0.75f };
            io.KeysData69 = value;
            Assert.Equal((byte)1, io.KeysData69.Down);
            Assert.Equal(34.5f, io.KeysData69.DownDuration, 5);
            Assert.Equal(17.25f, io.KeysData69.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData69.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 70 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData70_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 35.0f, DownDurationPrev = 17.5f, AnalogValue = 0.75f };
            io.KeysData70 = value;
            Assert.Equal((byte)1, io.KeysData70.Down);
            Assert.Equal(35.0f, io.KeysData70.DownDuration, 5);
            Assert.Equal(17.5f, io.KeysData70.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData70.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 71 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData71_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 35.5f, DownDurationPrev = 17.75f, AnalogValue = 0.75f };
            io.KeysData71 = value;
            Assert.Equal((byte)1, io.KeysData71.Down);
            Assert.Equal(35.5f, io.KeysData71.DownDuration, 5);
            Assert.Equal(17.75f, io.KeysData71.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData71.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 72 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData72_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 36.0f, DownDurationPrev = 18.0f, AnalogValue = 0.75f };
            io.KeysData72 = value;
            Assert.Equal((byte)1, io.KeysData72.Down);
            Assert.Equal(36.0f, io.KeysData72.DownDuration, 5);
            Assert.Equal(18.0f, io.KeysData72.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData72.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 73 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData73_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 36.5f, DownDurationPrev = 18.25f, AnalogValue = 0.75f };
            io.KeysData73 = value;
            Assert.Equal((byte)1, io.KeysData73.Down);
            Assert.Equal(36.5f, io.KeysData73.DownDuration, 5);
            Assert.Equal(18.25f, io.KeysData73.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData73.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 74 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData74_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 37.0f, DownDurationPrev = 18.5f, AnalogValue = 0.75f };
            io.KeysData74 = value;
            Assert.Equal((byte)1, io.KeysData74.Down);
            Assert.Equal(37.0f, io.KeysData74.DownDuration, 5);
            Assert.Equal(18.5f, io.KeysData74.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData74.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 75 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData75_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 37.5f, DownDurationPrev = 18.75f, AnalogValue = 0.75f };
            io.KeysData75 = value;
            Assert.Equal((byte)1, io.KeysData75.Down);
            Assert.Equal(37.5f, io.KeysData75.DownDuration, 5);
            Assert.Equal(18.75f, io.KeysData75.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData75.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 76 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData76_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 38.0f, DownDurationPrev = 19.0f, AnalogValue = 0.75f };
            io.KeysData76 = value;
            Assert.Equal((byte)1, io.KeysData76.Down);
            Assert.Equal(38.0f, io.KeysData76.DownDuration, 5);
            Assert.Equal(19.0f, io.KeysData76.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData76.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 77 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData77_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 38.5f, DownDurationPrev = 19.25f, AnalogValue = 0.75f };
            io.KeysData77 = value;
            Assert.Equal((byte)1, io.KeysData77.Down);
            Assert.Equal(38.5f, io.KeysData77.DownDuration, 5);
            Assert.Equal(19.25f, io.KeysData77.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData77.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 78 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData78_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 39.0f, DownDurationPrev = 19.5f, AnalogValue = 0.75f };
            io.KeysData78 = value;
            Assert.Equal((byte)1, io.KeysData78.Down);
            Assert.Equal(39.0f, io.KeysData78.DownDuration, 5);
            Assert.Equal(19.5f, io.KeysData78.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData78.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 79 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData79_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 39.5f, DownDurationPrev = 19.75f, AnalogValue = 0.75f };
            io.KeysData79 = value;
            Assert.Equal((byte)1, io.KeysData79.Down);
            Assert.Equal(39.5f, io.KeysData79.DownDuration, 5);
            Assert.Equal(19.75f, io.KeysData79.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData79.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 80 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData80_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 40.0f, DownDurationPrev = 20.0f, AnalogValue = 0.75f };
            io.KeysData80 = value;
            Assert.Equal((byte)1, io.KeysData80.Down);
            Assert.Equal(40.0f, io.KeysData80.DownDuration, 5);
            Assert.Equal(20.0f, io.KeysData80.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData80.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 81 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData81_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 40.5f, DownDurationPrev = 20.25f, AnalogValue = 0.75f };
            io.KeysData81 = value;
            Assert.Equal((byte)1, io.KeysData81.Down);
            Assert.Equal(40.5f, io.KeysData81.DownDuration, 5);
            Assert.Equal(20.25f, io.KeysData81.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData81.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 82 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData82_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 41.0f, DownDurationPrev = 20.5f, AnalogValue = 0.75f };
            io.KeysData82 = value;
            Assert.Equal((byte)1, io.KeysData82.Down);
            Assert.Equal(41.0f, io.KeysData82.DownDuration, 5);
            Assert.Equal(20.5f, io.KeysData82.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData82.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 83 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData83_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 41.5f, DownDurationPrev = 20.75f, AnalogValue = 0.75f };
            io.KeysData83 = value;
            Assert.Equal((byte)1, io.KeysData83.Down);
            Assert.Equal(41.5f, io.KeysData83.DownDuration, 5);
            Assert.Equal(20.75f, io.KeysData83.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData83.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 84 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData84_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 42.0f, DownDurationPrev = 21.0f, AnalogValue = 0.75f };
            io.KeysData84 = value;
            Assert.Equal((byte)1, io.KeysData84.Down);
            Assert.Equal(42.0f, io.KeysData84.DownDuration, 5);
            Assert.Equal(21.0f, io.KeysData84.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData84.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 85 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData85_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 42.5f, DownDurationPrev = 21.25f, AnalogValue = 0.75f };
            io.KeysData85 = value;
            Assert.Equal((byte)1, io.KeysData85.Down);
            Assert.Equal(42.5f, io.KeysData85.DownDuration, 5);
            Assert.Equal(21.25f, io.KeysData85.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData85.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 86 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData86_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 43.0f, DownDurationPrev = 21.5f, AnalogValue = 0.75f };
            io.KeysData86 = value;
            Assert.Equal((byte)1, io.KeysData86.Down);
            Assert.Equal(43.0f, io.KeysData86.DownDuration, 5);
            Assert.Equal(21.5f, io.KeysData86.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData86.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 87 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData87_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 43.5f, DownDurationPrev = 21.75f, AnalogValue = 0.75f };
            io.KeysData87 = value;
            Assert.Equal((byte)1, io.KeysData87.Down);
            Assert.Equal(43.5f, io.KeysData87.DownDuration, 5);
            Assert.Equal(21.75f, io.KeysData87.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData87.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 88 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData88_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 44.0f, DownDurationPrev = 22.0f, AnalogValue = 0.75f };
            io.KeysData88 = value;
            Assert.Equal((byte)1, io.KeysData88.Down);
            Assert.Equal(44.0f, io.KeysData88.DownDuration, 5);
            Assert.Equal(22.0f, io.KeysData88.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData88.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 89 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData89_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 44.5f, DownDurationPrev = 22.25f, AnalogValue = 0.75f };
            io.KeysData89 = value;
            Assert.Equal((byte)1, io.KeysData89.Down);
            Assert.Equal(44.5f, io.KeysData89.DownDuration, 5);
            Assert.Equal(22.25f, io.KeysData89.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData89.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 90 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData90_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 45.0f, DownDurationPrev = 22.5f, AnalogValue = 0.75f };
            io.KeysData90 = value;
            Assert.Equal((byte)1, io.KeysData90.Down);
            Assert.Equal(45.0f, io.KeysData90.DownDuration, 5);
            Assert.Equal(22.5f, io.KeysData90.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData90.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 91 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData91_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 45.5f, DownDurationPrev = 22.75f, AnalogValue = 0.75f };
            io.KeysData91 = value;
            Assert.Equal((byte)1, io.KeysData91.Down);
            Assert.Equal(45.5f, io.KeysData91.DownDuration, 5);
            Assert.Equal(22.75f, io.KeysData91.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData91.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 92 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData92_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 46.0f, DownDurationPrev = 23.0f, AnalogValue = 0.75f };
            io.KeysData92 = value;
            Assert.Equal((byte)1, io.KeysData92.Down);
            Assert.Equal(46.0f, io.KeysData92.DownDuration, 5);
            Assert.Equal(23.0f, io.KeysData92.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData92.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 93 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData93_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 46.5f, DownDurationPrev = 23.25f, AnalogValue = 0.75f };
            io.KeysData93 = value;
            Assert.Equal((byte)1, io.KeysData93.Down);
            Assert.Equal(46.5f, io.KeysData93.DownDuration, 5);
            Assert.Equal(23.25f, io.KeysData93.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData93.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 94 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData94_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 47.0f, DownDurationPrev = 23.5f, AnalogValue = 0.75f };
            io.KeysData94 = value;
            Assert.Equal((byte)1, io.KeysData94.Down);
            Assert.Equal(47.0f, io.KeysData94.DownDuration, 5);
            Assert.Equal(23.5f, io.KeysData94.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData94.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 95 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData95_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 47.5f, DownDurationPrev = 23.75f, AnalogValue = 0.75f };
            io.KeysData95 = value;
            Assert.Equal((byte)1, io.KeysData95.Down);
            Assert.Equal(47.5f, io.KeysData95.DownDuration, 5);
            Assert.Equal(23.75f, io.KeysData95.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData95.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 96 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData96_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 48.0f, DownDurationPrev = 24.0f, AnalogValue = 0.75f };
            io.KeysData96 = value;
            Assert.Equal((byte)1, io.KeysData96.Down);
            Assert.Equal(48.0f, io.KeysData96.DownDuration, 5);
            Assert.Equal(24.0f, io.KeysData96.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData96.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 97 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData97_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 48.5f, DownDurationPrev = 24.25f, AnalogValue = 0.75f };
            io.KeysData97 = value;
            Assert.Equal((byte)1, io.KeysData97.Down);
            Assert.Equal(48.5f, io.KeysData97.DownDuration, 5);
            Assert.Equal(24.25f, io.KeysData97.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData97.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 98 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData98_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 49.0f, DownDurationPrev = 24.5f, AnalogValue = 0.75f };
            io.KeysData98 = value;
            Assert.Equal((byte)1, io.KeysData98.Down);
            Assert.Equal(49.0f, io.KeysData98.DownDuration, 5);
            Assert.Equal(24.5f, io.KeysData98.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData98.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 99 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData99_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 49.5f, DownDurationPrev = 24.75f, AnalogValue = 0.75f };
            io.KeysData99 = value;
            Assert.Equal((byte)1, io.KeysData99.Down);
            Assert.Equal(49.5f, io.KeysData99.DownDuration, 5);
            Assert.Equal(24.75f, io.KeysData99.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData99.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 101 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData101_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 50.5f, DownDurationPrev = 25.25f, AnalogValue = 0.75f };
            io.KeysData101 = value;
            Assert.Equal((byte)1, io.KeysData101.Down);
            Assert.Equal(50.5f, io.KeysData101.DownDuration, 5);
            Assert.Equal(25.25f, io.KeysData101.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData101.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 102 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData102_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 51.0f, DownDurationPrev = 25.5f, AnalogValue = 0.75f };
            io.KeysData102 = value;
            Assert.Equal((byte)1, io.KeysData102.Down);
            Assert.Equal(51.0f, io.KeysData102.DownDuration, 5);
            Assert.Equal(25.5f, io.KeysData102.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData102.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 103 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData103_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 51.5f, DownDurationPrev = 25.75f, AnalogValue = 0.75f };
            io.KeysData103 = value;
            Assert.Equal((byte)1, io.KeysData103.Down);
            Assert.Equal(51.5f, io.KeysData103.DownDuration, 5);
            Assert.Equal(25.75f, io.KeysData103.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData103.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 104 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData104_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 52.0f, DownDurationPrev = 26.0f, AnalogValue = 0.75f };
            io.KeysData104 = value;
            Assert.Equal((byte)1, io.KeysData104.Down);
            Assert.Equal(52.0f, io.KeysData104.DownDuration, 5);
            Assert.Equal(26.0f, io.KeysData104.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData104.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 105 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData105_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 52.5f, DownDurationPrev = 26.25f, AnalogValue = 0.75f };
            io.KeysData105 = value;
            Assert.Equal((byte)1, io.KeysData105.Down);
            Assert.Equal(52.5f, io.KeysData105.DownDuration, 5);
            Assert.Equal(26.25f, io.KeysData105.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData105.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 106 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData106_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 53.0f, DownDurationPrev = 26.5f, AnalogValue = 0.75f };
            io.KeysData106 = value;
            Assert.Equal((byte)1, io.KeysData106.Down);
            Assert.Equal(53.0f, io.KeysData106.DownDuration, 5);
            Assert.Equal(26.5f, io.KeysData106.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData106.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 107 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData107_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 53.5f, DownDurationPrev = 26.75f, AnalogValue = 0.75f };
            io.KeysData107 = value;
            Assert.Equal((byte)1, io.KeysData107.Down);
            Assert.Equal(53.5f, io.KeysData107.DownDuration, 5);
            Assert.Equal(26.75f, io.KeysData107.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData107.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 108 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData108_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 54.0f, DownDurationPrev = 27.0f, AnalogValue = 0.75f };
            io.KeysData108 = value;
            Assert.Equal((byte)1, io.KeysData108.Down);
            Assert.Equal(54.0f, io.KeysData108.DownDuration, 5);
            Assert.Equal(27.0f, io.KeysData108.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData108.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 109 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData109_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 54.5f, DownDurationPrev = 27.25f, AnalogValue = 0.75f };
            io.KeysData109 = value;
            Assert.Equal((byte)1, io.KeysData109.Down);
            Assert.Equal(54.5f, io.KeysData109.DownDuration, 5);
            Assert.Equal(27.25f, io.KeysData109.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData109.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 110 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData110_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 55.0f, DownDurationPrev = 27.5f, AnalogValue = 0.75f };
            io.KeysData110 = value;
            Assert.Equal((byte)1, io.KeysData110.Down);
            Assert.Equal(55.0f, io.KeysData110.DownDuration, 5);
            Assert.Equal(27.5f, io.KeysData110.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData110.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 111 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData111_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 55.5f, DownDurationPrev = 27.75f, AnalogValue = 0.75f };
            io.KeysData111 = value;
            Assert.Equal((byte)1, io.KeysData111.Down);
            Assert.Equal(55.5f, io.KeysData111.DownDuration, 5);
            Assert.Equal(27.75f, io.KeysData111.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData111.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 112 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData112_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 56.0f, DownDurationPrev = 28.0f, AnalogValue = 0.75f };
            io.KeysData112 = value;
            Assert.Equal((byte)1, io.KeysData112.Down);
            Assert.Equal(56.0f, io.KeysData112.DownDuration, 5);
            Assert.Equal(28.0f, io.KeysData112.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData112.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 113 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData113_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 56.5f, DownDurationPrev = 28.25f, AnalogValue = 0.75f };
            io.KeysData113 = value;
            Assert.Equal((byte)1, io.KeysData113.Down);
            Assert.Equal(56.5f, io.KeysData113.DownDuration, 5);
            Assert.Equal(28.25f, io.KeysData113.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData113.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 114 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData114_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 57.0f, DownDurationPrev = 28.5f, AnalogValue = 0.75f };
            io.KeysData114 = value;
            Assert.Equal((byte)1, io.KeysData114.Down);
            Assert.Equal(57.0f, io.KeysData114.DownDuration, 5);
            Assert.Equal(28.5f, io.KeysData114.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData114.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 115 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData115_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 57.5f, DownDurationPrev = 28.75f, AnalogValue = 0.75f };
            io.KeysData115 = value;
            Assert.Equal((byte)1, io.KeysData115.Down);
            Assert.Equal(57.5f, io.KeysData115.DownDuration, 5);
            Assert.Equal(28.75f, io.KeysData115.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData115.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 116 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData116_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 58.0f, DownDurationPrev = 29.0f, AnalogValue = 0.75f };
            io.KeysData116 = value;
            Assert.Equal((byte)1, io.KeysData116.Down);
            Assert.Equal(58.0f, io.KeysData116.DownDuration, 5);
            Assert.Equal(29.0f, io.KeysData116.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData116.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 117 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData117_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 58.5f, DownDurationPrev = 29.25f, AnalogValue = 0.75f };
            io.KeysData117 = value;
            Assert.Equal((byte)1, io.KeysData117.Down);
            Assert.Equal(58.5f, io.KeysData117.DownDuration, 5);
            Assert.Equal(29.25f, io.KeysData117.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData117.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 118 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData118_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 59.0f, DownDurationPrev = 29.5f, AnalogValue = 0.75f };
            io.KeysData118 = value;
            Assert.Equal((byte)1, io.KeysData118.Down);
            Assert.Equal(59.0f, io.KeysData118.DownDuration, 5);
            Assert.Equal(29.5f, io.KeysData118.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData118.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 119 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData119_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 59.5f, DownDurationPrev = 29.75f, AnalogValue = 0.75f };
            io.KeysData119 = value;
            Assert.Equal((byte)1, io.KeysData119.Down);
            Assert.Equal(59.5f, io.KeysData119.DownDuration, 5);
            Assert.Equal(29.75f, io.KeysData119.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData119.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 120 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData120_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 60.0f, DownDurationPrev = 30.0f, AnalogValue = 0.75f };
            io.KeysData120 = value;
            Assert.Equal((byte)1, io.KeysData120.Down);
            Assert.Equal(60.0f, io.KeysData120.DownDuration, 5);
            Assert.Equal(30.0f, io.KeysData120.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData120.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 121 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData121_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 60.5f, DownDurationPrev = 30.25f, AnalogValue = 0.75f };
            io.KeysData121 = value;
            Assert.Equal((byte)1, io.KeysData121.Down);
            Assert.Equal(60.5f, io.KeysData121.DownDuration, 5);
            Assert.Equal(30.25f, io.KeysData121.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData121.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 122 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData122_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 61.0f, DownDurationPrev = 30.5f, AnalogValue = 0.75f };
            io.KeysData122 = value;
            Assert.Equal((byte)1, io.KeysData122.Down);
            Assert.Equal(61.0f, io.KeysData122.DownDuration, 5);
            Assert.Equal(30.5f, io.KeysData122.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData122.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 123 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData123_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 61.5f, DownDurationPrev = 30.75f, AnalogValue = 0.75f };
            io.KeysData123 = value;
            Assert.Equal((byte)1, io.KeysData123.Down);
            Assert.Equal(61.5f, io.KeysData123.DownDuration, 5);
            Assert.Equal(30.75f, io.KeysData123.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData123.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 124 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData124_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 62.0f, DownDurationPrev = 31.0f, AnalogValue = 0.75f };
            io.KeysData124 = value;
            Assert.Equal((byte)1, io.KeysData124.Down);
            Assert.Equal(62.0f, io.KeysData124.DownDuration, 5);
            Assert.Equal(31.0f, io.KeysData124.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData124.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 125 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData125_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 62.5f, DownDurationPrev = 31.25f, AnalogValue = 0.75f };
            io.KeysData125 = value;
            Assert.Equal((byte)1, io.KeysData125.Down);
            Assert.Equal(62.5f, io.KeysData125.DownDuration, 5);
            Assert.Equal(31.25f, io.KeysData125.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData125.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 126 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData126_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 63.0f, DownDurationPrev = 31.5f, AnalogValue = 0.75f };
            io.KeysData126 = value;
            Assert.Equal((byte)1, io.KeysData126.Down);
            Assert.Equal(63.0f, io.KeysData126.DownDuration, 5);
            Assert.Equal(31.5f, io.KeysData126.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData126.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 127 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData127_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 63.5f, DownDurationPrev = 31.75f, AnalogValue = 0.75f };
            io.KeysData127 = value;
            Assert.Equal((byte)1, io.KeysData127.Down);
            Assert.Equal(63.5f, io.KeysData127.DownDuration, 5);
            Assert.Equal(31.75f, io.KeysData127.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData127.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 128 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData128_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 64.0f, DownDurationPrev = 32.0f, AnalogValue = 0.75f };
            io.KeysData128 = value;
            Assert.Equal((byte)1, io.KeysData128.Down);
            Assert.Equal(64.0f, io.KeysData128.DownDuration, 5);
            Assert.Equal(32.0f, io.KeysData128.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData128.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 129 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData129_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 64.5f, DownDurationPrev = 32.25f, AnalogValue = 0.75f };
            io.KeysData129 = value;
            Assert.Equal((byte)1, io.KeysData129.Down);
            Assert.Equal(64.5f, io.KeysData129.DownDuration, 5);
            Assert.Equal(32.25f, io.KeysData129.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData129.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 130 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData130_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 65.0f, DownDurationPrev = 32.5f, AnalogValue = 0.75f };
            io.KeysData130 = value;
            Assert.Equal((byte)1, io.KeysData130.Down);
            Assert.Equal(65.0f, io.KeysData130.DownDuration, 5);
            Assert.Equal(32.5f, io.KeysData130.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData130.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 131 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData131_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 65.5f, DownDurationPrev = 32.75f, AnalogValue = 0.75f };
            io.KeysData131 = value;
            Assert.Equal((byte)1, io.KeysData131.Down);
            Assert.Equal(65.5f, io.KeysData131.DownDuration, 5);
            Assert.Equal(32.75f, io.KeysData131.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData131.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 132 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData132_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 66.0f, DownDurationPrev = 33.0f, AnalogValue = 0.75f };
            io.KeysData132 = value;
            Assert.Equal((byte)1, io.KeysData132.Down);
            Assert.Equal(66.0f, io.KeysData132.DownDuration, 5);
            Assert.Equal(33.0f, io.KeysData132.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData132.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 133 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData133_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 66.5f, DownDurationPrev = 33.25f, AnalogValue = 0.75f };
            io.KeysData133 = value;
            Assert.Equal((byte)1, io.KeysData133.Down);
            Assert.Equal(66.5f, io.KeysData133.DownDuration, 5);
            Assert.Equal(33.25f, io.KeysData133.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData133.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 134 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData134_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 67.0f, DownDurationPrev = 33.5f, AnalogValue = 0.75f };
            io.KeysData134 = value;
            Assert.Equal((byte)1, io.KeysData134.Down);
            Assert.Equal(67.0f, io.KeysData134.DownDuration, 5);
            Assert.Equal(33.5f, io.KeysData134.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData134.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 135 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData135_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 67.5f, DownDurationPrev = 33.75f, AnalogValue = 0.75f };
            io.KeysData135 = value;
            Assert.Equal((byte)1, io.KeysData135.Down);
            Assert.Equal(67.5f, io.KeysData135.DownDuration, 5);
            Assert.Equal(33.75f, io.KeysData135.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData135.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 136 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData136_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 68.0f, DownDurationPrev = 34.0f, AnalogValue = 0.75f };
            io.KeysData136 = value;
            Assert.Equal((byte)1, io.KeysData136.Down);
            Assert.Equal(68.0f, io.KeysData136.DownDuration, 5);
            Assert.Equal(34.0f, io.KeysData136.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData136.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 137 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData137_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 68.5f, DownDurationPrev = 34.25f, AnalogValue = 0.75f };
            io.KeysData137 = value;
            Assert.Equal((byte)1, io.KeysData137.Down);
            Assert.Equal(68.5f, io.KeysData137.DownDuration, 5);
            Assert.Equal(34.25f, io.KeysData137.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData137.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 138 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData138_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 69.0f, DownDurationPrev = 34.5f, AnalogValue = 0.75f };
            io.KeysData138 = value;
            Assert.Equal((byte)1, io.KeysData138.Down);
            Assert.Equal(69.0f, io.KeysData138.DownDuration, 5);
            Assert.Equal(34.5f, io.KeysData138.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData138.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 139 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData139_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 69.5f, DownDurationPrev = 34.75f, AnalogValue = 0.75f };
            io.KeysData139 = value;
            Assert.Equal((byte)1, io.KeysData139.Down);
            Assert.Equal(69.5f, io.KeysData139.DownDuration, 5);
            Assert.Equal(34.75f, io.KeysData139.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData139.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 140 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData140_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 70.0f, DownDurationPrev = 35.0f, AnalogValue = 0.75f };
            io.KeysData140 = value;
            Assert.Equal((byte)1, io.KeysData140.Down);
            Assert.Equal(70.0f, io.KeysData140.DownDuration, 5);
            Assert.Equal(35.0f, io.KeysData140.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData140.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 141 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData141_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 70.5f, DownDurationPrev = 35.25f, AnalogValue = 0.75f };
            io.KeysData141 = value;
            Assert.Equal((byte)1, io.KeysData141.Down);
            Assert.Equal(70.5f, io.KeysData141.DownDuration, 5);
            Assert.Equal(35.25f, io.KeysData141.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData141.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 142 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData142_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 71.0f, DownDurationPrev = 35.5f, AnalogValue = 0.75f };
            io.KeysData142 = value;
            Assert.Equal((byte)1, io.KeysData142.Down);
            Assert.Equal(71.0f, io.KeysData142.DownDuration, 5);
            Assert.Equal(35.5f, io.KeysData142.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData142.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 143 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData143_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 71.5f, DownDurationPrev = 35.75f, AnalogValue = 0.75f };
            io.KeysData143 = value;
            Assert.Equal((byte)1, io.KeysData143.Down);
            Assert.Equal(71.5f, io.KeysData143.DownDuration, 5);
            Assert.Equal(35.75f, io.KeysData143.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData143.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 144 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData144_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 72.0f, DownDurationPrev = 36.0f, AnalogValue = 0.75f };
            io.KeysData144 = value;
            Assert.Equal((byte)1, io.KeysData144.Down);
            Assert.Equal(72.0f, io.KeysData144.DownDuration, 5);
            Assert.Equal(36.0f, io.KeysData144.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData144.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 145 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData145_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 72.5f, DownDurationPrev = 36.25f, AnalogValue = 0.75f };
            io.KeysData145 = value;
            Assert.Equal((byte)1, io.KeysData145.Down);
            Assert.Equal(72.5f, io.KeysData145.DownDuration, 5);
            Assert.Equal(36.25f, io.KeysData145.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData145.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 146 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData146_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 73.0f, DownDurationPrev = 36.5f, AnalogValue = 0.75f };
            io.KeysData146 = value;
            Assert.Equal((byte)1, io.KeysData146.Down);
            Assert.Equal(73.0f, io.KeysData146.DownDuration, 5);
            Assert.Equal(36.5f, io.KeysData146.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData146.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 147 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData147_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 73.5f, DownDurationPrev = 36.75f, AnalogValue = 0.75f };
            io.KeysData147 = value;
            Assert.Equal((byte)1, io.KeysData147.Down);
            Assert.Equal(73.5f, io.KeysData147.DownDuration, 5);
            Assert.Equal(36.75f, io.KeysData147.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData147.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 148 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData148_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 74.0f, DownDurationPrev = 37.0f, AnalogValue = 0.75f };
            io.KeysData148 = value;
            Assert.Equal((byte)1, io.KeysData148.Down);
            Assert.Equal(74.0f, io.KeysData148.DownDuration, 5);
            Assert.Equal(37.0f, io.KeysData148.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData148.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 149 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData149_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 74.5f, DownDurationPrev = 37.25f, AnalogValue = 0.75f };
            io.KeysData149 = value;
            Assert.Equal((byte)1, io.KeysData149.Down);
            Assert.Equal(74.5f, io.KeysData149.DownDuration, 5);
            Assert.Equal(37.25f, io.KeysData149.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData149.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 150 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData150_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 75.0f, DownDurationPrev = 37.5f, AnalogValue = 0.75f };
            io.KeysData150 = value;
            Assert.Equal((byte)1, io.KeysData150.Down);
            Assert.Equal(75.0f, io.KeysData150.DownDuration, 5);
            Assert.Equal(37.5f, io.KeysData150.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData150.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 151 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData151_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 75.5f, DownDurationPrev = 37.75f, AnalogValue = 0.75f };
            io.KeysData151 = value;
            Assert.Equal((byte)1, io.KeysData151.Down);
            Assert.Equal(75.5f, io.KeysData151.DownDuration, 5);
            Assert.Equal(37.75f, io.KeysData151.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData151.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 152 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData152_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 76.0f, DownDurationPrev = 38.0f, AnalogValue = 0.75f };
            io.KeysData152 = value;
            Assert.Equal((byte)1, io.KeysData152.Down);
            Assert.Equal(76.0f, io.KeysData152.DownDuration, 5);
            Assert.Equal(38.0f, io.KeysData152.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData152.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 153 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData153_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 76.5f, DownDurationPrev = 38.25f, AnalogValue = 0.75f };
            io.KeysData153 = value;
            Assert.Equal((byte)1, io.KeysData153.Down);
            Assert.Equal(76.5f, io.KeysData153.DownDuration, 5);
            Assert.Equal(38.25f, io.KeysData153.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData153.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 154 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData154_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 77.0f, DownDurationPrev = 38.5f, AnalogValue = 0.75f };
            io.KeysData154 = value;
            Assert.Equal((byte)1, io.KeysData154.Down);
            Assert.Equal(77.0f, io.KeysData154.DownDuration, 5);
            Assert.Equal(38.5f, io.KeysData154.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData154.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 155 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData155_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 77.5f, DownDurationPrev = 38.75f, AnalogValue = 0.75f };
            io.KeysData155 = value;
            Assert.Equal((byte)1, io.KeysData155.Down);
            Assert.Equal(77.5f, io.KeysData155.DownDuration, 5);
            Assert.Equal(38.75f, io.KeysData155.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData155.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 156 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData156_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 78.0f, DownDurationPrev = 39.0f, AnalogValue = 0.75f };
            io.KeysData156 = value;
            Assert.Equal((byte)1, io.KeysData156.Down);
            Assert.Equal(78.0f, io.KeysData156.DownDuration, 5);
            Assert.Equal(39.0f, io.KeysData156.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData156.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 157 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData157_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 78.5f, DownDurationPrev = 39.25f, AnalogValue = 0.75f };
            io.KeysData157 = value;
            Assert.Equal((byte)1, io.KeysData157.Down);
            Assert.Equal(78.5f, io.KeysData157.DownDuration, 5);
            Assert.Equal(39.25f, io.KeysData157.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData157.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 158 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData158_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 79.0f, DownDurationPrev = 39.5f, AnalogValue = 0.75f };
            io.KeysData158 = value;
            Assert.Equal((byte)1, io.KeysData158.Down);
            Assert.Equal(79.0f, io.KeysData158.DownDuration, 5);
            Assert.Equal(39.5f, io.KeysData158.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData158.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 159 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData159_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 79.5f, DownDurationPrev = 39.75f, AnalogValue = 0.75f };
            io.KeysData159 = value;
            Assert.Equal((byte)1, io.KeysData159.Down);
            Assert.Equal(79.5f, io.KeysData159.DownDuration, 5);
            Assert.Equal(39.75f, io.KeysData159.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData159.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 160 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData160_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 80.0f, DownDurationPrev = 40.0f, AnalogValue = 0.75f };
            io.KeysData160 = value;
            Assert.Equal((byte)1, io.KeysData160.Down);
            Assert.Equal(80.0f, io.KeysData160.DownDuration, 5);
            Assert.Equal(40.0f, io.KeysData160.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData160.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 161 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData161_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 80.5f, DownDurationPrev = 40.25f, AnalogValue = 0.75f };
            io.KeysData161 = value;
            Assert.Equal((byte)1, io.KeysData161.Down);
            Assert.Equal(80.5f, io.KeysData161.DownDuration, 5);
            Assert.Equal(40.25f, io.KeysData161.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData161.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 162 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData162_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 81.0f, DownDurationPrev = 40.5f, AnalogValue = 0.75f };
            io.KeysData162 = value;
            Assert.Equal((byte)1, io.KeysData162.Down);
            Assert.Equal(81.0f, io.KeysData162.DownDuration, 5);
            Assert.Equal(40.5f, io.KeysData162.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData162.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 163 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData163_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 81.5f, DownDurationPrev = 40.75f, AnalogValue = 0.75f };
            io.KeysData163 = value;
            Assert.Equal((byte)1, io.KeysData163.Down);
            Assert.Equal(81.5f, io.KeysData163.DownDuration, 5);
            Assert.Equal(40.75f, io.KeysData163.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData163.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 164 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData164_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 82.0f, DownDurationPrev = 41.0f, AnalogValue = 0.75f };
            io.KeysData164 = value;
            Assert.Equal((byte)1, io.KeysData164.Down);
            Assert.Equal(82.0f, io.KeysData164.DownDuration, 5);
            Assert.Equal(41.0f, io.KeysData164.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData164.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 165 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData165_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 82.5f, DownDurationPrev = 41.25f, AnalogValue = 0.75f };
            io.KeysData165 = value;
            Assert.Equal((byte)1, io.KeysData165.Down);
            Assert.Equal(82.5f, io.KeysData165.DownDuration, 5);
            Assert.Equal(41.25f, io.KeysData165.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData165.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 166 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData166_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 83.0f, DownDurationPrev = 41.5f, AnalogValue = 0.75f };
            io.KeysData166 = value;
            Assert.Equal((byte)1, io.KeysData166.Down);
            Assert.Equal(83.0f, io.KeysData166.DownDuration, 5);
            Assert.Equal(41.5f, io.KeysData166.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData166.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 167 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData167_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 83.5f, DownDurationPrev = 41.75f, AnalogValue = 0.75f };
            io.KeysData167 = value;
            Assert.Equal((byte)1, io.KeysData167.Down);
            Assert.Equal(83.5f, io.KeysData167.DownDuration, 5);
            Assert.Equal(41.75f, io.KeysData167.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData167.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 168 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData168_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 84.0f, DownDurationPrev = 42.0f, AnalogValue = 0.75f };
            io.KeysData168 = value;
            Assert.Equal((byte)1, io.KeysData168.Down);
            Assert.Equal(84.0f, io.KeysData168.DownDuration, 5);
            Assert.Equal(42.0f, io.KeysData168.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData168.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 169 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData169_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 84.5f, DownDurationPrev = 42.25f, AnalogValue = 0.75f };
            io.KeysData169 = value;
            Assert.Equal((byte)1, io.KeysData169.Down);
            Assert.Equal(84.5f, io.KeysData169.DownDuration, 5);
            Assert.Equal(42.25f, io.KeysData169.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData169.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 170 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData170_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 85.0f, DownDurationPrev = 42.5f, AnalogValue = 0.75f };
            io.KeysData170 = value;
            Assert.Equal((byte)1, io.KeysData170.Down);
            Assert.Equal(85.0f, io.KeysData170.DownDuration, 5);
            Assert.Equal(42.5f, io.KeysData170.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData170.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 171 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData171_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 85.5f, DownDurationPrev = 42.75f, AnalogValue = 0.75f };
            io.KeysData171 = value;
            Assert.Equal((byte)1, io.KeysData171.Down);
            Assert.Equal(85.5f, io.KeysData171.DownDuration, 5);
            Assert.Equal(42.75f, io.KeysData171.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData171.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 172 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData172_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 86.0f, DownDurationPrev = 43.0f, AnalogValue = 0.75f };
            io.KeysData172 = value;
            Assert.Equal((byte)1, io.KeysData172.Down);
            Assert.Equal(86.0f, io.KeysData172.DownDuration, 5);
            Assert.Equal(43.0f, io.KeysData172.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData172.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 173 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData173_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 86.5f, DownDurationPrev = 43.25f, AnalogValue = 0.75f };
            io.KeysData173 = value;
            Assert.Equal((byte)1, io.KeysData173.Down);
            Assert.Equal(86.5f, io.KeysData173.DownDuration, 5);
            Assert.Equal(43.25f, io.KeysData173.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData173.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 174 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData174_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 87.0f, DownDurationPrev = 43.5f, AnalogValue = 0.75f };
            io.KeysData174 = value;
            Assert.Equal((byte)1, io.KeysData174.Down);
            Assert.Equal(87.0f, io.KeysData174.DownDuration, 5);
            Assert.Equal(43.5f, io.KeysData174.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData174.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 175 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData175_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 87.5f, DownDurationPrev = 43.75f, AnalogValue = 0.75f };
            io.KeysData175 = value;
            Assert.Equal((byte)1, io.KeysData175.Down);
            Assert.Equal(87.5f, io.KeysData175.DownDuration, 5);
            Assert.Equal(43.75f, io.KeysData175.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData175.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 176 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData176_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 88.0f, DownDurationPrev = 44.0f, AnalogValue = 0.75f };
            io.KeysData176 = value;
            Assert.Equal((byte)1, io.KeysData176.Down);
            Assert.Equal(88.0f, io.KeysData176.DownDuration, 5);
            Assert.Equal(44.0f, io.KeysData176.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData176.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 177 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData177_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 88.5f, DownDurationPrev = 44.25f, AnalogValue = 0.75f };
            io.KeysData177 = value;
            Assert.Equal((byte)1, io.KeysData177.Down);
            Assert.Equal(88.5f, io.KeysData177.DownDuration, 5);
            Assert.Equal(44.25f, io.KeysData177.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData177.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 178 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData178_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 89.0f, DownDurationPrev = 44.5f, AnalogValue = 0.75f };
            io.KeysData178 = value;
            Assert.Equal((byte)1, io.KeysData178.Down);
            Assert.Equal(89.0f, io.KeysData178.DownDuration, 5);
            Assert.Equal(44.5f, io.KeysData178.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData178.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 179 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData179_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 89.5f, DownDurationPrev = 44.75f, AnalogValue = 0.75f };
            io.KeysData179 = value;
            Assert.Equal((byte)1, io.KeysData179.Down);
            Assert.Equal(89.5f, io.KeysData179.DownDuration, 5);
            Assert.Equal(44.75f, io.KeysData179.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData179.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 180 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData180_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 90.0f, DownDurationPrev = 45.0f, AnalogValue = 0.75f };
            io.KeysData180 = value;
            Assert.Equal((byte)1, io.KeysData180.Down);
            Assert.Equal(90.0f, io.KeysData180.DownDuration, 5);
            Assert.Equal(45.0f, io.KeysData180.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData180.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 181 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData181_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 90.5f, DownDurationPrev = 45.25f, AnalogValue = 0.75f };
            io.KeysData181 = value;
            Assert.Equal((byte)1, io.KeysData181.Down);
            Assert.Equal(90.5f, io.KeysData181.DownDuration, 5);
            Assert.Equal(45.25f, io.KeysData181.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData181.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 182 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData182_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 91.0f, DownDurationPrev = 45.5f, AnalogValue = 0.75f };
            io.KeysData182 = value;
            Assert.Equal((byte)1, io.KeysData182.Down);
            Assert.Equal(91.0f, io.KeysData182.DownDuration, 5);
            Assert.Equal(45.5f, io.KeysData182.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData182.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 183 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData183_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 91.5f, DownDurationPrev = 45.75f, AnalogValue = 0.75f };
            io.KeysData183 = value;
            Assert.Equal((byte)1, io.KeysData183.Down);
            Assert.Equal(91.5f, io.KeysData183.DownDuration, 5);
            Assert.Equal(45.75f, io.KeysData183.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData183.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 184 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData184_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 92.0f, DownDurationPrev = 46.0f, AnalogValue = 0.75f };
            io.KeysData184 = value;
            Assert.Equal((byte)1, io.KeysData184.Down);
            Assert.Equal(92.0f, io.KeysData184.DownDuration, 5);
            Assert.Equal(46.0f, io.KeysData184.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData184.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 185 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData185_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 92.5f, DownDurationPrev = 46.25f, AnalogValue = 0.75f };
            io.KeysData185 = value;
            Assert.Equal((byte)1, io.KeysData185.Down);
            Assert.Equal(92.5f, io.KeysData185.DownDuration, 5);
            Assert.Equal(46.25f, io.KeysData185.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData185.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 186 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData186_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 93.0f, DownDurationPrev = 46.5f, AnalogValue = 0.75f };
            io.KeysData186 = value;
            Assert.Equal((byte)1, io.KeysData186.Down);
            Assert.Equal(93.0f, io.KeysData186.DownDuration, 5);
            Assert.Equal(46.5f, io.KeysData186.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData186.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 187 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData187_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 93.5f, DownDurationPrev = 46.75f, AnalogValue = 0.75f };
            io.KeysData187 = value;
            Assert.Equal((byte)1, io.KeysData187.Down);
            Assert.Equal(93.5f, io.KeysData187.DownDuration, 5);
            Assert.Equal(46.75f, io.KeysData187.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData187.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 188 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData188_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 94.0f, DownDurationPrev = 47.0f, AnalogValue = 0.75f };
            io.KeysData188 = value;
            Assert.Equal((byte)1, io.KeysData188.Down);
            Assert.Equal(94.0f, io.KeysData188.DownDuration, 5);
            Assert.Equal(47.0f, io.KeysData188.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData188.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 189 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData189_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 94.5f, DownDurationPrev = 47.25f, AnalogValue = 0.75f };
            io.KeysData189 = value;
            Assert.Equal((byte)1, io.KeysData189.Down);
            Assert.Equal(94.5f, io.KeysData189.DownDuration, 5);
            Assert.Equal(47.25f, io.KeysData189.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData189.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 190 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData190_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 95.0f, DownDurationPrev = 47.5f, AnalogValue = 0.75f };
            io.KeysData190 = value;
            Assert.Equal((byte)1, io.KeysData190.Down);
            Assert.Equal(95.0f, io.KeysData190.DownDuration, 5);
            Assert.Equal(47.5f, io.KeysData190.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData190.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 191 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData191_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 95.5f, DownDurationPrev = 47.75f, AnalogValue = 0.75f };
            io.KeysData191 = value;
            Assert.Equal((byte)1, io.KeysData191.Down);
            Assert.Equal(95.5f, io.KeysData191.DownDuration, 5);
            Assert.Equal(47.75f, io.KeysData191.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData191.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 192 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData192_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 96.0f, DownDurationPrev = 48.0f, AnalogValue = 0.75f };
            io.KeysData192 = value;
            Assert.Equal((byte)1, io.KeysData192.Down);
            Assert.Equal(96.0f, io.KeysData192.DownDuration, 5);
            Assert.Equal(48.0f, io.KeysData192.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData192.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 193 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData193_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 96.5f, DownDurationPrev = 48.25f, AnalogValue = 0.75f };
            io.KeysData193 = value;
            Assert.Equal((byte)1, io.KeysData193.Down);
            Assert.Equal(96.5f, io.KeysData193.DownDuration, 5);
            Assert.Equal(48.25f, io.KeysData193.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData193.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 194 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData194_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 97.0f, DownDurationPrev = 48.5f, AnalogValue = 0.75f };
            io.KeysData194 = value;
            Assert.Equal((byte)1, io.KeysData194.Down);
            Assert.Equal(97.0f, io.KeysData194.DownDuration, 5);
            Assert.Equal(48.5f, io.KeysData194.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData194.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 195 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData195_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 97.5f, DownDurationPrev = 48.75f, AnalogValue = 0.75f };
            io.KeysData195 = value;
            Assert.Equal((byte)1, io.KeysData195.Down);
            Assert.Equal(97.5f, io.KeysData195.DownDuration, 5);
            Assert.Equal(48.75f, io.KeysData195.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData195.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 196 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData196_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 98.0f, DownDurationPrev = 49.0f, AnalogValue = 0.75f };
            io.KeysData196 = value;
            Assert.Equal((byte)1, io.KeysData196.Down);
            Assert.Equal(98.0f, io.KeysData196.DownDuration, 5);
            Assert.Equal(49.0f, io.KeysData196.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData196.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 197 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData197_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 98.5f, DownDurationPrev = 49.25f, AnalogValue = 0.75f };
            io.KeysData197 = value;
            Assert.Equal((byte)1, io.KeysData197.Down);
            Assert.Equal(98.5f, io.KeysData197.DownDuration, 5);
            Assert.Equal(49.25f, io.KeysData197.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData197.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 198 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData198_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 99.0f, DownDurationPrev = 49.5f, AnalogValue = 0.75f };
            io.KeysData198 = value;
            Assert.Equal((byte)1, io.KeysData198.Down);
            Assert.Equal(99.0f, io.KeysData198.DownDuration, 5);
            Assert.Equal(49.5f, io.KeysData198.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData198.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 199 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData199_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 99.5f, DownDurationPrev = 49.75f, AnalogValue = 0.75f };
            io.KeysData199 = value;
            Assert.Equal((byte)1, io.KeysData199.Down);
            Assert.Equal(99.5f, io.KeysData199.DownDuration, 5);
            Assert.Equal(49.75f, io.KeysData199.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData199.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 200 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData200_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 100.0f, DownDurationPrev = 50.0f, AnalogValue = 0.75f };
            io.KeysData200 = value;
            Assert.Equal((byte)1, io.KeysData200.Down);
            Assert.Equal(100.0f, io.KeysData200.DownDuration, 5);
            Assert.Equal(50.0f, io.KeysData200.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData200.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 201 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData201_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 100.5f, DownDurationPrev = 50.25f, AnalogValue = 0.75f };
            io.KeysData201 = value;
            Assert.Equal((byte)1, io.KeysData201.Down);
            Assert.Equal(100.5f, io.KeysData201.DownDuration, 5);
            Assert.Equal(50.25f, io.KeysData201.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData201.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 202 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData202_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 101.0f, DownDurationPrev = 50.5f, AnalogValue = 0.75f };
            io.KeysData202 = value;
            Assert.Equal((byte)1, io.KeysData202.Down);
            Assert.Equal(101.0f, io.KeysData202.DownDuration, 5);
            Assert.Equal(50.5f, io.KeysData202.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData202.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 203 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData203_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 101.5f, DownDurationPrev = 50.75f, AnalogValue = 0.75f };
            io.KeysData203 = value;
            Assert.Equal((byte)1, io.KeysData203.Down);
            Assert.Equal(101.5f, io.KeysData203.DownDuration, 5);
            Assert.Equal(50.75f, io.KeysData203.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData203.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 204 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData204_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 102.0f, DownDurationPrev = 51.0f, AnalogValue = 0.75f };
            io.KeysData204 = value;
            Assert.Equal((byte)1, io.KeysData204.Down);
            Assert.Equal(102.0f, io.KeysData204.DownDuration, 5);
            Assert.Equal(51.0f, io.KeysData204.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData204.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 205 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData205_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 102.5f, DownDurationPrev = 51.25f, AnalogValue = 0.75f };
            io.KeysData205 = value;
            Assert.Equal((byte)1, io.KeysData205.Down);
            Assert.Equal(102.5f, io.KeysData205.DownDuration, 5);
            Assert.Equal(51.25f, io.KeysData205.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData205.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 206 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData206_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 103.0f, DownDurationPrev = 51.5f, AnalogValue = 0.75f };
            io.KeysData206 = value;
            Assert.Equal((byte)1, io.KeysData206.Down);
            Assert.Equal(103.0f, io.KeysData206.DownDuration, 5);
            Assert.Equal(51.5f, io.KeysData206.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData206.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 207 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData207_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 103.5f, DownDurationPrev = 51.75f, AnalogValue = 0.75f };
            io.KeysData207 = value;
            Assert.Equal((byte)1, io.KeysData207.Down);
            Assert.Equal(103.5f, io.KeysData207.DownDuration, 5);
            Assert.Equal(51.75f, io.KeysData207.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData207.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 208 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData208_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 104.0f, DownDurationPrev = 52.0f, AnalogValue = 0.75f };
            io.KeysData208 = value;
            Assert.Equal((byte)1, io.KeysData208.Down);
            Assert.Equal(104.0f, io.KeysData208.DownDuration, 5);
            Assert.Equal(52.0f, io.KeysData208.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData208.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 209 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData209_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 104.5f, DownDurationPrev = 52.25f, AnalogValue = 0.75f };
            io.KeysData209 = value;
            Assert.Equal((byte)1, io.KeysData209.Down);
            Assert.Equal(104.5f, io.KeysData209.DownDuration, 5);
            Assert.Equal(52.25f, io.KeysData209.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData209.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 210 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData210_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 105.0f, DownDurationPrev = 52.5f, AnalogValue = 0.75f };
            io.KeysData210 = value;
            Assert.Equal((byte)1, io.KeysData210.Down);
            Assert.Equal(105.0f, io.KeysData210.DownDuration, 5);
            Assert.Equal(52.5f, io.KeysData210.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData210.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 211 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData211_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 105.5f, DownDurationPrev = 52.75f, AnalogValue = 0.75f };
            io.KeysData211 = value;
            Assert.Equal((byte)1, io.KeysData211.Down);
            Assert.Equal(105.5f, io.KeysData211.DownDuration, 5);
            Assert.Equal(52.75f, io.KeysData211.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData211.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 212 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData212_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 106.0f, DownDurationPrev = 53.0f, AnalogValue = 0.75f };
            io.KeysData212 = value;
            Assert.Equal((byte)1, io.KeysData212.Down);
            Assert.Equal(106.0f, io.KeysData212.DownDuration, 5);
            Assert.Equal(53.0f, io.KeysData212.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData212.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 213 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData213_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 106.5f, DownDurationPrev = 53.25f, AnalogValue = 0.75f };
            io.KeysData213 = value;
            Assert.Equal((byte)1, io.KeysData213.Down);
            Assert.Equal(106.5f, io.KeysData213.DownDuration, 5);
            Assert.Equal(53.25f, io.KeysData213.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData213.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 214 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData214_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 107.0f, DownDurationPrev = 53.5f, AnalogValue = 0.75f };
            io.KeysData214 = value;
            Assert.Equal((byte)1, io.KeysData214.Down);
            Assert.Equal(107.0f, io.KeysData214.DownDuration, 5);
            Assert.Equal(53.5f, io.KeysData214.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData214.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 215 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData215_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 107.5f, DownDurationPrev = 53.75f, AnalogValue = 0.75f };
            io.KeysData215 = value;
            Assert.Equal((byte)1, io.KeysData215.Down);
            Assert.Equal(107.5f, io.KeysData215.DownDuration, 5);
            Assert.Equal(53.75f, io.KeysData215.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData215.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 216 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData216_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 108.0f, DownDurationPrev = 54.0f, AnalogValue = 0.75f };
            io.KeysData216 = value;
            Assert.Equal((byte)1, io.KeysData216.Down);
            Assert.Equal(108.0f, io.KeysData216.DownDuration, 5);
            Assert.Equal(54.0f, io.KeysData216.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData216.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 217 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData217_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 108.5f, DownDurationPrev = 54.25f, AnalogValue = 0.75f };
            io.KeysData217 = value;
            Assert.Equal((byte)1, io.KeysData217.Down);
            Assert.Equal(108.5f, io.KeysData217.DownDuration, 5);
            Assert.Equal(54.25f, io.KeysData217.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData217.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 218 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData218_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 109.0f, DownDurationPrev = 54.5f, AnalogValue = 0.75f };
            io.KeysData218 = value;
            Assert.Equal((byte)1, io.KeysData218.Down);
            Assert.Equal(109.0f, io.KeysData218.DownDuration, 5);
            Assert.Equal(54.5f, io.KeysData218.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData218.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 219 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData219_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 109.5f, DownDurationPrev = 54.75f, AnalogValue = 0.75f };
            io.KeysData219 = value;
            Assert.Equal((byte)1, io.KeysData219.Down);
            Assert.Equal(109.5f, io.KeysData219.DownDuration, 5);
            Assert.Equal(54.75f, io.KeysData219.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData219.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 220 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData220_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 110.0f, DownDurationPrev = 55.0f, AnalogValue = 0.75f };
            io.KeysData220 = value;
            Assert.Equal((byte)1, io.KeysData220.Down);
            Assert.Equal(110.0f, io.KeysData220.DownDuration, 5);
            Assert.Equal(55.0f, io.KeysData220.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData220.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 221 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData221_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 110.5f, DownDurationPrev = 55.25f, AnalogValue = 0.75f };
            io.KeysData221 = value;
            Assert.Equal((byte)1, io.KeysData221.Down);
            Assert.Equal(110.5f, io.KeysData221.DownDuration, 5);
            Assert.Equal(55.25f, io.KeysData221.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData221.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 222 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData222_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 111.0f, DownDurationPrev = 55.5f, AnalogValue = 0.75f };
            io.KeysData222 = value;
            Assert.Equal((byte)1, io.KeysData222.Down);
            Assert.Equal(111.0f, io.KeysData222.DownDuration, 5);
            Assert.Equal(55.5f, io.KeysData222.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData222.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 223 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData223_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 111.5f, DownDurationPrev = 55.75f, AnalogValue = 0.75f };
            io.KeysData223 = value;
            Assert.Equal((byte)1, io.KeysData223.Down);
            Assert.Equal(111.5f, io.KeysData223.DownDuration, 5);
            Assert.Equal(55.75f, io.KeysData223.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData223.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 224 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData224_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 112.0f, DownDurationPrev = 56.0f, AnalogValue = 0.75f };
            io.KeysData224 = value;
            Assert.Equal((byte)1, io.KeysData224.Down);
            Assert.Equal(112.0f, io.KeysData224.DownDuration, 5);
            Assert.Equal(56.0f, io.KeysData224.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData224.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 225 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData225_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 112.5f, DownDurationPrev = 56.25f, AnalogValue = 0.75f };
            io.KeysData225 = value;
            Assert.Equal((byte)1, io.KeysData225.Down);
            Assert.Equal(112.5f, io.KeysData225.DownDuration, 5);
            Assert.Equal(56.25f, io.KeysData225.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData225.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 226 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData226_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 113.0f, DownDurationPrev = 56.5f, AnalogValue = 0.75f };
            io.KeysData226 = value;
            Assert.Equal((byte)1, io.KeysData226.Down);
            Assert.Equal(113.0f, io.KeysData226.DownDuration, 5);
            Assert.Equal(56.5f, io.KeysData226.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData226.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 227 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData227_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 113.5f, DownDurationPrev = 56.75f, AnalogValue = 0.75f };
            io.KeysData227 = value;
            Assert.Equal((byte)1, io.KeysData227.Down);
            Assert.Equal(113.5f, io.KeysData227.DownDuration, 5);
            Assert.Equal(56.75f, io.KeysData227.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData227.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 228 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData228_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 114.0f, DownDurationPrev = 57.0f, AnalogValue = 0.75f };
            io.KeysData228 = value;
            Assert.Equal((byte)1, io.KeysData228.Down);
            Assert.Equal(114.0f, io.KeysData228.DownDuration, 5);
            Assert.Equal(57.0f, io.KeysData228.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData228.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 229 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData229_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 114.5f, DownDurationPrev = 57.25f, AnalogValue = 0.75f };
            io.KeysData229 = value;
            Assert.Equal((byte)1, io.KeysData229.Down);
            Assert.Equal(114.5f, io.KeysData229.DownDuration, 5);
            Assert.Equal(57.25f, io.KeysData229.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData229.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 230 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData230_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 115.0f, DownDurationPrev = 57.5f, AnalogValue = 0.75f };
            io.KeysData230 = value;
            Assert.Equal((byte)1, io.KeysData230.Down);
            Assert.Equal(115.0f, io.KeysData230.DownDuration, 5);
            Assert.Equal(57.5f, io.KeysData230.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData230.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 231 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData231_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 115.5f, DownDurationPrev = 57.75f, AnalogValue = 0.75f };
            io.KeysData231 = value;
            Assert.Equal((byte)1, io.KeysData231.Down);
            Assert.Equal(115.5f, io.KeysData231.DownDuration, 5);
            Assert.Equal(57.75f, io.KeysData231.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData231.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 232 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData232_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 116.0f, DownDurationPrev = 58.0f, AnalogValue = 0.75f };
            io.KeysData232 = value;
            Assert.Equal((byte)1, io.KeysData232.Down);
            Assert.Equal(116.0f, io.KeysData232.DownDuration, 5);
            Assert.Equal(58.0f, io.KeysData232.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData232.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 233 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData233_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 116.5f, DownDurationPrev = 58.25f, AnalogValue = 0.75f };
            io.KeysData233 = value;
            Assert.Equal((byte)1, io.KeysData233.Down);
            Assert.Equal(116.5f, io.KeysData233.DownDuration, 5);
            Assert.Equal(58.25f, io.KeysData233.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData233.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 234 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData234_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 117.0f, DownDurationPrev = 58.5f, AnalogValue = 0.75f };
            io.KeysData234 = value;
            Assert.Equal((byte)1, io.KeysData234.Down);
            Assert.Equal(117.0f, io.KeysData234.DownDuration, 5);
            Assert.Equal(58.5f, io.KeysData234.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData234.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 235 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData235_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 117.5f, DownDurationPrev = 58.75f, AnalogValue = 0.75f };
            io.KeysData235 = value;
            Assert.Equal((byte)1, io.KeysData235.Down);
            Assert.Equal(117.5f, io.KeysData235.DownDuration, 5);
            Assert.Equal(58.75f, io.KeysData235.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData235.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 236 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData236_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 118.0f, DownDurationPrev = 59.0f, AnalogValue = 0.75f };
            io.KeysData236 = value;
            Assert.Equal((byte)1, io.KeysData236.Down);
            Assert.Equal(118.0f, io.KeysData236.DownDuration, 5);
            Assert.Equal(59.0f, io.KeysData236.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData236.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 237 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData237_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 118.5f, DownDurationPrev = 59.25f, AnalogValue = 0.75f };
            io.KeysData237 = value;
            Assert.Equal((byte)1, io.KeysData237.Down);
            Assert.Equal(118.5f, io.KeysData237.DownDuration, 5);
            Assert.Equal(59.25f, io.KeysData237.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData237.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 238 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData238_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 119.0f, DownDurationPrev = 59.5f, AnalogValue = 0.75f };
            io.KeysData238 = value;
            Assert.Equal((byte)1, io.KeysData238.Down);
            Assert.Equal(119.0f, io.KeysData238.DownDuration, 5);
            Assert.Equal(59.5f, io.KeysData238.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData238.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 239 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData239_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 119.5f, DownDurationPrev = 59.75f, AnalogValue = 0.75f };
            io.KeysData239 = value;
            Assert.Equal((byte)1, io.KeysData239.Down);
            Assert.Equal(119.5f, io.KeysData239.DownDuration, 5);
            Assert.Equal(59.75f, io.KeysData239.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData239.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 240 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData240_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 120.0f, DownDurationPrev = 60.0f, AnalogValue = 0.75f };
            io.KeysData240 = value;
            Assert.Equal((byte)1, io.KeysData240.Down);
            Assert.Equal(120.0f, io.KeysData240.DownDuration, 5);
            Assert.Equal(60.0f, io.KeysData240.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData240.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 241 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData241_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 120.5f, DownDurationPrev = 60.25f, AnalogValue = 0.75f };
            io.KeysData241 = value;
            Assert.Equal((byte)1, io.KeysData241.Down);
            Assert.Equal(120.5f, io.KeysData241.DownDuration, 5);
            Assert.Equal(60.25f, io.KeysData241.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData241.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 242 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData242_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 121.0f, DownDurationPrev = 60.5f, AnalogValue = 0.75f };
            io.KeysData242 = value;
            Assert.Equal((byte)1, io.KeysData242.Down);
            Assert.Equal(121.0f, io.KeysData242.DownDuration, 5);
            Assert.Equal(60.5f, io.KeysData242.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData242.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 243 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData243_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 121.5f, DownDurationPrev = 60.75f, AnalogValue = 0.75f };
            io.KeysData243 = value;
            Assert.Equal((byte)1, io.KeysData243.Down);
            Assert.Equal(121.5f, io.KeysData243.DownDuration, 5);
            Assert.Equal(60.75f, io.KeysData243.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData243.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 244 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData244_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 122.0f, DownDurationPrev = 61.0f, AnalogValue = 0.75f };
            io.KeysData244 = value;
            Assert.Equal((byte)1, io.KeysData244.Down);
            Assert.Equal(122.0f, io.KeysData244.DownDuration, 5);
            Assert.Equal(61.0f, io.KeysData244.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData244.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 245 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData245_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 122.5f, DownDurationPrev = 61.25f, AnalogValue = 0.75f };
            io.KeysData245 = value;
            Assert.Equal((byte)1, io.KeysData245.Down);
            Assert.Equal(122.5f, io.KeysData245.DownDuration, 5);
            Assert.Equal(61.25f, io.KeysData245.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData245.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 246 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData246_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 123.0f, DownDurationPrev = 61.5f, AnalogValue = 0.75f };
            io.KeysData246 = value;
            Assert.Equal((byte)1, io.KeysData246.Down);
            Assert.Equal(123.0f, io.KeysData246.DownDuration, 5);
            Assert.Equal(61.5f, io.KeysData246.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData246.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 247 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData247_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 123.5f, DownDurationPrev = 61.75f, AnalogValue = 0.75f };
            io.KeysData247 = value;
            Assert.Equal((byte)1, io.KeysData247.Down);
            Assert.Equal(123.5f, io.KeysData247.DownDuration, 5);
            Assert.Equal(61.75f, io.KeysData247.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData247.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 248 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData248_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 124.0f, DownDurationPrev = 62.0f, AnalogValue = 0.75f };
            io.KeysData248 = value;
            Assert.Equal((byte)1, io.KeysData248.Down);
            Assert.Equal(124.0f, io.KeysData248.DownDuration, 5);
            Assert.Equal(62.0f, io.KeysData248.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData248.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 249 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData249_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 124.5f, DownDurationPrev = 62.25f, AnalogValue = 0.75f };
            io.KeysData249 = value;
            Assert.Equal((byte)1, io.KeysData249.Down);
            Assert.Equal(124.5f, io.KeysData249.DownDuration, 5);
            Assert.Equal(62.25f, io.KeysData249.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData249.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 250 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData250_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 125.0f, DownDurationPrev = 62.5f, AnalogValue = 0.75f };
            io.KeysData250 = value;
            Assert.Equal((byte)1, io.KeysData250.Down);
            Assert.Equal(125.0f, io.KeysData250.DownDuration, 5);
            Assert.Equal(62.5f, io.KeysData250.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData250.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 251 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData251_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 125.5f, DownDurationPrev = 62.75f, AnalogValue = 0.75f };
            io.KeysData251 = value;
            Assert.Equal((byte)1, io.KeysData251.Down);
            Assert.Equal(125.5f, io.KeysData251.DownDuration, 5);
            Assert.Equal(62.75f, io.KeysData251.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData251.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 252 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData252_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 126.0f, DownDurationPrev = 63.0f, AnalogValue = 0.75f };
            io.KeysData252 = value;
            Assert.Equal((byte)1, io.KeysData252.Down);
            Assert.Equal(126.0f, io.KeysData252.DownDuration, 5);
            Assert.Equal(63.0f, io.KeysData252.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData252.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 253 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData253_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 126.5f, DownDurationPrev = 63.25f, AnalogValue = 0.75f };
            io.KeysData253 = value;
            Assert.Equal((byte)1, io.KeysData253.Down);
            Assert.Equal(126.5f, io.KeysData253.DownDuration, 5);
            Assert.Equal(63.25f, io.KeysData253.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData253.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 254 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData254_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 127.0f, DownDurationPrev = 63.5f, AnalogValue = 0.75f };
            io.KeysData254 = value;
            Assert.Equal((byte)1, io.KeysData254.Down);
            Assert.Equal(127.0f, io.KeysData254.DownDuration, 5);
            Assert.Equal(63.5f, io.KeysData254.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData254.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 255 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData255_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 127.5f, DownDurationPrev = 63.75f, AnalogValue = 0.75f };
            io.KeysData255 = value;
            Assert.Equal((byte)1, io.KeysData255.Down);
            Assert.Equal(127.5f, io.KeysData255.DownDuration, 5);
            Assert.Equal(63.75f, io.KeysData255.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData255.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 256 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData256_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 128.0f, DownDurationPrev = 64.0f, AnalogValue = 0.75f };
            io.KeysData256 = value;
            Assert.Equal((byte)1, io.KeysData256.Down);
            Assert.Equal(128.0f, io.KeysData256.DownDuration, 5);
            Assert.Equal(64.0f, io.KeysData256.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData256.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 257 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData257_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 128.5f, DownDurationPrev = 64.25f, AnalogValue = 0.75f };
            io.KeysData257 = value;
            Assert.Equal((byte)1, io.KeysData257.Down);
            Assert.Equal(128.5f, io.KeysData257.DownDuration, 5);
            Assert.Equal(64.25f, io.KeysData257.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData257.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 258 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData258_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 129.0f, DownDurationPrev = 64.5f, AnalogValue = 0.75f };
            io.KeysData258 = value;
            Assert.Equal((byte)1, io.KeysData258.Down);
            Assert.Equal(129.0f, io.KeysData258.DownDuration, 5);
            Assert.Equal(64.5f, io.KeysData258.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData258.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 259 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData259_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 129.5f, DownDurationPrev = 64.75f, AnalogValue = 0.75f };
            io.KeysData259 = value;
            Assert.Equal((byte)1, io.KeysData259.Down);
            Assert.Equal(129.5f, io.KeysData259.DownDuration, 5);
            Assert.Equal(64.75f, io.KeysData259.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData259.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 260 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData260_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 130.0f, DownDurationPrev = 65.0f, AnalogValue = 0.75f };
            io.KeysData260 = value;
            Assert.Equal((byte)1, io.KeysData260.Down);
            Assert.Equal(130.0f, io.KeysData260.DownDuration, 5);
            Assert.Equal(65.0f, io.KeysData260.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData260.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 261 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData261_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 130.5f, DownDurationPrev = 65.25f, AnalogValue = 0.75f };
            io.KeysData261 = value;
            Assert.Equal((byte)1, io.KeysData261.Down);
            Assert.Equal(130.5f, io.KeysData261.DownDuration, 5);
            Assert.Equal(65.25f, io.KeysData261.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData261.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 262 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData262_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 131.0f, DownDurationPrev = 65.5f, AnalogValue = 0.75f };
            io.KeysData262 = value;
            Assert.Equal((byte)1, io.KeysData262.Down);
            Assert.Equal(131.0f, io.KeysData262.DownDuration, 5);
            Assert.Equal(65.5f, io.KeysData262.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData262.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 263 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData263_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 131.5f, DownDurationPrev = 65.75f, AnalogValue = 0.75f };
            io.KeysData263 = value;
            Assert.Equal((byte)1, io.KeysData263.Down);
            Assert.Equal(131.5f, io.KeysData263.DownDuration, 5);
            Assert.Equal(65.75f, io.KeysData263.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData263.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 264 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData264_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 132.0f, DownDurationPrev = 66.0f, AnalogValue = 0.75f };
            io.KeysData264 = value;
            Assert.Equal((byte)1, io.KeysData264.Down);
            Assert.Equal(132.0f, io.KeysData264.DownDuration, 5);
            Assert.Equal(66.0f, io.KeysData264.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData264.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 265 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData265_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 132.5f, DownDurationPrev = 66.25f, AnalogValue = 0.75f };
            io.KeysData265 = value;
            Assert.Equal((byte)1, io.KeysData265.Down);
            Assert.Equal(132.5f, io.KeysData265.DownDuration, 5);
            Assert.Equal(66.25f, io.KeysData265.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData265.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 266 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData266_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 133.0f, DownDurationPrev = 66.5f, AnalogValue = 0.75f };
            io.KeysData266 = value;
            Assert.Equal((byte)1, io.KeysData266.Down);
            Assert.Equal(133.0f, io.KeysData266.DownDuration, 5);
            Assert.Equal(66.5f, io.KeysData266.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData266.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 267 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData267_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 133.5f, DownDurationPrev = 66.75f, AnalogValue = 0.75f };
            io.KeysData267 = value;
            Assert.Equal((byte)1, io.KeysData267.Down);
            Assert.Equal(133.5f, io.KeysData267.DownDuration, 5);
            Assert.Equal(66.75f, io.KeysData267.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData267.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 268 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData268_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 134.0f, DownDurationPrev = 67.0f, AnalogValue = 0.75f };
            io.KeysData268 = value;
            Assert.Equal((byte)1, io.KeysData268.Down);
            Assert.Equal(134.0f, io.KeysData268.DownDuration, 5);
            Assert.Equal(67.0f, io.KeysData268.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData268.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 269 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData269_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 134.5f, DownDurationPrev = 67.25f, AnalogValue = 0.75f };
            io.KeysData269 = value;
            Assert.Equal((byte)1, io.KeysData269.Down);
            Assert.Equal(134.5f, io.KeysData269.DownDuration, 5);
            Assert.Equal(67.25f, io.KeysData269.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData269.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 270 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData270_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 135.0f, DownDurationPrev = 67.5f, AnalogValue = 0.75f };
            io.KeysData270 = value;
            Assert.Equal((byte)1, io.KeysData270.Down);
            Assert.Equal(135.0f, io.KeysData270.DownDuration, 5);
            Assert.Equal(67.5f, io.KeysData270.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData270.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 271 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData271_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 135.5f, DownDurationPrev = 67.75f, AnalogValue = 0.75f };
            io.KeysData271 = value;
            Assert.Equal((byte)1, io.KeysData271.Down);
            Assert.Equal(135.5f, io.KeysData271.DownDuration, 5);
            Assert.Equal(67.75f, io.KeysData271.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData271.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 272 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData272_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 136.0f, DownDurationPrev = 68.0f, AnalogValue = 0.75f };
            io.KeysData272 = value;
            Assert.Equal((byte)1, io.KeysData272.Down);
            Assert.Equal(136.0f, io.KeysData272.DownDuration, 5);
            Assert.Equal(68.0f, io.KeysData272.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData272.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 273 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData273_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 136.5f, DownDurationPrev = 68.25f, AnalogValue = 0.75f };
            io.KeysData273 = value;
            Assert.Equal((byte)1, io.KeysData273.Down);
            Assert.Equal(136.5f, io.KeysData273.DownDuration, 5);
            Assert.Equal(68.25f, io.KeysData273.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData273.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 274 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData274_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 137.0f, DownDurationPrev = 68.5f, AnalogValue = 0.75f };
            io.KeysData274 = value;
            Assert.Equal((byte)1, io.KeysData274.Down);
            Assert.Equal(137.0f, io.KeysData274.DownDuration, 5);
            Assert.Equal(68.5f, io.KeysData274.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData274.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 275 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData275_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 137.5f, DownDurationPrev = 68.75f, AnalogValue = 0.75f };
            io.KeysData275 = value;
            Assert.Equal((byte)1, io.KeysData275.Down);
            Assert.Equal(137.5f, io.KeysData275.DownDuration, 5);
            Assert.Equal(68.75f, io.KeysData275.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData275.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 276 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData276_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 138.0f, DownDurationPrev = 69.0f, AnalogValue = 0.75f };
            io.KeysData276 = value;
            Assert.Equal((byte)1, io.KeysData276.Down);
            Assert.Equal(138.0f, io.KeysData276.DownDuration, 5);
            Assert.Equal(69.0f, io.KeysData276.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData276.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 277 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData277_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 138.5f, DownDurationPrev = 69.25f, AnalogValue = 0.75f };
            io.KeysData277 = value;
            Assert.Equal((byte)1, io.KeysData277.Down);
            Assert.Equal(138.5f, io.KeysData277.DownDuration, 5);
            Assert.Equal(69.25f, io.KeysData277.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData277.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 278 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData278_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 139.0f, DownDurationPrev = 69.5f, AnalogValue = 0.75f };
            io.KeysData278 = value;
            Assert.Equal((byte)1, io.KeysData278.Down);
            Assert.Equal(139.0f, io.KeysData278.DownDuration, 5);
            Assert.Equal(69.5f, io.KeysData278.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData278.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 279 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData279_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 139.5f, DownDurationPrev = 69.75f, AnalogValue = 0.75f };
            io.KeysData279 = value;
            Assert.Equal((byte)1, io.KeysData279.Down);
            Assert.Equal(139.5f, io.KeysData279.DownDuration, 5);
            Assert.Equal(69.75f, io.KeysData279.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData279.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 280 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData280_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 140.0f, DownDurationPrev = 70.0f, AnalogValue = 0.75f };
            io.KeysData280 = value;
            Assert.Equal((byte)1, io.KeysData280.Down);
            Assert.Equal(140.0f, io.KeysData280.DownDuration, 5);
            Assert.Equal(70.0f, io.KeysData280.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData280.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 281 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData281_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 140.5f, DownDurationPrev = 70.25f, AnalogValue = 0.75f };
            io.KeysData281 = value;
            Assert.Equal((byte)1, io.KeysData281.Down);
            Assert.Equal(140.5f, io.KeysData281.DownDuration, 5);
            Assert.Equal(70.25f, io.KeysData281.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData281.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 282 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData282_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 141.0f, DownDurationPrev = 70.5f, AnalogValue = 0.75f };
            io.KeysData282 = value;
            Assert.Equal((byte)1, io.KeysData282.Down);
            Assert.Equal(141.0f, io.KeysData282.DownDuration, 5);
            Assert.Equal(70.5f, io.KeysData282.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData282.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 283 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData283_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 141.5f, DownDurationPrev = 70.75f, AnalogValue = 0.75f };
            io.KeysData283 = value;
            Assert.Equal((byte)1, io.KeysData283.Down);
            Assert.Equal(141.5f, io.KeysData283.DownDuration, 5);
            Assert.Equal(70.75f, io.KeysData283.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData283.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 284 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData284_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 142.0f, DownDurationPrev = 71.0f, AnalogValue = 0.75f };
            io.KeysData284 = value;
            Assert.Equal((byte)1, io.KeysData284.Down);
            Assert.Equal(142.0f, io.KeysData284.DownDuration, 5);
            Assert.Equal(71.0f, io.KeysData284.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData284.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 285 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData285_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 142.5f, DownDurationPrev = 71.25f, AnalogValue = 0.75f };
            io.KeysData285 = value;
            Assert.Equal((byte)1, io.KeysData285.Down);
            Assert.Equal(142.5f, io.KeysData285.DownDuration, 5);
            Assert.Equal(71.25f, io.KeysData285.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData285.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 286 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData286_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 143.0f, DownDurationPrev = 71.5f, AnalogValue = 0.75f };
            io.KeysData286 = value;
            Assert.Equal((byte)1, io.KeysData286.Down);
            Assert.Equal(143.0f, io.KeysData286.DownDuration, 5);
            Assert.Equal(71.5f, io.KeysData286.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData286.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 287 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData287_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 143.5f, DownDurationPrev = 71.75f, AnalogValue = 0.75f };
            io.KeysData287 = value;
            Assert.Equal((byte)1, io.KeysData287.Down);
            Assert.Equal(143.5f, io.KeysData287.DownDuration, 5);
            Assert.Equal(71.75f, io.KeysData287.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData287.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 288 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData288_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 144.0f, DownDurationPrev = 72.0f, AnalogValue = 0.75f };
            io.KeysData288 = value;
            Assert.Equal((byte)1, io.KeysData288.Down);
            Assert.Equal(144.0f, io.KeysData288.DownDuration, 5);
            Assert.Equal(72.0f, io.KeysData288.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData288.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 289 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData289_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 144.5f, DownDurationPrev = 72.25f, AnalogValue = 0.75f };
            io.KeysData289 = value;
            Assert.Equal((byte)1, io.KeysData289.Down);
            Assert.Equal(144.5f, io.KeysData289.DownDuration, 5);
            Assert.Equal(72.25f, io.KeysData289.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData289.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 290 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData290_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 145.0f, DownDurationPrev = 72.5f, AnalogValue = 0.75f };
            io.KeysData290 = value;
            Assert.Equal((byte)1, io.KeysData290.Down);
            Assert.Equal(145.0f, io.KeysData290.DownDuration, 5);
            Assert.Equal(72.5f, io.KeysData290.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData290.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 291 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData291_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 145.5f, DownDurationPrev = 72.75f, AnalogValue = 0.75f };
            io.KeysData291 = value;
            Assert.Equal((byte)1, io.KeysData291.Down);
            Assert.Equal(145.5f, io.KeysData291.DownDuration, 5);
            Assert.Equal(72.75f, io.KeysData291.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData291.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 292 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData292_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 146.0f, DownDurationPrev = 73.0f, AnalogValue = 0.75f };
            io.KeysData292 = value;
            Assert.Equal((byte)1, io.KeysData292.Down);
            Assert.Equal(146.0f, io.KeysData292.DownDuration, 5);
            Assert.Equal(73.0f, io.KeysData292.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData292.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 293 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData293_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 146.5f, DownDurationPrev = 73.25f, AnalogValue = 0.75f };
            io.KeysData293 = value;
            Assert.Equal((byte)1, io.KeysData293.Down);
            Assert.Equal(146.5f, io.KeysData293.DownDuration, 5);
            Assert.Equal(73.25f, io.KeysData293.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData293.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 296 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData296_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 148.0f, DownDurationPrev = 74.0f, AnalogValue = 0.75f };
            io.KeysData296 = value;
            Assert.Equal((byte)1, io.KeysData296.Down);
            Assert.Equal(148.0f, io.KeysData296.DownDuration, 5);
            Assert.Equal(74.0f, io.KeysData296.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData296.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 297 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData297_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 148.5f, DownDurationPrev = 74.25f, AnalogValue = 0.75f };
            io.KeysData297 = value;
            Assert.Equal((byte)1, io.KeysData297.Down);
            Assert.Equal(148.5f, io.KeysData297.DownDuration, 5);
            Assert.Equal(74.25f, io.KeysData297.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData297.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 298 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData298_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 149.0f, DownDurationPrev = 74.5f, AnalogValue = 0.75f };
            io.KeysData298 = value;
            Assert.Equal((byte)1, io.KeysData298.Down);
            Assert.Equal(149.0f, io.KeysData298.DownDuration, 5);
            Assert.Equal(74.5f, io.KeysData298.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData298.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 299 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData299_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 149.5f, DownDurationPrev = 74.75f, AnalogValue = 0.75f };
            io.KeysData299 = value;
            Assert.Equal((byte)1, io.KeysData299.Down);
            Assert.Equal(149.5f, io.KeysData299.DownDuration, 5);
            Assert.Equal(74.75f, io.KeysData299.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData299.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 300 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData300_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 150.0f, DownDurationPrev = 75.0f, AnalogValue = 0.75f };
            io.KeysData300 = value;
            Assert.Equal((byte)1, io.KeysData300.Down);
            Assert.Equal(150.0f, io.KeysData300.DownDuration, 5);
            Assert.Equal(75.0f, io.KeysData300.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData300.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 301 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData301_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 150.5f, DownDurationPrev = 75.25f, AnalogValue = 0.75f };
            io.KeysData301 = value;
            Assert.Equal((byte)1, io.KeysData301.Down);
            Assert.Equal(150.5f, io.KeysData301.DownDuration, 5);
            Assert.Equal(75.25f, io.KeysData301.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData301.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 302 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData302_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 151.0f, DownDurationPrev = 75.5f, AnalogValue = 0.75f };
            io.KeysData302 = value;
            Assert.Equal((byte)1, io.KeysData302.Down);
            Assert.Equal(151.0f, io.KeysData302.DownDuration, 5);
            Assert.Equal(75.5f, io.KeysData302.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData302.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 303 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData303_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 151.5f, DownDurationPrev = 75.75f, AnalogValue = 0.75f };
            io.KeysData303 = value;
            Assert.Equal((byte)1, io.KeysData303.Down);
            Assert.Equal(151.5f, io.KeysData303.DownDuration, 5);
            Assert.Equal(75.75f, io.KeysData303.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData303.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 304 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData304_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 152.0f, DownDurationPrev = 76.0f, AnalogValue = 0.75f };
            io.KeysData304 = value;
            Assert.Equal((byte)1, io.KeysData304.Down);
            Assert.Equal(152.0f, io.KeysData304.DownDuration, 5);
            Assert.Equal(76.0f, io.KeysData304.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData304.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 305 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData305_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 152.5f, DownDurationPrev = 76.25f, AnalogValue = 0.75f };
            io.KeysData305 = value;
            Assert.Equal((byte)1, io.KeysData305.Down);
            Assert.Equal(152.5f, io.KeysData305.DownDuration, 5);
            Assert.Equal(76.25f, io.KeysData305.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData305.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 306 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData306_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 153.0f, DownDurationPrev = 76.5f, AnalogValue = 0.75f };
            io.KeysData306 = value;
            Assert.Equal((byte)1, io.KeysData306.Down);
            Assert.Equal(153.0f, io.KeysData306.DownDuration, 5);
            Assert.Equal(76.5f, io.KeysData306.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData306.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 307 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData307_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 153.5f, DownDurationPrev = 76.75f, AnalogValue = 0.75f };
            io.KeysData307 = value;
            Assert.Equal((byte)1, io.KeysData307.Down);
            Assert.Equal(153.5f, io.KeysData307.DownDuration, 5);
            Assert.Equal(76.75f, io.KeysData307.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData307.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 308 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData308_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 154.0f, DownDurationPrev = 77.0f, AnalogValue = 0.75f };
            io.KeysData308 = value;
            Assert.Equal((byte)1, io.KeysData308.Down);
            Assert.Equal(154.0f, io.KeysData308.DownDuration, 5);
            Assert.Equal(77.0f, io.KeysData308.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData308.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 309 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData309_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 154.5f, DownDurationPrev = 77.25f, AnalogValue = 0.75f };
            io.KeysData309 = value;
            Assert.Equal((byte)1, io.KeysData309.Down);
            Assert.Equal(154.5f, io.KeysData309.DownDuration, 5);
            Assert.Equal(77.25f, io.KeysData309.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData309.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 310 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData310_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 155.0f, DownDurationPrev = 77.5f, AnalogValue = 0.75f };
            io.KeysData310 = value;
            Assert.Equal((byte)1, io.KeysData310.Down);
            Assert.Equal(155.0f, io.KeysData310.DownDuration, 5);
            Assert.Equal(77.5f, io.KeysData310.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData310.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 311 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData311_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 155.5f, DownDurationPrev = 77.75f, AnalogValue = 0.75f };
            io.KeysData311 = value;
            Assert.Equal((byte)1, io.KeysData311.Down);
            Assert.Equal(155.5f, io.KeysData311.DownDuration, 5);
            Assert.Equal(77.75f, io.KeysData311.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData311.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 312 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData312_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 156.0f, DownDurationPrev = 78.0f, AnalogValue = 0.75f };
            io.KeysData312 = value;
            Assert.Equal((byte)1, io.KeysData312.Down);
            Assert.Equal(156.0f, io.KeysData312.DownDuration, 5);
            Assert.Equal(78.0f, io.KeysData312.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData312.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 313 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData313_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 156.5f, DownDurationPrev = 78.25f, AnalogValue = 0.75f };
            io.KeysData313 = value;
            Assert.Equal((byte)1, io.KeysData313.Down);
            Assert.Equal(156.5f, io.KeysData313.DownDuration, 5);
            Assert.Equal(78.25f, io.KeysData313.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData313.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 314 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData314_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 157.0f, DownDurationPrev = 78.5f, AnalogValue = 0.75f };
            io.KeysData314 = value;
            Assert.Equal((byte)1, io.KeysData314.Down);
            Assert.Equal(157.0f, io.KeysData314.DownDuration, 5);
            Assert.Equal(78.5f, io.KeysData314.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData314.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 315 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData315_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 157.5f, DownDurationPrev = 78.75f, AnalogValue = 0.75f };
            io.KeysData315 = value;
            Assert.Equal((byte)1, io.KeysData315.Down);
            Assert.Equal(157.5f, io.KeysData315.DownDuration, 5);
            Assert.Equal(78.75f, io.KeysData315.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData315.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 316 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData316_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 158.0f, DownDurationPrev = 79.0f, AnalogValue = 0.75f };
            io.KeysData316 = value;
            Assert.Equal((byte)1, io.KeysData316.Down);
            Assert.Equal(158.0f, io.KeysData316.DownDuration, 5);
            Assert.Equal(79.0f, io.KeysData316.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData316.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 317 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData317_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 158.5f, DownDurationPrev = 79.25f, AnalogValue = 0.75f };
            io.KeysData317 = value;
            Assert.Equal((byte)1, io.KeysData317.Down);
            Assert.Equal(158.5f, io.KeysData317.DownDuration, 5);
            Assert.Equal(79.25f, io.KeysData317.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData317.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 318 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData318_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 159.0f, DownDurationPrev = 79.5f, AnalogValue = 0.75f };
            io.KeysData318 = value;
            Assert.Equal((byte)1, io.KeysData318.Down);
            Assert.Equal(159.0f, io.KeysData318.DownDuration, 5);
            Assert.Equal(79.5f, io.KeysData318.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData318.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 319 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData319_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 159.5f, DownDurationPrev = 79.75f, AnalogValue = 0.75f };
            io.KeysData319 = value;
            Assert.Equal((byte)1, io.KeysData319.Down);
            Assert.Equal(159.5f, io.KeysData319.DownDuration, 5);
            Assert.Equal(79.75f, io.KeysData319.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData319.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 320 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData320_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 160.0f, DownDurationPrev = 80.0f, AnalogValue = 0.75f };
            io.KeysData320 = value;
            Assert.Equal((byte)1, io.KeysData320.Down);
            Assert.Equal(160.0f, io.KeysData320.DownDuration, 5);
            Assert.Equal(80.0f, io.KeysData320.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData320.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 321 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData321_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 160.5f, DownDurationPrev = 80.25f, AnalogValue = 0.75f };
            io.KeysData321 = value;
            Assert.Equal((byte)1, io.KeysData321.Down);
            Assert.Equal(160.5f, io.KeysData321.DownDuration, 5);
            Assert.Equal(80.25f, io.KeysData321.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData321.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 322 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData322_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 161.0f, DownDurationPrev = 80.5f, AnalogValue = 0.75f };
            io.KeysData322 = value;
            Assert.Equal((byte)1, io.KeysData322.Down);
            Assert.Equal(161.0f, io.KeysData322.DownDuration, 5);
            Assert.Equal(80.5f, io.KeysData322.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData322.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 323 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData323_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 161.5f, DownDurationPrev = 80.75f, AnalogValue = 0.75f };
            io.KeysData323 = value;
            Assert.Equal((byte)1, io.KeysData323.Down);
            Assert.Equal(161.5f, io.KeysData323.DownDuration, 5);
            Assert.Equal(80.75f, io.KeysData323.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData323.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 324 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData324_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 162.0f, DownDurationPrev = 81.0f, AnalogValue = 0.75f };
            io.KeysData324 = value;
            Assert.Equal((byte)1, io.KeysData324.Down);
            Assert.Equal(162.0f, io.KeysData324.DownDuration, 5);
            Assert.Equal(81.0f, io.KeysData324.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData324.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 325 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData325_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 162.5f, DownDurationPrev = 81.25f, AnalogValue = 0.75f };
            io.KeysData325 = value;
            Assert.Equal((byte)1, io.KeysData325.Down);
            Assert.Equal(162.5f, io.KeysData325.DownDuration, 5);
            Assert.Equal(81.25f, io.KeysData325.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData325.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 326 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData326_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 163.0f, DownDurationPrev = 81.5f, AnalogValue = 0.75f };
            io.KeysData326 = value;
            Assert.Equal((byte)1, io.KeysData326.Down);
            Assert.Equal(163.0f, io.KeysData326.DownDuration, 5);
            Assert.Equal(81.5f, io.KeysData326.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData326.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 327 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData327_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 163.5f, DownDurationPrev = 81.75f, AnalogValue = 0.75f };
            io.KeysData327 = value;
            Assert.Equal((byte)1, io.KeysData327.Down);
            Assert.Equal(163.5f, io.KeysData327.DownDuration, 5);
            Assert.Equal(81.75f, io.KeysData327.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData327.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 328 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData328_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 164.0f, DownDurationPrev = 82.0f, AnalogValue = 0.75f };
            io.KeysData328 = value;
            Assert.Equal((byte)1, io.KeysData328.Down);
            Assert.Equal(164.0f, io.KeysData328.DownDuration, 5);
            Assert.Equal(82.0f, io.KeysData328.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData328.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 329 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData329_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 164.5f, DownDurationPrev = 82.25f, AnalogValue = 0.75f };
            io.KeysData329 = value;
            Assert.Equal((byte)1, io.KeysData329.Down);
            Assert.Equal(164.5f, io.KeysData329.DownDuration, 5);
            Assert.Equal(82.25f, io.KeysData329.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData329.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 330 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData330_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 165.0f, DownDurationPrev = 82.5f, AnalogValue = 0.75f };
            io.KeysData330 = value;
            Assert.Equal((byte)1, io.KeysData330.Down);
            Assert.Equal(165.0f, io.KeysData330.DownDuration, 5);
            Assert.Equal(82.5f, io.KeysData330.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData330.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 331 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData331_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 165.5f, DownDurationPrev = 82.75f, AnalogValue = 0.75f };
            io.KeysData331 = value;
            Assert.Equal((byte)1, io.KeysData331.Down);
            Assert.Equal(165.5f, io.KeysData331.DownDuration, 5);
            Assert.Equal(82.75f, io.KeysData331.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData331.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 332 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData332_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 166.0f, DownDurationPrev = 83.0f, AnalogValue = 0.75f };
            io.KeysData332 = value;
            Assert.Equal((byte)1, io.KeysData332.Down);
            Assert.Equal(166.0f, io.KeysData332.DownDuration, 5);
            Assert.Equal(83.0f, io.KeysData332.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData332.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 333 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData333_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 166.5f, DownDurationPrev = 83.25f, AnalogValue = 0.75f };
            io.KeysData333 = value;
            Assert.Equal((byte)1, io.KeysData333.Down);
            Assert.Equal(166.5f, io.KeysData333.DownDuration, 5);
            Assert.Equal(83.25f, io.KeysData333.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData333.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 334 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData334_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 167.0f, DownDurationPrev = 83.5f, AnalogValue = 0.75f };
            io.KeysData334 = value;
            Assert.Equal((byte)1, io.KeysData334.Down);
            Assert.Equal(167.0f, io.KeysData334.DownDuration, 5);
            Assert.Equal(83.5f, io.KeysData334.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData334.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 335 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData335_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 167.5f, DownDurationPrev = 83.75f, AnalogValue = 0.75f };
            io.KeysData335 = value;
            Assert.Equal((byte)1, io.KeysData335.Down);
            Assert.Equal(167.5f, io.KeysData335.DownDuration, 5);
            Assert.Equal(83.75f, io.KeysData335.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData335.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 336 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData336_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 168.0f, DownDurationPrev = 84.0f, AnalogValue = 0.75f };
            io.KeysData336 = value;
            Assert.Equal((byte)1, io.KeysData336.Down);
            Assert.Equal(168.0f, io.KeysData336.DownDuration, 5);
            Assert.Equal(84.0f, io.KeysData336.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData336.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 337 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData337_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 168.5f, DownDurationPrev = 84.25f, AnalogValue = 0.75f };
            io.KeysData337 = value;
            Assert.Equal((byte)1, io.KeysData337.Down);
            Assert.Equal(168.5f, io.KeysData337.DownDuration, 5);
            Assert.Equal(84.25f, io.KeysData337.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData337.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 338 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData338_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 169.0f, DownDurationPrev = 84.5f, AnalogValue = 0.75f };
            io.KeysData338 = value;
            Assert.Equal((byte)1, io.KeysData338.Down);
            Assert.Equal(169.0f, io.KeysData338.DownDuration, 5);
            Assert.Equal(84.5f, io.KeysData338.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData338.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 339 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData339_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 169.5f, DownDurationPrev = 84.75f, AnalogValue = 0.75f };
            io.KeysData339 = value;
            Assert.Equal((byte)1, io.KeysData339.Down);
            Assert.Equal(169.5f, io.KeysData339.DownDuration, 5);
            Assert.Equal(84.75f, io.KeysData339.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData339.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 340 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData340_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 170.0f, DownDurationPrev = 85.0f, AnalogValue = 0.75f };
            io.KeysData340 = value;
            Assert.Equal((byte)1, io.KeysData340.Down);
            Assert.Equal(170.0f, io.KeysData340.DownDuration, 5);
            Assert.Equal(85.0f, io.KeysData340.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData340.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 341 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData341_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 170.5f, DownDurationPrev = 85.25f, AnalogValue = 0.75f };
            io.KeysData341 = value;
            Assert.Equal((byte)1, io.KeysData341.Down);
            Assert.Equal(170.5f, io.KeysData341.DownDuration, 5);
            Assert.Equal(85.25f, io.KeysData341.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData341.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 342 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData342_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 171.0f, DownDurationPrev = 85.5f, AnalogValue = 0.75f };
            io.KeysData342 = value;
            Assert.Equal((byte)1, io.KeysData342.Down);
            Assert.Equal(171.0f, io.KeysData342.DownDuration, 5);
            Assert.Equal(85.5f, io.KeysData342.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData342.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 343 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData343_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 171.5f, DownDurationPrev = 85.75f, AnalogValue = 0.75f };
            io.KeysData343 = value;
            Assert.Equal((byte)1, io.KeysData343.Down);
            Assert.Equal(171.5f, io.KeysData343.DownDuration, 5);
            Assert.Equal(85.75f, io.KeysData343.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData343.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 344 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData344_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 172.0f, DownDurationPrev = 86.0f, AnalogValue = 0.75f };
            io.KeysData344 = value;
            Assert.Equal((byte)1, io.KeysData344.Down);
            Assert.Equal(172.0f, io.KeysData344.DownDuration, 5);
            Assert.Equal(86.0f, io.KeysData344.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData344.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 345 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData345_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 172.5f, DownDurationPrev = 86.25f, AnalogValue = 0.75f };
            io.KeysData345 = value;
            Assert.Equal((byte)1, io.KeysData345.Down);
            Assert.Equal(172.5f, io.KeysData345.DownDuration, 5);
            Assert.Equal(86.25f, io.KeysData345.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData345.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 346 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData346_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 173.0f, DownDurationPrev = 86.5f, AnalogValue = 0.75f };
            io.KeysData346 = value;
            Assert.Equal((byte)1, io.KeysData346.Down);
            Assert.Equal(173.0f, io.KeysData346.DownDuration, 5);
            Assert.Equal(86.5f, io.KeysData346.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData346.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 347 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData347_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 173.5f, DownDurationPrev = 86.75f, AnalogValue = 0.75f };
            io.KeysData347 = value;
            Assert.Equal((byte)1, io.KeysData347.Down);
            Assert.Equal(173.5f, io.KeysData347.DownDuration, 5);
            Assert.Equal(86.75f, io.KeysData347.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData347.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 348 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData348_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 174.0f, DownDurationPrev = 87.0f, AnalogValue = 0.75f };
            io.KeysData348 = value;
            Assert.Equal((byte)1, io.KeysData348.Down);
            Assert.Equal(174.0f, io.KeysData348.DownDuration, 5);
            Assert.Equal(87.0f, io.KeysData348.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData348.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 349 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData349_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 174.5f, DownDurationPrev = 87.25f, AnalogValue = 0.75f };
            io.KeysData349 = value;
            Assert.Equal((byte)1, io.KeysData349.Down);
            Assert.Equal(174.5f, io.KeysData349.DownDuration, 5);
            Assert.Equal(87.25f, io.KeysData349.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData349.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 350 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData350_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 175.0f, DownDurationPrev = 87.5f, AnalogValue = 0.75f };
            io.KeysData350 = value;
            Assert.Equal((byte)1, io.KeysData350.Down);
            Assert.Equal(175.0f, io.KeysData350.DownDuration, 5);
            Assert.Equal(87.5f, io.KeysData350.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData350.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 351 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData351_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 175.5f, DownDurationPrev = 87.75f, AnalogValue = 0.75f };
            io.KeysData351 = value;
            Assert.Equal((byte)1, io.KeysData351.Down);
            Assert.Equal(175.5f, io.KeysData351.DownDuration, 5);
            Assert.Equal(87.75f, io.KeysData351.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData351.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 352 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData352_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 176.0f, DownDurationPrev = 88.0f, AnalogValue = 0.75f };
            io.KeysData352 = value;
            Assert.Equal((byte)1, io.KeysData352.Down);
            Assert.Equal(176.0f, io.KeysData352.DownDuration, 5);
            Assert.Equal(88.0f, io.KeysData352.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData352.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 353 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData353_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 176.5f, DownDurationPrev = 88.25f, AnalogValue = 0.75f };
            io.KeysData353 = value;
            Assert.Equal((byte)1, io.KeysData353.Down);
            Assert.Equal(176.5f, io.KeysData353.DownDuration, 5);
            Assert.Equal(88.25f, io.KeysData353.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData353.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 354 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData354_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 177.0f, DownDurationPrev = 88.5f, AnalogValue = 0.75f };
            io.KeysData354 = value;
            Assert.Equal((byte)1, io.KeysData354.Down);
            Assert.Equal(177.0f, io.KeysData354.DownDuration, 5);
            Assert.Equal(88.5f, io.KeysData354.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData354.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 355 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData355_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 177.5f, DownDurationPrev = 88.75f, AnalogValue = 0.75f };
            io.KeysData355 = value;
            Assert.Equal((byte)1, io.KeysData355.Down);
            Assert.Equal(177.5f, io.KeysData355.DownDuration, 5);
            Assert.Equal(88.75f, io.KeysData355.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData355.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 356 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData356_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 178.0f, DownDurationPrev = 89.0f, AnalogValue = 0.75f };
            io.KeysData356 = value;
            Assert.Equal((byte)1, io.KeysData356.Down);
            Assert.Equal(178.0f, io.KeysData356.DownDuration, 5);
            Assert.Equal(89.0f, io.KeysData356.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData356.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 357 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData357_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 178.5f, DownDurationPrev = 89.25f, AnalogValue = 0.75f };
            io.KeysData357 = value;
            Assert.Equal((byte)1, io.KeysData357.Down);
            Assert.Equal(178.5f, io.KeysData357.DownDuration, 5);
            Assert.Equal(89.25f, io.KeysData357.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData357.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 358 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData358_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 179.0f, DownDurationPrev = 89.5f, AnalogValue = 0.75f };
            io.KeysData358 = value;
            Assert.Equal((byte)1, io.KeysData358.Down);
            Assert.Equal(179.0f, io.KeysData358.DownDuration, 5);
            Assert.Equal(89.5f, io.KeysData358.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData358.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 359 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData359_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 179.5f, DownDurationPrev = 89.75f, AnalogValue = 0.75f };
            io.KeysData359 = value;
            Assert.Equal((byte)1, io.KeysData359.Down);
            Assert.Equal(179.5f, io.KeysData359.DownDuration, 5);
            Assert.Equal(89.75f, io.KeysData359.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData359.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 360 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData360_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 180.0f, DownDurationPrev = 90.0f, AnalogValue = 0.75f };
            io.KeysData360 = value;
            Assert.Equal((byte)1, io.KeysData360.Down);
            Assert.Equal(180.0f, io.KeysData360.DownDuration, 5);
            Assert.Equal(90.0f, io.KeysData360.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData360.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 361 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData361_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 180.5f, DownDurationPrev = 90.25f, AnalogValue = 0.75f };
            io.KeysData361 = value;
            Assert.Equal((byte)1, io.KeysData361.Down);
            Assert.Equal(180.5f, io.KeysData361.DownDuration, 5);
            Assert.Equal(90.25f, io.KeysData361.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData361.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 362 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData362_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 181.0f, DownDurationPrev = 90.5f, AnalogValue = 0.75f };
            io.KeysData362 = value;
            Assert.Equal((byte)1, io.KeysData362.Down);
            Assert.Equal(181.0f, io.KeysData362.DownDuration, 5);
            Assert.Equal(90.5f, io.KeysData362.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData362.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 363 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData363_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 181.5f, DownDurationPrev = 90.75f, AnalogValue = 0.75f };
            io.KeysData363 = value;
            Assert.Equal((byte)1, io.KeysData363.Down);
            Assert.Equal(181.5f, io.KeysData363.DownDuration, 5);
            Assert.Equal(90.75f, io.KeysData363.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData363.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 364 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData364_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 182.0f, DownDurationPrev = 91.0f, AnalogValue = 0.75f };
            io.KeysData364 = value;
            Assert.Equal((byte)1, io.KeysData364.Down);
            Assert.Equal(182.0f, io.KeysData364.DownDuration, 5);
            Assert.Equal(91.0f, io.KeysData364.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData364.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 365 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData365_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 182.5f, DownDurationPrev = 91.25f, AnalogValue = 0.75f };
            io.KeysData365 = value;
            Assert.Equal((byte)1, io.KeysData365.Down);
            Assert.Equal(182.5f, io.KeysData365.DownDuration, 5);
            Assert.Equal(91.25f, io.KeysData365.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData365.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 366 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData366_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 183.0f, DownDurationPrev = 91.5f, AnalogValue = 0.75f };
            io.KeysData366 = value;
            Assert.Equal((byte)1, io.KeysData366.Down);
            Assert.Equal(183.0f, io.KeysData366.DownDuration, 5);
            Assert.Equal(91.5f, io.KeysData366.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData366.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 367 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData367_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 183.5f, DownDurationPrev = 91.75f, AnalogValue = 0.75f };
            io.KeysData367 = value;
            Assert.Equal((byte)1, io.KeysData367.Down);
            Assert.Equal(183.5f, io.KeysData367.DownDuration, 5);
            Assert.Equal(91.75f, io.KeysData367.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData367.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 368 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData368_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 184.0f, DownDurationPrev = 92.0f, AnalogValue = 0.75f };
            io.KeysData368 = value;
            Assert.Equal((byte)1, io.KeysData368.Down);
            Assert.Equal(184.0f, io.KeysData368.DownDuration, 5);
            Assert.Equal(92.0f, io.KeysData368.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData368.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 369 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData369_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 184.5f, DownDurationPrev = 92.25f, AnalogValue = 0.75f };
            io.KeysData369 = value;
            Assert.Equal((byte)1, io.KeysData369.Down);
            Assert.Equal(184.5f, io.KeysData369.DownDuration, 5);
            Assert.Equal(92.25f, io.KeysData369.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData369.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 370 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData370_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 185.0f, DownDurationPrev = 92.5f, AnalogValue = 0.75f };
            io.KeysData370 = value;
            Assert.Equal((byte)1, io.KeysData370.Down);
            Assert.Equal(185.0f, io.KeysData370.DownDuration, 5);
            Assert.Equal(92.5f, io.KeysData370.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData370.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 371 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData371_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 185.5f, DownDurationPrev = 92.75f, AnalogValue = 0.75f };
            io.KeysData371 = value;
            Assert.Equal((byte)1, io.KeysData371.Down);
            Assert.Equal(185.5f, io.KeysData371.DownDuration, 5);
            Assert.Equal(92.75f, io.KeysData371.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData371.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 372 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData372_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 186.0f, DownDurationPrev = 93.0f, AnalogValue = 0.75f };
            io.KeysData372 = value;
            Assert.Equal((byte)1, io.KeysData372.Down);
            Assert.Equal(186.0f, io.KeysData372.DownDuration, 5);
            Assert.Equal(93.0f, io.KeysData372.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData372.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 373 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData373_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 186.5f, DownDurationPrev = 93.25f, AnalogValue = 0.75f };
            io.KeysData373 = value;
            Assert.Equal((byte)1, io.KeysData373.Down);
            Assert.Equal(186.5f, io.KeysData373.DownDuration, 5);
            Assert.Equal(93.25f, io.KeysData373.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData373.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 374 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData374_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 187.0f, DownDurationPrev = 93.5f, AnalogValue = 0.75f };
            io.KeysData374 = value;
            Assert.Equal((byte)1, io.KeysData374.Down);
            Assert.Equal(187.0f, io.KeysData374.DownDuration, 5);
            Assert.Equal(93.5f, io.KeysData374.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData374.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 375 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData375_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 187.5f, DownDurationPrev = 93.75f, AnalogValue = 0.75f };
            io.KeysData375 = value;
            Assert.Equal((byte)1, io.KeysData375.Down);
            Assert.Equal(187.5f, io.KeysData375.DownDuration, 5);
            Assert.Equal(93.75f, io.KeysData375.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData375.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 376 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData376_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 188.0f, DownDurationPrev = 94.0f, AnalogValue = 0.75f };
            io.KeysData376 = value;
            Assert.Equal((byte)1, io.KeysData376.Down);
            Assert.Equal(188.0f, io.KeysData376.DownDuration, 5);
            Assert.Equal(94.0f, io.KeysData376.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData376.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 377 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData377_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 188.5f, DownDurationPrev = 94.25f, AnalogValue = 0.75f };
            io.KeysData377 = value;
            Assert.Equal((byte)1, io.KeysData377.Down);
            Assert.Equal(188.5f, io.KeysData377.DownDuration, 5);
            Assert.Equal(94.25f, io.KeysData377.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData377.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 378 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData378_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 189.0f, DownDurationPrev = 94.5f, AnalogValue = 0.75f };
            io.KeysData378 = value;
            Assert.Equal((byte)1, io.KeysData378.Down);
            Assert.Equal(189.0f, io.KeysData378.DownDuration, 5);
            Assert.Equal(94.5f, io.KeysData378.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData378.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 379 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData379_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 189.5f, DownDurationPrev = 94.75f, AnalogValue = 0.75f };
            io.KeysData379 = value;
            Assert.Equal((byte)1, io.KeysData379.Down);
            Assert.Equal(189.5f, io.KeysData379.DownDuration, 5);
            Assert.Equal(94.75f, io.KeysData379.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData379.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 380 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData380_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 190.0f, DownDurationPrev = 95.0f, AnalogValue = 0.75f };
            io.KeysData380 = value;
            Assert.Equal((byte)1, io.KeysData380.Down);
            Assert.Equal(190.0f, io.KeysData380.DownDuration, 5);
            Assert.Equal(95.0f, io.KeysData380.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData380.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 381 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData381_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 190.5f, DownDurationPrev = 95.25f, AnalogValue = 0.75f };
            io.KeysData381 = value;
            Assert.Equal((byte)1, io.KeysData381.Down);
            Assert.Equal(190.5f, io.KeysData381.DownDuration, 5);
            Assert.Equal(95.25f, io.KeysData381.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData381.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 382 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData382_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 191.0f, DownDurationPrev = 95.5f, AnalogValue = 0.75f };
            io.KeysData382 = value;
            Assert.Equal((byte)1, io.KeysData382.Down);
            Assert.Equal(191.0f, io.KeysData382.DownDuration, 5);
            Assert.Equal(95.5f, io.KeysData382.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData382.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 383 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData383_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 191.5f, DownDurationPrev = 95.75f, AnalogValue = 0.75f };
            io.KeysData383 = value;
            Assert.Equal((byte)1, io.KeysData383.Down);
            Assert.Equal(191.5f, io.KeysData383.DownDuration, 5);
            Assert.Equal(95.75f, io.KeysData383.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData383.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 384 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData384_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 192.0f, DownDurationPrev = 96.0f, AnalogValue = 0.75f };
            io.KeysData384 = value;
            Assert.Equal((byte)1, io.KeysData384.Down);
            Assert.Equal(192.0f, io.KeysData384.DownDuration, 5);
            Assert.Equal(96.0f, io.KeysData384.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData384.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 385 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData385_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 192.5f, DownDurationPrev = 96.25f, AnalogValue = 0.75f };
            io.KeysData385 = value;
            Assert.Equal((byte)1, io.KeysData385.Down);
            Assert.Equal(192.5f, io.KeysData385.DownDuration, 5);
            Assert.Equal(96.25f, io.KeysData385.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData385.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 386 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData386_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 193.0f, DownDurationPrev = 96.5f, AnalogValue = 0.75f };
            io.KeysData386 = value;
            Assert.Equal((byte)1, io.KeysData386.Down);
            Assert.Equal(193.0f, io.KeysData386.DownDuration, 5);
            Assert.Equal(96.5f, io.KeysData386.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData386.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 387 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData387_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 193.5f, DownDurationPrev = 96.75f, AnalogValue = 0.75f };
            io.KeysData387 = value;
            Assert.Equal((byte)1, io.KeysData387.Down);
            Assert.Equal(193.5f, io.KeysData387.DownDuration, 5);
            Assert.Equal(96.75f, io.KeysData387.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData387.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 388 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData388_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 194.0f, DownDurationPrev = 97.0f, AnalogValue = 0.75f };
            io.KeysData388 = value;
            Assert.Equal((byte)1, io.KeysData388.Down);
            Assert.Equal(194.0f, io.KeysData388.DownDuration, 5);
            Assert.Equal(97.0f, io.KeysData388.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData388.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 389 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData389_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 194.5f, DownDurationPrev = 97.25f, AnalogValue = 0.75f };
            io.KeysData389 = value;
            Assert.Equal((byte)1, io.KeysData389.Down);
            Assert.Equal(194.5f, io.KeysData389.DownDuration, 5);
            Assert.Equal(97.25f, io.KeysData389.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData389.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 390 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData390_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 195.0f, DownDurationPrev = 97.5f, AnalogValue = 0.75f };
            io.KeysData390 = value;
            Assert.Equal((byte)1, io.KeysData390.Down);
            Assert.Equal(195.0f, io.KeysData390.DownDuration, 5);
            Assert.Equal(97.5f, io.KeysData390.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData390.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 391 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData391_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 195.5f, DownDurationPrev = 97.75f, AnalogValue = 0.75f };
            io.KeysData391 = value;
            Assert.Equal((byte)1, io.KeysData391.Down);
            Assert.Equal(195.5f, io.KeysData391.DownDuration, 5);
            Assert.Equal(97.75f, io.KeysData391.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData391.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 392 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData392_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 196.0f, DownDurationPrev = 98.0f, AnalogValue = 0.75f };
            io.KeysData392 = value;
            Assert.Equal((byte)1, io.KeysData392.Down);
            Assert.Equal(196.0f, io.KeysData392.DownDuration, 5);
            Assert.Equal(98.0f, io.KeysData392.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData392.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 393 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData393_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 196.5f, DownDurationPrev = 98.25f, AnalogValue = 0.75f };
            io.KeysData393 = value;
            Assert.Equal((byte)1, io.KeysData393.Down);
            Assert.Equal(196.5f, io.KeysData393.DownDuration, 5);
            Assert.Equal(98.25f, io.KeysData393.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData393.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 394 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData394_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 197.0f, DownDurationPrev = 98.5f, AnalogValue = 0.75f };
            io.KeysData394 = value;
            Assert.Equal((byte)1, io.KeysData394.Down);
            Assert.Equal(197.0f, io.KeysData394.DownDuration, 5);
            Assert.Equal(98.5f, io.KeysData394.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData394.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 395 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData395_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 197.5f, DownDurationPrev = 98.75f, AnalogValue = 0.75f };
            io.KeysData395 = value;
            Assert.Equal((byte)1, io.KeysData395.Down);
            Assert.Equal(197.5f, io.KeysData395.DownDuration, 5);
            Assert.Equal(98.75f, io.KeysData395.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData395.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 396 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData396_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 198.0f, DownDurationPrev = 99.0f, AnalogValue = 0.75f };
            io.KeysData396 = value;
            Assert.Equal((byte)1, io.KeysData396.Down);
            Assert.Equal(198.0f, io.KeysData396.DownDuration, 5);
            Assert.Equal(99.0f, io.KeysData396.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData396.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 397 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData397_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 198.5f, DownDurationPrev = 99.25f, AnalogValue = 0.75f };
            io.KeysData397 = value;
            Assert.Equal((byte)1, io.KeysData397.Down);
            Assert.Equal(198.5f, io.KeysData397.DownDuration, 5);
            Assert.Equal(99.25f, io.KeysData397.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData397.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 398 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData398_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 199.0f, DownDurationPrev = 99.5f, AnalogValue = 0.75f };
            io.KeysData398 = value;
            Assert.Equal((byte)1, io.KeysData398.Down);
            Assert.Equal(199.0f, io.KeysData398.DownDuration, 5);
            Assert.Equal(99.5f, io.KeysData398.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData398.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 399 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData399_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 199.5f, DownDurationPrev = 99.75f, AnalogValue = 0.75f };
            io.KeysData399 = value;
            Assert.Equal((byte)1, io.KeysData399.Down);
            Assert.Equal(199.5f, io.KeysData399.DownDuration, 5);
            Assert.Equal(99.75f, io.KeysData399.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData399.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 400 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData400_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 200.0f, DownDurationPrev = 100.0f, AnalogValue = 0.75f };
            io.KeysData400 = value;
            Assert.Equal((byte)1, io.KeysData400.Down);
            Assert.Equal(200.0f, io.KeysData400.DownDuration, 5);
            Assert.Equal(100.0f, io.KeysData400.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData400.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 401 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData401_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 200.5f, DownDurationPrev = 100.25f, AnalogValue = 0.75f };
            io.KeysData401 = value;
            Assert.Equal((byte)1, io.KeysData401.Down);
            Assert.Equal(200.5f, io.KeysData401.DownDuration, 5);
            Assert.Equal(100.25f, io.KeysData401.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData401.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 402 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData402_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 201.0f, DownDurationPrev = 100.5f, AnalogValue = 0.75f };
            io.KeysData402 = value;
            Assert.Equal((byte)1, io.KeysData402.Down);
            Assert.Equal(201.0f, io.KeysData402.DownDuration, 5);
            Assert.Equal(100.5f, io.KeysData402.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData402.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 403 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData403_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 201.5f, DownDurationPrev = 100.75f, AnalogValue = 0.75f };
            io.KeysData403 = value;
            Assert.Equal((byte)1, io.KeysData403.Down);
            Assert.Equal(201.5f, io.KeysData403.DownDuration, 5);
            Assert.Equal(100.75f, io.KeysData403.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData403.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 404 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData404_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 202.0f, DownDurationPrev = 101.0f, AnalogValue = 0.75f };
            io.KeysData404 = value;
            Assert.Equal((byte)1, io.KeysData404.Down);
            Assert.Equal(202.0f, io.KeysData404.DownDuration, 5);
            Assert.Equal(101.0f, io.KeysData404.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData404.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 405 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData405_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 202.5f, DownDurationPrev = 101.25f, AnalogValue = 0.75f };
            io.KeysData405 = value;
            Assert.Equal((byte)1, io.KeysData405.Down);
            Assert.Equal(202.5f, io.KeysData405.DownDuration, 5);
            Assert.Equal(101.25f, io.KeysData405.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData405.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 406 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData406_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 203.0f, DownDurationPrev = 101.5f, AnalogValue = 0.75f };
            io.KeysData406 = value;
            Assert.Equal((byte)1, io.KeysData406.Down);
            Assert.Equal(203.0f, io.KeysData406.DownDuration, 5);
            Assert.Equal(101.5f, io.KeysData406.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData406.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 409 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData409_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 204.5f, DownDurationPrev = 102.25f, AnalogValue = 0.75f };
            io.KeysData409 = value;
            Assert.Equal((byte)1, io.KeysData409.Down);
            Assert.Equal(204.5f, io.KeysData409.DownDuration, 5);
            Assert.Equal(102.25f, io.KeysData409.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData409.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 410 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData410_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 205.0f, DownDurationPrev = 102.5f, AnalogValue = 0.75f };
            io.KeysData410 = value;
            Assert.Equal((byte)1, io.KeysData410.Down);
            Assert.Equal(205.0f, io.KeysData410.DownDuration, 5);
            Assert.Equal(102.5f, io.KeysData410.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData410.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 411 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData411_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 205.5f, DownDurationPrev = 102.75f, AnalogValue = 0.75f };
            io.KeysData411 = value;
            Assert.Equal((byte)1, io.KeysData411.Down);
            Assert.Equal(205.5f, io.KeysData411.DownDuration, 5);
            Assert.Equal(102.75f, io.KeysData411.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData411.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 412 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData412_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 206.0f, DownDurationPrev = 103.0f, AnalogValue = 0.75f };
            io.KeysData412 = value;
            Assert.Equal((byte)1, io.KeysData412.Down);
            Assert.Equal(206.0f, io.KeysData412.DownDuration, 5);
            Assert.Equal(103.0f, io.KeysData412.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData412.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 413 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData413_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 206.5f, DownDurationPrev = 103.25f, AnalogValue = 0.75f };
            io.KeysData413 = value;
            Assert.Equal((byte)1, io.KeysData413.Down);
            Assert.Equal(206.5f, io.KeysData413.DownDuration, 5);
            Assert.Equal(103.25f, io.KeysData413.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData413.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 414 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData414_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 207.0f, DownDurationPrev = 103.5f, AnalogValue = 0.75f };
            io.KeysData414 = value;
            Assert.Equal((byte)1, io.KeysData414.Down);
            Assert.Equal(207.0f, io.KeysData414.DownDuration, 5);
            Assert.Equal(103.5f, io.KeysData414.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData414.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 415 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData415_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 207.5f, DownDurationPrev = 103.75f, AnalogValue = 0.75f };
            io.KeysData415 = value;
            Assert.Equal((byte)1, io.KeysData415.Down);
            Assert.Equal(207.5f, io.KeysData415.DownDuration, 5);
            Assert.Equal(103.75f, io.KeysData415.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData415.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 416 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData416_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 208.0f, DownDurationPrev = 104.0f, AnalogValue = 0.75f };
            io.KeysData416 = value;
            Assert.Equal((byte)1, io.KeysData416.Down);
            Assert.Equal(208.0f, io.KeysData416.DownDuration, 5);
            Assert.Equal(104.0f, io.KeysData416.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData416.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 417 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData417_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 208.5f, DownDurationPrev = 104.25f, AnalogValue = 0.75f };
            io.KeysData417 = value;
            Assert.Equal((byte)1, io.KeysData417.Down);
            Assert.Equal(208.5f, io.KeysData417.DownDuration, 5);
            Assert.Equal(104.25f, io.KeysData417.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData417.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 418 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData418_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 209.0f, DownDurationPrev = 104.5f, AnalogValue = 0.75f };
            io.KeysData418 = value;
            Assert.Equal((byte)1, io.KeysData418.Down);
            Assert.Equal(209.0f, io.KeysData418.DownDuration, 5);
            Assert.Equal(104.5f, io.KeysData418.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData418.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 419 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData419_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 209.5f, DownDurationPrev = 104.75f, AnalogValue = 0.75f };
            io.KeysData419 = value;
            Assert.Equal((byte)1, io.KeysData419.Down);
            Assert.Equal(209.5f, io.KeysData419.DownDuration, 5);
            Assert.Equal(104.75f, io.KeysData419.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData419.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 420 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData420_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 210.0f, DownDurationPrev = 105.0f, AnalogValue = 0.75f };
            io.KeysData420 = value;
            Assert.Equal((byte)1, io.KeysData420.Down);
            Assert.Equal(210.0f, io.KeysData420.DownDuration, 5);
            Assert.Equal(105.0f, io.KeysData420.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData420.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 421 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData421_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 210.5f, DownDurationPrev = 105.25f, AnalogValue = 0.75f };
            io.KeysData421 = value;
            Assert.Equal((byte)1, io.KeysData421.Down);
            Assert.Equal(210.5f, io.KeysData421.DownDuration, 5);
            Assert.Equal(105.25f, io.KeysData421.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData421.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 422 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData422_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 211.0f, DownDurationPrev = 105.5f, AnalogValue = 0.75f };
            io.KeysData422 = value;
            Assert.Equal((byte)1, io.KeysData422.Down);
            Assert.Equal(211.0f, io.KeysData422.DownDuration, 5);
            Assert.Equal(105.5f, io.KeysData422.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData422.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 423 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData423_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 211.5f, DownDurationPrev = 105.75f, AnalogValue = 0.75f };
            io.KeysData423 = value;
            Assert.Equal((byte)1, io.KeysData423.Down);
            Assert.Equal(211.5f, io.KeysData423.DownDuration, 5);
            Assert.Equal(105.75f, io.KeysData423.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData423.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 424 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData424_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 212.0f, DownDurationPrev = 106.0f, AnalogValue = 0.75f };
            io.KeysData424 = value;
            Assert.Equal((byte)1, io.KeysData424.Down);
            Assert.Equal(212.0f, io.KeysData424.DownDuration, 5);
            Assert.Equal(106.0f, io.KeysData424.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData424.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 425 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData425_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 212.5f, DownDurationPrev = 106.25f, AnalogValue = 0.75f };
            io.KeysData425 = value;
            Assert.Equal((byte)1, io.KeysData425.Down);
            Assert.Equal(212.5f, io.KeysData425.DownDuration, 5);
            Assert.Equal(106.25f, io.KeysData425.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData425.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 426 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData426_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 213.0f, DownDurationPrev = 106.5f, AnalogValue = 0.75f };
            io.KeysData426 = value;
            Assert.Equal((byte)1, io.KeysData426.Down);
            Assert.Equal(213.0f, io.KeysData426.DownDuration, 5);
            Assert.Equal(106.5f, io.KeysData426.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData426.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 427 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData427_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 213.5f, DownDurationPrev = 106.75f, AnalogValue = 0.75f };
            io.KeysData427 = value;
            Assert.Equal((byte)1, io.KeysData427.Down);
            Assert.Equal(213.5f, io.KeysData427.DownDuration, 5);
            Assert.Equal(106.75f, io.KeysData427.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData427.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 428 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData428_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 214.0f, DownDurationPrev = 107.0f, AnalogValue = 0.75f };
            io.KeysData428 = value;
            Assert.Equal((byte)1, io.KeysData428.Down);
            Assert.Equal(214.0f, io.KeysData428.DownDuration, 5);
            Assert.Equal(107.0f, io.KeysData428.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData428.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 429 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData429_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 214.5f, DownDurationPrev = 107.25f, AnalogValue = 0.75f };
            io.KeysData429 = value;
            Assert.Equal((byte)1, io.KeysData429.Down);
            Assert.Equal(214.5f, io.KeysData429.DownDuration, 5);
            Assert.Equal(107.25f, io.KeysData429.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData429.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 430 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData430_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 215.0f, DownDurationPrev = 107.5f, AnalogValue = 0.75f };
            io.KeysData430 = value;
            Assert.Equal((byte)1, io.KeysData430.Down);
            Assert.Equal(215.0f, io.KeysData430.DownDuration, 5);
            Assert.Equal(107.5f, io.KeysData430.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData430.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 431 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData431_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 215.5f, DownDurationPrev = 107.75f, AnalogValue = 0.75f };
            io.KeysData431 = value;
            Assert.Equal((byte)1, io.KeysData431.Down);
            Assert.Equal(215.5f, io.KeysData431.DownDuration, 5);
            Assert.Equal(107.75f, io.KeysData431.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData431.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 432 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData432_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 216.0f, DownDurationPrev = 108.0f, AnalogValue = 0.75f };
            io.KeysData432 = value;
            Assert.Equal((byte)1, io.KeysData432.Down);
            Assert.Equal(216.0f, io.KeysData432.DownDuration, 5);
            Assert.Equal(108.0f, io.KeysData432.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData432.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 433 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData433_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 216.5f, DownDurationPrev = 108.25f, AnalogValue = 0.75f };
            io.KeysData433 = value;
            Assert.Equal((byte)1, io.KeysData433.Down);
            Assert.Equal(216.5f, io.KeysData433.DownDuration, 5);
            Assert.Equal(108.25f, io.KeysData433.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData433.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 434 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData434_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 217.0f, DownDurationPrev = 108.5f, AnalogValue = 0.75f };
            io.KeysData434 = value;
            Assert.Equal((byte)1, io.KeysData434.Down);
            Assert.Equal(217.0f, io.KeysData434.DownDuration, 5);
            Assert.Equal(108.5f, io.KeysData434.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData434.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 435 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData435_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 217.5f, DownDurationPrev = 108.75f, AnalogValue = 0.75f };
            io.KeysData435 = value;
            Assert.Equal((byte)1, io.KeysData435.Down);
            Assert.Equal(217.5f, io.KeysData435.DownDuration, 5);
            Assert.Equal(108.75f, io.KeysData435.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData435.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 436 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData436_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 218.0f, DownDurationPrev = 109.0f, AnalogValue = 0.75f };
            io.KeysData436 = value;
            Assert.Equal((byte)1, io.KeysData436.Down);
            Assert.Equal(218.0f, io.KeysData436.DownDuration, 5);
            Assert.Equal(109.0f, io.KeysData436.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData436.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 437 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData437_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 218.5f, DownDurationPrev = 109.25f, AnalogValue = 0.75f };
            io.KeysData437 = value;
            Assert.Equal((byte)1, io.KeysData437.Down);
            Assert.Equal(218.5f, io.KeysData437.DownDuration, 5);
            Assert.Equal(109.25f, io.KeysData437.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData437.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 438 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData438_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 219.0f, DownDurationPrev = 109.5f, AnalogValue = 0.75f };
            io.KeysData438 = value;
            Assert.Equal((byte)1, io.KeysData438.Down);
            Assert.Equal(219.0f, io.KeysData438.DownDuration, 5);
            Assert.Equal(109.5f, io.KeysData438.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData438.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 439 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData439_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 219.5f, DownDurationPrev = 109.75f, AnalogValue = 0.75f };
            io.KeysData439 = value;
            Assert.Equal((byte)1, io.KeysData439.Down);
            Assert.Equal(219.5f, io.KeysData439.DownDuration, 5);
            Assert.Equal(109.75f, io.KeysData439.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData439.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 440 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData440_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 220.0f, DownDurationPrev = 110.0f, AnalogValue = 0.75f };
            io.KeysData440 = value;
            Assert.Equal((byte)1, io.KeysData440.Down);
            Assert.Equal(220.0f, io.KeysData440.DownDuration, 5);
            Assert.Equal(110.0f, io.KeysData440.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData440.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 441 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData441_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 220.5f, DownDurationPrev = 110.25f, AnalogValue = 0.75f };
            io.KeysData441 = value;
            Assert.Equal((byte)1, io.KeysData441.Down);
            Assert.Equal(220.5f, io.KeysData441.DownDuration, 5);
            Assert.Equal(110.25f, io.KeysData441.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData441.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 442 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData442_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 221.0f, DownDurationPrev = 110.5f, AnalogValue = 0.75f };
            io.KeysData442 = value;
            Assert.Equal((byte)1, io.KeysData442.Down);
            Assert.Equal(221.0f, io.KeysData442.DownDuration, 5);
            Assert.Equal(110.5f, io.KeysData442.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData442.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 443 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData443_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 221.5f, DownDurationPrev = 110.75f, AnalogValue = 0.75f };
            io.KeysData443 = value;
            Assert.Equal((byte)1, io.KeysData443.Down);
            Assert.Equal(221.5f, io.KeysData443.DownDuration, 5);
            Assert.Equal(110.75f, io.KeysData443.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData443.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 444 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData444_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 222.0f, DownDurationPrev = 111.0f, AnalogValue = 0.75f };
            io.KeysData444 = value;
            Assert.Equal((byte)1, io.KeysData444.Down);
            Assert.Equal(222.0f, io.KeysData444.DownDuration, 5);
            Assert.Equal(111.0f, io.KeysData444.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData444.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 445 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData445_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 222.5f, DownDurationPrev = 111.25f, AnalogValue = 0.75f };
            io.KeysData445 = value;
            Assert.Equal((byte)1, io.KeysData445.Down);
            Assert.Equal(222.5f, io.KeysData445.DownDuration, 5);
            Assert.Equal(111.25f, io.KeysData445.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData445.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 446 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData446_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 223.0f, DownDurationPrev = 111.5f, AnalogValue = 0.75f };
            io.KeysData446 = value;
            Assert.Equal((byte)1, io.KeysData446.Down);
            Assert.Equal(223.0f, io.KeysData446.DownDuration, 5);
            Assert.Equal(111.5f, io.KeysData446.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData446.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 447 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData447_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 223.5f, DownDurationPrev = 111.75f, AnalogValue = 0.75f };
            io.KeysData447 = value;
            Assert.Equal((byte)1, io.KeysData447.Down);
            Assert.Equal(223.5f, io.KeysData447.DownDuration, 5);
            Assert.Equal(111.75f, io.KeysData447.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData447.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 448 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData448_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 224.0f, DownDurationPrev = 112.0f, AnalogValue = 0.75f };
            io.KeysData448 = value;
            Assert.Equal((byte)1, io.KeysData448.Down);
            Assert.Equal(224.0f, io.KeysData448.DownDuration, 5);
            Assert.Equal(112.0f, io.KeysData448.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData448.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 449 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData449_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 224.5f, DownDurationPrev = 112.25f, AnalogValue = 0.75f };
            io.KeysData449 = value;
            Assert.Equal((byte)1, io.KeysData449.Down);
            Assert.Equal(224.5f, io.KeysData449.DownDuration, 5);
            Assert.Equal(112.25f, io.KeysData449.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData449.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 450 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData450_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 225.0f, DownDurationPrev = 112.5f, AnalogValue = 0.75f };
            io.KeysData450 = value;
            Assert.Equal((byte)1, io.KeysData450.Down);
            Assert.Equal(225.0f, io.KeysData450.DownDuration, 5);
            Assert.Equal(112.5f, io.KeysData450.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData450.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 451 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData451_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 225.5f, DownDurationPrev = 112.75f, AnalogValue = 0.75f };
            io.KeysData451 = value;
            Assert.Equal((byte)1, io.KeysData451.Down);
            Assert.Equal(225.5f, io.KeysData451.DownDuration, 5);
            Assert.Equal(112.75f, io.KeysData451.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData451.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 452 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData452_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 226.0f, DownDurationPrev = 113.0f, AnalogValue = 0.75f };
            io.KeysData452 = value;
            Assert.Equal((byte)1, io.KeysData452.Down);
            Assert.Equal(226.0f, io.KeysData452.DownDuration, 5);
            Assert.Equal(113.0f, io.KeysData452.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData452.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 453 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData453_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 226.5f, DownDurationPrev = 113.25f, AnalogValue = 0.75f };
            io.KeysData453 = value;
            Assert.Equal((byte)1, io.KeysData453.Down);
            Assert.Equal(226.5f, io.KeysData453.DownDuration, 5);
            Assert.Equal(113.25f, io.KeysData453.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData453.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 454 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData454_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 227.0f, DownDurationPrev = 113.5f, AnalogValue = 0.75f };
            io.KeysData454 = value;
            Assert.Equal((byte)1, io.KeysData454.Down);
            Assert.Equal(227.0f, io.KeysData454.DownDuration, 5);
            Assert.Equal(113.5f, io.KeysData454.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData454.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 455 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData455_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 227.5f, DownDurationPrev = 113.75f, AnalogValue = 0.75f };
            io.KeysData455 = value;
            Assert.Equal((byte)1, io.KeysData455.Down);
            Assert.Equal(227.5f, io.KeysData455.DownDuration, 5);
            Assert.Equal(113.75f, io.KeysData455.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData455.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 456 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData456_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 228.0f, DownDurationPrev = 114.0f, AnalogValue = 0.75f };
            io.KeysData456 = value;
            Assert.Equal((byte)1, io.KeysData456.Down);
            Assert.Equal(228.0f, io.KeysData456.DownDuration, 5);
            Assert.Equal(114.0f, io.KeysData456.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData456.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 457 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData457_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 228.5f, DownDurationPrev = 114.25f, AnalogValue = 0.75f };
            io.KeysData457 = value;
            Assert.Equal((byte)1, io.KeysData457.Down);
            Assert.Equal(228.5f, io.KeysData457.DownDuration, 5);
            Assert.Equal(114.25f, io.KeysData457.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData457.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 458 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData458_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 229.0f, DownDurationPrev = 114.5f, AnalogValue = 0.75f };
            io.KeysData458 = value;
            Assert.Equal((byte)1, io.KeysData458.Down);
            Assert.Equal(229.0f, io.KeysData458.DownDuration, 5);
            Assert.Equal(114.5f, io.KeysData458.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData458.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 459 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData459_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 229.5f, DownDurationPrev = 114.75f, AnalogValue = 0.75f };
            io.KeysData459 = value;
            Assert.Equal((byte)1, io.KeysData459.Down);
            Assert.Equal(229.5f, io.KeysData459.DownDuration, 5);
            Assert.Equal(114.75f, io.KeysData459.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData459.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 460 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData460_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 230.0f, DownDurationPrev = 115.0f, AnalogValue = 0.75f };
            io.KeysData460 = value;
            Assert.Equal((byte)1, io.KeysData460.Down);
            Assert.Equal(230.0f, io.KeysData460.DownDuration, 5);
            Assert.Equal(115.0f, io.KeysData460.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData460.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 461 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData461_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 230.5f, DownDurationPrev = 115.25f, AnalogValue = 0.75f };
            io.KeysData461 = value;
            Assert.Equal((byte)1, io.KeysData461.Down);
            Assert.Equal(230.5f, io.KeysData461.DownDuration, 5);
            Assert.Equal(115.25f, io.KeysData461.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData461.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 462 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData462_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 231.0f, DownDurationPrev = 115.5f, AnalogValue = 0.75f };
            io.KeysData462 = value;
            Assert.Equal((byte)1, io.KeysData462.Down);
            Assert.Equal(231.0f, io.KeysData462.DownDuration, 5);
            Assert.Equal(115.5f, io.KeysData462.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData462.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 463 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData463_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 231.5f, DownDurationPrev = 115.75f, AnalogValue = 0.75f };
            io.KeysData463 = value;
            Assert.Equal((byte)1, io.KeysData463.Down);
            Assert.Equal(231.5f, io.KeysData463.DownDuration, 5);
            Assert.Equal(115.75f, io.KeysData463.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData463.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 464 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData464_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 232.0f, DownDurationPrev = 116.0f, AnalogValue = 0.75f };
            io.KeysData464 = value;
            Assert.Equal((byte)1, io.KeysData464.Down);
            Assert.Equal(232.0f, io.KeysData464.DownDuration, 5);
            Assert.Equal(116.0f, io.KeysData464.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData464.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 465 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData465_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 232.5f, DownDurationPrev = 116.25f, AnalogValue = 0.75f };
            io.KeysData465 = value;
            Assert.Equal((byte)1, io.KeysData465.Down);
            Assert.Equal(232.5f, io.KeysData465.DownDuration, 5);
            Assert.Equal(116.25f, io.KeysData465.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData465.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 466 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData466_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 233.0f, DownDurationPrev = 116.5f, AnalogValue = 0.75f };
            io.KeysData466 = value;
            Assert.Equal((byte)1, io.KeysData466.Down);
            Assert.Equal(233.0f, io.KeysData466.DownDuration, 5);
            Assert.Equal(116.5f, io.KeysData466.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData466.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 467 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData467_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 233.5f, DownDurationPrev = 116.75f, AnalogValue = 0.75f };
            io.KeysData467 = value;
            Assert.Equal((byte)1, io.KeysData467.Down);
            Assert.Equal(233.5f, io.KeysData467.DownDuration, 5);
            Assert.Equal(116.75f, io.KeysData467.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData467.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 468 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData468_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 234.0f, DownDurationPrev = 117.0f, AnalogValue = 0.75f };
            io.KeysData468 = value;
            Assert.Equal((byte)1, io.KeysData468.Down);
            Assert.Equal(234.0f, io.KeysData468.DownDuration, 5);
            Assert.Equal(117.0f, io.KeysData468.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData468.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 469 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData469_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 234.5f, DownDurationPrev = 117.25f, AnalogValue = 0.75f };
            io.KeysData469 = value;
            Assert.Equal((byte)1, io.KeysData469.Down);
            Assert.Equal(234.5f, io.KeysData469.DownDuration, 5);
            Assert.Equal(117.25f, io.KeysData469.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData469.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 470 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData470_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 235.0f, DownDurationPrev = 117.5f, AnalogValue = 0.75f };
            io.KeysData470 = value;
            Assert.Equal((byte)1, io.KeysData470.Down);
            Assert.Equal(235.0f, io.KeysData470.DownDuration, 5);
            Assert.Equal(117.5f, io.KeysData470.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData470.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 471 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData471_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 235.5f, DownDurationPrev = 117.75f, AnalogValue = 0.75f };
            io.KeysData471 = value;
            Assert.Equal((byte)1, io.KeysData471.Down);
            Assert.Equal(235.5f, io.KeysData471.DownDuration, 5);
            Assert.Equal(117.75f, io.KeysData471.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData471.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 472 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData472_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 236.0f, DownDurationPrev = 118.0f, AnalogValue = 0.75f };
            io.KeysData472 = value;
            Assert.Equal((byte)1, io.KeysData472.Down);
            Assert.Equal(236.0f, io.KeysData472.DownDuration, 5);
            Assert.Equal(118.0f, io.KeysData472.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData472.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 473 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData473_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 236.5f, DownDurationPrev = 118.25f, AnalogValue = 0.75f };
            io.KeysData473 = value;
            Assert.Equal((byte)1, io.KeysData473.Down);
            Assert.Equal(236.5f, io.KeysData473.DownDuration, 5);
            Assert.Equal(118.25f, io.KeysData473.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData473.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 474 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData474_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 237.0f, DownDurationPrev = 118.5f, AnalogValue = 0.75f };
            io.KeysData474 = value;
            Assert.Equal((byte)1, io.KeysData474.Down);
            Assert.Equal(237.0f, io.KeysData474.DownDuration, 5);
            Assert.Equal(118.5f, io.KeysData474.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData474.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 475 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData475_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 237.5f, DownDurationPrev = 118.75f, AnalogValue = 0.75f };
            io.KeysData475 = value;
            Assert.Equal((byte)1, io.KeysData475.Down);
            Assert.Equal(237.5f, io.KeysData475.DownDuration, 5);
            Assert.Equal(118.75f, io.KeysData475.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData475.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 476 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData476_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 238.0f, DownDurationPrev = 119.0f, AnalogValue = 0.75f };
            io.KeysData476 = value;
            Assert.Equal((byte)1, io.KeysData476.Down);
            Assert.Equal(238.0f, io.KeysData476.DownDuration, 5);
            Assert.Equal(119.0f, io.KeysData476.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData476.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 477 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData477_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 238.5f, DownDurationPrev = 119.25f, AnalogValue = 0.75f };
            io.KeysData477 = value;
            Assert.Equal((byte)1, io.KeysData477.Down);
            Assert.Equal(238.5f, io.KeysData477.DownDuration, 5);
            Assert.Equal(119.25f, io.KeysData477.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData477.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 478 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData478_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 239.0f, DownDurationPrev = 119.5f, AnalogValue = 0.75f };
            io.KeysData478 = value;
            Assert.Equal((byte)1, io.KeysData478.Down);
            Assert.Equal(239.0f, io.KeysData478.DownDuration, 5);
            Assert.Equal(119.5f, io.KeysData478.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData478.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 479 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData479_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 239.5f, DownDurationPrev = 119.75f, AnalogValue = 0.75f };
            io.KeysData479 = value;
            Assert.Equal((byte)1, io.KeysData479.Down);
            Assert.Equal(239.5f, io.KeysData479.DownDuration, 5);
            Assert.Equal(119.75f, io.KeysData479.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData479.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 480 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData480_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 240.0f, DownDurationPrev = 120.0f, AnalogValue = 0.75f };
            io.KeysData480 = value;
            Assert.Equal((byte)1, io.KeysData480.Down);
            Assert.Equal(240.0f, io.KeysData480.DownDuration, 5);
            Assert.Equal(120.0f, io.KeysData480.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData480.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 481 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData481_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 240.5f, DownDurationPrev = 120.25f, AnalogValue = 0.75f };
            io.KeysData481 = value;
            Assert.Equal((byte)1, io.KeysData481.Down);
            Assert.Equal(240.5f, io.KeysData481.DownDuration, 5);
            Assert.Equal(120.25f, io.KeysData481.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData481.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 482 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData482_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 241.0f, DownDurationPrev = 120.5f, AnalogValue = 0.75f };
            io.KeysData482 = value;
            Assert.Equal((byte)1, io.KeysData482.Down);
            Assert.Equal(241.0f, io.KeysData482.DownDuration, 5);
            Assert.Equal(120.5f, io.KeysData482.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData482.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 483 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData483_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 241.5f, DownDurationPrev = 120.75f, AnalogValue = 0.75f };
            io.KeysData483 = value;
            Assert.Equal((byte)1, io.KeysData483.Down);
            Assert.Equal(241.5f, io.KeysData483.DownDuration, 5);
            Assert.Equal(120.75f, io.KeysData483.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData483.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 484 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData484_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 242.0f, DownDurationPrev = 121.0f, AnalogValue = 0.75f };
            io.KeysData484 = value;
            Assert.Equal((byte)1, io.KeysData484.Down);
            Assert.Equal(242.0f, io.KeysData484.DownDuration, 5);
            Assert.Equal(121.0f, io.KeysData484.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData484.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 485 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData485_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 242.5f, DownDurationPrev = 121.25f, AnalogValue = 0.75f };
            io.KeysData485 = value;
            Assert.Equal((byte)1, io.KeysData485.Down);
            Assert.Equal(242.5f, io.KeysData485.DownDuration, 5);
            Assert.Equal(121.25f, io.KeysData485.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData485.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 486 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData486_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 243.0f, DownDurationPrev = 121.5f, AnalogValue = 0.75f };
            io.KeysData486 = value;
            Assert.Equal((byte)1, io.KeysData486.Down);
            Assert.Equal(243.0f, io.KeysData486.DownDuration, 5);
            Assert.Equal(121.5f, io.KeysData486.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData486.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 487 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData487_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 243.5f, DownDurationPrev = 121.75f, AnalogValue = 0.75f };
            io.KeysData487 = value;
            Assert.Equal((byte)1, io.KeysData487.Down);
            Assert.Equal(243.5f, io.KeysData487.DownDuration, 5);
            Assert.Equal(121.75f, io.KeysData487.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData487.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 488 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData488_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 244.0f, DownDurationPrev = 122.0f, AnalogValue = 0.75f };
            io.KeysData488 = value;
            Assert.Equal((byte)1, io.KeysData488.Down);
            Assert.Equal(244.0f, io.KeysData488.DownDuration, 5);
            Assert.Equal(122.0f, io.KeysData488.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData488.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 489 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData489_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 244.5f, DownDurationPrev = 122.25f, AnalogValue = 0.75f };
            io.KeysData489 = value;
            Assert.Equal((byte)1, io.KeysData489.Down);
            Assert.Equal(244.5f, io.KeysData489.DownDuration, 5);
            Assert.Equal(122.25f, io.KeysData489.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData489.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 490 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData490_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 245.0f, DownDurationPrev = 122.5f, AnalogValue = 0.75f };
            io.KeysData490 = value;
            Assert.Equal((byte)1, io.KeysData490.Down);
            Assert.Equal(245.0f, io.KeysData490.DownDuration, 5);
            Assert.Equal(122.5f, io.KeysData490.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData490.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 491 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData491_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 245.5f, DownDurationPrev = 122.75f, AnalogValue = 0.75f };
            io.KeysData491 = value;
            Assert.Equal((byte)1, io.KeysData491.Down);
            Assert.Equal(245.5f, io.KeysData491.DownDuration, 5);
            Assert.Equal(122.75f, io.KeysData491.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData491.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 492 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData492_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 246.0f, DownDurationPrev = 123.0f, AnalogValue = 0.75f };
            io.KeysData492 = value;
            Assert.Equal((byte)1, io.KeysData492.Down);
            Assert.Equal(246.0f, io.KeysData492.DownDuration, 5);
            Assert.Equal(123.0f, io.KeysData492.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData492.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 493 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData493_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 246.5f, DownDurationPrev = 123.25f, AnalogValue = 0.75f };
            io.KeysData493 = value;
            Assert.Equal((byte)1, io.KeysData493.Down);
            Assert.Equal(246.5f, io.KeysData493.DownDuration, 5);
            Assert.Equal(123.25f, io.KeysData493.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData493.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 494 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData494_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 247.0f, DownDurationPrev = 123.5f, AnalogValue = 0.75f };
            io.KeysData494 = value;
            Assert.Equal((byte)1, io.KeysData494.Down);
            Assert.Equal(247.0f, io.KeysData494.DownDuration, 5);
            Assert.Equal(123.5f, io.KeysData494.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData494.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 495 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData495_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 247.5f, DownDurationPrev = 123.75f, AnalogValue = 0.75f };
            io.KeysData495 = value;
            Assert.Equal((byte)1, io.KeysData495.Down);
            Assert.Equal(247.5f, io.KeysData495.DownDuration, 5);
            Assert.Equal(123.75f, io.KeysData495.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData495.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 496 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData496_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 248.0f, DownDurationPrev = 124.0f, AnalogValue = 0.75f };
            io.KeysData496 = value;
            Assert.Equal((byte)1, io.KeysData496.Down);
            Assert.Equal(248.0f, io.KeysData496.DownDuration, 5);
            Assert.Equal(124.0f, io.KeysData496.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData496.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 497 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData497_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 248.5f, DownDurationPrev = 124.25f, AnalogValue = 0.75f };
            io.KeysData497 = value;
            Assert.Equal((byte)1, io.KeysData497.Down);
            Assert.Equal(248.5f, io.KeysData497.DownDuration, 5);
            Assert.Equal(124.25f, io.KeysData497.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData497.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 498 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData498_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 249.0f, DownDurationPrev = 124.5f, AnalogValue = 0.75f };
            io.KeysData498 = value;
            Assert.Equal((byte)1, io.KeysData498.Down);
            Assert.Equal(249.0f, io.KeysData498.DownDuration, 5);
            Assert.Equal(124.5f, io.KeysData498.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData498.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 499 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData499_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 249.5f, DownDurationPrev = 124.75f, AnalogValue = 0.75f };
            io.KeysData499 = value;
            Assert.Equal((byte)1, io.KeysData499.Down);
            Assert.Equal(249.5f, io.KeysData499.DownDuration, 5);
            Assert.Equal(124.75f, io.KeysData499.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData499.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 500 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData500_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 250.0f, DownDurationPrev = 125.0f, AnalogValue = 0.75f };
            io.KeysData500 = value;
            Assert.Equal((byte)1, io.KeysData500.Down);
            Assert.Equal(250.0f, io.KeysData500.DownDuration, 5);
            Assert.Equal(125.0f, io.KeysData500.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData500.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 501 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData501_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 250.5f, DownDurationPrev = 125.25f, AnalogValue = 0.75f };
            io.KeysData501 = value;
            Assert.Equal((byte)1, io.KeysData501.Down);
            Assert.Equal(250.5f, io.KeysData501.DownDuration, 5);
            Assert.Equal(125.25f, io.KeysData501.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData501.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 502 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData502_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 251.0f, DownDurationPrev = 125.5f, AnalogValue = 0.75f };
            io.KeysData502 = value;
            Assert.Equal((byte)1, io.KeysData502.Down);
            Assert.Equal(251.0f, io.KeysData502.DownDuration, 5);
            Assert.Equal(125.5f, io.KeysData502.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData502.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 503 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData503_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 251.5f, DownDurationPrev = 125.75f, AnalogValue = 0.75f };
            io.KeysData503 = value;
            Assert.Equal((byte)1, io.KeysData503.Down);
            Assert.Equal(251.5f, io.KeysData503.DownDuration, 5);
            Assert.Equal(125.75f, io.KeysData503.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData503.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 504 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData504_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 252.0f, DownDurationPrev = 126.0f, AnalogValue = 0.75f };
            io.KeysData504 = value;
            Assert.Equal((byte)1, io.KeysData504.Down);
            Assert.Equal(252.0f, io.KeysData504.DownDuration, 5);
            Assert.Equal(126.0f, io.KeysData504.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData504.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 505 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData505_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 252.5f, DownDurationPrev = 126.25f, AnalogValue = 0.75f };
            io.KeysData505 = value;
            Assert.Equal((byte)1, io.KeysData505.Down);
            Assert.Equal(252.5f, io.KeysData505.DownDuration, 5);
            Assert.Equal(126.25f, io.KeysData505.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData505.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 506 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData506_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 253.0f, DownDurationPrev = 126.5f, AnalogValue = 0.75f };
            io.KeysData506 = value;
            Assert.Equal((byte)1, io.KeysData506.Down);
            Assert.Equal(253.0f, io.KeysData506.DownDuration, 5);
            Assert.Equal(126.5f, io.KeysData506.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData506.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 507 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData507_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 253.5f, DownDurationPrev = 126.75f, AnalogValue = 0.75f };
            io.KeysData507 = value;
            Assert.Equal((byte)1, io.KeysData507.Down);
            Assert.Equal(253.5f, io.KeysData507.DownDuration, 5);
            Assert.Equal(126.75f, io.KeysData507.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData507.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 508 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData508_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 254.0f, DownDurationPrev = 127.0f, AnalogValue = 0.75f };
            io.KeysData508 = value;
            Assert.Equal((byte)1, io.KeysData508.Down);
            Assert.Equal(254.0f, io.KeysData508.DownDuration, 5);
            Assert.Equal(127.0f, io.KeysData508.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData508.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 509 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData509_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 254.5f, DownDurationPrev = 127.25f, AnalogValue = 0.75f };
            io.KeysData509 = value;
            Assert.Equal((byte)1, io.KeysData509.Down);
            Assert.Equal(254.5f, io.KeysData509.DownDuration, 5);
            Assert.Equal(127.25f, io.KeysData509.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData509.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 510 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData510_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 255.0f, DownDurationPrev = 127.5f, AnalogValue = 0.75f };
            io.KeysData510 = value;
            Assert.Equal((byte)1, io.KeysData510.Down);
            Assert.Equal(255.0f, io.KeysData510.DownDuration, 5);
            Assert.Equal(127.5f, io.KeysData510.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData510.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 511 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData511_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 255.5f, DownDurationPrev = 127.75f, AnalogValue = 0.75f };
            io.KeysData511 = value;
            Assert.Equal((byte)1, io.KeysData511.Down);
            Assert.Equal(255.5f, io.KeysData511.DownDuration, 5);
            Assert.Equal(127.75f, io.KeysData511.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData511.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 512 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData512_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 256.0f, DownDurationPrev = 128.0f, AnalogValue = 0.75f };
            io.KeysData512 = value;
            Assert.Equal((byte)1, io.KeysData512.Down);
            Assert.Equal(256.0f, io.KeysData512.DownDuration, 5);
            Assert.Equal(128.0f, io.KeysData512.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData512.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 513 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData513_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 256.5f, DownDurationPrev = 128.25f, AnalogValue = 0.75f };
            io.KeysData513 = value;
            Assert.Equal((byte)1, io.KeysData513.Down);
            Assert.Equal(256.5f, io.KeysData513.DownDuration, 5);
            Assert.Equal(128.25f, io.KeysData513.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData513.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 514 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData514_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 257.0f, DownDurationPrev = 128.5f, AnalogValue = 0.75f };
            io.KeysData514 = value;
            Assert.Equal((byte)1, io.KeysData514.Down);
            Assert.Equal(257.0f, io.KeysData514.DownDuration, 5);
            Assert.Equal(128.5f, io.KeysData514.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData514.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 515 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData515_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 257.5f, DownDurationPrev = 128.75f, AnalogValue = 0.75f };
            io.KeysData515 = value;
            Assert.Equal((byte)1, io.KeysData515.Down);
            Assert.Equal(257.5f, io.KeysData515.DownDuration, 5);
            Assert.Equal(128.75f, io.KeysData515.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData515.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 516 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData516_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 258.0f, DownDurationPrev = 129.0f, AnalogValue = 0.75f };
            io.KeysData516 = value;
            Assert.Equal((byte)1, io.KeysData516.Down);
            Assert.Equal(258.0f, io.KeysData516.DownDuration, 5);
            Assert.Equal(129.0f, io.KeysData516.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData516.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 517 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData517_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 258.5f, DownDurationPrev = 129.25f, AnalogValue = 0.75f };
            io.KeysData517 = value;
            Assert.Equal((byte)1, io.KeysData517.Down);
            Assert.Equal(258.5f, io.KeysData517.DownDuration, 5);
            Assert.Equal(129.25f, io.KeysData517.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData517.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 518 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData518_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 259.0f, DownDurationPrev = 129.5f, AnalogValue = 0.75f };
            io.KeysData518 = value;
            Assert.Equal((byte)1, io.KeysData518.Down);
            Assert.Equal(259.0f, io.KeysData518.DownDuration, 5);
            Assert.Equal(129.5f, io.KeysData518.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData518.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 519 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData519_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 259.5f, DownDurationPrev = 129.75f, AnalogValue = 0.75f };
            io.KeysData519 = value;
            Assert.Equal((byte)1, io.KeysData519.Down);
            Assert.Equal(259.5f, io.KeysData519.DownDuration, 5);
            Assert.Equal(129.75f, io.KeysData519.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData519.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 520 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData520_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 260.0f, DownDurationPrev = 130.0f, AnalogValue = 0.75f };
            io.KeysData520 = value;
            Assert.Equal((byte)1, io.KeysData520.Down);
            Assert.Equal(260.0f, io.KeysData520.DownDuration, 5);
            Assert.Equal(130.0f, io.KeysData520.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData520.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 521 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData521_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 260.5f, DownDurationPrev = 130.25f, AnalogValue = 0.75f };
            io.KeysData521 = value;
            Assert.Equal((byte)1, io.KeysData521.Down);
            Assert.Equal(260.5f, io.KeysData521.DownDuration, 5);
            Assert.Equal(130.25f, io.KeysData521.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData521.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 522 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData522_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 261.0f, DownDurationPrev = 130.5f, AnalogValue = 0.75f };
            io.KeysData522 = value;
            Assert.Equal((byte)1, io.KeysData522.Down);
            Assert.Equal(261.0f, io.KeysData522.DownDuration, 5);
            Assert.Equal(130.5f, io.KeysData522.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData522.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 523 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData523_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 261.5f, DownDurationPrev = 130.75f, AnalogValue = 0.75f };
            io.KeysData523 = value;
            Assert.Equal((byte)1, io.KeysData523.Down);
            Assert.Equal(261.5f, io.KeysData523.DownDuration, 5);
            Assert.Equal(130.75f, io.KeysData523.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData523.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 524 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData524_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 262.0f, DownDurationPrev = 131.0f, AnalogValue = 0.75f };
            io.KeysData524 = value;
            Assert.Equal((byte)1, io.KeysData524.Down);
            Assert.Equal(262.0f, io.KeysData524.DownDuration, 5);
            Assert.Equal(131.0f, io.KeysData524.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData524.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 525 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData525_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 262.5f, DownDurationPrev = 131.25f, AnalogValue = 0.75f };
            io.KeysData525 = value;
            Assert.Equal((byte)1, io.KeysData525.Down);
            Assert.Equal(262.5f, io.KeysData525.DownDuration, 5);
            Assert.Equal(131.25f, io.KeysData525.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData525.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 526 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData526_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 263.0f, DownDurationPrev = 131.5f, AnalogValue = 0.75f };
            io.KeysData526 = value;
            Assert.Equal((byte)1, io.KeysData526.Down);
            Assert.Equal(263.0f, io.KeysData526.DownDuration, 5);
            Assert.Equal(131.5f, io.KeysData526.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData526.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 527 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData527_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 263.5f, DownDurationPrev = 131.75f, AnalogValue = 0.75f };
            io.KeysData527 = value;
            Assert.Equal((byte)1, io.KeysData527.Down);
            Assert.Equal(263.5f, io.KeysData527.DownDuration, 5);
            Assert.Equal(131.75f, io.KeysData527.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData527.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 528 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData528_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 264.0f, DownDurationPrev = 132.0f, AnalogValue = 0.75f };
            io.KeysData528 = value;
            Assert.Equal((byte)1, io.KeysData528.Down);
            Assert.Equal(264.0f, io.KeysData528.DownDuration, 5);
            Assert.Equal(132.0f, io.KeysData528.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData528.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 529 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData529_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 264.5f, DownDurationPrev = 132.25f, AnalogValue = 0.75f };
            io.KeysData529 = value;
            Assert.Equal((byte)1, io.KeysData529.Down);
            Assert.Equal(264.5f, io.KeysData529.DownDuration, 5);
            Assert.Equal(132.25f, io.KeysData529.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData529.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 530 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData530_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 265.0f, DownDurationPrev = 132.5f, AnalogValue = 0.75f };
            io.KeysData530 = value;
            Assert.Equal((byte)1, io.KeysData530.Down);
            Assert.Equal(265.0f, io.KeysData530.DownDuration, 5);
            Assert.Equal(132.5f, io.KeysData530.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData530.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 531 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData531_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 265.5f, DownDurationPrev = 132.75f, AnalogValue = 0.75f };
            io.KeysData531 = value;
            Assert.Equal((byte)1, io.KeysData531.Down);
            Assert.Equal(265.5f, io.KeysData531.DownDuration, 5);
            Assert.Equal(132.75f, io.KeysData531.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData531.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 532 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData532_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 266.0f, DownDurationPrev = 133.0f, AnalogValue = 0.75f };
            io.KeysData532 = value;
            Assert.Equal((byte)1, io.KeysData532.Down);
            Assert.Equal(266.0f, io.KeysData532.DownDuration, 5);
            Assert.Equal(133.0f, io.KeysData532.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData532.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 533 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData533_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 266.5f, DownDurationPrev = 133.25f, AnalogValue = 0.75f };
            io.KeysData533 = value;
            Assert.Equal((byte)1, io.KeysData533.Down);
            Assert.Equal(266.5f, io.KeysData533.DownDuration, 5);
            Assert.Equal(133.25f, io.KeysData533.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData533.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 534 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData534_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 267.0f, DownDurationPrev = 133.5f, AnalogValue = 0.75f };
            io.KeysData534 = value;
            Assert.Equal((byte)1, io.KeysData534.Down);
            Assert.Equal(267.0f, io.KeysData534.DownDuration, 5);
            Assert.Equal(133.5f, io.KeysData534.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData534.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 535 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData535_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 267.5f, DownDurationPrev = 133.75f, AnalogValue = 0.75f };
            io.KeysData535 = value;
            Assert.Equal((byte)1, io.KeysData535.Down);
            Assert.Equal(267.5f, io.KeysData535.DownDuration, 5);
            Assert.Equal(133.75f, io.KeysData535.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData535.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 536 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData536_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 268.0f, DownDurationPrev = 134.0f, AnalogValue = 0.75f };
            io.KeysData536 = value;
            Assert.Equal((byte)1, io.KeysData536.Down);
            Assert.Equal(268.0f, io.KeysData536.DownDuration, 5);
            Assert.Equal(134.0f, io.KeysData536.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData536.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 537 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData537_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 268.5f, DownDurationPrev = 134.25f, AnalogValue = 0.75f };
            io.KeysData537 = value;
            Assert.Equal((byte)1, io.KeysData537.Down);
            Assert.Equal(268.5f, io.KeysData537.DownDuration, 5);
            Assert.Equal(134.25f, io.KeysData537.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData537.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 538 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData538_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 269.0f, DownDurationPrev = 134.5f, AnalogValue = 0.75f };
            io.KeysData538 = value;
            Assert.Equal((byte)1, io.KeysData538.Down);
            Assert.Equal(269.0f, io.KeysData538.DownDuration, 5);
            Assert.Equal(134.5f, io.KeysData538.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData538.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 539 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData539_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 269.5f, DownDurationPrev = 134.75f, AnalogValue = 0.75f };
            io.KeysData539 = value;
            Assert.Equal((byte)1, io.KeysData539.Down);
            Assert.Equal(269.5f, io.KeysData539.DownDuration, 5);
            Assert.Equal(134.75f, io.KeysData539.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData539.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 540 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData540_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 270.0f, DownDurationPrev = 135.0f, AnalogValue = 0.75f };
            io.KeysData540 = value;
            Assert.Equal((byte)1, io.KeysData540.Down);
            Assert.Equal(270.0f, io.KeysData540.DownDuration, 5);
            Assert.Equal(135.0f, io.KeysData540.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData540.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 541 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData541_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 270.5f, DownDurationPrev = 135.25f, AnalogValue = 0.75f };
            io.KeysData541 = value;
            Assert.Equal((byte)1, io.KeysData541.Down);
            Assert.Equal(270.5f, io.KeysData541.DownDuration, 5);
            Assert.Equal(135.25f, io.KeysData541.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData541.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 542 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData542_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 271.0f, DownDurationPrev = 135.5f, AnalogValue = 0.75f };
            io.KeysData542 = value;
            Assert.Equal((byte)1, io.KeysData542.Down);
            Assert.Equal(271.0f, io.KeysData542.DownDuration, 5);
            Assert.Equal(135.5f, io.KeysData542.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData542.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 543 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData543_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 271.5f, DownDurationPrev = 135.75f, AnalogValue = 0.75f };
            io.KeysData543 = value;
            Assert.Equal((byte)1, io.KeysData543.Down);
            Assert.Equal(271.5f, io.KeysData543.DownDuration, 5);
            Assert.Equal(135.75f, io.KeysData543.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData543.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 544 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData544_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 272.0f, DownDurationPrev = 136.0f, AnalogValue = 0.75f };
            io.KeysData544 = value;
            Assert.Equal((byte)1, io.KeysData544.Down);
            Assert.Equal(272.0f, io.KeysData544.DownDuration, 5);
            Assert.Equal(136.0f, io.KeysData544.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData544.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 545 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData545_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 272.5f, DownDurationPrev = 136.25f, AnalogValue = 0.75f };
            io.KeysData545 = value;
            Assert.Equal((byte)1, io.KeysData545.Down);
            Assert.Equal(272.5f, io.KeysData545.DownDuration, 5);
            Assert.Equal(136.25f, io.KeysData545.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData545.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 546 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData546_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 273.0f, DownDurationPrev = 136.5f, AnalogValue = 0.75f };
            io.KeysData546 = value;
            Assert.Equal((byte)1, io.KeysData546.Down);
            Assert.Equal(273.0f, io.KeysData546.DownDuration, 5);
            Assert.Equal(136.5f, io.KeysData546.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData546.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 547 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData547_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 273.5f, DownDurationPrev = 136.75f, AnalogValue = 0.75f };
            io.KeysData547 = value;
            Assert.Equal((byte)1, io.KeysData547.Down);
            Assert.Equal(273.5f, io.KeysData547.DownDuration, 5);
            Assert.Equal(136.75f, io.KeysData547.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData547.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 548 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData548_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 274.0f, DownDurationPrev = 137.0f, AnalogValue = 0.75f };
            io.KeysData548 = value;
            Assert.Equal((byte)1, io.KeysData548.Down);
            Assert.Equal(274.0f, io.KeysData548.DownDuration, 5);
            Assert.Equal(137.0f, io.KeysData548.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData548.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 549 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData549_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 274.5f, DownDurationPrev = 137.25f, AnalogValue = 0.75f };
            io.KeysData549 = value;
            Assert.Equal((byte)1, io.KeysData549.Down);
            Assert.Equal(274.5f, io.KeysData549.DownDuration, 5);
            Assert.Equal(137.25f, io.KeysData549.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData549.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 550 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData550_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 275.0f, DownDurationPrev = 137.5f, AnalogValue = 0.75f };
            io.KeysData550 = value;
            Assert.Equal((byte)1, io.KeysData550.Down);
            Assert.Equal(275.0f, io.KeysData550.DownDuration, 5);
            Assert.Equal(137.5f, io.KeysData550.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData550.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 551 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData551_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 275.5f, DownDurationPrev = 137.75f, AnalogValue = 0.75f };
            io.KeysData551 = value;
            Assert.Equal((byte)1, io.KeysData551.Down);
            Assert.Equal(275.5f, io.KeysData551.DownDuration, 5);
            Assert.Equal(137.75f, io.KeysData551.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData551.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 552 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData552_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 276.0f, DownDurationPrev = 138.0f, AnalogValue = 0.75f };
            io.KeysData552 = value;
            Assert.Equal((byte)1, io.KeysData552.Down);
            Assert.Equal(276.0f, io.KeysData552.DownDuration, 5);
            Assert.Equal(138.0f, io.KeysData552.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData552.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 553 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData553_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 276.5f, DownDurationPrev = 138.25f, AnalogValue = 0.75f };
            io.KeysData553 = value;
            Assert.Equal((byte)1, io.KeysData553.Down);
            Assert.Equal(276.5f, io.KeysData553.DownDuration, 5);
            Assert.Equal(138.25f, io.KeysData553.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData553.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 554 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData554_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 277.0f, DownDurationPrev = 138.5f, AnalogValue = 0.75f };
            io.KeysData554 = value;
            Assert.Equal((byte)1, io.KeysData554.Down);
            Assert.Equal(277.0f, io.KeysData554.DownDuration, 5);
            Assert.Equal(138.5f, io.KeysData554.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData554.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 555 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData555_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 277.5f, DownDurationPrev = 138.75f, AnalogValue = 0.75f };
            io.KeysData555 = value;
            Assert.Equal((byte)1, io.KeysData555.Down);
            Assert.Equal(277.5f, io.KeysData555.DownDuration, 5);
            Assert.Equal(138.75f, io.KeysData555.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData555.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 556 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData556_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 278.0f, DownDurationPrev = 139.0f, AnalogValue = 0.75f };
            io.KeysData556 = value;
            Assert.Equal((byte)1, io.KeysData556.Down);
            Assert.Equal(278.0f, io.KeysData556.DownDuration, 5);
            Assert.Equal(139.0f, io.KeysData556.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData556.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 557 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData557_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 278.5f, DownDurationPrev = 139.25f, AnalogValue = 0.75f };
            io.KeysData557 = value;
            Assert.Equal((byte)1, io.KeysData557.Down);
            Assert.Equal(278.5f, io.KeysData557.DownDuration, 5);
            Assert.Equal(139.25f, io.KeysData557.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData557.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 558 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData558_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 279.0f, DownDurationPrev = 139.5f, AnalogValue = 0.75f };
            io.KeysData558 = value;
            Assert.Equal((byte)1, io.KeysData558.Down);
            Assert.Equal(279.0f, io.KeysData558.DownDuration, 5);
            Assert.Equal(139.5f, io.KeysData558.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData558.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 559 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData559_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 279.5f, DownDurationPrev = 139.75f, AnalogValue = 0.75f };
            io.KeysData559 = value;
            Assert.Equal((byte)1, io.KeysData559.Down);
            Assert.Equal(279.5f, io.KeysData559.DownDuration, 5);
            Assert.Equal(139.75f, io.KeysData559.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData559.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 560 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData560_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 280.0f, DownDurationPrev = 140.0f, AnalogValue = 0.75f };
            io.KeysData560 = value;
            Assert.Equal((byte)1, io.KeysData560.Down);
            Assert.Equal(280.0f, io.KeysData560.DownDuration, 5);
            Assert.Equal(140.0f, io.KeysData560.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData560.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 561 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData561_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 280.5f, DownDurationPrev = 140.25f, AnalogValue = 0.75f };
            io.KeysData561 = value;
            Assert.Equal((byte)1, io.KeysData561.Down);
            Assert.Equal(280.5f, io.KeysData561.DownDuration, 5);
            Assert.Equal(140.25f, io.KeysData561.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData561.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 562 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData562_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 281.0f, DownDurationPrev = 140.5f, AnalogValue = 0.75f };
            io.KeysData562 = value;
            Assert.Equal((byte)1, io.KeysData562.Down);
            Assert.Equal(281.0f, io.KeysData562.DownDuration, 5);
            Assert.Equal(140.5f, io.KeysData562.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData562.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 563 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData563_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 281.5f, DownDurationPrev = 140.75f, AnalogValue = 0.75f };
            io.KeysData563 = value;
            Assert.Equal((byte)1, io.KeysData563.Down);
            Assert.Equal(281.5f, io.KeysData563.DownDuration, 5);
            Assert.Equal(140.75f, io.KeysData563.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData563.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 564 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData564_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 282.0f, DownDurationPrev = 141.0f, AnalogValue = 0.75f };
            io.KeysData564 = value;
            Assert.Equal((byte)1, io.KeysData564.Down);
            Assert.Equal(282.0f, io.KeysData564.DownDuration, 5);
            Assert.Equal(141.0f, io.KeysData564.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData564.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 565 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData565_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 282.5f, DownDurationPrev = 141.25f, AnalogValue = 0.75f };
            io.KeysData565 = value;
            Assert.Equal((byte)1, io.KeysData565.Down);
            Assert.Equal(282.5f, io.KeysData565.DownDuration, 5);
            Assert.Equal(141.25f, io.KeysData565.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData565.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 566 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData566_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 283.0f, DownDurationPrev = 141.5f, AnalogValue = 0.75f };
            io.KeysData566 = value;
            Assert.Equal((byte)1, io.KeysData566.Down);
            Assert.Equal(283.0f, io.KeysData566.DownDuration, 5);
            Assert.Equal(141.5f, io.KeysData566.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData566.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 567 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData567_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 283.5f, DownDurationPrev = 141.75f, AnalogValue = 0.75f };
            io.KeysData567 = value;
            Assert.Equal((byte)1, io.KeysData567.Down);
            Assert.Equal(283.5f, io.KeysData567.DownDuration, 5);
            Assert.Equal(141.75f, io.KeysData567.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData567.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 568 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData568_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 284.0f, DownDurationPrev = 142.0f, AnalogValue = 0.75f };
            io.KeysData568 = value;
            Assert.Equal((byte)1, io.KeysData568.Down);
            Assert.Equal(284.0f, io.KeysData568.DownDuration, 5);
            Assert.Equal(142.0f, io.KeysData568.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData568.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 569 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData569_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 284.5f, DownDurationPrev = 142.25f, AnalogValue = 0.75f };
            io.KeysData569 = value;
            Assert.Equal((byte)1, io.KeysData569.Down);
            Assert.Equal(284.5f, io.KeysData569.DownDuration, 5);
            Assert.Equal(142.25f, io.KeysData569.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData569.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 570 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData570_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 285.0f, DownDurationPrev = 142.5f, AnalogValue = 0.75f };
            io.KeysData570 = value;
            Assert.Equal((byte)1, io.KeysData570.Down);
            Assert.Equal(285.0f, io.KeysData570.DownDuration, 5);
            Assert.Equal(142.5f, io.KeysData570.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData570.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 571 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData571_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 285.5f, DownDurationPrev = 142.75f, AnalogValue = 0.75f };
            io.KeysData571 = value;
            Assert.Equal((byte)1, io.KeysData571.Down);
            Assert.Equal(285.5f, io.KeysData571.DownDuration, 5);
            Assert.Equal(142.75f, io.KeysData571.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData571.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 572 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData572_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 286.0f, DownDurationPrev = 143.0f, AnalogValue = 0.75f };
            io.KeysData572 = value;
            Assert.Equal((byte)1, io.KeysData572.Down);
            Assert.Equal(286.0f, io.KeysData572.DownDuration, 5);
            Assert.Equal(143.0f, io.KeysData572.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData572.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 573 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData573_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 286.5f, DownDurationPrev = 143.25f, AnalogValue = 0.75f };
            io.KeysData573 = value;
            Assert.Equal((byte)1, io.KeysData573.Down);
            Assert.Equal(286.5f, io.KeysData573.DownDuration, 5);
            Assert.Equal(143.25f, io.KeysData573.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData573.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 574 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData574_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 287.0f, DownDurationPrev = 143.5f, AnalogValue = 0.75f };
            io.KeysData574 = value;
            Assert.Equal((byte)1, io.KeysData574.Down);
            Assert.Equal(287.0f, io.KeysData574.DownDuration, 5);
            Assert.Equal(143.5f, io.KeysData574.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData574.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 575 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData575_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 287.5f, DownDurationPrev = 143.75f, AnalogValue = 0.75f };
            io.KeysData575 = value;
            Assert.Equal((byte)1, io.KeysData575.Down);
            Assert.Equal(287.5f, io.KeysData575.DownDuration, 5);
            Assert.Equal(143.75f, io.KeysData575.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData575.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 576 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData576_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 288.0f, DownDurationPrev = 144.0f, AnalogValue = 0.75f };
            io.KeysData576 = value;
            Assert.Equal((byte)1, io.KeysData576.Down);
            Assert.Equal(288.0f, io.KeysData576.DownDuration, 5);
            Assert.Equal(144.0f, io.KeysData576.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData576.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 577 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData577_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 288.5f, DownDurationPrev = 144.25f, AnalogValue = 0.75f };
            io.KeysData577 = value;
            Assert.Equal((byte)1, io.KeysData577.Down);
            Assert.Equal(288.5f, io.KeysData577.DownDuration, 5);
            Assert.Equal(144.25f, io.KeysData577.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData577.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 578 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData578_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 289.0f, DownDurationPrev = 144.5f, AnalogValue = 0.75f };
            io.KeysData578 = value;
            Assert.Equal((byte)1, io.KeysData578.Down);
            Assert.Equal(289.0f, io.KeysData578.DownDuration, 5);
            Assert.Equal(144.5f, io.KeysData578.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData578.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 579 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData579_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 289.5f, DownDurationPrev = 144.75f, AnalogValue = 0.75f };
            io.KeysData579 = value;
            Assert.Equal((byte)1, io.KeysData579.Down);
            Assert.Equal(289.5f, io.KeysData579.DownDuration, 5);
            Assert.Equal(144.75f, io.KeysData579.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData579.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 580 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData580_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 290.0f, DownDurationPrev = 145.0f, AnalogValue = 0.75f };
            io.KeysData580 = value;
            Assert.Equal((byte)1, io.KeysData580.Down);
            Assert.Equal(290.0f, io.KeysData580.DownDuration, 5);
            Assert.Equal(145.0f, io.KeysData580.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData580.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 581 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData581_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 290.5f, DownDurationPrev = 145.25f, AnalogValue = 0.75f };
            io.KeysData581 = value;
            Assert.Equal((byte)1, io.KeysData581.Down);
            Assert.Equal(290.5f, io.KeysData581.DownDuration, 5);
            Assert.Equal(145.25f, io.KeysData581.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData581.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 582 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData582_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 291.0f, DownDurationPrev = 145.5f, AnalogValue = 0.75f };
            io.KeysData582 = value;
            Assert.Equal((byte)1, io.KeysData582.Down);
            Assert.Equal(291.0f, io.KeysData582.DownDuration, 5);
            Assert.Equal(145.5f, io.KeysData582.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData582.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 583 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData583_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 291.5f, DownDurationPrev = 145.75f, AnalogValue = 0.75f };
            io.KeysData583 = value;
            Assert.Equal((byte)1, io.KeysData583.Down);
            Assert.Equal(291.5f, io.KeysData583.DownDuration, 5);
            Assert.Equal(145.75f, io.KeysData583.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData583.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 584 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData584_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 292.0f, DownDurationPrev = 146.0f, AnalogValue = 0.75f };
            io.KeysData584 = value;
            Assert.Equal((byte)1, io.KeysData584.Down);
            Assert.Equal(292.0f, io.KeysData584.DownDuration, 5);
            Assert.Equal(146.0f, io.KeysData584.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData584.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 585 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData585_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 292.5f, DownDurationPrev = 146.25f, AnalogValue = 0.75f };
            io.KeysData585 = value;
            Assert.Equal((byte)1, io.KeysData585.Down);
            Assert.Equal(292.5f, io.KeysData585.DownDuration, 5);
            Assert.Equal(146.25f, io.KeysData585.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData585.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 586 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData586_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 293.0f, DownDurationPrev = 146.5f, AnalogValue = 0.75f };
            io.KeysData586 = value;
            Assert.Equal((byte)1, io.KeysData586.Down);
            Assert.Equal(293.0f, io.KeysData586.DownDuration, 5);
            Assert.Equal(146.5f, io.KeysData586.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData586.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 587 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData587_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 293.5f, DownDurationPrev = 146.75f, AnalogValue = 0.75f };
            io.KeysData587 = value;
            Assert.Equal((byte)1, io.KeysData587.Down);
            Assert.Equal(293.5f, io.KeysData587.DownDuration, 5);
            Assert.Equal(146.75f, io.KeysData587.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData587.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 588 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData588_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 294.0f, DownDurationPrev = 147.0f, AnalogValue = 0.75f };
            io.KeysData588 = value;
            Assert.Equal((byte)1, io.KeysData588.Down);
            Assert.Equal(294.0f, io.KeysData588.DownDuration, 5);
            Assert.Equal(147.0f, io.KeysData588.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData588.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 589 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData589_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 294.5f, DownDurationPrev = 147.25f, AnalogValue = 0.75f };
            io.KeysData589 = value;
            Assert.Equal((byte)1, io.KeysData589.Down);
            Assert.Equal(294.5f, io.KeysData589.DownDuration, 5);
            Assert.Equal(147.25f, io.KeysData589.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData589.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 590 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData590_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 295.0f, DownDurationPrev = 147.5f, AnalogValue = 0.75f };
            io.KeysData590 = value;
            Assert.Equal((byte)1, io.KeysData590.Down);
            Assert.Equal(295.0f, io.KeysData590.DownDuration, 5);
            Assert.Equal(147.5f, io.KeysData590.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData590.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 591 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData591_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 295.5f, DownDurationPrev = 147.75f, AnalogValue = 0.75f };
            io.KeysData591 = value;
            Assert.Equal((byte)1, io.KeysData591.Down);
            Assert.Equal(295.5f, io.KeysData591.DownDuration, 5);
            Assert.Equal(147.75f, io.KeysData591.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData591.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 592 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData592_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 296.0f, DownDurationPrev = 148.0f, AnalogValue = 0.75f };
            io.KeysData592 = value;
            Assert.Equal((byte)1, io.KeysData592.Down);
            Assert.Equal(296.0f, io.KeysData592.DownDuration, 5);
            Assert.Equal(148.0f, io.KeysData592.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData592.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 593 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData593_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 296.5f, DownDurationPrev = 148.25f, AnalogValue = 0.75f };
            io.KeysData593 = value;
            Assert.Equal((byte)1, io.KeysData593.Down);
            Assert.Equal(296.5f, io.KeysData593.DownDuration, 5);
            Assert.Equal(148.25f, io.KeysData593.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData593.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 594 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData594_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 297.0f, DownDurationPrev = 148.5f, AnalogValue = 0.75f };
            io.KeysData594 = value;
            Assert.Equal((byte)1, io.KeysData594.Down);
            Assert.Equal(297.0f, io.KeysData594.DownDuration, 5);
            Assert.Equal(148.5f, io.KeysData594.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData594.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 595 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData595_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 297.5f, DownDurationPrev = 148.75f, AnalogValue = 0.75f };
            io.KeysData595 = value;
            Assert.Equal((byte)1, io.KeysData595.Down);
            Assert.Equal(297.5f, io.KeysData595.DownDuration, 5);
            Assert.Equal(148.75f, io.KeysData595.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData595.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 596 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData596_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 298.0f, DownDurationPrev = 149.0f, AnalogValue = 0.75f };
            io.KeysData596 = value;
            Assert.Equal((byte)1, io.KeysData596.Down);
            Assert.Equal(298.0f, io.KeysData596.DownDuration, 5);
            Assert.Equal(149.0f, io.KeysData596.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData596.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 597 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData597_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 298.5f, DownDurationPrev = 149.25f, AnalogValue = 0.75f };
            io.KeysData597 = value;
            Assert.Equal((byte)1, io.KeysData597.Down);
            Assert.Equal(298.5f, io.KeysData597.DownDuration, 5);
            Assert.Equal(149.25f, io.KeysData597.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData597.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 598 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData598_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 299.0f, DownDurationPrev = 149.5f, AnalogValue = 0.75f };
            io.KeysData598 = value;
            Assert.Equal((byte)1, io.KeysData598.Down);
            Assert.Equal(299.0f, io.KeysData598.DownDuration, 5);
            Assert.Equal(149.5f, io.KeysData598.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData598.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 599 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData599_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 299.5f, DownDurationPrev = 149.75f, AnalogValue = 0.75f };
            io.KeysData599 = value;
            Assert.Equal((byte)1, io.KeysData599.Down);
            Assert.Equal(299.5f, io.KeysData599.DownDuration, 5);
            Assert.Equal(149.75f, io.KeysData599.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData599.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 600 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData600_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 300.0f, DownDurationPrev = 150.0f, AnalogValue = 0.75f };
            io.KeysData600 = value;
            Assert.Equal((byte)1, io.KeysData600.Down);
            Assert.Equal(300.0f, io.KeysData600.DownDuration, 5);
            Assert.Equal(150.0f, io.KeysData600.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData600.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 601 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData601_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 300.5f, DownDurationPrev = 150.25f, AnalogValue = 0.75f };
            io.KeysData601 = value;
            Assert.Equal((byte)1, io.KeysData601.Down);
            Assert.Equal(300.5f, io.KeysData601.DownDuration, 5);
            Assert.Equal(150.25f, io.KeysData601.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData601.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 602 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData602_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 301.0f, DownDurationPrev = 150.5f, AnalogValue = 0.75f };
            io.KeysData602 = value;
            Assert.Equal((byte)1, io.KeysData602.Down);
            Assert.Equal(301.0f, io.KeysData602.DownDuration, 5);
            Assert.Equal(150.5f, io.KeysData602.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData602.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 603 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData603_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 301.5f, DownDurationPrev = 150.75f, AnalogValue = 0.75f };
            io.KeysData603 = value;
            Assert.Equal((byte)1, io.KeysData603.Down);
            Assert.Equal(301.5f, io.KeysData603.DownDuration, 5);
            Assert.Equal(150.75f, io.KeysData603.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData603.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 604 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData604_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 302.0f, DownDurationPrev = 151.0f, AnalogValue = 0.75f };
            io.KeysData604 = value;
            Assert.Equal((byte)1, io.KeysData604.Down);
            Assert.Equal(302.0f, io.KeysData604.DownDuration, 5);
            Assert.Equal(151.0f, io.KeysData604.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData604.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 605 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData605_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 302.5f, DownDurationPrev = 151.25f, AnalogValue = 0.75f };
            io.KeysData605 = value;
            Assert.Equal((byte)1, io.KeysData605.Down);
            Assert.Equal(302.5f, io.KeysData605.DownDuration, 5);
            Assert.Equal(151.25f, io.KeysData605.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData605.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 606 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData606_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 303.0f, DownDurationPrev = 151.5f, AnalogValue = 0.75f };
            io.KeysData606 = value;
            Assert.Equal((byte)1, io.KeysData606.Down);
            Assert.Equal(303.0f, io.KeysData606.DownDuration, 5);
            Assert.Equal(151.5f, io.KeysData606.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData606.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 607 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData607_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 303.5f, DownDurationPrev = 151.75f, AnalogValue = 0.75f };
            io.KeysData607 = value;
            Assert.Equal((byte)1, io.KeysData607.Down);
            Assert.Equal(303.5f, io.KeysData607.DownDuration, 5);
            Assert.Equal(151.75f, io.KeysData607.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData607.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 608 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData608_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 304.0f, DownDurationPrev = 152.0f, AnalogValue = 0.75f };
            io.KeysData608 = value;
            Assert.Equal((byte)1, io.KeysData608.Down);
            Assert.Equal(304.0f, io.KeysData608.DownDuration, 5);
            Assert.Equal(152.0f, io.KeysData608.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData608.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 609 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData609_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 304.5f, DownDurationPrev = 152.25f, AnalogValue = 0.75f };
            io.KeysData609 = value;
            Assert.Equal((byte)1, io.KeysData609.Down);
            Assert.Equal(304.5f, io.KeysData609.DownDuration, 5);
            Assert.Equal(152.25f, io.KeysData609.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData609.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 610 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData610_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 305.0f, DownDurationPrev = 152.5f, AnalogValue = 0.75f };
            io.KeysData610 = value;
            Assert.Equal((byte)1, io.KeysData610.Down);
            Assert.Equal(305.0f, io.KeysData610.DownDuration, 5);
            Assert.Equal(152.5f, io.KeysData610.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData610.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 611 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData611_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 305.5f, DownDurationPrev = 152.75f, AnalogValue = 0.75f };
            io.KeysData611 = value;
            Assert.Equal((byte)1, io.KeysData611.Down);
            Assert.Equal(305.5f, io.KeysData611.DownDuration, 5);
            Assert.Equal(152.75f, io.KeysData611.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData611.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 612 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData612_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 306.0f, DownDurationPrev = 153.0f, AnalogValue = 0.75f };
            io.KeysData612 = value;
            Assert.Equal((byte)1, io.KeysData612.Down);
            Assert.Equal(306.0f, io.KeysData612.DownDuration, 5);
            Assert.Equal(153.0f, io.KeysData612.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData612.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 613 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData613_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 306.5f, DownDurationPrev = 153.25f, AnalogValue = 0.75f };
            io.KeysData613 = value;
            Assert.Equal((byte)1, io.KeysData613.Down);
            Assert.Equal(306.5f, io.KeysData613.DownDuration, 5);
            Assert.Equal(153.25f, io.KeysData613.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData613.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 614 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData614_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 307.0f, DownDurationPrev = 153.5f, AnalogValue = 0.75f };
            io.KeysData614 = value;
            Assert.Equal((byte)1, io.KeysData614.Down);
            Assert.Equal(307.0f, io.KeysData614.DownDuration, 5);
            Assert.Equal(153.5f, io.KeysData614.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData614.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 615 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData615_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 307.5f, DownDurationPrev = 153.75f, AnalogValue = 0.75f };
            io.KeysData615 = value;
            Assert.Equal((byte)1, io.KeysData615.Down);
            Assert.Equal(307.5f, io.KeysData615.DownDuration, 5);
            Assert.Equal(153.75f, io.KeysData615.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData615.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 616 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData616_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 308.0f, DownDurationPrev = 154.0f, AnalogValue = 0.75f };
            io.KeysData616 = value;
            Assert.Equal((byte)1, io.KeysData616.Down);
            Assert.Equal(308.0f, io.KeysData616.DownDuration, 5);
            Assert.Equal(154.0f, io.KeysData616.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData616.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 617 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData617_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 308.5f, DownDurationPrev = 154.25f, AnalogValue = 0.75f };
            io.KeysData617 = value;
            Assert.Equal((byte)1, io.KeysData617.Down);
            Assert.Equal(308.5f, io.KeysData617.DownDuration, 5);
            Assert.Equal(154.25f, io.KeysData617.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData617.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 618 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData618_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 309.0f, DownDurationPrev = 154.5f, AnalogValue = 0.75f };
            io.KeysData618 = value;
            Assert.Equal((byte)1, io.KeysData618.Down);
            Assert.Equal(309.0f, io.KeysData618.DownDuration, 5);
            Assert.Equal(154.5f, io.KeysData618.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData618.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 619 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData619_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 309.5f, DownDurationPrev = 154.75f, AnalogValue = 0.75f };
            io.KeysData619 = value;
            Assert.Equal((byte)1, io.KeysData619.Down);
            Assert.Equal(309.5f, io.KeysData619.DownDuration, 5);
            Assert.Equal(154.75f, io.KeysData619.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData619.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 620 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData620_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 310.0f, DownDurationPrev = 155.0f, AnalogValue = 0.75f };
            io.KeysData620 = value;
            Assert.Equal((byte)1, io.KeysData620.Down);
            Assert.Equal(310.0f, io.KeysData620.DownDuration, 5);
            Assert.Equal(155.0f, io.KeysData620.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData620.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 621 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData621_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 310.5f, DownDurationPrev = 155.25f, AnalogValue = 0.75f };
            io.KeysData621 = value;
            Assert.Equal((byte)1, io.KeysData621.Down);
            Assert.Equal(310.5f, io.KeysData621.DownDuration, 5);
            Assert.Equal(155.25f, io.KeysData621.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData621.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 622 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData622_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 311.0f, DownDurationPrev = 155.5f, AnalogValue = 0.75f };
            io.KeysData622 = value;
            Assert.Equal((byte)1, io.KeysData622.Down);
            Assert.Equal(311.0f, io.KeysData622.DownDuration, 5);
            Assert.Equal(155.5f, io.KeysData622.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData622.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 623 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData623_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 311.5f, DownDurationPrev = 155.75f, AnalogValue = 0.75f };
            io.KeysData623 = value;
            Assert.Equal((byte)1, io.KeysData623.Down);
            Assert.Equal(311.5f, io.KeysData623.DownDuration, 5);
            Assert.Equal(155.75f, io.KeysData623.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData623.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 624 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData624_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 312.0f, DownDurationPrev = 156.0f, AnalogValue = 0.75f };
            io.KeysData624 = value;
            Assert.Equal((byte)1, io.KeysData624.Down);
            Assert.Equal(312.0f, io.KeysData624.DownDuration, 5);
            Assert.Equal(156.0f, io.KeysData624.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData624.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 625 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData625_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 312.5f, DownDurationPrev = 156.25f, AnalogValue = 0.75f };
            io.KeysData625 = value;
            Assert.Equal((byte)1, io.KeysData625.Down);
            Assert.Equal(312.5f, io.KeysData625.DownDuration, 5);
            Assert.Equal(156.25f, io.KeysData625.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData625.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 626 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData626_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 313.0f, DownDurationPrev = 156.5f, AnalogValue = 0.75f };
            io.KeysData626 = value;
            Assert.Equal((byte)1, io.KeysData626.Down);
            Assert.Equal(313.0f, io.KeysData626.DownDuration, 5);
            Assert.Equal(156.5f, io.KeysData626.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData626.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 627 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData627_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 313.5f, DownDurationPrev = 156.75f, AnalogValue = 0.75f };
            io.KeysData627 = value;
            Assert.Equal((byte)1, io.KeysData627.Down);
            Assert.Equal(313.5f, io.KeysData627.DownDuration, 5);
            Assert.Equal(156.75f, io.KeysData627.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData627.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 628 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData628_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 314.0f, DownDurationPrev = 157.0f, AnalogValue = 0.75f };
            io.KeysData628 = value;
            Assert.Equal((byte)1, io.KeysData628.Down);
            Assert.Equal(314.0f, io.KeysData628.DownDuration, 5);
            Assert.Equal(157.0f, io.KeysData628.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData628.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 629 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData629_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 314.5f, DownDurationPrev = 157.25f, AnalogValue = 0.75f };
            io.KeysData629 = value;
            Assert.Equal((byte)1, io.KeysData629.Down);
            Assert.Equal(314.5f, io.KeysData629.DownDuration, 5);
            Assert.Equal(157.25f, io.KeysData629.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData629.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 630 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData630_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 315.0f, DownDurationPrev = 157.5f, AnalogValue = 0.75f };
            io.KeysData630 = value;
            Assert.Equal((byte)1, io.KeysData630.Down);
            Assert.Equal(315.0f, io.KeysData630.DownDuration, 5);
            Assert.Equal(157.5f, io.KeysData630.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData630.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 631 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData631_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 315.5f, DownDurationPrev = 157.75f, AnalogValue = 0.75f };
            io.KeysData631 = value;
            Assert.Equal((byte)1, io.KeysData631.Down);
            Assert.Equal(315.5f, io.KeysData631.DownDuration, 5);
            Assert.Equal(157.75f, io.KeysData631.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData631.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 632 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData632_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 316.0f, DownDurationPrev = 158.0f, AnalogValue = 0.75f };
            io.KeysData632 = value;
            Assert.Equal((byte)1, io.KeysData632.Down);
            Assert.Equal(316.0f, io.KeysData632.DownDuration, 5);
            Assert.Equal(158.0f, io.KeysData632.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData632.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 633 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData633_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 316.5f, DownDurationPrev = 158.25f, AnalogValue = 0.75f };
            io.KeysData633 = value;
            Assert.Equal((byte)1, io.KeysData633.Down);
            Assert.Equal(316.5f, io.KeysData633.DownDuration, 5);
            Assert.Equal(158.25f, io.KeysData633.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData633.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 634 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData634_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 317.0f, DownDurationPrev = 158.5f, AnalogValue = 0.75f };
            io.KeysData634 = value;
            Assert.Equal((byte)1, io.KeysData634.Down);
            Assert.Equal(317.0f, io.KeysData634.DownDuration, 5);
            Assert.Equal(158.5f, io.KeysData634.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData634.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 635 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData635_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 317.5f, DownDurationPrev = 158.75f, AnalogValue = 0.75f };
            io.KeysData635 = value;
            Assert.Equal((byte)1, io.KeysData635.Down);
            Assert.Equal(317.5f, io.KeysData635.DownDuration, 5);
            Assert.Equal(158.75f, io.KeysData635.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData635.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 636 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData636_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 318.0f, DownDurationPrev = 159.0f, AnalogValue = 0.75f };
            io.KeysData636 = value;
            Assert.Equal((byte)1, io.KeysData636.Down);
            Assert.Equal(318.0f, io.KeysData636.DownDuration, 5);
            Assert.Equal(159.0f, io.KeysData636.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData636.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 637 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData637_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 318.5f, DownDurationPrev = 159.25f, AnalogValue = 0.75f };
            io.KeysData637 = value;
            Assert.Equal((byte)1, io.KeysData637.Down);
            Assert.Equal(318.5f, io.KeysData637.DownDuration, 5);
            Assert.Equal(159.25f, io.KeysData637.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData637.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 638 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData638_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 319.0f, DownDurationPrev = 159.5f, AnalogValue = 0.75f };
            io.KeysData638 = value;
            Assert.Equal((byte)1, io.KeysData638.Down);
            Assert.Equal(319.0f, io.KeysData638.DownDuration, 5);
            Assert.Equal(159.5f, io.KeysData638.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData638.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 639 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData639_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 319.5f, DownDurationPrev = 159.75f, AnalogValue = 0.75f };
            io.KeysData639 = value;
            Assert.Equal((byte)1, io.KeysData639.Down);
            Assert.Equal(319.5f, io.KeysData639.DownDuration, 5);
            Assert.Equal(159.75f, io.KeysData639.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData639.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 640 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData640_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 320.0f, DownDurationPrev = 160.0f, AnalogValue = 0.75f };
            io.KeysData640 = value;
            Assert.Equal((byte)1, io.KeysData640.Down);
            Assert.Equal(320.0f, io.KeysData640.DownDuration, 5);
            Assert.Equal(160.0f, io.KeysData640.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData640.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 641 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData641_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 320.5f, DownDurationPrev = 160.25f, AnalogValue = 0.75f };
            io.KeysData641 = value;
            Assert.Equal((byte)1, io.KeysData641.Down);
            Assert.Equal(320.5f, io.KeysData641.DownDuration, 5);
            Assert.Equal(160.25f, io.KeysData641.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData641.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 642 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData642_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 321.0f, DownDurationPrev = 160.5f, AnalogValue = 0.75f };
            io.KeysData642 = value;
            Assert.Equal((byte)1, io.KeysData642.Down);
            Assert.Equal(321.0f, io.KeysData642.DownDuration, 5);
            Assert.Equal(160.5f, io.KeysData642.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData642.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 643 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData643_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 321.5f, DownDurationPrev = 160.75f, AnalogValue = 0.75f };
            io.KeysData643 = value;
            Assert.Equal((byte)1, io.KeysData643.Down);
            Assert.Equal(321.5f, io.KeysData643.DownDuration, 5);
            Assert.Equal(160.75f, io.KeysData643.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData643.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 644 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData644_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 322.0f, DownDurationPrev = 161.0f, AnalogValue = 0.75f };
            io.KeysData644 = value;
            Assert.Equal((byte)1, io.KeysData644.Down);
            Assert.Equal(322.0f, io.KeysData644.DownDuration, 5);
            Assert.Equal(161.0f, io.KeysData644.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData644.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 645 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData645_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 322.5f, DownDurationPrev = 161.25f, AnalogValue = 0.75f };
            io.KeysData645 = value;
            Assert.Equal((byte)1, io.KeysData645.Down);
            Assert.Equal(322.5f, io.KeysData645.DownDuration, 5);
            Assert.Equal(161.25f, io.KeysData645.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData645.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 646 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData646_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 323.0f, DownDurationPrev = 161.5f, AnalogValue = 0.75f };
            io.KeysData646 = value;
            Assert.Equal((byte)1, io.KeysData646.Down);
            Assert.Equal(323.0f, io.KeysData646.DownDuration, 5);
            Assert.Equal(161.5f, io.KeysData646.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData646.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 647 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData647_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 323.5f, DownDurationPrev = 161.75f, AnalogValue = 0.75f };
            io.KeysData647 = value;
            Assert.Equal((byte)1, io.KeysData647.Down);
            Assert.Equal(323.5f, io.KeysData647.DownDuration, 5);
            Assert.Equal(161.75f, io.KeysData647.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData647.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 648 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData648_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 324.0f, DownDurationPrev = 162.0f, AnalogValue = 0.75f };
            io.KeysData648 = value;
            Assert.Equal((byte)1, io.KeysData648.Down);
            Assert.Equal(324.0f, io.KeysData648.DownDuration, 5);
            Assert.Equal(162.0f, io.KeysData648.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData648.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 649 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData649_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 324.5f, DownDurationPrev = 162.25f, AnalogValue = 0.75f };
            io.KeysData649 = value;
            Assert.Equal((byte)1, io.KeysData649.Down);
            Assert.Equal(324.5f, io.KeysData649.DownDuration, 5);
            Assert.Equal(162.25f, io.KeysData649.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData649.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 650 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData650_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 325.0f, DownDurationPrev = 162.5f, AnalogValue = 0.75f };
            io.KeysData650 = value;
            Assert.Equal((byte)1, io.KeysData650.Down);
            Assert.Equal(325.0f, io.KeysData650.DownDuration, 5);
            Assert.Equal(162.5f, io.KeysData650.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData650.AnalogValue, 5);
        }

        /// <summary>
        ///     Tests that keys data 651 set and get returns correct value
        /// </summary>
         [RequireCImguiSystemFact]
        public void KeysData651_SetAndGet_ReturnsCorrectValue()
        {
            ImGuiIo io = new ImGuiIo();
            ImGuiKeyData value = new ImGuiKeyData { Down = 1, DownDuration = 325.5f, DownDurationPrev = 162.75f, AnalogValue = 0.75f };
            io.KeysData651 = value;
            Assert.Equal((byte)1, io.KeysData651.Down);
            Assert.Equal(325.5f, io.KeysData651.DownDuration, 5);
            Assert.Equal(162.75f, io.KeysData651.DownDurationPrev, 5);
            Assert.Equal(0.75f, io.KeysData651.AnalogValue, 5);
        }
    }
}
