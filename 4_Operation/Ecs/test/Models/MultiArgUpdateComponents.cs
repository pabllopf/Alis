using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    /// <summary>
    /// The update comp
    /// </summary>
    internal struct UpdateComp6(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>
    {
        /// <summary>
        /// The val
        /// </summary>
        public int Value = val;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6) { }
    }

    /// <summary>
    /// The update comp
    /// </summary>
    internal struct UpdateComp7(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>
    {
        /// <summary>
        /// The val
        /// </summary>
        public int Value = val;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7) { }
    }

    /// <summary>
    /// The update comp
    /// </summary>
    internal struct UpdateComp8(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor, Position>
    {
        /// <summary>
        /// The val
        /// </summary>
        public int Value = val;
        /// <summary>
        /// Updates the self
        /// </summary>
        /// <param name="self">The self</param>
        /// <param name="arg1">The arg</param>
        /// <param name="arg2">The arg</param>
        /// <param name="arg3">The arg</param>
        /// <param name="arg4">The arg</param>
        /// <param name="arg5">The arg</param>
        /// <param name="arg6">The arg</param>
        /// <param name="arg7">The arg</param>
        /// <param name="arg8">The arg</param>
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7, ref Position arg8) { }
    }
}
