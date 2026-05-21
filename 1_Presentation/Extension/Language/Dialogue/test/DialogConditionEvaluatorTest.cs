

using System;
using System.Collections.Generic;
using Alis.Extension.Language.Dialogue.Core;
using Xunit;

namespace Alis.Extension.Language.Dialogue.Test
{
    /// <summary>
    ///     Tests for DialogConditionEvaluator
    /// </summary>
    public class DialogConditionEvaluatorTest
    {
        /// <summary>
        ///     Tests that evaluate condition returns true when condition is satisfied
        /// </summary>
        [Fact]
        public void EvaluateCondition_ReturnsTrueWhenConditionIsSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");
            IDialogCondition condition = new LambdaDialogCondition(ctx => true);

            Assert.True(DialogConditionEvaluator.EvaluateCondition(condition, context));
        }

        /// <summary>
        ///     Tests that evaluate condition returns false when condition is not satisfied
        /// </summary>
        [Fact]
        public void EvaluateCondition_ReturnsFalseWhenConditionIsNotSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");
            IDialogCondition condition = new LambdaDialogCondition(ctx => false);

            Assert.False(DialogConditionEvaluator.EvaluateCondition(condition, context));
        }

        /// <summary>
        ///     Tests that evaluate condition with null condition throws exception
        /// </summary>
        [Fact]
        public void EvaluateCondition_WithNullCondition_ThrowsException()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            Assert.Throws<ArgumentNullException>(() => DialogConditionEvaluator.EvaluateCondition(null, context));
        }

        /// <summary>
        ///     Tests that evaluate condition with null context throws exception
        /// </summary>
        [Fact]
        public void EvaluateCondition_WithNullContext_ThrowsException()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            IDialogCondition condition = new LambdaDialogCondition(ctx => true);

            Assert.Throws<ArgumentNullException>(() => DialogConditionEvaluator.EvaluateCondition(condition, null));
        }

        /// <summary>
        ///     Tests that evaluate all returns true when all conditions are satisfied
        /// </summary>
        [Fact]
        public void EvaluateAll_ReturnsTrueWhenAllConditionsAreSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            List<IDialogCondition> conditions = new List<IDialogCondition>
            {
                new LambdaDialogCondition(ctx => true),
                new LambdaDialogCondition(ctx => true)
            };

            Assert.True(evaluator.EvaluateAll(conditions, context));
        }

        /// <summary>
        ///     Tests that evaluate all returns false when one condition is not satisfied
        /// </summary>
        [Fact]
        public void EvaluateAll_ReturnsFalseWhenOneConditionIsNotSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            List<IDialogCondition> conditions = new List<IDialogCondition>
            {
                new LambdaDialogCondition(ctx => true),
                new LambdaDialogCondition(ctx => false)
            };

            Assert.False(evaluator.EvaluateAll(conditions, context));
        }

        /// <summary>
        ///     Tests that evaluate any returns true when at least one condition is satisfied
        /// </summary>
        [Fact]
        public void EvaluateAny_ReturnsTrueWhenAtLeastOneConditionIsSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            List<IDialogCondition> conditions = new List<IDialogCondition>
            {
                new LambdaDialogCondition(ctx => false),
                new LambdaDialogCondition(ctx => true)
            };

            Assert.True(evaluator.EvaluateAny(conditions, context));
        }

        /// <summary>
        ///     Tests that evaluate any returns false when no condition is satisfied
        /// </summary>
        [Fact]
        public void EvaluateAny_ReturnsFalseWhenNoConditionIsSatisfied()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            List<IDialogCondition> conditions = new List<IDialogCondition>
            {
                new LambdaDialogCondition(ctx => false),
                new LambdaDialogCondition(ctx => false)
            };

            Assert.False(evaluator.EvaluateAny(conditions, context));
        }
    }
}