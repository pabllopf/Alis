using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.Nio;
using Javax.Microedition.Khronos.Opengles;

namespace OpenGLES_lessons_template
{
    /// <summary>
    /// This example Java source from https://github.com/learnopengles/Learn-OpenGLES-Tutorials/tree/master/android/AndroidOpenGLESLessons/app/src/main/java/com/learnopengles/android/lesson1
    /// </summary>
    class Renderer : Java.Lang.Object, GLSurfaceView.IRenderer
    {

        private FloatBuffer mTriangle1Vertices;

        //Store the model matrix. This matrix is used to move models from object space (where each model can be thought of being located at the center of the universe) to world space.
        private float[] mProjectionMatrix = new float[16];
        private float[] mViewMatrix = new float[16];

        private int mMVPMatrixHandle;

        // This will be used to pass in model position information. */
        private int mPositionHandle;

        // This will be used to pass in model color information. */
        private int mColorHandle;

        private float angleInDegrees = 0;

        // Offset of the position data. 
        private int mPositionOffset = 0;

        // Size of the position data in elements. 
        private int mPositionDataSize = 3;

        // How many bytes per float. 
        private const int mBytesPerFloat = 4;

        // How many elements per vertex. 
        private int mStrideBytes = 7 * mBytesPerFloat;

        // Offset of the color data. 
        private int mColorOffset = 3;

        // Size of the color data in elements. 
        private int mColorDataSize = 4;

        public void OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
        {
            // X, Y, Z, 
            // R, G, B, A
            float[] triangle1VerticesData = {
                -0.5f, -0.25f, 0.0f,
                1.0f, 0.0f, 0.0f, 1.0f,

                0.5f, -0.25f, 0.0f,
                0.0f, 0.0f, 1.0f, 1.0f,

                0.0f, 0.559016994f, 0.0f,
                0.0f, 1.0f, 0.0f, 1.0f};

            mTriangle1Vertices = ByteBuffer.AllocateDirect(triangle1VerticesData.Length * mBytesPerFloat).Order(ByteOrder.NativeOrder()).AsFloatBuffer();
            mTriangle1Vertices.Put(triangle1VerticesData).Position(0);

            GLES20.GlClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            // Position the eye behind the origin.
            float eyeX = 0.0f;
            float eyeY = 0.0f;
            float eyeZ = 1.5f;

            // We are looking toward the distance
            float lookX = 0.0f;
            float lookY = 0.0f;
            float lookZ = -5.0f;

            // Set our up vector. This is where our head would be pointing were we holding the camera.
            float upX = 0.0f;
            float upY = 1.0f;
            float upZ = 0.0f;

            // Set the view matrix. This matrix can be said to represent the camera position.
            // NOTE: In OpenGL 1, a ModelView matrix is used, which is a combination of a model and
            // view matrix. In OpenGL 2, we can keep track of these matrices separately if we choose.
            Matrix.SetLookAtM(mViewMatrix, 0, eyeX, eyeY, eyeZ, lookX, lookY, lookZ, upX, upY, upZ);

            string vertexShader =
                    "uniform mat4 u_MVPMatrix;      \n"     // A constant representing the combined model/view/projection matrix.
                  + "attribute vec4 a_Position;     \n"     // Per-vertex position information we will pass in.
                  + "attribute vec4 a_Color;        \n"     // Per-vertex color information we will pass in.			  
                  + "varying vec4 v_Color;          \n"     // This will be passed into the fragment shader.
                  + "void main()                    \n"     // The entry point for our vertex shader.
                  + "{                              \n"
                  + "   v_Color = a_Color;          \n"     // Pass the color through to the fragment shader. It will be interpolated across the triangle.                                                            
                  + "   gl_Position = u_MVPMatrix   \n"     // gl_Position is a special variable used to store the final position.
                  + "                 * a_Position; \n"     // Multiply the vertex by the matrix to get the final point in normalized screen coordinates.			                                            			 
                  + "}                              \n";

            string fragmentShader =
                "precision mediump float;       \n"     // Set the default precision to medium. We don't need as high of a 
                                                        // precision in the fragment shader.				
              + "varying vec4 v_Color;          \n"     // This is the color from the vertex shader interpolated across the triangle per fragment.			  
              + "void main()                    \n"     // The entry point for our fragment shader.
              + "{                              \n"
              + "   gl_FragColor = v_Color;     \n"     // Pass the color directly through the pipeline.		  
              + "}                              \n";

            int vertexShaderHandle = GLES20.GlCreateShader(GLES20.GlVertexShader);

            if (vertexShaderHandle != 0)
            {
                // Pass in the shader source.
                GLES20.GlShaderSource(vertexShaderHandle, vertexShader);

                // Compile the shader.
                GLES20.GlCompileShader(vertexShaderHandle);

                // Get the compilation status.
                int[] compileStatus = new int[1];
                GLES20.GlGetShaderiv(vertexShaderHandle, GLES20.GlCompileStatus, compileStatus, 0);

                // If the compilation failed, delete the shader.
                if (compileStatus[0] == 0)
                {
                    GLES20.GlDeleteShader(vertexShaderHandle);
                    vertexShaderHandle = 0;
                }
            }

            if (vertexShaderHandle == 0)
            {
                throw new Exception("Error creating vertex shader.");
            }

            // Load in the fragment shader shader.
            int fragmentShaderHandle = GLES20.GlCreateShader(GLES20.GlFragmentShader);

            if (fragmentShaderHandle != 0)
            {
                // Pass in the shader source.
                GLES20.GlShaderSource(fragmentShaderHandle, fragmentShader);

                // Compile the shader.
                GLES20.GlCompileShader(fragmentShaderHandle);

                // Get the compilation status.
                int[] compileStatus = new int[1];
                GLES20.GlGetShaderiv(fragmentShaderHandle, GLES20.GlCompileStatus, compileStatus, 0);

                // If the compilation failed, delete the shader.
                if (compileStatus[0] == 0)
                {
                    GLES20.GlDeleteShader(fragmentShaderHandle);
                    fragmentShaderHandle = 0;
                }
            }

            if (fragmentShaderHandle == 0)
            {
                throw new Exception("Error creating fragment shader.");
            }

            // Create a program object and store the handle to it.
            int programHandle = GLES20.GlCreateProgram();

            if (programHandle != 0)
            {
                // Bind the vertex shader to the program.
                GLES20.GlAttachShader(programHandle, vertexShaderHandle);

                // Bind the fragment shader to the program.
                GLES20.GlAttachShader(programHandle, fragmentShaderHandle);

                // Bind attributes
                GLES20.GlBindAttribLocation(programHandle, 0, "a_Position");
                GLES20.GlBindAttribLocation(programHandle, 1, "a_Color");

                // Link the two shaders together into a program.
                GLES20.GlLinkProgram(programHandle);

                // Get the link status.
                int[] linkStatus = new int[1];
                GLES20.GlGetProgramiv(programHandle, GLES20.GlLinkStatus, linkStatus, 0);

                // If the link failed, delete the program.
                if (linkStatus[0] == 0)
                {
                    GLES20.GlDeleteProgram(programHandle);
                    programHandle = 0;
                }
            }

            if (programHandle == 0)
            {
                throw new Exception("Error creating program.");
            }

            // Set program handles. These will later be used to pass in values to the program.
            mMVPMatrixHandle = GLES20.GlGetUniformLocation(programHandle, "u_MVPMatrix");
            mPositionHandle = GLES20.GlGetAttribLocation(programHandle, "a_Position");
            mColorHandle = GLES20.GlGetAttribLocation(programHandle, "a_Color");

            // Tell OpenGL to use this program when rendering.
            GLES20.GlUseProgram(programHandle);


        }

        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            GLES20.GlViewport(0, 0, width, height);
            float ratio = (float)width / height;
            float left = -ratio;
            float right = ratio;
            float top = 1.0f;
            float bottom = -1.0f;
            float near = 1.0f;
            float far = 10.0f;
            Matrix.FrustumM(mProjectionMatrix, 0, left, right, bottom, top, near, far);
        }

