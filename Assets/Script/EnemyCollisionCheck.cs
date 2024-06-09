using UnityEngine;

// 敵や壁との接触を検知するスクリプト
public class EnemyCollisionCheck : MonoBehaviour
{
    /// <summary>
    /// 判定内に敵か壁があるかどうかを示すフラグ
    /// </summary>
    [HideInInspector] public bool isOn = false;

    private string groundTag = "floor";   // 地面のタグ
    private string enemyTag = "Enemy";    // 敵のタグ

    // 接触判定メソッド
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触したオブジェクトが地面または敵である場合
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            // 判定内に敵か壁があることを示すフラグをtrueにする
            isOn = true;
        }
    }

    // 接触判定解除メソッド
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 接触していたオブジェクトが地面または敵である場合
        if (collision.tag == groundTag || collision.tag == enemyTag)
        {
            // 判定内に敵か壁があることを示すフラグをfalseにする
            isOn = false;
        }
    }
}
