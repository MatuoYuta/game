using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stage1kako : MonoBehaviour
{

    [SerializeField] GameObject clockani;

    private void Start()
    {
        clockani.SetActive(false);
    }

    private void Update()
    {
        void OnClick()
        {
            clockani.SetActive(true);
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
        clockani.SetActive(true);
        Debug.Log("クリック");
        Invoke("stage_change", 2);
        Debug.Log("いんぼーく");

    }

    void stage_change()
    {
        // ゲームを再開
        Time.timeScale = 1f;
        Debug.Log("ボタン");
        SceneManager.LoadScene("Stage1kako");
    }
}
