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
            
            DialogContext context = new DialogContext("testDialog");
            bool executed = false;

            IDialogAction action = new CallbackDialogAction("testAction", () => executed = true);

            bool result = DialogActionExecutor.ExecuteAction(action, context);

            Assert.True(result);
            Assert.True(executed);
        }

        /// <summary>
        ///     Tests that execute action with null action throws exception
        /// </summary>
        [Fact]
        public void ExecuteAction_WithNullAction_ThrowsException()
        {
            
            DialogContext context = new DialogContext("testDialog");

            Assert.Throws<ArgumentNullException>(() => DialogActionExecutor.ExecuteAction(null, context));
        }

        /// <summary>
        ///     Tests that execute action with null context throws exception
        /// </summary>
        [Fact]
        public void ExecuteAction_WithNullContext_ThrowsException()
        {
            
            IDialogAction action = new CallbackDialogAction("testAction");

            Assert.Throws<ArgumentNullException>(() => DialogActionExecutor.ExecuteAction(action, null));
        }

        /// <summary>
        ///     Tests that ExecuteActions with null actions throws exception
        /// </summary>
        [Fact]
        public void ExecuteActions_WithNullActions_ThrowsArgumentNullException()
        {
            DialogContext context = new DialogContext("test");

            Assert.Throws<ArgumentNullException>(() => DialogActionExecutor.ExecuteActions(null, context));
        }

        /// <summary>
        ///     Tests that ExecuteActions with null context throws exception
        /// </summary>
        [Fact]
        public void ExecuteActions_WithNullContext_ThrowsArgumentNullException()
        {
            IDialogAction[] actions = { new CallbackDialogAction("test") };

            Assert.Throws<ArgumentNullException>(() => DialogActionExecutor.ExecuteActions(actions, null));
        }

        /// <summary>
        ///     Tests that ExecuteActions returns correct count for valid actions
        /// </summary>
        [Fact]
        public void ExecuteActions_WithValidActions_ReturnsSuccessCount()
        {
            DialogContext context = new DialogContext("test");
            int executedCount = 0;
            IDialogAction[] actions =
            {
                new CallbackDialogAction("a", () => executedCount++),
                new CallbackDialogAction("b", () => executedCount++)
            };

            int result = DialogActionExecutor.ExecuteActions(actions, context);

            Assert.Equal(2, result);
            Assert.Equal(2, executedCount);
        }

        /// <summary>
        ///     Tests that ExecuteActions handles empty collection
        /// </summary>
        [Fact]
        public void ExecuteActions_WithEmptyCollection_ReturnsZero()
        {
            DialogContext context = new DialogContext("test");
            IDialogAction[] actions = System.Array.Empty<IDialogAction>();

            int result = DialogActionExecutor.ExecuteActions(actions, context);

            Assert.Equal(0, result);
        }
    }
}