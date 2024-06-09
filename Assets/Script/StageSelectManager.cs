using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] _stageButtons; // �X�e�[�W�I���{�^���̔z��

    // �Q�[���J�n���ɌĂяo����郁�\�b�h
    void Start()
    {
        // �A�����b�N���ꂽ�X�e�[�W�̐����擾
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);

        // �X�e�[�W�{�^���̃C���^���N�e�B�u��ݒ�
        for (int i = 0; i < _stageButtons.Length; i++)
        {
            _stageButtons[i].interactable = (i < stageUnlock);
        }
    }

    // �X�e�[�W�I�����\�b�h
    public void StageSelect(int stage)
    {
        // �w�肳�ꂽ�X�e�[�W�ɃV�[����ǂݍ���
        SceneManager.LoadScene(stage);
    }
}
