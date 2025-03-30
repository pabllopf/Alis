// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SkipLocalsInit.cs
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

#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)

namespace System.Runtime.CompilerServices
{
    /// <summary>
    ///     Used to indicate to the compiler that the <c>.locals init</c>
    ///     flag should not be set in method headers.
    /// </summary>
    /// <remarks>
    ///     This attribute is unsafe because it may reveal uninitialized memory to
    ///     the application in certain instances (e.g., reading from uninitialized
    ///     stackalloc'd memory). If applied to a method directly, the attribute
    ///     applies to that method and all nested functions (lambdas, local
    ///     functions) below it. If applied to a type or module, it applies to all
    ///     methods nested inside. This attribute is intentionally not permitted on
    ///     assemblies. Use at the module level instead to apply to multiple type
    ///     declarations.
    /// </remarks>
    [AttributeUsage(AttributeTargets.Module
                    | AttributeTargets.Class
                    | AttributeTargets.Struct
                    | AttributeTargets.Interface
                    | AttributeTargets.Constructor
                    | AttributeTargets.Method
                    | AttributeTargets.Property
                    | AttributeTargets.Event, Inherited = false)]
    public sealed class SkipLocalsInitAttribute : Attribute
    {
    }
}
#endif