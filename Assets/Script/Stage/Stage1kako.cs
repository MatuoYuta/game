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
            Debug.Log("�N���b�N");
            //Invoke("change_button", 2);
            //change_button();
            // �Q�[�����ĊJ
            /*Time.timeScale = 1f;
            Debug.Log("�{�^��");
            SceneManager.LoadScene("Stage1kako");*/
        }
    }


    void change_button()
    {
        clockani.SetActive(true);
        Debug.Log("�N���b�N");
        Invoke("stage_change", 2);
        Debug.Log("����ځ[��");

    }

    void stage_change()
    {
        // �Q�[�����ĊJ
        Time.timeScale = 1f;
        Debug.Log("�{�^��");
        SceneManager.LoadScene("Stage1kako");
    }
}
