using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    // �X�e�[�W�I����ʂɈړ����郁�\�b�h
    public void ChangeButton()
    {
        // �uStageSelect�v�V�[�������[�h
        SceneManager.LoadScene("StageSelect");
    }
}
