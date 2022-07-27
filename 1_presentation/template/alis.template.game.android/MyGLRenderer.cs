using Android.Opengl;

namespace Alis.Template.Game.Android
{
	/// <summary>
	/// The my gl renderer class
	/// </summary>
	/// <seealso cref="Java.Lang.Object"/>
	/// <seealso cref="GLSurfaceView.IRenderer"/>
	class MyGLRenderer : Java.Lang.Object, GLSurfaceView.IRenderer
	{
		/// <summary>
		/// The tag
		/// </summary>
		private static string TAG = "MyGLRenderer";
		/// <summary>
		/// The proj matrix
		/// </summary>
		private float[] mProjMatrix = new float[16];

		
		/// <summary>
		/// The blue
		/// </summary>
		float red, green, blue;
		
		/// <summary>
		/// Ons the draw frame using the specified gl
		/// </summary>
		/// <param name="gl">The gl</param>
		public void OnDrawFrame (Javax.Microedition.Khronos.Opengles.IGL10 gl)
		{
			GLES30.GlClearColor(red, green, blue, 1.0f);
			GLES30.GlClear ((int)GLES30.GlColorBufferBit);
			
			red += 0.01f;
			if (red >= 1.0f)
				red -= 1.0f;
			green += 0.02f;
			if (green >= 1.0f)
				green -= 1.0f;
			blue += 0.03f;
			if (blue >= 1.0f)
				blue -= 1.0f;
			
		}

		/// <summary>
		/// Ons the surface changed using the specified gl
		/// </summary>
		/// <param name="gl">The gl</param>
		/// <param name="width">The width</param>
		/// <param name="height">The height</param>
		public void OnSurfaceChanged (Javax.Microedition.Khronos.Opengles.IGL10 gl, int width, int height)
		{
			// Adjust the viewport based on geometry changes,
			// such as screen rotation
			GLES30.GlViewport (0, 0, width, height);

			float ratio = (float)width / height;

			// this projection matrix is applied to object coordinates
			// in the onDrawFrame() method
			Matrix.FrustumM (mProjMatrix, 0, -ratio, ratio, -1, 1, 3, 7);
		}

		/// <summary>
		/// Ons the surface created using the specified gl
		/// </summary>
		/// <param name="gl">The gl</param>
		/// <param name="config">The config</param>
		public void OnSurfaceCreated (Javax.Microedition.Khronos.Opengles.IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
		{
			//GLES30.GlClearColor (0.0f, 0.0f, 0.0f, 1.0f);
		}
	}
}

