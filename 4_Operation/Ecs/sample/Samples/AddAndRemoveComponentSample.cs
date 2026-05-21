// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AddAndRemoveComponentSample.cs
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
    ///     The add and remove component sample class
    /// </summary>
    /// <seealso cref="IEcsSample" />
    internal sealed class AddAndRemoveComponentSample : IEcsSample
    {
        /// <summary>
        ///     Gets the value of the key
        /// </summary>
        public string Key => "add-remove";

        /// <summary>
        ///     Gets the value of the title
        /// </summary>
        public string Title => "Add And Remove Components";

        /// <summary>
        ///     Gets the value of the description
        /// </summary>
        public string Description => "Shows runtime structural changes with Add<T> and Remove<T>.";

        /// <summary>
        ///     Runs this instance
        /// </summary>
        public void Run()
        {
            using Scene scene = new Scene();
            GameObject entity = scene.Create(42);

            Console.WriteLine($"Has<string> before Add: {entity.Has<string>()}");
            entity.Add("temporary component");
            Console.WriteLine($"Has<string> after Add: {entity.Has<string>()}");

            entity.Remove<string>();
            Console.WriteLine($"Has<string> after Remove: {entity.Has<string>()}");
        }
    }
}