using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetyousei : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;
    [SerializeField] GameObject MenuObject2;

    bool menuzyoutai;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            メニューの切り替え();
        }
    }

    void メニューの切り替え()
    {
        menuzyoutai = !menuzyoutai;

        if (menuzyoutai)
        {
            // メニューを表示
            MenuObject.SetActive(true);

            MenuObject2.SetActive(false);
            // マウスカーソルを表示にし、位置固定解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // メニューを非表示
            MenuObject.SetActive(false);

            MenuObject2.SetActive(true);

            // マウスカーソルを非表示にし、位置を固定
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

