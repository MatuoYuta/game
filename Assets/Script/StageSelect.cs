using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    // ステージ選択画面に移動するメソッド
    public void ChangeButton()
    {
        // 「StageSelect」シーンをロード
        SceneManager.LoadScene("StageSelect");
    }
}