        public void OnDrawFrame(IGL10 gl)
        {

            GLES20.GlClear(GLES20.GlColorBufferBit | GLES20.GlDepthBufferBit);

            // Draw the triangle facing straight on.
            angleInDegrees += 1.0f;
            float[] mModelMatrix = new float[16];
            Matrix.SetIdentityM(mModelMatrix, 0);
            Matrix.RotateM(mModelMatrix, 0, angleInDegrees, 0.0f, 0.0f, 1.0f);
            

            // Pass in the position information
            mTriangle1Vertices.Position(mPositionOffset);
            GLES20.GlVertexAttribPointer(mPositionHandle, mPositionDataSize, GLES20.GlFloat, false, mStrideBytes, mTriangle1Vertices);
            GLES20.GlEnableVertexAttribArray(mPositionHandle);

            // Pass in the color information
            mTriangle1Vertices.Position(mColorOffset);
            GLES20.GlVertexAttribPointer(mColorHandle, mColorDataSize, GLES20.GlFloat, false, mStrideBytes, mTriangle1Vertices);
            GLES20.GlEnableVertexAttribArray(mColorHandle);

            // This multiplies the view matrix by the model matrix, and stores the result in the MVP matrix
            // (which currently contains model * view).            
            // Allocate storage for the final combined matrix. This will be passed into the shader program. */
            float[] mMVPMatrix = new float[16];
            Matrix.MultiplyMM(mMVPMatrix, 0, mViewMatrix, 0, mModelMatrix, 0);

            // This multiplies the modelview matrix by the projection matrix, and stores the result in the MVP matrix
            // (which now contains model * view * projection).
            // THIS IS NOT WORK AT C# Matrix class -> Matrix.MultiplyMM(mMVPMatrix, 0, mProjectionMatrix, 0, mMVPMatrix, 0);
            float[] _mMVPMatrix = new float[16];
            Matrix.MultiplyMM(_mMVPMatrix, 0, mProjectionMatrix, 0, mMVPMatrix, 0);

            GLES20.GlUniformMatrix4fv(mMVPMatrixHandle, 1, false, _mMVPMatrix, 0);
            GLES20.GlDrawArrays(GLES20.GlTriangles, 0, 3);
        }
    }
}