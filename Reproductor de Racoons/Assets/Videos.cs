using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    public VideoPlayer _VideoPlayer;
    public VideoClip clip;
    public TMP_Text clipName;


    void Start()
    {
        try
        {
            clipName.text = clip.name;
            _VideoPlayer = FindObjectOfType<VideoPlayer>();
        }
        catch
        {
            Destroy(gameObject);
        }
    }
    public void playVideo()
    {
        _VideoPlayer.clip = clip;
        _VideoPlayer.Play();

    }
}