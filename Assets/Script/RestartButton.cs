using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private static RestartButton instance;

    private void Awake()
    {
        // �V���O���g���p�^�[���̎���
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RestartGame()
    {
        // �Q�[�������X�^�[�g����O�ɁADontDestroy�I�u�W�F�N�g��j��
        Destroy(DontDestroy.instance.gameObject);

        // �Q�[�������X�^�[�g����
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}