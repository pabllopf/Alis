// Licensed under the Apache License, Version 2.0 (the "License").
// See the LICENSE file in the project root for more information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using Alis.Core.Input.Controllers;
using DevDecoder.HIDDevices;
using DynamicData;

namespace Alis.Core.Input
{
    /// <summary>
    ///     Class DeviceExtensions implements various extension methods.
    /// </summary>
    public static class DeviceExtensions
    {
        /// <summary>
        ///     Controllerses the devices
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="devices">The devices</param>
        /// <param name="predicate">The predicate</param>
        /// <returns>An observable of t</returns>
        public static IObservable<T> Controllers<T>(this IObservableCache<Device, string> devices,
            Func<T, bool> predicate = null)
            where T : Controller
            => devices.Connect()
                .Flatten()
                .Where(change => change.Reason == ChangeReason.Add)
                .Select(change => change.Current)
#pragma warning disable CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
                .Select(Input.Controllers.Controller.Create<T>)
#pragma warning restore CS8621 // Nullability of reference types in return type doesn't match the target delegate (possibly because of nullability attributes).
                .Where(controller => controller != null && (predicate is null || predicate(controller)));


        /// <summary>
        ///     Controllerses the devices
        /// </summary>
        /// <param name="devices">The devices</param>
        /// <param name="controllerType">The controller type</param>
        /// <param name="predicate">The predicate</param>
        /// <returns>An observable of controller</returns>
        public static IObservable<Controller> Controllers(this IObservableCache<Device, string> devices,
            Type controllerType,
            Func<Controller, bool> predicate = null)
        {
            return devices.Connect()
                .Flatten()
                .Where(change => change.Reason == ChangeReason.Add)
                .Select(change => Input.Controllers.Controller.Create(change.Current, controllerType)!)
                .Where(controller => controller != null && (predicate is null || predicate(controller)));
        }

        /// <summary>
        ///     Gets a filtered observable of control changes.
        /// </summary>
        /// <param name="devices">The device collection.</param>
        /// <param name="predicate">
        ///     A function that returns <see langword="true" /> if the control should be monitored for changes;
        ///     otherwise <see langword="false" />.
        /// </param>
        /// <returns>A filtered observable of control changes.</returns>
        public static IObservable<IList<ControlChange>> ControlChanges(
            this IObservableCache<Device, string> devices,
            Func<Control, bool> predicate = null)
        {
            return devices
                .Connect()
                .Flatten()
                .Where(change =>
                    change.Reason != ChangeReason.Remove && (predicate is null || change.Current.Keys.Any(predicate)))
                .SelectMany(change => change.Current.Watch(predicate)
                    // Suppress errors so we don't stop listening on valid controllers - error will already have been logged.
                    .Catch((Exception _) => Observable.Empty<IList<ControlChange>>()))
                .Where(l => l.Count > 0);
        }

        /// <summary>
        ///     Connecteds the devices
        /// </summary>
        /// <param name="devices">The devices</param>
        /// <param name="predicate">The predicate</param>
        /// <returns>An observable of i change set device and string</returns>
        public static IObservable<IChangeSet<Device, string>> Connected(this IObservableCache<Device, string> devices,
            Func<Device, bool> predicate = null)
        {
            return ObservableChangeSet.Create<Device, string>(sourceCache
                        => devices.Connect(predicate)
                            .Flatten()
                            .SelectMany(change => change.Reason == ChangeReason.Remove
                                ? new[] { (device: change.Current, isConnected: false) }.ToObservable()
                                : change.Current.ConnectionState.Select(isConnected =>
                                    (device: change.Current, isConnected)))
                            .Subscribe(tuple =>
                            {
                                if (tuple.isConnected)
                                {
                                    sourceCache.AddOrUpdate(tuple.device);
                                }
                                else
                                {
                                    sourceCache.Remove(tuple.device);
                                }
                            }),
                    device => device.DevicePath)
                .AsObservableCache()
                .Connect();
        }

        /// <summary>
        ///     Filters devices, such that the device must implement all supplied
        /// </summary>
        /// <param name="devices">The device collection.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>A filtered observable of device change sets.</returns>
        public static IObservable<IChangeSet<Device, string>> DeviceUsagesAll(
            this IObservableCache<Device, string> devices,
            params Usage[] usages)
        {
            return devices.Connect(device => device.UsagesAll(usages));
        }

