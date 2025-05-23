using Alis.Core.Ecs.Test.Helpers;
        using Alis;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test.Framework
        {
            /// <summary>
            /// The generic components class
            /// </summary>
            public class GenericComponents
            {
                /// <summary>
                /// Tests that generic component updated
                /// </summary>
                [Fact]
                public void GenericComponent_Updated()
                {
                    using Scene scene = new Scene();
        
                    var e1 = scene.Create<GenericComponent<int>>(default);
                    var e2 = scene.Create<GenericComponent<object>>(default);
        
                    scene.Update();
        
                    Assert.Equal(1, e1.Get<GenericComponent<int>>().CalledCount);
                    Assert.False(e1.Has<GenericComponent<object>>());
        
                    Assert.Equal(1, e2.Get<GenericComponent<object>>().CalledCount);
                    Assert.False(e2.Has<GenericComponent<int>>());
                }
            }
        }