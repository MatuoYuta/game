using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // 次のステージに進むメソッド
    public void NextStage()
    {
        // アンロックされたステージの情報を取得
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock");

        // 次のシーンのインデックスを取得
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;

        // 次のシーンがビルド設定内に存在するか確認
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            // アンロックされたステージが次のステージよりも小さい場合、次のステージをアンロック
            if (stageUnlock < nextSceneIndex)
                PlayerPrefs.SetInt("StageUnlock", nextSceneIndex);

            // 次のステージを読み込む
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // 最後のシーンの場合、最初のシーンを読み込む
            SceneManager.LoadScene(0);
        }
    }
}
