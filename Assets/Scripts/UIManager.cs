using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    // TODO Game Over Scene
    
    [SerializeField] TMP_Text scoreText;
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Player player;
    [SerializeField] private Button restartButton;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.enabled = true;
        gameOverScreen.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.IsDie)
        {
            gameOverScreen.SetActive(true);
            scoreText.enabled = false;
        }
    }
}
