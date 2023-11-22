using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField, Header("移動速度")]
    private float _movespeed;
    [SerializeField, Header("ジャンプ速度")]
    private float _jumpSpeed;

    private bool _bjump;
    private Animator _anim;
    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _bjump = false;


    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _LookMoveDirect();
        _HitFloor();


    }

    private void _Move()
    {
        if (_bjump) return;
        _rigid.velocity = new Vector2(_inputDirection.x * _movespeed, _rigid.velocity.y);
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
    }

    private void _HitFloor()
    {
        int layerMask = LayerMask.GetMask("Floor");
        Vector3 rayPos = transform.position - new Vector3(0.0f, transform.lossyScale.y / 2.0f);
        Vector3 raySize = new Vector3(transform.lossyScale.x - 0.1f, 0.1f);
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
}
