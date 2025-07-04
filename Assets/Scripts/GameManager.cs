using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthLeftText;
    public TextMeshProUGUI scoreNewText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthLeftText.text = "100";
        scoreNewText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        PlayerController playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        if (playerController.health <= 0)
        {
            playerController.health = 0;
            healthLeftText.color = new Color32(255, 0, 0, 255);
        }
        healthLeftText.text = playerController.health.ToString();
        scoreNewText.text = playerController.score.ToString();
    }
}
