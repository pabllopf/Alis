// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogStateTypeTest.cs
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
    ///     Tests for DialogStateType enum
    /// </summary>
    public class DialogStateTypeTest
    {
        /// <summary>
        ///     Tests that dialog state type idle has correct value
        /// </summary>
        [Fact]
        public void DialogStateType_Idle_HasCorrectValue()
        {
            Assert.Equal(0, (int)DialogStateType.Idle);
        }

        /// <summary>
        ///     Tests that dialog state type running has correct value
        /// </summary>
        [Fact]
        public void DialogStateType_Running_HasCorrectValue()
        {
            Assert.Equal(1, (int)DialogStateType.Running);
        }

        /// <summary>
        ///     Tests that dialog state type paused has correct value
        /// </summary>
        [Fact]
        public void DialogStateType_Paused_HasCorrectValue()
        {
            Assert.Equal(2, (int)DialogStateType.Paused);
        }

        /// <summary>
        ///     Tests that dialog state type completed has correct value
        /// </summary>
        [Fact]
        public void DialogStateType_Completed_HasCorrectValue()
        {
            Assert.Equal(3, (int)DialogStateType.Completed);
        }
    }
}

