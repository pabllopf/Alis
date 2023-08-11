using System;

namespace Veldrid.Sdl2
{
    /// <summary>
    /// The sdl keycode enum
    /// </summary>
    public enum SDL_Keycode
    {
        /// <summary>
        /// The sdlk unknown sdl keycode
        /// </summary>
        SDLK_UNKNOWN = 0,

        /// <summary>
        /// The sdlk return sdl keycode
        /// </summary>
        SDLK_RETURN = '\r',
        /// <summary>
        /// The sdlk escape sdl keycode
        /// </summary>
        SDLK_ESCAPE = 27,
        /// <summary>
        /// The sdlk backspace sdl keycode
        /// </summary>
        SDLK_BACKSPACE = '\b',
        /// <summary>
        /// The sdlk tab sdl keycode
        /// </summary>
        SDLK_TAB = '\t',
        /// <summary>
        /// The sdlk space sdl keycode
        /// </summary>
        SDLK_SPACE = ' ',
        /// <summary>
        /// The sdlk exclaim sdl keycode
        /// </summary>
        SDLK_EXCLAIM = '!',
        /// <summary>
        /// The sdlk quotedbl sdl keycode
        /// </summary>
        SDLK_QUOTEDBL = '"',
        /// <summary>
        /// The sdlk hash sdl keycode
        /// </summary>
        SDLK_HASH = '#',
        /// <summary>
        /// The sdlk percent sdl keycode
        /// </summary>
        SDLK_PERCENT = '%',
        /// <summary>
        /// The sdlk dollar sdl keycode
        /// </summary>
        SDLK_DOLLAR = '$',
        /// <summary>
        /// The sdlk ampersand sdl keycode
        /// </summary>
        SDLK_AMPERSAND = '&',
        /// <summary>
        /// The sdlk quote sdl keycode
        /// </summary>
        SDLK_QUOTE = '\'',
        /// <summary>
        /// The sdlk leftparen sdl keycode
        /// </summary>
        SDLK_LEFTPAREN = '(',
        /// <summary>
        /// The sdlk rightparen sdl keycode
        /// </summary>
        SDLK_RIGHTPAREN = ')',
        /// <summary>
        /// The sdlk asterisk sdl keycode
        /// </summary>
        SDLK_ASTERISK = '*',
        /// <summary>
        /// The sdlk plus sdl keycode
        /// </summary>
        SDLK_PLUS = '+',
        /// <summary>
        /// The sdlk comma sdl keycode
        /// </summary>
        SDLK_COMMA = ',',
        /// <summary>
        /// The sdlk minus sdl keycode
        /// </summary>
        SDLK_MINUS = '-',
        /// <summary>
        /// The sdlk period sdl keycode
        /// </summary>
        SDLK_PERIOD = '.',
        /// <summary>
        /// The sdlk slash sdl keycode
        /// </summary>
        SDLK_SLASH = '/',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_0 = '0',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_1 = '1',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_2 = '2',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_3 = '3',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_4 = '4',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_5 = '5',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_6 = '6',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_7 = '7',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_8 = '8',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_9 = '9',
        /// <summary>
        /// The sdlk colon sdl keycode
        /// </summary>
        SDLK_COLON = ':',
        /// <summary>
        /// The sdlk semicolon sdl keycode
        /// </summary>
        SDLK_SEMICOLON = ';',
        /// <summary>
        /// The sdlk less sdl keycode
        /// </summary>
        SDLK_LESS = '<',
        /// <summary>
        /// The sdlk equals sdl keycode
        /// </summary>
        SDLK_EQUALS = '=',
        /// <summary>
        /// The sdlk greater sdl keycode
        /// </summary>
        SDLK_GREATER = '>',
        /// <summary>
        /// The sdlk question sdl keycode
        /// </summary>
        SDLK_QUESTION = '?',
        /// <summary>
        /// The sdlk at sdl keycode
        /// </summary>
        SDLK_AT = '@',
        /*
           Skip uppercase letters
         */
        /// <summary>
        /// The sdlk leftbracket sdl keycode
        /// </summary>
        SDLK_LEFTBRACKET = '[',
        /// <summary>
        /// The sdlk backslash sdl keycode
        /// </summary>
        SDLK_BACKSLASH = '\\',
        /// <summary>
        /// The sdlk rightbracket sdl keycode
        /// </summary>
        SDLK_RIGHTBRACKET = ']',
        /// <summary>
        /// The sdlk caret sdl keycode
        /// </summary>
        SDLK_CARET = '^',
        /// <summary>
        /// The sdlk underscore sdl keycode
        /// </summary>
        SDLK_UNDERSCORE = '_',
        /// <summary>
        /// The sdlk backquote sdl keycode
        /// </summary>
        SDLK_BACKQUOTE = '`',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_a = 'a',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_b = 'b',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_c = 'c',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_d = 'd',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_e = 'e',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_f = 'f',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_g = 'g',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_h = 'h',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_i = 'i',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_j = 'j',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_k = 'k',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_l = 'l',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_m = 'm',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_n = 'n',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_o = 'o',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_p = 'p',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_q = 'q',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_r = 'r',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_s = 's',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_t = 't',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_u = 'u',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_v = 'v',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_w = 'w',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_x = 'x',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_y = 'y',
        /// <summary>
        /// The sdlk sdl keycode
        /// </summary>
        SDLK_z = 'z',

