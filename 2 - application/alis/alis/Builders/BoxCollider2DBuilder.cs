// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BoxCollider2DBuilder.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Components;
using Alis.Core.FluentApi;
using Alis.Core.FluentApi.Words;
using Alis.Core.Systems.Physics2D.Dynamics;

namespace Alis.Core.Builders
{
    /// <summary>
    ///     The box collider builder class
    /// </summary>
    /// <seealso cref="IBuild{TOrigin}" />
    /// <seealso cref="ISize{TBuilder,TArgument1,TArgument2}" />
    /// <seealso cref="IIsTrigger{TBuilder,TArgument}" />
    /// <seealso cref="IIsStatic{BoxCollider2DBuilder, bool}" />
    /// <seealso cref="IIsDynamic{BoxCollider2DBuilder, bool}" />
    /// <seealso cref="IIsActive{BoxCollider2DBuilder, bool}" />
    public class BoxCollider2DBuilder :
        IBuild<BoxCollider2D>,
        ISize<BoxCollider2DBuilder, int, int>,
        IIsTrigger<BoxCollider2DBuilder, bool>,
        IIsStatic<BoxCollider2DBuilder, bool>,
        IIsDynamic<BoxCollider2DBuilder, bool>,
        IIsActive<BoxCollider2DBuilder, bool>
    {
        /// <summary>
        ///     Gets the value of the box collider 2 d
        /// </summary>
        private BoxCollider2D BoxCollider2D { get; } = new BoxCollider2D();

        /// <summary>
        ///     Builds this instance
        /// </summary>
        /// <returns>The box collider</returns>
        public BoxCollider2D Build()
        {
            return BoxCollider2D;
        }

        /// <summary>
        ///     Ises the active
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsActive()
        {
            BoxCollider2D.IsActive = true;
            return this;
        }

        /// <summary>
        ///     Ises the active using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsActive(bool value)
        {
            BoxCollider2D.IsActive = value;
            return this;
        }

        /// <summary>
        ///     Ises the dynamic
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsDynamic()
        {
            BoxCollider2D.BodyType = BodyType.Dynamic;
            return this;
        }

        /// <summary>
        ///     Ises the dynamic using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsDynamic(bool value)
        {
            if (value)
            {
                BoxCollider2D.BodyType = BodyType.Dynamic;
            }

            return this;
        }

        /// <summary>
        ///     Ises the static
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsStatic()
        {
            BoxCollider2D.IsStatic = true;
            BoxCollider2D.BodyType = BodyType.Static;
            return this;
        }

        /// <summary>
        ///     Ises the static using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsStatic(bool value)
        {
            BoxCollider2D.IsStatic = value;
            if (value)
            {
                BoxCollider2D.BodyType = BodyType.Static;
            }

            return this;
        }

        /// <summary>
        ///     Ises the trigger
        /// </summary>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsTrigger()
        {
            BoxCollider2D.IsTrigger = true;
            return this;
        }

        /// <summary>
        ///     Ises the trigger using the specified value
        /// </summary>
        /// <param name="value">The value</param>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder IsTrigger(bool value)
        {
            BoxCollider2D.IsTrigger = value;
            return this;
        }


        /// <summary>
        ///     Sizes the x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The box collider builder</returns>
        public BoxCollider2DBuilder Size(int x, int y)
        {
            //BoxCollider2D.Size = new Vector2(x, y);
            return this;
        }
    }
}