// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GeneralSetting.cs
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

using System.Collections.Generic;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Json;

namespace Alis.Core.Ecs.Systems.Configuration.General
{
    /// <summary>
    ///     The general setting class
    /// </summary>
    /// <seealso cref="IGeneralSetting" />
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct GeneralSetting(
        bool debug,
        string name,
        string description,
        string version,
        string author,
        string license,
        string icon) : IGeneralSetting, IJsonSerializable, IJsonDesSerializable<GeneralSetting>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GeneralSetting" /> class with default values.
        /// </summary>
        public GeneralSetting() : this(false, "Default Name", "Default Description", "0.0.0",
            "Pablo Perdomo Falcón", "GPL-3.0 license", "app.ico")
        {
        }

        /// <summary>
        ///     Gets or sets the value of the debug
        /// </summary>
        public bool Debug { get; set; } = debug;

        /// <summary>
        ///     Gets or sets the value of the name
        /// </summary>
        public string Name { get; set; } = name;

        /// <summary>
        ///     Gets or sets the value of the description
        /// </summary>
        public string Description { get; set; } = description;

        /// <summary>
        ///     Gets or sets the value of the version
        /// </summary>
        public string Version { get; set; } = version;

        /// <summary>
        ///     Gets or sets the value of the author
        /// </summary>
        public string Author { get; set; } = author;

        /// <summary>
        ///     Gets or sets the value of the license
        /// </summary>
        public string License { get; set; } = license;

        /// <summary>
        ///     Gets or sets the value of the icon
        /// </summary>
        public string Icon { get; set; } = icon;

        /// <summary>
        ///     Ons the save
        /// </summary>
        internal void OnSave() => JsonNativeAot.SerializeToFile(this, nameof(GeneralSetting), "Data");

        /// <summary>
        ///     Ons the load
        /// </summary>
        /// <returns>The general setting</returns>
        internal static GeneralSetting OnLoad() => JsonNativeAot.DeserializeFromFile<GeneralSetting>(nameof(GeneralSetting), "Data");

        /// <summary>
        ///     Gets the serializable properties
        /// </summary>
        /// <returns>An enumerable of string property name and string value</returns>
        IEnumerable<(string PropertyName, string Value)> IJsonSerializable.GetSerializableProperties()
        {
            yield return (nameof(Debug), Debug.ToString());
            yield return (nameof(Name), Name);
            yield return (nameof(Description), Description);
            yield return (nameof(Version), Version);
            yield return (nameof(Author), Author);
            yield return (nameof(License), License);
            yield return (nameof(Icon), Icon);
        }

        /// <summary>
        ///     Creates the from properties using the specified properties
        /// </summary>
        /// <param name="properties">The properties</param>
        /// <returns>The general setting</returns>
        GeneralSetting IJsonDesSerializable<GeneralSetting>.CreateFromProperties(Dictionary<string, string> properties) => new GeneralSetting(
            properties.TryGetValue(nameof(Debug), out string debugValue) && bool.TryParse(debugValue, out bool debugValueLocal) && debugValueLocal,
            properties.TryGetValue(nameof(Name), out string nameValue) ? nameValue : "Default Name",
            properties.TryGetValue(nameof(Description), out string descriptionValue) ? descriptionValue : "Default Description",
            properties.TryGetValue(nameof(Version), out string versionValue) ? versionValue : "0.0.0",
            properties.TryGetValue(nameof(Author), out string authorValue) ? authorValue : "Pablo Perdomo Falcón",
            properties.TryGetValue(nameof(License), out string licenseValue) ? licenseValue : "GPL-3.0 license",
            properties.TryGetValue(nameof(Icon), out string iconValue) ? iconValue : "app.jpeg"
        );
    }
}