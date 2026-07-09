
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 9 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Ads/GoogleAds/src/AdsManager.cs

    ### Language
    cs

    ### Coverage
    91.0% (Line: 91.0%, Branch: 90.9%)

    ### Uncovered Lines
    15

    ### Uncovered Branches
    6

    ### Method
    cs

    ### Complexity / LOC
    53 / 229 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AdsManager.cs
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
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Ads.GoogleAds
{
    /// <summary>
    ///     The ads manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="IAdsManager" />
    public class AdsManager : AManager, IAdsManager, IDisposable
    {
        /// <summary>
        ///     The not initialized message
        /// </summary>
        private const string NotInitializedMessage = "AdsManager not initialized. Call InitializeAsync first.";

        /// <summary>
        ///     The ads configuration
        /// </summary>
        private AdConfiguration _configuration;

        /// <summary>
        ///     Flag indicating if banner ad is loaded
        /// </summary>
        private bool _isBannerAdLoaded;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Ads/GoogleAds/test/AdsManagerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Ads/GoogleAds/src/AdsManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AdsManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
