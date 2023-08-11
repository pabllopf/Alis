using System;
using System.Collections.Generic;
using System.Text;

namespace Veldrid.Sdl2
{

    /// <summary>
    /// The SDL keyboard scancode representation.
    /// Values of this type are used to represent keyboard keys, among other places
    /// in the SDL_Keysym::scancode key.keysym.scancode field of the
    /// SDL_Event structure.
    /// The values in this enumeration are based on the USB usage page standard:
    /// http://www.usb.org/developers/devclass_docs/Hut1_12v2.pdf
    /// </summary>
    public enum SDL_Scancode
    {
        /// <summary>
        /// The sdl scancode unknown sdl scancode
        /// </summary>
        SDL_SCANCODE_UNKNOWN = 0,

        /*
         * These values are from usage page 0x07 (USB keyboard page).
         */
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_A = 4,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_B = 5,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_C = 6,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_D = 7,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_E = 8,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_F = 9,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_G = 10,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_H = 11,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_I = 12,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_J = 13,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_K = 14,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_L = 15,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_M = 16,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_N = 17,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_O = 18,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_P = 19,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_Q = 20,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_R = 21,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_S = 22,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_T = 23,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_U = 24,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_V = 25,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_W = 26,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_X = 27,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_Y = 28,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_Z = 29,

        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_1 = 30,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_2 = 31,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_3 = 32,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_4 = 33,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_5 = 34,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_6 = 35,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_7 = 36,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_8 = 37,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_9 = 38,
        /// <summary>
        /// The sdl scancode sdl scancode
        /// </summary>
        SDL_SCANCODE_0 = 39,

        /// <summary>
        /// The sdl scancode return sdl scancode
        /// </summary>
        SDL_SCANCODE_RETURN = 40,
        /// <summary>
        /// The sdl scancode escape sdl scancode
        /// </summary>
        SDL_SCANCODE_ESCAPE = 41,
        /// <summary>
        /// The sdl scancode backspace sdl scancode
        /// </summary>
        SDL_SCANCODE_BACKSPACE = 42,
        /// <summary>
        /// The sdl scancode tab sdl scancode
        /// </summary>
        SDL_SCANCODE_TAB = 43,
        /// <summary>
        /// The sdl scancode space sdl scancode
        /// </summary>
        SDL_SCANCODE_SPACE = 44,

        /// <summary>
        /// The sdl scancode minus sdl scancode
        /// </summary>
        SDL_SCANCODE_MINUS = 45,
        /// <summary>
        /// The sdl scancode equals sdl scancode
        /// </summary>
        SDL_SCANCODE_EQUALS = 46,
        /// <summary>
        /// The sdl scancode leftbracket sdl scancode
        /// </summary>
        SDL_SCANCODE_LEFTBRACKET = 47,
        /// <summary>
        /// The sdl scancode rightbracket sdl scancode
        /// </summary>
        SDL_SCANCODE_RIGHTBRACKET = 48,
        /// <summary>
        /// Located at the lower left of the return key on ISO keyboards and at the right end of the QWERTY row on
        /// ANSI keyboards. Produces REVERSE SOLIDUS (backslash) and VERTICAL LINE in a US layout, REVERSE
        /// SOLIDUS and VERTICAL LINE in a UK Mac layout, NUMBER SIGN and TILDE in a UK Windows layout, DOLLAR SIGN
        /// and POUND SIGN in a Swiss German layout, NUMBER SIGN and APOSTROPHE in a German layout, GRAVE ACCENT and
        /// POUND SIGN in a French Mac layout, and ASTERISK and MICRO SIGN in a French Windows layout.
        /// </summary>
        SDL_SCANCODE_BACKSLASH = 49, 
        /// <summary>
        /// The sdl scancode nonushash sdl scancode
        /// </summary>
        SDL_SCANCODE_NONUSHASH = 50, /* ISO USB keyboards actually use this code
                                  *   instead of 49 for the same key, but all
                                  *   OSes I've seen treat the two codes
                                  *   identically. So, as an implementor, unless
                                  *   your keyboard generates both of those
                                  *   codes and your OS treats them differently,
                                  *   you should generate SDL_SCANCODE_BACKSLASH
                                  *   instead of this code. As a user, you
                                  *   should not rely on this code because SDL
                                  *   will never generate it with most (all?)
                                  *   keyboards.
                                  */
        /// <summary>
        /// The sdl scancode semicolon sdl scancode
        /// </summary>
        SDL_SCANCODE_SEMICOLON = 51,
        /// <summary>
        /// The sdl scancode apostrophe sdl scancode
        /// </summary>
        SDL_SCANCODE_APOSTROPHE = 52,
        /// <summary>
        /// The sdl scancode grave sdl scancode
        /// </summary>
        SDL_SCANCODE_GRAVE = 53, /* Located in the top left corner (on both ANSI
                              *   and ISO keyboards). Produces GRAVE ACCENT and
                              *   TILDE in a US Windows layout and in US and UK
                              *   Mac layouts on ANSI keyboards, GRAVE ACCENT
                              *   and NOT SIGN in a UK Windows layout, SECTION
                              *   SIGN and PLUS-MINUS SIGN in US and UK Mac
                              *   layouts on ISO keyboards, SECTION SIGN and
                              *   DEGREE SIGN in a Swiss German layout (Mac:
                              *   only on ISO keyboards), CIRCUMFLEX ACCENT and
                              *   DEGREE SIGN in a German layout (Mac: only on
                              *   ISO keyboards), SUPERSCRIPT TWO and TILDE in a
                              *   French Windows layout, COMMERCIAL AT and
                              *   NUMBER SIGN in a French Mac layout on ISO
                              *   keyboards, and LESS-THAN SIGN and GREATER-THAN
                              *   SIGN in a Swiss German, German, or French Mac
                              *   layout on ANSI keyboards.
                              */
        /// <summary>
        /// The sdl scancode comma sdl scancode
        /// </summary>
        SDL_SCANCODE_COMMA = 54,
        /// <summary>
        /// The sdl scancode period sdl scancode
        /// </summary>
        SDL_SCANCODE_PERIOD = 55,
        /// <summary>
        /// The sdl scancode slash sdl scancode
        /// </summary>
        SDL_SCANCODE_SLASH = 56,

