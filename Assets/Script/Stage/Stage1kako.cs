using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1kako : MonoBehaviour
{
    private bool kako;
    private bool mirai;
    private bool ima;

    private Animator _anim;

    [SerializeField] GameObject clockani;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        kako = false;
        mirai = false;
        ima = false;
    }

    private void Update()
    {
        void OnClick()
        {
           
            Debug.Log("クリック");
            //Invoke("change_button", 2);
            //change_button();
            // ゲームを再開
            /*Time.timeScale = 1f;
            Debug.Log("ボタン");
            SceneManager.LoadScene("Stage1kako");*/
        }
    }


    void change_button()
    {
        kako = true;
        clockani.SetActive(true);
        Debug.Log("クリック");
        _anim.SetBool("ClockGyaku", kako);
        Invoke("stage_change", 2);
        Debug.Log("いんぼーく");

    }
    
    void stage_change()
    {
        kako = false;
        // ゲームを再開
        Time.timeScale = 1f;
        Debug.Log("ボタン");
        SceneManager.LoadScene("Stage1kako");
    }
}
