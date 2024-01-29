using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSlip : MonoBehaviour
{
    Vector3 pos;


    // Start is called before the first frame update
    void Start()
    {
        pos.x = 2;
        pos.y = 0;
        pos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Transform myTransform = this.transform;
        if (Input.GetKeyDown(KeyCode.P))
        {
            myTransform.position += pos;
        }
    }
}
