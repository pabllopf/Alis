

using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogEventType enum
    /// </summary>
    public class DialogEventTypeTest
    {
        /// <summary>
        ///     Tests that on dialog start event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnDialogStart_HasCorrectValue()
        {
            Assert.Equal(0, (int) DialogEventType.OnDialogStart);
        }

        /// <summary>
        ///     Tests that on dialog end event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnDialogEnd_HasCorrectValue()
        {
            Assert.Equal(1, (int) DialogEventType.OnDialogEnd);
        }

        /// <summary>
        ///     Tests that on option selected event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnOptionSelected_HasCorrectValue()
        {
            Assert.Equal(2, (int) DialogEventType.OnOptionSelected);
        }

        /// <summary>
        ///     Tests that on option validated event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnOptionValidated_HasCorrectValue()
        {
            Assert.Equal(3, (int) DialogEventType.OnOptionValidated);
        }

        /// <summary>
        ///     Tests that on state changed event type has correct value
        /// </summary>
        [Fact]
        public void DialogEventType_OnStateChanged_HasCorrectValue()
        {
            Assert.Equal(4, (int) DialogEventType.OnStateChanged);
        }
    }
}