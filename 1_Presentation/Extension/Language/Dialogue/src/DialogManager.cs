// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogManager.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Extension.Language.Dialogue.Core;

namespace Alis.Extension.Language.Dialogue
{
    /// <summary>
    ///     Unified dialog manager with support for basic and advanced features including state machine, events, and conditions
    /// </summary>
    public class DialogManager
    {
        /// <summary>
        ///     The dialog dictionary
        /// </summary>
        internal readonly Dictionary<string, Dialog> Dialogs = new Dictionary<string, Dialog>();

        /// <summary>
        ///     The event publisher
        /// </summary>
        private readonly DialogEventPublisher _eventPublisher = new DialogEventPublisher();

        /// <summary>
        ///     The condition evaluator
        /// </summary>
        private readonly DialogConditionEvaluator _conditionEvaluator = new DialogConditionEvaluator();

        /// <summary>
        ///     The action executor
        /// </summary>
        private readonly DialogActionExecutor _actionExecutor = new DialogActionExecutor();

        /// <summary>
        ///     The current dialog context
        /// </summary>
        private DialogContext _currentContext;

        /// <summary>
        ///     The last dialog state (for tracking after dialog ends)
        /// </summary>
        private DialogStateType _lastState = DialogStateType.Idle;

        /// <summary>
        ///     Gets the current state
        /// </summary>
        public DialogStateType CurrentState => _currentContext?.State ?? _lastState;

        /// <summary>
        ///     Registers a dialog observer
        /// </summary>
        /// <param name="observer">The observer to register</param>
        /// <exception cref="ArgumentNullException">Thrown when observer is null</exception>
        public void RegisterObserver(IDialogEventObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            _eventPublisher.Subscribe(observer);
        }

        /// <summary>
        ///     Unregisters a dialog observer
        /// </summary>
        /// <param name="observer">The observer to unregister</param>
        /// <exception cref="ArgumentNullException">Thrown when observer is null</exception>
        public void UnregisterObserver(IDialogEventObserver observer)
        {
            if (observer == null)
            {
                throw new ArgumentNullException(nameof(observer));
            }

            _eventPublisher.Unsubscribe(observer);
        }

        /// <summary>
        ///     Adds the dialog using the specified dialog
        /// </summary>
        /// <param name="dialog">The dialog</param>
        /// <exception cref="ArgumentNullException">Thrown when dialog is null</exception>
        public void AddDialog(Dialog dialog)
        {
            if (dialog == null)
            {
                throw new ArgumentNullException(nameof(dialog));
            }

            Dialogs[dialog.Id] = dialog;
        }

        /// <summary>
        ///     Gets the dialog using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The dialog or null if not found</returns>
        public Dialog GetDialog(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }

            return Dialogs.TryGetValue(id, out Dialog dialog) ? dialog : null;
        }

        /// <summary>
        ///     Shows the dialog using the specified id (simple mode)
        /// </summary>
        /// <param name="id">The id</param>
        public void ShowDialog(string id)
        {
            Dialog dialog = GetDialog(id);
            if (dialog == null)
            {
                return;
            }

            Logger.Info(dialog.Text);
            for (int i = 0; i < dialog.Options.Count; i++)
            {
                Logger.Info($"{i + 1}. {dialog.Options[i].Text}");
            }

            // Assuming user input for example purposes
            int choice = Convert.ToInt32(Console.ReadLine()) - 1;
            if ((choice >= 0) && (choice < dialog.Options.Count))
            {
                dialog.Options[choice].Action?.Invoke();
            }
        }

        /// <summary>
        ///     Starts a dialog (advanced mode)
        /// </summary>
        /// <param name="dialogId">The dialog id</param>
        /// <exception cref="ArgumentNullException">Thrown when dialogId is null or empty</exception>
        public void StartDialog(string dialogId)
        {
            if (string.IsNullOrWhiteSpace(dialogId))
            {
                throw new ArgumentNullException(nameof(dialogId));
            }

            Dialog dialog = GetDialog(dialogId);
            if (dialog == null)
            {
                return;
            }

            _currentContext = new DialogContext(dialogId);
            ChangeState(DialogStateType.Running);
            _eventPublisher.Publish(new DialogEvent(DialogEventType.OnDialogStart, dialogId));
        }

