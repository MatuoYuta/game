using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // プレイヤーがカギを取った場合
            other.GetComponent<Player>().HasKey = true;
            Destroy(gameObject); // カギを削除
            Debug.Log(other.GetComponent<Player>().HasKey);
        }
    }
}

