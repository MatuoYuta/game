using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float _movespeed;
    [SerializeField, Header("�W�����v���x")]
    private float _jumpSpeed;
    [SerializeField, Header("��q�ŏ�鑬�x")]
    private float _ladderSpeed;
    public bool IsLadder;

    private bool _bjump;
    private bool _bladder;
    private Animator _anim;
    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;
    public LayerMask ladderLayer;


    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _rigid = GetComponent<Rigidbody2D>();
        _bjump = false;
        _bladder = false;
        _anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _LookMoveDirect();
        _HitFloor();
        _HitLadder();

        if(Input.GetKey(KeyCode.W) && IsLadder)
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, 3);
            _rigid.gravityScale = 0;
            IsLadder = true;
        }
        else
        {
            _rigid.velocity = new Vector2(_rigid.velocity.x, _rigid.velocity.y);
            _rigid.gravityScale = 1;
            IsLadder = false;
        }
    }

    private void _Move()
    {
        //if (_bjump) return;
        float currentMoveSpeed = _movespeed;
        _rigid.velocity = new Vector2(_inputDirection.x * currentMoveSpeed, _rigid.velocity.y);
        _anim.SetBool("run", _inputDirection.x != 0.0f);

    }

    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
    }

    private void _LookMoveDirect()
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

    public void _OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed || _bjump) return;

        _rigid.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
        /*_bjump = true;
        _anim.SetBool("jump", _bjump);*/

    }

    private void _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position - new Vector3(0.0f, transform.lossyScale.y / 0.63f);
        Vector3 raySize = new Vector3(transform.lossyScale.x - 0.3f, 0.1f);
        RaycastHit2D rayHit = Physics2D.BoxCast(rayPos, raySize, 0.0f, Vector2.zero, 0.0f, layerMask);
        if (rayHit.transform == null)
        {
            _bjump = true;
            _anim.SetBool("jump", _bjump);
            return;
        }

        if (rayHit.transform.tag == "floor" && _bjump)
        {
            _bjump = false;
            _anim.SetBool("jump", _bjump);
        }
    }
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "floor")
        {
            _bjump = false;
            _anim.SetBool("jump", _bjump);
        }
    }*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; // �M�Y���̐F��Ԃɐݒ�

        // �{�b�N�X�L���X�g�̃p�����[�^�[���V�[���r���[�ɕ`��
        Gizmos.DrawWireCube(transform.position - new Vector3(-0.7f, transform.lossyScale.y / 1.0f), new Vector3(transform.lossyScale.x - 0.85f, 1.0f));
    }

    public void _OnLadder(InputAction.CallbackContext context)
    {
        float LadderSpeed = _ladderSpeed;
        _rigid.velocity = new Vector2(_rigid.velocity.x, _inputDirection.y * LadderSpeed);

    }

    private void _HitLadder()
    {
        int ladderLayer = LayerMask.GetMask("Ladder");
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, 2 ,ladderLayer);

            if (hitInfo.collider != null)
        {
            Debug.Log(hitInfo.collider.name + "������");
            Debug.Log(_inputDirection.y);
            if (_inputDirection.y > 0)
            {
                _bladder = true;

            }

            if (_bladder)
            {
                _rigid.velocity = new Vector2(_rigid.velocity.x, _inputDirection.y * _ladderSpeed);
                _rigid.gravityScale = 0;
            }
            else
            {
                _rigid.gravityScale = 1;
            }
        }
    }
    
}
