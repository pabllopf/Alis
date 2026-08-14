// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SensorTests.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    /// The sensor tests class
    /// </summary>
    public class SensorTests
    {
        /// <summary>
        /// Tests that is available invoke does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsAvailable_Invoke_DoesNotThrow()
        {
            bool result = Sensor.IsAvailable(Sensor.Type.Accelerometer);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is available invoke with gyroscope returns false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsAvailable_Invoke_WithGyroscope_ReturnsFalse()
        {
            bool result = Sensor.IsAvailable(Sensor.Type.Gyroscope);
            Assert.False(result);
        }

        /// <summary>
        /// Tests that is available invoke with all types returns false
        /// </summary>
        [RequireCSfmlSystemFact]
        public void IsAvailable_Invoke_WithAllTypes_ReturnsFalse()
        {
            foreach (Sensor.Type type in Enum.GetValues(typeof(Sensor.Type)))
            {
                if (type == Sensor.Type.TypeCount)
                {
                    continue;
                }

                bool result = Sensor.IsAvailable(type);
                Assert.False(result);
            }
        }

        /// <summary>
        /// Tests that set enabled invoke does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetEnabled_Invoke_DoesNotThrow()
        {
            Sensor.SetEnabled(Sensor.Type.Accelerometer, true);
        }

        /// <summary>
        /// Tests that set enabled invoke with false does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetEnabled_Invoke_WithFalse_DoesNotThrow()
        {
            Sensor.SetEnabled(Sensor.Type.Gyroscope, false);
        }

        /// <summary>
        /// Tests that set enabled invoke with all types does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SetEnabled_Invoke_WithAllTypes_DoesNotThrow()
        {
            foreach (Sensor.Type type in Enum.GetValues(typeof(Sensor.Type)))
            {
                if (type == Sensor.Type.TypeCount)
                {
                    continue;
                }

                Sensor.SetEnabled(type, true);
            }
        }

        /// <summary>
        /// Tests that get value invoke does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetValue_Invoke_DoesNotThrow()
        {
            Vector3F result = Sensor.GetValue(Sensor.Type.Accelerometer);
            _ = result.X;
            _ = result.Y;
            _ = result.Z;
        }

        /// <summary>
        /// Tests that get value invoke with gyroscope does not throw
        /// </summary>
        [RequireCSfmlSystemFact]
        public void GetValue_Invoke_WithGyroscope_DoesNotThrow()
        {
            Vector3F result = Sensor.GetValue(Sensor.Type.Gyroscope);
            _ = result.X;
            _ = result.Y;
            _ = result.Z;
        }

        /// <summary>
        /// Tests that sf sensor is available dll import exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfSensor_isAvailable_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Sensor).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfSensor_isAvailable"))
                {
                    method = mi;
                    break;
                }
            }

            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        /// <summary>
        /// Tests that sf sensor set enabled dll import exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfSensor_setEnabled_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Sensor).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfSensor_setEnabled"))
                {
                    method = mi;
                    break;
                }
            }

            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        /// <summary>
        /// Tests that sf sensor get value dll import exists
        /// </summary>
        [RequireCSfmlSystemFact]
        public void SfSensor_getValue_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Sensor).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfSensor_getValue"))
                {
                    method = mi;
                    break;
                }
            }

            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        /// <summary>
        /// Tests that is available throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsAvailable_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => Sensor.IsAvailable(Sensor.Type.Accelerometer));
            }
        }

        /// <summary>
        /// Tests that set enabled throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetEnabled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => Sensor.SetEnabled(Sensor.Type.Accelerometer, true));
            }
        }

        /// <summary>
        /// Tests that get value throws when native library is unavailable
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void GetValue_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => Sensor.GetValue(Sensor.Type.Accelerometer));
            }
        }

        /// <summary>
        /// Determines whether the csfml window native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadWindowLibrary()
        {
            if (NativeLibrary.TryLoad("csfml-window", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(Alis.Extension.Graphic.Sfml.Test.Attributes.RequireCSfmlSystemFactAttribute).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "csfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
