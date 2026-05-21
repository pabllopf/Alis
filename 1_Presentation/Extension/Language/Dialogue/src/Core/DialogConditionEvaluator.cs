

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
        public static bool EvaluateCondition(IDialogCondition condition, DialogContext context)
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
        [ExcludeFromCodeCoverage]
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
        [ExcludeFromCodeCoverage]
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