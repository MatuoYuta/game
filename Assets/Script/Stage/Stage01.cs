using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01 : MonoBehaviour
{
    // プレイヤーの位置を管理する変数
    Vector3 pos;

    // アニメーターコンポーネント
    public Animator _anim;

    // 時間の状態を管理する変数
    public static bool kako;
    private bool mirai;
    private bool ima;

    // プレイヤーのTransform
    Transform myTransform;

    // 対象のオブジェクト（プレイヤー）
    public GameObject targetObj;

    // UI要素
    [SerializeField] GameObject clockani;
    public GameObject kako_Botton;
    public GameObject mirai_Bottun;
    public GameObject ima_Button;

    // 初期化処理
    void Start()
    {
        // clock_Aオブジェクトのアニメーターコンポーネントを取得
        _anim = GameObject.Find("clock_A").GetComponent<Animator>();

        // posの初期化
        pos = Vector3.zero;
    }

    // 毎フレームの更新処理
    void Update()
    {
        // プレイヤーのTransformを取得
        myTransform = this.transform;
    }

    // 過去に移動する処理
    public void Go_kako()
    {
        kako = true;

        // プレイヤーのステージ変更メソッドを呼び出す
        targetObj.GetComponent<Player>().ChangeStage_kako();

        Debug.Log("button");

        Debug.Log("アニメーション" + kako);

        // アニメーターの状態を更新
        _anim.SetBool("kako", kako);

        // ボタンを非表示にする
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }

    // 現在に移動する処理
    public void Go_ima()
    {
        ima = true;

        // プレイヤーのステージ変更メソッドを呼び出す
        targetObj.GetComponent<Player>().ChangeStage_ima();

        Debug.Log("button");

        Debug.Log("アニメーション" + ima);

        // アニメーターの状態を更新
        _anim.SetBool("ima", ima);

        // ボタンを非表示にする
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }

    // 未来に移動する処理
    public void Go_mirai()
    {
        mirai = true;

        // プレイヤーのステージ変更メソッドを呼び出す
        targetObj.GetComponent<Player>().ChangeStage_mirai();

        Debug.Log("button");

        Debug.Log("アニメーション" + mirai);

        // アニメーターの状態を更新
        _anim.SetBool("mirai", mirai);

        // ボタンを非表示にする
        kako_Botton.SetActive(false);
        mirai_Bottun.SetActive(false);
        ima_Button.SetActive(false);
    }
}
