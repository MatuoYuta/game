using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1 : MonoBehaviour
{
    // �{�^���������ꂽ�Ƃ��ɃX�e�[�W��ύX���郁�\�b�h
    public void change_button()
    {
        // "stage01"�V�[�������[�h
        SceneManager.LoadScene("stage01");

        // �Q�[���̎��Ԃ�ʏ�̑��x�ɖ߂�
        Time.timeScale = 1f;
    }
}
