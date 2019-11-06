using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class VideoScreen : MonoBehaviour {

    static public VideoScreen S;
    public Transform target;
    public VideoPlayer videoPlayer;
    //public SimplePlayback simplePlayback;
    //public InputField inputField;
    public string URL = "https://www.youtube.com/watch?v=ZybDjf5-wHw";

    void Awake()
    {
        S = this;
    }

    

	public void Pause()
    {
        videoPlayer.Pause();
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void AttachURL()
    {
        //string[] data = inputField.text.Split(new string[] { "v=" }, System.StringSplitOptions.None);
        //Debug.Log(data[1]);
    }
}
