using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage2mirai : MonoBehaviour
{
    // ボタンが押されたときに呼び出されるメソッド
    public void change_button()
    {
        // "Stage2mirai"シーンをロードする
        SceneManager.LoadScene("Stage2mirai");
    }
}
