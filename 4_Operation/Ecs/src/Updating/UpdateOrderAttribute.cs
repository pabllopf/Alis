using System;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The update order attribute class
    /// </summary>
    /// <seealso cref="Attribute" />
    /// <seealso cref="IComponentUpdateOrderAttribute" />
    [AttributeUsage(AttributeTargets.Method)]
    [Obsolete("Unused")]
#pragma warning disable CS9113 // Parameter is unread.
    public class UpdateOrderAttribute(int order) : Attribute, IComponentUpdateOrderAttribute;
#pragma warning restore CS9113 // Parameter is unread.
}