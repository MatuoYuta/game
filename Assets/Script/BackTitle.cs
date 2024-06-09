using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{
    // 「戻る」ボタンが押された時に呼ばれるメソッド
    public void Back_button()
    {
        // 「Title」シーンをロード
        SceneManager.LoadScene("Title");
    }
}
