

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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
        [ExcludeFromCodeCoverage]
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

            return actions.Count(action => ExecuteAction(action, context));
        }
    }
}