        /// <summary>
        /// The sdl scancode capslock sdl scancode
        /// </summary>
        SDL_SCANCODE_CAPSLOCK = 57,

        /// <summary>
        /// The sdl scancode f1 sdl scancode
        /// </summary>
        SDL_SCANCODE_F1 = 58,
        /// <summary>
        /// The sdl scancode f2 sdl scancode
        /// </summary>
        SDL_SCANCODE_F2 = 59,
        /// <summary>
        /// The sdl scancode f3 sdl scancode
        /// </summary>
        SDL_SCANCODE_F3 = 60,
        /// <summary>
        /// The sdl scancode f4 sdl scancode
        /// </summary>
        SDL_SCANCODE_F4 = 61,
        /// <summary>
        /// The sdl scancode f5 sdl scancode
        /// </summary>
        SDL_SCANCODE_F5 = 62,
        /// <summary>
        /// The sdl scancode f6 sdl scancode
        /// </summary>
        SDL_SCANCODE_F6 = 63,
        /// <summary>
        /// The sdl scancode f7 sdl scancode
        /// </summary>
        SDL_SCANCODE_F7 = 64,
        /// <summary>
        /// The sdl scancode f8 sdl scancode
        /// </summary>
        SDL_SCANCODE_F8 = 65,
        /// <summary>
        /// The sdl scancode f9 sdl scancode
        /// </summary>
        SDL_SCANCODE_F9 = 66,
        /// <summary>
        /// The sdl scancode f10 sdl scancode
        /// </summary>
        SDL_SCANCODE_F10 = 67,
        /// <summary>
        /// The sdl scancode f11 sdl scancode
        /// </summary>
        SDL_SCANCODE_F11 = 68,
        /// <summary>
        /// The sdl scancode f12 sdl scancode
        /// </summary>
        SDL_SCANCODE_F12 = 69,

