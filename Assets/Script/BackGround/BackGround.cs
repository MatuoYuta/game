using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("��������"), Range(0, 1)]
    private float _parallaxEffect; // �w�i�̎������ʂ̒l�B0����1�͈̔́B

    private GameObject _camera; // ���C���J�����ւ̎Q�ƁB
    private float _length; // �w�i�X�v���C�g��x����̒����B
    private float _lengthY; // �w�i�X�v���C�g��y����̒����B
    private float _startPosX; // �w�i�̏���x���W�B
    private float _startPosY; // �w�i�̏���y���W�B

    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x; // �w�i�̏���x���W��ۑ��B
        _startPosY = transform.position.y; // �w�i�̏���y���W��ۑ��B
        _length = GetComponent<SpriteRenderer>().bounds.size.x; // �w�i�X�v���C�g��x����̒������擾�B
        _lengthY = GetComponent<SpriteRenderer>().bounds.size.y; // �w�i�X�v���C�g��y����̒������擾�B
        _camera = Camera.main.gameObject; // ���C���J�����ւ̎Q�Ƃ��擾�B
    }

    private void FixedUpdate()
    {
        _ParallaxX(); // x����̎������ʂ�K�p�B
        _ParallaxY(); // y����̎������ʂ�K�p�B
    }

    private void _ParallaxX()
    {
        // x�������̃J�����̈ړ��Ɋ�Â��Ĉꎞ�I�Ȉʒu���v�Z�B
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        // �w�i���ړ����鋗�����v�Z�B
        float dist = _camera.transform.position.x * _parallaxEffect;

        // �w�i�𐅕������Ɉړ��B
        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        // �w�i�����������Ƀ��[�v����K�v�����邩�ǂ������`�F�b�N�B
        if (temp > _startPosX + _length)
        {
            _startPosX += _length;
        }
        else if (temp < _startPosX - _length)
        {
            _startPosX -= _length;
        }
    }

    private void _ParallaxY()
    {
        // y�������̃J�����̈ړ��Ɋ�Â��Ĉꎞ�I�Ȉʒu���v�Z�B
        float temp = _camera.transform.position.y * (1 - _parallaxEffect);
        // �w�i���ړ����鋗�����v�Z�B
        float dist = _camera.transform.position.y * _parallaxEffect;

        // �w�i�𐂒������Ɉړ��B
        transform.position = new Vector3(transform.position.x, _startPosY + dist, transform.position.z);

        // �w�i�����������Ƀ��[�v����K�v�����邩�ǂ������`�F�b�N�B
        if (temp > _startPosY + _lengthY)
        {
            _startPosY += _lengthY;
        }
        else if (temp < _startPosY - _lengthY)
        {
            _startPosY -= _lengthY;
        }
    }
}
