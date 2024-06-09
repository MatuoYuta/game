using UnityEngine;

// �G��ǂƂ̐ڐG�����m����X�N���v�g
public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>
    /// ������ɓG���ǂ����邩�ǂ����������t���O
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string groundTag = "floor";   // �n�ʂ̃^�O
    private string enemyTag = "Enemy";    // �G�̃^�O

    // �ڐG���胁�\�b�h
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ڐG�����I�u�W�F�N�g���n�ʂ܂��͓G�ł���ꍇ
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            // ������ɓG���ǂ����邱�Ƃ������t���O��true�ɂ���
            isOn = true;
        }
    }

    // �ڐG����������\�b�h
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ڐG���Ă����I�u�W�F�N�g���n�ʂ܂��͓G�ł���ꍇ
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            // ������ɓG���ǂ����邱�Ƃ������t���O��false�ɂ���
            isOn = false;
        }
    }
}