        /// <summary>
        /// The sdlk capslock sdl keycode
        /// </summary>
        SDLK_CAPSLOCK = SDL_Scancode.SDL_SCANCODE_CAPSLOCK | (1 << 30),

        /// <summary>
        /// The sdlk f1 sdl keycode
        /// </summary>
        SDLK_F1 = SDL_Scancode.SDL_SCANCODE_F1 | (1 << 30),
        /// <summary>
        /// The sdlk f2 sdl keycode
        /// </summary>
        SDLK_F2 = SDL_Scancode.SDL_SCANCODE_F2 | (1 << 30),
        /// <summary>
        /// The sdlk f3 sdl keycode
        /// </summary>
        SDLK_F3 = SDL_Scancode.SDL_SCANCODE_F3 | (1 << 30),
        /// <summary>
        /// The sdlk f4 sdl keycode
        /// </summary>
        SDLK_F4 = SDL_Scancode.SDL_SCANCODE_F4 | (1 << 30),
        /// <summary>
        /// The sdlk f5 sdl keycode
        /// </summary>
        SDLK_F5 = SDL_Scancode.SDL_SCANCODE_F5 | (1 << 30),
        /// <summary>
        /// The sdlk f6 sdl keycode
        /// </summary>
        SDLK_F6 = SDL_Scancode.SDL_SCANCODE_F6 | (1 << 30),
        /// <summary>
        /// The sdlk f7 sdl keycode
        /// </summary>
        SDLK_F7 = SDL_Scancode.SDL_SCANCODE_F7 | (1 << 30),
        /// <summary>
        /// The sdlk f8 sdl keycode
        /// </summary>
        SDLK_F8 = SDL_Scancode.SDL_SCANCODE_F8 | (1 << 30),
        /// <summary>
        /// The sdlk f9 sdl keycode
        /// </summary>
        SDLK_F9 = SDL_Scancode.SDL_SCANCODE_F9 | (1 << 30),
        /// <summary>
        /// The sdlk f10 sdl keycode
        /// </summary>
        SDLK_F10 = SDL_Scancode.SDL_SCANCODE_F10 | (1 << 30),
        /// <summary>
        /// The sdlk f11 sdl keycode
        /// </summary>
        SDLK_F11 = SDL_Scancode.SDL_SCANCODE_F11 | (1 << 30),
        /// <summary>
        /// The sdlk f12 sdl keycode
        /// </summary>
        SDLK_F12 = SDL_Scancode.SDL_SCANCODE_F12 | (1 << 30),

        /// <summary>
        /// The sdlk printscreen sdl keycode
        /// </summary>
        SDLK_PRINTSCREEN = SDL_Scancode.SDL_SCANCODE_PRINTSCREEN | (1 << 30),
        /// <summary>
        /// The sdlk scrolllock sdl keycode
        /// </summary>
        SDLK_SCROLLLOCK = SDL_Scancode.SDL_SCANCODE_SCROLLLOCK | (1 << 30),
        /// <summary>
        /// The sdlk pause sdl keycode
        /// </summary>
        SDLK_PAUSE = SDL_Scancode.SDL_SCANCODE_PAUSE | (1 << 30),
        /// <summary>
        /// The sdlk insert sdl keycode
        /// </summary>
        SDLK_INSERT = SDL_Scancode.SDL_SCANCODE_INSERT | (1 << 30),
        /// <summary>
        /// The sdlk home sdl keycode
        /// </summary>
        SDLK_HOME = SDL_Scancode.SDL_SCANCODE_HOME | (1 << 30),
        /// <summary>
        /// The sdlk pageup sdl keycode
        /// </summary>
        SDLK_PAGEUP = SDL_Scancode.SDL_SCANCODE_PAGEUP | (1 << 30),
        /// <summary>
        /// The sdlk delete sdl keycode
        /// </summary>
        SDLK_DELETE = 127,
        /// <summary>
        /// The sdlk end sdl keycode
        /// </summary>
        SDLK_END = SDL_Scancode.SDL_SCANCODE_END | (1 << 30),
        /// <summary>
        /// The sdlk pagedown sdl keycode
        /// </summary>
        SDLK_PAGEDOWN = SDL_Scancode.SDL_SCANCODE_PAGEDOWN | (1 << 30),
        /// <summary>
        /// The sdlk right sdl keycode
        /// </summary>
        SDLK_RIGHT = SDL_Scancode.SDL_SCANCODE_RIGHT | (1 << 30),
        /// <summary>
        /// The sdlk left sdl keycode
        /// </summary>
        SDLK_LEFT = SDL_Scancode.SDL_SCANCODE_LEFT | (1 << 30),
        /// <summary>
        /// The sdlk down sdl keycode
        /// </summary>
        SDLK_DOWN = SDL_Scancode.SDL_SCANCODE_DOWN | (1 << 30),
        /// <summary>
        /// The sdlk up sdl keycode
        /// </summary>
        SDLK_UP = SDL_Scancode.SDL_SCANCODE_UP | (1 << 30),

