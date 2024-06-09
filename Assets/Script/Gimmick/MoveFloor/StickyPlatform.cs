using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // プレイヤーが床の上に入った時に実行されるメソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトがプレイヤーであるか確認し、プレイヤーを床の子オブジェクトにする
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform); // プレイヤーを床の子オブジェクトに設定
        }
    }

    // プレイヤーが床の上から離れた時に実行されるメソッド
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 衝突したオブジェクトがプレイヤーであるか確認し、プレイヤーを床の子オブジェクトから解除する
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null); // プレイヤーの親を解除
            DontDestroyOnLoad(collision.gameObject); // シーン遷移してもプレイヤーが残るように設定
        }
    }
}
