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
using System.Collections.Generic;
using System.IO;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Unified tests for DialogManager (basic and advanced functionality)
    /// </summary>
    public class DialogManagerTest
    {
        // ================ BASIC FUNCTIONALITY TESTS ================

        /// <summary>
        ///     Tests that add dialog should add dialog to dictionary
        /// </summary>
        [Fact]
        public void AddDialog_ShouldAddDialogToDictionary()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testId", "Test Dialog");
            manager.AddDialog(dialog);
            Assert.True(manager.Dialogs.ContainsKey("testId"));
        }

        /// <summary>
        ///     Tests that add dialog with null throws exception
        /// </summary>
        [Fact]
        public void AddDialog_WithNull_ThrowsException()
        {
            DialogManager manager = new DialogManager();
            Assert.Throws<ArgumentNullException>(() => manager.AddDialog(null));
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
        ///     Tests that get dialog with null id returns null
        /// </summary>
        [Fact]
        public void GetDialog_WithNullId_ReturnsNull()
        {
            DialogManager manager = new DialogManager();
            Dialog result = manager.GetDialog(null);
            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that get dialog with empty id returns null
        /// </summary>
        [Fact]
        public void GetDialog_WithEmptyId_ReturnsNull()
        {
            DialogManager manager = new DialogManager();
            Dialog result = manager.GetDialog("");
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
            dialog.AddOption(new DialogOption("Option 1", () => actionInvoked = true));
            manager.AddDialog(dialog);

            Console.SetIn(new StringReader("1\n"));
            manager.ShowDialog("testId");

            Assert.True(actionInvoked);
        }

        // ================ ADVANCED FUNCTIONALITY TESTS ================

        /// <summary>
        ///     Tests that start dialog sets state to running
        /// </summary>
        [Fact]
        public void StartDialog_SetsStateToRunning()
        {
            DialogManager manager = new DialogManager();
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
            DialogManager manager = new DialogManager();
            Assert.Throws<ArgumentNullException>(() => manager.StartDialog(null));
        }

        /// <summary>
        ///     Tests that start dialog with empty id throws exception
        /// </summary>
        [Fact]
        public void StartDialog_WithEmptyId_ThrowsException()
        {
            DialogManager manager = new DialogManager();
            Assert.Throws<ArgumentNullException>(() => manager.StartDialog(""));
        }

        /// <summary>
        ///     Tests that pause dialog sets state to paused
        /// </summary>
        [Fact]
        public void PauseDialog_SetsStateToPaused()
        {
            DialogManager manager = new DialogManager();
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
            DialogManager manager = new DialogManager();
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
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            Assert.Equal(DialogStateType.Running, manager.CurrentState);

            manager.EndDialog();

            Assert.Equal(DialogStateType.Completed, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that pause dialog when no dialog is running does not throw
        /// </summary>
        [Fact]
        public void PauseDialog_WhenNoDialogRunning_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Exception exception = Record.Exception(() => manager.PauseDialog());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that resume dialog when dialog is not paused does not resume
        /// </summary>
        [Fact]
        public void ResumeDialog_WhenDialogNotPaused_DoesNotChange()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.ResumeDialog();

            Assert.Equal(DialogStateType.Running, manager.CurrentState);
        }

        /// <summary>
        ///     Tests that end dialog when no dialog is running does not throw
        /// </summary>
        [Fact]
        public void EndDialog_WhenNoDialogRunning_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Exception exception = Record.Exception(() => manager.EndDialog());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that get available options returns options for current dialog
        /// </summary>
        [Fact]
        public void GetAvailableOptions_ReturnsOptionsForCurrentDialog()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            dialog.AddOption(new DialogOption("Option 1", () => { }));
            dialog.AddOption(new DialogOption("Option 2", () => { }));
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            var options = manager.GetAvailableOptions();

            Assert.Equal(2, options.Count);
        }

        /// <summary>
        ///     Tests that get available options returns empty list when no dialog is running
        /// </summary>
        [Fact]
        public void GetAvailableOptions_WhenNoDialogRunning_ReturnsEmptyList()
        {
            DialogManager manager = new DialogManager();

            var options = manager.GetAvailableOptions();

            Assert.Empty(options);
        }

        /// <summary>
        ///     Tests that set context variable stores variable correctly
        /// </summary>
        [Fact]
        public void SetContextVariable_StoresVariableCorrectly()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.SetContextVariable("testVar", "testValue");

            Assert.Equal("testValue", manager.GetContextVariable("testVar"));
        }

        /// <summary>
        ///     Tests that set context variable when no dialog is running does not throw
        /// </summary>
        [Fact]
        public void SetContextVariable_WhenNoDialogRunning_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Exception exception = Record.Exception(() => manager.SetContextVariable("key", "value"));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that get context variable returns null when no dialog is running
        /// </summary>
        [Fact]
        public void GetContextVariable_WhenNoDialogRunning_ReturnsNull()
        {
            DialogManager manager = new DialogManager();
            object value = manager.GetContextVariable("anyKey");
            Assert.Null(value);
        }

        /// <summary>
        ///     Tests that get current dialog returns current dialog
        /// </summary>
        [Fact]
        public void GetCurrentDialog_ReturnsCurrentDialog()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            Dialog currentDialog = manager.GetCurrentDialog();

            Assert.Equal(dialog, currentDialog);
        }

        /// <summary>
        ///     Tests that get current dialog returns null when no dialog is running
        /// </summary>
        [Fact]
        public void GetCurrentDialog_WhenNoDialogRunning_ReturnsNull()
        {
            DialogManager manager = new DialogManager();

            Dialog currentDialog = manager.GetCurrentDialog();

            Assert.Null(currentDialog);
        }

        /// <summary>
        ///     Tests that register observer adds observer correctly
        /// </summary>
        [Fact]
        public void RegisterObserver_AddsObserverCorrectly()
        {
            DialogManager manager = new DialogManager();
            IDialogEventObserver observer = new MockDialogEventObserver();

            manager.RegisterObserver(observer);

            // Should not throw exception
        }

        /// <summary>
        ///     Tests that register observer with null observer throws exception
        /// </summary>
        [Fact]
        public void RegisterObserver_WithNull_ThrowsException()
        {
            DialogManager manager = new DialogManager();
            Assert.Throws<ArgumentNullException>(() => manager.RegisterObserver(null));
        }

        /// <summary>
        ///     Tests that unregister observer removes observer correctly
        /// </summary>
        [Fact]
        public void UnregisterObserver_RemovesObserverCorrectly()
        {
            DialogManager manager = new DialogManager();
            IDialogEventObserver observer = new MockDialogEventObserver();
            manager.RegisterObserver(observer);

            manager.UnregisterObserver(observer);

            // Should not throw exception
        }

        /// <summary>
        ///     Tests that unregister observer with null observer throws exception
        /// </summary>
        [Fact]
        public void UnregisterObserver_WithNull_ThrowsException()
        {
            DialogManager manager = new DialogManager();
            Assert.Throws<ArgumentNullException>(() => manager.UnregisterObserver(null));
        }

        // ================ CONDITION AND ACTION TESTS ================

        /// <summary>
        ///     Tests that select option with invalid index does not throw
        /// </summary>
        [Fact]
        public void SelectOption_WithInvalidIndex_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            dialog.AddOption(new DialogOption("Option 1", () => { }));
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            Exception exception = Record.Exception(() => manager.SelectOption(10));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that select option when no dialog is running does not throw
        /// </summary>
        [Fact]
        public void SelectOption_WhenNoDialogRunning_DoesNotThrow()
        {
            DialogManager manager = new DialogManager();
            Exception exception = Record.Exception(() => manager.SelectOption(0));
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that select option with condition evaluates correctly
        /// </summary>
        [Fact]
        public void SelectOption_WithCondition_EvaluatesCorrectly()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            var option = new DialogOption("Option 1", () => { });
            option.AddCondition(new LambdaDialogCondition(ctx => ctx.GetVariable("canSelect") as bool? ?? false));
            dialog.AddOption(option);
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            // Should not execute because condition is false
            manager.SelectOption(0);
            Assert.Empty(manager.GetAvailableOptions());

            // Set condition to true
            manager.SetContextVariable("canSelect", true);
            Assert.Equal(1, manager.GetAvailableOptions().Count);
        }

        /// <summary>
        ///     Tests that available options respects conditions
        /// </summary>
        [Fact]
        public void GetAvailableOptions_RespectsConditions()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            
            var option1 = new DialogOption("Option 1", () => { });
            var option2 = new DialogOption("Option 2", () => { });
            option1.AddCondition(new LambdaDialogCondition(_ => true));
            option2.AddCondition(new LambdaDialogCondition(_ => false));
            
            dialog.AddOption(option1);
            dialog.AddOption(option2);
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            var availableOptions = manager.GetAvailableOptions();

            Assert.Single(availableOptions);
            Assert.Equal("Option 1", availableOptions[0].Text);
        }

        /// <summary>
        ///     Tests multiple dialogs management
        /// </summary>
        [Fact]
        public void MultipleDialogs_CanBeManaged()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog1 = new Dialog("dialog1", "Dialog 1");
            Dialog dialog2 = new Dialog("dialog2", "Dialog 2");
            
            manager.AddDialog(dialog1);
            manager.AddDialog(dialog2);

            Assert.NotNull(manager.GetDialog("dialog1"));
            Assert.NotNull(manager.GetDialog("dialog2"));
        }

        /// <summary>
        ///     Tests dialog state transitions
        /// </summary>
        [Fact]
        public void DialogStateTransitions_WorkCorrectly()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);

            // Initial state
            Assert.Equal(DialogStateType.Idle, manager.CurrentState);

            // Start dialog
            manager.StartDialog("testDialog");
            Assert.Equal(DialogStateType.Running, manager.CurrentState);

            // Pause dialog
            manager.PauseDialog();
            Assert.Equal(DialogStateType.Paused, manager.CurrentState);

            // Resume dialog
            manager.ResumeDialog();
            Assert.Equal(DialogStateType.Running, manager.CurrentState);

            // End dialog
            manager.EndDialog();
            Assert.Equal(DialogStateType.Completed, manager.CurrentState);
        }

        /// <summary>
        ///     Tests context variable persistence
        /// </summary>
        [Fact]
        public void ContextVariables_PersistCorrectly()
        {
            DialogManager manager = new DialogManager();
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.SetContextVariable("var1", "value1");
            manager.SetContextVariable("var2", 42);
            manager.SetContextVariable("var3", true);

            Assert.Equal("value1", manager.GetContextVariable("var1"));
            Assert.Equal(42, manager.GetContextVariable("var2"));
            Assert.Equal(true, manager.GetContextVariable("var3"));
        }

        /// <summary>
        ///     Tests event observer notification
        /// </summary>
        [Fact]
        public void EventObserver_ReceivesNotifications()
        {
            DialogManager manager = new DialogManager();
            var observer = new MockDialogEventObserver();
            manager.RegisterObserver(observer);

            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            Assert.True(observer.EventsReceived > 0);
        }

        /// <summary>
        ///     Tests dialog option callback execution
        /// </summary>
        [Fact]
        public void DialogOption_CallbackExecutes()
        {
            DialogManager manager = new DialogManager();
            bool callbackExecuted = false;
            
            Dialog dialog = new Dialog("testDialog", "Test Dialog");
            dialog.AddOption(new DialogOption("Option", () => callbackExecuted = true));
            manager.AddDialog(dialog);
            manager.StartDialog("testDialog");

            manager.SelectOption(0);

            Assert.True(callbackExecuted);
        }

        /// <summary>
        ///     Mock observer for testing
        /// </summary>
        private class MockDialogEventObserver : IDialogEventObserver
        {
            /// <summary>
            /// Gets or sets the value of the events received
            /// </summary>
            public int EventsReceived { get; private set; }

            /// <summary>
            /// Ons the dialog event using the specified dialog event
            /// </summary>
            /// <param name="dialogEvent">The dialog event</param>
            public void OnDialogEvent(DialogEvent dialogEvent)
            {
                EventsReceived++;
            }
        }
    }
}


