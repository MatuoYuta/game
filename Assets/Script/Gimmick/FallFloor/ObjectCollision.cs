using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollision : MonoBehaviour
{
    [Header("����𓥂񂾎��̃v���C���[�����˂鍂��")]
    public float boundHeight; // �v���C���[�����񂾎��ɒ��˂鍂��

    /// <summary>
    /// ���̃I�u�W�F�N�g���v���C���[�����񂾂��ǂ�����\���t���O
    /// </summary>
    [HideInInspector]
    public bool playerStepOn; // �v���C���[�����̃I�u�W�F�N�g�𓥂񂾂��ǂ�����\���t���O
}
