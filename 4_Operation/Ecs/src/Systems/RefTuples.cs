using System;
using Frent.Core;


namespace Frent.Systems;






public ref struct RefTuple<T>
{
    public Ref<T> Item1;
    public void Deconstruct(out Ref<T> @ref)
    {
        @ref = Item1;
    }
}





public ref struct EntityRefTuple<T>
{
    public Entity Entity;
    public Ref<T> Item1;
    public void Deconstruct(out Entity entity, out Ref<T> @ref)
    {
        entity = Entity;
        @ref = Item1;
    }
}





public ref struct ChunkTuple<T>
{
    public EntityEnumerator.EntityEnumerable Entities;
    public Span<T> Span;
    public void Deconstruct(out Span<T> @comp1)
    {
        @comp1 = Span;
    }
}