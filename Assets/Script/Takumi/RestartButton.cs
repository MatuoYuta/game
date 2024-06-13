using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    private static RestartButton instance;

    private void Awake()
    {
        // シングルトンパターンの実装
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

    public void RestartGame()
    {
        // ゲームをリスタートする前に、DontDestroyオブジェクトを破棄
        //Destroy(DontDestroy.instance.gameObject);
        Debug.Log("りすたーと");
        // ゲームをリスタートする
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
}