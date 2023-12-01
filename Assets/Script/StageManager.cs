using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    public void nextStage()
    {
        int StageUnlock = PlayerPrefs.GetInt("StageUnlock");

        int NextScene = SceneManager.GetActiveScene().buildIndex + 1;
        if (NextScene < SceneManager.sceneCountInBuildSettings)
        {
            if (StageUnlock < NextScene) PlayerPrefs.SetInt("StageUnlock", NextScene);

            SceneManager.LoadScene(NextScene);
        }
        else
            SceneManager.LoadScene(0);
    }
}
