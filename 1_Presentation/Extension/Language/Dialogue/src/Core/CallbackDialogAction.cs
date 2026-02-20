// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CallbackDialogAction.cs
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

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     A dialog action that executes a callback function
    /// </summary>
    public class CallbackDialogAction : ICallbackDialogAction
    {
        /// <summary>
        ///     The action callback
        /// </summary>
        private Action _callback;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CallbackDialogAction" /> class
        /// </summary>
        /// <param name="id">The action identifier</param>
        /// <param name="callback">The callback to execute (optional)</param>
        /// <exception cref="ArgumentNullException">Thrown when id is null or empty</exception>
        public CallbackDialogAction(string id, Action callback = null)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            Id = id;
            _callback = callback;
        }

        /// <summary>
        ///     Gets the action identifier
        /// </summary>
        public string Id { get; }

        /// <summary>
        ///     Executes the action with the provided context
        /// </summary>
        /// <param name="context">The dialog context</param>
        public void Execute(DialogContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            _callback?.Invoke();
        }

        /// <summary>
        ///     Validates if the action can be executed
        /// </summary>
        /// <param name="context">The dialog context</param>
        /// <returns>Always true for callback actions</returns>
        public bool IsValid(DialogContext context)
        {
            return context != null;
        }

        /// <summary>
        ///     Sets the callback to be invoked when action is executed
        /// </summary>
        /// <param name="callback">The callback action</param>
        public void SetCallback(Action callback)
        {
            _callback = callback;
        }
    }
}

