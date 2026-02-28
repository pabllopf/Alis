// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorkItemTest.cs
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
using Alis.Extension.Thread.Core;
using Xunit;

namespace Alis.Extension.Thread.Test.Core
{
    /// <summary>
    ///     The work item test class
    /// </summary>
    public class WorkItemTest
    {
        /// <summary>
        ///     Tests that work item can be instantiated
        /// </summary>
        [Fact]
        public void WorkItem_CanBeInstantiated()
        {
            // Act
            WorkItem item = new WorkItem();

            // Assert
            Assert.NotNull(item);
            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that action property can store and execute action
        /// </summary>
        [Fact]
        public void Action_CanStoreAndExecuteAction()
        {
            // Arrange
            WorkItem item = new WorkItem();
            int executionCount = 0;
            int receivedStart = -1;
            int receivedLength = -1;

            // Act
            item.Action = (start, length) =>
            {
                executionCount++;
                receivedStart = start;
                receivedLength = length;
            };
            item.Action(10, 20);

            // Assert
            Assert.Equal(1, executionCount);
            Assert.Equal(10, receivedStart);
            Assert.Equal(20, receivedLength);
        }

        /// <summary>
        ///     Tests that start index can be set and retrieved
        /// </summary>
        [Fact]
        public void StartIndex_CanBeSetAndRetrieved()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.StartIndex = 100;

            // Assert
            Assert.Equal(100, item.StartIndex);
        }

        /// <summary>
        ///     Tests that length can be set and retrieved
        /// </summary>
        [Fact]
        public void Length_CanBeSetAndRetrieved()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.Length = 200;

            // Assert
            Assert.Equal(200, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears action property
        /// </summary>
        [Fact]
        public void Reset_ClearsActionProperty()
        {
            // Arrange
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { }
            };

            // Act
            item.Reset();

            // Assert
            Assert.Null(item.Action);
        }

        /// <summary>
        ///     Tests that reset clears start index
        /// </summary>
        [Fact]
        public void Reset_ClearsStartIndex()
        {
            // Arrange
            WorkItem item = new WorkItem
            {
                StartIndex = 50
            };

            // Act
            item.Reset();

            // Assert
            Assert.Equal(0, item.StartIndex);
        }

        /// <summary>
        ///     Tests that reset clears length
        /// </summary>
        [Fact]
        public void Reset_ClearsLength()
        {
            // Arrange
            WorkItem item = new WorkItem
            {
                Length = 100
            };

            // Act
            item.Reset();

            // Assert
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that reset clears all properties at once
        /// </summary>
        [Fact]
        public void Reset_ClearsAllPropertiesAtOnce()
        {
            // Arrange
            WorkItem item = new WorkItem
            {
                Action = (s, l) => { },
                StartIndex = 75,
                Length = 150
            };

            // Act
            item.Reset();

            // Assert
            Assert.Null(item.Action);
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that multiple resets work correctly
        /// </summary>
        [Fact]
        public void Reset_MultipleResets_WorkCorrectly()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act & Assert
            for (int i = 0; i < 5; i++)
            {
                item.Action = (s, l) => { };
                item.StartIndex = i * 10;
                item.Length = i * 20;
                item.Reset();

                Assert.Null(item.Action);
                Assert.Equal(0, item.StartIndex);
                Assert.Equal(0, item.Length);
            }
        }

        /// <summary>
        ///     Tests that work item can store complex action
        /// </summary>
        [Fact]
        public void WorkItem_CanStoreComplexAction()
        {
            // Arrange
            WorkItem item = new WorkItem();
            int[] results = new int[10];

            // Act
            item.Action = (start, length) =>
            {
                for (int i = start; i < start + length; i++)
                {
                    if (i < results.Length)
                    {
                        results[i] = i * 2;
                    }
                }
            };
            item.Action(0, 5);

            // Assert
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(i * 2, results[i]);
            }
        }

        /// <summary>
        ///     Tests that work item properties are independent
        /// </summary>
        [Fact]
        public void WorkItem_PropertiesAreIndependent()
        {
            // Arrange
            WorkItem item1 = new WorkItem();
            WorkItem item2 = new WorkItem();

            // Act
            item1.StartIndex = 10;
            item1.Length = 20;
            item2.StartIndex = 30;
            item2.Length = 40;

            // Assert
            Assert.Equal(10, item1.StartIndex);
            Assert.Equal(20, item1.Length);
            Assert.Equal(30, item2.StartIndex);
            Assert.Equal(40, item2.Length);
        }

        /// <summary>
        ///     Tests that work item can handle negative indices
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleNegativeIndices()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.StartIndex = -5;
            item.Length = -10;

            // Assert
            Assert.Equal(-5, item.StartIndex);
            Assert.Equal(-10, item.Length);
        }

        /// <summary>
        ///     Tests that work item can handle zero values
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleZeroValues()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.StartIndex = 0;
            item.Length = 0;

            // Assert
            Assert.Equal(0, item.StartIndex);
            Assert.Equal(0, item.Length);
        }

        /// <summary>
        ///     Tests that work item can handle maximum integer values
        /// </summary>
        [Fact]
        public void WorkItem_CanHandleMaxIntegerValues()
        {
            // Arrange
            WorkItem item = new WorkItem();

            // Act
            item.StartIndex = int.MaxValue;
            item.Length = int.MaxValue;

            // Assert
            Assert.Equal(int.MaxValue, item.StartIndex);
            Assert.Equal(int.MaxValue, item.Length);
        }
    }
}

