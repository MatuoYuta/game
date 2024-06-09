using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    public UnityEvent<Collider2D> onColliderEnter; // コライダーがトリガーに入ったときに呼ばれるイベント

    // 2D コライダーがトリガー内に侵入したときに呼び出されるメソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // トリガーに入った時のイベントを実行
        onColliderEnter.Invoke(collision);
    }
}
