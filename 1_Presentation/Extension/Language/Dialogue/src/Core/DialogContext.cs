// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogContext.cs
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

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Represents the context and state of a dialog conversation
    /// </summary>
    public class DialogContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DialogContext" /> class
        /// </summary>
        /// <param name="dialogId">The dialog identifier</param>
        public DialogContext(string dialogId)
        {
            DialogId = dialogId;
            State = DialogStateType.Idle;
            Variables = new Dictionary<string, object>();
            VisitedDialogs = new Stack<string>();
        }

        /// <summary>
        ///     Gets the dialog identifier
        /// </summary>
        public string DialogId { get; }

        /// <summary>
        ///     Gets or sets the current state
        /// </summary>
        public DialogStateType State { get; set; }

        /// <summary>
        ///     Gets the variables dictionary for storing dialog-related data
        /// </summary>
        public Dictionary<string, object> Variables { get; }

        /// <summary>
        ///     Gets the stack of visited dialogs for tracking history
        /// </summary>
        public Stack<string> VisitedDialogs { get; }

        /// <summary>
        ///     Sets a variable in the context
        /// </summary>
        /// <param name="key">The variable key</param>
        /// <param name="value">The variable value</param>
        /// <exception cref="ArgumentNullException">Thrown when key is null or empty</exception>
        public void SetVariable(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            Variables[key] = value;
        }

        /// <summary>
        ///     Gets a variable from the context
        /// </summary>
        /// <param name="key">The variable key</param>
        /// <returns>The variable value or null if not found</returns>
        /// <exception cref="ArgumentNullException">Thrown when key is null or empty</exception>
        public object GetVariable(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Variables.TryGetValue(key, out object value) ? value : null;
        }

        /// <summary>
        ///     Gets a variable from the context with a specific type
        /// </summary>
        /// <typeparam name="T">The expected variable type</typeparam>
        /// <param name="key">The variable key</param>
        /// <returns>The variable value casted to type T or default value if not found</returns>
        /// <exception cref="ArgumentNullException">Thrown when key is null or empty</exception>
        public T GetVariable<T>(string key)
        {
            object value = GetVariable(key);
            return value is T typedValue ? typedValue : default;
        }

        /// <summary>
        ///     Checks if a variable exists in the context
        /// </summary>
        /// <param name="key">The variable key</param>
        /// <returns>True if the variable exists</returns>
        /// <exception cref="ArgumentNullException">Thrown when key is null or empty</exception>
        public bool HasVariable(string key)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            return Variables.ContainsKey(key);
        }

        /// <summary>
        ///     Records a visited dialog in the history
        /// </summary>
        /// <param name="dialogId">The dialog identifier to record</param>
        /// <exception cref="ArgumentNullException">Thrown when dialogId is null or empty</exception>
        public void RecordVisit(string dialogId)
        {
            if (string.IsNullOrWhiteSpace(dialogId))
            {
                throw new ArgumentNullException(nameof(dialogId));
            }

            VisitedDialogs.Push(dialogId);
        }

        /// <summary>
        ///     Gets the last visited dialog, if available
        /// </summary>
        /// <returns>The last visited dialog id or null if no dialogs have been visited</returns>
        public string GetLastVisitedDialog()
        {
            return VisitedDialogs.Count > 0 ? VisitedDialogs.Peek() : null;
        }

        /// <summary>
        ///     Clears the dialog context
        /// </summary>
        public void Clear()
        {
            State = DialogStateType.Idle;
            Variables.Clear();
            VisitedDialogs.Clear();
        }
    }
}

