// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumsTest.cs
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

using Alis.Extension.Graphic.Sdl2.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    ///     The enums test class
    /// </summary>
    public class EnumsTest
    {
        /// <summary>
        ///     The array order test class
        /// </summary>
        public class ArrayOrderTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)ArrayOrder.SdlArrayOrderNone);
                Assert.Equal(1, (int)ArrayOrder.SdlArrayOrderRgb);
                Assert.Equal(2, (int)ArrayOrder.SdlArrayOrderRgba);
                Assert.Equal(3, (int)ArrayOrder.SdlArrayOrderArgb);
                Assert.Equal(4, (int)ArrayOrder.SdlArrayOrderBgr);
                Assert.Equal(5, (int)ArrayOrder.SdlArrayOrderBgrA);
                Assert.Equal(6, (int)ArrayOrder.SdlArrayOrderAbgR);
            }
        }

        /// <summary>
        ///     The attr test class
        /// </summary>
        public class AttrTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)Attr.SdlGlRedSize);
                Assert.Equal(1, (int)Attr.SdlGlGreenSize);
                Assert.Equal(14, (int)Attr.SdlGlMultiSampleSamples);
                Assert.Equal(26, (int)Attr.SdlGlContextNoError);
            }
        }

        /// <summary>
        ///     The audio allow test class
        /// </summary>
        public class AudioAllowTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(1u, (uint)AudioAllow.AudioAllowFrequencyChange);
                Assert.Equal(2u, (uint)AudioAllow.AudioAllowFormatChange);
                Assert.Equal(4u, (uint)AudioAllow.AudioAllowChannelsChange);
                Assert.Equal(8u, (uint)AudioAllow.AudioAllowSamplesChange);
                Assert.Equal(0xFu, (uint)AudioAllow.AudioAllowAnyChange);
            }
        }

        /// <summary>
        ///     The audio status test class
        /// </summary>
        public class AudioStatusTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)AudioStatus.SdlAudioStopped);
                Assert.Equal(1, (int)AudioStatus.SdlAudioPlaying);
                Assert.Equal(2, (int)AudioStatus.SdlAudioPaused);
            }
        }

        /// <summary>
        ///     The bitmap order test class
        /// </summary>
        public class BitmapOrderTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)BitmapOrder.BitMapOrderNone);
                Assert.Equal(1, (int)BitmapOrder.BitMapOrder4321);
                Assert.Equal(2, (int)BitmapOrder.BitMapOrder1234);
            }
        }

        /// <summary>
        ///     The blend factor test class
        /// </summary>
        public class BlendFactorTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x1, (int)BlendFactor.SdlBlendFactorZero);
                Assert.Equal(0x2, (int)BlendFactor.SdlBlendFactorOne);
                Assert.Equal(0x5, (int)BlendFactor.SdlBlendFactorSrcAlpha);
                Assert.Equal(0xA, (int)BlendFactor.SdlBlendFactorOneMinusDstAlpha);
            }
        }

        /// <summary>
        ///     The blend modes test class
        /// </summary>
        public class BlendModesTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)BlendModes.None);
                Assert.Equal(0x1, (int)BlendModes.BlendModeBlend);
                Assert.Equal(0x2, (int)BlendModes.BlendModeAdd);
                Assert.Equal(0x4, (int)BlendModes.BlendModeMod);
                Assert.Equal(0x8, (int)BlendModes.BlendModeMul);
                Assert.Equal(0x7FFFFFFF, (int)BlendModes.BlendModeInvalid);
            }
        }

        /// <summary>
        ///     The blend operation test class
        /// </summary>
        public class BlendOperationTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x1, (int)BlendOperation.SdlBlendOperationAdd);
                Assert.Equal(0x2, (int)BlendOperation.SdlBlendOperationSubtract);
                Assert.Equal(0x5, (int)BlendOperation.SdlBlendOperationMaximum);
            }
        }

        /// <summary>
        ///     The display event id test class
        /// </summary>
        public class DisplayEventIdTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)DisplayEventId.SdlDisplayEventNone);
                Assert.Equal(1, (int)DisplayEventId.SdlDisplayEventOrientation);
                Assert.Equal(2, (int)DisplayEventId.SdlDisplayEventConnected);
                Assert.Equal(3, (int)DisplayEventId.SdlDisplayEventDisconnected);
            }
        }

        /// <summary>
        ///     The display orientation test class
        /// </summary>
        public class DisplayOrientationTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)DisplayOrientation.SdlOrientationUnknown);
                Assert.Equal(1, (int)DisplayOrientation.SdlOrientationLandscape);
                Assert.Equal(3, (int)DisplayOrientation.SdlOrientationPortrait);
                Assert.Equal(4, (int)DisplayOrientation.SdlOrientationPortraitFlipped);
            }
        }

        /// <summary>
        ///     The event action test class
        /// </summary>
        public class EventActionTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)EventAction.SdlAddEvent);
                Assert.Equal(1, (int)EventAction.SdlPeekEvent);
                Assert.Equal(2, (int)EventAction.SdlGetEvent);
            }
        }

        /// <summary>
        ///     The event type test class
        /// </summary>
        public class EventTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0u, (uint)EventType.FirstEvent);
                Assert.Equal(0x100u, (uint)EventType.Quit);
                Assert.Equal(0x200u, (uint)EventType.WindowEvent);
                Assert.Equal(0x300u, (uint)EventType.Keydown);
                Assert.Equal(0x301u, (uint)EventType.Keyup);
                Assert.Equal(0x400u, (uint)EventType.MouseMotion);
                Assert.Equal(0x600u, (uint)EventType.JoyAxisMotion);
                Assert.Equal(0x650u, (uint)EventType.ControllerAxisMotion);
                Assert.Equal(0x700u, (uint)EventType.FingerDown);
                Assert.Equal(0x800u, (uint)EventType.DollarGesture);
                Assert.Equal(0x8000u, (uint)EventType.UserEvent);
                Assert.Equal(0xFFFFu, (uint)EventType.LastEvent);
            }
        }

        /// <summary>
        ///     The flash operation test class
        /// </summary>
        public class FlashOperationTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)FlashOperation.SdlFlashCancel);
                Assert.Equal(1, (int)FlashOperation.SdlFlashBriefly);
                Assert.Equal(2, (int)FlashOperation.SdlFlashUntilFocused);
            }
        }

        /// <summary>
        ///     The game controller axis test class
        /// </summary>
        public class GameControllerAxisTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(-1, (int)GameControllerAxis.SdlControllerAxisInvalid);
                Assert.Equal(0, (int)GameControllerAxis.SdlControllerAxisLeftX);
                Assert.Equal(1, (int)GameControllerAxis.SdlControllerAxisLeftY);
                Assert.Equal(4, (int)GameControllerAxis.SdlControllerAxisTriggerLeft);
                Assert.Equal(5, (int)GameControllerAxis.SdlControllerAxisTriggerRight);
                Assert.Equal(6, (int)GameControllerAxis.SdlControllerAxisMax);
            }
        }

        /// <summary>
        ///     The game controller bind type test class
        /// </summary>
        public class GameControllerBindTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)GameControllerBindType.SdlControllerBindTypeNone);
                Assert.Equal(1, (int)GameControllerBindType.SdlControllerBindTypeButton);
                Assert.Equal(2, (int)GameControllerBindType.SdlControllerBindTypeAxis);
                Assert.Equal(3, (int)GameControllerBindType.SdlControllerBindTypeHat);
            }
        }

        /// <summary>
        ///     The game controller button test class
        /// </summary>
        public class GameControllerButtonTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(-1, (int)GameControllerButton.SdlControllerButtonInvalid);
                Assert.Equal(0, (int)GameControllerButton.SdlControllerButtonA);
                Assert.Equal(1, (int)GameControllerButton.SdlControllerButtonB);
                Assert.Equal(2, (int)GameControllerButton.SdlControllerButtonX);
                Assert.Equal(3, (int)GameControllerButton.SdlControllerButtonY);
                Assert.Equal(21, (int)GameControllerButton.SdlControllerButtonMax);
            }
        }

        /// <summary>
        ///     The haptic test class
        /// </summary>
        public class HapticTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)Haptic.HapticPolar);
                Assert.Equal(1, (int)Haptic.HapticCartesian);
                Assert.Equal(2, (int)Haptic.HapticSpherical);
                Assert.Equal(3, (int)Haptic.HapticSteeringAxis);
            }
        }

        /// <summary>
        ///     The haptic constant test class
        /// </summary>
        public class HapticConstantTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(1u, (ushort)HapticConstant.HapticConstant);
                Assert.Equal(2u, (ushort)HapticConstant.HapticSine);
                Assert.Equal(4u, (ushort)HapticConstant.HapticLeftRight);
                Assert.Equal(8u, (ushort)HapticConstant.HapticTriangle);
                Assert.Equal(16u, (ushort)HapticConstant.HapticSawToothUp);
                Assert.Equal(2048u, (ushort)HapticConstant.HapticCustom);
                Assert.Equal(32768u, (ushort)HapticConstant.HapticPauseVar);
            }
        }

        /// <summary>
        ///     The hat test class
        /// </summary>
        public class HatTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x00, (int)Hat.Centered);
                Assert.Equal(0x01, (int)Hat.Up);
                Assert.Equal(0x02, (int)Hat.Right);
                Assert.Equal(0x04, (int)Hat.Down);
                Assert.Equal(0x08, (int)Hat.Left);
                Assert.Equal(0x03, (int)Hat.RightUp);
                Assert.Equal(0x06, (int)Hat.RightDown);
                Assert.Equal(0x09, (int)Hat.LeftUp);
                Assert.Equal(0x0C, (int)Hat.LeftDown);
            }

            /// <summary>
            ///     Tests that combined values are bitwise or
            /// </summary>
            [RequireSdl2ImageFact]
            public void CombinedValues_AreBitwiseOr()
            {
                Assert.Equal((int)Hat.RightUp, (int)Hat.Right | (int)Hat.Up);
                Assert.Equal((int)Hat.RightDown, (int)Hat.Right | (int)Hat.Down);
                Assert.Equal((int)Hat.LeftUp, (int)Hat.Left | (int)Hat.Up);
                Assert.Equal((int)Hat.LeftDown, (int)Hat.Left | (int)Hat.Down);
            }
        }

        /// <summary>
        ///     The hint priority test class
        /// </summary>
        public class HintPriorityTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)HintPriority.SdlHintDefault);
                Assert.Equal(1, (int)HintPriority.SdlHintNormal);
                Assert.Equal(2, (int)HintPriority.SdlHintOverride);
            }
        }

        /// <summary>
        ///     The hit test result test class
        /// </summary>
        public class HitTestResultTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)HitTestResult.SdlHitTestNormal);
                Assert.Equal(1, (int)HitTestResult.SdlHitTestDraggable);
                Assert.Equal(2, (int)HitTestResult.SdlHitTestResizeTopLeft);
                Assert.Equal(9, (int)HitTestResult.SdlHitTestResizeLeft);
            }
        }

        /// <summary>
        ///     The init settings test class
        /// </summary>
        public class InitSettingsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x00000001u, (uint)InitSettings.InitTimer);
                Assert.Equal(0x00000010u, (uint)InitSettings.InitAudio);
                Assert.Equal(0x00000020u, (uint)InitSettings.InitVideo);
                Assert.Equal(0x00000200u, (uint)InitSettings.InitJoystick);
                Assert.Equal(0x00001000u, (uint)InitSettings.InitHaptic);
                Assert.Equal(0x00002000u, (uint)InitSettings.InitGameController);
                Assert.Equal(0x00004000u, (uint)InitSettings.InitEvents);
                Assert.Equal(0x00008000u, (uint)InitSettings.InitSensor);
            }

            /// <summary>
            ///     Tests that init everything includes all flags
            /// </summary>
            [RequireSdl2ImageFact]
            public void InitEverything_IncludesAllFlags()
            {
                InitSettings expected = InitSettings.InitTimer | InitSettings.InitAudio | InitSettings.InitVideo | InitSettings.InitJoystick | InitSettings.InitHaptic | InitSettings.InitGameController | InitSettings.InitEvents | InitSettings.InitSensor;
                Assert.Equal(expected, InitSettings.InitEverything);
            }
        }

        /// <summary>
        ///     The joystick power level test class
        /// </summary>
        public class JoystickPowerLevelTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(-1, (int)JoystickPowerLevel.SdlJoystickPowerUnknown);
                Assert.Equal(0, (int)JoystickPowerLevel.SdlJoystickPowerEmpty);
                Assert.Equal(1, (int)JoystickPowerLevel.SdlJoystickPowerLow);
                Assert.Equal(2, (int)JoystickPowerLevel.SdlJoystickPowerMedium);
                Assert.Equal(3, (int)JoystickPowerLevel.SdlJoystickPowerFull);
                Assert.Equal(4, (int)JoystickPowerLevel.SdlJoystickPowerWired);
                Assert.Equal(5, (int)JoystickPowerLevel.SdlJoystickPowerMax);
            }
        }

        /// <summary>
        ///     The joystick type test class
        /// </summary>
        public class JoystickTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)JoystickType.SdlJoystickTypeUnknown);
                Assert.Equal(1, (int)JoystickType.SdlJoystickTypeGameController);
                Assert.Equal(8, (int)JoystickType.SdlJoystickTypeArcadePad);
            }
        }

        /// <summary>
        ///     The key mods test class
        /// </summary>
        public class KeyModsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x0000, (int)KeyMods.None);
                Assert.Equal(0x0001, (int)KeyMods.KModLShift);
                Assert.Equal(0x0002, (int)KeyMods.KModRShift);
                Assert.Equal(0x0040, (int)KeyMods.KModLCtrl);
                Assert.Equal(0x0080, (int)KeyMods.KModRCtrl);
                Assert.Equal(0x0100, (int)KeyMods.KModLAlt);
                Assert.Equal(0x0200, (int)KeyMods.KModRAlt);
                Assert.Equal(0x0400, (int)KeyMods.KModLGui);
                Assert.Equal(0x0800, (int)KeyMods.KModRGui);
                Assert.Equal(0x1000, (ushort)KeyMods.KModNum);
                Assert.Equal(0x2000, (ushort)KeyMods.KModCaps);
                Assert.Equal(0x4000, (ushort)KeyMods.KModMode);
                Assert.Equal(0x8000, (ushort)KeyMods.KModScroll);
                Assert.Equal(0x00C0, (int)KeyMods.KModCtrl);
                Assert.Equal(0x0003, (int)KeyMods.KModShift);
            }

            /// <summary>
            ///     Tests that ctrl is l ctrl or r ctrl
            /// </summary>
            [RequireSdl2ImageFact]
            public void Ctrl_IsLCtrlOrRCtrl()
            {
                Assert.Equal((int)(KeyMods.KModLCtrl | KeyMods.KModRCtrl), (int)KeyMods.KModCtrl);
            }

            /// <summary>
            ///     Tests that shift is l shift or r shift
            /// </summary>
            [RequireSdl2ImageFact]
            public void Shift_IsLShiftOrRShift()
            {
                Assert.Equal((int)(KeyMods.KModLShift | KeyMods.KModRShift), (int)KeyMods.KModShift);
            }
        }

        /// <summary>
        ///     The log category test class
        /// </summary>
        public class LogCategoryTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)LogCategory.SdlLogCategoryApplication);
                Assert.Equal(1, (int)LogCategory.SdlLogCategoryError);
                Assert.Equal(2, (int)LogCategory.SdlLogCategoryAssert);
                Assert.Equal(4, (int)LogCategory.SdlLogCategoryAudio);
                Assert.Equal(5, (int)LogCategory.SdlLogCategoryVideo);
                Assert.Equal(6, (int)LogCategory.SdlLogCategoryRender);
                Assert.Equal(7, (int)LogCategory.SdlLogCategoryInput);
                Assert.Equal(8, (int)LogCategory.SdlLogCategoryTest);
                Assert.Equal(19, (int)LogCategory.SdlLogCategoryCustom);
            }
        }

        /// <summary>
        ///     The log priority test class
        /// </summary>
        public class LogPriorityTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(1, (int)LogPriority.SdlLogPriorityVerbose);
                Assert.Equal(2, (int)LogPriority.SdlLogPriorityDebug);
                Assert.Equal(3, (int)LogPriority.SdlLogPriorityInfo);
                Assert.Equal(4, (int)LogPriority.SdlLogPriorityWarn);
                Assert.Equal(5, (int)LogPriority.SdlLogPriorityError);
                Assert.Equal(6, (int)LogPriority.SdlLogPriorityCritical);
                Assert.Equal(7, (int)LogPriority.SdlNumLogPriorities);
            }
        }

        /// <summary>
        ///     The mouse wheel direction test class
        /// </summary>
        public class MouseWheelDirectionTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0u, (uint)MouseWheelDirection.SdlMousewheelNormal);
                Assert.Equal(1u, (uint)MouseWheelDirection.SdlMousewheelFlipped);
            }
        }

        /// <summary>
        ///     The packed layout test class
        /// </summary>
        public class PackedLayoutTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)PackedLayout.PackedLayoutNone);
                Assert.Equal(1, (int)PackedLayout.PackedLayout332);
                Assert.Equal(2, (int)PackedLayout.PackedLayout4444);
                Assert.Equal(3, (int)PackedLayout.PackedLayout1555);
                Assert.Equal(4, (int)PackedLayout.PackedLayout5551);
                Assert.Equal(6, (int)PackedLayout.PackedLayout8888);
                Assert.Equal(7, (int)PackedLayout.PackedLayout2101010);
                Assert.Equal(8, (int)PackedLayout.PackedLayout1010102);
            }
        }

        /// <summary>
        ///     The packed order test class
        /// </summary>
        public class PackedOrderTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)PackedOrder.PackedOrderNone);
                Assert.Equal(1, (int)PackedOrder.PackedOrderXRgb);
                Assert.Equal(2, (int)PackedOrder.PackedOrderRGbx);
                Assert.Equal(3, (int)PackedOrder.PackedOrderARgb);
                Assert.Equal(4, (int)PackedOrder.PackedOrderRGba);
                Assert.Equal(5, (int)PackedOrder.PackedOrderXBgr);
                Assert.Equal(6, (int)PackedOrder.PackedOrderBGrx);
                Assert.Equal(7, (int)PackedOrder.PackedOrderABgr);
                Assert.Equal(8, (int)PackedOrder.PackedOrderBGra);
            }
        }

        /// <summary>
        ///     The power state test class
        /// </summary>
        public class PowerStateTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)PowerState.SdlPowerStateUnknown);
                Assert.Equal(1, (int)PowerState.SdlPowerStateOnBattery);
                Assert.Equal(2, (int)PowerState.SdlPowerStateNoBattery);
                Assert.Equal(3, (int)PowerState.SdlPowerStateCharging);
                Assert.Equal(4, (int)PowerState.SdlPowerStateCharged);
            }
        }

        /// <summary>
        ///     The profiles test class
        /// </summary>
        public class ProfilesTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x0001, (int)Profiles.SdlGlContextProfileCore);
                Assert.Equal(0x0002, (int)Profiles.SdlGlContextProfileCompatibility);
                Assert.Equal(0x0004, (int)Profiles.SdlGlContextProfileEs);
            }
        }

        /// <summary>
        ///     The renderers test class
        /// </summary>
        public class RenderersTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0u, (uint)Renderers.None);
                Assert.Equal(1u, (uint)Renderers.SdlRendererSoftware);
                Assert.Equal(2u, (uint)Renderers.SdlRendererAccelerated);
                Assert.Equal(4u, (uint)Renderers.SdlRendererPresentVSync);
                Assert.Equal(8u, (uint)Renderers.SdlRendererTargetTexture);
            }
        }

        /// <summary>
        ///     The renderer flips test class
        /// </summary>
        public class RendererFlipsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)RendererFlips.None);
                Assert.Equal(1, (int)RendererFlips.FlipHorizontal);
                Assert.Equal(2, (int)RendererFlips.FlipVertical);
            }
        }

        /// <summary>
        ///     The rw ops test class
        /// </summary>
        public class RwOpsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0u, (uint)RwOps.RwOpsUnknown);
                Assert.Equal(1u, (uint)RwOps.RwOpsWinFile);
                Assert.Equal(2u, (uint)RwOps.RwOpsStdFile);
                Assert.Equal(5u, (uint)RwOps.RwOpsMemoryRo);
            }
        }

        /// <summary>
        ///     The rw seek test class
        /// </summary>
        public class RwSeekTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)RwSeek.RwSeekSet);
                Assert.Equal(1, (int)RwSeek.RwSeekCur);
                Assert.Equal(2, (int)RwSeek.RwSeekEnd);
            }
        }

        /// <summary>
        ///     The scale mode test class
        /// </summary>
        public class ScaleModeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)ScaleMode.SdlScaleModeNearest);
                Assert.Equal(1, (int)ScaleMode.SdlScaleModeLinear);
                Assert.Equal(2, (int)ScaleMode.SdlScaleModeBest);
            }
        }

        /// <summary>
        ///     The sdl2 contexts test class
        /// </summary>
        public class Sdl2ContextsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x0001, (int)Sdl2Contexts.SdlGlContextDebugFlag);
                Assert.Equal(0x0002, (int)Sdl2Contexts.SdlGlContextForwardCompatibleFlag);
                Assert.Equal(0x0004, (int)Sdl2Contexts.SdlGlContextRobustAccessFlag);
                Assert.Equal(0x0008, (int)Sdl2Contexts.SdlGlContextResetIsolationFlag);
            }
        }

        /// <summary>
        ///     The sensor type test class
        /// </summary>
        public class SensorTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(-1, (int)SensorType.SdlSensorInvalid);
                Assert.Equal(0, (int)SensorType.SdlSensorUnknown);
                Assert.Equal(1, (int)SensorType.SdlSensorAccel);
                Assert.Equal(2, (int)SensorType.SdlSensorGyro);
            }
        }

        /// <summary>
        ///     The sys wm type test class
        /// </summary>
        public class SysWmTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)SysWmType.SdlSysWmUnknown);
                Assert.Equal(1, (int)SysWmType.SdlSysWmWindows);
                Assert.Equal(2, (int)SysWmType.SdlSysWmX11);
                Assert.Equal(6, (int)SysWmType.SdlSysWmWayland);
            }
        }

        /// <summary>
        ///     The system cursor test class
        /// </summary>
        public class SystemCursorTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)SystemCursor.SdlSystemCursorArrow);
                Assert.Equal(2, (int)SystemCursor.SdlSystemCursorWait);
                Assert.Equal(10, (int)SystemCursor.SdlSystemCursorNo);
                Assert.Equal(5, (int)SystemCursor.SdlSystemCursorSizeNwSe);
                Assert.Equal(12, (int)SystemCursor.SdlNumSystemCursors);
            }
        }

        /// <summary>
        ///     The texture access test class
        /// </summary>
        public class TextureAccessTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)TextureAccess.None);
                Assert.Equal(1, (int)TextureAccess.SdlTextureAccessStreaming);
                Assert.Equal(2, (int)TextureAccess.SdlTextureAccessTarget);
            }
        }

        /// <summary>
        ///     The texture modulates test class
        /// </summary>
        public class TextureModulatesTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)TextureModulates.None);
                Assert.Equal(1, (int)TextureModulates.SdlTextureModulateHorizontal);
                Assert.Equal(2, (int)TextureModulates.SdlTextureModulateVertical);
            }
        }

        /// <summary>
        ///     The touch device type test class
        /// </summary>
        public class TouchDeviceTypeTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(-1, (int)TouchDeviceType.SdlTouchDeviceInvalid);
                Assert.Equal(0, (int)TouchDeviceType.SdlTouchDeviceDirect);
                Assert.Equal(1, (int)TouchDeviceType.SdlTouchDeviceIndirectAbsolute);
                Assert.Equal(2, (int)TouchDeviceType.SdlTouchDeviceIndirectRelative);
            }
        }

        /// <summary>
        ///     The type pixel test class
        /// </summary>
        public class TypePixelTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)TypePixel.TypeUnknown);
                Assert.Equal(1, (int)TypePixel.TypeIndex1);
                Assert.Equal(3, (int)TypePixel.TypeIndex8);
                Assert.Equal(4, (int)TypePixel.TypePacked8);
                Assert.Equal(6, (int)TypePixel.TypePacked32);
                Assert.Equal(11, (int)TypePixel.TypeArrayF32);
            }
        }

        /// <summary>
        ///     The win rt device family test class
        /// </summary>
        public class WinRtDeviceFamilyTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)WinRtDeviceFamily.SdlWinrtDeviceFamilyUnknown);
                Assert.Equal(1, (int)WinRtDeviceFamily.SdlWinrtDeviceFamilyDesktop);
                Assert.Equal(2, (int)WinRtDeviceFamily.SdlWinrtDeviceFamilyMobile);
                Assert.Equal(3, (int)WinRtDeviceFamily.SdlWinrtDeviceFamilyXbox);
            }
        }

        /// <summary>
        ///     The window event id test class
        /// </summary>
        public class WindowEventIdTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)WindowEventId.SdlWindowEventNone);
                Assert.Equal(1, (int)WindowEventId.SdlWindowEventShown);
                Assert.Equal(2, (int)WindowEventId.SdlWindowEventHidden);
                Assert.Equal(3, (int)WindowEventId.SdlWindowEventExposed);
                Assert.Equal(4, (int)WindowEventId.SdlWindowEventMoved);
                Assert.Equal(5, (int)WindowEventId.SdlWindowEventResized);
                Assert.Equal(14, (int)WindowEventId.SdlWindowEventClose);
                Assert.Equal(15, (int)WindowEventId.SdlWindowEventTakeFocus);
                Assert.Equal(16, (int)WindowEventId.SdlWindowEventHitTest);
                Assert.Equal(17, (int)WindowEventId.SdlWindowEventIccProfChanged);
                Assert.Equal(18, (int)WindowEventId.SdlWindowEventDisplayChanged);
            }
        }

        /// <summary>
        ///     The window event test class
        /// </summary>
        public class WindowEventTest
        {
            /// <summary>
            ///     Tests that window event id values match expected
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0, (int)WindowEventId.SdlWindowEventNone);
                Assert.Equal(1, (int)WindowEventId.SdlWindowEventShown);
                Assert.Equal(3, (int)WindowEventId.SdlWindowEventExposed);
                Assert.Equal(4, (int)WindowEventId.SdlWindowEventMoved);
                Assert.Equal(5, (int)WindowEventId.SdlWindowEventResized);
                Assert.Equal(14, (int)WindowEventId.SdlWindowEventClose);
                Assert.Equal(15, (int)WindowEventId.SdlWindowEventTakeFocus);
                Assert.Equal(16, (int)WindowEventId.SdlWindowEventHitTest);
            }
        }

        /// <summary>
        ///     The window pos test class
        /// </summary>
        public class WindowPosTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x1FFF0000, (int)WindowPos.WindowPosUndefinedMask);
                Assert.Equal(0x2FFF0000, (int)WindowPos.WindowPosCenteredMask);
                Assert.Equal(0x1FFF0000, (int)WindowPos.WindowPosUndefined);
                Assert.Equal(0x2FFF0000, (int)WindowPos.WindowPosCentered);
            }
        }

        /// <summary>
        ///     The window settings test class
        /// </summary>
        public class WindowSettingsTest
        {
            /// <summary>
            ///     Tests that values are correct
            /// </summary>
            [RequireSdl2ImageFact]
            public void Values_AreCorrect()
            {
                Assert.Equal(0x00000000u, (uint)WindowSettings.None);
                Assert.Equal(0x00000001u, (uint)WindowSettings.WindowFullscreen);
                Assert.Equal(0x00000002u, (uint)WindowSettings.WindowOpengl);
                Assert.Equal(0x00000004u, (uint)WindowSettings.WindowShown);
                Assert.Equal(0x00000008u, (uint)WindowSettings.WindowHidden);
                Assert.Equal(0x00000010u, (uint)WindowSettings.WindowBorderless);
                Assert.Equal(0x00000020u, (uint)WindowSettings.WindowResizable);
                Assert.Equal(0x00000040u, (uint)WindowSettings.WindowMinimized);
                Assert.Equal(0x00000080u, (uint)WindowSettings.WindowMaximized);
                Assert.Equal(0x10000000u, (uint)WindowSettings.WindowVulkan);
                Assert.Equal(0x00000100u, (uint)WindowSettings.WindowInputGrabbed);
            }

            /// <summary>
            ///     Tests that fullscreen desktop equals fullscreen or 0x1000
            /// </summary>
            [RequireSdl2ImageFact]
            public void FullscreenDesktop_IsFullscreenOr0x1000()
            {
                Assert.Equal((uint)(WindowSettings.WindowFullscreen | (WindowSettings)0x00001000), (uint)WindowSettings.WindowFullscreenDesktop);
            }
        }
    }
}
