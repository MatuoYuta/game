using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [Header("�G�t�F�N�g���������𔻒肷�邩")] public bool checkPlatformGround = true;

    private string groundTag = "Ground"; // �ʏ�̒n�ʂ̃^�O
    private string platformTag = "GroundPlatform"; // �v���b�g�t�H�[���̃^�O
    private string moveFloorTag = "MoveFloor"; // �ړ����̃^�O
    private string fallFloorTag = "FallFloor"; // �������̃^�O
    private bool isGround = false; // �ڒn���Ă��邩�̃t���O
    private bool isGroundEnter, isGroundStay, isGroundExit; // �ڒn��Ԃ�\���t���O

    // �ڒn�����Ԃ����\�b�h
    public bool IsGround()
    {
        if (isGroundEnter || isGroundStay)
        {
            isGround = true; // �ڒn��
        }
        else if (isGroundExit)
        {
            isGround = false; // �ڒn���Ă��Ȃ�
        }
        // �t���O�����Z�b�g
        isGroundEnter = false;
        isGroundStay = false;
        isGroundExit = false;
        return isGround;
    }

    // �g���K�[�̈�ɓ��������̏���
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �ʏ�̒n�ʂɐڐG�����ꍇ�A�܂��̓v���b�g�t�H�[���E�ړ����E�������ɐڐG���Ă���ꍇ
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundEnter = true; // �ڒn��Ԃɓ���
        }
    }

    // �g���K�[�̈�ɑ؍݂��Ă���Ԃ̏���
    private void OnTriggerStay2D(Collider2D collision)
    {
        // �ʏ�̒n�ʂɐڐG�����ꍇ�A�܂��̓v���b�g�t�H�[���E�ړ����E�������ɐڐG���Ă���ꍇ
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundStay = true; // �ڒn��Ԃ��ێ�
        }
    }

    // �g���K�[�̈悩��o�����̏���
    private void OnTriggerExit2D(Collider2D collision)
    {
        // �ʏ�̒n�ʂ��痣�ꂽ�ꍇ�A�܂��̓v���b�g�t�H�[���E�ړ����E���������痣�ꂽ�ꍇ
        if (collision.tag == groundTag || (checkPlatformGround && (collision.tag == platformTag || collision.tag == moveFloorTag || collision.tag == fallFloorTag)))
        {
            isGroundExit = true; // �ڒn��Ԃ���o��
        }
    }
}
