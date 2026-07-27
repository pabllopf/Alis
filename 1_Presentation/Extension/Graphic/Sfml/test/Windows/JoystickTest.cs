// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoystickTest.cs
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

using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class JoystickTest
    {
        [Fact]
        public void Axis_Enum_HasCorrectValues()
        {
            Assert.Equal(0, (int)Joystick.Axis.X);
            Assert.Equal(1, (int)Joystick.Axis.Y);
            Assert.Equal(2, (int)Joystick.Axis.Z);
            Assert.Equal(3, (int)Joystick.Axis.R);
            Assert.Equal(4, (int)Joystick.Axis.U);
            Assert.Equal(5, (int)Joystick.Axis.V);
            Assert.Equal(6, (int)Joystick.Axis.PovX);
            Assert.Equal(7, (int)Joystick.Axis.PovY);
        }

        [Fact]
        public void Constants_AreCorrect()
        {
            Assert.Equal(8u, Joystick.Count);
            Assert.Equal(32u, Joystick.ButtonCount);
            Assert.Equal(8u, Joystick.AxisCount);
        }

        [Fact]
        public void IsConnected_Invoke_ReturnsFalse()
        {
            bool result = Joystick.IsConnected(0);
            Assert.False(result);
        }

        [Fact]
        public void IsConnected_Invoke_WithMaxJoystick_ReturnsFalse()
        {
            bool result = Joystick.IsConnected(7);
            Assert.False(result);
        }

        [Fact]
        public void GetButtonCount_Invoke_ReturnsZero()
        {
            uint result = Joystick.GetButtonCount(0);
            Assert.Equal(0u, result);
        }

        [Fact]
        public void GetButtonCount_Invoke_WithMaxJoystick_ReturnsZero()
        {
            uint result = Joystick.GetButtonCount(7);
            Assert.Equal(0u, result);
        }

        [Fact]
        public void HasAxis_Invoke_WithX_ReturnsFalse()
        {
            bool result = Joystick.HasAxis(0, Joystick.Axis.X);
            Assert.False(result);
        }

        [Fact]
        public void HasAxis_Invoke_WithAllAxes_ReturnsFalse()
        {
            foreach (Joystick.Axis axis in System.Enum.GetValues(typeof(Joystick.Axis)))
            {
                bool result = Joystick.HasAxis(0, axis);
                Assert.False(result);
            }
        }

        [Fact]
        public void IsButtonPressed_Invoke_ReturnsFalse()
        {
            bool result = Joystick.IsButtonPressed(0, 0);
            Assert.False(result);
        }

        [Fact]
        public void IsButtonPressed_Invoke_WithMaxButton_ReturnsFalse()
        {
            bool result = Joystick.IsButtonPressed(0, 31);
            Assert.False(result);
        }

        [Fact]
        public void GetAxisPosition_Invoke_ReturnsZero()
        {
            float result = Joystick.GetAxisPosition(0, Joystick.Axis.X);
            Assert.Equal(0f, result);
        }

        [Fact]
        public void GetAxisPosition_Invoke_WithAllAxes_ReturnsZero()
        {
            foreach (Joystick.Axis axis in System.Enum.GetValues(typeof(Joystick.Axis)))
            {
                float result = Joystick.GetAxisPosition(0, axis);
                Assert.Equal(0f, result);
            }
        }

        [Fact]
        public void Update_Invoke_DoesNotThrow()
        {
            Joystick.Update();
        }

        [Fact]
        public void GetIdentification_Invoke_DoesNotThrow()
        {
            Joystick.Identification result = Joystick.GetIdentification(0);
            Assert.NotNull(result);
        }

        [Fact]
        public void GetIdentification_Invoke_ReturnsNonEmptyName()
        {
            Joystick.Identification result = Joystick.GetIdentification(0);
            Assert.NotNull(result.Name);
            Assert.NotEmpty(result.Name);
        }

        [Fact]
        public void Identification_Struct_HasProperties()
        {
            System.Type identType = typeof(Joystick.Identification);
            Assert.NotNull(identType.GetProperty("Name"));
            Assert.NotNull(identType.GetProperty("VendorId"));
            Assert.NotNull(identType.GetProperty("ProductId"));
        }

        [Fact]
        public void Identification_Struct_CanSetProperties()
        {
            Joystick.Identification ident = new Joystick.Identification
            {
                Name = "TestJoystick",
                VendorId = 1234u,
                ProductId = 5678u
            };
            Assert.Equal("TestJoystick", ident.Name);
            Assert.Equal(1234u, ident.VendorId);
            Assert.Equal(5678u, ident.ProductId);
        }

        [Fact]
        public void SfJoystick_isConnected_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_isConnected"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_getButtonCount_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_getButtonCount"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_hasAxis_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_hasAxis"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_isButtonPressed_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_isButtonPressed"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_getAxisPosition_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_getAxisPosition"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_update_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_update"))
                {
                    method = mi;
                    break;
                }
            }
            Assert.NotNull(method);
            Assert.NotNull(method.GetCustomAttribute<DllImportAttribute>());
        }

        [Fact]
        public void SfJoystick_getIdentification_DllImport_Exists()
        {
            MethodInfo[] methods = typeof(Joystick).GetMethods(BindingFlags.Static | BindingFlags.NonPublic);
            MethodInfo method = null;
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name.Contains("sfJoystick_getIdentification"))
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
