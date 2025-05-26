using System;
            using System.Collections.Generic;
            using System.Linq;
            using Alis.Core.Ecs.Test.Helpers;
            using Alis;
            using Alis.Core;
            using Alis.Core.Ecs.Core;
            using Alis.Core.Ecs.Core.Events;
            using Xunit;
            
            namespace Alis.Core.Ecs.Test
            {
    /// <summary>
    /// The gameObject tests class
    /// </summary>
    public class GameObjectTests
                {
                    [Fact]
                    public void Ctor_CreatesNull()
                    {
                        Assert.Equal(GameObject.Null, new GameObject());
                        Assert.Equal(default(GameObject), new GameObject());
                    }
            
                    [Fact]
                    public void OnComponentAddedGeneric_Invoked()
                    {
                        using Scene scene = new();
            
                        var entity = scene.Create();
                        bool passed = false;
            
                        entity.OnComponentAddedGeneric += new GenericAction((t, o) =>
                        {
                            Assert.Equal(1, o);
                            if (t == typeof(int))
                                passed = true;
                        });
            
                        entity.Add(1);
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnComponentRemovedGeneric_Invoked()
                    {
                        using Scene scene = new();
            
                        var entity = scene.Create(1);
                        bool passed = false;
            
                        entity.OnComponentRemovedGeneric += new GenericAction((t, o) =>
                        {
                            Assert.Equal(1, o);
                            if (t == typeof(int))
                                passed = true;
                        });
            
                        entity.Remove<int>();
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnComponentAdded_Invoked()
                    {
                        using Scene scene = new();
            
                        var entity = scene.Create();
                        bool passed = false;
            
                        entity.OnComponentAdded += (t, o) =>
                        {
                            Assert.Equal(1, t.Get<int>());
                            if (o.Type == typeof(int))
                                passed = true;
                        };
            
                        entity.Add(1);
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnComponentRemoved_Invoked()
                    {
                        using Scene scene = new();
            
                        var entity = scene.Create(1);
                        bool passed = false;
            
                        entity.OnComponentRemoved += (t, o) =>
                        {
                            if (o.Type == typeof(int))
                                passed = true;
                        };
            
                        entity.Remove<int>();
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnTagged_Invoked()
                    {
                        using Scene scene = new();
                        var entity = scene.Create(1);
                        bool passed = false;
            
                        entity.OnTagged += (a, b) => passed = true;
                        entity.Tag<int>();
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnDetach_Invoked()
                    {
                        using Scene scene = new();
                        var entity = scene.Create(1);
                        bool passed = false;
            
                        entity.OnDetach += (a, b) => passed = true;
                        entity.Tag<int>();
                        entity.Detach<int>();
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void OnDelete_Invoked()
                    {
                        using Scene scene = new();
                        var entity = scene.Create(1);
                        bool passed = false;
            
                        entity.OnDelete += (a) => passed = true;
                        entity.Delete();
                        Assert.True(passed);
                    }
            
                    [Fact]
                    public void World_IsWorld()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        Assert.Equal(scene, e.Scene);
                    }
            
                    [Fact]
                    public void AddAs_AddsAs()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        e.AddAs(Component<BaseClass>.Id, new ChildClass());
            
                        Assert.Equal(typeof(ChildClass), e.Get<BaseClass>().GetType());
                        Assert.Throws<InvalidCastException>(() => e.AddAs(Component<ChildClass>.Id, new BaseClass()));
                    }
            
                    [Fact]
                    public void Add_DefaultType()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        e.AddBoxed((object)1);
            
                        Assert.True(e.Has<int>());
                        Assert.Equal(1, e.Get<int>());
                    }
            
                    [Fact]
                    public void AddAsType_AddsAsType()
                    {
                        Component.RegisterComponent<BaseClass>();
                        Component.RegisterComponent<ChildClass>();
                        Component.RegisterComponent<Class1>();
            
                        using Scene scene = new();
                        var e = scene.Create();
                        e.Add(typeof(ChildClass), new ChildClass());
            
                        Assert.Equal(typeof(ChildClass), e.Get<ChildClass>().GetType());
                        Assert.Throws<InvalidCastException>(() => e.AddAs(typeof(Class1), new Class2()));
                    }
            
                    [Fact]
                    public void Delete_NoLongerIsAlive()
                    {
                        using Scene scene = new();
                        var e = scene.Create(new Struct1(), new Struct2(), new Struct3());
            
                        Assert.True(e.IsAlive);
                        e.Delete();
                        Assert.False(e.IsAlive);
                    }
            
                    [Fact]
                    public void Detach_RemovesTag()
                    {
                        using Scene scene = new();
                        var e = scene.Create(0, 0.0, "0");
                        e.Tag<Struct1>();
                        e.Tag<Struct2>();
                        e.Tag<Struct3>();
            
                        e.Detach<Struct1>();
                        e.Detach<Struct2>();
                        e.Detach<Struct3>();
            
                        Assert.Empty(e.TagTypes);
                    }
            
                    [Fact]
                    public void Tag_AddsTag()
                    {
                        using Scene scene = new();
                        var e = scene.Create(0, 0.0, "0");
                        e.Tag<Struct1>();
                        e.Tag<Struct2>();
                        e.Tag<Struct3>();
            
                        Assert.Equal(3, e.TagTypes.Length);
                        Assert.Contains(Tag<Struct1>.Id, e.TagTypes);
                        Assert.Contains(Tag<Struct2>.Id, e.TagTypes);
                        Assert.Contains(Tag<Struct3>.Id, e.TagTypes);
                    }
            
                    [Fact]
                    public void EnumerateComponents_IteratesAllComponents()
                    {
                        using Scene scene = new();
                        var e = scene.Create(new Struct1(), new Struct2(), new Struct3());
            
                        List<Type> types = new();
                        e.EnumerateComponents(new GenericAction((t, o) => types.Add(t)));
            
                        Assert.Equal(new[] { typeof(Struct1), typeof(Struct2), typeof(Struct3) }, types);
                        Assert.Equal(e.ComponentTypes.Select(t => t.Type), types);
                    }
            
                    [Fact]
                    public void GetGeneric_ReturnsReference()
                    {
                        using Scene scene = new();
                        var e = scene.Create(10, new Struct1(), new Struct2(), new Class1());
            
                        Assert.Equal(10, e.Get<int>());
            
                        e.Get<int>() = 20;
            
                        Assert.Equal(20, e.Get<int>());
                    }
            
                    [Fact]
                    public void Get_ReturnsComponent()
                    {
                        using Scene scene = new();
                        var e = scene.Create(10, new Struct1(), new Struct2(), new Class1());
            
                        Assert.Equal(10, e.Get(typeof(int)));
                        Assert.Equal(10, e.Get(Component<int>.Id));
                    }
            
                    [Fact]
                    public void Has_ReturnsTrueIfHasComponent()
                    {
                        using Scene scene = new();
                        var e = scene.Create(10, new Struct1(), new Struct2(), new Class1());
            
                        Assert.True(e.Has(typeof(int)));
                        Assert.True(e.Has(Component<int>.Id));
            
                        Assert.False(e.Has(typeof(double)));
                        Assert.False(e.Has(Component<double>.Id));
            
                        Assert.True(e.Has<Struct1>());
                        Assert.True(e.Has<Struct2>());
                        Assert.True(e.Has<Class1>());
                    }
            
                    [Fact]
                    public void Remove_RemovesComponent()
                    {
                        using Scene scene = new();
                        var e = scene.Create(new Struct1(), new Struct2(), new Struct3());
            
                        e.Remove<Struct1>();
                        e.Remove(Component<Struct2>.Id);
            
                        Assert.Equal(1, e.ComponentTypes.Length);
                    }
            
                    [Fact]
                    public void RemoveMany_RetainValue()
                    {
                        using Scene scene = new();
                        var e = scene.Create(69, 42.0, new Struct1(), new Struct2(), new Struct3());
            
                        e.Remove<int, Struct1, Struct2, Struct3>();
            
                        Assert.Equal(42.0, e.Get<double>());
                        Assert.Equal(1, e.ComponentTypes.Length);
                    }
            
                    [Fact]
                    public void Set_ChangesObjectValue()
                    {
                        using Scene scene = new();
                        var e = scene.Create(-1, new Struct1(-2));
            
                        Assert.Equal(-1, e.Get<int>());
                        Assert.Equal(-2, e.Get<Struct1>().Value);
            
                        e.Set(Component<int>.Id, 1);
                        Assert.Equal(1, e.Get<int>());
            
                        e.Set(typeof(Struct1), new Struct1(1));
                        Assert.Equal(1, e.Get<Struct1>().Value);
                    }
            
                    [Fact]
                    public void Tagged_ChecksTag()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        e.Tag<Struct1>();
            
                        Assert.False(e.Tagged<int>());
                        e.Tag<int>();
                        Assert.True(e.Tagged<int>());
                        Assert.True(e.Tagged(Tag<Struct1>.Id));
                    }
            
                    /// <summary>
                    /// Tests that try get returns false no component
                    /// </summary>
                    [Fact]
                    public void TryGet_ReturnsFalseNoComponent()
                    {
                        using Scene scene = new();
                    
                        var e = scene.Create(new Struct1(1));
                    
                        Assert.False(e.TryGet<int>(out var value));
                    }
            
                    [Fact]
                    public void TryGet_ReturnsCorrectRef()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(3));
            
                        Assert.True(e.TryGet<Struct1>(out var value));
                        Assert.Equal(3, value.Value.Value);
                        value.Value.Value = 1;
            
                        Assert.Equal(1, e.Get<Struct1>().Value);
                    }
            
                    [Fact]
                    public void TryGet_DoesntThrow()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
                        e.Delete();
            
                        Assert.False(e.TryGet<Struct1>(out _));
                    }
            
                    [Fact]
                    public void TryHas_DoesntThrow()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
                        e.Delete();
            
                        Assert.False(e.TryHas<Struct1>());
                    }
            
                    [Fact]
                    public void TryHas_ReturnsTrue()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
            
                        Assert.True(e.TryHas<Struct1>());
                    }
            
                    public class GenericAction : IGenericAction<GameObject>, IGenericAction
                    {
                        private readonly Action<Type, object?> onAction;
            
                        public GenericAction(Action<Type, object?> onAction) => this.onAction = onAction;
            
                        public void Invoke<T>(GameObject e, ref T type) => onAction(typeof(T), type);
            
                        public void Invoke<T>(ref T type) => onAction(typeof(T), type);
                    }
                }
            }