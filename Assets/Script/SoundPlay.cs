using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        // AudioSource コンポーネントの取得
        audioSource = GetComponent<AudioSource>();
    }

    // 音を再生するメソッド
    public void PlayStart()
    {
        // 音を一度だけ再生
        audioSource.PlayOneShot(audioSource.clip);
    }
}
