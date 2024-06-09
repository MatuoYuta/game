using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    [SerializeField, Header("視差効果"), Range(0, 1)]
    private float _parallaxEffect; // 背景の視差効果の値。0から1の範囲。

    private GameObject _camera; // メインカメラへの参照。
    private float _length; // 背景スプライトのx軸上の長さ。
    private float _lengthY; // 背景スプライトのy軸上の長さ。
    private float _startPosX; // 背景の初期x座標。
    private float _startPosY; // 背景の初期y座標。

    // Start is called before the first frame update
    void Start()
    {
        _startPosX = transform.position.x; // 背景の初期x座標を保存。
        _startPosY = transform.position.y; // 背景の初期y座標を保存。
        _length = GetComponent<SpriteRenderer>().bounds.size.x; // 背景スプライトのx軸上の長さを取得。
        _lengthY = GetComponent<SpriteRenderer>().bounds.size.y; // 背景スプライトのy軸上の長さを取得。
        _camera = Camera.main.gameObject; // メインカメラへの参照を取得。
    }

    private void FixedUpdate()
    {
        _ParallaxX(); // x軸上の視差効果を適用。
        _ParallaxY(); // y軸上の視差効果を適用。
    }

    private void _ParallaxX()
    {
        // x軸方向のカメラの移動に基づいて一時的な位置を計算。
        float temp = _camera.transform.position.x * (1 - _parallaxEffect);
        // 背景を移動する距離を計算。
        float dist = _camera.transform.position.x * _parallaxEffect;

        // 背景を水平方向に移動。
        transform.position = new Vector3(_startPosX + dist, transform.position.y, transform.position.z);

        // 背景が水平方向にループする必要があるかどうかをチェック。
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
        // y軸方向のカメラの移動に基づいて一時的な位置を計算。
        float temp = _camera.transform.position.y * (1 - _parallaxEffect);
        // 背景を移動する距離を計算。
        float dist = _camera.transform.position.y * _parallaxEffect;

        // 背景を垂直方向に移動。
        transform.position = new Vector3(transform.position.x, _startPosY + dist, transform.position.z);

        // 背景が垂直方向にループする必要があるかどうかをチェック。
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
