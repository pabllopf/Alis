using System;
        using Xunit;
        
        namespace Alis.Core.Ecs.Test.Helpers
        {
            /// <summary>
            /// The memory class
            /// </summary>
            internal static class Memory
            {
                /// <summary>
                /// The bytes allocated
                /// </summary>
                private static long _bytesAllocated;
        
                /// <summary>
                /// Records
                /// </summary>
                public static void Record()
                {
                    GC.Collect();
                    _bytesAllocated = GC.GetAllocatedBytesForCurrentThread();
                }
        
                /// <summary>
                /// Allocateds the at least using the specified bytes allocated
                /// </summary>
                /// <param name="bytesAllocated">The bytes allocated</param>
                public static void AllocatedAtLeast(long bytesAllocated)
                {
                    Assert.True(MeasureAllocated() >= bytesAllocated);
                }
        
                /// <summary>
                /// Allocateds the less than using the specified bytes allocated
                /// </summary>
                /// <param name="bytesAllocated">The bytes allocated</param>
                public static void AllocatedLessThan(long bytesAllocated)
                {
                    Assert.True(MeasureAllocated() < bytesAllocated);
                }
        
                /// <summary>
                /// Allocateds
                /// </summary>
                public static void Allocated()
                {
                    Assert.True(MeasureAllocated() > 0);
                }
        
                /// <summary>
                /// Nots the allocated
                /// </summary>
                public static void NotAllocated()
                {
                    Assert.Equal(0, MeasureAllocated());
                }
        
                /// <summary>
                /// Measures the allocated
                /// </summary>
                /// <returns>The allocated</returns>
                private static long MeasureAllocated()
                {
                    var allocated = GC.GetAllocatedBytesForCurrentThread() - _bytesAllocated;
                    // No equivalente directo para TestContext.WriteLine en xUnit
                    return allocated;
                }
            }
        }