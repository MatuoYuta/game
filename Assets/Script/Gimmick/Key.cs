using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // �v���C���[���J�M��������ꍇ
            other.GetComponent<Player>().HasKey = true;
            Destroy(gameObject); // �J�M���폜
            Debug.Log(other.GetComponent<Player>().HasKey);
        }
    }
}

