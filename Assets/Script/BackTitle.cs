using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{
    // �u�߂�v�{�^���������ꂽ���ɌĂ΂�郁�\�b�h
    public void Back_button()
    {
        // �uTitle�v�V�[�������[�h
        SceneManager.LoadScene("Title");
    }
}
