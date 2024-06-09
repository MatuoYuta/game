using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    // メニューボタンが押された時に呼び出されるメソッド
    public void MenuButton()
    {
        // Option シーンを読み込む
        SceneManager.LoadScene("Option");
    }
}
