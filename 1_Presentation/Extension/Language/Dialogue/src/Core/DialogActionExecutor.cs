// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogActionExecutor.cs
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
    ///     Executes dialog actions with validation
    /// </summary>
    public class DialogActionExecutor
    {
        /// <summary>
        ///     Executes a single action if valid
        /// </summary>
        /// <param name="action">The action to execute</param>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the action was executed successfully</returns>
        /// <exception cref="ArgumentNullException">Thrown when action or context is null</exception>
        public bool ExecuteAction(IDialogAction action, DialogContext context)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (!action.IsValid(context))
            {
                return false;
            }

            action.Execute(context);
            return true;
        }

        /// <summary>
        ///     Executes multiple actions sequentially
        /// </summary>
        /// <param name="actions">The actions to execute</param>
        /// <param name="context">The dialog context</param>
        /// <returns>The count of actions successfully executed</returns>
        /// <exception cref="ArgumentNullException">Thrown when actions or context is null</exception>
        public int ExecuteActions(IEnumerable<IDialogAction> actions, DialogContext context)
        {
            if (actions == null)
            {
                throw new ArgumentNullException(nameof(actions));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            int executedCount = 0;
            foreach (IDialogAction action in actions)
            {
                if (ExecuteAction(action, context))
                {
                    executedCount++;
                }
            }

            return executedCount;
        }
    }
}

