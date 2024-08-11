// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP15.cs
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
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.ImGui.Extras.Plot;
using Alis.Extension.Graphic.ImGui.Extras.Plot.Native;
using Xunit;

namespace Alis.Extension.Graphic.ImGui.Test.Extras.Plot.Native
{
    /// <summary>
    /// The im plot test class
    /// </summary>
    public class ImPlotTestP15
    {
        /// <summary>
        /// Tests that plot bar groups u int 32 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt32_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            uint[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }
        
        /// <summary>
        /// Tests that plot bar groups int 64 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_Int64_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            long[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }
        
        /// <summary>
        /// Tests that plot bar groups u int 64 test
        /// </summary>
        [Fact]
        public void PlotBarGroups_UInt64_Test()
        {
            string[] labelIds = {"Label1", "Label2"};
            ulong[] values = {1, 2};
            int itemCount = 2;
            int groupCount = 1;
            double groupSize = 0.67;
            double shift = 0;
            ImPlotBarGroupsFlags flags = 0;
            
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotBarGroups(labelIds, values, itemCount, groupCount, groupSize, shift, flags));
        }
        
        /// <summary>
        /// Tests that plot bars float test
        /// </summary>
        [Fact]
        public void PlotBars_Float_Test()
        {
            string labelId = "Label1";
            float[] values = {1.0f, 2.0f};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(float);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, ref values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars double test
        /// </summary>
        [Fact]
        public void PlotBars_Double_Test()
        {
            string labelId = "Label1";
            double[] values = {1.0, 2.0};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(double);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars s byte test
        /// </summary>
        [Fact]
        public void PlotBars_SByte_Test()
        {
            string labelId = "Label1";
            sbyte[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(sbyte);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars byte test
        /// </summary>
        [Fact]
        public void PlotBars_Byte_Test()
        {
            string labelId = "Label1";
            byte[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(byte);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars int 16 test
        /// </summary>
        [Fact]
        public void PlotBars_Int16_Test()
        {
            string labelId = "Label1";
            short[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(short);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars u int 16 test
        /// </summary>
        [Fact]
        public void PlotBars_UInt16_Test()
        {
            string labelId = "Label1";
            ushort[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(ushort);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars int 32 test
        /// </summary>
        [Fact]
        public void PlotBars_Int32_Test()
        {
            string labelId = "Label1";
            int[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(int);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
        
        /// <summary>
        /// Tests that plot bars u int 32 test
        /// </summary>
        [Fact]
        public void PlotBars_UInt32_Test()
        {
            string labelId = "Label1";
            uint[] values = {1, 2};
            int count = 2;
            double barSize = 0.67;
            double shift = 0;
            ImPlotBarsFlags flags = 0;
            int offset = 0;
            int stride = sizeof(uint);
            
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars(labelId, values, count, barSize, shift, flags, offset, stride));
        }
    }
}