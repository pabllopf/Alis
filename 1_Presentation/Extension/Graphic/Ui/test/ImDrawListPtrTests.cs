// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtrTests.cs
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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Xunit;
using Alis.Extension.Graphic.Ui;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im draw list ptr tests class
    /// </summary>
    public class ImDrawListPtrTests
    {
        /// <summary>
        ///     Tests that the int ptr constructor stores the native pointer
        /// </summary>
        [Fact]
        public void IntPtrCtor_StoresNativePointer()
        {
            IntPtr raw = new IntPtr(0x1234);
            ImDrawListPtr ptr = new ImDrawListPtr(raw);
            Assert.Equal(raw, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that the implicit int ptr conversion returns the native pointer
        /// </summary>
        [Fact]
        public void ImplicitToIntPtr_ReturnsNativePointer()
        {
            ImDrawListPtr ptr = new ImDrawListPtr(new IntPtr(0x1234));
            IntPtr raw = ptr;
            Assert.Equal(ptr.NativePtr, raw);
        }

        /// <summary>
        ///     Tests that the implicit conversion from int ptr wraps the pointer
        /// </summary>
        [Fact]
        public void ImplicitFromIntPtr_WrapsPointer()
        {
            IntPtr raw = new IntPtr(0x1234);
            ImDrawListPtr ptr = raw;
            Assert.Equal(raw, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests that the im draw list constructor allocates native memory
        /// </summary>
        [Fact]
        public void ImDrawListCtor_AllocatesNativeMemory()
        {
            ImDrawList src = new ImDrawList();
            ImDrawListPtr ptr = new ImDrawListPtr(src);
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Creates a source im draw list instance with all fields populated
        /// </summary>
        private static ImDrawList CreateSource()
        {
            ImDrawList src = new ImDrawList();
            src.CmdBuffer = new ImVector();
            src.IdxBuffer = new ImVector();
            src.VtxBuffer = new ImVector();
            src.Flags = (ImDrawListFlags)0;
            src.VtxCurrentIdx = 42;
            src.Data = new IntPtr(7);
            src.OwnerName = new IntPtr(8);
            src.VtxWritePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawVert>());
            src.IdxWritePtr = new IntPtr(10);
            src.ClipRectStack = new ImVector();
            src.TextureIdStack = new ImVector();
            src.Path = new ImVector();
            src.CmdHeader = new ImDrawCmdHeader();
            src.Splitter = new ImDrawListSplitter();
            src.FringeScale = 2.5f;
            return src;
        }

        /// <summary>
        ///     Creates a draw list pointer instance from the source
        /// </summary>
        private static ImDrawListPtr CreatePtr()
        {
            return new ImDrawListPtr(CreateSource());
        }

        /// <summary>
        ///     Tests that flags round trips through the pointer
        /// </summary>
        [Fact]
        public void Flags_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.Equal((ImDrawListFlags)0, ptr.Flags);
        }

        /// <summary>
        ///     Tests that vtx current idx round trips
        /// </summary>
        [Fact]
        public void VtxCurrentIdx_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.Equal(42u, ptr.VtxCurrentIdx);
        }

        /// <summary>
        ///     Tests that data round trips
        /// </summary>
        [Fact]
        public void Data_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.Equal(new IntPtr(7), ptr.Data);
        }

        /// <summary>
        ///     Tests that owner name round trips
        /// </summary>
        [Fact]
        public void OwnerName_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            NullTerminatedString ownerName = ptr.OwnerName;
            Assert.NotNull(ownerName);
        }

        /// <summary>
        ///     Tests that vtx write ptr reads the pointed to vert
        /// </summary>
        [Fact]
        public void VtxWritePtr_Getter_ReadsVert()
        {
            ImDrawListPtr ptr = CreatePtr();
            ImDrawVert vert = ptr.VtxWritePtr;
            Assert.NotNull(vert);
        }

        /// <summary>
        ///     Tests that idx write ptr round trips
        /// </summary>
        [Fact]
        public void IdxWritePtr_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.Equal(new IntPtr(10), ptr.IdxWritePtr);
        }

        /// <summary>
        ///     Tests that fringe scale round trips
        /// </summary>
        [Fact]
        public void FringeScale_Getter_MatchesSource()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.Equal(2.5f, ptr.FringeScale);
        }

        /// <summary>
        ///     Tests that the vector wrappers are produced without throwing
        /// </summary>
        [Fact]
        public void VectorProperties_ProduceWrappers()
        {
            ImDrawListPtr ptr = CreatePtr();
            Assert.NotNull(ptr.CmdBuffer);
            Assert.NotNull(ptr.IdxBuffer);
            Assert.NotNull(ptr.VtxBuffer);
            Assert.NotNull(ptr.ClipRectStack);
            Assert.NotNull(ptr.TextureIdStack);
            Assert.NotNull(ptr.Path);
        }

        /// <summary>
        ///     Tests that cmd header round trips
        /// </summary>
        [Fact]
        public void CmdHeader_Getter_ReturnsValue()
        {
            ImDrawListPtr ptr = CreatePtr();
            ImDrawCmdHeader header = ptr.CmdHeader;
            Assert.NotNull(header);
        }

        /// <summary>
        ///     Tests that splitter round trips
        /// </summary>
        [Fact]
        public void Splitter_Getter_ReturnsValue()
        {
            ImDrawListPtr ptr = CreatePtr();
            ImDrawListSplitter splitter = ptr.Splitter;
            Assert.NotNull(splitter);
        }
    }
}