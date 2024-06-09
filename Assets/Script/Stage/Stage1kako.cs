using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1kako : MonoBehaviour
{
    private bool kako;
    private bool mirai;
    private bool ima;

    public Animator _anim;

    [SerializeField] GameObject clockani;
    [SerializeField, Header("�C���{�[�N����")] float wait;

    // �X�N���v�g���J�n�����Ƃ��ɌĂяo�����
    private void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g���擾
        _anim = GameObject.Find("clock_A").GetComponent<Animator>();

        // �e�t���O��������
        kako = false;
        mirai = false;
        ima = false;
    }

    // �t���[�����ƂɌĂяo�����
    private void Update()
    {
        // �N���b�N�C�x���g�̏���
        void OnClick()
        {
            Debug.Log("�N���b�N");
            // �{�^�����N���b�N���ꂽ�Ƃ��ɏ��������s�i�R�����g�A�E�g���ꂽ�R�[�h�j
            //Invoke("change_button", 2);
            //change_button();
            // �Q�[�����ĊJ
            /*Time.timeScale = 1f;
            Debug.Log("�{�^��");
            SceneManager.LoadScene("Stage1kako");*/
        }
    }

    // �{�^���������ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    void change_button()
    {
        kako = true;

        // �A�j���[�V�������Đ�
        Debug.Log("�A�j���[�V����" + kako);
        _anim.SetBool("kako", kako);

        // �w�肵�����ԑ҂��Ă���X�e�[�W��ύX����
        Invoke("stage_change", wait);
        Debug.Log("����ځ[��");
    }

    // �X�e�[�W��ύX���郁�\�b�h
    void stage_change()
    {
        kako = false;

        // �Q�[���̎��Ԃ�ʏ�̑��x�ɖ߂�
        Time.timeScale = 1f;

        // "Stage1kako"�V�[�������[�h
        Debug.Log("�{�^��");
        SceneManager.LoadScene("Stage1kako");
    }
}
