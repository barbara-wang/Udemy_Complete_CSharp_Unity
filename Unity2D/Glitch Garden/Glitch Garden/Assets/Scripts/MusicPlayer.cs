using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        if (audioSource)
        {
            audioSource.volume = PlayerPrefsController.GetMasterVolume();
        }
    }

    public void SetVolume(float volume)
    {
        if(audioSource)
        {
            audioSource.volume = volume;
        }
    }
}
