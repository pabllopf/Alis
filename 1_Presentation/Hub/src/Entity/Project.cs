

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.App.Hub.Entity
{
    /// <summary>
    ///     The project class
    /// </summary>
    [Serializable, StructLayout(LayoutKind.Sequential, Pack = 1)]
    public partial struct Project
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Project" /> class
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="path">The path</param>
        /// <param name="cloudStatus">The cloud status</param>
        /// <param name="modifiedDate">The modified date</param>
        /// <param name="editorVersion">The editor version</param>
        public Project(string name, string path, string cloudStatus, string modifiedDate, string editorVersion)
        {
            Name = name;
            Path = path;
            CloudStatus = cloudStatus;
            ModifiedDate = modifiedDate;
            EditorVersion = editorVersion;
        }

        /// <summary>
        ///     Gets the value of the name
        /// </summary>
        [JsonNativePropertyName("_name_")]
        public string Name { get; set; } = "Not Set";

        /// <summary>
        ///     Gets the value of the path
        /// </summary>
        [JsonNativePropertyName("_path_")]
        public string Path { get; set; } = "Not Set";

        /// <summary>
        ///     Gets the value of the cloud status
        /// </summary>
        [JsonNativePropertyName("_cloudStatus_")]
        public string CloudStatus { get; set; } = "Not Synced";

        /// <summary>
        ///     Gets the value of the modified date
        /// </summary>
        [JsonNativePropertyName("_modifiedDate_")]
        public string ModifiedDate { get; set; } = "Never";

        /// <summary>
        ///     Gets the value of the editor version
        /// </summary>
        [JsonNativePropertyName("_editorVersion_")]
        public string EditorVersion { get; set; } = "2021.1.0";

        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        [JsonNativePropertyName("_version_")]
        public string Version { get; set; } = "1.0.0";

        /// <summary>
        ///     Gets or sets the value of the last modified
        /// </summary>
        [JsonNativePropertyName("_lastModified_")]
        public string LastModified { get; set; } = "Never";
    }
}