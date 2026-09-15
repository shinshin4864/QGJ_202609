using UnityEngine;
using TMPro;

public class ShowScore : MonoBehaviour
{
    public bool show_score;
    [SerializeField] private TextMeshProUGUI scoreTextField;

    void Update()
    {
        if (scoreTextField == null)
        {
            scoreTextField = GetComponent<TextMeshProUGUI>();
        }

        if (scoreTextField != null)
        {
            float score = PlayerPrefs.GetFloat("score", 0f);
            float money = PlayerPrefs.GetFloat("money", 0f);
            if (show_score == false)
            {
                scoreTextField.text = "所持金: " + money;
            }
            else
            {
            scoreTextField.text = "スコア: " + score + "\n所持金: " + money;
            }
        }
        else
        {
            Debug.LogError("ScoreTextFieldが割り当てられていません！");
        }
    }
}