        /// <summary>
        /// The sdlk numlockclear sdl keycode
        /// </summary>
        SDLK_NUMLOCKCLEAR = SDL_Scancode.SDL_SCANCODE_NUMLOCKCLEAR | (1 << 30),
        /// <summary>
        /// The sdlk kp divide sdl keycode
        /// </summary>
        SDLK_KP_DIVIDE = SDL_Scancode.SDL_SCANCODE_KP_DIVIDE | (1 << 30),
        /// <summary>
        /// The sdlk kp multiply sdl keycode
        /// </summary>
        SDLK_KP_MULTIPLY = SDL_Scancode.SDL_SCANCODE_KP_MULTIPLY | (1 << 30),
        /// <summary>
        /// The sdlk kp minus sdl keycode
        /// </summary>
        SDLK_KP_MINUS = SDL_Scancode.SDL_SCANCODE_KP_MINUS | (1 << 30),
        /// <summary>
        /// The sdlk kp plus sdl keycode
        /// </summary>
        SDLK_KP_PLUS = SDL_Scancode.SDL_SCANCODE_KP_PLUS | (1 << 30),
        /// <summary>
        /// The sdlk kp enter sdl keycode
        /// </summary>
        SDLK_KP_ENTER = SDL_Scancode.SDL_SCANCODE_KP_ENTER | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_1 = SDL_Scancode.SDL_SCANCODE_KP_1 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_2 = SDL_Scancode.SDL_SCANCODE_KP_2 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_3 = SDL_Scancode.SDL_SCANCODE_KP_3 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_4 = SDL_Scancode.SDL_SCANCODE_KP_4 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_5 = SDL_Scancode.SDL_SCANCODE_KP_5 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_6 = SDL_Scancode.SDL_SCANCODE_KP_6 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_7 = SDL_Scancode.SDL_SCANCODE_KP_7 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_8 = SDL_Scancode.SDL_SCANCODE_KP_8 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_9 = SDL_Scancode.SDL_SCANCODE_KP_9 | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_0 = SDL_Scancode.SDL_SCANCODE_KP_0 | (1 << 30),
        /// <summary>
        /// The sdlk kp period sdl keycode
        /// </summary>
        SDLK_KP_PERIOD = SDL_Scancode.SDL_SCANCODE_KP_PERIOD | (1 << 30),

