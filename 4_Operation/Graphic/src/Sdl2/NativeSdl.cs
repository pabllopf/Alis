// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: NativeSdl.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Internal License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Internal License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Internal License for more details.
// 
//  You should have received a copy of the GNU General Internal License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Base.Mapping;
using Alis.Core.Aspect.Math.Shape.Point;
using Alis.Core.Aspect.Math.Shape.Rectangle;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Properties;
using Alis.Core.Graphic.Sdl2.Delegates;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2
{
    /// <summary>
    /// The native sdl class
    /// </summary>
    internal static class NativeSdl
    {
        /// <summary>
        /// The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2";
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Sdl" /> class
        /// </summary>
        static NativeSdl() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2", Sdl2Dlls.GlSdlDllBytes, Assembly.GetExecutingAssembly());

        /// <summary>
        ///     Sdl the haptic rumble play using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="strength">The strength</param>
        /// <param name="length">The length</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumblePlay", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticRumblePlay([NotNull] IntPtr haptic, float strength, [NotNull] uint length);

        /// <summary>
        ///     Sdl the haptic rumble stop using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleStop", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticRumbleStop([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic rumble supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticRumbleSupported([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic run effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="iterations">The iterations</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRunEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticRunEffect([NotNull] IntPtr haptic, [NotNull] int effect, [NotNull] uint iterations);

        /// <summary>
        ///     Sdl the haptic set auto center using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="autoCenter">The auto center</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticSetAutoCenter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticSetAutoCenter([NotNull] IntPtr haptic, [NotNull] int autoCenter);

        /// <summary>
        ///     Sdl the haptic set gain using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="gain">The gain</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticSetGain", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticSetGain([NotNull] IntPtr haptic, [NotNull] int gain);

        /// <summary>
        ///     Sdl the haptic stop all using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticStopAll", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticStopAll([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic stop effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticStopEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticStopEffect([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Sdl the haptic unpause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticUnpause", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticUnpause([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic update effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <param name="data">The data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticUpdateEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticUpdateEffect([NotNull] IntPtr haptic, [NotNull] int effect, ref SdlHapticEffect data);

        /// <summary>
        ///     Sdl the joystick is haptic using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickIsHaptic", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickIsHaptic([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the mouse is haptic
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MouseIsHaptic", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalMouseIsHaptic();

        /// <summary>
        ///     Sdl the num haptics
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumHaptics", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalNumHaptics();

        /// <summary>
        ///     Sdl the num sensors
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalNumSensors();

        /// <summary>
        ///     Internals the sdl sensor get device name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalSensorGetDeviceName([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlSensorType InternalSensorGetDeviceType([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device non portable type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceNonPortableType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSensorGetDeviceNonPortableType([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetDeviceInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSensorGetDeviceInstanceID([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalSensorOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the sensor from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalSensorFromInstanceID([NotNull] int instanceId);

        /// <summary>
        ///     Internals the sdl sensor get name using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalSensorGetName([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The sdl sensor type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlSensorType InternalSensorGetType([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get non portable type using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetNonPortableType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSensorGetNonPortableType([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get instance id using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSensorGetInstanceID([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor get data using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorGetData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSensorGetData([NotNull] IntPtr sensor, float[] data, [NotNull] int numValues);

        /// <summary>
        ///     Sdl the sensor close using the specified sensor
        /// </summary>
        /// <param name="sensor">The sensor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSensorClose([NotNull] IntPtr sensor);

        /// <summary>
        ///     Sdl the sensor update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_SensorUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSensorUpdate();

        /// <summary>
        ///     Sdl the lock sensors
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLockSensors();

        /// <summary>
        ///     Sdl the unlock sensors
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockSensors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockSensors();

        /// <summary>
        ///     Internals the sdl audio init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAudioInit([NotNull] string driverName);

        /// <summary>
        ///     Sdl the audio quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioQuit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalAudioQuit();

        /// <summary>
        ///     Sdl the close audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_CloseAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalCloseAudio();

        /// <summary>
        ///     Sdl the close audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CloseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalCloseAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Sdl the free wav using the specified audio buf
        /// </summary>
        /// <param name="audioBuf">The audio buf</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeWAV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeWAV([NotNull] IntPtr audioBuf);

        /// <summary>
        ///     Internals the sdl get audio device name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetAudioDeviceName([NotNull] int index, [NotNull] int isCapture);

        /// <summary>
        ///     Sdl the get audio device status using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlAudioStatus InternalGetAudioDeviceStatus([NotNull] uint dev);

        /// <summary>
        ///     Internals the sdl get audio driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetAudioDriver([NotNull] int index);

        /// <summary>
        ///     Sdl the get audio status
        /// </summary>
        /// <returns>The sdl audio status</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlAudioStatus InternalGetAudioStatus();

        /// <summary>
        ///     Internals the sdl get current audio driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentAudioDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetCurrentAudioDriver();

        /// <summary>
        ///     Sdl the get num audio devices using the specified is capture
        /// </summary>
        /// <param name="isCapture">The is capture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDevices", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumAudioDevices([NotNull] int isCapture);

        /// <summary>
        ///     Sdl the get num audio drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumAudioDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumAudioDrivers();

        /// <summary>
        ///     Internals the sdl load wav rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="spec">The spec</param>
        /// <param name="audioBuf">The audio buf</param>
        /// <param name="audioLen">The audio len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadWAV_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalLoadWAV_RW([NotNull] IntPtr src, [NotNull] int freeSrc, out SdlAudioSpec spec, out IntPtr audioBuf, out uint audioLen);

        /// <summary>
        ///     Sdl the lock audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLockAudio();

        /// <summary>
        ///     Sdl the lock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLockAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Sdl the mix audio using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMixAudio([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] [NotNull] byte[] src, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMixAudioFormat([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Sdl the mix audio format using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="format">The format</param>
        /// <param name="len">The len</param>
        /// <param name="volume">The volume</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MixAudioFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMixAudioFormat([Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] dst, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 3)] [NotNull] byte[] src, [NotNull] ushort format, [NotNull] uint len, [NotNull] int volume);

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalOpenAudio(ref SdlAudioSpec desired, out SdlAudioSpec obtained);

        /// <summary>
        ///     Sdl the open audio using the specified desired
        /// </summary>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalOpenAudio(ref SdlAudioSpec desired, [NotNull] IntPtr obtained);

        /// <summary>
        ///     Sdl the open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalOpenAudioDevice([NotNull] IntPtr device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges);

        /// <summary>
        ///     Internals the sdl open audio device using the specified device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="desired">The desired</param>
        /// <param name="obtained">The obtained</param>
        /// <param name="allowedChanges">The allowed changes</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalOpenAudioDevice([NotNull] string device, [NotNull] int isCapture, ref SdlAudioSpec desired, out SdlAudioSpec obtained, [NotNull] int allowedChanges);

        /// <summary>
        ///     Sdl the pause audio using the specified pause on
        /// </summary>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalPauseAudio([NotNull] int pauseOn);

        /// <summary>
        ///     Sdl the pause audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="pauseOn">The pause on</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_PauseAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalPauseAudioDevice([NotNull] uint dev, [NotNull] int pauseOn);

        /// <summary>
        ///     Sdl the unlock audio
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockAudio();

        /// <summary>
        ///     Sdl the unlock audio device using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockAudioDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockAudioDevice([NotNull] uint dev);

        /// <summary>
        ///     Sdl the queue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueueAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalQueueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len);

        /// <summary>
        ///     Sdl the dequeue audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <param name="data">The data</param>
        /// <param name="len">The len</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_DequeueAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalDequeueAudio([NotNull] uint dev, [NotNull] IntPtr data, [NotNull] uint len);

        /// <summary>
        ///     Sdl the get queued audio size using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetQueuedAudioSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetQueuedAudioSize([NotNull] uint dev);

        /// <summary>
        ///     Sdl the clear queued audio using the specified dev
        /// </summary>
        /// <param name="dev">The dev</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearQueuedAudio", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalClearQueuedAudio([NotNull] uint dev);

        /// <summary>
        ///     Sdl the new audio stream using the specified src format
        /// </summary>
        /// <param name="srcFormat">The src format</param>
        /// <param name="srcChannels">The src channels</param>
        /// <param name="srcRate">The src rate</param>
        /// <param name="dstFormat">The dst format</param>
        /// <param name="dstChannels">The dst channels</param>
        /// <param name="dstRate">The dst rate</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NewAudioStream", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalNewAudioStream([NotNull] ushort srcFormat, [NotNull] byte srcChannels, [NotNull] int srcRate, [NotNull] ushort dstFormat, [NotNull] byte dstChannels, [NotNull] int dstRate);

        /// <summary>
        ///     Sdl the audio stream put using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamPut", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAudioStreamPut([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len);

        /// <summary>
        ///     Sdl the audio stream get using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="buf">The buf</param>
        /// <param name="len">The len</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamGet", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAudioStreamGet([NotNull] IntPtr stream, [NotNull] IntPtr buf, [NotNull] int len);

        /// <summary>
        ///     Sdl the audio stream available using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamAvailable", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAudioStreamAvailable(IntPtr stream);

        /// <summary>
        ///     Sdl the audio stream clear using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AudioStreamClear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalAudioStreamClear([NotNull] IntPtr stream);

        /// <summary>
        ///     Sdl the free audio stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeAudioStream", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeAudioStream([NotNull] IntPtr stream);

        /// <summary>
        ///     Sdl the get audio device spec using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="isCapture">The is capture</param>
        /// <param name="spec">The spec</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAudioDeviceSpec", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetAudioDeviceSpec([NotNull] int index, [NotNull] int isCapture, out SdlAudioSpec spec);

        /// <summary>
        ///     Sdl the delay using the specified ms
        /// </summary>
        /// <param name="ms">The ms</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Delay", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDelay([NotNull] uint ms);

        /// <summary>
        ///     Sdl the get ticks
        /// </summary>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTicks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetTicks();

        /// <summary>
        ///     Sdl the get ticks 64
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTicks64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ulong InternalGetTicks64();

        /// <summary>
        ///     Sdl the get performance counter
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceCounter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ulong InternalGetPerformanceCounter();

        /// <summary>
        ///     Sdl the get performance frequency
        /// </summary>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPerformanceFrequency", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ulong InternalGetPerformanceFrequency();

        /// <summary>
        ///     Sdl the add timer using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="param">The param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AddTimer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAddTimer([NotNull] uint interval, SdlTimerCallback callback, IntPtr param);

        /// <summary>
        ///     Sdl the remove timer using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RemoveTimer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalRemoveTimer([NotNull] int id);

        /// <summary>
        ///     Sdl the set windows message hook using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowsMessageHook", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowsMessageHook([NotNull] SdlWindowsMessageHook callback, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the render get d 3 d 9 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetD3D9Device", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRenderGetD3D9Device([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the render get d 3 d 11 device using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetD3D11Device", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRenderGetD3D11Device([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the i phone set animation callback using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="interval">The interval</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackParam">The callback param</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_iPhoneSetAnimationCallback", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalIPhoneSetAnimationCallback(IntPtr window, [NotNull] int interval, SdlIPhoneAnimationCallback callback, IntPtr callbackParam);

        /// <summary>
        ///     Sdl the android get jni env
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetJNIEnv", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalAndroidGetJNIEnv();

        /// <summary>
        ///     Sdl the android get activity
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetActivity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalAndroidGetActivity();

        /// <summary>
        ///     Sdl the is android tv
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsAndroidTV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsAndroidTV();

        /// <summary>
        ///     Sdl the is chromebook
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsChromebook", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsChromebook();

        /// <summary>
        ///     Sdl the is de x mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsDeXMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsDeXMode();

        /// <summary>
        ///     Sdl the android back button
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidBackButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalAndroidBackButton();

        /// <summary>
        ///     Internals the sdl android get internal storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetInternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalAndroidGetInternalStoragePath();

        /// <summary>
        ///     Sdl the android get external storage state
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStorageState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAndroidGetExternalStorageState();

        /// <summary>
        ///     Internals the sdl android get external storage path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidGetExternalStoragePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalAndroidGetExternalStoragePath();

        /// <summary>
        ///     Sdl the get android sdk version
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetAndroidSDKVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetAndroidSDKVersion();

        /// <summary>
        ///     Internals the sdl android request permission using the specified permission
        /// </summary>
        /// <param name="permission">The permission</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidRequestPermission", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalAndroidRequestPermission([NotNull] string permission);

        /// <summary>
        ///     Internals the sdl android show toast using the specified message
        /// </summary>
        /// <param name="message">The message</param>
        /// <param name="duration">The duration</param>
        /// <param name="gravity">The gravity</param>
        /// <param name="xOffset">The offset</param>
        /// <param name="yOffset">The offset</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AndroidShowToast", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalAndroidShowToast([NotNull] string message, [NotNull] int duration, [NotNull] int gravity, [NotNull] int xOffset, [NotNull] int yOffset);

        /// <summary>
        ///     Sdl the win rt get device family
        /// </summary>
        /// <returns>The sdl win rt device family</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WinRTGetDeviceFamily", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlWinRtDeviceFamily InternalWinRTGetDeviceFamily();

        /// <summary>
        ///     Sdl the is tablet
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsTablet", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsTablet();

        /// <summary>
        ///     Sdl the get window wm info using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="info">The info</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowWMInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetWindowWMInfo([NotNull] IntPtr window, ref SdlSysWMinfo info);

        /// <summary>
        ///     Internals the sdl get base path
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetBasePath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetBasePath();

        /// <summary>
        ///     Internals the sdl get pref path using the specified org
        /// </summary>
        /// <param name="org">The org</param>
        /// <param name="app">The app</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPrefPath", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetPrefPath([NotNull] string org, [NotNull] string app);

        /// <summary>
        ///     Sdl the get power info using the specified secs
        /// </summary>
        /// <param name="secs">The secs</param>
        /// <param name="pct">The pct</param>
        /// <returns>The sdl power state</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPowerInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlPowerState InternalGetPowerInfo(out int secs, out int pct);

        /// <summary>
        ///     Sdl the get cpu count
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCPUCount", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetCPUCount();

        /// <summary>
        ///     Sdl the get cpu cache line size
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCPUCacheLineSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetCPUCacheLineSize();

        /// <summary>
        ///     Sdl the has rdtsc
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasRDTSC", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasRdtsc();

        /// <summary>
        ///     Sdl the has alti vec
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAltiVec", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasAltiVec();

        /// <summary>
        ///     Sdl the has mmx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasMMX", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasMMX();

        /// <summary>
        ///     Sdl the has sse
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSSE();

        /// <summary>
        ///     Sdl the has sse 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE2", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSSE2();

        /// <summary>
        ///     Sdl the has sse 3
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE3", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSSE3();

        /// <summary>
        ///     Sdl the has sse 41
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE41", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSSE41();

        /// <summary>
        ///     Sdl the has sse 42
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSSE42", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSSE42();

        /// <summary>
        ///     Sdl the has avx
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasAVX();

        /// <summary>
        ///     Internals the sdl set clipboard text using the specified text
        /// </summary>
        /// <param name="text">The text</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetClipboardText([NotNull] string text);

        /// <summary>
        ///     Sdl the pump events
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_PumpEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalPumpEvents();

        /// <summary>
        ///     Sdl the peep events using the specified events
        /// </summary>
        /// <param name="events">The events</param>
        /// <param name="numEvents">The num events</param>
        /// <param name="action">The action</param>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PeepEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalPeepEvents([Out] SdlEvent[] events, [NotNull] int numEvents, SdlEventAction action, SdlEventType minType, SdlEventType maxType);

        /// <summary>
        ///     Sdl the has event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasEvent(SdlEventType type);

        /// <summary>
        ///     Sdl the has events using the specified min type
        /// </summary>
        /// <param name="minType">The min type</param>
        /// <param name="maxType">The max type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasEvents(SdlEventType minType, SdlEventType maxType);

        /// <summary>
        ///     Sdl the flush event using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlushEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFlushEvent(SdlEventType type);

        /// <summary>
        ///     Sdl the flush events using the specified min
        /// </summary>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlushEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFlushEvents(SdlEventType min, SdlEventType max);

        /// <summary>
        ///     Sdl the poll event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PollEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalPollEvent(out SdlEvent sdlEvent);

        /// <summary>
        ///     Sdl the wait event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WaitEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalWaitEvent(out SdlEvent sdlEvent);

        /// <summary>
        ///     Sdl the wait event timeout using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <param name="timeout">The timeout</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WaitEventTimeout", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalWaitEventTimeout(out SdlEvent sdlEvent, [NotNull] int timeout);

        /// <summary>
        ///     Sdl the push event using the specified  event
        /// </summary>
        /// <param name="sdlEvent">The event</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PushEvent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalPushEvent(ref SdlEvent sdlEvent);

        /// <summary>
        ///     Sdl the set event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetEventFilter(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the get event filter using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetEventFilter", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetEventFilter(out IntPtr filter, out IntPtr userdata);

        /// <summary>
        ///     Sdl the add event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_AddEventWatch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalAddEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the del event watch using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DelEventWatch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDelEventWatch(SdlEventFilter filter, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the filter events using the specified filter
        /// </summary>
        /// <param name="filter">The filter</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FilterEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFilterEvents(SdlEventFilter filter, IntPtr userdata);

        /// <summary>
        ///     Sdl the event state using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="state">The state</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_EventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern byte InternalEventState(SdlEventType type, [NotNull] int state);

        /// <summary>
        ///     Sdl the register events using the specified num events
        /// </summary>
        /// <param name="numEvents">The num events</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RegisterEvents", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalRegisterEvents([NotNull] int numEvents);

        /// <summary>
        ///     Sdl the get keyboard focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetKeyboardFocus();

        /// <summary>
        ///     Sdl the get keyboard state using the specified num keys
        /// </summary>
        /// <param name="numKeys">The num keys</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyboardState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetKeyboardState(out int numKeys);

        /// <summary>
        ///     Sdl the get mod state
        /// </summary>
        /// <returns>The sdl key mod</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetModState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlKeymod InternalGetModState();

        /// <summary>
        ///     Sdl the set mod state using the specified mod state
        /// </summary>
        /// <param name="modState">The mod state</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetModState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetModState(SdlKeymod modState);

        /// <summary>
        ///     Sdl the get key from scancode using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromScancode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlKeycode InternalGetKeyFromScancode(SdlScancode scancode);

        /// <summary>
        ///     Sdl the get scancode from key using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlScancode InternalGetScancodeFromKey(SdlKeycode key);

        /// <summary>
        ///     Internals the sdl get scancode name using the specified scancode
        /// </summary>
        /// <param name="scancode">The scancode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetScancodeName(SdlScancode scancode);

        /// <summary>
        ///     Internals the sdl get scancode from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl scancode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetScancodeFromName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlScancode InternalGetScancodeFromName([NotNull] string name);

        /// <summary>
        ///     Internals the sdl get key name using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetKeyName(SdlKeycode key);

        /// <summary>
        ///     Internals the sdl get key from name using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The sdl keycode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetKeyFromName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlKeycode InternalGetKeyFromName([NotNull] string name);

        /// <summary>
        ///     Sdl the start text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StartTextInput", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalStartTextInput();

        /// <summary>
        ///     Sdl the is text input active
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsTextInputActive", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsTextInputActive();

        /// <summary>
        ///     Sdl the stop text input
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_StopTextInput", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalStopTextInput();

        /// <summary>
        ///     Sdl the set text input rect using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextInputRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetTextInputRect(ref RectangleI rect);

        /// <summary>
        ///     Sdl the has screen keyboard support
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasScreenKeyboardSupport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasScreenKeyboardSupport();

        /// <summary>
        ///     Sdl the is screen keyboard shown using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsScreenKeyboardShown", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsScreenKeyboardShown([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get mouse focus
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetMouseFocus();

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetMouseState([NotNull] IntPtr x, out int y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetMouseState(out int x, [NotNull] IntPtr y);

        /// <summary>
        ///     Sdl the get mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetMouseState([NotNull] IntPtr x, [NotNull] IntPtr y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetGlobalMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetGlobalMouseState([NotNull] IntPtr x, out int y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetGlobalMouseState(out int x, [NotNull] IntPtr y);

        /// <summary>
        ///     Sdl the get global mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGlobalMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetGlobalMouseState([NotNull] IntPtr x, [NotNull] IntPtr y);

        /// <summary>
        ///     Sdl the get relative mouse state using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetRelativeMouseState(out int x, out int y);

        /// <summary>
        ///     Sdl the warp mouse in window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseInWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalWarpMouseInWindow([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Sdl the warp mouse global using the specified x
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WarpMouseGlobal", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalWarpMouseGlobal([NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Sdl the set relative mouse mode using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetRelativeMouseMode(SdlBool enabled);

        /// <summary>
        ///     Sdl the capture mouse using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CaptureMouse", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalCaptureMouse(SdlBool enabled);

        /// <summary>
        ///     Sdl the get relative mouse mode
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRelativeMouseMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetRelativeMouseMode();

        /// <summary>
        ///     Sdl the create cursor using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="mask">The mask</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateCursor([NotNull] IntPtr data, [NotNull] IntPtr mask, [NotNull] int w, [NotNull] int h, [NotNull] int hotX, [NotNull] int hotY);

        /// <summary>
        ///     Sdl the create color cursor using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="hotX">The hot</param>
        /// <param name="hotY">The hot</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateColorCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateColorCursor([NotNull] IntPtr surface, [NotNull] int hotX, [NotNull] int hotY);

        /// <summary>
        ///     Sdl the create system cursor using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSystemCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateSystemCursor(SdlSystemCursor id);

        /// <summary>
        ///     Sdl the set cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetCursor([NotNull] IntPtr cursor);

        /// <summary>
        ///     Sdl the get cursor
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetCursor();

        /// <summary>
        ///     Sdl the free cursor using the specified cursor
        /// </summary>
        /// <param name="cursor">The cursor</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeCursor([NotNull] IntPtr cursor);

        /// <summary>
        ///     Sdl the show cursor using the specified toggle
        /// </summary>
        /// <param name="toggle">The toggle</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowCursor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalShowCursor([NotNull] int toggle);

        /// <summary>
        ///     Sdl the get num touch devices
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumTouchDevices", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumTouchDevices();

        /// <summary>
        ///     Sdl the get touch device using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDevice", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalGetTouchDevice([NotNull] int index);

        /// <summary>
        ///     Sdl the get num touch fingers using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumTouchFingers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumTouchFingers(long touchId);

        /// <summary>
        ///     Sdl the get touch finger using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchFinger", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetTouchFinger([NotNull] long touchId, [NotNull] int index);

        /// <summary>
        ///     Sdl the get touch device type using the specified touch id
        /// </summary>
        /// <param name="touchId">The touch id</param>
        /// <returns>The sdl touch device type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTouchDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlTouchDeviceType InternalGetTouchDeviceType([NotNull] long touchId);

        /// <summary>
        ///     Sdl the joystick rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickRumble([NotNull] IntPtr joystick, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Sdl the joystick rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickRumbleTriggers([NotNull] IntPtr joystick, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Sdl the joystick close using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalJoystickClose([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickEventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickEventState([NotNull] int state);

        /// <summary>
        ///     Sdl the joystick get axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern short InternalJoystickGetAxis([NotNull] IntPtr joystick, [NotNull] int axis);

        /// <summary>
        ///     Sdl the joystick get axis initial state using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="state">The state</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAxisInitialState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickGetAxisInitialState([NotNull] IntPtr joystick, [NotNull] int axis, out ushort state);

        /// <summary>
        ///     Sdl the joystick get ball using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="ball">The ball</param>
        /// <param name="dx">The dx</param>
        /// <param name="dy">The dy</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetBall", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickGetBall([NotNull] IntPtr joystick, [NotNull] int ball, out int dx, out int dy);

        /// <summary>
        ///     Sdl the joystick get button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern byte InternalJoystickGetButton([NotNull] IntPtr joystick, [NotNull] int button);

        /// <summary>
        ///     Sdl the joystick get hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetHat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern byte InternalJoystickGetHat([NotNull] IntPtr joystick, [NotNull] int hat);

        /// <summary>
        ///     Internals the sdl joystick name using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalJoystickName([NotNull] IntPtr joystick);

        /// <summary>
        ///     Internals the sdl joystick name for index using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalJoystickNameForIndex([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick num axes using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumAxes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickNumAxes([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick num balls using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumBalls", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickNumBalls([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick num buttons using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumButtons", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickNumButtons([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick num hats using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickNumHats", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickNumHats([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalJoystickOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalJoystickUpdate();

        /// <summary>
        ///     Sdl the num joysticks
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_NumJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalNumJoysticks();

        /// <summary>
        ///     Sdl the joystick get device guid using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern Guid InternalJoystickGetDeviceGUID([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get guid using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern Guid InternalJoystickGetGUID(IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get guid string using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <param name="pszGuid">The psz guid</param>
        /// <param name="cbGuid">The cb guid</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalJoystickGetGUIDString(Guid guid, [NotNull] byte[] pszGuid, [NotNull] int cbGuid);

        /// <summary>
        ///     Internals the sdl joystick get guid from string using the specified pch guid
        /// </summary>
        /// <param name="pchGuid">The pch guid</param>
        /// <returns>The guid</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetGUIDFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern Guid InternalJoystickGetGUIDFromString([NotNull] string pchGuid);

        /// <summary>
        ///     Sdl the joystick get device vendor using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetDeviceVendor([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get device product using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetDeviceProduct([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get device product version using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetDeviceProductVersion([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get device type using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlJoystickType InternalJoystickGetDeviceType([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get device instance id using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetDeviceInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickGetDeviceInstanceID([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick get vendor using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetVendor([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get product using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetProduct([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get product version using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalJoystickGetProductVersion([NotNull] IntPtr joystick);

        /// <summary>
        ///     Internals the sdl joystick get serial using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetSerial", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalJoystickGetSerial([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get type using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlJoystickType InternalJoystickGetType([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick get attached using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickGetAttached", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickGetAttached([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick instance id using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickInstanceID([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick current power level using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl joystick power level</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickCurrentPowerLevel", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlJoystickPowerLevel InternalJoystickCurrentPowerLevel([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick from instance id using the specified instance id
        /// </summary>
        /// <param name="instanceId">The instance id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalJoystickFromInstanceID([NotNull] int instanceId);

        /// <summary>
        ///     Sdl the lock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLockJoysticks();

        /// <summary>
        ///     Sdl the unlock joysticks
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockJoysticks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockJoysticks();

        /// <summary>
        ///     Sdl the joystick from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickFromPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalJoystickFromPlayerIndex([NotNull] int playerIndex);

        /// <summary>
        ///     Sdl the joystick set player index using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalJoystickSetPlayerIndex([NotNull] IntPtr joystick, [NotNull] int playerIndex);

        /// <summary>
        ///     Sdl the joystick attach virtual using the specified type
        /// </summary>
        /// <param name="type">The type</param>
        /// <param name="nAxes">The n axes</param>
        /// <param name="nButtons">The n buttons</param>
        /// <param name="nHats">The n hats</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickAttachVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickAttachVirtual([NotNull] int type, [NotNull] int nAxes, [NotNull] int nButtons, [NotNull] int nHats);

        /// <summary>
        ///     Sdl the joystick detach virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickDetachVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickDetachVirtual([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick is virtual using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickIsVirtual", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickIsVirtual([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the joystick set virtual axis using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="axis">The axis</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickSetVirtualAxis([NotNull] IntPtr joystick, [NotNull] int axis, short value);

        /// <summary>
        ///     Sdl the joystick set virtual button using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="button">The button</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickSetVirtualButton([NotNull] IntPtr joystick, [NotNull] int button, [NotNull] byte value);

        /// <summary>
        ///     Sdl the has avx 2
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX2", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasAVX2();

        /// <summary>
        ///     Sdl the malloc using the specified size
        /// </summary>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_malloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalMalloc(int size);

        /// <summary>
        ///     Sdl the free using the specified mem block
        /// </summary>
        /// <param name="memBlock">The mem block</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_free", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFree([NotNull] IntPtr memBlock);

        /// <summary>
        ///     Sdl the mem cpy using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="src">The src</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_memCpy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalMemCpy([NotNull] IntPtr dst, [NotNull] IntPtr src, [NotNull] IntPtr len);

        /// <summary>
        ///     Internals the sdl rw from file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRWFromFile([NotNull] string file, [NotNull] string mode);

        /// <summary>
        ///     Sdl the alloc rw
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalAllocRW();

        /// <summary>
        ///     Sdl the free rw using the specified area
        /// </summary>
        /// <param name="area">The area</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeRW([NotNull] IntPtr area);

        /// <summary>
        ///     Sdl the rw from fp using the specified fp
        /// </summary>
        /// <param name="fp">The fp</param>
        /// <param name="autoClose">The auto close</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromFP", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRWFromFP([NotNull] IntPtr fp, [NotNull] SdlBool autoClose);

        /// <summary>
        ///     Sdl the rw from mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromMem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRWFromMem([NotNull] IntPtr mem, [NotNull] int size);

        /// <summary>
        ///     Sdl the rw from const mem using the specified mem
        /// </summary>
        /// <param name="mem">The mem</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RWFromConstMem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRWFromConstMem(IntPtr mem, [NotNull] int size);

        /// <summary>
        ///     Sdl the r w size using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwSize([NotNull] IntPtr context);

        /// <summary>
        ///     Sdl the r w seek using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="offset">The offset</param>
        /// <param name="whence">The whence</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwSeek", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwSeek([NotNull] IntPtr context, [NotNull] long offset, [NotNull] int whence);

        /// <summary>
        ///     Sdl the r w tell using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwTell", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwTell(IntPtr context);

        /// <summary>
        ///     Sdl the r w read using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwRead", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwRead([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum);

        /// <summary>
        ///     Sdl the r w write using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <param name="ptr">The ptr</param>
        /// <param name="size">The size</param>
        /// <param name="maxNum">The max num</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwWrite", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwWrite([NotNull] IntPtr context, [NotNull] IntPtr ptr, [NotNull] IntPtr size, [NotNull] IntPtr maxNum);

        /// <summary>
        ///     Sdl the read u 8 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadU8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern byte InternalReadU8([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read le 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalReadLE16([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read be 16 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 16</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalReadBE16([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read le 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalReadLE32([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read be 32 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 32</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalReadBE32([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read le 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadLE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ulong InternalReadLE64([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the read be 64 using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int 64</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ReadBE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ulong InternalReadBE64([NotNull] IntPtr src);

        /// <summary>
        ///     Sdl the write u 8 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteU8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteU8([NotNull] IntPtr dst, [NotNull] byte value);

        /// <summary>
        ///     Sdl the write le 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteLE16([NotNull] IntPtr dst, [NotNull] ushort value);

        /// <summary>
        ///     Sdl the write be 16 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE16", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteBE16([NotNull] IntPtr dst, [NotNull] ushort value);

        /// <summary>
        ///     Sdl the write le 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteLE32([NotNull] IntPtr dst, [NotNull] uint value);

        /// <summary>
        ///     Sdl the write be 32 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE32", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteBE32([NotNull] IntPtr dst, [NotNull] uint value);

        /// <summary>
        ///     Sdl the write le 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteLE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteLE64([NotNull] IntPtr dst, [NotNull] ulong value);

        /// <summary>
        ///     Sdl the write be 64 using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="value">The value</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WriteBE64", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWriteBE64([NotNull] IntPtr dst, [NotNull] ulong value);

        /// <summary>
        ///     Sdl the r w close using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The long</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RwClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern long InternalRwClose([NotNull] IntPtr context);

        /// <summary>
        ///     Internals the sdl load file using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="dataSize">The data size</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadFile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalLoadFile([NotNull] string file, out IntPtr dataSize);

        /// <summary>
        ///     Sdl the set main ready
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetMainReady", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetMainReady();

        /// <summary>
        ///     Sdl the win rt run app using the specified main function
        /// </summary>
        /// <param name="mainFunction">The main function</param>
        /// <param name="reserved">The reserved</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WinRTRunApp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalWinRTRunApp(SdlMainFunc mainFunction, [NotNull] IntPtr reserved);

        /// <summary>
        ///     Sdl the ui kit run app using the specified argc
        /// </summary>
        /// <param name="argc">The argc</param>
        /// <param name="argv">The argv</param>
        /// <param name="mainFunction">The main function</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UIKitRunApp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUIKitRunApp([NotNull] int argc, IntPtr argv, SdlMainFunc mainFunction);

        /// <summary>
        ///     Sdl the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Init", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalInit([NotNull] uint flags);

        /// <summary>
        ///     Sdl the init sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_InitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalInitSubSystem([NotNull] uint flags);

        /// <summary>
        ///     Sdl the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_Quit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalQuit();

        /// <summary>
        ///     Sdl the quit sub system using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_QuitSubSystem", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalQuitSubSystem([NotNull] uint flags);

        /// <summary>
        ///     Sdl the was init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_WasInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalWasInit([NotNull] uint flags);

        /// <summary>
        ///     Internals the sdl get platform
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPlatform", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetPlatform();

        /// <summary>
        ///     Sdl the clear hints
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearHints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalClearHints();

        /// <summary>
        ///     Internals the sdl get hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetHint([NotNull] string name);

        /// <summary>
        ///     Internals the sdl set hint using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalSetHint([NotNull] string name, [NotNull] string value);

        /// <summary>
        ///     Internals the sdl set hint with priority using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="value">The value</param>
        /// <param name="priority">The priority</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetHintWithPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalSetHintWithPriority([NotNull] string name, [NotNull] string value, SdlHintPriority priority);

        /// <summary>
        ///     Internals the sdl get hint boolean using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="defaultValue">The default value</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetHintBoolean", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetHintBoolean([NotNull] string name, SdlBool defaultValue);

        /// <summary>
        ///     Sdl the clear error
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_ClearError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalClearError();

        /// <summary>
        ///     Internals the sdl get error
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetError();

        /// <summary>
        ///     Internals the sdl set error using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetError([NotNull] string fmtAndArgList);

        /// <summary>
        ///     Sdl the get error msg using the specified err str
        /// </summary>
        /// <param name="errStr">The err str</param>
        /// <param name="maxlength">The maxlength</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetErrorMsg", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetErrorMsg([NotNull] IntPtr errStr, [NotNull] int maxlength);

        /// <summary>
        ///     Internals the sdl log using the specified fmt and arg list
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Log", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLog([NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log verbose using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogVerbose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogVerbose([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log debug using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogDebug", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogDebug([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log info using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogInfo([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log warn using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogWarn", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogWarn([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log error using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogError", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogError([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log critical using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogCritical", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogCritical([NotNull] int category, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log message using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessage", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogMessage([NotNull] int category, SdlLogPriority priority, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Internals the sdl log message v using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogMessageV", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogMessageV([NotNull] int category, SdlLogPriority priority, [NotNull] string fmtAndArgList);

        /// <summary>
        ///     Sdl the log get priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <returns>The sdl log priority</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogGetPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlLogPriority InternalLogGetPriority([NotNull] int category);

        /// <summary>
        ///     Sdl the log set priority using the specified category
        /// </summary>
        /// <param name="category">The category</param>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogSetPriority([NotNull] int category, SdlLogPriority priority);

        /// <summary>
        ///     Sdl the log set all priority using the specified priority
        /// </summary>
        /// <param name="priority">The priority</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetAllPriority", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogSetAllPriority([NotNull] SdlLogPriority priority);

        /// <summary>
        ///     Sdl the log reset priorities
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogResetPriorities", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogResetPriorities();

        /// <summary>
        ///     Sdl the log get output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogGetOutputFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogGetOutputFunction(out IntPtr callback, out IntPtr userdata);

        /// <summary>
        ///     Sdl the log set output function using the specified callback
        /// </summary>
        /// <param name="callback">The callback</param>
        /// <param name="userdata">The userdata</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_LogSetOutputFunction", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalLogSetOutputFunction([NotNull] SdlLogOutputFunction callback, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Internals the sdl show message box using the specified message box data
        /// </summary>
        /// <param name="messageBoxData">The message box data</param>
        /// <param name="buttonId">The button id</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowMessageBox", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalShowMessageBox([In] ref InternalSdlMessageBoxData messageBoxData, out int buttonId);

        /// <summary>
        ///     Internals the alloc utf 8 using the specified str
        /// </summary>
        /// <param name="str">The str</param>
        /// <returns>The mem</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static IntPtr AllocUtf8([NotNull] string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return IntPtr.Zero;
            }

            IntPtr mem = InternalMalloc(Encoding.UTF8.GetBytes(str + '\0').Length);
            Marshal.Copy(Encoding.UTF8.GetBytes(str + '\0'), 0, mem, Encoding.UTF8.GetBytes(str + '\0').Length);
            return mem;
        }

        /// <summary>
        ///     Internals the sdl show simple message box using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="title">The title</param>
        /// <param name="message">The message</param>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowSimpleMessageBox", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalShowSimpleMessageBox(SdlMessageBoxFlags flags, [NotNull] string title, [NotNull] string message, [NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get version using the specified ver
        /// </summary>
        /// <param name="ver">The ver</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetVersion(out SdlVersion ver);

        /// <summary>
        ///     Internals the sdl get revision
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevision", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetRevision();

        /// <summary>
        ///     Sdl the get revision number
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRevisionNumber", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRevisionNumber();

        /// <summary>
        ///     Internals the sdl create window using the specified title
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateWindow([NotNull] [NotNull] string title, [NotNull] int x, [NotNull] int y, [NotNull] int w, [NotNull] int h, [NotNull] SdlWindowFlags flags);

        /// <summary>
        ///     Sdl the create window and renderer using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="windowFlags">The window flags</param>
        /// <param name="window">The window</param>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindowAndRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalCreateWindowAndRenderer([NotNull] int width, [NotNull] int height, [NotNull] SdlWindowFlags windowFlags, out IntPtr window, out IntPtr renderer);

        /// <summary>
        ///     Sdl the create window from using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateWindowFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateWindowFrom([NotNull] IntPtr data);

        /// <summary>
        ///     Sdl the destroy window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDestroyWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the disable screen saver
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_DisableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDisableScreenSaver();

        /// <summary>
        ///     Sdl the enable screen saver
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_EnableScreenSaver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalEnableScreenSaver();

        /// <summary>
        ///     Sdl the get closest display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <param name="closest">The closest</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClosestDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetClosestDisplayMode([NotNull] int displayIndex, ref SdlDisplayMode mode, out SdlDisplayMode closest);

        /// <summary>
        ///     Sdl the get current display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetCurrentDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Internals the sdl get current video driver
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetCurrentVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetCurrentVideoDriver();

        /// <summary>
        ///     Sdl the get desktop display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDesktopDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetDesktopDisplayMode([NotNull] int displayIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Internals the sdl get display name using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetDisplayName([NotNull] int index);

        /// <summary>
        ///     Sdl the get display bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayBounds", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetDisplayBounds([NotNull] int displayIndex, out RectangleI rect);

        /// <summary>
        ///     Sdl the get display dpi using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="dDpi">The d dpi</param>
        /// <param name="hDpi">The h dpi</param>
        /// <param name="vDpi">The v dpi</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayDPI", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetDisplayDPI([NotNull] int displayIndex, out float dDpi, out float hDpi, out float vDpi);

        /// <summary>
        ///     Sdl the get display orientation using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The sdl display orientation</returns>
        [DllImport(NativeLibName, EntryPoint = "SdlDisplayOrientation", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlDisplayOrientation InternalGetDisplayOrientation([NotNull] int displayIndex);

        /// <summary>
        ///     Sdl the get display mode using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="modeIndex">The mode index</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetDisplayMode([NotNull] int displayIndex, [NotNull] int modeIndex, out SdlDisplayMode mode);

        /// <summary>
        ///     Sdl the get display usable bounds using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetDisplayUsableBounds", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetDisplayUsableBounds([NotNull] int displayIndex, out RectangleI rect);

        /// <summary>
        ///     Sdl the get num display modes using the specified display index
        /// </summary>
        /// <param name="displayIndex">The display index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumDisplayModes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumDisplayModes([NotNull] int displayIndex);

        /// <summary>
        ///     Sdl the get num video displays
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDisplays", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumVideoDisplays();

        /// <summary>
        ///     Sdl the get num video drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumVideoDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumVideoDrivers();

        /// <summary>
        ///     Internals the sdl get video driver using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetVideoDriver", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetVideoDriver([NotNull] int index);

        /// <summary>
        ///     Sdl the get window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowBrightness", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern float InternalGetWindowBrightness([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the set window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="opacity">The opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowOpacity([NotNull] IntPtr window, [NotNull] float opacity);

        /// <summary>
        ///     Sdl the get window opacity using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="outOpacity">The out opacity</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowOpacity", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetWindowOpacity([NotNull] IntPtr window, out float outOpacity);

        /// <summary>
        ///     Sdl the set window modal for using the specified modal window
        /// </summary>
        /// <param name="modalWindow">The modal window</param>
        /// <param name="parentWindow">The parent window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowModalFor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowModalFor([NotNull] IntPtr modalWindow, [NotNull] IntPtr parentWindow);

        /// <summary>
        ///     Sdl the set window input focus using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowInputFocus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowInputFocus([NotNull] IntPtr window);

        /// <summary>
        ///     Internals the sdl get window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetWindowData([NotNull] IntPtr window, [NotNull] string name);

        /// <summary>
        ///     Sdl the get window display index using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetWindowDisplayIndex([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetWindowDisplayMode([NotNull] IntPtr window, out SdlDisplayMode mode);

        /// <summary>
        ///     Sdl the get window icc profile using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowICCProfile", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetWindowICCProfile([NotNull] IntPtr window, out IntPtr mode);

        /// <summary>
        ///     Sdl the get window flags using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFlags", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetWindowFlags([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window from id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowFromID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetWindowFromID([NotNull] uint id);

        /// <summary>
        ///     Sdl the get window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetWindowGammaRamp([NotNull] IntPtr window, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue);

        /// <summary>
        ///     Sdl the get window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetWindowGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowKeyboardGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetWindowKeyboardGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMouseGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGetWindowMouseGrab([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window id using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetWindowID([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window pixel format using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPixelFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalGetWindowPixelFormat([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetWindowMaximumSize([NotNull] IntPtr window, out int maxW, out int maxH);

        /// <summary>
        ///     Sdl the get window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetWindowMinimumSize([NotNull] IntPtr window, out int minW, out int minH);

        /// <summary>
        ///     Sdl the get window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetWindowPosition([NotNull] IntPtr window, out int x, out int y);

        /// <summary>
        ///     Sdl the get window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetWindowSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Sdl the get window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetWindowSurface([NotNull] IntPtr window);

        /// <summary>
        ///     Internals the sdl get window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetWindowTitle([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the gl bind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="texW">The tex w</param>
        /// <param name="texH">The tex h</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_BindTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_BindTexture([NotNull] IntPtr texture, out float texW, out float texH);

        /// <summary>
        ///     Sdl the gl create context using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_CreateContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGL_CreateContext([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the gl delete context using the specified context
        /// </summary>
        /// <param name="context">The context</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_DeleteContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGL_DeleteContext([NotNull] IntPtr context);

        /// <summary>
        ///     Internals the sdl gl load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_LoadLibrary([NotNull] string path);

        /// <summary>
        ///     Sdl the gl get proc address using the specified proc
        /// </summary>
        /// <param name="proc">The proc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetProcAddress", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGL_GetProcAddress([NotNull] string proc);

        /// <summary>
        ///     Sdl the gl unload library
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_UnloadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGL_UnloadLibrary();

        /// <summary>
        ///     Internals the sdl gl extension supported using the specified extension
        /// </summary>
        /// <param name="extension">The extension</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ExtensionSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGL_ExtensionSupported([NotNull] string extension);

        /// <summary>
        ///     Sdl the gl reset attributes
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_ResetAttributes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGL_ResetAttributes();

        /// <summary>
        ///     Sdl the gl get attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_GetAttribute([NotNull] SdlGlAttr attr, out int value);

        /// <summary>
        ///     Sdl the gl get swap interval
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_GetSwapInterval();

        /// <summary>
        ///     Sdl the gl make current using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="context">The context</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_MakeCurrent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_MakeCurrent([NotNull] IntPtr window, [NotNull] IntPtr context);

        /// <summary>
        ///     Sdl the gl get current window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGL_GetCurrentWindow();

        /// <summary>
        ///     Sdl the render set v sync using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="vsync">The vsync</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetVSync", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetVSync([NotNull] IntPtr renderer, [NotNull] int vsync);

        /// <summary>
        ///     Sdl the render is clip enabled using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderIsClipEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalRenderIsClipEnabled([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the render flush using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFlush", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFlush([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the alloc format using the specified pixel format
        /// </summary>
        /// <param name="pixelFormat">The pixel format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalAllocFormat([NotNull] uint pixelFormat);

        /// <summary>
        ///     Sdl the alloc palette using the specified n colors
        /// </summary>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_AllocPalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalAllocPalette([NotNull] int nColors);

        /// <summary>
        ///     Sdl the calculate gamma ramp using the specified gamma
        /// </summary>
        /// <param name="gamma">The gamma</param>
        /// <param name="ramp">The ramp</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_CalculateGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalCalculateGammaRamp(float gamma, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] ramp);

        /// <summary>
        ///     Sdl the free format using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeFormat([NotNull] IntPtr format);

        /// <summary>
        ///     Sdl the free palette using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreePalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreePalette([NotNull] IntPtr palette);

        /// <summary>
        ///     Internals the sdl get pixel format name using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPixelFormatName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetPixelFormatName([NotNull] uint format);

        /// <summary>
        ///     Sdl the get rgb using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRGB", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetRGB([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Sdl the get rgba using the specified pixel
        /// </summary>
        /// <param name="pixel">The pixel</param>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRGBA", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetRGBA([NotNull] uint pixel, [NotNull] IntPtr format, out byte r, out byte g, out byte b, out byte a);

        /// <summary>
        ///     Sdl the map rgb using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MapRGB", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalMapRGB([NotNull] IntPtr format, byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Sdl the map rgba using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MapRGBA", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalMapRGBA([NotNull] IntPtr format, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a);

        /// <summary>
        ///     Sdl the masks to pixel format enum using the specified bpp
        /// </summary>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_MasksToPixelFormatEnum", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalMasksToPixelFormatEnum([NotNull] int bpp, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

        /// <summary>
        ///     Sdl the pixel format enum to masks using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="bpp">The bpp</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_PixelFormatEnumToMasks", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalPixelFormatEnumToMasks([NotNull] uint format, out int bpp, out uint rMask, out uint gMask, out uint bMask, out uint aMask);

        /// <summary>
        ///     Sdl the set palette colors using the specified palette
        /// </summary>
        /// <param name="palette">The palette</param>
        /// <param name="colors">The colors</param>
        /// <param name="firstColor">The first color</param>
        /// <param name="nColors">The n colors</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPaletteColors", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetPaletteColors([NotNull] IntPtr palette, [In] SdlColor[] colors, [NotNull] int firstColor, [NotNull] int nColors);

        /// <summary>
        ///     Sdl the set pixel format palette using the specified format
        /// </summary>
        /// <param name="format">The format</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetPixelFormatPalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetPixelFormatPalette([NotNull] IntPtr format, [NotNull] IntPtr palette);

        /// <summary>
        ///     Sdl the enclose points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <param name="clip">The clip</param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_EnclosePoints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalEnclosePoints([In] PointI[] points, [NotNull] int count, ref RectangleI clip, out RectangleI result);

        /// <summary>
        ///     Sdl the has intersection using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasIntersection", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasIntersection(ref RectangleI a, ref RectangleI b);

        /// <summary>
        ///     Sdl the intersect rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IntersectRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIntersectRect(ref RectangleI a, ref RectangleI b, out RectangleI result);

        /// <summary>
        ///     Sdl the intersect rect and line using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IntersectRectAndLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIntersectRectAndLine(ref RectangleI rect, ref int x1, ref int y1, ref int x2, ref int y2);

        /// <summary>
        ///     Sdl the union rect using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="result">The result</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnionRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnionRect(RectangleI a, RectangleI b, out RectangleI result);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalBlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalBlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalBlitSurface([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Sdl the blit surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalBlitSurface([NotNull] IntPtr src, [NotNull] IntPtr srcRect, [NotNull] IntPtr dst, [NotNull] IntPtr dstRect);
        
        /// <summary>
        ///     Sdl the convert surface using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="fmt">The fmt</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalConvertSurface([NotNull] IntPtr src, [NotNull] IntPtr fmt, [NotNull] uint flags);

        /// <summary>
        ///     Sdl the convert surface format using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="pixelFormat">The pixel format</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ConvertSurfaceFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalConvertSurfaceFormat([NotNull] IntPtr src, [NotNull] uint pixelFormat, [NotNull] uint flags);

        /// <summary>
        ///     Sdl the create rgb surface using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateRGBSurface([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

        /// <summary>
        ///     Sdl the create rgb surface from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="rMask">The r mask</param>
        /// <param name="gMask">The g mask</param>
        /// <param name="bMask">The b mask</param>
        /// <param name="aMask">The a mask</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateRGBSurfaceFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint rMask, [NotNull] uint gMask, [NotNull] uint bMask, [NotNull] uint aMask);

        /// <summary>
        ///     Sdl the create rgb surface with format using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceWithFormat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateRGBSurfaceWithFormat([NotNull] uint flags, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] uint format);

        /// <summary>
        ///     Sdl the create rgb surface with format from using the specified pixels
        /// </summary>
        /// <param name="pixels">The pixels</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="depth">The depth</param>
        /// <param name="pitch">The pitch</param>
        /// <param name="format">The format</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRGBSurfaceWithFormatFrom", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateRGBSurfaceWithFormatFrom([NotNull] IntPtr pixels, [NotNull] int width, [NotNull] int height, [NotNull] int depth, [NotNull] int pitch, [NotNull] uint format);

        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalFillRect([NotNull] IntPtr dst, ref RectangleI rect, [NotNull] uint color);

        /// <summary>
        ///     Sdl the fill rect using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rect">The rect</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalFillRect([NotNull] IntPtr dst, [NotNull] IntPtr rect, [NotNull] uint color);

        /// <summary>
        ///     Sdl the fill rects using the specified dst
        /// </summary>
        /// <param name="dst">The dst</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <param name="color">The color</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FillRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalFillRects([NotNull] IntPtr dst, [In] RectangleI[] rects, [NotNull] int count, [NotNull] uint color);

        /// <summary>
        ///     Sdl the free surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_FreeSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalFreeSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the get clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGetClipRect([NotNull] IntPtr surface, out RectangleI rect);

        /// <summary>
        ///     Sdl the has color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasColorKey([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the get color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetColorKey([NotNull] IntPtr surface, out uint key);

        /// <summary>
        ///     Sdl the get surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetSurfaceAlphaMod([NotNull] IntPtr surface, out byte alpha);

        /// <summary>
        ///     Sdl the get surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetSurfaceBlendMode([NotNull] IntPtr surface, out SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the get surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetSurfaceColorMod([NotNull] IntPtr surface, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Internals the sdl load bmp rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LoadBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalLoadBMP_RW([NotNull] IntPtr src, [NotNull] int freeSrc);

        /// <summary>
        ///     Sdl the lock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLockSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the lower blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LowerBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLowerBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the lower blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LowerBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLowerBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Internals the sdl save bmp rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SaveBMP_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSaveBMP_RW([NotNull] IntPtr surface, [NotNull] IntPtr src, [NotNull] int freeSrc);

        /// <summary>
        ///     Sdl the set clip rect using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="rect">The rect</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalSetClipRect([NotNull] IntPtr surface, ref RectangleI rect);

        /// <summary>
        ///     Sdl the set color key using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetColorKey", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetColorKey([NotNull] IntPtr surface, [NotNull] int flag, [NotNull] uint key);

        /// <summary>
        ///     Sdl the set surface alpha mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetSurfaceAlphaMod([NotNull] IntPtr surface, [NotNull] byte alpha);

        /// <summary>
        ///     Sdl the set surface blend mode using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetSurfaceBlendMode([NotNull] IntPtr surface, SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the set surface color mod using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetSurfaceColorMod([NotNull] IntPtr surface, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Sdl the set surface palette using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="palette">The palette</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfacePalette", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetSurfacePalette([NotNull] IntPtr surface, [NotNull] IntPtr palette);

        /// <summary>
        ///     Sdl the set surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="flag">The flag</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetSurfaceRLE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetSurfaceRLE([NotNull] IntPtr surface, [NotNull] int flag);

        /// <summary>
        ///     Sdl the has surface rle using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasSurfaceRLE", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasSurfaceRLE([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the soft stretch using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SoftStretch", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSoftStretch([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the soft stretch linear using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SoftStretchLinear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSoftStretchLinear([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the unlock surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the upper blit using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpperBlit([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the upper blit scaled using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpperBlitScaled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpperBlitScaled([NotNull] IntPtr src, ref RectangleI srcRect, [NotNull] IntPtr dst, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the duplicate surface using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_DuplicateSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalDuplicateSurface([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the has clipboard text
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasClipboardText();

        /// <summary>
        ///     Internals the sdl get clipboard text
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetClipboardText", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGetClipboardText();

        /// <summary>
        ///     Sdl the joystick set virtual hat using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="hat">The hat</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetVirtualHat", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickSetVirtualHat([NotNull] IntPtr joystick, [NotNull] int hat, [NotNull] byte value);

        /// <summary>
        ///     Sdl the joystick has led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickHasLED([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick has rumble using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickHasRumble([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick has rumble triggers using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickHasRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalJoystickHasRumbleTriggers([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the joystick set led using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSetLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickSetLED([NotNull] IntPtr joystick, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue);

        /// <summary>
        ///     Sdl the joystick send effect using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_JoystickSendEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalJoystickSendEffect([NotNull] IntPtr joystick, [NotNull] IntPtr data, [NotNull] int size);

        /// <summary>
        ///     Internals the sdl game controller add mapping using the specified mapping string
        /// </summary>
        /// <param name="mappingString">The mapping string</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMapping", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerAddMapping([NotNull] string mappingString);

        /// <summary>
        ///     Sdl the game controller num mappings
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNumMappings", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerNumMappings();

        /// <summary>
        ///     Internals the sdl game controller mapping for index using the specified mapping index
        /// </summary>
        /// <param name="mappingIndex">The mapping index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerMappingForIndex([NotNull] int mappingIndex);

        /// <summary>
        ///     Internals the sdl game controller add mappings from rw using the specified rw
        /// </summary>
        /// <param name="rw">The rw</param>
        /// <param name="freeRw">The free rw</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerAddMappingsFromRW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerAddMappingsFromRW([NotNull] IntPtr rw, [NotNull] int freeRw);

        /// <summary>
        ///     Internals the sdl game controller mapping for guid using the specified guid
        /// </summary>
        /// <param name="guid">The guid</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForGUID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerMappingForGUID(Guid guid);

        /// <summary>
        ///     Internals the sdl game controller mapping using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMapping", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerMapping([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the is game controller using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsGameController", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsGameController([NotNull] int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller name for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerNameForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerNameForIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller mapping for device index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerMappingForDeviceIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerMappingForDeviceIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Sdl the game controller open using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGameControllerOpen([NotNull] int joystickIndex);

        /// <summary>
        ///     Internals the sdl game controller name using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerName([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get vendor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetVendor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalGameControllerGetVendor([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get product using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProduct", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalGameControllerGetProduct([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get product version using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The ushort</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetProductVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern ushort InternalGameControllerGetProductVersion([NotNull] IntPtr gameController);

        /// <summary>
        ///     Internals the sdl game controller get serial using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSerial", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerGetSerial([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get attached using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAttached", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerGetAttached([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get joystick using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetJoystick", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGameControllerGetJoystick([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller event state using the specified state
        /// </summary>
        /// <param name="state">The state</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerEventState", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerEventState([NotNull] int state);

        /// <summary>
        ///     Sdl the game controller update
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerUpdate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGameControllerUpdate();

        /// <summary>
        ///     Internals the sdl game controller get axis from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller axis</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxisFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlGameControllerAxis InternalGameControllerGetAxisFromString([NotNull] string pchString);

        /// <summary>
        ///     Internals the sdl game controller get string for axis using the specified axis
        /// </summary>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerGetStringForAxis(SdlGameControllerAxis axis);

        /// <summary>
        ///     Internals the sdl game controller get bind for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern InternalSdlGameControllerButtonBind InternalGameControllerGetBindForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller get axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The short</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern short InternalGameControllerGetAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Internals the sdl game controller get button from string using the specified pch string
        /// </summary>
        /// <param name="pchString">The pch string</param>
        /// <returns>The sdl game controller button</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButtonFromString", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlGameControllerButton InternalGameControllerGetButtonFromString([NotNull] string pchString);

        /// <summary>
        ///     Internals the sdl game controller get string for button using the specified button
        /// </summary>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetStringForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerGetStringForButton(SdlGameControllerButton button);

        /// <summary>
        ///     Internals the sdl game controller get bind for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The internal sdl game controller button bind</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetBindForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern InternalSdlGameControllerButtonBind InternalGameControllerGetBindForButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller get button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The byte</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern byte InternalGameControllerGetButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="lowFrequencyRumble">The low frequency rumble</param>
        /// <param name="highFrequencyRumble">The high frequency rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerRumble([NotNull] IntPtr gameController, [NotNull] ushort lowFrequencyRumble, [NotNull] ushort highFrequencyRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Sdl the game controller rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="leftRumble">The left rumble</param>
        /// <param name="rightRumble">The right rumble</param>
        /// <param name="durationMs">The duration ms</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerRumbleTriggers([NotNull] IntPtr gameController, [NotNull] ushort leftRumble, [NotNull] ushort rightRumble, [NotNull] uint durationMs);

        /// <summary>
        ///     Sdl the game controller close using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGameControllerClose([NotNull] IntPtr gameController);

        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerGetAppleSFSymbolsNameForButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Internals the sdl game controller get apple sf symbols name for axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetAppleSFSymbolsNameForAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalGameControllerGetAppleSFSymbolsNameForAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller from instance id using the specified joy id
        /// </summary>
        /// <param name="joyId">The joy id</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerFromInstanceID", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGameControllerFromInstanceID([NotNull] int joyId);

        /// <summary>
        ///     Sdl the game controller type for index using the specified joystick index
        /// </summary>
        /// <param name="joystickIndex">The joystick index</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerTypeForIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlGameControllerType InternalGameControllerTypeForIndex([NotNull] int joystickIndex);

        /// <summary>
        ///     Sdl the game controller get type using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl game controller type</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetType", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlGameControllerType InternalGameControllerGetType([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller from player index using the specified player index
        /// </summary>
        /// <param name="playerIndex">The player index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerFromPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGameControllerFromPlayerIndex([NotNull] int playerIndex);

        /// <summary>
        ///     Sdl the game controller set player index using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="playerIndex">The player index</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetPlayerIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGameControllerSetPlayerIndex([NotNull] IntPtr gameController, [NotNull] int playerIndex);

        /// <summary>
        ///     Sdl the game controller has led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasLED([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller has rumble using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasRumble", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasRumble([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller has rumble triggers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasRumbleTriggers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasRumbleTriggers([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller set led using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetLED", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerSetLED([NotNull] IntPtr gameController, [NotNull] byte red, [NotNull] byte green, [NotNull] byte blue);

        /// <summary>
        ///     Sdl the game controller has axis using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="axis">The axis</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasAxis", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasAxis([NotNull] IntPtr gameController, SdlGameControllerAxis axis);

        /// <summary>
        ///     Sdl the game controller has button using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="button">The button</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasButton", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasButton([NotNull] IntPtr gameController, SdlGameControllerButton button);

        /// <summary>
        ///     Sdl the game controller get num touchpads using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetNumTouchpads", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerGetNumTouchpads([NotNull] IntPtr gameController);

        /// <summary>
        ///     Sdl the game controller get num touchpad fingers using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetNumTouchpadFingers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerGetNumTouchpadFingers([NotNull] IntPtr gameController, [NotNull] int touchpad);

        /// <summary>
        ///     Sdl the game controller get touchpad finger using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="touchpad">The touchpad</param>
        /// <param name="finger">The finger</param>
        /// <param name="state">The state</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="pressure">The pressure</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetTouchpadFinger", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerGetTouchpadFinger([NotNull] IntPtr gameController, [NotNull] int touchpad, [NotNull] int finger, out byte state, out float x, out float y, out float pressure);

        /// <summary>
        ///     Sdl the game controller has sensor using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerHasSensor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerHasSensor([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Sdl the game controller set sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="enabled">The enabled</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSetSensorEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerSetSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type, SdlBool enabled);

        /// <summary>
        ///     Sdl the game controller is sensor enabled using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerIsSensorEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalGameControllerIsSensorEnabled([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Sdl the game controller get sensor data using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <param name="data">The data</param>
        /// <param name="numValues">The num values</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSensorData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerGetSensorData([NotNull] IntPtr gameController, SdlSensorType type, [NotNull] IntPtr data, [NotNull] int numValues);

        /// <summary>
        ///     Sdl the game controller get sensor data rate using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="type">The type</param>
        /// <returns>The float</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerGetSensorDataRate", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern float InternalGameControllerGetSensorDataRate([NotNull] IntPtr gameController, SdlSensorType type);

        /// <summary>
        ///     Sdl the game controller send effect using the specified game controller
        /// </summary>
        /// <param name="gameController">The game controller</param>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GameControllerSendEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGameControllerSendEffect([NotNull] IntPtr gameController, [NotNull] IntPtr data, [NotNull] int size);

        /// <summary>
        ///     Sdl the haptic close using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticClose", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalHapticClose([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic destroy effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticDestroyEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalHapticDestroyEffect([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Sdl the haptic effect supported using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticEffectSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticEffectSupported([NotNull] IntPtr haptic, ref SdlHapticEffect effect);

        /// <summary>
        ///     Sdl the haptic get effect status using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticGetEffectStatus", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticGetEffectStatus([NotNull] IntPtr haptic, [NotNull] int effect);

        /// <summary>
        ///     Sdl the haptic index using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticIndex([NotNull] IntPtr haptic);

        /// <summary>
        ///     Internals the sdl haptic name using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern string InternalHapticName([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the haptic new effect using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <param name="effect">The effect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNewEffect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticNewEffect([NotNull] IntPtr haptic, ref SdlHapticEffect effect);

        /// <summary>
        ///     Sdl the haptic num axes using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumAxes", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticNumAxes([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic num effects using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumEffects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticNumEffects([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic num effects playing using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticNumEffectsPlaying", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticNumEffectsPlaying([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic open using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalHapticOpen([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the haptic opened using the specified device index
        /// </summary>
        /// <param name="deviceIndex">The device index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpened", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticOpened([NotNull] int deviceIndex);

        /// <summary>
        ///     Sdl the haptic open from joystick using the specified joystick
        /// </summary>
        /// <param name="joystick">The joystick</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpenFromJoystick", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalHapticOpenFromJoystick([NotNull] IntPtr joystick);

        /// <summary>
        ///     Sdl the haptic open from mouse
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticOpenFromMouse", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalHapticOpenFromMouse();

        /// <summary>
        ///     Sdl the haptic pause using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticPause", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticPause([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic query using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticQuery", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalHapticQuery([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the haptic rumble init using the specified haptic
        /// </summary>
        /// <param name="haptic">The haptic</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HapticRumbleInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalHapticRumbleInit([NotNull] IntPtr haptic);

        /// <summary>
        ///     Sdl the has 3 d now
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Has3DNow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHas3DNow();

        /// <summary>
        ///     Sdl the has avx 512 f
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasAVX512F", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasAvx512F();

        /// <summary>
        ///     Sdl the get system ram
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetSystemRAM", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetSystemRam();

        /// <summary>
        ///     Sdl the simd get alignment
        /// </summary>
        /// <returns>The uint</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDGetAlignment", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern uint InternalSimdGetAlignment();

        /// <summary>
        ///     Sdl the simd alloc using the specified len
        /// </summary>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDAlloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalSimdAlloc([NotNull] uint len);

        /// <summary>
        ///     Sdl the simd realloc using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        /// <param name="len">The len</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDRealloc", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalSimdRealloc([NotNull] IntPtr ptr, [NotNull] uint len);

        /// <summary>
        ///     Sdl the simd free using the specified ptr
        /// </summary>
        /// <param name="ptr">The ptr</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SIMDFree", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSimdFree(IntPtr ptr);

        /// <summary>
        ///     Sdl the has arms imd
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasARMSIMD", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalHasArmSimd();

        /// <summary>
        ///     Sdl the get preferred locales
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetPreferredLocales", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetPreferredLocales();

        /// <summary>
        ///     Internals the sdl open url using the specified url
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_OpenURL", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalOpenURL([NotNull, NotEmpty] byte[] url);

        /// <summary>
        ///     Sdl the gl get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGL_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Sdl the gl set attribute using the specified attr
        /// </summary>
        /// <param name="attr">The attr</param>
        /// <param name="value">The value</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetAttribute", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_SetAttribute([NotNull] SdlGlAttr attr, [NotNull] int value);

        /// <summary>
        ///     Sdl the gl set swap interval using the specified interval
        /// </summary>
        /// <param name="interval">The interval</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SetSwapInterval", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_SetSwapInterval([NotNull] int interval);

        /// <summary>
        ///     Sdl the gl swap window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_SwapWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalGL_SwapWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the gl unbind texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_UnbindTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGL_UnbindTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Sdl the hide window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_HideWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalHideWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the is screen saver enabled
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_IsScreenSaverEnabled", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalIsScreenSaverEnabled();

        /// <summary>
        ///     Sdl the maximize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MaximizeWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMaximizeWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the minimize window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_MinimizeWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMinimizeWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the raise window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RaiseWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRaiseWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the restore window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RestoreWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRestoreWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the set window brightness using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="brightness">The brightness</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBrightness", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowBrightness([NotNull] IntPtr window, float brightness);

        /// <summary>
        ///     Internals the sdl set window data using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="name">The name</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalSetWindowData([NotNull] IntPtr window, [NotNull] string name, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowDisplayMode([NotNull] IntPtr window, ref SdlDisplayMode mode);

        /// <summary>
        ///     Sdl the set window display mode using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="mode">The mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowDisplayMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowDisplayMode([NotNull] IntPtr window, [NotNull] IntPtr mode);

        /// <summary>
        ///     Sdl the set window fullscreen using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowFullscreen", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowFullscreen([NotNull] IntPtr window, [NotNull] uint flags);

        /// <summary>
        ///     Sdl the set window gamma ramp using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="red">The red</param>
        /// <param name="green">The green</param>
        /// <param name="blue">The blue</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGammaRamp", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowGammaRamp([NotNull] IntPtr window, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] red, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)] ushort[] green,
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U2, SizeConst = 256)]
            ushort[] blue);

        /// <summary>
        ///     Sdl the set window grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed);

        /// <summary>
        ///     Sdl the set window keyboard grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowKeyboardGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowKeyboardGrab([NotNull] IntPtr window, [NotNull] SdlBool grabbed);

        /// <summary>
        ///     Sdl the set window mouse grab using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="grabbed">The grabbed</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseGrab", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowMouseGrab([NotNull] IntPtr window, SdlBool grabbed);

        /// <summary>
        ///     Sdl the set window icon using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="icon">The icon</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowIcon", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowIcon([NotNull] IntPtr window, [NotNull] IntPtr icon);

        /// <summary>
        ///     Sdl the set window maximum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="maxW">The max</param>
        /// <param name="maxH">The max</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMaximumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowMaximumSize([NotNull] IntPtr window, [NotNull] int maxW, [NotNull] int maxH);

        /// <summary>
        ///     Sdl the set window minimum size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="minW">The min</param>
        /// <param name="minH">The min</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMinimumSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowMinimumSize([NotNull] IntPtr window, [NotNull] int minW, [NotNull] int minH);

        /// <summary>
        ///     Sdl the set window size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowSize([NotNull] IntPtr window, [NotNull] int w, [NotNull] int h);

        /// <summary>
        ///     Sdl the set window bordered using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="bordered">The bordered</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowBordered([NotNull] IntPtr window, SdlBool bordered);

        /// <summary>
        ///     Sdl the get window borders size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="top">The top</param>
        /// <param name="left">The left</param>
        /// <param name="bottom">The bottom</param>
        /// <param name="right">The right</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowBordered", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetWindowBordersSize([NotNull] IntPtr window, out int top, out int left, out int bottom, out int right);

        /// <summary>
        ///     Sdl the set window resizable using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="resizable">The resizable</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowResizable", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowResizable([NotNull] IntPtr window, SdlBool resizable);

        /// <summary>
        ///     Sdl the set window always on top using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="onTop">The on top</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowAlwaysOnTop", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowAlwaysOnTop([NotNull] IntPtr window, SdlBool onTop);

        /// <summary>
        ///     Internals the sdl set window title using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="title">The title</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowTitle", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowTitle([NotNull] IntPtr window, [NotNull] string title);

        /// <summary>
        ///     Sdl the show window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_ShowWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalShowWindow([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the update window surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpdateWindowSurface([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the update window surface rects using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rects">The rects</param>
        /// <param name="numRects">The num rects</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateWindowSurfaceRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpdateWindowSurfaceRects([NotNull] IntPtr window, [In] RectangleI[] rects, [NotNull] int numRects);

        /// <summary>
        ///     Internals the sdl video init using the specified driver name
        /// </summary>
        /// <param name="driverName">The driver name</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoInit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalVideoInit([NotNull] string driverName);

        /// <summary>
        ///     Sdl the video quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_VideoQuit", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalVideoQuit();

        /// <summary>
        ///     Sdl the set window hit test using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="callback">The callback</param>
        /// <param name="callbackData">The callback data</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowHitTest", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowHitTest([NotNull] IntPtr window, SdlHitTest callback, [NotNull] IntPtr callbackData);

        /// <summary>
        ///     Sdl the get grabbed window
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetGrabbedWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetGrabbedWindow();

        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowMouseRect([NotNull] IntPtr window, ref RectangleI rect);

        /// <summary>
        ///     Sdl the set window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetWindowMouseRect([NotNull] IntPtr window, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the get window mouse rect using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetWindowMouseRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetWindowMouseRect([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the flash window using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="operation">The operation</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_FlashWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalFlashWindow([NotNull] IntPtr window, SdlFlashOperation operation);

        /// <summary>
        ///     Sdl the compose custom blend mode using the specified src color factor
        /// </summary>
        /// <param name="srcColorFactor">The src color factor</param>
        /// <param name="dstColorFactor">The dst color factor</param>
        /// <param name="colorOperation">The color operation</param>
        /// <param name="srcAlphaFactor">The src alpha factor</param>
        /// <param name="dstAlphaFactor">The dst alpha factor</param>
        /// <param name="alphaOperation">The alpha operation</param>
        /// <returns>The sdl blend mode</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_ComposeCustomBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBlendMode InternalComposeCustomBlendMode([NotNull] SdlBlendFactor srcColorFactor, [NotNull] SdlBlendFactor dstColorFactor, [NotNull] SdlBlendOperation colorOperation, [NotNull] SdlBlendFactor srcAlphaFactor, [NotNull] SdlBlendFactor dstAlphaFactor, [NotNull] SdlBlendOperation alphaOperation);

        /// <summary>
        ///     Internals the sdl vulkan load library using the specified path
        /// </summary>
        /// <param name="path">The path</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_LoadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalVulkan_LoadLibrary([NotNull] string path);

        /// <summary>
        ///     Sdl the vulkan get vk get instance proc addr
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetVkGetInstanceProcAddr", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalVulkan_GetVkGetInstanceProcAddr();

        /// <summary>
        ///     Sdl the vulkan unload library
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_UnloadLibrary", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalVulkan_UnloadLibrary();

        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetInstanceExtensions", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalVulkan_GetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr pNames);

        /// <summary>
        ///     Sdl the vulkan get instance extensions using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="pCount">The count</param>
        /// <param name="pNames">The names</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetInstanceExtensions", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalVulkan_GetInstanceExtensions([NotNull] IntPtr window, out uint pCount, [NotNull] IntPtr[] pNames);

        /// <summary>
        ///     Sdl the vulkan create surface using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="instance">The instance</param>
        /// <param name="surface">The surface</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_CreateSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalVulkan_CreateSurface([NotNull] IntPtr window, [NotNull] IntPtr instance, out ulong surface);

        /// <summary>
        ///     Sdl the vulkan get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Vulkan_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalVulkan_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Sdl the metal create view using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_CreateView", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalMetal_CreateView([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the metal destroy view using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_DestroyView", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMetal_DestroyView([NotNull] IntPtr view);

        /// <summary>
        ///     Sdl the metal get layer using the specified view
        /// </summary>
        /// <param name="view">The view</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_GetLayer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalMetal_GetLayer([NotNull] IntPtr view);

        /// <summary>
        ///     Sdl the metal get drawable size using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_Metal_GetDrawableSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalMetal_GetDrawableSize([NotNull] IntPtr window, out int w, out int h);

        /// <summary>
        ///     Sdl the create renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="index">The index</param>
        /// <param name="flags">The flags</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateRenderer([NotNull] IntPtr window, [NotNull] int index, SdlRendererFlags flags);

        /// <summary>
        ///     Sdl the create software renderer using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateSoftwareRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateSoftwareRenderer([NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the create texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateTexture([NotNull] IntPtr renderer, [NotNull] uint format, [NotNull] int access, [NotNull] int w, [NotNull] int h);

        /// <summary>
        ///     Sdl the create texture from surface using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_CreateTextureFromSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalCreateTextureFromSurface([NotNull] IntPtr renderer, [NotNull] IntPtr surface);

        /// <summary>
        ///     Sdl the destroy renderer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDestroyRenderer([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the destroy texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_DestroyTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalDestroyTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Sdl the get num render drivers
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetNumRenderDrivers", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetNumRenderDrivers();

        /// <summary>
        ///     Sdl the get render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRenderDrawBlendMode([NotNull] IntPtr renderer, out SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the set texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureScaleMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetTextureScaleMode([NotNull] IntPtr texture, SdlScaleMode scaleMode);

        /// <summary>
        ///     Sdl the get texture scale mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="scaleMode">The scale mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureScaleMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetTextureScaleMode([NotNull] IntPtr texture, out SdlScaleMode scaleMode);

        /// <summary>
        ///     Sdl the set texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="userdata">The userdata</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureUserData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetTextureUserData([NotNull] IntPtr texture, [NotNull] IntPtr userdata);

        /// <summary>
        ///     Sdl the get texture user data using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureUserData", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetTextureUserData([NotNull] IntPtr texture);

        /// <summary>
        ///     Sdl the get render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRenderDrawColor([NotNull] IntPtr renderer, out byte r, out byte g, out byte b, out byte a);

        /// <summary>
        ///     Sdl the get render driver info using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderDriverInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRenderDriverInfo([NotNull] int index, out SdlRendererInfo info);

        /// <summary>
        ///     Sdl the get renderer using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetRenderer([NotNull] IntPtr window);

        /// <summary>
        ///     Sdl the get renderer info using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="info">The info</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererInfo", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRendererInfo([NotNull] IntPtr renderer, out SdlRendererInfo info);

        /// <summary>
        ///     Sdl the get renderer output size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRendererOutputSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetRendererOutputSize([NotNull] IntPtr renderer, out int w, out int h);

        /// <summary>
        ///     Sdl the get texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetTextureAlphaMod([NotNull] IntPtr texture, out byte alpha);

        /// <summary>
        ///     Sdl the get texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetTextureBlendMode([NotNull] IntPtr texture, out SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the get texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetTextureColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalGetTextureColorMod([NotNull] IntPtr texture, out byte r, out byte g, out byte b);

        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLockTexture([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr pixels, out int pitch);

        /// <summary>
        ///     Sdl the lock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLockTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr pixels, out int pitch);

        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTextureToSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLockTextureToSurface([NotNull] IntPtr texture, ref RectangleI rect, out IntPtr surface);

        /// <summary>
        ///     Sdl the lock texture to surface using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="surface">The surface</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_LockTextureToSurface", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalLockTextureToSurface([NotNull] IntPtr texture, [NotNull] IntPtr rect, out IntPtr surface);

        /// <summary>
        ///     Sdl the query texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="format">The format</param>
        /// <param name="access">The access</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_QueryTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalQueryTexture([NotNull] IntPtr texture, out uint format, out int access, out int w, out int h);

        /// <summary>
        ///     Sdl the render clear using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderClear", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderClear([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect);

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Sdl the render copy using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopy", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopy([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, ref PointI center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect"></param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointI center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleI dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render draw line using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLine", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawLine([NotNull] IntPtr renderer, [NotNull] int x1, [NotNull] int y1, [NotNull] int x2, [NotNull] int y2);

        /// <summary>
        ///     Sdl the render draw lines using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLines", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawLines([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count);

        /// <summary>
        ///     Sdl the render draw point using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoint", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawPoint([NotNull] IntPtr renderer, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Sdl the render draw points using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPoints", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawPoints([NotNull] IntPtr renderer, [In] PointI[] points, [NotNull] int count);

        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Sdl the render draw rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the render draw rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count);

        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Sdl the render fill rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the render fill rects using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRects", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRects([NotNull] IntPtr renderer, [In] RectangleI[] rects, [NotNull] int count);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Sdl the render copy f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyEx", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyEx([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, ref PointF center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, ref PointF center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dst">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, ref RectangleF dst, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, ref RectangleI srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render copy ex f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="srcRect">The src rect</param>
        /// <param name="dstRect">The dst rect</param>
        /// <param name="angle">The angle</param>
        /// <param name="center">The center</param>
        /// <param name="flip">The flip</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderCopyExF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderCopyExF([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [NotNull] IntPtr srcRect, [NotNull] IntPtr dstRect, double angle, [NotNull] IntPtr center, SdlRendererFlip flip);

        /// <summary>
        ///     Sdl the render geometry using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <param name="vertices">The vertices</param>
        /// <param name="numVertices">The num vertices</param>
        /// <param name="indices">The indices</param>
        /// <param name="numIndices">The num indices</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGeometry", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderGeometry([NotNull] IntPtr renderer, [NotNull] IntPtr texture, [In] SdlVertex[] vertices, [NotNull] int numVertices, [In] [NotNull] int[] indices, [NotNull] int numIndices);
        
        /// <summary>
        ///     Sdl the render draw point f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawPointF([NotNull] IntPtr renderer, float x, float y);

        /// <summary>
        ///     Sdl the render draw points f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawPointsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawPointsF(IntPtr renderer, [In] PointF[] points, [NotNull] int count);

        /// <summary>
        ///     Sdl the render draw line f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="x1">The </param>
        /// <param name="y1">The </param>
        /// <param name="x2">The </param>
        /// <param name="y2">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLineF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawLineF([NotNull] IntPtr renderer, float x1, float y1, float x2, float y2);

        /// <summary>
        ///     Sdl the render draw lines f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="points">The points</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawLinesF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawLinesF([NotNull] IntPtr renderer, [In] PointF[] points, [NotNull] int count);

        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRectF([NotNull] IntPtr renderer, ref RectangleF rect);

        /// <summary>
        ///     Sdl the render draw rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the render draw rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderDrawRectsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderDrawRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count);

        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRectF([NotNull] IntPtr renderer, RectangleF rect);

        /// <summary>
        ///     Sdl the render fill rect f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRectF([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the render fill rects f using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rects">The rects</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderFillRectsF", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderFillRectsF([NotNull] IntPtr renderer, [In] RectangleF[] rects, [NotNull] int count);

        /// <summary>
        ///     Sdl the render get clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderGetClipRect([NotNull] IntPtr renderer, out RectangleI rect);

        /// <summary>
        ///     Sdl the render get logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetLogicalSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderGetLogicalSize([NotNull] IntPtr renderer, out int w, out int h);

        /// <summary>
        ///     Sdl the render get scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderGetScale([NotNull] IntPtr renderer, out float scaleX, out float scaleY);

        /// <summary>
        ///     Sdl the render window to logical using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderWindowToLogical", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderWindowToLogical([NotNull] IntPtr renderer, [NotNull] int windowX, [NotNull] int windowY, out float logicalX, out float logicalY);

        /// <summary>
        ///     Sdl the render logical to window using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="logicalX">The logical</param>
        /// <param name="logicalY">The logical</param>
        /// <param name="windowX">The window</param>
        /// <param name="windowY">The window</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderLogicalToWindow", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderLogicalToWindow([NotNull] IntPtr renderer, float logicalX, float logicalY, out int windowX, out int windowY);

        /// <summary>
        ///     Sdl the render get viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetViewport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderGetViewport([NotNull] IntPtr renderer, out RectangleI rect);

        /// <summary>
        ///     Sdl the render present using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderPresent", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalRenderPresent(IntPtr renderer);

        /// <summary>
        ///     Sdl the render read pixels using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <param name="format">The format</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderReadPixels", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderReadPixels([NotNull] IntPtr renderer, ref RectangleI rect, [NotNull] uint format, [NotNull] IntPtr pixels, [NotNull] int pitch);

        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetClipRect([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Sdl the render set clip rect using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetClipRect", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetClipRect([NotNull] IntPtr renderer, [NotNull] IntPtr rect);

        /// <summary>
        ///     Sdl the render set logical size using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetLogicalSize", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetLogicalSize([NotNull] IntPtr renderer, [NotNull] int w, [NotNull] int h);

        /// <summary>
        ///     Sdl the render set scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="scaleX">The scale</param>
        /// <param name="scaleY">The scale</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetScale([NotNull] IntPtr renderer, float scaleX, float scaleY);

        /// <summary>
        ///     Sdl the render set integer scale using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="enable">The enable</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetIntegerScale", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetIntegerScale([NotNull] IntPtr renderer, SdlBool enable);

        /// <summary>
        ///     Sdl the render set viewport using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="rect">The rect</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderSetViewport", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalRenderSetViewport([NotNull] IntPtr renderer, ref RectangleI rect);

        /// <summary>
        ///     Sdl the set render draw blend mode using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetRenderDrawBlendMode([NotNull] IntPtr renderer, SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the set render draw color using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <param name="a">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderDrawColor", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetRenderDrawColor([NotNull] IntPtr renderer, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b, [NotNull] byte a);

        /// <summary>
        ///     Sdl the set render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="texture">The texture</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetRenderTarget([NotNull] IntPtr renderer, [NotNull] IntPtr texture);

        /// <summary>
        ///     Sdl the set texture alpha mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="alpha">The alpha</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureAlphaMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetTextureAlphaMod([NotNull] IntPtr texture, [NotNull] byte alpha);

        /// <summary>
        ///     Sdl the set texture blend mode using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="blendMode">The blend mode</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureBlendMode", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetTextureBlendMode([NotNull] IntPtr texture, SdlBlendMode blendMode);

        /// <summary>
        ///     Sdl the set texture color mod using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="r">The </param>
        /// <param name="g">The </param>
        /// <param name="b">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetTextureColorMod", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalSetTextureColorMod([NotNull] IntPtr texture, [NotNull] byte r, [NotNull] byte g, [NotNull] byte b);

        /// <summary>
        ///     Sdl the unlock texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_UnlockTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalUnlockTexture([NotNull] IntPtr texture);

        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpdateTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr pixels, [NotNull] int pitch);

        /// <summary>
        ///     Sdl the update texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="pixels">The pixels</param>
        /// <param name="pitch">The pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpdateTexture([NotNull] IntPtr texture, [NotNull] IntPtr rect, [NotNull] IntPtr pixels, [NotNull] int pitch);
        
        /// <summary>
        ///     Sdl the update nv texture using the specified texture
        /// </summary>
        /// <param name="texture">The texture</param>
        /// <param name="rect">The rect</param>
        /// <param name="yPlane">The plane</param>
        /// <param name="yPitch">The pitch</param>
        /// <param name="uvPlane">The uv plane</param>
        /// <param name="uvPitch">The uv pitch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_UpdateNVTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern int InternalUpdateNVTexture([NotNull] IntPtr texture, ref RectangleI rect, [NotNull] IntPtr yPlane, [NotNull] int yPitch, [NotNull] IntPtr uvPlane, [NotNull] int uvPitch);

        /// <summary>
        ///     Sdl the render target supported using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderTargetSupported", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalRenderTargetSupported([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the get render target using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GetRenderTarget", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGetRenderTarget([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the render get metal layer using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetMetalLayer", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRenderGetMetalLayer([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the render get metal command encoder using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_RenderGetMetalCommandEncoder", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalRenderGetMetalCommandEncoder([NotNull] IntPtr renderer);

        /// <summary>
        ///     Sdl the i phone set event pump using the specified enabled
        /// </summary>
        /// <param name="enabled">The enabled</param>
        [DllImport(NativeLibName, EntryPoint = "SDL_iPhoneSetEventPump", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalIPhoneSetEventPump([NotNull] SdlBool enabled);

        /// <summary>
        ///     Sdl the set window position using the specified window
        /// </summary>
        /// <param name="window">The window</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [DllImport(NativeLibName, EntryPoint = "SDL_SetWindowPosition", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetWindowPosition([NotNull] IntPtr window, [NotNull] int x, [NotNull] int y);

        /// <summary>
        ///     Sdl the gl get current context
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_GL_GetCurrentContext", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern IntPtr InternalGlGetCurrentContext();

        /// <summary>
        ///     Sdl the has neon
        /// </summary>
        /// <returns>The sdl bool</returns>
        [DllImport(NativeLibName, EntryPoint = "SDL_HasNEON", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern SdlBool InternalHasNeon();
    }
}