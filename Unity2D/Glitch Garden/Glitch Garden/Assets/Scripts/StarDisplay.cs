﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour
{
    [SerializeField] int stars = 100;

    Text starText;

    // Start is called before the first frame update
    void Start()
    {
        starText = GetComponent<Text>();
        UpdateDisplay();
    }

    public bool HaveEnoughStars(int amount)
    {
        return amount <= stars;
    }

    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }

    public void AddStars(int amount)
    {
        stars += amount;
        starText.text = stars.ToString();
    }

    public void SpendStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            starText.text = stars.ToString();
        }
    }
}
