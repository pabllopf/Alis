

using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogEvent
    /// </summary>
    public class DialogEventTest
    {
        /// <summary>
        ///     Tests that dialog event constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void DialogEvent_Constructor_InitializesPropertiesCorrectly()
        {
            DialogEventType eventType = DialogEventType.OnDialogStart;
            string dialogId = "testDialog";

            DialogEvent dialogEvent = new DialogEvent(eventType, dialogId);

            Assert.Equal(eventType, dialogEvent.EventType);
            Assert.Equal(dialogId, dialogEvent.DialogId);
            Assert.False(dialogEvent.IsHandled);
            Assert.Null(dialogEvent.Data);
        }

        /// <summary>
        ///     Tests that dialog event data property works correctly
        /// </summary>
        [Fact]
        public void DialogEvent_Data_WorksCorrectly()
        {
            DialogEvent dialogEvent = new DialogEvent(DialogEventType.OnOptionSelected, "testDialog");
            object testData = new {Text = "Test Option"};

            dialogEvent.Data = testData;

            Assert.Equal(testData, dialogEvent.Data);
        }

        /// <summary>
        ///     Tests that dialog event handled flag works correctly
        /// </summary>
        [Fact]
        public void DialogEvent_IsHandled_WorksCorrectly()
        {
            DialogEvent dialogEvent = new DialogEvent(DialogEventType.OnDialogStart, "testDialog");

            Assert.False(dialogEvent.IsHandled);

            dialogEvent.IsHandled = true;

            Assert.True(dialogEvent.IsHandled);
        }
    }
}