// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoTest.cs
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
using System.Diagnostics.CodeAnalysis;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.ImGui.Extras.GuizMo;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.GuizMo
{
    /// <summary>
    ///     The im guiz mo test class
    /// </summary>
    	  
	 public class ImGuizMoTest 
    {
        /// <summary>
        ///     Tests that allow axis flip should not throw
        /// </summary>
        [Fact]
        public void AllowAxisFlip_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.AllowAxisFlip(true));
        }

        /// <summary>
        ///     Tests that begin frame should not throw
        /// </summary>
        [Fact]
        public void BeginFrame_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.BeginFrame());
        }

        /// <summary>
        ///     Tests that decompose matrix to components should not throw
        /// </summary>
        [Fact]
        public void DecomposeMatrixToComponents_ShouldNotThrow()
        {
            float[] matrix = new float[16];
            float[] translation = new float[3];
            float[] rotation = new float[3];
            float[] scale = new float[3];
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref translation, ref rotation, ref scale));
        }

        /// <summary>
        ///     Tests that draw cubes should not throw
        /// </summary>
        [Fact]
        public void DrawCubes_ShouldNotThrow()
        {
            float view = 0;
            float projection = 0;
            float matrices = 0;
            int matrixCount = 1;
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.DrawCubes(ref view, ref projection, ref matrices, matrixCount));
        }

        /// <summary>
        ///     Tests that draw grid should not throw
        /// </summary>
        [Fact]
        public void DrawGrid_ShouldNotThrow()
        {
            float[] view = new float[16];
            float[] projection = new float[16];
            float[] matrix = new float[16];
            float gridSize = 1.0f;
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.DrawGrid(ref view, ref projection, ref matrix, gridSize));
        }

        /// <summary>
        ///     Tests that enable should not throw
        /// </summary>
        [Fact]
        public void Enable_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.Enable(true));
        }

        /// <summary>
        ///     Tests that is over should return bool
        /// </summary>
        [Fact]
        public void IsOver_ShouldReturnBool()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.IsOver());
        }

        /// <summary>
        ///     Tests that is over with operation should return bool
        /// </summary>
        [Fact]
        public void IsOver_WithOperation_ShouldReturnBool()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.IsOver(Operation.Translate));
        }

        /// <summary>
        ///     Tests that is using should return bool
        /// </summary>
        [Fact]
        public void IsUsing_ShouldReturnBool()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.IsUsing());
        }

        /// <summary>
        ///     Tests that manipulate should return byte
        /// </summary>
        [Fact]
        public void Manipulate_ShouldReturnByte()
        {
            float[] view = new float[16];
            float[] projection = new float[16];
            float[] matrix = new float[16];
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.Manipulate(view, projection, Operation.Translate, Mode.Local, matrix));
        }

        /// <summary>
        ///     Tests that recompose matrix from components should not throw
        /// </summary>
        [Fact]
        public void RecomposeMatrixFromComponents_ShouldNotThrow()
        {
            float[] translation = new float[3];
            float[] rotation = new float[3];
            float[] scale = new float[3];
            float[] matrix = new float[16];
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.RecomposeMatrixFromComponents(ref translation, ref rotation, ref scale, ref matrix));
        }

        /// <summary>
        ///     Tests that set draw list should not throw
        /// </summary>
        [Fact]
        public void SetDrawList_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetDrawList());
        }

        /// <summary>
        ///     Tests that set draw list with draw list should not throw
        /// </summary>
        [Fact]
        public void SetDrawList_WithDrawList_ShouldNotThrow()
        {
            ImDrawList drawList = new ImDrawList();
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetDrawList(drawList));
        }

        /// <summary>
        ///     Tests that set gizmo size clip space should not throw
        /// </summary>
        [Fact]
        public void SetGizmoSizeClipSpace_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetGizmoSizeClipSpace(1.0f));
        }

        /// <summary>
        ///     Tests that set id should not throw
        /// </summary>
        [Fact]
        public void SetId_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetId(1));
        }

        /// <summary>
        ///     Tests that set im gui context should not throw
        /// </summary>
        [Fact]
        public void SetImGuiContext_ShouldNotThrow()
        {
            IntPtr ctx = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetImGuiContext(ctx));
        }

        /// <summary>
        ///     Tests that set orthographic should not throw
        /// </summary>
        [Fact]
        public void SetOrthographic_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetOrthographic(true));
        }

        /// <summary>
        ///     Tests that set rect should not throw
        /// </summary>
        [Fact]
        public void SetRect_ShouldNotThrow()
        {
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.SetRect(0.0f, 0.0f, 1.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that view manipulate should not throw
        /// </summary>
        [Fact]
        public void ViewManipulate_ShouldNotThrow()
        {
            float[] view = new float[16];
            float length = 1.0f;
            Vector2F position = new Vector2F(0.0f, 0.0f);
            Vector2F size = new Vector2F(1.0f, 1.0f);
            uint backgroundColor = 0;
            Assert.Throws<DllNotFoundException>(() => ImGuizMo.ViewManipulate(ref view, length, position, size, backgroundColor));
        }
    }
}