using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextManipulator : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + gameManager.Score;
    }
}
