using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;

    public int score;

    public PlayerController playerController;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        healthText.text = "Health: 100";
        scoreText.text = "Score: 0";
        isGameActive = true;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: ";
        if (playerController.health <= 0)
        {
            GameOver();
        }
        healthText.text += playerController.health.ToString();
        scoreText.text = $"Score: {score.ToString()}";
    }

    private void GameOver()
    {
        isGameActive = false;
        playerController.health = 0;
        healthText.color = new Color32(255, 0, 0, 255);
        gameOverText.gameObject.SetActive(true);
        playerController.SitDown();
    }

    public void UpdateScore(int addScore = 10)
    {
        if (isGameActive)
        {
            score += addScore;
        }
    }
}
