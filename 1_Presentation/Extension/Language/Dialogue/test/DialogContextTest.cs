

using System;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogContext
    /// </summary>
    public class DialogContextTest
    {
        /// <summary>
        ///     Tests that dialog context constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void DialogContext_Constructor_InitializesPropertiesCorrectly()
        {
            string dialogId = "testDialog";
            DialogContext context = new DialogContext(dialogId);

            Assert.Equal(dialogId, context.DialogId);
            Assert.Equal(DialogStateType.Idle, context.State);
            Assert.NotNull(context.Variables);
            Assert.NotNull(context.VisitedDialogs);
            Assert.Empty(context.Variables);
        }

        /// <summary>
        ///     Tests that set variable stores value correctly
        /// </summary>
        [Fact]
        public void SetVariable_StoresValueCorrectly()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("key", "value");

            Assert.True(context.HasVariable("key"));
            Assert.Equal("value", context.GetVariable("key"));
        }

        /// <summary>
        ///     Tests that set variable with null key throws exception
        /// </summary>
        [Fact]
        public void SetVariable_WithNullKey_ThrowsException()
        {
            DialogContext context = new DialogContext("testDialog");
            Assert.Throws<ArgumentNullException>(() => context.SetVariable(null, "value"));
        }

        /// <summary>
        ///     Tests that get variable returns null for non-existent key
        /// </summary>
        [Fact]
        public void GetVariable_ReturnsNullForNonExistentKey()
        {
            DialogContext context = new DialogContext("testDialog");
            Assert.Null(context.GetVariable("nonExistent"));
        }

        /// <summary>
        ///     Tests that get variable with type returns default for non-existent key
        /// </summary>
        [Fact]
        public void GetVariableT_ReturnsDefaultForNonExistentKey()
        {
            DialogContext context = new DialogContext("testDialog");
            int result = context.GetVariable<int>("nonExistent");
            Assert.Equal(0, result);
        }

        /// <summary>
        ///     Tests that get variable with type returns typed value correctly
        /// </summary>
        [Fact]
        public void GetVariableT_ReturnsTypedValueCorrectly()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("intKey", 42);
            int result = context.GetVariable<int>("intKey");
            Assert.Equal(42, result);
        }

        /// <summary>
        ///     Tests that has variable returns true for existing variable
        /// </summary>
        [Fact]
        public void HasVariable_ReturnsTrueForExistingVariable()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("key", "value");
            Assert.True(context.HasVariable("key"));
        }

        /// <summary>
        ///     Tests that has variable returns false for non-existent variable
        /// </summary>
        [Fact]
        public void HasVariable_ReturnsFalseForNonExistentVariable()
        {
            DialogContext context = new DialogContext("testDialog");
            Assert.False(context.HasVariable("nonExistent"));
        }

        /// <summary>
        ///     Tests that record visit adds dialog to history
        /// </summary>
        [Fact]
        public void RecordVisit_AddsDialogToHistory()
        {
            DialogContext context = new DialogContext("testDialog");
            context.RecordVisit("dialog1");
            context.RecordVisit("dialog2");

            Assert.Equal(2, context.VisitedDialogs.Count);
        }

        /// <summary>
        ///     Tests that get last visited dialog returns correct value
        /// </summary>
        [Fact]
        public void GetLastVisitedDialog_ReturnsCorrectValue()
        {
            DialogContext context = new DialogContext("testDialog");
            context.RecordVisit("dialog1");
            context.RecordVisit("dialog2");

            Assert.Equal("dialog2", context.GetLastVisitedDialog());
        }

        /// <summary>
        ///     Tests that get last visited dialog returns null when empty
        /// </summary>
        [Fact]
        public void GetLastVisitedDialog_ReturnsNullWhenEmpty()
        {
            DialogContext context = new DialogContext("testDialog");
            Assert.Null(context.GetLastVisitedDialog());
        }

        /// <summary>
        ///     Tests that clear resets context
        /// </summary>
        [Fact]
        public void Clear_ResetsContext()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("key", "value");
            context.RecordVisit("dialog1");
            context.State = DialogStateType.Running;

            context.Clear();

            Assert.Equal(DialogStateType.Idle, context.State);
            Assert.Empty(context.Variables);
            Assert.Empty(context.VisitedDialogs);
        }
    }
}