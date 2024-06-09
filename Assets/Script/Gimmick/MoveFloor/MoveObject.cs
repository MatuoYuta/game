using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("移動経路")]
    public GameObject[] movePoints; // 移動するポイントの配列

    [Header("速さ")]
    public float speed = 1.0f; // 移動速度

    private Rigidbody2D rb; // Rigidbody2D コンポーネント
    private int currentPointIndex = 0; // 現在の目標ポイントのインデックス
    private bool returnPoint = false; // 進行方向が折り返し状態かどうかのフラグ
    private Vector2 oldPosition = Vector2.zero; // 前のフレームの位置
    private Vector2 myVelocity = Vector2.zero; // 移動速度ベクトル

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D コンポーネントを取得
        if (movePoints != null && movePoints.Length > 0 && rb != null)
        {
            rb.position = movePoints[0].transform.position; // 最初のポイントに移動
            oldPosition = rb.position; // 初期位置を保存
        }
    }

    // 移動速度ベクトルを返すメソッド
    public Vector2 GetVelocity()
    {
        return myVelocity;
    }

    private void FixedUpdate()
    {
        if (movePoints != null && movePoints.Length > 1 && rb != null)
        {
            // 通常進行
            if (!returnPoint)
            {
                int nextPointIndex = currentPointIndex + 1;

                // 次のポイントに到達するまで移動
                if (Vector2.Distance(transform.position, movePoints[nextPointIndex].transform.position) > 0.1f)
                {
                    Vector2 nextPosition = Vector2.MoveTowards(transform.position, movePoints[nextPointIndex].transform.position, speed * Time.deltaTime);
                    rb.MovePosition(nextPosition); // 次のポイントへ移動
                }
                else
                {
                    rb.MovePosition(movePoints[nextPointIndex].transform.position); // 次のポイントへ移動
                    currentPointIndex++; // インデックスを増やす

                    // ポイント配列の最後に到達した場合
                    if (currentPointIndex + 1 >= movePoints.Length)
                    {
                        returnPoint = true; // 折り返し状態にする
                    }
                }
            }
            // 折り返し進行
            else
            {
                int nextPointIndex = currentPointIndex - 1;

                // 次のポイントに到達するまで移動
                if (Vector2.Distance(transform.position, movePoints[nextPointIndex].transform.position) > 0.1f)
                {
                    Vector2 nextPosition = Vector2.MoveTowards(transform.position, movePoints[nextPointIndex].transform.position, speed * Time.deltaTime);
                    rb.MovePosition(nextPosition); // 次のポイントへ移動
                }
                else
                {
                    rb.MovePosition(movePoints[nextPointIndex].transform.position); // 次のポイントへ移動
                    currentPointIndex--; // インデックスを減らす

                    // ポイント配列の最初に到達した場合
                    if (currentPointIndex <= 0)
                    {
                        returnPoint = false; // 通常進行状態に戻す
                    }
                }
            }

            // 移動速度ベクトルを更新
            myVelocity = (rb.position - oldPosition) / Time.deltaTime;
            oldPosition = rb.position; // 位置を更新
        }
    }
}
