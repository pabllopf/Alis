// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1NullLabelCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;
using Alis.Extension.Graphic.Ui;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui p1 null label coverage tests class
    /// </summary>
    public class ImGuiP1NullLabelCoverageTests
    {
        /// <summary>
        ///     Tests the combo null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Combo_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Combo((string)null, ref currentItem, "a")));
        }

        /// <summary>
        ///     Tests the combo null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Combo_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int currentItem = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Combo((string)null, ref currentItem, "a", 1)));
        }

        /// <summary>
        ///     Tests the debug check version and data layout null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DebugCheckVersionAndDataLayout_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DebugCheckVersionAndDataLayout((string)null, 0, 0, 0, 0, 0, 0)));

        /// <summary>
        ///     Tests the debug text encoding null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DebugTextEncoding_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DebugTextEncoding((string)null)));

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_0_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_1_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v, 0.01f)));
        }

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_2_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v, 0.01f, 0)));
        }

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_3_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v, 0.01f, 0, 1)));
        }

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_4_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v, 0.01f, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat_5_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat((string)null, ref v, 0.01f, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_0_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_1_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v, 0.01f)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_2_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v, 0.01f, 0)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_3_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v, 0.01f, 0, 1)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_4_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v, 0.01f, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat2_5_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat2((string)null, ref v, 0.01f, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_0_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_1_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v, 0.01f)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_2_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v, 0.01f, 0)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_3_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v, 0.01f, 0, 1)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_4_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v, 0.01f, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat3_5_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat3((string)null, ref v, 0.01f, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_0_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_1_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v, 0.01f)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_2_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v, 0.01f, 0)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_3_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v, 0.01f, 0, 1)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_4_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v, 0.01f, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloat4_5_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloat4((string)null, ref v, 0.01f, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_0_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_1_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_2_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f, 0)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_3_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f, 0, 1)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_4_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_5_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f, 0, 1, (string)null, (string)null)));
        }

        /// <summary>
        ///     Tests the drag float range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragFloatRange2_6_NullLabel_ShouldThrowArgumentNullException()
        {
            float vCurrentMin = 0;
            float vCurrentMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragFloatRange2((string)null, ref vCurrentMin, ref vCurrentMax, 0.01f, 0, 1, (string)null, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v)));
        }
    }
}