// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnUpdate1Test.cs
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
    ///     Unit tests for the IOnUpdate generic interface with one parameter.
    ///     Tests the Update method with self and one component argument.
    /// </summary>
    public class IOnUpdate1Test
    {
        /// <summary>
        ///     Tests that IOnUpdate can be implemented with one parameter.
        /// </summary>
        [Fact]
        public void IOnUpdate1_CanBeImplemented()
        {
            Update1Handler handler = new Update1Handler();
            Assert.NotNull(handler);
            Assert.IsAssignableFrom<IOnUpdate<int>>(handler);
        }

        /// <summary>
        ///     Tests that Update method executes with correct parameter.
        /// </summary>
        [Fact]
        public void Update_ExecutesWithCorrectParameter()
        {
            Update1Handler handler = new Update1Handler();
            MockGameObject gameObject = new MockGameObject();
            int value = 42;
            handler.Update(gameObject, ref value);
            Assert.Equal(42, handler.LastValue);
        }

        /// <summary>
        ///     Tests that Update counts invocations correctly.
        /// </summary>
        [Fact]
        public void Update_CountsInvocations()
        {
            Update1Handler handler = new Update1Handler();
            MockGameObject gameObject = new MockGameObject();
            int value = 10;
            handler.Update(gameObject, ref value);
            handler.Update(gameObject, ref value);
            Assert.Equal(2, handler.CallCount);
        }

        /// <summary>
        ///     Tests IOnUpdate with string parameter type.
        /// </summary>
        [Fact]
        public void IOnUpdate1_WithStringParameterType()
        {
            UpdateStringHandler handler = new UpdateStringHandler();
            MockGameObject gameObject = new MockGameObject();
            string value = "test";
            handler.Update(gameObject, ref value);
            Assert.Equal("test", handler.LastValue);
        }


        /// <summary>
        ///     Helper implementation for testing IOnUpdate with one parameter.
        /// </summary>
        private class Update1Handler : IOnUpdate<int>
        {
            /// <summary>
            ///     Gets the value of the is component base
            /// </summary>
            public bool IsComponentBase => true;

            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public int LastValue { get; private set; }

            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg">The arg</param>
            public void Update(IGameObject self, ref int arg)
            {
                LastValue = arg;
                CallCount++;
            }
        }

        /// <summary>
        ///     Helper implementation with string parameter.
        /// </summary>
        private class UpdateStringHandler : IOnUpdate<string>
        {
            /// <summary>
            ///     Gets or sets the value of the last value
            /// </summary>
            public string LastValue { get; private set; }

            /// <summary>
            ///     Updates the self
            /// </summary>
            /// <param name="self">The self</param>
            /// <param name="arg">The arg</param>
            public void Update(IGameObject self, ref string arg)
            {
                LastValue = arg;
            }
        }
    }
}