using System;
        using System.Collections.Generic;
        using System.Runtime.InteropServices;
        using Alis.Core.Ecs.Test.Helpers;
        using Alis;
        using Alis.Core.Aspect.Fluent.Components;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test.Framework
        {
            /// <summary>
            /// The lifetime class
            /// </summary>
            public class Lifetime
            {
                // Delegados reutilizables para los tests
                /// <summary>
                /// The destroy count
                /// </summary>
                private int destroyCount;
                /// <summary>
                /// The 
                /// </summary>
                private IGameObject e1;
                /// <summary>
                /// The init flag
                /// </summary>
                private bool initFlag;
                /// <summary>
                /// The destroy flag
                /// </summary>
                private bool destroyFlag;

                /// <summary>
                /// The destroy action
                /// </summary>
                private readonly Action destroyAction;
                /// <summary>
                /// The init action
                /// </summary>
                private readonly Action<IGameObject> initAction;
                /// <summary>
                /// The destroy component action
                /// </summary>
                private readonly Action<IGameObject> destroyComponentAction;
                /// <summary>
                /// The init component action
                /// </summary>
                private readonly Action<IGameObject> initComponentAction;

                /// <summary>
                /// Initializes a new instance of the <see cref="Lifetime"/> class
                /// </summary>
                public Lifetime()
                {
                    destroyAction = () => destroyCount++;
                    initAction = e => e1 = e;
                    initComponentAction = e => initFlag = true;
                    destroyComponentAction = e => destroyFlag = true;
                }

                /// <summary>
                /// Tests that destroy called on delete
                /// </summary>
                [Fact]
                public void Destroy_CalledOnDelete()
                {
                    destroyCount = 0;
                    using (Scene scene = new Scene())
                    {
                        List<GameObject> entities = new List<GameObject>();

                        for (int i = 0; i < 10; i++)
                        {
                            GameObject entity = scene.Create<int, float, FilteredBehavior1>(default, default, new FilteredBehavior1(() => { }, null, destroyAction));
                            entities.Add(entity);
                        }

                        foreach (GameObject entity in entities)
                        {
                            entity.Delete();
                        }

                        Assert.Equal(10, destroyCount);
                    }
                }
        
                /// <summary>
                /// Tests that init called when created
                /// </summary>
                [Fact]
                public void Init_CalledWhenCreated()
                {
                    using (Scene scene = new Scene())
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            e1 = default;
                            GameObject entity = scene.Create<int, float, FilteredBehavior1>(default, default, new FilteredBehavior1(() => { }, initAction));
                            Assert.Equal(e1, entity);
                        }
                    }
                }
        
               /// <summary>
               /// Tests that lifetime called add remove
               /// </summary>
               [Fact]
               public void LifetimeCalled_AddRemove()
               {
                   using (Scene scene = new Scene())
                   {
                       TestForLifetimeInvocation(scene, (w, c) =>
                       {
                           GameObject e = w.Create();
                           e.Add(c);
                           e.Remove<LifetimeComponent>();
                       });
                   }
               }
        
                /// <summary>
                /// Tests that lifetime called create delete
                /// </summary>
                [Fact]
                public void LifetimeCalled_CreateDelete()
                {
                    using (Scene scene = new Scene())
                    {
                        TestForLifetimeInvocation(scene, (w, c) =>
                        {
                            GameObject e = w.Create(c);
                            e.Delete();
                        });
                    }
                }
        
                /// <summary>
                /// Tests the for lifetime invocation using the specified scene
                /// </summary>
                /// <param name="scene">The scene</param>
                /// <param name="action">The action</param>
                private void TestForLifetimeInvocation(Scene scene, Action<Scene, LifetimeComponent> action)
                {
                    initFlag = false;
                    destroyFlag = false;
                    action(scene, new LifetimeComponent(initComponentAction, destroyComponentAction));
                    Assert.True(initFlag);
                    Assert.True(destroyFlag);
                }
        
                /// <summary>
                /// The lifetime component
                /// </summary>
                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                public struct LifetimeComponent(Action<IGameObject> init, Action<IGameObject> destroy) : IInitable, IDestroyable
                {
                    /// <summary>
                    /// The self
                    /// </summary>
                    private IGameObject _self;
        
                    /// <summary>
                    /// Inits the self
                    /// </summary>
                    /// <param name="self">The self</param>
                    public void Init(IGameObject self) => init?.Invoke(_self = self);
        
                    /// <summary>
                    /// Destroys this instance
                    /// </summary>
                    public void Destroy() => destroy?.Invoke(_self);
                }
            }
        }