using System.Numerics;

namespace Alis.Core.Graphic.OpenGL.NumericsExtensions
{
	/// <summary>
	/// The vector ext class
	/// </summary>
	public static class Vector4Ext
	{
		/// <summary>
		/// Gets the v
		/// </summary>
		/// <param name="v">The </param>
		/// <param name="index">The index</param>
		/// <returns>The float</returns>
		public static float Get(this Vector4 v, int index)
		{
			switch (index)
			{
				case 0: return v.X;
				case 1: return v.Y;
				case 2: return v.Z;
				case 3: return v.W;
				default: return 0;  // error case
			}
		}
	}
}
