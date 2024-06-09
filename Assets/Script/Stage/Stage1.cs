using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    // ボタンが押されたときにステージを変更するメソッド
    public void change_button()
    {
        // "stage01"シーンをロード
        SceneManager.LoadScene("stage01");

        // ゲームの時間を通常の速度に戻す
        Time.timeScale = 1f;
    }
}
