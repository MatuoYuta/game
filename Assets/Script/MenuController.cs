using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuObject; // メニューオブジェクトの参照

    // Start メソッドは最初のフレームの前に呼び出される
    void Start()
    {
        // 最初はメニューを非表示にする
        menuObject.SetActive(false);
    }

    // メニューの表示・非表示を切り替えるメソッド
    public void ToggleMenu()
    {
        // メニューの表示状態を反転させる
        menuObject.SetActive(!menuObject.activeSelf);
    }
}
