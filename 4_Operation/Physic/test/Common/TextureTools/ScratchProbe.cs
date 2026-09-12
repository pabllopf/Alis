using System;
using System.Collections.Generic;
using System.IO;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common.TextureTools;
using Xunit;

namespace Alis.Core.Physic.Test.Common.TextureTools
{
    public class ScratchProbe
    {
        [Fact]
        public void Probe()
        {
            sbyte[,] f = new sbyte[40, 40];
            for (int x = 0; x < 40; x++)
            {
                for (int y = 0; y < 40; y++)
                {
                    f[x, y] = 1;
                }
            }

            for (int x = 1; x <= 2; x++)
            {
                for (int y = 1; y <= 2; y++)
                {
                    f[x, y] = -1;
                }
            }

            Aabb domain = new Aabb(new Vector2F(0, 0), new Vector2F(8, 8));
            List<Vertices> sep = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, false);
            List<Vertices> com = MarchingSquares.DetectSquares(domain, 1.0f, 1.0f, f, 0, true);

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"sep count={sep.Count}");
            foreach (Vertices v in sep)
            {
                sb.AppendLine("SEP " + v.Count + " :: " + string.Join(" | ", v));
            }
            sb.AppendLine($"com count={com.Count}");
            foreach (Vertices v in com)
            {
                sb.AppendLine("COM " + v.Count + " :: " + string.Join(" | ", v));
            }

            throw new Exception(sb.ToString());
        }
    }
}
