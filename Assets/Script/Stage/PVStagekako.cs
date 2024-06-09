using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PVStagekako : MonoBehaviour
{
    // ボタンが押された時に呼ばれるメソッド
    public void change_button()
    {
        // シーンを "PVstagekako" に変更する
        SceneManager.LoadScene("PVstagekako");
    }
}
