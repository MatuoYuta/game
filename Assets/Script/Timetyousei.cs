using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timetyousei : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;

    bool menuzyoutai;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ���j���[�̐؂�ւ�();
        }
    }

    void ���j���[�̐؂�ւ�()
    {
        menuzyoutai = !menuzyoutai;

        if (menuzyoutai)
        {
            // ���j���[��\��
            MenuObject.SetActive(true);

            // �}�E�X�J�[�\����\���ɂ��A�ʒu�Œ����
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // ���j���[���\��
            MenuObject.SetActive(false);

            // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}

