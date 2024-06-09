using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [Header("�ړ��o�H")]
    public GameObject[] movePoints; // �ړ�����|�C���g�̔z��

    [Header("����")]
    public float speed = 1.0f; // �ړ����x

    private Rigidbody2D rb; // Rigidbody2D �R���|�[�l���g
    private int currentPointIndex = 0; // ���݂̖ڕW�|�C���g�̃C���f�b�N�X
    private bool returnPoint = false; // �i�s�������܂�Ԃ���Ԃ��ǂ����̃t���O
    private Vector2 oldPosition = Vector2.zero; // �O�̃t���[���̈ʒu
    private Vector2 myVelocity = Vector2.zero; // �ړ����x�x�N�g��

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D �R���|�[�l���g���擾
        if (movePoints != null && movePoints.Length > 0 && rb != null)
        {
            rb.position = movePoints[0].transform.position; // �ŏ��̃|�C���g�Ɉړ�
            oldPosition = rb.position; // �����ʒu��ۑ�
        }
    }

    // �ړ����x�x�N�g����Ԃ����\�b�h
    public Vector2 GetVelocity()
    {
        return myVelocity;
    }

    private void FixedUpdate()
    {
        if (movePoints != null && movePoints.Length > 1 && rb != null)
        {
            // �ʏ�i�s
            if (!returnPoint)
            {
                int nextPointIndex = currentPointIndex + 1;

                // ���̃|�C���g�ɓ��B����܂ňړ�
                if (Vector2.Distance(transform.position, movePoints[nextPointIndex].transform.position) > 0.1f)
                {
                    Vector2 nextPosition = Vector2.MoveTowards(transform.position, movePoints[nextPointIndex].transform.position, speed * Time.deltaTime);
                    rb.MovePosition(nextPosition); // ���̃|�C���g�ֈړ�
                }
                else
                {
                    rb.MovePosition(movePoints[nextPointIndex].transform.position); // ���̃|�C���g�ֈړ�
                    currentPointIndex++; // �C���f�b�N�X�𑝂₷

                    // �|�C���g�z��̍Ō�ɓ��B�����ꍇ
                    if (currentPointIndex + 1 >= movePoints.Length)
                    {
                        returnPoint = true; // �܂�Ԃ���Ԃɂ���
                    }
                }
            }
            // �܂�Ԃ��i�s
            else
            {
                int nextPointIndex = currentPointIndex - 1;

                // ���̃|�C���g�ɓ��B����܂ňړ�
                if (Vector2.Distance(transform.position, movePoints[nextPointIndex].transform.position) > 0.1f)
                {
                    Vector2 nextPosition = Vector2.MoveTowards(transform.position, movePoints[nextPointIndex].transform.position, speed * Time.deltaTime);
                    rb.MovePosition(nextPosition); // ���̃|�C���g�ֈړ�
                }
                else
                {
                    rb.MovePosition(movePoints[nextPointIndex].transform.position); // ���̃|�C���g�ֈړ�
                    currentPointIndex--; // �C���f�b�N�X�����炷

                    // �|�C���g�z��̍ŏ��ɓ��B�����ꍇ
                    if (currentPointIndex <= 0)
                    {
                        returnPoint = false; // �ʏ�i�s��Ԃɖ߂�
                    }
                }
            }

            // �ړ����x�x�N�g�����X�V
            myVelocity = (rb.position - oldPosition) / Time.deltaTime;
            oldPosition = rb.position; // �ʒu���X�V
        }
    }
}
