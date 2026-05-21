

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Interface representing a dialog state in the state machine pattern
    /// </summary>
    public interface IDialogState
    {
        /// <summary>
        ///     Gets the state type
        /// </summary>
        DialogStateType StateType { get; }

        /// <summary>
        ///     Called when entering this state
        /// </summary>
        /// <param name="context">The dialog context</param>
        void OnEnter(DialogContext context);

        /// <summary>
        ///     Called when exiting this state
        /// </summary>
        /// <param name="context">The dialog context</param>
        void OnExit(DialogContext context);
    }
}