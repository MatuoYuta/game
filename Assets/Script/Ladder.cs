using UnityEngine;

public class Ladder : MonoBehaviour
{
    // ����Collider�Ƃ̏Փ˂����o�����Ƃ��ɌĂ΂�郁�\�b�h
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �Փ˂����I�u�W�F�N�g���v���C���[�ł���ꍇ
        if (collision.CompareTag("Player"))
        {
            // �v���C���[���͂����ɓo���Ă��邱�Ƃ������t���O��true�ɂ���
            collision.GetComponent<Player>().IsLadder = true;
        }
        else
        {
            // �v���C���[���͂����ɓo���Ă��Ȃ����Ƃ������t���O��false�ɂ���
            collision.GetComponent<Player>().IsLadder = false;
        }
    }
}
