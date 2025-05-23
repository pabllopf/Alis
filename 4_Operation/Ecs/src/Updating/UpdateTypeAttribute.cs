using System;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The base class of all attributes used to filter scene updates
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public abstract class UpdateTypeAttribute : Attribute;
}