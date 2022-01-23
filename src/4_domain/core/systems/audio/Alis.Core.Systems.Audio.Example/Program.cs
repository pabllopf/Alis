
using System;
using System.Buffers.Binary;
using System.IO;
using System.Threading;
using OpenTK.Audio.OpenAL.Extensions.Creative.EFX;
using OpenTK.Audio.OpenAL.Extensions.EXT.Double;
using OpenTK.Audio.OpenAL.Extensions.EXT.Float32;
using OpenTK.Audio.OpenAL.Extensions.EXT.FloatFormat;

namespace OpenTK.Audio.OpenAL
{
    internal class ALTest
    {
        public static void Main(string[] args)
        {
           Console.WriteLine("Hello!");
            var devices = ALC.GetStringList(GetEnumerationStringList.DeviceSpecifier);
            Console.WriteLine($"Devices: {string.Join(", ", devices)}");

            // Get the default device, then go though all devices and select the AL soft device if it exists.
            string deviceName = ALC.GetString(ALDevice.Null, AlcGetString.DefaultDeviceSpecifier);
            foreach (var d in devices)
            {
                if (d.Contains("OpenAL Soft"))
                {
                    deviceName = d;
                }
            }

            var allDevices = Extensions.Creative.EnumerateAll.EnumerateAll.GetStringList(Extensions.Creative.EnumerateAll.GetEnumerateAllContextStringList.AllDevicesSpecifier);
            Console.WriteLine($"All Devices: {string.Join(", ", allDevices)}");

            var device = ALC.OpenDevice(deviceName);
            ALContext context = ALC.CreateContext(device, (int[])null);
            ALC.MakeContextCurrent(context);

            CheckALError("Start");

            ALC.GetInteger(device, AlcGetInteger.MajorVersion, 1, out int alcMajorVersion);
            ALC.GetInteger(device, AlcGetInteger.MinorVersion, 1, out int alcMinorVersion);
            string alcExts = ALC.GetString(device, AlcGetString.Extensions);

            var attrs = ALC.GetContextAttributes(device);
            Console.WriteLine($"Attributes: {attrs}");

            string exts = AL.Get(ALGetString.Extensions);
            string rend = AL.Get(ALGetString.Renderer);
            string vend = AL.Get(ALGetString.Vendor);
            string vers = AL.Get(ALGetString.Version);

            Console.WriteLine($"Vendor: {vend}, \nVersion: {vers}, \nRenderer: {rend}, \nExtensions: {exts}, \nALC Version: {alcMajorVersion}.{alcMinorVersion}, \nALC Extensions: {alcExts}");

            Console.WriteLine("Available devices: ");
            var list = Extensions.Creative.EnumerateAll.EnumerateAll.GetStringList(Extensions.Creative.EnumerateAll.GetEnumerateAllContextStringList.AllDevicesSpecifier);
            foreach (var item in list)
            {
                Console.WriteLine("  " + item);
            }

            Console.WriteLine("Available capture devices: ");
            list = ALC.GetStringList(GetEnumerationStringList.CaptureDeviceSpecifier);
            foreach (var item in list)
            {
                Console.WriteLine("  " + item);
            }
            int auxSlot = 0;
            if (EFX.IsExtensionPresent(device))
            {
                Console.WriteLine("EFX extension is present!!");
                EFX.GenEffect(out int effect);
                EFX.Effect(effect, EffectInteger.EffectType, (int)EffectType.Reverb);
                EFX.GenAuxiliaryEffectSlot(out auxSlot);
                EFX.AuxiliaryEffectSlot(auxSlot, EffectSlotInteger.Effect, effect);
            }

            // Record a second of data
            CheckALError("Before record");
            short[] recording = new short[44100 * 4];
            ALCaptureDevice captureDevice = ALC.CaptureOpenDevice(null, 44100, ALFormat.Mono16, 1024);
            {
                ALC.CaptureStart(captureDevice);

                int current = 0;
                while (current < recording.Length)
                {
                    int samplesAvailable = ALC.GetAvailableSamples(captureDevice);
                    if (samplesAvailable > 512)
                    {
                        int samplesToRead = Math.Min(samplesAvailable, recording.Length - current);
                        ALC.CaptureSamples(captureDevice, ref recording[current], samplesToRead);
                        current += samplesToRead;
                    }
                    Thread.Yield();
                }

                ALC.CaptureStop(captureDevice);
            }
            CheckALError("After record");

            // Playback the recorded data
            CheckALError("Before data");
            AL.GenBuffer(out int alBuffer);
            // short[] sine = new short[44100 * 1];
            // FillSine(sine, 4400, 44100);
            // FillSine(recording, 440, 44100);
            AL.BufferData(alBuffer, ALFormat.Mono16, ref recording[0], recording.Length * 2, 44100);
            CheckALError("After data");

            AL.Listener(ALListenerf.Gain, 0.1f);

            AL.GenSource(out int alSource);
            AL.Source(alSource, ALSourcef.Gain, 1f);
            AL.Source(alSource, ALSourcei.Buffer, alBuffer);
            if (EFX.IsExtensionPresent(device))
            {
                EFX.Source(alSource, EFXSourceInteger3.AuxiliarySendFilter, auxSlot, 0, 0);
            }
            AL.SourcePlay(alSource);

            Console.WriteLine("Before Playing: " + AL.GetErrorString(AL.GetError()));

            if (Extensions.SOFT.DeviceClock.DeviceClock.IsExtensionPresent(device))
            {
                long[] clockLatency = new long[2];
                Extensions.SOFT.DeviceClock.DeviceClock.GetInteger(device, Extensions.SOFT.DeviceClock.GetInteger64.DeviceClock, clockLatency);
                Console.WriteLine("Clock: " + clockLatency[0] + ", Latency: " + clockLatency[1]);
                CheckALError(" ");
            }

            if (Extensions.SOFT.SourceLatency.SourceLatency.IsExtensionPresent())
            {
                Extensions.SOFT.SourceLatency.SourceLatency.GetSource(alSource, Extensions.SOFT.SourceLatency.SourceLatencyVector2d.SecOffsetLatency, out var values);
                Extensions.SOFT.SourceLatency.SourceLatency.GetSource(alSource, Extensions.SOFT.SourceLatency.SourceLatencyVector2i.SampleOffsetLatency, out var values1, out var values2, out var values3);
                Console.WriteLine("Source latency: " + values);
                Console.WriteLine($"Source latency 2: {Convert.ToString(values1, 2)}, {values2}; {values3}");
                CheckALError(" ");
            }

            while (AL.GetSourceState(alSource) == ALSourceState.Playing)
            {
                if (Extensions.SOFT.SourceLatency.SourceLatency.IsExtensionPresent())
                {
                    Extensions.SOFT.SourceLatency.SourceLatency.GetSource(alSource, Extensions.SOFT.SourceLatency.SourceLatencyVector2d.SecOffsetLatency, out var values);
                    Extensions.SOFT.SourceLatency.SourceLatency.GetSource(alSource, Extensions.SOFT.SourceLatency.SourceLatencyVector2i.SampleOffsetLatency, out var values1, out var values2, out var values3);
                    Console.WriteLine("Source latency: " + values);
                    Console.WriteLine($"Source latency 2: {Convert.ToString(values1, 2)}, {values2}; {values3}");
                    CheckALError(" ");
                }
                if (Extensions.SOFT.DeviceClock.DeviceClock.IsExtensionPresent(device))
                {
                    long[] clockLatency = new long[2];
                    Extensions.SOFT.DeviceClock.DeviceClock.GetInteger(device, Extensions.SOFT.DeviceClock.GetInteger64.DeviceClock, 1, clockLatency);
                    Console.WriteLine("Clock: " + clockLatency[0] + ", Latency: " + clockLatency[1]);
                    CheckALError(" ");
                }

                Thread.Sleep(10);
            }

            AL.SourceStop(alSource);

            // Test float32 format extension
            if (EXTFloat32.IsExtensionPresent()) {
                Console.WriteLine("Testing float32 format extension with a sine wave...");

                float[] sine = new float[44100 * 2];
                for (int i = 0; i < sine.Length; i++)
                {
                    sine[i] = MathF.Sin(440 * MathF.PI * 2 * (i / (float)sine.Length));
                }

                var buffer = AL.GenBuffer();
                EXTFloat32.BufferData(buffer, FloatBufferFormat.Mono, sine, 44100);

                AL.Listener(ALListenerf.Gain, 0.1f);

                AL.Source(alSource, ALSourcef.Gain, 1f);
                AL.Source(alSource, ALSourcei.Buffer, buffer);

                AL.SourcePlay(alSource);

                while (AL.GetSourceState(alSource) == ALSourceState.Playing)
                {
                    Thread.Sleep(10);
                }

                AL.SourceStop(alSource);
            }

            // Test double format extension
            if (EXTDouble.IsExtensionPresent())
            {
                Console.WriteLine("Testing float64 format extension with a saw wave...");

                double[] saw = new double[44100 * 2];
                for (int i = 0; i < saw.Length; i++)
                {
                    var t = (i / (double)saw.Length) * 440;
                    saw[i] = t - Math.Floor(t);
                }

                var buffer = AL.GenBuffer();
                EXTDouble.BufferData(buffer, DoubleBufferFormat.Mono, saw, 44100);

                AL.Listener(ALListenerf.Gain, 0.1f);

                AL.Source(alSource, ALSourcef.Gain, 1f);
                AL.Source(alSource, ALSourcei.Buffer, buffer);

                AL.SourcePlay(alSource);

                while (AL.GetSourceState(alSource) == ALSourceState.Playing)
                {
                    Thread.Sleep(10);
                }

                AL.SourceStop(alSource);
            }

            
            
            
            

            ALC.MakeContextCurrent(ALContext.Null);
            ALC.DestroyContext(context);
            ALC.CloseDevice(device);
            
            Console.WriteLine("Goodbye!");
            
            Console.WriteLine("Playing sound...");
            ExampleSound();
            Console.WriteLine("Done!");
        }

