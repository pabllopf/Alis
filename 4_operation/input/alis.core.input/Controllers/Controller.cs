// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Controller.cs
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
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Subjects;
using System.Runtime.CompilerServices;
using System.Threading;
using DevDecoder.HIDDevices;
using BooleanConverter = Alis.Core.Input.Converters.BooleanConverter;

namespace Alis.Core.Input.Controllers
{
    /// <summary>
    ///     Class Controller is a collection of controls mapped to properties.
    ///     Implements the <see cref="IReadOnlyCollection{T}" /> interface.
    ///     Implements the <see cref="IDisposable" /> interface.
    /// </summary>
    /// <seealso cref="IReadOnlyCollection{T}" />
    /// <seealso cref="IDisposable" />
    public partial class Controller : IReadOnlyCollection<ControlValue>, IDisposable
    {
        /// <summary>
        ///     The control value
        /// </summary>
        private readonly ConcurrentDictionary<string, ControlValue> _values =
            new ConcurrentDictionary<string, ControlValue>();

        /// <summary>
        ///     The mapping of <seealso cref="Control" /> to associated <see cref="ControlInfo">ControlInfos</see>.
        /// </summary>
        public readonly IReadOnlyDictionary<Control, IReadOnlyList<ControlInfo>> Mapping;

        /// <summary>
        ///     The subscription
        /// </summary>
        private IDisposable _subscription;

        /// <summary>
        ///     The values subject
        /// </summary>
        private Subject<IList<ControlValue>> _valuesSubject;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Controller" /> class
        /// </summary>
        static Controller() =>
            // Register a default converter to boolean.
            s_defaultConverters[typeof(bool)] = BooleanConverter.Instance;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Controller" /> class
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="controls">The controls</param>
        protected Controller(Device device, params ControlInfo[] controls)
        {
            Device = device;
            Mapping = controls.GroupBy(c => c.Control)
                .ToDictionary(g => g.Key, g => (IReadOnlyList<ControlInfo>) g.ToArray());
            _valuesSubject = new Subject<IList<ControlValue>>();
        }

        /// <summary>
        ///     Gets the controls associated with this controller.
        /// </summary>
        /// <value>The controls.</value>
        public IEnumerable Controls => Mapping.Values;

        /// <summary>
        ///     Gets the timestamp of the last update received from the controller.
        /// </summary>
        /// <value>The timestamp.</value>
        public long Timestamp { get; private set; }

        /// <summary>
        ///     Gets the associated device.
        /// </summary>
        /// <value>The device.</value>
        public Device Device { get; }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name => Device.Name;

        /// <summary>
        ///     Gets an observable of the device's connection state.
        /// </summary>
        /// <value>
        ///     An observable of the device's connection state, which returns <see langword="true" /> when connecting and
        ///     <see langword="false" /> when disconnecting.
        /// </value>
        public IObservable<bool> ConnectionState => Device.ConnectionState;

        /// <summary>
        ///     Gets a value indicating whether this controller is connected.
        /// </summary>
        /// <value><see langword="true" /> if this controller is connected; otherwise, <see langword="false" />.</value>
        public bool IsConnected => (_subscription != null) && Device.IsConnected;

        /// <summary>
        ///     Gets an observable of changes.
        /// </summary>
        /// <value>The changes.</value>
        /// <exception cref="ObjectDisposedException">The controller is disposed.</exception>
        public IObservable<IList<ControlValue>> Changes => _valuesSubject ?? throw new ObjectDisposedException(Name);

        /// <summary>
        ///     The type converter
        /// </summary>
        private static readonly ConcurrentDictionary<Type, TypeConverter> s_defaultConverters =
            new ConcurrentDictionary<Type, TypeConverter>();

        /// <inheritdoc />
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc />
        public IEnumerator<ControlValue> GetEnumerator() => _values.Values.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <inheritdoc />
        public int Count => _values.Count;

        /// <summary>
        ///     Connects to the controller and starts listening for changes.
        /// </summary>
        public void Connect()
        {
            // Create a new subscription, disposing any existing one.
            Interlocked.Exchange(ref _subscription, Device.Subscribe(OnControlChange, OnError, OnDisconnect))
                ?.Dispose();
        }

        /// <summary>
        ///     Describes whether this instance is mapped
        /// </summary>
        /// <param name="propertyName">The property name</param>
        /// <returns>The bool</returns>
        public bool IsMapped(string propertyName)
        {
            return Mapping.Values
                .SelectMany(list => list)
                .Any(controlInfo => string.Equals(controlInfo.PropertyName, propertyName));
        }


        /// <summary>
        ///     Gets the value using the specified property name
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="propertyName">The property name</param>
        /// <exception cref="InvalidOperationException"></exception>
        /// <returns>The</returns>
        protected T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (!_values.TryGetValue(propertyName!, out ControlValue controlValue))
            {
                return default(T)!;
            }

            if (!typeof(T).IsAssignableFrom(controlValue.Type))
            {
                throw new InvalidOperationException(string.Format(Resources.ControllerInvalidPropertyType, propertyName,
                    typeof(T), controlValue.Type));
            }

