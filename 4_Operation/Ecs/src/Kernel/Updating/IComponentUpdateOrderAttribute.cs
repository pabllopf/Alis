namespace Alis.Core.Ecs.Kernel.Updating
{
    /// <summary>
    ///     Marker interface for any update order attribute.
    /// </summary>
    /// <remarks>
    ///     This is an interface so the user can implement an
    ///     <see cref="UpdateTypeAttribute" /> as also an order attribute
    /// </remarks>
    internal interface IComponentUpdateOrderAttribute;
}