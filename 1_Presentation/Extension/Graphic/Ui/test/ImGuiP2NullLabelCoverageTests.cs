// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2NullLabelCoverageTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  --------------------------------------------------------------------------
using System;
using Alis.Extension.Graphic.Ui;
using Xunit;
namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui p 2 null label coverage tests class
    /// </summary>
    public class ImGuiP2NullLabelCoverageTests
    {

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_0_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_1_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v, 1.0f, -100)));
        }

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_2_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v, 1.0f, -100, 100)));
        }

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_3_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v, 1.0f, -100, 100, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt_4_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt((string)null, ref v, 1.0f, -100, 100, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_0_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_1_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_2_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v, 1.0f, -100)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_3_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v, 1.0f, -100, 100)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_4_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v, 1.0f, -100, 100, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt2_5_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt2((string)null, ref v, 1.0f, -100, 100, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_0_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_1_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_2_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v, 1.0f, -100)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_3_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v, 1.0f, -100, 100)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_4_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v, 1.0f, -100, 100, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt3_5_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt3((string)null, ref v, 1.0f, -100, 100, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_0_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_1_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_2_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v, 1.0f, -100)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_3_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v, 1.0f, -100, 100)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_4_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v, 1.0f, -100, 100, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragInt4_5_NullLabel_ThrowsArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragInt4((string)null, ref v, 1.0f, -100, 100, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_0_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_1_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_2_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f, -100)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_3_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f, -100, 100)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_4_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f, -100, 100, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_5_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f, -100, 100, (string)null, (string)null)));
        }

        /// <summary>
        ///     Tests the drag int range 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragIntRange2_6_NullLabel_ThrowsArgumentNullException()
        {
            int vMin = 0;
            int vMax = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragIntRange2((string)null, ref vMin, ref vMax, 1.0f, -100, 100, (string)null, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_2_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero, 1.0f, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_3_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero, 1.0f, IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_4_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero, 1.0f, IntPtr.Zero, IntPtr.Zero, (string)null)));
        }

        /// <summary>
        ///     Tests the drag scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalar_5_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalar((string)null, ImGuiDataType.S32, IntPtr.Zero, 1.0f, IntPtr.Zero, IntPtr.Zero, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the drag scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_0_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN((string)null, ImGuiDataType.S32, IntPtr.Zero, 1)));
        }

        /// <summary>
        ///     Tests the drag scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_1_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN((string)null, ImGuiDataType.S32, IntPtr.Zero, 1, 1.0f)));
        }

        /// <summary>
        ///     Tests the drag scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_2_NullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN((string)null, ImGuiDataType.S32, IntPtr.Zero, 1, 1.0f, IntPtr.Zero)));
        }
    }
}