            object value = controlValue.Value;
            return value is null ? default(T)! : (T) value;
        }

        /// <summary>
        ///     Called when the controller is disconnected.
        /// </summary>
        protected virtual void OnDisconnect()
        {
            Interlocked.Exchange(ref _subscription, null)?.Dispose();
        }

        /// <summary>
        ///     Called when an error is raised by the underlying connection.
        /// </summary>
        /// <param name="exception">The exception.</param>
        protected virtual void OnError(Exception exception)
        {
            Interlocked.Exchange(ref _subscription, null)?.Dispose();
        }

        /// <summary>
        ///     Called when a control's value changes.
        /// </summary>
        /// <param name="changes">The changes.</param>
        /// <exception cref="InvalidOperationException">No converter was found for a control.</exception>
        protected virtual void OnControlChange(IList<ControlChange> changes)
        {
            List<ControlValue> valueChanges = new List<ControlValue>(changes.Count);
            foreach (ControlChange change in changes)
            {
                if (!Mapping.TryGetValue(change.Control, out IReadOnlyList<ControlInfo> list))
                {
                    continue;
                }

                foreach (ControlInfo controlInfo in list)
                {
                    object value;
                    // Find converter, or get default converter
                    TypeConverter converter = controlInfo.Converter ??
                                              (s_defaultConverters.TryGetValue(controlInfo.Type, out TypeConverter defaultConverter)
                                                  ? defaultConverter
                                                  : null);

                    if (converter is null)
                    {
                        // Attempt to get valid TypeConverter
                        converter = TypeDescriptor.GetConverter(controlInfo.Type);
                        if (!converter.CanConvertFrom(typeof(double)))
                        {
                            converter = null;
                        }
                    }

                    if (converter is null)
                    {
                        if (!controlInfo.Type.IsAssignableFrom(typeof(double)))
                        {
                            throw new InvalidOperationException(
                                string.Format(
                                    Resources.ControllerMissingConverter,
                                    controlInfo.PropertyName, controlInfo.Type));
                        }

                        // We can accept a double directly
                        value = change.Value;
                    }
                    else
                    {
                        value = converter.ConvertFrom(change.Value);
                    }

                    ControlValue controlValue = new ControlValue(change, controlInfo, value);
                    _values[controlInfo.PropertyName] = controlValue;

                    if (change.Timestamp > Timestamp)
                    {
                        Timestamp = change.Timestamp;
                    }

                    valueChanges.Add(controlValue);
                }
            }

            if (valueChanges.Count > 0)
            {
                _valuesSubject?.OnNext(valueChanges.ToArray());
            }
        }

        /// <summary>
        ///     Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing">
        ///     <see langword="true" /> to release both managed and unmanaged resources;
        ///     <see langword="false" /> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Interlocked.Exchange(ref _subscription, null)?.Dispose();
                Interlocked.Exchange(ref _valuesSubject, null)?.Dispose();
            }
        }


        /// <summary>
        ///     Changeses the since using the specified timestamp
        /// </summary>
        /// <param name="timestamp">The timestamp</param>
        /// <returns>A read only list of control value</returns>
        public IReadOnlyList<ControlValue> ChangesSince(long timestamp)
        {
            return timestamp < Timestamp
                ? _values.Values.Where(c => c.Timestamp > timestamp).ToArray()
                : Array.Empty<ControlValue>();
        }


        /// <summary>
        ///     Creates the device
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="device">The device</param>
        /// <returns>The</returns>
        public static T Create<T>(Device device) where T : Controller => ControllerInfo.Get<T>()?.CreateController(device) as T;


        /// <summary>
        ///     Creates the device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="deviceType">The device type</param>
        /// <returns>The controller</returns>
        public static Controller Create(Device device, Type deviceType) => ControllerInfo.Get(deviceType)?.CreateController(device);

        /// <summary>
        ///     Registers a control creation delegate which creates controls for the specified controller type
        /// </summary>
        /// <typeparam name="T">The controller type.</typeparam>
        /// <param name="createControllerDelegate">The create controller delegate.</param>
        public static void Register<T>(CreateControllerDelegate<T> createControllerDelegate) where T : Controller
        {
            Register(typeof(T), createControllerDelegate);
        }

        /// <summary>
        ///     Registers a control creation delegate which creates controls
        /// </summary>
        /// <param name="type">The controller type.</param>
        /// <param name="createControllerDelegate">The create controller delegate.</param>
        public static void Register(
            Type type,
            CreateControllerDelegate<Controller> createControllerDelegate)
        {
            ControllerInfo.Register(type, createControllerDelegate);
        }

        /// <summary>
        ///     Registers a default type converter used for converting control values to property values.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="converter">The converter.</param>
        /// <exception cref="ArgumentOutOfRangeException">The supplied converter must implement IControlConverter&lt;&gt;</exception>
        public static void RegisterDefaultTypeConverter(Type type, TypeConverter converter)
        {
            s_defaultConverters[type] = converter;
        }
    }
}