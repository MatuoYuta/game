using UnityEngine;

public class HitFade : MonoBehaviour
{
    public GameObject targetObj; // �t�F�[�h�������s���I�u�W�F�N�g

    // ����Collider�Ƃ̏Փ˂����o�����Ƃ��ɌĂ΂�郁�\�b�h
    private void OnTriggerEnter2D(Collider2D other)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ
        if (other.gameObject.tag == "Player")
        {
            // �t�F�[�h�������s���I�u�W�F�N�g��Fade�R���|�[�l���g�Ƀt�F�[�h�A�E�g�������J�n������悤�w������
            targetObj.GetComponent<Fade>().Fadeout();
        }
    }
}
