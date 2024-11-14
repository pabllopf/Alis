// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogManagerTest.cs
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
using System.IO;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     The dialog manager test class
    /// </summary>
    public class DialogManagerTest
    {
        /// <summary>
        ///     Tests that add dialog should add dialog to dictionary
        /// </summary>
        [Fact]
        public void AddDialog_ShouldAddDialogToDictionary()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testId", "Test Dialog");
            manager.AddDialog(dialog);
            Assert.True(manager.dialogs.ContainsKey("testId"));
        }

        /// <summary>
        ///     Tests that get dialog should return dialog if exists
        /// </summary>
        [Fact]
        public void GetDialog_ShouldReturnDialogIfExists()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testId", "Test Dialog");
            manager.AddDialog(dialog);
            Dialog result = manager.GetDialog("testId");
            Assert.Equal(dialog, result);
        }

        /// <summary>
        ///     Tests that get dialog should return null if not exists
        /// </summary>
        [Fact]
        public void GetDialog_ShouldReturnNullIfNotExists()
        {
            DialogManager manager = new DialogManager();
            Dialog result = manager.GetDialog("nonExistentId");
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that show dialog should not throw exception if dialog does not exist
        /// </summary>
        [Fact]
        public void ShowDialog_ShouldNotThrowExceptionIfDialogDoesNotExist()
        {
            DialogManager manager = new DialogManager();
            Exception exception = Record.Exception(() => manager.ShowDialog("nonExistentId"));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that show dialog should invoke action on valid option selection
        /// </summary>
        [Fact]
        public void ShowDialog_ShouldInvokeActionOnValidOptionSelection()
        {
            DialogManager manager = new DialogManager();
            bool actionInvoked = false;
            Dialog dialog = new Dialog("testId", "Test Dialog");
            dialog.AddOption(new DialogOption("Option 1", () => { actionInvoked = true; }));
            manager.AddDialog(dialog);

            Console.SetIn(new StringReader("1\n")); // Simulate user input
            manager.ShowDialog("testId");

            Assert.True(actionInvoked);
        }
    }
}