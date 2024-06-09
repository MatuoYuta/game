using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetyousei : MonoBehaviour
{
    // メニューオブジェクトを参照するための変数
    [SerializeField] GameObject MenuObject;
    [SerializeField] GameObject MenuObject2;
    [SerializeField] GameObject MenuObject3;
    //[SerializeField] GameObject MenuObject4;

    // メニューの状態を管理する変数
    private bool isMenuActive;

    // ゲーム開始時の処理
    void Start()
    {
        // 一部メニューオブジェクトを非表示に設定
        MenuObject2.SetActive(false);
        MenuObject3.SetActive(false);
        //MenuObject4.SetActive(false);
    }

    // 毎フレームの更新処理
    void Update()
    {
        // 'G'キーが押された時にメニューの切り替えを行う
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleMenu();
            Debug.Log(isMenuActive);
        }
    }

    // メニューの表示・非表示を切り替えるメソッド
    void ToggleMenu()
    {
        // 現在のメニューの状態に応じて処理を分岐
        if (isMenuActive)
        {
            // メニューがアクティブな場合は、ゲームを再開
            Time.timeScale = 1f;

            // メニューオブジェクトを表示
            MenuObject.SetActive(true);
            MenuObject2.SetActive(false);
            MenuObject3.SetActive(false);
            //MenuObject4.SetActive(false);

            // マウスカーソルを表示にし、位置固定解除
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            isMenuActive = false;
        }
        else
        {
            // メニューが非アクティブな場合は、ゲームを停止
            //Time.timeScale = 0f;

            // メニューオブジェクトを非表示
            MenuObject.SetActive(false);
            MenuObject2.SetActive(true);
            MenuObject3.SetActive(true);
            //MenuObject4.SetActive(true);

            // マウスカーソルを非表示にし、位置を固定
            /*Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/

            isMenuActive = true;
        }
    }
}
