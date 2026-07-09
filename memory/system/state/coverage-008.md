
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 7 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Body.cs

    ### Language
    cs

    ### Coverage
    90.2% (Line: 90.6%, Branch: 89.1%)

    ### Uncovered Lines
    54

    ### Uncovered Branches
    20

    ### Method
    cs

    ### Complexity / LOC
    192 / 730 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Body.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The body class
    /// </summary>
    public partial class Body
    {
        /// <summary>
        /// The world locked message
        /// </summary>
        private const string WorldLockedMessage = "The World is locked.";

        /// <summary>
        ///     Gets all the fixtures attached to this body.
        /// </summary>
        /// <value>The fixture list.</value>
        internal readonly FixtureCollection FixtureList;

        /// <summary>
        ///     The angular damping
        /// </summary>

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/BodyTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Body.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Body.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
