using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // �I�[�f�B�I�N���b�v�ƃ\�[�X
    public AudioClip sound1;
    private AudioSource audioSource;

    // �v���C���[�̈ړ��֘A�̃p�����[�^
    [SerializeField, Header("�ړ����x")]
    private float _movespeed;
    [SerializeField, Header("�W�����v���x")]
    private float _jumpSpeed;
    [SerializeField, Header("��q�ŏ�鑬�x")]
    private float _ladderSpeed;

    // ��q�֘A�̃t���O�ƃ��C���[�}�X�N
    public bool IsLadder;
    public LayerMask ladderLayer;

    // ���݂�����̍����̊���
    [Header("���݂�����̍����̊���(%)")]
    public float stepOnRate;

    // �v���C�x�[�g�ϐ�
    private string fallFloorTag = "FallFloor";
    private CapsuleCollider2D capcol = null;

    // �A�j���[�V�����֘A�̃t���O�ƃR���|�[�l���g
    private bool _bjump;
    private bool _bladder;
    private bool _run;
    private Animator _anim;
    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    private float currentMoveSpeed;

    // �v���C���[�̏��
    public bool HasKey;

    // �|�W�V�����ƕϊ��֘A
    private Vector3 pos;
    private Transform myTransform;
    private bool now_kako;
    private bool now_mirai;

    // �J�����ƃt���O�֘A
    private GameObject CAMERA;
    private int flag = 0;
    public GameObject aka;

    // UI�I�u�W�F�N�g
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
        // �R���|�[�l���g�̎擾
        audioSource = GetComponent<AudioSource>();
        _rigid = GetComponent<Rigidbody2D>();
        capcol = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();

        // �����ݒ�
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

        // ��q�̈ړ����W�b�N
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

    // �v���C���[�̈ړ�
    public void _Move()
    {
        currentMoveSpeed = _movespeed;
        _rigid.velocity = new Vector2(_inputDirection.x * currentMoveSpeed, _rigid.velocity.y);
        _run = _inputDirection.x != 0.0f;
        _anim.SetBool("run", _run);
    }

    // �ړ����͂̏���
    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }

    // �v���C���[�̌�����ύX
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

    // �W�����v���͂̏���
    public void _OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bjump) return;
        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
    }

    // �t���A�ւ̐ڐG������
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

    // �g���K�[�ɓ��������̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            IsLadder = true;
            _anim.SetBool("ladder", IsLadder);
        }

        // �G��g���b�v�ɐG�ꂽ���̏���
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
                Debug.Log("Player�I�u�W�F�N�g�����ɔj������Ă��܂�");
            }
        }
    }

    // �g���K�[���o�����̏���
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ladder")
        {
            IsLadder = false;
            _anim.SetBool("ladder", IsLadder);
        }
    }

    // �Փˎ��̏���
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
                        Debug.Log("ObjectCollision���t���ĂȂ���!");
                    }
                }
            }
        }
    }

    // �J������h�炷
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

    // ���Ԃ̕ύX
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

    // �ߋ��Ɏ��ԕύX����R���[�`��
    IEnumerator Change_time_kako()
    {
        yield return null;
    }

    // ���݂Ɏ��ԕύX����R���[�`��
    IEnumerator Change_time_ima()
    {
        yield return null;
    }

    // �����Ɏ��ԕύX����R���[�`��
    IEnumerator Change_time_mirai()
    {
        yield return null;
    }
}
