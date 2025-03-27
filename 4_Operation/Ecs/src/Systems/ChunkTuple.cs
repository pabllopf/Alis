using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;

        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;

        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
        public Span<T12> Span12;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11, out Span<T12> comp12)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
            comp12 = this.Span12;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
        public Span<T12> Span12;
        public Span<T13> Span13;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11, out Span<T12> comp12, out Span<T13> comp13)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
            comp12 = this.Span12;
            comp13 = this.Span13;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
        public Span<T12> Span12;
        public Span<T13> Span13;
        public Span<T14> Span14;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11, out Span<T12> comp12, out Span<T13> comp13, out Span<T14> comp14)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
            comp12 = this.Span12;
            comp13 = this.Span13;
            comp14 = this.Span14;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
        public Span<T12> Span12;
        public Span<T13> Span13;
        public Span<T14> Span14;
        public Span<T15> Span15;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11, out Span<T12> comp12, out Span<T13> comp13, out Span<T14> comp14, out Span<T15> comp15)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
            comp12 = this.Span12;
            comp13 = this.Span13;
            comp14 = this.Span14;
            comp15 = this.Span15;
        }
    }
    
    [StructLayout(LayoutKind.Sequential)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;
        public Span<T3> Span3;
        public Span<T4> Span4;
        public Span<T5> Span5;
        public Span<T6> Span6;
        public Span<T7> Span7;
        public Span<T8> Span8;
        public Span<T9> Span9;
        public Span<T10> Span10;
        public Span<T11> Span11;
        public Span<T12> Span12;
        public Span<T13> Span13;
        public Span<T14> Span14;
        public Span<T15> Span15;
        public Span<T16> Span16;
    
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5, out Span<T6> comp6, out Span<T7> comp7, out Span<T8> comp8, out Span<T9> comp9, out Span<T10> comp10, out Span<T11> comp11, out Span<T12> comp12, out Span<T13> comp13, out Span<T14> comp14, out Span<T15> comp15, out Span<T16> comp16)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
            comp6 = this.Span6;
            comp7 = this.Span7;
            comp8 = this.Span8;
            comp9 = this.Span9;
            comp10 = this.Span10;
            comp11 = this.Span11;
            comp12 = this.Span12;
            comp13 = this.Span13;
            comp14 = this.Span14;
            comp15 = this.Span15;
            comp16 = this.Span16;
        }
    }
}