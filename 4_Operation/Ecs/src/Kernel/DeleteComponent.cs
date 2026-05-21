// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DeleteComponent.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
/// <summary>
///     Represents a command to delete a component from an entity in the ECS system.
///     This is a readonly struct used in command-based architectures where modifications
///     to entities are queued and processed later, ensuring thread safety and deterministic behavior.
/// </summary>
/// <param name="Entity">The entity (GameObject) from which the component should be removed.</param>
/// <param name="ComponentId">The unique identifier of the component type to delete.</param>
/// <remarks>
///     Memory layout optimized: 8 bytes total (GameObjectIdOnly 6 bytes + ComponentId 2 bytes)
///     Pack = 1 for minimal memory footprint
///     
///     This command follows the Entity Command Pattern where state changes are
///     deferred until a safe point in the game loop (typically after all systems
///     have updated) to avoid modifying entities while they are being iterated over.
///     
///     Usage example:
///     <code>
///     // Create a delete component command
///     var deleteCmd = new DeleteComponent(entity.Id, typeof(MyComponent).ComponentId);
///     
///     // Add to command buffer for later execution
///     commandBuffer.Add(deleteCmd);
///     
///     // Later in the update loop:
///     foreach (var cmd in commandBuffer)
///     {
///         if (cmd is DeleteComponent deleteCmd)
///         {
///             world.DeleteComponent(deleteCmd.Entity, deleteCmd.ComponentId);
///         }
///     }
///     </code>
/// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct DeleteComponent(GameObjectIdOnly Entity, ComponentId ComponentId);
}