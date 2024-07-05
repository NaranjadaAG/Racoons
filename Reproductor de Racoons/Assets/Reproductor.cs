using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Losmomos : MonoBehaviour
{
    public VideoPlayer repvideo;
    public List<VideoClip> album_01 = new List<VideoClip>();
    public Transform videos;
    public GameObject VideoObj;

    public Button nextButton;
    public Button prevButton;
    public Slider progressBar;
    public Slider volumeBar;
    public Text durationText;

    private int currentVideoIndex = 0;

    void Start()
    {
        for (int i = 0; i < album_01.Count; i++)
        {
            Instantiate(VideoObj, videos);
            VideoObj.GetComponent<Video>().clip = album_01[i];
        }

        repvideo.clip = album_01[currentVideoIndex];

        nextButton.onClick.AddListener(NextVideo);
        prevButton.onClick.AddListener(PrevVideo);
        progressBar.onValueChanged.AddListener(Seek);
        volumeBar.onValueChanged.AddListener(ChangeVolume);

        volumeBar.value = repvideo.GetDirectAudioVolume(0);
    }

    void Update()
    {
        if (repvideo.isPlaying)
        {
            progressBar.value = (float)(repvideo.time / repvideo.clip.length);
            durationText.text = $"{FormatTime(repvideo.time)} / {FormatTime(repvideo.clip.length)}";
        }
    }

    void NextVideo()
    {
        currentVideoIndex = (currentVideoIndex + 1) % album_01.Count;
        repvideo.clip = album_01[currentVideoIndex];
        repvideo.Play();
    }

    void PrevVideo()
    {
        currentVideoIndex = (currentVideoIndex - 1 + album_01.Count) % album_01.Count;
        repvideo.clip = album_01[currentVideoIndex];
        repvideo.Play();
    }

    void Seek(float value)
    {
        repvideo.time = value * repvideo.clip.length;
    }

    void ChangeVolume(float value)
    {
        repvideo.SetDirectAudioVolume(0, value);
    }

    string FormatTime(double time)
    {
        int minutes = Mathf.FloorToInt((float)time / 60F);
        int seconds = Mathf.FloorToInt((float)time - minutes * 60);
        return string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}


