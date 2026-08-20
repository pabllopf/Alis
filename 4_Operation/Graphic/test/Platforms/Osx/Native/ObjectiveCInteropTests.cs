// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ObjectiveCInteropTests.cs
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
    ///     Exercises the Objective-C interop wrappers against the native Objective-C runtime.
    /// </summary>
    public class ObjectiveCInteropTests
    {
        /// <summary>
        ///     Verifies that a known Objective-C class resolves to a non-zero handle.
        /// </summary>
        [MacOsOnly]
        public void Class_WithKnownClass_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Class("NSObject");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that an unknown Objective-C class resolves to zero.
        /// </summary>
        [MacOsOnly]
        public void Class_WithUnknownClass_ReturnsZero()
        {
            IntPtr handle = ObjectiveCInterop.Class("AlisNonExistentClass98765");
            Assert.Equal(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that a known selector resolves to a non-zero handle.
        /// </summary>
        [MacOsOnly]
        public void Sel_WithKnownSelector_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Sel("frame");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that a selector can be registered at runtime.
        /// </summary>
        [MacOsOnly]
        public void Sel_WithNewSelector_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.Sel("alisRuntimeRegisteredSelector123");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that the pre-registered selector fields are initialized to non-zero
        ///     handles by the type initializer.
        /// </summary>
        [MacOsOnly]
        public void StaticSelectorFields_AreInitialized()
        {
            Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.selMouseLocationOutside);
            Assert.NotEqual(IntPtr.Zero, ObjectiveCInterop.selConvertPointFromView);
        }

        /// <summary>
        ///     Verifies that sending a message to a null view returns a zeroed frame.
        /// </summary>
        [MacOsOnly]
        public void NSViewGetFrame_WithNullView_ReturnsZeroedFrame()
        {
            NsRect frame = ObjectiveCInterop.NSViewGetFrame(IntPtr.Zero);
            Assert.Equal(0.0, frame.x);
            Assert.Equal(0.0, frame.y);
        }

        /// <summary>
        ///     Verifies that sending a message to a null window returns a zeroed frame.
        /// </summary>
        [MacOsOnly]
        public void GetWindowFrame_WithNullWindow_ReturnsZeroedFrame()
        {
            NsRect frame = ObjectiveCInterop.GetWindowFrame(IntPtr.Zero);
            Assert.Equal(0.0, frame.x);
            Assert.Equal(0.0, frame.y);
        }

        /// <summary>
        ///     Verifies that a managed string converts into a non-zero NSString handle.
        /// </summary>
        [MacOsOnly]
        public void NsString_WithValidString_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.NsString("hello interop");
            Assert.NotEqual(IntPtr.Zero, handle);
        }

        /// <summary>
        ///     Verifies that converting a null string throws before any native call.
        /// </summary>
        [Fact]
        public void NsString_WithNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ObjectiveCInterop.NsString(null));
        }

        /// <summary>
        ///     Verifies that converting an empty string produces a valid NSString handle.
        /// </summary>
        [MacOsOnly]
        public void NsString_WithEmptyString_ReturnsNonZero()
        {
            IntPtr handle = ObjectiveCInterop.NsString(string.Empty);
            Assert.NotEqual(IntPtr.Zero, handle);
        }
    }
}


#endif