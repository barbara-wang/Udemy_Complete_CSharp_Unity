using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] float LevelLoadDelay = 2f;
    [SerializeField] float LevelLoadSlowMoFactor = 0.2f;

    private void OnTriggerEnter2D(Collider2D othercollider)
    {
        StartCoroutine(LoadNextLevel());
    }
    
    IEnumerator LoadNextLevel()
    {
        Time.timeScale = LevelLoadSlowMoFactor;

        yield return new WaitForSecondsRealtime(LevelLoadDelay);

        Time.timeScale = 1f;
        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
}
