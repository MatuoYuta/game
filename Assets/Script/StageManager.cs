using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // ���̃X�e�[�W�ɐi�ރ��\�b�h
    public void NextStage()
    {
        // �A�����b�N���ꂽ�X�e�[�W�̏����擾
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock");

        // ���̃V�[���̃C���f�b�N�X���擾
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // ���̃V�[�����r���h�ݒ���ɑ��݂��邩�m�F
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // �A�����b�N���ꂽ�X�e�[�W�����̃X�e�[�W�����������ꍇ�A���̃X�e�[�W���A�����b�N
            if (stageUnlock < nextSceneIndex)
                PlayerPrefs.SetInt("StageUnlock", nextSceneIndex);

            // ���̃X�e�[�W��ǂݍ���
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // �Ō�̃V�[���̏ꍇ�A�ŏ��̃V�[����ǂݍ���
            SceneManager.LoadScene(0);
        }
    }
}
