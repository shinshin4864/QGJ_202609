using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 
using UnityEngine.SceneManagement; 
using TMPro;



public enum StructureType
{
    None,      // 何もしない
    Restart,  // タイトル画面,
    QuitApp,     // アプリを終了
}

public class Ending : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ResultText;
    private AudioSource audioSource;
    [SerializeField] private AudioClip GameOverBGM;
    [SerializeField] private AudioClip GameClearBGM;
    //gameoverかgameclearかを判定するフラグ
    public static bool is_clear = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (is_clear)
        {
            ResultText.text = "GameClear!";
            audioSource.generator = GameClearBGM;
            audioSource.Play();
            
        }
        else
        {
            ResultText.text = "Game Over";
            audioSource.generator = GameOverBGM;
            audioSource.Play();
        }
        GameObject Restart = GameObject.Find("Restart");
        Button RestartBTN = Restart.GetComponent<Button>();
        RestartBTN.onClick.AddListener(ClickRestartBTN);

        GameObject QuitApp = GameObject.Find("QuitApp");
        Button QuitAppBTN = QuitApp.GetComponent<Button>();
        QuitAppBTN.onClick.AddListener(ClickQuitAppBTN);
    }

    private void ClickRestartBTN()
    {
        SceneManager.LoadScene("Start");
    }

    private void ClickQuitAppBTN()
    {
        QuitGame();
    }

    // アプリ終了処理（エディタ対策込み）
    void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ実行時は停止
#else
        Application.Quit(); // 本番ビルド時はアプリ終了
#endif
    }
}