        /// <summary>
        /// The sdlk application sdl keycode
        /// </summary>
        SDLK_APPLICATION = SDL_Scancode.SDL_SCANCODE_APPLICATION | (1 << 30),
        /// <summary>
        /// The sdlk power sdl keycode
        /// </summary>
        SDLK_POWER = SDL_Scancode.SDL_SCANCODE_POWER | (1 << 30),
        /// <summary>
        /// The sdlk kp equals sdl keycode
        /// </summary>
        SDLK_KP_EQUALS = SDL_Scancode.SDL_SCANCODE_KP_EQUALS | (1 << 30),
        /// <summary>
        /// The sdlk f13 sdl keycode
        /// </summary>
        SDLK_F13 = SDL_Scancode.SDL_SCANCODE_F13 | (1 << 30),
        /// <summary>
        /// The sdlk f14 sdl keycode
        /// </summary>
        SDLK_F14 = SDL_Scancode.SDL_SCANCODE_F14 | (1 << 30),
        /// <summary>
        /// The sdlk f15 sdl keycode
        /// </summary>
        SDLK_F15 = SDL_Scancode.SDL_SCANCODE_F15 | (1 << 30),
        /// <summary>
        /// The sdlk f16 sdl keycode
        /// </summary>
        SDLK_F16 = SDL_Scancode.SDL_SCANCODE_F16 | (1 << 30),
        /// <summary>
        /// The sdlk f17 sdl keycode
        /// </summary>
        SDLK_F17 = SDL_Scancode.SDL_SCANCODE_F17 | (1 << 30),
        /// <summary>
        /// The sdlk f18 sdl keycode
        /// </summary>
        SDLK_F18 = SDL_Scancode.SDL_SCANCODE_F18 | (1 << 30),
        /// <summary>
        /// The sdlk f19 sdl keycode
        /// </summary>
        SDLK_F19 = SDL_Scancode.SDL_SCANCODE_F19 | (1 << 30),
        /// <summary>
        /// The sdlk f20 sdl keycode
        /// </summary>
        SDLK_F20 = SDL_Scancode.SDL_SCANCODE_F20 | (1 << 30),
        /// <summary>
        /// The sdlk f21 sdl keycode
        /// </summary>
        SDLK_F21 = SDL_Scancode.SDL_SCANCODE_F21 | (1 << 30),
        /// <summary>
        /// The sdlk f22 sdl keycode
        /// </summary>
        SDLK_F22 = SDL_Scancode.SDL_SCANCODE_F22 | (1 << 30),
        /// <summary>
        /// The sdlk f23 sdl keycode
        /// </summary>
        SDLK_F23 = SDL_Scancode.SDL_SCANCODE_F23 | (1 << 30),
        /// <summary>
        /// The sdlk f24 sdl keycode
        /// </summary>
        SDLK_F24 = SDL_Scancode.SDL_SCANCODE_F24 | (1 << 30),
        /// <summary>
        /// The sdlk execute sdl keycode
        /// </summary>
        SDLK_EXECUTE = SDL_Scancode.SDL_SCANCODE_EXECUTE | (1 << 30),
        /// <summary>
        /// The sdlk help sdl keycode
        /// </summary>
        SDLK_HELP = SDL_Scancode.SDL_SCANCODE_HELP | (1 << 30),
        /// <summary>
        /// The sdlk menu sdl keycode
        /// </summary>
        SDLK_MENU = SDL_Scancode.SDL_SCANCODE_MENU | (1 << 30),
        /// <summary>
        /// The sdlk select sdl keycode
        /// </summary>
        SDLK_SELECT = SDL_Scancode.SDL_SCANCODE_SELECT | (1 << 30),
        /// <summary>
        /// The sdlk stop sdl keycode
        /// </summary>
        SDLK_STOP = SDL_Scancode.SDL_SCANCODE_STOP | (1 << 30),
        /// <summary>
        /// The sdlk again sdl keycode
        /// </summary>
        SDLK_AGAIN = SDL_Scancode.SDL_SCANCODE_AGAIN | (1 << 30),
        /// <summary>
        /// The sdlk undo sdl keycode
        /// </summary>
        SDLK_UNDO = SDL_Scancode.SDL_SCANCODE_UNDO | (1 << 30),
        /// <summary>
        /// The sdlk cut sdl keycode
        /// </summary>
        SDLK_CUT = SDL_Scancode.SDL_SCANCODE_CUT | (1 << 30),
        /// <summary>
        /// The sdlk copy sdl keycode
        /// </summary>
        SDLK_COPY = SDL_Scancode.SDL_SCANCODE_COPY | (1 << 30),
        /// <summary>
        /// The sdlk paste sdl keycode
        /// </summary>
        SDLK_PASTE = SDL_Scancode.SDL_SCANCODE_PASTE | (1 << 30),
        /// <summary>
        /// The sdlk find sdl keycode
        /// </summary>
        SDLK_FIND = SDL_Scancode.SDL_SCANCODE_FIND | (1 << 30),
        /// <summary>
        /// The sdlk mute sdl keycode
        /// </summary>
        SDLK_MUTE = SDL_Scancode.SDL_SCANCODE_MUTE | (1 << 30),
        /// <summary>
        /// The sdlk volumeup sdl keycode
        /// </summary>
        SDLK_VOLUMEUP = SDL_Scancode.SDL_SCANCODE_VOLUMEUP | (1 << 30),
        /// <summary>
        /// The sdlk volumedown sdl keycode
        /// </summary>
        SDLK_VOLUMEDOWN = SDL_Scancode.SDL_SCANCODE_VOLUMEDOWN | (1 << 30),
        /// <summary>
        /// The sdlk kp comma sdl keycode
        /// </summary>
        SDLK_KP_COMMA = SDL_Scancode.SDL_SCANCODE_KP_COMMA | (1 << 30),
        /// <summary>
        /// The sdlk kp equalsas400 sdl keycode
        /// </summary>
        SDLK_KP_EQUALSAS400 =
            SDL_Scancode.SDL_SCANCODE_KP_EQUALSAS400 | (1 << 30),

