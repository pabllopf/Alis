// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StartupHook.cs
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

/// <summary>
///     Runtime startup hook invoked by the .NET runtime on the main thread before the entry point when
///     <c>DOTNET_STARTUP_HOOKS</c> points at this assembly and <c>ALIS_GRAPHICMANAGER_HOOK=1</c> is set.
/// </summary>
public static class StartupHook
{
    /// <summary>
    ///     Initializes the GraphicManager bootstrap on the main thread.
    /// </summary>
    public static void Initialize()
    {
        try
        {
            if (Environment.GetEnvironmentVariable("ALIS_GRAPHICMANAGER_HOOK") == "1")
            {
                Alis.Test.GraphicManagerBootstrap.Initialize();
            }
        }
        catch (Exception)
        {
        }
    }
}