        /// <summary>
        /// The sdl scancode printscreen sdl scancode
        /// </summary>
        SDL_SCANCODE_PRINTSCREEN = 70,
        /// <summary>
        /// The sdl scancode scrolllock sdl scancode
        /// </summary>
        SDL_SCANCODE_SCROLLLOCK = 71,
        /// <summary>
        /// The sdl scancode pause sdl scancode
        /// </summary>
        SDL_SCANCODE_PAUSE = 72,
        /// <summary>
        /// The sdl scancode insert sdl scancode
        /// </summary>
        SDL_SCANCODE_INSERT = 73, /* insert on PC, help on some Mac keyboards (but
                                   does send code 73, not 117) */
        /// <summary>
        /// The sdl scancode home sdl scancode
        /// </summary>
        SDL_SCANCODE_HOME = 74,
        /// <summary>
        /// The sdl scancode pageup sdl scancode
        /// </summary>
        SDL_SCANCODE_PAGEUP = 75,
        /// <summary>
        /// The sdl scancode delete sdl scancode
        /// </summary>
        SDL_SCANCODE_DELETE = 76,
        /// <summary>
        /// The sdl scancode end sdl scancode
        /// </summary>
        SDL_SCANCODE_END = 77,
        /// <summary>
        /// The sdl scancode pagedown sdl scancode
        /// </summary>
        SDL_SCANCODE_PAGEDOWN = 78,
        /// <summary>
        /// The sdl scancode right sdl scancode
        /// </summary>
        SDL_SCANCODE_RIGHT = 79,
        /// <summary>
        /// The sdl scancode left sdl scancode
        /// </summary>
        SDL_SCANCODE_LEFT = 80,
        /// <summary>
        /// The sdl scancode down sdl scancode
        /// </summary>
        SDL_SCANCODE_DOWN = 81,
        /// <summary>
        /// The sdl scancode up sdl scancode
        /// </summary>
        SDL_SCANCODE_UP = 82,

        /// <summary>
        /// The sdl scancode numlockclear sdl scancode
        /// </summary>
        SDL_SCANCODE_NUMLOCKCLEAR = 83, /* num lock on PC, clear on Mac keyboards
                                     */
        /// <summary>
        /// The sdl scancode kp divide sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_DIVIDE = 84,
        /// <summary>
        /// The sdl scancode kp multiply sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MULTIPLY = 85,
        /// <summary>
        /// The sdl scancode kp minus sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MINUS = 86,
        /// <summary>
        /// The sdl scancode kp plus sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_PLUS = 87,
        /// <summary>
        /// The sdl scancode kp enter sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_ENTER = 88,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_1 = 89,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_2 = 90,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_3 = 91,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_4 = 92,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_5 = 93,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_6 = 94,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_7 = 95,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_8 = 96,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_9 = 97,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_0 = 98,
        /// <summary>
        /// The sdl scancode kp period sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_PERIOD = 99,

