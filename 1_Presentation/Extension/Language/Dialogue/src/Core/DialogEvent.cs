

namespace Alis.Extension.Language.Dialogue.Core
{
    /// <summary>
    ///     Represents a dialog event with metadata
    /// </summary>
    public class DialogEvent
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DialogEvent" /> class
        /// </summary>
        /// <param name="eventType">The event type</param>
        /// <param name="dialogId">The dialog identifier</param>
        public DialogEvent(DialogEventType eventType, string dialogId)
        {
            EventType = eventType;
            DialogId = dialogId;
        }

        /// <summary>
        ///     Gets the event type
        /// </summary>
        public DialogEventType EventType { get; }

        /// <summary>
        ///     Gets the dialog identifier
        /// </summary>
        public string DialogId { get; }

        /// <summary>
        ///     Gets or sets additional event data
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this event has been handled
        /// </summary>
        public bool IsHandled { get; set; }
    }
}