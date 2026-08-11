
[INFO] Found 203 coverage targets. (limited to 500 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    690

    ### Uncovered Branches
    112

    ### Method
    ImGuiIOPtr

    ### Complexity / LOC
    235 / 1001 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIOPtr.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui io ptr
    /// </summary>
    public struct ImGuiIoPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImGuiIoPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIoPtr" /> class
        /// </summary>
        /// <param name="imGuiIo">The im gui io</param>
        public ImGuiIoPtr(ImGuiIo imGuiIo)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImGuiIo>());
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiIOPtrTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIOPtr.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiIOPtr.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    457

    ### Uncovered Branches
    8

    ### Method
    ImPlot

    ### Complexity / LOC
    135 / 597 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlot.cs
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
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="flags">The flags</param>
        public static void PlotStems(string labelId, ref ushort xs, ref ushort ys, int count, double @ref, ImPlotStemsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStems_U16PtrU16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, @ref, flags, 0, sizeof(ushort));
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlot.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlot.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    445

    ### Uncovered Branches
    2

    ### Method
    ImGuiP3

    ### Complexity / LOC
    128 / 564 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     The io
        /// </summary>
        private static ImGuiIoPtr _io;


        /// <summary>
        ///     Describes whether drag scalar n
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="dataType">The data type</param>
        /// <param name="pData">The data</param>
        /// <param name="components">The components</param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="pMin">The min</param>
        /// <param name="pMax">The max</param>
        /// <returns>The bool</returns>
        public static bool DragScalarN(string label, ImGuiDataType dataType, IntPtr pData, int components, float vSpeed, IntPtr pMin, IntPtr pMax)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP3Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP3.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP3.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    369

    ### Uncovered Branches
    16

    ### Method
    ImGuiP5

    ### Complexity / LOC
    98 / 467 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP5.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayload AcceptDragDropPayload(string type) => ImGuiNative.igAcceptDragDropPayload(Encoding.UTF8.GetBytes(type), ImGuiDragDropFlags.None);

        /// <summary>
        ///     Accepts the drag drop payload using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="flags">The flags</param>
        /// <returns>The im gui payload ptr</returns>
        public static ImGuiPayload AcceptDragDropPayload(string type, ImGuiDragDropFlags flags)
        {
            ImGuiPayload ret = ImGuiNative.igAcceptDragDropPayload(Encoding.UTF8.GetBytes(type), flags);
            return ret;
        }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP5Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP5.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP5.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP6.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    367

    ### Uncovered Branches
    16

    ### Method
    ImGuiP6

    ### Complexity / LOC
    97 / 465 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP6.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
        /// <returns>The bool</returns>
        public static bool InputFloat4(string label, ref Vector4F v, string format)
        {
            byte ret = ImGuiNative.igInputFloat4(Encoding.UTF8.GetBytes(label), ref v, Encoding.UTF8.GetBytes(format), ImGuiInputTextFlags.None);

            return ret != 0;
        }

        /// <summary>
        ///     Describes whether input float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="format">The format</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP6Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP6.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP6.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    364

    ### Uncovered Branches
    88

    ### Method
    NativeWindow

    ### Complexity / LOC
    134 / 594 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:NativeWindow.cs
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
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Microsoft.Win32.SafeHandles;
using Image = Alis.Core.Graphic.Image;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Provides a simplified interface for creating and using a GLFW window with properties, events, etc.
    /// </summary>
    /// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid" />
    // S3897: Static fields are inherited from SafeHandle base class; ISerializable is not applicable for native handles
    // S4035: No unsafe methods in this class; base SafeHandle inherits from unsafe contexts
    [SuppressMessage("SonarAnalyzer.CSharp", "S3897", Justification = "Inherited static fields from SafeHandle base class")]
    [SuppressMessage("SonarAnalyzer.CSharp", "S4035", Justification = "No unsafe methods in this class")]
    public class NativeWindow : SafeHandleZeroOrMinusOneIsInvalid
    {
        /// <summary>
        ///     The window instance this object wraps.
        /// </summary>
        protected readonly Window Window;

        /// <summary>
        ///     Roots GLFW callback delegates to prevent GC collection while they are registered with unmanaged code.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/NativeWindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/NativeWindow.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage NativeWindow.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    332

    ### Uncovered Branches
    22

    ### Method
    EmscriptenWeb

    ### Complexity / LOC
    50 / 634 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:EmscriptenWeb.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     EmscriptenWeb provides JavaScript interop for WebAssembly applications
    ///     Handles communication with JavaScript functions for DOM manipulation,
    ///     input event handling, and browser APIs
    /// </summary>
    
    public static class EmscriptenWeb
    {
        /// <summary>
        /// The emscripten lib
        /// </summary>
        private const string EmscriptenLib = "emscripten";

        // =====================================================================

        /// <summary>
        /// Registers the keyboard callbacks native using the specified on key down callback
        /// </summary>
        /// <param name="onKeyDownCallback">The on key down callback</param>
        /// <param name="onKeyUpCallback">The on key up callback</param>
        /// <param name="onCharInputCallback">The on char input callback</param>
        [DllImport(EmscriptenLib, EntryPoint = "registerKeyboardCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories), ExcludeFromCodeCoverage]
        private static extern void RegisterKeyboardCallbacksNative(
            IntPtr onKeyDownCallback,
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/EmscriptenWebTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage EmscriptenWeb.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawListPtr.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    328

    ### Uncovered Branches
    2

    ### Method
    ImDrawListPtr

    ### Complexity / LOC
    112 / 418 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImDrawListPtr.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw list ptr
    /// </summary>
    public readonly struct ImDrawListPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImDrawListPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImDrawListPtr(ImDrawList nativePtr)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImDrawList>());
            Marshal.StructureToPtr(nativePtr, NativePtr, false);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImDrawListPtrTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawListPtr.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImDrawListPtr.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP10.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    315

    ### Uncovered Branches
    0

    ### Method
    ImPlotP10

    ### Complexity / LOC
    105 / 428 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP10.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotScatter(string labelId, ref short xs, ref short ys, int count, ImPlotScatterFlags flags)
        {
            ImPlotNative.ImPlot_PlotScatter_S16PtrS16Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, 0, sizeof(short));
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP10Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP10.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP10.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

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

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    224

    ### Uncovered Branches
    22

    ### Method
    ImPlotP15

    ### Complexity / LOC
    65 / 285 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP15.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="itemCount">The item count</param>
        /// <param name="groupCount">The group count</param>
        /// <param name="groupSize">The group size</param>
        public static void PlotBarGroups(string[] labelIds, uint[] values, int itemCount, int groupCount, double groupSize)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotBarGroups_U32Ptr(nativeLabelIds, values, itemCount, groupCount, groupSize, 0, 0);
        }

        /// <summary>
        ///     Plots the bar groups using the specified label ids
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP15Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP15.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP15.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP11.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    221

    ### Uncovered Branches
    38

    ### Method
    ImPlotP11

    ### Complexity / LOC
    61 / 270 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the pie chart using the specified label ids
        /// </summary>
        /// <param name="labelIds">The label ids</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="radius">The radius</param>
        /// <param name="labelFmt">The label fmt</param>
        public static void PlotPieChart(string[] labelIds, ushort[] values, int count, double x, double y, double radius, string labelFmt)
        {
            byte[][] nativeLabelIds = new byte[labelIds.Length][];
            for (int i = 0; i < labelIds.Length; i++)
            {
                nativeLabelIds[i] = Encoding.UTF8.GetBytes(labelIds[i]);
            }

            ImPlotNative.ImPlot_PlotPieChart_U16Ptr(nativeLabelIds, values, count, x, y, radius, Encoding.UTF8.GetBytes(labelFmt), 90, ImPlotPieChartFlags.None);
        }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP11Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP11.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP11.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    214

    ### Uncovered Branches
    0

    ### Method
    ImGuiP4

    ### Complexity / LOC
    69 / 384 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4.cs
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

//  File:ImGuiP4.cs
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


using System;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP4Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP4.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP4.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP14.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    210

    ### Uncovered Branches
    0

    ### Method
    ImPlotP14

    ### Complexity / LOC
    70 / 287 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="ref">The ref</param>
        /// <param name="scale">The scale</param>
        /// <param name="start">The start</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotStems(string labelId, byte[] values, int count, double @ref, double scale, double start, ImPlotStemsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotStems_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, @ref, scale, start, flags, offset, 0);
        }

        /// <summary>
        ///     Plots the stems using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP14Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP14.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP14.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP12.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    200

    ### Uncovered Branches
    0

    ### Method
    ImPlotP12

    ### Complexity / LOC
    50 / 257 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="bins">The bins</param>
        /// <param name="barScale">The bar scale</param>
        /// <param name="range">The range</param>
        /// <returns>The double</returns>
        public static double PlotHistogram(string labelId, byte[] values, int count, int bins, double barScale, ImPlotRange range)
        {
            double ret = ImPlotNative.ImPlot_PlotHistogram_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, bins, barScale, range, 0);
            return ret;
        }

        /// <summary>
        ///     Plots the histogram using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP12Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP12.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP12.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGui.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    197

    ### Uncovered Branches
    2

    ### Method
    ImGui

    ### Complexity / LOC
    58 / 258 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGui.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether slider float 4
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vMin">The min</param>
        /// <param name="vMax">The max</param>
        /// <param name="format">The format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The bool</returns>
        public static bool SliderFloat4(string label, ref Vector4F v, float vMin, float vMax, string format, ImGuiSliderFlags flags)
        {
            byte ret = ImGuiNative.igSliderFloat4(Encoding.UTF8.GetBytes(label), v, vMin, vMax, Encoding.UTF8.GetBytes(format), flags);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether slider int
        /// </summary>
        /// <param name="label">The label</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGui.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGui.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP1.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    196

    ### Uncovered Branches
    0

    ### Method
    ImGuiP1

    ### Complexity / LOC
    46 / 250 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <returns>The bool</returns>
        public static bool Combo(string label, ref int currentItem, string itemsSeparatedByZeros)
        {
            byte ret = ImGuiNative.igCombo_Str(Encoding.UTF8.GetBytes(label), ref currentItem, Encoding.UTF8.GetBytes(itemsSeparatedByZeros), 0);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether combo
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="currentItem">The current item</param>
        /// <param name="itemsSeparatedByZeros">The items separated by zeros</param>
        /// <param name="popupMaxHeightInItems">The popup max height in items</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP1Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP1.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP1.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameContext.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    190

    ### Uncovered Branches
    22

    ### Method
    WebAssemblyGameContext

    ### Complexity / LOC
    66 / 230 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameContext.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Complete WebAssembly game context providing unified access to all platform features
    ///     This is the main entry point for game development on WebAssembly
    /// </summary>
    
    public sealed class WebAssemblyGameContext : IDisposable
    {
        /// <summary>
        /// The platform
        /// </summary>
        internal readonly WebAssemblyPlatform _platform;
        /// <summary>
        /// The input manager
        /// </summary>
        internal readonly WebAssemblyInputManager _inputManager;
        /// <summary>
        /// The input context
        /// </summary>
        internal readonly WebAssemblyInputContext _inputContext;
        /// <summary>
        /// The display manager
        /// </summary>
        internal readonly WebAssemblyDisplayManager _displayManager;
        /// <summary>
        /// The configuration
        /// </summary>
        internal readonly WebAssemblyConfiguration _configuration;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyGameContextTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameContext.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyGameContext.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    189

    ### Uncovered Branches
    24

    ### Method
    Shader

    ### Complexity / LOC
    54 / 350 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Shader.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Wrapper for pixel shaders
    /// </summary>
    public class Shader : ObjectBase
    {
        /// <summary>
        ///     Special value that can be passed to SetParameter,
        ///     and that represents the texture of the object being drawn
        /// </summary>
        public static readonly CurrentTextureType CurrentTexture = null;

        /// <summary>
        ///     The texture
        /// </summary>
        internal readonly Dictionary<string, Texture> myTextures = new Dictionary<string, Texture>();


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ShaderTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Shader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasPtr.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    182

    ### Uncovered Branches
    0

    ### Method
    ImFontAtlasPtr

    ### Complexity / LOC
    71 / 243 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtr.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font atlas ptr
    /// </summary>
    public readonly struct ImFontAtlasPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public IntPtr NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(IntPtr nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(ImFontAtlas nativePtr)
        {
            NativePtr = Marshal.AllocHGlobal(Marshal.SizeOf<ImFontAtlas>());
            Marshal.StructureToPtr(nativePtr, NativePtr, false);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImFontAtlasPtrTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontAtlasPtr.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImFontAtlasPtr.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    179

    ### Uncovered Branches
    78

    ### Method
    AudioVideoWriter

    ### Complexity / LOC
    67 / 221 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioVideoWriter.cs
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
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Alis.Extension.Media.FFmpeg.Audio;
using Alis.Extension.Media.FFmpeg.Encoding;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The audio video writer class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class AudioVideoWriter : IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        internal readonly string ffmpeg;

        /// <summary>
        ///     The connected socket
        /// </summary>
        private Socket connectedSocket;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/AudioVideoWriterTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/AudioVideoWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioVideoWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Mapping/KeyCodes.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    169

    ### Uncovered Branches
    0

    ### Method
    KeyCodes

    ### Complexity / LOC
    0 / 258 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:KeyCodes.cs
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

namespace Alis.Extension.Graphic.Sdl2.Mapping
{
    /// <summary>
    ///     The sdl keycode enum
    /// </summary>
    public enum KeyCodes
    {
        /// <summary>
        ///     The  unknown sdl keycode
        /// </summary>
        Unknown = 0,

        /// <summary>
        ///     The  return sdl keycode
        /// </summary>
        Return = 13,

        /// <summary>
        ///     The  escape sdl keycode
        /// </summary>
        Escape = 27,

        /// <summary>
        ///     The  backspace sdl keycode
        /// </summary>
        Backspace = 8,

        /// <summary>
        ///     The  tab sdl keycode
        /// </summary>
        Tab = 9,
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/Mapping/KeyCodesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Mapping/KeyCodes.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage KeyCodes.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyDisplayManager.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    166

    ### Uncovered Branches
    51

    ### Method
    WebAssemblyDisplayManager

    ### Complexity / LOC
    70 / 239 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyDisplayManager.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Manages display and window-related functionality for WebAssembly
    ///     Handles resolution, orientation, fullscreen, and display events
    /// </summary>
    
    public class WebAssemblyDisplayManager
    {
        /// <summary>
        /// The platform
        /// </summary>
        internal readonly WebAssemblyPlatform _platform;
        /// <summary>
        /// The current width
        /// </summary>
        internal int _currentWidth;
        /// <summary>
        /// The current height
        /// </summary>
        internal int _currentHeight;
        /// <summary>
        /// The current orientation
        /// </summary>
        private ScreenOrientation _currentOrientation;
        /// <summary>
        /// The is fullscreen
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyDisplayManagerTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyDisplayManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyDisplayManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    165

    ### Uncovered Branches
    0

    ### Method
    ImPlotP22

    ### Complexity / LOC
    55 / 227 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP22.cs
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

//  File:ImPlotP22.cs
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


using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP22Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP22.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP22.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP19.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    162

    ### Uncovered Branches
    0

    ### Method
    ImPlotP19

    ### Complexity / LOC
    54 / 223 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        public static void PlotStairs(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotStairsFlags flags)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, 0, sizeof(byte));
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP19Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP19.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP19.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP6.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    162

    ### Uncovered Branches
    0

    ### Method
    ImPlotP6

    ### Complexity / LOC
    54 / 223 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotInfLines(string labelId, byte[] values, int count, ImPlotInfLinesFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotInfLines_U8Ptr(Encoding.UTF8.GetBytes(labelId), values, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the inf lines using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        public static void PlotInfLines(string labelId, short[] values, int count)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP6Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP6.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP6.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP7.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    162

    ### Uncovered Branches
    0

    ### Method
    ImPlotP7

    ### Complexity / LOC
    54 / 223 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP7.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="xscale">The xscale</param>
        /// <param name="xstart">The xstart</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotScatter(string labelId, byte[] values, int count, double xscale, double xstart, ImPlotScatterFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotScatter_U8PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, xscale, xstart, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the scatter using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP7Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP7.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP7.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    161

    ### Uncovered Branches
    8

    ### Method
    RenderWindow

    ### Complexity / LOC
    57 / 319 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:RenderWindow.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Simple wrapper for Window that allows easy
    ///     2D rendering
    /// </summary>
    public class RenderWindow : Window, IRenderTarget
    {
        /// <summary>
        ///     The my default view
        /// </summary>
        private View myDefaultView;

        /// <summary>
        ///     Create the window with default style and creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        public RenderWindow(VideoMode mode, string title) :
            this(mode, title, Windows.Styles.Default, new ContextSettings(0, 0))
        {
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/RenderWindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderWindow.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage RenderWindow.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP2.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    161

    ### Uncovered Branches
    0

    ### Method
    ImGuiP2

    ### Complexity / LOC
    39 / 208 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <returns>The bool</returns>
        public static bool DragInt(string label, ref int v, float vSpeed)
        {
            byte ret = ImGuiNative.igDragInt(Encoding.UTF8.GetBytes(label), ref v, vSpeed, 0, 0, Encoding.UTF8.GetBytes("%d"), ImGuiSliderFlags.None);
            return ret != 0;
        }

        /// <summary>
        ///     Describes whether drag int
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="v">The </param>
        /// <param name="vSpeed">The speed</param>
        /// <param name="vMin">The min</param>
        /// <returns>The bool</returns>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP2Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP2.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP2.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    159

    ### Uncovered Branches
    0

    ### Method
    ImPlotP13

    ### Complexity / LOC
    53 / 220 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotStairs(string labelId, ref byte xs, ref byte ys, int count, ImPlotStairsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotStairs_U8PtrU8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the stairs using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP13Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP13.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP13.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP17.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    159

    ### Uncovered Branches
    0

    ### Method
    ImPlotP17

    ### Complexity / LOC
    53 / 220 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP17.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        /// <param name="stride">The stride</param>
        public static void PlotBars(string labelId, ref long xs, ref long ys, int count, double barSize, ImPlotBarsFlags flags, int offset, int stride)
        {
            ImPlotNative.ImPlot_PlotBars_S64PtrS64Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, barSize, flags, offset, stride);
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP17Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP17.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP17.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP16.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    156

    ### Uncovered Branches
    0

    ### Method
    ImPlotP16

    ### Complexity / LOC
    52 / 215 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP16.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize)
        {
            ImPlotNative.ImPlot_PlotBars_U32PtrInt(Encoding.UTF8.GetBytes(labelId), values, count, barSize, 0, 0, 0, sizeof(uint));
        }

        /// <summary>
        ///     Plots the bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="count">The count</param>
        /// <param name="barSize">The bar size</param>
        /// <param name="shift">The shift</param>
        public static void PlotBars(string labelId, uint[] values, int count, double barSize, double shift)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP16Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP16.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP16.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatformIntegration.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    152

    ### Uncovered Branches
    38

    ### Method
    WebAssemblyPlatformIntegration

    ### Complexity / LOC
    62 / 207 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatformIntegration.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     WebAssembly Platform Integration Guide and Factory
    ///     
    ///     INTEGRATION INSTRUCTIONS FOR LINUX AND WEB PLATFORMS
    ///     ======================================================
    ///     
    ///     This controller provides complete WebAssembly support for game development.
    ///     It implements all methods from INativePlatform and adds extensive input handling
    ///     for keyboards, gamepads (Xbox, PlayStation, etc.), mice, and touch input.
    ///     
    ///     KEY FEATURES:
    ///     - Full INativePlatform implementation for WebAssembly
    ///     - EGL context management for OpenGL rendering
    ///     - Comprehensive keyboard input with key binding system
    ///     - Gamepad support (Xbox controllers, PlayStation controllers, etc.)
    ///     - Mouse and wheel input handling
    ///     - Touch input support
    ///     - Display management (resolution, fullscreen, orientation)
    ///     - Pointer locking for FPS games
    ///     - Device capabilities detection
    ///     - Browser API integration
    ///     - Cross-platform Linux support through Emscripten
    ///     
    ///     FOR LINUX SUPPORT:
    ///     - Compile with: emcripten or wasm target
    ///     - Use HTML5 Canvas for rendering
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyPlatformIntegrationTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatformIntegration.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyPlatformIntegration.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP21.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    150

    ### Uncovered Branches
    0

    ### Method
    ImPlotP21

    ### Complexity / LOC
    50 / 207 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP21.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, count, 0, 0, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="yref">The yref</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys, int count, double yref)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP21Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP21.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP21.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    149

    ### Uncovered Branches
    14

    ### Method
    ImGuizMo

    ### Complexity / LOC
    27 / 182 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMo.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.GuizMo
{
    /// <summary>
    ///     The im guizmo class
    /// </summary>
    public static class ImGuizMo
    {
        /// <summary>
        ///     The camera projection
        /// </summary>
        private static float[] cameraProjection = new float[16]
        {
            2.0f / 800.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 2.0f / 600.0f, 0.0f, 0.0f,
            0.0f, 0.0f, -1.0f, 0.0f,
            -1.0f, -1.0f, 0.0f, 1.0f
        };

        /// <summary>
        ///     The camera view
        /// </summary>
        private static float[] cameraView = new float[16]
        {
            1.0f, 0.0f, 0.0f, 0.0f,
            0.0f, 1.0f, 0.0f, 0.0f,
            0.0f, 0.0f, 1.0f, 0.0f,
            0.0f, 0.0f, 0.0f, 1.0f
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/GuizMo/ImGuizMoTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/GuizMo/ImGuizMo.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuizMo.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    140

    ### Uncovered Branches
    18

    ### Method
    GlfwNative

    ### Complexity / LOC
    57 / 448 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GlfwNative.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Structs;
using Image = Alis.Core.Graphic.Image;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     The base class the vast majority of the GLFW functions, excluding only Vulkan and native platform specific
    ///     functions.
    /// </summary>
    public static class GlfwNative
    {
        /// <summary>
        ///     The native library name,
        ///     <para>For Unix users using an installed version of GLFW, this needs refactored to <c>glfw</c>.</para>
        /// </summary>
        public const string Library = "glfw";

        /// <summary>
        ///     The glfw error
        /// </summary>
        private static readonly ErrorCallback ErrorCallback = GlfwError;


        /// <summary>
        ///     Initializes a new instance of the <see cref="GlfwNative" /> class
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/GlfwNativeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/GlfwNative.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GlfwNative.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Texture.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    127

    ### Uncovered Branches
    18

    ### Method
    Texture

    ### Complexity / LOC
    43 / 238 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Texture.cs
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Image living on the graphics card that can be used for drawing
    /// </summary>
    public class Texture : ObjectBase
    {
        /// <summary>
        /// The resource name
        /// </summary>
        private const string _resourceName = "texture";

        /// <summary>
        ///     The my external
        /// </summary>
        internal readonly bool myExternal;

        /// <summary>
        ///     Construct the texture
        /// </summary>
        /// <param name="width">Texture width</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/TextureTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Texture.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Texture.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    121

    ### Uncovered Branches
    10

    ### Method
    ImGuiP8

    ### Complexity / LOC
    36 / 161 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Shows the about window
        /// </summary>
        public static void ShowAboutWindow()
        {
            ImGuiNative.igShowAboutWindow(IntPtr.Zero);
        }

        /// <summary>
        ///     Shows the about window using the specified p open
        /// </summary>
        /// <param name="pOpen">The open</param>
        public static void ShowAboutWindow(ref bool pOpen)
        {
            byte nativePOpenVal = pOpen ? (byte) 1 : (byte) 0;
            ImGuiNative.igShowAboutWindow(new IntPtr(nativePOpenVal));
            pOpen = nativePOpenVal != 0;
        }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP8Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP8.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP8.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    111

    ### Uncovered Branches
    50

    ### Method
    VideoWriter

    ### Complexity / LOC
    40 / 142 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoWriter.cs
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
using System.Diagnostics;
using System.IO;
using System.Threading;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The video writer class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class VideoWriter : MediaWriter<VideoFrame>, IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        internal readonly string ffmpeg;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process Ffmpegp;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/VideoWriterTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    110

    ### Uncovered Branches
    58

    ### Method
    AudioWriter

    ### Complexity / LOC
    44 / 141 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioWriter.cs
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
using System.Diagnostics;
using System.IO;
using System.Threading;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Encoding;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio writer class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioWriter : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffmpeg
        /// </summary>
        internal readonly string ffmpeg;

        /// <summary>
        ///     The csc
        /// </summary>
        private CancellationTokenSource csc;

        /// <summary>
        ///     The ffmpegp
        /// </summary>
        internal Process Ffmpegp;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioWriterTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioWriter.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioWriter.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP18.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    100

    ### Uncovered Branches
    0

    ### Method
    ImPlotP18

    ### Complexity / LOC
    52 / 129 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP18.cs
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

//  File:ImPlotP18.cs
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


using System;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP18Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP18.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP18.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    99

    ### Uncovered Branches
    48

    ### Method
    AudioPlayer

    ### Complexity / LOC
    32 / 133 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioPlayer.cs
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
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio player class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class AudioPlayer : MediaWriter<AudioFrame>, IDisposable
    {
        /// <summary>
        ///     The ffplay
        /// </summary>
        internal readonly string ffplay;

        /// <summary>
        ///     The ffplayp
        /// </summary>
        private Process ffplayp;

        /// <summary>
        ///     Used for playing audio data
        /// </summary>
        /// <param name="input">Input audio to play (can be left empty if planning on playing samples directly)</param>
        /// <param name="ffplayExecutable">Name or path to the ffplay executable</param>
        public AudioPlayer(string input = null, string ffplayExecutable = "ffplay")
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioPlayerTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioPlayer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioPlayer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoPlayer.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    95

    ### Uncovered Branches
    36

    ### Method
    VideoPlayer

    ### Complexity / LOC
    26 / 128 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoPlayer.cs
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
using System.Diagnostics;
using System.IO;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The video player class
    /// </summary>
    /// <seealso cref="MediaWriter{Frame}" />
    /// <seealso cref="IDisposable" />
    public class VideoPlayer : MediaWriter<VideoFrame>, IDisposable
    {
        /// <summary>
        ///     The ffplay
        /// </summary>
        internal readonly string ffplay;

        /// <summary>
        ///     The ffplayp
        /// </summary>
        private Process ffplayp;

        /// <summary>
        ///     Used for playing video data
        /// </summary>
        /// <param name="input">Input video to play (can be left empty if planning on playing frames directly)</param>
        /// <param name="ffplayExecutable">Name or path to the ffplay executable</param>
        public VideoPlayer(string input = null, string ffplayExecutable = "ffplay")
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/VideoPlayerTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoPlayer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoPlayer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderTexture.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    93

    ### Uncovered Branches
    14

    ### Method
    RenderTexture

    ### Complexity / LOC
    38 / 187 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:RenderTexture.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Target for off-screen 2D rendering into an texture
    /// </summary>
    public class RenderTexture : ObjectBase, IRenderTarget
    {
        /// <summary>
        ///     The my default view
        /// </summary>
        internal readonly View myDefaultView;

        /// <summary>
        ///     The my texture
        /// </summary>
        internal readonly Texture myTexture;

        /// <summary>
        ///     Create the render-texture with the given dimensions
        /// </summary>
        /// <param name="width">Width of the render-texture</param>
        /// <param name="height">Height of the render-texture</param>
        public RenderTexture(uint width, uint height) :
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/RenderTextureTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderTexture.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage RenderTexture.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    91

    ### Uncovered Branches
    10

    ### Method
    Image

    ### Complexity / LOC
    27 / 162 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Image.cs
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Image is the low-level class for loading and
    ///     manipulating images
    /// </summary>
    public class Image : ObjectBase
    {
        /// <summary>
        /// The resource name
        /// </summary>
        private const string _resourceName = "image";

        /// <summary>
        ///     Construct the image with black color
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <exception cref="LoadingFailedException" />
        public Image(uint width, uint height) : this(width, height, Color.Black)
        {
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ImageTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Image.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Image.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP20.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    87

    ### Uncovered Branches
    0

    ### Method
    ImPlotP20

    ### Complexity / LOC
    41 / 117 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP20.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        /// <param name="boundsMax">The bounds max</param>
        public static void PlotHeatmap(string labelId, int[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin, ImPlotPoint boundsMax)
        {
            ImPlotNative.ImPlot_PlotHeatmap_S32Ptr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, boundsMax, 0);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP20Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP20.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP20.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/SfmlText.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    84

    ### Uncovered Branches
    10

    ### Method
    SfmlText

    ### Complexity / LOC
    30 / 197 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SfmlText.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     This class defines a graphical 2D text, that can be drawn on screen
    /// </summary>
    /// <remarks>
    ///     See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    public class SfmlText : Transformable, IDrawable
    {
        /// <summary>
        ///     The my font
        /// </summary>
        private Font myFont;


        /// <summary>
        ///     Default constructor
        /// </summary>
        public SfmlText() :
            this("", null)
        {
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/SfmlTextTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/SfmlText.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SfmlText.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

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
    34 / 200 lines

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

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    76

    ### Uncovered Branches
    2

    ### Method
    Transform

    ### Complexity / LOC
    23 / 129 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Transform.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Define a 3x3 transform matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Transform : IEquatable<Transform>
    {
        /// <summary>
        ///     Construct a transform from a 3x3 matrix
        /// </summary>
        /// <param name="a00">Element (0, 0) of the matrix</param>
        /// <param name="a01">Element (0, 1) of the matrix</param>
        /// <param name="a02">Element (0, 2) of the matrix</param>
        /// <param name="a10">Element (1, 0) of the matrix</param>
        /// <param name="a11">Element (1, 1) of the matrix</param>
        /// <param name="a12">Element (1, 2) of the matrix</param>
        /// <param name="a20">Element (2, 0) of the matrix</param>
        /// <param name="a21">Element (2, 1) of the matrix</param>
        /// <param name="a22">Element (2, 2) of the matrix</param>
        public Transform(float a00, float a01, float a02,
            float a10, float a11, float a12,
            float a20, float a21, float a22)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/TransformTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Transform.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Transform.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Transformable.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    72

    ### Uncovered Branches
    4

    ### Method
    Transformable

    ### Complexity / LOC
    16 / 112 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Transformable.cs
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
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Decomposed transform defined by a position, a rotation and a scale
    /// </summary>
    /// <remarks>
    ///     A note on coordinates and undistorted rendering:
    ///     By default, SFML (or more exactly, OpenGL) may interpolate drawable objects
    ///     such as sprites or texts when rendering. While this allows transitions
    ///     like slow movements or rotations to appear smoothly, it can lead to
    ///     unwanted results in some cases, for example blurred or distorted objects.
    ///     In order to render a SFML.Graphics.Drawable object pixel-perfectly, make sure
    ///     the involved coordinates allow a 1:1 mapping of pixels in the window
    ///     to texels (pixels in the texture). More specifically, this means:
    ///     * The object's position, origin and scale have no fractional part
    ///     * The object's and the view's rotation are a multiple of 90 degrees
    ///     * The view's center and size have no fractional part
    /// </remarks>
    public class Transformable : ObjectBase
    {
        /// <summary>
        ///     The my inverse need update
        /// </summary>
        private bool myInverseNeedUpdate = true;

        /// <summary>
        ///     The my inverse transform
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/TransformableTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Transformable.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Transformable.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundStream.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    69

    ### Uncovered Branches
    2

    ### Method
    SoundStream

    ### Complexity / LOC
    29 / 171 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SoundStream.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Abstract base class for streamed audio sources
    /// </summary>
    public abstract class SoundStream : ObjectBase
    {
        /// <summary>
        ///     The my seek callback
        /// </summary>
        /// <summary>
        ///     The my temp buffer
        /// </summary>
        private short[] myTempBuffer;

        /// <summary>
        ///     Default constructor
        /// </summary>
        protected SoundStream() :
            base(IntPtr.Zero)
        {
        }


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/SoundStreamTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundStream.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SoundStream.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBuffer.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    63

    ### Uncovered Branches
    8

    ### Method
    SoundBuffer

    ### Complexity / LOC
    16 / 121 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SoundBuffer.cs
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Storage for audio samples defining a sound
    /// </summary>
    public class SoundBuffer : ObjectBase
    {
        /// <summary>
        /// The resource name
        /// </summary>
        private const string _resourceName = "sound buffer";

        /// <summary>
        ///     Construct a sound buffer from a file
        ///     Here is a complete list of all the supported audio formats:
        ///     ogg, wav, flac, aiff, au, raw, paf, svx, nist, voc, ircam,
        ///     w64, mat4, mat5 pvf, htk, sds, avr, sd2, caf, wve, mpc2k, rf64.
        /// </summary>
        /// <param name="filename">Path of the sound file to load</param>
        /// <exception cref="LoadingFailedException" />
        public SoundBuffer(string filename) :
            base(sfSoundBuffer_createFromFile(filename))
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/SoundBufferTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBuffer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SoundBuffer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shape.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    60

    ### Uncovered Branches
    6

    ### Method
    Shape

    ### Complexity / LOC
    20 / 138 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Shape.cs
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
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Base class for textured shapes with outline
    /// </summary>
    public abstract class Shape : Transformable, IDrawable
    {
        /// <summary>
        ///     Roots callback delegates to prevent GC collection while registered with unmanaged SFML code.
        /// </summary>
        internal readonly List<Delegate> _pinnedCallbacks = new(2);

        /// <summary>
        ///     The my texture
        /// </summary>
        private Texture myTexture;

        /// <summary>
        ///     Default constructor
        /// </summary>
        protected Shape() :
            base(IntPtr.Zero)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ShapeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Shape.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Shape.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Font.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    59

    ### Uncovered Branches
    10

    ### Method
    Font

    ### Complexity / LOC
    21 / 111 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Font.cs
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
using Alis.Extension.Graphic.Sfml.Systems;
using Alis.Extension.Graphic.Sfml.Windows;
using LoadingFailedException = Alis.Extension.Graphic.Sfml.Windows.LoadingFailedException;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Font is the low-level class for loading and
    ///     manipulating character fonts. This class is meant to
    ///     be used by String2D
    /// </summary>
    public class Font : ObjectBase
    {
        /// <summary>
        ///     Roots the StreamAdaptor to prevent GC collection while referenced by unmanaged SFML code.
        /// </summary>
        internal readonly List<object> _pinnedObjects = new(1);

        /// <summary>
        ///     The texture
        /// </summary>
        internal readonly Dictionary<uint, Texture> myTextures = new Dictionary<uint, Texture>();

        /// <summary>
        ///     Construct the font from a file
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/FontTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Font.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Font.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Sound.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    53

    ### Uncovered Branches
    4

    ### Method
    Sound

    ### Complexity / LOC
    28 / 151 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Sound.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Regular sound that can be played in the audio environment
    /// </summary>
    public class Sound : ObjectBase
    {
        /// <summary>
        ///     The my buffer
        /// </summary>
        private SoundBuffer myBuffer;

        /// <summary>
        ///     Default constructor (invalid sound)
        /// </summary>
        public Sound() :
            base(sfSound_create())
        {
        }


        /// <summary>
        ///     Construct the sound with a buffer
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/SoundTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Sound.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Sound.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundRecorder.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    51

    ### Uncovered Branches
    2

    ### Method
    SoundRecorder

    ### Complexity / LOC
    19 / 111 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SoundRecorder.cs
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
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Base class intended for capturing sound data
    /// </summary>
    public abstract class SoundRecorder : ObjectBase
    {
        /// <summary>
        ///     Roots callback delegates to prevent GC collection while registered with unmanaged SFML code.
        /// </summary>
        internal readonly List<Delegate> _pinnedCallbacks = new(3);

        /// <summary>
        ///     Default constructor
        /// </summary>
        protected SoundRecorder() :
            base(IntPtr.Zero)
        {
            StartCallback myStartCallback = OnStart;
            _pinnedCallbacks.Add(myStartCallback);
            ProcessCallback myProcessCallback = ProcessSamples;
            _pinnedCallbacks.Add(myProcessCallback);
            StopCallback myStopCallback = OnStop;
            _pinnedCallbacks.Add(myStopCallback);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/SoundRecorderTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundRecorder.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SoundRecorder.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/View.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    48

    ### Uncovered Branches
    2

    ### Method
    View

    ### Complexity / LOC
    20 / 115 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:View.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     This class defines a view (position, size, etc.) ;
    ///     you can consider it as a 2D camera
    /// </summary>
    /// <remarks>
    ///     See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    public class View : ObjectBase
    {
        /// <summary>
        ///     The my external
        /// </summary>
        internal readonly bool myExternal;

        /// <summary>
        ///     Create a default view (1000x1000)
        /// </summary>
        public View() :
            base(sfView_create())
        {
        }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ViewTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/View.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage View.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/MacWindow.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    47

    ### Uncovered Branches
    0

    ### Method
    MacWindow

    ### Complexity / LOC
    16 / 59 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MacWindow.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Representa una ventana nativa de macOS
    /// </summary>
    internal class MacWindow
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MacWindow" /> class
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="title">The title</param>
        public MacWindow(int width, int height, string title)
        {
            Width = width;
            Height = height;
            Title = title;
            CrearVentana();
        }

        /// <summary>
        ///     Gets or sets the value of the handle
        /// </summary>
        public IntPtr Handle { get; private set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Osx/Native/MacWindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/MacWindow.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MacWindow.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/VertexArray.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    46

    ### Uncovered Branches
    4

    ### Method
    VertexArray

    ### Complexity / LOC
    15 / 106 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VertexArray.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Define a set of one or more 2D primitives
    /// </summary>
    public class VertexArray : ObjectBase, IDrawable
    {
        /// <summary>
        ///     Default constructor
        /// </summary>
        public VertexArray() :
            base(sfVertexArray_create())
        {
        }


        /// <summary>
        ///     Construct the vertex array with a type
        /// </summary>
        /// <param name="type">Type of primitives</param>
        public VertexArray(PrimitiveType type) :
            base(sfVertexArray_create())
            => PrimitiveType = type;


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/VertexArrayTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/VertexArray.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VertexArray.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    43

    ### Uncovered Branches
    6

    ### Method
    Sprite

    ### Complexity / LOC
    16 / 98 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     This class defines a sprite : texture, transformations,
    ///     color, and draw on screen
    /// </summary>
    /// <remarks>
    ///     See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    public class Sprite : Transformable, IDrawable
    {
        /// <summary>
        ///     The my texture
        /// </summary>
        private Texture myTexture;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public Sprite() :
            base(sfSprite_create())
        {
        }


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/SpriteTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Sprite.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Sprite.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/VertexBuffer.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    40

    ### Uncovered Branches
    4

    ### Method
    VertexBuffer

    ### Complexity / LOC
    16 / 108 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VertexBuffer.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     The vertex buffer class
    /// </summary>
    /// <seealso cref="ObjectBase" />
    /// <seealso cref="IDrawable" />
    public class VertexBuffer : ObjectBase, IDrawable
    {
        /// <summary>
        ///     Usage specifiers
        ///     If data is going to be updated once or more every frame,
        ///     set the usage to Stream. If data is going
        ///     to be set once and used for a long time without being
        ///     modified, set the usage to Static.
        ///     For everything else Dynamic should
        ///     be a good compromise.
        /// </summary>
        public enum UsageSpecifier
        {
            /// <summary>
            ///     The stream usage specifier
            /// </summary>
            Stream,

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/VertexBufferTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/VertexBuffer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VertexBuffer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderStates.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    37

    ### Uncovered Branches
    4

    ### Method
    RenderStates

    ### Complexity / LOC
    18 / 60 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:RenderStates.cs
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
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Define the states used for drawing to a RenderTarget
    /// </summary>
    public struct RenderStates
    {
        /// <summary>
        ///     Construct a default set of render states with a custom blend mode
        /// </summary>
        /// <param name="blendMode">Blend mode to use</param>
        public RenderStates(BlendMode blendMode) :
            this(blendMode, Transform.Identity, null, null)
        {
        }


        /// <summary>
        ///     Construct a default set of render states with a custom transform
        /// </summary>
        /// <param name="transform">Transform to use</param>
        public RenderStates(Transform transform) :
            this(BlendMode.Alpha, transform, null, null)
        {
        }


        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/RenderStatesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RenderStates.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage RenderStates.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/MacOpenGLContext.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    33

    ### Uncovered Branches
    0

    ### Method
    MacOpenGLContext

    ### Complexity / LOC
    10 / 44 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MacOpenGLContext.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Gestiona el contexto OpenGL nativo en macOS
    /// </summary>
    internal class MacOpenGLContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MacOpenGLContext" /> class
        /// </summary>
        /// <param name="window">The window</param>
        public MacOpenGLContext(MacWindow window)
        {
            CrearContexto(window);
        }

        /// <summary>
        ///     Gets or sets the value of the view
        /// </summary>
        public IntPtr View { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the context
        /// </summary>
        public IntPtr Context { get; private set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Osx/Native/MacOpenGLContextTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/MacOpenGLContext.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MacOpenGLContext.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/CircleShape.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    32

    ### Uncovered Branches
    0

    ### Method
    CircleShape

    ### Complexity / LOC
    9 / 48 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CircleShape.cs
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

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Specialized shape representing a circle
    /// </summary>
    public class CircleShape : Shape
    {
        /// <summary>
        ///     The my point count
        /// </summary>
        private uint myPointCount;

        /// <summary>
        ///     The my radius
        /// </summary>
        internal float myRadius;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public CircleShape() : this(0)
        {
        }


        /// <summary>
        ///     Construct the shape with an initial radius
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/CircleShapeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/CircleShape.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CircleShape.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/SfmlTime.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    26

    ### Uncovered Branches
    2

    ### Method
    SfmlTime

    ### Complexity / LOC
    26 / 50 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SfmlTime.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     This class represents a time value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SfmlTime : IEquatable<SfmlTime>
    {
        /// <summary>
        ///     Predefined "zero" time value
        /// </summary>
        public static readonly SfmlTime Zero = FromMicroseconds(0);


        /// <summary>
        ///     Construct a time value from a number of seconds
        /// </summary>
        /// <param name="seconds">Number of seconds</param>
        /// <returns>Time value constructed from the amount of seconds</returns>
        public static SfmlTime FromSeconds(float seconds) => sfSeconds(seconds);


        /// <summary>
        ///     Construct a time value from a number of milliseconds
        /// </summary>
        /// <param name="milliseconds">Number of milliseconds</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Systems/SfmlTimeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/SfmlTime.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SfmlTime.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/ConvexShape.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    26

    ### Uncovered Branches
    2

    ### Method
    ConvexShape

    ### Complexity / LOC
    8 / 36 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ConvexShape.cs
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

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Specialized shape representing a convex polygon
    /// </summary>
    public class ConvexShape : Shape
    {
        /// <summary>
        ///     The my points
        /// </summary>
        private Vector2F[] myPoints = [];

        /// <summary>
        ///     Default constructor
        /// </summary>
        public ConvexShape() : this(0)
        {
        }


        /// <summary>
        ///     Construct the shape with an initial point count
        /// </summary>
        /// <param name="pointCount">Number of points of the shape</param>
        public ConvexShape(uint pointCount)
        {
            SetPointCount(pointCount);
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ConvexShapeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/ConvexShape.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ConvexShape.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/VideoMode.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    25

    ### Uncovered Branches
    2

    ### Method
    VideoMode

    ### Complexity / LOC
    7 / 55 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoMode.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     VideoMode defines a video mode (width, height, bpp, frequency)
    ///     and provides static functions for getting modes supported
    ///     by the display device
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct VideoMode
    {
        /// <summary>
        ///     Construct the video mode with its width and height
        /// </summary>
        /// <param name="width">Video mode width</param>
        /// <param name="height">Video mode height</param>
        public VideoMode(uint width, uint height) :
            this(width, height, 32)
        {
        }


        /// <summary>
        ///     Construct the video mode with its width, height and depth
        /// </summary>
        /// <param name="width">Video mode width</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/VideoModeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/VideoMode.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoMode.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Joystick.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    22

    ### Uncovered Branches
    0

    ### Method
    Joystick

    ### Complexity / LOC
    13 / 70 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Joystick.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of the joysticks
    /// </summary>
    public static class Joystick
    {
        /// <summary>
        ///     Axes supported by SFML joysticks
        /// </summary>
        public enum Axis
        {
            /// <summary>The X axis</summary>
            X,

            /// <summary>The Y axis</summary>
            Y,

            /// <summary>The Z axis</summary>
            Z,

            /// <summary>The R axis</summary>
            R,

            /// <summary>The U axis</summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/JoystickTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Joystick.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Joystick.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Clipboard.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    21

    ### Uncovered Branches
    2

    ### Method
    Clipboard

    ### Complexity / LOC
    3 / 44 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Clipboard.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     The clipboard class
    /// </summary>
    public static class Clipboard
    {
        /// <summary>
        ///     The contents of the Clipboard as a UTF-32 string
        /// </summary>
        public static string Contents
        {
            get
            {
                IntPtr source = sfClipboard_getUnicodeString();

                uint length = 0;
                while (Marshal.ReadInt32(source, (int) (length * 4)) != 0)
                {
                    length++;
                }

                byte[] sourceBytes = new byte[length * 4];
                Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/ClipboardTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Clipboard.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Clipboard.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    20

    ### Uncovered Branches
    2

    ### Method
    Context

    ### Complexity / LOC
    7 / 47 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Context.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    //////////////////////////////////////////////////////////////////
    /// <summary>
    ///     This class defines a .NET interface to an SFML OpenGL Context
    /// </summary>
    //////////////////////////////////////////////////////////////////
    public class Context : CriticalFinalizerObject
    {
        /// <summary>
        ///     The our global context
        /// </summary>
        private static Context _ourGlobalContext;

        /// <summary>
        ///     The zero
        /// </summary>
        internal readonly IntPtr myThis = IntPtr.Zero;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public Context() => myThis = sfContext_create();

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/ContextTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Context.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Context.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RectangleShape.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    19

    ### Uncovered Branches
    5

    ### Method
    RectangleShape

    ### Complexity / LOC
    11 / 41 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:RectangleShape.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Sfml.Render
{
    /// <summary>
    ///     Specialized shape representing a rectangle
    /// </summary>
    public class RectangleShape : Shape
    {
        /// <summary>
        ///     The my size
        /// </summary>
        private Vector2F mySize;

        /// <summary>
        ///     Default constructor
        /// </summary>
        public RectangleShape() :
            this(new Vector2F(0, 0))
        {
        }


        /// <summary>
        ///     Construct the shape with an initial size
        /// </summary>
        /// <param name="size">Size of the shape</param>
        public RectangleShape(Vector2F size) => Size = size;


        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/RectangleShapeTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/RectangleShape.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage RectangleShape.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Cursor.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    18

    ### Uncovered Branches
    0

    ### Method
    Cursor

    ### Complexity / LOC
    3 / 57 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Cursor.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     The cursor class
    /// </summary>
    /// <seealso cref="ObjectBase" />
    public class Cursor : ObjectBase
    {
        /// <summary>
        ///     Enumeration of possibly available native system cursor types
        /// </summary>
        public enum CursorType
        {
            /// <summary>
            ///     Arrow cursor (default)
            ///     Windows: Yes
            ///     Mac OS:  Yes
            ///     Linux:   Yes
            /// </summary>
            Arrow,

            /// <summary>
            ///     Busy arrow cursor
            ///     Windows: Yes
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/CursorTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Cursor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Cursor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBufferRecorder.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    16

    ### Uncovered Branches
    2

    ### Method
    SoundBufferRecorder

    ### Complexity / LOC
    5 / 27 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SoundBufferRecorder.cs
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

using System.Collections.Generic;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     Specialized SoundRecorder which saves the captured
    ///     audio data into a sound buffer
    /// </summary>
    public class SoundBufferRecorder : SoundRecorder
    {
        /// <summary>
        ///     The list
        /// </summary>
        internal readonly List<short> mySamplesArray = new List<short>();

        /// <summary>
        ///     The my sound buffer
        /// </summary>
        private SoundBuffer mySoundBuffer;

        /// <summary>
        ///     Sound buffer containing the captured audio data
        ///     The sound buffer is valid only after the capture has ended.
        ///     This function provides a reference to the internal
        ///     sound buffer, but you should make a copy of it if you want
        ///     to make any modifications to it.
        /// </summary>

        public SoundBuffer SoundBuffer => mySoundBuffer;


    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/SoundBufferRecorderTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/SoundBufferRecorder.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SoundBufferRecorder.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontGlyphRangesBuilder.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    14

    ### Uncovered Branches
    0

    ### Method
    ImFontGlyphRangesBuilder

    ### Complexity / LOC
    6 / 24 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImFontGlyphRangesBuilder.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font glyph ranges builder
    /// </summary>
    public struct ImFontGlyphRangesBuilder
    {
        /// <summary>
        ///     The used chars
        /// </summary>
        public ImVector UsedChars { get; set; }


        /// <summary>
        ///     Adds the char using the specified c
        /// </summary>
        /// <param name="c">The </param>
        public void AddChar(ushort c)
        {
            ImGuiNative.ImFontGlyphRangesBuilder_AddChar(ref this, c);
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontGlyphRangesBuilder_Clear(ref this);
        }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImFontGlyphRangesBuilderTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontGlyphRangesBuilder.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImFontGlyphRangesBuilder.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/GameWindow.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    10

    ### Uncovered Branches
    0

    ### Method
    GameWindow

    ### Complexity / LOC
    3 / 17 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GameWindow.cs
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

using Alis.Extension.Graphic.Glfw.Structs;

namespace Alis.Extension.Graphic.Glfw
{
    /// <inheritdoc cref="NativeWindow" />
    public class GameWindow : NativeWindow
    {
        /// <inheritdoc cref="NativeWindow()" />
        public GameWindow()
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string)" />
        public GameWindow(int width, int height, string title) : base(width, height, title)
        {
        }

        /// <inheritdoc cref="NativeWindow(int, int, string, Monitor, Window)" />
        public GameWindow(int width, int height, string title, Monitor monitor, Window share) : base(width, height,
            title, monitor, share)
        {
        }
    }
}
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/GameWindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/GameWindow.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GameWindow.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/Clock.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    0

    ### Method
    Clock

    ### Complexity / LOC
    4 / 28 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Clock.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     Utility class that measures the elapsed time
    /// </summary>
    public class Clock : ObjectBase
    {
        /// <summary>
        ///     Default Constructor
        /// </summary>
        public Clock() : base(sfClock_create())
        {
        }


        /// <summary>
        ///     Gets the time elapsed since the last call to Restart
        /// </summary>

        public SfmlTime ElapsedSfmlTime => sfClock_getElapsedTime(CPointer);


        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Systems/ClockTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/Clock.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Clock.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Listener.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    8

    ### Uncovered Branches
    0

    ### Method
    Listener

    ### Complexity / LOC
    8 / 47 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Listener.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Audios
{
    /// <summary>
    ///     The audio listener is the point in the scene
    ///     from where all the sounds are heard
    /// </summary>
    public static class Listener
    {
        /// <summary>
        ///     The volume is a number between 0 and 100; it is combined with
        ///     the individual volume of each sound / music.
        ///     The default value for the volume is 100 (maximum).
        /// </summary>

        public static float GlobalVolume
        {
            get => sfListener_getGlobalVolume();
            set => sfListener_setGlobalVolume(value);
        }


        /// <summary>
        ///     3D position of the listener (default is (0, 0, 0))
        /// </summary>

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Audios/ListenerTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Audios/Listener.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Listener.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Touch.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: 0.0%)

    ### Uncovered Lines
    8

    ### Uncovered Branches
    2

    ### Method
    Touch

    ### Complexity / LOC
    4 / 26 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Touch.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of the touches
    /// </summary>
    public static class Touch
    {
        /// <summary>
        ///     Check if a touch event is currently down
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <returns>True if the finger is currently touching the screen, false otherwise</returns>
        public static bool IsDown(uint finger) => sfTouch_isDown(finger);


        /// <summary>
        ///     This function returns the current touch position
        /// </summary>
        /// <param name="finger">Finger index</param>
        /// <returns>Current position of the finger</returns>
        ////////////////////////////////////////////////////////////
        public static Vector2F GetPosition(uint finger) => GetPosition(finger, null);

        ////////////////////////////////////////////////////////////
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/TouchTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Touch.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Touch.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Sensor.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    0

    ### Method
    Sensor

    ### Complexity / LOC
    3 / 33 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Sensor.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of sensors
    /// </summary>
    public static class Sensor
    {
        /// <summary>
        ///     Sensor types
        /// </summary>
        public enum Type
        {
            /// <summary>Measures the raw acceleration (m/s^2)</summary>
            Accelerometer,

            /// <summary>Measures the raw rotation rates (degrees/s)</summary>
            Gyroscope,

            /// <summary>Measures the ambient magnetic field (micro-teslas)</summary>
            Magnetometer,

            /// <summary>Measures the direction and intensity of gravity, independent of device acceleration (m/s^2)</summary>
            Gravity,

            /// <summary>Measures the direction and intensity of device acceleration, independent of the gravity (m/s^2)</summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/SensorTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Sensor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Sensor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:6_Ideation/Math/src/Util/Constant.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    0

    ### Method
    Constant

    ### Complexity / LOC
    0 / 16 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Constant.cs
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

namespace Alis.Core.Aspect.Math.Util
{
    /// <summary>
    ///     Provides commonly used mathematical constants for single-precision floating-point computations,
    ///     including epsilon, Euler's number, pi, logarithmic values, and tau.
    /// </summary>
    public static class Constant
    {
        /// <summary>
        ///     A very small positive epsilon value (1.192092896e-07f) used as a tolerance threshold
        ///     for floating-point comparisons and near-zero checks.
        /// </summary>
        public const float Epsilon = 1.192092896e-07f;

        /// <summary>
        ///     Euler's number (2.71828175f) representing the base of natural logarithms,
        ///     used in exponential and logarithmic mathematical operations.
        /// </summary>
        public const float Euler = 2.7182818284590452354f;

        /// <summary>Represents the mathematical constant e(2.71828175).</summary>
        public const float E = (float) System.Math.E;

        /// <summary>Represents the log base ten of e(0.4342945).</summary>
        public const float Log10E = 0.4342945f;

        /// <summary>Represents the log base two of e(1.442695).</summary>
        public const float Log2E = 1.442695f;

        /// <summary>Represents the value of pi(3.14159274).</summary>
        public const float Pi = (float) System.Math.PI;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:6_Ideation/Math/test/Util/ConstantTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:6_Ideation/Math/src/Util/Constant.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Constant.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Keyboard.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    0

    ### Method
    Keyboard

    ### Complexity / LOC
    2 / 130 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Keyboard.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of the keyboard
    /// </summary>
    public static class Keyboard
    {
        /// <summary>
        ///     Key codes
        /// </summary>
        public enum Key
        {
            /// <summary>Unhandled key</summary>
            Unknown = -1,

            /// <summary>The A key</summary>
            A = 0,

            /// <summary>The B key</summary>
            B,

            /// <summary>The C key</summary>
            C,

            /// <summary>The D key</summary>
            D,
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/KeyboardTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Keyboard.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Keyboard.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Constant.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    0

    ### Method
    Constant

    ### Complexity / LOC
    0 / 9 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Constant.cs
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

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Provides mathematical constants used throughout the physics engine.
    /// </summary>
    /// <remarks>
    ///     These constants are pre-computed as float values for performance in hot paths.
    ///     The names follow common mathematical conventions: Pi (Ï) and Tau (Ï = 2Ï).
    /// </remarks>
    internal static class Constant
    {
        /// <summary>
        ///     The ratio of a circle's circumference to its diameter (Ï â 3.14159).
        /// </summary>
        public const float Pi = (float) Math.PI;

        /// <summary>
        ///     The ratio of a circle's circumference to its radius (Ï = 2Ï â 6.28318).
        ///     Also known as "tau", this constant is useful for angle calculations in full circles.
        /// </summary>
        public const float Tau = (float) (Math.PI * 2.0);
    }
}
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/ConstantTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Constant.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Constant.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesMiniMapNodeHoveringCallback.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ImNodesMiniMapNodeHoveringCallback

    ### Complexity / LOC
    1 / 7 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImNodesMiniMapNodeHoveringCallback.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes mini map node hovering callback class
    /// </summary>
    public class ImNodesMiniMapNodeHoveringCallback
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesMiniMapNodeHoveringCallback"/> class
        /// </summary>
        public ImNodesMiniMapNodeHoveringCallback() { }
    }
}
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Node/ImNodesMiniMapNodeHoveringCallbackTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesMiniMapNodeHoveringCallback.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImNodesMiniMapNodeHoveringCallback.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesMiniMapNodeHoveringCallbackUserData.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ImNodesMiniMapNodeHoveringCallbackUserData

    ### Complexity / LOC
    1 / 7 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImNodesMiniMapNodeHoveringCallbackUserData.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes mini map node hovering callback user data class
    /// </summary>
    public class ImNodesMiniMapNodeHoveringCallbackUserData
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImNodesMiniMapNodeHoveringCallbackUserData"/> class
        /// </summary>
        public ImNodesMiniMapNodeHoveringCallbackUserData() { }
    }
}
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Node/ImNodesMiniMapNodeHoveringCallbackUserDataTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesMiniMapNodeHoveringCallbackUserData.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImNodesMiniMapNodeHoveringCallbackUserData.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Categories.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    Categories

    ### Complexity / LOC
    0 / 41 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Categories.cs
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

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The category enum
    /// </summary>
    [Flags]
    public enum Categories
    {
        /// <summary>
        ///     The none category
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat1 = 0x00000001,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat2 = 0x00000002,

        /// <summary>
        ///     The cat category
        /// </summary>
        Cat3 = 0x00000004,

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/CategoriesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Categories.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Categories.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Logic/ControllerCategories.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ControllerCategories

    ### Complexity / LOC
    0 / 41 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ControllerCategories.cs
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

namespace Alis.Core.Physic.Common.Logic
{
    /// <summary>
    ///     The controller category enum
    /// </summary>
    [Flags]
    public enum ControllerCategories
    {
        /// <summary>
        ///     The none controller category
        /// </summary>
        None = 0x00000000,

        /// <summary>
        ///     The cat 01 controller category
        /// </summary>
        Cat01 = 0x00000001,

        /// <summary>
        ///     The cat 02 controller category
        /// </summary>
        Cat02 = 0x00000002,

        /// <summary>
        ///     The cat 03 controller category
        /// </summary>
        Cat03 = 0x00000004,

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Logic/ControllerCategoriesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Logic/ControllerCategories.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ControllerCategories.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Mapping/SdlInputConst.cs

    ### Language
    cs

    ### Coverage
    0.0% (Line: 0.0%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    SdlInputConst

    ### Complexity / LOC
    0 / 40 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SdlInputConst.cs
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

namespace Alis.Extension.Graphic.Sdl2.Mapping
{
    /// <summary>
    ///     The sdl input const class
    /// </summary>
    public static class SdlInputConst
    {
        /// <summary>
        ///     The sdl scancode mask
        /// </summary>
        public const int KScancodeMask = 1 << 30;

        /// <summary>
        ///     The sdl button left
        /// </summary>
        public const uint ButtonLeft = 1;

        /// <summary>
        ///     The sdl button middle
        /// </summary>
        public const uint ButtonMiddle = 2;

        /// <summary>
        ///     The sdl button right
        /// </summary>
        public const uint ButtonRight = 3;

        /// <summary>
        ///     The max value
        /// </summary>
        public const uint TouchMouseId = uint.MaxValue;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/Mapping/SdlInputConstTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Mapping/SdlInputConst.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SdlInputConst.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP7.cs

    ### Language
    cs

    ### Coverage
    0.6% (Line: 0.6%, Branch: 0.0%)

    ### Uncovered Lines
    486

    ### Uncovered Branches
    22

    ### Method
    ImGuiP7

    ### Complexity / LOC
    155 / 640 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP7.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui class
    /// </summary>
    public static partial class ImGui
    {
        /// <summary>
        ///     Describes whether menu item
        /// </summary>
        /// <param name="label">The label</param>
        /// <param name="shortcut">The shortcut</param>
        /// <param name="pSelected">The selected</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The bool</returns>
        public static bool MenuItem(string label, string shortcut, ref bool pSelected, bool enabled)
        {
            byte ret = ImGuiNative.igMenuItem_BoolPtr(Encoding.UTF8.GetBytes(label), Encoding.UTF8.GetBytes(shortcut), pSelected, enabled);
            return ret != 0;
        }

        /// <summary>
        ///     News the frame
        /// </summary>
        public static void NewFrame()
        {
            ImGuiNative.igNewFrame();
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiP7Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiP7.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiP7.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP3.cs

    ### Language
    cs

    ### Coverage
    1.4% (Line: 1.4%, Branch: None%)

    ### Uncovered Lines
    139

    ### Uncovered Branches
    0

    ### Method
    ImPlotP3

    ### Complexity / LOC
    47 / 195 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP3.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotErrorBars(string labelId, ref float xs, ref float ys, ref float err, int count, ImPlotErrorBarsFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotErrorBars_FloatPtrFloatPtrFloatPtrInt(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, err, count, flags, offset, sizeof(float));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="err">The err</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP3Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP3.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP3.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs

    ### Language
    cs

    ### Coverage
    1.5% (Line: 1.8%, Branch: 0.0%)

    ### Uncovered Lines
    166

    ### Uncovered Branches
    32

    ### Method
    Window

    ### Complexity / LOC
    68 / 334 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Window is a rendering window ; it can create a new window
    ///     or connect to an existing one
    /// </summary>
    public class Window : ObjectBase
    {
        /// <summary>
        ///     Create the window with default style and creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
        /// <param name="title">Title of the window</param>
        public Window(VideoMode mode, string title) :
            this(mode, title, Styles.Default, new ContextSettings(0, 0))
        {
        }


        /// <summary>
        ///     Create the window with default creation settings
        /// </summary>
        /// <param name="mode">Video mode to use</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/WindowTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Window.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Window.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs

    ### Language
    cs

    ### Coverage
    1.6% (Line: 1.5%, Branch: 1.6%)

    ### Uncovered Lines
    445

    ### Uncovered Branches
    61

    ### Method
    ImPlotP2

    ### Complexity / LOC
    110 / 534 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2.cs
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
        ///     Ends the drag drop target
        /// </summary>
        public static void EndDragDropTarget()
        {
            ImPlotNative.ImPlot_EndDragDropTarget();
        }

        /// <summary>
        ///     Ends the legend popup
        /// </summary>
        public static void EndLegendPopup()
        {
            ImPlotNative.ImPlot_EndLegendPopup();
        }

        /// <summary>
        ///     Ends the plot
        /// </summary>
        public static void EndPlot()
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP2Tests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP2.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP2.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/SdlTtf.cs

    ### Language
    cs

    ### Coverage
    2.2% (Line: 2.2%, Branch: None%)

    ### Uncovered Lines
    176

    ### Uncovered Branches
    0

    ### Method
    SdlTtf

    ### Complexity / LOC
    47 / 249 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SdlTtf.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2.Sdl2Ttf
{
    /// <summary>
    ///     The sdl ttf extern class
    /// </summary>
    public static class SdlTtf
    {
        /// <summary>
        ///     The unicode bom native
        /// </summary>
        public const int UnicodeBomNative = 0xFEFF;

        /// <summary>
        ///     The unicode bom swapped
        /// </summary>
        public const int UnicodeBomSwapped = 0xFFFE;

        /// <summary>
        ///     The ttf style normal
        /// </summary>
        public const int TtfStyleNormal = 0x00;

        /// <summary>
        ///     The ttf style bold
        /// </summary>
        public const int TtfStyleBold = 0x01;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/Sdl2Ttf/SdlTtfTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Ttf/SdlTtf.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SdlTtf.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodes.cs

    ### Language
    cs

    ### Coverage
    3.3% (Line: 3.5%, Branch: 0.0%)

    ### Uncovered Lines
    386

    ### Uncovered Branches
    18

    ### Method
    ImNodes

    ### Complexity / LOC
    105 / 513 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImNodes.cs
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

//  File:ImNodes.cs
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


using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes class
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Node/ImNodesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodes.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImNodes.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatform.cs

    ### Language
    cs

    ### Coverage
    4.2% (Line: 5.7%, Branch: 1.0%)

    ### Uncovered Lines
    416

    ### Uncovered Branches
    205

    ### Method
    WebAssemblyPlatform

    ### Complexity / LOC
    204 / 543 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyPlatform.cs
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
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     WebAssembly platform controller implementing INativePlatform interface
    ///     Provides full support for graphics, input handling, and window management
    ///     in WebAssembly environments for cross-platform game development.
    /// </summary>
    
    public class WebAssemblyPlatform : INativePlatform
    {
        /// <summary>
        /// The window width
        /// </summary>
        internal int _windowWidth;
        /// <summary>
        /// The window height
        /// </summary>
        internal int _windowHeight;

        /// <summary>
        /// The is window visible
        /// </summary>
        private bool _isWindowVisible;
        /// <summary>
        /// The window should close
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyPlatformTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyPlatform.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyPlatform.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Image/SdlImage.cs

    ### Language
    cs

    ### Coverage
    4.8% (Line: 4.8%, Branch: None%)

    ### Uncovered Lines
    20

    ### Uncovered Branches
    0

    ### Method
    SdlImage

    ### Complexity / LOC
    21 / 29 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SdlImage.cs
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
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Sdl2Image
{
    /// <summary>
    ///     The sdl image class
    /// </summary>
    public static class SdlImage
    {
        /// <summary>
        ///     Versions
        /// </summary>
        /// <returns>The version</returns>
        public static Version Version() => new Version(2, 0, 6);

        /// <summary>
        ///     Linkeds the version
        /// </summary>
        /// <returns>The version</returns>
        public static Version LinkedVersion() => Marshal.PtrToStructure<Version>(NativeSdlImage.InternalVersion());

        /// <summary>
        ///     Loads the img using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadImg(string file) => NativeSdlImage.InternalLoad(Marshal.StringToHGlobalAnsi(file));

        /// <summary>
        ///     Loads the typed rw using the specified src
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/Sdl2Image/SdlImageTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl2Image/SdlImage.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SdlImage.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/ObjectiveCInterop.cs

    ### Language
    cs

    ### Coverage
    5.0% (Line: 5.0%, Branch: None%)

    ### Uncovered Lines
    19

    ### Uncovered Branches
    0

    ### Method
    ObjectiveCInterop

    ### Complexity / LOC
    5 / 96 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ObjectiveCInterop.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Core.Graphic.Platforms.Osx.Native
{
    /// <summary>
    ///     Utilidades para interoperar con Objective-C
    /// </summary>
    internal static class ObjectiveCInterop
    {
        /// <summary>
        ///     The objc
        /// </summary>
        public const string Objc = "/usr/lib/libobjc.A.dylib";
        /// <summary>
        ///     Gets the selMouseLocationOutside
        /// </summary>

        internal static readonly IntPtr selMouseLocationOutside =
            Sel("mouseLocationOutsideOfEventStream");
        /// <summary>
        ///     Gets the selConvertPointFromView
        /// </summary>

        internal static readonly IntPtr selConvertPointFromView =
            Sel("convertPoint:fromView:");

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Osx/Native/ObjectiveCInteropTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/Native/ObjectiveCInterop.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ObjectiveCInterop.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaStream.cs

    ### Language
    cs

    ### Coverage
    6.1% (Line: 6.4%, Branch: 0.0%)

    ### Uncovered Lines
    44

    ### Uncovered Branches
    2

    ### Method
    MediaStream

    ### Complexity / LOC
    92 / 104 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MediaStream.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media stream class
    /// </summary>
    [Serializable]
    public partial class MediaStream
    {
        /// <summary>
        ///     Gets or sets the value of the index
        /// </summary>
        [JsonNativePropertyName("index")]
        public long Index { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec name
        /// </summary>
        [JsonNativePropertyName("codec_name")]
        public string CodecName { get; set; }

        /// <summary>
        ///     Gets or sets the value of the codec long name
        /// </summary>
        [JsonNativePropertyName("codec_long_name")]
        public string CodecLongName { get; set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/BaseClasses/MediaStreamTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaStream.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MediaStream.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontPtr.cs

    ### Language
    cs

    ### Coverage
    6.3% (Line: 6.7%, Branch: 0.0%)

    ### Uncovered Lines
    56

    ### Uncovered Branches
    4

    ### Method
    ImFontPtr

    ### Complexity / LOC
    34 / 83 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImFontPtr.cs
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

//  File:ImFontPtr.cs
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


using System;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im font ptr
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImFontPtrTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImFontPtr.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImFontPtr.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs

    ### Language
    cs

    ### Coverage
    11.1% (Line: 9.5%, Branch: 17.6%)

    ### Uncovered Lines
    379

    ### Uncovered Branches
    84

    ### Method
    WebAssemblyGameExamples

    ### Complexity / LOC
    76 / 411 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyGameExamples.cs
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
using System.Threading;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Examples and utilities for developing games with WebAssembly
    ///     This class provides practical examples and helper methods for common game development tasks
    /// </summary>
    
    public static class WebAssemblyGameExamples
    {
        /// <summary>
        ///     Example 1: Basic game loop setup
        ///     Shows how to create a simple game context and run a basic game loop
        /// </summary>
        public static void BasicGameLoopExample()
        {
            using (WebAssemblyGameContext gameContext = WebAssemblyGameContext.Create(1280, 720, "My Game"))
            {
                gameContext.RegisterAction("Move_Up", ConsoleKey.W, ConsoleKey.UpArrow);
                gameContext.RegisterAction("Move_Down", ConsoleKey.S, ConsoleKey.DownArrow);
                gameContext.RegisterAction("Move_Left", ConsoleKey.A, ConsoleKey.LeftArrow);
                gameContext.RegisterAction("Move_Right", ConsoleKey.D, ConsoleKey.RightArrow);
                gameContext.RegisterAction("Jump", ConsoleKey.Spacebar);
                gameContext.RegisterAction("MenuToggle", ConsoleKey.Escape);

                gameContext.OnUpdate += (sender, e) =>
                {
                    if (gameContext.IsActionActive("Move_Up"))
                    {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyGameExamplesTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyGameExamples.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyGameExamples.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs

    ### Language
    cs

    ### Coverage
    12.7% (Line: 12.7%, Branch: None%)

    ### Uncovered Lines
    647

    ### Uncovered Branches
    0

    ### Method
    ImGuiIO

    ### Complexity / LOC
    1481 / 781 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIO.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui io
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct ImGuiIo
    {
        /// <summary>
        ///     The config flags
        /// </summary>
        public ImGuiConfigFlags ConfigFlags { get; set; }

        /// <summary>
        ///     The backend flags
        /// </summary>
        public ImGuiBackendFlags BackendFlags { get; set; }

        /// <summary>
        ///     The display size
        /// </summary>
        public Vector2F DisplaySize { get; set; }

        /// <summary>
        ///     The delta time
        /// </summary>
        public float DeltaTime { get; set; }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiIOTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiIO.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiIO.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/MacNativePlatform.cs

    ### Language
    cs

    ### Coverage
    14.2% (Line: 15.7%, Branch: 9.8%)

    ### Uncovered Lines
    295

    ### Uncovered Branches
    111

    ### Method
    MacNativePlatform

    ### Complexity / LOC
    101 / 424 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatform.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;
using Alis.Core.Graphic.Platforms.Osx.Native;

namespace Alis.Core.Graphic.Platforms.Osx
{
    /// <summary>
    ///     Plataforma nativa para macOS, coordinando ventana y contexto OpenGL
    /// </summary>
    public class MacNativePlatform : INativePlatform
    {
        /// <summary>
        /// </summary>
        private static IntPtr _openGlHandle = IntPtr.Zero;

        /// <summary>
        ///     The mouse buttons
        /// </summary>
        internal readonly bool[] mouseButtons = new bool[5];

        /// <summary>
        ///     The pressed keys
        /// </summary>
        internal readonly HashSet<ConsoleKey> pressedKeys = new HashSet<ConsoleKey>();

        /// <summary>
        /// </summary>
        private MacOpenGLContext glContext;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Osx/MacNativePlatformTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Osx/MacNativePlatform.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MacNativePlatform.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Vulkan.cs

    ### Language
    cs

    ### Coverage
    18.2% (Line: 25.0%, Branch: 0.0%)

    ### Uncovered Lines
    12

    ### Uncovered Branches
    6

    ### Method
    Vulkan

    ### Complexity / LOC
    6 / 44 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Vulkan.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace Alis.Extension.Graphic.Glfw
{
    /// <summary>
    ///     Implements the Vulkan specific functions of GLFW.
    ///     <para>See http://www.glfw.org/docs/latest/vulkan_guide.html for detailed documentation.</para>
    /// </summary>
    [SuppressUnmanagedCodeSecurity]
    public static class Vulkan
    {
        /// <summary>
        ///     Gets whether the Vulkan loader has been found. This check is performed by <see cref="GlfwNative.Init" />.
        /// </summary>
        /// <value>
        ///     <c>true</c> if Vulkan is supported; otherwise <c>false</c>.
        /// </value>
        public static bool IsSupported => VulkanSupported();


        /// <summary>
        ///     This function creates a Vulkan surface for the specified window.
        /// </summary>
        /// <param name="vulkan">A pointer to the Vulkan instance.</param>
        /// <param name="window">The window handle.</param>
        /// <param name="allocator">A pointer to the allocator to use, or <see cref="IntPtr.Zero" /> to use default allocator.</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/VulkanTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Vulkan.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Vulkan.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl.cs

    ### Language
    cs

    ### Coverage
    19.6% (Line: 19.3%, Branch: 50.0%)

    ### Uncovered Lines
    673

    ### Uncovered Branches
    4

    ### Method
    Sdl

    ### Complexity / LOC
    381 / 1042 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Sdl.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Point;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sdl2.Delegates;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;
using Alis.Extension.Graphic.Sdl2.Structs;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2
{
    /// <summary>
    ///     The sdl class
    /// </summary>
    public static class Sdl
    {
        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        public const int TextEditingEventTextSize = 32;

        /// <summary>
        ///     The sdl text input event text size
        /// </summary>
        public const int TextInputEventTextSize = 32;

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/test/SdlTests.cs

    Priority
    CRITICAL (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sdl2/src/Sdl.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Sdl.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Gl.cs

    ### Language
    cs

    ### Coverage
    30.7% (Line: 30.6%, Branch: 31.3%)

    ### Uncovered Lines
    145

    ### Uncovered Branches
    11

    ### Method
    Gl

    ### Complexity / LOC
    101 / 262 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Gl.cs
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
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Graphic.OpenGL.Delegates;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.OpenGL
{
    /// <summary>
    ///     The gl class
    /// </summary>
    public static class Gl
    {
        /// <summary>
        ///     Activates the specified texture unit
        /// </summary>
        /// <param name="texture">The texture unit</param>
        public delegate void ActiveTexture(TextureUnit texture);

        // Enum para FramebufferTarget

        /// <summary>
        ///     The bind framebuffer
        /// </summary>
        public delegate void BindFramebuffer(FramebufferTarget target, uint framebuffer);

        /// <summary>
        ///     The framebuffer texture
        /// </summary>
        public delegate void FramebufferTexture2D(FramebufferTarget target, FramebufferAttachment attachment, TextureTarget texTarget, uint texture, int level);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/OpenGL/GlTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Gl.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Gl.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs

    ### Language
    cs

    ### Coverage
    31.6% (Line: 30.1%, Branch: 40.0%)

    ### Uncovered Lines
    151

    ### Uncovered Branches
    24

    ### Method
    Sprite

    ### Complexity / LOC
    40 / 250 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Sprite.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Ecs.Components.Render
{
    /// <summary>
    ///     The sprite
    /// </summary>
    public record struct Sprite(Context Context, string NameFile, int Depth) : ISprite
    {
        /// <summary>
        ///     Gets or sets the value of the shader program
        /// </summary>
        private static uint SharedShaderProgram;

        /// <summary>
        ///     The shared vao
        /// </summary>
        private static uint SharedVao;



    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Components/Render/SpriteTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Render/Sprite.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Sprite.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImColor.cs

    ### Language
    cs

    ### Coverage
    33.3% (Line: 33.3%, Branch: None%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    0

    ### Method
    ImColor

    ### Complexity / LOC
    4 / 10 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImColor.cs
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

//  File:ImColor.cs
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


using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im color
    /// </summary>
    public struct ImColor
    {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImColorTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImColor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImColor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/FFMpegWrapper.cs

    ### Language
    cs

    ### Coverage
    36.4% (Line: 39.3%, Branch: 22.2%)

    ### Uncovered Lines
    105

    ### Uncovered Branches
    28

    ### Method
    FFMpegWrapper

    ### Complexity / LOC
    38 / 195 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapper.cs
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Alis.Extension.Media.FFmpeg
{
    /// <summary>
    ///     FFmpeg wrapper
    /// </summary>
    public static class FfMpegWrapper
    {
        /// <summary>
        /// The hide banner arg
        /// </summary>
        private const string HideBannerArg = "-hide_banner";

        /// <summary>
        ///     The regex
        /// </summary>
        private static readonly Regex CodecRegex = new Regex(@"(?<type>[VAS\.])[F\.][S\.][X\.][B\.][D\.] (?<codec>[a-zA-Z0-9_-]+)\W+(?<description>.*)\n?", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     The regex
        /// </summary>
        private static readonly Regex FormatRegex = new Regex(@"(?<type>[DE]{1,2})\s+?(?<format>[a-zA-Z0-9_\-,]+)\W+(?<description>.*)\n?", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     FFmpeg verbosity. This sets the 'loglevel' parameter on FFmpeg. Useful when showing output and debugging issues.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/FFMpegWrapperTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/FFMpegWrapper.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FFMpegWrapper.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Audio/src/Players/WindowsPlayer.cs

    ### Language
    cs

    ### Coverage
    38.1% (Line: 38.6%, Branch: 36.1%)

    ### Uncovered Lines
    89

    ### Uncovered Branches
    23

    ### Method
    WindowsPlayer

    ### Complexity / LOC
    33 / 189 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WindowsPlayer.cs
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
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Time;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The windows player class
    /// </summary>
    /// <seealso cref="IPlayer" />
    internal class WindowsPlayer : IPlayer, IDisposable
    {
        /// <summary>
        ///     The file name
        /// </summary>
        internal string _fileName;

        /// <summary>
        ///     The playback timer
        /// </summary>
        private Timer _playbackTimer;

        /// <summary>
        ///     The play stopwatch
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Audio/test/Players/WindowsPlayerTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Audio/src/Players/WindowsPlayer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WindowsPlayer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoReader.cs

    ### Language
    cs

    ### Coverage
    38.4% (Line: 39.0%, Branch: 36.8%)

    ### Uncovered Lines
    61

    ### Uncovered Branches
    24

    ### Method
    VideoReader

    ### Complexity / LOC
    35 / 135 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoReader.cs
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Media.FFmpeg.BaseClasses;
using Alis.Extension.Media.FFmpeg.Video.Models;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     The video reader class
    /// </summary>
    /// <seealso cref="MediaReader{Frame,Writer}" />
    /// <seealso cref="IDisposable" />
    public class VideoReader : MediaReader<VideoFrame, MediaWriter<VideoFrame>>, IDisposable
    {
        /// <summary>
        ///     The compiled
        /// </summary>
        private static readonly Regex BitRateSimpleRgx = new Regex(@"\D(\d+?)[bl]e", RegexOptions.Compiled, TimeSpan.FromSeconds(10));

        /// <summary>
        ///     The ffprobe
        /// </summary>
        internal readonly string ffmpeg;

        /// <summary>
        ///     The ffprobe
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/VideoReaderTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoReader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoReader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs

    ### Language
    cs

    ### Coverage
    39.6% (Line: 41.6%, Branch: 32.3%)

    ### Uncovered Lines
    129

    ### Uncovered Branches
    42

    ### Method
    GraphicManager

    ### Complexity / LOC
    48 / 266 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GraphicManager.cs
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
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory;
using Alis.Core.Ecs.Components;
using Alis.Core.Ecs.Components.Collider;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Configuration.Physic;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Graphic.Platforms;
using Alis.Core.Graphic.Platforms.Osx;
using Color = Alis.Core.Aspect.Math.Definition.Color;

namespace Alis.Core.Ecs.Systems.Manager.Graphic
{
    /// <summary>
    ///     The graphic manager base class
    /// </summary>
    /// <seealso cref="AManager" />
    public class GraphicManager : AManager
    {
        /// <summary>
        ///     The pixels per meter
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Systems/Manager/Graphic/GraphicManagerTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Manager/Graphic/GraphicManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GraphicManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs

    ### Language
    cs

    ### Coverage
    43.8% (Line: 52.0%, Branch: 0.0%)

    ### Uncovered Lines
    36

    ### Uncovered Branches
    14

    ### Method
    Gen2GcCallback

    ### Complexity / LOC
    15 / 104 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Gen2GcCallback.cs
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
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Redifinition
{
    /// <summary>
    ///     Schedules a callback roughly every gen 2 GC (you may see a Gen 0 an Gen 1 but only once)
    ///     (We can fix this by capturing the Gen 2 count at startup and testing, but I mostly don't care)
    /// </summary>
    public sealed class Gen2GcCallback : CriticalFinalizerObject
    {
        /// <summary>
        ///     The gen collection occured
        /// </summary>
        public static Action Gen2CollectionOccured
        {
            get
            {
                lock (Gen2CollectionLock)
                {
                    return _gen2CollectionOccured;
                }
            }
            set
            {
                lock (Gen2CollectionLock)
                {
                    _gen2CollectionOccured = value;
                }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Redifinition/Gen2GcCallbackTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Redifinition/Gen2GcCallback.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Gen2GcCallback.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyInputManager.cs

    ### Language
    cs

    ### Coverage
    47.5% (Line: 43.0%, Branch: 52.8%)

    ### Uncovered Lines
    110

    ### Uncovered Branches
    77

    ### Method
    WebAssemblyInputManager

    ### Complexity / LOC
    149 / 250 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyInputManager.cs
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
using System.Linq;

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Advanced input manager for WebAssembly applications
    ///     Provides high-level input handling for keyboards, mice, gamepads, and touch
    /// </summary>
    
    public class WebAssemblyInputManager
    {
        /// <summary>
        /// The platform
        /// </summary>
        internal readonly WebAssemblyPlatform _platform;
        /// <summary>
        /// The key bindings
        /// </summary>
        internal readonly Dictionary<string, KeyBinding> _keyBindings;
        /// <summary>
        /// The previous gamepad states
        /// </summary>
        internal readonly Dictionary<int, GamepadInputState> _previousGamepadStates;
        /// <summary>
        /// The last mouse wheel delta
        /// </summary>
        internal float _lastMouseWheelDelta;
        /// <summary>
        ///     Initializes a new instance of the WebAssemblyInputManager
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyInputManagerTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyInputManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyInputManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Ui/Font.cs

    ### Language
    cs

    ### Coverage
    47.6% (Line: 46.5%, Branch: 60.0%)

    ### Uncovered Lines
    122

    ### Uncovered Branches
    8

    ### Method
    Font

    ### Complexity / LOC
    34 / 250 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Font.cs
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
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Definition;
using Alis.Core.Aspect.Math.Shapes.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;

namespace Alis.Core.Graphic.Ui
{
    /// <summary>
    ///     The font class
    /// </summary>
    public class Font(string NameFile, int Depth, int size)
    {
        /// <summary>
        ///     The size
        /// </summary>
        internal readonly int sizeFont = size;


        /// <summary>
        ///     The character rects
        /// </summary>
        private Dictionary<char, RectangleI> CharacterRects = new();

        /// <summary>
        ///     The vertices handle
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Ui/FontTests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Ui/Font.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Font.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP5.cs

    ### Language
    cs

    ### Coverage
    47.6% (Line: 47.6%, Branch: None%)

    ### Uncovered Lines
    66

    ### Uncovered Branches
    0

    ### Method
    ImPlotP5

    ### Complexity / LOC
    42 / 175 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
        /// <param name="pos">The pos</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotErrorBars(string labelId, ref sbyte xs, ref sbyte ys, ref sbyte neg, ref sbyte pos, int count, ImPlotErrorBarsFlags flags)
        {
            ImPlotNative.ImPlot_PlotErrorBars_S8PtrS8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys, neg, pos, count, flags, 0, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the error bars using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="neg">The neg</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP5Tests.cs

    Priority
    HIGH (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP5.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP5.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs

    ### Language
    cs

    ### Coverage
    52.5% (Line: 53.6%, Branch: 46.9%)

    ### Uncovered Lines
    77

    ### Uncovered Branches
    17

    ### Method
    GLShaderProgram

    ### Complexity / LOC
    32 / 197 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgram.cs
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
using System.Text;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Graphic.OpenGL.Enums;
using Type = System.Type;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShaderProgram : IDisposable
    {
        /// <summary>
        ///     Specifies whether this program will dispose of the child
        ///     vertex/fragment programs when the IDisposable method is called.
        /// </summary>
        public readonly bool DisposeChildren;

        /// <summary>
        ///     Specifies the fragment shader used in this program.
        /// </summary>
        public readonly GlShader FragmentShader;

        /// <summary>
        ///     Specifies the vertex shader used in this program.
        /// </summary>
        public readonly GlShader VertexShader;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/OpenGL/Constructs/GLShaderProgramTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgram.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GLShaderProgram.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawData.cs

    ### Language
    cs

    ### Coverage
    52.6% (Line: 52.6%, Branch: None%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    0

    ### Method
    ImDrawData

    ### Complexity / LOC
    22 / 30 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImDrawData.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw data
    /// </summary>
    public struct ImDrawData
    {
        /// <summary>
        ///     The valid
        /// </summary>
        public byte Valid { get; set; }

        /// <summary>
        ///     The cmd lists count
        /// </summary>
        public int CmdListsCount { get; set; }

        /// <summary>
        ///     The total idx count
        /// </summary>
        public int TotalIdxCount { get; set; }

        /// <summary>
        ///     The total vtx count
        /// </summary>
        public int TotalVtxCount { get; set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImDrawDataTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawData.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImDrawData.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiPayload.cs

    ### Language
    cs

    ### Coverage
    53.8% (Line: 53.8%, Branch: None%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    0

    ### Method
    ImGuiPayload

    ### Complexity / LOC
    20 / 27 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPayload.cs
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
using System.Runtime.InteropServices;
using System.Text;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im gui payload
    /// </summary>
    public struct ImGuiPayload
    {
        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data { get; set; }

        /// <summary>
        ///     The data size
        /// </summary>
        public int DataSize { get; set; }

        /// <summary>
        ///     The source id
        /// </summary>
        public uint SourceId { get; set; }

        /// <summary>
        ///     The source parent id
        /// </summary>
        public uint SourceParentId { get; set; }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiPayloadTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiPayload.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiPayload.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs

    ### Language
    cs

    ### Coverage
    54.2% (Line: 55.0%, Branch: 50.0%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    2

    ### Method
    Mouse

    ### Complexity / LOC
    7 / 57 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Mouse.cs
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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Windows
{
    /// <summary>
    ///     Give access to the real-time state of the mouse
    /// </summary>
    public static class Mouse
    {
        /// <summary>
        ///     Mouse buttons
        /// </summary>
        public enum Button
        {
            /// <summary>The left mouse button</summary>
            Left,

            /// <summary>The right mouse button</summary>
            Right,

            /// <summary>The middle (wheel) mouse button</summary>
            Middle,

            /// <summary>The first extra mouse button</summary>
            XButton1,

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Windows/MouseTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Windows/Mouse.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Mouse.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs

    ### Language
    cs

    ### Coverage
    54.6% (Line: 53.6%, Branch: 60.7%)

    ### Uncovered Lines
    83

    ### Uncovered Branches
    11

    ### Method
    WebAssemblyConfiguration

    ### Complexity / LOC
    75 / 216 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebAssemblyConfiguration.cs
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

namespace Alis.Core.Graphic.Platforms.Web
{
    /// <summary>
    ///     Configuration builder for WebAssembly platform
    ///     Provides a fluent interface to configure platform settings
    /// </summary>
    
    public class WebAssemblyConfigurationBuilder
    {
        /// <summary>
        /// The configuration
        /// </summary>
        internal readonly WebAssemblyConfiguration _configuration;

        /// <summary>
        ///     Initializes a new instance of the WebAssemblyConfigurationBuilder
        /// </summary>
        public WebAssemblyConfigurationBuilder() => _configuration = new WebAssemblyConfiguration();

        /// <summary>
        ///     Sets the window width and height
        /// </summary>
        public WebAssemblyConfigurationBuilder WithSize(int width, int height)
        {
            _configuration.WindowWidth = width;
            _configuration.WindowHeight = height;
            return this;
        }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/WebAssemblyConfigurationTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebAssemblyConfiguration.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaReader.cs

    ### Language
    cs

    ### Coverage
    55.2% (Line: 57.1%, Branch: 50.0%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    4

    ### Method
    MediaReader

    ### Complexity / LOC
    12 / 38 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MediaReader.cs
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
using System.Threading.Tasks;

namespace Alis.Extension.Media.FFmpeg.BaseClasses
{
    /// <summary>
    ///     The media reader class
    /// </summary>
    public abstract class MediaReader<TFrame, TWriter> where TFrame : IMediaFrame where TWriter : MediaWriter<TFrame>
    {
        /// <summary>
        ///     Input filename
        /// </summary>
        public virtual string Filename { get; protected set; }

        /// <summary>
        ///     Input raw data stream
        /// </summary>
        public virtual Stream DataStream { get; protected set; }

        /// <summary>
        ///     Is data stream opened for reading
        /// </summary>
        public virtual bool OpenedForReading { get; protected set; }

        /// <summary>
        ///     Nexts the frame
        /// </summary>
        /// <returns>The frame</returns>
        public abstract TFrame NextFrame();
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/BaseClasses/MediaReaderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/BaseClasses/MediaReader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MediaReader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShader.cs

    ### Language
    cs

    ### Coverage
    55.6% (Line: 59.4%, Branch: 25.0%)

    ### Uncovered Lines
    13

    ### Uncovered Branches
    3

    ### Method
    GLShader

    ### Complexity / LOC
    11 / 46 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GLShader.cs
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
using Alis.Core.Graphic.OpenGL.Enums;
using static Alis.Core.Graphic.OpenGL.Gl;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader class
    /// </summary>
    /// <seealso cref="IDisposable" />
    public sealed class GlShader : IDisposable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GlShader" /> class
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="type">The type</param>
        /// <exception cref="Exception"></exception>
        public GlShader(string source, ShaderType type)
        {
            ShaderType = type;
            ShaderId = GlCreateShader(type);

            ShaderSource(ShaderId, source);
            GlCompileShader(ShaderId);

            if (!GetShaderCompileStatus(ShaderId))
            {
                throw new InvalidOperationException(ShaderLog);
            }
        }
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/OpenGL/Constructs/GLShaderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GLShader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs

    ### Language
    cs

    ### Coverage
    56.1% (Line: 57.9%, Branch: 45.8%)

    ### Uncovered Lines
    117

    ### Uncovered Branches
    26

    ### Method
    BoxCollider

    ### Complexity / LOC
    72 / 314 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BoxCollider.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems.Scope;
using Alis.Core.Graphic.OpenGL;
using Alis.Core.Graphic.OpenGL.Enums;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Ecs.Components.Collider
{
    /// <summary>
    ///     The box collider class
    /// </summary>
    /// <seealso cref="IBoxCollider" />
    /// <seealso cref="IOnInit" />
    /// <seealso cref="IOnUpdate" />
    public class BoxCollider : IBoxCollider
    {
        /// <summary>
        ///     The vertices
        /// </summary>
        private static readonly float[] Vertices =
        {
            -0.5f, -0.5f,
            0.5f, -0.5f,
            0.0f, 0.5f
        };

    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Components/Collider/BoxColliderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Components/Collider/BoxCollider.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BoxCollider.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Monitor.cs

    ### Language
    cs

    ### Coverage
    60.0% (Line: 52.4%, Branch: 100.0%)

    ### Uncovered Lines
    10

    ### Uncovered Branches
    0

    ### Method
    Monitor

    ### Complexity / LOC
    11 / 46 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Monitor.cs
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
using System.Drawing;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Wrapper around a pointer to monitor.
    /// </summary>
    /// <seealso cref="Monitor" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Monitor : IEquatable<Monitor>
    {
        /// <summary>
        ///     Represents a <c>null</c> value for a <see cref="Monitor" /> object.
        /// </summary>
        public static readonly Monitor None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        internal readonly IntPtr handle;

        /// <summary>
        ///     Determines whether the specified <see cref="Monitor" />, is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="Monitor" /> to compare with this instance.</param>
        /// <returns>
        ///     <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Monitor other) => handle.Equals(other.handle);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/Structs/MonitorTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Monitor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Monitor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs

    ### Language
    cs

    ### Coverage
    62.4% (Line: 63.4%, Branch: 59.2%)

    ### Uncovered Lines
    241

    ### Uncovered Branches
    84

    ### Method
    DTSweep

    ### Complexity / LOC
    141 / 766 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DTSweep.cs
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
using Alis.Core.Aspect.Logging;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep class
    /// </summary>
    internal static class DtSweep
    {
        /// <summary>
        ///     The pi
        /// </summary>
        private const double PiDiv2 = Math.PI / 2;

        /// <summary>
        ///     The pi
        /// </summary>
        private const double Pi3Div4 = 3 * Math.PI / 4;

        /// <summary>
        ///     Triangulate simple polygon with holes
        /// </summary>
        public static void Triangulate(DtSweepContext tcx)
        {
            tcx.CreateAdvancingFront();

            Sweep(tcx);

            if (tcx.TriangulationMode == TriangulationMode.Polygon)
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/CDT/Delaunay/Sweep/DTSweepTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DTSweep.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotStyle.cs

    ### Language
    cs

    ### Coverage
    63.5% (Line: 63.5%, Branch: None%)

    ### Uncovered Lines
    19

    ### Uncovered Branches
    0

    ### Method
    ImPlotStyle

    ### Complexity / LOC
    104 / 59 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotStyle.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot style
    /// </summary>
    public struct ImPlotStyle
    {
        /// <summary>
        ///     The line weight
        /// </summary>
        public float LineWeight { get; set; }

        /// <summary>
        ///     The marker
        /// </summary>
        public int Marker { get; set; }

        /// <summary>
        ///     The marker size
        /// </summary>
        public float MarkerSize { get; set; }

        /// <summary>
        ///     The marker weight
        /// </summary>
        public float MarkerWeight { get; set; }

        /// <summary>
        ///     The fill alpha
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotStyleTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotStyle.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotStyle.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs

    ### Language
    cs

    ### Coverage
    65.9% (Line: 63.0%, Branch: 72.9%)

    ### Uncovered Lines
    44

    ### Uncovered Branches
    13

    ### Method
    AudioReader

    ### Complexity / LOC
    40 / 154 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AudioReader.cs
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
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Media.FFmpeg.Audio.Models;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Audio
{
    /// <summary>
    ///     The audio reader class
    /// </summary>
    /// <seealso cref="MediaReader{Frame,Writer}" />
    /// <seealso cref="IDisposable" />
    public class AudioReader : MediaReader<AudioFrame, AudioWriter>, IDisposable
    {
        /// <summary>
        ///     The ffprobe
        /// </summary>
        internal readonly string ffmpeg;

        /// <summary>
        ///     The ffprobe
        /// </summary>
        internal readonly string ffprobe;

        /// <summary>
        ///     The loaded bit depth
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Audio/AudioReaderTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Audio/AudioReader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AudioReader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP8.cs

    ### Language
    cs

    ### Coverage
    66.7% (Line: 66.7%, Branch: None%)

    ### Uncovered Lines
    53

    ### Uncovered Branches
    0

    ### Method
    ImPlotP8

    ### Complexity / LOC
    53 / 220 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
        /// <param name="ys2">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        /// <param name="offset">The offset</param>
        public static void PlotShaded(string labelId, ref sbyte xs, ref sbyte ys1, ref sbyte ys2, int count, ImPlotShadedFlags flags, int offset)
        {
            ImPlotNative.ImPlot_PlotShaded_S8PtrS8PtrS8Ptr(Encoding.UTF8.GetBytes(labelId), ref xs, ref ys1, ref ys2, count, flags, offset, sizeof(sbyte));
        }

        /// <summary>
        ///     Plots the shaded using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys1">The ys</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP8Tests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP8.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP8.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP4.cs

    ### Language
    cs

    ### Coverage
    66.7% (Line: 66.7%, Branch: None%)

    ### Uncovered Lines
    36

    ### Uncovered Branches
    0

    ### Method
    ImPlotP4

    ### Complexity / LOC
    36 / 151 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP4.cs
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

using System.Text;

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
        /// <param name="cols">The cols</param>
        /// <param name="scaleMin">The scale min</param>
        /// <param name="scaleMax">The scale max</param>
        /// <param name="labelFmt">The label fmt</param>
        /// <param name="boundsMin">The bounds min</param>
        public static void PlotHeatmap(string labelId, double[] values, int rows, int cols, double scaleMin, double scaleMax, string labelFmt, ImPlotPoint boundsMin)
        {
            ImPlotNative.ImPlot_PlotHeatmap_doublePtr(Encoding.UTF8.GetBytes(labelId), values, rows, cols, scaleMin, scaleMax, Encoding.UTF8.GetBytes(labelFmt), boundsMin, new ImPlotPoint(), ImPlotHeatmapFlags.None);
        }

        /// <summary>
        ///     Plots the heatmap using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="values">The values</param>
        /// <param name="rows">The rows</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP4Tests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP4.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP4.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Payment/Stripe/src/StripeGatewayClient.cs

    ### Language
    cs

    ### Coverage
    67.5% (Line: 61.9%, Branch: 85.4%)

    ### Uncovered Lines
    59

    ### Uncovered Branches
    7

    ### Method
    StripeGatewayClient

    ### Complexity / LOC
    33 / 197 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:StripeGatewayClient.cs
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
using System.Threading;
using System.Threading.Tasks;
using Stripe;
using Stripe.Checkout;

namespace Alis.Extension.Payment.Stripe
{
    /// <summary>
    ///     Real Stripe SDK adapter used by StoreManager.
    /// </summary>
    public class StripeGatewayClient : IStripeGatewayClient
    {
        /// <summary>
        ///     The configured api key
        /// </summary>
        internal string _configuredApiKey;

        /// <summary>
        ///     Configures the secret api key
        /// </summary>
        /// <param name="secretApiKey">The secret api key</param>
        /// <exception cref="ArgumentException">Stripe secret API key cannot be null or empty. </exception>
        public void Configure(string secretApiKey)
        {
            if (string.IsNullOrWhiteSpace(secretApiKey))
            {
                throw new ArgumentException("Stripe secret API key cannot be null or empty.", nameof(secretApiKey));
            }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Payment/Stripe/test/StripeGatewayClientTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Payment/Stripe/src/StripeGatewayClient.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage StripeGatewayClient.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs

    ### Language
    cs

    ### Coverage
    69.2% (Line: 71.3%, Branch: 60.0%)

    ### Uncovered Lines
    25

    ### Uncovered Branches
    8

    ### Method
    GLShaderProgramParam

    ### Complexity / LOC
    27 / 113 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GLShaderProgramParam.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Graphic.OpenGL.Constructs
{
    /// <summary>
    ///     The gl shader program param class
    /// </summary>
    public sealed class GlShaderProgramParam
    {
        /// <summary>
        ///     Specifies the case-sensitive name of the parameter.
        /// </summary>
        public readonly string Name;

        /// <summary>
        ///     Specifies the parameter type (either attribute or uniform).
        /// </summary>
        public readonly ParamType ParamType;

        /// <summary>
        ///     Specifies the C# equivalent of the GLSL data type.
        /// </summary>
        public readonly Type Type;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GlShaderProgramParam" /> class
        /// </summary>
        /// <param name="type">The type</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/OpenGL/Constructs/GLShaderProgramParamTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GLShaderProgramParam.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs

    ### Language
    cs

    ### Coverage
    70.3% (Line: 71.4%, Branch: 57.1%)

    ### Uncovered Lines
    48

    ### Uncovered Branches
    6

    ### Method
    ContextHandler

    ### Complexity / LOC
    17 / 196 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ContextHandler.cs
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
using System.Threading;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Execution;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Manager.Time;

namespace Alis.Core.Ecs.Systems.Scope
{
    /// <summary>
    ///     The context handler class
    /// </summary>
    /// <seealso cref="IContextHandler{Context}" />
    public class ContextHandler : IContextHandler<Context>
    {
        /// <summary>
        ///     The context
        /// </summary>
        internal readonly Context _context;

        /// <summary>
        ///     The accumulator
        /// </summary>
        internal float accumulator;

        /// <summary>
        ///     The current time
        /// </summary>
        private double currentTime;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Core/Ecs/Systems/Scope/ContextHandlerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Core/Ecs/Systems/Scope/ContextHandler.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ContextHandler.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Ui/FontManager.cs

    ### Language
    cs

    ### Coverage
    71.4% (Line: 71.4%, Branch: None%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    0

    ### Method
    FontManager

    ### Complexity / LOC
    3 / 16 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FontManager.cs
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

using Alis.Core.Aspect.Math.Definition;

namespace Alis.Core.Graphic.Ui
{
    /// <summary>
    ///     The font manager class
    /// </summary>
    public static class FontManager
    {
        /// <summary>
        ///     Gets the value of the default font
        /// </summary>
        public static Font DefaultFont { get; } = new Font("mono.bmp", 1, 1);

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <param name="x">The x position to render the text</param>
        /// <param name="y">The y position to render the text</param>
        /// <param name="foreColor">The foreground color of the text</param>
        /// <param name="backColor">The background color of the text</param>
        public static void RenderText(string text, int x, int y, Color foreColor, Color backColor)
        {
            DefaultFont.RenderText(text, x, y, foreColor, backColor);
        }

        /// <summary>
        ///     Renders the text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Ui/FontManagerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Graphic/src/Ui/FontManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FontManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/ContactManager.cs

    ### Language
    cs

    ### Coverage
    73.0% (Line: 73.7%, Branch: 71.4%)

    ### Uncovered Lines
    90

    ### Uncovered Branches
    40

    ### Method
    ContactManager

    ### Complexity / LOC
    94 / 412 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ContactManager.cs
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
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The contact manager class
    /// </summary>
    public class ContactManager
    {
        /// <summary>
        ///     The broad phase
        /// </summary>
        public readonly IBroadPhase BroadPhase;

        /// <summary>
        ///     A threshold for activating multiple cores to solve Collide.
        ///     An World with a contact count above this threshold will use multiple threads to solve Collide.
        ///     A value of 0 will always use multithreading. A value of (int.MaxValue) will never use multithreading.
        ///     Typical values are {128 or 256}.
        /// </summary>
        public readonly int CollideMultithreadThreshold = int.MaxValue;

        /// <summary>
        ///     The contact list
        /// </summary>
        public readonly ContactListHead ContactList;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/ContactManagerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/ContactManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ContactManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Cloud/DropBox/src/DropBoxCloudManager.cs

    ### Language
    cs

    ### Coverage
    73.2% (Line: 71.8%, Branch: 78.6%)

    ### Uncovered Lines
    46

    ### Uncovered Branches
    9

    ### Method
    DropBoxCloudManager

    ### Complexity / LOC
    32 / 216 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DropBoxCloudManager.cs
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
using System.IO;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Dropbox.Api;
using Dropbox.Api.Files;
using Dropbox.Api.Stone;
using Dropbox.Api.Users;

namespace Alis.Extension.Cloud.DropBox
{
    /// <summary>
    ///     The cloud manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="ICloudManager" />
    public class DropBoxCloudManager : AManager, ICloudManager, IDisposable
    {
    /// <summary>
    ///     Error message for not initialized state
    /// </summary>
    private const string NotInitializedError = "DropBox manager is not initialized. Call InitializeAsync first.";

    /// <summary>
    ///     The path delimiter used for Dropbox paths (always forward slash)
    /// </summary>
    private const string PathDelimiter = "/";

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Cloud/DropBox/test/DropBoxCloudManagerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Cloud/DropBox/src/DropBoxCloudManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DropBoxCloudManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Audio/src/Players/BrowserPlayer.cs

    ### Language
    cs

    ### Coverage
    76.9% (Line: 74.0%, Branch: 85.3%)

    ### Uncovered Lines
    51

    ### Uncovered Branches
    10

    ### Method
    BrowserPlayer

    ### Complexity / LOC
    47 / 248 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BrowserPlayer.cs
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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The browser player class
    /// </summary>
    /// <seealso cref="IPlayer" />
    internal class BrowserPlayer : IPlayer
    {
        /// <summary>
        ///     The buffer
        /// </summary>
        internal readonly uint _buffer;

        /// <summary>
        ///     The source
        /// </summary>
        internal readonly uint _source;

        /// <summary>
        ///     The paused
        /// </summary>
        private bool _paused;

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Audio/test/Players/BrowserPlayerTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Audio/src/Players/BrowserPlayer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BrowserPlayer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoFrame.cs

    ### Language
    cs

    ### Coverage
    78.3% (Line: 76.1%, Branch: 87.5%)

    ### Uncovered Lines
    16

    ### Uncovered Branches
    2

    ### Method
    VideoFrame

    ### Complexity / LOC
    18 / 88 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoFrame.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Extension.Media.FFmpeg.BaseClasses;

namespace Alis.Extension.Media.FFmpeg.Video
{
    /// <summary>
    ///     Video frame containing pixel data in RGB24 format.
    /// </summary>
    public class VideoFrame : IDisposable, IMediaFrame
    {
        /// <summary>
        ///     The offset
        /// </summary>
        internal readonly int size;

        /// <summary>
        ///     The frame buffer
        /// </summary>
        private byte[] frameBuffer;

        /// <summary>
        ///     Creates an empty video frame with given dimensions using the RGB24 pixel format.
        /// </summary>
        /// <param name="w">Width in pixels</param>
        /// <param name="h">Height in pixels</param>
        public VideoFrame(int w, int h)
        {
            if (w <= 0 || h <= 0)
            {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/test/Video/VideoFrameTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Media/FFmpeg/src/Video/VideoFrame.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoFrame.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs

    ### Language
    cs

    ### Coverage
    79.9% (Line: 81.5%, Branch: 75.6%)

    ### Uncovered Lines
    92

    ### Uncovered Branches
    44

    ### Method
    MarchingSquares

    ### Complexity / LOC
    137 / 603 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:MarchingSquares.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;

namespace Alis.Core.Physic.Common.TextureTools
{
    /// <summary>
    ///     The marching squares class
    /// </summary>
    public static class MarchingSquares
    {
        //- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - 


        /// <summary>
        ///     The look march
        /// </summary>
        internal static readonly int[] LookMarch =
        {
            0x00, 0xE0, 0x38, 0xD8, 0x0E, 0xEE, 0x36, 0xD6, 0x83, 0x63, 0xBB, 0x5B, 0x8D,
            0x6D, 0xB5, 0x55
        };

        /// <summary>
        ///     Marching squares over the given domain using the mesh defined via the dimensions
        ///     (wid,hei) to build a set of polygons such that f(x,y) less than 0, using the given number
        ///     'bin' for recursive linear inteprolation along cell boundaries.
        ///     if 'comb' is true, then the polygons will also be composited into larger possible concave
        ///     polygons.
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/TextureTools/MarchingSquaresTests.cs

    Priority
    MEDIUM (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/TextureTools/MarchingSquares.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage MarchingSquares.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Core/WebSocketNetworkTransport.cs

    ### Language
    cs

    ### Coverage
    80.1% (Line: 83.4%, Branch: 69.2%)

    ### Uncovered Lines
    28

    ### Uncovered Branches
    16

    ### Method
    WebSocketNetworkTransport

    ### Complexity / LOC
    37 / 220 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebSocketNetworkTransport.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Core
{
    /// <summary>
    ///     WebSocket-based network transport implementation
    /// </summary>
    public sealed class WebSocketNetworkTransport : INetworkTransport
    {
        /// <summary>
        ///     The client sockets
        /// </summary>
        internal readonly ConcurrentDictionary<string, WebSocket> _clientSockets;

        /// <summary>
        ///     The host
        /// </summary>
        internal readonly string _host;

        /// <summary>
        ///     The lock object
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Core/WebSocketNetworkTransportTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Core/WebSocketNetworkTransport.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebSocketNetworkTransport.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs

    ### Language
    cs

    ### Coverage
    80.7% (Line: 79.7%, Branch: 85.7%)

    ### Uncovered Lines
    45

    ### Uncovered Branches
    6

    ### Method
    ImPlotP9

    ### Complexity / LOC
    60 / 269 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9.cs
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

namespace Alis.Extension.Graphic.Ui.Extras.Plot
{
    /// <summary>
    ///     The im plot class
    /// </summary>
    public static partial class ImPlot
    {
        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count)
        {
            ImPlotNative.ImPlot_PlotLine_S32PtrS32Ptr(Encoding.UTF8.GetBytes(labelId), xs, ys, count, 0, 0, sizeof(int));
        }

        /// <summary>
        ///     Plots the line using the specified label id
        /// </summary>
        /// <param name="labelId">The label id</param>
        /// <param name="xs">The xs</param>
        /// <param name="ys">The ys</param>
        /// <param name="count">The count</param>
        /// <param name="flags">The flags</param>
        public static void PlotLine(string labelId, ref int xs, ref int ys, int count, ImPlotLineFlags flags)
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Plot/ImPlotP9Tests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Plot/ImPlotP9.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImPlotP9.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Client/NetworkClientManager.cs

    ### Language
    cs

    ### Coverage
    83.7% (Line: 82.2%, Branch: 88.2%)

    ### Uncovered Lines
    38

    ### Uncovered Branches
    8

    ### Method
    NetworkClientManager

    ### Complexity / LOC
    54 / 271 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:NetworkClientManager.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Client
{
    /// <summary>
    ///     Client-side network manager implementation
    /// </summary>
    public sealed class NetworkClientManager : INetworkClientManager
    {
        /// <summary>
        ///     The id
        /// </summary>
        internal readonly string _id;

        /// <summary>
        ///     The lock object
        /// </summary>
        internal readonly object _lockObject = new object();

        /// <summary>
        ///     The message handlers
        /// </summary>
        internal readonly ConcurrentDictionary<string, Func<string, string, Task>> _messageHandlers;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Client/NetworkClientManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Client/NetworkClientManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage NetworkClientManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs

    ### Language
    cs

    ### Coverage
    85.1% (Line: 87.6%, Branch: 72.7%)

    ### Uncovered Lines
    78

    ### Uncovered Branches
    35

    ### Method
    ContactSolver

    ### Complexity / LOC
    93 / 719 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ContactSolver.cs
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
using System.Buffers;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The contact solver class
    /// </summary>
    public class ContactSolver : IDisposable
    {
        /// <summary>
        ///     Bundles contact constraint data for impulse application.
        /// </summary>
        internal readonly struct ContactConstraintData
        {
            /// <summary>
            /// The cp
            /// </summary>
            public readonly VelocityConstraintPoint Cp1;
            /// <summary>
            /// The cp
            /// </summary>
            public readonly VelocityConstraintPoint Cp2;
            /// <summary>
            /// The normal
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Contacts/ContactSolverTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/ContactSolver.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ContactSolver.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Updater/src/UpdateManager.cs

    ### Language
    cs

    ### Coverage
    86.3% (Line: 89.6%, Branch: 71.2%)

    ### Uncovered Lines
    49

    ### Uncovered Branches
    30

    ### Method
    UpdateManager

    ### Complexity / LOC
    102 / 578 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:UpdateManager.cs
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
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Extension.Updater.Events;
using Alis.Extension.Updater.Services.Api;
using Alis.Extension.Updater.Services.Files;

namespace Alis.Extension.Updater
{
    /// <summary>
    ///     The update manager class
    /// </summary>
    public sealed class UpdateManager
    {
        /// <summary>
        ///     The threshold entries
        /// </summary>
        private const int ThresholdEntries = 10000;

        /// <summary>
        ///     The threshold size
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Updater/test/UpdateManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Updater/src/UpdateManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage UpdateManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiStyle.cs

    ### Language
    cs

    ### Coverage
    86.9% (Line: 80.8%, Branch: 98.3%)

    ### Uncovered Lines
    43

    ### Uncovered Branches
    2

    ### Method
    ImGuiStyle

    ### Complexity / LOC
    308 / 243 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImGuiStyle.cs
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

using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The imgui style
    /// </summary>
    public struct ImGuiStyle
    {
        /// <summary>
        /// The index out of range message
        /// </summary>
        private const string IndexOutOfRangeMessage = "Index out of range. Valid range is [0, 54].";

        /// <summary>
        ///     The alpha
        /// </summary>
        public float Alpha { get; set; }

        /// <summary>
        ///     The disabled alpha
        /// </summary>
        public float DisabledAlpha { get; set; }

        /// <summary>
        ///     The window padding
        /// </summary>
        public Vector2F WindowPadding { get; set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImGuiStyleTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiStyle.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImGuiStyle.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/TimeOfImpact.cs

    ### Language
    cs

    ### Coverage
    86.9% (Line: 87.8%, Branch: 82.1%)

    ### Uncovered Lines
    18

    ### Uncovered Branches
    5

    ### Method
    TimeOfImpact

    ### Complexity / LOC
    30 / 183 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:TimeOfImpact.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Computes the Time of Impact (TOI) between two moving convex shapes using continuous collision detection (CCD).
    /// </summary>
    /// <remarks>
    ///     This class implements the local separating axis method for CCD. It seeks progression
    ///     by computing the largest time at which separation is maintained between two shapes.
    ///     
    ///     The algorithm uses a swept separating axis and may miss some intermediate, non-tunneling collisions.
    ///     For contact point and normal information at the time of impact, use <see cref="Distance"/> after calling this method.
    ///     
    ///     Diagnostics can be enabled via <see cref="SettingEnv.EnableDiagnostics"/> to track TOI computation statistics.
    /// </remarks>
    public static class TimeOfImpact
    {
        // by computing the largest time at which separation is maintained.

        /// <summary>
        ///     Gets or sets the total number of TOI computation calls made (diagnostics only).
        /// </summary>
        /// <remarks>
        ///     Only updated when <see cref="SettingEnv.EnableDiagnostics"/> is true.
        /// </remarks>
        [ThreadStatic] public static int ToiCalls;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/TimeOfImpactTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/TimeOfImpact.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage TimeOfImpact.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Audio/src/Players/UnixPlayerBase.cs

    ### Language
    cs

    ### Coverage
    88.3% (Line: 91.3%, Branch: 78.3%)

    ### Uncovered Lines
    13

    ### Uncovered Branches
    10

    ### Method
    UnixPlayerBase

    ### Complexity / LOC
    36 / 188 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:UnixPlayerBase.cs
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
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Memory;
using Alis.Core.Audio.Interfaces;

namespace Alis.Core.Audio.Players
{
    /// <summary>
    ///     The unix player base class
    /// </summary>
    /// <seealso cref="IPlayer" />
    public abstract class UnixPlayerBase : IPlayer
    {
        /// <summary>
        ///     The pause process command
        /// </summary>
        internal const string PauseProcessCommand = "kill -STOP {0}";

        /// <summary>
        ///     The resume process command
        /// </summary>
        internal const string ResumeProcessCommand = "kill -CONT {0}";

        /// <summary>
        ///     The last extracted file
        /// </summary>
        internal string _lastExtractedFile;

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Audio/test/Players/UnixPlayerBaseTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Audio/src/Players/UnixPlayerBase.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage UnixPlayerBase.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs

    ### Language
    cs

    ### Coverage
    88.7% (Line: 88.5%, Branch: 90.0%)

    ### Uncovered Lines
    13

    ### Uncovered Branches
    2

    ### Method
    WebSocketFrameReader

    ### Complexity / LOC
    19 / 149 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebSocketFrameReader.cs
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
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     Reads a WebSocket frame
    ///     see http://tools.ietf.org/html/rfc6455 for specification
    /// </summary>
    internal static class WebSocketFrameReader
    {
        /// <summary>
        ///     Calculates the num bytes to read using the specified num bytes letf to read
        /// </summary>
        /// <param name="numBytesLetfToRead">The num bytes letf to read</param>
        /// <param name="bufferSize">The buffer size</param>
        /// <returns>The num bytes letf to read</returns>
        internal static int CalculateNumBytesToRead(int numBytesLetfToRead, int bufferSize)
        {
            if (bufferSize < numBytesLetfToRead)
            {
                return bufferSize - bufferSize % 4;
            }

            return numBytesLetfToRead;
        }

    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Internal/WebSocketFrameReaderTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebSocketFrameReader.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/Events.cs

    ### Language
    cs

    ### Coverage
    89.1% (Line: 83.7%, Branch: 100.0%)

    ### Uncovered Lines
    39

    ### Uncovered Branches
    0

    ### Method
    Events

    ### Complexity / LOC
    98 / 333 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Events.cs
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
using System.Diagnostics.Tracing;
using System.Net.Security;
using System.Net.WebSockets;

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     Use the Guid to locate this EventSource in PerfView using the Additional Providers box (without wildcard
    ///     characters)
    /// </summary>
    [EventSource(Name = "Ninja-WebSockets")]
    internal sealed class Events : EventSource
    {
        /// <summary>
        ///     The events
        /// </summary>
        public static readonly Events Log = new Events();

        /// <summary>
        ///     Clients the connecting to ip address using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="ipAddress">The ip address</param>
        /// <param name="port">The port</param>
        [Event(1, Level = EventLevel.Informational)]
        public void ClientConnectingToIpAddress(Guid guid, string ipAddress, int port)
        {
            if (IsEnabled())
            {
                WriteEvent(1, guid, ipAddress, port);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Internal/EventsTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/Events.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Events.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/Contact.cs

    ### Language
    cs

    ### Coverage
    89.5% (Line: 91.1%, Branch: 83.3%)

    ### Uncovered Lines
    26

    ### Uncovered Branches
    13

    ### Method
    Contact

    ### Complexity / LOC
    88 / 347 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Contact.cs
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

namespace Alis.Core.Physic.Dynamics.Contacts
{
    /// <summary>
    ///     The class manages contact between two shapes. A contact exists for each overlapping
    ///     AABB in the broad-phase (except if filtered). Therefore a contact object may exist
    ///     that has no contact points.
    /// </summary>
    public class Contact
    {
        /// <summary>
        ///     Test hook: when set to true, Create returns null.
        /// </summary>
        private static bool ReturnNullOverride = false;

        /// <summary>
        ///     The edge shape
        /// </summary>
        private static readonly EdgeShape Edge = new EdgeShape();

        /// <summary>
        ///     The not supported
        /// </summary>
        private static readonly ContactType[,] Registers =
        {
            {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Contacts/ContactTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/Contact.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Contact.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs

    ### Language
    cs

    ### Coverage
    90.0% (Line: 87.5%, Branch: 100.0%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    0

    ### Method
    Window

    ### Complexity / LOC
    10 / 32 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Window.cs
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
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Glfw.Structs
{
    /// <summary>
    ///     Wrapper around a GLFW window pointer.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Window : IEquatable<Window>
    {
        /// <summary>
        ///     Describes a default/null instance.
        /// </summary>
        public static readonly Window None;

        /// <summary>
        ///     Internal pointer.
        /// </summary>
        internal readonly IntPtr handle;

        /// <summary>
        ///     Performs an implicit conversion from <see cref="Window" /> to <see cref="IntPtr" />.
        /// </summary>
        /// <param name="window">The window.</param>
        /// <returns>
        ///     The result of the conversion.
        /// </returns>
        public static implicit operator IntPtr(Window window) => window.handle;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/test/Structs/WindowTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Glfw/src/Structs/Window.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Window.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/WorldPhysic.cs

    ### Language
    cs

    ### Coverage
    90.1% (Line: 91.7%, Branch: 85.2%)

    ### Uncovered Lines
    78

    ### Uncovered Branches
    44

    ### Method
    WorldPhysic

    ### Complexity / LOC
    244 / 1106 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WorldPhysic.cs
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
using System.Buffers;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Controllers;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     The world class manages all physics entities, dynamic simulation,
    ///     and asynchronous queries.
    /// </summary>
    public class WorldPhysic
    {
        /// <summary>This is only for debugging the solver</summary>
        private const bool WarmStarting = true;

        /// <summary>
        ///     The world locked message
        /// </summary>
        private const string WorldLockedMessage = "The World is locked.";

        /// <summary>
        ///     The query callback cache
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/WorldPhysicTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/WorldPhysic.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WorldPhysic.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs

    ### Language
    cs

    ### Coverage
    90.2% (Line: 91.3%, Branch: 84.2%)

    ### Uncovered Lines
    56

    ### Uncovered Branches
    18

    ### Method
    Archetype

    ### Complexity / LOC
    104 / 786 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Archetype.cs
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
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;
using HashCode = Alis.Core.Aspect.Math.HashCode;

// S3963: Static constructor required for ECS null archetype initialization
[assembly: SuppressMessage("SonarAnalyzer.CSharp", "S3963", Justification = "Static constructor required for ECS null archetype lazy initialization")]

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    public class Archetype(GameObjectType archetypeId, ComponentStorageBase[] components, bool isTempCreateArchetype)
    {
        /// <summary>
        ///     The null
        /// </summary>
        internal static readonly GameObjectType Null;

        /// <summary>
        ///     The create
        /// </summary>
        // S2223: Required for ECS archetype table access from GameObjectType
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Kernel/Archetypes/ArchetypeTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Archetype.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:6_Ideation/Memory/src/AssetRegistry.cs

    ### Language
    cs

    ### Coverage
    90.2% (Line: 92.1%, Branch: 85.3%)

    ### Uncovered Lines
    21

    ### Uncovered Branches
    15

    ### Method
    AssetRegistry

    ### Complexity / LOC
    66 / 334 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:AssetRegistry.cs
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
using System.Buffers;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    ///     Provides static methods for registering assembly-level embedded asset packages
    ///     (.pack / .zip) and resolving embedded resource paths or in-memory streams by
    ///     resource name. Maintains thread-safe caches for zip indexes and extracted file
    ///     paths to minimize redundant I/O across assemblies.
    /// </summary>
    public static class AssetRegistry
    {
        /// <summary>
        ///     Stores the registered asset loader delegates keyed by assembly name.
        ///     Each delegate, when invoked, returns a <see cref="Stream" /> providing
        ///     access to the assembly's embedded assets.pack content.
        /// </summary>
        private static readonly Dictionary<string, Func<Stream>> RegisteredAssetLoaders = new();

        /// <summary>
        ///     Per-assembly lock objects used to synchronize zip cache operations
        ///     independently, reducing contention compared to a single global lock.
        /// </summary>
        private static readonly ConcurrentDictionary<string, object> _assemblyLocks = new();
    ```
    
    ### Test File Hint
    pabllopf-official_alis:6_Ideation/Memory/test/AssetRegistryTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:6_Ideation/Memory/src/AssetRegistry.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage AssetRegistry.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:6_Ideation/Logging/src/Logger.cs

    ### Language
    cs

    ### Coverage
    90.6% (Line: 100.0%, Branch: 62.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    6

    ### Method
    Logger

    ### Complexity / LOC
    17 / 70 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Logger.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;
using Alis.Core.Aspect.Logging.Outputs;

namespace Alis.Core.Aspect.Logging
{
    /// <summary>
    ///     Static utility methods for backward compatibility with the legacy logging API.
    ///     NOTE: For new code, use LoggerFactory and ILogger directly for better performance
    ///     and flexibility. This class is provided for backward compatibility only.
    ///     Uses a default global logger instance.
    /// </summary>
    public static class Logger
    {
        /// <summary>
        ///     The default logger
        /// </summary>
        private static ILogger _defaultLogger;

        /// <summary>
        ///     The lock
        /// </summary>
        private static readonly object _lock = new object();

        /// <summary>
        ///     Ensures the default logger is initialized.
        /// </summary>
        private static void EnsureInitialized()
        {
            if (_defaultLogger != null)
    ```
    
    ### Test File Hint
    pabllopf-official_alis:6_Ideation/Logging/test/LoggerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:6_Ideation/Logging/src/Logger.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Logger.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/YuPengClipper.cs

    ### Language
    cs

    ### Coverage
    91.1% (Line: 91.1%, Branch: 91.1%)

    ### Uncovered Lines
    27

    ### Uncovered Branches
    10

    ### Method
    YuPengClipper

    ### Complexity / LOC
    87 / 363 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:YuPengClipper.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    //Clipper contributed by Helge Backhaus

    /// <summary>
    ///     The yu peng clipper class
    /// </summary>
    public static class YuPengClipper
    {
        /// <summary>
        ///     The clipper epsilon squared
        /// </summary>
        private const float ClipperEpsilonSquared = 1.192092896e-07f;

        /// <summary>
        ///     Unions the polygon 1
        /// </summary>
        /// <param name="polygon1">The polygon</param>
        /// <param name="polygon2">The polygon</param>
        /// <param name="error">The error</param>
        /// <returns>A list of vertices</returns>
        public static List<Vertices> Union(Vertices polygon1, Vertices polygon2, out PolyClipError error) => Execute(polygon1, polygon2, PolyClipType.Union, out error);

        /// <summary>
        ///     Differences the polygon 1
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/PolygonManipulation/YuPengClipperTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/YuPengClipper.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage YuPengClipper.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Scene.cs

    ### Language
    cs

    ### Coverage
    91.7% (Line: 93.9%, Branch: 82.8%)

    ### Uncovered Lines
    63

    ### Uncovered Branches
    44

    ### Method
    Scene

    ### Complexity / LOC
    187 / 1187 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Scene.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The central container for all entities and systems in the ECS (Entity Component System) architecture.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     A Scene represents an isolated world or game level that manages its own collection of entities,
    ///     each consisting of typed components. It provides the primary interface for creating, querying,
    /// and updating entities and their components.
    /// </para>
    ///     <para>
    ///     Key features:
    ///     <list type="bullet">
    ///         <item><description>Entity creation with arbitrary component combinations</description></item>
    ///         <item><description>Component add/remove operations with event notifications</description></item>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/SceneTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Scene.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Scene.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs

    ### Language
    cs

    ### Coverage
    92.2% (Line: 91.3%, Branch: 93.5%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    3

    ### Method
    DungeonData

    ### Complexity / LOC
    37 / 108 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DungeonData.cs
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
using Alis.Core.Aspect.Data.Json;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the complete data structure for a generated dungeon.
    ///     Contains all the information about the dungeon including board, rooms, and corridors.
    /// </summary>
    [Serializable]
    public partial class DungeonData : IJsonSerializable, IJsonDesSerializable<DungeonData>
    {
        /// <summary>
        ///     The backing field for <see cref="Board" />.
        /// </summary>
        private BoardSquare[,] _board;

        /// <summary>
        ///     The backing field for <see cref="Rooms" />.
        /// </summary>
        private List<RoomData> _rooms;

        /// <summary>
        ///     The backing field for <see cref="Corridors" />.
        /// </summary>
        private List<CorridorData> _corridors;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DungeonData" /> class.
        ///     Default constructor for serialization support.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/test/Models/DungeonDataTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Models/DungeonData.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DungeonData.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Collections/EnumerableHelpers.cs

    ### Language
    cs

    ### Coverage
    92.2% (Line: 94.9%, Branch: 83.3%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    3

    ### Method
    EnumerableHelpers

    ### Complexity / LOC
    15 / 79 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpers.cs
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

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     Internal helper functions for working with enumerables.
    /// </summary>
    public static class EnumerableHelpers
    {
        /// <summary>Calls Reset on an enumerator instance.</summary>
        /// <remarks>Enables Reset to be called without boxing on a struct enumerator that lacks a public Reset.</remarks>
        internal static void Reset<T>(ref T enumerator) where T : IEnumerator
        {
            enumerator.Reset();
        }

        /// <summary>Gets an enumerator singleton for an empty collection.</summary>
        public static IEnumerator<T> GetEmptyEnumerator<T>() => ((IEnumerable<T>) Array.Empty<T>()).GetEnumerator();

        /// <summary>Converts an enumerable to an array using the same logic as List{T}.</summary>
        /// <param name="source">The enumerable to convert.</param>
        /// <param name="length">The number of items stored in the resulting array, 0-indexed.</param>
        /// <returns>
        ///     The resulting array.  The length of the array may be greater than <paramref name="length" />,
        ///     which is the actual number of elements in the array.
        /// </returns>
        public static T[] ToArray<T>(IEnumerable<T> source, out int length)
        {
            const int arrayMaxLength = 0X7FFFFFC7;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Collections/EnumerableHelpersTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Collections/EnumerableHelpers.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage EnumerableHelpers.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/ComponentRegistry.cs

    ### Language
    cs

    ### Coverage
    92.8% (Line: 94.1%, Branch: 89.6%)

    ### Uncovered Lines
    7

    ### Uncovered Branches
    5

    ### Method
    ComponentRegistry

    ### Complexity / LOC
    32 / 158 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ComponentRegistry.cs
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
using System.Linq;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Class for registering components
    /// </summary>
    public static class Component
    {
        /// <summary>
        ///     The create
        /// </summary>
        internal static FastestStack<ComponentData> ComponentTable = FastestStack<ComponentData>.Create(16);

        /// <summary>
        ///     The none component runner table
        /// </summary>
        internal static Dictionary<Type, IComponentStorageBaseFactory> NoneComponentRunnerTable = [];

        /// <summary>
        ///     The existing component ds
        /// </summary>
        private static readonly Dictionary<Type, ComponentId> _existingComponentIDs = [];

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Kernel/ComponentRegistryTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Kernel/ComponentRegistry.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ComponentRegistry.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/BufferPool.cs

    ### Language
    cs

    ### Coverage
    93.3% (Line: 91.9%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    BufferPool

    ### Complexity / LOC
    10 / 57 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BufferPool.cs
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
using System.Collections.Concurrent;
using System.IO;

namespace Alis.Extension.Network
{
    /// <summary>
    ///     This buffer pool is instance thread safe
    ///     Use GetBuffer to get a MemoryStream (with a publically accessible buffer)
    ///     Calling Close on this MemoryStream will clear its internal buffer and return the buffer to the pool for reuse
    ///     MemoryStreams can grow larger than the DEFAULT_BUFFER_SIZE (or whatever you passed in)
    ///     and the underlying buffers will be returned to the pool at their larger sizes
    /// </summary>
    public class BufferPool : IBufferPool, IDisposable
    {
        /// <summary>
        ///     The default buffer size
        /// </summary>
        private const int DefaultBufferSize = 16384;

        /// <summary>
        ///     The buffer pool stack
        /// </summary>
        internal readonly ConcurrentStack<byte[]> _bufferPoolStack;

        /// <summary>
        ///     The buffer size
        /// </summary>
        internal readonly int _bufferSize;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/BufferPoolTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/BufferPool.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BufferPool.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/Update.cs

    ### Language
    cs

    ### Coverage
    93.6% (Line: 95.3%, Branch: 78.6%)

    ### Uncovered Lines
    12

    ### Uncovered Branches
    6

    ### Method
    Update

    ### Complexity / LOC
    35 / 394 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Update.cs
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

using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating.Runners
{
    /// <summary>
    ///     The update loop class
    /// </summary>
    internal static class UpdateLoop
    {
        /// <summary>
        ///     Runs the entity ids
        /// </summary>
        /// <typeparam name="TComp">The comp</typeparam>
        /// <param name="entityIds">The entity ids</param>
        /// <param name="comp">The comp</param>
        /// <param name="length">The length</param>
        /// <param name="gameObject">The game object</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void Run<TComp>(ref GameObjectIdOnly entityIds, ref TComp comp, int length, GameObject gameObject)
            where TComp : IOnUpdate
        {
            if (length <= 0)
            {
                return;
            }

            do
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Updating/Runners/UpdateTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/Update.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Update.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Body.cs

    ### Language
    cs

    ### Coverage
    93.7% (Line: 94.4%, Branch: 91.3%)

    ### Uncovered Lines
    32

    ### Uncovered Branches
    16

    ### Method
    Body

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
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Body.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Body.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawCmd.cs

    ### Language
    cs

    ### Coverage
    93.8% (Line: 93.8%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ImDrawCmd

    ### Complexity / LOC
    23 / 24 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImDrawCmd.cs
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

namespace Alis.Extension.Graphic.Ui
{
    /// <summary>
    ///     The im draw cmd
    /// </summary>
    public struct ImDrawCmd
    {
        /// <summary>
        ///     The clip rect
        /// </summary>
        public Vector4F ClipRect { get; set; }

        /// <summary>
        ///     The texture id
        /// </summary>
        public IntPtr TextureId { get; set; }

        /// <summary>
        ///     The vtx offset
        /// </summary>
        public uint VtxOffset { get; set; }

        /// <summary>
        ///     The idx offset
        /// </summary>
        public uint IdxOffset { get; set; }

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/ImDrawCmdTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImDrawCmd.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImDrawCmd.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:2_Application/Alis/src/Builder/Core/Ecs/System/VideoGameBuilder.cs

    ### Language
    cs

    ### Coverage
    93.8% (Line: 93.8%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    VideoGameBuilder

    ### Complexity / LOC
    4 / 35 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:VideoGameBuilder.cs
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

//  File:VideoGameBuilder.cs
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


using System;
using Alis.Builder.Core.Ecs.System.ConfigurationBuilders;
using Alis.Builder.Core.Ecs.System.ManagerBuilders.Scenes;
using Alis.Core.Aspect.Fluent;
using Alis.Core.Aspect.Fluent.Words;
using Alis.Core.Ecs.Systems;
using Alis.Core.Ecs.Systems.Configuration;
using Alis.Core.Ecs.Systems.Manager.Scene;
using Alis.Core.Ecs.Systems.Scope;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:2_Application/Alis/test/Builder/Core/Ecs/System/VideoGameBuilderTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:2_Application/Alis/src/Builder/Core/Ecs/System/VideoGameBuilder.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage VideoGameBuilder.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/StreamAdaptor.cs

    ### Language
    cs

    ### Coverage
    93.9% (Line: 93.6%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    StreamAdaptor

    ### Complexity / LOC
    10 / 64 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:StreamAdaptor.cs
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
using System.IO;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     Adapts a System.IO.Stream to be usable as a SFML InputStream
    /// </summary>
    public class StreamAdaptor : IDisposable
    {
        /// <summary>
        ///     Roots InputStream delegate fields to prevent GC collection.
        /// </summary>
        internal readonly List<Delegate> _pinnedCallbacks = new(4);

        /// <summary>
        ///     The my input stream ptr
        /// </summary>
        internal readonly IntPtr myInputStreamPtr;

        /// <summary>
        ///     The my stream
        /// </summary>
        internal readonly Stream myStream;

        /// <summary>
        ///     Construct from a System.IO.Stream
        /// </summary>
        /// <param name="stream">Stream to adapt</param>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Systems/StreamAdaptorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/StreamAdaptor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage StreamAdaptor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:6_Ideation/Logging/src/Outputs/FileLogOutput.cs

    ### Language
    cs

    ### Coverage
    94.0% (Line: 91.9%, Branch: 100.0%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    0

    ### Method
    FileLogOutput

    ### Complexity / LOC
    20 / 100 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FileLogOutput.cs
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
using System.Text;
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to a file on disk.
    ///     Supports appending to existing files and creates directories as needed.
    ///     Thread-safe: Uses a lock for file writes.
    ///     AOT-compatible: Uses standard file I/O, no reflection.
    /// </summary>
    public sealed class FileLogOutput : ILogOutput
    {
        /// <summary>
        ///     The file path
        /// </summary>
        internal readonly string _filePath;

        /// <summary>
        ///     The formatter
        /// </summary>
        internal readonly ILogFormatter _formatter;

        /// <summary>
        ///     The write lock
        /// </summary>
        internal readonly object _writeLock = new object();

    ```
    
    ### Test File Hint
    pabllopf-official_alis:6_Ideation/Logging/test/Outputs/FileLogOutputTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:6_Ideation/Logging/src/Outputs/FileLogOutput.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FileLogOutput.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/GameObjectExtensions.cs

    ### Language
    cs

    ### Coverage
    94.1% (Line: 94.1%, Branch: None%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    0

    ### Method
    GameObjectExtensions

    ### Complexity / LOC
    10 / 98 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GameObjectExtensions.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Deconstruction extensions for entities.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        ///     Deconstructs the entity into a component reference
        /// </summary>
        /// <typeparam name="T">The component type to extract</typeparam>
        /// <param name="e">The gameObject to deconstruct</param>
        /// <param name="comp">The extracted component reference</param>
        public static void Deconstruct<T>(this GameObject e, out Ref<T> comp)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            comp = GetComp<T>(eloc.Archetype.ComponentTagTableSpan, eloc.Archetype.ComponentsSpan, eloc.Index);
        }

        /// <summary>
        ///     Deconstructs the entity into two component references
        /// </summary>
        /// <typeparam name="T1">The first component type</typeparam>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/GameObjectExtensionsTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/GameObjectExtensions.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GameObjectExtensions.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesStyle.cs

    ### Language
    cs

    ### Coverage
    94.1% (Line: 94.1%, Branch: None%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    ImNodesStyle

    ### Complexity / LOC
    34 / 24 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ImNodesStyle.cs
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

using Alis.Core.Aspect.Math.Vector;

namespace Alis.Extension.Graphic.Ui.Extras.Node
{
    /// <summary>
    ///     The im nodes style
    /// </summary>
    public struct ImNodesStyle
    {
        /// <summary>
        ///     The grid spacing
        /// </summary>
        public float GridSpacing { get; set; }

        /// <summary>
        ///     The node corner rounding
        /// </summary>
        public float NodeCornerRounding { get; set; }

        /// <summary>
        ///     The node padding
        /// </summary>
        public Vector2F NodePadding { get; set; }

        /// <summary>
        ///     The node border thickness
        /// </summary>
        public float NodeBorderThickness { get; set; }

        /// <summary>
        ///     The link thickness
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/test/Extras/Node/ImNodesStyleTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/Extras/Node/ImNodesStyle.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ImNodesStyle.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Island.cs

    ### Language
    cs

    ### Coverage
    94.6% (Line: 94.9%, Branch: 93.1%)

    ### Uncovered Lines
    20

    ### Uncovered Branches
    7

    ### Method
    Island

    ### Complexity / LOC
    86 / 456 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Island.cs
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
using System.Buffers;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Time;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     This is an internal class.
    /// </summary>
    public class Island : IDisposable
    {
        /// <summary>
        ///     The linear sleep tolerance
        /// </summary>
        private const float LinTolSqr = SettingEnv.LinearSleepTolerance * SettingEnv.LinearSleepTolerance;

        /// <summary>
        ///     The angular sleep tolerance
        /// </summary>
        private const float AngTolSqr = SettingEnv.AngularSleepTolerance * SettingEnv.AngularSleepTolerance;

        /// <summary>
        ///     The contact solver
        /// </summary>
        internal readonly ContactSolver _contactSolver = new ContactSolver();

        /// <summary>
        ///     The stopwatch
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/IslandTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Island.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Island.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs

    ### Language
    cs

    ### Coverage
    94.6% (Line: 95.9%, Branch: 91.3%)

    ### Uncovered Lines
    11

    ### Uncovered Branches
    9

    ### Method
    EarclipDecomposer

    ### Complexity / LOC
    66 / 312 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:EarclipDecomposer.cs
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
using System.Buffers;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Decomposition
{
    /// <summary>
    ///     Convex decomposition algorithm using ear clipping
    ///     Properties:
    ///     - Only works on simple polygons.
    ///     - Does not support holes.
    ///     - Running time is O(n^2), n = number of vertices.
    ///     Source: http://www.ewjordan.com/earClip/
    /// </summary>
    internal static class EarclipDecomposer
    {
        //box2D rev 32 - for details, see http://www.box2d.org/forum/viewtopic.php?f=4&t=83&start=50 

        /// <summary>
        ///     Decompose the polygon into several smaller non-concave polygon.
        ///     Each resulting polygon will have no more than Settings.MaxPolygonVertices vertices.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="tolerance">The tolerance.</param>
        public static List<Vertices> ConvexPartition(Vertices vertices, float tolerance = 0.001f) => TriangulatePolygon(vertices, tolerance);

        /// <summary>
        ///     Triangulates a polygon using simple ear-clipping algorithm. Returns
        ///     size of Triangle array unless the polygon can't be triangulated.
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/EarclipDecomposerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage EarclipDecomposer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:6_Ideation/Logging/src/Outputs/ConsoleLogOutput.cs

    ### Language
    cs

    ### Coverage
    94.7% (Line: 92.9%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    ConsoleLogOutput

    ### Complexity / LOC
    18 / 61 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ConsoleLogOutput.cs
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
using Alis.Core.Aspect.Logging.Abstractions;
using Alis.Core.Aspect.Logging.Formatters;

namespace Alis.Core.Aspect.Logging.Outputs
{
    /// <summary>
    ///     Writes log entries to the standard console output.
    ///     Uses colored output when available based on log level.
    ///     Thread-safe: Console.WriteLine is thread-safe in .NET.
    ///     AOT-compatible: No reflection, simple console I/O.
    /// </summary>
    public sealed class ConsoleLogOutput : ILogOutput
    {
        /// <summary>
        ///     The formatter used to convert log entries into strings for console display.
        /// </summary>
        internal readonly ILogFormatter _formatter;

        /// <summary>
        ///     Indicates whether this instance has been disposed and should no longer accept writes.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the ConsoleLogOutput class.
        /// </summary>
        /// <param name="formatter">The formatter to use for log entries. If null, uses a simple formatter.</param>
        public ConsoleLogOutput(ILogFormatter formatter = null) => _formatter = formatter ?? new SimpleLogFormatter();


    ```
    
    ### Test File Hint
    pabllopf-official_alis:6_Ideation/Logging/test/Outputs/ConsoleLogOutputTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:6_Ideation/Logging/src/Outputs/ConsoleLogOutput.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ConsoleLogOutput.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/WebSocketClientFactory.cs

    ### Language
    cs

    ### Coverage
    94.8% (Line: 94.4%, Branch: 96.9%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    1

    ### Method
    WebSocketClientFactory

    ### Complexity / LOC
    35 / 218 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebSocketClientFactory.cs
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
using System.IO;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Security.Authentication;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Alis.Extension.Network.Exceptions;
using Alis.Extension.Network.Internal;

namespace Alis.Extension.Network
{
    /// <summary>
    ///     Web socket client factory used to open web socket client connections
    /// </summary>
    public class WebSocketClientFactory : IWebSocketClientFactory, IDisposable
    {
        /// <summary>
        ///     The buffer factory
        /// </summary>
        internal readonly Func<MemoryStream> BufferFactory;

        /// <summary>
        ///     The buffer pool
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/WebSocketClientFactoryTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/WebSocketClientFactory.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebSocketClientFactory.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs

    ### Language
    cs

    ### Coverage
    95.1% (Line: 94.2%, Branch: 97.2%)

    ### Uncovered Lines
    10

    ### Uncovered Branches
    2

    ### Method
    BayazitDecomposer

    ### Complexity / LOC
    55 / 205 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BayazitDecomposer.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Decomposition
{
    //From phed rev 36: http://code.google.com/p/phed/source/browse/trunk/Polygon.cpp

    /// <summary>
    ///     Convex decomposition algorithm created by Mark Bayazit (http://mnbayazit.com/)
    ///     Properties:
    ///     - Tries to decompose using polygons instead of triangles.
    ///     - Tends to produce optimal results with low processing time.
    ///     - Running time is O(nr), n = number of vertices, r = reflex vertices.
    ///     - Does not support holes.
    ///     For more information about this algorithm, see http://mnbayazit.com/406/bayazit
    /// </summary>
    internal static class BayazitDecomposer
    {
        /// <summary>
        ///     Decompose the polygon into several smaller non-concave polygon.
        ///     If the polygon is already convex, it will return the original polygon, unless it is over
        ///     Settings.MaxPolygonVertices.
        /// </summary>
        public static List<Vertices> ConvexPartition(Vertices vertices) => TriangulatePolygon(vertices);

        /// <summary>
        ///     Triangulates the polygon using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <returns>The list</returns>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/BayazitDecomposerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/BayazitDecomposer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BayazitDecomposer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/SeparationFunction.cs

    ### Language
    cs

    ### Coverage
    95.7% (Line: 96.7%, Branch: 87.5%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    2

    ### Method
    SeparationFunction

    ### Complexity / LOC
    13 / 161 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SeparationFunction.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Computes the separation distance between two convex shapes at a given time fraction during continuous collision detection.
    /// </summary>
    /// <remarks>
    ///     This class is used by the TOI (Time of Impact) solver to evaluate how far apart two shapes are
    ///     at a specific point in time. It maintains thread-static state for the separation axis, local point,
    ///     proxies, and sweeps to avoid allocations during iterative distance evaluation.
    ///     
    ///     The separation function can operate in three modes:
    ///     <list type="bullet">
    ///         <item><term>Points</term><description>Both shapes contribute a single vertex.</description></item>
    ///         <item><term>FaceA</term><description>Shape A contributes a face, Shape B contributes a vertex.</description></item>
    ///         <item><term>FaceB</term><description>Shape B contributes a face, Shape A contributes a vertex.</description></item>
    ///     </list>
    /// </remarks>
    public static class SeparationFunction
    {
        /// <summary>
        ///     Gets or sets the separation axis in world space.
        /// </summary>
        /// <value>
        ///     A <see cref="Vector2F"/> representing the direction along which separation is measured.
        /// </value>
        /// <remarks>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/SeparationFunctionTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/SeparationFunction.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SeparationFunction.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Thread/src/ThreadManager.cs

    ### Language
    cs

    ### Coverage
    95.8% (Line: 100.0%, Branch: 83.3%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    ThreadManager

    ### Complexity / LOC
    7 / 32 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ThreadManager.cs
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
using Alis.Extension.Thread.Configuration;
using Alis.Extension.Thread.Execution;

namespace Alis.Extension.Thread
{
    /// <summary>
    ///     Modern thread manager for parallel execution of ECS component updates.
    ///     Provides automatic work partitioning and efficient thread pool management.
    /// </summary>
    public sealed class ThreadManager : IDisposable
    {
        /// <summary>
        ///     The parallel update executor
        /// </summary>
        internal readonly ParallelUpdateExecutor parallelExecutor;

        /// <summary>
        ///     Whether the manager has been disposed
        /// </summary>
        private bool disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class with default configuration
        /// </summary>
        public ThreadManager() : this(new ParallelExtensionConfiguration())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ThreadManager" /> class
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Thread/test/ThreadManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Thread/src/ThreadManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ThreadManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Fixture.cs

    ### Language
    cs

    ### Coverage
    96.2% (Line: 96.9%, Branch: 92.3%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    2

    ### Method
    Fixture

    ### Complexity / LOC
    43 / 179 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Fixture.cs
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
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Dynamics
{
    /// <summary>
    ///     A fixture is used to attach a Shape to a body for collision detection. A fixture
    ///     inherits its transform from its parent. Fixtures hold additional non-geometric data
    ///     such as friction, collision filters, etc.
    /// </summary>
    public class Fixture
    {
        /// <summary>
        ///     The friction
        /// </summary>

        /// <summary>
        ///     The is sensor
        /// </summary>
        private bool _isSensor;

        /// <summary>
        ///     The restitution
        /// </summary>

        /// <summary>
        ///     Fires after two shapes has collided and are solved. This gives you a chance to get the impact force.
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/FixtureTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Fixture.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Fixture.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/SimpleCombiner.cs

    ### Language
    cs

    ### Coverage
    96.6% (Line: 96.8%, Branch: 96.2%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    3

    ### Method
    SimpleCombiner

    ### Complexity / LOC
    54 / 223 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SimpleCombiner.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    /// <summary>
    ///     Combines a list of triangles into a list of convex polygons.
    ///     Starts with a seed triangle, keep adding triangles to it until you can't add any more without making the polygon
    ///     non-convex.
    /// </summary>
    public static class SimpleCombiner
    {
        /// <summary>
        ///     Combine a list of triangles into a list of convex polygons.
        ///     Note: This only works on triangles.
        /// </summary>
        /// <param name="triangles">The triangles.</param>
        /// <param name="maxPolys">The maximun number of polygons to return.</param>
        /// <param name="tolerance">The tolerance</param>
        public static List<Vertices> PolygonizeTriangles(List<Vertices> triangles, int maxPolys = int.MaxValue, float tolerance = 0.001f)
        {
            if (triangles.Count <= 0)
            {
                return triangles;
            }

            List<Vertices> polys = new List<Vertices>();

            bool[] covered = MarkDegenerateTriangles(triangles);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/PolygonManipulation/SimpleCombinerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/SimpleCombiner.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SimpleCombiner.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/PingPongManager.cs

    ### Language
    cs

    ### Coverage
    96.6% (Line: 95.9%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    PingPongManager

    ### Complexity / LOC
    18 / 106 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:PingPongManager.cs
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
using System.Net.WebSockets;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Time;
using Alis.Extension.Network.Internal;

namespace Alis.Extension.Network
{
    /// <summary>
    ///     Ping Pong Manager used to facilitate ping pong WebSocket messages
    /// </summary>
    public class PingPongManager : IPingPongManager
    {
        /// <summary>
        ///     The cancellation token
        /// </summary>
        internal readonly CancellationToken CancellationToken;

        /// <summary>
        ///     The guid
        /// </summary>
        internal readonly Guid Guid;

        /// <summary>
        ///     The keep alive interval
        /// </summary>
        internal readonly TimeSpan KeepAliveInterval;

        /// <summary>
        ///     The stopwatch
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/PingPongManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/PingPongManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage PingPongManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

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

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Collections/FastestStack.cs

    ### Language
    cs

    ### Coverage
    96.7% (Line: 97.4%, Branch: 94.4%)

    ### Uncovered Lines
    7

    ### Uncovered Branches
    5

    ### Method
    FastestStack

    ### Complexity / LOC
    87 / 361 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FastestStack.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fastest stack class
    /// </summary>
    /// <seealso cref="ICollection" />
    /// <seealso cref="IReadOnlyCollection{T}" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct FastestStack<T> : ICollection,
        IReadOnlyCollection<T>, IDisposable
    {
        /// <summary>
        ///     The array
        /// </summary>
        private T[] _array;

        /// <summary>
        ///     The size
        /// </summary>
        internal int _size;

        /// <summary>
        ///     The version
        /// </summary>
        internal int _version;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Collections/FastestStackTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Collections/FastestStack.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FastestStack.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Cloud/GoogleDrive/src/GoogleDriveCloudManager.cs

    ### Language
    cs

    ### Coverage
    96.8% (Line: 98.0%, Branch: 92.2%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    5

    ### Method
    GoogleDriveCloudManager

    ### Complexity / LOC
    49 / 319 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GoogleDriveCloudManager.cs
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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Drive.v3.Data;
using Google.Apis.Services;
using Google.Apis.Upload;
using File = System.IO.File;

namespace Alis.Extension.Cloud.GoogleDrive
{
    /// <summary>
    ///     The cloud manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="ICloudManager" />
    public class GoogleDriveCloudManager : AManager, ICloudManager, IDisposable
    {
        /// <summary>
        ///     Error message for not initialized state
        /// </summary>
        private const string NotInitializedError = "Google Drive manager is not initialized. Call InitializeAsync first.";

        /// <summary>
        ///     The Google Drive space identifier for file operations
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Cloud/GoogleDrive/test/GoogleDriveCloudManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Cloud/GoogleDrive/src/GoogleDriveCloudManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GoogleDriveCloudManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/GameObject.cs

    ### Language
    cs

    ### Coverage
    96.9% (Line: 99.9%, Branch: 84.7%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    37

    ### Method
    GameObject

    ### Complexity / LOC
    207 / 1153 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GameObject.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     A lightweight identifier that represents an entity in the ECS (Entity Component System) architecture.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     In the ECS pattern, an entity is simply an ID that identifies a collection of components.
    ///     Components hold data, while systems provide logic. This struct serves as the primary handle
    ///     for accessing and manipulating game objects within a <see cref="Scene" />.
    ///     </para>
    ///     <para>
    ///     The struct is designed for value-type performance: 8 bytes total (int + ushort + ushort),
    ///     with no padding due to <c>Pack = 1</c>. The fields are laid out as: EntityID (4 bytes),
    ///     EntityVersion (2 bytes), WorldID (2 bytes).
    ///     </para>
    ///     <para>
    ///     The version field enables safe handling of recycled entity IDs, preventing access to
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/GameObjectTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/GameObject.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GameObject.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerExecutor.cs

    ### Language
    cs

    ### Coverage
    97.0% (Line: 100.0%, Branch: 87.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    3

    ### Method
    FilePickerExecutor

    ### Complexity / LOC
    18 / 103 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FilePickerExecutor.cs
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
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Provides methods for executing system commands related to file dialogs.
    /// </summary>
    
    public static class FilePickerExecutor
    {
        /// <summary>
        /// Gets or sets the value of the command exists override
        /// </summary>
        internal static Func<string, bool> CommandExistsOverride { get; set; }

        /// <summary>
        /// Gets or sets the value of the execute command override
        /// </summary>
        internal static Func<string, string, int, string> ExecuteCommandOverride { get; set; }

        /// <summary>
        ///     Executes a system command and returns its output.
        /// </summary>
        /// <param name="fileName">The name of the executable to run</param>
        /// <param name="arguments">The command arguments</param>
        /// <param name="timeoutMs">The maximum time to wait for the process (in milliseconds)</param>
        /// <returns>The command output</returns>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/test/FilePickerExecutorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerExecutor.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FilePickerExecutor.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Util/PolygonGenerator.cs

    ### Language
    cs

    ### Coverage
    97.1% (Line: 100.0%, Branch: 87.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    PolygonGenerator

    ### Complexity / LOC
    10 / 71 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:PolygonGenerator.cs
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
using System.Security.Cryptography;
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The polygon generator class
    /// </summary>
    internal static class PolygonGenerator
    {
        /// <summary>
        ///     The random
        /// </summary>
        internal static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Randoms the circle sweep using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <returns>The polygon polygon</returns>
        public static Polygon.Polygon RandomCircleSweep(double scale, int vertexCount)
        {
            PolygonPoint point;
            PolygonPoint[] points;
            double radius = scale / 4;

            points = new PolygonPoint[vertexCount];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/CDT/Util/PolygonGeneratorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Util/PolygonGenerator.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage PolygonGenerator.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Updater/src/Services/Api/GitHubApiService.cs

    ### Language
    cs

    ### Coverage
    97.1% (Line: 100.0%, Branch: 83.3%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    GitHubApiService

    ### Complexity / LOC
    9 / 43 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GitHubApiService.cs
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
using System.Net.Http;
using System.Threading.Tasks;

namespace Alis.Extension.Updater.Services.Api
{
    /// <summary>
    ///     The git hub api service class
    /// </summary>
    /// <seealso cref="IGitHubApiService" />
    public class GitHubApiService : IGitHubApiService, IDisposable
    {
        /// <summary>
        ///     The http client
        /// </summary>
        internal readonly HttpClient _httpClient;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GitHubApiService" /> class
        /// </summary>
        /// <param name="apiUrl"></param>
        public GitHubApiService(Uri apiUrl)
        {
            _httpClient = new HttpClient();
            ApiUrl = apiUrl;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GitHubApiService" /> class with a pre-configured HttpClient
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Updater/test/Services/Api/GitHubApiServiceTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Updater/src/Services/Api/GitHubApiService.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GitHubApiService.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CryptoRandomNumberGenerator.cs

    ### Language
    cs

    ### Coverage
    97.8% (Line: 100.0%, Branch: 90.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    CryptoRandomNumberGenerator

    ### Complexity / LOC
    11 / 54 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CryptoRandomNumberGenerator.cs
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
using System.Security.Cryptography;
using Alis.Extension.Math.ProceduralDungeon.Interfaces;

namespace Alis.Extension.Math.ProceduralDungeon.Services
{
    /// <summary>
    ///     Implementation of <see cref="IRandomNumberGenerator" /> using cryptographic random number generation.
    ///     Provides secure random number generation for dungeon creation.
    /// </summary>
    public class CryptoRandomNumberGenerator : IRandomNumberGenerator, IDisposable
    {
        /// <summary>
        ///     The random number generator instance.
        /// </summary>
        internal readonly RandomNumberGenerator _rng;

        /// <summary>
        ///     Indicates whether this instance has been disposed.
        /// </summary>
        private bool _disposed;

        /// <summary>
        ///     Initializes a new instance of the <see cref="CryptoRandomNumberGenerator" /> class.
        /// </summary>
        public CryptoRandomNumberGenerator() => _rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Releases all resources used by this instance.
        /// </summary>
        public void Dispose()
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/test/Services/CryptoRandomNumberGeneratorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/ProceduralDungeon/src/Services/CryptoRandomNumberGenerator.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CryptoRandomNumberGenerator.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/Collision.cs

    ### Language
    cs

    ### Coverage
    97.9% (Line: 98.2%, Branch: 96.9%)

    ### Uncovered Lines
    15

    ### Uncovered Branches
    8

    ### Method
    Collision

    ### Complexity / LOC
    172 / 961 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Collision.cs
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
using System.Buffers;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Collision methods
    /// </summary>
    public static class Collision
    {
        /// <summary>
        ///     Test overlap between the two shapes.
        /// </summary>
        /// <param name="shapeA">The first shape.</param>
        /// <param name="indexA">The index for the first shape.</param>
        /// <param name="shapeB">The second shape.</param>
        /// <param name="indexB">The index for the second shape.</param>
        /// <param name="xfA">The transform for the first shape.</param>
        /// <param name="xfB">The transform for the seconds shape.</param>
        /// <returns>True if the shapes overlap, false otherwise.</returns>
        public static bool TestOverlap(Shape shapeA, int indexA, Shape shapeB, int indexB, ref ControllerTransform xfA, ref ControllerTransform xfB)
        {
            DistanceInput input = new DistanceInput();
            input.ProxyA = new DistanceProxy(shapeA, indexA);
            input.ProxyB = new DistanceProxy(shapeB, indexB);
            input.ControllerTransformA = xfA;
            input.ControllerTransformB = xfB;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/CollisionTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/Collision.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Collision.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/WindowsFilePicker.cs

    ### Language
    cs

    ### Coverage
    98.1% (Line: 100.0%, Branch: 92.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    3

    ### Method
    WindowsFilePicker

    ### Complexity / LOC
    30 / 179 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WindowsFilePicker.cs
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
using System.Linq;
using System.Text;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     FilePicker implementation for Windows using PowerShell.
    /// </summary>
    
    public class WindowsFilePicker : IFilePicker
    {
        /// <summary>
        ///     The file open script
        /// </summary>
        private const string FileOpenScript = @"
Add-Type -AssemblyName System.Windows.Forms
$dialog = New-Object System.Windows.Forms.OpenFileDialog
$dialog.Title = '{0}'
{1}
{2}
if ($dialog.ShowDialog() -eq 'OK') {{
    $dialog.FileName
}}
";

        /// <summary>
        ///     The folder select script
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/test/WindowsFilePickerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/WindowsFilePicker.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WindowsFilePicker.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerResult.cs

    ### Language
    cs

    ### Coverage
    98.3% (Line: 100.0%, Branch: 90.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    FilePickerResult

    ### Complexity / LOC
    19 / 62 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FilePickerResult.cs
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
using System.Linq;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Represents the result of a file picker dialog operation.
    /// </summary>
    public class FilePickerResult
    {
        /// <summary>
        ///     Initializes a new instance of the FilePickerResult class for a successful operation.
        /// </summary>
        /// <param name="selectedPaths">The list of selected paths</param>
        /// <exception cref="ArgumentNullException">Thrown when selectedPaths is null</exception>
        /// <exception cref="ArgumentException">Thrown when selectedPaths is empty</exception>
        public FilePickerResult(List<string> selectedPaths)
        {
            if (selectedPaths == null)
            {
                throw new ArgumentNullException(nameof(selectedPaths), "Selected paths cannot be null.");
            }

            if (selectedPaths.Count == 0)
            {
                throw new ArgumentException("At least one path must be selected.", nameof(selectedPaths));
            }

            IsSuccess = true;
            IsCancelled = false;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/test/FilePickerResultTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerResult.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FilePickerResult.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WheelJoint.cs

    ### Language
    cs

    ### Coverage
    98.5% (Line: 98.8%, Branch: 95.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    1

    ### Method
    WheelJoint

    ### Complexity / LOC
    46 / 332 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WheelJoint.cs
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
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A wheel joint. This joint provides two degrees of freedom: translation
    ///     along an axis fixed in bodyA and rotation in the plane. You can use a
    ///     joint limit to restrict the range of motion and a joint motor to drive
    ///     the rotation or to model rotational friction.
    ///     This joint is designed for vehicle suspensions.
    /// </summary>
    /// <remarks>
    ///     Linear constraint (point-to-line)
    ///     d = pB - pA = xB + rB - xA - rA
    ///     C = dot(ay, d)
    ///     Cdot = dot(d, cross(wA, ay)) + dot(ay, vB + cross(wB, rB) - vA - cross(wA, rA))
    ///     = -dot(ay, vA) - dot(cross(d + rA, ay), wA) + dot(ay, vB) + dot(cross(rB, ay), vB)
    ///     J = [-ay, -cross(d + rA, ay), ay, cross(rB, ay)]
    ///     Spring linear constraint
    ///     C = dot(ax, d)
    ///     Cdot = = -dot(ax, vA) - dot(cross(d + rA, ax), wA) + dot(ax, vB) + dot(cross(rB, ax), vB)
    ///     J = [-ax -cross(d+rA, ax) ax cross(rB, ax)]
    ///     Motor rotational constraint
    ///     Cdot = wB - wA
    ///     J = [0 0 -1 0 0 1]
    /// </remarks>
    public class WheelJoint : Joint
    {
        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/WheelJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WheelJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WheelJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/SimplePriorityQueue.cs

    ### Language
    cs

    ### Coverage
    98.6% (Line: 100.0%, Branch: 93.6%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    5

    ### Method
    SimplePriorityQueue

    ### Complexity / LOC
    66 / 367 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:SimplePriorityQueue.cs
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
using System.Linq;

namespace Alis.Extension.Math.HighSpeedPriorityQueue
{
    /// <summary>
    ///     A simplified priority queue implementation.  Is stable, auto-resizes, and thread-safe, at the cost of being
    ///     slightly slower than
    ///     FastPriorityQueue
    ///     Methods tagged as O(1) or O(log n) are assuming there are no duplicates.  Duplicates may increase the algorithmic
    ///     complexity.
    /// </summary>
    /// <typeparam name="TItem">The type to enqueue</typeparam>
    /// <typeparam name="TPriority">The priority-type to use for nodes.  Must extend IComparable&lt;TPriority&gt;</typeparam>
    public class SimplePriorityQueue<TItem, TPriority> : IPriorityQueue<TItem, TPriority>
    {
        /// <summary>
        ///     The initial queue size
        /// </summary>
        private const int InitialQueueSize = 10;

        /// <summary>
        ///     The item to nodes cache
        /// </summary>
        internal readonly Dictionary<TItem, IList<SimpleNode>> _itemToNodesCache;

        /// <summary>
        ///     The null nodes cache
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/test/SimplePriorityQueueTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Math/HighSpeedPriorityQueue/src/SimplePriorityQueue.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage SimplePriorityQueue.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/DelaunayTriangle.cs

    ### Language
    cs

    ### Coverage
    98.7% (Line: 100.0%, Branch: 95.7%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    4

    ### Method
    DelaunayTriangle

    ### Complexity / LOC
    90 / 265 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangle.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep;
using Alis.Core.Physic.Common.Decomposition.CDT.Util;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay
{
    /// <summary>
    ///     The delaunay triangle class
    /// </summary>
    internal class DelaunayTriangle
    {
        /// <summary>
        ///     The edge is constrained
        /// </summary>
        public FixedBitArray3 EdgeIsConstrained;


        /// <summary>
        ///     The edge is delaunay
        /// </summary>
        public FixedBitArray3 EdgeIsDelaunay;

        /// <summary>
        ///     The neighbors
        /// </summary>
        public Util.FixedArray3<DelaunayTriangle> Neighbors;


        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Decomposition/CDT/Delaunay/DelaunayTriangleTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/DelaunayTriangle.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DelaunayTriangle.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/WebSocketImplementation.cs

    ### Language
    cs

    ### Coverage
    98.8% (Line: 98.8%, Branch: 98.6%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    1

    ### Method
    WebSocketImplementation

    ### Complexity / LOC
    71 / 430 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WebSocketImplementation.cs
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
using System.IO.Compression;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Alis.Extension.Network.Internal
{
    /// <summary>
    ///     Main implementation of the WebSocket abstract class
    /// </summary>
    internal sealed class WebSocketImplementation : WebSocket
    {
        /// <summary>
        ///     The max ping pong payload len
        /// </summary>
        internal const int PingPongPayloadLen = 125;

        /// <summary>
        ///     The guid
        /// </summary>
        internal readonly Guid Guid;

        /// <summary>
        ///     The include exception in close response
        /// </summary>
        internal readonly bool IncludeExceptionInCloseResponse;

        /// <summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Internal/WebSocketImplementationTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/WebSocketImplementation.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WebSocketImplementation.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/DistanceJoint.cs

    ### Language
    cs

    ### Coverage
    98.8% (Line: 100.0%, Branch: 87.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    DistanceJoint

    ### Complexity / LOC
    29 / 187 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DistanceJoint.cs
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
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A distance joint rains two points on two bodies
    ///     to remain at a fixed distance from each other. You can view
    ///     this as a massless, rigid rod.
    /// </summary>
    /// <remarks>
    ///     1-D rained system
    ///     m (v2 - v1) = lambda
    ///     v2 + (beta/h) * x1 + gamma * lambda = 0, gamma has units of inverse mass.
    ///     x2 = x1 + h * v2
    ///     1-D mass-damper-spring system
    ///     m (v2 - v1) + h * d * v2 + h * k *
    ///     C = norm(p2 - p1) - L
    ///     u = (p2 - p1) / norm(p2 - p1)
    ///     Cdot = dot(u, v2 + cross(w2, r2) - v1 - cross(w1, r1))
    ///     J = [-u -cross(r1, u) u cross(r2, u)]
    ///     K = J * invM * JT
    ///     = invMass1 + invI1 * cross(r1, u)^2 + invMass2 + invI2 * cross(r2, u)^2
    /// </remarks>
    public class DistanceJoint : Joint
    {
        /// <summary>
        ///     The bias
        /// </summary>
        internal float _bias;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/DistanceJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/DistanceJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DistanceJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Server/NetworkServerManager.cs

    ### Language
    cs

    ### Coverage
    99.0% (Line: 98.8%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    NetworkServerManager

    ### Complexity / LOC
    59 / 301 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:NetworkServerManager.cs
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
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Data.Json;
using Alis.Extension.Network.Core;

namespace Alis.Extension.Network.Server
{



    /// <summary>
    /// The network server manager class
    /// </summary>
    /// <seealso cref="INetworkServerManager"/>
    public sealed class NetworkServerManager : INetworkServerManager
    {



        /// <summary>
        /// The client to session map
        /// </summary>
        internal readonly ConcurrentDictionary<string, string> _clientToSessionMap;




    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Network/test/Server/NetworkServerManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Network/src/Server/NetworkServerManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage NetworkServerManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/src/DialogManager.cs

    ### Language
    cs

    ### Coverage
    99.0% (Line: 100.0%, Branch: 97.1%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    DialogManager

    ### Complexity / LOC
    51 / 170 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DialogManager.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Extension.Language.Dialogue.Core;

namespace Alis.Extension.Language.Dialogue
{
    /// <summary>
    ///     Unified dialog manager with support for basic and advanced features including state machine, events, and conditions
    /// </summary>
    public class DialogManager
    {
        /// <summary>
        ///     The event publisher
        /// </summary>
        internal readonly DialogEventPublisher _eventPublisher = new DialogEventPublisher();

        /// <summary>
        ///     The dialog dictionary
        /// </summary>
        internal readonly Dictionary<string, Dialog> Dialogs = new Dictionary<string, Dialog>();

        /// <summary>
        ///     The current dialog context
        /// </summary>
        private DialogContext _currentContext;

        /// <summary>
        ///     The last dialog state (for tracking after dialog ends)
        /// </summary>
        private DialogStateType _lastState = DialogStateType.Idle;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/test/DialogManagerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Language/Dialogue/src/DialogManager.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DialogManager.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerValidator.cs

    ### Language
    cs

    ### Coverage
    99.0% (Line: 100.0%, Branch: 97.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    FilePickerValidator

    ### Complexity / LOC
    42 / 186 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:FilePickerValidator.cs
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
using System.IO;
using System.Linq;
using Alis.Core.Aspect.Logging;

namespace Alis.Extension.Io.FileDialog
{
    /// <summary>
    ///     Provides validation methods for file picker operations.
    /// </summary>
    
    public static class FilePickerValidator
    {
        /// <summary>
        ///     Validates file picker options.
        /// </summary>
        /// <param name="options">The options to validate</param>
        /// <exception cref="ArgumentNullException">Thrown when options is null</exception>
        /// <exception cref="ArgumentException">Thrown when options contain invalid values</exception>
        public static void ValidateOptions(FilePickerOptions options)
        {
            Logger.Trace("Validating FilePickerOptions...");

            if (options == null)
            {
                Logger.Warning("FilePickerOptions is null.");
                throw new ArgumentNullException(nameof(options), "Options cannot be null.");
            }

            if (string.IsNullOrWhiteSpace(options.Title))
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/test/FilePickerValidatorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Io/FileDialog/src/FilePickerValidator.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage FilePickerValidator.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Controllers/GravityController.cs

    ### Language
    cs

    ### Coverage
    99.1% (Line: 100.0%, Branch: 97.2%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    GravityController

    ### Complexity / LOC
    37 / 103 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GravityController.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Controllers
{
    /// <summary>
    ///     A physics controller that applies gravitational forces between bodies and/or points.
    /// </summary>
    /// <remarks>
    ///     This controller simulates gravitational attraction using either Newton's law of
    ///     universal gravitation (distance-squared) or linear falloff. It can apply gravity
    ///     between specific bodies (body-to-body gravity) or between bodies and fixed points
    ///     (like planets or gravity wells).
    ///     
    ///     The controller supports distance-based falloff with configurable minimum and maximum
    ///     radius limits, allowing you to create localized gravity fields or global gravity systems.
    /// </remarks>
    /// <example>
    ///     <code>
    ///     // Create global gravity (like planetary gravity)
    ///     var gravity = new GravityController(100f);
    ///     gravity.AddPoint(new Vector2F(0, 0)); // Sun position
    ///     
    ///     // Add to world
    ///     world.AddController(gravity);
    ///     
    ///     // Or create body-to-body gravity (like star system)
    ///     var mutualGravity = new GravityController(500f, 1000f, 10f);
    ///     mutualGravity.AddBody(sun);
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Controllers/GravityControllerTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Controllers/GravityController.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GravityController.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WeldJoint.cs

    ### Language
    cs

    ### Coverage
    99.1% (Line: 100.0%, Branch: 90.9%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    WeldJoint

    ### Complexity / LOC
    32 / 241 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:WeldJoint.cs
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
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Dynamics.Joints
{
    /// <summary>
    ///     A weld joint essentially glues two bodies together. A weld joint may
    ///     distort somewhat because the island constraint solver is approximate.
    ///     The joint is soft constraint based, which means the two bodies will move
    ///     relative to each other, when a force is applied. To combine two bodies
    ///     in a rigid fashion, combine the fixtures to a single body instead.
    /// </summary>
    /// <remarks>
    ///     Point-to-point constraint
    ///     C = p2 - p1
    ///     Cdot = v2 - v1
    ///     = v2 + cross(w2, r2) - v1 - cross(w1, r1)
    ///     J = [-I -r1_skew I r2_skew ]
    ///     Identity used:
    ///     w k % (rx i + ry j) = w * (-ry i + rx j)
    ///     Angle constraint
    ///     C = angle2 - angle1 - referenceAngle
    ///     Cdot = w2 - w1
    ///     J = [0 0 -1 0 0 1]
    ///     K = invI1 + invI2
    /// </remarks>
    public class WeldJoint : Joint
    {
        /// <summary>
        ///     The bias
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/WeldJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/WeldJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage WeldJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Common/Logic/BreakableBody.cs

    ### Language
    cs

    ### Coverage
    99.2% (Line: 100.0%, Branch: 96.4%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    BreakableBody

    ### Complexity / LOC
    26 / 121 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:BreakableBody.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common.Decomposition;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;

namespace Alis.Core.Physic.Common.Logic
{
/// <summary>
///     Represents a breakable body composed of multiple fixtures that can separate when subjected to sufficient force.
///     This class manages a collection of fixtures that belong to a main body, and when the impact force exceeds
///     a specified strength threshold, the body decomposes into separate independent bodies.
///     The breakable body tracks its state (unbroken, should break, broken) and caches velocities to ensure
///     proper physical behavior after decomposition.
///     
///     When a breakable body is subjected to a collision with an impulse greater than its Strength property,
///     it transitions from Unbroken to ShouldBreak state, and during the next Update() call it decomposes into
///     separate Body instances, each containing one of the original fixtures with preserved velocities.
///     
///     Usage example:
///     <code>
///     // Create a breakable body from a list of vertices
///     var verticesList = new List&lt;Vertices&gt; { /* polygon vertices */ };
///     var breakableBody = new BreakableBody(world, verticesList, 1.0f);
///     
///     // Adjust the strength threshold (optional)
///     breakableBody.Strength = 1000.0f;
///     
///     // In your game loop:
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Common/Logic/BreakableBodyTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Common/Logic/BreakableBody.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage BreakableBody.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs

    ### Language
    cs

    ### Coverage
    99.4% (Line: 100.0%, Branch: 97.4%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

    ### Method
    PolygonShape

    ### Complexity / LOC
    61 / 312 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:PolygonShape.cs
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
using System.Runtime.CompilerServices;
#if NET5_0_OR_GREATER || NETCOREAPP3_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
using System.Runtime.InteropServices;
#endif
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.ConvexHull;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions.Shapes
{
    /// <summary>
    ///     Represents a simple non-selfintersecting convex polygon.
    ///     Create a convex hull from the given array of points.
    /// </summary>
    public class PolygonShape : Shape
    {
        /// <summary>
        ///     The vertices
        /// </summary>
        private Vertices _vertices;

        /// <summary>
        ///     Initializes a new instance of the <see cref="PolygonShape" /> class.
        /// </summary>
        /// <param name="vertices">The vertices.</param>
        /// <param name="density">The density.</param>
        public PolygonShape(Vertices vertices, float density)
            : base(density)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/Shapes/PolygonShapeTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage PolygonShape.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/CommandBuffer.cs

    ### Language
    cs

    ### Coverage
    99.5% (Line: 99.5%, Branch: 100.0%)

    ### Uncovered Lines
    1

    ### Uncovered Branches
    0

    ### Method
    CommandBuffer

    ### Complexity / LOC
    44 / 226 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:CommandBuffer.cs
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
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Stores a set of structual changes that can be applied to a <see cref="Scene" />.
    /// </summary>
    public class CommandBuffer
    {
        /// <summary>
        ///     The max component count
        /// </summary>
        internal readonly ComponentStorageBase[] _componentRunnerBuffer =
            new ComponentStorageBase[MemoryHelpers.MaxComponentCount];

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<AddComponent> AddComponentBuffer = FastestStack<AddComponent>.Create(2);

        /// <summary>
        ///     The create
        /// </summary>
        internal FastestStack<CreateCommand> CreateEntityBuffer = FastestStack<CreateCommand>.Create(2);

    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Ecs/test/Kernel/CommandBufferTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Ecs/src/Kernel/CommandBuffer.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage CommandBuffer.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs

    ### Language
    cs

    ### Coverage
    99.7% (Line: 100.0%, Branch: 94.4%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    GearJoint

    ### Complexity / LOC
    23 / 335 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:GearJoint.cs
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

namespace Alis.Core.Physic.Dynamics.Joints
{
    // K = J * invM * JT = invMass + invI * cross(r, ug)^2

    /// <summary>
    ///     A gear joint is used to connect two joints together.
    ///     Either joint can be a revolute or prismatic joint.
    ///     You specify a gear ratio to bind the motions together:
    ///     <![CDATA[coordinate1 + ratio * coordinate2 = ant]]>
    ///     The ratio can be negative or positive. If one joint is a revolute joint
    ///     and the other joint is a prismatic joint, then the ratio will have units
    ///     of length or units of 1/length.
    ///     Warning: You have to manually destroy the gear joint if jointA or jointB is destroyed.
    /// </summary>
    public class GearJoint : Joint
    {
        /// <summary>
        ///     The body
        /// </summary>
        internal readonly Body _bodyA;

        /// <summary>
        ///     The body
        /// </summary>
        internal readonly Body _bodyB;

        /// <summary>
        ///     The body
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Dynamics/Joints/GearJointTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Joints/GearJoint.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage GearJoint.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/DynamicTree.cs

    ### Language
    cs

    ### Coverage
    99.8% (Line: 100.0%, Branch: 99.2%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    DynamicTree

    ### Complexity / LOC
    94 / 637 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:DynamicTree.cs
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
using System.Buffers;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     A dynamic tree arranges data in a binary tree to accelerate
    ///     queries such as volume queries and ray casts. Leafs are proxies
    ///     with an AABB. In the tree we expand the proxy AABB by Settings.b2_fatAABBFactor
    ///     so that the proxy AABB is bigger than the client object. This allows the client
    ///     object to move by small amounts without triggering a tree update.
    ///     Nodes are pooled and relocatable, so we use node indices rather than pointers.
    /// </summary>
    public class DynamicTree<TNode>
    {
        /// <summary>
        ///     The null node
        /// </summary>
        internal const int NullNode = -1;

        /// <summary>
        ///     The stack
        /// </summary>
        internal readonly Stack<int> _queryStack = new Stack<int>(256);

        /// <summary>
        ///     The stack
        /// </summary>
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Physic/test/Collisions/DynamicTreeTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:4_Operation/Physic/src/Collisions/DynamicTree.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage DynamicTree.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================
