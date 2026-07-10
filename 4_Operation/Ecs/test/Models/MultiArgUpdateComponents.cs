using Alis.Core.Aspect.Fluent.Components;

namespace Alis.Core.Ecs.Test.Models
{
    internal struct UpdateComp6(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage>
    {
        public int Value = val;
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6) { }
    }

    internal struct UpdateComp7(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor>
    {
        public int Value = val;
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7) { }
    }

    internal struct UpdateComp8(int val) : IOnUpdate<Velocity, Health, Transform, TestComponent, AnotherComponent, Damage, Armor, Position>
    {
        public int Value = val;
        public void Update(IGameObject self, ref Velocity arg1, ref Health arg2, ref Transform arg3, ref TestComponent arg4, ref AnotherComponent arg5, ref Damage arg6, ref Armor arg7, ref Position arg8) { }
    }
}
