// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnAfterDraw.cs
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
    ///     Lifecycle hook called once per frame after the rendering <see cref="IOnDraw"/> pass completes.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Use <see cref="IOnAfterDraw"/> for post-render cleanup, overlay drawing,
    ///     or UI elements that must appear on top of the scene. This hook fires after
    ///     all <see cref="IOnDraw"/> implementations have completed.
    ///     </para>
    ///     <para>
    ///     Drawing commands issued here are typically rendered on top of the scene's
    ///     main visual layer.
    ///     </para>
    /// </remarks>
    public interface IOnAfterDraw
    {
        /// <summary>
        ///     Called every frame after <see cref="IOnDraw.OnDraw" /> hooks finish executing.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnAfterDraw(IGameObject self);
    }
}