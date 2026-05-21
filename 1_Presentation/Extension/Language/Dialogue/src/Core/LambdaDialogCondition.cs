

using System;

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     A dialog condition implemented using a lambda function
    /// </summary>
    public class LambdaDialogCondition : IDialogCondition
    {
        /// <summary>
        ///     The evaluation function
        /// </summary>
        private readonly Func<DialogContext, bool> _evaluateFunc;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LambdaDialogCondition" /> class
        /// </summary>
        /// <param name="evaluateFunc">The evaluation function</param>
        /// <exception cref="ArgumentNullException">Thrown when evaluateFunc is null</exception>
        public LambdaDialogCondition(Func<DialogContext, bool> evaluateFunc) => _evaluateFunc = evaluateFunc ?? throw new ArgumentNullException(nameof(evaluateFunc));

        /// <summary>
        ///     Evaluates the condition against the provided context
        /// </summary>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the condition is satisfied</returns>
        public bool Evaluate(DialogContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return _evaluateFunc(context);
        }
    }
}