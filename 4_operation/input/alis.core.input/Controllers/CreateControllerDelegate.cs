// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CreateControllerDelegate.cs
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

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     Delegate CreateControllerDelegate used to define a method for creating a new <seealso cref="Controller" /> from a
    ///     <seealso cref="Device" />.
    /// </summary>
    /// <typeparam name="T">The controller type.</typeparam>
    /// <param name="device">The device.</param>
    /// <returns>A controller; otherwise <see langword="null" />.</returns>
    /// <seealso cref="Controller" />
    /// <seealso cref="Device" />
    public delegate T CreateControllerDelegate<out T>(Device device) where T : Controller;
}