// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LoadingFailedException.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------
namespace Alis.Exceptions
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Exception thrown by SFML whenever loading a resource fails
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class LoadingFailedException : System.Exception
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Default constructor (unknown error)
        /// </summary>
        ////////////////////////////////////////////////////////////
        public LoadingFailedException() : base("Failed to load a resource")
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Failure to load a resource from memory
        /// </summary>
        /// <param name="resourceName">Name of the resource</param>
        ////////////////////////////////////////////////////////////
        public LoadingFailedException(string resourceName) : base($"Failed to load {resourceName} from memory")
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Failure to load a resource from memory
        /// </summary>
        /// <param name="resourceName">Name of the resource</param>
        /// <param name="innerException">Exception which is the cause ofthe current exception</param>
        ////////////////////////////////////////////////////////////
        public LoadingFailedException(string resourceName, System.Exception innerException) :
            base($"Failed to load {resourceName} from memory", innerException)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Failure to load a resource from a file
        /// </summary>
        /// <param name="resourceName">Name of the resource</param>
        /// <param name="filename">Path of the file</param>
        ////////////////////////////////////////////////////////////
        public LoadingFailedException(string resourceName, string filename) :
            base($"Failed to load {resourceName} from file {filename}")
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Failure to load a resource from a file
        /// </summary>
        /// <param name="resourceName">Name of the resource</param>
        /// <param name="filename">Path of the file</param>
        /// <param name="innerException">Exception which is the cause ofthe current exception</param>
        ////////////////////////////////////////////////////////////
        public LoadingFailedException(string resourceName, string filename, System.Exception innerException) :
            base($"Failed to load {resourceName} from file {filename}", innerException)
        {
        }
    }
}