using UnityEngine;

public class EnemyController : MonoBehaviour
{
    #region// �C���X�y�N�^�[�Őݒ肷��ϐ�
    [Header("�ړ����x")] public float speed;                 // �ړ����x
    [Header("�d��")] public float gravity;                    // �d��
    [Header("��ʊO�ł��s������")] public bool nonVisibleAct; // ��ʊO�ł��s�����邩�ǂ���
    [Header("�ڐG����")] public EnemyCollisionCheck checkCollision; // �ڐG����
    #endregion

    #region// �v���C�x�[�g�ϐ�
    private Rigidbody2D rb = null;       // Rigidbody2D �R���|�[�l���g
    private SpriteRenderer sr = null;     // SpriteRenderer �R���|�[�l���g
    private bool rightTleftF = false;    // �E�������Ă��邩���������Ă��邩�̃t���O
    #endregion

    // Start ���\�b�h�͍ŏ��̃t���[���̑O�ɌĂяo�����
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();     // Rigidbody2D �R���|�[�l���g���擾����
        sr = GetComponent<SpriteRenderer>(); // SpriteRenderer �R���|�[�l���g���擾����
    }

    // FixedUpdate ���\�b�h�͌Œ�̎��ԊԊu�ŌĂяo�����
    void FixedUpdate()
    {
        // ��ʓ��ɕ\������Ă��邩�A��ʊO�ł��s����������Ă���ꍇ
        if (sr.isVisible || nonVisibleAct)
        {
            // �ڐG���肪���邩�ǂ������`�F�b�N���A����Έړ������𔽓]����
            if (checkCollision.isOn)
            {
                rightTleftF = !rightTleftF;
            }

            int xVector = -1; // �ړ������𐧌䂷��ϐ�
            // �E�������Ă���ꍇ
            if (rightTleftF)
            {
                xVector = 1; // �ړ��������E�ɂ���
                // �X�v���C�g�𔽓]������
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                // ���������Ă���ꍇ�A�X�v���C�g�����ɖ߂�
                transform.localScale = new Vector3(1, 1, 1);
            }

            // Rigidbody2D �̑��x��ݒ肷�邱�Ƃňړ��𐧌䂷��
            rb.velocity = new Vector2(xVector * speed, -gravity);
        }
        else
        {
            // ��ʊO�ɂ���ꍇ�� Rigidbody2D �̑��x��0�ɂ��邱�ƂŐÎ~������
            rb.Sleep();
        }
    }
}
