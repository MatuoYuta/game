using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1kako : MonoBehaviour
{
    private bool kako;
    private bool mirai;
    private bool ima;

    public Animator _anim;

    [SerializeField] GameObject clockani;
    [SerializeField, Header("インボーク時間")] float wait;

    // スクリプトが開始したときに呼び出される
    private void Start()
    {
        // アニメーターコンポーネントを取得
        _anim = GameObject.Find("clock_A").GetComponent<Animator>();

        // 各フラグを初期化
        kako = false;
        mirai = false;
        ima = false;
    }

    // フレームごとに呼び出される
    private void Update()
    {
        // クリックイベントの処理
        void OnClick()
        {
            Debug.Log("クリック");
            // ボタンがクリックされたときに処理を実行（コメントアウトされたコード）
            //Invoke("change_button", 2);
            //change_button();
            // ゲームを再開
            /*Time.timeScale = 1f;
            Debug.Log("ボタン");
            SceneManager.LoadScene("Stage1kako");*/
        }
    }

    // ボタンが押されたときに呼び出されるメソッド
    void change_button()
    {
        kako = true;

        // アニメーションを再生
        Debug.Log("アニメーション" + kako);
        _anim.SetBool("kako", kako);

        // 指定した時間待ってからステージを変更する
        Invoke("stage_change", wait);
        Debug.Log("いんぼーく");
    }

    // ステージを変更するメソッド
    void stage_change()
    {
        kako = false;

        // ゲームの時間を通常の速度に戻す
        Time.timeScale = 1f;

        // "Stage1kako"シーンをロード
        Debug.Log("ボタン");
        SceneManager.LoadScene("Stage1kako");
    }
}
