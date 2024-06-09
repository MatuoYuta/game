using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // �v���C���[���J�M���擾�����ꍇ�̏���
            Player player = collision.GetComponent<Player>(); // �v���C���[�R���|�[�l���g���擾
            if (player != null)
            {
                player.HasKey = true; // �v���C���[�̌��̏����t���O��ݒ�
                Destroy(gameObject); // �J�M�̃Q�[���I�u�W�F�N�g���폜
                Debug.Log("Player obtained the key."); // �f�o�b�O���O�Ƀ��b�Z�[�W��\��
            }
        }
    }
}
