using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01 : MonoBehaviour
{
    // �v���C���[�̈ʒu���Ǘ�����ϐ�
    Vector3 pos;

    // �A�j���[�^�[�R���|�[�l���g
    public Animator _anim;

    // ���Ԃ̏�Ԃ��Ǘ�����ϐ�
    public static bool kako;
    private bool mirai;
    private bool ima;

    // �v���C���[��Transform
    Transform myTransform;

    // �Ώۂ̃I�u�W�F�N�g�i�v���C���[�j
    public GameObject targetObj;

    // UI�v�f
    [SerializeField] GameObject clockani;
    public GameObject kako_Botton;
    public GameObject mirai_Bottun;
    public GameObject ima_Button;

    // ����������
    void Start()
    {
        // clock_A�I�u�W�F�N�g�̃A�j���[�^�[�R���|�[�l���g���擾
        _anim = GameObject.Find("clock_A").GetComponent<Animator>();

        // pos�̏�����
        pos = Vector3.zero;
    }

    // ���t���[���̍X�V����
    void Update()
    {
        // �v���C���[��Transform���擾
        myTransform = this.transform;
    }

    // �ߋ��Ɉړ����鏈��
    public void Go_kako()
    {
        kako = true;

        // �v���C���[�̃X�e�[�W�ύX���\�b�h���Ăяo��
        targetObj.GetComponent<Player>().ChangeStage_kako();

        Debug.Log("button");

        Debug.Log("�A�j���[�V����" + kako);

        // �A�j���[�^�[�̏�Ԃ��X�V
        _anim.SetBool("kako", kako);

        // �{�^�����\���ɂ���
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }

    // ���݂Ɉړ����鏈��
    public void Go_ima()
    {
        ima = true;

        // �v���C���[�̃X�e�[�W�ύX���\�b�h���Ăяo��
        targetObj.GetComponent<Player>().ChangeStage_ima();

        Debug.Log("button");

        Debug.Log("�A�j���[�V����" + ima);

        // �A�j���[�^�[�̏�Ԃ��X�V
        _anim.SetBool("ima", ima);

        // �{�^�����\���ɂ���
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }

    // �����Ɉړ����鏈��
    public void Go_mirai()
    {
        mirai = true;

        // �v���C���[�̃X�e�[�W�ύX���\�b�h���Ăяo��
        targetObj.GetComponent<Player>().ChangeStage_mirai();

        Debug.Log("button");

        Debug.Log("�A�j���[�V����" + mirai);

        // �A�j���[�^�[�̏�Ԃ��X�V
        _anim.SetBool("mirai", mirai);

        // �{�^�����\���ɂ���
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }
}
