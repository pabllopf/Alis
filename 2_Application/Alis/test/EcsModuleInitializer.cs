using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Alis.Test
{
    internal static class EcsModuleInitializer
    {
        [ModuleInitializer]
        internal static void Initialize()
        {
            Type globalWorldTables = Type.GetType("Alis.Core.Ecs.Kernel.Archetypes.GlobalWorldTables, Alis.Core.Ecs");
            if (globalWorldTables == null) return;

            FieldInfo tableField = globalWorldTables.GetField("ComponentTagLocationTable",
                BindingFlags.Public | BindingFlags.Static);
            if (tableField == null) return;

            byte[][] table = (byte[][])tableField.GetValue(null);
            if (table == null || table.Length < 64)
            {
                tableField.SetValue(null, new byte[64][]);
            }

            PropertyInfo bufferProp = globalWorldTables.GetProperty("ComponentTagTableBufferSize",
                BindingFlags.NonPublic | BindingFlags.Static);
            if (bufferProp != null && (int)(bufferProp.GetValue(null) ?? 0) < 64)
            {
                bufferProp.SetValue(null, 64);
            }
        }
    }
}
