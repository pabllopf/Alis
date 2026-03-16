// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DataStructureExtensiveTest.cs
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
using Alis.Core.Aspect.Data.Json.Helpers;
using Xunit;

namespace Alis.Core.Aspect.Data.Test
{
    /// <summary>
    ///     Parametrized extensive tests for core data structures.
    ///     Tests collections, containers, and data management.
    /// </summary>
    public class DataStructureExtensiveTest
    {
        /// <summary>
        ///     Gets the list operations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetListOperations()
        {
            for (int size = 0; size <= 10; size++)
            {
                for (int element = 0; element < Math.Max(1, size); element++)
                {
                    yield return new object[] {size, element};
                }
            }
        }

        /// <summary>
        ///     Tests that list operations
        /// </summary>
        /// <param name="size">The size</param>
        /// <param name="element">The element</param>
        [Theory, MemberData(nameof(GetListOperations))]
        public void List_Operations(int size, int element)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < size; i++)
            {
                list.Add(i);
            }

            Assert.Equal(size, list.Count);
        }

        /// <summary>
        ///     Tests that list add increases count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(0), InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void List_Add_Increases_Count(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            Assert.Equal(count, list.Count);
        }

        /// <summary>
        ///     Tests that list remove decreases count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(0), InlineData(1), InlineData(10), InlineData(100)]
        public void List_Remove_Decreases_Count(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            if (list.Count > 0)
            {
                list.RemoveAt(0);
                Assert.Equal(count - 1, list.Count);
            }
        }

        /// <summary>
        ///     Tests that list clear empties list
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(0), InlineData(5), InlineData(50), InlineData(500)]
        public void List_Clear_EmptiesList(int count)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < count; i++)
            {
                list.Add(i);
            }

            list.Clear();
            Assert.Empty(list);
        }


        /// <summary>
        ///     Tests that dictionary add increases count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(0), InlineData(1), InlineData(10), InlineData(100)]
        public void Dictionary_Add_IncreasesCount(int count)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
            {
                dict[i] = i.ToString();
            }

            Assert.Equal(count, dict.Count);
        }

        /// <summary>
        ///     Tests that dictionary get returns value
        /// </summary>
        /// <param name="key">The key</param>
        /// <param name="value">The value</param>
        [Theory, InlineData("Key1", "Value1"), InlineData("Key2", "Value2"), InlineData("LongKey", "LongValue")]
        public void Dictionary_Get_ReturnsValue(string key, string value)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>
            {
                {key, value}
            };

            Assert.Equal(value, dict[key]);
        }


        /// <summary>
        ///     Tests that stack push increases count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(100)]
        public void Stack_Push_IncreasesCount(int count)
        {
            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < count; i++)
            {
                stack.Push(i);
            }

            Assert.Equal(count, stack.Count);
        }

        /// <summary>
        ///     Tests that stack lifo order
        /// </summary>
        [Fact]
        public void Stack_LIFO_Order()
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Assert.Equal(3, stack.Pop());
            Assert.Equal(2, stack.Pop());
            Assert.Equal(1, stack.Pop());
        }


        /// <summary>
        ///     Tests that queue enqueue increases count
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(1), InlineData(5), InlineData(10), InlineData(100)]
        public void Queue_Enqueue_IncreasesCount(int count)
        {
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < count; i++)
            {
                queue.Enqueue(i);
            }

            Assert.Equal(count, queue.Count);
        }

        /// <summary>
        ///     Tests that queue fifo order
        /// </summary>
        [Fact]
        public void Queue_FIFO_Order()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Assert.Equal(1, queue.Dequeue());
            Assert.Equal(2, queue.Dequeue());
            Assert.Equal(3, queue.Dequeue());
        }

        /// <summary>
        ///     Gets the escape sequence stress cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GetEscapeSequenceStressCases()
        {
            for (int slashCount = 0; slashCount < 2000; slashCount++)
            {
                yield return new object[] {slashCount};
            }
        }

        /// <summary>
        ///     Tests that escape sequence handler backslash parity is correct
        /// </summary>
        /// <param name="slashCount">The slash count</param>
        [Theory, MemberData(nameof(GetEscapeSequenceStressCases))]
        public void EscapeSequenceHandler_IsEscaped_BackslashParity_IsCorrect(int slashCount)
        {
            EscapeSequenceHandler handler = new EscapeSequenceHandler();
            string text = new string('\\', slashCount) + "\"";

            bool result = handler.IsEscaped(text, slashCount);
            bool expected = (slashCount % 2) == 1;

            Assert.Equal(expected, result);
        }
    }
}