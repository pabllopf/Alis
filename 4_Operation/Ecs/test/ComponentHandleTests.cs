using System;
using System.Linq;
using Alis.Core.Ecs.Test.Helpers;
        using Alis.Core;
        using Alis.Core.Ecs.Kernel;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test
        {
            /// <summary>
            /// The component handle tests class
            /// </summary>
            public class ComponentHandleTests
            {
                /// <summary>
                /// Tests that component handle stores component
                /// </summary>
                [Fact]
                public void ComponentHandle_StoresComponent()
                {
                    using var handle = ComponentHandle.Create(69);
                    Assert.Equal(69, handle.Retrieve<int>());
                }
        
                /// <summary>
                /// Tests that retrieve throws wrong type
                /// </summary>
                [Fact]
                public void Retrieve_ThrowsWrongType()
                {
                    using var handle = ComponentHandle.Create(69);
                    Assert.Throws<InvalidOperationException>(() => handle.Retrieve<double>());
                }
        
                /// <summary>
                /// Tests that retrieve boxed correct value
                /// </summary>
                [Fact]
                public void RetrieveBoxed_CorrectValue()
                {
                    using var handle = ComponentHandle.Create(69);
                    object box = handle.RetrieveBoxed();
                    Assert.Equal(typeof(int), box.GetType());
                    Assert.Equal(69, (int)box);
                }
        
                /// <summary>
                /// Tests that type correct type
                /// </summary>
                [Fact]
                public void Type_CorrectType()
                {
                    ComponentHandle[] handle = 
                    {
                        ComponentHandle.Create(0),
                        ComponentHandle.Create(0.0),
                        ComponentHandle.Create(0f)
                    };
        
                    Assert.Equal(new[] { typeof(int), typeof(double), typeof(float) }, handle.Select(c => c.Type));
                    Assert.Equal(new[] { Component<int>.Id, Component<double>.Id, Component<float>.Id }, handle.Select(c => c.ComponentId));
                }
            }
        }