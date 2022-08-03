// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     Delegate CreateControllerDelegate used to define a method for creating a new <seealso cref="Controller" /> from a
    ///     <seealso cref="Device" />.
    /// </summary>
    /// <typeparam name="T">The controller type.</typeparam>
    /// <param name="device">The device.</param>
    /// <returns>A controller; otherwise <see langword="null" />.</returns>
    /// <seealso cref="Controller" />
    /// <seealso cref="Device" />
    public delegate T CreateControllerDelegate<out T>(Device device) where T : Controller;
}