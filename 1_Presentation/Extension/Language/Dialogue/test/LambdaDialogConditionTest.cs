// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LambdaDialogConditionTest.cs
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

