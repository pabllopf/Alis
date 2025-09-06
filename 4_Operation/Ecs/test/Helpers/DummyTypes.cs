// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DummyTypes.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Helpers
{
    /// <summary>
    ///     The class class
    /// </summary>
    public class Class1;

    /// <summary>
    ///     The class class
    /// </summary>
    public class Class2;

    /// <summary>
    ///     The class class
    /// </summary>
    public class Class3;

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct Struct1(int Value);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct Struct2(int Value);

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct Struct3(int Value);

    /// <summary>
    ///     The delegate behavior class
    /// </summary>
    /// <seealso cref="IComponent" />
    public class DelegateBehavior(Action onUpdate) : IComponent
    {
        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update() => onUpdate();
    }

    /// <summary>
    ///     The filtered behavior class
    /// </summary>
    /// <seealso cref="IComponent" />
    /// <seealso cref="IInitable" />
    /// <seealso cref="IDestroyable" />
    public class FilteredBehavior1(Action onUpdate, Action<IGameObject> onInit = null, Action onDestroy = null) : IComponent, IInitable, IDestroyable
    {
        /// <summary>
        ///     Updates this instance
        /// </summary>
        [FilterAttribute1]
        public void Update() => onUpdate();

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy() => onDestroy?.Invoke();

        /// <summary>
        ///     Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(IGameObject self) => onInit?.Invoke(self);
    }

    /// <summary>
    ///     The filtered behavior class
    /// </summary>
    /// <seealso cref="IComponent" />
    public class FilteredBehavior2(Action onUpdate) : IComponent
    {
        /// <summary>
        ///     Updates this instance
        /// </summary>
        [FilterAttribute2]
        public void Update() => onUpdate();
    }

    /// <summary>
    ///     The child class
    /// </summary>
    /// <seealso cref="BaseClass" />
    public class ChildClass : BaseClass;

    /// <summary>
    ///     The base class
    /// </summary>
    public class BaseClass;

    /// <summary>
    ///     The generic component
    /// </summary>
    internal partial struct GenericComponent<T> : IComponent
    {
        /// <summary>
        ///     The
        /// </summary>
        public static readonly int x;

        /// <summary>
        ///     The value
        /// </summary>
        public T Value;

        /// <summary>
        ///     The called count
        /// </summary>
        public int CalledCount;

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update() => CalledCount++;
    }
}