using UnityEngine;

public class WarpGate : MonoBehaviour
{
    // ���[�v��̈ʒu
    public Transform warpDestination;

    // ���[�v�����s����L�[
    public KeyCode warpKey = KeyCode.W;

    // ���[�v�����s����Ώۂ̃I�u�W�F�N�g
    public GameObject targetObject;

    void Update()
    {
        // ���[�v�L�[�������ꂽ���ǂ������m�F
        if (Input.GetKeyDown(warpKey))
        {
            // �^�[�Q�b�g�I�u�W�F�N�g�̑O�Ƀv���C���[�����邩���m�F���ă��[�v���s
            if (IsPlayerInFrontOfGate())
            {
                WarpPlayer();
            }
        }
    }

    // �v���C���[�����[�v�Q�[�g�̑O�ɂ��邩���`�F�b�N���郁�\�b�h
    private bool IsPlayerInFrontOfGate()
    {
        // �^�[�Q�b�g�I�u�W�F�N�g�ƃv���C���[�� Collider2D ���擾
        Collider2D targetCollider = targetObject?.GetComponent<Collider2D>();
        Collider2D playerCollider = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Collider2D>();

        // �^�[�Q�b�g�I�u�W�F�N�g�ƃv���C���[�����݂��Ȃ��ꍇ�͌x�������O�ɏo�͂��� false ��Ԃ�
        if (targetCollider == null || playerCollider == null)
        {
            Debug.LogWarning("Target object or player not found or does not have a Collider2D component");
            return false;
        }

        // �^�[�Q�b�g�I�u�W�F�N�g�̑O�Ƀv���C���[�����邩�ǂ����𕨗��I�ɔ��肵�Č��ʂ�Ԃ�
        return Physics2D.IsTouching(targetCollider, playerCollider);
    }

    // �v���C���[�����[�v��̈ʒu�Ɉړ������郁�\�b�h
    private void WarpPlayer()
    {
        // ���[�v��̈ʒu���ݒ肳��Ă��邩���m�F
        if (warpDestination != null)
        {
            GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

            // �v���C���[�I�u�W�F�N�g�����݂��邩���m�F���ă��[�v���s
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
