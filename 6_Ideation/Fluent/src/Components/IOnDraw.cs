// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IOnDraw.cs
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
    ///     Lifecycle hook called every frame during the rendering pass.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///     Components implementing <see cref="IOnDraw"/> are responsible for drawing their
    ///     visual representation. This fires after all <see cref="IOnBeforeDraw"/> hooks
    ///     and before <see cref="IOnAfterDraw"/> hooks, within the render pipeline.
    ///     </para>
    ///     <para>
    ///     Drawing commands issued here should be limited to the owning entity's own visual.
    ///     For batch rendering or sprite sorting, consider using a system-based approach instead.
    ///     </para>
    /// </remarks>
    public interface IOnDraw
    {
        /// <summary>
        ///     Called every frame during the rendering pass with a reference to the owning entity.
        /// </summary>
        /// <param name="self">The entity that owns this component.</param>
        void OnDraw(IGameObject self);
    }
}