using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim1; // ドアのアニメーター
    private Rigidbody2D rigid; // Rigidbody2D コンポーネント
    private BoxCollider2D col; // BoxCollider2D コンポーネント

    float x; // ドアの x 座標
    float y; // ドアの y 座標
    float waitsecond = 0.05f; // 待機秒数

    bool open = false; // ドアが開いているかどうかを示すフラグ
    [SerializeField] float testY; // ドアが開く y 座標の上限

    private void Start()
    {
        x = transform.position.x; // 初期 x 座標を設定
        y = transform.position.y; // 初期 y 座標を設定
    }

    void Update()
    {
        if (open)
        {
            // ドアが開いている場合の処理
            if (transform.position.y > testY)
            {
                open = false; // ドアが目標の高さに達したら開閉を停止
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // プレイヤーが鍵を持っているかどうかをチェックし、鍵を持っていればドアを開ける
        if (collision.GetComponent<Player>()?.HasKey == true)
        {
            StartCoroutine("DoorUp"); // ドアを開くコルーチンを実行
            Debug.Log("Door opened!"); // ドアが開いたことをログで表示
            collision.GetComponent<Player>().HasKey = false; // プレイヤーの鍵の所持フラグをリセット
        }
        else
        {
            // プレイヤーが鍵を持っていない場合の処理
            // Debug.Log("Player does not have the key.");
        }
    }

    IEnumerator DoorUp()
    {
        open = true; // ドアが開く状態に設定
        for (int i = 0; i < 5; i++) // ドアを徐々に上昇させる処理
        {
            transform.position = new Vector2(x, y + i); // ドアの位置を上に移動
            yield return new WaitForSeconds(0.1f); // 0.1秒待機
        }
    }
}
