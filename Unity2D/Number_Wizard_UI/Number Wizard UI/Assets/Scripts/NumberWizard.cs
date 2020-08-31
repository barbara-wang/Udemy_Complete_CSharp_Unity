using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] TextMeshProUGUI guessText;

    int guess = 500;

    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        //guess = (max + min) / 2;
        //guessText.text = guess.ToString();

        NextGuess();
    }

    public void OnPressHigher()
    {
        min = guess + 1;
        NextGuess();
    }

    public void OnPressLower()
    {
        max = guess - 1;
        NextGuess();
    }

    void NextGuess()
    {
        //guess = (max + min) / 2;
        guess = Random.Range(min, max + 1);
        guessText.text = guess.ToString();
    }
}
