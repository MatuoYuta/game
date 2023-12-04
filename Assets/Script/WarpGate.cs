using UnityEngine;

public class WarpGate : MonoBehaviour
{
    // ワープ先の位置
    public Transform warpDestination;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WarpPlayer(other.transform);
        }
    }

    private void WarpPlayer(Transform playerTransform)
    {
        Debug.Log("わーぴ");
        // プレイヤーをワープ先の位置に移動させる
        playerTransform.position = warpDestination.position;
    }
}
