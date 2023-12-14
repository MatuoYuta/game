using UnityEngine;

public class Door : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>().HasKey == true)
        {
            // ドアを開く処理をここに追加
            Debug.Log("Door opened!");
            collision.GetComponent<Player>().HasKey = false;
        } else
        {
            Debug.Log("カギがないよ");
        }
    }
}

