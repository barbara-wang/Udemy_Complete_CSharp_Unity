using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] float waitToLoad = 4f;
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;

    int numberOfAttackers = 0;
    bool levelTimerFinished = false;

    private void Start()
    {
        if (winLabel)
        {
            winLabel.SetActive(false);
        }

        if (loseLabel)
        {
            loseLabel.SetActive(false);
        }
    }

    public void AttackerSpawned()
    {
        numberOfAttackers++;
    }

    public void AttackerKilled()
    {
        numberOfAttackers--;
        if(numberOfAttackers <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
        }
    }

    IEnumerator HandleWinCondition()
    {
        if (winLabel)
        {
            winLabel.SetActive(true);
        }
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);

        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "Level 1")
        {
            GetComponent<LevelLoader>().LoadNextScene();
        }
        else
        {
            GetComponent<LevelLoader>().LoadMainMenu();
        }
    }

    public void HandleLoseCondition()
    {
        if (loseLabel)
        {
            loseLabel.SetActive(true);
        }
        Time.timeScale = 0;
    }

    public void LevelTimeFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        AttackerSpawner[] attackSpawnerArray = FindObjectsOfType<AttackerSpawner>();
        foreach(AttackerSpawner spawner in attackSpawnerArray)
        {
            spawner.StopSpawning();
        }
    }
}
