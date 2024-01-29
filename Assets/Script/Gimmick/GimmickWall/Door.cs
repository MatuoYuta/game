using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    private Animator anim1;
    private Rigidbody2D rigid;
    private BoxCollider2D col;

    float x;
    float y;
    float waitsecond = 0.05f;

    bool open = false;
    [SerializeField] float testY;
    private void Start()
    {
        x = this.gameObject.transform.position.x;
        y = this.gameObject.transform.position.y;
    }

    void Update()
    {
        if (open)
        {
            //transform.Translate(0, 0.2f, 0);
            
            if (transform.position.y > testY)
            {
                open = false;
            }
        }
        //transform.Translate(0, 0.2f, 0);
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
<<<<<<< HEAD
            // ドアを開く処理をここに追加
            //anim1.SetBool("isOpen", true);
            
            for(int i = 1;i<=10; i++)
            {
                this.gameObject.transform.position = new Vector2(x, y * i);
            }
            
=======
            StartCoroutine("Door_up");
>>>>>>> a652afe5780f8cdf4df0b5445b868f82b3ca4863
            Debug.Log("Door opened!");
            collision.GetComponent<Player>().HasKey = false;

        } else
        {
            Debug.Log("カギがないよ");
        }
    }

    IEnumerator Door_up()
    {
        open = true;
        // ドアを開く処理をここに追加
        //anim1.SetBool("isOpen", true);
        for (int i = 0; i < 10; i++)
        {
            this.gameObject.transform.position = new Vector2(x, y + i);
            yield return new WaitForSeconds(0.1f);
        }
    }
}

