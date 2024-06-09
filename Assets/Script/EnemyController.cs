using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region// インスペクターで設定する変数
    [Header("移動速度")] public float speed;                 // 移動速度
    [Header("重力")] public float gravity;                    // 重力
    [Header("画面外でも行動する")] public bool nonVisibleAct; // 画面外でも行動するかどうか
    [Header("接触判定")] public EnemyCollisionCheck checkCollision; // 接触判定
    #endregion

    #region// プライベート変数
    private Rigidbody2D rb = null;       // Rigidbody2D コンポーネント
    private SpriteRenderer sr = null;     // SpriteRenderer コンポーネント
    private bool rightTleftF = false;    // 右を向いているか左を向いているかのフラグ
    #endregion

    // Start メソッドは最初のフレームの前に呼び出される
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // Rigidbody2D コンポーネントを取得する
        sr = GetComponent<SpriteRenderer>(); // SpriteRenderer コンポーネントを取得する
    }

    // FixedUpdate メソッドは固定の時間間隔で呼び出される
    void FixedUpdate()
    {
        // 画面内に表示されているか、画面外でも行動が許可されている場合
        if (sr.isVisible || nonVisibleAct)
        {
            // 接触判定があるかどうかをチェックし、あれば移動方向を反転する
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }

            int xVector = -1; // 移動方向を制御する変数
            // 右を向いている場合
            if (rightTleftF)
            {
                xVector = 1; // 移動方向を右にする
                // スプライトを反転させる
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                // 左を向いている場合、スプライトを元に戻す
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Rigidbody2D の速度を設定することで移動を制御する
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            // 画面外にいる場合は Rigidbody2D の速度を0にすることで静止させる
            rb.Sleep();
        }
    }
}
