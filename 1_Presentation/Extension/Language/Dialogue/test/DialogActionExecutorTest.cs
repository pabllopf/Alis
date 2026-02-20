// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DialogActionExecutorTest.cs
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
    ///     Tests for DialogActionExecutor
    /// </summary>
    public class DialogActionExecutorTest
    {
        /// <summary>
        ///     Tests that execute action executes the action if valid
        /// </summary>
        [Fact]
        public void ExecuteAction_ExecutesActionIfValid()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            DialogContext context = new DialogContext("testDialog");
            bool executed = false;

            IDialogAction action = new CallbackDialogAction("testAction", () => executed = true);

            bool result = executor.ExecuteAction(action, context);

            Assert.True(result);
            Assert.True(executed);
        }

        /// <summary>
        ///     Tests that execute action with null action throws exception
        /// </summary>
        [Fact]
        public void ExecuteAction_WithNullAction_ThrowsException()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            DialogContext context = new DialogContext("testDialog");

            Assert.Throws<ArgumentNullException>(() => executor.ExecuteAction(null, context));
        }

        /// <summary>
        ///     Tests that execute action with null context throws exception
        /// </summary>
        [Fact]
        public void ExecuteAction_WithNullContext_ThrowsException()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            IDialogAction action = new CallbackDialogAction("testAction");

            Assert.Throws<ArgumentNullException>(() => executor.ExecuteAction(action, null));
        }

        /// <summary>
        ///     Tests that execute actions executes multiple actions sequentially
        /// </summary>
        [Fact]
        public void ExecuteActions_ExecutesMultipleActionsSequentially()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            DialogContext context = new DialogContext("testDialog");

            int executionOrder = 0;
            List<IDialogAction> actions = new List<IDialogAction>
            {
                new CallbackDialogAction("action1", () => executionOrder++),
                new CallbackDialogAction("action2", () => executionOrder++)
            };

            int result = executor.ExecuteActions(actions, context);

            Assert.Equal(2, result);
            Assert.Equal(2, executionOrder);
        }

        /// <summary>
        ///     Tests that execute actions with null actions throws exception
        /// </summary>
        [Fact]
        public void ExecuteActions_WithNullActions_ThrowsException()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            DialogContext context = new DialogContext("testDialog");

            Assert.Throws<ArgumentNullException>(() => executor.ExecuteActions(null, context));
        }

        /// <summary>
        ///     Tests that execute actions with null context throws exception
        /// </summary>
        [Fact]
        public void ExecuteActions_WithNullContext_ThrowsException()
        {
            DialogActionExecutor executor = new DialogActionExecutor();
            List<IDialogAction> actions = new List<IDialogAction>();

            Assert.Throws<ArgumentNullException>(() => executor.ExecuteActions(actions, null));
        }
    }
}

