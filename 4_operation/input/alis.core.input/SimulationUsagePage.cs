// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimulationUsagePage.cs
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

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class SimulationUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SimulationUsagePage" /> class
        /// </summary>
        private SimulationUsagePage() : base(0x0002, "Simulation")
        {
        }

        /// <summary>
        ///     Singleton instance of Simulation Usage Page.
        /// </summary>
        public static readonly SimulationUsagePage Instance = new SimulationUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Flight Simulation Device", UsageTypes.Ca);
                case 0x0002: return new Usage(this, id, "Automobile Simulation Device", UsageTypes.Ca);
                case 0x0003: return new Usage(this, id, "Tank Simulation Device", UsageTypes.Ca);
                case 0x0004: return new Usage(this, id, "Spaceship Simulation Device", UsageTypes.Ca);
                case 0x0005: return new Usage(this, id, "Submarine Simulation Device", UsageTypes.Ca);
                case 0x0006: return new Usage(this, id, "Sailing Simulation Device", UsageTypes.Ca);
                case 0x0007: return new Usage(this, id, "Motorcycle Simulation Device", UsageTypes.Ca);
                case 0x0008: return new Usage(this, id, "Sports Simulation Device", UsageTypes.Ca);
                case 0x0009: return new Usage(this, id, "Airplane Simulation Device", UsageTypes.Ca);
                case 0x000a: return new Usage(this, id, "Helicopter Simulation Device", UsageTypes.Ca);
                case 0x000b: return new Usage(this, id, "Magic Carpet Simulation Device", UsageTypes.Ca);
                case 0x000c: return new Usage(this, id, "Bicycle Simulation Device", UsageTypes.Ca);
                case 0x0020: return new Usage(this, id, "Flight Control Stick", UsageTypes.Ca);
                case 0x0021: return new Usage(this, id, "Flight Stick", UsageTypes.Ca);
                case 0x0022: return new Usage(this, id, "Cyclic Control", UsageTypes.Cp);
                case 0x0023: return new Usage(this, id, "Cyclic Trim", UsageTypes.Cp);
                case 0x0024: return new Usage(this, id, "Flight Yoke", UsageTypes.Ca);
                case 0x0025: return new Usage(this, id, "Track Control", UsageTypes.Cp);
                case 0x00b0: return new Usage(this, id, "Aileron", UsageTypes.Dv);
                case 0x00b1: return new Usage(this, id, "Aileron Trim", UsageTypes.Dv);
                case 0x00b2: return new Usage(this, id, "Anti-Torque Control", UsageTypes.Dv);
                case 0x00b3: return new Usage(this, id, "Autopilot Enable", UsageTypes.Ooc);
                case 0x00b4: return new Usage(this, id, "Chaff Release", UsageTypes.Osc);
                case 0x00b5: return new Usage(this, id, "Collective Control", UsageTypes.Dv);
                case 0x00b6: return new Usage(this, id, "Dive Brake", UsageTypes.Dv);
                case 0x00b7: return new Usage(this, id, "Electronic Countermeasures", UsageTypes.Ooc);
                case 0x00b8: return new Usage(this, id, "Elevator", UsageTypes.Dv);
                case 0x00b9: return new Usage(this, id, "Elevator Trim", UsageTypes.Dv);
                case 0x00ba: return new Usage(this, id, "Rudder", UsageTypes.Dv);
                case 0x00bb: return new Usage(this, id, "Throttle", UsageTypes.Dv);
                case 0x00bc: return new Usage(this, id, "Flight Communications", UsageTypes.Ooc);
                case 0x00bd: return new Usage(this, id, "Flare Release", UsageTypes.Osc);
                case 0x00be: return new Usage(this, id, "Landing Gear", UsageTypes.Ooc);
                case 0x00bf: return new Usage(this, id, "Toe Brake", UsageTypes.Dv);
                case 0x00c0: return new Usage(this, id, "Trigger", UsageTypes.Mc);
                case 0x00c1: return new Usage(this, id, "Weapons Arm", UsageTypes.Ooc);
                case 0x00c2: return new Usage(this, id, "Weapons Select", UsageTypes.Osc);
                case 0x00c3: return new Usage(this, id, "Wing Flaps", UsageTypes.Dv);
                case 0x00c4: return new Usage(this, id, "Accelerator", UsageTypes.Dv);
                case 0x00c5: return new Usage(this, id, "Brake", UsageTypes.Dv);
                case 0x00c6: return new Usage(this, id, "Clutch", UsageTypes.Dv);
                case 0x00c7: return new Usage(this, id, "Shifter", UsageTypes.Dv);
                case 0x00c8: return new Usage(this, id, "Steering", UsageTypes.Dv);
                case 0x00c9: return new Usage(this, id, "Turret Direction", UsageTypes.Dv);
                case 0x00ca: return new Usage(this, id, "Barrel Elevation", UsageTypes.Dv);
                case 0x00cb: return new Usage(this, id, "Dive Plane", UsageTypes.Dv);
                case 0x00cc: return new Usage(this, id, "Ballast", UsageTypes.Dv);
                case 0x00cd: return new Usage(this, id, "Bicycle Crank", UsageTypes.Dv);
                case 0x00ce: return new Usage(this, id, "Handle Bars", UsageTypes.Dv);
                case 0x00cf: return new Usage(this, id, "Front Brake", UsageTypes.Dv);
                case 0x00d0: return new Usage(this, id, "Rear Brake", UsageTypes.Dv);
            }

            return base.CreateUsage(id);
        }
    }
}