        /// <summary>
        /// The sdlk alterase sdl keycode
        /// </summary>
        SDLK_ALTERASE = SDL_Scancode.SDL_SCANCODE_ALTERASE | (1 << 30),
        /// <summary>
        /// The sdlk sysreq sdl keycode
        /// </summary>
        SDLK_SYSREQ = SDL_Scancode.SDL_SCANCODE_SYSREQ | (1 << 30),
        /// <summary>
        /// The sdlk cancel sdl keycode
        /// </summary>
        SDLK_CANCEL = SDL_Scancode.SDL_SCANCODE_CANCEL | (1 << 30),
        /// <summary>
        /// The sdlk clear sdl keycode
        /// </summary>
        SDLK_CLEAR = SDL_Scancode.SDL_SCANCODE_CLEAR | (1 << 30),
        /// <summary>
        /// The sdlk prior sdl keycode
        /// </summary>
        SDLK_PRIOR = SDL_Scancode.SDL_SCANCODE_PRIOR | (1 << 30),
        /// <summary>
        /// The sdlk return2 sdl keycode
        /// </summary>
        SDLK_RETURN2 = SDL_Scancode.SDL_SCANCODE_RETURN2 | (1 << 30),
        /// <summary>
        /// The sdlk separator sdl keycode
        /// </summary>
        SDLK_SEPARATOR = SDL_Scancode.SDL_SCANCODE_SEPARATOR | (1 << 30),
        /// <summary>
        /// The sdlk out sdl keycode
        /// </summary>
        SDLK_OUT = SDL_Scancode.SDL_SCANCODE_OUT | (1 << 30),
        /// <summary>
        /// The sdlk oper sdl keycode
        /// </summary>
        SDLK_OPER = SDL_Scancode.SDL_SCANCODE_OPER | (1 << 30),
        /// <summary>
        /// The sdlk clearagain sdl keycode
        /// </summary>
        SDLK_CLEARAGAIN = SDL_Scancode.SDL_SCANCODE_CLEARAGAIN | (1 << 30),
        /// <summary>
        /// The sdlk crsel sdl keycode
        /// </summary>
        SDLK_CRSEL = SDL_Scancode.SDL_SCANCODE_CRSEL | (1 << 30),
        /// <summary>
        /// The sdlk exsel sdl keycode
        /// </summary>
        SDLK_EXSEL = SDL_Scancode.SDL_SCANCODE_EXSEL | (1 << 30),

