using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1kako : MonoBehaviour
{

    public void change_button()
    {
        // �Q�[�����ĊJ
        Time.timeScale = 1f;
        SceneManager.LoadScene("Stage1kako");
    }
}
