using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        // AudioSource �R���|�[�l���g�̎擾
        audioSource = GetComponent<AudioSource>();
    }

    // �����Đ����郁�\�b�h
    public void PlayStart()
    {
        // ������x�����Đ�
        audioSource.PlayOneShot(audioSource.clip);
    }
}
