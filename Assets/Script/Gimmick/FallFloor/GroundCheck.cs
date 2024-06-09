using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("エフェクトがついた床を判定するか")] public bool checkPlatformGround = true;

    private string groundTag = "Ground"; // 通常の地面のタグ
    private string platformTag = "GroundPlatform"; // プラットフォームのタグ
    private string moveFloorTag = "MoveFloor"; // 移動床のタグ
    private string fallFloorTag = "FallFloor"; // 落下床のタグ
    private bool isGround = false; // 接地しているかのフラグ
    private bool isGroundEnter, isGroundStay, isGroundExit; // 接地状態を表すフラグ

    // 接地判定を返すメソッド
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true; // 接地中
        }
        else if (isGroundExit)
        {
            isGround = false; // 接地していない
        }
        // フラグをリセット
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    // トリガー領域に入った時の処理
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 通常の地面に接触した場合、またはプラットフォーム・移動床・落下床に接触している場合
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundEnter = true; // 接地状態に入る
        }
    }

    // トリガー領域に滞在している間の処理
    private void OnTriggerStay2D(Collider2D collision)
    {
        // 通常の地面に接触した場合、またはプラットフォーム・移動床・落下床に接触している場合
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundStay = true; // 接地状態を維持
        }
    }

    // トリガー領域から出た時の処理
    private void OnTriggerExit2D(Collider2D collision)
    {
        // 通常の地面から離れた場合、またはプラットフォーム・移動床・落下床から離れた場合
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundExit = true; // 接地状態から出る
        }
    }
}
