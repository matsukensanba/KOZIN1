using UnityEngine;
using UnityEngine.SceneManagement; // これがシーン切り替えの魔法の言葉です

public class TitleManager : MonoBehaviour
{
    // この関数をボタンに登録します
    public void StartGame()
    {
        // 遷移先のシーン名を正確に（大文字小文字も区別します）
        SceneManager.LoadScene("GameScene");
    }
}