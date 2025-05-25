using System;
using System.Runtime.InteropServices;
using Alis;

using Alis.Core.Ecs.Components;

namespace Alis.Core.Ecs.Test.Helpers
{
    /// <summary>
    /// The class class
    /// </summary>
    public class Class1;
    /// <summary>
    /// The class class
    /// </summary>
    public class Class2;
    /// <summary>
    /// The class class
    /// </summary>
    public class Class3;
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Struct1(int Value);
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Struct2(int Value);
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
public record struct Struct3(int Value);

    /// <summary>
    /// The delegate behavior class
    /// </summary>
    /// <seealso cref="IComponent"/>
    public class DelegateBehavior(Action onUpdate) : IComponent
    {
        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update() => onUpdate();
    }

    /// <summary>
    /// The filtered behavior class
    /// </summary>
    /// <seealso cref="IComponent"/>
    /// <seealso cref="IInitable"/>
    /// <seealso cref="IDestroyable"/>
    public class FilteredBehavior1(Action onUpdate, Action<GameObject> onInit = null, Action onDestroy = null) : IComponent, IInitable, IDestroyable
    {
        /// <summary>
        /// Inits the self
        /// </summary>
        /// <param name="self">The self</param>
        public void Init(GameObject self) => onInit?.Invoke(self);
        /// <summary>
        /// Destroys this instance
        /// </summary>
        public void Destroy() => onDestroy?.Invoke();
        /// <summary>
        /// Updates this instance
        /// </summary>
        [FilterAttribute1]
        public void Update() => onUpdate();
    }

    /// <summary>
    /// The filtered behavior class
    /// </summary>
    /// <seealso cref="IComponent"/>
    public class FilteredBehavior2(Action onUpdate) : IComponent
    {
        /// <summary>
        /// Updates this instance
        /// </summary>
        [FilterAttribute2]
        public void Update() => onUpdate();
    }

    /// <summary>
    /// The child class
    /// </summary>
    /// <seealso cref="BaseClass"/>
    public class ChildClass : BaseClass;
    /// <summary>
    /// The base class
    /// </summary>
    public class BaseClass;

    /// <summary>
    /// The generic component
    /// </summary>
    partial struct GenericComponent<T>() : IComponent
    {
        /// <summary>
        /// The 
        /// </summary>
        public static readonly int x;

        /// <summary>
        /// The value
        /// </summary>
        public T Value;
        /// <summary>
        /// The called count
        /// </summary>
        public int CalledCount;
        /// <summary>
        /// Updates this instance
        /// </summary>
        public void Update() => CalledCount++;
    }
}