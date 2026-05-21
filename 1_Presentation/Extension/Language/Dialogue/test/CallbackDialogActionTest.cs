

using System;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for CallbackDialogAction
    /// </summary>
    public class CallbackDialogActionTest
    {
        /// <summary>
        ///     Tests that constructor with null id throws exception
        /// </summary>
        [Fact]
        public void CallbackDialogAction_Constructor_WithNullId_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new CallbackDialogAction(null));
        }

        /// <summary>
        ///     Tests that constructor initializes properties correctly
        /// </summary>
        [Fact]
        public void CallbackDialogAction_Constructor_InitializesPropertiesCorrectly()
        {
            CallbackDialogAction action = new CallbackDialogAction("testAction");
            Assert.Equal("testAction", action.Id);
        }

        /// <summary>
        ///     Tests that execute calls the callback
        /// </summary>
        [Fact]
        public void Execute_CallsTheCallback()
        {
            bool callbackInvoked = false;
            CallbackDialogAction action = new CallbackDialogAction("testAction", () => callbackInvoked = true);
            DialogContext context = new DialogContext("testDialog");

            action.Execute(context);

            Assert.True(callbackInvoked);
        }

        /// <summary>
        ///     Tests that execute with null context throws exception
        /// </summary>
        [Fact]
        public void Execute_WithNullContext_ThrowsException()
        {
            CallbackDialogAction action = new CallbackDialogAction("testAction");
            Assert.Throws<ArgumentNullException>(() => action.Execute(null));
        }

        /// <summary>
        ///     Tests that is valid returns true for valid context
        /// </summary>
        [Fact]
        public void IsValid_ReturnsTrueForValidContext()
        {
            CallbackDialogAction action = new CallbackDialogAction("testAction");
            DialogContext context = new DialogContext("testDialog");

            Assert.True(action.IsValid(context));
        }

        /// <summary>
        ///     Tests that is valid returns false for null context
        /// </summary>
        [Fact]
        public void IsValid_ReturnsFalseForNullContext()
        {
            CallbackDialogAction action = new CallbackDialogAction("testAction");
            Assert.False(action.IsValid(null));
        }

        /// <summary>
        ///     Tests that set callback updates the callback
        /// </summary>
        [Fact]
        public void SetCallback_UpdatesTheCallback()
        {
            CallbackDialogAction action = new CallbackDialogAction("testAction");
            DialogContext context = new DialogContext("testDialog");

            bool firstCallbackInvoked = false;
            bool secondCallbackInvoked = false;

            action.SetCallback(() => firstCallbackInvoked = true);
            action.Execute(context);
            Assert.True(firstCallbackInvoked);

            action.SetCallback(() => secondCallbackInvoked = true);
            action.Execute(context);
            Assert.True(secondCallbackInvoked);
        }
    }
}