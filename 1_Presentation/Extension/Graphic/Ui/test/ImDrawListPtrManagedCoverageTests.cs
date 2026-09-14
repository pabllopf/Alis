// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrManagedCoverageTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw list ptr managed coverage tests class
    /// </summary>
    public class ImDrawListPtrManagedCoverageTests
    {
        /// <summary>
        ///     Wraps a default ImDrawList struct into a native pointer
        /// </summary>
        /// <returns>A pointer wrapping a freshly allocated native draw list block</returns>
        private static ImDrawListPtr WrapDefault()
        {
            ImDrawList drawList = default;
            int size = Marshal.SizeOf<ImDrawList>();
            IntPtr nativePtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(drawList, nativePtr, false);
            return new ImDrawListPtr(nativePtr);
        }

        /// <summary>
        ///     Wraps a custom ImDrawList struct into a native pointer
        /// </summary>
        /// <param name="drawList">The managed draw list to marshal into the native block</param>
        /// <returns>A pointer wrapping a freshly allocated native draw list block</returns>
        private static ImDrawListPtr Wrap(ImDrawList drawList)
        {
            int size = Marshal.SizeOf<ImDrawList>();
            IntPtr nativePtr = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(drawList, nativePtr, false);
            return new ImDrawListPtr(nativePtr);
        }

        /// <summary>
        ///     Tests that native ptr after int ptr constructor returns same pointer
        /// </summary>
        [Fact]
        public void NativePtr_AfterIntPtrConstructor_ReturnsSamePointer()
        {
            IntPtr expected = new IntPtr(0xABCD);
            ImDrawListPtr ptr = new ImDrawListPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that native ptr after im draw list constructor returns allocated pointer
        /// </summary>
        [Fact]
        public void NativePtr_AfterImDrawListConstructor_ReturnsAllocatedPointer()
        {
            ImDrawList drawList = default;
            ImDrawListPtr ptr = new ImDrawListPtr(drawList);
            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that constructor with int ptr stores pointer
        /// </summary>
        [Fact]
        public void Constructor_WithIntPtr_StoresPointer()
        {
            IntPtr expected = new IntPtr(1234);
            ImDrawListPtr ptr = new ImDrawListPtr(expected);
            Assert.Equal(expected, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that constructor with im draw list allocates and marshals
        /// </summary>
        [Fact]
        public void Constructor_WithImDrawList_AllocatesAndMarshals()
        {
            ImDrawList drawList = default;
            drawList.VtxCurrentIdx = 42u;
            drawList.FringeScale = 1.5f;
            ImDrawListPtr ptr = new ImDrawListPtr(drawList);
            try
            {
                Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
                Assert.Equal(42u, ptr.VtxCurrentIdx);
                Assert.Equal(1.5f, ptr.FringeScale);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that implicit operator to int ptr returns native ptr
        /// </summary>
        [Fact]
        public void ImplicitOperator_ToIntPtr_ReturnsNativePtr()
        {
            IntPtr native = new IntPtr(0x7777);
            ImDrawListPtr ptr = new ImDrawListPtr(native);
            IntPtr result = ptr;
            Assert.Equal(native, result);
        }

        /// <summary>
        ///     Tests that implicit operator from int ptr returns wrapper
        /// </summary>
        [Fact]
        public void ImplicitOperator_FromIntPtr_ReturnsWrapper()
        {
            IntPtr native = new IntPtr(0x8888);
            ImDrawListPtr ptr = native;
            Assert.Equal(native, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that flags reads correct value
        /// </summary>
        [Fact]
        public void Flags_ReadsCorrectValue()
        {
            ImDrawList drawList = default;
            drawList.Flags = ImDrawListFlags.AntiAliasedFill;
            ImDrawListPtr ptr = Wrap(drawList);
            try
            {
                Assert.Equal(ImDrawListFlags.AntiAliasedFill, ptr.Flags);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that vtx current idx reads correct value
        /// </summary>
        [Fact]
        public void VtxCurrentIdx_ReadsCorrectValue()
        {
            ImDrawList drawList = default;
            drawList.VtxCurrentIdx = 99u;
            ImDrawListPtr ptr = Wrap(drawList);
            try
            {
                Assert.Equal(99u, ptr.VtxCurrentIdx);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that data reads correct value
        /// </summary>
        [Fact]
        public void Data_ReadsCorrectValue()
        {
            ImDrawList drawList = default;
            drawList.Data = new IntPtr(0xDEAD);
            ImDrawListPtr ptr = Wrap(drawList);
            try
            {
                Assert.Equal(new IntPtr(0xDEAD), ptr.Data);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that idx write ptr reads correct value
        /// </summary>
        [Fact]
        public void IdxWritePtr_ReadsCorrectValue()
        {
            ImDrawList drawList = default;
            drawList.IdxWritePtr = new IntPtr(0xBEEF);
            ImDrawListPtr ptr = Wrap(drawList);
            try
            {
                Assert.Equal(new IntPtr(0xBEEF), ptr.IdxWritePtr);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that fringe scale reads correct value
        /// </summary>
        [Fact]
        public void FringeScale_ReadsCorrectValue()
        {
            ImDrawList drawList = default;
            drawList.FringeScale = 2.75f;
            ImDrawListPtr ptr = Wrap(drawList);
            try
            {
                Assert.Equal(2.75f, ptr.FringeScale);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that cmd buffer returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void CmdBuffer_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<ImDrawCmd> cmdBuffer = ptr.CmdBuffer;
                Assert.Equal(0, cmdBuffer.Size);
                Assert.Equal(0, cmdBuffer.Capacity);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that idx buffer returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void IdxBuffer_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<ushort> idxBuffer = ptr.IdxBuffer;
                Assert.Equal(0, idxBuffer.Size);
                Assert.Equal(0, idxBuffer.Capacity);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that vtx buffer returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void VtxBuffer_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<ImDrawVert> vtxBuffer = ptr.VtxBuffer;
                Assert.Equal(0, vtxBuffer.Size);
                Assert.Equal(0, vtxBuffer.Capacity);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that clip rect stack returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void ClipRectStack_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<Alis.Core.Aspect.Math.Vector.Vector4F> clipRectStack = ptr.ClipRectStack;
                Assert.Equal(0, clipRectStack.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that texture id stack returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void TextureIdStack_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<IntPtr> textureIdStack = ptr.TextureIdStack;
                Assert.Equal(0, textureIdStack.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that path returns vector with zero size for default draw list
        /// </summary>
        [Fact]
        public void Path_DefaultDrawList_ReturnsZeroSizeVector()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImVectorG<Alis.Core.Aspect.Math.Vector.Vector2F> path = ptr.Path;
                Assert.Equal(0, path.Size);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that owner name returns null terminated string with zero data for default draw list
        /// </summary>
        [Fact]
        public void OwnerName_DefaultDrawList_ReturnsEmptyString()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                NullTerminatedString ownerName = ptr.OwnerName;
                string result = ownerName;
                Assert.Equal(string.Empty, result);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that cmd header returns default struct for default draw list
        /// </summary>
        [Fact]
        public void CmdHeader_DefaultDrawList_ReturnsDefaultStruct()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImDrawCmdHeader cmdHeader = ptr.CmdHeader;
                Assert.Equal(IntPtr.Zero, cmdHeader.TextureId);
                Assert.Equal(0u, cmdHeader.VtxOffset);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that splitter returns default struct for default draw list
        /// </summary>
        [Fact]
        public void Splitter_DefaultDrawList_ReturnsDefaultStruct()
        {
            ImDrawListPtr ptr = WrapDefault();
            try
            {
                ImDrawListSplitter splitter = ptr.Splitter;
                Assert.Equal(0, splitter.Current);
                Assert.Equal(0, splitter.Count);
            }
            finally
            {
                Marshal.FreeHGlobal(ptr.NativePtr);
            }
        }

        /// <summary>
        ///     Tests that vtx write ptr reads valid im draw vert from prepared pointer
        /// </summary>
        [Fact]
        public void VtxWritePtr_PreparedPointer_ReadsImDrawVert()
        {
            IntPtr vtxVertPtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawVert>());
            try
            {
                ImDrawVert defaultVtx = default;
                Marshal.StructureToPtr(defaultVtx, vtxVertPtr, false);

                ImDrawList drawList = default;
                drawList.VtxWritePtr = vtxVertPtr;

                int drawListSize = Marshal.SizeOf<ImDrawList>();
                IntPtr nativePtr = Marshal.AllocHGlobal(drawListSize);
                Marshal.StructureToPtr(drawList, nativePtr, false);

                ImDrawListPtr ptr = new ImDrawListPtr(nativePtr);
                try
                {
                    ImDrawVert vtx = ptr.VtxWritePtr;
                    Assert.Equal(defaultVtx.Pos, vtx.Pos);
                    Assert.Equal(defaultVtx.Uv, vtx.Uv);
                    Assert.Equal(defaultVtx.Col, vtx.Col);
                }
                finally
                {
                    Marshal.FreeHGlobal(nativePtr);
                }
            }
            finally
            {
                Marshal.FreeHGlobal(vtxVertPtr);
            }
        }
    }
}