        /// <summary>
        ///     Filters devices, such that the device must implement at least one of the supplied
        /// </summary>
        /// <param name="devices">The device collection.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>A filtered observable of device change sets.</returns>
        public static IObservable<IChangeSet<Device, string>> DeviceUsagesAny(
            this IObservableCache<Device, string> devices,
            params Usage[] usages)
        {
            return devices.Connect(device => device.UsagesAny(usages));
        }

        /// <summary>
        ///     Filters devices, such that the device must have controls that implement all supplied
        /// </summary>
        /// <param name="devices">The device collection.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>A filtered observable of device change sets.</returns>
        public static IObservable<IChangeSet<Device, string>> ControlUsagesAll(
            this IObservableCache<Device, string> devices,
            params Usage[] usages)
        {
            return devices.Connect(device => device.ControlUsagesAll(usages));
        }

        /// <summary>
        ///     Filters devices, such that the device must have controls that implement at least one of the supplied
        /// </summary>
        /// <param name="devices">The device collection.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>A filtered observable of device change sets.</returns>
        public static IObservable<IChangeSet<Device, string>> ControlUsagesAny(
            this IObservableCache<Device, string> devices,
            params Usage[] usages)
        {
            return devices.Connect(device => device.ControlUsagesAny(usages));
        }

        /// <summary>
        ///     Checks that the device implements all supplied
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified device implements all the supplied usages; otherwise
        ///     <see langword="false" />.
        /// </returns>
        public static bool UsagesAll(
            this Device device,
            params Usage[] usages)
        {
            return device.Usages.ContainsAll(usages);
        }


        /// <summary>
        ///     Describes whether usages any
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="usages">The usages</param>
        /// <returns>The bool</returns>
        public static bool UsagesAny(
            this Device device,
            params Usage[] usages)
        {
            return usages.Any(usage => device.Usages.Contains(usage));
        }

        /// <summary>
        ///     Checks that the device has controls that implement all the supplied
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified device has controls that implement all the supplied usages; otherwise
        ///     <see langword="false" />.
        /// </returns>
        public static bool ControlUsagesAll(
            this Device device,
            params Usage[] usages)
        {
            return usages.All(usage => device.Controls.Any(control => control.Usages.Contains(usage)));
        }

        /// <summary>
        ///     Checks that the device has controls that implement at least one of the supplied
        /// </summary>
        /// <param name="device">The device.</param>
        /// <param name="usages">The required device usages.</param>
        /// <returns>
        ///     <see langword="true" /> if the specified device has controls that implement at least one of the supplied
        ///     usages; otherwise <see langword="false" />.
        /// </returns>
        public static bool ControlUsagesAny(
            this Device device,
            params Usage[] usages)
        {
            return usages.Any(usage => device.Controls.Any(control => control.Usages.Contains(usage)));
        }

        /// <summary>
        ///     controller
        /// </summary>
        /// <param name="device"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Controller<T>(this Device device) where T : Controller
        {
            return Input.Controllers.Controller.Create<T>(device);
        }


        /// <summary>
        ///     Controllers the device
        /// </summary>
        /// <param name="device">The device</param>
        /// <param name="controllerType">The controller type</param>
        /// <returns>The controller</returns>
        public static Controller Controller(this Device device, Type controllerType)
        {
            return Input.Controllers.Controller.Create(device, controllerType);
        }


        /// <summary>
        ///     Describes whether contains all
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="items">The items</param>
        /// <returns>The bool</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> enumerable, params T[] items)
        {
            return enumerable.ContainsAll(null!, items);
        }


        /// <summary>
        ///     Describes whether contains all
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="comparer">The comparer</param>
        /// <param name="items">The items</param>
        /// <returns>The bool</returns>
        public static bool ContainsAll<T>(
            this IEnumerable<T> enumerable,
            IEqualityComparer<T> comparer,
            params T[] items)
        {
            if (items.Length < 1)
            {
                return true;
            }

            if (items.Length < 2)
            {
                return enumerable.Contains(items[0], comparer);
            }

            var hashSet = new HashSet<T>(items, comparer);
            foreach (var item in enumerable)
            {
                hashSet.Remove(item);
                if (hashSet.Count < 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}