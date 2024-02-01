using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class butterflyFlg : MonoBehaviour
{
    public static bool flg = false;
    public GameObject text;
    [SerializeField] GameObject Text;
    int cnt = 0;
    public GameObject targetObj;

    // Start is called before the first frame update
    void Start()
    {
        Text.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (flg)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                cnt++;
                switch(cnt){
                    case 1:
                        text.GetComponent<TextMeshProUGUI>().text = "Flag OK!";
                        break;
                    case 2: 
                        text.GetComponent<TextMeshProUGUI>().text = "Finish";
                        break;
                    default:
                        Text.gameObject.SetActive(false);
                        break;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("test");
                Text.gameObject.SetActive(true);
                flg = true;
                targetObj.GetComponent<Fade>().Fadeout();
            }
            
        }
    }


}
