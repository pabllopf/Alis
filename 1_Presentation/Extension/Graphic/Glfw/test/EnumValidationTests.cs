

using System;
using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

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
            CursorMode normal = CursorMode.Normal;
            CursorMode hidden = CursorMode.Hidden;
            CursorMode disabled = CursorMode.Disabled;

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
            InputState release = InputState.Release;
            InputState press = InputState.Press;
            InputState repeat = InputState.Repeat;

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
            MouseButton button1 = MouseButton.Button1;
            MouseButton button2 = MouseButton.Button2;
            MouseButton button3 = MouseButton.Button3;

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
            Array keyValues = Enum.GetValues(typeof(Keys));

            Assert.True(keyValues.Length > 100, "Keys enum should have many key definitions");
        }

        /// <summary>
        ///     Test WindowAttribute enum values
        /// </summary>
        [Fact]
        public void WindowAttributeEnumValues_ShouldBeDefined()
        {
            WindowAttribute focused = WindowAttribute.Focused;
            WindowAttribute autoIconify = WindowAttribute.AutoIconify;
            WindowAttribute resizable = WindowAttribute.Resizable;

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
            ErrorCode none = ErrorCode.None;

            Assert.True(Enum.IsDefined(typeof(ErrorCode), none));
        }

        /// <summary>
        ///     Test ClientApi enum values
        /// </summary>
        [Fact]
        public void ClientApiEnumValues_ShouldBeDefined()
        {
            ClientApi none = ClientApi.None;
            ClientApi openGl = ClientApi.OpenGl;
            ClientApi openGles = ClientApi.OpenGles;

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
            ContextApi native = ContextApi.Native;

            Assert.True(Enum.IsDefined(typeof(ContextApi), native));
        }

        /// <summary>
        ///     Test ReleaseBehavior enum values
        /// </summary>
        [Fact]
        public void ReleaseBehaviorEnumValues_ShouldBeDefined()
        {
            ReleaseBehavior any = ReleaseBehavior.Any;
            ReleaseBehavior flush = ReleaseBehavior.Flush;
            ReleaseBehavior none = ReleaseBehavior.None;

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
            Robustness none = Robustness.None;
            Robustness noResetNotification = Robustness.NoResetNotification;
            Robustness loseContextOnReset = Robustness.LoseContextOnReset;

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
            ModifierKeys shift = ModifierKeys.Shift;
            ModifierKeys control = ModifierKeys.Control;
            ModifierKeys alt = ModifierKeys.Alt;
            ModifierKeys super = ModifierKeys.Super;

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
            Array cursorTypeValues = Enum.GetValues(typeof(CursorType));

            Assert.True(cursorTypeValues.Length > 0);
        }

        /// <summary>
        ///     Test Hint enum values
        /// </summary>
        [Fact]
        public void HintEnumValues_ShouldBeDefined()
        {
            Array hintValues = Enum.GetValues(typeof(Hint));

            Assert.True(hintValues.Length > 0);
        }

        /// <summary>
        ///     Test ContextAttributes enum values
        /// </summary>
        [Fact]
        public void ContextAttributesEnumValues_ShouldBeDefined()
        {
            Array contextAttribValues = Enum.GetValues(typeof(ContextAttributes));

            Assert.True(contextAttribValues.Length > 0);
        }

        /// <summary>
        ///     Test ConnectionStatus enum values
        /// </summary>
        [Fact]
        public void ConnectionStatusEnumValues_ShouldBeDefined()
        {
            Array connectionStatusValues = Enum.GetValues(typeof(ConnectionStatus));

            Assert.True(connectionStatusValues.Length > 0);
        }

        /// <summary>
        ///     Test CursorMode enum casting
        /// </summary>
        [Fact]
        public void CursorModeEnumCasting_ShouldSucceed()
        {
            CursorMode mode = CursorMode.Hidden;

            int value = (int) mode;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Test InputState enum casting
        /// </summary>
        [Fact]
        public void InputStateEnumCasting_ShouldSucceed()
        {
            InputState state = InputState.Press;

            int value = (int) state;

            Assert.True(value >= 0);
        }

        /// <summary>
        ///     Test MouseButton enum ordering
        /// </summary>
        [Fact]
        public void MouseButtonEnumOrdering_ShouldBeValid()
        {
            MouseButton button1 = MouseButton.Button1;
            MouseButton button2 = MouseButton.Button2;
            MouseButton button3 = MouseButton.Button3;

            int val1 = (int) button1;
            int val2 = (int) button2;
            int val3 = (int) button3;

            Assert.True(val1 != val2);
            Assert.True(val2 != val3);
        }

        /// <summary>
        ///     Test all enum types are defined
        /// </summary>
        [Fact]
        public void AllEnumTypesShouldBeDefined_ShouldPass()
        {
            Type[] enums = new[]
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

            foreach (Type enumType in enums)
            {
                Assert.NotNull(enumType);
                Assert.True(enumType.IsEnum, $"{enumType.Name} should be an enum");
            }
        }
    }
}