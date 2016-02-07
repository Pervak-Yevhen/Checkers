using IrrKlang;
using Vcge.Concrete;

namespace Checkers
{
    public class Audio
    {
        private readonly ISoundSource _source;
        private ISound _sound;

        public Audio(string filename)
        {
            _source = AudioProvider.GetSource(filename);
        }

        public void Play()
        {
            if (_sound == null) _sound = AudioProvider.SoundEngine.Play2D(_source, false, false, false);
            else
            {
                _sound.Looped = false;
                _sound.Paused = false;
            }
        }

        public void PlayLooped()
        {
            if (_sound == null) _sound = AudioProvider.SoundEngine.Play2D(_source, true, false, false);
            else
            {
                _sound.Looped = true;
                _sound.Paused = false;
            }
        }

        public void Pause()
        {
            _sound.Paused = true;
        }

        public void Stop()
        {
            _sound.PlayPosition = 0;
            _sound.Paused = true;
        }
    }
}
