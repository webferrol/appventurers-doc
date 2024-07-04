using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

namespace YoutubePlayer.Samples.PlayVideo
{
    [RequireComponent(typeof(Button))]
    public class PlayVideoButton : MonoBehaviour
    {
        public VideoPlayer videoPlayer;
        private Button m_Button;

        void Awake()
        {
            m_Button = GetComponent<Button>();
            m_Button.interactable = videoPlayer.isPrepared;
            videoPlayer.prepareCompleted += VideoPlayerOnPrepareCompleted;
            m_Button.onClick.AddListener(TogglePlayPause); // Add listener for button click
        }

        void VideoPlayerOnPrepareCompleted(VideoPlayer source)
        {
            m_Button.interactable = videoPlayer.isPrepared;
        }

        void TogglePlayPause()
        {
            if (videoPlayer.isPlaying)
            {
                videoPlayer.Pause();
            }
            else
            {
                videoPlayer.Play();
            }
        }

        void OnDestroy()
        {
            videoPlayer.prepareCompleted -= VideoPlayerOnPrepareCompleted;
            m_Button.onClick.RemoveListener(TogglePlayPause); // Remove listener on destroy
        }
    }
}
