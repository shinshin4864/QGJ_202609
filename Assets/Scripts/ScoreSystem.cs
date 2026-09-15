using UnityEngine;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    float score = 0f;
    float money = 0f;
    TextMeshProUGUI Scores;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void AddScore(float amount)
    {
        score += amount;
        PlayerPrefs.SetFloat("score", score);
    }
}
