using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class Starting : MonoBehaviour
{
    //難易度の設定(1=easy,2=normal,3=hard)
    public static int difficulty;

    private TextMeshProUGUI TextMeshPro;
    private AudioSource audiosSource;
    public AudioClip titleBGM;

    [SerializeField] private GameObject Slideshow;

    [SerializeField] private GameObject fourth;

    [Header("UI要素の参照")]
    [SerializeField] private Button firstButton;    // 1番上のボタン（切替用）
    [SerializeField] private Button secondButton1;   // 2番目のボタン
    [SerializeField] private Button thirdButton2;    // 3番目のボタン
    [SerializeField] private Button forthButton;     // 4番目のボタン

    [SerializeField] private TextMeshProUGUI firstButtonText;
    [SerializeField] private TextMeshProUGUI secondButtonText;
    [SerializeField] private TextMeshProUGUI thirdButtonText;
    [SerializeField] private TextMeshProUGUI forthButtonText;

    private int currentMode = 0;
    private List<GameObject> TitleObjects = new List<GameObject>();

    private void RegistTitleObjects()
    {
        GameObject[] titleObjects = GameObject.FindGameObjectsWithTag("Title");
        foreach (GameObject obj in titleObjects)
        {
            TitleObjects.Add(obj);
        }
    }

    private void Start()
    {
        RegistTitleObjects();

        // ボタンがクリックされたときの処理をコード側で登録
        firstButton.onClick.AddListener(OnfirstButtonClicked);
        secondButton1.onClick.AddListener(OnsecondButtonClicked);
        thirdButton2.onClick.AddListener(OnthirdButtonClicked);
        forthButton.onClick.AddListener(OnforthButtonClicked);

        // 最初の状態をセット
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentMode == 0)
        {
            firstButtonText.text = "スタート";
            secondButtonText.text = "チュートリアル";
            thirdButtonText.text = "終了";
            fourth.SetActive(false);
        }
        else if (currentMode == 1)
        {
            firstButtonText.text = "イージー";
            secondButtonText.text = "ノーマル";
            thirdButtonText.text = "ハード";
            forthButtonText.text = "戻る";
            fourth.SetActive(true);
        }
    }

    // 1番上のボタンを押したとき（モード切替）
    private void OnfirstButtonClicked()
    {
        if (currentMode == 0)
        {
            currentMode = (currentMode + 1) % 2;
        }
        else
        {
            difficulty = 1;
            SceneManager.LoadScene("MainScene");
        }

        Debug.Log("モード切り替え: " + currentMode);
        UpdateUI();
    }

    // 2番目のボタンを押したときの実装内容
    private void OnsecondButtonClicked()
    {
        if (currentMode == 0)
        {
            ChangeTutorialMode();
        }
        else if (currentMode == 1)
        {
            difficulty = 2;
            SceneManager.LoadScene("MainScene");
        }
    }

    // 3番目のボタンを押したときの実装内容
    private void OnthirdButtonClicked()
    {
        if (currentMode == 0)
        {
            QuitGame();
        }
        else if (currentMode == 1)
        {
            difficulty = 3;
            SceneManager.LoadScene("MainScene");
        }
    }

    private void OnforthButtonClicked()
    {
        if (currentMode == 0)
        {
            return;
        }

        currentMode = 0;
        UpdateUI();
    }

    private void ChangeTutorialMode()
    {
        foreach (GameObject obj in TitleObjects)
        {
            obj.SetActive(false);
        }

        //Slideshow = GameObject.Find("Slideshow");
        Slideshow.SetActive(true);
        TutorialSlideshow tutorialSlideshow = Slideshow.GetComponent<TutorialSlideshow>();
        tutorialSlideshow.StartCoroutine(tutorialSlideshow.Slideshow());
    }
    public void ChangeStartMode()
    {
        foreach (GameObject obj in TitleObjects)
        {
            obj.SetActive(true);
        }
        Slideshow.SetActive(false);
    }
    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // エディタ実行時は停止
#else
        Application.Quit();
#endif
    }
}

