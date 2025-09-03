using System;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Sfml.Systems;

namespace Alis.Extension.Graphic.Sfml.Render
{
    
    /// <summary>
    /// This class defines a graphical 2D text, that can be drawn on screen
    /// </summary>
    /// <remarks>
    /// See also the note on coordinates and undistorted rendering in SFML.Graphics.Transformable.
    /// </remarks>
    
    public class Text : Transformable, Drawable
    {
        
        /// <summary>
        /// Enumerate the string drawing styles
        /// </summary>
        
        [Flags]
        public enum Styles
        {
            /// <summary>Regular characters, no style</summary>
            Regular = 0,

            /// <summary>Bold characters</summary>
            Bold = 1 << 0,

            /// <summary>Italic characters</summary>
            Italic = 1 << 1,

            /// <summary>Underlined characters</summary>
            Underlined = 1 << 2,

            /// <summary>Strike through characters</summary>
            StrikeThrough = 1 << 3
        }

        
        /// <summary>
        /// Default constructor
        /// </summary>
        
        public Text() :
            this("", null)
        {
        }

        
        /// <summary>
        /// Construct the text from a string and a font
        /// </summary>
        /// <param name="str">String to display</param>
        /// <param name="font">Font to use</param>
        
        public Text(string str, Font font) :
            this(str, font, 30)
        {
        }

        
        /// <summary>
        /// Construct the text from a string, font and size
        /// </summary>
        /// <param name="str">String to display</param>
        /// <param name="font">Font to use</param>
        /// <param name="characterSize">Base characters size</param>
        
        public Text(string str, Font font, uint characterSize) :
            base(sfText_create())
        {
            DisplayedString = str;
            Font = font;
            CharacterSize = characterSize;
        }

        
        /// <summary>
        /// Construct the text from another text
        /// </summary>
        /// <param name="copy">Text to copy</param>
        
        public Text(Text copy) :
            base(sfText_copy(copy.CPointer))
        {
            Origin = copy.Origin;
            Position = copy.Position;
            Rotation = copy.Rotation;
            Scale = copy.Scale;

            Font = copy.Font;
        }

        
        /// <summary>
        /// Fill color of the object
        /// </summary>
        /// 
        /// <remarks>
        /// Deprecated. Use <see cref="FillColor"/> instead.
        /// 
        /// By default, the text's fill color is opaque white.
        /// Setting the fill color to a transparent color with an outline
        /// will cause the outline to be displayed in the fill area of the text.
        /// </remarks>
        
        [Obsolete]
        public Color Color
        {
            get { return sfText_getFillColor(CPointer); }
            set { sfText_setFillColor(CPointer, value); }
        }

        
        /// <summary>
        /// Fill color of the object
        /// </summary>
        /// 
        /// <remarks>
        /// By default, the text's fill color is opaque white.
        /// Setting the fill color to a transparent color with an outline
        /// will cause the outline to be displayed in the fill area of the text.
        /// </remarks>
        
        public Color FillColor
        {
            get { return sfText_getFillColor(CPointer); }
            set { sfText_setFillColor(CPointer, value); }
        }

        
        /// <summary>
        /// Outline color of the object
        /// </summary>
        /// 
        /// <remarks>
        /// By default, the text's outline color is opaque black.
        /// </remarks>
        
        public Color OutlineColor
        {
            get { return sfText_getOutlineColor(CPointer); }
            set { sfText_setOutlineColor(CPointer, value); }
        }

        
        /// <summary>
        /// Thickness of the object's outline
        /// </summary>
        /// 
        /// <remarks>
        /// <para>By default, the outline thickness is 0.</para>
        /// <para>Be aware that using a negative value for the outline
        /// thickness will cause distorted rendering.</para>
        /// </remarks>
        
        public float OutlineThickness
        {
            get { return sfText_getOutlineThickness(CPointer); }
            set { sfText_setOutlineThickness(CPointer, value); }
        }

        
        /// <summary>
        /// String which is displayed
        /// </summary>
        
