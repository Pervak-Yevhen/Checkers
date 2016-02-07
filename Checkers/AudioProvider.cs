using System;
using IrrKlang;

namespace Vcge.Concrete
{
    public static class AudioProvider
    {
        public static ISoundEngine SoundEngine { get; private set; }

        static AudioProvider()
        {
            SoundEngine = new ISoundEngine(SoundOutputDriver.DirectSound);
            Console.Clear();
        }

        public static ISoundSource GetSource(string filename)
        {
            var file = System.IO.File.ReadAllBytes(filename);
            var source = SoundEngine.AddSoundSourceFromMemory(file, filename);
            source.ForcedStreamingThreshold = file.Length;
            source.StreamMode = StreamMode.Streaming;
            return source;
        }
    }
}
