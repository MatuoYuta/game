using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // �V���O���g���p�^�[���̎���
    private static RestartButton instance;

    private void Awake()
    {
        /*if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }*/
    }

    // �Q�[�������X�^�[�g����
    public void RestartGame()
    {
        // �Q�[�������X�^�[�g����O�ɁADontDestroy�I�u�W�F�N�g��j��
        //Destroy(DontDestroy.instance.gameObject);
        Debug.Log("�肷���[��");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
