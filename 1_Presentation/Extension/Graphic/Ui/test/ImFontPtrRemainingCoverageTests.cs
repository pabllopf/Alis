// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtrRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font ptr remaining coverage tests class
    /// </summary>
    public class ImFontPtrRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor assigns native ptr
        /// </summary>
         [RequireCImguiSystemFact]
        public void Constructor_AssignsNativePtr()
        {
            ImFontPtr fontPtr = new ImFontPtr(new IntPtr(1234));

            Assert.Equal(new IntPtr(1234), fontPtr.NativePtr);
        }

        /// <summary>
        ///     Tests that implicit cast to int ptr returns native ptr
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitCast_ToIntPtr_ReturnsNativePtr()
        {
            ImFontPtr fontPtr = new ImFontPtr(new IntPtr(5678));

            IntPtr result = fontPtr;

            Assert.Equal(new IntPtr(5678), result);
        }

        /// <summary>
        ///     Tests that implicit cast from int ptr creates wrapper
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitCast_FromIntPtr_CreatesWrapper()
        {
            ImFontPtr fontPtr = new IntPtr(999);

            Assert.Equal(new IntPtr(999), fontPtr.NativePtr);
        }
    }
}
