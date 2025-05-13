using System;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    /// The base class of all attributes used to filter world updates
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class UpdateTypeAttribute : Attribute;
}