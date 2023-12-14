using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereDrop : MonoBehaviour
{
    public GameObject target;

    bool check = false;
    void Start()
    {

    }
    void Update()
    {
        /*Vector3 cube = target.transform.position;
        float dis = Vector3.Distance(cube, this.transform.position);

        if (dis < 3f)
        {
            SphereGravity();
        }*/
        if (check)
        {
            var rb = GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void SphereGravity()
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

    public void CheckEventHandler(Collider2D collider)
    {
        check = true;
    }

}
