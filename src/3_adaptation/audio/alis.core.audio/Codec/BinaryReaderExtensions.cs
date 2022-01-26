// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BinaryReaderExtensions.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.IO;

namespace Alis.Core.Audio.Codec
{
    public static class BinaryReaderExtensions
    {
        public static string ReadFourCc(this BinaryReader reader, bool bigEndian = false)
        {
            char a = reader.ReadChar();
            char b = reader.ReadChar();
            char c = reader.ReadChar();
            char d = reader.ReadChar();

            return bigEndian
                ? new string(new[] {d, c, b, a})
                : new string(new[] {a, b, c, d});
        }
    }

    public static class StreamExtensions
    {
        public static byte[] ReadFourCc(this Stream reader, bool bigEndian = false)
        {
            byte a = (byte) reader.ReadByte();
            byte b = (byte) reader.ReadByte();
            byte c = (byte) reader.ReadByte();
            byte d = (byte) reader.ReadByte();

            return new[] {a, b, c, d};
        }
    }
}