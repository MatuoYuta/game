using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage01 : MonoBehaviour
{
    Vector3 pos;
    public Animator _anim;
    public static bool kako;
    private bool mirai;
    private bool ima;
    Transform myTransform;
    public GameObject targetObj;

    [SerializeField] GameObject clockani;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("clock_A").GetComponent<Animator>();
        pos.x = 0;
        pos.y = 0;
        pos.z = 0;
    }

    // Update is called once per frame
    void Update()
    {

       myTransform = this.transform;
    }

    public void Go_kako()
    {

        kako = true;
        targetObj.GetComponent<Player>().ChangeStage();
        Debug.Log("button");

        Debug.Log("アニメーション" + kako);
        _anim.SetBool("kako", kako);
        
    }

    
}
