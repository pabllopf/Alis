
[INFO] Found 66 coverage targets. (skipped first 143 files) Outputting AI-ready tasks:


    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/EmscriptenWeb.cs

    ### Language
    cs

    ### Coverage
    77.7% (Line: 82.2%, Branch: 9.1%)

    ### Uncovered Lines
    59

    ### Uncovered Branches
    20

    ### Method
    EmscriptenWeb

    ### Complexity / LOC
    50 / 678 lines

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
        [ExcludeFromCodeCoverage]
        [DllImport(EmscriptenLib, EntryPoint = "registerKeyboardCallbacks", CallingConvention = CallingConvention.Cdecl),
         DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories)]
        private static extern void RegisterKeyboardCallbacksNative(
    ```
    
    ### Test File Hint
    pabllopf-official_alis:4_Operation/Graphic/test/Platforms/Web/EmscriptenWebTests.cs

    Priority
    MEDIUM (NEW)

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
    81.7% (Line: 82.9%, Branch: 78.3%)

    ### Uncovered Lines
    85

    ### Uncovered Branches
    39

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
    LOW (NEW)

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
    pabllopf-official_alis:4_Operation/Ecs/src/Updating/Runners/Update.cs

    ### Language
    cs

    ### Coverage
    84.1% (Line: 83.1%, Branch: 92.9%)

    ### Uncovered Lines
    43

    ### Uncovered Branches
    2

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
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Ui/src/ImGuiStyle.cs

    ### Language
    cs

    ### Coverage
    84.6% (Line: 79.0%, Branch: 95.0%)

    ### Uncovered Lines
    47

    ### Uncovered Branches
    6

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
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/CDT/Delaunay/Sweep/DTSweep.cs

    ### Language
    cs

    ### Coverage
    85.0% (Line: 86.6%, Branch: 79.6%)

    ### Uncovered Lines
    88

    ### Uncovered Branches
    42

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
    LOW (NEW)

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
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyDisplayManager.cs

    ### Language
    cs

    ### Coverage
    88.0% (Line: 91.0%, Branch: 78.4%)

    ### Uncovered Lines
    15

    ### Uncovered Branches
    11

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
    LOW (NEW)

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
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/ObjectBase.cs

    ### Language
    cs

    ### Coverage
    88.0% (Line: 87.0%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

    ### Method
    ObjectBase

    ### Complexity / LOC
    7 / 38 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:ObjectBase.cs
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

namespace Alis.Extension.Graphic.Sfml.Systems
{
    /// <summary>
    ///     The ObjectBase class is an abstract base for every
    ///     SFML object. It's meant for internal use only
    /// </summary>
    public abstract class ObjectBase : IDisposable
    {
        /// <summary>
        ///     The zero
        /// </summary>
        private IntPtr myCPointer = IntPtr.Zero;

        /// <summary>
        ///     Construct the object from a pointer to the C library object
        /// </summary>
        /// <param name="cPointer">Internal pointer to the object in the C libraries</param>
        protected ObjectBase(IntPtr cPointer) => myCPointer = cPointer;


        /// <summary>
        ///     Access to the internal pointer of the object.
        ///     For internal use only
        /// </summary>

        public IntPtr CPointer
        {
            get => myCPointer;
            protected set => myCPointer = value;
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Systems/ObjectBaseTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Systems/ObjectBase.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage ObjectBase.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:1_Presentation/Extension/Updater/src/UpdateManager.cs

    ### Language
    cs

    ### Coverage
    88.9% (Line: 92.4%, Branch: 73.1%)

    ### Uncovered Lines
    36

    ### Uncovered Branches
    28

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
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/TimeOfImpact.cs

    ### Language
    cs

    ### Coverage
    89.7% (Line: 90.5%, Branch: 85.7%)

    ### Uncovered Lines
    14

    ### Uncovered Branches
    4

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
    pabllopf-official_alis:4_Operation/Audio/src/Players/UnixPlayerBase.cs

    ### Language
    cs

    ### Coverage
    90.3% (Line: 92.7%, Branch: 82.6%)

    ### Uncovered Lines
    11

    ### Uncovered Branches
    8

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
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyConfiguration.cs

    ### Language
    cs

    ### Coverage
    90.8% (Line: 92.2%, Branch: 82.1%)

    ### Uncovered Lines
    14

    ### Uncovered Branches
    5

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
    LOW (NEW)

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
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/ComponentRegistry.cs

    ### Language
    cs

    ### Coverage
    93.4% (Line: 94.1%, Branch: 91.7%)

    ### Uncovered Lines
    7

    ### Uncovered Branches
    4

    ### Method
    ComponentRegistry

    ### Complexity / LOC
    32 / 157 lines

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

        /// <summary>
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
    pabllopf-official_alis:1_Presentation/Extension/Payment/Stripe/src/StripeGatewayClient.cs

    ### Language
    cs

    ### Coverage
    94.6% (Line: 94.2%, Branch: 95.8%)

    ### Uncovered Lines
    9

    ### Uncovered Branches
    2

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
    LOW (NEW)

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
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Internal/WebSocketFrameReader.cs

    ### Language
    cs

    ### Coverage
    96.2% (Line: 95.6%, Branch: 100.0%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    0

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
    pabllopf-official_alis:4_Operation/Graphic/src/Platforms/Web/WebAssemblyInputManager.cs

    ### Language
    cs

    ### Coverage
    96.3% (Line: 97.4%, Branch: 95.1%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    8

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
    LOW (NEW)

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
    pabllopf-official_alis:6_Ideation/Memory/src/AssetRegistry.cs

    ### Language
    cs

    ### Coverage
    96.5% (Line: 97.4%, Branch: 94.1%)

    ### Uncovered Lines
    7

    ### Uncovered Branches
    6

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
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/CommandBuffer.cs

    ### Language
    cs

    ### Coverage
    96.8% (Line: 96.7%, Branch: 97.4%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    1

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
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/WorldPhysic.cs

    ### Language
    cs

    ### Coverage
    97.1% (Line: 97.5%, Branch: 95.6%)

    ### Uncovered Lines
    23

    ### Uncovered Branches
    13

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
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Island.cs

    ### Language
    cs

    ### Coverage
    97.2% (Line: 97.5%, Branch: 96.1%)

    ### Uncovered Lines
    10

    ### Uncovered Branches
    4

    ### Method
    Island

    ### Complexity / LOC
    86 / 457 lines

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
    pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/YuPengClipper.cs

    ### Language
    cs

    ### Coverage
    97.6% (Line: 97.7%, Branch: 97.3%)

    ### Uncovered Lines
    7

    ### Uncovered Branches
    3

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
    pabllopf-official_alis:4_Operation/Ecs/src/Scene.cs

    ### Language
    cs

    ### Coverage
    97.9% (Line: 99.4%, Branch: 91.8%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    21

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
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Client/NetworkClientManager.cs

    ### Language
    cs

    ### Coverage
    97.9% (Line: 98.6%, Branch: 95.6%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    3

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
    98.0% (Line: 99.1%, Branch: 93.1%)

    ### Uncovered Lines
    6

    ### Uncovered Branches
    9

    ### Method
    ContactSolver

    ### Complexity / LOC
    94 / 723 lines

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
    pabllopf-official_alis:4_Operation/Physic/src/Common/PolygonManipulation/SimpleCombiner.cs

    ### Language
    cs

    ### Coverage
    98.1% (Line: 98.4%, Branch: 97.4%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    2

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
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Color.cs

    ### Language
    cs

    ### Coverage
    98.2% (Line: 100.0%, Branch: 87.5%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

    ### Method
    Color

    ### Complexity / LOC
    18 / 64 lines

    ### Source Code
    ```csharp
    // --------------------------------------------------------------------------
// 
//                               ââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
//                              âââââ âââââ âââ ââââââ
// 
//  --------------------------------------------------------------------------
//  File:Color.cs
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
    ///     Utility class for manipulating 32-bits RGBA colors
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Color : IEquatable<Color>
    {
        /// <summary>
        ///     Construct the color from its red, green and blue components
        /// </summary>
        /// <param name="red">Red component</param>
        /// <param name="green">Green component</param>
        /// <param name="blue">Blue component</param>
        public Color(byte red, byte green, byte blue) : this(red, green, blue, 255)
        {
        }


        /// <summary>
        ///     Construct the color from its red, green, blue and alpha components
        /// </summary>
        /// <param name="red">Red component</param>
        /// <param name="green">Green component</param>
        /// <param name="blue">Blue component</param>
        /// <param name="alpha">Alpha (transparency) component</param>
        public Color(byte red, byte green, byte blue, byte alpha)
        {
    ```
    
    ### Test File Hint
    pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/test/Render/ColorTests.cs

    Priority
    LOW (NEW)

    AI Execution Instructions
    Generate xUnit test targeting pabllopf-official_alis:1_Presentation/Extension/Graphic/Sfml/src/Render/Color.cs
    Follow Arrange/Act/Assert pattern
    Use real objects first, Moq ONLY if interface/external dependency
    Target: net8.0 (compatible with netstandard2.0 production)
    Commit format: test: coverage Color.cs
    Update ./.memory/coverage/state/coverage-index.md after completion
            
==================================================

    ## COVERAGE TASK

    ### File
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/ContactManager.cs

    ### Language
    cs

    ### Coverage
    98.3% (Line: 98.5%, Branch: 97.9%)

    ### Uncovered Lines
    5

    ### Uncovered Branches
    3

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
    LOW (NEW)

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
    pabllopf-official_alis:1_Presentation/Extension/Network/src/WebSocketClientFactory.cs

    ### Language
    cs

    ### Coverage
    98.4% (Line: 98.1%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

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
    pabllopf-official_alis:1_Presentation/Extension/Cloud/DropBox/src/DropBoxCloudManager.cs

    ### Language
    cs

    ### Coverage
    98.5% (Line: 98.2%, Branch: 100.0%)

    ### Uncovered Lines
    3

    ### Uncovered Branches
    0

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
    LOW (NEW)

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
    pabllopf-official_alis:1_Presentation/Extension/Network/src/Core/WebSocketNetworkTransport.cs

    ### Language
    cs

    ### Coverage
    98.6% (Line: 100.0%, Branch: 94.2%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    3

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
    pabllopf-official_alis:4_Operation/Physic/src/Common/Decomposition/EarclipDecomposer.cs

    ### Language
    cs

    ### Coverage
    98.7% (Line: 99.3%, Branch: 97.1%)

    ### Uncovered Lines
    2

    ### Uncovered Branches
    3

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
    pabllopf-official_alis:4_Operation/Graphic/src/OpenGL/Constructs/GLShaderProgramParam.cs

    ### Language
    cs

    ### Coverage
    99.1% (Line: 100.0%, Branch: 95.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

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
    LOW (NEW)

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
    pabllopf-official_alis:4_Operation/Ecs/src/Kernel/Archetypes/Archetype.cs

    ### Language
    cs

    ### Coverage
    99.2% (Line: 99.4%, Branch: 98.2%)

    ### Uncovered Lines
    4

    ### Uncovered Branches
    2

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
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Contacts/Contact.cs

    ### Language
    cs

    ### Coverage
    99.5% (Line: 100.0%, Branch: 97.4%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

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
    pabllopf-official_alis:4_Operation/Graphic/src/Ui/Font.cs

    ### Language
    cs

    ### Coverage
    99.6% (Line: 100.0%, Branch: 95.0%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

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
    LOW (NEW)

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
    pabllopf-official_alis:4_Operation/Physic/src/Dynamics/Body.cs

    ### Language
    cs

    ### Coverage
    99.7% (Line: 100.0%, Branch: 98.9%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    2

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
    pabllopf-official_alis:4_Operation/Physic/src/Collisions/Shapes/PolygonShape.cs

    ### Language
    cs

    ### Coverage
    99.7% (Line: 100.0%, Branch: 98.7%)

    ### Uncovered Lines
    0

    ### Uncovered Branches
    1

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
