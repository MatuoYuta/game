using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionMenu : MonoBehaviour
{
    // ���j���[�{�^���������ꂽ���ɌĂяo����郁�\�b�h
    public void MenuButton()
    {
        // Option �V�[����ǂݍ���
        SceneManager.LoadScene("Option");
    }
}
