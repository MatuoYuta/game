using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageChange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            SceneManager.LoadScene("TestTsuchi 1");

        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("TestTsuchi");

        }
    }

    void stagechange()
    {
        SceneManager.LoadScene("TestTsuchi 1");
    }

    
}
