using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerChecker : MonoBehaviour
{
    public UnityEvent<Collider2D> onColliderEnter; // �R���C�_�[���g���K�[�ɓ������Ƃ��ɌĂ΂��C�x���g

    // 2D �R���C�_�[���g���K�[���ɐN�������Ƃ��ɌĂяo����郁�\�b�h
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �g���K�[�ɓ��������̃C�x���g�����s
        onColliderEnter.Invoke(collision);
    }
}
