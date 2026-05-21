

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing a dialog condition for evaluating dialog visibility/availability
    /// </summary>
    public interface IDialogCondition
    {
        /// <summary>
        ///     Evaluates the condition against the provided context
        /// </summary>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the condition is satisfied</returns>
        bool Evaluate(DialogContext context);
    }
}