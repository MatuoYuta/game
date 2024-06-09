using UnityEngine;
using UnityEngine.UI;

// 背景音楽の管理を行うスクリプト
public class BgmManager : MonoBehaviour
{
    public Slider slider;       // 音量を調整するためのスライダー
    AudioSource audioSource;    // AudioSourceコンポーネントへの参照

    // 開始時に呼ばれるメソッド
    void Start()
    {
        // AudioSourceコンポーネントを取得する
        audioSource = GetComponent<AudioSource>();

        // スライダーの値が変更されたときに呼ばれるリスナーを登録する
        slider.onValueChanged.AddListener(value => this.audioSource.volume = value);
    }
}
