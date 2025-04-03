using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Operations
{
    /// <summary>
    ///     The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;

        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
        }
    }
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;

        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
        }
    }
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
        }
    }
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4, out Span<T5> comp5)
        {
            comp1 = this.Span1;
            comp2 = this.Span2;
            comp3 = this.Span3;
            comp4 = this.Span4;
            comp5 = this.Span5;
        }
    }
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
        /// <summary>
        /// The span 12
        /// </summary>
        public Span<T12> Span12;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
        /// <param name="comp12">The comp 12</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
        /// <summary>
        /// The span 12
        /// </summary>
        public Span<T12> Span12;
        /// <summary>
        /// The span 13
        /// </summary>
        public Span<T13> Span13;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
        /// <param name="comp12">The comp 12</param>
        /// <param name="comp13">The comp 13</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
        /// <summary>
        /// The span 12
        /// </summary>
        public Span<T12> Span12;
        /// <summary>
        /// The span 13
        /// </summary>
        public Span<T13> Span13;
        /// <summary>
        /// The span 14
        /// </summary>
        public Span<T14> Span14;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
        /// <param name="comp12">The comp 12</param>
        /// <param name="comp13">The comp 13</param>
        /// <param name="comp14">The comp 14</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
        /// <summary>
        /// The span 12
        /// </summary>
        public Span<T12> Span12;
        /// <summary>
        /// The span 13
        /// </summary>
        public Span<T13> Span13;
        /// <summary>
        /// The span 14
        /// </summary>
        public Span<T14> Span14;
        /// <summary>
        /// The span 15
        /// </summary>
        public Span<T15> Span15;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
        /// <param name="comp12">The comp 12</param>
        /// <param name="comp13">The comp 13</param>
        /// <param name="comp14">The comp 14</param>
        /// <param name="comp15">The comp 15</param>
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
    
    /// <summary>
    /// The chunk tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T1> Span1;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T2> Span2;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T3> Span3;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T4> Span4;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T5> Span5;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T6> Span6;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T7> Span7;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T8> Span8;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T9> Span9;
        /// <summary>
        /// The span 10
        /// </summary>
        public Span<T10> Span10;
        /// <summary>
        /// The span 11
        /// </summary>
        public Span<T11> Span11;
        /// <summary>
        /// The span 12
        /// </summary>
        public Span<T12> Span12;
        /// <summary>
        /// The span 13
        /// </summary>
        public Span<T13> Span13;
        /// <summary>
        /// The span 14
        /// </summary>
        public Span<T14> Span14;
        /// <summary>
        /// The span 15
        /// </summary>
        public Span<T15> Span15;
        /// <summary>
        /// The span 16
        /// </summary>
        public Span<T16> Span16;
    
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        /// <param name="comp2">The comp</param>
        /// <param name="comp3">The comp</param>
        /// <param name="comp4">The comp</param>
        /// <param name="comp5">The comp</param>
        /// <param name="comp6">The comp</param>
        /// <param name="comp7">The comp</param>
        /// <param name="comp8">The comp</param>
        /// <param name="comp9">The comp</param>
        /// <param name="comp10">The comp 10</param>
        /// <param name="comp11">The comp 11</param>
        /// <param name="comp12">The comp 12</param>
        /// <param name="comp13">The comp 13</param>
        /// <param name="comp14">The comp 14</param>
        /// <param name="comp15">The comp 15</param>
        /// <param name="comp16">The comp 16</param>
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