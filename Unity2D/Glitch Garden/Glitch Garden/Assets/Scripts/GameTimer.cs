using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [Tooltip("Our level timer in SECONDS")]
    [SerializeField] float levelTime = 10f;

    bool triggeredLevelFinished = false;

    // Update is called once per frame
    void Update()
    {
        if(triggeredLevelFinished) { return; }

        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool finished = (Time.timeSinceLevelLoad >= levelTime);
        if(finished)
        {
            FindObjectOfType<LevelController>().LevelTimeFinished();
            triggeredLevelFinished = true;
        }
    }
}
