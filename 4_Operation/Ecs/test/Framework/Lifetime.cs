using System;
        using System.Collections.Generic;
        using System.Runtime.InteropServices;
        using Alis.Core.Ecs.Test.Helpers;
        using Alis;
        using Alis.Core.Ecs.Components;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test.Framework
        {
            /// <summary>
            /// The lifetime class
            /// </summary>
            public class Lifetime
            {
                /// <summary>
                /// Tests that destroy called on delete
                /// </summary>
                [Fact]
                public void Destroy_CalledOnDelete()
                {
                    using Scene scene = new();
                    int destroyCount = 0;
        
                    List<GameObject> entities = new List<GameObject>();
        
                    for (int i = 0; i < 10; i++)
                    {
                        var entity = scene.Create<int, float, FilteredBehavior1>(default, default, new FilteredBehavior1(() => { }, null, () => destroyCount++));
                        entities.Add(entity);
                    }
        
                    foreach (var entity in entities)
                    {
                        entity.Delete();
                    }
        
                    Assert.Equal(10, destroyCount);
                }
        
                /// <summary>
                /// Tests that init called when created
                /// </summary>
                [Fact]
                public void Init_CalledWhenCreated()
                {
                    using Scene scene = new();
        
                    for (int i = 0; i < 10; i++)
                    {
                        GameObject e1 = default;
        
                        var entity = scene.Create<int, float, FilteredBehavior1>(default, default, new FilteredBehavior1(() => { }, e => e1 = e));
        
                        Assert.Equal(e1, entity);
                    }
                }
        
               /// <summary>
               /// Tests that lifetime called add remove
               /// </summary>
               [Fact]
               public void LifetimeCalled_AddRemove()
               {
                   using Scene scene = new();
               
                   TestForLifetimeInvocation(scene, (w, c) =>
                   {
                       GameObject e = w.Create();
                       e.Add(c);
                       e.Remove<LifetimeComponent>();
                   });
               }
        
                /// <summary>
                /// Tests that lifetime called create delete
                /// </summary>
                [Fact]
                public void LifetimeCalled_CreateDelete()
                {
                    using Scene scene = new();
        
                    TestForLifetimeInvocation(scene, (w, c) =>
                    {
                        GameObject e = w.Create(c);
                        e.Delete();
                    });
                }
        
                /// <summary>
                /// Tests the for lifetime invocation using the specified scene
                /// </summary>
                /// <param name="scene">The scene</param>
                /// <param name="action">The action</param>
                private void TestForLifetimeInvocation(Scene scene, Action<Scene, LifetimeComponent> action)
                {
                    bool initFlag = false;
                    bool destroyFlag = false;
        
                    action(scene, new LifetimeComponent(e => initFlag = true, e => destroyFlag = true));
        
                    Assert.True(initFlag);
                    Assert.True(destroyFlag);
                }
        
                /// <summary>
                /// The lifetime component
                /// </summary>
                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                public struct LifetimeComponent(Action<GameObject> init, Action<GameObject> destroy) : IInitable, IDestroyable
                {
                    /// <summary>
                    /// The self
                    /// </summary>
                    private GameObject _self;
        
                    /// <summary>
                    /// Inits the self
                    /// </summary>
                    /// <param name="self">The self</param>
                    public void Init(GameObject self) => init?.Invoke(_self = self);
        
                    /// <summary>
                    /// Destroys this instance
                    /// </summary>
                    public void Destroy() => destroy?.Invoke(_self);
                }
            }
        }