// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogConditionEvaluator.cs
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
using System.Linq;

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Evaluates dialog conditions using AND/OR logic
    /// </summary>
    public class DialogConditionEvaluator
    {
        /// <summary>
        ///     Evaluates a single condition against the context
        /// </summary>
        /// <param name="condition">The condition to evaluate</param>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the condition is satisfied</returns>
        /// <exception cref="ArgumentNullException">Thrown when condition or context is null</exception>
        public bool EvaluateCondition(IDialogCondition condition, DialogContext context)
        {
            if (condition == null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return condition.Evaluate(context);
        }

        /// <summary>
        ///     Evaluates multiple conditions with AND logic (all must be true)
        /// </summary>
        /// <param name="conditions">The conditions to evaluate</param>
        /// <param name="context">The dialog context</param>
        /// <returns>True if all conditions are satisfied</returns>
        /// <exception cref="ArgumentNullException">Thrown when conditions or context is null</exception>
        public bool EvaluateAll(IEnumerable<IDialogCondition> conditions, DialogContext context)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return conditions.All(condition => EvaluateCondition(condition, context));
        }

        /// <summary>
        ///     Evaluates multiple conditions with OR logic (at least one must be true)
        /// </summary>
        /// <param name="conditions">The conditions to evaluate</param>
        /// <param name="context">The dialog context</param>
        /// <returns>True if at least one condition is satisfied</returns>
        /// <exception cref="ArgumentNullException">Thrown when conditions or context is null</exception>
        public bool EvaluateAny(IEnumerable<IDialogCondition> conditions, DialogContext context)
        {
            if (conditions == null)
            {
                throw new ArgumentNullException(nameof(conditions));
            }

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return conditions.Any(condition => EvaluateCondition(condition, context));
        }
    }
}

