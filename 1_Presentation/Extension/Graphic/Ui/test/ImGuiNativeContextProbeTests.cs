// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNativeContextProbeTests.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui native context probe tests class
    /// </summary>
    public class ImGuiNativeContextProbeTests
    {
        /// <summary>
        ///     Tests that create context and get version works natively
        /// </summary>
        [Fact]
        public void CreateContext_AndGetVersion_Works()
        {
            IntPtr context = ImGui.CreateContext();
            Assert.NotEqual(IntPtr.Zero, context);

            string version = ImGui.GetVersion();
            Assert.False(string.IsNullOrEmpty(version));

            ImGuiNative.igDestroyContext(context);
        }

        /// <summary>
        ///     Tests that create context without font atlas works natively
        /// </summary>
        [Fact]
        public void CreateContext_WithoutFontAtlas_Works()
        {
            IntPtr context = ImGui.CreateContext();
            try
            {
                Assert.NotEqual(IntPtr.Zero, context);
                ImGuiNative.igGetIO();
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }
    }
}
