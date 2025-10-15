// En Alis.csproj (la librería que accede)

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

// Necesario para la búsqueda con LINQ

namespace Alis.Core.Aspect.Memory
{
    public static class AssetRegistry
    {
        
        // Almacena una función lambda que devuelve el Stream (totalmente AOT-safe)
        private static readonly Dictionary<string, Func<Stream>> RegisteredAssetLoaders = new();
        private static string ActiveAssemblyName { get; set; } = null;

        // Nuevo método de registro que acepta el cargador delegado (AOT-safe)
        public static void RegisterAssembly(string assemblyName, Func<Stream> assetLoader)
        {
            RegisteredAssetLoaders[assemblyName] = assetLoader;
            
            if (ActiveAssemblyName == null)
            {
                ActiveAssemblyName = assemblyName;
            }
        }

        
        /// <summary>
        /// Obtiene un Stream del recurso "assets.pak" de la asamblea activa o predeterminada.
        /// </summary>
        /// <param name="baseResourceName">El nombre base del recurso (debe ser "assets.pak" en este contexto).</param>
        public static Stream GetAssetStreamByBaseName(string baseResourceName)
        {
            if (!string.Equals(baseResourceName, "assets.pak", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException("Este método solo soporta la búsqueda para 'assets.pak'.", nameof(baseResourceName));
            }

            if (ActiveAssemblyName == null)
            {
                throw new InvalidOperationException("No hay una asamblea activa configurada.");
            }
            
            // Usamos el cargador delegado registrado
            if (!RegisteredAssetLoaders.TryGetValue(ActiveAssemblyName, out var loader))
            {
                throw new InvalidOperationException($"La asamblea activa '{ActiveAssemblyName}' no tiene un assets.pak registrado.");
            }

            // Llamamos a la función lambda generada estáticamente
            return loader.Invoke(); 
        }
    }
}