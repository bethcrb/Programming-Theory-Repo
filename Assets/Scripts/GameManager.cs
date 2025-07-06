using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGameActive { get; private set; } // ENCAPSULATION

    public AudioClip gameOverSound;

    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    private AudioSource gameAudio;

    private PlayerController playerController;

    private int score;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        healthText.text = "Health: 100";
        scoreText.text = "Score: 0";
        isGameActive = true;
        gameAudio = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = "Health: ";
        if (playerController.health <= 0)
        {
            GameOver(); // ABSTRACTION
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
        gameAudio.PlayOneShot(gameOverSound, 1.0f);
    }

    public void UpdateScore(int addScore = 10)
    {
        if (isGameActive)
        {
            score += addScore;
        }
    }
}
