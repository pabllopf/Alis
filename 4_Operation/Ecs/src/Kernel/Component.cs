// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Component.cs
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
using System.Collections.Generic;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Used to quickly get the component ID of a given type
    /// </summary>
    /// <typeparam name="T">The type of component</typeparam>
    public static class Component<T>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly ComponentId Id;

        /// <summary>
        ///     The runner instance
        /// </summary>
        private static readonly IComponentStorageBaseFactory<T> RunnerInstance;

        /// <summary>
        ///     The general component storage
        /// </summary>
        internal static readonly IdTable<T> GeneralComponentStorage;

        /// <summary>
        ///     The initer
        /// </summary>
        internal static readonly ComponentDelegates<T>.InitDelegate Initer;

        /// <summary>
        ///     The destroyer
        /// </summary>
        internal static readonly ComponentDelegates<T>.DestroyDelegate Destroyer;

        /// <summary>
        ///     The
        /// </summary>
        internal static readonly bool IsDestroyable = typeof(T).IsValueType
            ? default(T) is IOnDestroy
            : typeof(IOnDestroy).IsAssignableFrom(typeof(T));

        /// <summary>
        ///     Initializes a new instance of the <see cref="Component{T}" /> class
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     {typeof(T).FullName} is not initalized correctly. (Is the source generator
        ///     working?)
        /// </exception>
        static Component()
        {
            (Id, GeneralComponentStorage, Initer, Destroyer) = Component.GetExistingOrSetupNewComponent<T>();

            if (GenerationServices.UserGeneratedTypeMap.TryGetValue(typeof(T),
                    out (IComponentStorageBaseFactory Factory, int UpdateOrder) type))
            {
                if (type.Factory is IComponentStorageBaseFactory<T> casted)
                {
                    RunnerInstance = casted;
                    return;
                }

                throw new InvalidOperationException(
                    $"{typeof(T).FullName} is not initalized correctly. (Is the source generator working?)");
            }

            NoneUpdateRunnerFactory<T> fac = new NoneUpdateRunnerFactory<T>();
            Component.NoneComponentRunnerTable[typeof(T)] = fac;
            RunnerInstance = fac;
        }

        /// <summary>
        ///     Use ComponentHandle.Create instead.
        /// </summary>
        public static ComponentHandle StoreComponent(in T component)
        {
            GeneralComponentStorage.Create(out int index) = component;
            return new ComponentHandle(index, Id);
        }

        /// <summary>
        ///     Creates the instance using the specified cap
        /// </summary>
        /// <param name="cap">The cap</param>
        /// <returns>A component storage of t</returns>
        internal static ComponentStorage<T> CreateInstance(int cap) => RunnerInstance.CreateStronglyTyped(cap);
    }
}
