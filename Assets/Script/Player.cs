using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Player : MonoBehaviour
{
    [SerializeField, Header("�ړ����x")]
    private float _movespeed;

    private Animator _anim;
    private Vector2 _inputDirection;
    private Rigidbody2D _rigid;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _LookMoveDirect();

    }

    private void _Move()
    {
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
}