        /// <summary>
        /// The sdl scancode nonusbackslash sdl scancode
        /// </summary>
        SDL_SCANCODE_NONUSBACKSLASH = 100, /* This is the additional key that ISO
                                        *   keyboards have over ANSI ones,
                                        *   located between left shift and Y.
                                        *   Produces GRAVE ACCENT and TILDE in a
                                        *   US or UK Mac layout, REVERSE SOLIDUS
                                        *   (backslash) and VERTICAL LINE in a
                                        *   US or UK Windows layout, and
                                        *   LESS-THAN SIGN and GREATER-THAN SIGN
                                        *   in a Swiss German, German, or French
                                        *   layout. */
        /// <summary>
        /// The sdl scancode application sdl scancode
        /// </summary>
        SDL_SCANCODE_APPLICATION = 101, /* windows contextual menu, compose */
        /// <summary>
        /// The sdl scancode power sdl scancode
        /// </summary>
        SDL_SCANCODE_POWER = 102, /* The USB document says this is a status flag,
                               *   not a physical key - but some Mac keyboards
                               *   do have a power key. */
        /// <summary>
        /// The sdl scancode kp equals sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_EQUALS = 103,
        /// <summary>
        /// The sdl scancode f13 sdl scancode
        /// </summary>
        SDL_SCANCODE_F13 = 104,
        /// <summary>
        /// The sdl scancode f14 sdl scancode
        /// </summary>
        SDL_SCANCODE_F14 = 105,
        /// <summary>
        /// The sdl scancode f15 sdl scancode
        /// </summary>
        SDL_SCANCODE_F15 = 106,
        /// <summary>
        /// The sdl scancode f16 sdl scancode
        /// </summary>
        SDL_SCANCODE_F16 = 107,
        /// <summary>
        /// The sdl scancode f17 sdl scancode
        /// </summary>
        SDL_SCANCODE_F17 = 108,
        /// <summary>
        /// The sdl scancode f18 sdl scancode
        /// </summary>
        SDL_SCANCODE_F18 = 109,
        /// <summary>
        /// The sdl scancode f19 sdl scancode
        /// </summary>
        SDL_SCANCODE_F19 = 110,
        /// <summary>
        /// The sdl scancode f20 sdl scancode
        /// </summary>
        SDL_SCANCODE_F20 = 111,
        /// <summary>
        /// The sdl scancode f21 sdl scancode
        /// </summary>
        SDL_SCANCODE_F21 = 112,
        /// <summary>
        /// The sdl scancode f22 sdl scancode
        /// </summary>
        SDL_SCANCODE_F22 = 113,
        /// <summary>
        /// The sdl scancode f23 sdl scancode
        /// </summary>
        SDL_SCANCODE_F23 = 114,
        /// <summary>
        /// The sdl scancode f24 sdl scancode
        /// </summary>
        SDL_SCANCODE_F24 = 115,
        /// <summary>
        /// The sdl scancode execute sdl scancode
        /// </summary>
        SDL_SCANCODE_EXECUTE = 116,
        /// <summary>
        /// The sdl scancode help sdl scancode
        /// </summary>
        SDL_SCANCODE_HELP = 117,
        /// <summary>
        /// The sdl scancode menu sdl scancode
        /// </summary>
        SDL_SCANCODE_MENU = 118,
        /// <summary>
        /// The sdl scancode select sdl scancode
        /// </summary>
        SDL_SCANCODE_SELECT = 119,
        /// <summary>
        /// The sdl scancode stop sdl scancode
        /// </summary>
        SDL_SCANCODE_STOP = 120,
        /// <summary>
        /// The sdl scancode again sdl scancode
        /// </summary>
        SDL_SCANCODE_AGAIN = 121,   /* redo */
        /// <summary>
        /// The sdl scancode undo sdl scancode
        /// </summary>
        SDL_SCANCODE_UNDO = 122,
        /// <summary>
        /// The sdl scancode cut sdl scancode
        /// </summary>
        SDL_SCANCODE_CUT = 123,
        /// <summary>
        /// The sdl scancode copy sdl scancode
        /// </summary>
        SDL_SCANCODE_COPY = 124,
        /// <summary>
        /// The sdl scancode paste sdl scancode
        /// </summary>
        SDL_SCANCODE_PASTE = 125,
        /// <summary>
        /// The sdl scancode find sdl scancode
        /// </summary>
        SDL_SCANCODE_FIND = 126,
        /// <summary>
        /// The sdl scancode mute sdl scancode
        /// </summary>
        SDL_SCANCODE_MUTE = 127,
        /// <summary>
        /// The sdl scancode volumeup sdl scancode
        /// </summary>
        SDL_SCANCODE_VOLUMEUP = 128,
        /// <summary>
        /// The sdl scancode volumedown sdl scancode
        /// </summary>
        SDL_SCANCODE_VOLUMEDOWN = 129,
        /* not sure whether there's a reason to enable these */
        /*     SDL_SCANCODE_LOCKINGCAPSLOCK = 130,  */
        /*     SDL_SCANCODE_LOCKINGNUMLOCK = 131, */
        /*     SDL_SCANCODE_LOCKINGSCROLLLOCK = 132, */
        /// <summary>
        /// The sdl scancode kp comma sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_COMMA = 133,
        /// <summary>
        /// The sdl scancode kp equalsas400 sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_EQUALSAS400 = 134,

        /// <summary>
        /// The sdl scancode international1 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL1 = 135, /* used on Asian keyboards, see
                                            footnotes in USB doc */
        /// <summary>
        /// The sdl scancode international2 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL2 = 136,
        /// <summary>
        /// The sdl scancode international3 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL3 = 137, /* Yen */
        /// <summary>
        /// The sdl scancode international4 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL4 = 138,
        /// <summary>
        /// The sdl scancode international5 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL5 = 139,
        /// <summary>
        /// The sdl scancode international6 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL6 = 140,
        /// <summary>
        /// The sdl scancode international7 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL7 = 141,
        /// <summary>
        /// The sdl scancode international8 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL8 = 142,
        /// <summary>
        /// The sdl scancode international9 sdl scancode
        /// </summary>
        SDL_SCANCODE_INTERNATIONAL9 = 143,
        /// <summary>
        /// The sdl scancode lang1 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG1 = 144, /* Hangul/English toggle */
        /// <summary>
        /// The sdl scancode lang2 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG2 = 145, /* Hanja conversion */
        /// <summary>
        /// The sdl scancode lang3 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG3 = 146, /* Katakana */
        /// <summary>
        /// The sdl scancode lang4 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG4 = 147, /* Hiragana */
        /// <summary>
        /// The sdl scancode lang5 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG5 = 148, /* Zenkaku/Hankaku */
        /// <summary>
        /// The sdl scancode lang6 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG6 = 149, /* reserved */
        /// <summary>
        /// The sdl scancode lang7 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG7 = 150, /* reserved */
        /// <summary>
        /// The sdl scancode lang8 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG8 = 151, /* reserved */
        /// <summary>
        /// The sdl scancode lang9 sdl scancode
        /// </summary>
        SDL_SCANCODE_LANG9 = 152, /* reserved */

