using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    float volume;
    bool getMasterVolume = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefsController.SetMasterVolume(0.4f); 
    }

    // Update is called once per frame
    void Update()
    {
        if(!getMasterVolume)
        {
            volume = PlayerPrefsController.GetMasterVolume();
            Debug.Log("Master volume = " + volume);
            getMasterVolume = true;
        }
        
    }
}
