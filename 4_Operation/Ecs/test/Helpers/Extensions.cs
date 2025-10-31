// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Extensions.cs
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
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Systems;
using Xunit;

namespace Alis.Core.Ecs.Test.Helpers
{
    /// <summary>
    ///     The extensions class
    /// </summary>
    internal static class Extensions
    {
        /// <summary>
        ///     Entities the count using the specified query
        /// </summary>
        /// <param name="query">The query</param>
        /// <returns>The count</returns>
        public static int EntityCount(this Query query)
        {
            int count = 0;
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                count++;
            }

            return count;
        }

        /// <summary>
        ///     Asserts the entities not default using the specified query
        /// </summary>
        /// <param name="query">The query</param>
        public static void AssertEntitiesNotDefault(this Query query)
        {
            foreach (GameObject entity in query.EnumerateWithEntities())
            {
                foreach (ComponentId component in entity.ComponentTypes)
                {
                    AssertNotDefault(entity.Get(component));
                }
            }

            static void AssertNotDefault(object value)
            {
                Type type = value.GetType();
                if (type.IsValueType)
                {
                    Assert.NotEqual(Activator.CreateInstance(type), value);
                }
                else
                {
                    Assert.NotNull(value);
                }
            }
        }
    }
}