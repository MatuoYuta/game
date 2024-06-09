using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    // シングルトンパターンの実装
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

    // ゲームをリスタートする
    public void RestartGame()
    {
        // ゲームをリスタートする前に、DontDestroyオブジェクトを破棄
        //Destroy(DontDestroy.instance.gameObject);
        Debug.Log("りすたーと");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}
