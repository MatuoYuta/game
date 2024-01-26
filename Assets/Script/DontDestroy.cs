using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    // �V���O���g���p�^�[���̂��߂̐ÓI�C���X�^���X
    static public DontDestroy instance = null;

    // ���̃X�N���v�g����A�N�Z�X�\�ȃX�R�A
    [HideInInspector] public int Score = 0;

    void Awake()
    {
        // �V���O���g���p�^�[���̎���
        if (instance == null)
        {
            // �܂��C���X�^���X���ݒ肳��Ă��Ȃ��ꍇ�A���g��ݒ肵�j������Ȃ��悤�ɂ���
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // ���ɃC���X�^���X�����݂���ꍇ�A�V�����������ꂽ�I�u�W�F�N�g��j������
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �^�C�g���V�[���ɖ߂������ɔj������
        if (SceneManager.GetActiveScene().name == "Title")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // �����ɍX�V�R�[�h��ǉ����邱�Ƃ��ł��܂�
    }
}
