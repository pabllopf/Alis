// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SceneEventsSample.cs
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

using System;

namespace Alis.Core.Ecs.Sample.Samples
{
    /// <summary>
    ///     The scene events sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class SceneEventsSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "scene-events";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Scene Events";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Subscribes to scene-level entity and component events.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();

            int created = 0;
            int deleted = 0;
            int added = 0;
            int removed = 0;

            scene.EntityCreated += _ => created++;
            scene.EntityDeleted += _ => deleted++;
            scene.ComponentAdded += (_, componentId) =>
            {
                added++;
                Console.WriteLine($"Component added: {componentId.ToString()}");
            };
            scene.ComponentRemoved += (_, componentId) =>
            {
                removed++;
                Console.WriteLine($"Component removed: {componentId.ToString()}");
            };

            GameObject entity = scene.Create(7);
            entity.Add("hello");
            entity.Remove<int>();
            entity.Delete();

            Console.WriteLine($"Created events:  {created}");
            Console.WriteLine($"Deleted events:  {deleted}");
            Console.WriteLine($"Added events:    {added}");
            Console.WriteLine($"Removed events:  {removed}");
        }
    }
}