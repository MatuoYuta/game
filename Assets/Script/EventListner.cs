using UnityEngine;

public class EventListner : MonoBehaviour
{
    // プレイヤーに接近したときに呼ばれるイベントハンドラ
    public void CheckEventHandler(Collider2D collider)
    {
        // 衝突したオブジェクトがプレイヤーである場合
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("近づいた");

            // Rigidbody2D コンポーネントの物理挙動を動的に変更する
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // 衝突したときに呼ばれるイベントハンドラ
    public void HitEventHandler(Collider2D collider)
    {
        Debug.Log("当たった");
    }
}
