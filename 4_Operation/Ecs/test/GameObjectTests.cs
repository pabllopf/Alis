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
                    /// <summary>
                    /// Tests that ctor creates null
                    /// </summary>
                    [Fact]
                    public void Ctor_CreatesNull()
                    {
                        Assert.Equal(GameObject.Null, new GameObject());
                        Assert.Equal(default(GameObject), new GameObject());
                    }
            
                    /// <summary>
                    /// Tests that on component added generic invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on component removed generic invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on component added invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on component removed invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on tagged invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on detach invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that on delete invoked
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that world is world
                    /// </summary>
                    [Fact]
                    public void World_IsWorld()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        Assert.Equal(scene, e.Scene);
                    }
            
                    /// <summary>
                    /// Tests that add as adds as
                    /// </summary>
                    [Fact]
                    public void AddAs_AddsAs()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        e.AddAs(Component<BaseClass>.Id, new ChildClass());
            
                        Assert.Equal(typeof(ChildClass), e.Get<BaseClass>().GetType());
                        Assert.Throws<InvalidCastException>(() => e.AddAs(Component<ChildClass>.Id, new BaseClass()));
                    }
            
                    /// <summary>
                    /// Tests that add default type
                    /// </summary>
                    [Fact]
                    public void Add_DefaultType()
                    {
                        using Scene scene = new();
                        var e = scene.Create();
                        e.AddBoxed((object)1);
            
                        Assert.True(e.Has<int>());
                        Assert.Equal(1, e.Get<int>());
                    }
            
                    /// <summary>
                    /// Tests that add as type adds as type
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that delete no longer is alive
                    /// </summary>
                    [Fact]
                    public void Delete_NoLongerIsAlive()
                    {
                        using Scene scene = new();
                        var e = scene.Create(new Struct1(), new Struct2(), new Struct3());
            
                        Assert.True(e.IsAlive);
                        e.Delete();
                        Assert.False(e.IsAlive);
                    }
            
                    /// <summary>
                    /// Tests that detach removes tag
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that tag adds tag
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that enumerate components iterates all components
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that get generic returns reference
                    /// </summary>
                    [Fact]
                    public void GetGeneric_ReturnsReference()
                    {
                        using Scene scene = new();
                        var e = scene.Create(10, new Struct1(), new Struct2(), new Class1());
            
                        Assert.Equal(10, e.Get<int>());
            
                        e.Get<int>() = 20;
            
                        Assert.Equal(20, e.Get<int>());
                    }
            
                    /// <summary>
                    /// Tests that get returns component
                    /// </summary>
                    [Fact]
                    public void Get_ReturnsComponent()
                    {
                        using Scene scene = new();
                        var e = scene.Create(10, new Struct1(), new Struct2(), new Class1());
            
                        Assert.Equal(10, e.Get(typeof(int)));
                        Assert.Equal(10, e.Get(Component<int>.Id));
                    }
            
                    /// <summary>
                    /// Tests that has returns true if has component
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that remove removes component
                    /// </summary>
                    [Fact]
                    public void Remove_RemovesComponent()
                    {
                        using Scene scene = new();
                        var e = scene.Create(new Struct1(), new Struct2(), new Struct3());
            
                        e.Remove<Struct1>();
                        e.Remove(Component<Struct2>.Id);
            
                        Assert.Equal(1, e.ComponentTypes.Length);
                    }
            
                    /// <summary>
                    /// Tests that remove many retain value
                    /// </summary>
                    [Fact]
                    public void RemoveMany_RetainValue()
                    {
                        using Scene scene = new();
                        var e = scene.Create(69, 42.0, new Struct1(), new Struct2(), new Struct3());
            
                        e.Remove<int, Struct1, Struct2, Struct3>();
            
                        Assert.Equal(42.0, e.Get<double>());
                        Assert.Equal(1, e.ComponentTypes.Length);
                    }
            
                    /// <summary>
                    /// Tests that set changes object value
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that tagged checks tag
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that try get returns correct ref
                    /// </summary>
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
            
                    /// <summary>
                    /// Tests that try get doesnt throw
                    /// </summary>
                    [Fact]
                    public void TryGet_DoesntThrow()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
                        e.Delete();
            
                        Assert.False(e.TryGet<Struct1>(out _));
                    }
            
                    /// <summary>
                    /// Tests that try has doesnt throw
                    /// </summary>
                    [Fact]
                    public void TryHas_DoesntThrow()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
                        e.Delete();
            
                        Assert.False(e.TryHas<Struct1>());
                    }
            
                    /// <summary>
                    /// Tests that try has returns true
                    /// </summary>
                    [Fact]
                    public void TryHas_ReturnsTrue()
                    {
                        using Scene scene = new();
            
                        var e = scene.Create(new Struct1(4));
            
                        Assert.True(e.TryHas<Struct1>());
                    }
            
                    /// <summary>
                    /// The generic action class
                    /// </summary>
                    /// <seealso cref="IGenericAction{GameObject}"/>
                    /// <seealso cref="IGenericAction"/>
                    public class GenericAction : IGenericAction<GameObject>, IGenericAction
                    {
                        /// <summary>
                        /// The on action
                        /// </summary>
                        private readonly Action<Type, object> onAction;
            
                        /// <summary>
                        /// Initializes a new instance of the <see cref="GenericAction"/> class
                        /// </summary>
                        /// <param name="onAction">The on action</param>
                        public GenericAction(Action<Type, object> onAction) => this.onAction = onAction;
            
                        /// <summary>
                        /// Invokes the e
                        /// </summary>
                        /// <typeparam name="T">The </typeparam>
                        /// <param name="e">The </param>
                        /// <param name="type">The type</param>
                        public void Invoke<T>(GameObject e, ref T type) => onAction(typeof(T), type);
            
                        /// <summary>
                        /// Invokes the type
                        /// </summary>
                        /// <typeparam name="T">The </typeparam>
                        /// <param name="type">The type</param>
                        public void Invoke<T>(ref T type) => onAction(typeof(T), type);
                    }
                }
            }