namespace Interface_Segregation_Principle
{
    public interface IAudioPlayer
    {
        void PlayAudio();
    }
    public interface IVideoPlayer
    {
        void PlayVideo();
    }
    public interface IAudioLoader
    {
        public void LoadAudio(string filePath);
    }
    public interface IVideoLoader
    {
        public void LoadVideo(string filePath);
    }
    public interface ISubtitlesDisplayer
    {
        void DisplaySubtitles();
    }

    public class AudioPlayer : IAudioPlayer, IAudioLoader
    {
        public void PlayAudio()
        {
            // Code to play audio
        }

        public void LoadAudio(string filePath)
        {
            // Code to load audio file
        }
    }

    public class VideoPlayer : IVideoPlayer, ISubtitlesDisplayer, IVideoLoader
    {
        public void PlayVideo()
        {
            // Code to play video
        }

        public void DisplaySubtitles()
        {
            // Code to display subtitles
        }

        public void LoadVideo(string filePath)
        {
            // Code to load video file
        }
    }
}
