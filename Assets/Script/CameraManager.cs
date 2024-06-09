using UnityEngine;

// �v���C���[��ǐՂ���J�����̊Ǘ����s���X�N���v�g
public class CameraManager : MonoBehaviour
{
    private Player _player;         // �v���C���[�ւ̎Q��
    private Vector3 _initPos;       // �J�����̏����ʒu

    // Start���\�b�h�͍ŏ��̃t���[���̑O�ɌĂяo�����
    void Start()
    {
        // �V�[��������v���C���[�I�u�W�F�N�g��������
        _player = FindObjectOfType<Player>();

        // �J�����̏����ʒu��ݒ肷��
        _initPos = transform.position;
    }

    // Update���\�b�h�̓t���[�����ƂɌĂяo�����
    void Update()
    {
        // �v���C���[��ǐՂ���
        _FollowPlayer();
    }

    // �v���C���[��ǐՂ��郁�\�b�h
    private void _FollowPlayer()
    {
        // �v���C���[�����݂��邩�`�F�b�N����
        if (_player != null)
        {
            // �v���C���[�̈ʒu���擾����
            float y = _player.transform.position.y;
            float x = _player.transform.position.x;

            // �J�����̈ʒu���v���C���[�̈ʒu�ɒǏ]������
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
