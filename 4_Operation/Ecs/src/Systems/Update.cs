// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Update.cs
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

using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The update class
    /// </summary>
    /// <seealso cref="ComponentStorage{TComp}" />
    public class Update<TComp, TArg1>(int cap)
        : ComponentStorage<TComp>(cap)
        where TComp : IComponent<TArg1>
    {
        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Scene scene, Archetype b)
        {
            ref TComp comp = ref GetComponentStorageDataReference();

            ref TArg1 arg1 = ref b.GetComponentDataReference<TArg1>();

            for (int i = b.EntityCount - 1; i >= 0; i--)
            {
                comp.Update(ref arg1);

                comp = ref Unsafe.Add(ref comp, 1);

                arg1 = ref Unsafe.Add(ref arg1, 1);
            }
        }

        /// <summary>
        ///     Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Scene scene, Archetype b, int start, int length)
        {
            ref TComp comp = ref Unsafe.Add(ref GetComponentStorageDataReference(), start);

            ref TArg1 arg1 = ref Unsafe.Add(ref b.GetComponentDataReference<TArg1>(), start); ;


            for (int i = length - 1; i >= 0; i--)
            {
                comp.Update(ref arg1);

                comp = ref Unsafe.Add(ref comp, 1);
                arg1 = ref Unsafe.Add(ref arg1, 1);
            }
        }
    }
}