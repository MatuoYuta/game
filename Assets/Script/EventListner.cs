using UnityEngine;

public class EventListner : MonoBehaviour
{
    // �v���C���[�ɐڋ߂����Ƃ��ɌĂ΂��C�x���g�n���h��
    public void CheckEventHandler(Collider2D collider)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ
        if (collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("�߂Â���");

            // Rigidbody2D �R���|�[�l���g�̕��������𓮓I�ɕύX����
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    // �Փ˂����Ƃ��ɌĂ΂��C�x���g�n���h��
    public void HitEventHandler(Collider2D collider)
    {
        Debug.Log("��������");
    }
}
