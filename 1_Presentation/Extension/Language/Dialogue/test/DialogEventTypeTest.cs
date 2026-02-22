// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogEventTypeTest.cs
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

using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogEventType enum
    /// </summary>
    public class DialogEventTypeTest
    {
        /// <summary>
        ///     Tests that on dialog start event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnDialogStart_HasCorrectValue()
        {
            Assert.Equal(0, (int)DialogEventType.OnDialogStart);
        }

        /// <summary>
        ///     Tests that on dialog end event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnDialogEnd_HasCorrectValue()
        {
            Assert.Equal(1, (int)DialogEventType.OnDialogEnd);
        }

        /// <summary>
        ///     Tests that on option selected event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnOptionSelected_HasCorrectValue()
        {
            Assert.Equal(2, (int)DialogEventType.OnOptionSelected);
        }

        /// <summary>
        ///     Tests that on option validated event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnOptionValidated_HasCorrectValue()
        {
            Assert.Equal(3, (int)DialogEventType.OnOptionValidated);
        }

        /// <summary>
        ///     Tests that on state changed event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnStateChanged_HasCorrectValue()
        {
            Assert.Equal(4, (int)DialogEventType.OnStateChanged);
        }
    }
}

