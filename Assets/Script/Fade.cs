using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    // フェードインを行うコルーチン
    IEnumerator Color_FadeIn()
    {
        // 画面をフェードインさせるコルーチン

        // 色を変えるゲームオブジェクトからImageコンポーネントを取得
        Image fade = GetComponent<Image>();

        // フェード元の色を設定（黒）★変更可
        fade.color = new Color(0.0f, 0.0f, 0.0f, 1.0f);

        // フェードインにかかる時間（秒）★変更可
        const float fade_time = 2.0f;

        // ループ回数（0はエラー）★変更可
        const int loop_count = 10;

        // ウェイト時間算出
        float wait_time = fade_time / loop_count;

        // 色の間隔を算出
        float alpha_interval = 1.0f / loop_count;

        // 色を徐々に変えるループ
        for (float alpha = 1.0f; alpha >= 0.0f; alpha -= alpha_interval)
        {
            // 待ち時間
            yield return new WaitForSeconds(wait_time);

            // Alpha値を少しずつ下げる
            fade.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }
    }

    // フェードアウトを行うコルーチン
    IEnumerator Color_FadeOut()
    {
        // 画面をフェードアウトさせるコルーチン

        // 色を変えるゲームオブジェクトからImageコンポーネントを取得
        Image fade = GetComponent<Image>();

        // フェード後の色を設定（黒）★変更可
        fade.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);

        // フェードアウトにかかる時間（秒）★変更可
        const float fade_time = 2.0f;

        // ループ回数（0はエラー）★変更可
        const int loop_count = 10;

        // ウェイト時間算出
        float wait_time = fade_time / loop_count;

        // 色の間隔を算出
        float alpha_interval = 1.0f / loop_count;

        // 色を徐々に変えるループ
        for (float alpha = 0.0f; alpha <= 1.0f; alpha += alpha_interval)
        {
            // 待ち時間
            yield return new WaitForSeconds(wait_time);

            // Alpha値を少しずつ上げる
            fade.color = new Color(0.0f, 0.0f, 0.0f, alpha);
        }

        // シーンをロードする
        SceneManager.LoadScene("Title");
    }

    // フェードアウト処理を開始するメソッド
    public void Fadeout()
    {
        StartCoroutine(Color_FadeOut());
    }
}
