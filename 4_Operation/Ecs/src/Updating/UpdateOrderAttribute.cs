using System;

namespace Alis.Core.Ecs.Updating
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    [Obsolete("Unused")]
#pragma warning disable CS9113 // Parameter is unread.
    internal class UpdateOrderAttribute(int order) : Attribute, IComponentUpdateOrderAttribute;
#pragma warning restore CS9113 // Parameter is unread.
}