        /// <summary>
        /// The sdlk kp 00 sdl keycode
        /// </summary>
        SDLK_KP_00 = SDL_Scancode.SDL_SCANCODE_KP_00 | (1 << 30),
        /// <summary>
        /// The sdlk kp 000 sdl keycode
        /// </summary>
        SDLK_KP_000 = SDL_Scancode.SDL_SCANCODE_KP_000 | (1 << 30),
        /// <summary>
        /// The sdlk thousandsseparator sdl keycode
        /// </summary>
        SDLK_THOUSANDSSEPARATOR =
            SDL_Scancode.SDL_SCANCODE_THOUSANDSSEPARATOR | (1 << 30),
        /// <summary>
        /// The sdlk decimalseparator sdl keycode
        /// </summary>
        SDLK_DECIMALSEPARATOR =
            SDL_Scancode.SDL_SCANCODE_DECIMALSEPARATOR | (1 << 30),
        /// <summary>
        /// The sdlk currencyunit sdl keycode
        /// </summary>
        SDLK_CURRENCYUNIT = SDL_Scancode.SDL_SCANCODE_CURRENCYUNIT | (1 << 30),
        /// <summary>
        /// The sdlk currencysubunit sdl keycode
        /// </summary>
        SDLK_CURRENCYSUBUNIT =
            SDL_Scancode.SDL_SCANCODE_CURRENCYSUBUNIT | (1 << 30),
        /// <summary>
        /// The sdlk kp leftparen sdl keycode
        /// </summary>
        SDLK_KP_LEFTPAREN = SDL_Scancode.SDL_SCANCODE_KP_LEFTPAREN | (1 << 30),
        /// <summary>
        /// The sdlk kp rightparen sdl keycode
        /// </summary>
        SDLK_KP_RIGHTPAREN = SDL_Scancode.SDL_SCANCODE_KP_RIGHTPAREN | (1 << 30),
        /// <summary>
        /// The sdlk kp leftbrace sdl keycode
        /// </summary>
        SDLK_KP_LEFTBRACE = SDL_Scancode.SDL_SCANCODE_KP_LEFTBRACE | (1 << 30),
        /// <summary>
        /// The sdlk kp rightbrace sdl keycode
        /// </summary>
        SDLK_KP_RIGHTBRACE = SDL_Scancode.SDL_SCANCODE_KP_RIGHTBRACE | (1 << 30),
        /// <summary>
        /// The sdlk kp tab sdl keycode
        /// </summary>
        SDLK_KP_TAB = SDL_Scancode.SDL_SCANCODE_KP_TAB | (1 << 30),
        /// <summary>
        /// The sdlk kp backspace sdl keycode
        /// </summary>
        SDLK_KP_BACKSPACE = SDL_Scancode.SDL_SCANCODE_KP_BACKSPACE | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_A = SDL_Scancode.SDL_SCANCODE_KP_A | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_B = SDL_Scancode.SDL_SCANCODE_KP_B | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_C = SDL_Scancode.SDL_SCANCODE_KP_C | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_D = SDL_Scancode.SDL_SCANCODE_KP_D | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_E = SDL_Scancode.SDL_SCANCODE_KP_E | (1 << 30),
        /// <summary>
        /// The sdlk kp sdl keycode
        /// </summary>
        SDLK_KP_F = SDL_Scancode.SDL_SCANCODE_KP_F | (1 << 30),
        /// <summary>
        /// The sdlk kp xor sdl keycode
        /// </summary>
        SDLK_KP_XOR = SDL_Scancode.SDL_SCANCODE_KP_XOR | (1 << 30),
        /// <summary>
        /// The sdlk kp power sdl keycode
        /// </summary>
        SDLK_KP_POWER = SDL_Scancode.SDL_SCANCODE_KP_POWER | (1 << 30),
        /// <summary>
        /// The sdlk kp percent sdl keycode
        /// </summary>
        SDLK_KP_PERCENT = SDL_Scancode.SDL_SCANCODE_KP_PERCENT | (1 << 30),
        /// <summary>
        /// The sdlk kp less sdl keycode
        /// </summary>
        SDLK_KP_LESS = SDL_Scancode.SDL_SCANCODE_KP_LESS | (1 << 30),
        /// <summary>
        /// The sdlk kp greater sdl keycode
        /// </summary>
        SDLK_KP_GREATER = SDL_Scancode.SDL_SCANCODE_KP_GREATER | (1 << 30),
        /// <summary>
        /// The sdlk kp ampersand sdl keycode
        /// </summary>
        SDLK_KP_AMPERSAND = SDL_Scancode.SDL_SCANCODE_KP_AMPERSAND | (1 << 30),
        /// <summary>
        /// The sdlk kp dblampersand sdl keycode
        /// </summary>
        SDLK_KP_DBLAMPERSAND =
            SDL_Scancode.SDL_SCANCODE_KP_DBLAMPERSAND | (1 << 30),
        /// <summary>
        /// The sdlk kp verticalbar sdl keycode
        /// </summary>
        SDLK_KP_VERTICALBAR =
            SDL_Scancode.SDL_SCANCODE_KP_VERTICALBAR | (1 << 30),
        /// <summary>
        /// The sdlk kp dblverticalbar sdl keycode
        /// </summary>
        SDLK_KP_DBLVERTICALBAR =
            SDL_Scancode.SDL_SCANCODE_KP_DBLVERTICALBAR | (1 << 30),
        /// <summary>
        /// The sdlk kp colon sdl keycode
        /// </summary>
        SDLK_KP_COLON = SDL_Scancode.SDL_SCANCODE_KP_COLON | (1 << 30),
        /// <summary>
        /// The sdlk kp hash sdl keycode
        /// </summary>
        SDLK_KP_HASH = SDL_Scancode.SDL_SCANCODE_KP_HASH | (1 << 30),
        /// <summary>
        /// The sdlk kp space sdl keycode
        /// </summary>
        SDLK_KP_SPACE = SDL_Scancode.SDL_SCANCODE_KP_SPACE | (1 << 30),
        /// <summary>
        /// The sdlk kp at sdl keycode
        /// </summary>
        SDLK_KP_AT = SDL_Scancode.SDL_SCANCODE_KP_AT | (1 << 30),
        /// <summary>
        /// The sdlk kp exclam sdl keycode
        /// </summary>
        SDLK_KP_EXCLAM = SDL_Scancode.SDL_SCANCODE_KP_EXCLAM | (1 << 30),
        /// <summary>
        /// The sdlk kp memstore sdl keycode
        /// </summary>
        SDLK_KP_MEMSTORE = SDL_Scancode.SDL_SCANCODE_KP_MEMSTORE | (1 << 30),
        /// <summary>
        /// The sdlk kp memrecall sdl keycode
        /// </summary>
        SDLK_KP_MEMRECALL = SDL_Scancode.SDL_SCANCODE_KP_MEMRECALL | (1 << 30),
        /// <summary>
        /// The sdlk kp memclear sdl keycode
        /// </summary>
        SDLK_KP_MEMCLEAR = SDL_Scancode.SDL_SCANCODE_KP_MEMCLEAR | (1 << 30),
        /// <summary>
        /// The sdlk kp memadd sdl keycode
        /// </summary>
        SDLK_KP_MEMADD = SDL_Scancode.SDL_SCANCODE_KP_MEMADD | (1 << 30),
        /// <summary>
        /// The sdlk kp memsubtract sdl keycode
        /// </summary>
        SDLK_KP_MEMSUBTRACT =
            SDL_Scancode.SDL_SCANCODE_KP_MEMSUBTRACT | (1 << 30),
        /// <summary>
        /// The sdlk kp memmultiply sdl keycode
        /// </summary>
        SDLK_KP_MEMMULTIPLY =
            SDL_Scancode.SDL_SCANCODE_KP_MEMMULTIPLY | (1 << 30),
        /// <summary>
        /// The sdlk kp memdivide sdl keycode
        /// </summary>
        SDLK_KP_MEMDIVIDE = SDL_Scancode.SDL_SCANCODE_KP_MEMDIVIDE | (1 << 30),
        /// <summary>
        /// The sdlk kp plusminus sdl keycode
        /// </summary>
        SDLK_KP_PLUSMINUS = SDL_Scancode.SDL_SCANCODE_KP_PLUSMINUS | (1 << 30),
        /// <summary>
        /// The sdlk kp clear sdl keycode
        /// </summary>
        SDLK_KP_CLEAR = SDL_Scancode.SDL_SCANCODE_KP_CLEAR | (1 << 30),
        /// <summary>
        /// The sdlk kp clearentry sdl keycode
        /// </summary>
        SDLK_KP_CLEARENTRY = SDL_Scancode.SDL_SCANCODE_KP_CLEARENTRY | (1 << 30),
        /// <summary>
        /// The sdlk kp binary sdl keycode
        /// </summary>
        SDLK_KP_BINARY = SDL_Scancode.SDL_SCANCODE_KP_BINARY | (1 << 30),
        /// <summary>
        /// The sdlk kp octal sdl keycode
        /// </summary>
        SDLK_KP_OCTAL = SDL_Scancode.SDL_SCANCODE_KP_OCTAL | (1 << 30),
        /// <summary>
        /// The sdlk kp decimal sdl keycode
        /// </summary>
        SDLK_KP_DECIMAL = SDL_Scancode.SDL_SCANCODE_KP_DECIMAL | (1 << 30),
        /// <summary>
        /// The sdlk kp hexadecimal sdl keycode
        /// </summary>
        SDLK_KP_HEXADECIMAL =
            SDL_Scancode.SDL_SCANCODE_KP_HEXADECIMAL | (1 << 30),

