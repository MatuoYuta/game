using UnityEngine;

public class WarpGate : MonoBehaviour
{
    // ワープ先の位置
    public Transform warpDestination;

    // ワープを実行するキー
    public KeyCode warpKey = KeyCode.W;

    // ワープを実行する対象のオブジェクト
    public GameObject targetObject;

    void Update()
    {
        // ワープキーが押されたかどうかを確認
        if (Input.GetKeyDown(warpKey))
        {
            // ターゲットオブジェクトの前にプレイヤーがいるかを確認してワープ実行
            if (IsPlayerInFrontOfGate())
            {
                WarpPlayer();
            }
        }
    }

    // プレイヤーがワープゲートの前にいるかをチェックするメソッド
    private bool IsPlayerInFrontOfGate()
    {
        // ターゲットオブジェクトとプレイヤーの Collider2D を取得
        Collider2D targetCollider = targetObject?.GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Collider2D>();

        // ターゲットオブジェクトとプレイヤーが存在しない場合は警告をログに出力して false を返す
        if (targetCollider == null || playerCollider == null)
        {
            Debug.LogWarning("Target object or player not found or does not have a Collider2D component");
            return false;
        }

        // ターゲットオブジェクトの前にプレイヤーがいるかどうかを物理的に判定して結果を返す
        return Physics2D.IsTouching(targetCollider, playerCollider);
    }

    // プレイヤーをワープ先の位置に移動させるメソッド
    private void WarpPlayer()
    {
        // ワープ先の位置が設定されているかを確認
        if (warpDestination != null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // プレイヤーオブジェクトが存在するかを確認してワープ実行
            if (playerObject != null)
            {
                Transform playerTransform = playerObject.transform;
                playerTransform.position = warpDestination.position;
                Debug.Log("Player warped");
            }
            else
            {
                Debug.LogWarning("Player not found");
            }
        }
        else
        {
            Debug.LogWarning("Warp destination not set");
        }
    }
}
