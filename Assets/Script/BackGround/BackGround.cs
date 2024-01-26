using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{

    [SerializeField, Header("éãç∑å¯â "), Range(0, 1)]
    private float _parallaxEffect;

    private GameObject _camera;
    private float _length;
    private float _startPosX;
    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x;
        _length = GetComponent<SpriteRenderer>().bounds.size.x;
        _camera = Camera.main.gameObject;
    }

    void Update()
    {
     
    }

    private void FixedUpdate()
    {
        _ParallaxX();
    }
    private void _ParallaxX()
    {
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        float dist = _camera.transform.position.x * _parallaxEffect;

        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        if (temp > _startPosX + _length)
        {
            _startPosX += _length;
        }
        else if (temp < _startPosX - _length)
        {
            _startPosX -= _length;
        }
    }
}
