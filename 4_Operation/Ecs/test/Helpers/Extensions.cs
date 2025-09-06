using System;
        using Alis;
        using Alis.Core.Ecs.Kernel;
        using Alis.Core.Ecs.Systems;
        using Xunit;

        namespace Alis.Core.Ecs.Test.Helpers
        {
            /// <summary>
            /// The extensions class
            /// </summary>
            internal static class Extensions
            {
                /// <summary>
                /// Entities the count using the specified query
                /// </summary>
                /// <param name="query">The query</param>
                /// <returns>The count</returns>
                public static int EntityCount(this Query query)
                {
                    int count = 0;
                    foreach (GameObject entity in query.EnumerateWithEntities())
                    {
                        count++;
                    }
                    return count;
                }
        
                /// <summary>
                /// Asserts the entities not default using the specified query
                /// </summary>
                /// <param name="query">The query</param>
                public static void AssertEntitiesNotDefault(this Query query)
                {
                    foreach (GameObject entity in query.EnumerateWithEntities())
                    {
                        foreach (ComponentId component in entity.ComponentTypes)
                        {
                            AssertNotDefault(entity.Get(component));
                        }
                    }
        
                    static void AssertNotDefault(object value)
                    {
                        Type type = value.GetType();
                        if (type.IsValueType)
                        {
                            Assert.NotEqual(Activator.CreateInstance(type), value);
                        }
                        else
                        {
                            Assert.NotNull(value);
                        }
                    }
                }
            }
        }