        /// <summary>
        ///     Pauses the current dialog
        /// </summary>
        public void PauseDialog()
        {
            if (_currentContext != null)
            {
                ChangeState(DialogStateType.Paused);
            }
        }

        /// <summary>
        ///     Resumes the current dialog
        /// </summary>
        public void ResumeDialog()
        {
            if (_currentContext != null && _currentContext.State == DialogStateType.Paused)
            {
                ChangeState(DialogStateType.Running);
            }
        }

        /// <summary>
        ///     Ends the current dialog
        /// </summary>
        public void EndDialog()
        {
            if (_currentContext != null)
            {
                string dialogId = _currentContext.DialogId;
                ChangeState(DialogStateType.Completed);
                _eventPublisher.Publish(new DialogEvent(DialogEventType.OnDialogEnd, dialogId));
                _currentContext = null;
            }
        }

        /// <summary>
        ///     Selects a dialog option
        /// </summary>
        /// <param name="optionIndex">The option index</param>
        public void SelectOption(int optionIndex)
        {
            if (_currentContext == null)
            {
                return;
            }

            Dialog dialog = GetDialog(_currentContext.DialogId);
            if (dialog == null || optionIndex < 0 || optionIndex >= dialog.Options.Count)
            {
                return;
            }

            DialogOption option = dialog.Options[optionIndex];

            // Validate conditions
            if (option.Conditions.Count > 0 && !_conditionEvaluator.EvaluateAll(option.Conditions, _currentContext))
            {
                return;
            }

            // Execute dialog actions
            _actionExecutor.ExecuteActions(option.DialogActions, _currentContext);

            // Fire event
            var @event = new DialogEvent(DialogEventType.OnOptionSelected, _currentContext.DialogId)
            {
                Data = option
            };
            _eventPublisher.Publish(@event);

            // Execute callback
            option.Action?.Invoke();
        }

        /// <summary>
        ///     Gets available options for the current dialog
        /// </summary>
        /// <returns>List of available options</returns>
        public List<DialogOption> GetAvailableOptions()
        {
            if (_currentContext == null)
            {
                return new List<DialogOption>();
            }

            Dialog dialog = GetDialog(_currentContext.DialogId);
            if (dialog == null)
            {
                return new List<DialogOption>();
            }

            var availableOptions = new List<DialogOption>();
            foreach (DialogOption option in dialog.Options)
            {
                if (option.Conditions.Count == 0 || _conditionEvaluator.EvaluateAll(option.Conditions, _currentContext))
                {
                    availableOptions.Add(option);
                }
            }

            return availableOptions;
        }

        /// <summary>
        ///     Sets a context variable
        /// </summary>
        /// <param name="key">The variable key</param>
        /// <param name="value">The variable value</param>
        public void SetContextVariable(string key, object value)
        {
            if (_currentContext != null)
            {
                _currentContext.SetVariable(key, value);
            }
        }

        /// <summary>
        ///     Gets a context variable
        /// </summary>
        /// <param name="key">The variable key</param>
        /// <returns>The variable value or null</returns>
        public object GetContextVariable(string key)
        {
            return _currentContext?.GetVariable(key);
        }

        /// <summary>
        ///     Gets the current dialog
        /// </summary>
        /// <returns>The current dialog or null</returns>
        public Dialog GetCurrentDialog()
        {
            return _currentContext != null ? GetDialog(_currentContext.DialogId) : null;
        }

        /// <summary>
        ///     Changes the dialog state
        /// </summary>
        /// <param name="newState">The new state</param>
        private void ChangeState(DialogStateType newState)
        {
            if (_currentContext != null && _currentContext.State != newState)
            {
                _currentContext.State = newState;
                _lastState = newState;
                _eventPublisher.Publish(new DialogEvent(DialogEventType.OnStateChanged, _currentContext.DialogId)
                {
                    Data = newState
                });
            }
        }
    }
}