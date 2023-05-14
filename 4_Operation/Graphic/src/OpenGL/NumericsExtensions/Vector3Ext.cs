using System.Numerics;

namespace Alis.Core.Graphic.OpenGL.NumericsExtensions
{
	/// <summary>
	/// The vector ext class
	/// </summary>
	public static class Vector3Ext
	{
		/// <summary>
		/// Store the minimum values of x, y, and z between the two vectors.
		/// </summary>
		/// <param name="tv">The Vector3 to perform the TakeMin on.</param>
		/// <param name="v">Vector to check against.</param>
		public static void TakeMin(this Vector3 tv, Vector3 v)
		{
			if (v.X < tv.X) tv.X = v.X;
			if (v.Y < tv.Y) tv.Y = v.Y;
			if (v.Z < tv.Z) tv.Z = v.Z;
		}

		/// <summary>
		/// Store the maximum values of x, y, and z between the two vectors.
		/// </summary>
		/// <param name="tv">The Vector3 to perform the TakeMax on.</param>
		/// <param name="v">Vector to check against.</param>
		public static void TakeMax(this Vector3 tv, Vector3 v)
		{
			if (v.X > tv.X) tv.X = v.X;
			if (v.Y > tv.Y) tv.Y = v.Y;
			if (v.Z > tv.Z) tv.Z = v.Z;
		}

		/// <summary>
		/// Normalizes the Vector3 structure to have a peak value of one.
		/// </summary>
		/// <param name="v">The Vector3 to perform the Normalize on.</param>
		/// <returns>if (Length = 0) return Zero; else return Vector3(x,y,z)/Length.</returns>
		public static Vector3 Normalize(this Vector3 v)
		{
			if (v.Length() == 0) return Vector3.Zero;
			else return new Vector3(v.X, v.Y, v.Z) / v.Length();
		}

		/// <summary>
		/// Performs the Vector3 scalar dot product.
		/// </summary>
		/// <param name="tv">The Vector3 to perform the dot product on.</param>
		/// <param name="v">Second dot product term.</param>
		/// <returns>Vector3.Dot(this, v).</returns>
		public static float Dot(this Vector3 tv, Vector3 v)
		{
			return Vector3.Dot(tv, v);
		}

		/// <summary>
		/// Provide an accessor for each of the elements of the Vector structure.
		/// </summary>
		/// <param name="v">The Vector3 to access.</param>
		/// <param name="index">The element to access (0 = X, 1 = Y, 2 = Z).</param>
		/// <returns>The element of the Vector3 as indexed by i.</returns>
		public static float Get(this Vector3 v, int index)
		{
			return index == 0 ? v.X : index == 1 ? v.Y : v.Z;
		}
	}
}
