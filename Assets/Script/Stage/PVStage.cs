using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PVStage : MonoBehaviour
{
    // �{�^���������ꂽ���ɌĂ΂�郁�\�b�h
    public void change_button()
    {
        // �V�[����"PVStage"�ɕύX����
        SceneManager.LoadScene("PVStage");
    }
}
