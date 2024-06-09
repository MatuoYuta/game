using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StageSelectManager : MonoBehaviour
{
    [SerializeField] private Button[] _stageButtons; // ステージ選択ボタンの配列

    // ゲーム開始時に呼び出されるメソッド
    void Start()
    {
        // アンロックされたステージの数を取得
        int stageUnlock = PlayerPrefs.GetInt("StageUnlock", 1);

        // ステージボタンのインタラクティブを設定
        for (int i = 0; i < _stageButtons.Length; i++)
        {
            _stageButtons[i].interactable = (i < stageUnlock);
        }
    }

    // ステージ選択メソッド
    public void StageSelect(int stage)
    {
        // 指定されたステージにシーンを読み込む
        SceneManager.LoadScene(stage);
    }
}
