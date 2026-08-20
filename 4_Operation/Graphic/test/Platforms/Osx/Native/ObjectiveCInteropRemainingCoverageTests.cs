// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectiveCInteropRemainingCoverageTests.cs
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

#if osx

using System;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx.Native
{
    /// <summary>
    ///     Exercises the remaining Objective-C interop edge cases against the native runtime.
    /// </summary>
    public class ObjectiveCInteropRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that a Foundation class resolves to a non-zero handle.
        /// </summary>
        [MacOsOnly]
        public void Class_WithNSStringClass_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Class("NSString");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that an empty class name resolves to zero without throwing.
        /// </summary>
        [MacOsOnly]
        public void Class_WithEmptyName_ReturnsZero()
        {
            IntPtr handle = ObjectiveCInterop.Class(string.Empty);
            Assert.Equal(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that an empty selector name still registers a valid selector handle.
        /// </summary>
        [MacOsOnly]
        public void Sel_WithEmptyName_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Sel(string.Empty);
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that Unicode UTF-8 content converts into a non-zero NSString handle.
        /// </summary>
        [MacOsOnly]
        public void NsString_WithUnicodeUtf8Content_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.NsString("café 日本語");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that whitespace-only content converts into a non-zero NSString handle.
        /// </summary>
        [MacOsOnly]
        public void NsString_WithWhitespaceContent_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.NsString("   ");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that a converted ASCII string reports the expected length through the runtime.
        /// </summary>
        [MacOsOnly]
        public void NsString_WithAsciiContent_ReportsExpectedLength()
        {
            IntPtr handle = ObjectiveCInterop.NsString("interop");
            IntPtr selector = ObjectiveCInterop.Sel("length");
            ulong length = ObjectiveCInterop.objc_msgSend_UL(handle, selector);
            Assert.Equal(7UL, length);
        }

        /// <summary>
        ///     Verifies that the converted string is a distinct NSString instance on the runtime heap.
        /// </summary>
        [MacOsOnly]
        public void NsString_IsAnObject_RespondsToIsKindOfClass()
        {
            IntPtr handle = ObjectiveCInterop.NsString("object");
            IntPtr selector = ObjectiveCInterop.Sel("isKindOfClass:");
            IntPtr nsStringClass = ObjectiveCInterop.Class("NSString");
            IntPtr result = ObjectiveCInterop.objc_msgSend_IntPtr(handle, selector, nsStringClass);
            Assert.NotEqual(IntPtr.Zero, result);
        }
    }
}

#endif