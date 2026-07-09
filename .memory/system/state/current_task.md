
[INFO] Found 1 coverage targets. (limited to 1 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/BinaryReaderWriter.cs

    ### Language
    cs

    ### Coverage
    96.6% (Line: 100.0%, Branch: 86.7%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    4

    ### Method
    BinaryReaderWriter

    ### Complexity / LOC
    28 / 119 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BinaryReaderWriter.cs
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
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     The binary reader writer class
    /// </summary>
    internal static class BinaryReaderWriter
    {
        /// <summary>
        ///     Reads the exactly using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <param name="stream">The stream</param>
        /// <param name="buffer">The buffer</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <exception cref="EndOfStreamException"></exception>
        /// <exception cref="InternalBufferOverflowException">
        ///     Unable to read {length} bytes into buffer (offset: {buffer.Offset}
        ///     size: {buffer.Count}). Use a larger read buffer
        /// </exception>
        public static async Task ReadExactly(int length, Stream stream, ArraySegment<byte> buffer,
            CancellationToken cancellationToken)
        {
            if (length == 0)
            {
                return;
            }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Internal/BinaryReaderWriterTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/BinaryReaderWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BinaryReaderWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
