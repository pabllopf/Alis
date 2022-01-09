using System;

namespace Alis.Core.Systems.Audio.Codec
{
    public interface ISoundSinkReceiver : IDisposable
    {
        void Receive(byte[] tempBuf);
    }
}
