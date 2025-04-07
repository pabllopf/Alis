// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:WorldSerializer.cs
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

using System.IO;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common
{
    /// <summary>
    ///     Serialize the world into an XML file
    /// </summary>
    public static class WorldSerializer
    {
        /// <summary>
        ///     Serialize the world to a stream in XML format
        /// </summary>
        /// <param name="worldPhysic"></param>
        /// <param name="stream"></param>
        public static void Serialize(WorldPhysic worldPhysic, Stream stream)
        {
            WorldXmlSerializer.Serialize(worldPhysic, stream);
        }

        /// <summary>
        ///     Deserialize the world from a stream XML
        /// </summary>
        /// <param name="stream"></param>
        public static WorldPhysic Deserialize(Stream stream) => WorldXmlDeserializer.Deserialize(stream);
    }
}