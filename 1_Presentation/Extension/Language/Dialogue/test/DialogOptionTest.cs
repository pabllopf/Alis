// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogOptionTest.cs
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

//  File:DialogOptionTest.cs
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


using System;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     The dialog option test class
    /// </summary>
    public class DialogOptionTest
    {
        /// <summary>
        ///     Tests that dialog option constructor sets properties correctly
        /// </summary>
        [Fact]
        public void DialogOption_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string expectedText = "Option Text";
            Action expectedAction = () => Logger.Info("Action executed");

            // Act
            DialogOption option = new DialogOption(expectedText, expectedAction);

            // Assert
            Assert.Equal(expectedText, option.Text);
            Assert.Equal(expectedAction, option.Action);
        }

        /// <summary>
        ///     Tests that dialog add option adds option to list
        /// </summary>
        [Fact]
        public void Dialog_AddOption_AddsOptionToList()
        {
            // Arrange
            Dialog dialog = new Dialog("dialogId", "Dialog Text");
            DialogOption option = new DialogOption("Option Text", () => Logger.Info("Action executed"));
            int expectedCount = 1;

            // Act
            dialog.AddOption(option);

            // Assert
            Assert.Equal(expectedCount, dialog.Options.Count);
        }

        /// <summary>
        ///     Tests that dialog manager add dialog adds dialog to dictionary
        /// </summary>
        [Fact]
        public void DialogManager_AddDialog_AddsDialogToDictionary()
        {
            // Arrange
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("dialogId", "Dialog Text");
            int expectedCount = 1;

            // Act
            manager.AddDialog(dialog);

            // Assert
            Assert.Equal(expectedCount, manager.Dialogs.Count);
        }

        /// <summary>
        ///     Tests that dialog manager get dialog returns correct dialog
        /// </summary>
        [Fact]
        public void DialogManager_GetDialog_ReturnsCorrectDialog()
        {
            // Arrange
            DialogManager manager = new DialogManager();
            Dialog expectedDialog = new Dialog("dialogId", "Dialog Text");
            manager.AddDialog(expectedDialog);

            // Act
            Dialog actualDialog = manager.GetDialog("dialogId");

            // Assert
            Assert.Equal(expectedDialog, actualDialog);
        }

        /// <summary>
        ///     Tests that dialog manager get dialog returns null for non existent id
        /// </summary>
        [Fact]
        public void DialogManager_GetDialog_ReturnsNullForNonExistentId()
        {
            // Arrange
            DialogManager manager = new DialogManager();

            // Act
            Dialog result = manager.GetDialog("nonExistentId");

            // Assert
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that AddCondition with a valid condition adds to the Conditions list
        /// </summary>
        [Fact]
        public void DialogOption_AddCondition_WithValidCondition_AddsToList()
        {
            DialogOption option = new DialogOption("text", () => { });
            IDialogCondition condition = new TestCondition();

            option.AddCondition(condition);

            Assert.Contains(condition, option.Conditions);
        }

        /// <summary>
        ///     Tests that AddCondition with null does not add to the Conditions list
        /// </summary>
        [Fact]
        public void DialogOption_AddCondition_WithNullCondition_DoesNotAdd()
        {
            DialogOption option = new DialogOption("text", () => { });

            option.AddCondition(null!);

            Assert.Empty(option.Conditions);
        }

        /// <summary>
        ///     Tests that AddDialogAction with a valid action adds to the DialogActions list
        /// </summary>
        [Fact]
        public void DialogOption_AddDialogAction_WithValidAction_AddsToList()
        {
            DialogOption option = new DialogOption("text", () => { });
            IDialogAction action = new TestAction();

            option.AddDialogAction(action);

            Assert.Contains(action, option.DialogActions);
        }

        /// <summary>
        ///     Tests that AddDialogAction with null does not add to the DialogActions list
        /// </summary>
        [Fact]
        public void DialogOption_AddDialogAction_WithNullAction_DoesNotAdd()
        {
            DialogOption option = new DialogOption("text", () => { });

            option.AddDialogAction(null!);

            Assert.Empty(option.DialogActions);
        }

        /// <summary>
        ///     Tests that constructor initializes the Conditions list
        /// </summary>
        [Fact]
        public void DialogOption_Constructor_InitializesConditionsList()
        {
            DialogOption option = new DialogOption("text", () => { });

            Assert.NotNull(option.Conditions);
            Assert.Empty(option.Conditions);
        }

        /// <summary>
        ///     Tests that constructor initializes the DialogActions list
        /// </summary>
        [Fact]
        public void DialogOption_Constructor_InitializesDialogActionsList()
        {
            DialogOption option = new DialogOption("text", () => { });

            Assert.NotNull(option.DialogActions);
            Assert.Empty(option.DialogActions);
        }

        /// <summary>
        ///     Test implementation of IDialogCondition
        /// </summary>
        private class TestCondition : IDialogCondition
        {
            public bool Evaluate(DialogContext context) => true;
        }

        /// <summary>
        ///     Test implementation of IDialogAction
        /// </summary>
        private class TestAction : IDialogAction
        {
            public string Id => "test";

            public void Execute(DialogContext context)
            {
            }

            public bool IsValid(DialogContext context) => true;
        }
    }
}