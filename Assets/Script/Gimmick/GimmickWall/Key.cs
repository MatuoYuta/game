using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // プレイヤーがカギを取得した場合の処理
            Player player = collision.GetComponent<Player>(); // プレイヤーコンポーネントを取得
            if (player != null)
            {
                player.HasKey = true; // プレイヤーの鍵の所持フラグを設定
                Destroy(gameObject); // カギのゲームオブジェクトを削除
                Debug.Log("Player obtained the key."); // デバッグログにメッセージを表示
            }
        }
    }
}
