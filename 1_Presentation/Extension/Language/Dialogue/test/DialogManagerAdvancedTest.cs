// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogManagerAdvancedTest.cs
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
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogManagerAdvanced
    /// </summary>
    public class DialogManagerAdvancedTest
    {
        /// <summary>
        ///     Tests that add dialog adds dialog correctly
        /// </summary>
        [Fact]
        public void AddDialog_AddsDialogCorrectly()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");

            manager.AddDialog(dialog);

            Assert.NotNull(manager.GetDialog("testDialog"));
        }

        /// <summary>
        ///     Tests that add dialog with null dialog throws exception
        /// </summary>
        [Fact]
        public void AddDialog_WithNullDialog_ThrowsException()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Assert.Throws<ArgumentNullException>(() => manager.AddDialog(null));
        }

        /// <summary>
        ///     Tests that get dialog returns correct dialog
        /// </summary>
        [Fact]
        public void GetDialog_ReturnsCorrectDialog()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);

            Dialog result = manager.GetDialog("testDialog");

            Assert.Equal(dialog, result);
        }

        /// <summary>
        ///     Tests that get dialog returns null for non-existent dialog
        /// </summary>
        [Fact]
        public void GetDialog_ReturnsNullForNonExistentDialog()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();

            Dialog result = manager.GetDialog("nonExistent");

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that start dialog sets state to running
        /// </summary>
        [Fact]
        public void StartDialog_SetsStateToRunning()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);

            manager.StartDialog("testDialog");

            Assert.Equal(DialogStateType.Running, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that start dialog with null id throws exception
        /// </summary>
        [Fact]
        public void StartDialog_WithNullId_ThrowsException()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Assert.Throws<ArgumentNullException>(() => manager.StartDialog(null));
        }

        /// <summary>
        ///     Tests that pause dialog sets state to paused
        /// </summary>
        [Fact]
        public void PauseDialog_SetsStateToPaused()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.PauseDialog();

            Assert.Equal(DialogStateType.Paused, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that resume dialog sets state to running
        /// </summary>
        [Fact]
        public void ResumeDialog_SetsStateToRunning()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");
            manager.PauseDialog();

            manager.ResumeDialog();

            Assert.Equal(DialogStateType.Running, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that end dialog sets state to completed
        /// </summary>
        [Fact]
        public void EndDialog_SetsStateToCompleted()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");
            
            Assert.Equal(DialogStateType.Running, manager.CurrentState);

            manager.EndDialog();

            Assert.Equal(DialogStateType.Completed, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that get available options returns options for current dialog
        /// </summary>
        [Fact]
        public void GetAvailableOptions_ReturnsOptionsForCurrentDialog()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            dialog.AddOption(new DialogOption("Option 1", () => { }));
            dialog.AddOption(new DialogOption("Option 2", () => { }));
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            var options = manager.GetAvailableOptions();

            Assert.Equal(2, options.Count);
        }

        /// <summary>
        ///     Tests that set context variable stores variable correctly
        /// </summary>
        [Fact]
        public void SetContextVariable_StoresVariableCorrectly()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.SetContextVariable("testVar", "testValue");

            Assert.Equal("testValue", manager.GetContextVariable("testVar"));
        }

        /// <summary>
        ///     Tests that get current dialog returns current dialog
        /// </summary>
        [Fact]
        public void GetCurrentDialog_ReturnsCurrentDialog()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            Dialog currentDialog = manager.GetCurrentDialog();

            Assert.Equal(dialog, currentDialog);
        }

        /// <summary>
        ///     Tests that register observer adds observer correctly
        /// </summary>
        [Fact]
        public void RegisterObserver_AddsObserverCorrectly()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            IDialogEventObserver observer = new MockDialogEventObserver();

            manager.RegisterObserver(observer);

            // Should not throw exception
        }

        /// <summary>
        ///     Tests that unregister observer removes observer correctly
        /// </summary>
        [Fact]
        public void UnregisterObserver_RemovesObserverCorrectly()
        {
            DialogManagerAdvanced manager = new DialogManagerAdvanced();
            IDialogEventObserver observer = new MockDialogEventObserver();
            manager.RegisterObserver(observer);

            manager.UnregisterObserver(observer);

            // Should not throw exception
        }

        /// <summary>
        ///     Mock observer for testing
        /// </summary>
        private class MockDialogEventObserver : IDialogEventObserver
        {
            public void OnDialogEvent(DialogEvent dialogEvent)
            {
                // Mock implementation
            }
        }
    }
}

