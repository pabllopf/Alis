using System;
            using System.Runtime.InteropServices;
            using Alis.Core.Ecs.Test.Helpers;
            using Alis;
            
            using Alis.Core;
            using Alis.Core.Aspect.Fluent.Components;
            
            using Alis.Core.Ecs.Kernel;
            using Xunit;
            
            namespace Alis.Core.Ecs.Test.Framework
            {
                /// <summary>
                /// The updating class
                /// </summary>
                public class Updating
                {
                    /// <summary>
            /// Tests that component filter updates single component
            /// </summary>
            [Fact]
            public void ComponentFilter_UpdatesSingleComponent()
            {
                using Scene scene = new();
            
                int count = 0;
            
                scene.Create(0f, 0, new DelegateBehavior(() => count++));
                scene.Create(0f, 0, new DelegateBehavior(() => count++));
                scene.Create(new DelegateBehavior(() => count++));
            
                scene.Create(new DelegateBehavior(() => count++), new FilteredBehavior1(() => count++));
            
                scene.Create(0, new FilteredBehavior1(() => count++));
            
                scene.UpdateComponent(Component<DelegateBehavior>.Id);
            
                Assert.Equal(4, count);
            
                scene.UpdateComponent(Component<DelegateBehavior>.Id);
            
                Assert.Equal(8, count);
            
                scene.UpdateComponent(Component<FilteredBehavior1>.Id);
            
                Assert.Equal(10, count);
            }
                    /// <summary>
                    /// Tests that update updates components
                    /// </summary>
                    [Fact]
                    public void Update_UpdatesComponents()
                    {
                        using Scene scene = new();
            
                        int count = 0;
                        for (int i = 0; i < 10; i++)
                            scene.Create<int, float, DelegateBehavior>(default, default, new DelegateBehavior(() => count++));
            
                        scene.Update();
            
                        Assert.Equal(10, count);
                    }
            
                    /// <summary>
                    /// Tests that update filters components
                    /// </summary>
                    [Fact]
                    public void Update_FiltersComponents()
                    {
                        using Scene scene = new();
            
                        int count = 0;
                        for (int i = 0; i < 10; i++)
                            scene.Create<int, float, FilteredBehavior1>(default, default, new FilteredBehavior1(() => count++));
                        for (int i = 0; i < 10; i++)
                            scene.Create<int, float, FilteredBehavior2>(default, default, new FilteredBehavior2(() => count++));
            
                        scene.Update<FilterAttribute1>();
            
                        Assert.Equal(10, count);
            
                        scene.Update<FilterAttribute2>();
            
                        Assert.Equal(20, count);
                    }
            
                    /// <summary>
                    /// Tests that update register late filters components
                    /// </summary>
                    [Fact]
                    public void Update_RegisterLate_FiltersComponents()
                    {
                        int count = 0;
                        using Scene scene = new();
            
                        scene.Update<FilterAttribute1>();
            
                        for (int i = 0; i < 10; i++)
                        {
                            scene.Create(new LazyComponent<int>(() => count++));
                            scene.Create(new FilteredBehavior2(() => count++));
                        }
            
                        scene.Update<FilterAttribute1>();
                        Assert.Equal(10, count);
            
                        for (int i = 0; i < 10; i++)
                        {
                            scene.Create(new LazyComponent<double>(() => count++));
                            scene.Create(new FilteredBehavior2(() => count++));
                        }
            
                        scene.Update<FilterAttribute1>();
                        Assert.Equal(30, count);
                    }
                    
            
                    /// <summary>
                    /// Tests that update deferred gameObject creation update updates deferred entities
                    /// </summary>
                    [Fact]
                    public void Update_DeferredEntityCreationUpdate_UpdatesDeferredEntities()
                    {
                        int count = 0;
                        using Scene scene = new();
            
                        scene.Create(new DelegateBehavior(() =>
                        {
                            scene.Create(new DelegateBehavior(() =>
                            {
                                count++;
                            }));
                        }));
            
                        scene.Update();
            
                        Assert.Equal(1, count);
            
                        scene.Update();
            
                        Assert.Equal(3, count);
                    }
            
                    /// <summary>
                    /// Tests that update deferred gameObject creation update hits recursion limit
                    /// </summary>
                    [Fact]
                    public void Update_DeferredEntityCreationUpdate_HitsRecursionLimit()
                    {
                        using Scene scene = new();
            
                        scene.Create(new DelegateBehavior(() =>
                        {
                            Create();
                        }));
            
                        Assert.Throws<InvalidOperationException>(() => scene.Update());
            
                        void Create()
                        {
                            scene.Create(new DelegateBehavior(() =>
                            {
                                Create();
                            }));
                        }
                    }
            
                    /// <summary>
                    /// Tests that update filtered deferred gameObject creation update updates deferred entities
                    /// </summary>
                    [Fact]
                    public void Update_FilteredDeferredEntityCreationUpdate_UpdatesDeferredEntities()
                    {
                        int count = 0;
                        using Scene scene = new();
            
                        scene.Create(new FilteredBehavior1(() =>
                        {
                            scene.Create(new FilteredBehavior1(() =>
                            {
                                count++;
                            }));
                        }));
            
                        scene.Update<FilterAttribute1>();
            
                        Assert.Equal(1, count);
            
                        scene.Update<FilterAttribute1>();
            
                        Assert.Equal(3, count);
                    }
                }
            
                /// <summary>
                /// The lazy component
                /// </summary>
                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                public partial struct LazyComponent<T>(Action a) : IComponent
                {
                    /// <summary>
                    /// Updates this instance
                    /// </summary>
                    [FilterAttribute1]
                    public void Update() => a();
                }
            }