        /// <summary>
        /// The sdl scancode alterase sdl scancode
        /// </summary>
        SDL_SCANCODE_ALTERASE = 153, /* Erase-Eaze */
        /// <summary>
        /// The sdl scancode sysreq sdl scancode
        /// </summary>
        SDL_SCANCODE_SYSREQ = 154,
        /// <summary>
        /// The sdl scancode cancel sdl scancode
        /// </summary>
        SDL_SCANCODE_CANCEL = 155,
        /// <summary>
        /// The sdl scancode clear sdl scancode
        /// </summary>
        SDL_SCANCODE_CLEAR = 156,
        /// <summary>
        /// The sdl scancode prior sdl scancode
        /// </summary>
        SDL_SCANCODE_PRIOR = 157,
        /// <summary>
        /// The sdl scancode return2 sdl scancode
        /// </summary>
        SDL_SCANCODE_RETURN2 = 158,
        /// <summary>
        /// The sdl scancode separator sdl scancode
        /// </summary>
        SDL_SCANCODE_SEPARATOR = 159,
        /// <summary>
        /// The sdl scancode out sdl scancode
        /// </summary>
        SDL_SCANCODE_OUT = 160,
        /// <summary>
        /// The sdl scancode oper sdl scancode
        /// </summary>
        SDL_SCANCODE_OPER = 161,
        /// <summary>
        /// The sdl scancode clearagain sdl scancode
        /// </summary>
        SDL_SCANCODE_CLEARAGAIN = 162,
        /// <summary>
        /// The sdl scancode crsel sdl scancode
        /// </summary>
        SDL_SCANCODE_CRSEL = 163,
        /// <summary>
        /// The sdl scancode exsel sdl scancode
        /// </summary>
        SDL_SCANCODE_EXSEL = 164,

