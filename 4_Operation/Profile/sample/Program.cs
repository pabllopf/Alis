// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

namespace Alis.Core.Profile.Sample
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            ProfilerService profilerService = new ProfilerService();

            profilerService.StartProfiling();

            // Call the method you want to profile here
            SampleMethod();

            ProfileData profileData = profilerService.StopProfiling();

            Console.WriteLine($"CPU Usage: {profileData.CpuUsage}");
            Console.WriteLine($"Memory Usage: {profileData.MemoryUsage}");
        }

        private static void SampleMethod()
        {
            // This is a placeholder for the method you want to profile
            // Replace this with the actual code
            for (int i = 0; i < 1000000; i++)
            {
                int j = i;
            }
        }
    }
}