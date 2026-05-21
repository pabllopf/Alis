

using System;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for LambdaDialogCondition
    /// </summary>
    public class LambdaDialogConditionTest
    {
        /// <summary>
        ///     Tests that constructor with null function throws exception
        /// </summary>
        [Fact]
        public void LambdaDialogCondition_Constructor_WithNullFunction_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new LambdaDialogCondition(null));
        }

        /// <summary>
        ///     Tests that evaluate returns true when condition is satisfied
        /// </summary>
        [Fact]
        public void Evaluate_ReturnsTrueWhenConditionIsSatisfied()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("level", 10);

            LambdaDialogCondition condition = new LambdaDialogCondition(ctx => ctx.GetVariable<int>("level") >= 10);

            Assert.True(condition.Evaluate(context));
        }

        /// <summary>
        ///     Tests that evaluate returns false when condition is not satisfied
        /// </summary>
        [Fact]
        public void Evaluate_ReturnsFalseWhenConditionIsNotSatisfied()
        {
            DialogContext context = new DialogContext("testDialog");
            context.SetVariable("level", 5);

            LambdaDialogCondition condition = new LambdaDialogCondition(ctx => ctx.GetVariable<int>("level") >= 10);

            Assert.False(condition.Evaluate(context));
        }

        /// <summary>
        ///     Tests that evaluate with null context throws exception
        /// </summary>
        [Fact]
        public void Evaluate_WithNullContext_ThrowsException()
        {
            LambdaDialogCondition condition = new LambdaDialogCondition(ctx => true);
            Assert.Throws<ArgumentNullException>(() => condition.Evaluate(null));
        }
    }
}