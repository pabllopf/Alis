// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnBeforeDraw.cs
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

namespace Alis.Core.Aspect.Fluent.Components
{
    /// <summary>
    ///     Lifecycle hook called once per frame before the rendering <see cref="IOnDraw"/> pass begins.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     <see cref="IOnBeforeDraw"/> is the ideal place for preparing transform matrices,
    ///     performing visibility culling, sorting draw calls, or setting up rendering state
    ///     before any draw hooks execute.
    ///     </para>
    ///     <para>
    ///     This hook fires after <see cref="IOnAfterUpdate"/> but before <see cref="IOnDraw"/>,
    ///     giving it a window to influence how the frame is rendered without being part
    ///     of the actual drawing commands.
    ///     </para>
    /// </remarks>
    public interface IOnBeforeDraw
    {
        /// <summary>
        ///     Called every frame before <see cref="IOnDraw.OnDraw" /> hooks execute.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnBeforeDraw(IGameObject self);
    }
}