using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    // �v���C���[�����̏�ɓ��������Ɏ��s����郁�\�b�h
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł��邩�m�F���A�v���C���[�����̎q�I�u�W�F�N�g�ɂ���
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(transform); // �v���C���[�����̎q�I�u�W�F�N�g�ɐݒ�
        }
    }

    // �v���C���[�����̏ォ�痣�ꂽ���Ɏ��s����郁�\�b�h
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł��邩�m�F���A�v���C���[�����̎q�I�u�W�F�N�g�����������
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.SetParent(null); // �v���C���[�̐e������
            DontDestroyOnLoad(collision.gameObject); // �V�[���J�ڂ��Ă��v���C���[���c��悤�ɐݒ�
        }
    }
}
