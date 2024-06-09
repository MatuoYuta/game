using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetyousei : MonoBehaviour
{
    // ���j���[�I�u�W�F�N�g���Q�Ƃ��邽�߂̕ϐ�
    [SerializeField] GameObject MenuObject;
    [SerializeField] GameObject MenuObject2;
    [SerializeField] GameObject MenuObject3;
    //[SerializeField] GameObject MenuObject4;

    // ���j���[�̏�Ԃ��Ǘ�����ϐ�
    private bool isMenuActive;

    // �Q�[���J�n���̏���
    void Start()
    {
        // �ꕔ���j���[�I�u�W�F�N�g���\���ɐݒ�
        MenuObject2.SetActive(false);
        MenuObject3.SetActive(false);
        //MenuObject4.SetActive(false);
    }

    // ���t���[���̍X�V����
    void Update()
    {
        // 'G'�L�[�������ꂽ���Ƀ��j���[�̐؂�ւ����s��
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleMenu();
            Debug.Log(isMenuActive);
        }
    }

    // ���j���[�̕\���E��\����؂�ւ��郁�\�b�h
    void ToggleMenu()
    {
        // ���݂̃��j���[�̏�Ԃɉ����ď����𕪊�
        if (isMenuActive)
        {
            // ���j���[���A�N�e�B�u�ȏꍇ�́A�Q�[�����ĊJ
            Time.timeScale = 1f;

            // ���j���[�I�u�W�F�N�g��\��
            MenuObject.SetActive(true);
            MenuObject2.SetActive(false);
            MenuObject3.SetActive(false);
            //MenuObject4.SetActive(false);

            // �}�E�X�J�[�\����\���ɂ��A�ʒu�Œ����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            isMenuActive = false;
        }
        else
        {
            // ���j���[����A�N�e�B�u�ȏꍇ�́A�Q�[�����~
            //Time.timeScale = 0f;

            // ���j���[�I�u�W�F�N�g���\��
            MenuObject.SetActive(false);
            MenuObject2.SetActive(true);
            MenuObject3.SetActive(true);
            //MenuObject4.SetActive(true);

            // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
            /*Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;*/

            isMenuActive = true;
        }
    }
}
