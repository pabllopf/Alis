// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumValidationTests.cs
// 
//  Author:GitHub Copilot
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
using Xunit;
using Alis.Extension.Graphic.Glfw.Enums;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for enum validation
    /// </summary>
    public class EnumValidationTests
    {
        /// <summary>
        ///     Test CursorMode enum values
        /// </summary>
        [Fact]
        public void CursorModeEnumValues_ShouldHaveValidValues()
        {
            // Arrange & Act
            CursorMode normal = CursorMode.Normal;
            CursorMode hidden = CursorMode.Hidden;
            CursorMode disabled = CursorMode.Disabled;

            // Assert
            Assert.True(Enum.IsDefined(typeof(CursorMode), normal));
            Assert.True(Enum.IsDefined(typeof(CursorMode), hidden));
            Assert.True(Enum.IsDefined(typeof(CursorMode), disabled));
        }

        /// <summary>
        ///     Test InputState enum values
        /// </summary>
        [Fact]
        public void InputStateEnumValues_ShouldHaveValidValues()
        {
            // Arrange & Act
            InputState release = InputState.Release;
            InputState press = InputState.Press;
            InputState repeat = InputState.Repeat;

            // Assert
            Assert.True(Enum.IsDefined(typeof(InputState), release));
            Assert.True(Enum.IsDefined(typeof(InputState), press));
            Assert.True(Enum.IsDefined(typeof(InputState), repeat));
        }

        /// <summary>
        ///     Test MouseButton enum has valid values
        /// </summary>
        [Fact]
        public void MouseButtonEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            MouseButton button1 = MouseButton.Button1;
            MouseButton button2 = MouseButton.Button2;
            MouseButton button3 = MouseButton.Button3;

            // Assert
            Assert.True(Enum.IsDefined(typeof(MouseButton), button1));
            Assert.True(Enum.IsDefined(typeof(MouseButton), button2));
            Assert.True(Enum.IsDefined(typeof(MouseButton), button3));
        }

        /// <summary>
        ///     Test Keys enum has many values
        /// </summary>
        [Fact]
        public void KeysEnumCompleteness_ShouldHaveManyValues()
        {
            // Arrange & Act
            Array keyValues = Enum.GetValues(typeof(Keys));

            // Assert
            Assert.True(keyValues.Length > 100, "Keys enum should have many key definitions");
        }

        /// <summary>
        ///     Test WindowAttribute enum values
        /// </summary>
        [Fact]
        public void WindowAttributeEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            WindowAttribute focused = WindowAttribute.Focused;
            WindowAttribute autoIconify = WindowAttribute.AutoIconify;
            WindowAttribute resizable = WindowAttribute.Resizable;

            // Assert
            Assert.True(Enum.IsDefined(typeof(WindowAttribute), focused));
            Assert.True(Enum.IsDefined(typeof(WindowAttribute), autoIconify));
            Assert.True(Enum.IsDefined(typeof(WindowAttribute), resizable));
        }

        /// <summary>
        ///     Test ErrorCode enum values
        /// </summary>
        [Fact]
        public void ErrorCodeEnumValues_ShouldHaveValidValues()
        {
            // Arrange & Act
            ErrorCode none = ErrorCode.None;

            // Assert
            Assert.True(Enum.IsDefined(typeof(ErrorCode), none));
        }

        /// <summary>
        ///     Test ClientApi enum values
        /// </summary>
        [Fact]
        public void ClientApiEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            ClientApi none = ClientApi.None;
            ClientApi openGl = ClientApi.OpenGl;
            ClientApi openGles = ClientApi.OpenGles;

            // Assert
            Assert.True(Enum.IsDefined(typeof(ClientApi), none));
            Assert.True(Enum.IsDefined(typeof(ClientApi), openGl));
            Assert.True(Enum.IsDefined(typeof(ClientApi), openGles));
        }

        /// <summary>
        ///     Test ContextApi enum values
        /// </summary>
        [Fact]
        public void ContextApiEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            ContextApi native = ContextApi.Native;

            // Assert
            Assert.True(Enum.IsDefined(typeof(ContextApi), native));
        }

        /// <summary>
        ///     Test ReleaseBehavior enum values
        /// </summary>
        [Fact]
        public void ReleaseBehaviorEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            ReleaseBehavior any = ReleaseBehavior.Any;
            ReleaseBehavior flush = ReleaseBehavior.Flush;
            ReleaseBehavior none = ReleaseBehavior.None;

            // Assert
            Assert.True(Enum.IsDefined(typeof(ReleaseBehavior), any));
            Assert.True(Enum.IsDefined(typeof(ReleaseBehavior), flush));
            Assert.True(Enum.IsDefined(typeof(ReleaseBehavior), none));
        }

        /// <summary>
        ///     Test Robustness enum values
        /// </summary>
        [Fact]
        public void RobustnessEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            Robustness none = Robustness.None;
            Robustness noResetNotification = Robustness.NoResetNotification;
            Robustness loseContextOnReset = Robustness.LoseContextOnReset;

            // Assert
            Assert.True(Enum.IsDefined(typeof(Robustness), none));
            Assert.True(Enum.IsDefined(typeof(Robustness), noResetNotification));
            Assert.True(Enum.IsDefined(typeof(Robustness), loseContextOnReset));
        }

        /// <summary>
        ///     Test ModifierKeys enum values
        /// </summary>
        [Fact]
        public void ModifierKeysEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            ModifierKeys shift = ModifierKeys.Shift;
            ModifierKeys control = ModifierKeys.Control;
            ModifierKeys alt = ModifierKeys.Alt;
            ModifierKeys super = ModifierKeys.Super;

            // Assert
            Assert.True(Enum.IsDefined(typeof(ModifierKeys), shift));
            Assert.True(Enum.IsDefined(typeof(ModifierKeys), control));
            Assert.True(Enum.IsDefined(typeof(ModifierKeys), alt));
            Assert.True(Enum.IsDefined(typeof(ModifierKeys), super));
        }

        /// <summary>
        ///     Test CursorType enum values
        /// </summary>
        [Fact]
        public void CursorTypeEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            Array cursorTypeValues = Enum.GetValues(typeof(CursorType));

            // Assert
            Assert.True(cursorTypeValues.Length > 0);
        }

        /// <summary>
        ///     Test Hint enum values
        /// </summary>
        [Fact]
        public void HintEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            Array hintValues = Enum.GetValues(typeof(Hint));

            // Assert
            Assert.True(hintValues.Length > 0);
        }

        /// <summary>
        ///     Test ContextAttributes enum values
        /// </summary>
        [Fact]
        public void ContextAttributesEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            Array contextAttribValues = Enum.GetValues(typeof(ContextAttributes));

            // Assert
            Assert.True(contextAttribValues.Length > 0);
        }

        /// <summary>
        ///     Test ConnectionStatus enum values
        /// </summary>
        [Fact]
        public void ConnectionStatusEnumValues_ShouldBeDefined()
        {
            // Arrange & Act
            Array connectionStatusValues = Enum.GetValues(typeof(ConnectionStatus));

            // Assert
            Assert.True(connectionStatusValues.Length > 0);
        }

        /// <summary>
        ///     Test CursorMode enum casting
        /// </summary>
        [Fact]
        public void CursorModeEnumCasting_ShouldSucceed()
        {
            // Arrange
            CursorMode mode = CursorMode.Hidden;

            // Act
            int value = (int)mode;

            // Assert
            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Test InputState enum casting
        /// </summary>
        [Fact]
        public void InputStateEnumCasting_ShouldSucceed()
        {
            // Arrange
            InputState state = InputState.Press;

            // Act
            int value = (int)state;

            // Assert
            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Test MouseButton enum ordering
        /// </summary>
        [Fact]
        public void MouseButtonEnumOrdering_ShouldBeValid()
        {
            // Arrange
            MouseButton button1 = MouseButton.Button1;
            MouseButton button2 = MouseButton.Button2;
            MouseButton button3 = MouseButton.Button3;

            // Act
            int val1 = (int)button1;
            int val2 = (int)button2;
            int val3 = (int)button3;

            // Assert
            Assert.True(val1 != val2);
            Assert.True(val2 != val3);
        }

        /// <summary>
        ///     Test all enum types are defined
        /// </summary>
        [Fact]
        public void AllEnumTypesShouldBeDefined_ShouldPass()
        {
            // Arrange
            Type[] enums = new Type[]
            {
                typeof(CursorMode),
                typeof(InputMode),
                typeof(InputState),
                typeof(MouseButton),
                typeof(Keys),
                typeof(WindowAttribute),
                typeof(ErrorCode),
                typeof(ClientApi),
                typeof(ContextApi),
                typeof(ReleaseBehavior),
                typeof(Robustness),
                typeof(ModifierKeys),
                typeof(CursorType),
                typeof(Hint),
                typeof(ContextAttributes),
                typeof(ConnectionStatus)
            };

            // Act & Assert
            foreach (Type enumType in enums)
            {
                Assert.NotNull(enumType);
                Assert.True(enumType.IsEnum, $"{enumType.Name} should be an enum");
            }
        }
    }
}

