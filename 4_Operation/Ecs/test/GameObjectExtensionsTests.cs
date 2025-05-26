using System;
        using Alis.Core.Ecs.Test.Helpers;
        using Alis;
        using Alis.Core;
        using Alis.Core.Ecs.Core;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test
        {
    /// <summary>
    /// The gameObject extensions tests class
    /// </summary>
    public class GameObjectExtensionsTests
            {
                /// <summary>
                /// Tests that deconstruct deconstructs gameObject
                /// </summary>
                [Fact]
                public void Deconstruct_DeconstructsEntity()
                {
                    using Scene scene = new();
        
                    var e = scene.Create<Class1, Struct1, int, double, string>(new(), new(), 1, 2.0, "3");
        
                    e.Deconstruct(
                        out Ref<Class1> class1,
                        out Ref<Struct1> struct1,
                        out Ref<int> int1,
                        out Ref<double> double1,
                        out Ref<string> string1);
        
                    Assert.Equal(e.Get<Class1>(), class1.Value);
                    Assert.Equal(e.Get<Struct1>(), struct1.Value);
                    Assert.Equal(e.Get<int>(), int1.Value);
                    Assert.Equal(e.Get<double>(), double1.Value);
                    Assert.Equal(e.Get<string>(), string1.Value);
                }
        
                /// <summary>
                /// Tests that deconstruct null ref exception
                /// </summary>
                [Fact]
                public void Deconstruct_NullRefException()
                {
                    using Scene scene = new();
        
                    var e = scene.Create<Class1, Struct1, int, double, string>(new(), new(), 1, 2.0, "3");
        
                    Assert.Throws<NullReferenceException>(() => e.Deconstruct(out Ref<Class2> _));
                }
            }
        }