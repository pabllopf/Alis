// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IComponentBase.cs
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

namespace Alis.Core.Aspect.Fluent
{
    /*  ALL COMPONENT TYPES                                 |Interface|Storage
     *  Arbitary data                                           X       X
     *  Update Only                                             X       X
     *  Update with N components                                X       X
     *  Update with N components + uniform                      X       X
     *  Update with N components + entityid                     X       X
     *  Update with N components + uniform + entityid           X       X
     *  Update with uniform                                     X       X
     *  Update with entityid                                    X       X
     *  Update with uniform + entityid                          X       X
     */

    /// <summary>
    ///     Base marker component for all component interfaces
    /// </summary>
    /// <remarks>
    ///     All components with <see cref="IComponentBase" /> will be auto-registered. This makes it useful for AOT
    ///     compilation scenarios
    /// </remarks>
    public interface IComponentBase;
}