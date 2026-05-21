

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing a dialog action (Strategy pattern)
    /// </summary>
    public interface IDialogAction
    {
        /// <summary>
        ///     Gets the action identifier
        /// </summary>
        string Id { get; }

        /// <summary>
        ///     Executes the action with the provided context
        /// </summary>
        /// <param name="context">The dialog context</param>
        void Execute(DialogContext context);

        /// <summary>
        ///     Validates if the action can be executed
        /// </summary>
        /// <param name="context">The dialog context</param>
        /// <returns>True if the action is valid for execution</returns>
        bool IsValid(DialogContext context);
    }
}