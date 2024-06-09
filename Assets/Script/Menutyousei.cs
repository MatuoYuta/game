using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    // メニューオブジェクトへの参照
    [SerializeField] GameObject menuObject;

    // メニューの表示状態を管理するフラグ
    bool menuVisible;

    // Update is called once per frame
    void Update()
    {
        // メニューが非表示の場合
        if (!menuVisible)
        {
            // キャンセルボタンが押されたらメニューを表示
            if (Input.GetButtonDown("Cancel"))
            {
                menuObject.SetActive(true);
                menuVisible = true;

                // ゲームを停止
                Time.timeScale = 0f;

                // マウスカーソルを表示し、位置固定解除
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            // メニューが表示されている場合
            // キャンセルボタンが押されたらメニューを非表示にする
            if (Input.GetButtonDown("Cancel"))
            {
                menuObject.SetActive(false);
                menuVisible = false;

                // ゲームを再開
                Time.timeScale = 1f;

                // マウスカーソルを非表示にし、位置を固定
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
