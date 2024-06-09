using UnityEngine;

public class HitFade : MonoBehaviour
{
    public GameObject targetObj; // フェード処理を行うオブジェクト

    // 他のColliderとの衝突を検出したときに呼ばれるメソッド
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトがプレイヤーである場合
        if (other.gameObject.tag == "Player")
        {
            // フェード処理を行うオブジェクトのFadeコンポーネントにフェードアウト処理を開始させるよう指示する
            targetObj.GetComponent<Fade>().Fadeout();
        }
    }
}
