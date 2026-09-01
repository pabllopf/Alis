
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 10 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP1.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    240

    ### Uncovered Branches
    14

    ### Method
    ImPlotP1

    ### Complexity / LOC
    66 / 308 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP1.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <returns>The im plot colormap</returns>
        public static ImPlotColormap AddColormap(string name, ref Vector4F cols, int size)
        {
            ImPlotColormap ret = ImPlotNative.ImPlot_AddColormap_Vec4Ptr(Encoding.UTF8.GetBytes(name), cols, size, 0);
            return ret;
        }

        /// <summary>
        ///     Adds the colormap using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="cols">The cols</param>
        /// <param name="size">The size</param>
        /// <param name="qual">The qual</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP1Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP1.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP1.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