        public static void CheckALError(string str)
        {
            ALError error = AL.GetError();
            if (error != ALError.NoError)
            {
                Console.WriteLine($"ALError at '{str}': {AL.GetErrorString(error)}");
            }
        }

        public static void FillSine(short[] buffer, float frequency, float sampleRate)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = (short)(MathF.Sin((i * frequency * MathF.PI * 2) / sampleRate) * short.MaxValue);
            }
        }

        public static void ExampleSound()
        {
            unsafe
            {
                //Initialize
                var device = ALC.OpenDevice(null);
                var context = ALC.CreateContext(device, (int*)null);

                ALC.MakeContextCurrent(context);

                var version = AL.Get(ALGetString.Version);
                var vendor = AL.Get(ALGetString.Vendor);
                var renderer = AL.Get(ALGetString.Renderer);
                Console.WriteLine(version);
                Console.WriteLine(vendor);
                Console.WriteLine(renderer);
                Console.ReadKey();

                //Process
                int buffers, source;
                AL.GenBuffer(out buffers);
                AL.GenSource(out source);

                int sampleFreq = 44100;
                double dt = 2 * Math.PI / sampleFreq;
                double amp = 0.5;

                int freq = 440;
                var dataCount = sampleFreq / freq;

                var sinData = new short[dataCount];
                for (int i = 0; i < sinData.Length; ++i) {
                    sinData[i] = (short)(amp * short.MaxValue * Math.Sin(i * dt * freq));
                }
                
                AL.BufferData(buffers, ALFormat.Mono16, sinData, sinData.Length * sizeof(short), sampleFreq);
                AL.Source(source, ALSourcei.Buffer, buffers);
                AL.Source(source, ALSourceb.Looping, true);

                AL.SourcePlay(source);
                Console.ReadKey();

                ///Dispose
                ALC.CloseDevice(device);
            }
        }
        

        


        /*
        ReadOnlySpan<byte> file = File.ReadAllBytes("test.wav");
        int index = 0;
        if (file[index++] != 'R' || file[index++] != 'I' || file[index++] != 'F' || file[index++] != 'F')
        {
            Console.WriteLine("Given file is not in RIFF format");
            return;
        }

        var chunkSize = BinaryPrimitives.ReadInt32LittleEndian(file.Slice(index,  4));
        index += 4;

        if (file[index++] != 'W' || file[index++] != 'A' || file[index++] != 'V' || file[index++] != 'E')
        {
            Console.WriteLine("Given file is not in WAVE format");
            return;
        }

        short numChannels = -1;
        int sampleRate = -1;
        int byteRate = -1;
        short blockAlign = -1;
        short bitsPerSample = -1;
        BufferFormat format = 0;

        var alc = ALContext.GetApi();
        var al = AL.GetApi();
        var device = alc.OpenDevice("");
        if (device == null)
        {
            Console.WriteLine("Could not create device");
            return;
        }

        var context = alc.CreateContext(device, null);
        alc.MakeContextCurrent(context);
        
        al.GetError();
        
        var source = al.GenSource();
        var buffer = al.GenBuffer();
        al.SetSourceProperty(source, SourceBoolean.Looping, true);


        while (index + 4 < file.Length)
        {
            var identifier = "" + (char) file[index++] + (char) file[index++] + (char) file[index++] + (char) file[index++];
            var size = BinaryPrimitives.ReadInt32LittleEndian(file.Slice(index, 4));
            index += 4;
            if (identifier == "fmt ")
            {
                if (size != 16)
                {
                    Console.WriteLine($"Unknown Audio Format with subchunk1 size {size}");
                }
                else
                {
                    var audioFormat = BinaryPrimitives.ReadInt16LittleEndian(file.Slice(index, 2));
                    index += 2;
                    if (audioFormat != 1)
                    {
                        Console.WriteLine($"Unknown Audio Format with ID {audioFormat}");
                    }
                    else
                    {
                        numChannels = BinaryPrimitives.ReadInt16LittleEndian(file.Slice(index, 2));
                        index += 2;
                        sampleRate = BinaryPrimitives.ReadInt32LittleEndian(file.Slice(index, 4));
                        index += 4;
                        byteRate = BinaryPrimitives.ReadInt32LittleEndian(file.Slice(index, 4));
                        index += 4;
                        blockAlign = BinaryPrimitives.ReadInt16LittleEndian(file.Slice(index, 2));
                        index += 2;
                        bitsPerSample = BinaryPrimitives.ReadInt16LittleEndian(file.Slice(index, 2));
                        index += 2;
                
                        if (numChannels == 1)
                        {
                            if (bitsPerSample == 8)
                                format = BufferFormat.Mono8;
                            else if (bitsPerSample == 16)
                                format = BufferFormat.Mono16;
                            else
                            {
                                Console.WriteLine($"Can't Play mono {bitsPerSample} sound.");
                            }
                        }
                        else if (numChannels == 2)
                        {
                            if (bitsPerSample == 8)
                                format = BufferFormat.Stereo8;
                            else if (bitsPerSample == 16)
                                format = BufferFormat.Stereo16;
                            else
                            {
                                Console.WriteLine($"Can't Play stereo {bitsPerSample} sound.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Can't play audio with {numChannels} sound");
                        }
                    }
                }
            } 
            else if (identifier == "data")
            {
                var data = file.Slice(44, size);
                index += size;
                
                fixed(byte* pData = data)
                    al.BufferData(buffer, format, pData, size, sampleRate);
                Console.WriteLine($"Read {size} bytes Data");
            }
            else if (identifier == "JUNK")
            {
                // this exists to align things
                index += size;
            }
            else if (identifier == "iXML")
            {
                var v = file.Slice(index, size);
                var str = Encoding.ASCII.GetString(v);
                Console.WriteLine($"iXML Chunk: {str}");
                index += size;
            }
            else
            {
                Console.WriteLine($"Unknown Section: {identifier}");
                index += size;
            }
        }

        Console.WriteLine
        (
            $"Success. Detected RIFF-WAVE audio file, PCM encoding. {numChannels} Channels, {sampleRate} Sample Rate, {byteRate} Byte Rate, {blockAlign} Block Align, {bitsPerSample} Bits per Sample"
        );

        al.SetSourceProperty(source, SourceInteger.Buffer, buffer);
        al.SourcePlay(source);

        Console.WriteLine("Press Enter to Exit...");
        Console.ReadLine();

        al.SourceStop(source);

        al.DeleteSource(source);
        al.DeleteBuffer(buffer);
        alc.DestroyContext(context);
        alc.CloseDevice(device);
        al.Dispose();
        alc.Dispose();
    }*/
    }
}