using UnityEngine;
using UnityEngine.UI;

public class BackgroundMover : MonoBehaviour
{
    private const float k_maxLength = 1f; // テクスチャの最大長さ
    private const string k_propName = "_MainTex"; // テクスチャのプロパティ名

    [SerializeField]
    private Vector2 m_offsetSpeed; // 背景の移動速度の設定

    private Material m_material; // 背景に使用されるマテリアル

    private void Start()
    {
        // Imageコンポーネントがアタッチされている場合、そのマテリアルを使用する
        if (GetComponent<Image>() is Image image)
        {
            m_material = image.material;
        }
    }

    private void Update()
    {
        // マテリアルが設定されている場合のみ処理を行う
        if (m_material)
        {
            // xとyのオフセット値を時間と速度に基づいて計算し、0 ～ 1の範囲でループさせる
            var x = Mathf.Repeat(Time.time * m_offsetSpeed.x, k_maxLength);
            var y = Mathf.Repeat(Time.time * m_offsetSpeed.y, k_maxLength);
            var offset = new Vector2(x, y);

            // マテリアルにオフセットを設定する
            m_material.SetTextureOffset(k_propName, offset);
        }
    }

    private void OnDestroy()
    {
        // ゲームオブジェクトが破棄される際に、マテリアルのオフセットをリセットする
        if (m_material)
        {
            m_material.SetTextureOffset(k_propName, Vector2.zero);
        }
    }
}
