// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrRemainingCoverageTests.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImDrawListPtr remaining coverage tests class
    /// </summary>
    public class ImDrawListPtrRemainingCoverageTests
    {
        /// <summary>
        /// Tests that _CalcCircleAutoSegmentCount throws when native library is unavailable
        /// </summary>
        [Fact]
        public void _CalcCircleAutoSegmentCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance._CalcCircleAutoSegmentCount(0); });
            }
        }

        /// <summary>
        /// Tests that ClearFreeMemory throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ClearFreeMemory_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ClearFreeMemory(); });
            }
        }

        /// <summary>
        /// Tests that OnChangedClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OnChangedClipRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.OnChangedClipRect(); });
            }
        }

        /// <summary>
        /// Tests that OnChangedTextureID throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OnChangedTextureID_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.OnChangedTextureID(); });
            }
        }

        /// <summary>
        /// Tests that OnChangedVtxOffset throws when native library is unavailable
        /// </summary>
        [Fact]
        public void OnChangedVtxOffset_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.OnChangedVtxOffset(); });
            }
        }

        /// <summary>
        /// Tests that PathArcToFastEx throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathArcToFastEx_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathArcToFastEx(default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathArcToN throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathArcToN_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathArcToN(default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PopUnusedDrawCmd throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopUnusedDrawCmd_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PopUnusedDrawCmd(); });
            }
        }

        /// <summary>
        /// Tests that ResetForNewFrame throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ResetForNewFrame_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ResetForNewFrame(); });
            }
        }

        /// <summary>
        /// Tests that TryMergeDrawCmd throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TryMergeDrawCmd_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.TryMergeDrawCmd(); });
            }
        }

        /// <summary>
        /// Tests that AddBezierCubic throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddBezierCubic_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddBezierCubic(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddBezierCubic throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddBezierCubic_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddBezierCubic(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddBezierQuadratic throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddBezierQuadratic_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddBezierQuadratic(default(Vector2F), default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddBezierQuadratic throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddBezierQuadratic_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddBezierQuadratic(default(Vector2F), default(Vector2F), default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCallback throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCallback_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCallback(IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that AddCircle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCircle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCircle(default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCircle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCircle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCircle(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCircle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCircle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCircle(default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCircleFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCircleFilled_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCircleFilled(default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddCircleFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddCircleFilled_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddCircleFilled(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddConvexPolyFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddConvexPolyFilled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); Vector2F points = default;
                Assert.Throws<DllNotFoundException>(() => { instance.AddConvexPolyFilled(ref points, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddDrawCmd throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddDrawCmd_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddDrawCmd(); });
            }
        }

        /// <summary>
        /// Tests that AddImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImage_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImage(IntPtr.Zero, default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImage_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImage(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImage_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImage(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImage_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImage(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that AddImageQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageQuad_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageQuad(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddImageRounded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageRounded_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageRounded(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddImageRounded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddImageRounded_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddImageRounded(IntPtr.Zero, default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddLine_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddLine(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddLine_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddLine(default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddNgon throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddNgon_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddNgon(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddNgon throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddNgon_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddNgon(default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddNgonFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddNgonFilled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddNgonFilled(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddPolyline throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddPolyline_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); Vector2F points = default;
                Assert.Throws<DllNotFoundException>(() => { instance.AddPolyline(ref points, 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddQuad_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddQuad(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddQuad throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddQuad_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddQuad(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddQuadFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddQuadFilled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddQuadFilled(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRect(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRect(default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRect_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRect(default(Vector2F), default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRect_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRect(default(Vector2F), default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddRectFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRectFilled_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRectFilled(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddRectFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRectFilled_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRectFilled(default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddRectFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRectFilled_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRectFilled(default(Vector2F), default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddRectFilledMultiColor throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddRectFilledMultiColor_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddRectFilledMultiColor(default(Vector2F), default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddTriangle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddTriangle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddTriangle(default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that AddTriangle throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddTriangle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddTriangle(default(Vector2F), default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that AddTriangleFilled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddTriangleFilled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddTriangleFilled(default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that ChannelsMerge throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ChannelsMerge_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ChannelsMerge(); });
            }
        }

        /// <summary>
        /// Tests that ChannelsSetCurrent throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ChannelsSetCurrent_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ChannelsSetCurrent(0); });
            }
        }

        /// <summary>
        /// Tests that ChannelsSplit throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ChannelsSplit_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.ChannelsSplit(0); });
            }
        }

        /// <summary>
        /// Tests that CloneOutput throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CloneOutput_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.CloneOutput(); });
            }
        }

        /// <summary>
        /// Tests that GetClipRectMax throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetClipRectMax_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetClipRectMax(); });
            }
        }

        /// <summary>
        /// Tests that GetClipRectMin throws when native library is unavailable
        /// </summary>
        [Fact]
        public void GetClipRectMin_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.GetClipRectMin(); });
            }
        }

        /// <summary>
        /// Tests that PathArcTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathArcTo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathArcTo(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathArcTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathArcTo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathArcTo(default(Vector2F), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathArcToFast throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathArcToFast_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathArcToFast(default(Vector2F), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathBezierCubicCurveTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathBezierCubicCurveTo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathBezierCubicCurveTo(default(Vector2F), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PathBezierCubicCurveTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathBezierCubicCurveTo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathBezierCubicCurveTo(default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PathBezierQuadraticCurveTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathBezierQuadraticCurveTo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathBezierQuadraticCurveTo(default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PathBezierQuadraticCurveTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathBezierQuadraticCurveTo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathBezierQuadraticCurveTo(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PathClear throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathClear_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathClear(); });
            }
        }

        /// <summary>
        /// Tests that PathFillConvex throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathFillConvex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathFillConvex(0); });
            }
        }

        /// <summary>
        /// Tests that PathLineTo throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathLineTo_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathLineTo(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PathLineToMergeDuplicate throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathLineToMergeDuplicate_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathLineToMergeDuplicate(default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PathRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathRect(default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PathRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathRect(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PathRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathRect_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathRect(default(Vector2F), default(Vector2F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathStroke throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathStroke_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathStroke(0); });
            }
        }

        /// <summary>
        /// Tests that PathStroke throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathStroke_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathStroke(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PathStroke throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PathStroke_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PathStroke(0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PopClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopClipRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PopClipRect(); });
            }
        }

        /// <summary>
        /// Tests that PopTextureId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PopTextureId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PopTextureId(); });
            }
        }

        /// <summary>
        /// Tests that PrimQuadUv throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimQuadUv_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimQuadUv(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PrimRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimRect(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PrimRectUv throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimRectUv_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimRectUv(default(Vector2F), default(Vector2F), default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PrimReserve throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimReserve_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimReserve(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PrimUnreserve throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimUnreserve_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimUnreserve(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PrimVtx throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimVtx_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimVtx(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PrimWriteIdx throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimWriteIdx_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimWriteIdx(default(ushort)); });
            }
        }

        /// <summary>
        /// Tests that PrimWriteVtx throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PrimWriteVtx_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PrimWriteVtx(default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that PushClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushClipRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PushClipRect(default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PushClipRect throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushClipRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PushClipRect(default(Vector2F), default(Vector2F), false); });
            }
        }

        /// <summary>
        /// Tests that PushClipRectFullScreen throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushClipRectFullScreen_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PushClipRectFullScreen(); });
            }
        }

        /// <summary>
        /// Tests that PushTextureId throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PushTextureId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.PushTextureId(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that AddText throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddText_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddText(default(Vector2F), 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that AddText throws when native library is unavailable
        /// </summary>
        [Fact]
        public void AddText_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                ImDrawListPtr instance = new ImDrawListPtr(IntPtr.Zero); 
                Assert.Throws<DllNotFoundException>(() => { instance.AddText(default(ImFontPtr), 0, default(Vector2F), 0, "label"); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImDrawListPtrRemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
