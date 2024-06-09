using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PVStage : MonoBehaviour
{
    // ボタンが押された時に呼ばれるメソッド
    public void change_button()
    {
        // シーンを"PVStage"に変更する
        SceneManager.LoadScene("PVStage");
    }
}
