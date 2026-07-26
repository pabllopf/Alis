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
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class SensorTests
    {
        [Fact]
        public void IsAvailable_Invoke_DoesNotThrow()
        {
            bool result = Sensor.IsAvailable(Sensor.Type.Accelerometer);
            Assert.False(result);
        }

        [Fact]
        public void IsAvailable_Invoke_WithGyroscope_ReturnsFalse()
        {
            bool result = Sensor.IsAvailable(Sensor.Type.Gyroscope);
            Assert.False(result);
        }

        [Fact]
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

        [Fact]
        public void SetEnabled_Invoke_DoesNotThrow()
        {
            Sensor.SetEnabled(Sensor.Type.Accelerometer, true);
        }

        [Fact]
        public void SetEnabled_Invoke_WithFalse_DoesNotThrow()
        {
            Sensor.SetEnabled(Sensor.Type.Gyroscope, false);
        }

        [Fact]
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

        [Fact]
        public void GetValue_Invoke_DoesNotThrow()
        {
            Vector3F result = Sensor.GetValue(Sensor.Type.Accelerometer);
            _ = result.X;
            _ = result.Y;
            _ = result.Z;
        }

        [Fact]
        public void GetValue_Invoke_WithGyroscope_DoesNotThrow()
        {
            Vector3F result = Sensor.GetValue(Sensor.Type.Gyroscope);
            _ = result.X;
            _ = result.Y;
            _ = result.Z;
        }

        [Fact]
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

        [Fact]
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

        [Fact]
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
    }
}
