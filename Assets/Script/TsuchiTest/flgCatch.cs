using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flgCatch : MonoBehaviour
{
    [SerializeField] GameObject MenuObject;
    // Start is called before the first frame update
    void Start()
    {
        if (butterflyFlg.flg)
        {
            MenuObject.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
