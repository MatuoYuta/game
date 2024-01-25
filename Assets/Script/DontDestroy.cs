using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // シングルトンパターンのための静的インスタンス
    static public DontDestroy instance = null;

    // 他のスクリプトからアクセス可能なスコア
    [HideInInspector] public int Score = 0;

    void Awake()
    {
        // シングルトンパターンの実装
        if (instance == null)
        {
            // まだインスタンスが設定されていない場合、自身を設定し破棄されないようにする
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // 既にインスタンスが存在する場合、新しく生成されたオブジェクトを破棄する
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // タイトルシーンに戻った時に破棄する
        if (SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // ここに更新コードを追加することができます
    }
}
