namespace Alis.Core.Graphic.Stb.Hebron.Runtime
{
	/// <summary>
	/// The utility class
	/// </summary>
	internal class Utility
	{
		/// <summary>
		/// Creates the array using the specified d 1
		/// </summary>
		/// <typeparam name="T">The </typeparam>
		/// <param name="d1">The </param>
		/// <param name="d2">The </param>
		/// <returns>The result</returns>
		public static T[][] CreateArray<T>(int d1, int d2)
		{
			T[][] result = new T[d1][];
			for (int i = 0; i < d1; i++)
			{
				result[i] = new T[d2];
			}

			return result;
		}
	}
}
