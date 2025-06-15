using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject debug view class
    /// </summary>
    public class EntityDebugView(GameObject target)
    {
        /// <summary>
        ///     Gets the value of the component types
        /// </summary>
        public FastImmutableArray<ComponentId> ComponentTypes => target.ComponentTypes;

        /// <summary>
        ///     Gets the value of the tags
        /// </summary>
        public FastImmutableArray<TagId> Tags => target.TagTypes;

        /// <summary>
        ///     Gets the value of the components
        /// </summary>

        public Dictionary<Type, object> Components
        {
            get
            {
                if (!target.InternalIsAlive(out Scene world, out GameObjectLocation eloc))
                    return [];

                Dictionary<Type, object> components = [];

                for (int i = 0; i < ComponentTypes.Length; i++)
                    components[ComponentTypes[i].Type] = target.Get(ComponentTypes[i]);

                return components;
            }
        }
    }
}