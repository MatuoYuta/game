using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>().HasKey == true)
        {
            // �h�A���J�������������ɒǉ�
            Debug.Log("Door opened!");
            collision.GetComponent<Player>().HasKey = false;
        } else
        {
            Debug.Log("�J�M���Ȃ���");
        }
    }
}

