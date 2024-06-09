using UnityEngine;

// プレイヤーを追跡するカメラの管理を行うスクリプト
public class CameraManager : MonoBehaviour
{
    private Player _player;         // プレイヤーへの参照
    private Vector3 _initPos;       // カメラの初期位置

    // Startメソッドは最初のフレームの前に呼び出される
    void Start()
    {
        // シーン内からプレイヤーオブジェクトを見つける
        _player = FindObjectOfType<Player>();

        // カメラの初期位置を設定する
        _initPos = transform.position;
    }

    // Updateメソッドはフレームごとに呼び出される
    void Update()
    {
        // プレイヤーを追跡する
        _FollowPlayer();
    }

    // プレイヤーを追跡するメソッド
    private void _FollowPlayer()
    {
        // プレイヤーが存在するかチェックする
        if (_player != null)
        {
            // プレイヤーの位置を取得する
            float y = _player.transform.position.y;
            float x = _player.transform.position.x;

            // カメラの位置をプレイヤーの位置に追従させる
            transform.position = new Vector3(x, y, transform.position.z);
        }
    }
}
