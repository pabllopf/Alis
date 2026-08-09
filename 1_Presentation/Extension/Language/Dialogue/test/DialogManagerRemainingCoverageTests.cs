// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogManagerRemainingCoverageTests.cs
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
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    /// The dialog manager remaining coverage tests class
    /// </summary>
    public class DialogManagerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that get available options when dialog not in dictionary returns empty
        /// </summary>
        [Fact]
        public void GetAvailableOptions_WhenDialogNotInDictionary_ReturnsEmpty()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testId", "Test");
            manager.AddDialog(dialog);
            manager.StartDialog("testId");

            manager.Dialogs.Clear();

            List<DialogOption> options = manager.GetAvailableOptions();

            Assert.Empty(options);
        }
        
        /// <summary>
        /// Tests that resume dialog when no context does not throw
        /// </summary>
        [Fact]
        public void ResumeDialog_WhenNoContext_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();

            Exception exception = Record.Exception(() => manager.ResumeDialog());

            Assert.Null(exception);
        }

        /// <summary>
        /// Tests that select option with null action does not throw
        /// </summary>
        [Fact]
        public void SelectOption_WithNullAction_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testId", "Test");
            DialogOption option = new DialogOption("Option", null);
            dialog.AddOption(option);
            manager.AddDialog(dialog);
            manager.StartDialog("testId");

            Exception exception = Record.Exception(() => manager.SelectOption(0));

            Assert.Null(exception);
        }
    }
}