        /// <summary>
        /// The sdlk lctrl sdl keycode
        /// </summary>
        SDLK_LCTRL = SDL_Scancode.SDL_SCANCODE_LCTRL | (1 << 30),
        /// <summary>
        /// The sdlk lshift sdl keycode
        /// </summary>
        SDLK_LSHIFT = SDL_Scancode.SDL_SCANCODE_LSHIFT | (1 << 30),
        /// <summary>
        /// The sdlk lalt sdl keycode
        /// </summary>
        SDLK_LALT = SDL_Scancode.SDL_SCANCODE_LALT | (1 << 30),
        /// <summary>
        /// The sdlk lgui sdl keycode
        /// </summary>
        SDLK_LGUI = SDL_Scancode.SDL_SCANCODE_LGUI | (1 << 30),
        /// <summary>
        /// The sdlk rctrl sdl keycode
        /// </summary>
        SDLK_RCTRL = SDL_Scancode.SDL_SCANCODE_RCTRL | (1 << 30),
        /// <summary>
        /// The sdlk rshift sdl keycode
        /// </summary>
        SDLK_RSHIFT = SDL_Scancode.SDL_SCANCODE_RSHIFT | (1 << 30),
        /// <summary>
        /// The sdlk ralt sdl keycode
        /// </summary>
        SDLK_RALT = SDL_Scancode.SDL_SCANCODE_RALT | (1 << 30),
        /// <summary>
        /// The sdlk rgui sdl keycode
        /// </summary>
        SDLK_RGUI = SDL_Scancode.SDL_SCANCODE_RGUI | (1 << 30),

        /// <summary>
        /// The sdlk mode sdl keycode
        /// </summary>
        SDLK_MODE = SDL_Scancode.SDL_SCANCODE_MODE | (1 << 30),

        /// <summary>
        /// The sdlk audionext sdl keycode
        /// </summary>
        SDLK_AUDIONEXT = SDL_Scancode.SDL_SCANCODE_AUDIONEXT | (1 << 30),
        /// <summary>
        /// The sdlk audioprev sdl keycode
        /// </summary>
        SDLK_AUDIOPREV = SDL_Scancode.SDL_SCANCODE_AUDIOPREV | (1 << 30),
        /// <summary>
        /// The sdlk audiostop sdl keycode
        /// </summary>
        SDLK_AUDIOSTOP = SDL_Scancode.SDL_SCANCODE_AUDIOSTOP | (1 << 30),
        /// <summary>
        /// The sdlk audioplay sdl keycode
        /// </summary>
        SDLK_AUDIOPLAY = SDL_Scancode.SDL_SCANCODE_AUDIOPLAY | (1 << 30),
        /// <summary>
        /// The sdlk audiomute sdl keycode
        /// </summary>
        SDLK_AUDIOMUTE = SDL_Scancode.SDL_SCANCODE_AUDIOMUTE | (1 << 30),
        /// <summary>
        /// The sdlk mediaselect sdl keycode
        /// </summary>
        SDLK_MEDIASELECT = SDL_Scancode.SDL_SCANCODE_MEDIASELECT | (1 << 30),
        /// <summary>
        /// The sdlk www sdl keycode
        /// </summary>
        SDLK_WWW = SDL_Scancode.SDL_SCANCODE_WWW | (1 << 30),
        /// <summary>
        /// The sdlk mail sdl keycode
        /// </summary>
        SDLK_MAIL = SDL_Scancode.SDL_SCANCODE_MAIL | (1 << 30),
        /// <summary>
        /// The sdlk calculator sdl keycode
        /// </summary>
        SDLK_CALCULATOR = SDL_Scancode.SDL_SCANCODE_CALCULATOR | (1 << 30),
        /// <summary>
        /// The sdlk computer sdl keycode
        /// </summary>
        SDLK_COMPUTER = SDL_Scancode.SDL_SCANCODE_COMPUTER | (1 << 30),
        /// <summary>
        /// The sdlk ac search sdl keycode
        /// </summary>
        SDLK_AC_SEARCH = SDL_Scancode.SDL_SCANCODE_AC_SEARCH | (1 << 30),
        /// <summary>
        /// The sdlk ac home sdl keycode
        /// </summary>
        SDLK_AC_HOME = SDL_Scancode.SDL_SCANCODE_AC_HOME | (1 << 30),
        /// <summary>
        /// The sdlk ac back sdl keycode
        /// </summary>
        SDLK_AC_BACK = SDL_Scancode.SDL_SCANCODE_AC_BACK | (1 << 30),
        /// <summary>
        /// The sdlk ac forward sdl keycode
        /// </summary>
        SDLK_AC_FORWARD = SDL_Scancode.SDL_SCANCODE_AC_FORWARD | (1 << 30),
        /// <summary>
        /// The sdlk ac stop sdl keycode
        /// </summary>
        SDLK_AC_STOP = SDL_Scancode.SDL_SCANCODE_AC_STOP | (1 << 30),
        /// <summary>
        /// The sdlk ac refresh sdl keycode
        /// </summary>
        SDLK_AC_REFRESH = SDL_Scancode.SDL_SCANCODE_AC_REFRESH | (1 << 30),
        /// <summary>
        /// The sdlk ac bookmarks sdl keycode
        /// </summary>
        SDLK_AC_BOOKMARKS = SDL_Scancode.SDL_SCANCODE_AC_BOOKMARKS | (1 << 30),

