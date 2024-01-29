using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim1;
    private Rigidbody2D rigid;
    private BoxCollider2D col;

    float x;
    float y;
    private void Start()
    {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
    }

    private void Awake()
    {
        //anim1 = GetComponent<Animator>();
        //anim1.SetBool("isOpen", false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>().HasKey == true)
        {
            // ドアを開く処理をここに追加
            //anim1.SetBool("isOpen", true);
            
            for(int i = 1;i<=10; i++)
            {
                this.gameObject.transform.position = new Vector2(x, y * i);
            }
            
            Debug.Log("Door opened!");
            collision.GetComponent<Player>().HasKey = false;

        } else
        {
            Debug.Log("カギがないよ");
        }
    }
}

