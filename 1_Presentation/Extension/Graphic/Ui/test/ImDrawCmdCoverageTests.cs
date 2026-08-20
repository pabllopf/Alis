// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmdCoverageTests.cs
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
    ///     The im draw cmd coverage tests class
    /// </summary>
    public class ImDrawCmdCoverageTests
    {
        /// <summary>
        ///     Tests that get tex id returns texture id when native library is available
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetTexId_ReturnsTextureId()
        {
            ImDrawCmd drawCmd = new ImDrawCmd {TextureId = new IntPtr(123)};

            IntPtr texId;
            try
            {
                texId = drawCmd.GetTexId();
            }
            catch (DllNotFoundException)
            {
                return;
            }
            catch (EntryPointNotFoundException)
            {
                return;
            }

            Assert.Equal(new IntPtr(123), texId);
        }

        /// <summary>
        ///     Tests that get tex id returns default texture id for default command
        /// </summary>
         [RequireCImguiSystemFact]
        public void GetTexId_Default_ReturnsDefaultTextureId()
        {
            ImDrawCmd drawCmd = default;

            IntPtr texId;
            try
            {
                texId = drawCmd.GetTexId();
            }
            catch (DllNotFoundException)
            {
                return;
            }
            catch (EntryPointNotFoundException)
            {
                return;
            }

            Assert.Equal(IntPtr.Zero, texId);
        }
    }
}
