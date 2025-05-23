using System;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     Marker interface for any update order attribute.
    /// </summary>
    /// <remarks>
    ///     This is an interface so the user can implement an
    ///     <see cref="UpdateTypeAttribute" /> as also an order attribute
    /// </remarks>
    [Obsolete("Unused")]
    internal interface IComponentUpdateOrderAttribute;
}