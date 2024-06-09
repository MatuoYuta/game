using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControl : MonoBehaviour
{
    // ���j���[�I�u�W�F�N�g�ւ̎Q��
    [SerializeField] GameObject menuObject;

    // ���j���[�̕\����Ԃ��Ǘ�����t���O
    bool menuVisible;

    // Update is called once per frame
    void Update()
    {
        // ���j���[����\���̏ꍇ
        if (!menuVisible)
        {
            // �L�����Z���{�^���������ꂽ�烁�j���[��\��
            if (Input.GetButtonDown("Cancel"))
            {
                menuObject.SetActive(true);
                menuVisible = true;

                // �Q�[�����~
                Time.timeScale = 0f;

                // �}�E�X�J�[�\����\�����A�ʒu�Œ����
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            // ���j���[���\������Ă���ꍇ
            // �L�����Z���{�^���������ꂽ�烁�j���[���\���ɂ���
            if (Input.GetButtonDown("Cancel"))
            {
                menuObject.SetActive(false);
                menuVisible = false;

                // �Q�[�����ĊJ
                Time.timeScale = 1f;

                // �}�E�X�J�[�\�����\���ɂ��A�ʒu���Œ�
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
