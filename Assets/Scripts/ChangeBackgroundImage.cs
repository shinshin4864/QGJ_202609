using UnityEngine;
using UnityEngine.UI;

public class ChangeBackgroundImage : MonoBehaviour
{
    [SerializeField] private Sprite[] backgroundImages; // 背景画像の配列
    [SerializeField] private Image BGphoto; // 背景画像を表示するSpriteRenderer
    bool is_clear = Ending.is_clear;

    void Start()
    {
        BGphoto = GetComponent<Image>();
        if (is_clear)
        {
            // ゲームクリアの場合、背景画像を変更
           BGphoto.sprite = backgroundImages[1]; // 1番目の画像に変更
        }
        else
        {
            // ゲームオーバーの場合、背景画像を変更
            BGphoto.sprite = backgroundImages[0]; // 0番目の画像に変更
        }
    }
}

