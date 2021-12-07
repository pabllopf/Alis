// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Filter.cs
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

using Alis.Core.Systems.Physics2D.Config;

namespace Alis.Core.Systems.Physics2D.Collision.Filtering
{
    /// <summary>
    ///     The filter class
    /// </summary>
    public class Filter
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Filter" /> class
        /// </summary>
        public Filter()
        {
            Group = Settings.DefaultCollisionGroup;
            Category = Settings.DefaultFixtureCollisionCategories;
            CategoryMask = Settings.DefaultFixtureCollidesWith;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Filter" /> class
        /// </summary>
        /// <param name="group">The group</param>
        /// <param name="category">The category</param>
        /// <param name="mask">The mask</param>
        public Filter(short group, Category category, Category mask)
        {
            Group = group;
            Category = category;
            CategoryMask = mask;
        }

        /// <summary>
        ///     Collision groups allow a certain group of objects to never collide(negative) or always collide (positive).
        ///     Zero means no collision group. Non-zero group filtering always wins against the mask bits.
        /// </summary>
        public short Group { get; set; }

        /// <summary>The collision category bits. Normally you would just set one bit.</summary>
        public Category Category { get; set; }

        /// <summary>The collision mask bits. This states the categories that this shape would accept for collision.</summary>
        public Category CategoryMask { get; set; }
    }
}