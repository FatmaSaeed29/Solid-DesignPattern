public interface IAudioPlayer
    {
        void PlayAudio();
        void LoadAudio(string filePath);
    }

    public interface IVideoPlayer
    {
        void PlayVideo();
        void DisplaySubtitles();
        void LoadVideo(string filePath);
    }

    public class AudioPlayer : IAudioPlayer
    {
        public void PlayAudio()
        {
            // Implementation to play audio
        }

        public void LoadAudio(string filePath)
        {
            // Implementation to load audio file
        }
    }

    public class VideoPlayer : IVideoPlayer
    {
        public void PlayVideo()
        {
            // Implementation to play video
        }

        public void DisplaySubtitles()
        {
            // Implementation to display subtitles
        }

        public void LoadVideo(string filePath)
        {
            // Implementation to load video file
        }
    }
