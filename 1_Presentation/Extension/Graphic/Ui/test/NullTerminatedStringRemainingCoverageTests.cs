// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NullTerminatedStringRemainingCoverageTests.cs
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
    ///     The null terminated string remaining coverage tests class
    /// </summary>
    public class NullTerminatedStringRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that constructor with int ptr should set data
        /// </summary>
         [RequireCImguiSystemFact]
        public void ConstructorWithIntPtr_ShouldSetData()
        {
            IntPtr data = new IntPtr(123);
            NullTerminatedString nts = new NullTerminatedString(data);
            Assert.Equal(data, nts.Data);
        }

        /// <summary>
        ///     Tests that to string with zero data returns empty string
        /// </summary>
         [RequireCImguiSystemFact]
        public void ToString_WithZeroData_ReturnsEmptyString()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            Assert.Equal(string.Empty, nts.ToString());
        }

        /// <summary>
        ///     Tests that implicit operator to string with zero data returns empty string
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImplicitOperator_WithZeroData_ReturnsEmptyString()
        {
            NullTerminatedString nts = new NullTerminatedString(IntPtr.Zero);
            string result = nts;
            Assert.Equal(string.Empty, result);
        }
    }
}
