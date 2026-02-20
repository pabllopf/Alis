// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogConditionEvaluatorTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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

            Assert.True(evaluator.EvaluateCondition(condition, context));
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

            Assert.False(evaluator.EvaluateCondition(condition, context));
        }

        /// <summary>
        ///     Tests that evaluate condition with null condition throws exception
        /// </summary>
        [Fact]
        public void EvaluateCondition_WithNullCondition_ThrowsException()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            DialogContext context = new DialogContext("testDialog");

            Assert.Throws<ArgumentNullException>(() => evaluator.EvaluateCondition(null, context));
        }

        /// <summary>
        ///     Tests that evaluate condition with null context throws exception
        /// </summary>
        [Fact]
        public void EvaluateCondition_WithNullContext_ThrowsException()
        {
            DialogConditionEvaluator evaluator = new DialogConditionEvaluator();
            IDialogCondition condition = new LambdaDialogCondition(ctx => true);

            Assert.Throws<ArgumentNullException>(() => evaluator.EvaluateCondition(condition, null));
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