       public string DisplayedString
       {
           get
           {
               IntPtr source = sfText_getUnicodeString(CPointer);
       
               // Buscar la longitud (terminador 0)
               uint length = 0;
               while (Marshal.ReadInt32(source, (int)(length * 4)) != 0)
               {
                   length++;
               }
       
               // Copiar a un array de bytes
               byte[] sourceBytes = new byte[length * 4];
               Marshal.Copy(source, sourceBytes, 0, sourceBytes.Length);
       
               // Convertir a string C#
               return Encoding.UTF32.GetString(sourceBytes);
           }
       
           set
           {
               // Convertir a UTF-32 null-terminated
               byte[] utf32 = Encoding.UTF32.GetBytes(value + '\0');
       
               // Fijar el array y pasar el puntero
               GCHandle handle = GCHandle.Alloc(utf32, GCHandleType.Pinned);
               try
               {
                   sfText_setUnicodeString(CPointer, handle.AddrOfPinnedObject());
               }
               finally
               {
                   handle.Free();
               }
           }
       }

        
        /// <summary>
        /// Font used to display the text
        /// </summary>
        
        public Font Font
        {
            get { return myFont; }
            set { myFont = value; sfText_setFont(CPointer, value != null ? value.CPointer : IntPtr.Zero); }
        }

        
        /// <summary>
        /// Base size of characters
        /// </summary>
        
        public uint CharacterSize
        {
            get { return sfText_getCharacterSize(CPointer); }
            set { sfText_setCharacterSize(CPointer, value); }
        }

        
        /// <summary>
        /// Size of the letter spacing factor
        /// </summary>
        
        public float LetterSpacing
        {
            get { return sfText_getLetterSpacing(CPointer); }
            set { sfText_setLetterSpacing(CPointer, value); }
        }

        
        /// <summary>
        /// Size of the line spacing factor
        /// </summary>
        
        public float LineSpacing
        {
            get { return sfText_getLineSpacing(CPointer); }
            set { sfText_setLineSpacing(CPointer, value); }
        }

        
        /// <summary>
        /// Style of the text (see Styles enum)
        /// </summary>
        
        public Styles Style
        {
            get { return sfText_getStyle(CPointer); }
            set { sfText_setStyle(CPointer, value); }
        }

        
        /// <summary>
        /// Return the visual position of the Index-th character of the text,
        /// in coordinates relative to the text
        /// (note : translation, origin, rotation and scale are not applied)
        /// </summary>
        /// <param name="index">Index of the character</param>
        /// <returns>Position of the Index-th character (end of text if Index is out of range)</returns>
        
        public Vector2F FindCharacterPos(uint index)
        {
            return sfText_findCharacterPos(CPointer, index);
        }

        
        /// <summary>
        /// Get the local bounding rectangle of the entity.
        ///
        /// The returned rectangle is in local coordinates, which means
        /// that it ignores the transformations (translation, rotation,
        /// scale, ...) that are applied to the entity.
        /// In other words, this function returns the bounds of the
        /// entity in the entity's coordinate system.
        /// </summary>
        /// <returns>Local bounding rectangle of the entity</returns>
        
        public FloatRect GetLocalBounds()
        {
            return sfText_getLocalBounds(CPointer);
        }

        
        /// <summary>
        /// Get the global bounding rectangle of the entity.
        ///
        /// The returned rectangle is in global coordinates, which means
        /// that it takes in account the transformations (translation,
        /// rotation, scale, ...) that are applied to the entity.
        /// In other words, this function returns the bounds of the
        /// sprite in the global 2D world's coordinate system.
        /// </summary>
        /// <returns>Global bounding rectangle of the entity</returns>
        
        public FloatRect GetGlobalBounds()
        {
            // we don't use the native getGlobalBounds function,
            // because we override the object's transform
            return Transform.TransformRect(GetLocalBounds());
        }

        
        /// <summary>
        /// Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        
        public override string ToString()
        {
            return "[Text]" +
                   " FillColor(" + FillColor + ")" +
                   " OutlineColor(" + OutlineColor + ")" +
                   " String(" + DisplayedString + ")" +
                   " Font(" + Font + ")" +
                   " CharacterSize(" + CharacterSize + ")" +
                   " OutlineThickness(" + OutlineThickness + ")" +
                   " Style(" + Style + ")";
        }

        
        /// <summary>
        /// Draw the text to a render target
        /// </summary>
        /// <param name="target">Render target to draw to</param>
        /// <param name="states">Current render states</param>
        
