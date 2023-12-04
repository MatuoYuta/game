using UnityEngine;

public class WarpGate : MonoBehaviour
{
    // ���[�v��̈ʒu
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
        Debug.Log("��[��");
        // �v���C���[�����[�v��̈ʒu�Ɉړ�������
        playerTransform.position = warpDestination.position;
    }
}
