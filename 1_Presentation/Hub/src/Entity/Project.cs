// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Project.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     Represents a project metadata record containing name, path, synchronization status, and version information.
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Project
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Project" /> struct with the specified project metadata.
        /// </summary>
        /// <param name="name">The project display name.</param>
        /// <param name="path">The file system path to the project directory.</param>
        /// <param name="cloudStatus">The current cloud synchronization status.</param>
        /// <param name="modifiedDate">The last modification date string.</param>
        /// <param name="editorVersion">The editor version associated with the project.</param>
        public Project(string name, string path, string cloudStatus, string modifiedDate, string editorVersion)
        {
            Name = name;
            Path = path;
            CloudStatus = cloudStatus;
            ModifiedDate = modifiedDate;
            EditorVersion = editorVersion;
        }

        /// <summary>
        ///     Gets or sets the project display name. Defaults to "Not Set".
        /// </summary>
        [JsonNativePropertyName("_name_")]
        public string Name { get; set; } = "Not Set";

        /// <summary>
        ///     Gets or sets the file system path to the project directory. Defaults to "Not Set".
        /// </summary>
        [JsonNativePropertyName("_path_")]
        public string Path { get; set; } = "Not Set";

        /// <summary>
        ///     Gets or sets the current cloud synchronization status. Defaults to "Not Synced".
        /// </summary>
        [JsonNativePropertyName("_cloudStatus_")]
        public string CloudStatus { get; set; } = "Not Synced";

        /// <summary>
        ///     Gets or sets the last modification date string. Defaults to "Never".
        /// </summary>
        [JsonNativePropertyName("_modifiedDate_")]
        public string ModifiedDate { get; set; } = "Never";

        /// <summary>
        ///     Gets or sets the editor version associated with the project. Defaults to "2021.1.0".
        /// </summary>
        [JsonNativePropertyName("_editorVersion_")]
        public string EditorVersion { get; set; } = "2021.1.0";

        /// <summary>
        ///     Gets or sets the project version string. Defaults to "1.0.0".
        /// </summary>
        [JsonNativePropertyName("_version_")]
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        ///     Gets or sets the last modified timestamp string. Defaults to "Never".
        /// </summary>
        [JsonNativePropertyName("_lastModified_")]
        public string LastModified { get; set; } = "Never";
    }
}