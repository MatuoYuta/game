using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [Header("これを踏んだ時のプレイヤーが跳ねる高さ")]
    public float boundHeight; // プレイヤーが踏んだ時に跳ねる高さ

    /// <summary>
    /// このオブジェクトをプレイヤーが踏んだかどうかを表すフラグ
    /// </summary>
    [HideInInspector]
    public bool playerStepOn; // プレイヤーがこのオブジェクトを踏んだかどうかを表すフラグ
}
