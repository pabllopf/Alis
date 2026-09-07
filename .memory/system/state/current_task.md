
[INFO] Found 1 coverage targets. (limited to 1 files) (skipped first 152 files) Outputting AI-ready tasks:


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
