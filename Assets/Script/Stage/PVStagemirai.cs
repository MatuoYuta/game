using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PVStagemirai : MonoBehaviour
{
    // ボタンが押された時に呼ばれるメソッド
    public void change_button()
    {
        // シーンを "PVStagemiraoi" に変更する
        SceneManager.LoadScene("PVStagemiraoi");
    }
}
