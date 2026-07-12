// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlatformSetWindowTitleTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="PlatformSetWindowTitle" /> delegate behavior.
    /// </summary>
    public class PlatformSetWindowTitleTest
    {
        /// <summary>
        ///     Verifies that the delegate receives the expected title pointer.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Invoke_ShouldReceiveExpectedTitlePointer()
        {
            IntPtr expectedTitle = Marshal.StringToHGlobalAnsi("UI Test Window");
            IntPtr captured = IntPtr.Zero;
            PlatformSetWindowTitle callback = (_, title) => captured = title;

            try
            {
                callback(new ImGuiViewportPtr(IntPtr.Zero), expectedTitle);
                Assert.Equal(expectedTitle, captured);
            }
            finally
            {
                Marshal.FreeHGlobal(expectedTitle);
            }
        }
    }
}