        /// <summary>
        /// The sdl scancode kp 00 sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_00 = 176,
        /// <summary>
        /// The sdl scancode kp 000 sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_000 = 177,
        /// <summary>
        /// The sdl scancode thousandsseparator sdl scancode
        /// </summary>
        SDL_SCANCODE_THOUSANDSSEPARATOR = 178,
        /// <summary>
        /// The sdl scancode decimalseparator sdl scancode
        /// </summary>
        SDL_SCANCODE_DECIMALSEPARATOR = 179,
        /// <summary>
        /// The sdl scancode currencyunit sdl scancode
        /// </summary>
        SDL_SCANCODE_CURRENCYUNIT = 180,
        /// <summary>
        /// The sdl scancode currencysubunit sdl scancode
        /// </summary>
        SDL_SCANCODE_CURRENCYSUBUNIT = 181,
        /// <summary>
        /// The sdl scancode kp leftparen sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_LEFTPAREN = 182,
        /// <summary>
        /// The sdl scancode kp rightparen sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_RIGHTPAREN = 183,
        /// <summary>
        /// The sdl scancode kp leftbrace sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_LEFTBRACE = 184,
        /// <summary>
        /// The sdl scancode kp rightbrace sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_RIGHTBRACE = 185,
        /// <summary>
        /// The sdl scancode kp tab sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_TAB = 186,
        /// <summary>
        /// The sdl scancode kp backspace sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_BACKSPACE = 187,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_A = 188,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_B = 189,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_C = 190,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_D = 191,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_E = 192,
        /// <summary>
        /// The sdl scancode kp sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_F = 193,
        /// <summary>
        /// The sdl scancode kp xor sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_XOR = 194,
        /// <summary>
        /// The sdl scancode kp power sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_POWER = 195,
        /// <summary>
        /// The sdl scancode kp percent sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_PERCENT = 196,
        /// <summary>
        /// The sdl scancode kp less sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_LESS = 197,
        /// <summary>
        /// The sdl scancode kp greater sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_GREATER = 198,
        /// <summary>
        /// The sdl scancode kp ampersand sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_AMPERSAND = 199,
        /// <summary>
        /// The sdl scancode kp dblampersand sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_DBLAMPERSAND = 200,
        /// <summary>
        /// The sdl scancode kp verticalbar sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_VERTICALBAR = 201,
        /// <summary>
        /// The sdl scancode kp dblverticalbar sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_DBLVERTICALBAR = 202,
        /// <summary>
        /// The sdl scancode kp colon sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_COLON = 203,
        /// <summary>
        /// The sdl scancode kp hash sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_HASH = 204,
        /// <summary>
        /// The sdl scancode kp space sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_SPACE = 205,
        /// <summary>
        /// The sdl scancode kp at sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_AT = 206,
        /// <summary>
        /// The sdl scancode kp exclam sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_EXCLAM = 207,
        /// <summary>
        /// The sdl scancode kp memstore sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMSTORE = 208,
        /// <summary>
        /// The sdl scancode kp memrecall sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMRECALL = 209,
        /// <summary>
        /// The sdl scancode kp memclear sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMCLEAR = 210,
        /// <summary>
        /// The sdl scancode kp memadd sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMADD = 211,
        /// <summary>
        /// The sdl scancode kp memsubtract sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMSUBTRACT = 212,
        /// <summary>
        /// The sdl scancode kp memmultiply sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMMULTIPLY = 213,
        /// <summary>
        /// The sdl scancode kp memdivide sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_MEMDIVIDE = 214,
        /// <summary>
        /// The sdl scancode kp plusminus sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_PLUSMINUS = 215,
        /// <summary>
        /// The sdl scancode kp clear sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_CLEAR = 216,
        /// <summary>
        /// The sdl scancode kp clearentry sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_CLEARENTRY = 217,
        /// <summary>
        /// The sdl scancode kp binary sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_BINARY = 218,
        /// <summary>
        /// The sdl scancode kp octal sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_OCTAL = 219,
        /// <summary>
        /// The sdl scancode kp decimal sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_DECIMAL = 220,
        /// <summary>
        /// The sdl scancode kp hexadecimal sdl scancode
        /// </summary>
        SDL_SCANCODE_KP_HEXADECIMAL = 221,

        /// <summary>
        /// The sdl scancode lctrl sdl scancode
        /// </summary>
        SDL_SCANCODE_LCTRL = 224,
        /// <summary>
        /// The sdl scancode lshift sdl scancode
        /// </summary>
        SDL_SCANCODE_LSHIFT = 225,
        /// <summary>
        /// The sdl scancode lalt sdl scancode
        /// </summary>
        SDL_SCANCODE_LALT = 226, /* alt, option */
        /// <summary>
        /// The sdl scancode lgui sdl scancode
        /// </summary>
        SDL_SCANCODE_LGUI = 227, /* windows, command (apple), meta */
        /// <summary>
        /// The sdl scancode rctrl sdl scancode
        /// </summary>
        SDL_SCANCODE_RCTRL = 228,
        /// <summary>
        /// The sdl scancode rshift sdl scancode
        /// </summary>
        SDL_SCANCODE_RSHIFT = 229,
        /// <summary>
        /// The sdl scancode ralt sdl scancode
        /// </summary>
        SDL_SCANCODE_RALT = 230, /* alt gr, option */
        /// <summary>
        /// The sdl scancode rgui sdl scancode
        /// </summary>
        SDL_SCANCODE_RGUI = 231, /* windows, command (apple), meta */

        /// <summary>
        /// The sdl scancode mode sdl scancode
        /// </summary>
        SDL_SCANCODE_MODE = 257,    /* I'm not sure if this is really not covered
                                 *   by any of the above, but since there's a
                                 *   special KMOD_MODE for it I'm adding it here
                                 */

        /* @} *//* Usage page 0x07 */

        /*
         *  \name Usage page 0x0C
         *
         *  These values are mapped from usage page 0x0C (USB consumer page).
         */
        /* @{ */

