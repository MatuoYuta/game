using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropstage : MonoBehaviour
{
    public float fallDelay = 2f; // ������܂ł̑ҋ@����

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Invoke("Fall", fallDelay); // ������܂ł̑ҋ@���Ԍ��Fall���\�b�h���Ăяo��
        }
    }

    private void Fall()
    {
        // Rigidbody���擾���A�d�͂�L���ɂ��ď��𗎂Ƃ�
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
    }
}
