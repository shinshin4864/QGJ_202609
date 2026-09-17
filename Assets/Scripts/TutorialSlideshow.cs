using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorialSlideshow : MonoBehaviour
{
    [SerializeField] private Sprite[] SlideshowImages; // 背景画像の配列
    [SerializeField] private Image TSphoto; 
    [SerializeField] private float slideDuration = 2f; // 画像の表示時間
    private void Start()
    {
        //TSphoto = GetComponent<Image>();
        //StartCoroutine(slideshow());
        
    }
    public IEnumerator Slideshow()
    {
        for (int i = 0; i < SlideshowImages.Length; i++)
        {
            TSphoto.sprite = SlideshowImages[i]; // 画像を変更
            yield return new WaitForSeconds(slideDuration); // 画像の表示時間
        }
        // スライドショーが終了したら、タイトル画面に戻る
        GameObject.Find("Canvas").GetComponent<Starting>().ChangeStartMode();
    }
}