        /// <summary>
        /// The sdl scancode audionext sdl scancode
        /// </summary>
        SDL_SCANCODE_AUDIONEXT = 258,
        /// <summary>
        /// The sdl scancode audioprev sdl scancode
        /// </summary>
        SDL_SCANCODE_AUDIOPREV = 259,
        /// <summary>
        /// The sdl scancode audiostop sdl scancode
        /// </summary>
        SDL_SCANCODE_AUDIOSTOP = 260,
        /// <summary>
        /// The sdl scancode audioplay sdl scancode
        /// </summary>
        SDL_SCANCODE_AUDIOPLAY = 261,
        /// <summary>
        /// The sdl scancode audiomute sdl scancode
        /// </summary>
        SDL_SCANCODE_AUDIOMUTE = 262,
        /// <summary>
        /// The sdl scancode mediaselect sdl scancode
        /// </summary>
        SDL_SCANCODE_MEDIASELECT = 263,
        /// <summary>
        /// The sdl scancode www sdl scancode
        /// </summary>
        SDL_SCANCODE_WWW = 264,
        /// <summary>
        /// The sdl scancode mail sdl scancode
        /// </summary>
        SDL_SCANCODE_MAIL = 265,
        /// <summary>
        /// The sdl scancode calculator sdl scancode
        /// </summary>
        SDL_SCANCODE_CALCULATOR = 266,
        /// <summary>
        /// The sdl scancode computer sdl scancode
        /// </summary>
        SDL_SCANCODE_COMPUTER = 267,
        /// <summary>
        /// The sdl scancode ac search sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_SEARCH = 268,
        /// <summary>
        /// The sdl scancode ac home sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_HOME = 269,
        /// <summary>
        /// The sdl scancode ac back sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_BACK = 270,
        /// <summary>
        /// The sdl scancode ac forward sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_FORWARD = 271,
        /// <summary>
        /// The sdl scancode ac stop sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_STOP = 272,
        /// <summary>
        /// The sdl scancode ac refresh sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_REFRESH = 273,
        /// <summary>
        /// The sdl scancode ac bookmarks sdl scancode
        /// </summary>
        SDL_SCANCODE_AC_BOOKMARKS = 274,

        /* @} *//* Usage page 0x0C */

        /*
         *  \name Walther keys
         *
         *  These are values that Christian Walther added (for mac keyboard?).
         */
        /* @{ */

        /// <summary>
        /// The sdl scancode brightnessdown sdl scancode
        /// </summary>
        SDL_SCANCODE_BRIGHTNESSDOWN = 275,
        /// <summary>
        /// The sdl scancode brightnessup sdl scancode
        /// </summary>
        SDL_SCANCODE_BRIGHTNESSUP = 276,
        /// <summary>
        /// The sdl scancode displayswitch sdl scancode
        /// </summary>
        SDL_SCANCODE_DISPLAYSWITCH = 277, /* display mirroring/dual display
                                           switch, video mode switch */
        /// <summary>
        /// The sdl scancode kbdillumtoggle sdl scancode
        /// </summary>
        SDL_SCANCODE_KBDILLUMTOGGLE = 278,
        /// <summary>
        /// The sdl scancode kbdillumdown sdl scancode
        /// </summary>
        SDL_SCANCODE_KBDILLUMDOWN = 279,
        /// <summary>
        /// The sdl scancode kbdillumup sdl scancode
        /// </summary>
        SDL_SCANCODE_KBDILLUMUP = 280,
        /// <summary>
        /// The sdl scancode eject sdl scancode
        /// </summary>
        SDL_SCANCODE_EJECT = 281,
        /// <summary>
        /// The sdl scancode sleep sdl scancode
        /// </summary>
        SDL_SCANCODE_SLEEP = 282,

        /// <summary>
        /// The sdl scancode app1 sdl scancode
        /// </summary>
        SDL_SCANCODE_APP1 = 283,
        /// <summary>
        /// The sdl scancode app2 sdl scancode
        /// </summary>
        SDL_SCANCODE_APP2 = 284,

        /* @} *//* Walther keys */

        /* Add any other keys here. */

        /// <summary>
        /// The sdl num scancodes sdl scancode
        /// </summary>
        SDL_NUM_SCANCODES = 512 /* not a key, just marks the number of scancodes
                                 for array bounds */
    }
 }
