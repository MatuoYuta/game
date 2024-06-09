using UnityEngine;

public class SphereDrop : MonoBehaviour
{
    public GameObject target; // 対象オブジェクト

    bool check = false; // チェックフラグ

    void Update()
    {
        /*Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < 3f)
        {
            SphereGravity();
        }*/

        // チェックがされた場合
        if (check)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic; // Rigidbody の動的なタイプに変更
        }
    }

    // 球体に重力を適用するメソッド
    void SphereGravity()
    {
        GetComponent<Rigidbody>().useGravity = true; // 重力を有効にする
    }

    // チェックイベントの処理
    public void CheckEventHandler(Collider2D collider)
    {
        check = true; // チェックフラグを立てる
    }
}