        public void Draw(RenderTarget target, RenderStates states)
        {
            states.Transform *= Transform;
            RenderStates.MarshalData marshaledStates = states.Marshal();

            if (target is RenderWindow)
            {
                sfRenderWindow_drawText(( (RenderWindow)target ).CPointer, CPointer, ref marshaledStates);
            }
            else if (target is RenderTexture)
            {
                sfRenderTexture_drawText(( (RenderTexture)target ).CPointer, CPointer, ref marshaledStates);
            }
        }

        
        /// <summary>
        /// Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        
        public override void Destroy(bool disposing)
        {
            sfText_destroy(CPointer);
        }

        /// <summary>
        /// The my font
        /// </summary>
        private Font myFont = null;

        #region Imports
        /// <summary>
        /// Sfs the text create
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfText_create();

        /// <summary>
        /// Sfs the text copy using the specified text
        /// </summary>
        /// <param name="Text">The text</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfText_copy(IntPtr Text);

        /// <summary>
        /// Sfs the text destroy using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_destroy(IntPtr CPointer);

        /// <summary>
        /// Sfs the text set color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Color">The color</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, Obsolete]
        static extern void sfText_setColor(IntPtr CPointer, Color Color);

        /// <summary>
        /// Sfs the text set fill color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Color">The color</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setFillColor(IntPtr CPointer, Color Color);

        /// <summary>
        /// Sfs the text set outline color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Color">The color</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setOutlineColor(IntPtr CPointer, Color Color);

        /// <summary>
        /// Sfs the text set outline thickness using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="thickness">The thickness</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setOutlineThickness(IntPtr CPointer, float thickness);

        /// <summary>
        /// Sfs the text get color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity, Obsolete]
        static extern Color sfText_getColor(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get fill color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Color sfText_getFillColor(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get outline color using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The color</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Color sfText_getOutlineColor(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get outline thickness using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfText_getOutlineThickness(IntPtr CPointer);

        /// <summary>
        /// Sfs the render window draw text using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Text">The text</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderWindow_drawText(IntPtr CPointer, IntPtr Text, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the render texture draw text using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Text">The text</param>
        /// <param name="states">The states</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfRenderTexture_drawText(IntPtr CPointer, IntPtr Text, ref RenderStates.MarshalData states);

        /// <summary>
        /// Sfs the text set unicode string using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Text">The text</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setUnicodeString(IntPtr CPointer, IntPtr Text);

        /// <summary>
        /// Sfs the text set font using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Font">The font</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setFont(IntPtr CPointer, IntPtr Font);

        /// <summary>
        /// Sfs the text set character size using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Size">The size</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setCharacterSize(IntPtr CPointer, uint Size);

        /// <summary>
        /// Sfs the text set line spacing using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="spacingFactor">The spacing factor</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setLineSpacing(IntPtr CPointer, float spacingFactor);

        /// <summary>
        /// Sfs the text set letter spacing using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="spacingFactor">The spacing factor</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setLetterSpacing(IntPtr CPointer, float spacingFactor);

        /// <summary>
        /// Sfs the text set style using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Style">The style</param>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern void sfText_setStyle(IntPtr CPointer, Styles Style);

        /// <summary>
        /// Sfs the text get string using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfText_getString(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get unicode string using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern IntPtr sfText_getUnicodeString(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get character size using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern uint sfText_getCharacterSize(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get letter spacing using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfText_getLetterSpacing(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get line spacing using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern float sfText_getLineSpacing(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get style using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The styles</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Styles sfText_getStyle(IntPtr CPointer);

        /// <summary>
        /// Sfs the text get rect using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfText_getRect(IntPtr CPointer);

        /// <summary>
        /// Sfs the text find character pos using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <param name="Index">The index</param>
        /// <returns>The vector 2f</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern Vector2F sfText_findCharacterPos(IntPtr CPointer, uint Index);

        /// <summary>
        /// Sfs the text get local bounds using the specified c pointer
        /// </summary>
        /// <param name="CPointer">The pointer</param>
        /// <returns>The float rect</returns>
        [DllImport(CSFML.graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        static extern FloatRect sfText_getLocalBounds(IntPtr CPointer);
        #endregion
    }
}
