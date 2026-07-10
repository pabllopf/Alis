
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 246 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/GenericPriorityQueue.cs

    ### Language
    cs

    ### Coverage
    97.1% (Line: 97.5%, Branch: 95.7%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    2

    ### Method
    GenericPriorityQueue

    ### Complexity / LOC
    44 / 198 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GenericPriorityQueue.cs
// 
//  Author:Pablo Perdomo FalcÃ³n
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
using System.Collections;
using System.Collections.Generic;

namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     A copy of StablePriorityQueue which also has generic priority-type
    /// </summary>
    /// <typeparam name="TItem">The values in the queue.  Must extend the GenericPriorityQueueNode class</typeparam>
    /// <typeparam name="TPriority">The priority-type.  Must extend IComparable&lt;TPriority&gt;</typeparam>
    public sealed class GenericPriorityQueue<TItem, TPriority> : IFixedSizePriorityQueue<TItem, TPriority>
        where TItem : GenericPriorityQueueNode<TPriority>
    {
        /// <summary>
        ///     The comparer
        /// </summary>
        private readonly Comparison<TPriority> _comparer;

        /// <summary>
        ///     The nodes
        /// </summary>
        private TItem[] _nodes;

        /// <summary>
        ///     The num nodes
        /// </summary>
        internal int _numNodes;

        /// <summary>
        ///     The num nodes ever enqueued
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/test/GenericPriorityQueueTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/GenericPriorityQueue.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GenericPriorityQueue.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
