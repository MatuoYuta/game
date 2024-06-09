using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2 : MonoBehaviour
{
    // ボタンが押されたときに呼び出されるメソッド
    public void change_button()
    {
        // "Stage2"シーンをロードする
        SceneManager.LoadScene("Stage2");
    }
}
