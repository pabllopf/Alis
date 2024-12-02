// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:InstalledVersion.cs
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

namespace Alis.App.Engine.Hub
{
    /// <summary>
    /// The installed version class
    /// </summary>
    public class InstalledVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstalledVersion"/> class
        /// </summary>
        /// <param name="version">The version</param>
        /// <param name="releaseDate">The release date</param>
        /// <param name="installPath">The install path</param>
        public InstalledVersion(string version, string releaseDate, string installPath)
        {
            Version = version;
            ReleaseDate = releaseDate;
            InstallPath = installPath;
        }

        /// <summary>
        /// Gets the value of the version
        /// </summary>
        public string Version { get; }
        /// <summary>
        /// Gets the value of the release date
        /// </summary>
        public string ReleaseDate { get; }
        /// <summary>
        /// Gets the value of the install path
        /// </summary>
        public string InstallPath { get; }
    }
}