        /// <summary>
        /// The sdlk brightnessdown sdl keycode
        /// </summary>
        SDLK_BRIGHTNESSDOWN =
            SDL_Scancode.SDL_SCANCODE_BRIGHTNESSDOWN | (1 << 30),
        /// <summary>
        /// The sdlk brightnessup sdl keycode
        /// </summary>
        SDLK_BRIGHTNESSUP = SDL_Scancode.SDL_SCANCODE_BRIGHTNESSUP | (1 << 30),
        /// <summary>
        /// The sdlk displayswitch sdl keycode
        /// </summary>
        SDLK_DISPLAYSWITCH = SDL_Scancode.SDL_SCANCODE_DISPLAYSWITCH | (1 << 30),
        /// <summary>
        /// The sdlk kbdillumtoggle sdl keycode
        /// </summary>
        SDLK_KBDILLUMTOGGLE =
            SDL_Scancode.SDL_SCANCODE_KBDILLUMTOGGLE | (1 << 30),
        /// <summary>
        /// The sdlk kbdillumdown sdl keycode
        /// </summary>
        SDLK_KBDILLUMDOWN = SDL_Scancode.SDL_SCANCODE_KBDILLUMDOWN | (1 << 30),
        /// <summary>
        /// The sdlk kbdillumup sdl keycode
        /// </summary>
        SDLK_KBDILLUMUP = SDL_Scancode.SDL_SCANCODE_KBDILLUMUP | (1 << 30),
        /// <summary>
        /// The sdlk eject sdl keycode
        /// </summary>
        SDLK_EJECT = SDL_Scancode.SDL_SCANCODE_EJECT | (1 << 30),
        /// <summary>
        /// The sdlk sleep sdl keycode
        /// </summary>
        SDLK_SLEEP = SDL_Scancode.SDL_SCANCODE_SLEEP | (1 << 30)
    }

    /// <summary>
    /// Enumeration of valid key mods (possibly OR'd together).
    /// </summary>
    [Flags]
    public enum SDL_Keymod
    {
        /// <summary>
        /// The none sdl keymod
        /// </summary>
        None = 0x0000,
        /// <summary>
        /// The left shift sdl keymod
        /// </summary>
        LeftShift = 0x0001,
        /// <summary>
        /// The right shift sdl keymod
        /// </summary>
        RightShift = 0x0002,
        /// <summary>
        /// The left control sdl keymod
        /// </summary>
        LeftControl = 0x0040,
        /// <summary>
        /// The right control sdl keymod
        /// </summary>
        RightControl = 0x0080,
        /// <summary>
        /// The left alt sdl keymod
        /// </summary>
        LeftAlt = 0x0100,
        /// <summary>
        /// The right alt sdl keymod
        /// </summary>
        RightAlt = 0x0200,
        /// <summary>
        /// The left gui sdl keymod
        /// </summary>
        LeftGui = 0x0400,
        /// <summary>
        /// The right gui sdl keymod
        /// </summary>
        RightGui = 0x0800,
        /// <summary>
        /// The num sdl keymod
        /// </summary>
        Num = 0x1000,
        /// <summary>
        /// The caps sdl keymod
        /// </summary>
        Caps = 0x2000,
        /// <summary>
        /// The mode sdl keymod
        /// </summary>
        Mode = 0x4000,
        /// <summary>
        /// The reserved sdl keymod
        /// </summary>
        Reserved = 0x8000
    }
}
