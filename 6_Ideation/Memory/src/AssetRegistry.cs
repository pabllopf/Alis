// En Alis.csproj (la librería que accede)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// Necesario para la búsqueda con LINQ

namespace Alis.Core.Aspect.Memory
{
    /// <summary>
    /// The asset registry class
    /// </summary>
    public static class AssetRegistry
    {
        
        // Almacena una función lambda que devuelve el Stream (totalmente AOT-safe)
        /// <summary>
        /// The registered asset loaders
        /// </summary>
        private static readonly Dictionary<string, Func<Stream>> RegisteredAssetLoaders = new();
        /// <summary>
        /// Gets or sets the value of the active assembly name
        /// </summary>
        private static string ActiveAssemblyName { get; set; } = null;

        // Nuevo método de registro que acepta el cargador delegado (AOT-safe)
        /// <summary>
        /// Registers the assembly using the specified assembly name
        /// </summary>
        /// <param name="assemblyName">The assembly name</param>
        /// <param name="assetLoader">The asset loader</param>
        public static void RegisterAssembly(string assemblyName, Func<Stream> assetLoader)
        {
            RegisteredAssetLoaders[assemblyName] = assetLoader;
            
            if (ActiveAssemblyName == null)
            {
                ActiveAssemblyName = assemblyName;
            }
        }

        
        /// <summary>
        /// Obtiene un Stream del recurso "assets.pack" de la asamblea activa o predeterminada.
        /// </summary>
        /// <param name="baseResourceName">El nombre base del recurso (debe ser "assets.pack" en este contexto).</param>
        public static Stream GetAssetStreamByBaseName(string baseResourceName)
        {
            if (!string.Equals(baseResourceName, "assets.pack", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Este método solo soporta la búsqueda para 'assets.pack'.", nameof(baseResourceName));
            }

            if (ActiveAssemblyName == null)
            {
                throw new InvalidOperationException("No hay una asamblea activa configurada.");
            }
            
            // Usamos el cargador delegado registrado
            if (!RegisteredAssetLoaders.TryGetValue(ActiveAssemblyName, out var loader))
            {
                throw new InvalidOperationException($"La asamblea activa '{ActiveAssemblyName}' no tiene un assets.pack registrado.");
            }

            // Llamamos a la función lambda generada estáticamente
            return loader.Invoke(); 
        }
    }
}