
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 13 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Music.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    82

    ### Uncovered Branches
    8

    ### Method
    Music

    ### Complexity / LOC
    34 / 229 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Music.cs
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
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Streamed music played from an audio file
    /// </summary>
    public class Music : ObjectBase
    {
        /// <summary>
        ///     Roots the StreamAdaptor to prevent GC collection while referenced by unmanaged SFML code.
        /// </summary>
        internal readonly List<object> _pinnedObjects = new(1);

        /// <summary>
        ///     Constructs a music from an audio file
        /// </summary>
        /// <param name="filename">Path of the music file to open</param>
        public Music(string filename) :
            base(sfMusic_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/MusicTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Music.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Music.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
