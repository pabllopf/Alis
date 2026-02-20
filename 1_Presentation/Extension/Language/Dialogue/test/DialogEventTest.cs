// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogEventTest.cs
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
    ///     Tests for DialogEvent
    /// </summary>
    public class DialogEventTest
    {
        /// <summary>
        ///     Tests that dialog event constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void DialogEvent_Constructor_InitializesPropertiesCorrectly()
        {
            DialogEventType eventType = DialogEventType.OnDialogStart;
            string dialogId = "testDialog";

            DialogEvent dialogEvent = new DialogEvent(eventType, dialogId);

            Assert.Equal(eventType, dialogEvent.EventType);
            Assert.Equal(dialogId, dialogEvent.DialogId);
            Assert.False(dialogEvent.IsHandled);
            Assert.Null(dialogEvent.Data);
        }

        /// <summary>
        ///     Tests that dialog event data property works correctly
        /// </summary>
        [Fact]
        public void DialogEvent_Data_WorksCorrectly()
        {
            DialogEvent dialogEvent = new DialogEvent(DialogEventType.OnOptionSelected, "testDialog");
            object testData = new { Text = "Test Option" };

            dialogEvent.Data = testData;

            Assert.Equal(testData, dialogEvent.Data);
        }

        /// <summary>
        ///     Tests that dialog event handled flag works correctly
        /// </summary>
        [Fact]
        public void DialogEvent_IsHandled_WorksCorrectly()
        {
            DialogEvent dialogEvent = new DialogEvent(DialogEventType.OnDialogStart, "testDialog");

            Assert.False(dialogEvent.IsHandled);

            dialogEvent.IsHandled = true;

            Assert.True(dialogEvent.IsHandled);
        }
    }
}

