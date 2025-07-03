using System;
        using System.Collections.Generic;
        using System.Linq;
        using Alis.Core.Ecs.Kernel;
        using Alis.Core.Ecs.Test.Helpers;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test
        {
    /// <summary>
    /// The tag tests class
    /// </summary>
    public class TagTests
            {
                /// <summary>
                /// Tests that get component id unique
                /// </summary>
                [Fact]
                public void GetComponentID_Unique()
                {
                    HashSet<TagId> componentIDs = new()
                    {
                        Tag.GetTagId(typeof(int)),
                        Tag.GetTagId(typeof(long)),
                        Tag.GetTagId(typeof(double)),
                        Tag.GetTagId(typeof(string)),
                    };
        
                    Assert.Equal(4, componentIDs.Count);
                }
        
                /// <summary>
                /// Tests that get component id same
                /// </summary>
                [Fact]
                public void GetComponentID_Same()
                {
                    Assert.Equal(Tag.GetTagId(typeof(int)), Tag.GetTagId(typeof(int)));
                    Assert.Equal(Tag.GetTagId(typeof(Struct1)), Tag.GetTagId(typeof(Struct1)));
                }
        
                /// <summary>
                /// Tests that get component id generic unique
                /// </summary>
                [Fact]
                public void GetComponentIDGeneric_Unique()
                {
                    HashSet<TagId> componentIDs = new()
                    {
                        Tag<int>.Id,
                        Tag<long>.Id,
                        Tag<double>.Id,
                        Tag<string>.Id,
                    };
        
                    Assert.Equal(4, componentIDs.Count);
                }
        
                /// <summary>
                /// Tests that get component id generic same
                /// </summary>
                [Fact]
                public void GetComponentIDGeneric_Same()
                {
                    Assert.Equal(Tag<int>.Id, Tag.GetTagId(typeof(int)));
                    Assert.Equal(Tag<Struct1>.Id, Tag.GetTagId(typeof(Struct1)));
                }
            }
        }