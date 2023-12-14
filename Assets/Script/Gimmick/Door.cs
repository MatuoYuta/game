using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim1;

    private void Awake()
    {
        anim1 = GetComponent<Animator>();
        anim1.SetBool("isOpen", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (anim1.enabled && collision.GetComponent<Player>().HasKey == true)
        {
            // ドアを開く処理をここに追加
            anim1.SetBool("isOpen", true);
            Debug.Log("Door opened!");
            collision.GetComponent<Player>().HasKey = false;
        } else
        {
            Debug.Log("カギがないよ");
        }
    }
}

