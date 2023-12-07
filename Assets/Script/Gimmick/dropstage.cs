using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropstage : MonoBehaviour
{
    public float fallDelay = 2f; // 落ちるまでの待機時間

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay); // 落ちるまでの待機時間後にFallメソッドを呼び出す
        }
    }

    private void Fall()
    {
        // Rigidbodyを取得し、重力を有効にして床を落とす
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }
}
