using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI scoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health: 100";
        scoreText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        healthText.text = "Health: ";
        if (playerController.health <= 0)
        {
            playerController.health = 0;
            healthText.color = new Color32(255, 0, 0, 255);
        }
        healthText.text += playerController.health.ToString();
        scoreText.text = $"Score: {playerController.score.ToString()}";
    }
}
