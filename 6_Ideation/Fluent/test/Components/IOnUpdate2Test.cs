// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate2Test.cs
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

using Alis.Core.Aspect.Fluent.Components;
using Xunit;

namespace Alis.Core.Aspect.Fluent.Test.Components
{
    /// <summary>
    ///     Unit tests for the <see cref="IOnUpdate{TArg1,TArg2}" /> interface.
    ///     Tests the Update lifecycle method with two component arguments.
    /// </summary>
    public class IOnUpdate2Test
    {
        /// <summary>
        ///     Tests that <see cref="IOnUpdate{TArg1,TArg2}" /> can be implemented.
        /// </summary>
        [Fact]
        public void IOnUpdate2_CanBeImplemented()
        {
            var handler = new Update2Handler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnUpdate<int, string>>(handler);
        }

        /// <summary>
        ///     Tests that Update executes and passes both arguments correctly.
        /// </summary>
        [Fact]
        public void Update_ExecutesWithCorrectParameters()
        {
            var handler = new Update2Handler();
            var gameObject = new MockGameObject();
            int arg1 = 42;
            string arg2 = "hello";

            handler.Update(gameObject, ref arg1, ref arg2);

            Assert.Equal(42, handler.LastArg1);
            Assert.Equal("hello", handler.LastArg2);
        }

        /// <summary>
        ///     Tests that Update counts multiple invocations correctly.
        /// </summary>
        [Fact]
        public void Update_CountsMultipleInvocations()
        {
            var handler = new Update2Handler();
            var gameObject = new MockGameObject();
            int arg1 = 1;
            string arg2 = "x";

            handler.Update(gameObject, ref arg1, ref arg2);
            handler.Update(gameObject, ref arg1, ref arg2);
            handler.Update(gameObject, ref arg1, ref arg2);

            Assert.Equal(3, handler.CallCount);
        }

        /// <summary>
        ///     Tests IOnUpdate with different argument type combinations.
        /// </summary>
        [Fact]
        public void IOnUpdate2_WithDifferentTypeCombinations()
        {
            var handler = new UpdateDoubleBoolHandler();
            var gameObject = new MockGameObject();
            double arg1 = 3.14;
            bool arg2 = true;

            handler.Update(gameObject, ref arg1, ref arg2);

            Assert.Equal(3.14, handler.LastArg1);
            Assert.True(handler.LastArg2);
        }

        /// <summary>
        ///     Helper implementation for testing <see cref="IOnUpdate{TArg1,TArg2}" /> with int and string.
        /// </summary>
        private class Update2Handler : IOnUpdate<int, string>
        {
            /// <summary>
            ///     Gets the value of the is component base
            /// </summary>
            public bool IsComponentBase => true;

            /// <summary>
            ///     Gets or sets the value of the last arg1
            /// </summary>
            public int LastArg1 { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the last arg2
            /// </summary>
            public string LastArg2 { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg1</param>
            /// <param name="arg2">The arg2</param>
            public void Update(IGameObject self, ref int arg1, ref string arg2)
            {
                LastArg1 = arg1;
                LastArg2 = arg2;
                CallCount++;
            }
        }

        /// <summary>
        ///     Helper implementation with double and bool parameter types.
        /// </summary>
        private class UpdateDoubleBoolHandler : IOnUpdate<double, bool>
        {
            /// <summary>
            ///     Gets or sets the value of the last arg1
            /// </summary>
            public double LastArg1 { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the last arg2
            /// </summary>
            public bool LastArg2 { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg1">The arg1</param>
            /// <param name="arg2">The arg2</param>
            public void Update(IGameObject self, ref double arg1, ref bool arg2)
            {
                LastArg1 = arg1;
                LastArg2 = arg2;
            }
        }
    }
}
