using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthText.text = "Health: 100";
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = $"Health: {GameObject.Find("Player").GetComponent<PlayerController>().health}";   
    }
}
