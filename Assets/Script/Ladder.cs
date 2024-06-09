using UnityEngine;

public class Ladder : MonoBehaviour
{
    // 他のColliderとの衝突を検出したときに呼ばれるメソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 衝突したオブジェクトがプレイヤーである場合
        if (collision.CompareTag("Player"))
        {
            // プレイヤーがはしごに登っていることを示すフラグをtrueにする
            collision.GetComponent<Player>().IsLadder = true;
        }
        else
        {
            // プレイヤーがはしごに登っていないことを示すフラグをfalseにする
            collision.GetComponent<Player>().IsLadder = false;
        }
    }
}
