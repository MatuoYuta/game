using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject menuObject; // ���j���[�I�u�W�F�N�g�̎Q��

    // Start ���\�b�h�͍ŏ��̃t���[���̑O�ɌĂяo�����
    void Start()
    {
        // �ŏ��̓��j���[���\���ɂ���
        menuObject.SetActive(false);
    }

    // ���j���[�̕\���E��\����؂�ւ��郁�\�b�h
    public void ToggleMenu()
    {
        // ���j���[�̕\����Ԃ𔽓]������
        menuObject.SetActive(!menuObject.activeSelf);
    }
}
