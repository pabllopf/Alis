using System.Collections.Generic;
        using Alis.Core.Ecs.Test.Helpers;
        using Alis.Core;
        using Alis.Core.Ecs.Core;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test
        {
            /// <summary>
            /// The component tests class
            /// </summary>
            public class ComponentTests
            {
                /// <summary>
                /// Tests that get component id unique
                /// </summary>
                [Fact]
                public void GetComponentID_Unique()
                {
                    Component.RegisterComponent<int>();
                    Component.RegisterComponent<long>();
                    Component.RegisterComponent<double>();
                    Component.RegisterComponent<string>();
        
                    HashSet<ComponentId> componentIDs = new()
                    {
                        Component.GetComponentId(typeof(int)),
                        Component.GetComponentId(typeof(long)),
                        Component.GetComponentId(typeof(double)),
                        Component.GetComponentId(typeof(string)),
                    };
        
                    Assert.Equal(4, componentIDs.Count);
                }
        
                /// <summary>
                /// Tests that get component id same
                /// </summary>
                [Fact]
                public void GetComponentID_Same()
                {
                    Component.RegisterComponent<int>();
                    Component.RegisterComponent<Struct1>();
        
                    Assert.Equal(Component.GetComponentId(typeof(int)), Component.GetComponentId(typeof(int)));
                    Assert.Equal(Component.GetComponentId(typeof(Struct1)), Component.GetComponentId(typeof(Struct1)));
                }
        
                /// <summary>
                /// Tests that get component id generic unique
                /// </summary>
                [Fact]
                public void GetComponentIDGeneric_Unique()
                {
                    Component.RegisterComponent<int>();
                    Component.RegisterComponent<long>();
                    Component.RegisterComponent<double>();
                    Component.RegisterComponent<string>();
        
                    HashSet<ComponentId> componentIDs = new()
                    {
                        Component<int>.Id,
                        Component<long>.Id,
                        Component<double>.Id,
                        Component<string>.Id,
                    };
        
                    Assert.Equal(4, componentIDs.Count);
                }
        
                /// <summary>
                /// Tests that get component id generic same
                /// </summary>
                [Fact]
                public void GetComponentIDGeneric_Same()
                {
                    Component.RegisterComponent<int>();
                    Component.RegisterComponent<Struct1>();
        
                    Assert.Equal(Component<int>.Id, Component.GetComponentId(typeof(int)));
                    Assert.Equal(Component<Struct1>.Id, Component.GetComponentId(typeof(Struct1)));
                }
            }
        }