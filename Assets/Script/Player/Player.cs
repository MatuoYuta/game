using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // オーディオクリップとソース
    public AudioClip sound1;
    private AudioSource audioSource;

    // プレイヤーの移動関連のパラメータ
    [SerializeField, Header("移動速度")]
    private float _movespeed;
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;
    [SerializeField, Header("梯子で上る速度")]
    private float _ladderSpeed;

    // 梯子関連のフラグとレイヤーマスク
    public bool IsLadder;
    public LayerMask ladderLayer;

    // 踏みつけ判定の高さの割合
    [Header("踏みつけ判定の高さの割合(%)")]
    public float stepOnRate;

    // プライベート変数
    private string fallFloorTag = "FallFloor";
    private CapsuleCollider2D capcol = null;

    // アニメーション関連のフラグとコンポーネント
    private bool _bjump;
    private bool _bladder;
    private bool _run;
    private Animator _anim;
    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private float currentMoveSpeed;

    // プレイヤーの状態
    public bool HasKey;

    // ポジションと変換関連
    private Vector3 pos;
    private Transform myTransform;
    private bool now_kako;
    private bool now_mirai;

    // カメラとフラグ関連
    private GameObject CAMERA;
    private int flag = 0;
    public GameObject aka;

    // UIオブジェクト
    [SerializeField] private GameObject TCanvas2Object;
    [SerializeField] private GameObject clockObject;
    [SerializeField] private GameObject TCanvas;
    [SerializeField] private GameObject TCanvas_ima;
    [SerializeField] private GameObject TCanvas_mirai;
    [SerializeField] private GameObject TCanvas_kako;
    [SerializeField] private GameObject Button_kako;
    [SerializeField] private GameObject Button_ima;
    [SerializeField] private GameObject Button_mirai;

    // Start is called before the first frame update
    void Start()
    {
        // コンポーネントの取得
        audioSource = GetComponent<AudioSource>();
        _rigid = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();

        // 初期設定
        Application.targetFrameRate = 60;
        _bjump = false;
        _bladder = false;
        HasKey = false;
        _run = false;
        IsLadder = false;
        pos = Vector3.zero;
        now_kako = false;
        now_mirai = false;
        CAMERA = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        myTransform = this.transform;
        _Move();
        _LookMoveDirect();
        _HitFloor();

        // 梯子の移動ロジック
        if (Input.GetKey(KeyCode.W) && IsLadder && _inputDirection.y != 0.0f)
        {
            _rigid.velocity = new Vector2(0, _inputDirection.y) * _ladderSpeed;
            _rigid.gravityScale = 0;
            _anim.SetBool("ladder", _inputDirection.y != 0.0f);
        }
        else
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _rigid.velocity.y);
            _rigid.gravityScale = 1;
        }
    }

    // プレイヤーの移動
    public void _Move()
    {
        currentMoveSpeed = _movespeed;
        _rigid.velocity = new Vector2(_inputDirection.x * currentMoveSpeed, _rigid.velocity.y);
        _run = _inputDirection.x != 0.0f;
        _anim.SetBool("run", _run);
    }

    // 移動入力の処理
    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }

    // プレイヤーの向きを変更
    private void _LookMoveDirect()
    {
        if (!IsLadder)
        {
            if (_inputDirection.x < 0.0f)
            {
                transform.eulerAngles = Vector3.zero;
            }
            else if (_inputDirection.x > 0.0f)
            {
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
        }
    }

    // ジャンプ入力の処理
    public void _OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bjump) return;
        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    // フロアへの接触を処理
    private void _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position - new Vector3(0.0f, transform.lossyScale.y / 0.65f);
        Vector3 raySize = new Vector3(transform.lossyScale.x - 0.3f, 0.1f);
        RaycastHit2D rayHit = Physics2D.BoxCast(rayPos, raySize, 0.0f, Vector2.zero, 0.0f, layerMask);

        if (rayHit.transform == null)
        {
            _movespeed = 3;
            _bjump = true;
            if (!IsLadder)
            {
                _anim.SetBool("jump", _bjump);
            }
            return;
        }

        if (rayHit.transform.tag == "floor" && _bjump || rayHit.transform.tag == "FallFloor" && _bjump || rayHit.transform.tag == "MoveFloor" && _bjump)
        {
            _bjump = false;
            _anim.SetBool("jump", _bjump);
        }

        _movespeed = 8.0f;
    }

    // トリガーに入った時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            IsLadder = true;
            _anim.SetBool("ladder", IsLadder);
        }

        // 敵やトラップに触れた時の処理
        if (collision.gameObject.tag == "EnemyController" || collision.gameObject.tag == "DeadSpace" || collision.gameObject.tag == "toge")
        {
            flag = 1;

            if (this.gameObject != null)
            {
                if (collision.gameObject.tag == "EnemyController" || collision.gameObject.tag == "DeadSpace" || collision.gameObject.tag == "toge")
                {
                    Shake();
                    SceneManager.LoadScene("stage01");
                }
            }
            else
            {
                Debug.Log("Playerオブジェクトが既に破棄されています");
            }
        }
    }

    // トリガーを出た時の処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            IsLadder = false;
            _anim.SetBool("ladder", IsLadder);
        }
    }

    // 衝突時の処理
    private void OnCollisionEnter2D(Collision2D collision)
    {
        bool fallFloor = (collision.collider.tag == fallFloorTag);

        if (fallFloor)
        {
            float stepOnHeight = (capcol.size.y * (stepOnRate / 100f));
            float judgePos = transform.position.y - (capcol.size.y / 2f) + stepOnHeight;

            foreach (ContactPoint2D p in collision.contacts)
            {
                if (p.point.y < judgePos)
                {
                    ObjectCollision o = collision.gameObject.GetComponent<ObjectCollision>();
                    if (o != null)
                    {
                        o.playerStepOn = true;
                    }
                    else
                    {
                        Debug.Log("ObjectCollisionが付いてないよ!");
                    }
                }
            }
        }
    }

    // カメラを揺らす
    public void Shake()
    {
        switch (flag)
        {
            case 1:
                aka.SetActive(true);
                goto case 3;
            case 3:
                CAMERA.transform.Translate(30 * Time.deltaTime, 0, 0);
                if (CAMERA.transform.position.x >= 1.0f)
                    flag++;
                break;
            case 2:
                CAMERA.transform.Translate(-30 * Time.deltaTime, 0, 0);
                if (CAMERA.transform.position.x <= -1.0f)
                    flag++;
                break;
            case 4:
                CAMERA.transform.Translate(-30 * Time.deltaTime, 0, 0);
                if (CAMERA.transform.position.x <= 0)
                {
                    flag = 0;
                    aka.SetActive(false);
                }
                break;
        }
    }

    // 時間の変更
    public void ChangeStage_kako()
    {
        StartCoroutine(Change_time_kako());
    }

    public void ChangeStage_ima()
    {
        StartCoroutine(Change_time_ima());
    }

    public void ChangeStage_mirai()
    {
        StartCoroutine(Change_time_mirai());
    }

    // 過去に時間変更するコルーチン
    IEnumerator Change_time_kako()
    {
        yield return null;
    }

    // 現在に時間変更するコルーチン
    IEnumerator Change_time_ima()
    {
        yield return null;
    }

    // 未来に時間変更するコルーチン
    IEnumerator Change_time_mirai()
    {
        yield return null;
    }
}
