using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI healthLeftText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthLeftText.text = "100";
    }

    // Update is called once per frame
    void Update()
    {
        healthLeftText.text = GameObject.Find("Player").GetComponent<PlayerController>().health.ToString();   
    }
}
